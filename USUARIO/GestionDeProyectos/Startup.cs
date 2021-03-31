using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionDeProyectos.Startup))]
namespace GestionDeProyectos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
