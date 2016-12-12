using System.Threading.Tasks;
using Api.Architecture.Web.VM.Out;

namespace Api.Architecture.Application.Interface
{
    public interface IClientApp
    {
        Task<UserGetAllNamesOutVM> GetAllActiveNamesAsync();
    }
}
