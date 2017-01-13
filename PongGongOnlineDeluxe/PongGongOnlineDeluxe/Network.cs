using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace PongGongOnlineDeluxe
{




    class Network
    {



        NetPeerConfiguration netconfig;
        
        NetServer server;
        NetClient client;

        NetIncomingMessage msgRecieve;
        NetOutgoingMessage msgSend;



        public Network(string serverIdentifier)
        {
            // netpiercconfiguration argumentet är som en sorts identifier så att man vet att spelarna kopplar upp rätt. Båda klienterna måste använda samma identifier
            

            netconfig = new NetPeerConfiguration(serverIdentifier);
            netconfig.Port = 1337;
            netconfig.EnableMessageType(NetIncomingMessageType.Data);

            server = new NetServer(netconfig);
        }

        void startServer()
        {
            server = new NetServer(netconfig);
        }

        void closeServer()
        {
           
        }


        bool send(string message)
        {
            return false;
        }
           

    }
}
