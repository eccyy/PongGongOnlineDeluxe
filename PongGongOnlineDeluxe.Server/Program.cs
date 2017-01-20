using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using PongGongOnlineDeluxe.Library;

namespace PongGongOnlineDeluxe.Server
{
    class Program
    {
        private static List<Player> players;

        static void Main(string[] args)
        {
            players = new List<Player>();
            var config = new NetPeerConfiguration("networkGame") { Port = 1337 };
            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            var server = new NetServer(config);
            server.Start();
            Console.WriteLine("Server started..");
            while(true)
            {
                NetIncomingMessage inc;
                if((inc = server.ReadMessage()) == null) continue;
                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.Error:
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        //Happens when the status is changed, ex, connected
                        var outmsg = server.CreateMessage();
                        outmsg.Write((byte)PacketType.Login);
                        outmsg.Write(true);
                        var player = CreatePlayer(inc);
                        outmsg.Write(player.YPosition);
                        server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                        break;
                    case NetIncomingMessageType.UnconnectedData:
                        break;
                    case NetIncomingMessageType.ConnectionApproval:
                        Console.WriteLine("New connection...");
                        var data = inc.ReadByte();
                        if (data == (byte)PacketType.Login)
                        {
                            Console.WriteLine("..connection accepted");
                            inc.SenderConnection.Approve();
                        }
                        else
                        {
                            inc.SenderConnection.Deny("Diddn't send correct information");
                        }
                        break;
                    case NetIncomingMessageType.Data:
                        break;
                    case NetIncomingMessageType.Receipt:
                        break;
                    case NetIncomingMessageType.DiscoveryRequest:
                        break;
                    case NetIncomingMessageType.DiscoveryResponse:
                        break;
                    case NetIncomingMessageType.VerboseDebugMessage:
                        break;
                    case NetIncomingMessageType.DebugMessage:
                        break;
                    case NetIncomingMessageType.WarningMessage:
                        break;
                    case NetIncomingMessageType.ErrorMessage:
                        break;
                    case NetIncomingMessageType.NatIntroductionSuccess:
                        break;
                    case NetIncomingMessageType.ConnectionLatencyUpdated:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
            
        }
        private static Player CreatePlayer(NetIncomingMessage inc)
        {
            var random = new Random();
            var player = new Player
            {
                Connection = inc.SenderConnection,
                Name = inc.ReadString(),
                YPosition = random.Next(0, 420)
            };
            players.Add(player);
            return player;
        }

        //comment
    }
}
