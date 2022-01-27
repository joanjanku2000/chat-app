using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Repository.group;
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
        public ContactsForm(Group g,GroupRepository gr,List<User> contacts)
        {
            repo = gr;
            this.contacts = contacts;
            this.g = g;
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
            }

            this.Dispose();
            this.Close();
        }
    }
}
