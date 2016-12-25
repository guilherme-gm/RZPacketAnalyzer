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
    class ClientGameController : IController
    {
        public ClientGameController() { }

        public void ProcessRequest(Session session, byte[] data)
        {
            RequestParser.Parse(RequestType.ClientGame, data);
            Main.AuthSocket.SendPacket(Main.Auth, data);
        }
    }
}
