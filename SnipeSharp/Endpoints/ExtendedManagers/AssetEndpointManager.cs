using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class AssetEndpointManager : EndpointManager<Asset>
    {
        // Explicitly pass hardware as the endpoint, ignoring what the client gives us
        public AssetEndpointManager(IRequestManager reqManager) : base(reqManager, "hardware")
        {
        }

        public IRequestResponse Checkout(ICommonEndpointModel item)
        {
            string response = this.ReqManager.Post(string.Format("{0}/{1}/checkout", this.EndPoint, item.Id), item);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);

            return result;
        }

        public IRequestResponse Checkin(ICommonEndpointModel item)
        {
            string response = this.ReqManager.Post(string.Format("{0}/{1}/checkin", this.EndPoint, item.Id), item);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);

            return result;
        }
    }
}
