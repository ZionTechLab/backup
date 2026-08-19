using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string StrMessage { get; set; }
        public string ReturnValue { get; set; }
    }
}
