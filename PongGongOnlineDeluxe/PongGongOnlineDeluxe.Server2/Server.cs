using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongGongOnlineDeluxe.Library2;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PongGongOnlineDeluxe.Server2
{
    class Server
    {
        private static List<Player> players;
        private NetPeerConfiguration config;
        private NetServer server;

        public Server()
        {
            players = new List<Player>();
            config = new NetPeerConfiguration("networkGame") { Port = 1337 };
            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            server = new NetServer(config);
        }

        public void Run()
        {
            server.Start();
            Console.WriteLine("Server started...");
            while (true)
            {
                NetIncomingMessage inc;
                if ((inc = server.ReadMessage()) == null) continue;

                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.StatusChanged:
                        break;
                    //Checks if joining player has login approval
                    case NetIncomingMessageType.ConnectionApproval:
                        ConnectionApproval(inc);
                        break;
                    case NetIncomingMessageType.Data:
                        Data(inc);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
        }

        private void Data(NetIncomingMessage inc)
        {
            var packetType = (PacketType)inc.ReadByte();

            switch (packetType)
            {
                case PacketType.Input:
                    Input(inc);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        private void Input(NetIncomingMessage inc)
        {
            Console.WriteLine("Recieved new input");
            var key = (Keys)inc.ReadByte();
            var name = inc.ReadString();
            var player = players.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                Console.WriteLine("Could not find player with name {0}", name);
                return;
            }
            switch (key)
            {
                case Keys.Down:
                    player.YPosition += 1;
                    break;
                case Keys.Up:
                    player.YPosition -= 1;
                    break;
                case Keys.Left:
                    player.XPosition -= 1;
                    break;
                case Keys.Right:
                    player.XPosition += 1;
                    break;
            }
            SendPlayerPosition(player, inc);
        }

        private void ConnectionApproval(NetIncomingMessage inc)
        {
            Console.WriteLine("New connection...");
            var data = inc.ReadByte();
            if (data == (byte)PacketType.Login)
            {
                Console.WriteLine("..connection accpeted.");
                var player = CreatePlayer(inc);
                inc.SenderConnection.Approve();
                var outmsg = server.CreateMessage();
                outmsg.Write((byte)PacketType.Login);
                System.Threading.Thread.Sleep(1000);
                outmsg.Write(true);
                outmsg.Write(players.Count);
                for (int n = 0; n < players.Count; n++)
                {
                    outmsg.WriteAllProperties(players[n]);
                }
                server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                SendPlayerPosition(player, inc);
            }
            else
            {
                inc.SenderConnection.Deny("Diddn't send correct information");
            }
        }

        private Player CreatePlayer(NetIncomingMessage inc)
        {
            var random = new Random();
            var player = new Player
            {
                Connection = inc.SenderConnection,
                Name = inc.ReadString(),
                XPosition = random.Next(0, 300),
                YPosition = random.Next(0, 420)
            };
            players.Add(player);
            return player;
        }

        private void SendPlayerPosition(Player player, NetIncomingMessage inc)
        {
            Console.WriteLine("Sending out new player position");
            var outmessage = server.CreateMessage();
            outmessage.Write((byte)PacketType.PlayerPosition);
            outmessage.WriteAllProperties(player);
            server.SendToAll(outmessage, NetDeliveryMethod.ReliableOrdered);
        }

        private void SendFullPlayerList()
        {
            Console.WriteLine("Sending out full player list");
            var outmessage = server.CreateMessage();
            outmessage.Write((byte)PacketType.AllPlayers);
            outmessage.Write(players.Count);
            foreach (var player in players)
            {
                outmessage.WriteAllProperties(player);
            }
            server.SendToAll(outmessage, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
