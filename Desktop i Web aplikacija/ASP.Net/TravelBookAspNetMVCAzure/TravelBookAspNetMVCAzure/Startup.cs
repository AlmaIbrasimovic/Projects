using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelBookAspNetMVCAzure.Startup))]
namespace TravelBookAspNetMVCAzure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
