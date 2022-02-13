using Chat_application_with_windows_forms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.Utils
{
    class ContactListViewItem : ListViewItem  
    {
        public User user { get; }

        public ContactListViewItem(User user)
        {
            this.user = user;
        }
    }

    class FileListViewItem : ListViewItem
    {
        public MessageFile file { get; }

        public FileListViewItem(MessageFile file)
        {
            this.file = file;
            this.Text = file.name.Trim();
        }
    }
}
