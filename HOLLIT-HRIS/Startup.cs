using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HOLLIT_HRIS.Startup))]
namespace HOLLIT_HRIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
