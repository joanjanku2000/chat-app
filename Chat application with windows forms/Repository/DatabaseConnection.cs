using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Repository
{
    class DatabaseConnection
    {
        private static SqlConnection conn;
        private static string connectionString = "Data Source=DESKTOP-M7F6609;Initial Catalog=chat_applicatin;Integrated Security=True";
        public static SqlConnection getInstance()
        {
            if (conn == null )
            {
                conn = new SqlConnection(connectionString);
            }
            return conn;
        }
    }
}
