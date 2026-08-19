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
using Digiteq.DataSets;
using Digiteq.DataSets.ACC;
using System.IO;

namespace Digiteq
{
    public partial class frm_accAPNSettlementViewer : MettroForm
    {
        #region Variables
        //from Receipt
        public bool bIsFromReceipt = false;
        public string rcpCustomerID = "default";
        public string rcpInvoiceID = "default";
        public string rcpReceiptID = "default";
        public DateTime rcpDate = clsSecurity.getServerDateTime();
        public decimal rcpCashAmount = 0;

        private string sFilterQuery = "";

        public DataTable dtAllRecodes = new DataTable();

        string sFormConfigCode;

        public int iFormID;

        //for security handle
        public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
     //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
     //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        DataTable dt = new DataTable();
        string sFilter = "";
        #endregion

        #region Form Load
        public frm_accAPNSettlementViewer()
        {
            //accAPNSettlement = 453,
            iFormID = clsSecurity.getFormID(FormName.accAPNSettlement);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            SetDataTable();

            InitializeComponent();
        }
        private void frm_bpsChequeRegister_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            //clsFormatter.ApplyGridFormat(dgvMain, clsFormatter.colorDigiteqTheamColor1, Color.FromArgb(191, 201, 200));
            this.Text = clsFormatter.DigiteqTitle + " - F" + iFormID.ToString("0000") + " - " + "Tracking Report - Supplier Credit Note ";

            RefreshGrid();
            ClearFields();
        }
        #endregion

        #region Create Data Table
        private void SetDataTable()
        {
            dt.Columns.Add("LineNo");
            dt.Columns.Add("APNNo"); 
            dt.Columns.Add("BillNo");
            dt.Columns.Add("APNDate");
            dt.Columns.Add("CreditorName");
            dt.Columns.Add("sType");
            dt.Columns.Add("PVNo");
            dt.Columns.Add("PVDate");
            dt.Columns.Add("Credit");
            dt.Columns.Add("Debit");
            dt.Columns.Add("Balance");
            dt.Columns.Add("Status");
        } 
        #endregion

        #region Button Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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

        #region Clear Fields
        private void ClearFields()
        {
            //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCreditorID, true);
            //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAPNNo, true);

            txtCreditorID.Text = "<All Creditors>";
            txtAPNNo.Text = "<All APN Numbers>";

            txtAPNNo.Enabled = false;
            txtCreditorID.Enabled = false;
            cmbSettlementMode.Enabled = false;

            txtCreditorID.Tag = null;
            txtAPNNo.Tag = null;

            chkAPNNo.Checked = false;
            chkCreditorID.Checked = false;
            chkSettlementMode.Checked = false;

            cmbSettlementMode.SelectedIndex = 0;
        }
        #endregion

