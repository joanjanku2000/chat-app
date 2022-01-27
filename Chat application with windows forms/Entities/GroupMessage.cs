using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Entities
{
   public class GroupMessage
    {
        public long id;
        public string message;
        public User sender;
        public Group group;

        public GroupMessage(long id, string message, User sender, Group group)
        {
            this.id = id;
            this.message = message;
            this.sender = sender;
            this.group = group;
        }

        public GroupMessage(long id, string message)
        {
            this.id = id;
            this.message = message;
        }
    }
}
