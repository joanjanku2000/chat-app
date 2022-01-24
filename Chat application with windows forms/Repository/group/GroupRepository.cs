using Chat_application_with_windows_forms.Entities;
using Chat_application_with_windows_forms.Repository.user;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Repository.group
{
    class GroupRepository
    {
        private SqlConnection conn;
        private UserRepo userRepo;

        private static string CREATE_GROUP = "insert into groupp(name,admin_id) values (@Name,@Adminid)";
        private static string ADD_USER_TO_GROUP = "insert into user_group(group_id,user_id) values (@Groupid,@Userid)";
        private static string GET_USERS_OF_GROUP_PROCEDURE = "USERS_OF_GROUP";
        private static string GET_GROUPS_OF_USER_PROCEDURE = "GROUPS_OF_USER";
        private static string MESSAGES_OF_GROUP_PROCEDURE = "MESSAGES_OF_GROUP";
        private static string ADD_MESSAGE_TO_GROUP = "insert into group_message(sender_id,group_id,message) values " +
            "(@Senderid,@Groupid,@Message)";
        private static string DELETE_USER_FROM_GROUP = "delete from user_group where group_id = @Groupid and user_id = @Userid";
        private static string DELETE_GROUP = "delete from group where id = @Id";
        private static string DELETE_MESSAGES_OF_GROUP = "delete from group_message where group_id = @Id";
        private static string DELETE_GROUP_PARTICIPANTS = "delete from user_group where group_id = @Id";
        private static string MODIFY_GROUP_NAME = "update groupp set name = @Name where id = @Id";
        private static string GET_GROUP_BY_ID = "select * from groupp where id = @Id";
        public GroupRepository()
        {
            conn = DatabaseConnection.getInstance();
            userRepo = new UserRepo();
        }

        public void createGroup(long adminid, string groupName)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            sqlCommand.CommandText = CREATE_GROUP;
            sqlCommand.Parameters.AddWithValue("@Name", groupName);
            sqlCommand.Parameters.AddWithValue("@Adminid", adminid);

            sqlCommand.ExecuteNonQuery();

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

                    groupsWrapperList
                        .Add(new Wrapper<Group>(reader.GetInt64(2), constructGroup(id, groupName)));
                    
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



        private static Group constructGroup(long id, string groupName)
        {
            Group group = new Group();
            group.id = id;
            group.name = groupName;

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
