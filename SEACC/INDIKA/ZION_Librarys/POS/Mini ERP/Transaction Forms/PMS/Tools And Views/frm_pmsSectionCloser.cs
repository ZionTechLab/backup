using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Digiteq
{
    public partial class frm_pmsSectionCloser : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;
        static bool IsUpdateSection = false;
        static bool IsUpdateInput = false;
        static bool IsUpdateOutPutManual = false;
        static bool IsUpdateOutPutAuto = false;

        //form manage
        string sFormConfigCode;
        string sSemiFinishedConfigCode;
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        #endregion

        #region Form Load
        public frm_pmsSectionCloser()
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.PrePlanSection);
            //sSemiFinishedConfigCode = clsAutocode.getFormConfigCode(FormName.ItemSemiFinishedGood);
            iFormID = clsSecurity.getFormID(FormName.SectionCloser);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_pmsPrePlanSection_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Planed Section Closer ", 3, iFormID);
            CusDataGridViewFormat();
            ClearFields();
        } 
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))//Write Permission Validity
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        ValidateEmptyForeignKey();
                        tbl_pmsPrePlan oldRecord = tbl_pmsPrePlan.Select(txtPrePlanID.Text.Trim());
                        if (oldRecord != null)
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                int iSecLineNo = GetSelectedSectionOrderNo();
                                string sSectionID = GetSelectedSection();
                                tbl_pmsPrePlan_SectionPath secPathLock = tbl_pmsPrePlan_SectionPath.Select(iSecLineNo, txtPrePlanID.Text.Trim(), sSectionID);
                                if (secPathLock != null)
                                {
                                    DialogResult msgResult = MessageBox.Show("Do You Want To Re-Open This Job from Section?\n" +  clsGenaralName.getName_Section(secPathLock.Section_ID) + "!.", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        secPathLock.IsJobClosed = false;
                                        secPathLock.DateJobClosed = clsSecurity.getServerDateTime();
                                        secPathLock.Update();
                                        MessageBox.Show("Section Re-Opened Successfully.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                                    }
                                }
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);                                    
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        tbl_pmsPrePlan oldRecord = tbl_pmsPrePlan.Select(txtPrePlanID.Text.Trim());
                        if (oldRecord != null)
                            FillDetails(txtPrePlanID.Text.Trim());
                    }
                }
            }
        }
        #endregion
         

        #region Btn Clear Section
        private void btnClearSection_Click(object sender, EventArgs e)
        {
            ClearSection();
        }
        #endregion                 

        #region Btn Viewer JobCode
        private void btnViewerJobCode_Click(object sender, EventArgs e)
        {
            if (txtJobID.Tag != null)
            {
                frm_sasJobViewer detail = new frm_sasJobViewer();
                tbl_pmsProductionJobRegister JobID = tbl_pmsProductionJobRegister.Select(txtJobID.Tag.ToString());
                if (JobID != null)
                {
                    detail.glbJobID = JobID.Job_ID;
                    detail.glbProductionJobID = txtJobID.Tag.ToString();
                    detail.ShowDialog();
                }
            }
        }
        #endregion
        

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvSection, clsFormatter.colorDigiteqTheamColor1, Color.FromArgb(99, 50, 50));
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPrePlanID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblPlan, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtJobID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblJob, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDate, true);


            txtPrePlanID.Tag = null;
            txtJobID.Tag = null;

            ClearSectionOrder();
         
            ClearSection();
            dtpPrePlanDate.Enabled = true;

            txtJobID.Clear();           
            txtPrePlanID.Clear();
            txtRemarks.Clear();

            dtpPrePlanDate.Value = clsSecurity.getServerDateTime();
                      

            bHasApproved = false;
            bHasChecked = false;

            dgvSection.Rows.Clear();
        }                
        #endregion

        #region Clear Filelds Section Order
        private void ClearSectionOrder()
        {
            txtSectionOrder1.Clear();
            txtSectionOrder2.Clear();
            txtSectionOrder3.Clear();
            txtSectionOrder4.Clear();
            txtSectionOrder5.Clear();
            txtSectionOrder6.Clear();
            txtSectionOrder7.Clear();
            txtSectionOrder8.Clear();
            txtSectionOrder9.Clear();
        } 
        #endregion

        #region Clear Fields Section
        private void ClearSection()
        {
            IsUpdateSection = false;
        } 
        #endregion
        
        #region Refresh Grid
        private void RefreshGridSectionByPrePlanID(string sID)
        {
            try
            {
                int iRow;
                ClearSection();
                dgvSection.Rows.Clear();
                List<tbl_pmsPrePlan_SectionPath> details = tbl_pmsPrePlan_SectionPath.SelectAllByPrePlan_ID(sID);
                foreach (tbl_pmsPrePlan_SectionPath detail in details)
                {                    
                    dgvSection.Rows.Add();
                    iRow = dgvSection.Rows.Count - 1;
                    dgvSection["LineNo", iRow].Value = detail.Line_No;
                    if (detail.Section_ID != null)
                    {
                        dgvSection["SectionName", iRow].Tag = detail.Section_ID;
                        dgvSection["SectionName", iRow].Value = clsGenaralName.getName_Section(detail.Section_ID.ToString());
                    }
                    if (detail.PlanDate != null)
                        dgvSection["PlanDate", iRow].Value = detail.PlanDate.ToShortDateString();
                    if (detail.Section_ID != null)
                    {
                        dgvSection["WorkShift", iRow].Tag = detail.Shift_ID;
                        dgvSection["WorkShift", iRow].Value = clsGenaralName.getName_Shift(detail.Shift_ID.ToString());
                    }

                    if (detail.IsJobClosed)
                    {
                        dgvSection["Status", iRow].Value = "Section Closed";
                        dgvSection.Rows[iRow].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgvSection["Status", iRow].Value = "Section Open";
                        dgvSection.Rows[iRow].DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
                DisplaySectionOrder();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion


        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Trim().Length > 0)
                {
                    tbl_pmsPrePlan detail = tbl_pmsPrePlan.Select(sID);
                    if (detail != null)
                    {
                        //IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPrePlanID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtJobID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblPlan, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblJob, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDate, false);
                        dtpPrePlanDate.Enabled = false;
                        txtRemarks.Text = detail.Remark;
                        txtJobID.Tag = detail.ProductionJob_ID;
                        txtJobID.Text = detail.ProductionJob_ID;
                        dtpPrePlanDate.Value = detail.PrePlanDate;

                        RefreshGridSectionByPrePlanID(detail.PrePlan_ID);   
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion
                
        #region Check Validity
        private bool CheckValidity()
        {
            bool rtn = true;
            if (txtJobID.Tag == null)
            {
                rtn = false;
                MessageBox.Show("Please Select the Job Code..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJobID.Focus();
            }
            return rtn;
        }
        private bool CheckNumberValidity()
        {
            //string strMessage = "";
            bool bStatus = true;

            return bStatus;
        }
        #endregion       

        #region Check Section Selection Validity
        private bool CheckSectionIsSelect()
        {
            bool rtn = true;
            if (dgvSection.SelectedRows.Count > 0)
            {
                if (dgvSection.SelectedRows[0].Cells["SectionName"].Tag != null)
                {
                    rtn = true;
                }
                else
                {
                    rtn = false;
                }
            }
            else if (dgvSection.SelectedCells.Count > 0)
            {
                int rowIndex = dgvSection.SelectedCells[0].RowIndex;
                if (dgvSection.Rows[rowIndex].Cells["SectionName"].Tag != null)
                {
                    rtn = true;
                }
                else
                {
                    rtn = false;
                }

            }
            else
            {
                rtn = false;
            }

            if (!rtn)
            {
                MessageBox.Show("Please Select the Section..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return rtn;
        }
        #endregion                       

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtJobID);           
        }
        #endregion     
        
        #region Event DoubleClick
        private void txtPrePlanID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPrePlane(ref txtPrePlanID);
            if (txtPrePlanID.Text != null && txtPrePlanID.Text.Trim().Length > 0)
            {
                FillDetails(txtPrePlanID.Text);
            }
        }
        private void txtJobID_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_MasterProductionJobForPrePlan(ref txtJobID);
        }
        #endregion

        #region Event KeyDown
        private void txtPrePlanID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionPrePlane(ref txtPrePlanID);
                if (txtPrePlanID.Text != null && txtPrePlanID.Text.Trim().Length > 0)
                {
                    FillDetails(txtPrePlanID.Text);
                }
            }
        }
        private void txtJobID_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F1)
            //{
            //    clsSearch.Search_MasterProductionJobForPrePlan(ref txtJobID);
            //}
        }       
        private void frm_pmsPrePlanSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        
        #endregion


        #region Genarate Section Order
        private void GenarateSectionOrder()
        {
            int iRow = dgvSection.Rows.Count - 1;
            int lineNo = 1;
            if ((iRow - 1) >= 0)
            {
                lineNo = clsValidate.ValidateGridValue(dgvSection, "LineNo", iRow - 1, int.Parse("0"));
                lineNo += 1;
                dgvSection["LineNo", iRow].Value = (lineNo);
            }
            else
            {
                dgvSection["LineNo", iRow].Value = lineNo;
            }
            DisplaySectionOrder();
        }
        #endregion

        #region Display Section Order
        private void DisplaySectionOrder()
        {
            ClearSectionOrder();
            //string 
            string sSection = "";
            int iOrderID = 0;
            for (int i = 0; i < dgvSection.Rows.Count; i++)
            {
                sSection = clsValidate.ValidateGridValue(dgvSection, "SectionName", i, "");
                iOrderID = i + 1;// clsValidate.ValidateGridValue(dgvSection, "LineNo", i, int.Parse("0"));
                switch (iOrderID)
                {
                    case 1:
                        txtSectionOrder1.Text = sSection.Trim();
                        txtSectionOrder1.ForeColor = Color.Red;
                        break;
                    case 2:
                        txtSectionOrder2.Text = sSection.Trim();
                        txtSectionOrder2.ForeColor = Color.Red;
                        break;
                    case 3:
                        txtSectionOrder3.Text = sSection.Trim();
                        txtSectionOrder3.ForeColor = Color.Red;
                        break;
                    case 4:
                        txtSectionOrder4.Text = sSection.Trim();
                        txtSectionOrder4.ForeColor = Color.Red;
                        break;
                    case 5:
                        txtSectionOrder5.Text = sSection.Trim();
                        txtSectionOrder5.ForeColor = Color.Red;
                        break;
                    case 6:
                        txtSectionOrder6.Text = sSection.Trim();
                        txtSectionOrder6.ForeColor = Color.Red;
                        break;
                    case 7:
                        txtSectionOrder7.Text = sSection.Trim();
                        txtSectionOrder7.ForeColor = Color.Red;
                        break;
                    case 8:
                        txtSectionOrder8.Text = sSection.Trim();
                        txtSectionOrder8.ForeColor = Color.Red;
                        break;
                    case 9:
                        txtSectionOrder9.Text = sSection.Trim();
                        txtSectionOrder9.ForeColor = Color.Red;
                        break;
                }
            }
        }
        #endregion

        #region Get Selected Section
        private string GetSelectedSection()
        {
            string rtn = "default";
            try
            {
                if (dgvSection.SelectedRows.Count > 0)
                {
                    if (dgvSection.SelectedRows[0].Cells["SectionName"].Tag != null)
                    {
                        rtn = dgvSection.SelectedRows[0].Cells["SectionName"].Tag.ToString();
                    }
                }
            }
            catch (Exception)
            {
                return rtn;
            }
            return rtn;
        }
        #endregion

        #region Get Selected Section Order Number
        private int GetSelectedSectionOrderNo()
        {
            int rtn = -1;
            try
            {
                if (dgvSection.SelectedRows.Count > 0)
                {
                    if (dgvSection.SelectedRows[0].Cells["LineNo"].Value != null)
                    {
                        rtn = int.Parse(dgvSection.SelectedRows[0].Cells["LineNo"].Value.ToString());
                    }
                }
            }
            catch (Exception)
            {
                return rtn;
            }
            return rtn;
        }
        #endregion                

        #region Get Section Counter
        private int getSectionCounter(string sSection)
        {
            int rtn = 0;
            int iRow = -1;
            int gridOrderVal = -1;
            string gridSecVal = "";
            foreach (DataGridViewRow row in dgvSection.Rows)
            {
                gridOrderVal = clsValidate.ValidateGridValue(dgvSection, "LineNo", row.Index, int.Parse("-1"));
                gridSecVal = clsValidate.ValidateGridTag(dgvSection, "SectionName", row.Index, "");
                if (gridOrderVal == GetSelectedSectionOrderNo() && gridSecVal== sSection)
                {
                    iRow = row.Index;
                    break;
                }
            }
            for (int i = iRow; i >= 0; i--)
            {
                gridSecVal = clsValidate.ValidateGridTag(dgvSection, "SectionName", i, "");
                if (gridSecVal == sSection)
                    rtn++;
            }            
            return rtn;
        } 
        #endregion

        private void btnCloseSection_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))//Write Permission Validity
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        ValidateEmptyForeignKey();
                        tbl_pmsPrePlan oldRecord = tbl_pmsPrePlan.Select(txtPrePlanID.Text.Trim());
                        if (oldRecord != null)
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                int iSecLineNo = GetSelectedSectionOrderNo();
                                string sSectionID = GetSelectedSection();
                                tbl_pmsPrePlan_SectionPath secPathLock = tbl_pmsPrePlan_SectionPath.Select(iSecLineNo, txtPrePlanID.Text.Trim(), sSectionID);
                                if (secPathLock != null)
                                {
                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForSectionClose, clsGenaralName.getName_Section(secPathLock.Section_ID)), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        secPathLock.IsJobClosed = true;
                                        secPathLock.DateJobClosed = clsSecurity.getServerDateTime();
                                        secPathLock.Update();
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SectionCloseDone, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                    }
                                }
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        tbl_pmsPrePlan oldRecord = tbl_pmsPrePlan.Select(txtPrePlanID.Text.Trim());
                        if (oldRecord != null)
                            FillDetails(txtPrePlanID.Text.Trim());
                    }
                }
            }
        }



        


 

        

       



       

       



       



       

       




   
    }
}
