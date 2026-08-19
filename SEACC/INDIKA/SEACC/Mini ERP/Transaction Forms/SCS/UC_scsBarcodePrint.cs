using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using DataTire;
using Zion.ERP.Reports.DataSets;
using Zion.ERP.Reports.DataSets.SCS;
using CrystalDecisions.CrystalReports.Engine;
using ZION.ERP.Reports.DataSets.SCS;

namespace Digiteq
{
    public partial class UC_scsBarcodePrint : SEACC_Form
    {
        
        DataTable dt_GLP = new DataTable();

        public bool bHasChecked;
        public bool bHasApproved;

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Accounts glb_dts_Accounts = new dts_Accounts();
        dts_scsBarcode glb_dts_scsBarcode = new dts_scsBarcode();


        #region Form Load
        public UC_scsBarcodePrint(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
            CusDataGridViewFormat();
        }
        private void CusDataGridViewFormat()
        {
            //if (enmForm == FormName.accJournalEntry_Creditor)
            //{
            //    dgvDetail.Columns["Supplier_Name"].Visible = true;
            //    dgvDetail.Columns["customer_Name"].Visible = false;
            //}
            //else if (enmForm == FormName.accJournalEntry_Debtor)
            //{
            //    dgvDetail.Columns["Supplier_Name"].Visible = false;
            //    dgvDetail.Columns["customer_Name"].Visible = true;
            //}
        }
        private void UC_AccJournalEntry_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, false, false, false, false, false, false, false);

            clsFill.Fill_ItemPrices(ref cmbItemPrice);

            if (cmbItemPrice.Items.Count > 0)
                cmbItemPrice.SelectedIndex = 0;

