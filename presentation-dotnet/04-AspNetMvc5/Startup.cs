using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_04_AspNetMvc5.Startup))]
namespace _04_AspNetMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
