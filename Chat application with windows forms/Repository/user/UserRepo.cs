using Chat_application_with_windows_forms.Entities;
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
                    toReturn
                        = new User(reader.GetInt64(0), reader.GetString(1)
                        , reader.GetString(2), reader.GetString(3));
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
            return toReturn;
        }

        
    }
}
