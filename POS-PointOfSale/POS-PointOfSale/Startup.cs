using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POS_PointOfSale.Startup))]
namespace POS_PointOfSale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
