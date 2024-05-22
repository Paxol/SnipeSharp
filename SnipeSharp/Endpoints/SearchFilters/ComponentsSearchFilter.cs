using SnipeSharp.Common;
using SnipeSharp.Endpoints.SearchFilters;

namespace SnipeSharp.Endpoints.SearchFilters
{
    class ComponentsSearchFilter : SearchFilter
    {
        [FilterParameterName("order_number")]
        public string OrderNumber { get; set; }

        public bool Expand { get; set; }
    }
}
