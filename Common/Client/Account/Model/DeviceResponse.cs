using System;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Account.Model
{
    public class DeviceResponse
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("ownerId")]
        public Guid OwnerId;
        [JsonProperty("modelId")]
        public Guid ModelId;
        [JsonProperty("regDate")]
        public string RegDate;
        [JsonProperty("name")]
        public string Name;
    }
}