        #region Events DoubleClick
        private void txtAPNNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //clsSearch.Search_TransactionAccountPayableNote(ref txtAPNNo);
            clsSearch.Search_TransactionAccountPayableNote_Viewer(ref txtAPNNo);
        }
        private void txtCreditorID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_MasterSupplier(ref txtCreditorID);
        }
        #endregion

        #region Events KeyUp
        private void txtAPNNo_KeyUp(object sender, KeyEventArgs e)
        {
            //FilterDataTable(txtAPNNo);
        }
        private void txtCreditorID_KeyUp(object sender, KeyEventArgs e)
        {
            //FilterDataTable(txtCreditorID);
        }
        #endregion

        #region Event Checkbox ChechChange
        private void chkAPNNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAPNNo.Checked){
                txtAPNNo.Enabled = true;
                cmbSettlementMode.Enabled = false;
                txtAPNNo.Clear();

                chkSettlementMode.Checked = false;
            } 
            else
            {
                txtAPNNo.Enabled = false;
                txtAPNNo.Text = "<All APN Numbers>";
                txtAPNNo.Tag = null;
            }
        }

        private void chkSettlementMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSettlementMode.Checked){
                cmbSettlementMode.Enabled = true;
                txtAPNNo.Enabled = false;

                chkAPNNo.Checked = false;
            }
            else
            {
                cmbSettlementMode.Enabled = false;
                cmbSettlementMode.SelectedIndex = 0;
            }
        }

        private void chkCreditorID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreditorID.Checked){
                txtCreditorID.Enabled = true;
                txtCreditorID.Clear();

                chkAPNNo.Checked = false;
                chkSettlementMode.Checked = false;
            }
            else
            {
                txtCreditorID.Enabled = false;
                txtCreditorID.Text = "<All Creditors>";
                txtCreditorID.Tag = null;
                
            }
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDetail_CellDoubleClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Cursor = Cursors.WaitCursor;
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvMain.Columns[e.ColumnIndex].Name;

                    if (sColName == "APNNo" || sColName == "BillNo")
                    {
                        string sAPNNo = clsValidate.ValidateGridValue(dgvMain, "APNNo", e.RowIndex, "");
                        if (sAPNNo.Length > 0)
                        {
                            frm_accAccountpayableNote_OLD frm = new frm_accAccountpayableNote_OLD(FormName.accAccountpayableNote);
                            frm.glbAPNID = sAPNNo;
                            if (frm.bNoAccess)
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, this.MdiParent);
                            }
                        }
                    }
                    else if (sColName == "PVNo")
                    {
                        string sPVNo = clsValidate.ValidateGridValue(dgvMain, "PVNo", e.RowIndex, "");
                        string sType = clsValidate.ValidateGridValue(dgvMain, "sType", e.RowIndex, "");
                        if (sPVNo.Length > 0)
                        {
                            if (sType == "P.V.")
                            {
                                frm_accPaymentVoucher frm = new frm_accPaymentVoucher(FormName.accPaymentVoucher);
                                frm.glbPamentVoucher = sPVNo;
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

        #region BindingSource Filtering
        private void FilterDataTable(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";
                //iGridCount = 1;
                if (chkAPNNo.Checked && argText.Name != "txtAPNNo")
                {
                    if (sFilterQuery.Trim().Length > 0)
                        sFilterQuery += " AND APNNo LIKE '%" + txtAPNNo.Text.Trim() + "%'";
                    else
                        sFilterQuery = " APNNo LIKE '%" + txtAPNNo.Text.Trim() + "%'";
                }
                
                if (chkCreditorID.Checked && argText.Name != "txtCreditorID")
                {
                    if (sFilterQuery.Trim().Length > 0)
                        sFilterQuery += " AND CreditorName LIKE '%" + txtCreditorID.Text.Trim() + "%'";
                    else
                        sFilterQuery = " CreditorName LIKE '%" + txtCreditorID.Text.Trim() + "%'";
                }

                if (argText.Name == "txtAPNNo")
                    sTemp = " APNNo LIKE '%" + txtAPNNo.Text.Trim() + "%'";
                if (argText.Name == "txtCreditorID")
                    sTemp = " CreditorName LIKE '%" + txtCreditorID.Text.Trim() + "%'";

                if (sTemp.Trim().Length > 0)
                {
                    if (sFilterQuery.Trim().Length > 0)
                    {
                        sFinalQuary = sFilterQuery + " AND " + sTemp;
                    }
                    else
                    {
                        sFinalQuary = sTemp;
                    }
                }
                dt.DefaultView.RowFilter = "";
                if (sFinalQuary.Trim().Length > 0)
                    dt.DefaultView.RowFilter = sFinalQuary;
                else
                    dt.DefaultView.RowFilter = sTemp;


                if (!(chkCreditorID.Checked || chkAPNNo.Checked))
                {
                    sFilterQuery = "";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validation
        private bool GridValidation()
        {
            bool bStatus = true;
            if (dgvMain.RowCount <= 0)
                bStatus = false;

            if (bStatus == false)
            {
                MessageBox.Show("Fill Table", "Please fill data table", MessageBoxButtons.OK);
            }

            return bStatus;
        } 
        #endregion

        #region Refresh Grid
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            //string sFormula = "";
            string sDaterange = "";
            try
            {
                Cursor = Cursors.WaitCursor;
                dt.Clear();

                #region Selected Filters Variables
                bool bCreditorSelected = false;
                bool bPaymentMode = false;
                bool bAPNNoSelected = false; 
                #endregion
              
                sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " To " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                #region Filters
                if (txtCreditorID.Tag != null && txtCreditorID.Tag.ToString().Length > 0)
                    bCreditorSelected = true;
                if (txtAPNNo.Tag != null && txtAPNNo.Tag.ToString().Length > 0)
                    bAPNNoSelected = true;
                if (cmbSettlementMode.SelectedIndex != 0 && cmbSettlementMode.SelectedIndex != -1)
                    bPaymentMode = true; 
                #endregion

                List<tbl_accAccountPayableNote> oAPNList;

                #region Selected Filter
                if (bCreditorSelected)
                {
                    if (bAPNNoSelected)
                    {
                        oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == txtCreditorID.Tag.ToString() && p.AccountPayableNote_ID == txtAPNNo.Text && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.IsDeleted != true ).ToList();
                        sFilter += " Creditor Name - " + txtCreditorID.Text.Trim() + ", Account Payable Note ID - " + txtAPNNo.Text;
                    }
                    else if (bPaymentMode)
                    {
                        bool bStatus = false;
                        if (cmbSettlementMode.SelectedIndex == 1)
                            bStatus = true;
                        else if (cmbSettlementMode.SelectedIndex == 2)
                            bStatus = false;
                        oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == txtCreditorID.Tag.ToString() && p.IsSeattled == bStatus && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.IsDeleted != true ).ToList();
                        sFilter += " Creditor Name - " + txtCreditorID.Text.Trim() + ", Settlement Mode - " + cmbSettlementMode.SelectedItem;
                    }
                    else
                    {
                        oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == txtCreditorID.Tag.ToString() && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.IsDeleted != true ).ToList();
                        sFilter += " Creditor Name - " + txtCreditorID.Text.Trim();
                    }
                }
                else if (bAPNNoSelected)
                {
                    oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNote_ID == txtAPNNo.Text.Trim() && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.IsDeleted != true ).ToList();
                    sFilter += " Account Payable Note ID - " + txtAPNNo.Text.Trim();
                }
                else if (bPaymentMode)
                {
                    bool bStatus = false;
                    if (cmbSettlementMode.SelectedIndex == 1)
                        bStatus = true;
                    else if (cmbSettlementMode.SelectedIndex == 2)
                        bStatus = false;
                    oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.IsSeattled == bStatus && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.IsDeleted != true ).ToList();
                    sFilter += "Settlement Mode - " + cmbSettlementMode.SelectedItem;
                }
                else
                {
                    oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.IsDeleted != true ).ToList();
                    sFilter += "All Details";
                    //oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNoteDate.Date >= DateTime.Parse("2017-06-01") && p.AccountPayableNoteDate.Date <= DateTime.Parse("2017-07-14")).ToList();
                }
                #endregion

                #region Display Date and Filters
                string sFilters = "";
                if (sFilter != null)
                {
                    sFilters = " | Filter : " + sFilter;
                }
                lblAction.Text = "Date : " + sDaterange + sFilters;
                #endregion

                #region Variables
                int iRowID = 1;
                string sIsSettlement = "", sPVnDNid = "", sType = "", sAPNNo = "";
                DateTime sPVDnDNdate = new DateTime();
                DateTime dtpPVDate = DateTime.Now;
                decimal dTotalAmount = 0, dSettleAmount = 0, dBalance = 0, dSettlementAmounts = 0, dDebit = 0, dCredit = 0; 
                #endregion

                foreach (tbl_accAccountPayableNote oAPN in oAPNList)
                {
                    if (oAPN.IsSeattled == true)
                        sIsSettlement = "Settled";
                    else
                        sIsSettlement = "Unsettled";

                    dBalance = oAPN.GrandTotal;
                    dCredit += oAPN.GrandTotal;
                    dt.Rows.Add(iRowID, oAPN.AccountPayableNote_ID, oAPN.BillNo, clsFormatter.FormatDate_SL(oAPN.AccountPayableNoteDate),
                        clsGenaralName.getName_Supplier(oAPN.Supplier_ID) + (oAPN.ExternalGoodReceivedNote_ID != "default" ? " - GRN No: " + oAPN.ExternalGoodReceivedNote_ID : "") + (oAPN.PurchaseOrder_ID != "default" ? " - PO No: " + oAPN.PurchaseOrder_ID : ""),
                        "", "", "", clsFormatter.FormatDecimalPlaces_Price(oAPN.GrandTotal), "", clsFormatter.FormatDecimalPlaces_Price(dBalance), sIsSettlement);
                    
                    foreach (tbl_accPaymentVoucher_Detail oPVD in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(oAPN.AccountPayableNote_ID))
                    {
                        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(oPVD.PaymentVoucher_ID);
                        tbl_accDebitNote oDN = tbl_accDebitNote.Select(oPVD.DebitNote_ID);
                        tbl_accJournalEntry oJE_DR = tbl_accJournalEntry.Select(oPVD.JournalEntry_ID_DR);

                        if (oPV != null && oPVD.PaymentVoucher_ID != "default")
                        {
                            sPVnDNid = oPV.PaymentVoucher_ID;
                            sPVDnDNdate = oPV.PaymentVoucherDate;
                            sType = "P.V.";
                        }
                        else if (oDN != null && oPVD.DebitNote_ID != "default")
                        {
                            sPVnDNid = oDN.DebitNote_ID;
                            sPVDnDNdate = oDN.DebitNote_Date;
                            sType = "S.D.B.N.";
                        }
                        else if (oJE_DR != null && oJE_DR.JournalEntry_ID != "default")
                        {
                            sPVnDNid = oJE_DR.JournalEntry_ID;
                            sPVDnDNdate = oJE_DR.JournalEntryDate;
                            sType = "J.E.";
                        }

                        dSettlementAmounts += oPVD.SettleAmount;
                        dSettleAmount = dBalance - dSettlementAmounts;
                        dDebit += oPVD.SettleAmount;

                        dt.Rows.Add("", "","", "", "", sType, sPVnDNid, clsFormatter.FormatDate_SL(sPVDnDNdate), "",
                                clsFormatter.FormatDecimalPlaces_Price(oPVD.SettleAmount), clsFormatter.FormatDecimalPlaces_Price(dSettleAmount), "");
                    }

                    dSettlementAmounts = 0;
                    dSettleAmount = 0;
                    dBalance = 0;

                    iRowID++;

                    //dt.Rows.Add("", "", "", "", "", "", "", "", "", "", "");
                }

                dt.Rows.Add("", "", "", "", "", "", "Total : ", "", clsFormatter.FormatDecimalPlaces_Price(dCredit), clsFormatter.FormatDecimalPlaces_Price(dDebit), "", "");

                lblCredit.Text = clsFormatter.FormatDecimalPlaces_Price(dCredit);
                lblDebit.Text = clsFormatter.FormatDecimalPlaces_Price(dDebit);

                dgvMain.DataSource = dt.DefaultView;
                GridColor();
                HighLightCalculation();

                sDaterange = "";
                //sFormula = "";
                sFilter = "";
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

        #region Grid Color
        private void GridColor()
        {
            //foreach (DataGridViewRow row in dgvMain.Rows)
            //{
            //    if (row.Cells[0].Value == "" && row.Cells[1].Value == "" && row.Cells[2].Value == "" && row.Cells[3].Value == ""
            //        && row.Cells[4].Value == "" && row.Cells[5].Value == "" && row.Cells[6].Value == "" && row.Cells[7].Value == ""
            //        && row.Cells[8].Value == "" && row.Cells[9].Value == "" && row.Cells[10].Value == "")
            //    {
            //        row.Height = 150;
            //        row.DefaultCellStyle.BackColor = Color.Silver;
            //        //row.DefaultCellStyle.ForeColor = Color.White;

            //    }
            //}

            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells[0].Value != "" && row.Cells[1].Value != "")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 222);

                    //row.DataGridView.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
                    //row.DataGridView.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
                    //row.DataGridView.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
                    //row.DataGridView.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
                }
            }

            //for (int i = 0; i < dgvMain.Rows.Count; i++)
            //{
            //    if (dgvMain.Rows[i] == null)
            //    {
            //        dgvMain.Rows[i].DefaultCellStyle.ForeColor = Color.SteelBlue;
            //        //var dgv = new DataGridView();
            //        DataGridView dgv = dgvMain;
            //        dgv.RowTemplate.Height = 50;

            //    }
            //}
        }
        #endregion

        #region Highlight Calculation
        private void HighLightCalculation()
        {
            //foreach (DataGridViewRow row in dgvMain.Rows)
            //{
            int index = dgvMain.Rows.Count - 1;
            if (index != null)
            {
                if (dgvMain.Rows[index].Cells[7].Value != "" && dgvMain.Rows[index].Cells[8].Value != "")
                {
                dgvMain.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
                dgvMain.Rows[index].DefaultCellStyle.Font = new Font(dgvMain.Font, FontStyle.Bold);

                //row.DefaultCellStyle.ForeColor = Color.Black;
                //row.DefaultCellStyle.Font = new Font(dgvMain.Font, FontStyle.Bold);
                }
            }

            //}
        } 
        #endregion

        #region Export Data
        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = "";

            #region Display Save Dialog Box
           SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xls";
            //dlg.DefaultExt = ".doc";
            dlg.Filter = "Excel Sheet (.xls)|*.xlsx";
            //dlg.Filter = "Word documents (.doc)|*.docx";
            //dlg.Filter = "Excel Sheet (.xls)|*.xlsx |Word documents (.doc)|*.docx |Text documents (.txt)|*.txt";
            //dlg.Filter = "Excel Sheet (.xlsx)|*.xlsx |Word documents (.docx)|*.docx |Text documents (.txt)|*.txt |All Files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                ExportToExcel(filename);
                //ExportToWord(filename);

                #region Get File Extension using Switch
                //var extension = Path.GetExtension(filename);
                //switch (extension)
                //{
                //    case ".xlsx":
                //        ExportToExcel(filename);
                //        break;
                //    case ".docx":
                //        ExportToWord(filename);
                //        break;
                //    case ".xls":
                //        ExportToExcel(filename);
                //        break;
                //    case ".doc":
                //        ExportToWord(filename);
                //        break;
                //    case ".txt":
                //        ExportToText(filename);
                //        break;
                //    default:
                //        throw new ArgumentOutOfRangeException(extension);
                //} 
                #endregion
            }
            #endregion
        }
        #endregion

        #region Export to Excel
        public void ExportToExcel(string filename)
        {
            try
            {
                if (GridValidation())
                {
                    //string filename = "";
                    #region Display Save Dialog Box
                    //Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    //dlg.DefaultExt = ".xls";
                    //dlg.Filter = "Excel Sheet (.xls)|*.xlsx";
                    //if (dlg.ShowDialog() == true)
                    //{
                    //    filename = dlg.FileName;
                    //}
                    #endregion

                    Cursor = Cursors.WaitCursor;

                    Microsoft.Office.Interop.Excel.Application WsObj = new Microsoft.Office.Interop.Excel.Application();
                    WsObj.Application.Workbooks.Add(Type.Missing);
                    WsObj.Application.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    #region Generate Page Header
                    WsObj.Visible = false;
                    WsObj.Cells[1, 1] = "Supplier Credit Note Report";
                    WsObj.Cells[2, 1] = "Created Date & Time : " + DateTime.Now.ToString();
                    WsObj.Range[WsObj.Cells[1, 1], WsObj.Cells[1, 5]].Merge();
                    WsObj.Range[WsObj.Cells[2, 1], WsObj.Cells[2, 5]].Merge();
                    #endregion

                    #region Generate Header
                    int row = 4; int col = 1;
                    for (int i = 1; i < dgvMain.Columns.Count + 1; i++)
                    {
                        WsObj.Cells[row, i] = dgvMain.Columns[i - 1].HeaderText;
                        WsObj.Cells[row, i].Borders.Color = System.Drawing.Color.Black;
                        WsObj.Cells[row, i].Interior.Color = System.Drawing.Color.LightGray;
                    }
                    #endregion

                    #region Generate Columns
                    row++;
                    for (int i = 0; i < dgvMain.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvMain.Columns.Count; j++)
                        {
                            WsObj.Cells[row + i, col + j] = dgvMain.Rows[i].Cells[j].Value.ToString();
                            WsObj.Cells[row + i, col + j].Borders.Color = System.Drawing.Color.Black;
                        }
                    }
                    WsObj.Columns.AutoFit();
                    #endregion

                    WsObj.ActiveWorkbook.SaveAs(filename);
                    MessageBox.Show("Excel File is successfully created", "Successfully Created", MessageBoxButtons.OK);
                    //WsObj.Visible = true;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                //System.Runtime.InteropServices;
                //Marshal.FinalReleaseComObject(WsObj);
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Export to Word
        public void ExportToWord(string name)
        {
            //Create an instance for word app
            try
            {
                Cursor = Cursors.WaitCursor;
                //Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                //dlg.DefaultExt = ".doc";
                //dlg.Filter = "Text documents (.doc)|*.docx";
                //if (dlg.ShowDialog() == true)
                //{
                //    object filename = dlg.FileName;
                //    MessageBox.Show("successfully Created", "Word File is successfully created", MessageBoxButtons.OK);
                //}

                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                //Set status for word application is to be visible or not.
                winword.Visible = false;

                //Create a missing variable for missing value
                //object missing = System.Reflection.Missing.Value;

                //Create a new document
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                document.Paragraphs.SpaceAfter = 0;
                document.Paragraphs.LineSpacing = 12;

                #region Header and Footer
                //Add header into the document
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Created Date & Time : " + DateTime.Now.ToString() + Environment.NewLine + " " + 
                        clsSecurity.CompanyName + " " + Environment.NewLine + " " + 
                        clsSecurity.CompanyAddress1 + " " + Environment.NewLine + " " + 
                        clsSecurity.CompanyAddress2 + " " + Environment.NewLine + " " +
                        "Account Payable Note Settlement Report ";
                    
                    //Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    //headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    //headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    //headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    //headerRange.Font.Size = 16;
                    //headerRange.Text = "Account Payable Note Settlement Report ";
                }

                //Add the footers into the document
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Digiteq";

                    Microsoft.Office.Interop.Word.Range footerRange2 = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange2.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    footerRange2.Font.Size = 10;
                    footerRange2.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    //footerRange2.Text = Microsoft.Office.Interop.Word.PageNumbers;
                } 
                #endregion

                //adding text to document
                document.Content.SetRange(0, 3);
                //document.Content.Text = "This is test document " + Environment.NewLine;

                //Add paragraph with Heading 1 style
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(Type.Missing);

                //for (int i = 0; i < dgvMain.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dgvMain.Columns.Count; j++)
                //    {
                //        WsObj.Cells[row + i, col + j] = dgvMain.Rows[i].Cells[j].Value.ToString();
                //        WsObj.Cells[row + i, col + j].Borders.Color = System.Drawing.Color.Black;
                //    }
                //}

                //Create a  table and insert some records
                //Microsoft.Office.Interop.Word.Table firstTable = document.Tables.Add(para1.Range, dt.Rows.Count, dt.Columns.Count, Type.Missing, Type.Missing);
                Microsoft.Office.Interop.Word.Table firstTable = document.Tables.Add(para1.Range, dgvMain.Rows.Count, dgvMain.Columns.Count, Type.Missing, Type.Missing);

                firstTable.Borders.Enable = 1;

                int rowCount = 0;
                foreach (Microsoft.Office.Interop.Word.Row row in firstTable.Rows)
                {
                    int columnCount = 0;
                    foreach (Microsoft.Office.Interop.Word.Cell cell in row.Cells)
                    {
                        //Header row
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = dgvMain.Columns[columnCount].HeaderText;// "Column " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdGray25;                            
                            cell.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray25;
                            //Center alignment for the Header cells
                            cell.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        //Data row
                        else
                        {
                            cell.Range.Text = dgvMain.Rows[rowCount].Cells[columnCount].Value.ToString();
                                //dgvMain.Rows[rowCount].ToString();  //(cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                        columnCount++;
                    }
                    rowCount++;
                }
                firstTable.Rows[1].Range.Bold = 1;

                firstTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent);
                document.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;
                document.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;

                document.SaveAs(name);
                MessageBox.Show("Successfully Created", "Word File is successfully created", MessageBoxButtons.OK);
                winword.Visible = false;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                //System.Runtime.InteropServices;
                //Marshal.FinalReleaseComObject(winword);
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Export to Text
        public void ExportToText(string filename)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int[] maxLengths = new int[dgvMain.Columns.Count];

                for (int i = 0; i < dgvMain.Columns.Count; i++)
                {
                    maxLengths[i] = dgvMain.Columns[i].HeaderCell.ColumnIndex;

                    foreach (DataRow row in dgvMain.Rows)
                    {
                        if (!row.IsNull(i))
                        {
                            int length = row[i].ToString().Length;

                            if (length > maxLengths[i])
                            {
                                maxLengths[i] = length;
                            }
                        }
                    }
                }

                //Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                //dlg.DefaultExt = ".txt";
                //dlg.Filter = "Text documents (.txt)|*.txt|All files (*.*)|*.*";
                //if (dlg.ShowDialog() == true)
                //{
                    //filename = dlg.FileName;
                    using (StreamWriter sw = new StreamWriter(filename, false))
                    {
                        sw.WriteLine("Created Date & Time : " + DateTime.Now.ToString());

                        for (int i = 0; i < dgvMain.Columns.Count; i++)
                        {
                            sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                        }

                        sw.WriteLine();

                        foreach (DataRow row in dgvMain.Rows)
                        {
                            for (int i = 0; i < dgvMain.Columns.Count; i++)
                            {
                                if (!row.IsNull(i))
                                {
                                    sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                                }
                                else
                                {
                                    sw.Write(new string(' ', maxLengths[i] + 2));
                                }
                            }
                            sw.WriteLine();
                        }
                        sw.Close();
                        MessageBox.Show("successfully Created", "Text File is successfully created", MessageBoxButtons.OK);
                    //}
                }
                System.Diagnostics.Process.Start(filename);
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

        #region Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
            dts_accAPNSettlement glb_dts_accAPNSettlement = new dts_accAPNSettlement();

            string sRptID = clsAutocode.getReportID(enum_ReportName.RG_APN_Settlement_Report);


            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
            if (clsHelpMethods.GetReportPath(sRptID, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
            {

                string sFormula = "";

                string sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " To " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                if (clsSecurity.PermissionToPrint_WithMessage(sRptID))
                {
                    try
                    {
                        if (sReportPath != "")
                        {
                            glb_dts_accAPNSettlement.Clear();
                            glb_dtsReportExport.Clear();
                            Cursor = Cursors.WaitCursor;

                            foreach (DataRow row in dt.Rows)
                            {

                                //glb_dts_accAPNSettlement.dt_accAPNPaymentTracking.Adddt_accAPNPaymentTrackingRow(row["APNNo"].ToString(), DateTime.Parse(row["APNDate"].ToString()),
                                //    "", row["CreditorName"].ToString(), Decimal.Parse(row["Credit"].ToString()), Boolean.Parse(row["Status"].ToString()), 
                                //    row["PVNo"].ToString(), DateTime.Parse(row["PVDate"].ToString()),0, Decimal.Parse(row["Debit"].ToString()),
                                //    "",DateTime.Now, Decimal.Parse(row["Balance"].ToString()), row["sType"].ToString(), row["LineNo"].ToString());

                                glb_dts_accAPNSettlement.dt_accAPNPaymentTracking.Adddt_accAPNPaymentTrackingRow(row["APNNo"].ToString(), row["APNDate"].ToString(),
                                    "", row["CreditorName"].ToString(), row["Credit"].ToString(), row["Status"].ToString(),
                                    row["PVNo"].ToString(), row["PVDate"].ToString(), "", row["Debit"].ToString(),
                                    "", "", row["Balance"].ToString(), row["sType"].ToString(), row["LineNo"].ToString());
                            }

                            glb_dts_accAPNSettlement.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);

                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                            rpt.print(sReportPath, glb_dts_accAPNSettlement, glb_dtsReportExport.dt_rptParameter, sRptID);

                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        glb_dts_accAPNSettlement.Clear();
                        glb_dtsReportExport.Clear();
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        #endregion

        #region Commented Methods
        private void ExportMethod2()
        {
            //Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //// creating new WorkBook within Excel application
            //Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //// creating new Excelsheet in workbook
            //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //// see the excel sheet behind the program
            //app.Visible = true;
            //// get the reference of first sheet. By default its name is Sheet1.
            //// store its reference to worksheet
            //worksheet = workbook.Sheets["Sheet1"];
            //worksheet = workbook.ActiveSheet;
            //// changing the name of active sheet
            //worksheet.Name = "Exported from gridview";
            ////storing header part in Excel
            //for (int i = 1; i < dgvMain.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[1, i] = dgvMain.Columns[i - 1].HeaderText;
            //}
            //// storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvMain.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvMain.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 2, j + 1] = dgvMain.Rows[i].Cells[j].Value.ToString();
            //    }
            //}

            //// save the application
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //// Exit from the application
            //app.Quit();
        } 
        #endregion
    }
}


