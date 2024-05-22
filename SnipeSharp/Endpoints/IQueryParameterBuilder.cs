using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints
{
    public interface IQueryParameterBuilder
    {
        Dictionary<string, string> GetParameters(object item);
    }
}