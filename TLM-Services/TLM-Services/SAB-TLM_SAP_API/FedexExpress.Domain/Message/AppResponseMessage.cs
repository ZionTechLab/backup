using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Message
{
   public class AppResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string StrMessage { get; set; }
        public string ReturnValue { get; set; }
        public string ReturnValue2 { get; set; }
        public string ResponseMessage { get; set; }
    }
}
