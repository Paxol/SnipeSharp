using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class UserEndpointManager : EndpointManager<User>
    {
        public UserEndpointManager(IRequestManager reqManager) : base(reqManager, "users")
        {
        }

        public ResponseCollection<User> GetAssignedAssets(ICommonEndpointModel user)
        {
            string response = this.ReqManager.Get(string.Format("{0}/{1}/assets", this.EndPoint, user.Id));
            var results = JsonConvert.DeserializeObject<ResponseCollection<User>>(response);
            
            return results;
        }
    }
}
