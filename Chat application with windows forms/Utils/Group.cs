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


            InitializeComponent();
            populateListView();
            name.Text = group.name.Trim();
            label2.Text = group.admin.fullname().Trim();
            totalCount_label.Text = group.participants.Count().ToString();

            if (! userIsAllowedToEditGroup())
            {
                makeButtonsNotClickable();
            }
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
    }
}
