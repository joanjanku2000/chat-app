using Chat_application_with_windows_forms.MessageBoxes;
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

namespace Chat_application_with_windows_forms.Client
{
    public partial class GroupForm : Form
    {

        private GroupRepository repo;
        private long id;
        public GroupForm(GroupRepository repo, long adminid)
        {
            InitializeComponent();
            this.repo = repo;
            this.id = adminid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            if (name.Length < 0)
            {
                MessageB.ERROR("Gabim", "Emri nuk eshte i vlefshem");
                return;
            }

            repo.createGroup(id, name);

           
            this.Close();
            this.Dispose();
            
        }
    }
}
