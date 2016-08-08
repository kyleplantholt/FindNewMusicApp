using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindNewMusicApp.Startup))]
namespace FindNewMusicApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
