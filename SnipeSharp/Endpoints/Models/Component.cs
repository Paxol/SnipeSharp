using Newtonsoft.Json;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.Models
{
    public class Component : CommonEndpointModel
    {
        [JsonProperty("serial_number")]
        [RequestHeader("serial_number")]
        public string SerialNumber { get; set; }

        [JsonProperty("location")]
        [RequestHeader("location_id")]
        public Location Location { get; set; }

        [JsonProperty("qty")]
        [RequestHeader("qty", true)]
        public long? Quantity { get; set; }

        [JsonProperty("min_amt")]
        [RequestHeader("min_amt")]
        public long? MinAmt { get; set; }

        [JsonProperty("category")]
        [RequestHeader("category_id", true)]
        public Category Category { get; set; }

        [JsonProperty("order_number")]
        [RequestHeader("order_number")]
        public string OrderNumber { get; set; }

        [JsonProperty("purchase_date")]
        [RequestHeader("purchase_date")]
        public ResponseDate PurchaseDate { get; set; }

        [JsonProperty("purchase_cost")]
        [RequestHeader("purchase_cost")]
        public string PurchaseCost { get; set; }

        [JsonProperty("remaining")]
        public long? Remaining { get; set; }

        [JsonProperty("company")]
        [RequestHeader("company_id")]
        public Company Company { get; set; }

        [JsonProperty("user_can_checkout")]
        public bool UserCanCheckout { get; set; }
    }
}
