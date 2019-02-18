using System;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Account.Model
{
    public class DeviceRequest
    {
        [JsonProperty("modelId")]
        public Guid ModelId;
        [JsonProperty("name")]
        public string Name;
    }
}