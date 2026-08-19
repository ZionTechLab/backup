using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frm_AlertShedules : Form
    {
        

        static bool IsUpdate = false;   
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        DateTime lastSent;
  

        #region Form Load

        public frm_AlertShedules()
        {
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_Alert_Load(object sender, EventArgs e)
        {
            CusDataGridViewFormat();
            ClearFields();
            RefreshGrid();
        }

        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool newrec = true;

            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;

                            List<tbl_utlAlert_Shedule> oldRecords = tbl_utlAlert_Shedule.SelectAll();
                            foreach (tbl_utlAlert_Shedule Record in oldRecords)
                            {
                                if (txtAlertID.Text.Trim().ToUpper() == Record.Alert_ID.ToUpper())
                                {
                                    if (IsUpdate)  //update records
                                    {
                                        //tbl_utlAlert_Shedule oldRecord = tbl_utlAlert_Shedule.Select(txtAlertID.Text.Trim());
                                        //if (oldRecord != null)
                                        //{
                                        //    //Country Header
                                        //    //tbl_utlAlert_Shedule detail = new tbl_utlAlert_Shedule(txtAlertID.Text.Trim(), chkActive.Checked, rdoDay.Checked,rdoWeek.Checked,rdoMonth.Checked,rdoYear.Checked, System.Convert.ToDateTime(dtpShedule.Text), lastSent,false);
                                        //    //detail.Update();
                                        //    //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //}
                                    }
                                    newrec = false;
                                    break;
                                }
                            }

                            if (newrec)//Insert Record
                            {
                                MessageBox.Show("Cannot insert New Record");
                            }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID,ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                            RefreshGrid();
                        }
                    }
                }
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAlertID, false);
            clsCommon.SetEnableDisable_NormalLabel(lblAlertID, true);

            txtAlertName.Clear();

            chkActive.Checked = false;
            rdoDay.Checked = false;
            rdoWeek.Checked = false;
            rdoMonth.Checked = false;
            rdoYear.Checked = false;
            dtpShedule.Text = System.DateTime.Now.ToString();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_utlAlert_Shedule> details = tbl_utlAlert_Shedule.SelectAll();
                foreach (tbl_utlAlert_Shedule detail in details)
                {//not sure
                    if (detail.Alert_ID.Trim() != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        tbl_utlAlert oAlert = tbl_utlAlert.Select(detail.Alert_ID);
                        if (oAlert != null && oAlert.Alert_ID != "default")
                        {
                            dgvDetail["AlertId", iRow].Value = detail.Alert_ID;
                            dgvDetail["AlertName", iRow].Value = oAlert.AlertName;                           
                            dgvDetail["Sheduleddate", iRow].Value = detail.SheduledTime;
                            dgvDetail["SheduledTime", iRow].Value = detail.SheduledTime;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                //if (sID.Length > 0)
                //{
                //    tbl_utlAlert detail = tbl_utlAlert.Select(sID);
                //    tbl_utlAlert_Shedule detail1 = tbl_utlAlert_Shedule.Select(sID);
                //    if (detail != null && detail1 != null)
                //    {
                //        //set the update flag and Locked
                //        IsUpdate = true;
                //        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAlertID, false);
                //        clsCommon.SetEnableDisable_NormalLabel(lblAlertID, false);

                //        //asign values
                //        txtAlertID.Text = detail.Alert_ID;
                //        txtAlertName.Text = detail.AlertName;

                //        //asign values
                //        chkActive.Checked = detail1.IsActive;
                //        rdoDay.Checked = detail1.IsDaily;
                //        rdoWeek.Checked = detail1.IsWeekly;
                //        rdoMonth.Checked = detail1.IsMonthly;
                //        rdoYear.Checked = detail1.IsYearly;
                //        dtpShedule.Text = detail1.SheduledTime.ToString();
                //        lastSent = detail1.LastAlert_SentTime;
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
          //  string strMessage = "";
            bool bStatus = true;

            //if (txtAlertName.TextLength == 0)
            //{
            //    strMessage += "\n" + "Alert Name ";
            //    bStatus = false;
            //}
            //if (bStatus == false)
            //{
            //    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Events KeyDown
        private void txtAlertID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AlertID();
            }
        }

        private void frm_Alert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtAlertID_DoubleClick(object sender, EventArgs e)
        {
            Search_AlertID();
        }
        #endregion

        #region Events Datagrid
        private void DGAlert_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sID = dgvDetail["AlertId", e.RowIndex].Value.ToString();
                    if (sID.Length > 0)
                    {
                        //fills the values to controls
                        FillDetails(sID.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void DGAlert_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DGAlert_CellClick(sender, e);
        }
        #endregion

        #region Search Methods
        private void Search_AlertID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_AlertID();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtAlertID.Text = frmSearchMaster.s_SearchID;
                    FillDetails(frmSearchMaster.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion 

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoDay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoWeek_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoYear_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
