using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcRaamatupood.Startup))]
namespace MvcRaamatupood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
