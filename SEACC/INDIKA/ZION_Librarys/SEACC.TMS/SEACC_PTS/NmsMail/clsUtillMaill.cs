using SEACC_PTS.NmsEnum;
using SEACC_PTS.NmsLogic;
using SEACC_PTS.NmsSecurity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEACC_PTS
{
    class clsUtillMaill
    {
        DataTable dtMailDetail = new DataTable();

        public static void createEmail_AssignedTask(int iTaskID, ref RichTextBox oRich, bool bIsUpdate, int iOldAssingUserID)
        {

            tbl_ptsTasks oDetail = tbl_ptsTasks.Select(iTaskID);
            int iEngid = oDetail.Assign_To;
            int iCreateUserID = oDetail.CreateUser_ID;
            int iModifiedUserID = oDetail.ModifiedUser_ID;
            string sEmail_ID = ClsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
            if (oDetail != null)
            {
                List<emailLine> lstEData = new List<emailLine>();
                EmailLineformating oEmailLineFormat = new EmailLineformating();

                string sBodyHTML = "";
                #region Create/Format Email Body

                #region Data

                string sSubject = oDetail.Task_ID + ":" + oDetail.Task;
                string sTitle = bIsUpdate ? "Task Updated" : "New Task Created";
                bool bIsChangeAssignUser = false;
                if (bIsUpdate)
                    if (oDetail.Assign_To != iOldAssingUserID)
                        bIsChangeAssignUser = true;
                #endregion

                lstEData.Add(new emailLine(LineType.H1, sTitle));
                lstEData.Add(new emailLine(LineType.Line1));

                lstEData.Add(new emailLine(LineType.Detail2, "Task ID", oDetail.Task_ID.ToString()));
                lstEData.Add(new emailLine(LineType.Detail2, "Task", oDetail.Task));

                lstEData.Add(new emailLine(LineType.Detail2, "Reference ", oDetail.Reference_1 == "" ? "-" : oDetail.Reference_1));
                oRich.Clear();
                oRich.Rtf = oDetail.Task_Desc;

                #region for Split Detail
                //for Split Detail
                lstEData.Add(new emailLine(LineType.P_heading, "Detail"));
                String[] sDetailContainer = oRich.Text.ToString().Split('\n');
                if (sDetailContainer != null && sDetailContainer.Length > 0)
                {
                    foreach (string sDetail in sDetailContainer)
                    {
                        lstEData.Add(new emailLine(LineType.P, "", sDetail == "" ? "" : sDetail));
                    }
                }
                #endregion

                //----------------------------------------
                // lstEData.Add(new emailLine(LineType.Detail2, "Description", oRich.Text == "" ? "-" : oRich.Text));
                oRich.Clear();
                oRich.Rtf = oDetail.DevComments;
                lstEData.Add(new emailLine(LineType.Detail2, "Tech.Comments", oRich.Text == "" ? "-" : oRich.Text));
                lstEData.Add(new emailLine(LineType.Space));


                lstEData.Add(new emailLine(LineType.Detail2, "Client", clsGenaralNmaes.getNameClient(oDetail.Client_ID)));//string
                lstEData.Add(new emailLine(LineType.Detail2, "Reported By", oDetail.ReportedBy == "" ? "-" : oDetail.ReportedBy));
                lstEData.Add(new emailLine(LineType.Detail2, "Reported Date", oDetail.ReportedDate.Date.ToString("dd/MM/yyyy")));

                // if(bIsChangeAssignUser)
                //  lstEData.Add(new emailLine(LineType.Detail2, "Canceled Assign User", clsGenaralNmaes.getNameEngineer(iOldAssingUserID)));
                lstEData.Add(new emailLine(LineType.Space));

                lstEData.Add(new emailLine(LineType.Detail2, "Product", clsGenaralNmaes.getNameProduct(oDetail.Prod_ID)));
                lstEData.Add(new emailLine(LineType.Detail2, "Function", clsGenaralNmaes.getNameFunction(oDetail.Function_ID)));
                lstEData.Add(new emailLine(LineType.Space));

                lstEData.Add(new emailLine(LineType.Detail2, "Assign To", clsGenaralNmaes.getNameEngineer(iEngid)));
                lstEData.Add(new emailLine(LineType.Detail2, "Task Type", clsGenaralNmaes.getNameTaskType(oDetail.Type_ID)));
                lstEData.Add(new emailLine(LineType.Detail2, "Priority", clsGenaralNmaes.getNamePriorityType(oDetail.Priority)));
                lstEData.Add(new emailLine(LineType.Detail2, "Estimate Hours", ClsFormatter.FormatMinitsToHours(oDetail.Estimate_Minutes)));
                lstEData.Add(new emailLine(LineType.Detail2, "DeadLine", oDetail.Deadline.Date.Date.ToString("dd/MM/yyyy")));
                lstEData.Add(new emailLine(LineType.Space));

                lstEData.Add(new emailLine(LineType.Detail2, "Status", clsGenaralNmaes.getNameStatus(oDetail.Status_ID)));
                lstEData.Add(new emailLine(LineType.Space));

                lstEData.Add(new emailLine(LineType.Line1));
                #region Set Create Date Time
                DateTime dtmCreateDate = DateTime.MinValue;
                if (bIsUpdate)
                    dtmCreateDate = oDetail.DateCreate;
                else
                    dtmCreateDate = clsSecurity.getServerDateTime();
                #endregion
                lstEData.Add(new emailLine(LineType.Detail2, "Created", (dtmCreateDate + " | " + clsGenaralNmaes.getNameEngineer(oDetail.CreateUser_ID)).ToString()));
                lstEData.Add(new emailLine(LineType.Detail2, "Modified", oDetail.ModifiedUser_ID.ToString() == "0" ? "-" : (clsSecurity.getServerDateTime() + " | " + (oDetail.ModifiedUser_ID.ToString() == "0" ? "-" : clsGenaralNmaes.getNameEngineer(oDetail.ModifiedUser_ID))).ToString()));
                lstEData.Add(new emailLine(LineType.H5, "Email Ref No :" + sEmail_ID));
                //lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                sBodyHTML = Alert.CreateEmailBody(lstEData, oEmailLineFormat, null, null, null);
                #endregion

                #region Send Email
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                List<int> oUserID = new List<int>();
                oUserID.Add(iEngid);
                oUserID.Add(iCreateUserID);
                if (bIsUpdate)
                    oUserID.Add(iModifiedUserID);
                if (bIsChangeAssignUser)
                    oUserID.Add(iOldAssingUserID);
                foreach (int iID in oUserID)
                {
                    tbl_masUser oMaster = tbl_masUser.Select(iID);

                    if (oMaster != null)
                        if (oMaster.EmailAddress.Length > 0)
                            tolist.Add(oMaster.EmailAddress);
                }


                foreach (tbl_ptsTasks_Attachments oAtachment in tbl_ptsTasks_Attachments.SelectAllByTask_ID(oDetail.Task_ID))
                {
                    string sAttachment = Path.GetExtension(oAtachment.Attachment.ToString());
                    if (sAttachment == ".png" || sAttachment == ".PNG" || sAttachment == ".jpg" || sAttachment == ".JPG" || sAttachment == ".JPEG" || sAttachment == ".gif" || sAttachment == ".GIF" || sAttachment == ".bmp" || sAttachment == ".BMP")
                    {
                        //int iStartIndex = oAtachment.Attachment.IndexOf('.');
                        // int iLenth = oAtachment.Attachment.Length;
                        //string sFileName = oAtachment.Attachment.Substring(0, iStartIndex);
                        filelist.Add(@"Attachments\" + oAtachment.Attachment);
                    }
                    else
                    {
                        continue;
                    }

                    /* string [] sSplit= oAtachment.DipsplayName.Split('.');
                     foreach (string name in sSplit)
                     {
                         if (name != "png" || name != "PNG" || name != "jpg" || name != "JPG" || name != "JPEG" || name != "jpg")
                         {
                             continue;
                         }
                         else
                         {
                             filelist.Add(@"Attachments\" + oAtachment.Attachment);
                         }
                     }*/

                }

                Alert.SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                #endregion
            }
        }

        public static void createEmail_CompleatTask(int iTaskID, string sStatus)
        {

            tbl_ptsTasks oDetail = tbl_ptsTasks.Select(iTaskID);
            int iCreateUserID = oDetail.CreateUser_ID;
            string sEmail_ID = ClsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
            if (oDetail != null)
            {
                List<emailLine> lstEData = new List<emailLine>();
                EmailLineformating oEmailLineFormat = new EmailLineformating();

                string sBodyHTML = "";
                #region Create/Format Email Body

                #region Data
                string sSubject = oDetail.Task_ID + ":" + oDetail.Task;
                string sTitle = oDetail.Task + "Task is" + sStatus;
                #endregion

                lstEData.Add(new emailLine(LineType.H1, sTitle));
                lstEData.Add(new emailLine(LineType.Line1));

                lstEData.Add(new emailLine(LineType.Detail2, "Task ID", oDetail.Task_ID.ToString()));
                lstEData.Add(new emailLine(LineType.Detail2, "Task", oDetail.Task));
                lstEData.Add(new emailLine(LineType.Detail2, "Reference ", oDetail.Reference_1 == "" ? "-" : oDetail.Reference_1));
                lstEData.Add(new emailLine(LineType.Detail2, "Client", clsGenaralNmaes.getNameClient(oDetail.Client_ID)));//string
                lstEData.Add(new emailLine(LineType.Space));
                lstEData.Add(new emailLine(LineType.Detail2, "Status", sStatus));
                lstEData.Add(new emailLine(LineType.Space));
                lstEData.Add(new emailLine(LineType.Line1));

                #region Set Create Date Time
                DateTime dtmCreateDate = DateTime.MinValue;
                dtmCreateDate = clsSecurity.getServerDateTime();
                #endregion
                lstEData.Add(new emailLine(LineType.Detail2, sStatus, (dtmCreateDate + " | " + clsGenaralNmaes.getNameEngineer(settings.UserId_Loged))));
                lstEData.Add(new emailLine(LineType.H5, "Email Ref No :" + sEmail_ID));

                sBodyHTML = Alert.CreateEmailBody(lstEData, oEmailLineFormat, null, null, null);
                #endregion

                #region Send Email
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                List<int> oUserID = new List<int>();

                oUserID.Add(iCreateUserID);

                foreach (int iID in oUserID)
                {
                    tbl_masUser oMaster = tbl_masUser.Select(iID);
                    // Foreach(tbl_altAlert_Shedule_Users oGroup in tbl_altAlert_Shedule_Users.SelectAllByShedule_ID())
                    if (oMaster != null)
                        if (oMaster.EmailAddress.Length > 0)
                            tolist.Add(oMaster.EmailAddress);
                }

                Alert.SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                #endregion
            }
        }

        public static void createEmail_RepeatedTask_Summary()
        {

            DataTable dtDetail = new DataTable();
            DataTable dtHeader = new DataTable();
            List<emailLine> lstEData = new List<emailLine>();

            EmailLineformating oEmailLineFormat = new EmailLineformating();

            string sTitle = "Task Summary(Repeated Function Wise)", sBodyHTML = "";

            #region Add Coloumn For Detail
            //For Detail one
            dtDetail.Columns.Add("TaskNo");
            dtDetail.Columns.Add("Description");
            dtDetail.Columns.Add("Client");
            dtDetail.Columns.Add("EngName");
            dtDetail.Columns.Add("UTMinutes");
            dtDetail.Rows.Add("TaskNo", "Task Description", "Client Name", "Engineer Name", "UT Minutes");
            clsEnum.Email_Alignment[] ClomnAlignment = new clsEnum.Email_Alignment[] { clsEnum.Email_Alignment.Left, clsEnum.Email_Alignment.Left, clsEnum.Email_Alignment.Left, clsEnum.Email_Alignment.Left, clsEnum.Email_Alignment.Right };
            // dtDetail.Rows.Add(clsEnum.Email_Alignment.Left, clsEnum.Email_Alignment.Left, clsEnum.Email_Alignment.Left, clsEnum.Email_Alignment.Left);
            #endregion



            lstEData.Add(new emailLine(LineType.H1, sTitle));
            lstEData.Add(new emailLine(LineType.Line1));


            foreach (tbl_refFunction oFuntion in tbl_refFunction.SelectAll())
            {
                int iFunCount = 1;
                int iFuntionGroupCount = 0;


                List<tbl_ptsTasks> oTaskList = tbl_ptsTasks.SelectAll().OrderBy(x => x.Function_ID).Where(p => p.Function_ID != 0 && p.Function_ID == oFuntion.Function_ID && p.Type_ID == 2 && p.DateCreate.Date > clsGenaralNmaes.getNowDate().AddMonths(-6) && p.DateCreate.Date < clsGenaralNmaes.getNowDate()).ToList();
                foreach (tbl_ptsTasks oTask in oTaskList)
                {
                    if (oTaskList.Count >= 3)
                    {
                        if (iFuntionGroupCount == 0)
                        {

                            dtDetail.Rows.Add("", clsGenaralNmaes.getNameFunction(oFuntion.Function_ID), "5", "", "");//4 For Colspan(Group_)
                        }
                        iFuntionGroupCount++;
                        dtDetail.Rows.Add(oTask.Task_ID, oTask.Task, clsGenaralNmaes.getNameClient(oTask.Client_ID), clsGenaralNmaes.getNameEngineer(oTask.Assign_To), clsFinder.getUtilizedHours(oTask.Task_ID));

                    }
                    #region ********How to use Colspan For Data Datable********
                    /*
                             #Add Data Table 0 Index Value As Empty("") for Active Colspan Option
                             #Add Data Table 1 Index Value As Your Comments
                             #Add Data Table 2 Index Value As Your Colspan Number Ex=IF 4 Coloumn Table Full Colspan number Should be 4
                                 
                             */

                    #endregion
                    iFunCount++;

                    #region Removed
                    /*
                     *  int iMatchRowCount = 0;//For Add Group to ProdId 
                foreach (tbl_ptsTimeSheet oTimeSheet in tbl_ptsTimeSheet.SelectAll().Where(p => p.TS_Date.Date > clsGenaralNmaes.getNowDate().AddMonths(-1) && p.TS_Date.Date < clsGenaralNmaes.getNowDate() && p.User_ID == oTask.Assign_To))
                {

                    dtDetail.Rows.Add(oTimeSheet.Task_ID, clsGenaralNmaes.getNameClient(oTask.Client_ID), clsGenaralNmaes.getNameFunction(oTask.Function_ID), oTimeSheet.TS_Activity_Minutes);
                   // #region ********How to use Colspan For Data Datable********
                    
                           //  #Add Data Table 0 Index Value As Empty("") for Active Colspan Option
                           //  #Add Data Table 1 Index Value As Your Comments
                            // #Add Data Table 2 Index Value As Your Colspan Number Ex=IF 4 Coloumn Table Full Colspan number Should be 4
                                 
                             

                    #endregion

                    tbl_ptsTasks oTmpTsk = tbl_ptsTasks.Select(oTimeSheet.Task_ID);
                    if (oTmpTsk != null)
                    {

                        if (oTimeSheet.User_ID == oUser.User_ID && oTask.Prod_ID == oTmpTsk.Prod_ID)
                        {
                            if (iMatchRowCount == 0)
                                dtDetail.Rows.Add("", clsGenaralNmaes.getNameProduct(oTmpTsk.Prod_ID), "4", "");//4 For Colspan

                            #region ********How to use Colspan For Data Datable********
                            
                             #Add Data Table 0 Index Value As Empty("") for Active Colspan Option
                             #Add Data Table 1 Index Value As Your Comments
                             #Add Data Table 2 Index Value As Your Colspan Number Ex=IF 4 Coloumn Table Full Colspan number Should be 4
                                 
                             

                           #endregion

                            dtDetail.Rows.Add(oTimeSheet.Task_ID, clsGenaralNmaes.getNameClient(oTmpTsk.Client_ID), clsGenaralNmaes.getNameProduct(oTmpTsk.Prod_ID), oTimeSheet.TS_Activity_Minutes);
                            dTotHours += oTimeSheet.TS_Activity_Minutes;
                            iMatchRowCount++;
                           
                        }
                        else
                        {
                           
                        }

                    }

                }
                dtDetail.Rows.Add("#", "2", "TOTAL Hours", dTotHours.ToString());*/

                    #endregion

                }
                if (iFunCount >= 3)
                {
                    //dtDetail.Rows.Add("#", "2", "TOTAL Hours", dTotHours.ToString());//For Sum
                }
            }

            #region Remove
            /* DataColumn TaskNo = new DataColumn();
            DataColumn Client = new DataColumn();
            DataColumn Product = new DataColumn();
            DataColumn UTHours = new DataColumn();

            foreach (DataRow dRow in dtDetail.Rows)
            {
                int iCount = dRow.Table.Columns.Count;

                for (int i = 0; i < iCount; i++)
                {
                    int iColoumnLength = dtDetail.Columns[i].MaxLength;


                    if (i == 0)
                    {
                        TaskNo.ColumnName = "TaskNo";
                        TaskNo.DataType = typeof(string);
                        TaskNo.MaxLength = iColoumnLength;
                    }
                    else if (i == 1)
                    {
                        Client.ColumnName = "Client";
                        Client.DataType = typeof(string);
                        Client.MaxLength = iColoumnLength;
                    }
                    else if (i == 2)
                    {
                        Product.ColumnName = "Product";
                        Product.DataType = typeof(string);
                        Product.MaxLength = iColoumnLength;
                    }
                    else if (i == 3)
                    {
                        UTHours.ColumnName = "UT-Hours";
                        UTHours.DataType = typeof(string);
                        UTHours.MaxLength = iColoumnLength;
                    }

                }

            }
            dtHeader.Columns.AddRange(new DataColumn[] { TaskNo, Client, Product, UTHours });
            dtHeader.Rows.Add("TaskNo", "Client", "Product", "UT-Hours"); */
            #endregion


            lstEData.Add(new emailLine(LineType.Grid, ""));

            sBodyHTML = Alert.CreateEmailBody(lstEData, oEmailLineFormat, null, dtDetail, ClomnAlignment);

            #region Send Email
            ArrayList tolist = new ArrayList();
            ArrayList filelist = new ArrayList();
            List<int> oUserID = new List<int>();

            tolist.Add("pd_engineer1@digiteq.biz");

            foreach (tbl_altAlert_Shedule_Users ouser in tbl_altAlert_Shedule_Users.SelectAllByShedule_ID(clsFinder.getShaduleID(clsEnum.AutoSendEmail.RepeatedTask_Summary)))
            {
                if (ouser != null)
                {
                    foreach (tbl_masUser oMster in tbl_masUser.SelectAllByUserGroup_ID(ouser.UserGroup_Id))
                    {
                        tolist.Add(oMster.EmailAddress);
                    }
                }

            }

            Alert.SendMailHTML("admin", tolist, filelist, sTitle, sBodyHTML, false);
            #endregion

        }

        public static void createEmail_WeeklyReportEngineerWise()
        {
            DataSets.dts_PTS pts = new DataSets.dts_PTS();
            DataSets.dts_PTS RptData = new DataSets.dts_PTS();
            string sTitle = "Engineer Wise Task Weekly Report", sBodyHTML = "", sEmail_ID = ClsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime()), FilePath = "";
            List<emailLine> lstEData = new List<emailLine>();
            EmailLineformating oEmailLineFormat = new EmailLineformating();
            try
            {
                // cursor = Cursors.WaitCursor;
                #region Data Fill for Email

                Image newImage = Image.FromFile("image\\Digiteq_logo.png");

                MemoryStream ms = new MemoryStream();
                newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                string sDateRange = "Date Range : " + clsSecurity.getServerDateTime().AddDays(-7).ToString("dd-MM-yyy") + " To " + clsSecurity.getServerDateTime().ToString("dd-MM-yyy");
                pts.dt_CompanyInfo.Adddt_CompanyInfoRow("Digiteq Solutions (put)LTD.", "# 132/5, Negombo Road,Kandana, Sri Lanka.", "Tel:+94117820080 ", ms.ToArray(), "Auto Generated Report By DTQ Tms", sDateRange, "");


                int iTempID = 0000;
                foreach (tbl_ptsTimeSheet time in tbl_ptsTimeSheet.SelectAll().Where(p => p.TS_Date.Date <= System.DateTime.Now.Date && p.TS_Date.Date >= System.DateTime.Now.Date.AddDays(-7)).OrderBy(x=> x.Task_ID))
                {

                    tbl_ptsTasks task = tbl_ptsTasks.Select(time.Task_ID);
                    if(iTempID != time.Task_ID && task != null)
                        //pts.dt_Task.Adddt_TaskRow(task.Task_ID, "", "", "", task.ReportedDate, "", "", "", "", clsGenaralNmaes.getNameProduct(task.Prod_ID), clsGenaralNmaes.getNameFunction(task.Function_ID), "", 0, 0, "", "", 0.ToString(), System.DateTime.Now.Date);
                        pts.dt_Task.Adddt_TaskRow(task.Task_ID, "", "", "", "", "", task.ReportedDate, "", "", "", task.Prod_ID.ToString(), clsGenaralNmaes.getNameProduct(task.Prod_ID), clsGenaralNmaes.getNameFunction(task.Function_ID), 0, "", 0, 0, "", 0, "", "", task.Deadline, 0, task.CreateUser_ID.ToString(), task.ModifiedUser_ID.ToString(), System.DateTime.Now.Date, task.DateModified);
                    if (task != null)
                    {
                        tbl_masUser user = tbl_masUser.Select(time.User_ID);
                        if (user != null)
                        {
                            pts.dt_TimeSheet_Activitys.Adddt_TimeSheet_ActivitysRow(time.User_ID, task.Task_ID, task.Task, time.Remarks, time.TS_Activity_Minutes, user.Display_Name, time.TS_Date, configNames.GetStatus(task.Status_ID), task.Progress);
                        }
                    }

                    iTempID = time.Task_ID;

                } frm_ReportViewer rpr = new frm_ReportViewer();
                FilePath = rpr.print("\\Reports\\rpt_TimeSheet_EngWiseWeekly.rpt", pts, null, true);
                #endregion

                #region Create Email Body
                lstEData.Add(new emailLine(LineType.H1, sTitle));
                lstEData.Add(new emailLine(LineType.Line1));
                lstEData.Add(new emailLine(LineType.Space));
                lstEData.Add(new emailLine(LineType.Detail2, "", (System.DateTime.Now.Date + " | " + clsGenaralNmaes.getNameEngineer(settings.UserId_Loged))));
                lstEData.Add(new emailLine(LineType.H5, "Email Ref No :" + sEmail_ID));

                sBodyHTML = Alert.CreateEmailBody(lstEData, oEmailLineFormat, null, null, null);
                #endregion

                #region Send Email
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                List<int> oUserID = new List<int>();

                tolist.Add("pd_engineer1@digiteq.biz");

                foreach (tbl_altAlert_Shedule_Users ouser in tbl_altAlert_Shedule_Users.SelectAllByShedule_ID(clsFinder.getShaduleID(clsEnum.AutoSendEmail.EngWiseWeeklyReport)))
                {
                    if (ouser != null)
                    {
                        foreach (tbl_masUser oMster in tbl_masUser.SelectAllByUserGroup_ID(ouser.UserGroup_Id))
                        {
                            tolist.Add(oMster.EmailAddress);
                        }
                    }

                }

                if (FilePath != "" && FilePath.Length > 0)
                    filelist.Add(FilePath);

                Alert.SendMailHTML("admin", tolist, filelist, sTitle, sBodyHTML, false);
                #endregion


                #region Delete PDF
                if (File.Exists(FilePath))
                {
                    try
                    {
                        File.Delete(FilePath);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "#Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pts.Clear();
                RptData.Clear();
            }

        }
    }
}


