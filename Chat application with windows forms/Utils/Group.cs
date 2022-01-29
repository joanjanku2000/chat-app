using Chat_application_with_windows_forms.Client;
using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.MessageBoxes;
using Chat_application_with_windows_forms.Repository.group;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.Utils
{
    public partial class GroupInfoForm : Form
    {
        private Group   group;
        private GroupRepository repo;
        private List<User> contacts;
        private User logged;
        
        private HubConnection _signalRConnection;
        private IHubProxy _hubProxy;

        public GroupInfoForm(Group g, GroupRepository gr,List<User> co,User logged, HubConnection con , IHubProxy proxy)
        {
            group = g;
            repo = gr;
            this.logged = logged;
            contacts = co;
            this._hubProxy = proxy;
            this._signalRConnection = con;

            _hubProxy.On<string,string>("AddGroupChat", (sender, message) => this.Invoke(new Action(() => addGroupChat(sender, message))));

            InitializeComponent();
            populateListView();
            name.Text = group.name.Trim();
            label2.Text = group.admin.fullname().Trim();
            totalCount_label.Text = group.participants.Count().ToString();

            if (! userIsAllowedToEditGroup())
            {
                makeButtonsNotClickable();
            }

            fillChatBoxWithMessagesFromTheDatabase();
        }

        private Boolean userIsAllowedToEditGroup()
        {
            return group.admin.id == logged.id;
        }
        private void makeButtonsNotClickable()
        {
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO Validations
            ContactsForm form = new ContactsForm(group, repo, contacts);
            form.ShowDialog();
            group = repo.getGroupById(group.id, logged);
            populateListView();
            totalCount_label.Text = group.participants.Count().ToString();

            reFetchGroupsInGroupsParticipants(group.participants);
        }

        private void populateListView()
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Clear();
            }

            group.participants.ForEach(
                p =>
                {
                    ContactListViewItem c = new ContactListViewItem(p);
                    c.Text = p.fullname().Trim();
                    listView1.Items.Add(c);
                });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO VALIDATIONS
            // TODO Message boxes
            ContactListViewItem selected = (ContactListViewItem)listView1.SelectedItems[0];

            if (selected != null)
            {
                repo.deleteUserFromGroup(group.id, selected.user.id);
                group = repo.getGroupById(group.id, logged);
            }

            // TODO Message boxes
            totalCount_label.Text = group.participants.Count().ToString();
            reFetchGroupsInGroupsParticipants(group.participants);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // TODO Message boxes
            List<User> participants = group.participants;

            repo.deleteGroup(group.id);

            reFetchGroupsInGroupsParticipants(participants);

            this.Dispose();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GroupForm form = new GroupForm(repo, -1, true, group.id);
            form.ShowDialog();
            MessageB.INFORMATION("Emri u ndryshua me sukses","Sukses");
            group = repo.getGroupById(group.id, logged);
            name.Text = group.name.Trim();
            reFetchGroupsInGroupsParticipants(group.participants);

        }

        private void reFetchGroupsInGroupsParticipants(List<User> participants)
        {
            List<string> phoneNumbersOfParticipantsToUpdate =
               participants.Select(user => user.phoneNumber.Trim()).ToList();

            _hubProxy.Invoke("rePopulateGroupBoxes", phoneNumbersOfParticipantsToUpdate);
        }

        private void fillChatBoxWithMessagesFromTheDatabase()
        {
            List<GroupMessage> groupMessages = repo.getGroupMessages(group.id);

            groupMessages.ForEach(message =>
            {
                chatbox_Box.Text += extractMessageFormatForTextBox(message) ;
                chatbox_Box.AppendText(Environment.NewLine);
            });
        }

        private string extractMessageFormatForTextBox(GroupMessage message)
        {
            string sender = logged.id == message.sender.id ? "You: " : message.sender.name.Trim();

            string actualMessage = message.message.Trim();

            return sender + actualMessage;
        }

        private void sendMessage(string message)
        {
            Console.WriteLine("Client: Saving the message");
            repo.addMessageToGroup(group.id, logged.id, message);
            Console.WriteLine("Client: Saved the message");
            List<User> receivers = group.participants;
            receivers.Add(group.admin);
            Console.WriteLine("Client: Found receivers");

            List<string> receiversPhoneNumber = receivers
                .Select(r => r.phoneNumber.Trim())
                .ToList();

            _hubProxy.Invoke("sendGroupMessage", logged.phoneNumber, receiversPhoneNumber, message);
            Console.WriteLine("Client: Invoked remote method");
        }

        private void addGroupChat(string senderPhoneNumber, string message)
        {
            Console.WriteLine("Client: Method addGroupChat called by server");
            if (senderPhoneNumber.Trim().Equals(logged.phoneNumber.Trim())){
                chatbox_Box.Text += "You: " + message.Trim();
                chatbox_Box.AppendText(Environment.NewLine);
            } else
            {
                //finding the user with this phone

                group.participants.ForEach(p =>
                {
                    if (p.phoneNumber == senderPhoneNumber)
                    {
                        chatbox_Box.Text += p.fullname().Trim() + ":  " + message.Trim();
                        chatbox_Box.AppendText(Environment.NewLine);
                    }
                });
            }
           
        }

        private void send_Button_Click(object sender, EventArgs e)
        {
            string messageToSend = message_Box.Text.Trim();
            if (messageToSend.Length > 0)
            {
                Console.WriteLine("Client: Trying to send message");
                sendMessage(messageToSend);
            }
        }

        private void message_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string messageToSend = message_Box.Text.Trim();
                if (messageToSend.Length > 0)
                {
                    Console.WriteLine("Client: Trying to send message");
                    sendMessage(messageToSend);
                }
            }
        }
    }
}
