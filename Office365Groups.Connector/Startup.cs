using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Office365Groups.Connector.Startup))]
namespace Office365Groups.Connector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
