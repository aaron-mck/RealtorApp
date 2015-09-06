using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RealtorApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Check to see if the ListingImages folder exists
            //Since this app is running in IIS Express under the logged in user, it should work
            //This is only here so this app runs from Git without having to set anything up
            string listingDir = Server.MapPath("~/ListingImages/");
            if (!Directory.Exists(listingDir))
            {
                Directory.CreateDirectory(listingDir);
            }
        }
    }
}
