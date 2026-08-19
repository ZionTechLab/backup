using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace ZION.SFA.WebApiClient
{
    public class RestClient<T> where T : class
    {
        private readonly string _baseAddress;
        private static volatile RestClient<T> instance;
        private static object syncRoot = new Object();

        public RestClient(string baseAddress)
        {
            _baseAddress = baseAddress;
        }
        public RestClient()
        {

        }

        public static RestClient<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RestClient<T>();
                    }
                }

                return instance;
            }
        }

        public async Task<T> Get(string apiUrl)
        {
            T result = null;

            using (var client = HttpClientFactory.Instance.CreateHttpClient_Compressed())
            {
                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
                try
                {
                    response.EnsureSuccessStatusCode();

                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        if (x.IsFaulted)
                            throw x.Exception;

                        result = JsonConvert.DeserializeObject<T>(x.Result);
                    });
                }
                catch (HttpRequestException responseException)
                {
                    throw;// new HttpClientRequestException(response.StatusCode.ToString(), response.StatusCode.ToString(), response.ReasonPhrase, responseException);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return result;
        }

        public async Task<T[]> GetAll(string apiUrl)
        {
            T[] result = null;
            using (var client = HttpClientFactory.Instance.CreateHttpClient())
            {
                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
                try
                {
                    response.EnsureSuccessStatusCode();
                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        if (x.IsFaulted)
                            throw x.Exception;

                        result = JsonConvert.DeserializeObject<T[]>(x.Result);
                    });
                }
                catch (HttpRequestException responseException)
                {
                    throw;// new HttpClientRequestException(response.StatusCode.ToString(), response.StatusCode.ToString(), response.ReasonPhrase, responseException);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return result;
        }

        public async Task<T> Post(string apiUrl, object postObject)
        {
            T result = null;
            using (var client = HttpClientFactory.Instance.CreateHttpClient())
            {
                var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

                try
                {

                    response.EnsureSuccessStatusCode();
                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        if (x.IsFaulted)
                            throw x.Exception;

                        result = JsonConvert.DeserializeObject<T>(x.Result);
                    });
                }
                catch (HttpRequestException responseException)
                {
                    throw;// new HttpClientRequestException(response.StatusCode.ToString(), response.StatusCode.ToString(), response.ReasonPhrase, responseException);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

        public async Task<T> Put(string apiUrl, object putObject)
        {
            T result = null;
            using (var client = HttpClientFactory.Instance.CreateHttpClient())
            {
                var response = await client.PutAsync(apiUrl, putObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);
                try
                {
                    response.EnsureSuccessStatusCode();
                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        if (x.IsFaulted)
                            throw x.Exception;

                        result = JsonConvert.DeserializeObject<T>(x.Result);
                    });
                }
                catch (HttpRequestException responseException)
                {
                    throw;// new HttpClientRequestException(response.StatusCode.ToString(), response.StatusCode.ToString(), response.ReasonPhrase, responseException);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

        public async Task Delete(string apiUrl)
        {
            using (var client = HttpClientFactory.Instance.CreateHttpClient())
            {
                var response = await client.DeleteAsync(apiUrl).ConfigureAwait(false);

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException responseException)
                {
                    throw;// new HttpClientRequestException(response.StatusCode.ToString(), response.StatusCode.ToString(), response.ReasonPhrase, responseException);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        #region To Delete
        ////public async Task<T> Get(string apiUrl)
        ////{
        ////    T result = null;

        ////    using (var client = new HttpClientFactory().CreateHttpClient(_baseAddress))
        ////    {
        ////        var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
        ////        response.EnsureSuccessStatusCode();

        ////        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        ////        {
        ////            if (x.IsFaulted)
        ////                throw x.Exception;

        ////            result = JsonConvert.DeserializeObject<T>(x.Result);
        ////        });
        ////    }

        ////    return result;
        ////}

        ////public async Task<T[]> GetAll(string apiUrl)
        ////{
        ////    T[] result = null;
        ////    using (var client = new HttpClientFactory().CreateHttpClient(_baseAddress))
        ////    {
        ////        var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
        ////       response.EnsureSuccessStatusCode();




        ////        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        ////        {
        ////            if (x.IsFaulted)
        ////                throw x.Exception;

        ////            result = JsonConvert.DeserializeObject<T[]>(x.Result);
        ////        });
        ////    }
        ////    return result;
        ////}    

        ////public async Task<T> Post(string apiUrl, object postObject)
        ////{
        ////    T result = null;
        ////    using (var client = new HttpClientFactory().CreateHttpClient(_baseAddress))
        ////    {
        ////        var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

        ////        response.EnsureSuccessStatusCode();    

        ////        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        ////        {
        ////            if (x.IsFaulted)
        ////                throw x.Exception;

        ////            result = JsonConvert.DeserializeObject<T>(x.Result);
        ////        });
        ////    }

        ////    return result;
        ////}

        ////public async Task Put(string apiUrl, object  putObject)
        ////{
        ////    using (var client = new HttpClientFactory().CreateHttpClient(_baseAddress))
        ////    {
        ////        var response = await client.PutAsync(apiUrl, putObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);
        ////        response.EnsureSuccessStatusCode();
        ////    }
        ////}

        ////public async Task Delete(string apiUrl)
        ////{
        ////    using (var client = new HttpClientFactory().CreateHttpClient(_baseAddress))
        ////    {
        ////        var response = await client.DeleteAsync(apiUrl).ConfigureAwait(false);
        ////        response.EnsureSuccessStatusCode();
        ////    }
        ////}

        #endregion
    }
}
