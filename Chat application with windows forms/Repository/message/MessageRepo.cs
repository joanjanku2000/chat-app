using Chat_application_with_windows_forms.Exceptions;
using Chat_application_with_windows_forms.Repository;
using Chat_application_with_windows_forms.Repository.user;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Entities
{
    public class MessageRepo
    {
        private SqlConnection conn;
        private UserRepo userRepo;

        private static string ADD_MESSAGE
            = "insert into user_message(sender_id,receiver_id,message,received,seen)  output INSERTED.ID " +
            "values (@Senderid, @Receiverid, @Message,0,0)";
        private static string FIND_MESSAGES_OF_USERS =
            "select * from user_message where (sender_id = @Senderid and receiver_id = @Receiverid) or (sender_id = @Receiverid and receiver_id = @Senderid) order by id";
        private static string FIND_CHATS_OF_USER = "select distinct(receiver_id) as receiver " +
            "from dbo.user_message " +
            "where sender_id = @Senderid group by receiver_id;";
        private static string FIND_MESSAGE_BY_ID = "select * from user_message where id = @Id";
        private static string SEE_MESSAGE = "update user_message set seen = 1 where id = (select Max(id) from user_message where sender_id = @Senderid and receiver_id=@Receiverid )";

        private static string SEE_MESSAGE_BY_ID = "update user_message set seen = 1 where id = @Id";

        public MessageRepo ()
        {
            conn = DatabaseConnection.getInstance();
            userRepo = new UserRepo();
        }
        public Message findById(Int64 id)
        {

            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            sqlCommand.CommandText = FIND_MESSAGE_BY_ID;
            sqlCommand.Parameters.AddWithValue("@Id", id);
            MessageResult m = null;
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    m = new MessageResult();
                    m.id = reader.GetInt64(0);
                    m.senderId = reader.GetInt64(1);
                    m.receiverId = reader.GetInt64(2);
                    m.message = reader.GetString(3);
                    m.received = reader.GetBoolean(5);
                    m.seen = reader.GetBoolean(6);


                }
            }

            if (m!= null)
            {

                Message ms = new Message();
                ms.id = m.id;
                ms.sender = userRepo.findUserById(m.senderId);
                ms.receiver = userRepo.findUserById(m.receiverId);
                ms.message = m.message;
                ms.received = m.received;
                ms.seen = m.seen;
                conn.Close();
                return ms;
            } else
            {
                conn.Close();
                throw new BadRequestException("Not found message");
            }
        }
        public Message sendMessage(User sender, User receiver , string message)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
           
            sqlCommand.CommandText = ADD_MESSAGE;
            sqlCommand.Parameters.AddWithValue("@Senderid", sender.id);
            sqlCommand.Parameters.AddWithValue("@Receiverid", receiver.id);
            sqlCommand.Parameters.AddWithValue("@Message", message);

            try
            {
                Message m = new Message();
                
                User senderU = userRepo.findUserById(sender.id);
                User receiverU = userRepo.findUserById(receiver.id);
               
                m.sender = senderU;
                m.receiver = receiverU;
                m.message = message;
                m.seen = false;
                m.received = false;

                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                Int64 id = (Int64) sqlCommand.ExecuteScalar();
                m.id = id;
              
                return m;

            } catch(NotFoundException)
            {
                conn.Close();
                throw new BadRequestException("One of the users does not exist");
            }
           
        }

        public List<Message> findMessagesOfUsers(Int64 senderid, Int64 receiverId)
        {
            List<Message> toReturn = new List<Message>();
            List<MessageResult> dbRsult = new List<MessageResult>();

            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            sqlCommand.CommandText = FIND_MESSAGES_OF_USERS;
            sqlCommand.Parameters.AddWithValue("@Senderid", senderid);
            sqlCommand.Parameters.AddWithValue("@Receiverid", receiverId);

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MessageResult m = new MessageResult();
                    m.id = reader.GetInt64(0);
                    m.senderId = reader.GetInt64(1);
                    m.receiverId = reader.GetInt64(2);
                    m.message = reader.GetString(3);
                    m.received = reader.GetBoolean(5);
                    m.seen = reader.GetBoolean(6);
                    dbRsult.Add(m);
                  
                }
            }
            conn.Close();

            foreach (MessageResult msg  in dbRsult)
            {
                Message m = new Message();
                m.id = msg.id;
                m.sender = userRepo.findUserById(msg.senderId);
                m.receiver = userRepo.findUserById(msg.receiverId);
                m.message = msg.message;
                m.received = msg.received;
                m.seen = msg.seen;

                toReturn.Add(m);
            }

            return toReturn;
        }

        public List<Message> findChatsOfUser(Int64 senderid)
        {
            List<Message> toReturn = new List<Message>();
            List<MessageResult> dbRsult = new List<MessageResult>();

            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = FIND_CHATS_OF_USER;
            sqlCommand.Parameters.AddWithValue("@Senderid", senderid);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    MessageResult m = new MessageResult();
                    m.receiverId = reader.GetInt64(0);
                
                    dbRsult.Add(m);
                }
            }
            conn.Close();

            foreach (MessageResult msg in dbRsult)
            {
                long maxId = findMessagesOfUsers(senderid, msg.receiverId).Max(msgg => msgg.id);

                Message m = findById(maxId);
                    

                toReturn.Add(m);
            }

            return toReturn;
        }
   
        public void seeMessage(long id)
        {
            SqlCommand sqlCommand = conn.CreateCommand();

            sqlCommand.CommandText = SEE_MESSAGE_BY_ID;
            sqlCommand.Parameters.AddWithValue("@Id", id);
           
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

        public void seeMessage(long userid,long receiverid)
        {
            SqlCommand sqlCommand = conn.CreateCommand();

            sqlCommand.CommandText = SEE_MESSAGE;
            sqlCommand.Parameters.AddWithValue("@Senderid", userid);
            sqlCommand.Parameters.AddWithValue("@Receiverid", receiverid);

            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

    }
}
