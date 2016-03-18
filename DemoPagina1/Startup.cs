using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoPagina1.Startup))]
namespace DemoPagina1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
