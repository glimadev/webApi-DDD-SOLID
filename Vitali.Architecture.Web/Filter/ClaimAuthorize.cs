using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Api.Architecture.Web.Filter
{
    public class ClaimAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimAuthorizeAttribute(string claimName, string claimValue)
        {
            this._claimName = claimName;
            this._claimValue = claimValue;
        }

        public ClaimAuthorizeAttribute(string claimName)
        {
            this._claimName = claimName;
            this._claimValue = null;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            if (claim != null)
            {
                if (String.IsNullOrWhiteSpace(_claimValue))
                {
                    return true;
                }
                else
                {
                    return claim.Value == _claimValue;
                }
            }

            return false;
        }
    }
}