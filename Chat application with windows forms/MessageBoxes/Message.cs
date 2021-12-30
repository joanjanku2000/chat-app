using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.MessageBoxes
{
    public class MessageB
    {
        public static void ERROR(string name, string message)
        {
            MessageBox.Show(message, name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void INFORMATION(string message, string name)
        {
            MessageBox.Show(name, message, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void WARNING(string message, string name)
        {
            MessageBox.Show(name, message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
