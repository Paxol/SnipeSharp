using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.SearchFilters
{
    public class AssetSearchFilter : SearchFilter
    {
        [FilterParameterName("order_number")]
        public string OrderNumber { get; set; }

        [FilterParameterName("model_id")]
        public int? ModelId { get; set; }

        [FilterParameterName("category_id")]
        public int? CategoryId { get; set; }

        [FilterParameterName("manufacturer_id")]
        public Manufacturer Manufacturer { get; set; }

        [FilterParameterName("company_id")]
        public int? CompanyId { get; set; }

        [FilterParameterName("location_id")]
        public Location Location { get; set; }

        public string Status { get; set; }

        [FilterParameterName("status_id")]
        public int? StatusId { get; set; }
    }
}
