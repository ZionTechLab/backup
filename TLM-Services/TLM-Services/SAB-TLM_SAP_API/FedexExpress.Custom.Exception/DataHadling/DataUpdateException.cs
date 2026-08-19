using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Custom.ExcepHandle.DataHadling
{
   public  class DataUpdateException: DataHandlingBase
    {
        /// <summary>
        /// Customize DbupdateException
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorReasonPhrase"></param>
        /// <param name="erroRaiseModeule">error raise position</param>
        /// <param name="ex">exception</param>
        public DataUpdateException( string errorCode, string errorReasonPhrase, string erroRaiseModeule, Exception ex): base(ex.Message.ToString())
        {
            base.ErrorCode = errorCode;
            base.ErrorReasonPhrase = errorReasonPhrase;
            base.ErrorRaiseModule = erroRaiseModeule;
            base.Source = ex.Source;
        }
    }
}
