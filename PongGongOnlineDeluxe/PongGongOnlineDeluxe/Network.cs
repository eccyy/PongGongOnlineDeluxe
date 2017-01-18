using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace PongGongOnlineDeluxe
{


    /* Denna klass ska ta hand om kommunikationen mellan de två spelarna
     * Spelarna kommer överens över vem som tar hand om en server(om inte båda behöver ha en server)    
     * Ska finnas flera metoder för att skicka och ta emot olika sorters data      
     */

    class Network
    {
       



NetPeerConfiguration netconfig;
        
        NetServer server;
        NetClient client;

        public string text;

    

        
        string hostIp;

       public object data;



        public Network(string serverIdentifier)
        {
            // serverIdentifier som argument är som en sorts identifier så att man vet att spelarna kopplar upp rätt. Båda klienterna måste använda samma identifier

            netconfig = new NetPeerConfiguration(serverIdentifier);
            netconfig.Port = 1337;
            netconfig.EnableMessageType(NetIncomingMessageType.Data);
            


            client = new NetClient(netconfig);
            // lägga till exception hantering
           
                       
        }



        public bool startServer()
        {
            try
            {
                server = new NetServer(netconfig);
                server.Start();
                if (server.Status == NetPeerStatus.Running)
                {
                    return true;
                }
                else
                    return false;                   
               

            }
            catch(Exception e)
            {
                return false;
            }           
            
        }

        bool closeServer()
        {
            return false;
        }
      
       public bool startClient()
        {
            client.Start();

            while(client.Status != NetPeerStatus.Running)
            {
               
            }
            return true;
            
        }

        bool stopClient()
        {
            return false;
        }

      public bool connectServer(string hostIp){

            try
            {

                client.Connect(host: hostIp, port: 1337);

                while(client.ConnectionStatus != NetConnectionStatus.Connected)
                {
                    if(client.ConnectionsCount > 0)
                    {
                        return true;
                    }
                }
                return false;


            }
            catch(Exception e)
            {

                return false;
            }


           
        }


      public void sendString(string message)
        {
            var messageToSend = client.CreateMessage();

            messageToSend.Write(message);
            
            client.SendMessage(messageToSend, NetDeliveryMethod.ReliableOrdered);
            
            
        }


        // SKRIV DET SJÄLV SEDAN
        private void messageLoop()
        {
           NetIncomingMessage message;
            
            while ((message = server.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        // handle custom messages
                        // här ska datan tas emot och delas ut till de programm som behöver datan /Kallade datan.
                        // ska ta emot alla datatyper och returnera sedan



                       text = message.ReadString();
                       
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        // handle connection status messages
                        switch (message.SenderConnection.Status)
                        {
                            /* .. */
                        }
                        break;

                    case NetIncomingMessageType.DebugMessage:
                        // handle debug messages
                        // (only received when compiled in DEBUG mode)
                        Console.WriteLine(message.ReadString());
                        break;

                    /* .. */
                    default:
                        Console.WriteLine("unhandled message with type: "
                            + message.MessageType);
                        break;
                }

                
            }
        }

           

    }
}
