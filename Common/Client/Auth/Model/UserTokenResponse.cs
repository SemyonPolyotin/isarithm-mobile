using System;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Auth.Model
{
    public class UserTokenResponse
    {
        [JsonProperty("accessToken")]
        public string AccessToken;
        [JsonProperty("AccessExpires")]
        public DateTime AccessExpires;
        [JsonProperty("refreshToken")]
        public string RefreshToken;
        [JsonProperty("refreshExpires")]
        public DateTime RefreshExpires;
    }
}