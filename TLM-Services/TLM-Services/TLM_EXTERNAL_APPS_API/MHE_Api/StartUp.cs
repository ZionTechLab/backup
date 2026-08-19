using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using MHE_Api.Models;

[assembly: OwinStartup(typeof(MHE_Api.StartUp))]

namespace MHE_Api
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            var based = AppDomain.CurrentDomain.BaseDirectory;
            Environment.CurrentDirectory = based;
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}
