using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exameron.Startup))]
namespace Exameron
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
