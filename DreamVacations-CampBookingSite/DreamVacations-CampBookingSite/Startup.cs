﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(DreamVacations_CampBookingSite.Startup))]

namespace DreamVacations_CampBookingSite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
               // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

                app.UseCors(CorsOptions.AllowAll);

                OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
                {
                    TokenEndpointPath = new PathString("/token"),
                    Provider = new ApplicationOAuthProvider(),
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                    AllowInsecureHttp = true
                };
                app.UseOAuthAuthorizationServer(option);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            
        }
    }
}
