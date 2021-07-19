using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(registration.Startup))]
namespace registration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
