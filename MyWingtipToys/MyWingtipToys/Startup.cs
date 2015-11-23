using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWingtipToys.Startup))]
namespace MyWingtipToys
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
