using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealEststeRelar.Startup))]
namespace RealEststeRelar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
