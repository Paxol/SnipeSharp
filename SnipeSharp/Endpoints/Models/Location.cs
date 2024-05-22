using Newtonsoft.Json;
using System.Collections.Generic;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.Models
{
    public class Location : CommonEndpointModel
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("address")]
        [RequestHeader("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        [RequestHeader("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        [RequestHeader("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        [RequestHeader("zip")]
        public string Zip { get; set; }

        [JsonProperty("assets_count")]
        public long? AssetsCount { get; set; }

        [JsonProperty("users_count")]
        public long? UsersCount { get; set; }

        [JsonProperty("parent")]
        [RequestHeader("parent_id")]
        public Location Parent { get; set; }

        [JsonProperty("manager")]
        public User Manager { get; set; }

        [JsonProperty("children")]
        public List<Location> Children { get; set; }
    }
}
