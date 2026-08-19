using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Digiteq_Logic;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_AccountsOpeningBalance : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;
        bool bShowMessages = true;

        //to keep form detail       
        public int iFormID;
        public bool bNoAccess;

        BindingSource bindingSource = new BindingSource();
        DataTable dataTable = new DataTable();

       private string sFilteQuary = "";
       private bool bAcctCodeTypeCode;
       private bool bAcctTypeSubGlCode;
        #endregion

        #region Form Load
        public frm_AccountsOpeningBalance()
        {
            iFormID = clsSecurity.getFormID(FormName.accAccount);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();            
        }
        private void frm_AccountsOpeningBalance_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            ClearFields();
            CusDataGridViewFormat();
            CreateDataTable();
            dgvDetail.DataSource = bindingSource;
            //RefreshGrid();
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (CheckValidity())
            //{
            //    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            //    {
            //        string sAcctCode = "", sYearID = "", sMonthID = "";
            //        try
            //        {
            //            if (cmbMonth.Text.Length > 0)
            //            {
            //                sYearID = txtFinYear.Tag.ToString();
            //                tbl_zMonth month = tbl_zMonth.Select(cmbMonth.Text);
            //                if (month != null)
            //                    sMonthID = month.MonthName;
  
            //                Cursor = Cursors.WaitCursor;

            //                foreach (DataGridViewRow row in dgvDetail.Rows)
            //                {
            //                    decimal dOpeningBalance = 0, dClosingBalance = 0, dDebitAmount = 0, dCreditAmount = 0, dBudget = 0;
            //                    bool isOpenningCredit = false, isCloseingCredit = false;

            //                    //sAcctCode = clsValidate.ValidateGridValue(dgvDetail, "GL_code", row.Index, "");
            //                    sAcctCode = clsValidate.ValidateGridValue(dgvDetail, "AccCode", row.Index, "");
            //                    //dOpeningBalance = clsValidate.ValidateGridValue(dgvDetail, "openbalance", row.Index, decimal.Parse("0.00"));
            //                    dDebitAmount = clsValidate.ValidateGridValue(dgvDetail, "DebitAmount", row.Index, decimal.Parse("0.00"));
            //                    dCreditAmount = clsValidate.ValidateGridValue(dgvDetail, "CreditAmount", row.Index, decimal.Parse("0.00"));
            //                    dBudget = clsValidate.ValidateGridValue(dgvDetail, "budget", row.Index, decimal.Parse("0.00"));


            //                    //change due to reason. change column in datagrid - 2017-9-20
            //                    if (dCreditAmount > 0)
            //                    {
            //                        isOpenningCredit = true;
            //                        dOpeningBalance = dCreditAmount;
            //                    }
            //                    else
            //                    {
            //                        isOpenningCredit = false;
            //                        dOpeningBalance = dDebitAmount;
            //                    } 

            //                    dClosingBalance = dOpeningBalance + dDebitAmount - dCreditAmount;

            //                    tbl_accFinancialYearMaster_Month_OpenningBalance detailSelect = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(sAcctCode, sYearID, sMonthID);
            //                    if (detailSelect != null)
            //                    {
            //                        tbl_accFinancialYearMaster_Month_OpenningBalance detail = new tbl_accFinancialYearMaster_Month_OpenningBalance(sAcctCode, sYearID, sMonthID, dOpeningBalance, isOpenningCredit, dClosingBalance, isCloseingCredit, dDebitAmount, dCreditAmount, dBudget);
            //                        detail.Update();
            //                    }
            //                    else
            //                    {
            //                        tbl_accFinancialYearMaster_Month FYM_detail = tbl_accFinancialYearMaster_Month.Select(sYearID, sMonthID);
            //                        if (FYM_detail == null)
            //                        {
            //                            tbl_accFinancialYearMaster_Month Mdetail = new tbl_accFinancialYearMaster_Month(sYearID, sMonthID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, 
            //                                clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(),
            //                                clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
            //                                clsSecurity.TerminalID, clsSecurity.TerminalID,
            //                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
            //                            Mdetail.Insert();
            //                        }
            //                        tbl_accFinancialYearMaster_Month_OpenningBalance detail = new tbl_accFinancialYearMaster_Month_OpenningBalance(sAcctCode, sYearID, sMonthID, dOpeningBalance, isOpenningCredit, dClosingBalance, isCloseingCredit, dDebitAmount, dCreditAmount, dBudget);
            //                        detail.Insert();
            //                    }
            //                }
            //                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            clsValidate.WriteErrorLog("", iFormID,ex);
            //            SEACCException.Show(ex);
            //        }
            //        finally
            //        {
            //            Cursor = Cursors.Default;
            //            RefreshGridForMonth(sYearID, sMonthID);
            //        }
            //    }
            //}
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Filter Clear
        private void btnFilters_Click(object sender, EventArgs e)
        {
            ClearFilters();
        } 
        #endregion
        

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            //clsFormatter.ApplyGridFormat(dgvDetail, Color.FromArgb(150, 151, 150), Color.Black);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dataTable.Rows.Clear();

                foreach (tbl_accGLMaster glMaster in tbl_accGLMaster.SelectAll().Where(p => p.Gl_ID != "default"))
                {
                    tbl_zAccGLMaster_AccountType oAccType = tbl_zAccGLMaster_AccountType.Select(glMaster.GlAccountType_ID);
                    if (oAccType != null)
                    {
                        tbl_zAccGLMaster_SubCatagory oAccSubCatagory = tbl_zAccGLMaster_SubCatagory.Select(oAccType.GlSubCatagory_ID);
                        if (oAccSubCatagory != null)
                        {
                            foreach (tbl_accFinancialYearMaster oFinYear in tbl_accFinancialYearMaster.SelectAllByStatusID(1).Where(p => p.FinancialYear_ID != "default"))
                            {
                               tbl_accFinancialYearMaster_Month_OpenningBalance findetail = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(glMaster.Gl_ID, oFinYear.FinancialYear_ID, "April");
                                if (findetail != null)
                                {
                                    dataTable.Rows.Add(oAccSubCatagory.GlSubCatagory_ID, clsGenaralName.getName_GLSubCatagory(oAccSubCatagory.GlSubCatagory_ID),
                                                   glMaster.GlAccountType_ID, clsGenaralName.getName_GlAccountType1(glMaster.GlAccountType_ID),
                                                   glMaster.Gl_ID, clsGenaralName.getName_AccountName(glMaster.Gl_ID), 
                                                   clsFormatter.FormatToCurrecyWithThousendSep(findetail.OpeningBalance),
                                                   findetail.IsCreditOpening != true ? clsFormatter.FormatToCurrecyWithThousendSep(findetail.OpeningBalance) : clsFormatter.FormatToCurrecyWithThousendSep(0),
                                                   findetail.IsCreditOpening == true ? clsFormatter.FormatToCurrecyWithThousendSep(findetail.OpeningBalance) : clsFormatter.FormatToCurrecyWithThousendSep(0),
                                                   clsFormatter.FormatToCurrecyWithThousendSep(findetail.ClosingBalance),
                                                   !findetail.IsCreditClosing ? true : false, findetail.IsCreditClosing ? true : false, 
                                                   clsFormatter.FormatToCurrecyWithThousendSep(findetail.Budget));

                                }                        
                            }
                        }
                    }
                }
                bindingSource.DataSource = dataTable;
                CalculateCreditDebit();
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

        private void RefreshGridForMonth(string sFinancialYear, string sMonthID)
        {
            try
            {
                bAcctCodeTypeCode = false; bAcctTypeSubGlCode = false;

                if (txtAcctType.Tag != null && txtAcctType.Tag.ToString().Trim().Length > 0)
                    bAcctCodeTypeCode = true;
               

                Cursor = Cursors.WaitCursor;
                dataTable.Rows.Clear();

                foreach (tbl_accGLMaster glMaster in tbl_accGLMaster.SelectAll().Where(p => p.Gl_ID != "default" && p.IsDeleted != true && p.Gl_ID != "<Auto Generated>" && p.Gl_ID != "<Auto Generate>"))
                {
                    tbl_zAccGLMaster_AccountType oAccType = tbl_zAccGLMaster_AccountType.Select(glMaster.GlAccountType_ID);
                    if (oAccType != null)
                    {
                        tbl_zAccGLMaster_SubCatagory oAccSubCatagory = tbl_zAccGLMaster_SubCatagory.Select(oAccType.GlSubCatagory_ID);
                        if (oAccSubCatagory != null)
                        {
                            bool isCreditOpenningBal = false, isDebitOpenningBal = false, isDebitClosingBal = false, isCreditClosingBal = false;
                            decimal dOpeningBalance = 0, dDebitAmount = 0, dCreditAmount = 0, dClosingBalance = 0, dBudget = 0;
                            tbl_accFinancialYearMaster_Month_OpenningBalance findetail = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(glMaster.Gl_ID, sFinancialYear, sMonthID);
                            if (findetail != null)
                            {
                                if (findetail.IsCreditOpening)
                                    isCreditOpenningBal = true;
                                else
                                    isDebitOpenningBal = true;

                                if (findetail.IsCreditClosing)
                                    isCreditClosingBal = true;
                                else
                                    isDebitClosingBal = true;

                                dOpeningBalance = findetail.OpeningBalance;
                                dDebitAmount = findetail.DebitAmount;
                                dCreditAmount = findetail.CreditAmount;
                                dClosingBalance = findetail.ClosingBalance;
                                dBudget = findetail.Budget;
                            }
                            dataTable.Rows.Add(clsGenaralName.getName_GLMainCatagory(oAccSubCatagory.GlMainCatagory_ID), 
                                clsGenaralName.getName_GLSubCatagory(oAccSubCatagory.GlSubCatagory_ID),
                                clsGenaralName.getName_GlAccountType1(glMaster.GlAccountType_ID),
                                glMaster.Gl_ID, clsGenaralName.getName_AccountName(glMaster.Gl_ID), 
                                clsFormatter.FormatToCurrecyWithThousendSep(dOpeningBalance),
                                isDebitOpenningBal ? clsFormatter.FormatToCurrecyWithThousendSep(dOpeningBalance) : clsFormatter.FormatToCurrecyWithThousendSep(0),
                                isCreditOpenningBal ? clsFormatter.FormatToCurrecyWithThousendSep(dOpeningBalance) : clsFormatter.FormatToCurrecyWithThousendSep(0), 
                                clsFormatter.FormatToCurrecyWithThousendSep(dClosingBalance),
                                isDebitClosingBal, isCreditClosingBal, 
                                clsFormatter.FormatToCurrecyWithThousendSep(dBudget));
                        }
                    }
                }
                bindingSource.DataSource = dataTable;
                CalculateCreditDebit();
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


        #region Clear Fields
        private void ClearFields()
        {
            //IsUpdate = false;                       
            //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtFinYear, true);

            //txtFinYear.Tag = null;

            //txtFinYear.Clear();

            //ClearFilters();

            //txtDebit.Text = "0.00";
            //txtCredit.Text = "0.00";
            //txtBalance.Text = "0.00";

            //bShowMessages = false;

            //bindingSource.Filter = string.Empty;

            ////cmbMonth.SelectedIndex = -1;            
            //cmbMonth.SelectedIndex = 3;     
            //dataTable.Rows.Clear();

        }
        private void ClearFilters()
        {
            //txtSubGLCode.Tag = null;
            //txtGLCode.Tag = null;
            //txtAccountName.Tag = null;
            //txtAcctType.Tag = null;

            //txtSubGLCode.Clear();
            //txtGLCode.Clear();
            //txtAccountName.Clear();
            //txtAcctType.Clear();

            bindingSource.Filter = string.Empty;
        }
        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            dataTable.Columns.Clear();
            dataTable.Columns.Add("GLName", typeof(string));
            dataTable.Columns.Add("SUBGLName", typeof(string));
            dataTable.Columns.Add("AcctTypeName", typeof(string));
            dataTable.Columns.Add("AccCode", typeof(string));
            dataTable.Columns.Add("AccName", typeof(string));
            dataTable.Columns.Add("openbalance");
            dataTable.Columns.Add("DebitAmount");
            dataTable.Columns.Add("CreditAmount");
            dataTable.Columns.Add("closeBalance");
            dataTable.Columns.Add("IsClosingBalDebit", typeof(bool));
            dataTable.Columns.Add("IsClosingBalCredit", typeof(bool));
            dataTable.Columns.Add("budget");                                   
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_TextBoxes())
            {
                if (CheckNumberValidity())
                {
                    if (CheckOPbalanceValidity())
                    {
                        if (CheckValidity_DebitAndCreditAmount())
                        {
                            bStatus = true;
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_TextBoxes()
        {
            string strMessage = "";
            //bool bStatus = true;

            //if (txtFinYear.TextLength == 0)
            //{
            //    strMessage += "\n" + "FinYear Name ";
            //    bStatus = false;
            //}
            //if (cmbMonth.Text.Trim().Length == 0)
            //{
            //    strMessage += "\n" + "Month Name ";
            //    bStatus = false;
            //}

            //if (bStatus == false)
            //    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return bStatus;
            return true;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {

                //tbl_accFinancialYearMaster_Month FYM_detail = tbl_accFinancialYearMaster_Month.Select(txtFinYear.Tag.ToString(), cmbMonth.Text);
                //if (FYM_detail != null)
                //{
                //    if (FYM_detail.IsMonthClose)
                //    {
                //        bStatus = false;
                //        strMessage = " Month is Already Closed ";
                //    }
                //}


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

        private bool CheckOPbalanceValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                //if (txtFinYear.Tag.ToString() != txtFinYear.Tag.ToString() || clsMethods_GL.accountTXNStartMonth() != cmbMonth.Text)
                //{
                //    strMessage += "\n" + " Pleace enter your opanning balance to account system start date ";
                //    bStatus = false;
                //}
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

        private bool CheckValidity_DebitAndCreditAmount()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                //if (double.Parse(txtCredit.Text.Trim()) != double.Parse(txtDebit.Text.Trim()))
                //{
                //    if (double.Parse(txtBalance.Text.Trim()) != 0.00)
                //    {
                //        strMessage += "Debit Total And Credit Total Should Be Equal ";
                //        bStatus = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

            if (bStatus == false)
            {
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool ValidatePosting()
        {

            //string sMessage = "";
            bool bValidate = true;
            //if (txtFinYear.Tag != null && cmbMonth.SelectedText.Length > 0)
            //{
            //    DateTime Date = clsMethods_GL.GetDateFinancialYearDate(txtFinYear.Tag.ToString(), cmbMonth.Text.ToString());



            //    List<tbl_sasInvoice> INVdetailSales = tbl_sasInvoice.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    foreach (tbl_sasInvoice INVdetailSale in INVdetailSales)
            //    {
            //        if (INVdetailSale.InvoiceDate.Month == Date.Month && INVdetailSale.InvoiceDate.Year == Date.Year && INVdetailSale.IsDebitNote == false && INVdetailSale.IsOpeningBalance == false && INVdetailSale.IsReturnedCheque == false && INVdetailSale.IsDeleted == false)
            //        {
            //            bValidate = false;
            //            sMessage += "Invoice";
            //            break;
            //        }
            //    }
            //    //if (clsConfig.bValidate_CostCalculatedByInvoiceNotDO)
            //    //{
            //    //    List<tbl_sasInvoice> INVdetailCosts = tbl_sasInvoice.SelectAll().Where(p => p.PostingStatus_ID2 == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    //    foreach (tbl_sasInvoice INVdetailCost in INVdetailCosts)
            //    //    {
            //    //        if (INVdetailCost.InvoiceDate.Month == Date.Month && INVdetailCost.InvoiceDate.Year == Date.Year && INVdetailCost.IsDebitNote == false && INVdetailCost.IsOpeningBalance == false && INVdetailCost.IsReturnedCheque == false && INVdetailCost.IsDeleted == false)
            //    //        {
            //    //            bValidate = false;
            //    //            sMessage += " DO Costing Invoice ";
            //    //            break;
            //    //        }
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    List<tbl_sasDeliveryOrder> Dodetails = tbl_sasDeliveryOrder.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    //    foreach (tbl_sasDeliveryOrder Dodetail in Dodetails)
            //    //    {
            //    //        if (Dodetail.DeliveryOrderDate.Month == Date.Month && Dodetail.DeliveryOrderDate.Year == Date.Year && Dodetail.IsDeleted == false)
            //    //        {
            //    //            bValidate = false;
            //    //            sMessage += "DO Costing";
            //    //            break;
            //    //        }
            //    //    }
            //    //}
            //    List<tbl_bpsReceipt> ReceiptDetails = tbl_bpsReceipt.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    foreach (tbl_bpsReceipt ReceiptDetail in ReceiptDetails)
            //    {
            //        if (ReceiptDetail.ReceiptDate.Month == Date.Month && ReceiptDetail.ReceiptDate.Year == Date.Year && ReceiptDetail.IsDeleted == false && ReceiptDetail.CashAmount > 0)
            //        {
            //            bValidate = false;
            //            sMessage += " Receipt ";
            //            break;
            //        }
            //    }
            //    //List<tbl_bpsReceipt> RCPdetails = tbl_bpsReceipt.SelectAll();//TODO 
            //    //foreach (tbl_bpsReceipt RCPdetail in RCPdetails)
            //    //{
            //    //    if (RCPdetail.ReceiptDate.Month == Date.Month && RCPdetail.ReceiptDate.Year == Date.Year )
            //    //    {
            //    //        List<tbl_bpsChequeRegister> CRDetails = tbl_bpsChequeRegister.SelectAllByReceipt_ID(RCPdetail.Receipt_ID).Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    //        foreach (tbl_bpsChequeRegister CRDetail in CRDetails)
            //    //        {
            //    //            bValidate = false;
            //    //            sMessage += CRDetail.Receipt_ID;
            //    //            sMessage += " Cheque ";
            //    //            break;
            //    //        }
            //    //    }
            //    //}
            //    List<tbl_bpsCreditNote> CNDetails = tbl_bpsCreditNote.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    foreach (tbl_bpsCreditNote CNDetail in CNDetails)
            //    {
            //        if (CNDetail.CreditNoteDate.Month == Date.Month && CNDetail.CreditNoteDate.Year == Date.Year && CNDetail.IsDeleted == false)
            //        {
            //            bValidate = false;
            //            sMessage += " Credit Note ";
            //            break;
            //        }
            //    }
            //    List<tbl_bpsDebitNote> DBDetails = tbl_bpsDebitNote.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    foreach (tbl_bpsDebitNote DBDetail in DBDetails)
            //    {
            //        if (DBDetail.DebitNoteDate.Month == Date.Month && DBDetail.DebitNoteDate.Year == Date.Year && DBDetail.IsDeleted == false)
            //        {
            //            bValidate = false;
            //            sMessage += " Debit Note ";
            //            break;
            //        }
            //    }
            //    List<tbl_sasSalesReturnedNote> SRNdetails = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    foreach (tbl_sasSalesReturnedNote SRNdetail in SRNdetails)
            //    {
            //        if (SRNdetail.SalesReturnedNoteDate.Month == Date.Month && SRNdetail.SalesReturnedNoteDate.Year == Date.Year && SRNdetail.IsDeleted == false)
            //        {
            //            bValidate = false;
            //            sMessage += " Sales Returned Note";
            //            break;
            //        }
            //    }

            //    List<tbl_scsExternalGoodReceivedNote> GRNDetails = tbl_scsExternalGoodReceivedNote.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)).ToList();
            //    foreach (tbl_scsExternalGoodReceivedNote GRNDetail in GRNDetails)
            //    {
            //        if (GRNDetail.ExternalGoodReceivedNoteDate.Month == Date.Month && GRNDetail.ExternalGoodReceivedNoteDate.Year == Date.Year && GRNDetail.IsDeleted == false)
            //        {
            //            bValidate = false;
            //            sMessage += " Good Received Note ";
            //            break;
            //        }
            //    }

            //    if (!bValidate)
            //    {
            //        MessageBox.Show(" " + sMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            return bValidate;
        }

        private bool ValidatePreviousMonth()
        {
            //string sMessage = "";
            bool bValidate = true;
            //DateTime Date = clsFormatter.GetDateFinancialYearDate(txtFinYear.Tag.ToString(), cmbMonth.Text.ToString());

            //tbl_accFinancialYearMaster_Month FYM_detail = tbl_accFinancialYearMaster_Month.Select(txtFinYear.Text, clsFormatter.GetMonthName(Date.Month - 1));
            //if (FYM_detail == null)
            //{
            //    MessageBox.Show("Please close the previous month ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //bValidate = false;
            //}

            return bValidate;
        }

        #endregion

        #region Binding Source Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";
                bindingSource.Filter = "";

                //if (argText.Name == txtAccountName.Name)
                //    sTemp = " AccName LIKE '%" + txtAccountName.Text.Trim() + "%'";
                //if (argText.Name == txtAcctType.Name)
                //    sTemp = " AcctTypeName LIKE '%" + txtAcctType.Text.Trim() + "%'";
                //if (argText.Name == txtSubGLCode.Name)
                //    sTemp = " SUBGLName LIKE '%" + txtSubGLCode.Text.Trim() + "%'";
                //if (argText.Name == txtGLCode.Name)
                //    sTemp = " GLName LIKE '%" + txtGLCode.Text.Trim() + "%'";

                if (sTemp.Trim().Length > 0)
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFinalQuary = sFilteQuary + " AND " + sTemp;
                    else
                        sFinalQuary = sTemp;
                }

                if (sFinalQuary.Trim().Length > 0)
                    bindingSource.Filter = sFinalQuary;
                else
                    bindingSource.Filter = sTemp;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Event KeyUp
        private void txtAccountName_KeyUp(object sender, KeyEventArgs e)
        {
            //createFilterQuary(txtAccountName);
        }

        private void txtAcctType_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtAcctType);
        }

        private void txtSubGLCode_KeyUp(object sender, KeyEventArgs e)
        {
            //createFilterQuary(txtSubGLCode);
        }
        private void txtGLCode_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        #endregion 
        
        #region Event Click
        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (cmbMonth.SelectedIndex < 11) 
            //{
            //    if (txtFinYear.Text.Length > 0)
            //    {
            //        cmbMonth.SelectedIndex = ++cmbMonth.SelectedIndex;
            //        RefreshGridForMonth(txtFinYear.Tag.ToString(), cmbMonth.Text);
            //    }
            //    else 
            //        MessageBox.Show("Please select financial year", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);           
            //}                           
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            //if (cmbMonth.SelectedIndex > 0) 
            //{
            //    if (txtFinYear.Text.Length > 0) 
            //    {
            //        cmbMonth.SelectedIndex = --cmbMonth.SelectedIndex;
            //        RefreshGridForMonth(txtFinYear.Tag.ToString(), cmbMonth.Text);
            //    }
            //    else
            //        MessageBox.Show("Please select financial year", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);            
            //}            
        }
        #endregion

        #region Event Grid
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                    if (sColName == "DebitAmount")
                    {
                        decimal sDebitAmount = clsValidate.ValidateGridValue(dgvDetail, "DebitAmount", e.RowIndex, decimal.Parse("0.00"));
                        dgvDetail["DebitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(sDebitAmount);
                    }
                    if (sColName == "CreditAmount")
                    {
                        decimal sCreditAmount = clsValidate.ValidateGridValue(dgvDetail, "CreditAmount", e.RowIndex, decimal.Parse("0.00"));
                        dgvDetail["CreditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(sCreditAmount);
                    }
                    CalculateCreditDebit();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "DebitAmount" || sColName == "CreditAmount")
                {
                    if (!clsCommon.isCurrency(e.Value.ToString()))
                    {
                        if (sColName == "DebitAmount")
                            dgvDetail["DebitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);

                        if (sColName == "CreditAmount")
                            dgvDetail["CreditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion
        
        #region Event Double Click
        private void txtFinYear_DoubleClick(object sender, EventArgs e)
        {
            //Search_FinancialID();
            //if (txtFinYear.Text.Length > 0)
            //{
            //    RefreshGridForMonth(txtFinYear.Tag.ToString(), cmbMonth.Text);
            //    CalculateCreditDebit();
            //}
        }
        private void txtAcctTypeSubGlCode_DoubleClick(object sender, EventArgs e)
        {
            SearchSubledgerSubGLCode();
        }

        private void txtAcctCodeTypeCode_DoubleClick(object sender, EventArgs e)
        {
            SearchAcctType();
        }

        #endregion

        #region  Event Key Down
        private void txtFinYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_FinancialID();
        }
        #endregion

        #region Event Selected Value Changed
        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            
            //if (txtFinYear.Text.Length > 0) 
            //{
            //    RefreshGridForMonth(txtFinYear.Tag.ToString(), cmbMonth.Text);
            //    CalculateCreditDebit();
            //}

            //else
            //if(bShowMessages)
            //    MessageBox.Show("Please select financial year", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Search Methods
        private void Search_FinancialID()
        {
            try
            {
                //clsSearch.Search_FinancialID(ref txtFinYear);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
      
        private void SearchSubledgerSubGLCode()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void SearchAcctType()
        {
            try
            {
                clsSearch.Search_AccountType(txtAcctType, null, "", false);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        #region Old Search
        //public static void passValue_SubledgerSubGLCode(TextBox SubGlCode)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_zAccGLMaster_SubCatagory ";
        //    frmSearchMaster.s_Columns = " glSubCatagory_ID [Sub General Ledger Code], glSubCatagoryName [Sub General Ledger Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.s_Criteria = "glSubCatagory_ID != 'default'";

        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        SubGlCode.Tag = frmSearchMaster.s_SearchID;

        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //    {
        //        SubGlCode.Tag = frmSearchMaster.s_SearchID;
        //        SubGlCode.Text = frmSearchMaster.s_SearchText;
        //    }
        //}
        //public static void SearchValue_AcctType(TextBox txtAcctTypeCode)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_zAccGLMaster_AccountType ";
        //    frmSearchMaster.s_Columns = " glAccountType_ID [Account Type Code], glAccountTypeName [Account Type Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.s_Criteria = "glAccountType_ID != 'default'";

        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtAcctTypeCode.Tag = frmSearchMaster.s_SearchID;

        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //    {
        //        txtAcctTypeCode.Text = frmSearchMaster.s_SearchID;
        //        txtAcctTypeCode.Text = frmSearchMaster.s_SearchText;
        //    }
        //} 
        #endregion

        
        #endregion

        #region insert update Tabales
        public void InsertHederTabale(string sFinYear , string sMonth )
        {
            tbl_accFinancialYearMaster oldRecord = tbl_accFinancialYearMaster.Select(sFinYear);
            if (oldRecord == null)
            {
                //tbl_accFinancialYearMaster detail = new tbl_accFinancialYearMaster(sFinYear, sFinYear,
                //                   sFinYear, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                //                     1, 0, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                //                   clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.UserIDLoged, clsSecurity.TerminalID,
                //                  clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                //                   clsSecurity.getServerDateTime(), false, false, false, false, false, false, false, false, false);
                //detail.Insert();
            }
            tbl_accFinancialYearMaster_Month FYM_detail = tbl_accFinancialYearMaster_Month.Select(sFinYear, sMonth);
            if (FYM_detail == null)
            {
                //clsMethods_GL.GetDateFinancialYearDate(sFinYear, sMonth)
                tbl_accFinancialYearMaster_Month detail = new tbl_accFinancialYearMaster_Month(sFinYear, sMonth, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false,
                    clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(),
                             clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                            clsSecurity.TerminalID, clsSecurity.TerminalID,
                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                detail.Insert();
            }
        }

        public void UpdateHederTabale()
        {
            //DateTime Date = clsMethods_GL.GetDateFinancialYearDate(txtFinYear.Tag.ToString(), cmbMonth.Text.ToString());

            ////tbl_accFinancialYearMaster_Month FYMClosingdate = tbl_accFinancialYearMaster_Month.Select(txtFinYear.Tag.ToString() , cmbMonth.Text.ToString());
            //if (FYMClosingdate != null)
            //{
            //    FYMClosingdate.IsMonthClose = true;
            // //   FYMClosingdate.MonthCloseDate = clsMethods_GL.GetDateFinancialYearDate(txtFinYear.Tag.ToString(), clsFormatter.GetMonthName(Date.Month+1));
            //    FYMClosingdate.Update();
            //}
            //tbl_accFinancialYearMaster_Month FYMOpaniningdate = tbl_accFinancialYearMaster_Month.Select(txtFinYear.Tag.ToString(), cmbMonth.Text.ToString());
            //if (FYMOpaniningdate != null)
            //{
            //    FYMOpaniningdate.IsMonthClose = true;
            //    //opaningbalance
            //    FYMOpaniningdate.MonthCloseDate = clsFormatter.GetDateFinancialYearDate(txtFinYear.Tag.ToString(), clsFormatter.GetMonthName(Date.Month + 1));
            //    FYMOpaniningdate.Update();
            //}
        } 
        #endregion  

        #region Calculate Credit Debit
        private void CalculateCreditDebit()
        {
            if (dgvDetail.RowCount > 0)
            {
                decimal dCredit = 0, dDebit = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {                    
                    dCredit += clsValidate.ValidateGridValue(dgvDetail, "DebitAmount", row.Index, decimal.Parse("0.00"));                            
                    dDebit += clsValidate.ValidateGridValue(dgvDetail, "CreditAmount", row.Index, decimal.Parse("0.00"));
                }
                //txtCredit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCredit);
                //txtDebit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebit);
                //txtBalance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebit - dCredit);
            }
        }

        #endregion

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

#region Btn Open Balance
//private void btnOpen_Click(object sender, EventArgs e)
//{
//    if (CheckValidity_TextBoxes())
//    {
//        if (CheckNumberValidity())
//        {
//            if (ValidatePosting())
//            {
//                if (ValidatePreviousMonth())
//                {
//                    DateTime Date = clsFormatter.GetDateFinancialYearDate(txtFinYear.Tag.ToString(), cmbMonth.Text.ToString());

//                    InsertHederTabale(txtFinYear.Tag.ToString(), cmbMonth.Text.ToString());
//                    InsertHederTabale(txtFinYear.Tag.ToString(), clsFormatter.GetMonthName(Date.Month + 1));

//                    string sYearID = txtFinYear.Tag.ToString();
//                    string sMonthID = "";
//                    decimal dOpeningBalance = 0, dClosingBalance = 0, //dBudget = 0,
//                    dDebitAmount = 0, dCreditAmount = 0, //dOPCreditAmount = 0, dOPDebitAmount = 0, 
//                    dthisMonthdDebitAmount, dthisMonthddCreditAmount;
//                    bool isOpenningCredit = false, isCloseingCredit = false;


//                    List<tbl_accGLMaster> glMasters = tbl_accGLMaster.SelectAll();
//                    foreach (tbl_accGLMaster glMaster in glMasters)
//                    {
//                        if (glMaster.Gl_ID != "default")
//                        {
//                            dDebitAmount = 0;
//                            dCreditAmount = 0;

//                            #region Get Debit Credits Amount This Month
//                            List<tbl_accGLPosting_Detail> GLpostingDetails = tbl_accGLPosting_Detail.SelectAllByGl_ID(glMaster.Gl_ID);
//                            foreach (tbl_accGLPosting_Detail GLpostingDetail in GLpostingDetails)
//                            {
//                                #region This Month Closing Balance
//                                if (Date <= GLpostingDetail.TransactionDate && GLpostingDetail.TransactionDate < Date.AddMonths(1))
//                                {
//                                    if (GLpostingDetail.IsCredit)
//                                        dCreditAmount = dCreditAmount + GLpostingDetail.Amount;
//                                    else
//                                        dDebitAmount = dDebitAmount + GLpostingDetail.Amount;
//                                }
//                                #endregion
//                            }
//                            #endregion

//                            dthisMonthdDebitAmount = dDebitAmount;
//                            dthisMonthddCreditAmount = dCreditAmount;

//                            #region Previous Month Openning Balance
//                            tbl_accFinancialYearMaster_Month_OpenningBalance OPdetail = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(glMaster.Gl_ID, sYearID, clsFormatter.GetMonthName(Date.Month - 1));
//                            if (OPdetail != null)
//                            {
//                                if (OPdetail.IsCreditClosing)
//                                    dCreditAmount = dCreditAmount + OPdetail.ClosingBalance;
//                                else
//                                    dDebitAmount = dDebitAmount + OPdetail.ClosingBalance;

//                                dOpeningBalance = OPdetail.ClosingBalance;
//                                isOpenningCredit = OPdetail.IsCreditClosing;
//                            }
//                            #endregion


//                            #region Closing Total Amount Balance
//                            if (dCreditAmount > dDebitAmount)
//                            {
//                                dClosingBalance = dCreditAmount - dDebitAmount;
//                                isCloseingCredit = true;
//                            }
//                            else
//                            {
//                                dClosingBalance = dDebitAmount - dCreditAmount;
//                                isCloseingCredit = false;
//                            }
//                            #endregion

//                            #region Udate Or Insert To Closing month  Month Table
//                            tbl_accFinancialYearMaster_Month_OpenningBalance detailSelect = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(glMaster.Gl_ID, sYearID, cmbMonth.Text.ToString());
//                            if (detailSelect != null)
//                            {
//                                tbl_accFinancialYearMaster_Month_OpenningBalance detail = new tbl_accFinancialYearMaster_Month_OpenningBalance(glMaster.Gl_ID, sYearID, cmbMonth.Text.ToString(), dOpeningBalance, isOpenningCredit, dClosingBalance, isCloseingCredit, dthisMonthdDebitAmount, dthisMonthddCreditAmount, 0);
//                                detail.Update();
//                            }
//                            else
//                            {
//                                tbl_accFinancialYearMaster_Month_OpenningBalance detail = new tbl_accFinancialYearMaster_Month_OpenningBalance(glMaster.Gl_ID, sYearID, cmbMonth.Text.ToString(), dOpeningBalance, isOpenningCredit, dClosingBalance, isCloseingCredit, dthisMonthdDebitAmount, dthisMonthddCreditAmount, 0);
//                                detail.Insert();
//                            }
//                            #endregion


//                            #region Udate or Insert To Next Closing month  Month Table
//                            sMonthID = cmbMonth.Text.ToString();
//                            tbl_accFinancialYearMaster_Month_OpenningBalance NXMDetailSelect = tbl_accFinancialYearMaster_Month_OpenningBalance.Select(glMaster.Gl_ID, sYearID, clsFormatter.GetMonthName(Date.Month + 1));
//                            if (NXMDetailSelect != null)
//                            {
//                                tbl_accFinancialYearMaster_Month_OpenningBalance detail = new tbl_accFinancialYearMaster_Month_OpenningBalance(glMaster.Gl_ID, sYearID, clsFormatter.GetMonthName(Date.Month + 1), dClosingBalance, isCloseingCredit, 0, isCloseingCredit, 0, 0, 0);
//                                detail.Update();
//                            }
//                            else
//                            {
//                                // TO do
//                                tbl_accFinancialYearMaster_Month_OpenningBalance detail = new tbl_accFinancialYearMaster_Month_OpenningBalance(glMaster.Gl_ID, sYearID, clsFormatter.GetMonthName(Date.Month + 1), dClosingBalance, isCloseingCredit, 0, isCloseingCredit, 0, 0, 0);
//                                detail.Insert();
//                            }
//                            #endregion

//                        }
//                    }

//                    UpdateHederTabale();
//                    RefreshGridForMonth(txtFinYear.Tag.ToString(), cmbMonth.Text);
//                }

//            }
//        }
//    }
//}
#endregion

#region Fill Datagrid
//private bool Fill_Datagrid(int iRow,string sSubGLCode, string sAcctType, string sAcctCode, decimal dOpenBal, bool bDebitOrCredit)
//{
//    bool bComplete = false;
//    try
//    {
//        dgvDetail["SUBGLName", iRow].Tag = sSubGLCode;
//        dgvDetail["AcctTypeName", iRow].Tag = sAcctType;
//        dgvDetail["SUBGLName", iRow].Value = clsGenaralName.getName_GLSubCatagory(sSubGLCode);
//        dgvDetail["AcctTypeName", iRow].Value = clsGenaralName.getName_GlAccountType(sAcctType);
//        dgvDetail["GL_code", iRow].Value = sAcctCode;
//        dgvDetail["GLName", iRow].Value = clsGenaralName.getName_AccountName(sAcctCode);
//        dgvDetail["openbalance", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dOpenBal);

//        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dgvDetail["IsOpenningBalance", iRow];
//        cell.Items[0] = bDebitOrCredit ? "Cr" : "Dr";
//        (dgvDetail["IsOpenningBalance", iRow] as DataGridViewComboBoxCell).Value = (dgvDetail["IsOpenningBalance", iRow] as DataGridViewComboBoxCell).Items[0];
//        //cell.FlatStyle = FlatStyle.System;
//        DataGridViewComboBoxCell cell2 = (DataGridViewComboBoxCell)dgvDetail["IsClosingBalance", iRow];
//        cell2.Items[0] = bDebitOrCredit ? "Cr" : "Dr";
//        (dgvDetail["IsClosingBalance", iRow] as DataGridViewComboBoxCell).Value = (dgvDetail["IsClosingBalance", iRow] as DataGridViewComboBoxCell).Items[0];

//        bComplete = true;
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//    return bComplete;
//}
#endregion