using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMobileStore.Startup))]
namespace EMobileStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
