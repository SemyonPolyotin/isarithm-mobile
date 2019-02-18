using Newtonsoft.Json;

namespace Isarithm.Common.Client.Account.Model
{
    public class UserRequest
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("username")]
        public string Username;
        [JsonProperty("email")]
        public string Email;
        [JsonProperty("regDate")]
        public string RegDate;
    }
}