using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF
{
   public sealed class DapperConnetion
    {
        private static string conStr;
        private DapperConnetion()
        {

        }       
        public static string GetConnetion()
        {
            if (conStr == null || conStr == "")
            {
                conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            return conStr;
        }
    }
}
