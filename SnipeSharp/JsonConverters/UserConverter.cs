using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.JsonConverters
{
    public class UserConverter : JsonConverter
    {
        public override Boolean CanConvert(Type objectType)
        {
            return true;
        }

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.Object)
            {
                return token.ToObject<User>();
            }

            if (token.Type == JTokenType.Integer)
            {
                return new User()
                {
                    Id = token.ToObject<int>()
                };
            }
            
            if (token.Type == JTokenType.String)
            {
                if (int.TryParse(token.ToObject<string>(), out int id))
                {
                    return new User()
                    {
                        Id = id
                    };
                }
                
                throw new JsonSerializationException("Unable to parse string as User");
            }

            return null;
        }
        
        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}