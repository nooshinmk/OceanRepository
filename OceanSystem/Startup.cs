using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OceanSystem.Startup))]
namespace OceanSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
