using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTire;
using System.Windows.Forms;

namespace Digiteq_Logic
{
    public class clsLog
    {
        #region Process - Print
        public static void Process_Print(int sForm_ID, int sProcessNote_ID, string sNote_ID)
        {
            //need to change
            tbl_atlProcess_Print detail = new tbl_atlProcess_Print(sForm_ID, sProcessNote_ID, sNote_ID, "", clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID);
            detail.Insert();
        }
        //public static void Process_Print_Reports(string sReport_ID)
        //{
        //    try
        //    {
        //        tbl_securityReportMaster oReportMaster = tbl_securityReportMaster.Select(sReport_ID);
        //        if (oReportMaster != null )
        //        {
        //            oReportMaster.PrintCount++;
        //            oReportMaster.Update();
        //        }
        //        tbl_atlProcess_Print_Reports detail = new tbl_atlProcess_Print_Reports(sReport_ID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID);
        //        detail.Insert();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //} 
        #endregion

        #region Process - Modify
        public static void Process_Modify(int sForm_ID, int sProcessNote_ID, string sNote_ID, string sRemarks)
        {
            tbl_atlProcess_Modify detail = new tbl_atlProcess_Modify(sForm_ID, sProcessNote_ID, clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged, clsSecurity.TerminalID, sNote_ID, sRemarks);
            detail.Insert();
        }
        #endregion

        #region Process - Back Up
        public static void Process_Backup(long iTransaction_ID, DateTime dBackupDate, string sBackupLocation, string sUserID, string sTerminal_ID, bool bIsAutoBackup)
        {
            tbl_trcDBBackup detail = new tbl_trcDBBackup(iTransaction_ID, dBackupDate, sBackupLocation, sUserID, sTerminal_ID, bIsAutoBackup);
            detail.Insert();
        }
        #endregion
     }
}
