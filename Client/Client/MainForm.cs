using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        private TcpClient tcp;
        private Stream stm;
        private byte[] dataIn;
        private byte[] dataOut;

        private String id = "";
        private bool isNewRound = false;

        public MainForm()
        {
            InitializeComponent();

            dataIn = new byte[100];
            dataOut = new byte[100];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            InitClient();

            Thread t = new Thread(Listener);
            t.Start();
        }

        private void InitClient()
        {
            // Create client
            tcp = new TcpClient();
            // get ip address
            String ip = tbIPAddress.Text;
            // get port number
            int port = int.Parse(tbPort.Text);
            // start connection
            tcp.Connect(ip, port);
            // set stream for this client
            stm = tcp.GetStream();
        }

        /******** Receive data ********/
        private void Listener(object obj)
        {
            while (true)
            {
                try
                {                   
                    // get message from server
                    int k = stm.Read(dataIn, 0, 100);

                    char[] c = new char[k];

                    // fill each character of message
                    for (int i = 0; i < k; i++)
                        c[i] = Convert.ToChar(dataIn[i]);

                    String message = new String(c);

                    /**** TO DO ****/
                    Process(message);
                }
                catch
                {
                    break;
                }
            }
        }

        private void Process(String str)
        {
            String[] content = str.Split(':');

            // set id for this client
            if (content[0] == "ID")
            {
                id = content[1];

                MessageBox.Show(id);
            }
            else if (content[0] == "New")
            {
                /**** Reset to ready for the next turn ****/
                tbMine.Text = "";
                tbOp.Text = "";
            }
            else if (content[0] == "Total")
            {
                int total = Convert.ToInt16(tbMoney.Text) + Convert.ToInt16(content[1]);
                tbMoney.Text = Convert.ToString(total);

                // 0$ that mine this client cannot continue the game
                if (total == 0)
                    btPlay.Enabled = false;
            }
            else if (content[0] == "Wait")
            {
                btPlay.Enabled = false;
            }
            else if (content[0] == "Continue")
            {
                btPlay.Enabled = true;
            }
            else if (content[0] == id)
            {
                tbMine.Text = content[1];
            }
            else
                tbOp.Text = content[1];
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            Send_Message(id + ":T");
        }

        /// <summary>
        /// Send data with request that server receive and process this,
        /// after that server auto send the result to this client.
        /// </summary>
        /// <param name="str">data in string type</param>
        private void Send_Message(String str)
        {
            try
            {
                // Create buffer
                

                // Encode the message to byte[]
                ASCIIEncoding asen = new ASCIIEncoding();
                dataOut = asen.GetBytes(str);

                // Send the request to server
                stm.Write(dataOut, 0, dataOut.Length);
            }
            catch
            {
                MessageBox.Show("Cannot send the requirement!");
            }

        }
    }
}
