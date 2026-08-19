using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;


namespace Express.UI.Insfastructure.SAP
{

    public class SAPRest<T> where T : class
    {
       

        static HttpClient client = new HttpClient();

        //public SAPRest(string baseAddress)
        //    {
        //        _baseAddress = baseAddress;
        //    }




        //    public async Task<T> Post(string apiUrl, T postObject)
        //    {
        //        try
        //        {

        //                string URL = Properties.Settings.Default.SAPApiUrl;

        //                T result = null;
        //                HttpResponseMessage response = await client.PostAsJsonAsync(
        //                 URL +  apiUrl, postObject);
        //                response.EnsureSuccessStatusCode();

        //                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        //                {
        //                    if (x.IsFaulted)
        //                        throw x.Exception;

        //                    result = JsonConvert.DeserializeObject<T>(x.Result);
        //                });

        //                return result;

        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }
        //    }

        //    private class JsonMediaTypeFormatter
        //    {
        //        public JsonMediaTypeFormatter()
        //        {
        //        }
        //    }
        //}


        public async Task<T> Post(string apiUrl, T postObject)
        {
            T result = null;
            string URL = Properties.Settings.Default.SAPApiUrl;
            using (var outbound = new HttpClientFactory().CreateHttpClient(URL))
            {
                
                HttpResponseMessage response = await outbound.PostAsync(URL + apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<T>(x.Result);
                });
            }

            return result;
        }
    }

    }
