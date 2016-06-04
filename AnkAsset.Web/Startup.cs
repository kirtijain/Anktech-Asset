using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnkAsset.Web.Startup))]
namespace AnkAsset.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
