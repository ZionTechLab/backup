using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_LOGIN
{
  public   class ConfisSetting
    {
        public static string GetServer()
        {
          return  ConfigurationManager.AppSettings["Server"];
        }


    }
}
