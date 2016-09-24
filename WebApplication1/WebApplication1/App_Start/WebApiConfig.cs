using System.Web.Http;
using Confluence.Model;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            config.MapHttpAttributeRoutes();

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            config.Formatters.Insert(0, new BrowserJsonFormatter(json));
        }
    }
}
