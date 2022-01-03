using Chat_application_with_windows_forms.Entities;
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
using System.Windows;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Chat_application_with_windows_forms.MessageBoxes;
using Chat_application_with_windows_forms.Repository.user;
using Chat_application_with_windows_forms.Exceptions;
using Chat_application_with_windows_forms.Repository.contacts;
using static System.Windows.Forms.ListView;
using Chat_application_with_windows_forms.Utils;

namespace Chat_application_with_windows_forms.Client
{
    public partial class MessagesLayout : Form
    {
        private HubConnection _signalRConnection;
        private IHubProxy _hubProxy;
        private User loggedUser;
        private UserRepo userRepo;
        private ContactsRepo contactsRepo;
        private List<User> contacts;
        private Dictionary<ListViewItem, Int64> contactListItem = new Dictionary<ListViewItem, long>();
        private List<ChatPanel> chats = new List<ChatPanel>();
        private User selectedUserToMessage; //this field will shift pretty often
        public MessagesLayout(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            name.Text = loggedUser.name;
            last_name.Text = loggedUser.lastName;
            phone_number.Text = loggedUser.phoneNumber;
            contactsRepo = new ContactsRepo();
            userRepo = new UserRepo();
            populateContactBoxWithContacts();
            ConnectAsync();
        }

        private async Task ConnectAsync()
        {
            
            Console.WriteLine("Starting signalRConnection on link");
            _signalRConnection = new HubConnection("http://localhost:8080/signalr");
            Console.WriteLine("Initialized hub connection");
            _hubProxy = _signalRConnection.CreateHubProxy("ChatHub");
            Console.WriteLine("Creating proxy");
            _hubProxy.On<string, string>("AddMessage", (name, message) => AddMessage(name,message) );
            Console.WriteLine("MEthod mapping done");
            try
            {
                await _signalRConnection.Start();
                Console.WriteLine("Started succesfully signalRConnection for user {0}",loggedUser.fullname());
            } catch (Exception e)
            {
                Console.WriteLine("Not started");
                Console.WriteLine(e.Message);
            }
          
           
            await _hubProxy.Invoke("setPhoneNumber", loggedUser.phoneNumber);

            Console.WriteLine("Connection established");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MessagesLayout_Load(object sender, EventArgs e)
        {

        }
        int y = 2;
        public void AddMessage(string sender, string message)
        {
            try
            {
                User senderUser = userRepo.findUserByPhoneNumber(sender);

                createActiveChat(senderUser.fullname(), message, y, sender);
                y += 35;
                Console.WriteLine("Chats length {0}", chats.Count);
                chatPanelPopulation(senderUser.fullname(), message, y, sender);

              
                if (loggedUser.phoneNumber.Trim().Equals(sender.Trim()))
                {
                    AppendTextBox("You: " + "  " + message);
                }
                else
                {
                    AppendTextBox(sender + ":  " + message);
                }
            }
            catch (NotFoundException)
            {
                Console.WriteLine("Not found user (AddMessage method)");
            }

        }

        private void chatPanelPopulation(string sender,string message, int y, string sendersPhone)
        {
           // ChatPanel ch = createActiveChat(sender, message, y, sender);

            chat_panel.Invoke(new Action(() => chat_panel.Controls.Clear()));
            foreach(ChatPanel chat  in chats)
            {
                chat_panel.Invoke(new Action(() => chat_panel.Controls.Add(chat)));
            }
        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
           
            textBox1.Text += value;
            textBox1.AppendText(Environment.NewLine);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _hubProxy.Invoke("Send", loggedUser.phoneNumber, selectedUserToMessage.phoneNumber, message.Text);
        }

        private void MessagesLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Exiting app");
            System.Windows.Forms.Application.ExitThread();
        }

        private void new_contact_Click(object sender, EventArgs e)
        {
            addContact();
        }

