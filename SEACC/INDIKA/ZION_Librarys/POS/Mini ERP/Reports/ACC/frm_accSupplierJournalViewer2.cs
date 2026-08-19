using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_accSupplierJournalViewer2 : MettroForm
    {
        #region Class Variables
        DataTable dt = new DataTable();
        string sFilter = "";
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_accSupplierJournalViewer2()
        {
            InitializeComponent();
            //FormName.accSupplierJournalTrackingReport = 454
            //Search.Supplier = 5015
            iFormID = clsSecurity.getFormID(FormName.accSupplierJournalTrackingReport);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            #region Data Table Column Initialize
            dt.Columns.Add("SupplierID");
            dt.Columns.Add("Supplier");
            dt.Columns.Add("txnDate");
            dt.Columns.Add("txnNo");
            dt.Columns.Add("txnID");
            dt.Columns.Add("Narration");
            dt.Columns.Add("Credit", typeof(decimal));
            dt.Columns.Add("Debit", typeof(decimal));
            dt.Columns.Add("Balance", typeof(decimal));
            //dt.Columns.Add("IsDelete", typeof(bool));
            #endregion

        }

        private void frm_accSupplierJournalViewer_Load(object sender, EventArgs e)
        {
            //ucTittleBar1.DisplayName = clsFormatter.DigiteqTitle + " - F" + iFormID.ToString("0000") + " - " + "Tracking Report - Supplier Journal";
            this.Text = clsFormatter.DigiteqTitle + " - F" + iFormID.ToString("0000") + " - " + "Tracking Report - Supplier Journal";

            RefreshGrid();
            ClearFields();
        }
        #endregion

        #region Button Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Button Minimzed
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Button Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtSupplierID.Text = "<All Suppliers>";
            txtSupplierID.Enabled = false;
            txtSupplierID.Tag = null;
            chkCreditorID.Checked = false;

            //txtAPNNo.Text = "<All APN Numbers>";
            //txtAPNNo.Enabled = false;           
            //txtAPNNo.Tag = null;

            chkDeleted.Checked = false;

        }
        #endregion

        #region Event Checkbox ChechChange
        private void chkCreditorID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreditorID.Checked)
            {
                txtSupplierID.Enabled = true;
                txtSupplierID.Clear();

                chkDeleted.Checked = false;
            }
            else
            {
                txtSupplierID.Enabled = false;
                txtSupplierID.Text = "<All Creditors>";
                txtSupplierID.Tag = null;

            }
        }
        #endregion

        #region Event Double Click - Search
        private void txtCreditorID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSupplier(ref txtSupplierID);
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

        #region Button Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            //string sDaterange = "";
            try
            {
                Cursor = Cursors.WaitCursor;
                dt.Clear();
                lblAction.Text = "";

                #region Selected Filters Variables
                bool bSupplierSelected = false;
                bool bDeleted = false;
                #endregion

                string sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " To " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");
                string sSupplier = "%%";

                #region Filters
                if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Length > 0)
                    bSupplierSelected = true;
                if (chkDeleted.Checked == true)
                    bDeleted = true;
                #endregion

                #region MyRegion
                //List<tbl_genSupplierMaster> oSupplierList;
                //if (bSupplierSelected)
                //{
                //    oSupplierList = tbl_genSupplierMaster.SelectAll().Where(p => p.Supplier_ID == txtSupplierID.Tag.ToString() && p.IsDeleted != true && p.CompanyBranch_ID == clsSecurity.BranchID && p.Supplier_ID != "default").OrderBy(p => p.Supplier_ID).ToList();
                //}
                //else
                //{
                //    oSupplierList = tbl_genSupplierMaster.SelectAll().Where(p => p.IsDeleted != true && p.CompanyBranch_ID == clsSecurity.BranchID && p.Supplier_ID != "default").OrderBy(p => p.Supplier_ID).ToList();
                //    //oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNoteDate.Date >= DateTime.Parse("2017-06-01") && p.AccountPayableNoteDate.Date <= DateTime.Parse("2017-07-14")).ToList();
                //}

                //foreach (tbl_genSupplierMaster oSupplier in oSupplierList)
                //{
                //    int iRowID = 1;
                //    #region Changing Filters
                //    //if (bSupplierSelected)
                //    //{
                //    //    if (bDeleted)
                //    //    {
                //    //        oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default").ToList();
                //    //        oPVList = tbl_accPaymentVoucher.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //        oSDBNList = tbl_accDebitNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.DebitNote_Date.Date >= dtpFrom.Value.Date && p.DebitNote_Date.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //    }
                //    //    else
                //    //    {
                //    //        oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.IsDeleted != true && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default").ToList();
                //    //        oPVList = tbl_accPaymentVoucher.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.IsDeleted != true && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //        oSDBNList = tbl_accDebitNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.IsDeleted != true && p.DebitNote_Date.Date >= dtpFrom.Value.Date && p.DebitNote_Date.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //    }
                //    //}
                //    //if (bDeleted)
                //    //{
                //    //    oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default").ToList();
                //    //    oPVList = tbl_accPaymentVoucher.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //    oSDBNList = tbl_accDebitNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.DebitNote_Date.Date >= dtpFrom.Value.Date && p.DebitNote_Date.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //}
                //    //else
                //    //{
                //    //    oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.IsDeleted != true && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default").ToList();
                //    //    oPVList = tbl_accPaymentVoucher.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.IsDeleted != true && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //    oSDBNList = tbl_accDebitNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.IsDeleted != true && p.DebitNote_Date.Date >= dtpFrom.Value.Date && p.DebitNote_Date.Date <= dtpTo.Value.Date && p.IsDeleted && p.Supplier_ID != "default").ToList();
                //    //    //oAPNList = tbl_accAccountPayableNote.SelectAll().Where(p => p.AccountPayableNoteDate.Date >= DateTime.Parse("2017-06-01") && p.AccountPayableNoteDate.Date <= DateTime.Parse("2017-07-14")).ToList();
                //    //    //oPVList = tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucherDate.Date >= DateTime.Parse("2017-06-01") && p.PaymentVoucherDate.Date <= DateTime.Parse("2017-07-14")).ToList();
                //    //    //oSDBNList = tbl_accDebitNote.SelectAll().Where(p => p.DebitNote_Date.Date >= DateTime.Parse("2017-06-01") && p.DebitNote_Date.Date <= DateTime.Parse("2017-07-14")).ToList();
                //    //} 
                //    #endregion
                //    decimal dOpeningBalance = 0, dAPNAmount = 0, dAPNAmountDebit = 0, dPVAmount = 0, dPVAmountCredit = 0, dSDBNAmount = 0, dSDBNAmountCredit = 0;

                //    foreach (srh_bssSupplierOutstanding oOutstanding in srh_bssSupplierOutstanding.SelectAllBySupplierId(oSupplier.Supplier_ID, dtpFrom.Value.Date, false, false, clsSecurity.BranchID).Where(p => p.OutstandingAmount != 0 || p.ChequeInHand != 0 && p.Supplier_ID != "default"))
                //    {
                //        dOpeningBalance += oOutstanding.TransactionAmount;
                //    }
                //    dt.Rows.Add(oSupplier.Supplier_ID, clsGenaralName.getName_Supplier(oSupplier.Supplier_ID), "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dOpeningBalance));
                //    foreach (tbl_accAccountPayableNote oAPN in tbl_accAccountPayableNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.AccountPayableNoteDate.Date >= dtpFrom.Value.Date && p.AccountPayableNoteDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default"))
                //    {
                //        //dAPNAmount = dOpeningBalance + oAPN.GrandTotal;
                //        dt.Rows.Add(oSupplier.Supplier_ID, "", clsFormatter.FormatDate_SL(oAPN.AccountPayableNoteDate), oAPN.AccountPayableNote_ID, "1", "APN", clsFormatter.FormatDecimalPlaces_Price(oAPN.GrandTotal), "", "");
                //        if (oAPN.IsDeleted != false && bDeleted)
                //        {
                //            //dAPNAmountDebit = dAPNAmount - oAPN.GrandTotal;
                //            dt.Rows.Add(oSupplier.Supplier_ID, "", clsFormatter.FormatDate_SL(oAPN.AccountPayableNoteDate), oAPN.AccountPayableNote_ID, "1", "APN", "", clsFormatter.FormatDecimalPlaces_Price(oAPN.GrandTotal), "");
                //        }
                //    }
                //    foreach (tbl_accPaymentVoucher oPV in tbl_accPaymentVoucher.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.PaymentVoucherDate.Date >= dtpFrom.Value.Date && p.PaymentVoucherDate.Date <= dtpTo.Value.Date && p.Supplier_ID != "default"))
                //    {
                //        //dPVAmount = dAPNAmount - oPV.TotalAmount;
                //        dt.Rows.Add(oSupplier.Supplier_ID, "", clsFormatter.FormatDate_SL(oPV.PaymentVoucherDate), oPV.PaymentVoucher_ID, "2", "PV", "", clsFormatter.FormatDecimalPlaces_Price(oPV.TotalAmount), "");

                //        if (oPV.IsDeleted != false && bDeleted)
                //        {
                //            //dPVAmountCredit = dPVAmount + oPV.TotalAmount;
                //            dt.Rows.Add(oSupplier.Supplier_ID, "", clsFormatter.FormatDate_SL(oPV.PaymentVoucherDate), oPV.PaymentVoucher_ID, "2", "PV", clsFormatter.FormatDecimalPlaces_Price(oPV.TotalAmount), "", "");
                //        }
                //    }
                //    foreach (tbl_accDebitNote oSDBN in tbl_accDebitNote.SelectAll().Where(p => p.Supplier_ID == oSupplier.Supplier_ID && p.DebitNote_Date.Date >= dtpFrom.Value.Date && p.DebitNote_Date.Date <= dtpTo.Value.Date && p.Supplier_ID != "default"))
                //    {
                //        //dSDBNAmount = dPVAmount - oSDBN.GrandTotal;
                //        dt.Rows.Add(oSupplier.Supplier_ID, "", clsFormatter.FormatDate_SL(oSDBN.DebitNote_Date), oSDBN.DebitNote_ID, "3", "SDBN", "", clsFormatter.FormatDecimalPlaces_Price(oSDBN.GrandTotal), "");

                //        if (oSDBN.IsDeleted != false && bDeleted)
                //        {
                //            //dSDBNAmountCredit = dSDBNAmount + oSDBN.GrandTotal;
                //            dt.Rows.Add(oSupplier.Supplier_ID, "", clsFormatter.FormatDate_SL(oSDBN.DebitNote_Date), oSDBN.DebitNote_ID, "3", "SDBN", clsFormatter.FormatDecimalPlaces_Price(oSDBN.GrandTotal), "", "");
                //        }
                //    }
                //} 
                #endregion

                if (bSupplierSelected)
                {
                    sSupplier = "%"+ txtSupplierID.Tag.ToString() + "%";
                }
                //dt.Rows.Clear();


                dt.Merge(DBHandling.ExecQuery("exec spSupplierJournalSelectAll '" + sSupplier + "','" + dtpFrom.Value.Date + "','" + dtpTo.Value.Date + "','" + clsSecurity.BranchID + "'").Tables[0]);
                dgvMain.DataSource = dt;

                #region Selected Filters
                if (bSupplierSelected)
                {
                    if (bDeleted)
                        sFilter += " Creditor Name - " + txtSupplierID.Text.Trim() + ", All Records ";
                    else
                        sFilter += " Creditor Name - " + txtSupplierID.Text.Trim() + ", All Active Records";
                }
                else if (bDeleted)
                    sFilter += " All Records ";
                else
                    sFilter += " All Active Records";
                #endregion

                #region Display Date and Filters
                string sFilters = "";
                if (sFilter != "")
                {
                    sFilters = " | Filter : " + sFilter;
                }
                lblAction.Text = "Date : " + sDaterange + sFilters;
                #endregion

                //var vSuppliers = dt.AsEnumerable().GroupBy(r => r.Field<string>("SupplierID"))
                //        .Select(group => new
                //        {
                //            Metric = group.Key,
                //            Count = group.Count()
                //        })
                //        .OrderBy(x => x.Metric);

                //foreach (var vSupplier in vSuppliers.Where(r => r.Count == 1))
                //{
                //    var vRows = dt.Select("SupplierID ='" + vSupplier.Metric + "' ");
                //    foreach (var vRow in vRows)
                //    {
                //        vRow.Delete();
                //        dt.AcceptChanges();
                //    }
                //}


                if (dt.Rows.Count > 0)
                {
                    //DataView dv = dt.DefaultView;
                    //dgvMain.DataSource = dv;
                    dgvMain.DataSource = dt;
                    //GridColor();

                    //dv.RowFilter = " txnDate >= #" + DateTime.Parse("2017-07-01") + "#  AND txnDate <= #" + DateTime.Parse("2017-07-30") + "#";
                    //dv.Sort = "Supplier ASC";
                    //dv.Sort = "SupplierID ASC, txnDate ASC";
                    GridFormats();
                    Calculation();
                    //RemoveWithoutAPNPVSDBNSuppliers();

                    //dt.AsEnumerable()
                    //.GroupBy(r => r.Field<string>("Supplier"))
                    //.OrderBy(g => g.Max(r => r.Field<string>("Supplier")))
                    //.SelectMany(g => g.OrderBy(r => r.Field<DateTime>("txnDate")))
                    //.CopyToDataTable();

                    sDaterange = "";
                    sFilter = "";
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells[5].Value == "APN" && row.Cells[7].Value != "")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                if (row.Cells[5].Value == "PV" && row.Cells[6].Value != "")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                if (row.Cells[5].Value == "SDBN" && row.Cells[6].Value != "")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        #endregion

        #region Calculation
        private void Calculation()
        {
            decimal sOpenningBalance = 0;
            string sSupplierID_Previous = dgvMain.Rows[0].Cells[0].Value.ToString();
            string sSupplierID_Current = "";

            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                sSupplierID_Current = row.Cells[0].Value.ToString();

                if (sSupplierID_Previous != sSupplierID_Current)
                {
                    sOpenningBalance = 0;
                    sSupplierID_Previous = sSupplierID_Current;
                }

                if (decimal.Parse(row.Cells[8].Value.ToString()) != 0m)
                {
                    sOpenningBalance += decimal.Parse(row.Cells[8].Value.ToString());
                }

                if (decimal.Parse(row.Cells[6].Value.ToString()) != 0m)
                {
                    sOpenningBalance += decimal.Parse(row.Cells[6].Value.ToString());
                    row.Cells[8].Value = sOpenningBalance;
                }
                else if (decimal.Parse(row.Cells[7].Value.ToString()) != 0m)
                {
                    sOpenningBalance -= decimal.Parse(row.Cells[7].Value.ToString());
                    row.Cells[8].Value = sOpenningBalance;
                }
            }
        }
        #endregion

        #region Grid Formats
        private void GridFormats()
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                row.Cells[6].Value = clsFormatter.RoundDecimalPlaces(decimal.Parse(row.Cells[6].Value.ToString()));
                row.Cells[7].Value = clsFormatter.RoundDecimalPlaces(decimal.Parse(row.Cells[7].Value.ToString()));
                row.Cells[8].Value = clsFormatter.RoundDecimalPlaces(decimal.Parse(row.Cells[8].Value.ToString()));
            }
        } 
        #endregion

        #region Button Export
        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = "";

            #region Display Save Dialog Box
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xls";
            dlg.Filter = "Excel Sheet (.xls)|*.xlsx";

            //dlg.Filter = "Excel Sheet (.xls)|*.xlsx |PDF File (.pdf)|*.pdf |Text documents (.doc)|*.docx";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                ExportToExcel(filename);

                #region Get File Extension using switch
                //var extension = Path.GetExtension(dlg.FileName);
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
                //    default:
                //        throw new ArgumentOutOfRangeException(extension);
                //} 
                #endregion
            }
            #endregion

            #region Radio Button Export
            //if (rdoExcel.Checked == true)
            //{
            //    ExportToExcel();
            //}
            //else
            //{
            //    ExportToWord();
            //} 
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
                    WsObj.Cells[1, 1] = "Supplier Journal Report";
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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {

                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Export to Word
        public void ExportToWord()
        {
            //Create an instance for word app
            try
            {
                if (GridValidation())
                {
                    string filename = "";

                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.DefaultExt = ".doc";
                    dlg.Filter = "Word documents (.doc)|*.docx";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        filename = dlg.FileName;
                        //MessageBox.Show("successfully Created", "Word File is successfully created", MessageBoxButtons.OK);
                    }

                    Cursor = Cursors.WaitCursor;
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
                        headerRange.Text = "Supplier Journal Report \n Created Date & Time : " + DateTime.Now.ToString();
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
                        footerRange2.Text = "Digiteq";
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
                                //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
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


                    document.SaveAs(filename);
                    MessageBox.Show("successfully Created", "Word File is successfully created", MessageBoxButtons.OK);
                    winword.Visible = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {

                Cursor = Cursors.Default;
            }
        }
        #endregion

        private void PrintDialog()
        {
            //int height = dgvMain.Height;
            //dgvMain.Height = dgvMain.RowCount * dgvMain.RowTemplate.Height * 2;
            //Bitmap bmp = new Bitmap(dgvMain.Width, dgvMain.Height);
            //dgvMain.DrawToBitmap(bmp, new Rectangle(0, 0, dgvMain.Width, dgvMain.Height));
            //dgvMain.Height = height;
            //PrintPreviewDialog ppd = new PrintPreviewDialog();
            //ppd.ShowDialog();
        }

        #region To Be Remove
        private void GridBorder()
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells[0].Value != "" && row.Cells[1].Value != "")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 222);

                    row.DataGridView.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
                    row.DataGridView.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    row.DataGridView.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
                    row.DataGridView.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
                }
            }
        }
        private void RemoveWithoutAPNPVSDBNSuppliers()
        {
            string supplierid = "", supplierids = "";
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                //if (row.Cells[0].Value != "" && row.Cells[1].Value != "" && row.Cells[3].Value == "" && row.Cells[4].Value == "")
                //{
                //    dgvMain.Rows.Remove(row);
                //}

                if (row.Cells[0].Value != "")
                {
                    supplierid = row.Cells[0].Value.ToString();
                    int count = dgvMain.Rows.Count;
                }
                if (row.Cells[0].Value != "" && row.Cells[3].Value == "")
                {
                    supplierids = row.Cells[0].Value.ToString();
                }
                if (supplierid != supplierids)
                {
                    dgvMain.Rows.Remove(row);
                }
            }
        }
        #endregion

    }
}
