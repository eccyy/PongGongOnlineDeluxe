using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using PongGongOnlineDeluxe.Library2;

namespace PongGongOnlineDeluxe.Server2
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            server.Run();
        }
    }
}
