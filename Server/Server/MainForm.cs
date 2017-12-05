using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class MainForm : Form
    {
        // Constant
        private int rootID = 3600;

        private TcpListener server;
        private Socket[] socket = new Socket[10];
        private IPAddress ipAd;
        private int port;
        private int counter = 0;
        private byte[] dataIn = new byte[10];
        private byte[] dataOut;

        // Game structure
        private int[] gameBuff = new int[2];
        private int gameCounter = 0;

        //
        private int[] id = new int[100];

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            InitServer();

            /* This thread is always listen the request to connect to server from clients*/
            Thread t = new Thread(SetConnection);
            t.Start();
        }

        private void InitServer()
        {
            try
            {
                // get ip address
                ipAd = IPAddress.Parse(tbIPAddress.Text);
                // get port
                port = int.Parse(tbPort.Text);

                // set server
                server = new TcpListener(ipAd, port);

                // start server
                server.Start();
            }
            catch
            {
                //MessageBox.Show("Cannot init server!");
            }

        }

        private void SetConnection(object obj)
        {
            while (true)
            {
                try
                {
                    // Set connection to client
                    socket[counter] = server.AcceptSocket();
                    // get ip of client which've just connected to server
                    String str = socket[counter].RemoteEndPoint.ToString();
                    str += " is connected." + Environment.NewLine;

                    // Show this str to textbox to show that having a client is connected
                    tbConnect.AppendText(str);

                    /* Set the thread that always listen the data from client with thí index*/
                    Thread t = new Thread(Listener);
                    t.Start(counter);

                    /* Message the client that the connection is successful */
                    MessageConnected(rootID + counter + 1, counter);

                    id[counter] = rootID + counter + 1;

                    /* Set connection for the next client*/
                    counter++;
                }
                catch
                {
                    break;
                }
            }
        }

        private void MessageConnected(int id, int index)
        {
            String str = "ID:" + id;

            SendDataToClient(str, index);

            // If this is the first client
            if (counter < 1)
            {
                SendDataToClient("Wait", counter);
            }
            else // the other
            {
                SendDataToClient("Wait", counter);

                Thread.Sleep(1000);

                SendDataToClient("Continue", counter - 1);
            }
        }

        private void SendDataToClient(String str, int index)
        {
            /* Send the result to the client*/
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();

                // put to buffer
                dataOut = asen.GetBytes(str.ToString());

                // send result to client
                socket[index].Send(dataOut);
            }
            catch
            {

            }
        }

        private void SendDataToAll(String message)
        {
            for (int i = 0; i < counter; i++)
            {
                SendDataToClient(message, i);
            }
        }

        private void Listener(object obj)
        {
            while (true)
            {
                int index = (int)obj;

                try
                {
                    //dataIn = new byte[100];

                    // Get message from client
                    // k: length of message
                    int k = socket[index].Receive(dataIn);

                    /* If client disconnect to server */
                    if (k == 0)
                        return;

                    // Create buffer
                    char[] c = new char[k];

                    // Transfer the message to string
                    // Fill buffer
                    for (int i = 0; i < k; i++)
                        c[i] = Convert.ToChar(dataIn[i]);

                    String message = new String(c);

                    String str1 = socket[index].RemoteEndPoint.ToString();
                    str1 += ": " + message + Environment.NewLine;

                    /**** TO DO ****/
                    /* solve and send the result to client */
                    Process(message, index);
                }
                catch
                {
                    //break;
                }
            }
        }

        private void Process(String message, int index)
        {
            // Get request from client
            String[] content = message.Split(':');
            int result = 0;

            // If request = "T" that mine start the game
            if (content[1] == "T")
                result = VirtualResult();

            gameBuff[gameCounter] = result;

            // Ready fpr next turn
            gameCounter++;

            String temp = content[0] + ":" + result;

            // Turn off this
            SendDataToClient("Wait", index);

            // 
            Thread.Sleep(1500);

            SendDataToAll(temp);

            // The turn for the other
            SendDataToClient("Continue", index + 1);

            // if end of 2 turn
            if (gameCounter > 1)
                CalculateWhoWin();
        }

        private void CalculateWhoWin()
        {
            int a = gameBuff[0];
            int b = gameBuff[1];

            // Who win
            if (a > b)
            {
                SendDataToClient("Total:" + "+100", 0);
                SendDataToClient("Total:" + "-100", 1);
            }
            else if (a < b)
            {
                SendDataToClient("Total:" + "-100", 0);
                SendDataToClient("Total:" + "+100", 1);
            }
            else
            {
                SendDataToAll("Total:" + "+0");
            }

            /**** Reset ****/
            gameBuff = new int[2];
            gameCounter = 0;

            // 3 seconds
            Thread.Sleep(3000);

            SendDataToAll("New");
            SendDataToClient("Continue", 0);
        }

        int k = 0;
        private void btPlay_Click(object sender, EventArgs e)
        {
            Process(rootID + k + 1 + ":T", k);
            k++;
        }    

        private int VirtualResult()
        {
            // Virtual the result of XX
            Random ran = new Random();

            int temp = ran.Next(1, 6);

            return temp;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SendDataToAll(tbSend.Text);
        }
    }
}
