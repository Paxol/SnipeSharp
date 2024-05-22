using SnipeSharp.Endpoints.Models;
using System;
using System.Linq;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.EndpointHelpers
{
    public class AssetCheckoutRequest
    {
        [RequestHeader("checkout_to_type", true)]
        public string CheckoutToType { get; set; }

        [RequestHeader("assigned_location")]
        public Location AssignedLocation { get; set; }

        [RequestHeader("assigned_asset")]
        public Asset AssignedAsset { get; set; }

        [RequestHeader("assigned_user")]
        public User AssignedUser { get; set; }

        [RequestHeader("note")]
        public string Note { get; set; }

        // TODO: Make this a date object
        [RequestHeader("expected_checkin")]
        public string ExpectedCheckin { get; set; }

        // TODO: Make this a date object
        [RequestHeader("checkout_at")]
        public string CheckoutAt { get; set; }

        [RequestHeader("name")]
        public string Name { get; set; }
    }
}
