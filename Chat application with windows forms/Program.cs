using Chat_application_with_windows_forms.Client;
using Chat_application_with_windows_forms.Login;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_application_with_windows_forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WebApp.Start<Startup>("http://localhost:8080");
            Application.Run(new MessagesLayout());
        }
    }
}
