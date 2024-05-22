using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class SimpleEndpointManager<T> : EndpointManager<T>
        where T : CommonEndpointModel
    {
        public SimpleEndpointManager(IRequestManager reqManager, string endPoint) : base(reqManager, endPoint)
        {
        }

        protected override IResponseCollection<T> GetAllInternal()
        {
            // If there are more than 1000 assets split up the requests to avoid timeouts
            string response = ReqManager.Get(EndPoint);
            var results = JsonConvert.DeserializeObject<ResponseCollection<T>>(response);

            return results;
        }
    }
}