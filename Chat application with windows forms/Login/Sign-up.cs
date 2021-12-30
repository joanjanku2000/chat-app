using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Exceptions;
using Chat_application_with_windows_forms.Repository;
using Chat_application_with_windows_forms.Repository.user;
using Chat_application_with_windows_forms.MessageBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.Login
{
    public partial class Sign_in : Form
    {
        private User loggedUser;
        private UserRepo userRepo;
        public Sign_in()
        {
            InitializeComponent();
            password.PasswordChar = '*';
            password_sign_up.PasswordChar = '*';
            confirm_password.PasswordChar = '*';
            userRepo = new UserRepo();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void log_in_Click(object sender, EventArgs e)
        {
            SqlConnection sql = DatabaseConnection.getInstance();
            Console.WriteLine("Connected to database {0}",sql.ToString());
            string phoneNumber = phone_number.Text;
            string psw = password.Text;

            if (true && sql != null)
            {
               
                this.loggedUser = login(phoneNumber,psw);
                if (loggedUser != null)
                {
                    this.Hide();
                    Form1 form1 = new Form1(loggedUser);
                    form1.Show();
                }
                
            }
        }

        private User login(string phonenumber,string password)
        {
            try
            {
                return userRepo.findUserByUsernameAndPassword(phonenumber, password);
            } catch (NotFoundException e)
            {
                MessageB.ERROR("Not Found" , "Personi me keto te dhena nuk u gjet! Ju lutem provoni perseri" );
            }
            return null;
           
        }
    }
}
