using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Transit.Startup))]
namespace Transit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
