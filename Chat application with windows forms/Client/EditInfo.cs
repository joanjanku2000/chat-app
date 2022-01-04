using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.MessageBoxes;
using Chat_application_with_windows_forms.Repository.user;
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
    public partial class EditInfo : Form
    {
        private User user;
        private UserRepo userRepo;
        public EditInfo(User user)
        {
            InitializeComponent();
            this.user = user;
            userRepo = new UserRepo();
            name.Text = user.name.Trim();
            last_name.Text = user.lastName;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _name = name.Text;
            string _lastname = last_name.Text;

            if (_name.Length == 0 || _lastname.Length == 0)
            {
                MessageB.ERROR("Gabim", "Ju lutem jepni te dhena te plota");
                return;
            }

            userRepo.updateUserInfo(user.phoneNumber, _name, _lastname);
            
            this.Dispose();
        }
    }
}
