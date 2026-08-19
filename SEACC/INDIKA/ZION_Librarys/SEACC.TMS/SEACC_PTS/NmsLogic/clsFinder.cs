using SEACC_PTS.NmsEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEACC_PTS.NmsLogic
{
    class clsFinder
    {
        public static int getShaduleID(clsEnum.AutoSendEmail enmEmail)
        {
            int iShaduleID = 0;
            switch ((int)enmEmail)
            {
                case 0:
                    iShaduleID = 5;
                    break;
                case 1:
                    iShaduleID = 6;
                    break;
            }

            return iShaduleID;
        }

        public static string getUtilizedHours(int iTaskId)
        {
            string sUtHours = "-";
            tbl_ptsTimeSheet oTime = tbl_ptsTimeSheet.Select(iTaskId);
            if (oTime != null)
                sUtHours = oTime.TS_Utilized_Mts.ToString();

            return sUtHours;
        }


    }
}
