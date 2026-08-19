using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEACC_PTS.NmsEnum
{
    class clsEnum
    {
        public enum Email_Alignment
        {
            Left=0,
            Right=1,
            Center=2
        }

        public enum AutoSendEmail
        {
            RepeatedTask_Summary=0,
            EngWiseWeeklyReport=1,
        }
    }
}
