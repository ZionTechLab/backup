using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_sasCustomerOrderManuallySettleTool : MettroForm
    {
        #region Global Variable
        public int iFormID;
        public bool bNoAccess;

        DataTable dt = new DataTable(); 
        #endregion

        #region Form Load
        public frm_sasCustomerOrderManuallySettleTool()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.sasCustomerOrderManuallySettleTool);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            #region Initialize Grid
            dt.Columns.Add("LineNo");
            dt.Columns.Add("CONo");
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("Date");
            dt.Columns.Add("PreparedBy");
            dt.Columns.Add("ModifiedBy");
            dt.Columns.Add("CheckedBy");
            dt.Columns.Add("ApprovedBy");
            dt.Columns.Add("Settled");
            #endregion

        }

        private void frm_sasCustomerOrderManuallySettleTool_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Customer Order Manually Settle Tool ", 2, iFormID);
            //lblFormName.Text = clsFormatter.DigiteqTitle + " - F" + iFormID.ToString("0000") + " - " + "Customer Order Manually Settle Tool" ;
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvDetail, clsFormatter.colorGrid, clsFormatter.colorSales);
            ThemeColor = clsFormatter.colorSales;

            ClearField();
            Refreshgrid();
        }
        #endregion

        #region Button Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refreshgrid();
        }
        #endregion

        #region Button Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        } 
        #endregion

        #region Clear Field
        private void ClearField()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomer, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesman, true);

            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;

        } 
        #endregion

        #region Refresh Grid
        private void Refreshgrid()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int iRow = 1;
                dt.Clear();

                List<tbl_sasCustomerOrder> details = null;
                if (txtCustomer.Tag != null && txtCustomer.Tag != "default" && txtCustomer.Text.Length > 0)
                    details = tbl_sasCustomerOrder.SelectAll().Where(p => p.IsSeattled != true && !p.IsDeleted && p.Customer_ID == txtCustomer.Tag.ToString() && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).OrderByDescending(p => p.CustomerOrder_ID).ToList();
                else if (txtSalesman.Tag != null && txtSalesman.Tag != "default" && txtSalesman.Text.Length > 0)
                    details = tbl_sasCustomerOrder.SelectAll().Where(p => p.IsSeattled != true && !p.IsDeleted && p.Employee_ID == txtSalesman.Tag.ToString() && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).OrderByDescending(p => p.CustomerOrder_ID).ToList();
                else
                    details = tbl_sasCustomerOrder.SelectAll().Where(p => p.IsSeattled != true && !p.IsDeleted && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date && p.CompanyBranch_ID == clsSecurity.BranchID).OrderByDescending(p => p.CustomerOrder_ID).ToList();
                
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    dt.Rows.Add(iRow, detail.CustomerOrder_ID, clsGenaralName.getName_Customer(detail.Customer_ID), clsFormatter.FormatDate_Short(detail.CustomerOrderDate),
                        detail.CreateUser_ID == "default" ? "-" : clsGenaralName.getName_User(detail.CreateUser_ID) + "-" + clsFormatter.FormatDate_Short_WithTime(detail.DateCreate),
                        detail.ModifiedUser_ID == "default" ? "-" : clsGenaralName.getName_User(detail.ModifiedUser_ID) + "-" + clsFormatter.FormatDate_Short_WithTime(detail.DateModified),
                        detail.IsChecked == false ? "-" : clsGenaralName.getName_User(detail.CheckedUser_ID) + "-" + clsFormatter.FormatDate_Short_WithTime(detail.DateChecked),
                        detail.IsApproved == false ? "-" : clsGenaralName.getName_User(detail.ApprovedUser_ID) + "-" + clsFormatter.FormatDate_Short_WithTime(detail.DateApproved), 
                        detail.IsSeattled);
                    iRow++;
                }
                dgvDetail.DataSource = dt.DefaultView;
                dgvDetail.Refresh();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region Button Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Button Minimized
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        } 
        #endregion

        #region Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    #region Update
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        string sPreparedBy = "", sApprovedBy = "", sQuotationCode = "", sCONo = "";
                        bool bIsSettled = false;

                        sCONo = clsValidate.ValidateGridValue(dgvDetail, "CONo", row.Index, "");
                        sPreparedBy = clsValidate.ValidateGridValue(dgvDetail, "PreparedBy", row.Index, "");
                        sApprovedBy = clsValidate.ValidateGridValue(dgvDetail, "ApprovedBy", row.Index, "");
                        bIsSettled = clsValidate.ValidateGridValue(dgvDetail, "Settled", row.Index, "") == "True" ? true : false;

                        tbl_sasCustomerOrder oldRecord = tbl_sasCustomerOrder.Select(sCONo);
                        if (oldRecord != null && bIsSettled != false)
                        {
                            if (sPreparedBy.Length > 0)
                            {
                                //audit trail log
                                clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder), oldRecord.CustomerOrder_ID, "Customer Order");

                                oldRecord.IsSeattled = bIsSettled;

                                oldRecord.Update();

                            }
                        }

                    }

                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endregion

                }
                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                    clsValidate.WriteErrorLog("", iFormID,ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    Refreshgrid();
                }
            }
        } 
        #endregion

        #region Event Double Click
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CustomerMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtCustomer.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtCustomer.Tag = frmSearchMaster.s_SearchID;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void txtSalesman_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesman);

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        } 
        #endregion

        #region Event Key Down
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtCustomer_DoubleClick(sender, e);
        }

        private void txtSalesman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSalesman_DoubleClick(sender, e);
        } 
        #endregion

        #region Validation
        private bool ValidateSave()
        {
            bool bStatus = true;

            if (dgvDetail.Rows.Count <= 0)
            {
                bStatus = false;
                MessageBox.Show("Please Fill Grid", "Fill Grid", MessageBoxButtons.OK);
            }

            return bStatus;
        } 
        #endregion

        #region Grid Mouse Double Click
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {        
            if (e.RowIndex >= 0)
            {
                Cursor = Cursors.WaitCursor;

                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                if (sColName != "LineNo" && sColName != "Date" && sColName != "PreparedBy" && sColName != "ModifiedBy" && sColName != "CheckedBy" && sColName != "ApprovedBy" && sColName != "Settled")
                {
                    string sCOID = clsValidate.ValidateGridValue(dgvDetail, "CONo", e.RowIndex, "");
                    if (sCOID != "")
                    {
                        frm_sasCustomerOrder frm = new frm_sasCustomerOrder(FormName.CustomerOrder);
                        frm.glbCustomerOrderID = sCOID;
                        if (frm.bNoAccess)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                    }
                }
                Cursor = Cursors.Default;
            }
        } 
        #endregion

    }
}
