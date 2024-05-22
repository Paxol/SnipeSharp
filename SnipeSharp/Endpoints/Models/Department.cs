using Newtonsoft.Json;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.Models
{
    public class Department : CommonEndpointModel
    {
        [JsonProperty("company_id")]
        [RequestHeader("company_id")]
        public Company Company { get; set; }

        [JsonProperty("manager")]
        [RequestHeader("manager_id")]
        public User Manager { get; set; }

        [JsonProperty("location")]
        [RequestHeader("location_id")]
        public Location Location { get; set; }
    }
}
