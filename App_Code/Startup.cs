using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSLRegisterWeb.Startup))]
namespace RSLRegisterWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
