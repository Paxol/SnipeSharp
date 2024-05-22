using System.Collections.Generic;

namespace SnipeSharp.Common
{
    public interface IResponseCollection<T>
    {
        long Total { get; }
        
        List<T> Rows { get; }
    }
}
