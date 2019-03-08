using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Action.Model
{
    public class TimeRecordResponse
    {
        [JsonProperty("order")]
        public int Order;
        [JsonProperty("angleX")]
        public int AngleX;
        [JsonProperty("angleY")]
        public int AngleY;
        [JsonProperty("angleZ")]
        public int AngleZ;
        [JsonProperty("accelerationX")]
        public int AccelerationX;
        [JsonProperty("accelerationY")]
        public int AccelerationY;
        [JsonProperty("accelerationZ")]
        public int AccelerationZ;
    }
    
    public class ActivityResponse
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("tolerance")]
        public int Tolerance;
        [JsonProperty("timeRecords")]
        public List<TimeRecordResponse> TimeRecords;
        [JsonProperty("createDate")]
        public DateTime CreateDateTime;
        [JsonProperty("lastUpdateDate")]
        public DateTime LastUpdateDateTime;
    }
}