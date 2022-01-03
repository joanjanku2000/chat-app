
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
            Console.WriteLine("Hub: User connected {0}", Context.ConnectionId);
            return base.OnConnected();
        }

        public void setPhoneNumber(string phone)
        {
            users[Context.ConnectionId] = phone;
            ClientConnected?.Invoke(Context.ConnectionId);
            Console.WriteLine("HUB: Setting phone number {0}", phone);
            reversed_users.Add(phone, Context.ConnectionId);

            Console.WriteLine("Total number of logged users  now is {0} "
                , reversed_users.Count);
            Console.WriteLine("Logged users are ");
            foreach (KeyValuePair<string, string> entry in reversed_users)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }

        public void Send(string sender,string receiver,string message)
        {
            Console.WriteLine("Hub: User {0} is trying to send message to {1}", sender, receiver);
            Console.WriteLine("Hub: Logged users are ");
            string receiverConId = null;
            string senderConId = null;
            foreach (KeyValuePair<string, string> entry in reversed_users)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
                if (entry.Key.Trim().CompareTo(receiver.Trim())==0)
                {
                    Console.WriteLine("HUB : Found reciver he is {0}",entry.Key);
                    receiverConId = entry.Value;
                }
                if (entry.Key.Trim().CompareTo(sender.Trim()) == 0)
                {
                    senderConId = entry.Value;
                    Console.WriteLine("HUB : Found sender he is {0}", entry.Key);
                }
            }
            List<string> conIdsOfParticipants = new List<String>();
            conIdsOfParticipants.Add(senderConId);
            conIdsOfParticipants.Add(receiverConId);
            
            if (receiverConId!=null && senderConId != null)
            {
                Console.WriteLine("Found connection id of  {0}", receiverConId);
               // Clients.Client(receiverConId).AddMessage(sender, message);
                // Clients.Client(senderConId).A
                Clients.Clients(conIdsOfParticipants).AddMessage(sender,receiver, message);
                  
            } else
            {
                Console.WriteLine("COuld not send message");
            }
            
        }
    }
}
