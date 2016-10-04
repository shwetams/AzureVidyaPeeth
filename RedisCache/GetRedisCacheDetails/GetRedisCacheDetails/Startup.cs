using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetRedisCacheDetails.Startup))]
namespace GetRedisCacheDetails
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
