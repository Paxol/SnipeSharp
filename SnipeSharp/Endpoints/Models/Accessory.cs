using Newtonsoft.Json;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.Models
{
    public class Accessory : CommonEndpointModel
    {
        [JsonProperty("company")]
        [RequestHeader("company_id")]
        public Company Company { get; set; }

        [JsonProperty("manufacturer")]
        [RequestHeader("manufacturer_id")]
        public Manufacturer Manufacturer { get; set; }

        [JsonProperty("supplier")]
        [RequestHeader("supplier_id")]
        public Supplier Supplier { get; set; }

        [JsonProperty("model_number")]
        [RequestHeader("model_number")]
        public string ModelNumber { get; set; }        

        [JsonProperty("category")]
        [RequestHeader("category_id", true)]
        public Category Category { get; set; }

        [JsonProperty("location")]
        [RequestHeader("location_id")]
        public Location Location { get; set; }

        [JsonProperty("notes")]
        [RequestHeader("notes")]
        public string Notes { get; set; }

        [JsonProperty("qty")]
        [RequestHeader("qty", true)]
        public long? Quantity { get; set; }

        [JsonProperty("purchase_date")]
        [RequestHeader("purchase_date")]
        public ResponseDate PurchaseDate { get; set; }

        [JsonProperty("purchase_cost")]
        [RequestHeader("purchase_cost")]
        public string PurchaseCost { get; set; }

        [JsonProperty("order_number")]
        [RequestHeader("order_number")]
        public string OrderNumber { get; set; }

        [JsonProperty("min_qty")]
        [RequestHeader("min_qty")]
        public long? MinQty { get; set; }

        [JsonProperty("remaining_qty")]
        public long? RemainingQty { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("user_can_checkout")]
        public bool UserCanCheckout { get; set; }
    }
}
