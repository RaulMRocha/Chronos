using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Chronos.Data.IkarusWS.Calls
{
    internal class WebServiceCall
    {
        private readonly HttpClient _httpClient;
        private static readonly string _testServiceURL = "http://localhost:3030/Ikarus/api/";
        private static readonly string _productionServiceURL = "http://localhost:3030/Ikarus/api/";
        internal readonly string UtilitiesServiceURI = "Utilities/";
        internal readonly string AppsServiceURI = "Apps/";
        internal readonly string MasterServiceURI = "MasterData/";

        #region Web API Call
        internal WebServiceCall(bool ConnectToProd)
        {
            string ServiceURL = ConnectToProd ? _productionServiceURL  : _testServiceURL;
            _httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }) { BaseAddress = new Uri(ServiceURL) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal DataTable CallGETService(string RequestURI)
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync(RequestURI).Result;
                if (response.IsSuccessStatusCode)
                {
                    try
                    {

                        var a = response.Content.ReadAsAsync<DataTable>();

                        if (a == null)
                            return null;
                        else
                            return a.Result;
                    }
                    catch
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }

        }

        internal string CallPOSTService(string RequestURI, Dictionary<string, string> Content)
        {
            try
            {
                var content = new FormUrlEncodedContent(Content);
                var response = _httpClient.PostAsync(RequestURI, content);
                return response.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

    }
}
