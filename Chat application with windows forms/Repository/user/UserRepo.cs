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
        public UserRepo()
        {
            conn = DatabaseConnection.getInstance();
        }


        public User findUserById(int id)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
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
                // excepion
            }
            if (count == 0)
            {
                // exception
            }
            conn.Close();
            return toReturn;
        }

        public User findUserByUsernameAndPassword(string phoneNumber,string password)
        {
           
            SqlCommand sqlCommand = conn.CreateCommand();
           
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

        private User extractUser(SqlDataReader reader)
        {
            return new User(reader.GetInt64(0), reader.GetString(1)
                        , reader.GetString(2), reader.GetString(3));
        }

        
    }
}
