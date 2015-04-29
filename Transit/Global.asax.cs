using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Transit
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			AreaRegistration.RegisterAllAreas();
			Database.SetInitializer(new Models.DBInitializer());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
