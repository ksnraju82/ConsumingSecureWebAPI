using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MVCWebAPIUsingSecureToken.Models;
using System.Web.Http;
using System.Configuration;

namespace MVCWebAPIUsingSecureToken.HelperClass
{
    public static class GetAPIResponse
    {
        public static string GetRequest(string token, string apiBaseUri, string requestPath)
        {
            try
            {
                var responseData = "";

                var client = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(apiBaseUri + requestPath),
                    Method = HttpMethod.Get,
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("x-access-token", token);
                var task = client.SendAsync(request)
                    .ContinueWith((taskwithmsg) =>
                    {
                        var response = taskwithmsg.Result;
                        if (response.IsSuccessStatusCode)
                            responseData = response.Content.ReadAsStringAsync().Result;
                        else
                            responseData = "";
                    });
                task.Wait();
                return responseData;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
                
        }
    }
}