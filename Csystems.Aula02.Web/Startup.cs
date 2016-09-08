using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Csystems.Aula02.Web.Startup))]
namespace Csystems.Aula02.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
