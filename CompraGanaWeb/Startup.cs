using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompraGanaWeb.Startup))]
namespace CompraGanaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
