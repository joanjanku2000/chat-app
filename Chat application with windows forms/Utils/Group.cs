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

namespace Chat_application_with_windows_forms.Utils
{
    public partial class GroupInfoForm : Form
    {
        private Group   group;
        private GroupRepository repo;
        private List<User> contacts;
        private User logged;
        public GroupInfoForm(Group g, GroupRepository gr,List<User> co,User logged)
        {
            group = g;
            repo = gr;
            this.logged = logged;
            contacts = co;
            InitializeComponent();
            populateListView();
            name.Text = group.name.Trim();
            label2.Text = group.admin.fullname().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO Validations
            ContactsForm form = new ContactsForm(group, repo, contacts);
            form.ShowDialog();
            group = repo.getGroupById(group.id, logged);
            populateListView();
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
            }
            // TODO Message boxes
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // TODO Message boxes
            repo.deleteGroup(group.id);

            this.Dispose();
            this.Close();
        }
    }
}
