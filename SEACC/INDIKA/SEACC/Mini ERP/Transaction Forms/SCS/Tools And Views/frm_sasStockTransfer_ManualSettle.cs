using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_sasStockTransfer_ManualSettle : Form
    {

        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;


        #region Form Load
        public frm_sasStockTransfer_ManualSettle()
        {
            iFormID = clsSecurity.getFormID(FormName.StockTransferManualSettle);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasDeliveryOrderManuslSettle_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Stock Transfer Manual Settle", 2, iFormID);
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
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                if (bool.Parse(dgvDetail["Settle", row.Index].Value.ToString()))
                                {
                                    string sSR_ID = dgvDetail["DOCode", row.Index].Value.ToString();
                                    tbl_scsDepartmentReqositionNote srDepartment = tbl_scsDepartmentReqositionNote.Select(sSR_ID);
                                    tbl_scsSectionReqositionNote srSection = tbl_scsSectionReqositionNote.Select(sSR_ID);
                                    tbl_scsStoreReqositionNote srStore = tbl_scsStoreReqositionNote.Select(sSR_ID);

                                    if (srDepartment != null)
                                    {
                                        srDepartment.IsSeattled = true;
                                        srDepartment.Update();
                                    }
                                    if (srSection != null)
                                    {
                                        srSection.IsSeattled = true;
                                        srSection.Update();
                                    }
                                    if (srStore != null)
                                    {
                                        srStore.IsSeattled = true;
                                        srStore.Update();
                                    }
                                }
                            }
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            //RefreshGrid();
                        }
                    }
                }
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtJobNo.Tag = null;
            txtSectionRequisitionNoteID.Tag = null;
            txtDepartmentRequisitionNoteID.Tag = null;
            txtStoreRequisitionNoteID.Tag = null;

            txtJobNo.Clear();
            txtSectionRequisitionNoteID.Clear();
            txtDepartmentRequisitionNoteID.Clear();
            txtStoreRequisitionNoteID.Clear();

            dgvDetail.Rows.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridBySectionSR(string sSRID)
        {
            int iRow;
            dgvDetail.Rows.Clear();
            tbl_scsSectionReqositionNote detail = tbl_scsSectionReqositionNote.Select(sSRID);
            if (detail != null)
            {
                if (detail.SectionReqositionNote_ID.Trim() != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["DOCode", iRow].Value = detail.SectionReqositionNote_ID;
                    dgvDetail["DODate", iRow].Value = clsFormatter.FormatDate_Short(detail.SectionReqositionNoteDate);
                    dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(detail.Job_ID);
                    dgvDetail["IssuedBy", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Section(detail.FromSection_ID));
                }
            }
        }
        private void RefreshGridByStoreSR(string sSRID)
        {
            int iRow;
            dgvDetail.Rows.Clear();
            tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sSRID);
            if (detail != null)
            {
                if (detail.StoreRecositionNote_ID.Trim() != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["DOCode", iRow].Value = detail.StoreRecositionNote_ID;
                    dgvDetail["DODate", iRow].Value = clsFormatter.FormatDate_Short(detail.StoreRecositionNoteDate);
                    dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(detail.Job_ID);
                    dgvDetail["IssuedBy", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.FromStore_ID));
                }
            }
        }
        private void RefreshGridByDepartmentSR(string sSRID)
        {
            int iRow;
            dgvDetail.Rows.Clear();
            tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(sSRID);
            if (detail != null)
            {
                if (detail.DepartmentReqositionNote_ID.Trim() != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["DOCode", iRow].Value = detail.DepartmentReqositionNote_ID;
                    dgvDetail["DODate", iRow].Value = clsFormatter.FormatDate_Short(detail.DepartmentReqositionNoteDate);
                    dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(detail.Job_ID);
                    dgvDetail["IssuedBy", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Department(detail.FromDepartment_ID));
                }
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
           // string strMessage = "";
            bool bStatus = false;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (bool.Parse(dgvDetail["Settle", row.Index].Value.ToString()))
                    bStatus = true;
            }

            if (bStatus == false)
            {
                MessageBox.Show("User Needs To Select Atleast One Delivery Order No To Settle", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        private void txtJobNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
               
                
            }   
        }

        private void frm_sasDeliveryOrderManuslSettle_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtJobNo_DoubleClick(object sender, EventArgs e)
        {
            Search_JobCode();

            
        }       
        #endregion

        #region Search Methods       
        private void Search_SectionGoodReceiveNote()
        {
            clsSearch.Search_TransactionSectionStoreReqositionNote(ref txtSectionRequisitionNoteID, false);
            if (txtSectionRequisitionNoteID.Text.Trim().Length > 0)
                RefreshGridBySectionSR(txtSectionRequisitionNoteID.Text.Trim());
        }
        private void Search_StoreGoodReceiveNote()
        {
            clsSearch.Search_TransactionStoreReqositionNote(ref txtStoreRequisitionNoteID, false, false, "");
            if (txtStoreRequisitionNoteID.Text.Trim().Length > 0)
                RefreshGridByStoreSR(txtStoreRequisitionNoteID.Text.Trim());
        }
        private void Search_JobCode()
        {
            ClearFields();
            clsSearch.Search_TransactionProductionJobRegister(ref txtJobNo);
            if (txtJobNo.Tag != null && txtJobNo.Tag.ToString().Trim().Length > 0)
            {
                dgvDetail.Rows.Clear();

                //Section SR
                List<tbl_scsSectionReqositionNote> details = tbl_scsSectionReqositionNote.SelectAllByJob_ID(txtJobNo.Tag.ToString());
                foreach (tbl_scsSectionReqositionNote detail in details)
                {
                    RefreshGridBySectionSR(detail.SectionReqositionNote_ID);
                }

                //Store SR
                List<tbl_scsStoreReqositionNote> storeDetails = tbl_scsStoreReqositionNote.SelectAllByJob_ID(txtJobNo.Tag.ToString());
                foreach (tbl_scsStoreReqositionNote storeDetail in storeDetails)
                {
                    RefreshGridByStoreSR(storeDetail.StoreRecositionNote_ID);
                }

                //Department SR
                //List<tbl_scsDepartmentReqositionNote> departmentDetails = tbl_scsDepartmentReqositionNote.SelectAllByJob_ID(txtJobNo.Tag.ToString());
                //foreach (tbl_scsDepartmentReqositionNote departmentDetail in departmentDetails)
                //{
                //    RefreshGridByStoreSR(departmentDetail.DepartmentReqositionNoteDate);
                //}
            }
        }
        #endregion

        private void txtSectionRequisitionNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_SectionGoodReceiveNote();
        }

        private void txtSectionRequisitionNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_SectionGoodReceiveNote();
        }

        private void txtStoreRequisitionNoteID_DoubleClick(object sender, EventArgs e)
        {
            Search_StoreGoodReceiveNote();
        }

        private void txtStoreRequisitionNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_StoreGoodReceiveNote();
        }
    }
}
