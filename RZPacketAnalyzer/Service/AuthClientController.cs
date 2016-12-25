using Common.DataClasses;
using Common.Service;
using RZPacketAnalyzer.UI;
using RZPacketAnalyzer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZPacketAnalyzer.Service
{
    public class AuthClientController : IController
    {
        public AuthClientController() { }

        public void ProcessRequest(Session session, byte[] data)
        {
            RequestParser.Parse(RequestType.AuthClient, data);
            Main.ClientSocket.SendPacket(Main.Client, data);
        }
    }
}
