using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using SEACC_PTS.NmsLogic;
using System.Data.Common;

namespace SEACC_PTS
{
    public partial class frmReports : Form
    {
        #region variables
        bool bCustomerSelected = false, bProductSelected = false, bTaskTypeSelected = false, bPrioritySelected = false, bStatusSelected = false, bAssignedToSelected = false, bReportedDateSelected = false;
        private BindingSource bSource = new BindingSource();
        #endregion
        public frmReports()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                bCustomerSelected = true;
            if (txtProduct.Tag != null && txtProduct.Tag.ToString().Trim().Length > 0)
                bProductSelected = true;
            if (txtTaskType.Tag != null && txtTaskType.Tag.ToString().Trim().Length > 0)
                bTaskTypeSelected = true;
            if (txtPriority.Tag != null && txtPriority.Tag.ToString().Trim().Length > 0)
                bPrioritySelected = true;
            if (txtStatus.Tag != null && txtStatus.Tag.ToString().Trim().Length > 0)
                bStatusSelected = true;
            if (txtAssignedTo.Tag != null && txtAssignedTo.Tag.ToString().Trim().Length > 0)
                bAssignedToSelected = true;
           
            if (rbtTimeSheet.Checked == true)
                PrintReport(false);            

            #region Task
            else if (rbtTask.Checked)
            {
                DataSets.dts_PTS pts = new DataSets.dts_PTS();
                DataSets.dts_PTS RptData = new DataSets.dts_PTS();

                Image newImage = Image.FromFile("image\\Digiteq_logo.png");

                MemoryStream ms = new MemoryStream();
                newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                string sDateRange = (dtpToDate.Value.Date == dtpFromDate.Value.Date) ? "Date : " + dtpFromDate.Value.Date.ToString("dd-MM-yyy") : "Date Range : " + dtpFromDate.Value.Date.ToString("dd-MM-yyy") + " To " + dtpToDate.Value.Date.ToString("dd-MM-yyy");
                pts.dt_CompanyInfo.Adddt_CompanyInfoRow("Digiteq Solutions (put)LTD.", "# 132/5, Negombo Road,Kandana, Sri Lanka.", "Tel:+94117820080 ", ms.ToArray(), settings.strLogedUserName, sDateRange, "www.digiteq.biz");

                foreach (tbl_ptsTasks task in tbl_ptsTasks.SelectAll().Where(p => p.ReportedDate.Date <= dtpToDate.Value.Date && p.ReportedDate.Date >= dtpFromDate.Value.Date))
                {
                   RichTextBox rtf_Desc = new RichTextBox();
                    RichTextBox rtf_TestCases = new RichTextBox();
                    RichTextBox rtf_DevComments = new RichTextBox();

                    rtf_Desc.Rtf = task.Task_Desc;
                    rtf_TestCases.Rtf = task.TestCases;
                    rtf_DevComments.Rtf = task.DevComments;

                    pts.dt_Task.Adddt_TaskRow(task.Task_ID, task.Task, rtf_Desc.Text, rtf_TestCases.Text, rtf_DevComments.Text, task.Reference_1, task.ReportedDate, task.ReportedBy, task.Client_ID.ToString(), configNames.GetClientCode(task.Client_ID), task.Prod_ID.ToString(), configNames.GetProductName(task.Prod_ID),
                        configNames.GetFunctionName(task.Function_ID), task.Activity_ID, configNames.GetStatus(task.Status_ID), task.Progress, task.Assign_To, configNames.GetUserName(task.Assign_To), task.Estimate_Minutes, configNames.GetType(task.Type_ID) , configNames.GetPriority(task.Priority), task.Deadline, task.ActualHours, configNames.GetUserName(task.CreateUser_ID), configNames.GetUserName(task.ModifiedUser_ID), task.DateCreate,task.DateModified );

                    foreach (tbl_ptsTimeSheet time in tbl_ptsTimeSheet.SelectAllByTask_ID(task.Task_ID))
                    {
                        tbl_masUser user = tbl_masUser.Select(time.CreateUser_ID);
                        if (user != null)
                        {
                            pts.dt_TimeSheet_Activitys.Adddt_TimeSheet_ActivitysRow(time.CreateUser_ID, time.Task_ID, task.Task, time.Remarks, time.TS_Activity_Minutes/60, user.Display_Name, time.TS_Date, configNames.GetStatus(task.Status_ID), task.Progress);
                        }
                    }
                }

                frm_ReportViewer rpr = new frm_ReportViewer();
                rpr.print("\\Reports\\rpt_TimeSheetDetail.rpt", pts, null, false);
                //rpr.print("\\Reports\\rpt_TimeSheetDetail.rpt", pts, null, true);
            }
            #endregion

