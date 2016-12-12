using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Architecture.Infra.Identity.Configuration;
using Api.Architecture.Infra.Identity.Model;

namespace Api.Architecture.Web.Provider
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            this._publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            var roleManager = context.OwinContext.Get<ApplicationRoleManager>();

            string passwordHash = Framework.Security.Security.Crypto.Sha1.Encrypt(context.Password);

            ApplicationUser user = await userManager.FindAsync(context.UserName, passwordHash);

            if (user != null)
            {
                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
                   OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                    CookieAuthenticationDefaults.AuthenticationType);

                List<string> roles = new List<string>();

                foreach (var role in user.Roles)
                {
                    var userRole = await roleManager.FindByIdAsync(role.RoleId);

                    if (userRole != null)
                    {
                        roles.Add(userRole.Name);
                    }
                }

                AuthenticationProperties properties = CreateProperties(
                    user.Id,
                    user.UserName,
                    JsonConvert.SerializeObject(user.Claims.Select(x => new { x.ClaimType, x.ClaimValue }).ToList()),
                    JsonConvert.SerializeObject(roles)
                );

                AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesIdentity);
            }
            else
            {
                context.SetError("Acesso negado", "Usuário inválido");
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userId, string userName, string claims, string roles)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userId", userId },
                { "userName", userName },
                { "claims", claims },
                { "roles", roles }
            };
            return new AuthenticationProperties(data);
        }
    }
}