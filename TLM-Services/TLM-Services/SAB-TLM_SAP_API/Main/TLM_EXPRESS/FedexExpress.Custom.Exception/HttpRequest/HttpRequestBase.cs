using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Custom.ExcepHandle.HttpRequest
{
   public class HttpRequestBase :Exception 
    {
        public HttpRequestBase(string defultMessage):base(defultMessage)
        {

        }
        public virtual string ErrorStatusCode { get; set; }
        public virtual string ErrorReasonPhrase { get; set; }
    }
}
