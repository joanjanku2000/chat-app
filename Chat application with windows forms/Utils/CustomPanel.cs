using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.Utils
{
    class ChatPanel : Panel 
    {
        public string phoneNumber { get; set; }
    }

    class ChatButton : Button
    {
        public string phoneNumber { get; set; }
    }
}
