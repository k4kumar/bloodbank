using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace bloodbank
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // setup camel-case for property names
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));

            config.Routes.MapHttpRoute(
              "BloodDonor_update_donation_date",
              "api/v1/blooddonor/update_donation_date",
              new { controller = "BloodDonor", action = "UpdateDonationDate", id = RouteParameter.Optional, date = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               "BloodDonor_approve",
               "api/v1/blooddonor/approve",
               new { controller = "BloodDonor", action = "Approve", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               "BloodDonor_register",
               "api/v1/blooddonor/registration",
               new { controller = "BloodDonor", action = "Registration", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                "ActiveBloodDonors",
                "api/v1/blooddonors",
                new { controller = "BloodDonor", action = "GetActiveBloodDonors", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                "BloodDonors",
                "api/v1/admin/blooddonors",
                new { controller = "BloodDonor", action = "GetBloodDonors", id = RouteParameter.Optional }
            );

            

            config.Routes.MapHttpRoute(
                "Login",
                "api/v1/admin/login",
                new { controller = "User", action = "Login", id=RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
