using DataTire;
using Digiteq_Logic;
using SEACC_PCB.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SEACC_PCB.Transaction_Forms
{
    /// <summary>
    /// Interaction logic for frm_ReimbursmentRequest.xaml
    /// </summary>
    public partial class frm_ReimbursmentRequest : Window
    {
        #region Class Variables
        DataTable dtReimbursment = new DataTable();
        DataTable dtGL = new DataTable();
        string sPCAccCode = "", sGLCode = "", sGLName = "";
        int iNoOfExp = 0;
        decimal dTotalAmount = 0;
        #endregion

        #region Form Load
        public frm_ReimbursmentRequest()
        {
            #region User Control Initialization
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.PCB_ReimbursmentRequest;
            SEACC_Form.Initialize();
            #endregion

            #region Reimbursment Data Table
            dtReimbursment.Columns.Add("LineNo");
            dtReimbursment.Columns.Add("IsSelect", typeof(bool));
            dtReimbursment.Columns.Add("Date");
            dtReimbursment.Columns.Add("ExpID");
            dtReimbursment.Columns.Add("TxnID");
            dtReimbursment.Columns.Add("TxnCode");
            dtReimbursment.Columns.Add("Remarks");
            dtReimbursment.Columns.Add("SpentBy");
            dtReimbursment.Columns.Add("Amount");
            #endregion

            #region Double Entry Data Table
            dtGL.Columns.Add("No", typeof(int));
            dtGL.Columns.Add("ExpenID");
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
                                    //0, details.TotalAmount);
                                    Decimal.ToInt32(details.NoOfExpences), details.TotalAmount);

                                foreach (tbl_pcbTxExpenditure oExpenditure in tbl_pcbTxExpenditure.SelectAll().Where(p => p.Reimbursment_ID == details.Reimbursment_ID))
                                {
                                    //dts_pettyCash.dt_Expenditure.Adddt_ExpenditureRow(oExpenditure.Expenditure_ID, oExpenditure.ExpenditureDate, details.PcbAccount_ID, clsGenaralName.getName_PCAccount(details.PcbAccount_ID), oExpenditure.PcbExpenditureCategory_ID, clsGenaralName.getName_ExpCategory(oExpenditure.PcbExpenditureCategory_ID), oExpenditure.SpentUser_ID, clsGenaralName.getName_User(oExpenditure.SpentUser_ID), oExpenditure.Cost_Center_ID, "", oExpenditure.TotalAmount, oExpenditure.Remarks, "");
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

                                    if (dtReimbursment.Rows.Count > 0)
                                    {
                                        #region Update Expenditures
                                        foreach (DataRow row in dtReimbursment.Rows)
                                        {
                                            bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);
                                            if (!bSelect)
                                                continue;

                                            string sExpID = row["ExpID"].ToString();
                                            string sUser = clsGenaralName.getName_User(row["SpentBy"].ToString());
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
                                    }

                                    if (iNoOfReimbursements > 0)
                                    {
                                        tbl_pcbTxReimbursment oReim = new tbl_pcbTxReimbursment(txtRemReq.Tag.ToString(), dtpToDate.GetDateTime().Date, sPCAccCode, dtpToDate.GetDateTime().Date, iNoOfExp, dTotalAmount, oOldReim.IsApproved, oOldReim.IsCanceled, oOldReim.CreateUser_ID, clsSecurity.UserIDLoged, oOldReim.ApprovedUser_ID, oOldReim.CanceldUser_ID, oOldReim.DateCreate, clsSecurity.getServerDateTime(), oOldReim.DateApproved, oOldReim.DateCanceled, oOldReim.CreateUserTerminal_ID, oOldReim.CreateUserTerminal_ID, oOldReim.ApprovedUserTerminal_ID, oOldReim.CanceledUserTerminal_ID);
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

                            if (dtReimbursment.Rows.Count > 0)
                            {
                                #region Update Expenditures
                                foreach (DataRow row in dtReimbursment.Rows)
                                {
                                    bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);
                                    if (!bSelect)
                                        continue;

                                    string sExpID = row["ExpID"].ToString();
                                    string sUser = clsGenaralName.getName_User(row["SpentBy"].ToString());
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
                            }

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
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    SEACC_Form.IsUpdateMode = true;
                    ClearFields();
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

                                        string[] sExpList = { };
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
                    //tbl_pcbTxReimbursment oReimbursment = tbl_pcbTxReimbursment.Select(txtRemReq.Tag.ToString());
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
                if (CheckValidity_DuplicateFiled())
                {
                    if (ChekValidity_DuplicateNames())
                        bStatus = true;
                }
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

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                //if (SEACC_Form.isAutoGenaratedCode)
                //{
                //    txtDepartmentID.Tag = SEACC_Form.getAutoGeneratedCode();
                //    txtDepartmentID.Text = txtDepartmentID.Tag.ToString();
                //}

                //tbl_genDepartmentMaster oDept = tbl_genDepartmentMaster.Select(txtDepartmentID.Text);
                //if (oDept != null)
                //{
                //    bStatus = false;
                //    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                //}
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            //foreach (tbl_genDepartmentMaster oDept in tbl_genDepartmentMaster.SelectAll().Where(p => p.DepartmentName == txtDeptName.Text && p.Department_ID != txtDepartmentID.Text))
            //{
            //    bStatus = false;
            //    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
            //    break;
            //}
            return bStatus;
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtRemReq, true, false, false);
            dtpToDate.SetTime(clsSecurity.getServerDateTime());
            txtRemReq.Tag = null;

            tbl_pcbMasAccount oPCAccounts = tbl_pcbMasAccount.SelectAllByAssignedUser_ID(clsSecurity.UserIDLoged).FirstOrDefault();
            if (oPCAccounts != null)
            {
                sPCAccCode = oPCAccounts.PcbAccount_ID;
                string sPCAccName = oPCAccounts.PcbAccountName;
                string sCurreecy = oPCAccounts.Currency_ID;
                decimal dFloatAmnt = oPCAccounts.FloatAmount;
                sGLCode = oPCAccounts.Gl_ID;
                sGLName = clsGenaralName.getName_AccountName(sGLCode);

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
                RefreshGrid_DoubleEntry( true);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRowNo = 0;
                dtReimbursment.Rows.Clear();

                foreach (tbl_pcbTxExpenditure detail in tbl_pcbTxExpenditure.SelectAllByPcbAccount_ID(sPCAccCode).Where(p => p.Expenditure_ID != "default" && !p.IsCanceled && !p.IsReimburst && p.ExpenditureDate <= dtpToDate.GetDateTime().Date))
                {
                    iRowNo++;
                    decimal dAmountIOU = detail.TotalAmount;
                    dtReimbursment.Rows.Add(iRowNo, true, clsFormatter.FormatDate_Short(detail.ExpenditureDate), detail.Expenditure_ID, "", "", detail.Remarks, clsGenaralName.getName_User(detail.SpentUser_ID), clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount));
                    dTotalAmount += dAmountIOU;
                }
                dgr_Reim.ItemsSource = dtReimbursment.DefaultView;
                iNoOfExp = iRowNo - 1;
                lblNoOfBillVal.Content = iNoOfExp;
                lblTotAmntVal.Content = clsFormatter.FormatDecimalPlaces_Price(dTotalAmount);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void RefreshGrid_DoubleEntry( bool bIsLoadAll)
        {
            try
            {
                if (dtReimbursment.Rows.Count > 0)
                {
                    int iRowNo = 0;
                    foreach (DataRow row in dtReimbursment.Rows)
                    {
                        bool bSelect = clsValidate.ValidateRowValue(row, "IsSelect", false);
                        if (!bSelect)
                            continue;

                        string sExpID = clsValidate.ValidateRowValue(row, "ExpID", ""); 
                     //   string sUser = clsGenaralName.getName_User(row["SpentBy"].ToString());
                      //  string sDate = row["Date"].ToString();

                        tbl_pcbTxExpenditure oOEx = tbl_pcbTxExpenditure.Select(sExpID);
                        if (oOEx != null)
                        {
                          //  tbl_pcbTxExpenditure_Detail oOExDetail = tbl_pcbTxExpenditure_Detail.SelectAll()
                         //   tbl_pcbRefExpenditureType oExType = tbl_pcbRefExpenditureType.Select(oCat.PcbExpenditureType_ID);
                         //   dtGL.Rows.Add(iRowNo++, oOExpenditure.Expenditure_ID, oExType.Gl_ID, clsGenaralName.getName_AccountName(oExType.Gl_ID), clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount), 0);
                        }


                        //++iNoOfReimbursements;
                        //dTotAmount += decimal.Parse(row["Amount"].ToString());

                        //sNarration += sExpID + " : " + sUser + " : " + sDate + " , ";

                    }
                }





              
                decimal dTotalAmount = 0;
                List<tbl_pcbTxExpenditure> oExpenditures = null;
                dtGL.Rows.Clear();

                //#region Load All
                //if (bIsLoadAll)
                //{
                //    oExpenditures = tbl_pcbTxExpenditure.SelectAll().Where(p => p.Expenditure_ID != "default" && !p.IsCanceled && !p.IsReimburst && p.ExpenditureDate <= dtpToDate.GetDateTime().Date && p.PcbAccount_ID == sPCAccCode).ToList();
                //    foreach (tbl_pcbTxExpenditure detail in oExpenditures)
                //    {
                //        iRowNo++;
                //        //tbl_pcbRefExpenditureCategory oCat = tbl_pcbRefExpenditureCategory.Select(detail.PcbExpenditureCategory_ID);
                //        tbl_pcbRefExpenditureCategory oCat = tbl_pcbRefExpenditureCategory.Select("");
                //        tbl_pcbRefExpenditureType oExType = tbl_pcbRefExpenditureType.Select(oCat.PcbExpenditureType_ID);

                //        dTotalAmount += detail.TotalAmount;
                        
                //        dtGL.Rows.Add(iRowNo, detail.Expenditure_ID, oExType.Gl_ID, clsGenaralName.getName_AccountName(oExType.Gl_ID), detail.TotalAmount, 0);
                        
                //        dgr_DEntry.ItemsSource = dtGL.DefaultView;

                //    }
                //}
                //#endregion

                //#region Load only selected
                //else
                //{
                //    for (int i = 1; i <= ExpenditureList.Length; i++)
                //    {
                //        foreach (tbl_pcbTxExpenditure detail in tbl_pcbTxExpenditure.SelectAll().Where(p => p.Expenditure_ID == ExpenditureList[i - 1] && !p.IsCanceled && p.ExpenditureDate <= dtpToDate.GetDateTime().Date && p.PcbAccount_ID == sPCAccCode).ToList())
                //        {
                //            iRowNo++;
                //            //tbl_pcbRefExpenditureCategory oCat = tbl_pcbRefExpenditureCategory.Select(detail.PcbExpenditureCategory_ID);
                //            tbl_pcbRefExpenditureCategory oCat = tbl_pcbRefExpenditureCategory.Select("");
                //            tbl_pcbRefExpenditureType oExType = tbl_pcbRefExpenditureType.Select(oCat.PcbExpenditureType_ID);

                //            dTotalAmount += detail.TotalAmount;
                //            dtGL.Rows.Add(iRowNo, detail.Expenditure_ID, oExType.Gl_ID, clsGenaralName.getName_AccountName(oExType.Gl_ID), clsFormatter.FormatDecimalPlaces_Price(detail.TotalAmount), 0);
                //            dgr_DEntry.ItemsSource = dtGL.DefaultView;
                //        }
                //    }
                //}
                //#endregion

                //dtGL.Rows.Add(iRowNo + 1, "", sGLCode, sGLName, 0, clsFormatter.FormatDecimalPlaces_Price(dTotalAmount));

                //#region Group By GL Code
                //int iLineNo = 1;
                //var newGroup = (from row in dtGL.AsEnumerable()
                //                group row by new { ID = row.Field<string>("AccountCode"), AccName = row.Field<string>("AccountName"), credit = row.Field<string>("CreditAmount") } into grp
                //                select new
                //                {
                //                    No = iLineNo++,
                //                    AccountCode = grp.Key.ID,
                //                    AccountName = grp.Key.AccName,
                //                    DebitAmount = clsFormatter.FormatDecimalPlaces_Price(grp.Sum(r => r.Field<Decimal>("DebitAmount"))),
                //                    CreditAmount = grp.Key.credit
                //                }).ToList();

                //dgr_DEntry.ItemsSource = newGroup;
                //#endregion

                //#region Set label values
                //iNoOfExp = iRowNo;
                //lblNoOfBillVal.Content = iNoOfExp;
                //lblTotAmntVal.Content = clsFormatter.FormatDecimalPlaces_Price(dTotalAmount);
                //#endregion

            }
            catch (Exception ex)
            {
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
            RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.PCB_ReimbursmentRequest);
            if (RowDataSearch.DialogResult == true)
            {
                txtRemReq.Tag = lstResult[0];
                txtRemReq.Text = lstResult[0];
                SEACC_Form.IsUpdateMode = true;

                tbl_pcbTxReimbursment oRem = tbl_pcbTxReimbursment.Select(lstResult[0]);
                dtpToDate.SetTime(oRem.ReimbursmentDate.Date);

                List<tbl_pcbTxExpenditure> oExs = tbl_pcbTxExpenditure.SelectAll().Where(p => p.Reimbursment_ID == lstResult[0]).ToList();
                if (oExs.Count > 0)
                {
                    string[] sExpList = new string[oExs.Count];
                    int i = 0;
                    foreach (tbl_pcbTxExpenditure oEx in oExs)
                    {
                        sExpList[i] = oEx.Expenditure_ID;
                        i++;
                    }

                    RefreshGrid();
                    RefreshGrid_DoubleEntry( false);
                }
            }
        }
        #endregion

        #region Check Box Events
        private void Reimbursment_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dgr_Reim.SelectedItem;
                if (dataRow != null)
                {
                    var rows = dtGL.Select();
                    foreach (var row in rows)
                    {
                        row.Delete();
                    }

                    var rows2 = dtReimbursment.Select("IsSelect = '" + true + "'");
                    int numberOfRecords = rows2.Length;
                    string[] sExpList = new string[numberOfRecords];
                    int i = 0;

                    foreach (var row2 in rows2)
                    {
                        sExpList[i] = row2.ItemArray[3].ToString().Trim();
                        i++;
                    }
                    RefreshGrid_DoubleEntry( false);

                }
                //chk_selectAll.IsChecked = false;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Reimbursment_UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dgr_Reim.SelectedItem;
                if (dataRow != null)
                {
                    var rows = dtGL.Select();
                    foreach (var row in rows)
                    {
                        row.Delete();
                    }

                    var rows2 = dtReimbursment.Select("IsSelect = '" + true + "'");
                    int numberOfRecords = rows2.Length;
                    string[] sExpList = new string[numberOfRecords];
                    int i = 0;

                    foreach (var row2 in rows2)
                    {
                        sExpList[i] = row2.ItemArray[3].ToString().Trim();
                        i++;
                    }
                    RefreshGrid_DoubleEntry( false);

                }
                //chk_selectAll.IsChecked = false;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtReimbursment.Select().ToList().ForEach(r => r["IsSelect"] = true);
            ClearFields();
        }
        private void chk_selectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtReimbursment.Select().ToList().ForEach(r => r["IsSelect"] = false);
            dtGL.Clear();
        }

        #endregion

        #region Date Change Events
        private void dtpToDate_DateTimeChanged(object sender, EventArgs e)
        {
            string[] sExpList = { };
            RefreshGrid();
            RefreshGrid_DoubleEntry( true);
        }
        #endregion

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnCloseTop_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}