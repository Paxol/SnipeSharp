using System;
using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Exceptions;
using SnipeSharp.JsonConverters;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SnipeSharp.Endpoints.Models
{
    /// <summary>
    /// Represents the the base of all objects we get back the API.  This is the building block for all more 
    /// specific return objects. 
    /// </summary>
    public class CommonEndpointModel : ICommonEndpointModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        [RequestHeader("name", true)]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(ResponseDateTimeConverter))]
        public ResponseDate CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(ResponseDateTimeConverter))]
        public ResponseDate UpdatedAt { get; set; }

        // TODO - We're doing this so when it's passed in the header for create action we get the ID
        public override string ToString()
        {
            return Id.ToString();
        }

        protected virtual Dictionary<string, string> BuildQueryStringInternal(params string[] notRequiredProperties)
        {
            var values = new Dictionary<string, string>();

            // TODO: Revisit this.  Look at loop in SearchFilter
            foreach (var prop in this.GetType().GetProperties())
            {
                foreach (var attData in prop.GetCustomAttributesData())
                {
                    string typeName = attData.Constructor.DeclaringType?.Name;

                    if (typeName != "RequiredRequestHeader" && typeName != "OptionalRequestHeader")
                    {
                        continue;
                    }
                    
                    var propValue = prop.GetValue(this)?.ToString();

                    // Abort in missing required headers (except the ones from the exception list).
                    if (propValue == null
                        && typeName == "RequiredRequestHeader"
                        && !notRequiredProperties.Contains(prop.Name, StringComparer.InvariantCultureIgnoreCase))
                    {
                        throw new RequiredValueIsNullException($"Property {prop.Name} cannot be null.");
                    }

                    if (propValue == null)
                    {
                        continue;
                    }
                    
                    string attName = attData.ConstructorArguments.First().ToString().Replace("\"", "");

                    values.Add(attName, propValue);
                }
            }

            return values;
        }
    }
}
