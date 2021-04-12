using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_BanVeMayBay.Startup))]
namespace Website_BanVeMayBay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
