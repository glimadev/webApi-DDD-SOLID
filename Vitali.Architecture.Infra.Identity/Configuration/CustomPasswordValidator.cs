using Microsoft.AspNet.Identity;

namespace Api.Architecture.Infra.Identity.Configuration
{
    internal class CustomPasswordValidator : PasswordValidator
    {
        public CustomPasswordValidator()
        {
            RequiredLength = 4;
            RequireNonLetterOrDigit = false;
            RequireDigit = false;
            RequireLowercase = false;
            RequireUppercase = false;
        }
    }
}
