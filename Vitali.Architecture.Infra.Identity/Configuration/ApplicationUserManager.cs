using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Threading.Tasks;
using Api.Architecture.Infra.Identity.Context;
using Api.Architecture.Infra.Identity.Model;

namespace Api.Architecture.Infra.Identity.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            this.UserValidator = new CustomUserValidator(this);
            this.PasswordValidator = new CustomPasswordValidator();
            this.PasswordHasher = new CustomPasswordHasher();
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = false,
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new CustomPasswordValidator();

            // Configure password hasher
            manager.PasswordHasher = new CustomPasswordHasher();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string PasswordHash)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new ApplicationDbContext());

            IdentityResult identityResult = await UserValidator.ValidateAsync(user);            

            if(identityResult.Succeeded)
            {
                var PasswordHasher = new CustomPasswordHasher();
                user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
                user.SecurityStamp = Guid.NewGuid().ToString();
                
                var context = userStore.Context as ApplicationDbContext;
                context.Users.Add(user);
                context.Configuration.ValidateOnSaveEnabled = false;
                await context.SaveChangesAsync();
            }

            return identityResult;
        }

        public async Task<string> GeneratePasswordResetTokenUser(ApplicationUserManager ApplicationUserManager, string userId)
        {
            ApplicationUserManager.UserTokenProvider = GetDataProtectorTokenProvider(new DpapiDataProtectionProvider("CenarioCapital"));

            return await ApplicationUserManager.GeneratePasswordResetTokenAsync(userId);
        }

        public static DataProtectorTokenProvider<ApplicationUser> GetDataProtectorTokenProvider(IDataProtectionProvider dataProtectionProvider)
        {
            return new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        }
    }
}