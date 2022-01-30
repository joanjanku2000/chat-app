using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Repository.user;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Repository.reports
{
    public class ReportsRepo
    {

        private SqlConnection conn;
        private UserRepo userRepo;

        private string SENT_MOST_MESSAGES_PROC = "SENT_MOST_MESSAGES";
        private string GROUPS_MOST_INTERACTED_WITH = "GROUPS_MOST_INTERACTED_WITH";
        private string RECEIVED_MOST_MESSAGES_PROC = "RECEIVED_MOST_MESSAGES_FROM";
        public ReportsRepo()
        {
            conn = DatabaseConnection.getInstance();
            userRepo = new UserRepo();
        }

        public Dictionary<long,long> sentMostMessagesTo(long userid)
        {
            conn.Open();

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = SENT_MOST_MESSAGES_PROC;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Userid", userid);

            Dictionary<long, long> toReturn = new Dictionary<long, long>();

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    long receiverid = reader.GetInt64(0);
                    int totalMessagesSent = reader.GetInt32(1);

                    toReturn.Add(receiverid, totalMessagesSent);
                }
            }

            conn.Close();

            return toReturn;
        }

        public Dictionary<long, long> receivedMostMessagesFrom(long userid)
        {
            conn.Open();

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = RECEIVED_MOST_MESSAGES_PROC;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Userid", userid);

            Dictionary<long, long> toReturn = new Dictionary<long, long>();

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    long senderId = reader.GetInt64(0);
                    int totalMessagesSent = reader.GetInt32(1);

                    toReturn.Add(senderId, totalMessagesSent);
                }
            }

            conn.Close();

            return toReturn;
        }

        public Dictionary<long, long> groupsWithMostInteraction(long userid)
        {
            conn.Open();

            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = GROUPS_MOST_INTERACTED_WITH;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Userid", userid);

            Dictionary<long, long> toReturn = new Dictionary<long, long>();

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    long groupid = reader.GetInt64(0);
                    int totalMessagesSent = reader.GetInt32(1);

                    toReturn.Add(groupid, totalMessagesSent);
                }
            }

            conn.Close();

            return toReturn;
        }
    }
}
