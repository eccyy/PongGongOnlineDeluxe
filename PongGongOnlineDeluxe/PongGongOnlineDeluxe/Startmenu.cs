using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongGongOnlineDeluxe
{
    public partial class Startmenu : Form
    {
        Network network;


        public Startmenu()
        {
            InitializeComponent();
        }

        private void btnServerHost_Click(object sender, EventArgs e)
        {
            if(tbxServerName.Text.Length  > 0){

                try
                {
                    // gör ett nytt objekt och server
                    network = new Network(tbxServerName.Text);

                    if (network.startServer() == true)
                    {
                        MessageBox.Show("success");
                    }
                    else
                    {
                        MessageBox.Show("Server start failed");
                    }
                       
                   
                  
                }
                catch(Exception connectException)
                {
                    MessageBox.Show("an error occured: " + connectException.Message);
                }
            

            }
        }

        
        
        private bool join()
        {
            if (tbxIpAdress.Text.Length > 6)
            {

                network = new Network(tbxServerName.Text);
                if ( network.connectServer(tbxIpAdress.Text.ToString()) == true)
                {
                    MessageBox.Show("success connected");
                }

                return true;
            }
            else return false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (network.startClient() == true)
            {
                join();
            }
            
        }

        private void tbxStartTetris_Click(object sender, EventArgs e)
        {
            Game1 tetris = new Game1();
            tetris.Run();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {

            network.sendString("dadido");
            
            MessageBox.Show("message is " + network.text);

        }
    }
}
