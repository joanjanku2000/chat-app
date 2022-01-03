using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Repository.user
{
    class UserRepo
    {
        private SqlConnection conn;

        private string FIND_USER_BY_ID = "SELECT * FROM DBO.USERR WHERE ID = @Id";
        private string AUTHENTICATE =
            "SELECT * FROM DBO.USERR WHERE phone_number = @Phonenumber and PASSWORDD = @Password";

        private string USER_BY_PHONE_NUMBER ="SELECT * FROM DBO.USERR WHERE phone_number = @Phonenumber";
        private string PASSWORD_BY_PHONE_NUMBER = "SELECT passwordd FROM DBO.USERR WHERE phone_number = @Phonenumber";

        private string USER_EXISTS = "SELECT count(*) FROM DBO.USERR WHERE phone_number = @Phonenumber";
        private string REGISTER_USER = "INSERT INTO DBO.USERR (NAMEE,LAST_NAME,PHONE_NUMBER,PASSWORDD) VALUES" +
            "(@Name, @Lastname , @Phonenumber,@Password) ";
        public UserRepo()
        {
            conn = DatabaseConnection.getInstance();
        }


        public User findUserById(Int64 id)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            int count = 0;
            sqlCommand.CommandText = FIND_USER_BY_ID;
            sqlCommand.Parameters.AddWithValue("@Id", id);
            User toReturn = new User();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    toReturn = extractUser(reader);
                    count++;
                }
            }
            if (count > 1)
            {
                conn.Close();
                throw new NotFoundException("Multiple users with this id");
            }
            if (count == 0)
            {
                conn.Close();
                throw new NotFoundException("User not found");
            }
            conn.Close();
            return toReturn;
        }

        public User findUserByUsernameAndPassword(string phoneNumber,string password)
        {
           
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            sqlCommand.CommandText = AUTHENTICATE;
            sqlCommand.Parameters.AddWithValue("@Phonenumber", phoneNumber);
            sqlCommand.Parameters.AddWithValue("@Password", password);

            List<User> users = new List<User>();
          

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
               while (reader.Read())
                {
                    User toReturn = extractUser(reader);
                    users.Add(toReturn);       
                }
            }
            conn.Close();
            if (users.Count == 0)
            {
                throw new NotFoundException("User Not Found");
              
            }
            if (users.Count > 1)
            {
                throw new NotFoundException("Ambiguous users");
            }
            
            return users.First();
        }

        public User findUserByPhoneNumber(string phoneNumber)
        {

            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            sqlCommand.CommandText = USER_BY_PHONE_NUMBER;
            sqlCommand.Parameters.AddWithValue("@Phonenumber", phoneNumber);
        


            List<User> users = new List<User>();

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    User toReturn = extractUser(reader);
                    users.Add(toReturn);
                }
            }
            conn.Close();
            if (users.Count == 0)
            {
                throw new NotFoundException("User Not Found");

            }
            if (users.Count > 1)
            {
                throw new NotFoundException("Ambiguous users");
            }

            return users.First();
        }

        public string findPassword(string phoneNumber)
        {

            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            sqlCommand.CommandText = PASSWORD_BY_PHONE_NUMBER;
            sqlCommand.Parameters.AddWithValue("@Phonenumber", phoneNumber);


            List<string> users = new List<string>();


            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string toReturn = reader.GetString(0);
                    users.Add(toReturn);
                }
            }
            conn.Close();
            if (users.Count == 0)
            {
                throw new NotFoundException("User Not Found");

            }
            if (users.Count > 1)
            {
                throw new NotFoundException("Ambiguous users");
            }

            return users.First();
        }

        public Boolean userExists(string phoneNumber)
        {

            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            sqlCommand.CommandText = USER_EXISTS;
            sqlCommand.Parameters.AddWithValue("@Phonenumber", phoneNumber);


            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int totalUsers = reader.GetInt32(0);
                    if (totalUsers == 1)
                    {
                        conn.Close();
                        return true;
                    }
                    else if (totalUsers > 1)
                    {
                        conn.Close();
                        throw new NotFoundException("Multiple phone numbers like this exist, contact admin");
                    }
                }
               
            }
            conn.Close();
            return false;
        }

        public Boolean registerUser(User user)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = REGISTER_USER;
            bindParameters(sqlCommand, user);

            sqlCommand.ExecuteNonQuery();

            conn.Close();

            return true;
            
        }
        private void bindParameters(SqlCommand sqlCommand, User user)
        {
            sqlCommand.Parameters.AddWithValue("@Name", user.name);
            sqlCommand.Parameters.AddWithValue("@Lastname", user.lastName);
            sqlCommand.Parameters.AddWithValue("@Phonenumber", user.phoneNumber);
            sqlCommand.Parameters.AddWithValue("@Password", user.hashedPassword);
        }
        private User extractUser(SqlDataReader reader)
        {
            return new User(reader.GetInt64(0), reader.GetString(1)
                        , reader.GetString(2), reader.GetString(3));
        }

        
    }
}