            #region Time Sheet Register
            else if (rbtTimeSheetRegister.Checked)
            {
                DataSets.dts_PTS pts = new DataSets.dts_PTS();
                DataSets.dts_PTS RptData = new DataSets.dts_PTS();

                Image newImage = Image.FromFile("image\\Digiteq_logo.png");

                MemoryStream ms = new MemoryStream();
                newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);                

                foreach (tbl_ptsTimeSheet time in tbl_ptsTimeSheet.SelectAll().Where(p => p.TS_Date.Date <= dtpToDate.Value.Date && p.TS_Date.Date >= dtpFromDate.Value.Date))
                {                   
                    pts.dt_TimeSheet.Adddt_TimeSheetRow(time.TS_ID, time.TS_Date, time.Task_ID, time.User_ID, configNames.GetUserName(time.User_ID), time.Remarks, time.Activity_ID,
                            time.TS_Activity_Minutes, time.TS_Utilized_Mts, time.TS_Accum_Mts, time.CreateUser_ID.ToString(), configNames.GetUserName(time.CreateUser_ID), time.ModifiedUser_ID.ToString(), configNames.GetUserName(time.ModifiedUser_ID), time.DateCreate, time.DateModified);

                }

                string sDateRange = " From " + dtpFromDate.Value.Date.ToString("dd-MM-yyy") + " To " + dtpToDate.Value.Date.ToString("dd-MM-yyy");
                pts.dt_Company.Adddt_CompanyRow("Digiteq Solutions (put)LTD.", "www.digiteq.biz", "Digiteq Solutions (put)LTD.", "# 132/5, Negombo Road,Kandana, Sri Lanka.", "Tel:+94117820080 ", ms.ToArray(), "Time Sheet Register", "", sDateRange, settings.strLogedUserName, "");

                frm_ReportViewer rpr = new frm_ReportViewer();
                rpr.print("\\Reports\\rpt_TimeSheet_Register.rpt", pts, null, false);
            }
            #endregion

            #region Task Register
            else if (rbtTaskRegister.Checked)
            {
             
                DataSets.dts_PTS pts = new DataSets.dts_PTS();
                DataSets.dts_PTS RptData = new DataSets.dts_PTS();

                Image newImage = Image.FromFile("image\\Digiteq_logo.png");

                MemoryStream ms = new MemoryStream();
                newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                String sFilter = "";
                int cus = 0;

                List<tbl_masClient> oCust;
                List<tbl_masProduct> oPro;
                List<tbl_refType> oTp;
                List<tbl_masPriority> oPrio;
                List<tbl_refStatus> oSt;
                List<tbl_masUser> oAss;

                #region Filter - Customer
                if (!bCustomerSelected)
                    oCust = tbl_masClient.SelectAll().ToList();
                else
                {
                    oCust = tbl_masClient.SelectAll().Where(p => p.Client_ID.ToString() == txtCustomer.Tag.ToString()).ToList();
                    cus =  oCust.First().Client_ID;
                    sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                }
                #endregion

                #region Filter - Product
                if (!bProductSelected)
                    oPro = tbl_masProduct.SelectAll().ToList();
                else
                {
                    oPro = tbl_masProduct.SelectAll().Where(p => p.Product_ID.ToString() == txtProduct.Tag.ToString()).ToList();
                    sFilter += " Product Name : " + txtProduct.Text.Trim();
                }
                #endregion

                #region Filter - Type
                if (!bTaskTypeSelected)
                    oTp = tbl_refType.SelectAll().ToList();
                else
                {
                    oTp = tbl_refType.SelectAll().Where(p => p.Type_ID.ToString() == txtTaskType.Tag.ToString()).ToList();
                    sFilter += " Task Type Name : " + txtTaskType.Text.Trim();
                }
                #endregion

                #region Filter - Priority
                if (!bPrioritySelected)
                    oPrio = tbl_masPriority.SelectAll().ToList();
                else
                {
                    oPrio = tbl_masPriority.SelectAll().Where(p => p.priorityID.ToString() == txtPriority.Tag.ToString()).ToList();
                    sFilter += " Priority : " + txtPriority.Text.Trim();
                }
                #endregion

                #region Filter - Status
                if (!bStatusSelected)
                    oSt = tbl_refStatus.SelectAll().ToList();
                else
                {
                    oSt = tbl_refStatus.SelectAll().Where(p => p.Status_ID.ToString() == txtStatus.Tag.ToString()).ToList();
                    sFilter += " Status : " + txtStatus.Text.Trim();
                }
                #endregion

                #region Filter - Assigned To
                if (!bAssignedToSelected)
                    oAss = tbl_masUser.SelectAll().ToList();
                else
                {
                    oAss = tbl_masUser.SelectAll().Where(p => p.User_ID.ToString() == txtAssignedTo.Tag.ToString()).ToList();
                    sFilter += " Assigned To : " + txtAssignedTo.Text.Trim();
                }
                #endregion                            


                tbl_ptsTasks Task = new tbl_ptsTasks();
                string sCustomer = "%";
                if (bCustomerSelected)
                    sCustomer = txtCustomer.Tag.ToString();

                string sProduct = "%";
                if (bProductSelected)
                    sProduct = txtProduct.Tag.ToString();

                string sTask = "%";
                if (bTaskTypeSelected)
                    sTask = txtTaskType.Tag.ToString();

                string sPriority = "%";
                if (bPrioritySelected)
                    sPriority = txtPriority.Tag.ToString();

                string sStatus = "%";
                if (bStatusSelected)
                    sStatus = txtStatus.Tag.ToString();

                string sAssigned = "%";
                if (bAssignedToSelected)
                    sAssigned = txtAssignedTo.Tag.ToString();

                dt= Task.SelectAll_TableWithRefference2(sCustomer, sProduct, sTask, sPriority, sStatus, sAssigned, dtpFromDate.Value.Date, dtpToDate.Value.Date);
                

                //string sDateRange = (dtpToDate.Value.Date == dtpFromDate.Value.Date) ? "Date : " + dtpFromDate.Value.Date.ToString("dd-MM-yyy") : "Date Range : " + dtpToDate.Value.Date.ToString("dd-MM-yyy") + " To " + dtpToDate.Value.Date.ToString("dd-MM-yyy");
                string sDateRange = " From " + dtpFromDate.Value.Date.ToString("dd-MM-yyy") + " To " + dtpToDate.Value.Date.ToString("dd-MM-yyy");                

                pts.dt_Company.Adddt_CompanyRow("Digiteq Solutions (put)LTD.", "www.digiteq.biz", "Digiteq Solutions (put)LTD.", "# 132/5, Negombo Road,Kandana, Sri Lanka.", "Tel:+94117820080 ", ms.ToArray(), "Task Register", "", sDateRange, settings.strLogedUserName, sFilter );
                
                frm_ReportViewer rpr = new frm_ReportViewer();

                rpr.print2("\\Reports\\rpt_TaskRegister.rpt", pts, dt, null, false);
            }
            #endregion


