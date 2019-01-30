using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentMyWrox.Startup))]
namespace RentMyWrox
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
