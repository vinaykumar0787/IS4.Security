using IdentityModel.Client;

namespace LMS.UI.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
