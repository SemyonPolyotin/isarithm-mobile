using System.Threading.Tasks;
using Isarithm.Common.Client.Auth.Model;
using UserResponse = Isarithm.Common.Client.Auth.Model.UserResponse;

namespace Isarithm.Common.Client.Auth
{
    public interface IAuthService
    {
        Task<UserResponse> CreateUserAsync(UserCredentialsRequest userCredentialsRequest);
        
        Task<UserTokenResponse> CreateTokenAsync(UserCredentialsRequest userCredentialsRequest);
        Task DeleteTokenAsync(UserTokenRequest userTokenRequest);
        Task<UserResponse> CheckTokenAsync(UserTokenRequest userTokenRequest);
        Task<UserTokenResponse> RefreshTokenAsync(UserTokenRequest userTokenRequest);
    }
}