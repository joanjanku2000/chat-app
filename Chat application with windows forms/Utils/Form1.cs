using Chat_application_with_windows_forms.Entities;
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
    public partial class ContactInfoForm : Form
    {
        private User user;
        public ContactInfoForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            name_label.Text = user.fullname().Trim();
            phoneNumber_Label.Text = user.phoneNumber.Trim();
           
        }
    }
}
