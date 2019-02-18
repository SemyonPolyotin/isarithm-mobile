using Newtonsoft.Json;

namespace Isarithm.Common.Client.Auth.Model
{
    public class UserTokenRequest
    {
        [JsonProperty("accessToken")]
        public string AccessToken;
        [JsonProperty("refreshToken")]
        public string RefreshToken;
    }
}