using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ZION.SFA.WebApiClient
{
    public sealed class HttpClientFactory
    {
        private static volatile HttpClientFactory instance;
        private static object syncRoot = new Object();
        //      private WebServerClient _webServerClient;

        private HttpClientFactory()
        {

        }

        public static HttpClientFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new HttpClientFactory();
                    }
                }

                return instance;
            }
        }
        public HttpClient CreateHttpClient_Compressed(bool isJson = true)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip
            };


            //   _webServerClient = (WebServerClient)LoginInfoView.WEBSERVERCLIENT;
            if (isJson)
            {
                var client = new HttpClient(handler);//_webServerClient.CreateAuthorizingHandler(LoginInfoView.BEARERTOKEN));
                ////var client = new HttpClient();
                client.BaseAddress = new Uri(Config.URl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public HttpClient CreateHttpClient(bool isJson = true)
        {
            //    _webServerClient = (WebServerClient)LoginInfoView.WEBSERVERCLIENT;
            if (isJson)
            {
                if (Config.URl == null)
                    throw new ExecutionEngineException("API Configaration not found");

                var client = new HttpClient();//_webServerClient.CreateAuthorizingHandler(LoginInfoView.BEARERTOKEN));
                ////var client = new HttpClient();
                client.BaseAddress = new Uri(Config.URl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
