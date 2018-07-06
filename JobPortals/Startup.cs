using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobPortals.Startup))]
namespace JobPortals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
