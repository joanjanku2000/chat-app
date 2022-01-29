using Chat_application_with_windows_forms.Entities;
using Microsoft.AspNet.SignalR.Client;
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
using MessageBox = System.Windows.Forms.MessageBox;
using Chat_application_with_windows_forms.Repository.group;

namespace Chat_application_with_windows_forms.Client
{
    public partial class MessagesLayout : Form
    {
        private HubConnection _signalRConnection;
        private IHubProxy _hubProxy;
        private User loggedUser;

        private UserRepo userRepo;
        private MessageRepo messageRepo;
        private ContactsRepo contactsRepo;

        private List<User> contacts;
        private Dictionary<ListViewItem, Int64> contactListItem = new Dictionary<ListViewItem, long>();
        private List<ChatPanel> chats = new List<ChatPanel>();

        private User selectedUserToMessage; //this field will shift pretty often

        private List<Entities.Message> userChatsFromDatabase = new List<Entities.Message>();
        private List<Entities.Message> activeChatMessages = new List<Entities.Message>(); //this field will shift pretty often

        private GroupRepository groupRepository;
        private List<Group> groupsOfUser;

        public MessagesLayout(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            name.Text = loggedUser.name;
            last_name.Text = loggedUser.lastName;
            phone_number.Text = loggedUser.phoneNumber;
            contactsRepo = new ContactsRepo();
            userRepo = new UserRepo();
            messageRepo = new MessageRepo();
            userChatsFromDatabase = messageRepo.findChatsOfUser(loggedUser.id);
            groupRepository = new GroupRepository();
            groupsOfUser = new List<Group>();
            //  populateContactBoxWithContacts();

            ConnectAsync();

            userRepo.setUserOnline(loggedUser.id);

            getGroupsOfUser();
            populateGroupsList();
        }
        private void populateChatsFromDatabase()
        {
            Console.WriteLine("Found {0} chats ", userChatsFromDatabase.Count);
            foreach (Entities.Message mes in userChatsFromDatabase)
            {
                if (loggedUser.phoneNumber.Trim().Equals(mes.sender.phoneNumber.Trim()))
                {
                    createActiveChat(mes.receiver.fullname(), mes.message, y, mes.receiver.phoneNumber, true, mes.seen);

                }
                else
                {
                    createActiveChat(mes.sender.fullname(), mes.message, y, mes.sender.phoneNumber, false, mes.seen);

                }
                y += 43;
            }

            chatPanelPopulation();

        }

        private void registerAsAContact(Int64 contactId)
        {
            if (contactsRepo.RegisterContact(loggedUser.id, contactId))
            {
                MessageB.INFORMATION("Kontakti u regjistrua me sukses", "Sukses");
            }
            else
            {
                MessageB.WARNING("Kontakti ekziston ose ndodhi nje gabim tjeter", "Warning");
            }
        }
        private async Task ConnectAsync()
        {

            Console.WriteLine("Starting signalRConnection on link");
            _signalRConnection = new HubConnection("http://localhost:8080/signalr");
            Console.WriteLine("Initialized hub connection");
            _hubProxy = _signalRConnection.CreateHubProxy("ChatHub");
            Console.WriteLine("Creating proxy");

            _hubProxy.On<string, string, string>("AddMessage", (name, reciver, message) => AddMessage(name, reciver, message));

            _hubProxy.On("populateContactBoxWithContacts", () => this.Invoke(new Action(() => populateContactBoxWithContacts())));

            _hubProxy.On("ShowUserLoggedInError", () => ShowUserLoggedInError());

            _hubProxy.On("getGroupsOfUser", () => getGroupsOfUser());

            _hubProxy.On("populateGroupsList", () => populateGroupsList());



            Console.WriteLine("MEthod mapping done");

            try
            {
                await _signalRConnection.Start();
                Console.WriteLine("Started succesfully signalRConnection for user {0}", loggedUser.fullname());
            }
            catch (Exception e)
            {
                Console.WriteLine("Not started");
                Console.WriteLine(e.Message);
            }

            await _hubProxy.Invoke("setPhoneNumber", loggedUser.phoneNumber);

            Console.WriteLine("Connection established");
        }

