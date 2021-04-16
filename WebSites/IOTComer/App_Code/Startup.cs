using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOTComer.Startup))]
namespace IOTComer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
