using DataTire;
using Digiteq_Logic;
using SEACC_PCB.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SEACC_PCB
{
    /// <summary>
    /// Interaction logic for frm_ReimbursmentReq.xaml
    /// </summary>
    public partial class frm_ReimbursmentReq : Window
    {
        #region Class Variables
        DataTable dtGL = new DataTable();
        string sPCAccCode = "";
        #endregion

        #region Form Load
        public frm_ReimbursmentReq()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_ReimbursmentRequest;
            SEACC_Form.Initialize();
            #endregion

            #region Reimbursment Grid
            dgr_Main.dt.Columns.Add("LineNo");
            dgr_Main.dt.Columns.Add("IsSelect");
            dgr_Main.dt.Columns.Add("Date");
            //dgr_Main.dt.Columns.Add("ExpID");
            dgr_Main.dt.Columns.Add("TxnID");
            dgr_Main.dt.Columns.Add("Remarks");
            dgr_Main.dt.Columns.Add("SpentBy");
            dgr_Main.dt.Columns.Add("Amount", typeof(decimal));


            dgr_Main.Add_DatagridColoumn("Line No", "LineNo", 100, false);
            //dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "", "IsSelect", 40, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "", "IsSelect", 40, true, false);
            //dgr_Main.Add_DatagridColoumn(ColoumnType.Text, "Segoe MDL2 Assets", "✔", "IsSelect", 40, true, true);
            dgr_Main.Add_DatagridColoumn("Date", "Date", 80);
            //dgr_Main.Add_DatagridColoumn("Expenditure ID", "ExpID", 150, false);
            dgr_Main.Add_DatagridColoumn("Txn Code", "TxnID", 80);
            dgr_Main.Add_DatagridColoumn("Remarks", "Remarks", 320);
            dgr_Main.Add_DatagridColoumn("Spent By", "SpentBy", 150);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Amount", "Amount", 90, true, true);
            #endregion

            #region Double Entry Data Table
            dtGL.Columns.Add("No", typeof(int));
            //dtGL.Columns.Add("ExpenID");
            //dtGL.Columns.Add("CategoryID");
            dtGL.Columns.Add("AccountCode");
            dtGL.Columns.Add("AccountName");
            dtGL.Columns.Add("DebitAmount", typeof(decimal));
            dtGL.Columns.Add("CreditAmount");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Approved.Click += btn_Approve_Click;
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtRemReq.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermission_ToPrint())
                    {
                        tbl_securityFunctionMaster_Permission oRepPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, (int)enum_ReportName.pcb_Reimbursement);
                        tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.pcb_Reimbursement);
                        if (oReports != null)
                        {
                            DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                            DataSets.dts_PettyCash dts_pettyCash = new DataSets.dts_PettyCash();
                            dts_pettyCash.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, Digiteq_Logic.clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, "");

                            tbl_pcbTxReimbursment details = tbl_pcbTxReimbursment.Select(txtRemReq.Tag.ToString());
                            if (details != null)
                            {
                                dts_pettyCash.dt_Reimbursement.Adddt_ReimbursementRow(details.Reimbursment_ID, details.ReimbursmentDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID),
                                    Decimal.ToInt32(details.NoOfExpences), details.TotalAmount);

                                foreach (tbl_pcbTxExpenditure oExpenditure in tbl_pcbTxExpenditure.SelectAll().Where(p => p.Reimbursment_ID == details.Reimbursment_ID))
                                {
                                    dts_pettyCash.dt_Expenditure.Adddt_ExpenditureRow(oExpenditure.Expenditure_ID, oExpenditure.ExpenditureDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID),
                                        oExpenditure.SpentUser_ID, clsGenaralName.getName_User(oExpenditure.SpentUser_ID), oExpenditure.Cost_Center_ID, "", oExpenditure.TotalAmount, oExpenditure.Remarks, "");
                                }

                                decimal dCreditVal = 0, dDebetVal = 0;
                                foreach (tbl_accAccountPayableNote_SubTotal oAPNSub in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(details.Reimbursment_ID))
                                {
                                    dCreditVal = 0;
                                    dDebetVal = 0;
                                    if (oAPNSub.IsCredit)
                                        dCreditVal = oAPNSub.Amount;
                                    else
                                        dDebetVal = oAPNSub.Amount;

                                    dts_pettyCash.dt_APNDetail.Adddt_APNDetailRow(oAPNSub.Line_No, oAPNSub.Gl_ID, clsGenaralName.getName_AccountName(oAPNSub.Gl_ID), dCreditVal, dDebetVal);
                                }

                                glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("Cancel", details.IsCanceled ? "Cancelled" : "", true);
                                frm_ReportViewer RepViwer = new frm_ReportViewer();
                                RepViwer.print(oReports.ReportPath, dts_pettyCash, glb_dts_ExportReport.dt_rptParameter, oRepPermission);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCMessageBox.Show("Print Failed", ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_pcbTxReimbursment oOldReim = tbl_pcbTxReimbursment.Select(txtRemReq.Tag.ToString());
                            if (oOldReim != null)
                            {
                                if (!oOldReim.IsCanceled && !oOldReim.IsApproved)
                                {
                                    #region Update Expenditures
                                    foreach (tbl_pcbTxExpenditure oOExpenditure in tbl_pcbTxExpenditure.SelectAll().Where(p => p.Reimbursment_ID == txtRemReq.Tag.ToString()))
                                    {
                                        oOExpenditure.Reimbursment_ID = "default";
                                        oOExpenditure.IsReimburst = false;
                                        oOExpenditure.Update();
                                    }
                                    #endregion

                                    tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(txtRemReq.Tag.ToString());
                                    clsMethods_GL.GLPosting_Delete(oAPN.GlPosting_ID);
                                    tbl_accAccountPayableNote_SubTotal.DeleteAllByAccountPayableNote_ID(txtRemReq.Tag.ToString());

                                    decimal dTotAmount = 0;
                                    int iNoOfReimbursements = 0;
                                    string sNarration = "";

                                    //if (dtReimbursment.Rows.Count > 0)
                                    //if (dgr_Main.dt.Rows.Count > 0)
                                    //{
                                    #region Update Expenditures
                                    //foreach (DataRow row in dtReimbursment.Rows)
                                    foreach (DataRow row in dgr_Main.dt.Rows)
                                    {
                                        bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);
                                        if (!bSelect)
                                            continue;

                                        string sExpID = row["TxnID"].ToString();
                                        string sUser = row["SpentBy"].ToString();
                                        string sDate = row["Date"].ToString();

                                        tbl_pcbTxExpenditure oOExpenditure = tbl_pcbTxExpenditure.Select(sExpID);
                                        oOExpenditure.IsReimburst = true;
                                        oOExpenditure.Reimbursment_ID = txtRemReq.Tag.ToString();
                                        oOExpenditure.Update();

                                        ++iNoOfReimbursements;
                                        dTotAmount += decimal.Parse(row["Amount"].ToString());

                                        sNarration += sExpID + " : " + sUser + " : " + sDate + " , ";

                                    }
                                    #endregion
                                    //}

                                    if (iNoOfReimbursements > 0)
                                    {
                                        tbl_pcbTxReimbursment oReim = new tbl_pcbTxReimbursment(txtRemReq.Tag.ToString(), dtpToDate.GetDateTime().Date, sPCAccCode, dtpToDate.GetDateTime().Date, iNoOfReimbursements, dTotAmount, oOldReim.IsApproved, oOldReim.IsCanceled, oOldReim.CreateUser_ID, clsSecurity.UserIDLoged, oOldReim.ApprovedUser_ID, oOldReim.CanceldUser_ID, oOldReim.DateCreate, clsSecurity.getServerDateTime(), oOldReim.DateApproved, oOldReim.DateCanceled, oOldReim.CreateUserTerminal_ID, oOldReim.CreateUserTerminal_ID, oOldReim.ApprovedUserTerminal_ID, oOldReim.CanceledUserTerminal_ID);
                                        oReim.Update();

                                        #region APN Update

                                        #region APN Header
                                        tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtRemReq.Text.Trim());
                                        if (oldRecord != null)
                                        {
                                            tbl_accAccountPayableNote oldAPN = new tbl_accAccountPayableNote(txtRemReq.Tag.ToString(), dtpToDate.GetDateTime().Date, sNarration, "", clsValidation.defaultDateTime, "", "", "", "default", "default", "default",
                                                                   "default", "default", "default", "default", "default", "default", "default", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, "CUR/048",
                                                                   1, 0, 0, 0, 0, 0, dTotAmount, 0, 0, 0, 0, dTotAmount, oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, "default",
                                                                   oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateChecked,
                                        oldRecord.DateApproved, oldRecord.DateDeleted, oldRecord.DatePrinted, oldRecord.IsAdvancePayment, oldRecord.IsPartPayment, oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsPettyCashReimbursment, oldRecord.IsSAPN, oldRecord.SettledAmount, oldRecord.IsSeattled, oldRecord.ChequeRegister_ID, oldRecord.IsReturnCheque, oldRecord.PrintCount, clsSecurity.CompanyID, clsSecurity.BranchID);
                                            oldAPN.Update();
                                        }
                                        #endregion

                                        #region  Insert Detail - APN Details
                                        int iRow;
                                        string sGLCode = "", sCategoryID = "";
                                        bool bIsCredit;
                                        decimal dDebitAmount = 0, dCreditAmount = 0, dAmount = 0;

                                        foreach (DataRow row in dtGL.Rows)
                                        {
                                            iRow = int.Parse(row["No"].ToString());
                                            sGLCode = clsValidate.ValidateRowValue(row, "AccountCode", "default");
                                            dDebitAmount = clsValidate.ValidateRowValue(row, "DebitAmount", 0);
                                            dCreditAmount = clsValidate.ValidateRowValue(row, "CreditAmount", 0);

                                            if (dCreditAmount == 0)
                                            {
                                                bIsCredit = false;
                                                dAmount = dDebitAmount;
                                                sCategoryID = "12";
                                            }
                                            else
                                            {
                                                bIsCredit = true;
                                                dAmount = dCreditAmount;
                                                sCategoryID = "11";
                                            }

                                            tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRow, txtRemReq.Tag.ToString(), sCategoryID,
                                                sGLCode, "default", "default", "default", "default", "default", "default", dAmount, bIsCredit);
                                            Insdetail.Insert();
                                        }

                                        clsMethods_GL.PostTransaction_APN(txtRemReq.Tag.ToString());
                                        #endregion

                                        #endregion

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Can not Update", "This is already approved..", MessageBoxButton.OK);
                                }
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            if (SEACC_Form.isAutoGenaratedCode)
                            {
                                txtRemReq.Tag = SEACC_Form.getAutoGeneratedCode();
                            }

                            decimal dTotAmount = 0;
                            int iNoOfReimbursements = 0;
                            string sNarration = "";

                            //if (dtReimbursment.Rows.Count > 0)
                            //if (dgr_Main.dt.Rows.Count > 0)
                            //{
                            #region Update Expenditures
                            //foreach (DataRow row in dtReimbursment.Rows)
                            foreach (DataRow row in dgr_Main.dt.Rows)
                            {
                                bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);
                                if (!bSelect)
                                    continue;

                                string sExpID = row["TxnID"].ToString();
                                string sUser = row["SpentBy"].ToString();
                                string sDate = row["Date"].ToString();

                                tbl_pcbTxExpenditure oOExpenditure = tbl_pcbTxExpenditure.Select(sExpID);
                                oOExpenditure.IsReimburst = true;
                                oOExpenditure.Reimbursment_ID = txtRemReq.Tag.ToString();
                                oOExpenditure.Update();

                                ++iNoOfReimbursements;
                                dTotAmount += decimal.Parse(row["Amount"].ToString());

                                sNarration += sExpID + " : " + sUser + " : " + sDate + " , ";

                            }
                            #endregion
                            //}

                            if (iNoOfReimbursements > 0)
                            {
                                tbl_pcbTxReimbursment oNewRembursment = new tbl_pcbTxReimbursment(txtRemReq.Tag.ToString(), dtpToDate.GetDateTime().Date, sPCAccCode, dtpToDate.GetDateTime().Date, iNoOfReimbursements, dTotAmount, false, false, clsSecurity.UserIDLoged, "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default", "default");
                                oNewRembursment.Insert();

                                #region APN Create

                                #region APN Header
                                tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(txtRemReq.Tag.ToString(), dtpToDate.GetDateTime().Date, sNarration, "", clsValidation.defaultDateTime, "", "", "", "A000", "default", "default",
                                                                               "default", "default", "default", "default", "default", "default", "default", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, "CUR/048",
                                                                               1, 0, 0, 0, 0, 0, dTotAmount, 0, 0, 0, 0, dTotAmount, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default",
                                                                               "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                               clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), true, false, false, false, false, false, false, true, true, 0, false, "default", false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                                AccAPN.Insert();
                                #endregion

                                //  Insert supplier outstanding amount
                                //clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, true);

                                #region  Insert Detail - APN Details
                                int iRow;
                                string sGLCode = "", sCategoryID = "";
                                bool bIsCredit;
                                decimal dDebitAmount = 0, dCreditAmount = 0, dAmount = 0;

                                foreach (DataRow row in dtGL.Rows)
                                {
                                    iRow = int.Parse(row["No"].ToString());
                                    sGLCode = clsValidate.ValidateRowValue(row, "AccountCode", "default");
                                    dDebitAmount = clsValidate.ValidateRowValue(row, "DebitAmount", 0);
                                    dCreditAmount = clsValidate.ValidateRowValue(row, "CreditAmount", 0);

                                    if (dCreditAmount == 0)
                                    {
                                        bIsCredit = false;
                                        dAmount = dDebitAmount;
                                        sCategoryID = "12";
                                    }
                                    else
                                    {
                                        bIsCredit = true;
                                        dAmount = dCreditAmount;
                                        sCategoryID = "11";
                                    }


                                    tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRow, txtRemReq.Tag.ToString(), sCategoryID,
                                        sGLCode, "default", "default", "default", "default", "default", "default", dAmount, bIsCredit);
                                    Insdetail.Insert();

                                }

                                clsMethods_GL.PostTransaction_APN(txtRemReq.Tag.ToString());
                                #endregion

                                #endregion

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                            else
                                SEACCMessageBox.Show("", "Plese select transactions to Reimburse..", MessageBoxButton.OK);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    //SEACC_Form.IsUpdateMode = true;
                    //ClearFields();
                    fillDetails(txtRemReq.Tag.ToString());
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtRemReq.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_pcbTxReimbursment Details = tbl_pcbTxReimbursment.Select(txtRemReq.Tag.ToString());
                            if (Details != null)
                            {
                                if (!Details.IsApproved)
                                {
                                    if (!Details.IsCanceled)
                                    {
                                        #region Update Expenditures
                                        foreach (tbl_pcbTxExpenditure oOExpenditure in tbl_pcbTxExpenditure.SelectAll().Where(p => p.Reimbursment_ID == txtRemReq.Tag.ToString()))
                                        {
                                            oOExpenditure.Reimbursment_ID = "default";
                                            oOExpenditure.IsReimburst = false;
                                            oOExpenditure.Update();
                                        }
                                        #endregion

                                        #region APN Cancel
                                        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(txtRemReq.Tag.ToString());
                                        oAPN.IsDeleted = true;
                                        oAPN.DateDeleted = clsSecurity.getServerDateTime();
                                        oAPN.DeletedUser_ID = clsSecurity.UserIDLoged;
                                        oAPN.Update();

                                        clsMethods_GL.GLPosting_Delete(oAPN.GlPosting_ID);
                                        #endregion

                                        Details.IsCanceled = true;
                                        Details.DateCanceled = clsSecurity.getServerDateTime();
                                        Details.CanceldUser_ID = clsSecurity.UserIDLoged;
                                        Details.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                        Details.Update();

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                        
                                        RefreshGrid();
                                        ClearFields();

                                    }
                                    else
                                        SEACCMessageBox.Show("Can not Cancel..", "This Expenditure is already cancelled", MessageBoxButton.OK);
                                }
                                else
                                    SEACCMessageBox.Show("Can not Cancel..", "This is already Approved", MessageBoxButton.OK);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }

        private void btn_Approve_Click(object sender, RoutedEventArgs e)
        {
            if (txtRemReq.Tag != null)
            {
                tbl_pcbTxReimbursment oReimbursment = tbl_pcbTxReimbursment.Select(txtRemReq.Tag.ToString());
                if (oReimbursment != null)
                {
                    oReimbursment.IsApproved = true;
                    oReimbursment.ApprovedUser_ID = clsSecurity.UserIDLoged;
                    oReimbursment.DateApproved = clsValidation.defaultDateTime;
                    oReimbursment.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                    oReimbursment.Update();

                    tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(txtRemReq.Tag.ToString());
                    oAPN.IsApproved = true;
                    oAPN.ApprovedUser_ID = clsSecurity.UserIDLoged;
                    oAPN.DateApproved = clsValidation.defaultDateTime;
                    oAPN.Update();
                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                }
            }
            else
                SEACCMessageBox.Show("", "Plese select a transactions to Approve..", MessageBoxButton.OK);
        }
        #endregion

        #region Check validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            //if (!clsValidation.Validate_EmptyValue(txtExpenditureName))
            //    bStatus = false;

            return bStatus;
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRemReq, true, false, false);
            dtpToDate.SetTime(clsSecurity.getServerDateTime());
            txtRemReq.Tag = null;

            lblCancel.Visibility = Visibility.Collapsed;

            lblSelectedCount.Content = "";
            lblSelectedAmnt.Content = "";
            lblTotCount.Content = "";
            lblTotAmount.Content = "";

            tbl_pcbMasAccount oPCAccounts = tbl_pcbMasAccount.SelectAllByAssignedUser_ID(clsSecurity.UserIDLoged).FirstOrDefault();
            if (oPCAccounts != null)
            {
                sPCAccCode = oPCAccounts.PcbAccount_ID;

                decimal dBookBalance = 0;
                string sValue = DBHandling.ExecQuery_ReturnString("sp_getBookBalance '" + dtpToDate.GetDateTime().Date + "','" + sPCAccCode + "'");
                if (sValue != "")
                    dBookBalance = decimal.Parse(sValue);

                decimal dUnSettledIOUTotal = 0;
                string sValueIOU = DBHandling.ExecQuery_ReturnString("sp_getUnSettledIOUTotal '" + dtpToDate.GetDateTime().Date + "','" + sPCAccCode + "'");
                if (sValueIOU != "")
                    dUnSettledIOUTotal = decimal.Parse(sValueIOU);

                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtRemReq.setReadOnlyStatus(true);
                    txtRemReq.Text = "<Auto Generate>";
                }
                else
                    txtRemReq.setReadOnlyStatus(false);

                RefreshGrid();
            }
        }
        #endregion

        #region FillDetails
        public void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_pcbTxReimbursment detail = tbl_pcbTxReimbursment.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRemReq, false, false, false);

                        txtRemReq.Tag = detail.Reimbursment_ID;
                        txtRemReq.Text = detail.Reimbursment_ID;
                        dtpToDate.SetTime(detail.ReimbursmentDate.Date);

                        if (detail.IsCanceled)
                            lblCancel.Visibility = Visibility.Visible;
                        else
                            lblCancel.Visibility = Visibility.Collapsed;

                        dgr_Main.dt.Rows.Clear();
                        int iRowNo = 0;
                        decimal dTotalAmount = 0;
                        foreach (tbl_pcbTxExpenditure expDetail in tbl_pcbTxExpenditure.SelectAll().Where(p => p.Reimbursment_ID == sID))
                        {
                            iRowNo++;
                            decimal dAmountIOU = expDetail.TotalAmount;
                            dgr_Main.dt.Rows.Add(iRowNo, true, clsFormatter.FormatDate_Short(expDetail.ExpenditureDate), expDetail.Expenditure_ID, expDetail.Remarks,
                                clsGenaralName.getName_User(expDetail.SpentUser_ID), clsFormatter.FormatDecimalPlaces_Price(expDetail.TotalAmount));
                            dTotalAmount += dAmountIOU;
                        }
                        dgr_Main.RefreshGrid();

                        lblTotCount.Content = iRowNo;
                        lblTotAmount.Content = clsFormatter.FormatDecimalPlaces_Price(dTotalAmount);
                        getCount();

                        fillDoubleEntry();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRowNo = 0;
                decimal dTotalAmount = 0;
                dgr_Main.dt.Rows.Clear();

                foreach (tbl_pcbTxExpenditure detail in tbl_pcbTxExpenditure.SelectAllByPcbAccount_ID(sPCAccCode).Where(p => p.Expenditure_ID != "default" &&
                !p.IsCanceled && !p.IsReimburst && p.ExpenditureDate <= dtpToDate.GetDateTime().Date))
                {
                    iRowNo++;
                    decimal dAmountIOU = detail.TotalAmount;
                    dgr_Main.dt.Rows.Add(iRowNo, true, clsFormatter.FormatDate_Short(detail.ExpenditureDate), detail.Expenditure_ID, detail.Remarks,
                        clsGenaralName.getName_User(detail.SpentUser_ID), clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount));
                    //dgr_Main.dt.Rows.Add(iRowNo, "\uE0A2", clsFormatter.FormatDate_Short(detail.ExpenditureDate), detail.Expenditure_ID, detail.Remarks, 
                    //    clsGenaralName.getName_User(detail.SpentUser_ID), clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount));
                    dTotalAmount += dAmountIOU;
                }
                dgr_Main.RefreshGrid();
                
                lblTotCount.Content = iRowNo;
                lblTotAmount.Content = clsFormatter.FormatDecimalPlaces_Price(dTotalAmount);
                getCount();

                fillDoubleEntry();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Search event
        private void txtRemReq_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frm_search RowDataSearch = null;
            lstParameeters.Add(sPCAccCode);
            RowDataSearch = new frm_search(false, lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_ReimbursmentRequest);

            if (RowDataSearch.DialogResult == true)
            {              
                fillDetails(lstResult[0]);                            
            }
        }
        #endregion
               
        #region Mouse Events
      
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect")
                    dgr_Main.dt.Rows[irowID]["IsSelect"] = dgr_Main.dt.Rows[irowID]["IsSelect"].ToString() == "True" ? false : true;

                getCount();
                fillDoubleEntry();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
            }
        }

        private void dgr_Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect")
                    dgr_Main.dt.Rows[irowID]["IsSelect"] = dgr_Main.dt.Rows[irowID]["IsSelect"].ToString() == "True" ? false : true;

                getCount();
                fillDoubleEntry();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", clsSecurity.getFormID(SEACC_Form.enmFormName), ex);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        #endregion

        #region Click Event
        private void btnCloseTop_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void getCount()
        {
            int iSelectedCount = 0;
            decimal dAmount = 0;
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);

                if (bSelect)
                {
                    ++iSelectedCount;
                    dAmount += clsValidate.ValidateRowValue(row, "Amount", 0);
                }
            }
            lblSelectedCount.Content = iSelectedCount;
            lblSelectedAmnt.Content = clsFormatter.FormatDecimalPlaces_Price(dAmount);
        }

        private void fillDoubleEntry()
        {
            int iRowNo = 0;
            dtGL.Rows.Clear();

            #region Debit Entry
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);

                if (bSelect)
                {
                    string sExpID = clsValidate.ValidateRowValue(row, "TxnID", "default");
                    foreach (tbl_pcbTxExpenditure_Detail detail in tbl_pcbTxExpenditure_Detail.SelectAllByExpenditure_ID(sExpID))
                    {
                        tbl_pcbRefExpenditureCategory oCategory = tbl_pcbRefExpenditureCategory.Select(detail.PcbExpenditureCategory_ID);
                        if (oCategory != null)
                        {
                            tbl_pcbRefExpenditureType oExpType = tbl_pcbRefExpenditureType.Select(oCategory.PcbExpenditureType_ID);
                            if (oExpType != null)
                            {
                                iRowNo++;
                                dtGL.Rows.Add(iRowNo, oExpType.Gl_ID, clsGenaralName.getName_AccountName(oExpType.Gl_ID), detail.Amount, clsFormatter.FormatDecimalPlaces_Price(0));
                            }
                        }
                    }
                }
            } 
            #endregion

            #region Credit Entry
            tbl_pcbMasAccount oAccount = tbl_pcbMasAccount.Select(sPCAccCode);
            if (oAccount != null)
                dtGL.Rows.Add(++iRowNo, oAccount.Gl_ID, clsGenaralName.getName_AccountName(oAccount.Gl_ID), 0, decimal.Parse(lblSelectedAmnt.Content.ToString())); 
            #endregion

            #region Group By GL Code
            int iLineNo = 1;
            var newGroup = (from row in dtGL.AsEnumerable()
                            group row by new { ID = row.Field<string>("AccountCode"), AccName = row.Field<string>("AccountName"), credit = row.Field<string>("CreditAmount") } into grp
                            select new
                            {
                                No = iLineNo++,
                                AccountCode = grp.Key.ID,
                                AccountName = grp.Key.AccName,
                                DebitAmount = clsFormatter.FormatDecimalPlaces_Price(grp.Sum(r => r.Field<Decimal>("DebitAmount"))),
                                CreditAmount = grp.Key.credit
                            }).ToList();            
            #endregion

            dgr_DEntry.ItemsSource = newGroup;
                        
        }
               
    }
}

