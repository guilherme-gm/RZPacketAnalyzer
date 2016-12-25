using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZPacketAnalyzer.DataClasses
{
    public enum StructItemType
    {
        Byte,
        SByte,
        UInt16,
        Int16,
        UInt32,
        Int32,
        UInt64,
        Int64,
        String,
        Struct
    }

    public class StructItem
    {
        public string Name { get; set; }
        public StructItemType _Type { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public bool HasRewrite { get; set; }
        public string Rewrite { get; set; }

        public StructItem()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        public static string[] GetParameterByType(StructItemType type)
        {
            switch (type)
            {
                case StructItemType.Byte:
                case StructItemType.SByte:
                case StructItemType.UInt16:
                case StructItemType.Int16:
                case StructItemType.UInt32:
                case StructItemType.Int32:
                case StructItemType.UInt64:
                case StructItemType.Int64:
                    return new string[0];

                case StructItemType.String:
                    return new string[]
                    {
                        "size"
                    };
                case StructItemType.Struct:
                    return new string[]
                    {
                        "name"
                    };
            }

            return new string[0];
        }

        internal string Parse(BinaryReader reader, BinaryWriter writer)
        {
            string typeName = "";
            string value = "";
            
            switch (this._Type)
            {
                case StructItemType.Byte:
                    typeName = "byte";
                    value = reader.ReadByte().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(byte), SeekOrigin.Current);
                        writer.Write(byte.Parse(Rewrite));
                    }
                    break;

                case StructItemType.SByte:
                    typeName = "sbyte";
                    value = reader.ReadSByte().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(sbyte), SeekOrigin.Current);
                        writer.Write(sbyte.Parse(Rewrite));
                    }
                    break;
                    
                case StructItemType.UInt16:
                    typeName = "ushort";
                    value = reader.ReadUInt16().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(ushort), SeekOrigin.Current);
                        writer.Write(ushort.Parse(Rewrite));
                    }
                    break;

                case StructItemType.Int16:
                    typeName = "short";
                    value = reader.ReadInt16().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(short), SeekOrigin.Current);
                        writer.Write(short.Parse(Rewrite));
                    }
                    break;

                case StructItemType.UInt32:
                    typeName = "uint";
                    value = reader.ReadUInt32().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(uint), SeekOrigin.Current);
                        writer.Write(uint.Parse(Rewrite));
                    }
                    break;

                case StructItemType.Int32:
                    typeName = "int32";
                    value = reader.ReadInt32().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(int), SeekOrigin.Current);
                        writer.Write(int.Parse(Rewrite));
                    }
                    break;

                case StructItemType.UInt64:
                    typeName = "ulong";
                    value = reader.ReadUInt64().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(ulong), SeekOrigin.Current);
                        writer.Write(ulong.Parse(Rewrite));
                    }
                    break;

                case StructItemType.Int64:
                    typeName = "long";
                    value = reader.ReadInt64().ToString();
                    if (HasRewrite)
                    {
                        writer.Seek(-sizeof(long), SeekOrigin.Current);
                        writer.Write(long.Parse(Rewrite));
                    }
                    break;


                case StructItemType.String:
                    {
                        int size = int.Parse(this.Parameters["size"]);
                        typeName = "string(" + size + ")";
                        value = Encoding.UTF8.GetString(reader.ReadBytes(size)).TrimEnd('\0');
                        if (HasRewrite)
                        {
                            writer.Seek(-size, SeekOrigin.Current);
                            writer.Write(Encoding.UTF8.GetBytes(Rewrite));
                            writer.Write(new byte[size - Rewrite.Length]);
                        }
                    }
                    break;

                case StructItemType.Struct:
                    typeName = "Struct";
                    value = "TODO";
                    break;
            }

            return string.Format("{0} {1} = {2};\n", typeName, this.Name, value);
        }
    }
}
