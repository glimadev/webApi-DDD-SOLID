using Helpers.Security;
using Microsoft.AspNet.Identity;

namespace Api.Architecture.Infra.Identity.Configuration
{
    internal class CustomPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return Crypto.Sha1.Encrypt(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var testHash = Crypto.Sha1.Encrypt(providedPassword);

            return hashedPassword.Equals(testHash) || hashedPassword.Equals(providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}
