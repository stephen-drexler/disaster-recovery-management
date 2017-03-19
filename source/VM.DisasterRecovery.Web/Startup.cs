using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VM.DisasterRecovery.Web.Startup))]
namespace VM.DisasterRecovery.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
