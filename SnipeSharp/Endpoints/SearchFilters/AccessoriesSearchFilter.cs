using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.SearchFilters
{
    class AccessoriesSearchFilter : SearchFilter
    {
        [FilterParameterName("order_number")]
        public string OrderNumber { get; set; }

        public bool Expand { get; set; }
    }
}