        public void ShowUserLoggedInError()
        {
            MessageB.ERROR("Je i loguar", "Ju jeni te loguar");
            try
            {
                _signalRConnection.Dispose();
            }
            catch (Exception)
            {
                Console.WriteLine("Server is probably down");
            }
            Console.WriteLine("Exiting app");
            try
            {
                System.Windows.Forms.Application.ExitThread();

            }
            catch (Exception)
            {

                Console.WriteLine("Server is probably down");
            }
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception)
            {
                Console.WriteLine("Server is probably down");
            }


        }

        int y = 2;
        public void AddMessage(string sender, string receiver, string message)
        {
            try
            {
                User senderUser = userRepo.findUserByPhoneNumber(sender);
                User receiverUser = userRepo.findUserByPhoneNumber(receiver);
                ChatPanel addedChat;
                if (loggedUser.phoneNumber.Equals(sender))
                {

                    addedChat = createActiveChat(receiverUser.fullname(), message, y, receiver, true, false);

                }
                else
                {
                    addedChat = createActiveChat(senderUser.fullname(), message, y, sender, false, false);

                }
                y += 38;
                Console.WriteLine("Chats length {0}", chats.Count);

                chatPanelPopulation();

                if (selectedUserToMessage != null)
                {
                    if (loggedUser.phoneNumber.Trim().Equals(sender.Trim()))
                    {
                        AppendTextBox("You: " + "  " + message);
                    }
                    else
                    {
                        User u = userRepo.findUserByPhoneNumber(sender.Trim());

                        AppendTextBox(u.fullname().Trim() + ":  " + message.Trim());

                    }
                }


                if (loggedUser.phoneNumber.Trim().Equals(senderUser.phoneNumber.Trim()))
                {
                    Entities.Message toBeSaved = messageRepo.sendMessage(senderUser, receiverUser, message);

                }

                if (loggedUser.phoneNumber.Trim().Equals(receiverUser.phoneNumber.Trim()) && selectedUserToMessage != null && selectedUserToMessage.id.Equals(senderUser.id))
                {
                    Console.WriteLine("Seeing message since selected user is the sender");
                    messageRepo.seeMessage(senderUser.id, receiverUser.id);
                    addedChat.Invoke(
                           new Action(() =>
                           {
                               Console.WriteLine("Changing the color of chat ");
                               addedChat.BackColor = Color.AliceBlue;
                           }));
                }




                Console.WriteLine("Successfully wrote the message to the database");


            }
            catch (NotFoundException)
            {
                Console.WriteLine("Not found user (AddMessage method)");
            }

        }
        private void populateChatBox()
        {
            textBox1.Clear();
            foreach (Entities.Message m in activeChatMessages)
            {
                if (loggedUser.phoneNumber.Trim().Equals(m.sender.phoneNumber.Trim()))
                {
                    AppendTextBox("You: " + "  " + m.message.Trim());
                }
                else
                {

                    AppendTextBox(m.sender.fullname().Trim() + ":  " + m.message.Trim());

                }
            }
        }
        private void chatPanelPopulation()
        {
            chat_panel.Invoke(new Action(() => chat_panel.Controls.Clear()));
            foreach (ChatPanel chat in chats)
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
            message.Text = "";
        }

