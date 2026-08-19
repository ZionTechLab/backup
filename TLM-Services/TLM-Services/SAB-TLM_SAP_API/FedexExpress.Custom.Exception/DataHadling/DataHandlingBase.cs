using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Custom.ExcepHandle.DataHadling
{
   public class DataHandlingBase:Exception 
    {
        public DataHandlingBase(string defultMessage):base(defultMessage)
        {

        }
        public virtual string ErrorCode { get; set; } // ID or code of Exception
        public virtual string ErrorReasonPhrase { get; set; } // Error Message
        public virtual string ErrorRaiseModule { get; set; } // where this error generage
    }
}
