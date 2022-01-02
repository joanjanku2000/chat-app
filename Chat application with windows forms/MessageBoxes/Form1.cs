using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms.MessageBoxes
{
    public partial class InputMessage : Form
    {
        public string text;
        public InputMessage(string label)
        {
           
            InitializeComponent();
            label1.Text = label;
            this.Focus();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                text = textBox1.Text;
                this.Close();
            }
           
        }
    }
}
