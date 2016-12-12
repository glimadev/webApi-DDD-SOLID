using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Api.Architecture.Infra.Identity.Context;
using Api.Architecture.Infra.Identity.Model;

namespace Api.Architecture.Infra.Identity.Configuration
{
    internal class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(UserManager<ApplicationUser, string> manager)
            : base(manager)
        {
            AllowOnlyAlphanumericUserNames = true;
            RequireUniqueEmail = true;
            _manager = manager;
        }

        private UserManager<ApplicationUser, string> _manager { get; set; }

        /// <summary>
        ///     Validates a user before saving
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var errors = new List<string>();

            //ValidateUserName(item, errors);

            if (RequireUniqueEmail)
            {
                ValidateEmail(item, errors);
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }

        private void ValidateUserName(ApplicationUser user, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add(String.Format("Informe o nome de usuário"));
            }
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
            {
                // If any characters are not letters or digits, its an illegal user name
                errors.Add(String.Format("O nome de usuário {0} dever ser alfanumérico", user.UserName));
            }
            else
            {
                UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new ApplicationDbContext());

                var context = userStore.Context as ApplicationDbContext;

                var owner = context.Users.Where(u => u.UserName == user.UserName && !u.Deleted).FirstOrDefault();

                if (owner != null && !EqualityComparer<string>.Default.Equals(owner.Id, user.Id))
                {
                    errors.Add(String.Format(CultureInfo.CurrentCulture, "O nome de usuário {0} já foi cadastrado", user.UserName));
                }
            }
        }

        // make sure email is not empty, valid, and unique
        private void ValidateEmail(ApplicationUser user, List<string> errors)
        {
            if (!String.IsNullOrWhiteSpace(user.Email))
            {
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    errors.Add(String.Format(CultureInfo.CurrentCulture, "Informe o e-mail", "Email"));
                    return;
                }
                try
                {
                    var m = new MailAddress(user.Email);
                }
                catch (FormatException)
                {
                    errors.Add(String.Format(CultureInfo.CurrentCulture, "E-mail inválido"));
                    return;
                }
            }

            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new ApplicationDbContext());

            var context = userStore.Context as ApplicationDbContext;

            var owner = context.Users.Where(u => u.Email == user.Email && !u.Deleted).FirstOrDefault();

            if (owner != null)
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, "O e-mail {0} já foi cadastrado", user.Email));
            }
        }
    }
}
