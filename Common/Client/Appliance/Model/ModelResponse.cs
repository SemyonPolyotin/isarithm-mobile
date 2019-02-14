using System;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Appliance.Model
{
    public class ModelResponse
    {
        [JsonProperty("id")]
        public Guid Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("image")]
        public string Image;
        [JsonProperty("name_ru")]
        public string NameRu;
    }
}