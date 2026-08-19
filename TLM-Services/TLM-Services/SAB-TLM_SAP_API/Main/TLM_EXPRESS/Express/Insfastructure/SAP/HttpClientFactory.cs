using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Insfastructure.SAP
{
    public class HttpClientFactory
    {
        public HttpClient CreateHttpClient(string baseAddress, bool isJson = true)
        {
            if (isJson)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(baseAddress);
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
