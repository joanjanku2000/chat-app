
using Owin;
using Microsoft.Owin.Cors;
namespace Chat_application_with_windows_forms
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //CORS need to be enabled for calling SignalR service 
            app.UseCors(CorsOptions.AllowAll);
            //Find and reigster SignalR hubs
            app.MapSignalR();
        }
    }
}
