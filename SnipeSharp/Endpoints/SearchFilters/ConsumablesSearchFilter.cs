using SnipeSharp.Endpoints.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnipeSharp.Common;

namespace SnipeSharp.Endpoints.SearchFilters
{
    class ConsumablesSearchFilter : SearchFilter
    {
        [FilterParameterName("order_number")]
        public string OrderNumber { get; set; }

        public bool Expand { get; set; }
    }
}
