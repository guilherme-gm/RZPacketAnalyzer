using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZPacketAnalyzer.DataClasses
{
    public class CustomSettings
    {
        public Dictionary<string, string> Settings { get; set; }

        public CustomSettings()
        {
            this.Settings = new Dictionary<string, string>(10);
        }

    }
}
