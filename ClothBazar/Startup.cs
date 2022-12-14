using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClothBazar.Startup))]
namespace ClothBazar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
