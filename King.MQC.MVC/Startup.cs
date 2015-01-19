using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(King.MQC.MVC.Startup))]
namespace King.MQC.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
