using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace AuthPlayground.Api.Extensions
{
    public static class IAppBuilderExtensions
    {
        public static void ConfigureToken(this IAppBuilder app, IOAuthAuthorizationServerProvider provider)
        {
            var options = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = provider
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}