
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormServer.Security;

namespace Chat_application_with_windows_forms.Hubs
{
    public delegate void ClientConnectionEventHandler(string clientId);
   public class ChatHub : Hub
    {
        /** <ConnectionId , PhoneNumber> */
        static Dictionary<string, string> users = new Dictionary<string,string>();
        /** <PhoneNumber , ConnectionId> */
        static Dictionary<string, string> reversed_users = new Dictionary<string, string>();

        /** <PhoneNumber , Public Key> */
        static Dictionary<string, byte[]> user_public_key = new Dictionary<string, byte[]>();
        /** <PhoneNumber , IV> */
        static Dictionary<string, byte[]> user_IV = new Dictionary<string, byte[]>();

        public static event ClientConnectionEventHandler ClientConnected;

        /**
         * Used to refresh the list of contacts in all logged users since another
         * User joined
         * */
        public override Task OnConnected()
        {
            users.Add(Context.ConnectionId, Context.ConnectionId);
            Console.WriteLine("Hub: User connected {0}", Context.ConnectionId);
          
            return base.OnConnected();
        }

        /**
         * Used to refresh the list of contacts in all logged users since another
         * User left
         * */
        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("Hub: Refreshing lists on all connected clients since someone just left");
            Clients.All.populateContactBoxWithContacts();
            return base.OnDisconnected(stopCalled);
        }

        public void logout(string phone)
        {
            string con = "";
            reversed_users.TryGetValue(phone.Trim(), out con);
            Console.WriteLine("Found connection string to logout {0}", con);
            reversed_users.Remove(phone.Trim());
            users.Remove(con);
            Console.WriteLine("User {0} is now logged out", phone);
        }
        public void setPhoneNumber(string phone,byte[] publickey, byte[] iv)
        {
            string existingCon = null;

            reversed_users.TryGetValue(phone.Trim(), out existingCon);
            Console.WriteLine("Trying to login a user , found connectio id is {0}", existingCon);
            users[Context.ConnectionId] = phone.Trim();
            ClientConnected?.Invoke(Context.ConnectionId);

            Console.WriteLine("HUB: Setting phone number {0}", phone);
            try
            {
                reversed_users.Add(phone.Trim(), Context.ConnectionId);

            } catch (Exception)
            {
                Console.WriteLine("Hub: User is already logged in");
                Clients.Client(Context.ConnectionId).ShowUserLoggedInError();
                return;
            }
         

            Console.WriteLine("Total number of logged users  now is {0} "
                , reversed_users.Count);
            Console.WriteLine("Logged users are ");
            foreach (KeyValuePair<string, string> entry in reversed_users)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }


            user_public_key.Add(phone, publickey);
            user_IV.Add(phone, iv);
            Console.WriteLine("Registered users public key and iv");
            Clients.All.populateContactBoxWithContacts();
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
                Clients.Client(senderConId).AddMessage(sender, receiver, message);
            }
            
        }

        public void rePopulateChatBoxes()
        {
            Clients.All.populateContactBoxWithContacts();
        }

        public void rePopulateGroupBoxes(List<string> phonenumbers)
        {
            List<string> connectionIds 
                = getConnectionIdsOfPhoneNumbers(phonenumbers)
                .Where(phone => phone != null)
                .ToList();

            Clients.Clients(connectionIds).getGroupsOfUser();
            Clients.Clients(connectionIds).populateGroupsList();
        }

        private List<string> getConnectionIdsOfPhoneNumbers(List<string> phonenumbers)
        {
            return phonenumbers.Select(phone =>
            {
                string con = "";
                reversed_users.TryGetValue(phone.Trim(), out con);
                return con;
            }).ToList();
        }

        public void sendGroupMessage(string senderphone, List<string> participantsPhoneNumbers
            , Dictionary<string, byte[]> differenteEncryptionsForTheSameMessageToAccomodateDifferentReceivers, byte[] senderPublic,byte[] senderiv)
        {
            Console.WriteLine("Server -> sendGroupMessage: Got senderphone {0}",senderphone);
            string con = "";
            reversed_users.TryGetValue(senderphone.Trim(), out con);
           
            if (con != null)
            {
                List<string> connectionIds
                = getConnectionIdsOfPhoneNumbers(participantsPhoneNumbers)
                    .Where(phone => phone != null)
                  .ToList();
                Console.WriteLine("Server: Calling client method: AddGroupChat");
                Clients.Clients(connectionIds).AddGroupChat(senderphone, differenteEncryptionsForTheSameMessageToAccomodateDifferentReceivers,senderPublic,senderiv);
            }
        }

        public void getUsersPublicKeys(string senderphone , List<string> users)
        {
            Console.WriteLine("Server: Got senderphone (to get users) {0}", senderphone);
            string con = "";
            reversed_users.TryGetValue(senderphone.Trim(), out con);
            if (con != null)
            {
                List<string> connectionIds
                = getConnectionIdsOfPhoneNumbers(users)
                    .Where(phone => phone != null)
                  .ToList();

                Console.WriteLine("Server: Calling client method");

                Dictionary<string, byte[]> receiversPublicKeys = new Dictionary<string, byte[]>();


                connectionIds.ForEach(cid =>
                {
                    string user = "";
                    ChatHub.users.TryGetValue(cid, out user);

                    if (user.Length > 0)
                    {
                        byte[] pkey = getPublicKeyOfUser(user.Trim());
                        if (pkey != null)
                        {
                           try
                            {
                                receiversPublicKeys.Add(user.Trim(), pkey);
                            } catch (System.ArgumentException) { Console.WriteLine("Server error: An item with the same key has already been added."); }
                        } 
                           
                    }
                    
                });

                Console.WriteLine("Users pkeys {0}", receiversPublicKeys.Count);

                Clients.Clients(connectionIds).RegisterPublicKeys(receiversPublicKeys);
            }
        }

        private byte[] getPublicKeyOfUser(string phone)
        {
           foreach (KeyValuePair<string, byte[]>  k in user_public_key)
            {
                if (k.Key.Trim().Equals(phone.Trim()))
                {
                    return k.Value;
                }
            }
            return null;
        }
        public void refreshChatOfUserWithUser(string sender,string receiver)
        {

        }
    }
}
