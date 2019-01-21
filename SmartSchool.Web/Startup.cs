using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartSchool.Web.Startup))]
namespace SmartSchool.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
