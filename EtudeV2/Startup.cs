using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EtudeV2.Startup))]
namespace EtudeV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
