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

namespace Chat_application_with_windows_forms
{
  
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
        TcpClient tcpClient;
        NetworkStream networkStream;
        BackgroundWorker backgroundWorker;
        int port = 8080;
        Dictionary<string, string> messages = new Dictionary<string,string>();
        List<Message> messagesList = new List<Message>();
        public Form1()
        {
          
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += this.receiveMessagesWorker;
            backgroundWorker.RunWorkerCompleted += this.backGroundWorkerCOmpleted;

            backgroundWorker.RunWorkerAsync();
            InitializeComponent();
        }
        private void receiveMessagesWorker(object sender, DoWorkEventArgs args)
        {

            tcpClient = tcpListener.AcceptTcpClient();
           
            IPEndPoint remoteIpEndPoint = (IPEndPoint) tcpClient.Client.RemoteEndPoint;
            string ip = remoteIpEndPoint.Address.ToString();
            NetworkStream networkStreamLocal = tcpClient.GetStream();
            string message = readMessage(networkStreamLocal);
            if (message != null)
            {
                Console.WriteLine("Received: {0} from IP : {1}", message, ip);
                messagesList.Add(new Message(ip, message));
                groupBox1.Invoke((MethodInvoker)(() => showMessagesToFront()));
            }
        }
      void backGroundWorkerCOmpleted(object sender, RunWorkerCompletedEventArgs args)
        {
            backgroundWorker.RunWorkerAsync();
        }
        private void showMessagesToFront()
        {
            Console.WriteLine("Showing messages now , length of list is {0}", messages.Count);
            if (messages.Count != 0)
            {
                groupBox1.Controls.Clear();
                foreach (Message message in messagesList)
                {
                    
                    Label ip = new Label();
                 
                    ip.Text = message.ip;
                    ip.Location = new Point();
                    ip.Visible = true;
                    groupBox1.Controls.Add(ip);

                    TextBox messageBox = new TextBox();
                    messageBox.Enabled = false;
                    messageBox.Text = message.message;
                    messageBox.Visible = true;
                    groupBox1.Controls.Add(messageBox);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ipToSend = IP.Text;
            string messageToSend = message.Text;
            
            if (ipToSend==null || ipToSend.Length==0)
            {
                throw new Exception("IP IS EMPTY");
                
            }
            if (messageToSend == null || messageToSend.Length == 0)
            {
                throw new Exception("IP IS EMPTY");
            }

            // saved to database
            tcpClient = new TcpClient();
            tcpClient.Connect(ipToSend, port);
            networkStream = tcpClient.GetStream();

  
            
            if (networkStream.CanWrite)
            {
                Console.WriteLine("Sending message to IP {0}", ipToSend);
                sendMessage(messageToSend, networkStream);
            }
            Console.WriteLine("Sent message to IP {0}", ipToSend);
            networkStream.Flush();
         //   tcpClient.Close();
            
        }

        private void sendMessage(String message, NetworkStream stream)
        {
            Console.WriteLine("Sending message to " + message);
            int lengthOfMessage = message.Length;
            byte[] bytesOfLength = BitConverter.GetBytes(lengthOfMessage);
            byte[] bytesOfMessage = Encoding.ASCII.GetBytes(message);
            Console.WriteLine("Sending message of bytes  " + lengthOfMessage);
            stream.Write(bytesOfLength, 0, 4);
            stream.Write(bytesOfMessage, 0, lengthOfMessage);
        }

        private string readMessage(NetworkStream stream)
        {
            Console.WriteLine("Receiving message");
            if (stream.CanRead)
            {
                byte[] lengthInBytes = new byte[4];
                stream.Read(lengthInBytes, 0, 4);
             
                int length = BitConverter.ToInt32(lengthInBytes, 0);

                Console.WriteLine("Reading bytes {0}", length);
                byte[] message = new byte[length];

                stream.Read(message, 0, length);
                Console.WriteLine("Successfully read bytes {0}", length);
                return Encoding.ASCII.GetString(message);
            }

            return null;
            
        }
    }

    class Message
    {
        public Message(string ip, string message)
        {
            this.ip = ip;
            this.message = message;
        }
        public string ip { get; }
        public string message { get; }


    }
}
