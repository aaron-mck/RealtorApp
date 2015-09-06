using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealtorApp.Web.Startup))]
namespace RealtorApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
