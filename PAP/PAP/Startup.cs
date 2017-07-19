using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAP.Startup))]
namespace PAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
