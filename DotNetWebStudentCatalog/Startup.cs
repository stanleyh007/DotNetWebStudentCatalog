using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetWebStudentCatalog.Startup))]
namespace DotNetWebStudentCatalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
