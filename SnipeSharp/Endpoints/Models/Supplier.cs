using Newtonsoft.Json;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.Models
{
    public class Supplier : CommonEndpointModel
    {
        [JsonProperty("name")]
        [RequestHeader("name")]
        public new string Name { get; set; }

        [RequestHeader("address")]
        [JsonProperty("address")]
        public string Address { get; set; }

        [RequestHeader("city")]
        [JsonProperty("city")]
        public string City { get; set; }

        [RequestHeader("state")]
        [JsonProperty("state")]
        public string State { get; set; }

        [RequestHeader("country")]
        [JsonProperty("country")]
        public string Country { get; set; }

        [RequestHeader("zip")]
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [RequestHeader("fax")]
        [JsonProperty("fax")]
        public string Fax { get; set; }

        [RequestHeader("phone")]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [RequestHeader("email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [RequestHeader("contact")]
        [JsonProperty("contact")]
        public string Contact { get; set; }

        [RequestHeader("notes")]
        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
