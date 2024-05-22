using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using System.Collections.Generic;
using System.Linq;

namespace SnipeSharp.Endpoints
{
    /// <summary>
    /// Generic class that can represent each of the different models returned by each endpoint. 
    /// </summary>
    /// <typeparam name="T">Type of the objects that should be created.</typeparam>
    public class EndpointManager<T> : IEndpointManager<T>
        where T : CommonEndpointModel 
    {
        public IRequestManager ReqManager { get; }

        public string EndPoint { get; }

        public EndpointManager(IRequestManager reqManager, string endPoint)
        {
            ReqManager = reqManager;
            EndPoint = endPoint;
        }

        /// <summary>
        /// Gets all objects from the endpoint
        /// </summary>
        /// <returns>
        /// Returns all objects of the specified type.
        /// </returns>
        public IResponseCollection<T> GetAll()
        {
            return this.GetAllInternal();
        }

        /// <summary>
        /// Search for Assets that match filters defined in an ISearchFilter object. 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IResponseCollection<T> FindAll(ISearchFilter filter)
        {
            string response = ReqManager.Get(EndPoint, filter);
            var results = JsonConvert.DeserializeObject<ResponseCollection<T>>(response);
            
            return results;
        }

        /// <summary>
        /// Finds all objects that match the filter and returns the first
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T FindOne(ISearchFilter filter)
        {
            string response = ReqManager.Get(EndPoint, filter);
            var result = JsonConvert.DeserializeObject<ResponseCollection<T>>(response);
            
            return result?.Rows?.FirstOrDefault();
        }

        /// <summary>
        /// Attempts to get a given object by it's ID
        /// </summary>
        /// <param name="id">ID of the object to find</param>
        /// <returns></returns>
        public T Get(int id)
        {
            // TODO: Find better way to deal with objects that are not found
            string response = ReqManager.Get($"{EndPoint}/{id}");
            var result = JsonConvert.DeserializeObject<T>(response); 

            return result;
        }

        /// <summary>
        /// Attempts to find a given object by it's name. 
        /// </summary>
        /// <param name="name">The name of the object we want to find</param>
        /// <returns></returns>
        public T Get(string name)
        {
            name = name.ToLower();
            var everything = GetAll();

            var result = everything.Rows.FirstOrDefault(i => i?.Name?.ToLower() == name);

            return result;
        }

        /// <summary>
        /// Creates a new object from the provided CommonResponseObject
        /// </summary>
        /// <param name="toCreate"></param>
        /// <returns></returns>
        public IRequestResponse Create(T toCreate)
        {
            string res = ReqManager.Post(EndPoint, toCreate);
            var response = JsonConvert.DeserializeObject<RequestResponse>(res);

            return response;
        }

        public IRequestResponse Update(T toUpdate)
        {
            string response = ReqManager.Put($"{EndPoint}/{toUpdate.Id}", toUpdate);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);

            return result;
        }

        public IRequestResponse Delete(int id)
        {
            string response = ReqManager.Delete($"{EndPoint}/{id}");
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            
            return result;
        }

        public IRequestResponse Delete(ICommonEndpointModel toDelete)
        {
            return Delete((int)toDelete.Id);
        }
        
        protected virtual IResponseCollection<T> GetAllInternal()
        {
            // Figure out how many rows the results will return so we can splitup requests
            var count = FindAll(new SearchFilter {Limit = 1});

            // If there are more than 1000 assets split up the requests to avoid timeouts
            if (count.Total < 1000)
            {
                string response = ReqManager.Get(EndPoint);
                var results = JsonConvert.DeserializeObject<ResponseCollection<T>>(response);

                return results;
            }

            var finalResults = new ResponseCollection<T>
            {
                Total = count.Total
            };

            int offset = 0;

            while (finalResults.Rows.Count < count.Total)
            {
                var batch = FindAll(new SearchFilter
                {
                    Limit = 1000,
                    Offset = offset
                });

                finalResults.Rows.AddRange(batch.Rows);
                offset = finalResults.Rows.Count;
            }

            return finalResults;
        }
    }
}
