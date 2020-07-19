using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bloodbank
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Logout
            routes.MapRoute(
                "logout",
                "logout",
                new { action = "Logout", controller = "Users", id = UrlParameter.Optional }
            );

            //Login
            routes.MapRoute(
                "login",
                "login",
                new { action = "Login", controller = "Users", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            "BloodDonors",
            "blood_donors",
            new { controller = "BloodDonor", action = "Index", id = UrlParameter.Optional, title = UrlParameter.Optional }
           );

            routes.MapRoute(
               "BloodDonorCreate",
               "blood_donor_create",
               new { controller = "BloodDonor", action = "Create", id = UrlParameter.Optional, title = UrlParameter.Optional }
           );

            routes.MapRoute(
               "HospitalCreate",
               "hospital_create",
               new { controller = "Hospital", action = "Create", id = UrlParameter.Optional, title = UrlParameter.Optional }
           );

            routes.MapRoute(
               "Hospitals",
               "hospitals",
               new { controller = "Hospital", action = "Index", id = UrlParameter.Optional, title = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
