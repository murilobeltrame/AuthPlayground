using AuthPlayground.Api.Extensions;
using AuthPlayground.Api.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(AuthPlayground.Api.Startup))]

namespace AuthPlayground.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
            );

            app.UseCors(CorsOptions.AllowAll);

            app.ConfigureToken(new OAuthProvider());

            app.UseWebApi(config);
        }
    }
}
