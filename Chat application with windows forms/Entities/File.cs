using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Entities
{
    class MessageFile
    {
        public Int64 id { get; set; }
        public long sender { get; set; }
        public long receiver { get; set; }

        public string name; 

        public byte[] file;

      
    }
}
