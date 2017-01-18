using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;

namespace PongGongOnlineDeluxe
{
  

    class Client
    {


        NetClient client;


        NetPeerConfiguration netconfig;
        NetIncomingMessage msgRecieve;
        NetOutgoingMessage msgSend;

        string serverIp;

        public Client()
        {
            netconfig = new NetPeerConfiguration("abc");
            netconfig.Port = 1337;
            netconfig.EnableMessageType(NetIncomingMessageType.Data);


            client = new NetClient(netconfig);
        // lägga till exception hantering
            client.Start();

        }


       
    }
}
