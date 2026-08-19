using SEACC_PTS.NmsEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEACC_PTS.NmsLogic
{
    class ClsFormatter
    {
        public static string FormatDate_FullString(DateTime dt)
        {
            string sValue = dt.ToString("yyyy''MM''dd''HH''mm''ss");
            return sValue;
        }

        public static string FormatMinitsToHours(int iMinits)
        {
            TimeSpan tsTime = TimeSpan.FromMinutes(iMinits);
            string sValue = tsTime.TotalHours.ToString();
            if (sValue != "")
                return sValue;
            else
                return "-";
        }

        public static string GetAlignment(clsEnum.Email_Alignment oL)
        {
            string sValue = "Left";
            switch (oL)
            {
                case clsEnum.Email_Alignment.Center:
                    sValue = "Center";
                    break;
                case clsEnum.Email_Alignment.Right:
                    sValue = "Right";
                    break;
                default:
                    sValue = "Left";
                    break;

            }
            return sValue;

        }

    }
}
