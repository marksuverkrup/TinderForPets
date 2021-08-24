using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TinderForPets.WebMVC.Startup))]
namespace TinderForPets.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
