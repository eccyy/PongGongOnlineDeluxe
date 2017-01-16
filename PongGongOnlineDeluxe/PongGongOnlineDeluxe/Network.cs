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

        NetIncomingMessage msgRecieve;
        NetOutgoingMessage msgSend;

        string hostIp;



        public Network(string serverIdentifier)
        {
            // serverIdentifier som argument är som en sorts identifier så att man vet att spelarna kopplar upp rätt. Båda klienterna måste använda samma identifier

            netconfig = new NetPeerConfiguration(serverIdentifier);
            netconfig.Port = 1337;
            netconfig.EnableMessageType(NetIncomingMessageType.Data);


            client = new NetClient(netconfig);
            client.Start();
                       
        }



        public bool startServer()
        {
            try
            {
                server = new NetServer(netconfig);
                server.Start();

                return true;

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
      

        bool stopClient()
        {
            return false;
        }

      public bool connectServer(string hostIp){

            try
            {
                client.Connect(host: hostIp, port: 1337);
                return true;

            }
            catch(Exception e)
            {

                return false;
            }


           
        }


        bool sendString(string message)
        {
            return false;
        }

           

    }
}
