using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Repository.user;
using Chat_application_with_windows_forms.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Repository.group
{
    public class GroupRepository
    {
        private SqlConnection conn;
        private UserRepo userRepo;

        private static string CREATE_GROUP = "insert into groupp(name,admin_id) values (@Name,@Adminid)";
        private static string ADD_USER_TO_GROUP = "insert into user_group(group_id,user_id,public_communication_key) values (@Groupid,@Userid,@Publickey)";
        private static string GET_USERS_OF_GROUP_PROCEDURE = "USERS_OF_GROUP";
        private static string GET_GROUPS_OF_USER_PROCEDURE = "GROUPS_OF_USER";
        private static string MESSAGES_OF_GROUP_PROCEDURE = "MESSAGES_OF_GROUP";
        private static string ADD_MESSAGE_TO_GROUP = "insert into group_message(sender_id,group_id,message) values " +
            "(@Senderid,@Groupid,@Message)";
      
        private static string DELETE_USER_FROM_GROUP = "delete from user_group where group_id = @Groupid and user_id = @Userid";
        private static string DELETE_GROUP = "delete from groupp where id = @Groupid";
        private static string DELETE_MESSAGES_OF_GROUP = "delete from group_message where group_id = @Groupid";
        private static string DELETE_GROUP_PARTICIPANTS = "delete from user_group where group_id = @Groupid";
     
        private static string MODIFY_GROUP_NAME = "update groupp set name = @Name where id = @Groupid";
       
        private static string GET_GROUP_BY_ID = "select * from groupp where id = @Groupid";
        public GroupRepository()
        {
            conn = DatabaseConnection.getInstance();
            userRepo = new UserRepo();
        }

        public void createGroup(long adminid, string groupName)
        {

            var csp = new RSACryptoServiceProvider(2048);
            var privKey = csp.ExportParameters(true);
            var pubKey = csp.ExportParameters(false);

            string pubKeyString;
            string privKeyString;

            {
                //we need some buffer
                var sw = new System.IO.StringWriter();
                var pw = new StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, pubKey);
                xs.Serialize(pw, privKey);
                //get the string from the stream
                pubKeyString = sw.ToString();
                privKeyString = pw.ToString();
            }


            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = CREATE_GROUP;
            sqlCommand.Parameters.AddWithValue("@Name", groupName);
            sqlCommand.Parameters.AddWithValue("@Adminid", adminid);
            sqlCommand.Parameters.AddWithValue("@Publickey", pubKeyString);

            long id = (long) sqlCommand.ExecuteScalar();

            // create public private key pair to save
            // ky celes do te perdoret per te shkembyer te dhenat
           
            RsaEncryption.generatePublicKeyAndPrivateKeyAndSaveItToLocation_Group(id, "C:/Users/" + Environment.UserName,pubKeyString,privKeyString);

            conn.Close();

        }
        public void addUserToGroup(long groupid,long userid)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = ADD_USER_TO_GROUP;
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);
            sqlCommand.Parameters.AddWithValue("@Userid", userid);

            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

        public List<User> getUsersOfGroup(long id)
        {
           
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = GET_USERS_OF_GROUP_PROCEDURE;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Groupid", id);

            List<User> toReturn = new List<User>();

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {

                    long userid = reader.GetInt64(0);
                    string user_name = reader.GetString(1);
                    string lastname = reader.GetString(2);
                    string phone_number = reader.GetString(3);
                    bool online = reader.GetBoolean(4);

                    toReturn.Add(getUser(userid, user_name, lastname, phone_number, online));

                }
            }

            conn.Close();
            return toReturn;
        }

        /**
         * Kjo eshte metoda kryesore qe supozohet te perdoret 
         * dhe te therritet sapo perdoruesi logohet 
         * */
        public List<Group> getGroupsOfUser(User user)
        {

            Console.WriteLine("Getting groups of user {0}", user.id);
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = GET_GROUPS_OF_USER_PROCEDURE;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Userid", user.id);

            List<Group> groupsToReturn = new List<Group>();
 
            List<Wrapper<Group>> groupsWrapperList = new List<Wrapper<Group>>();
            
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.GetInt64(0);
                    string groupName = reader.GetString(1);
                    string publickey = reader.GetString(2);

                    groupsWrapperList
                        .Add(new Wrapper<Group>(reader.GetInt64(2), constructGroup(id, groupName, publickey)));
                    
                }
            }

            conn.Close();

            foreach (Wrapper<Group> entry in groupsWrapperList)
            {
                User admin = userRepo.findUserById(entry.senderid);
                entry.objectToMap.admin = admin;
                entry.objectToMap.participants = getUsersOfGroup(entry.objectToMap.id);
                entry.objectToMap.messages = getGroupMessages(entry.objectToMap.id);
                groupsToReturn.Add(entry.objectToMap);
            }
            Console.WriteLine("Total groups user has is {0}", groupsToReturn.Count);
            return groupsToReturn;
            
        }

        public List<GroupMessage> getGroupMessages(long groupid)
        {
           
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = MESSAGES_OF_GROUP_PROCEDURE;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);


            List<Wrapper<GroupMessage>> messages = new List<Wrapper<GroupMessage>>();
           
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.GetInt64(0);
                    string message = reader.GetString(3);

                    messages.Add(new Wrapper<GroupMessage>(reader.GetInt64(1), new GroupMessage(id, message)));
                }
            }
            conn.Close();

            List<GroupMessage> toReturn = new List<GroupMessage>();


            messages.ForEach(
                m =>
                {
                    User sender = userRepo.findUserById(m.senderid);
                    m.objectToMap.sender = sender;
                    toReturn.Add(m.objectToMap);
                });

            return toReturn;
        }


        public void addMessageToGroup(long groupid, long userid,string message)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = ADD_MESSAGE_TO_GROUP;
            sqlCommand.Parameters.AddWithValue("@Senderid", userid);
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);
            sqlCommand.Parameters.AddWithValue("@Message", message);
            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

        public void deleteUserFromGroup(long groupid,long userid)
        {
            
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = DELETE_USER_FROM_GROUP;
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);
            sqlCommand.Parameters.AddWithValue("@Userid", userid);
   
            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

        public void modifyGroupName(long groupid, string name)
        {
            

           SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = MODIFY_GROUP_NAME;
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);
            sqlCommand.Parameters.AddWithValue("@Name", name);

            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

        public Group getGroupById(long groupid, User user)
        {

            List<Group> groupsOfUser = getGroupsOfUser(user);

            return groupsOfUser.Find(g => g.id == groupid);
        }

        public void deleteGroup(long groupid)
        {
            /**
             * Fillmisht fshihen mesazhet dhe pjesemarresit e grupit
             * per te shmanguar gabimet me foreign key, qe nuk lejohet 
             * te fshihet sepse grupi ekziston diku jeter
             * */

            deleteMessagesFromGroup(groupid);
            deleteUsersFromGroup(groupid);

            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = DELETE_GROUP;
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);


            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

        private void deleteMessagesFromGroup(long groupid)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = DELETE_MESSAGES_OF_GROUP;
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);
         

            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }

        private void deleteUsersFromGroup(long groupid)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = DELETE_GROUP_PARTICIPANTS;
            sqlCommand.Parameters.AddWithValue("@Groupid", groupid);


            sqlCommand.ExecuteNonQuery();

            conn.Close();
        }
        private static Group constructGroup(long id, string groupName,string publickey)
        {
            Group group = new Group();
            group.id = id;
            group.name = groupName;
            group.publicKey = publickey;
            return group;
        }

        private static User getUser(long userid, string user_name, string lastname, string phone_number, bool online)
        {
            User user = new User();
            user.id = userid;
            user.name = user_name;
            user.lastName = lastname;
            user.phoneNumber = phone_number;
            user.online = online;

            return user;
        }

        class Wrapper<T>
        {
            public long senderid;
            public T objectToMap;

            public Wrapper(long id, T objectToMap)
            {
                this.senderid = id;
                this.objectToMap = objectToMap;
            }
        }


    }
}
