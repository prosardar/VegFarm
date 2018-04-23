using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Owin;
using Unity.AspNet.WebApi;

namespace VegFarm.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Formatters.Clear();
            config.Formatters.Add(new JsonpMediaTypeFormatter());
           
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.Container);
            config.EnableCors(new EnableCorsAttribute("*", "*", "GET,PUT,POST,DELETE"));

            appBuilder.UseWebApi(config);            
        }
    }
}
