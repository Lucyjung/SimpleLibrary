using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MongoContext mongo = new MongoContext();
            UserModel user = new UserModel();
            user.Create();
            UserSchema userInfo = user.Query("0999");
            userInfo.name = "Prawit";
            user.Update(userInfo);
            user.Delete("0999");
        }
    }
}
