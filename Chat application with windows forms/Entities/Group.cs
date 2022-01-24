using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Entities
{
    class Group
    {
        public long id;
        public string name;
        public User admin;
        public List<User> participants;
        public List<GroupMessage> messages;

        public Group(long id, string name,User admin, List<User> participants, List<GroupMessage> messages)
        {
            this.id = id;
            this.name = name;
            this.admin = admin;
            this.participants = participants;
            this.messages = messages;
        }

        public Group() { }
    }
}
