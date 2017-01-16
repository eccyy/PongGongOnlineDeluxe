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
                    network = new Network(tbxServerName.Text);
                    network.startServer();
                    network.connectServer("127.0.0.1");
                    MessageBox.Show("success");
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

              if( network.connectServer(tbxIpAdress.Text.ToString()) == true)
                {
                    MessageBox.Show("success connected");
                }

                return true;
            }
            else return false;
            
        }
    }
}
