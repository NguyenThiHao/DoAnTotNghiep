using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectManage.Startup))]
namespace ProjectManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
