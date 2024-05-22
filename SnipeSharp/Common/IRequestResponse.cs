using SnipeSharp.Endpoints.Models;
using System.Collections.Generic;

namespace SnipeSharp.Common
{
    public interface IRequestResponse
    {
        Dictionary<string, string> Messages { get; set; }
        
        ICommonEndpointModel Payload { get; set; }
        
        string Status { get; set; }
    }
}
