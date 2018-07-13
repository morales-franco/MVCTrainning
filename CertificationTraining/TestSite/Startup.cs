using Owin;

namespace TestSite
{
    //Generamos clase Startup para utilizar SignalR
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}