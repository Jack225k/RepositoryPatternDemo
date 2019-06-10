using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarShopRepositoryImplementation.Startup))]
namespace CarShopRepositoryImplementation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
