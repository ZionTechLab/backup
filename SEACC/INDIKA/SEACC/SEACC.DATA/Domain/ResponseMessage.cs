using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string OutMsg { get; set; }
        public string ReturnValue { get; set; }
    }
    public class ResponseMessage_Value
    {
        public bool IsSuccess { get; set; }
        public string OutMsg { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}