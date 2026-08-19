
using SEACC_LOGIN.DataTire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_LOGIN
{
    public class clsBackProcess_Login
    {
        public static void AutoAssignConfigStatus_POS()
        {
            foreach (tbl_securityConfigStatus oStatus in tbl_securityConfigStatus.SelectAll())
            {
                switch (oStatus.ValueID)
                {
                    //--SEACC LOGIN (FROM 800 - 850)

                }
            }
        }

        public static void AutoAssignConfigValue_POS()
        {
            //foreach (tbl_securityConfigValue oValue in tbl_securityConfigValue.SelectAll())
            //{
            //    switch (oValue.ValueID)
            //    {
            //        //--SEACC LOGIN (FROM 800 - 850)


            //    }
            //}
        }
    }
}
