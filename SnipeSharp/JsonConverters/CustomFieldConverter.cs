using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using SnipeSharp.Common;

namespace SnipeSharp.JsonConverters
{
    internal class CustomFieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // TODO: There's probably a hell of a lot that can go wrong here
            var token = JToken.Load(reader);

            return token.Select(subToken => subToken.Children()).SelectMany(children => children)
                .ToDictionary(child => child.Value<string>("field"), child => child.Value<string>("value"));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
