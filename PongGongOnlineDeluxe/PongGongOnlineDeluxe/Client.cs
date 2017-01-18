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

        NetConnection connection;

        string serverIp;

        public Client()
        {
            netconfig = new NetPeerConfiguration("abc");
            netconfig.Port = 1337;
            netconfig.EnableMessageType(NetIncomingMessageType.Data);
            netconfig.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            netconfig.EnableMessageType(NetIncomingMessageType.ConnectionLatencyUpdated);

            client = new NetClient(netconfig);             
                            
        }

        public bool startClient()
        {
            client.Start();

            if (client.Status == NetPeerStatus.Running)            
                return true;            
            else
                return false;

        }

        public bool connectToServer(string ip, string serverIdentifier)
        {
            try
            {
                                
                client.Connect(host: serverIp, port: 1337);


                while (client.ConnectionStatus != NetConnectionStatus.Connected)
                {
                    if (client.ConnectionsCount > 0)
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception e)
            {
                return false;
            }            
        }

        public bool sendMessage(string message)
        {

            var messageToSend = client.CreateMessage();
            messageToSend.Write(message);

            if (client.SendMessage(messageToSend, NetDeliveryMethod.ReliableOrdered) == NetSendResult.Sent)            
                return true;
            else                               
                return false;
        }


       
    }
}