            else
                btn_Task_Click(null, null);
        }

        public string PrintReport(bool bIsExport)
        {
            DataSets.dts_PTS pts = new DataSets.dts_PTS();
            DataSets.dts_PTS RptData = new DataSets.dts_PTS();

            Image newImage = Image.FromFile("image\\Digiteq_logo.png");

            MemoryStream ms = new MemoryStream();
            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            string sDateRange = (dtpToDate.Value.Date == dtpFromDate.Value.Date) ? "Date : " + dtpFromDate.Value.Date.ToString("dd-MM-yyy") : "Date Range : " + dtpFromDate.Value.Date.ToString("dd-MM-yyy") + " To " + dtpToDate.Value.Date.ToString("dd-MM-yyy");
            pts.dt_CompanyInfo.Adddt_CompanyInfoRow("Digiteq Solutions (put)LTD.", "# 132/5, Negombo Road,Kandana, Sri Lanka.", "Tel:+94117820080 ", ms.ToArray(), settings.strLogedUserName, sDateRange, "");

            List<tbl_masUser> oUser;
            if (txtAssignedTo.Tag != null && txtAssignedTo.Text != "")
            {
                int iUserID = int.Parse(txtAssignedTo.Tag.ToString());
                oUser = tbl_masUser.SelectAll().Where(p => p.User_ID == iUserID).ToList();
            }
            else
                oUser = tbl_masUser.SelectAll().ToList();

            foreach (tbl_masUser oUsr in oUser)
            {
                foreach (tbl_ptsTimeSheet time in tbl_ptsTimeSheet.SelectAll().Where(p => p.TS_Date.Date <= dtpToDate.Value.Date && p.TS_Date.Date >= dtpFromDate.Value.Date && p.User_ID == oUsr.User_ID))
            {
                tbl_ptsTasks task = tbl_ptsTasks.Select(time.Task_ID);
                if (task != null)
                {
                        //tbl_masUser user = tbl_masUser.Select(time.CreateUser_ID);
                        //if (user != null)
                        //{
                            pts.dt_TimeSheet_Activitys.Adddt_TimeSheet_ActivitysRow(time.CreateUser_ID, time.Task_ID, task.Task, time.Remarks, time.TS_Activity_Minutes, oUsr.Display_Name, time.TS_Date, configNames.GetStatus(task.Status_ID), task.Progress);
                        //}
                    }

                }

            }
            frm_ReportViewer rpr = new frm_ReportViewer();
            return rpr.print("\\Reports\\rpt_TimeSheet.rpt", pts, null, bIsExport);
        }

        private void btn_Task_Click(object sender, EventArgs e)
        {
            DataSets.dts_PTS pts = new DataSets.dts_PTS();
            DataSets.dts_PTS RptData = new DataSets.dts_PTS();

            Image newImage = Image.FromFile("image\\Digiteq_logo.png");

            MemoryStream ms = new MemoryStream();
            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            pts.dt_CompanyInfo.Adddt_CompanyInfoRow("Digiteq Solutions (put)LTD.", "# 132/5, Negombo Road,Kandana, Sri Lanka.", "Tel:+94117820080 ", ms.ToArray(), settings.strLogedUserName, "", "");

            foreach (vw_ptsTasks task in vw_ptsTasks.SelectAll())
            {
                pts.dt_Task.Adddt_TaskRow(task.Task_ID, task.Task, task.Task_Desc, "", "",  task.Reference_1, task.ReportedDate, task.ReportedBy, task.Client_Code, task.Client_Code, task.Product_Code, task.Product_Code,"", 0, task.Status, 0, task.Assign_To_User_ID, task.Assign_To_User_Name, 0, "", 0.ToString(), System.DateTime.Now.Date, 0, "", "", task.ReportedDate, task.ReportedDate);
            }
            frm_ReportViewer rpr = new frm_ReportViewer();
            rpr.print("\\Reports\\rpt_TaskRegister2.rpt", pts, null, false);
        }

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = "";
            txtCustomer.Tag = null;
            txtProduct.Text = "";
            txtProduct.Tag = null;
            txtTaskType.Text = "";
            txtTaskType.Tag = null;
            txtPriority.Text = "";
            txtPriority.Tag = null;
            txtStatus.Text = "";
            txtStatus.Tag = null;
            txtAssignedTo.Text = "";
            txtAssignedTo.Tag = null;

            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;

        }
        #endregion

        #region Enable/ Disable fields
        private void rbtTaskRegister_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = true;
            txtProduct.Enabled = true;
            txtTaskType.Enabled = true;
            txtPriority.Enabled = true;
            txtStatus.Enabled = true;
            txtAssignedTo.Enabled = true;

            btnClear_Click(sender, e);

            //dtpFromDate.Value = DateTime.Today;
            //dtpToDate.Value = DateTime.Today;
        }        

        private void rbtTimeSheet_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = false;
            txtProduct.Enabled = false;
            txtTaskType.Enabled = false;
            txtPriority.Enabled = false;
            txtStatus.Enabled = false;
            txtAssignedTo.Enabled = true;

            btnClear_Click(sender, e);

            //dtpFromDate.Value = DateTime.Today;
            //dtpToDate.Value = DateTime.Today;
        }

        private void rbtTask_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = false;
            txtProduct.Enabled = false;
            txtTaskType.Enabled = false;
            txtPriority.Enabled = false;
            txtStatus.Enabled = false;
            txtAssignedTo.Enabled = false;

            btnClear_Click(sender, e);

            //dtpFromDate.Value = DateTime.Today;
            //dtpToDate.Value = DateTime.Today;
        }

        private void rbtTimeSheetRegister_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomer.Enabled = false;
            txtProduct.Enabled = false;
            txtTaskType.Enabled = false;
            txtPriority.Enabled = false;
            txtStatus.Enabled = false;
            txtAssignedTo.Enabled = false;

            btnClear_Click(sender, e);

            //dtpFromDate.Value = DateTime.Today;
            //dtpToDate.Value = DateTime.Today;
        }
        #endregion

        #region Search
        private void txtStatus_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("612");
            if (strResult.Count > 0)
            {
                txtStatus.Tag = strResult[0];
                txtStatus.Text = strResult[1];
            }

        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("100");
            if (strResult.Count > 0)
            {
                txtCustomer.Tag = strResult[0];
                txtCustomer.Text = strResult[1];
            }
        }

        private void txtProduct_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("105");
            if (strResult.Count > 0)
            {
                txtProduct.Tag = strResult[0];
                txtProduct.Text = strResult[1];
            }
        }

        private void txtTaskType_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("605");
            if (strResult.Count > 0)
            {
                txtTaskType.Tag = strResult[0];
                txtTaskType.Text = strResult[1];
               // txtAssignedTo.Text = strResult[2];
            }
        }

        private void txtAssignedTo_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("110");
            if (strResult.Count > 0)
            {
                txtAssignedTo.Tag = strResult[0];
                txtAssignedTo.Text = strResult[1];
            }
        }

        private void txtPriority_DoubleClick(object sender, EventArgs e)
        {
            frm_PickBox PickBx = new frm_PickBox();
            List<string> strResult = PickBx.Pick("611");
            if (strResult.Count > 0)
            {
                txtPriority.Tag = strResult[0];
                txtPriority.Text = strResult[1];
            }
        }
        #endregion

        #region Event Closed and Minimize
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}