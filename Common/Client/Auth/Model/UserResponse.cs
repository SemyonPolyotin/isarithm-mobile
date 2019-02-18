using System;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Auth.Model
{
    public class UserResponse
    {
        [JsonProperty("id")]
        public Guid Id;
        [JsonProperty("username")]
        public string Username;
    }
}