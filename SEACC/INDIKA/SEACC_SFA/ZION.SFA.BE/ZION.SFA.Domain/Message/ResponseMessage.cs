using System;
using System.Collections.Generic;
using System.Text;

namespace ZION.SFA.Domain.Message
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string StrMessage { get; set; }
        public string ReturnValue { get; set; }
        public string ReturnValue2 { get; set; }
        public string varOutMsg { get; set; }

    }
}
