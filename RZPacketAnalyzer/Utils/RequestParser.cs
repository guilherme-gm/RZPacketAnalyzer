using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using RZPacketAnalyzer.DataClasses;
using System.Windows.Forms;
using RZPacketAnalyzer.UI;

namespace RZPacketAnalyzer.Utils
{
    public enum RequestType
    {
        ClientAuth,
        AuthClient,
        ClientGame,
        GameClient
    }

    public static class RequestParser
    {
        public static Dictionary<int, PacketStruct> ClientAuthPackets;
        public static Dictionary<int, PacketStruct> AuthClientPackets;
        public static Dictionary<int, PacketStruct> ClientGamePackets;
        public static Dictionary<int, PacketStruct> GameClientPackets;

        public static void Load()
        {
            ClientAuthPackets = new Dictionary<int, PacketStruct>();
            AuthClientPackets = new Dictionary<int, PacketStruct>();
            ClientGamePackets = new Dictionary<int, PacketStruct>();
            GameClientPackets = new Dictionary<int, PacketStruct>();

            ParsePacketStructFile("Data/Packets/CA.json", ClientAuthPackets);
            ParsePacketStructFile("Data/Packets/AC.json", AuthClientPackets);
            ParsePacketStructFile("Data/Packets/CG.json", ClientAuthPackets);
            ParsePacketStructFile("Data/Packets/GC.json", GameClientPackets);
        }

        private static void ParsePacketStructFile(string file, Dictionary<int, PacketStruct> dict)
        {
            Dictionary<string, JObject> packetList;
            string json;
            JObject main;

            json = File.ReadAllText(file);
            main = JObject.Parse(json);
            packetList = main.ToObject<Dictionary<string, JObject>>();

            foreach (string id in packetList.Keys)
            {
                int packetId = (int)new System.ComponentModel.Int32Converter().ConvertFromString(id);
                PacketStruct structInfo = ParsePacketStruct(packetList[id]);

                dict.Add(packetId, structInfo);
            }
        }

        private static PacketStruct ParsePacketStruct(JObject structInfo)
        {
            PacketStruct info = new PacketStruct();
            List<JObject> structItems = new List<JObject>();

            info.Name = (string)structInfo.GetValue("name");

            structItems = structInfo.GetValue("struct").ToObject<List<JObject>>();

            foreach (JObject strItem in structItems)
            {
                StructItem item = new StructItem();

                item.Name = strItem.GetValue("name").ToString();
                string type = strItem.GetValue("type").ToString();
                switch (type)
                {
                    case "byte": item._Type = StructItemType.Byte; break;
                    case "sbyte": item._Type = StructItemType.SByte; break;
                    case "ushort": item._Type = StructItemType.UInt16; break;
                    case "short": item._Type = StructItemType.Int16; break;
                    case "uint": item._Type = StructItemType.UInt32; break;
                    case "int": item._Type = StructItemType.Int32; break;
                    case "ulong": item._Type = StructItemType.UInt64; break;
                    case "long": item._Type = StructItemType.Int64; break;
                    case "string": item._Type = StructItemType.String; break;
                    case "struct": item._Type = StructItemType.Struct; break;
                    default: MessageBox.Show(string.Format("Invalid {0} type", type)); continue;
                }

                JToken rewrite;
                if (strItem.TryGetValue("@rewrite", out rewrite))
                {
                    item.HasRewrite = true;
                    if (rewrite.ToString().StartsWith("$@"))
                    {
                        item.Rewrite = Settings.Variables[rewrite.ToString().Substring(2)];
                    }
                    else
                    {
                        item.Rewrite = rewrite.ToString();
                    }
                }

                string[] paramList = StructItem.GetParameterByType(item._Type);
                foreach(string par in paramList)
                {
                    item.Parameters.Add(par, strItem.GetValue(par).ToString());
                }

                info.Struct.Add(item);
            }

            return info;
        }

        public static void Parse(RequestType type, byte[] data)
        {
            PacketInfo info = new PacketInfo();
            info.Data = data;
            info._Type = type;

            MemoryStream stream = new MemoryStream(data);

            using (BinaryReader reader = new BinaryReader(stream))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {

                    int length = reader.ReadInt32();
                    ushort packetId = reader.ReadUInt16();
                    reader.ReadByte(); // checksum

                    info.PacketId = packetId;

                    if (type == RequestType.ClientAuth)
                    {
                        PacketStruct str;
                        if (ClientAuthPackets.TryGetValue(packetId, out str))
                        {
                            info.Name = str.Name;
                            info.Struct = ParseStruct(str.Struct, reader, writer);
                        }
                    }
                }
            }

            Main.OnPacketReceive(info);
        }

        private static string ParseStruct(List<StructItem> structInfo, BinaryReader reader, BinaryWriter writer)
        {
            StringBuilder str = new StringBuilder();

            foreach(StructItem item in structInfo)
            {
                str.Append(item.Parse(reader, writer));
            }

            return str.ToString();
        }
    }
}
