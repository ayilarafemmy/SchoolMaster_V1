using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolMaster_Admin.Startup))]
namespace SchoolMaster_Admin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
