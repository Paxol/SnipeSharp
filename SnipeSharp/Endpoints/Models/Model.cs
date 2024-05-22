using Newtonsoft.Json;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.Models
{
    public class Model : CommonEndpointModel
    {
        [JsonProperty("manufacturer")]
        [RequestHeader("manufacturer_id", true)]
        public Manufacturer Manufacturer { get; set; }

        [JsonProperty("category")]
        [RequestHeader("category_id", true)]
        public Category Category { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("model_number")]
        [RequestHeader("model_number")]
        public string ModelNumber { get; set; }

        [JsonProperty("depreciation")]
        [RequestHeader("depreciation_id")]
        public Depreciation Depreciation { get; set; }

        [JsonProperty("assets_count")]
        public long AssetsCount { get; set; }

        [JsonProperty("eol")]
        [RequestHeader("eol")]
        public string Eol { get; set; }

        [JsonProperty("notes")]
        [RequestHeader("notes")]
        public string Notes { get; set; }

        [JsonProperty("fieldset")]
        [RequestHeader("fieldset_id")]
        public FieldSet FieldSet { get; set; }

        [JsonProperty("deleted_at")]
        public ResponseDate DeletedAt { get; set; }
    }
}
