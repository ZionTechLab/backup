using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_bpsChequeTracer : MettroForm
    {
        #region Variables
        //from Receipt
        public bool bIsFromReceipt = false;
        public string rcpCustomerID = "default";
        public string rcpInvoiceID = "default";
        public string rcpReceiptID = "default";
        public DateTime rcpDate = clsSecurity.getServerDateTime();
        public decimal rcpCashAmount = 0;

        private BindingSource bsInward = new BindingSource();
        private BindingSource nsOutward = new BindingSource();
        private BindingSource bsCashInward = new BindingSource();
        private string sFilterQuary_Inword = "";
        private string sFinalQuary_Inward_Cash = "";

        public DataTable dtAllRecodes = new DataTable();

        string sFormConfigCode;

        public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
    //    DateTime glbApprovedDate = clsSecurity.getServerDateTime();
    //    DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        #endregion

        #region Form Load
        public frm_bpsChequeTracer()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ChequeTracer);
            iFormID = clsSecurity.getFormID(FormName.ChequeTracer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
        private void frm_bpsChequeRegister_Load(object sender, EventArgs e)
        {
            this.Text = clsFormatter.DigiteqTitle + " - Cheque / Cash Tracer ";

            dgvInwardCash.AutoGenerateColumns = false;
            dgvInward.AutoGenerateColumns = false;
            dgvOutward.AutoGenerateColumns = false;

            ThemeColor = clsFormatter.colorBills;
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvInward, clsFormatter.colorGrid, clsFormatter.colorBills);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvOutward, clsFormatter.colorGrid, clsFormatter.colorBills);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvInwardCash, clsFormatter.colorGrid, clsFormatter.colorBills);

            dgvInward.DataSource = bsInward;
            dgvOutward.DataSource = nsOutward;
            dgvInwardCash.DataSource = bsCashInward;

            ClearFields_Inward();
            ClearFields_Outward();
            ClearFields_Inward_Cash();

            SetFormForInward_Cash();

        }
        #endregion

        #region Events VisibleChanged
        private void frm_bpsChequeRegister_VisibleChanged(object sender, EventArgs e)
        {
            changeGridColor_Inward();
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields_Inward();
            bsInward.Filter = "";
            sFilterQuary_Inword = "";
        }
        private void btnClearOut_Click(object sender, EventArgs e)
        {
            ClearFields_Outward();
            nsOutward.Filter = "";
        }
        private void btnCashClear_Click(object sender, EventArgs e)
        {
            ClearFields_Inward_Cash();
            bsCashInward.Filter = "";
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvInward, clsFormatter.colorGrid, clsFormatter.colorBills);
        }
        private void CusDataGridViewFormatOutward()
        {
            clsFormatter.ApplyGridFormat_New(dgvOutward, clsFormatter.colorGrid, clsFormatter.colorBills);
        }
        private void CusDataGridViewFormatInward_Cash()
        {
            clsFormatter.ApplyGridFormat_New(dgvInwardCash, clsFormatter.colorGrid, clsFormatter.colorBills);
        }
        #endregion

        #region Clear Fields
        private void ClearFields_Inward()
        {
            txtReceiptID.Clear();
            txtCustomerID.Clear();
            txtInvoiceID.Clear();
            txtRegisterID.Clear();
            txtAccountID.Clear();
            txtChequeNo.Clear();
            txtAmount.Text = "0.00";

            txtColourNew.ForeColor = clsFormatter.colorChequeNew;
            txtColourDeposit.ForeColor = clsFormatter.colorChequeDeposited;
            txtColourReleasedToSup.ForeColor = clsFormatter.colorChequeReleasedToSup;
            txtColourRealized.ForeColor = clsFormatter.colorChequeRealized;
            txtColourReturned_R.ForeColor = clsFormatter.colorChequeReturned_R;
            txtColourReturned_NR_C.ForeColor = clsFormatter.colorChequeReturned_NR_C;
            txtColourReturned_NR_O.ForeColor = clsFormatter.colorChequeReturned_NR_O;
            txtReDeposit.ForeColor = clsFormatter.colorChequeReDeposit;
            txtDeleted.ForeColor = clsFormatter.colorChequeDeleted;

            chkAccountNo.Checked = false;
            chkAmount.Checked = false;
            chkChequeNo.Checked = false;
            chkCustomerName.Checked = false;
            chkInvoiceNo.Checked = false;
            chkRecieptNo.Checked = false;
            chkRegisterCode.Checked = false;

            chkSetColorInwChq.Checked = false;
            chkSetColorInwChq.Enabled = true;

            changeGridColor_Inward();
        }

        private void ClearFields_Outward()
        {
            txtSupplierID.Clear();
            txtAccNoOut.Clear();
            txtPV.Clear();
            txtChequeNoOut.Clear();
            txtRegCodeOut.Clear();
            txtAmountOut.Text = "0.00";

            chkSetColorOutwChq.Checked = false;
            chkSetColorOutwChq.Enabled = true;

            txtColourNewOut.ForeColor = clsFormatter.colorChequeNew;
            txtColourRealizedOut.ForeColor = clsFormatter.colorChequeRealized;
            txtColourReturned_ROut.ForeColor = clsFormatter.colorChequeReturned_R;
            txtColourReturned_NR_COut.ForeColor = clsFormatter.colorChequeReturned_NR_C;
            txtColourReturned_NR_OOut.ForeColor = clsFormatter.colorChequeReturned_NR_O;
            txtDeletedOut.ForeColor = clsFormatter.colorChequeDeleted;

            changeGridColorOutward();
        }

        private void ClearFields_Inward_Cash()
        {
            txtCashReceipt.Clear();
            txtCashCustomer.Clear();
            txtCashAccount.Clear();
            txtCashAmount.Clear();
            txtCashAmount.Text = "0.00";

            cmbStatus.SelectedIndex = -1;

            chkSetColor.Enabled = true;
            chkSetColor.Checked = false;

            dtpCashFrom.Value = clsMethods_GL.getFinancialYear_StartDate(clsMethods_GL.getFinancialYear_ID_Current());
            dtpCashTo.Value = DateTime.Now;

            txtCashNew.ForeColor = clsFormatter.colorChequeNew;
            txtCashDeposit.ForeColor = clsFormatter.colorChequeDeposited;

            changeGridColorInward_Cash();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_Inward()
        {
            try
            {
                //display grid detail more and more when click the tab controlls again and again - changed by janith
                //dtAllRecodes.Merge(DBHandling.ExecQuery("Exec sp_ChequeTracer_SelectAll").Tables[0]);
                //bsInward.DataSource = dtAllRecodes;
                //changeGridColor_Inward();

                bsInward.DataSource = DBHandling.ExecQuery("Exec sp_ChequeTracer_SelectAll").Tables[0];
                changeGridColor_Inward();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridOutward()
        {
            try
            {
                nsOutward.DataSource = DBHandling.ExecQuery("Exec sp_ChequeTracerOutward_SelectAll").Tables[0];
                changeGridColorOutward();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridInward_Cash()
        {
            try
            {
                bsCashInward.DataSource = DBHandling.ExecQuery("Exec sp_CashTracerInward_SelectAll '" + dtpCashFrom.Value.ToString("yyyy-MM-dd") + "', '" + dtpCashTo.Value.ToString("yyyy-MM-dd") + "'").Tables[0];
                changeGridColorInward_Cash();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            //dtAllRecodes.Columns.Add("RegisterCode", typeof(string));
            dtAllRecodes.Columns.Add("ChequeNo", typeof(string));
            dtAllRecodes.Columns.Add("ChequeDate", typeof(string));
            dtAllRecodes.Columns.Add("Amount", typeof(string));
            dtAllRecodes.Columns.Add("GridChequeStatus", typeof(string));
            dtAllRecodes.Columns.Add("CustomerName", typeof(string));
            dtAllRecodes.Columns.Add("AccountNo", typeof(string));
            dtAllRecodes.Columns.Add("ReceiptID", typeof(string));
            dtAllRecodes.Columns.Add("CustomerID", typeof(string));
            //deposited AccNo. 2017-01-06
            dtAllRecodes.Columns.Add("DepositedAccountNumber", typeof(string));
            dtAllRecodes.Columns.Add("RegisterCode", typeof(string));

        }
        #endregion

        #region Events Keydown
        private void txtRegisterID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ChequeRegister();
        }

        private void txtAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Account(txtAccountID);
        }

        private void frm_bpsChequeRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        #endregion

        #region Events DoubleClick
        private void txtRegisterID_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeRegister();
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID(txtCustomerID);
        }

        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_Invoice();
        }

        private void txtReceiptID_DoubleClick(object sender, EventArgs e)
        {
            Search_Receipt();
        }

        private void txtAccountID_DoubleClick(object sender, EventArgs e)
        {
            Search_Account(txtAccountID);
        }

        private void txtCashCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID(txtCashCustomer);
        }

        private void txtCashAccount_DoubleClick(object sender, EventArgs e)
        {
            Search_Account(txtCashAccount);
        }

        private void txtRegCodeOut_DoubleClick(object sender, EventArgs e)
        {
            Search_ChequeRegisterOutward();
            createFilterQuary_Outward();
        }
        #endregion

        #region Event Keyup
        #region Events KeyUp Inward
        private void txtRegisterID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward(txtRegisterID);
        }

        private void txtCustomerID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward(txtCustomerID);
        }

        private void txtChequeNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward(txtChequeNo);

        }
        private void txtAccountID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward(txtAccountID);

        }
        private void txtInvoiceID_KeyUp(object sender, KeyEventArgs e)
        {
            //createFilterQuary(txtInvoiceID);
        }

        private void txtReceiptID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward(txtReceiptID);
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward(txtAmount);
        }
        #endregion

        #region Events KeyUp Outward
        private void txtSupplierID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Outward();
        }

        private void txtAccNoOut_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Outward();
        }

        private void txtRegCodeOut_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Outward();
        }

        private void txtPV_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Outward();
        }

        private void txtChequeNoOut_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Outward();
        }

        private void txtAPN_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Outward();
        }

        private void txtAmountOut_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Outward();
        }
        #endregion

        #region Events Keyup Inward - Cash
        private void txtCashCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward_Cash(txtCashCustomer, "CustomerName");
        }

        private void txtCashReceipt_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward_Cash(txtCashReceipt, "ReceiptID");
        }

        private void txtCashAccount_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward_Cash(txtCashAccount, "DepAccountNo");
        }

        private void txtCashAmount_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary_Inward_Cash(txtCashAmount, "Amount");
        }
        #endregion
        #endregion

        #region Event Checkbox ChechChange
        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomerName.Checked)
                txtCustomerID.Enabled = false;
            else
            {
                txtCustomerID.Enabled = true;
                txtCustomerID.Text = "";
                sFilterQuary_Inword = "";
                createFilterQuary_Inward(txtCustomerID);
            }
        }

        private void chkAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAccountNo.Checked)
                txtAccountID.Enabled = false;
            else
            {
                txtAccountID.Enabled = true;
                txtAccountID.Text = "";
                sFilterQuary_Inword = "";
                createFilterQuary_Inward(txtAccountID);
            }
        }

        private void chkRegisterCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegisterCode.Checked)
                txtRegisterID.Enabled = false;
            else
            {
                txtRegisterID.Enabled = true;
                txtRegisterID.Text = "";
                sFilterQuary_Inword = "";
                createFilterQuary_Inward(txtRegisterID);
            }
        }

        private void chkChequeNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChequeNo.Checked)
                txtChequeNo.Enabled = false;
            else
            {
                txtChequeNo.Enabled = true;
                txtChequeNo.Text = "";
                sFilterQuary_Inword = "";
                createFilterQuary_Inward(txtChequeNo);
            }
        }

        private void chkAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAmount.Checked)
                txtAmount.Enabled = false;
            else
            {
                txtAmount.Enabled = true;
                txtAmount.Text = "";
                sFilterQuary_Inword = "";
                createFilterQuary_Inward(txtAmount);
            }
        }

        private void chkRecieptNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecieptNo.Checked)
                txtReceiptID.Enabled = false;
            else
            {
                txtReceiptID.Enabled = true;
                txtReceiptID.Text = "";
                sFilterQuary_Inword = "";
                createFilterQuary_Inward(txtReceiptID);
            }
        }

        private void chkInvoiceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvoiceNo.Checked)
                txtInvoiceID.Enabled = false;
            else
            {
                txtInvoiceID.Enabled = true;
                txtInvoiceID.Text = "";
                sFilterQuary_Inword = "";
                createFilterQuary_Inward(txtInvoiceID);
            }
        }

        private void chkSetColor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetColor.Checked)
            {
                changeGridColorInward_Cash();
                chkSetColor.Enabled = false;
            }
            else
            {
                chkSetColor.Checked = false;
                chkSetColor.Enabled = true;
            }
        }
        private void chkSetColorInwChq_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetColorInwChq.Checked)
            {
                changeGridColor_Inward();
                chkSetColorInwChq.Enabled = false;
            }
            else
            {
                chkSetColorInwChq.Checked = false;
                chkSetColorInwChq.Enabled = true;
            }
        }

        private void chkSetColorOutwChq_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetColorOutwChq.Checked)
            {
                changeGridColorOutward();
                chkSetColorOutwChq.Enabled = false;
            }
            else
            {
                chkSetColorOutwChq.Checked = false;
                chkSetColorOutwChq.Enabled = true;
            }
        }
        #endregion

        #region Events Datagrid
        #region Inward Grid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDetail_CellDoubleClick(sender, e);
            try
            {
                if (e.RowIndex >= 0)
                {
                    Cursor = Cursors.WaitCursor;
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvInward.Columns[e.ColumnIndex].Name;
                    if (sColName == "CustomerName")
                    {
                        string sCustomerID = clsValidate.ValidateGridValue(dgvInward, "CustomerID", e.RowIndex, "");
                        if (sCustomerID.Length > 0)
                        {
                            frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                            frm.glbCustomerID = sCustomerID;
                            if (frm.bNoAccess)
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                frm.MdiParent = this.MdiParent;
                                frm.Show();
                            }
                        }
                    }
                    else if (sColName == "Amount" || sColName == "GridChequeStatus")
                    {
                        string sReceiptID = clsValidate.ValidateGridValue(dgvInward, "ReceiptID", e.RowIndex, "");
                        if (sReceiptID.Length > 0)
                        {
                            frm_bpsReceiptAgeingViewer frm = new frm_bpsReceiptAgeingViewer();
                            frm.glbReceiptID = sReceiptID;
                            if (frm.bNoAccess)
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                frm.MdiParent = this.MdiParent;
                                frm.Show();
                            }
                        }
                    }
                    else if (sColName == "ReceiptID" || sColName == "AccountNo")
                    {
                        string sReceiptID = clsValidate.ValidateGridValue(dgvInward, "ReceiptID", e.RowIndex, "");
                        if (sReceiptID.Length > 0)
                        {
                            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
                            if (detail != null)
                            {
                                if (detail.IsSalesReceipt)
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.UCReceipt);
                                    frm.glbReceiptID = sReceiptID;
                                    if (frm.bNoAccess)
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                                        //frm.MdiParent = this.MdiParent;
                                        //frm.Show();
                                    }
                                }
                                else
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.InterimReceipt);
                                    frm.glbReceiptID = sReceiptID;
                                    if (frm.bNoAccess)
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                                        //frm.MdiParent = this.MdiParent;
                                        //frm.Show();
                                    }

                                    //frm_bpsReceipt_Interim frm = new frm_bpsReceipt_Interim();
                                    //frm.gReceiptID = sReceiptID;
                                    //if (frm.bNoAccess)
                                    //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //else
                                    //{
                                    //    frm.MdiParent = this.MdiParent;
                                    //    frm.Show();
                                    //}
                                }
                            }
                        }
                    }
                    Cursor = Cursors.Default;
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
            }
        }
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // dgvDetail_CellClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        Cursor = Cursors.WaitCursor;
            //        string sColName = "";
            //        if (e.ColumnIndex >= 0)
            //            sColName = dgvInward.Columns[e.ColumnIndex].Name;
            //        if (sColName == "CustomerName")
            //        {
            //            string sCustomerID = clsValidate.ValidateGridValue(dgvInward, "CustomerID", e.RowIndex, "");
            //            if (sCustomerID.Length > 0)
            //            {
            //                frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
            //                frm.glbCustomerID = sCustomerID;
            //                if (frm.bNoAccess)
            //                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                else
            //                {
            //                    frm.MdiParent = this.MdiParent;
            //                    frm.Show();
            //                }
            //            }
            //        }
            //        else if (sColName == "Amount" || sColName == "GridChequeStatus")
            //        {
            //            string sReceiptID = clsValidate.ValidateGridValue(dgvInward, "ReceiptID", e.RowIndex, "");
            //            if (sReceiptID.Length > 0)
            //            {
            //                frm_bpsReceiptAgeingViewer frm = new frm_bpsReceiptAgeingViewer();
            //                frm.glbReceiptID = sReceiptID;
            //                if (frm.bNoAccess)
            //                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                else
            //                {
            //                    frm.MdiParent = this.MdiParent;
            //                    frm.Show();
            //                }
            //            }
            //        }
            //        else if (sColName == "ReceiptID" || sColName == "AccountNo")
            //        {
            //            string sReceiptID = clsValidate.ValidateGridValue(dgvInward, "ReceiptID", e.RowIndex, "");
            //            if (sReceiptID.Length > 0)
            //            {
            //                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
            //                if (detail != null)
            //                {
            //                    if (detail.IsSalesReceipt)
            //                    {
            //                        frm_bpsReceipt_Sales frm = new frm_bpsReceipt_Sales();
            //                        frm.gReceiptID = sReceiptID;
            //                        if (frm.bNoAccess)
            //                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        else
            //                        {
            //                            frm.MdiParent = this.MdiParent;
            //                            frm.Show();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        frm_bpsReceipt_Account frm = new frm_bpsReceipt_Account();
            //                        frm.gReceiptID = sReceiptID;
            //                        if (frm.bNoAccess)
            //                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        else
            //                        {
            //                            frm.MdiParent = this.MdiParent;
            //                            frm.Show();
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        Cursor = Cursors.Default;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    SEACCException.Show(ex);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;

                if (sColName != "ChequeNo" && sColName != "ChequeDate" && sColName != "RegisterCode" && sColName != "GridChequeStatus")
                {
                    Cursor = Cursors.Hand;
                }
            }
        }
        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;

                if (sColName != "ChequeNo" && sColName != "ChequeDate" && sColName != "RegisterCode" && sColName != "GridChequeStatus")
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Outward Grid
        private void dgvOutward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvOutward_CellClick(sender, e);
        }
        private void dgvOutward_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        Cursor = Cursors.WaitCursor;
            //        string sColName = "";
            //        if (e.ColumnIndex >= 0)
            //            sColName = dgvOutward.Columns[e.ColumnIndex].Name;
            //        if (sColName == "PVOut")
            //        {
            //            string sPVID = clsValidate.ValidateGridValue(dgvOutward, "PVOut", e.RowIndex, "");
            //            if (sPVID.Length > 0)
            //            {
            //                tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(sPVID);
            //                if (detail != null)
            //                {
            //                    frm_accPaymentVoucher frm = new frm_accPaymentVoucher();
            //                    frm.glbPamentVoucher = sPVID;
            //                    if (frm.bNoAccess)
            //                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    else
            //                    {
            //                        frm.MdiParent = this.MdiParent;
            //                        frm.Show();
            //                    }                               
            //                }
            //            }
            //        }
            //        Cursor = Cursors.Default;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID,ex);
            //    SEACCException.Show(ex);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }
        private void dgvOutward_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvOutward_CellDoubleClick(sender, e);

            try
            {
                if (e.RowIndex >= 0)
                {
                    Cursor = Cursors.WaitCursor;
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvOutward.Columns[e.ColumnIndex].Name;
                    if (sColName == "PVOut")
                    {
                        string sPVID = clsValidate.ValidateGridValue(dgvOutward, "PVOut", e.RowIndex, "");
                        if (sPVID.Length > 0)
                        {
                            tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(sPVID);
                            if (detail != null)
                            {
                                frm_accPaymentVoucher frm = new frm_accPaymentVoucher(FormName.accPaymentVoucher);
                                frm.glbPamentVoucher = sPVID;
                                if (frm.bNoAccess)
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, this.MdiParent);
                                }
                            }
                        }
                    }
                    Cursor = Cursors.Default;
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
            }


        }
        #endregion

        #region Inward Cash Grid
        private void dgvInwardCash_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDetail_CellDoubleClick(sender, e);
            try
            {
                if (e.RowIndex >= 0)
                {
                    Cursor = Cursors.WaitCursor;
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvInwardCash.Columns[e.ColumnIndex].Name;

                    if (sColName == "CashCustomerName")
                    {
                        string sCustomerID = clsValidate.ValidateGridValue(dgvInwardCash, "CashCustomerID", e.RowIndex, "");
                        if (sCustomerID.Length > 0)
                        {
                            frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                            frm.glbCustomerID = sCustomerID;
                            if (frm.bNoAccess)
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                frm.MdiParent = this.MdiParent;
                                frm.Show();
                            }
                        }
                    }
                    else if (sColName == "CashReceiptID")
                    {
                        string sReceiptID = clsValidate.ValidateGridValue(dgvInwardCash, "CashReceiptID", e.RowIndex, "");
                        if (sReceiptID.Length > 0)
                        {
                            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
                            if (detail != null)
                            {
                                if (detail.IsSalesReceipt)
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.UCReceipt);
                                    frm.glbReceiptID = sReceiptID;
                                    if (frm.bNoAccess)
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                                        //frm.MdiParent = this.MdiParent;
                                        //frm.Show();
                                    }
                                }
                                else
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.InterimReceipt);
                                    frm.glbReceiptID = sReceiptID;
                                    if (frm.bNoAccess)
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                    {
                                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
                                        //frm.MdiParent = this.MdiParent;
                                        //frm.Show();
                                    }

                                    //frm_bpsReceipt_Interim frm = new frm_bpsReceipt_Interim();
                                    //frm.gReceiptID = sReceiptID;
                                    //if (frm.bNoAccess)
                                    //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //else
                                    //{
                                    //    frm.MdiParent = this.MdiParent;
                                    //    frm.Show();
                                    //}
                                }
                            }
                        }
                    }
                    Cursor = Cursors.Default;
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
            }
        }
        #endregion
        #endregion

        #region Events Date Value Changed
        private void dtpCashFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshGridInward_Cash();
        }

        private void dtpCashTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshGridInward_Cash();
        }
        #endregion

        #region Search Methods
        private void Search_ChequeRegister()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_ChequeRegister();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                    txtRegisterID.Text = frmSearchTransaction.s_SearchID;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }
        private void Search_ChequeRegisterOutward()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_ChequeRegisterOutward();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                    txtRegCodeOut.Text = frmSearchTransaction.s_SearchID;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }
        private void Search_Invoice()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {
                    clsSearch.passValue_InvoiceByCustomerID(txtCustomerID.Tag.ToString());
                    frmhelpsearch.ShowDialog();

                    if (frmSearchTransaction.s_SearchText.Length > 0)
                    {
                        if (frmSearchTransaction.s_SearchText.Length > 0)
                            txtInvoiceID.Text = frmSearchTransaction.s_SearchID;
                        if (frmSearchTransaction.s_SearchID.Length > 0)
                            txtInvoiceID.Tag = frmSearchTransaction.s_SearchID;
                    }
                }
                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Receipt()
        {
            try
            {
                //Form frmhelpsearch = new frmSearchTransaction();
                //if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                //{
                //    clsSearch.Search_TransactionReceiptByCustomerID_Use(ref txtReceiptID, txtCustomerID.Tag.ToString(), false, "", true);
                //}
                //else
                //    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Account(TextBox txt)
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.passValue_CustomerAccountByCustomerID(txtCustomerID.Tag.ToString());
                else
                    clsSearch.passValue_CustomerAccount();

                frmhelpsearch.ShowDialog();
                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    if (frmSearchTransaction.s_SearchText.Length > 0)
                        txt.Text = frmSearchTransaction.s_SearchID;
                    if (frmSearchTransaction.s_SearchID.Length > 0)
                        txt.Tag = frmSearchTransaction.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID(TextBox txt)
        {
            try
            {
                //Form frmhelpsearch = new frmSearchMaster();
                //clsSearch.passValue_CustomerMaster();
                //frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchID.Length > 0)
                //{
                //    if (frmSearchMaster.s_SearchText.Length > 0)
                //        txt.Text = frmSearchMaster.s_SearchText;
                //    if (frmSearchMaster.s_SearchID.Length > 0)
                //        txt.Tag = frmSearchMaster.s_SearchID;

                clsSearch.Search_MasterCustomer(ref txt, false);
                createFilterQuary_Inward(txtCustomerID);
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Get Colour For Cheque Types
        private Color GetColorForCheque(string sRegisterID)
        {
            Color col = Color.FromArgb(99, 50, 50);
            tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(sRegisterID);
            if (detail != null)
            {
                if (detail.ChequeStatus_ID != null && detail.ChequeStatus_ID.Length > 0)
                {
                    if (detail.ChequeStatus_ID == "0")
                        col = clsFormatter.colorChequeNew;
                    else if (detail.ChequeStatus_ID == "1")
                        col = clsFormatter.colorChequeDeposited;
                    else if (detail.ChequeStatus_ID == "2")
                        col = clsFormatter.colorChequeReleasedToSup;
                    else if (detail.ChequeStatus_ID == "3")
                        col = clsFormatter.colorChequeRealized;
                    else if (detail.ChequeStatus_ID == "4")
                        col = clsFormatter.colorChequeReturned_R;
                    else if (detail.ChequeStatus_ID == "5")
                        col = clsFormatter.colorChequeReturned_NR_C;
                    else if (detail.ChequeStatus_ID == "6")
                        col = clsFormatter.colorChequeReturned_NR_O;
                    else if (detail.ChequeStatus_ID == "7")
                        col = clsFormatter.colorChequeReDeposit;
                    else if (detail.ChequeStatus_ID == "8")
                        col = clsFormatter.colorChequeDeleted;
                    else if (detail.ChequeStatus_ID == "9")
                        col = clsFormatter.colorChequeDeleted;
                }
            }
            return col;
        }

        private Color GetColorForChequeOutward(string sRegisterID)
        {
            Color col = Color.FromArgb(99, 50, 50);
            tbl_accChequeRegister detail = tbl_accChequeRegister.Select(sRegisterID);
            if (detail != null)
            {
                if (detail.ChequeStatus_ID != null && detail.ChequeStatus_ID.Length > 0)
                {
                    if (detail.ChequeStatus_ID == "0")
                        col = clsFormatter.colorChequeNew;
                    else if (detail.ChequeStatus_ID == "1")
                        col = clsFormatter.colorChequeDeposited;
                    else if (detail.ChequeStatus_ID == "2")
                        col = clsFormatter.colorChequeReleasedToSup;
                    else if (detail.ChequeStatus_ID == "3")
                        col = clsFormatter.colorChequeRealized;
                    else if (detail.ChequeStatus_ID == "4")
                        col = clsFormatter.colorChequeReturned_R;
                    else if (detail.ChequeStatus_ID == "5")
                        col = clsFormatter.colorChequeReturned_NR_C;
                    else if (detail.ChequeStatus_ID == "6")
                        col = clsFormatter.colorChequeReturned_NR_O;
                    else if (detail.ChequeStatus_ID == "7")
                        col = clsFormatter.colorChequeReDeposit;
                    else if (detail.ChequeStatus_ID == "8")
                        col = clsFormatter.colorChequeDeleted;
                    else if (detail.ChequeStatus_ID == "9")
                        col = clsFormatter.colorChequeDeleted;
                }
            }
            return col;
        }

        private Color GetColorForInward_Cash(string sReceiptID, string sStatus)
        {
            Color col = Color.FromArgb(99, 50, 50);
            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
            if (detail != null)
            {
                if (detail.Receipt_ID != null && detail.Receipt_ID.Length > 0)
                {
                    if (sStatus == "NEW")
                        col = clsFormatter.colorChequeNew;
                    else if (sStatus == "DEPOSITED")
                        col = clsFormatter.colorChequeDeposited;
                }
            }
            return col;
        }
        #endregion

        #region BindingSource Filtering
        private void createFilterQuary_Outward()
        {
            try
            {
                string sFinalQuary = "";

                sFinalQuary = " SupplierNameOut LIKE '%" + txtSupplierID.Text.Trim() + "%'";
                sFinalQuary += " AND IssuedAccountNumberOut LIKE '%" + txtAccNoOut.Text.Trim() + "%'";
                sFinalQuary += " AND RegisterCodeOut LIKE '%" + txtRegCodeOut.Text.Trim() + "%'";
                sFinalQuary += " AND PVOut LIKE '%" + txtPV.Text.Trim() + "%'";
                sFinalQuary += " AND ChequeNoOut LIKE '%" + txtChequeNoOut.Text.Trim() + "%'";
                //sFinalQuary += " AND AmountOut LIKE '%" + txtAmountOut.Text.Trim() + "%'";

                if (txtAmountOut.Text == "0.00")
                {
                    sFinalQuary += " AND AmountOut LIKE '%" + "" + "%'";
                }
                else
                {
                    sFinalQuary += " AND AmountOut LIKE '%" + txtAmountOut.Text.Trim() + "%'";
                }
                nsOutward.Filter = sFinalQuary;

                changeGridColorOutward();
            }
            catch (Exception)
            { }
        }
        private void createFilterQuary_Inward(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";
                //iGridCount = 1;
                if (chkAccountNo.Checked && argText.Name != "txtAccountID")
                {
                    if (sFilterQuary_Inword.Trim().Length > 0)
                        sFilterQuary_Inword += " AND AccountNo LIKE '%" + txtAccountID.Text.Trim() + "%'";
                    else
                        sFilterQuary_Inword = " AccountNo LIKE '%" + txtAccountID.Text.Trim() + "%'";
                }
                if (chkAmount.Checked && argText.Name != "txtAmount")
                {
                    if (sFilterQuary_Inword.Trim().Length > 0)
                        sFilterQuary_Inword += " AND Amount LIKE '%" + txtAmount.Text.Trim() + "%'";
                    else
                        sFilterQuary_Inword = " Amount LIKE '%" + txtAmount.Text.Trim() + "%'";
                }
                if (chkChequeNo.Checked && argText.Name != "txtChequeNo")
                {
                    if (sFilterQuary_Inword.Trim().Length > 0)
                        sFilterQuary_Inword += " AND ChequeNo LIKE '%" + txtChequeNo.Text.Trim() + "%'";
                    else
                        sFilterQuary_Inword = " ChequeNo LIKE '%" + txtChequeNo.Text.Trim() + "%'";
                }
                if (chkCustomerName.Checked && argText.Name != "txtCustomerID")
                {
                    if (sFilterQuary_Inword.Trim().Length > 0)
                        sFilterQuary_Inword += " AND CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";
                    else
                        sFilterQuary_Inword = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";
                }
                if (chkRecieptNo.Checked && argText.Name != "txtReceiptID")
                {
                    if (sFilterQuary_Inword.Trim().Length > 0)
                        sFilterQuary_Inword += " AND ReceiptID LIKE '%" + txtReceiptID.Text.Trim() + "%'";
                    else
                        sFilterQuary_Inword = " ReceiptID LIKE '%" + txtReceiptID.Text.Trim() + "%'";
                }
                if (chkRegisterCode.Checked && argText.Name != "txtRegisterID")
                {
                    if (sFilterQuary_Inword.Trim().Length > 0)
                        sFilterQuary_Inword += " AND RegisterCode LIKE '%" + txtRegisterID.Text.Trim() + "%'";
                    else
                        sFilterQuary_Inword = " RegisterCode LIKE '%" + txtRegisterID.Text.Trim() + "%'";
                }

                if (argText.Name == "txtAccountID")
                    sTemp = " AccountNo LIKE '%" + txtAccountID.Text.Trim() + "%'";
                if (argText.Name == "txtAmount")
                    sTemp = " Amount LIKE '%" + txtAmount.Text.Trim() + "%'";
                if (argText.Name == "txtChequeNo")
                    sTemp = " ChequeNo LIKE '%" + txtChequeNo.Text.Trim() + "%'";
                if (argText.Name == "txtCustomerID")
                    sTemp = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";
                if (argText.Name == "txtReceiptID")
                    sTemp = " ReceiptID LIKE '%" + txtReceiptID.Text.Trim() + "%'";
                if (argText.Name == "txtRegisterID")
                    sTemp = " RegisterCode LIKE '%" + txtRegisterID.Text.Trim() + "%'";

                if (sTemp.Trim().Length > 0)
                {
                    if (sFilterQuary_Inword.Trim().Length > 0)
                    {
                        sFinalQuary = sFilterQuary_Inword + " AND " + sTemp;
                    }
                    else
                    {
                        sFinalQuary = sTemp;
                    }
                }
                bsInward.Filter = "";
                if (sFinalQuary.Trim().Length > 0)
                    bsInward.Filter = sFinalQuary;
                else
                    bsInward.Filter = sTemp;


                if (!(chkRegisterCode.Checked || chkRecieptNo.Checked || chkInvoiceNo.Checked || chkCustomerName.Checked ||
                    chkChequeNo.Checked || chkAmount.Checked || chkAccountNo.Checked))
                {
                    sFilterQuary_Inword = "";
                }

                changeGridColor_Inward();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void createFilterQuary_Inward_Cash(TextBox txtBox, string sFilter)
        {
            string sFinalQuary = "";
            try
            {
                sFinalQuary = " " + sFilter + " LIKE '%" + txtBox.Text.Trim() + "%' ";

                //sFinalQuary = " ReceiptID LIKE '%" + txtCashReceipt.Text.Trim() + "%'";
                //sFinalQuary += " AND CustomerName LIKE '%" + txtCashCustomer.Text.Trim() + "%'";
                //sFinalQuary += " AND DepAccountNo LIKE '%" + txtCashAccount.Text.Trim() + "%'";
                //sFinalQuary += " AND Amount LIKE '%" + txtCashAmount.Text.Trim() + "%'";

                //if (bsCashInward.Filter.Trim().Length > 0 && bsCashInward.DataSource != sFilter)
                //    sFinalQuary = bsCashInward.Filter + " AND " + sFinalQuary;

                bsCashInward.Filter = sFinalQuary;
                changeGridColorInward_Cash();
            }
            catch (Exception)
            { }
        }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sFinalQuary = "";
            try
            {
                sFinalQuary = " Status LIKE '%" + cmbStatus.SelectedItem.ToString() + "%'";
                bsCashInward.Filter = sFinalQuary;
                changeGridColorInward_Cash();
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Grid row Color
        private void changeGridColor_Inward()
        {
            if (chkSetColorInwChq.Checked)
            {
                for (int i = 0; i < dgvInward.Rows.Count; i++)
                {
                    dgvInward.Rows[i].DefaultCellStyle.ForeColor = GetColorForCheque(dgvInward.Rows[i].Cells["RegisterCode"].Value.ToString());
                }
            }
            else
            {
                dgvInward.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void changeGridColorOutward()
        {
            if (chkSetColorOutwChq.Checked)
            {
                for (int i = 0; i < dgvOutward.Rows.Count; i++)
                {
                    dgvOutward.Rows[i].DefaultCellStyle.ForeColor = GetColorForChequeOutward(dgvOutward.Rows[i].Cells["RegisterCodeOut"].Value.ToString());
                }
            }
            else
            {
                dgvOutward.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void changeGridColorInward_Cash()
        {
            if (chkSetColor.Checked)
            {
                for (int i = 0; i < dgvInwardCash.Rows.Count; i++)
                {
                    dgvInwardCash.Rows[i].DefaultCellStyle.ForeColor = GetColorForInward_Cash(dgvInwardCash.Rows[i].Cells["CashReceiptID"].Value.ToString(), dgvInwardCash.Rows[i].Cells["CashStatus"].Value.ToString());
                }
            }
            else
            {
                dgvInwardCash.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
        #endregion

        #region Tab Select Event
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tbpInwardCheques)
                SetFormForInward();
            else if (tabControl.SelectedTab == tbpOutwardCheques)
                SetFormForOutward();
            else if (tabControl.SelectedTab == tbpInwardCash)
                SetFormForInward_Cash();
        }

        private void SetFormForInward()
        {
            Cursor = Cursors.WaitCursor;
            ClearFields_Inward();
            RefreshGrid_Inward();
            Cursor = Cursors.Hand;
        }
        private void SetFormForOutward()
        {
            Cursor = Cursors.WaitCursor;
            ClearFields_Inward();
            RefreshGridOutward();
            Cursor = Cursors.Hand;
        }
        private void SetFormForInward_Cash()
        {
            Cursor = Cursors.WaitCursor;
            ClearFields_Inward_Cash();
            RefreshGridInward_Cash();
            Cursor = Cursors.Hand;
        }
        #endregion

        #region Btn Export
        private void btnExport_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = "Exported from gridview";


            // storing header part in Excel
            for (int i = 1; i < dgvInward.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvInward.Columns[i - 1].HeaderText;
            }



            // storing Each row and column value to excel sheet
            for (int i = 0; i < dgvInward.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvInward.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgvInward.Rows[i].Cells[j].Value.ToString();
                }
            }


            // save the application
            workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application
            app.Quit();

        }
        #endregion

        #region Event Grid Sorted
        private void dgvInward_Sorted(object sender, EventArgs e)
        {
            changeGridColor_Inward();
        }

        private void dgvOutward_Sorted(object sender, EventArgs e)
        {
            changeGridColorOutward();
        }

        private void dgvInwardCash_Sorted(object sender, EventArgs e)
        {
            changeGridColorInward_Cash();
        }
        #endregion

    }
}