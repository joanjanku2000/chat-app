using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Exceptions;
using Chat_application_with_windows_forms.Repository;
using Chat_application_with_windows_forms.Repository.user;
using Chat_application_with_windows_forms.MessageBoxes;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Chat_application_with_windows_forms.Security;
using System.Text.RegularExpressions;
using Chat_application_with_windows_forms.Client;

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

        private void phoneNumberFormatCheck(string phonenumber)
        {
          

            if (phonenumber[0] != '+' )
            {
                throw new BadRequestException("Please input a phone number ");
            }
            try
            {
                string phone = phonenumber.Substring(1);
                int.Parse(phone);
                if (phonenumber.Length<8 || phonenumber.Length > 15)
                    throw new BadRequestException("Please input a phone number ");
            } catch (Exception )
            {
                throw new BadRequestException("Please input a phone number ");
            }
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
               
                    MessagesLayout messageLayout = new MessagesLayout(loggedUser);
                    messageLayout.Show();
                
                }
                
            }
        }


        private User login(string phonenumber,string password)
        {
           /** try
            {
                phoneNumberFormatCheck(phonenumber);
            }
            catch (BadRequestException)
            {
                MessageB.ERROR("Numri i telefonit", "Ju lutem jepni nje numer te vlefshem telefoni");
                return null;
            } */
            try
            {
                string hashedPsw = userRepo.findPassword(phonenumber).Trim();
                string trimmedPsw = password.Trim();
                if (PasswordHash.ValidatePassword(trimmedPsw, hashedPsw))
                {
                  
                    Console.WriteLine("Passwords match");
                    loggedUser = userRepo.findUserByPhoneNumber(phonenumber);

                    string userName = Environment.UserName;
                    string filepathToSaveEncryptionData = "C:/Users/" + userName;

                    Console.WriteLine("Writing encryption keys to filepath {0} ", filepathToSaveEncryptionData);
                    RsaEncryption.generatePublicKeyAndPrivateKeyAndSaveItToLocation(loggedUser.id,filepathToSaveEncryptionData);

                    return loggedUser;
                } else
                {
                    MessageB.ERROR("Not Found", "Personi me keto te dhena nuk u gjet! Ju lutem provoni perseri");
                    Console.WriteLine("Passwords do not match");
                    return null;
                }
              
            } catch (NotFoundException e)
            {
                MessageB.ERROR("Not Found" , "Personi me keto te dhena nuk u gjet! Ju lutem provoni perseri" );
            }
            return null;
           
        }

        private void sign_up_Click(object sender, EventArgs e)
        {
            string phoneNumber = phone_number_sign_up.Text;
           /* try
            {
                phoneNumberFormatCheck(phoneNumber);
            }
            catch (BadRequestException ex)
            {
                MessageB.ERROR("Numri i telefonit", "Ju lutem jepni nje numer te vlefshem telefoni");
                return ;
            } */
            string password = password_sign_up.Text;
            string cPassword = confirm_password.Text;
            string firstName = name.Text;
            string lastName = lastname.Text;

            if (!isPasswordSomewhatSafe(password))
            {
               
                MessageB.ERROR("Password jo i sigurt", "Passwordi te kete 8 - 12 karakter, nder te cilat te kete numra dhe germa te medha");
                return;
            }
            
            if (firstName.Length == 0 || lastName.Length == 0 ||
                phoneNumber.Length == 0 || password.Length == 0 || cPassword.Length == 0)
            {
                Console.WriteLine("Required fields were not set");
                MessageB.ERROR("Te pa plotesuara", "Ju lutem plotesoni fushat required");
                return;
            } 

            if (!password.Equals(cPassword))
            {
                MessageB.ERROR("Mosperputhje", "Passwordi dhe konfirmimi i tij nuk jane njesoj");
                return;
            }
            try
            {
                if (userRepo.userExists(phoneNumber))
                {
                    MessageBox.Show("Error", "Ekziston nje perdorues me kete numer telefoni");
                    return;
                }
            } catch (NotFoundException es)
            {
                MessageBox.Show("Error", "Ekziston me shume se nje perdorues me kete numer telefoni");
                return;
            }
            Console.WriteLine("Now registering user. Checks passed");

            Console.WriteLine("Hashing password ....");
            string hashedPassword = PasswordHash.HashPassword(password);
           
            User newUserToRegister = new User(firstName,lastName,phoneNumber,hashedPassword);

            if (userRepo.registerUser(newUserToRegister))
            {
                MessageB.INFORMATION("Sukses!", "Perdoruesi u regjistrua me sukses, ju mund te logoheni");
                return;
            }
        }

        private Boolean isPasswordSomewhatSafe(string password)
        {
            return true;
        }


        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                SqlConnection sql = DatabaseConnection.getInstance();
                Console.WriteLine("Connected to database {0}", sql.ToString());
                string phoneNumber = phone_number.Text;
                string psw = password.Text;

                if (true && sql != null)
                {

                    this.loggedUser = login(phoneNumber, psw);
                    if (loggedUser != null)
                    {
                        this.Hide();
                        //  Form1 form1 = new Form1(loggedUser);
                        MessagesLayout messageLayout = new MessagesLayout(loggedUser);
                        messageLayout.Show();
                        //  form1.Show();
                    }

                }

            }
        }
    }
}
