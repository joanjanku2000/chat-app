using Chat_application_with_windows_forms.Entities;
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
using static System.Windows.Forms.ListView;

namespace Chat_application_with_windows_forms.Utils
{
    public partial class ContactsForm : Form
    {

        private GroupRepository repo;
        private List<User> contacts;
        private Group g;

        private String privateKey;
        private IHubProxy _hubProxy;

        public ContactsForm(Group g,GroupRepository gr,List<User> contacts,string privateKey,IHubProxy _hubProxy)
        {
            repo = gr;
            this.contacts = contacts;
            this.g = g;
            this.privateKey = privateKey;
            this._hubProxy = _hubProxy;

            InitializeComponent();
            populateListView();
        }

        private void populateListView()
        {
            contacts.ForEach(c =>
            {
                ContactListViewItem co = new ContactListViewItem(c);
                co.Text = c.fullname().Trim();
                listView1.Items.Add(co);
            }

          );
        }
        private void button1_Click(object sender, EventArgs e)
        {
           SelectedListViewItemCollection selectedContactsToAdd =  listView1.SelectedItems;
           for (int i = 0; i < selectedContactsToAdd.Count; i++)
            {
                ContactListViewItem it = (ContactListViewItem)selectedContactsToAdd[i];

                repo.addUserToGroup(g.id, it.user.id);
                _hubProxy.Invoke("_AddUserGroupPrivateKey", this.g.id, it.user.phoneNumber);
            }

            this.Dispose();
            this.Close();
        }
    }
}
