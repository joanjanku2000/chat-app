using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Exceptions;
using Chat_application_with_windows_forms.Repository.user;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Repository.contacts
{

    class ContactsRepo
    {
        private SqlConnection conn;
        
        private static string REGISTER_CONTACT = "INSERT into contact_new(user_id,contact_id) values (@Userid,@Contactid);";
        private static string DELETE_CONTACT = "DELETE FROM contact_new WHERE id = @Id";
        private static string FIND_CONTACTS_OF_USER = " select * from contact_new where user_id = @Userid ";
        private static string FIND_CONTACT = FIND_CONTACTS_OF_USER + " and contact_id = @Contactid";
       
       
        public ContactsRepo()
        {
            conn = DatabaseConnection.getInstance();
        }

        public bool RegisterContact(Int64 userid, Int64 contactid)
        {
            if (contactExists(userid, contactid))
            {
                Console.WriteLine("Contact exists {0} , {1}", userid, contactid);
                throw new BadRequestException("This contact already exists");
            }

            SqlCommand sqlCommand = conn.CreateCommand();
            conn.Open();       
            sqlCommand.CommandText = REGISTER_CONTACT;
            sqlCommand.Parameters.AddWithValue("@Userid", userid);
            sqlCommand.Parameters.AddWithValue("@Contactid", contactid);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            
            return true;
        }

        private bool contactExists(Int64 userid, Int64 contactid)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            conn.Open();
            int count = 0;
            sqlCommand.CommandText = FIND_CONTACT;
            sqlCommand.Parameters.AddWithValue("@Userid", userid);
            sqlCommand.Parameters.AddWithValue("@Contactid", contactid);

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (count > 1)
                    {
                        conn.Close();
                        return true;
                    }
                    count++;
                }
            }
            conn.Close();

            return false;
        }

        public List<Int64> findContactsOfUser(Int64 userId)
        {
            List<Int64> results = new List<long>();
            SqlCommand sqlCommand = conn.CreateCommand();
            conn.Open();
            sqlCommand.CommandText = FIND_CONTACTS_OF_USER;

            sqlCommand.Parameters.AddWithValue("@Userid", userId);

            using(SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(reader.GetInt64(2));
                }
            }
            conn.Close();

            return results;
        }

        public Boolean deleteContact(Int64 id)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            conn.Open();

            sqlCommand.CommandText = DELETE_CONTACT;
            sqlCommand.Parameters.AddWithValue("@Id", id);

            int rowsAffected = sqlCommand.ExecuteNonQuery();

            conn.Close();

            return rowsAffected == 1;
        }

    }
}
