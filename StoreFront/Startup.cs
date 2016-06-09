using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Store_Front.Startup))]
namespace Store_Front
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
