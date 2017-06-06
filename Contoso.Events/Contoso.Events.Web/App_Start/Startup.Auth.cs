using System.Configuration;
using Microsoft.Owin.Security;
using Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Cookies;

namespace Contoso.Events.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = ConfigurationManager.AppSettings["aad:Authority"],
                ClientId = ConfigurationManager.AppSettings["aad:ClientId"],
                PostLogoutRedirectUri = ConfigurationManager.AppSettings["aad:PostLogoutRedirectUri"],
                RedirectUri = ConfigurationManager.AppSettings["aad:PostLogoutRedirectUri"]
            });
        }
    }
}