        private void MessagesLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            userRepo.setUserOffline(loggedUser.id);
            try
            {
                _hubProxy.Invoke("logout", loggedUser.phoneNumber);
            }
            catch (Exception)
            {
                Console.WriteLine("Hidhet zakonisht kur useri tenton te logohet 2 here");
            }
            _signalRConnection.Dispose();
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
                    ", logged user id {1}", foundUser.id, loggedUser.id);
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

            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }

            foreach (User c in contacts)
            {
                Console.WriteLine("Adding {0} to list who is active: [{1}]", c.fullname(), c.online);
                ListViewItem listViewItem = new ContactListViewItem(c);
                listViewItem.Text = c.fullname().Trim();
                listViewItem.EnsureVisible();
                if (c.online)
                {
                    listViewItem.ForeColor = Color.Green;
                    listViewItem.Text += " (On)";
                }

                listViewItem.EnsureVisible();
                contactListItem.Add(listViewItem, c.id);


                Console.WriteLine("Handle created {0}", listView1.IsHandleCreated);
                listView1.Items.Add(listViewItem);
            }

        }
        private void populateContactsList()
        {
            if (contacts == null)
            {
                contacts = new List<User>();
            }
            if (contacts.Count != 0)
            {
                contacts.Clear();
            }

            List<long> contactIds = contactsRepo.findContactsOfUser(loggedUser.id);
            Console.WriteLine("Got contact ids");
            foreach (Int64 id in contactIds)
            {
                try
                {
                    contacts.Add(userRepo.findUserById(id));
                    Console.WriteLine("Adding contacts");
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

        private Boolean isAContact(string phonenumber)
        {
            if (contacts != null)
            {

                foreach (User u in contacts)
                {
                    if (u.phoneNumber.Trim().Equals(phonenumber))
                    {
                        return true;
                    }
                }
            }

            return false;
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
                contactListItem.TryGetValue(item, out idOfContact);
            }

            if (idOfContact == 0)
            {
                MessageB.ERROR("Gabim", "Ju lutem zgjidhni te pakten nje kontakt per chat");
                return;
            }

            selectedUserToMessage = userRepo.findUserById(idOfContact);
            activeChatMessages = messageRepo.findMessagesOfUsers(loggedUser.id, selectedUserToMessage.id);
            populateChatBox();
        }

        private ChatPanel createActiveChat(string nameToBeShown, string message, int yLocation, string phonenumber, bool you, bool seen)
        {

            Label nameL = new Label();
            nameL.Text = nameToBeShown.Trim();
            nameL.Location = new Point(1, 2);
            nameL.Font = new Font("Book Antiqua", 10, FontStyle.Bold);
            Label messageL = new Label();
            if (you)
            {
                messageL.Text = "You: " + message.Trim();
            }
            else
            {
                messageL.Text = message.Trim();
            }

            messageL.Location = new Point(1, nameL.Height + 3);
            messageL.Font = new Font("Times New Roman", 9, FontStyle.Italic);


            ChatPanel existingPanel = chatExists(phonenumber);
            if (existingPanel != null)
            {
                if (!existingPanel.IsHandleCreated)
                {
                    existingPanel.CreateControl();
                }
                existingPanel.Invoke(new Action(() =>
                {
                    existingPanel.Controls.Clear();
                    existingPanel.Controls.Add(nameL);
                    existingPanel.Controls.Add(messageL);
                    existingPanel.Click += chatSelect_Event;
                }));

                //if not seen and not you the one who sends it mark it 
                if (!seen && !you)
                {
                    existingPanel.Invoke(
                        new Action(() =>
                        {
                            existingPanel.BackColor = Color.Green;
                        }));
                }

                return existingPanel;
            }
            else
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
                p.MouseClick += chatSelect_Event;
                p.BackColor = Color.AliceBlue;

                if (!seen && !you)
                {
                    p.BackColor = Color.Green;

                }

                return p;
            }
        }

        private ChatPanel chatExists(string phonenumber)
        {
            foreach (ChatPanel chat in chats)
            {
                if (chat.phoneNumber.Trim().Equals(phonenumber.Trim()))
                {
                    return chat;
                }
            }
            return null;
        }

        private void chatSelect_Event(object sender, EventArgs e)
        {
            ChatPanel selected = (ChatPanel)sender;
            Console.WriteLine("Selected {0}", selected.phoneNumber);

            if (selectedUserToMessage == null || !selected.phoneNumber.Trim().Equals(selectedUserToMessage.phoneNumber.Trim()))
            {

                if (selected.phoneNumber != null)
                {
                    selectedUserToMessage = userRepo.findUserByPhoneNumber(selected.phoneNumber.Trim());
                }


                Console.WriteLine("Changing color ");
                selected.BackColor = Color.White;

                foreach (ChatPanel p in chats)
                {
                    if (!p.phoneNumber.Trim().Equals(selected.phoneNumber.Trim()))
                    {
                        Console.WriteLine("Reverting color ");
                        selected.BackColor = Color.AliceBlue;
                    }
                }

                activeChatMessages = messageRepo.findMessagesOfUsers(loggedUser.id, selectedUserToMessage.id);
                activeChatMessages.ForEach(message =>
                {
                    messageRepo.seeMessage(message.id);
                });
                populateChatBox();
            }


        }


        private void MessagesLayout_Load(object sender, EventArgs e)
        {
            populateChatsFromDatabase();
        }

        private void update_info_Click(object sender, EventArgs e)
        {
            EditInfo editInfoForm = new EditInfo(loggedUser);
            editInfoForm.ShowDialog();
            loggedUser = userRepo.findUserByPhoneNumber(loggedUser.phoneNumber);
            name.Text = loggedUser.name;
            last_name.Text = loggedUser.lastName;
            phone_number.Text = loggedUser.phoneNumber;

            // duhet nje metode ne hub qe updateon

            _hubProxy.Invoke("rePopulateChatBoxes");
        }

        private void message_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _hubProxy.Invoke("Send", loggedUser.phoneNumber, selectedUserToMessage.phoneNumber, message.Text);
                message.Text = "";
            }
        }

        private void deleteChat_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
                MessageBox.Show("Fshirja e bisedes do te fshije edhe biseden nga ana e bashkekomunikuesit. Jeni i sigurt per kete ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                messageRepo.delete(loggedUser.id, selectedUserToMessage.id);
                userChatsFromDatabase = messageRepo.findChatsOfUser(loggedUser.id);
                chats = new List<ChatPanel>();
                populateChatsFromDatabase();
                selectedUserToMessage = null;
                textBox1.Clear();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ContactListViewItem selected = (ContactListViewItem)listView1.SelectedItems[0];
            ContactInfoForm c = new ContactInfoForm(selected.user);
            c.ShowDialog();
        }

        private void addContact_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
                MessageBox.Show("Jeni i sigurt qe doni ta shtoni personin ne listen tuaj te kontakteve ?", "Shto kontakt", MessageBoxButtons.YesNo);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                if (!isAContact(selectedUserToMessage.phoneNumber))
                {
                    contactsRepo.RegisterContact(loggedUser.id, selectedUserToMessage.id);
                    populateContactBoxWithContacts();
                } else
                {
                    MessageB.WARNING("Ky person eshte ne listen tuaj te kontakteve","Kontakti ekziston");
                }
               
            }
        }

        private void getGroupsOfUser()
        {
            groupsOfUser = groupRepository.getGroupsOfUser(loggedUser);
        }

        private void createGroup(long adminid, string group_name)
        {
            groupRepository.createGroup(adminid, group_name);

            getGroupsOfUser();
        }

        private void addUsersToGroup(long groupId, List<long> userIds)
        {
            userIds.ForEach(id => groupRepository.addUserToGroup(groupId, id));
            getGroupsOfUser();
        }

        private void addMessageToGroup(long groupid, string message)
        {
            groupRepository.addMessageToGroup(groupid, loggedUser.id, message);

        }

        private void populateGroupsList()
        {
            if (groupsListView.Items.Count > 0)
            {
                groupsListView.Items.Clear();
            }
            Console.WriteLine("Got {0} groups", groupsOfUser.Count);
            groupsOfUser.ForEach(
                group =>
                {
                    groupsListView.Items.Add(new GroupListViewItem(group));
                });   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm(groupRepository, loggedUser.id,false,-1);
            groupForm.ShowDialog();

            getGroupsOfUser();
            populateGroupsList();
        }

        private void viewGroup_button_Click(object sender, EventArgs e)
        {
            GroupListViewItem selected = (GroupListViewItem)groupsListView.SelectedItems[0];
           
            if (selected != null)
            {
                GroupInfoForm form = new GroupInfoForm(selected.group, groupRepository, contacts, loggedUser,_signalRConnection,_hubProxy);
                form.ShowDialog();

                // Ne rast se groupi eshte fshire
                getGroupsOfUser();
                populateGroupsList();
            }
            


        }
    }
}
