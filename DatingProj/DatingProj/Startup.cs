using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatingProj.Startup))]
namespace DatingProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
