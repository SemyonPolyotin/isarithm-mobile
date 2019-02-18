using Newtonsoft.Json;

namespace Isarithm.Common.Client.Auth.Model
{
    public class UserCredentialsRequest
    {
        [JsonProperty("username")]
        public string Username;
        [JsonProperty("password")]
        public string Password;
    }
}