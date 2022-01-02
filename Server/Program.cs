using Chat_application_with_windows_forms;
using Microsoft.Owin.Hosting;
using System;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:8080");
           
            Console.WriteLine("Hello World!");
        }
    }
}