            ClearFields();
        }
        #endregion       

        #region Btn New
        private void UC_AccJournalEntry_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion       

        #region Btn Print
        private void UC_AccJournalEntry_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion     

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        glb_dts_scsBarcode.dt_ItemBarcode.Rows.Clear();
                        int iCopies = 1;
                      
                        string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        string sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
                        decimal dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        decimal dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        iCopies = int.Parse(dQuantity.ToString()); //casting the qty
                        byte[] barcodeArray = clsUtil.GetBarcode(sItemCode); //get the barcode
                        glb_dts_scsBarcode.dt_ItemBarcode.Adddt_ItemBarcodeRow(sItemCode, sItemName, dUnitPrice, barcodeArray);

                        string sReportPath = "\\Reports\\SCS\\NotePrinting\\rpt_scsItemBarcode.rpt";
                        print_Direct(sReportPath, glb_dts_scsBarcode, iCopies);
                    }
                    catch (Exception ex)
                    {
                        SEACCException.Show(ex);
                        clsValidate.WriteErrorLog("", iFormID,ex);
                    }
                    finally
                    {
                        glb_dts_scsBarcode.dt_ItemBarcode.Rows.Clear();
                    }
                }
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
        public static void print_Direct(string path, DataSet ojbDataSet, int iNoOfCopies)
        {
            try
            {
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet);
               
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                objRpt.PrintToPrinter(iNoOfCopies, false, 0, 0);             

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion



        #region Event Double Click
        private void txtJournalID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_JournalEntry_Trasaction(ref txtJournalID, chkShowSettle.Checked, sFormConfigCode);
            if (txtJournalID.Text != null || txtJournalID.Text.Length > 0)
                FillDetails(txtJournalID.Text.ToString().Trim());
        }

        private void txtGTNID_DoubleClick(object sender, EventArgs e)
        {
            Search_ExternalGoodReceivedNoteID();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
        }
        #endregion

        #region Event KeyDown
        private void txtJournalID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
                txtJournalID_DoubleClick(sender, e);
        }
        private void txtGTNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtGTNID_DoubleClick(null, null);
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtItemID_DoubleClick(null, null);
        }
        #endregion

        #region Event Data Grid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region GL Account
                if (sColName == "accCode" || sColName == "accName")
                {
                    List<string> lstParameeters = new List<string>();
                    lstParameeters.Add("%");
                    lstParameeters.Add("");
                    lstParameeters.Add("-");

                    frmSearch RowDataSearch = new frmSearch(lstParameeters);
                    List<string> lstResult = RowDataSearch.Show(Search.AccName);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        #region Supplier Contral Acc. Selected
                        if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor) == lstResult[2])
                        {
                            if (enmForm == FormName.accJournalEntry_Creditor)
                            {
                                List<string> lstParameeters2 = new List<string>();
                                frmSearch oSearch = null;
                                lstParameeters2.Add(clsSecurity.BranchID);
                                lstParameeters2.Add(lstResult[0]);

                                oSearch = new frmSearch(lstParameeters2);
                                List<string> lstResult2 = oSearch.Show(Search.Supplier_ByControlAcc);

                                if (oSearch.DialogResult == DialogResult.OK)
                                {
                                    string sSupplier_ID = lstResult2[0];
                                    string sGlAcc_Supplier = clsMethods_GL.getAccountCode_Supplier(sSupplier_ID);
                                    if (sGlAcc_Supplier != "default")
                                    {
                                        dgvDetail["Supplier_ID", e.RowIndex].Value = sSupplier_ID;
                                        dgvDetail["Supplier_Name", e.RowIndex].Value = lstResult2[1];
                                        dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Supplier;
                                        dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Supplier);
                                    }
                                }
                            }
                            else
                                System.Windows.Forms.MessageBox.Show("Invalid Gl Account Code.. ", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                        #endregion
                        #region Customer Contral Acc. Selected
                        else if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor) == lstResult[2])
                        {
                            if (enmForm == FormName.accJournalEntry_Debtor)
                            {
                                List<string> lstParameeters2 = new List<string>();
                                frmSearch oSearch = null;
                                lstParameeters2.Add(clsSecurity.BranchID);
                                lstParameeters2.Add(lstResult[0]);

                                oSearch = new frmSearch(lstParameeters2);
                                List<string> lstResult2 = oSearch.Show(Search.Customer_ByControlAcc);

                                if (oSearch.DialogResult == DialogResult.OK)
                                {
                                    string sCustomer_ID = lstResult2[0];
                                    string sGlAcc_Customer = clsMethods_GL.GetAccountCode_Customer(sCustomer_ID);
                                    if (sGlAcc_Customer != "default")
                                    {
                                        dgvDetail["customer_ID", e.RowIndex].Value = sCustomer_ID;
                                        dgvDetail["customer_Name", e.RowIndex].Value = lstResult2[1];
                                        dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Customer;
                                        dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Customer);
                                    }
                                }
                            }
                            else
                                System.Windows.Forms.MessageBox.Show("Invalid Gl Account Code.. ", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                        #endregion
                        else
                        {
                            dgvDetail["AccCode", e.RowIndex].Value = lstResult[0];
                            dgvDetail["AccName", e.RowIndex].Value = lstResult[1];
                            dgvDetail["Supplier_ID", e.RowIndex].Value = "";
                            dgvDetail["Supplier_Name", e.RowIndex].Value = "";
                        }
                    }
                }
                #endregion

                #region Supplier
                else if (sColName == "Supplier_Name")
                {
                    List<string> lstParameeters = new List<string>();
                    frmSearch RowDataSearch = null;
                    lstParameeters.Add(clsSecurity.BranchID);

                    RowDataSearch = new frmSearch(lstParameeters);
                    List<string> lstResult = RowDataSearch.Show(Search.Supplier);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        string sSupplier_ID = lstResult[0];
                        string sGlAcc_Supplier = clsMethods_GL.getAccountCode_Supplier(sSupplier_ID);
                        if (sGlAcc_Supplier != "default")
                        {
                            dgvDetail["Supplier_ID", e.RowIndex].Value = sSupplier_ID;
                            dgvDetail["Supplier_Name", e.RowIndex].Value = lstResult[1];
                            dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Supplier;
                            dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Supplier);
                        }
                        else
                            System.Windows.Forms.MessageBox.Show("Please Link control account to Supplier <" + sSupplier_ID + ">", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
                #endregion

                #region Customer
                else if (sColName == "customer_Name")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.Customer);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        string sCustomer_ID = lstResult[0];
                        string sGlAcc_Customer = clsMethods_GL.GetAccountCode_Customer(sCustomer_ID);
                        if (sGlAcc_Customer != "default")
                        {
                            dgvDetail["customer_ID", e.RowIndex].Value = sCustomer_ID;
                            dgvDetail["customer_Name", e.RowIndex].Value = lstResult[1];
                            dgvDetail["AccCode", e.RowIndex].Value = sGlAcc_Customer;
                            dgvDetail["AccName", e.RowIndex].Value = clsGenaralName.getName_AccountName(sGlAcc_Customer);
                        }
                        else
                            System.Windows.Forms.MessageBox.Show("Please Link control account to cutomer <" + sCustomer_ID + ">", clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
                #endregion
            }
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                decimal dDebitAmount = 0, dCreditAmount = 0;
                string sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region Add Debit Amount
                if (sColName == "debitAmount")
                {
                    string sAccCode = dgvDetail["AccCode", e.RowIndex].Value.ToString();
                    if (sAccCode != "" && sAccCode.Length > 0)
                    {
                        dDebitAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", e.RowIndex, decimal.Parse("0.00"));
                        dgvDetail["debitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount);

                        if (dDebitAmount > 0)
                            dgvDetail["creditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                    else
                        dgvDetail["debitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                #endregion

                #region Credit Amount
                else if (sColName == "creditAmount")
                {
                    string sAccCode = dgvDetail["AccCode", e.RowIndex].Value.ToString();
                    if (sAccCode != "" && sAccCode.Length > 0)
                    {
                        dCreditAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", e.RowIndex, decimal.Parse("0.00"));
                        dgvDetail["creditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount);

                        if (dCreditAmount > 0)
                            dgvDetail["debitAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                    else
                        dgvDetail["creditAmount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                #endregion

                CalcualteCreditDebit();
            }
        }
                
        private void dgvDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            CalcualteCreditDebit();
        }
        #endregion        

        

        #region Clear Field
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            txtGTNID.Tag = null;
            txtItemID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;

            txtGTNID.Clear();
            txtItemID.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();           

            dgvDetail.Rows.Clear();
            dt_GLP.Rows.Clear();            
            dt_GLP.Rows.Clear();
        }
        #endregion        

        #region Refresh Grid
        private void RefreshGrid(string sGrnID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                foreach (tbl_scsExternalGoodReceivedNote_Detail detail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGrnID).OrderBy(p => p.Line_No).ToList())
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    tbl_genItemMaster_Pricing oItem = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                    if (detail != null && oItem != null)
                    {
                        decimal dExRate = 1;                     
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Color cFontColor = detail.BHasBreakDown ? clsConfig.Font_Grid_Locked : clsConfig.Font_Grid_Active;
                        decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, "default");

                        Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.PurchaseOrder_ID,
                           detail.PurchaseReturnedNote_ID, detail.BatchNo, item.IsTIEPItem, detail.Qty, dUnitPrice, 0, detail.Weight, oItem.WeightedAverageCostPrice, detail.TatalAmount, detail.Warranty, detail.Remark, dExRate, cFontColor);
                    }
                }               
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByItemID(string sItemrID)
        {
            try
            {
                int iRow;
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemrID);
                tbl_genItemMaster_Pricing oItem = tbl_genItemMaster_Pricing.Select(sItemrID);
                if (detail != null && oItem != null)
                {
                    decimal dExRate = 1;                   
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                    decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(detail.Item_ID, "default", "default", "0", "0", "default");

                    Fill_Datagrid(iRow, detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(),
                        "default", "default", "", detail.IsTIEPItem, 1, dUnitPrice, 0, 0, 0, 0, 0, detail.Description, dExRate, clsConfig.Font_Grid_Active);
                }              
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        #endregion          

        #region Search Methods
        private void Search_ExternalGoodReceivedNoteID()
        {
            clsSearch.Search_TransactionExternalGoodReceivedNote_Use(ref txtGTNID, false, "");

            if (txtGTNID.Tag != null && txtGTNID.Tag.ToString().Trim().Length > 0)
                RefreshGrid(txtGTNID.Tag.ToString().Trim());
        }
        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                RefreshGridByItemID(txtItemID.Tag.ToString());

        }
        #endregion            



        #region From Previous Form
        #region Btn Save
        private void UC_AccJournalEntry_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    #region Update
                    if (IsUpdate)
                    {
                        tbl_accJournalEntry oldRecord = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                bool bIsSettled = false;
                                foreach (tbl_accJournalEntry_Detail oJEDetail in tbl_accJournalEntry_Detail.SelectAll().Where(p => p.JournalEntry_ID == txtJournalID.Text.Trim() && (p.IsSeattled || p.SeattleAmount > 0)))
                                {
                                    bIsSettled = true;
                                    break;
                                }

                                if (!bIsSettled)
                                {
                                    if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        //    tbl_accGLPosting_Detail_Tmp.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                        tbl_accJournalEntry_Detail.DeleteAllByJournalEntry_ID(txtJournalID.Text.ToString());

                                        #region  Insert Detail - Journal
                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                        {
                                            bool bIsCredit = true;

                                            string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                            string sSupplier_ID = clsValidate.ValidateGridValue(dgvDetail, "Supplier_ID", row.Index, "");
                                            string sCustomer_ID = clsValidate.ValidateGridValue(dgvDetail, "customer_ID", row.Index, "");
                                            string sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                            string sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                            string sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                            int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));

                                            string sAccountNo = "default";
                                            int iCompanyAccID = -1;
                                            foreach (tbl_accGLMaster_Bank oGLBank in tbl_accGLMaster_Bank.SelectAllByGl_ID(sGLCode))
                                            {
                                                foreach (tbl_genCompanyAccount oComAcc in tbl_genCompanyAccount.SelectAll().Where(p => p.AccountNumber == oGLBank.AccountNumber))
                                                {
                                                    iCompanyAccID = oComAcc.CompanyAccount_ID;
                                                }
                                                sAccountNo = oGLBank.AccountNumber;
                                            }

                                            decimal dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                            if (dAmount == 0)
                                            {
                                                dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                                                bIsCredit = false;
                                            }
                                            if (sSupplier_ID == "")
                                                sSupplier_ID = "default";

                                            if (sCustomer_ID == "")
                                                sCustomer_ID = "default";

                                            #region Insert tbl_accJournalEntry_Detail
                                            tbl_accJournalEntry_Detail Insdetail = new tbl_accJournalEntry_Detail(iRow, txtJournalID.Text.Trim(), "default",
                                                sGLCode, sCustomer_ID, sSupplier_ID, "default", sAccountNo, sSubAcct1_ID, sSubAcct2_ID, sRemarks, dAmount, bIsCredit, false, 0, clsSecurity.getServerDateTime(), false, iCompanyAccID, -1);
                                            Insdetail.Insert();
                                            #endregion
                                        }
                                        #endregion

                                        #region  Update Header - Journal
                                        tbl_accJournalEntry detail = new tbl_accJournalEntry(txtJournalID.Text.ToString().Trim(), oldRecord.JournalEntryType_ID, dtpJVDate.Value, txtNarration.Text.ToString().Trim(),
                                                    txtNarration.Text.ToString().Trim(), oldRecord.GlPosting_ID, clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID,
                                                    decimal.Parse(txtTotCredit.Text.ToString().Trim()), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                                    oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                    oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateChecked, oldRecord.DateApproved, oldRecord.DateDeleted, oldRecord.DatePrinted, oldRecord.IsChecked, oldRecord.IsApproved,
                                                    oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsSeattled, oldRecord.PrintCount);
                                        detail.Update();
                                        #endregion

                                        clsMethods_GL.PostTransaction_Journal(txtJournalID.Text.Trim(), sSlotID);

                                        //Attachments.Insert(iFormID, oldRecord.JournalEntry_ID);
                                        //Attachments.Remove(iFormID, oldRecord.JournalEntry_ID);

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Can not Update \nThis Entry is already settled..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        #region Genarate Journal ID
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtJournalID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                        #endregion

                        if (txtJournalID.Text.Length > 0)
                        {
                            #region  Insert Header - Journal
                            tbl_accJournalEntry detail = new tbl_accJournalEntry(txtJournalID.Text.ToString().Trim(), sFormConfigCode, dtpJVDate.Value, txtNarration.Text.ToString().Trim(),
                                                   txtNarration.Text.ToString().Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID,
                                                   decimal.Parse(txtTotCredit.Text.ToString().Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default",
                                                   "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                   clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, false, 0);
                            detail.Insert();
                            #endregion

                            #region  Insert Detail - Journal
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                bool bIsCredit = true;

                                string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                string sSupplier_ID = clsValidate.ValidateGridValue(dgvDetail, "Supplier_ID", row.Index, "");
                                string sCustomer_ID = clsValidate.ValidateGridValue(dgvDetail, "customer_ID", row.Index, "");
                                string sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                string sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                string sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));

                                string sAccountNo = "default";
                                int iCompanyAccID = -1;
                                foreach (tbl_accGLMaster_Bank oGLBank in tbl_accGLMaster_Bank.SelectAllByGl_ID(sGLCode))
                                {
                                    foreach (tbl_genCompanyAccount oComAcc in tbl_genCompanyAccount.SelectAll().Where(p => p.AccountNumber == oGLBank.AccountNumber))
                                    {
                                        iCompanyAccID = oComAcc.CompanyAccount_ID;
                                    }
                                    sAccountNo = oGLBank.AccountNumber;
                                }

                                decimal dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                if (dAmount == 0)
                                {
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                                    bIsCredit = false;
                                }
                                if (sSupplier_ID == "")
                                    sSupplier_ID = "default";

                                if (sCustomer_ID == "")
                                    sCustomer_ID = "default";

                                #region Insert tbl_accJournalEntry_Detail
                                tbl_accJournalEntry_Detail Insdetail = new tbl_accJournalEntry_Detail(iRow, txtJournalID.Text.Trim(), "default",
                                    sGLCode, sCustomer_ID, sSupplier_ID, "default", sAccountNo, sSubAcct1_ID, sSubAcct2_ID, sRemarks, dAmount, bIsCredit, false, 0, clsSecurity.getServerDateTime(), false, iCompanyAccID, -1);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            clsMethods_GL.PostTransaction_Journal(txtJournalID.Text.Trim(), sSlotID);
                            Attachments.Insert(txtJournalID.Text);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(" Entry " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    tbl_accJournalEntry Fdetail = tbl_accJournalEntry.Select(txtJournalID.Text.ToString());
                    if (Fdetail != null)
                        FillDetails(txtJournalID.Text.ToString().Trim());
                }
            }
        }
        #endregion
        #region Btn Cancel
        private void UC_AccJournalEntry_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJournalID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_accJournalEntry detail = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Journal Voucher : " + detail.JournalEntry_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            if (clsHelpMethods_Local.RemoveSattlementsFrom_JournalEntryID(detail.JournalEntry_ID))
                                            {
                                                #region Reverce Posting
                                                // tbl_accGLPosting_Detail_Tmp.DeleteAllByGlPosting_ID(detail.GlPosting_ID);
                                                clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);
                                                #endregion

                                                detail.IsDeleted = true;
                                                detail.DateDeleted = clsSecurity.getServerDateTime();
                                                detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                detail.Update();
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearFields();
                                            }
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
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
        #region Btn Draft
        private void UC_AccJournalEntry_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion
        #region Btn Add n Delete - Data Grid
        private void Btn_AddRow_Click(object sender, EventArgs e)
        {
            if (CheckValidity_AddNewRow())
            {
                dt_GLP.Rows.Add();

                int i = 1;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    row.Cells["Line_No"].Value = i++;
                }
            }
        }
        private void Btn_GridDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedCells.Count > 0)
            {
                dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
            }
        }
        #endregion
        #region Calculation Credit n Debit
        private void CalcualteCreditDebit()
        {
            try
            {
                decimal dCreditAmount = 0, dDebitAmount = 0;

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dCreditAmount += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                    dDebitAmount += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                }

                txtTotCredit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount);
                txtTotCredit.Tag = dCreditAmount;

                txtTotDebit.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount);
                txtTotDebit.Tag = dDebitAmount;

                txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount - dCreditAmount);
                txtDifferance.Tag = (dDebitAmount - dCreditAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, string PurchaseOrderID, string sPRNID, string sBatch, bool bIsTiep, decimal Quantity, decimal UnitPrice, decimal WeightPrice, decimal Weight, decimal WeightAvg,
        decimal Amount, decimal dWarranty, string Remark, decimal dExRate, Color cFontColor)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                    if (ItemID == sItemID && ItemSubCategoryID1 == sItemSub && ItemSubCategoryID2 == sItemSub2 && ItemSerialNo1 == sSerial && ItemSerialNo2 == sSerial2)
                    {
                        dgvDetail.Rows.RemoveAt(iRow);
                        Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        Quantity += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        iRow = row.Index;
                    }
                }

                //Grid Locks
                dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_GRN ? true : false;

                //Get Unit Price with Exchange rate to save
                UnitPrice = getDisplayUnitPrice(UnitPrice, dExRate);
                WeightPrice = getDisplayUnitPrice(WeightPrice, dExRate);
                Amount = getDisplayUnitPrice(Amount, dExRate);
                WeightAvg = getDisplayUnitPrice(WeightAvg, dExRate);

                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                //
                dgvDetail["ItemSubCategoryID1", iRow].Tag = ItemSubCategoryID1;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = ItemSubCategoryID2;
                //
                dgvDetail["ItemSerialNo1", iRow].Value = ItemSerialNo1;
                dgvDetail["ItemSerialNo2", iRow].Value = ItemSerialNo2;
                dgvDetail["POID", iRow].Value = PurchaseOrderID;//add by thilina
                dgvDetail["PRNID", iRow].Value = sPRNID;
                dgvDetail["Batch", iRow].Value = sBatch;
                dgvDetail["IsTiep", iRow].Value = bIsTiep;
                dgvDetail["Warranty", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(dWarranty);
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_ItemUOM(ItemID);
                dgvDetail["Remarks", iRow].Value = Remark;

                if (clsCommon.IsCustomerizedGrid())
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatToNumberNoDecimal(Quantity);
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                    dgvDetail["Amount", iRow].Tag = Amount;

                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(UnitPrice);
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightPrice);
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["WeightAvg", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightAvg);
                }
                else
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatToNumberNoDecimal(System.Convert.ToDecimal(Quantity.ToString()));
                    dgvDetail["UnitPrice", iRow].Value = UnitPrice.ToString();
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(System.Convert.ToDecimal(Weight.ToString()));
                    dgvDetail["WeightPrice", iRow].Value = WeightPrice.ToString();
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["WeightAvg", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(WeightAvg);
                    dgvDetail["Amount", iRow].Value = Amount.ToString();
                    dgvDetail["Amount", iRow].Tag = Amount;

                }
                dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = cFontColor;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #region Fill Detail GL Code
        private void FillDetailGLCodes(string sJournalEntry_ID)
        {
            dt_GLP.Rows.Clear();

            foreach (tbl_accJournalEntry_Detail detail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntry_ID))
            {
                decimal dDebitAmount = 0, dCreditAmount = 0;
                if (!detail.IsCredit)
                    dDebitAmount = detail.Amount;
                else
                    dCreditAmount = detail.Amount;

                dt_GLP.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Supplier_ID, clsGenaralName.getName_Supplier(detail.Supplier_ID), detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID), clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount), clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount), detail.Remarks);
            }
        }
        #endregion
        #region Fill Details
        private void FillDetails(string sJournalID)
        {
            try
            {
                if (sJournalID.Length > 0 && sJournalID != "<Auto Generate>")
                {
                    ClearFields();
                    tbl_accJournalEntry detail = tbl_accJournalEntry.Select(sJournalID);
                    if (detail != null)
                    {
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtJournalID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblJournalID, false);
                        clsCommon.SetEnableDisable_NormalCheckBox(chkShowSettle, false);

                        txtJournalID.Text = sJournalID;
                        dtpJVDate.Value = detail.JournalEntryDate;
                        txtNarration.Text = detail.Narration;
                        txtTotCredit.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        txtTotDebit.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                        txtDifferance.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal - detail.GrandTotal);

                        bHasApproved = detail.IsApproved;
                        bHasChecked = detail.IsChecked;

                        userDetailsColorChanges();

                        FillDetailGLCodes(sJournalID);
                        //RefreshGrid(sJournalID);  
                        //RefreshGrid();

                        Attachments.FillAttachments(sJournalID);
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
        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
                    {
                        if (CheckValidity_Grid())
                            bStatus = true;
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_AddNewRow()
        {
            bool bStatus = true;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));
                string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                decimal dAmountCr = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                decimal dAmountDb = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                if (sGLCode == "" || dAmountCr + dAmountDb == 0)
                {
                    MessageBox.Show("Please complete Transaction line " + iRow.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                    break;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_Grid()
        {
            bool bStatus = true;
            int iConAccCount_CR = 0, iConAccCount_DB = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                int iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));
                string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                decimal dAmountCr = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                decimal dAmountDb = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                string sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                string sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");

                if (sGLCode == "" || dAmountCr + dAmountDb == 0)
                {
                    MessageBox.Show("Please complete Transaction line " + iRow.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                    break;
                }
                if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor) == clsGenaralName.getName_controlAccountTypeByGLID(sGLCode))
                    iConAccCount_CR++;

                if (clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor) == clsGenaralName.getName_controlAccountTypeByGLID(sGLCode))
                    iConAccCount_DB++;

                if (sSubAcct1_ID == null || sSubAcct1_ID == "")
                    dgvDetail["subAcc1", row.Index].Value = "default";

                if (sSubAcct2_ID == null || sSubAcct2_ID == "")
                    dgvDetail["subAcc2", row.Index].Value = "default";
            }

            if (enmForm == FormName.accJournalEntry_Creditor)
            {
                if (iConAccCount_CR == 0)
                {
                    MessageBox.Show("Please select Creditor Account(s) to Proceed..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
                if (iConAccCount_DB != 0)
                {
                    MessageBox.Show("Sorry...!/nYou Cannot select Debter Account(s) in Crediter journal..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
            }
            else if (enmForm == FormName.accJournalEntry_Debtor)
            {
                if (iConAccCount_DB == 0)
                {
                    MessageBox.Show("Please select Debter Account(s) to Proceed..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
                if (iConAccCount_CR != 0)
                {
                    MessageBox.Show("Sorry...!/nYou Cannot select Crediter Account(s) in Crediter Debter journal..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bStatus = false;
                }
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            CalcualteCreditDebit();

            if (txtDifferance.Text == "" || decimal.Parse(txtDifferance.Text.Trim()) != 0)
            {
                strMessage += "\n" + "Debit totals should be same as credit totals to process this journal entry! ";
                bStatus = false;
            }
            if (dgvDetail.RowCount <= 0)
            {
                strMessage += "\n" + "Please enter entries to process this journal entry! ";
                bStatus = false;
            }

            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        #endregion
        #region Approved and Checked Details
        private void UC_AccJournalEntry_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void UC_AccJournalEntry_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtJournalID.Text != null && txtJournalID.TextLength > 0 && txtJournalID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetApproved login = new frmSetApproved();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetApproved.bChecked)
                                {
                                    bHasApproved = true;
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_accJournalEntry objJV = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                                        if (objJV != null)
                                        {
                                            objJV.IsApproved = true;
                                            objJV.DateApproved = clsSecurity.getServerDateTime();
                                            objJV.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objJV.Update();
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }

                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (txtJournalID.Text != null && txtJournalID.TextLength > 0 && txtJournalID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpJVDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                        {

                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetChecked login = new frmSetChecked();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetChecked.bChecked)
                                {
                                    bHasChecked = true;
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_accJournalEntry objJV = tbl_accJournalEntry.Select(txtJournalID.Text.Trim());
                                        if (objJV != null)
                                        {
                                            objJV.IsChecked = true;
                                            objJV.DateChecked = clsSecurity.getServerDateTime();
                                            objJV.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objJV.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }

                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region User Details
        private void UC_AccJournalEntry_SF_History_Click(object sender, EventArgs e)
        {
            if (txtJournalID.Text != "" || txtJournalID.Text != "<Auto Generate>")
            {
                tbl_accJournalEntry detail = tbl_accJournalEntry.Select(txtJournalID.Text);
                if (detail != null)
                {
                    DataTable dt_UserDetails = new DataTable();
                    dt_UserDetails.Columns.Add("usertype", typeof(string));
                    dt_UserDetails.Columns.Add("Column1", typeof(string));
                    dt_UserDetails.Columns.Add("user", typeof(string));
                    dt_UserDetails.Columns.Add("Column2", typeof(string));
                    dt_UserDetails.Columns.Add("datetime", typeof(string));

                    dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                    if (detail.DateCreate != detail.DateModified)
                        dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                    if (detail.IsChecked)
                        dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                    if (detail.IsApproved)
                        dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                    if (detail.IsDeleted)
                        dt_UserDetails.Rows.Add("Cancelled by", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

                    Point startPoint = this.PointToScreen(new Point());

                    frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                    frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                }
            }
        }
        #endregion

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.Color.Red;
        //        this.btnChecked.ForeColor = System.Drawing.Color.Red;
        //        this.btnApproved.BackColor = System.Drawing.Color.White;
        //        this.btnChecked.BackColor = System.Drawing.Color.White;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}

        #endregion

        #endregion
        #region Price Convertion
        public decimal getSavePrice(decimal dEnteredPrice)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            //if (txtCurrencyRate.Text.Trim().Length > 0)
            //    dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            //dUnitPrice = dEnteredPrice * dExRate;
            return dUnitPrice;
        }

        public decimal getDisplayUnitPrice(decimal dEnteredUnitPrice, decimal dExRate)
        {
            decimal dUnitPrice = 0;
            if (dExRate > 0)
                dUnitPrice = dEnteredUnitPrice / dExRate;
            return dUnitPrice;
        }

        #endregion
        #endregion
    }
}