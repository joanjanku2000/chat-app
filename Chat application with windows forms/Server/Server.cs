using Chat_application_with_windows_forms.Entities;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Server
{
    class Server
    {
        private IDisposable _signalR;

        private BindingList<User> _clients = new BindingList<User>();
        private BindingList<string> _groups = new BindingList<string>();

        public Server()
        {
            _signalR = WebApp.Start<Startup>("http://localhost:8080");
        }
    }
}
