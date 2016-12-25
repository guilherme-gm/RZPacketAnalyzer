using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZPacketAnalyzer.DataClasses
{
    public class PacketStruct
    {
        public string Name { get; set; }
        public List<StructItem> Struct { get; set; }

        public PacketStruct()
        {
            this.Struct = new List<StructItem>();
        }
    }
}
