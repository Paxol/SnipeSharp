using Newtonsoft.Json;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.Models
{
    public class Manufacturer : CommonEndpointModel
    {
        [JsonProperty("url")]
        [RequestHeader("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("support_url")]
        [RequestHeader("support_url")]
        public string SupportUrl { get; set; }

        [JsonProperty("support_phone")]
        [RequestHeader("support_phone")]
        public string SupportPhone { get; set; }

        [JsonProperty("support_email")]
        [RequestHeader("support_email")]
        public string SupportEmail { get; set; }

        [JsonProperty("assets_count")]
        public long AssetsCount { get; set; }

        [JsonProperty("licenses_count")]
        public long LicensesCount { get; set; }
    }
}
