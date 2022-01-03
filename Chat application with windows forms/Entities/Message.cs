using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Entities
{
    public class Message
    {
        public Int64 id {get; set;}
        public User sender { get; set; }
        public User receiver { get; set; }
        public string message { get; set; }
        public bool received { get; set; }
        public bool seen { get; set; }

        public Message() { }
        public Message (User sender, User receiver, string message, bool received, bool seen)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.message = message;
            this.received = received;
            this.seen = seen;
        }

    }
}
