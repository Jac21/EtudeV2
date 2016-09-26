using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace EtudeV2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Project",
                routeTemplate: "api/projects/{projectId}",
                defaults: new { controller = "Projects", projectId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name:"Track",
                routeTemplate: "api/tracks/{id}",
                 defaults: new { controller = "Tracks", id = RouteParameter.Optional }
                );

            // Send responses as JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
