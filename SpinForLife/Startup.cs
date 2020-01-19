using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpinForLife.Startup))]
namespace SpinForLife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
