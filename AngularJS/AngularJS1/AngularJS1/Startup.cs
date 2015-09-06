using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJS1.Startup))]
namespace AngularJS1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
