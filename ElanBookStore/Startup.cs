using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElanBookStore.Startup))]
namespace ElanBookStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
