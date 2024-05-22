using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class StatusLabelEndpointManager : EndpointManager<StatusLabel>
    {
        public StatusLabelEndpointManager(IRequestManager reqManager)
            : base(reqManager, "statuslabels")
        {
        }

        public ResponseCollection<StatusLabel> GetAssignedAssets(ICommonEndpointModel statusLabel)
        {
            string response = this.ReqManager.Get(string.Format("{0}/{1}/assetlist", this.EndPoint, statusLabel.Id));
            var results = JsonConvert.DeserializeObject<ResponseCollection<StatusLabel>>(response);
            
            return results;
        }
    }
}
