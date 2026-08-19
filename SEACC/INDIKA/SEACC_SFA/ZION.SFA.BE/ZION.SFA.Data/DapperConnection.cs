using System;
using System.Collections.Generic;
using System.Text;

namespace ZION.SFA.Data
{
    public sealed class DapperConnection
    {
        private static string conStr;

        public static string GetConnetion(string name = "db")
        {
            return "Data Source=89.117.60.18;Initial Catalog=ieplus;Persist Security Info=True;User ID=sa;Password=nimda@123;MultipleActiveResultSets=True;App=EntityFramework";
        }
    }
}
