using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstShop.Web.UI.Startup))]
namespace MyFirstShop.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
