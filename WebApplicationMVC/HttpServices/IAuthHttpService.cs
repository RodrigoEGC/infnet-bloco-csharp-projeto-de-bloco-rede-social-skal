using Crosscutting.Identity.RequestModels;
using System.Threading.Tasks;

namespace WebApplicationMVC.HttpServices
{
    public interface IAuthHttpService
    {
        Task<string> GetTokenAsync(LoginRequest loginRequest);
    }
}
