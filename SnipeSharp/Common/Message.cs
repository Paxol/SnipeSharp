using Newtonsoft.Json;
using System.Collections.Generic;

namespace SnipeSharp.Common
{
    public class Message
    {
        [JsonProperty("name")]
        public List<string> Name { get; set; }

        [JsonProperty("general")]
        public List<string> General { get; set; }
    }
}
