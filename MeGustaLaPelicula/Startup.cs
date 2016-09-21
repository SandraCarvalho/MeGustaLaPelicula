using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeGustaLaPelicula.Startup))]
namespace MeGustaLaPelicula
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
