using Microsoft.Owin;
using Owin;
using MyWebHzg.Frontend.HzgWeb;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace MyWebHzg.Frontend.HzgWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
