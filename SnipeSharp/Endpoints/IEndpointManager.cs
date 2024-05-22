﻿using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;

namespace SnipeSharp.Endpoints
{
    public interface IEndpointManager<T>
        where T : ICommonEndpointModel
    {
        IResponseCollection<T> GetAll();
        
        IResponseCollection<T> FindAll(ISearchFilter filter);
        
        T FindOne(ISearchFilter filter);
        
        T Get(int id);

        T Get(string name);
        
        IRequestResponse Create(T toCreate);
        
        IRequestResponse Update(T toUpdate);
        
        IRequestResponse Delete(int id);
    }
}
