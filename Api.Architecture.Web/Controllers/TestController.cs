using System.Threading.Tasks;
using System.Web.Http;
using Api.Architecture.Application.Interface;
using Api.Architecture.Web.VM.Out;

namespace Api.Architecture.Web.Controllers
{
    public class TestController : ApiController
    {
        private readonly IClientApp _userApp;

        public TestController(IClientApp userApp)
        {
            this._userApp = userApp;
        }

        [HttpGet]
        public async Task<UserGetAllNamesOutVM> Index()
        {
            UserGetAllNamesOutVM userGetAllNamesOutVM = await _userApp.GetAllActiveNamesAsync();

            return userGetAllNamesOutVM;
        }
    }
}
