using Newtonsoft.Json;

namespace Isarithm.Common.Client.Action.Model
{
    public class ActivityResponse
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("name")]
        public string Name;
    }
}