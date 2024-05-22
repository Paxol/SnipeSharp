using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;

namespace SnipeSharp.Common
{
    public interface IRequestManager
    {
        string Get(string path);
        
        string Get(string path, ISearchFilter filter);
        
        string Put(string path, ICommonEndpointModel item);
        
        string Post(string path, ICommonEndpointModel item);
        
        string Delete(string path);
    }
}
