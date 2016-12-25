using RZPacketAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZPacketAnalyzer.DataClasses
{
    public class PacketInfo
    {
        public RequestType _Type { get; set; }
        public ushort PacketId { get; set; }
        public string Name { get; set; }
        public string Struct { get; set; }
        public byte[] Data { get; set; }

        public PacketInfo()
        {

        }
    }
}
