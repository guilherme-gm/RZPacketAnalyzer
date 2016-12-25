using Common.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using RZPacketAnalyzer.UI;
using Common.RC4;

namespace RZPacketAnalyzer.DataClasses
{
    public class AuthFactory : SessionFactory
    {
        public const string RC4Key = "}h79q~B%al;k'y $E";

        public override Session CreateSession(Socket socket)
        {
            Session s = new Session();
            s._NetworkData = new NetworkData(socket);
            s._NetworkData.InCipher = new XRC4Cipher(RC4Key);
            s._NetworkData.OutCipher = new XRC4Cipher(RC4Key);

            Main.Auth = s;
            return s;
        }
    }
}
