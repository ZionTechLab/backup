using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Custom.ExcepHandle.HttpRequest
{
   public class HttpClientRequestException :HttpRequestBase
    {
        public HttpClientRequestException(string exceptionMessage, string errorStatusCode, string errorReasonPhrase, Exception ex): base(ex.Message.ToString())
        {
            base.ErrorStatusCode = errorStatusCode;
            base.ErrorReasonPhrase = errorReasonPhrase;
            base.Source = ex.Source;
        }
    }
}
