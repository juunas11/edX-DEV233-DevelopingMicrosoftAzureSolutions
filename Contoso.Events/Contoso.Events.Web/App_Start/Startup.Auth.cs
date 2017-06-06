using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Cookies;

namespace Contoso.Events.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            //app.UseWindowsAzureActiveDirectoryBearerAuthentication(
            //    new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            //    {
            //        Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
            //        TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
            //        },
            //    });
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                Authority = ConfigurationManager.AppSettings["aad:Authority"],
                ClientId = ConfigurationManager.AppSettings["aad:ClientId"],
                PostLogoutRedirectUri = ConfigurationManager.AppSettings["aad:PostLogoutRedirectUri"],
                RedirectUri = ConfigurationManager.AppSettings["aad:PostLogoutRedirectUri"]
            });
        }
    }
}
