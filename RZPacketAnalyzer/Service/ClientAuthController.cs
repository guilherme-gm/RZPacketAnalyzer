using Common.DataClasses;
using Common.DataClasses.Network;
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
    public class ClientAuthController : IController
    {
        public ClientAuthController() { }

        public void ProcessRequest(Session session, byte[] data)
        {
            RequestParser.Parse(RequestType.ClientAuth, data);
            Main.AuthSocket.SendPacket(Main.Auth, data);
        }
    }
}
