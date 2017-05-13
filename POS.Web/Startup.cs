using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POS.Web.Startup))]
namespace POS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
