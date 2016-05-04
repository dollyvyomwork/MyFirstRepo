using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitApplication.Startup))]
namespace GitApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
