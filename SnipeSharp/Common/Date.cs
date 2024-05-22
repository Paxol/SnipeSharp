using Newtonsoft.Json;

namespace SnipeSharp.Common
{
    public class Date
    {
        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        [JsonProperty("date")]
        public string DateObj { get; set; }
    }
}
