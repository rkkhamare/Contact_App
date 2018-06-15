using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.WebAPI.Tests.Helpers
{
   public static class ApiHandler
    {
        public static T ExecuteGetAPIExtendedTime<T>(string apiRequestURL, Func<string> requestString) where T : new()
        {
            T apiResult = new T();
            try
            {
                HttpClient client = new HttpClient
                {
                    Timeout = TimeSpan.FromMinutes(10)
                };

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                apiResult = client
                                    .GetAsync(string.Concat(apiRequestURL, requestString.Invoke()))
                                    .Result
                                    .Content.ReadAsAsync<T>().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return apiResult;
        }

        public static T ExecutePostAPI<T, T1>(string baseApiUrl, string postURL, T1 postData, out int resultCode) where T : new()
        {
            T response = new T();
            resultCode = 0;
            try
            {
                string webApiBaseURL = baseApiUrl;
                HttpClient client = new HttpClient { BaseAddress = new Uri(webApiBaseURL) };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = client.PostAsJsonAsync(postURL, postData).Result
                     .Content.ReadAsAsync<T>().Result;
            }
            catch (AggregateException agex)
            {

            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public static T ExecutePutAPI<T, T1>(string baseApiUrl, string postURL, T1 postData, out int resultCode) where T : new()
        {
            T response = new T();
            resultCode = 0;
            try
            {
                string webApiBaseURL = baseApiUrl;
                HttpClient client = new HttpClient { BaseAddress = new Uri(webApiBaseURL) };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = client.PutAsJsonAsync(postURL, postData).Result
                     .Content.ReadAsAsync<T>().Result;
            }
            catch (AggregateException agex)
            {

            }
            catch (Exception ex)
            {

            }

            return response;
        }
    }
}
