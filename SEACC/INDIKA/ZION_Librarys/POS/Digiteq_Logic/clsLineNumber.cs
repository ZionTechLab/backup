using DataTire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digiteq_Logic
{
    public class clsLineNumber
    {
        //public static int GetMaximumLineNoGLMaster(string main, string sub, string account)
        //{
        //    int iMaxNo = 1;
        //    foreach (tbl_accGLMaster detail in tbl_accGLMaster.SelectAllByGlAccountType_ID(account).Where(p => !p.IsDeleted && p.Gl_ID != "default" && p.Line_No >= iMaxNo))
        //    {
        //        iMaxNo = detail.Line_No + 1;
        //    }
        //    return iMaxNo;
        //}

        public static int GetMaximumLineNo_WIPShedule(string sWIPCode, int iLineNo, string sPrePlanID, string sSectionID, string sMachineID)
        {
            int iMaxNo = 1;
            foreach (tbl_pmsWorkInProgress_Machine_Shedule detail in tbl_pmsWorkInProgress_Machine_Shedule.SelectAllByWorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID(sWIPCode, iLineNo, sPrePlanID, sSectionID, sMachineID).Where(p => p.WorkInProgress_ID != "default" && p.Line_NoShedule >= iMaxNo))
            {
                iMaxNo = detail.Line_NoShedule + 1;
            }
            return iMaxNo;
        }       
    }
}