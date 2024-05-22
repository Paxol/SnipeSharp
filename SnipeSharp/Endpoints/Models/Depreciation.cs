using SnipeSharp.Common;
using Newtonsoft.Json;

namespace SnipeSharp.Endpoints.Models
{
    public class Depreciation : CommonEndpointModel
    {

        private string _months;

        [JsonProperty("months")]
        [RequestHeader("months", true)]
        public string Months
        {
            get
            {
                return _months;
            }
            set
            {
                _months = (value != null) ? value : null;
            }
        }

    }
}
