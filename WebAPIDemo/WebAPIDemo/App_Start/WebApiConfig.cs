using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebAPIDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.Routes.MapHttpRoute(
            //       name: "BreezeApi",
            //       routeTemplate: "breeze/{controller}/{action}"
            //   );

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            var settings = json.SerializerSettings;
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            

            var jsonStyleFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonStyleFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            config.Formatters.Add(jsonStyleFormatter);

        }
    }
}
