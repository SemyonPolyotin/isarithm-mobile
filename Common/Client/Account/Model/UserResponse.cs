using System;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Account.Model
{
    public class UserResponse
    {
        [JsonProperty("id")]
        public Guid Id;
        [JsonProperty("username")]
        public string Username;
        [JsonProperty("firstname")]
        public string Firstname;
        [JsonProperty("surname")]
        public string Surname;
        [JsonProperty("email")]
        public string Email;
        [JsonProperty("regDate")]
        public string RegDate;
        [JsonProperty("bio")]
        public string Bio;
        [JsonProperty("avatar")]
        public string Avatar;
    }
}