using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public sealed class DapperConnection
    {
        private static string conStr;

        public static string GetConnetion(string name = "db")
        {
            return @"Data Source=IESVR\SQLDTQ;Initial Catalog=SEACC_LIVE;Persist Security Info=True;User ID=sa;Password=nimda@123;MultipleActiveResultSets=True;App=EntityFramework";
          //  return "Data Source=DESKTOP-ANOJ;Initial Catalog=indika;Persist Security Info=True;User ID=sa;Password=nimda@123;MultipleActiveResultSets=True;App=EntityFramework";
        }
    }
}
