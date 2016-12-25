using RZPacketAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZPacketAnalyzer
{
    public static class Settings
    {
        public static string ClientIp;
        public static string ClientPort;
        public static string AuthIp;
        public static string AuthPort;
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();

        public static void Load()
        {
            SettingsReader reader = new SettingsReader();
            reader.LoadSettings("settings.json");

            ClientIp = reader.ReadString("client_ip", "127.0.0.1", false);
            ClientPort = reader.ReadString("client_port", "8840", false);
            AuthIp = reader.ReadString("auth_ip", "127.0.0.1", false);
            AuthPort = reader.ReadString("auth_port", "8842", false);
            Variables = (Dictionary<string, string>)reader.ReadObject("custom", typeof(Dictionary<string, string>));

            return;
        }
    }
}
