using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GitHub_Users.App_Start;
using Microsoft.Practices.Unity;

namespace GitHub_Users
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterTypes(new UnityContainer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
