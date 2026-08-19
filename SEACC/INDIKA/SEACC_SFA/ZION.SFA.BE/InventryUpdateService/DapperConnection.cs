using System;
using System.Collections.Generic;
using System.Text;

namespace InventryUpdateService
{
    class DapperConnection
    {
        public static string GetConnetion(string name = "db")
        {
         //   return @"Data Source=MIT-SEU-L-00004\SQLEXPRESS;Initial Catalog=SEACC_LIVE;Persist Security Info=True;User ID=sa;Password=nimda@123;MultipleActiveResultSets=True;App=EntityFramework";
            return @"Data Source=server\SQLEXPRESS;Initial Catalog=SEACC_LIVE;Persist Security Info=True;User ID=sa;Password=nimda@123;MultipleActiveResultSets=True;App=EntityFramework";
         //     return "Data Source=DESKTOP-ANOJ;Initial Catalog=indika;Persist Security Info=True;User ID=sa;Password=nimda@123;MultipleActiveResultSets=True;App=EntityFramework";
        }
    }
}
