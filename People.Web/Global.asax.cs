using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using People.Web.App_Start;

namespace People.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Initialize();
        }
    }
}
