using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;

namespace PongGongOnlineDeluxe.Library2
{
    public class Player
    {
        public string Name { get; set; }

        public NetConnection Connection { get; set; }

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public Player(string name, int xPosition, int yPosition)
        {
            Name = name;
            XPosition = xPosition;
            YPosition = yPosition;
        }
        public Player()
        {

        }
    }
}
