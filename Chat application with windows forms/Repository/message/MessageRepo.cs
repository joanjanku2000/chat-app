using Chat_application_with_windows_forms.Repository;
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

        public MessageRepo ()
        {
            conn = DatabaseConnection.getInstance();
        }

        public void sendMessage(User sender, User receiver , string message)
        {
            // leaves messag trace in the database
        }
    }
}
