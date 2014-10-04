using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MessangerFirst.WebUI.Startup))]
namespace MessangerFirst.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
