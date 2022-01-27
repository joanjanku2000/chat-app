using Chat_application_with_windows_forms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.Utils
{
    class GroupListViewItem : ListViewItem
    {
        public Group group { get; private set; }

        public GroupListViewItem(Group group)
        {
            this.group = group;
            this.EnsureVisible();
            this.Text = group.name.Trim();
        }

    }
}
