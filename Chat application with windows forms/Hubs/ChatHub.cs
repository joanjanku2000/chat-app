using Chat_application_with_windows_forms.Entities;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Hubs
{
    public delegate void ClientConnectionEventHandler(string clientId);
   public class ChatHub : Hub
    {
        static Dictionary<string, string> users = new Dictionary<string,string>();
        static Dictionary<string, string> reversed_users = new Dictionary<string, string>();

        public static event ClientConnectionEventHandler ClientConnected;
        public override Task OnConnected()
        {
            users.Add(Context.ConnectionId, Context.ConnectionId);
            return base.OnConnected();
        }

        public void setPhoneNumber(string phone)
        {
            users[Context.ConnectionId] = phone;
            ClientConnected?.Invoke(Context.ConnectionId);
            reversed_users.Add(phone, Context.ConnectionId);
        }

        public void Send(string sender,string receiver,string message)
        {
            string conId = "";
            reversed_users.TryGetValue(receiver,out conId);

            Clients.Client(conId).AddMessage(sender,message);
        }
    }
}
