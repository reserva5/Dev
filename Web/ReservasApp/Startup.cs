using Microsoft.Owin;
using Owin;
using ReservasApp.Common;

[assembly: OwinStartup(typeof(ReservasApp.Startup))]

namespace ReservasApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888


            //Configure Bearer Authentication
            ConfigureAuth(app);

            //Log trafic using Log4Net
            app.Use(typeof(Logging));

            //Configure SignalR self host
            ConfigureSignalR(app);


        }
    }
}
