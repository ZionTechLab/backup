using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Domain.Message
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string StrMessage { get; set; }
        public string ReturnValue { get; set; }
        public string ReturnValue2 { get; set; }


    }
}
