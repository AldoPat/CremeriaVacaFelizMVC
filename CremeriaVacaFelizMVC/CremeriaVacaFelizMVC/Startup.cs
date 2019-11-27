using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CremeriaVacaFelizMVC.Startup))]
namespace CremeriaVacaFelizMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
