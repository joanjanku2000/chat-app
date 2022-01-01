using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.Client
{
    public partial class MessagesLayout : Form
    {
        HubConnection _signalRConnection;
        IHubProxy _hubProxy;

        public MessagesLayout()
        {
            InitializeComponent();
            ConnectAsync();
        }

        private async Task ConnectAsync()
        {
            
            Console.WriteLine("Starting signalRConnection on link");
            _signalRConnection = new HubConnection("http://localhost:8080/signalr");
            Console.WriteLine("Initialized hub connection");
            _hubProxy = _signalRConnection.CreateHubProxy("ChatHub");
            Console.WriteLine("Creating proxy");
            _hubProxy.On<string, string>("AddMessage", (name, message) => AppendTextBox(name + " Message " +  message) );
            Console.WriteLine("MEthod mapping done");
            try
            {
                await _signalRConnection.Start();
                Console.WriteLine("Started succesfully signalRConnection");
            } catch (Exception e)
            {
                Console.WriteLine("Not started");
                Console.WriteLine(e.Message);
            }
          
           
            await _hubProxy.Invoke("setPhoneNumber", "+355695474025");

            Console.WriteLine("Connection established");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MessagesLayout_Load(object sender, EventArgs e)
        {

        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            textBox1.Text += value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _hubProxy.Invoke("Send", "Test", "+355695474025", message.Text);
        }
    }
}
