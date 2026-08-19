using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MHE_Api
{
    public class HostValidationHandler : DelegatingHandler
    {
        string stringValue = ConfigurationManager.AppSettings["WhiteListHosts"];
        private string[] permittedDomains = { };
     


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string[] stringArray = stringValue.Split(',');
            permittedDomains = stringArray;
            // Get the 'Host' header from the request
            var hostHeader = request.Headers.Host;

            // Check if the domain is in the permitted list
            if (!IsDomainPermitted(hostHeader))
            {
                // Reject the request
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Forbidden: Unauthorized Host"),
                    RequestMessage = request
                };

                return Task.FromResult(response);
            }

            // Continue processing the request
            return base.SendAsync(request, cancellationToken);
        }
        static string RemoveAfterColon(string input)
        {
            int colonIndex = input.IndexOf(':');
            if (colonIndex != -1)
            {
                return input.Substring(0, colonIndex);
            }
            return input;
        }
        private bool IsDomainPermitted(string host)
        {
            // Convert the host to lowercase for case-insensitive comparison
            if (permittedDomains.Contains("*"))
            {
                return true;
            }
            else
            {
                host = RemoveAfterColon(host);
                var lowercaseHost = host.ToLower();

                return permittedDomains.Contains(lowercaseHost);
            }
        }
    }
}