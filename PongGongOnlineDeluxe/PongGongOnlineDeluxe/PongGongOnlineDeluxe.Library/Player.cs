using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
namespace PongGongOnlineDeluxe.Library
{
    public class Player
    {
        public string Name { get; set; }

        public NetConnection Connection { get; set; }

        public int YPosition { get; set; }

        public Player(string name, int yPosition)
        {
            Name = name;
            YPosition = yPosition;
        }
        public Player()
        {

        }
    }
}
