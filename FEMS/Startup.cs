using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FEMS.Startup))]
namespace FEMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
