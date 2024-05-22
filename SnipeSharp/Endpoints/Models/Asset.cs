using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.EndpointHelpers;
using SnipeSharp.JsonConverters;
using System.Collections.Generic;

namespace SnipeSharp.Endpoints.Models
{
    // TODO: Make constructor that forces required fields
    public class Asset : CommonEndpointModel
    {
        [JsonProperty("asset_tag")]
        [RequestHeader("asset_tag")]
        public string AssetTag { get; set; }

        [JsonProperty("serial")]
        [RequestHeader("serial")]
        public string Serial { get; set; }

        [JsonProperty("model")]
        [RequestHeader("model_id")]
        public Model Model { get; set; }

        [JsonProperty("model_number")]
        [RequestHeader("model_number")]
        public string ModelNumber { get; set; }

        [JsonProperty("status_label")]
        [RequestHeader("status_id", true)]
        public StatusLabel StatusLabel { get; set; }

        [JsonProperty("category")]
        [RequestHeader("category_id")]
        public Category Category { get; set; }

        [JsonProperty("manufacturer")]
        [RequestHeader("manufacturer_id")]
        public Manufacturer Manufacturer { get; set; }

        [JsonProperty("supplier")]
        [RequestHeader("supplier_id")]
        public Supplier Supplier { get; set; }

        [JsonProperty("notes")]
        [RequestHeader("notes")]
        public string Notes { get; set; }

        [JsonProperty("company")]
        [RequestHeader("company_id")]
        public Company Company { get; set; }

        [JsonProperty("location")]
        [RequestHeader("location_id")]
        public Location Location { get; set; }

        [JsonProperty("rtd_location")]
        [RequestHeader("rtd_location_id")]
        public Location RtdLocation { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("assigned_to")]
        [RequestHeader("assigned_to")]
        public User AssignedTo { get; set; }

        private string _warrantyMonths;

        [JsonProperty("warranty_months")]
        [RequestHeader("warranty_months")]
        public string WarrantyMonths
        {
            get { return _warrantyMonths; }
            set
            {
                this._warrantyMonths = value?.Replace(" months", "");
            }
        }

        [JsonProperty("warranty_expires")]
        public ResponseDate WarrantyExpires { get; set; }

        [JsonProperty("deleted_at")]
        public ResponseDate DeletedAt { get; set; }

        [JsonProperty("purchase_date")]
        [RequestHeader("purchase_date")]
        [JsonConverter(typeof(ResponseDateTimeConverter))]
        public ResponseDate PurchaseDate { get; set; }

        [JsonProperty("expected_checkin")]
        public ResponseDate ExpectedCheckin { get; set; }

        [JsonProperty("last_checkout")]
        [RequestHeader("last_checkout")]
        public ResponseDate LastCheckout { get; set; }

        [JsonProperty("purchase_cost")]
        [RequestHeader("purchase_cost")]
        public string PurchaseCost { get; set; }

        [JsonProperty("user_can_checkout")]
        public bool UserCanCheckout { get; set; }

        [JsonProperty("order_number")]
        [RequestHeader("order_number")]
        public string OrderNumber { get; set; }

        [JsonProperty("custom_fields")]
        [JsonConverter(typeof(CustomFieldConverter))]
        public Dictionary<string,string> CustomFields { get; set; }

        public AssetCheckoutRequest CheckoutRequest { get; set; }
    }
}
