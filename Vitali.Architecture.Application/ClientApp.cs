using System.Threading.Tasks;
using Api.Architecture.Application.Interface;
using Api.Architecture.Web.VM.Out;
using Api.Architecture.Infra.Identity.Configuration;
using Api.Architecture.Infra.Identity.Model;

namespace Api.Architecture.Application
{
    public class ClientApp : IClientApp
    {
        #region [ DI ]

        private readonly IClientService _userService;

        public ClientApp(IClientService userService, ApplicationUserManager userManager)
            : base()
        {
            this._userManager = userManager;
            this._userService = userService;
        }

        #endregion

        public async Task<UserGetAllNamesOutVM> GetAllActiveNamesAsync()
        {
            ApplicationUser user = new ApplicationUser();

            UserGetAllNamesOut userGetAllNamesOut = await _userService.GetAllActiveNamesAsync();

            UserGetAllNamesOutVM userGetAllNamesOutVM = Mapper.Map<UserGetAllNamesOutVM>(userGetAllNamesOut);

            return userGetAllNamesOutVM;
        }
    }
}
