using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.Exceptions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SnipeSharp.Endpoints;

namespace SnipeSharp.Common
{
    public class RequestManager : IRequestManager
    {
        public ApiSettings ApiSettings { get; }
        
        public IQueryParameterBuilder QueryParameterBuilder { get; set; } = new QueryParameterBuilder();

        private HttpClient Client { get; }

        public RequestManager(ApiSettings apiSettings)
        {
            this.ApiSettings = apiSettings;
            
            var client = new HttpClient {BaseAddress = ApiSettings.BaseUrl};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Client = client;
        }        

        public string Delete(string path)
        {
            CheckApiTokenAndUrl();

            var result = string.Empty;
            var response = Client.DeleteAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        public string Get(string path)
        {
            CheckApiTokenAndUrl();

            var result = string.Empty;
            var response = Task.Run(() => Client.GetAsync(path)).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;                
            }

            return result;
        }

        public string Get(string path, ISearchFilter filter)
        {
            CheckApiTokenAndUrl();
            path = path + "?" + this.QueryParameterBuilder.GetParameters(filter);
            var result = string.Empty;

            var response = Task.Run(() => Client.GetAsync(path)).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        public string Post(string path, ICommonEndpointModel item)
        {
            Console.WriteLine("Posting With Async");
            CheckApiTokenAndUrl();

            var response = Task.Run(() => Client.PostAsync(path, BuildQueryString(item))).Result;
            string result = null;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        public string Put(string path, ICommonEndpointModel item)
        {
            CheckApiTokenAndUrl();

            var response = Client.PutAsync(path, BuildQueryString(item)).Result;
            string result = null;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        public string Checkin(string path)
        {
            var response = Client.PostAsync(path, null).Result;
            string result = null;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        private FormUrlEncodedContent BuildQueryString(ICommonEndpointModel item)
        {
            var values = this.QueryParameterBuilder.GetParameters(item);

            // If it's an asset check if there's a checkout request.  Also process custom fields

            var asset = item as Asset;
            if (asset != null)
            {
                // If an asset as this set we know it needs to be check out. 
                var assetCheckoutRequest = asset.CheckoutRequest;
                
                if (assetCheckoutRequest != null)
                {
                    var additionalParameters = this.QueryParameterBuilder.GetParameters(asset.CheckoutRequest);

                    foreach (var kvp in additionalParameters)
                    {
                        values.Add(kvp.Key, kvp.Value);
                    }
                    
                    return new FormUrlEncodedContent(values);
                }

                // Assets are the only ones that have custom fields
                if (asset.CustomFields != null)
                {
                    foreach (var fieldValuePair in asset.CustomFields)
                    {
                        values.Add(fieldValuePair.Key, fieldValuePair.Value);
                    }
                }
            }

            var content = new FormUrlEncodedContent(values);

            return content;
        }

        // Since the Token and URL can be set anytime after the SnipApi object is created we need to check for these before sending a request
        public void CheckApiTokenAndUrl()
        {
            if (ApiSettings.BaseUrl == null)
            {
                throw new NullApiBaseUrlException("No API Base Url Set.");
            }

            if (ApiSettings.ApiToken == null)
            {
                throw new NullApiTokenException("No API Token Set");
            }

            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = ApiSettings.BaseUrl;
            }

            if (Client.DefaultRequestHeaders.Authorization == null)
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiSettings.ApiToken);
            }
        }
    }
}
