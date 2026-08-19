using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Helpers
{
    public class MessagHeaderInfo
    {

        #region Error
        public static string ValidationError {
            get {return "Validation Error";}
        }

        public static string SavingError
        {
            get { return "Data Save Error"; }
        }

        public static string InfoError
        {
            get { return "Error"; }
        }

        public static string SysError
        {
            get { return "System Error"; }
        }

        public static string PermissionError
        {
            get { return "Permission Error"; }
        }
        #endregion


        #region Success 
        public static string Successfull
        {
            get { return "Successfully"; }
        }

        public static string Information
        {
            get { return "Information"; }
        }
        #endregion


        #region Confirmation box

        
        public static string Confirmation
        {
            get { return "Confirmation"; }
        }

        #endregion


    }
}
