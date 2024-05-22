using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.SearchFilters
{
    /// <summary>
    /// The base class for all SearchFilter objects.
    /// These properties are common to any filter we want to do on a get request for all endpoints.
    /// </summary>
    public class SearchFilter : ISearchFilter
    {
        [FilterParameterName("limit")]
        public int? Limit { get; set; }
        
        [FilterParameterName("offset")]
        public int? Offset { get; set; }
        
        [FilterParameterName("search")]
        public string Search { get; set; }
        
        [FilterParameterName("sort")]
        public string Sort { get; set; }
        
        [FilterParameterName("order")]
        public string Order { get; set; }
    }
}
