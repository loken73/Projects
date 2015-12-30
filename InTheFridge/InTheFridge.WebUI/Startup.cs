using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InTheFridge.WebUI.Startup))]
namespace InTheFridge.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
