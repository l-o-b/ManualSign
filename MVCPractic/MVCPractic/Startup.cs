using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPractic.Startup))]
namespace MVCPractic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