        private User addContact()
        {
            InputMessage inputMessage = new InputMessage("Please enter the phone number of the person you're trying to add as contact.");
            inputMessage.ShowDialog();

            string phoneNumberToAdd = inputMessage.text;
            Console.WriteLine("Phone number to add is {0}", phoneNumberToAdd);
            try
            {
                User foundUser = userRepo.findUserByPhoneNumber(phoneNumberToAdd);
                Console.WriteLine("Found user to add to contacts {0} " +
                    ", logged user id {1}", foundUser.id,loggedUser.id);
                Console.WriteLine("Now executing the insert query");
                contactsRepo.RegisterContact(loggedUser.id, foundUser.id);
                populateContactBoxWithContacts();
                return foundUser;
            }
            catch (NotFoundException)
            {
                MessageB.ERROR("Not found", "User with this phone number cannot be found in our database");
                return null;
            }
           
        }

        private void populateContactBoxWithContacts()
        {
          
            
            populateContactsList();

            Console.WriteLine("Found {0} contacts", contacts.Count);
            foreach (User c in contacts)
            {
                Console.WriteLine("Adding {0} to list", c.fullname());
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = c.fullname().Trim();
               
                listViewItem.EnsureVisible();
                 contactListItem.Add(listViewItem, c.id);

                listView1.Items.Add(listViewItem);
               
            }

        }
        private void populateContactsList()
        {
            if (contacts == null)
            {
                contacts = new List<User>();
            }
            List<long> contactIds = contactsRepo.findContactsOfUser(loggedUser.id);

            foreach (Int64 id in contactIds)
            {
                try
                {
                    contacts.Add(userRepo.findUserById(id));
                }
                catch (NotFoundException)
                {
                    Console.WriteLine("USer with id {0} not found, maybe deleted", id);
                }

            }
        }

        private void phone_number_Click(object sender, EventArgs e)
        {

        }

        private void new_conversation_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection selectedITem = listView1.SelectedItems;

            if (selectedITem.Count > 1)
            {
                MessageB.ERROR("Gabim", "Ju lutem zgjidhni vetem 1 person ne cast");
                return;
            }
            Int64 idOfContact = 0;
            foreach (ListViewItem item in selectedITem)
            {
                contactListItem.TryGetValue(item,out idOfContact);
            }

            if (idOfContact == 0)
            {
                MessageB.ERROR("Gabim", "Ju lutem zgjidhni te pakten nje kontakt per chat");
                return;
            }

            selectedUserToMessage = userRepo.findUserById(idOfContact);
            getMessageDataFromTheDatabase(idOfContact);

        }

        void getMessageDataFromTheDatabase(long contactId)
        {

        }

      
       

        private ChatPanel createActiveChat(string name,string message, int yLocation,string phonenumber)
        {
            Label nameL = new Label();
            nameL.Text = name;
            nameL.Location = new Point(1, 2);
            nameL.Font = new Font("Book Antiqua", 12, FontStyle.Bold);
            Label messageL = new Label();
            messageL.Text = message;
            messageL.Location = new Point(1, nameL.Height + 2);
            messageL.Font = new Font("Times New Roman", 12, FontStyle.Italic);

            ChatPanel existingPanel = chatExists(phonenumber);
            if (existingPanel != null)
            {
                existingPanel.Invoke(new Action(() =>
                {
                    existingPanel.Controls.Clear();
                    existingPanel.Controls.Add(nameL);
                    existingPanel.Controls.Add(messageL);
                }));
               
                return existingPanel;
            } else
            {
                ChatPanel p = new ChatPanel();
                p.phoneNumber = phonenumber;

                p.Visible = true;
                p.Size = new Size(chat_panel.Width, 50);
                p.Location = new Point(0, yLocation);

                p.Controls.Add(nameL);
                p.Controls.Add(messageL);

                p.BorderStyle = BorderStyle.FixedSingle;
                chats.Add(p);
                return p;
            }    
        }

        private ChatPanel chatExists(string phonenumber)
        {
            foreach(ChatPanel chat in chats)
            {
                if (chat.phoneNumber.Trim().Equals(phonenumber.Trim()))
                {
                    return chat;
                }
            }
            return null;
        }
    }

    
}
