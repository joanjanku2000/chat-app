using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Entities
{
    class MessageResult
    {
        public Int64 id { get; set; }
        public Int64 senderId { get; set; }
        public Int64 receiverId { get; set; }
        public string message { get; set; }
        public bool received { get; set; }
        public bool seen { get; set; }

    }
}
