using System.Windows.Forms;
using System;

namespace PongGongOnlineDeluxe
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Startmenu());
        }
    }
#endif
}
