using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularBlog.Startup))]
namespace AngularBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
