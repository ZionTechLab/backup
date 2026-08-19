using System;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute("GatorsConfig", typeof(eDocs.Startup))]
[assembly: OwinStartupAttribute(typeof(eDocs.Startup))]

namespace eDocs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }

      
    }
}
