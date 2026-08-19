using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;
using System.Windows.Controls.Primitives;

namespace SEACC_FACTORING
{
    public partial class UC_ChequeManagement : UserControl
    {
        ContextMenu cm = new ContextMenu();
        string glbTransaction_ID = "";
        string sFormConfigReturnedCheque = clsAutocode.getFormConfigCode(FormName.RetruendChequeDebitInvoice);
        string sFormConfigBatchCode = clsAutocode.getFormConfigCode(FormName.accBatchPosting);

        string sGLA_FactoringCharges = "", sGLA_FactoringCharges_Vat = "", sGLA_FactoringCharges_Nbt = "",sGLA_FactoringContralAcc = "", sGLA_ChequeInHand = "";

        #region Form Load
        public UC_ChequeManagement()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_ChequeMgt;
            SEACC_Form.Initialize();

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);
            #endregion

            #region Data Grid Colums Initilize
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "✔", "Check", 25, true, true);
            //dgr_Main.Add_DatagridColoumn("Line No", "RowNo", 30, true);
            dgr_Main.Add_DatagridColoumn("Schedule ID", "factoringSehedule_ID", 80);
            dgr_Main.Add_DatagridColoumn("Cheque Date", "dateCheque_Display", 80);
            dgr_Main.Add_DatagridColoumn("Customer", "customerName", 140);
            dgr_Main.Add_DatagridColoumn("Account No", "accountNumber", 85);
            dgr_Main.Add_DatagridColoumn("Cheque No", "chequeNumber", 80);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Amount", "chequeAmount", 100, true, true);
            dgr_Main.Add_DatagridColoumn("Cheque Status", "statusName", 85);

            dgr_Factoring.Add_DatagridColoumn(ColoumnType.CheckBox, "✔", "Approve", 25, true, true);
            //dgr_Factoring.Add_DatagridColoumn("Line No", "RowNo", 30, true);
            dgr_Factoring.Add_DatagridColoumn("Schedule ID", "factoringSehedule_ID", 80);
            dgr_Factoring.Add_DatagridColoumn("Shedule Date", "SeheduleDate_Display", 80);
            dgr_Factoring.Add_DatagridColoumn("Bank", "bankName", 85);
            dgr_Factoring.Add_DatagridColoumn("Account No", "accountNumber_Factoring", 80);
            dgr_Factoring.Add_DatagridColoumn(ColoumnType.Numaric, "Face Amount", "totalChequeAmount", 80, true, true);
            dgr_Factoring.Add_DatagridColoumn(ColoumnType.Numaric, "Factoring Amount", "totalFactoringAmount", 80, true, true);
            dgr_Factoring.Add_DatagridColoumn(ColoumnType.Numaric, "Total Deductions", "totalDeductions", 80, true, true);
            dgr_Factoring.Add_DatagridColoumn(ColoumnType.Numaric, "Gross Amount", "grossFactoringAmount", 80, true, true);

            dgr_Reconcilation.Add_DatagridColoumn(ColoumnType.CheckBox, "Realized", "realized", 55, true, true);
            dgr_Reconcilation.Add_DatagridColoumn(ColoumnType.CheckBox, "Returned", "returned", 55, true, true);
            //dgr_Reconcilation.Add_DatagridColoumn("Line No", "RowNo", 30, true);
            dgr_Reconcilation.Add_DatagridColoumn("Schedule ID", "factoringSehedule_ID", 80);
            dgr_Reconcilation.Add_DatagridColoumn("Cheque Date", "dateCheque_Display", 80);
            dgr_Reconcilation.Add_DatagridColoumn("Customer", "customerName", 140);
            dgr_Reconcilation.Add_DatagridColoumn("Account No", "accountNumber", 85);
            dgr_Reconcilation.Add_DatagridColoumn("Cheque No", "chequeNumber", 80);
            dgr_Reconcilation.Add_DatagridColoumn(ColoumnType.Numaric, "Amount", "chequeAmount", 100, true, true);
            dgr_Reconcilation.Add_DatagridColoumn("Status ID", "statusID", 10,false);
            dgr_Reconcilation.Add_DatagridColoumn("Cheque Status", "statusName", 85);
            #endregion

            #region ContextMenu
            MenuItem mi1 = new MenuItem();
            mi1.Header = clsAutocode.getChequeStatusName(ChequeStatus.Returned_NR_C);
            mi1.Tag = clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C);
            mi1.Click += Mi1_Click;

            MenuItem mi2 = new MenuItem();
            mi2.Header = clsAutocode.getChequeStatusName(ChequeStatus.Returned_NR_O);
            mi2.Tag = clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O);
            mi2.Click += Mi1_Click;

            MenuItem mi3 = new MenuItem();
            mi3.Header = clsAutocode.getChequeStatusName(ChequeStatus.Returned_R);
            mi3.Tag = clsAutocode.getChequeStatusID(ChequeStatus.Returned_R);
            mi3.Click += Mi1_Click;

            cm.Items.Add(mi1);
            cm.Items.Add(mi2);
            cm.Items.Add(mi3);
            #endregion

            #region Configarations
            sGLA_FactoringCharges = clsSecurity.GetCofigValue(228);
            sGLA_FactoringCharges_Vat = clsSecurity.GetCofigValue(229);
            sGLA_FactoringCharges_Nbt = clsSecurity.GetCofigValue(230);
            sGLA_FactoringContralAcc = clsSecurity.GetCofigValue(231);
            sGLA_ChequeInHand = clsSecurity.GetCofigValue(232);
            #endregion

            ClearFields();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(410);
            else
                coloumnA.Width = new GridLength(800);
        }

        #endregion

        #region Action Buttons
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;

                #region Factoring Approval
                if (btn_Factor.bBtnStatus)
                {
                    bool bStatus = false;
                    if (CheckValidity_factoring())
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show("Are You Sure...", "Do You Want to Approve Selected Factoring Schedules?", MessageBoxButton.YesNo);
                        if (bMessegeBoxResult)
                        {
                            //  string sbatchPostingID = "";
                            //  if (clsAutocode.IsAutoGenerated(sFormConfigBatchCode))
                            // {
                            //  sbatchPostingID = clsAutocode.getAutoGeneratedCode(sFormConfigBatchCode);
                            //   clsProcessMethods.GLBatchPostingHeader(clsSecurity.getServerDateTime(), "Factoring Approval", sbatchPostingID, false);
                            // }
                            //  if (sbatchPostingID != "")
                            //  {
                            foreach (DataRow row in dgr_Factoring.dt.Rows)
                            {
                                bool isApproved = bool.Parse(row["Approve"].ToString());
                                if (isApproved)
                                {
                                    string sSchedule_ID = row["factoringSehedule_ID"].ToString();

                                    tbl_bpsFactoringSchedule oSchedule = tbl_bpsFactoringSchedule.Select(sSchedule_ID);
                                    if (oSchedule != null && oSchedule.FactoringSehedule_ID != "default")
                                    {
                                        tbl_bpsFactoringAgreement oAgreement = tbl_bpsFactoringAgreement.Select(oSchedule.FactoringAgreement_ID, oSchedule.FactoringAgreement_Revision);
                                        if (oAgreement != null)
                                        {
                                            int iLine = 0;
                                            int iSlot_ID = clsAutocode.getAccSlotID(AccSlot.Factoring_Approval);
                                            //   string sPostingID = clsProcessMethods.GLPostingPosting(clsSecurity.getServerDateTime(), "Factoring Approval", sbatchPostingID, false, "default");
                                            string sPostingID = clsMethods_Fin.Update_Primary_TXN("default", iSlot_ID, oSchedule.FactoringSehedule_ID, oSchedule.ApprovedDate, "default", "default", "Factoring Approval");
                                            if (sPostingID != "")
                                            {
                                                string sGLA_FactoringBank_ID = clsMethods_Fin.getAccountCode_Bank(oAgreement.AccountNumber_Factoring);
                                                string sGLA_CurrentBank_ID = clsMethods_Fin.getAccountCode_Bank(oAgreement.AccountNumber_Current);
                                                if (sGLA_FactoringBank_ID != "default" && sGLA_CurrentBank_ID != "default")
                                                {
                                                    #region Insert Posting Details
                                                    //Credit Transaction                            
                                                    bool bPostingStatus2 = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_FactoringBank_ID, "default", "default", "default", "default", "default", oAgreement.AccountNumber_Factoring, "default", oSchedule.FactoringSehedule_ID, "default", oSchedule.ApprovedDate, "", oSchedule.FactoringAmount, true, "", "");
                                                    //Debit Transaction
                                                    bool bPostingStatus = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_CurrentBank_ID, "default", "default", "default", "default", "default", oAgreement.AccountNumber_Current, "default", oSchedule.FactoringSehedule_ID, "default", oSchedule.ApprovedDate, "", oSchedule.GrossFactoringAmount, false, "", "");
                                                    bPostingStatus = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_FactoringCharges, "default", "default", "default", "default", "default", "default", "default", oSchedule.FactoringSehedule_ID, "default", oSchedule.ApprovedDate, "", oSchedule.ServiceCharges, false, "", "");
                                                    if (oSchedule.VatTotal > 0)
                                                        bPostingStatus = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_FactoringCharges_Vat, "default", "default", "default", "default", "default", "default", "default", oSchedule.FactoringSehedule_ID, "default", oSchedule.ApprovedDate, "", oSchedule.VatTotal, false, "", "");
                                                    if (oSchedule.NbtTotal > 0)
                                                        bPostingStatus = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_FactoringCharges_Nbt, "default", "default", "default", "default", "default", "default", "default", oSchedule.FactoringSehedule_ID, "default", oSchedule.ApprovedDate, "", oSchedule.NbtTotal, false, "", "");
                                                    #endregion

                                                    #region Update Cheque Register and Schedule
                                                    foreach (tbl_bpsFactoringSchedule_detail odetail in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(sSchedule_ID))
                                                    {
                                                        tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(odetail.ChequeRegister_ID);
                                                        if (oCheque != null)
                                                        {
                                                            //  int iLine = 0;
                                                            string sPostingID3 = clsMethods_Fin.Update_Primary_TXN("default", iSlot_ID, odetail.ChequeRegister_ID, oSchedule.ApprovedDate, "default", "default", "Factoring Approval - Cheques");
                                                            oCheque.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Factored);
                                                            oCheque.Update();

                                                            //Credit Transaction                            
                                                            bool bPostingStatus4 = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_ChequeInHand, "default", "default", "default", "default", "default", "", "default", odetail.ChequeRegister_ID, oSchedule.FactoringSehedule_ID, oSchedule.ApprovedDate, "", oCheque.ChequeAmount, true, oCheque.ChequeNumber, "");
                                                            //Debit Transaction
                                                            bool bPostingStatus5 = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_FactoringContralAcc, "default", "default", "default", "default", "default", "", "default", odetail.ChequeRegister_ID, oSchedule.FactoringSehedule_ID, oSchedule.ApprovedDate, "", oCheque.ChequeAmount, false, oCheque.ChequeNumber, "");
                                                            bStatus = true;
                                                        }
                                                    }

                                                    oSchedule.IsApproved = true;

                                                    oSchedule.DateApproved = clsSecurity.getServerDateTime();
                                                    oSchedule.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                                    oSchedule.ApprovedTerminal_ID = clsSecurity.TerminalID;
                                                    oSchedule.ApprovedDate = dtpDeposit_Date.GetDateTime().Date;
                                                    oSchedule.Update();
                                                    #endregion
                                                }
                                                else
                                                    MessageBox.Show("Please Link Bank GL Code(s)", clsFormatter.GetMessageCaption());
                                            }
                                            else
                                                MessageBox.Show("Error", "Problem with posting header..");
                                        }
                                    }
                                }
                            }
                            if (bStatus)
                            {
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                btn_Factor_Click(null, null);
                            }
                            // }
                            //else
                            //    SEACCMessageBox.Show("Sorry..", "Their's a problem with GL posting batch ID..");
                        }
                    }
                }
                #endregion

                #region Factoring Deposit
                else if (btn_Deposit.bBtnStatus)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Are You Sure...", "Do You Want to Approve Selectd Factoring Schedules?", MessageBoxButton.YesNo);
                    if (bMessegeBoxResult)
                    {
                        if (CheckValidity_Deposit())
                        {
                            #region Get Posting Batch ID
                            //  string sbatchPostingID = "";
                            // if (clsAutocode.IsAutoGenerated(sFormConfigBatchCode))
                            // {
                            //     sbatchPostingID = clsAutocode.getAutoGeneratedCode(sFormConfigBatchCode);
                            //     clsProcessMethods.GLBatchPostingHeader(clsSecurity.getServerDateTime(), "Factoring Deposit", sbatchPostingID, false);
                            //  }
                            #endregion

                            foreach (DataRow row in dgr_Main.dt.Rows)
                            {
                                bool isCheked = bool.Parse(row["Check"].ToString());
                                if (isCheked)
                                {
                                    string sChequeredister_ID = row["chequeRegister_ID"].ToString();
                                    if (sChequeredister_ID.Length > 0)
                                    {
                                        tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sChequeredister_ID);
                                        if (register != null)
                                        {
                                            string sGLA_Fact_ClearanceBankAccID = "", sACC_Fact_ClearanceBankAccID = "", sBank_Code = "", sBranch_Code = "", sfactoringSchedule_ID = "";

                                            #region Get Acount codes
                                            foreach (tbl_bpsFactoringSchedule_detail oSheduleDetail in tbl_bpsFactoringSchedule_detail.SelectAllByChequeRegister_ID(sChequeredister_ID))
                                            {
                                                tbl_bpsFactoringSchedule oShedule = tbl_bpsFactoringSchedule.Select(oSheduleDetail.FactoringSehedule_ID);
                                                if (oShedule != null && !oShedule.IsDeleted)
                                                {
                                                    tbl_bpsFactoringAgreement oAgreement = tbl_bpsFactoringAgreement.Select(oShedule.FactoringAgreement_ID, oShedule.FactoringAgreement_Revision);
                                                    if (oAgreement != null)
                                                    {
                                                        sBank_Code = oAgreement.Bank_ID;
                                                        sBranch_Code = oAgreement.Branch_ID;
                                                        sACC_Fact_ClearanceBankAccID = oAgreement.AccountNumber_Clearing;
                                                        sGLA_Fact_ClearanceBankAccID = clsMethods_Fin.getAccountCode_Bank(oAgreement.AccountNumber_Clearing);
                                                        sfactoringSchedule_ID = oShedule.FactoringSehedule_ID;
                                                    }
                                                }
                                            }
                                            #endregion

                                            string sDeposit_ID = UserControls.clsCommon.getAutoGeneratedCode(FormName.Fac_ChequeMgt_Deposit);
                                            if (sDeposit_ID != "" && sGLA_Fact_ClearanceBankAccID != "default" && sfactoringSchedule_ID != "")
                                            {
                                                #region Insert Cheque deposit
                                                tbl_bpsChequeDeposit detail = new tbl_bpsChequeDeposit(sDeposit_ID, txtRemarks.Text.Trim(), dtpDeposit_Date.GetDateTime().Date,
                                                                                       decimal.Parse(lblSelected_Count.Text.Trim()), decimal.Parse(lblSelected_Amount.Text.Trim()), "", sACC_Fact_ClearanceBankAccID,
                                                                                       sBank_Code, sBranch_Code, clsSecurity.UserIDLoged, "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, clsSecurity.CompanyID, clsSecurity.BranchID, true);
                                                detail.Insert();

                                                tbl_bpsChequeDeposit_Detail items = new tbl_bpsChequeDeposit_Detail(sDeposit_ID, sChequeredister_ID, dtpDeposit_Date.GetDateTime().Date,
                                                                                                  "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, false);
                                                items.Insert();
                                                #endregion

                                                #region Update Cheque register
                                                register.IsDepositted = true;
                                                register.DateDeposited = dtpDeposit_Date.GetDateTime().Date;
                                                register.DepositedBank_ID = sBank_Code;
                                                register.DepositedBranch_ID = sBranch_Code;
                                                register.DepositedAccountNumber = sACC_Fact_ClearanceBankAccID;
                                                register.IsLocked = true;
                                                register.DepositCount += 1;
                                                register.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Factoring_Deposited);
                                                clsDB.update_CustomerDeposittedCheques(register.Customer_ID, register.ChequeAmount, register.AccountNumber);
                                                register.Update();
                                                #endregion

                                                int iLine = 0;
                                                int iSlot_ID = clsAutocode.getAccSlotID(AccSlot.factoring_Deposit);
                                                string sPostingID = clsMethods_Fin.Update_Primary_TXN("default", iSlot_ID, register.ChequeRegister_ID, register.DateDeposited, "default", "default", "Factoring Approval");
                                                if (sPostingID != "")
                                                {
                                                    //Credit Transaction                            
                                                    bool bPostingStatus4 = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_FactoringContralAcc, "default", "default", "default", "default", "default", "", "default", register.ChequeRegister_ID, sfactoringSchedule_ID, register.DateDeposited, "", register.ChequeAmount, true, register.ChequeNumber, "");
                                                    //Debit Transaction
                                                    bool bPostingStatus5 = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_Fact_ClearanceBankAccID, "default", "default", "default", "default", "default", "", "default", register.ChequeRegister_ID, sfactoringSchedule_ID, register.DateDeposited, "", register.ChequeAmount, false, register.ChequeNumber, "");
                                                    //    bStatus = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            //   if (sbatchPostingID != "")
                            //  {
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            btn_Deposit_Click(null, null);
                            // }
                            // else
                            //    SEACCMessageBox.Show("Sorry..", "Their's a problem with GL posting batch ID..");
                        }
                    }
                }
                #endregion

                #region Cheque Reconcilation
                else if (btn_Reconsilation.bBtnStatus)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Are You Sure...", "Do you want to reconcile selectd factoring schedules?", MessageBoxButton.YesNo);
                    if (bMessegeBoxResult)
                    {
                        if (CheckValidity_Reconsilation())
                        {
                            //   string sbatchPostingID = "";
                            // if (clsAutocode.IsAutoGenerated(sFormConfigBatchCode))
                            //  {
                            //   sbatchPostingID = clsAutocode.getAutoGeneratedCode(sFormConfigBatchCode);
                            //  clsProcessMethods.GLBatchPostingHeader(clsSecurity.getServerDateTime(), "Factoring Deposit", sbatchPostingID, false);
                            //  }
                            // if (sbatchPostingID != "")
                            //  {
                            #region Insert Header
                            tbl_bpsChequeReconciliation detail = new tbl_bpsChequeReconciliation(glbTransaction_ID, txtRemarks.Text, dtpDeposit_Date.GetDateTime().Date,
                                                                                               decimal.Parse(lblSelected_Count.Text), decimal.Parse(lblTotal_Amount.Text), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                                                                  "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                                                                   clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, clsSecurity.CompanyID, clsSecurity.BranchID);
                            detail.Insert();
                            #endregion

                            #region Insert Details
                            int lineNo = 1;
                            foreach (DataRow row in dgr_Reconcilation.dt.Rows)
                            {
                                bool isRealized = bool.Parse(row["realized"].ToString());
                                bool isReturned = bool.Parse(row["returned"].ToString());
                                if (isRealized || isReturned)
                                {
                                    string sChequeredister_ID = row["chequeRegister_ID"].ToString();
                                    //string sStatusID = row["statusID"].ToString();
                                    string sStatusID = row["chequeStatus_ID"].ToString();

                                    if (sChequeredister_ID.Length > 0)
                                    {
                                        tbl_bpsChequeReconciliation_Detail oReconcilation = new tbl_bpsChequeReconciliation_Detail(glbTransaction_ID, sChequeredister_ID, 0, sStatusID, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction));
                                        oReconcilation.Insert();

                                        tbl_bpsChequeRegister register = tbl_bpsChequeRegister.Select(sChequeredister_ID);
                                        if (register != null)
                                        {
                                            string sGLA_Fact_ClearanceBankAccID = "", sfactoringSchedule_ID = "", sGLA_Fact_ControlAccID = "";

                                            #region Check Clearance Bank Acc ID, Factoring Schedule ID and Controll Acc ID
                                            foreach (tbl_bpsFactoringSchedule_detail oSheduleDetail in tbl_bpsFactoringSchedule_detail.SelectAllByChequeRegister_ID(sChequeredister_ID))
                                            {
                                                tbl_bpsFactoringSchedule oShedule = tbl_bpsFactoringSchedule.Select(oSheduleDetail.FactoringSehedule_ID);
                                                if (oShedule != null)
                                                {
                                                    tbl_bpsFactoringAgreement oAgreement = tbl_bpsFactoringAgreement.Select(oShedule.FactoringAgreement_ID, oShedule.FactoringAgreement_Revision);
                                                    if (oAgreement != null)
                                                    {
                                                        sGLA_Fact_ClearanceBankAccID = clsMethods_Fin.getAccountCode_Bank(oAgreement.AccountNumber_Clearing);
                                                        sfactoringSchedule_ID = oShedule.FactoringSehedule_ID;
                                                        sGLA_Fact_ControlAccID = clsMethods_Fin.getAccountCode_Bank(oAgreement.AccountNumber_Factoring);
                                                    }
                                                }
                                            }
                                            #endregion

                                            if (sGLA_Fact_ClearanceBankAccID != "default" && sGLA_Fact_ControlAccID != "default" && sfactoringSchedule_ID != "")
                                            {
                                                #region Realized Cheque
                                                if (isRealized)
                                                {
                                                    clsDB.update_CustomerRealizedCheques(register.Customer_ID, register.ChequeAmount, register.AccountNumber);
                                                    register.DateReconcilied = dtpDeposit_Date.GetDateTime().Date;
                                                    register.IsReconcilied = true;
                                                    register.IsLocked = true;
                                                    register.ChequeStatus_ID = sStatusID;
                                                    register.Update();

                                                    int iLine = 0;
                                                    int iSlot_ID = clsAutocode.getAccSlotID(AccSlot.ChequeRealized);
                                                    string sPostingID = clsMethods_Fin.Update_Primary_TXN("default", iSlot_ID, register.ChequeRegister_ID, register.DateDeposited, "default", "default", "Factoring Cheque realized");
                                                    if (sPostingID != "")
                                                    {
                                                        //Credit Transaction                            
                                                        bool bPostingStatus4 = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_FactoringContralAcc, "default", "default", "default", "default", "default", "", "default", register.ChequeRegister_ID, sfactoringSchedule_ID, register.DateDeposited, "", register.ChequeAmount, true, register.ChequeNumber, "");
                                                        //Debit Transaction
                                                        bool bPostingStatus5 = clsMethods_Fin.Update_Secondary_TXN(++iLine, sPostingID, iSlot_ID, sGLA_Fact_ClearanceBankAccID, "default", "default", "default", "default", "default", "", "default", register.ChequeRegister_ID, sfactoringSchedule_ID, register.DateDeposited, "", register.ChequeAmount, false, register.ChequeNumber, "");
                                                        //    bStatus = true;
                                                    }

                                                }
                                                #endregion

                                                #region Returned Cheque
                                                else
                                                {
                                                    #region Retern Cheque - Debit Note
                                                    register.IsReturned = true;
                                                    string sDebitNoteID = "";
                                                    if (clsAutocode.IsAutoGenerated(sFormConfigReturnedCheque))
                                                        sDebitNoteID = clsAutocode.getAutoGeneratedCode(sFormConfigReturnedCheque);

                                                    //Invoice Header
                                                    tbl_sasInvoice objInvoice = new tbl_sasInvoice(sDebitNoteID, dtpDeposit_Date.GetDateTime().Date, "Returned Cheque(Factoring) / Deibt Note",
                                                         "", clsCommon.CurrencyToWord(register.ChequeAmount), register.Customer_ID, "default", "default", "default", "default", clsHelpMethods.getEmployeeIDFromReceiptID(register.Receipt_ID), register.OrderRefNo_ID, register.ChequeRegister_ID,
                                                         clsConfig.sLocalCurrencyCode, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                                                         1, 0, 0, 0, 0, 0, 0, 0, register.ChequeAmount, 0, 0, 0, 0, 0, 0, 0, register.ChequeAmount, 0, 0,
                                                         clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                                                         clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                         clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                         false, false, true, false, "", "", "", clsSecurity.getServerDateTime().AddDays(30), true, 0, false, false, 0, false, false, true, false, false, false, false, false, false, "default", "", "default", false, register.CompanyID, register.CompanyBranch_ID, false, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                                                    objInvoice.Insert();

                                                    clsDB.update_CustomerReturnedCheques(register.Customer_ID, register.ChequeAmount, register.AccountNumber);
                                                    clsDB.update_CustomerDeposittedChequesFromReturns(register.Customer_ID, register.ChequeAmount, register.AccountNumber);
                                                    #endregion

                                                    register.DateReconcilied = dtpDeposit_Date.GetDateTime().Date;
                                                    register.IsReconcilied = true;
                                                    register.IsLocked = true;
                                                    register.ChequeStatus_ID = sStatusID;
                                                    register.Update();

                                                    oReconcilation.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                    oReconcilation.GlPosting_ID = "";
                                                    oReconcilation.Update();


                                                    //if (clsConfig.bAutoPostingEnable_ChequeReturned)
                                                    //{
                                                    //    //Add Cheque Deposited Posting Method
                                                    //    if (!bISBatchID)
                                                    //    {
                                                    //        if (clsAutocode.IsAutoGenerated(sFormConfigBatchCode))
                                                    //            sbatchPostingID = clsAutocode.getAutoGeneratedCode(sFormConfigBatchCode);

                                                    //        #region Insert Batch ID for the Posting
                                                    //        clsEvent.GLBatchPostingHeader(clsSecurity.getServerDateTime(), "CHEQ.RETURNDED", sbatchPostingID, false);
                                                    //        #endregion

                                                    //        bISBatchID = true;
                                                    //    }
                                                    //    bChequeReturnedAutoPostingStatus = chequeReturnedAutoPosting(sRegisterCode, dtpReconciliationDateIN.Value, sbatchPostingID);
                                                    //}
                                                }
                                                #endregion
                                            }
                                        }
                                        else
                                        {

                                        }
                                        lineNo++;
                                    }
                                }
                            }
                            #endregion

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            btn_Reconsilation_Click(null, null);
                            //  }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }
        #endregion
        
        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            glbTransaction_ID = "";

            dgr_Factoring.dt.Clear();
            dgr_Main.dt.Clear();
            dgr_Reconcilation.dt.Clear();

            dgr_Factoring.Visibility = Visibility.Hidden;
            dgr_Main.Visibility = Visibility.Hidden;
            dgr_Reconcilation.Visibility = Visibility.Hidden;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAcc_NO, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpDeposit_Date, true,false);

            txtAcc_NO.Tag = null;

            txtAcc_NO.Text = "<SELECT ACCOUNT>";
            txtRemarks.Text = "";

            lblbank.Tag = null;
            lblbranch.Tag = null;
            lblbank.Text = " - ";
            lblbranch.Text = " - ";
        }
        #endregion

        #region Refresh Grid
        private void btn_Factor_Click(object sender, MouseButtonEventArgs e)
        {
            ClearFields();
            dgr_Factoring.Visibility = Visibility.Visible;

            dgr_Factoring.dt = DBHandling.ExecQuery("sp_ChequesToBeFacterd").Tables[0];
            dgr_Factoring.RefreshGrid();

            lblTotal_Count.Text = cls_Formater.FormatDecimal(dgr_Factoring.dt.Rows.Count, 0);
            try
            {
                decimal sumObject = decimal.Parse(dgr_Factoring.dt.Compute("Sum(grossFactoringAmount_1)", "").ToString());
                lblTotal_Amount.Text = cls_Formater.FormatDecimal(sumObject, 2);
            }
            catch (Exception) { }

            lblSelected_Amount.Text = cls_Formater.FormatDecimal(0, 2);
            lblSelected_Count.Text = cls_Formater.FormatDecimal(0, 0);

            txtAcc_NO.Visibility = Visibility.Collapsed;
            grdBankDetail.Visibility = Visibility.Collapsed;
            dtpDeposit_Date.Caption = "Approval Date";
            txtRemarks.Visibility = Visibility.Collapsed;

            btn_Factor.SetStatus(true);
            btn_Deposit.SetStatus(false);
            btn_Reconsilation.SetStatus(false);
        }

        private void btn_Deposit_Click(object sender, MouseButtonEventArgs e)
        {
            ClearFields();
            dgr_Main.Visibility = Visibility.Visible;

            dgr_Main.dt = DBHandling.ExecQuery("sp_ChequesToBeDeposited").Tables[0];
            dgr_Main.RefreshGrid();

            lblTotal_Count.Text = cls_Formater.FormatDecimal(dgr_Main.dt.Rows.Count, 0);
            try
            {
                decimal sumObject = decimal.Parse(dgr_Main.dt.Compute("Sum(chequeAmount)", "").ToString());
                lblTotal_Amount.Text = cls_Formater.FormatDecimal(sumObject, 2);
            }
            catch (Exception) { }

            lblSelected_Amount.Text = cls_Formater.FormatDecimal(0, 2);
            lblSelected_Count.Text = cls_Formater.FormatDecimal(0, 0);

            //txtAcc_NO.Visibility = Visibility.Collapsed;
            //grdBankDetail.Visibility = Visibility.Collapsed;
            //dtpDeposit_Date.Caption = "Deposit Date";
            //txtRemarks.Visibility = Visibility.Visible;

            txtAcc_NO.Visibility = Visibility.Collapsed;
            grdBankDetail.Visibility = Visibility.Collapsed;
            dtpDeposit_Date.Caption = "Deposit Date";
            txtRemarks.Visibility = Visibility.Visible;

            btn_Factor.SetStatus(false);
            btn_Deposit.SetStatus(true);
            btn_Reconsilation.SetStatus(false);
        }

        private void btn_Reconsilation_Click(object sender, MouseButtonEventArgs e)
        {
            ClearFields();
            dgr_Reconcilation.Visibility = Visibility.Visible;

            dgr_Reconcilation.dt = DBHandling.ExecQuery("sp_ChequesToBeRealized").Tables[0];
            dgr_Reconcilation.RefreshGrid();

            lblTotal_Count.Text = cls_Formater.FormatDecimal(dgr_Reconcilation.dt.Rows.Count, 0);
            try
            {
                decimal sumObject = decimal.Parse(dgr_Reconcilation.dt.Compute("Sum(chequeAmount)", "").ToString());
                lblTotal_Amount.Text = cls_Formater.FormatDecimal(sumObject, 2);
            }
            catch (Exception) { }

            lblSelected_Amount.Text = cls_Formater.FormatDecimal(0, 2);
            lblSelected_Count.Text = cls_Formater.FormatDecimal(0, 0);

            //txtAcc_NO.Visibility = Visibility.Visible;
            //grdBankDetail.Visibility = Visibility.Visible;
            //dtpDeposit_Date.Caption = "Deposit Date";
            //txtRemarks.Visibility = Visibility.Visible;

            txtAcc_NO.Visibility = Visibility.Collapsed;
            grdBankDetail.Visibility = Visibility.Collapsed;
            dtpDeposit_Date.Caption = "Deposit Date";
            txtRemarks.Visibility = Visibility.Visible;

            btn_Factor.SetStatus(false);
            btn_Deposit.SetStatus(false);
            btn_Reconsilation.SetStatus(true);
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity_factoring()
        {
            string sMessege = "";
            bool bStatus = true;

            if (bStatus=CheckValidity_SelectedCount())
            {
                foreach (DataRow row in dgr_Factoring.dt.Rows)
                {
                    bool isApproved = bool.Parse(row["Approve"].ToString());

                    if (isApproved)
                    {
                        string sSchedule_ID = row["factoringSehedule_ID"].ToString();

                        tbl_bpsFactoringSchedule oSchedule = tbl_bpsFactoringSchedule.Select(sSchedule_ID);
                        if (oSchedule != null && oSchedule.FactoringSehedule_ID != "default")
                        {
                            if (oSchedule.IsApproved)
                            {
                                sMessege = "Sehedule ID - " + sSchedule_ID + " is already approved..!";
                                bStatus = false;
                            }
                            if (oSchedule.IsDeleted)
                            {
                                sMessege += ((sMessege.Length != 0) ? "\n\n" : "") + "Cannot factor canceled records       Sehedule ID - " + sSchedule_ID;
                                bStatus = false;
                            }

                            tbl_bpsFactoringAgreement oAgreement = tbl_bpsFactoringAgreement.Select(oSchedule.FactoringAgreement_ID, oSchedule.FactoringAgreement_Revision);
                            if (oAgreement != null)
                            {
                                string sGLA_FactoringBank_ID = clsMethods_Fin.getAccountCode_Bank(oAgreement.AccountNumber_Factoring);
                                if (sGLA_FactoringBank_ID == "default" )
                                {
                                    sMessege += ((sMessege.Length != 0) ? "\n\n" : "") + "Please Link GL Code(s) for bank accounts <" + oAgreement.AccountNumber_Factoring + ">";
                                    bStatus = false;
                                }
                                string sGLA_CurrentBank_ID = clsMethods_Fin.getAccountCode_Bank(oAgreement.AccountNumber_Current);
                                if ( sGLA_CurrentBank_ID == "default")
                                {
                                    sMessege += ((sMessege.Length != 0) ? "\n" : "") + "Please Link GL Code(s) for bank accounts <" + oAgreement.AccountNumber_Current + ">";
                                    bStatus = false;
                                }
                            }
                            if (!bStatus)
                            {
                                foreach (tbl_bpsFactoringSchedule_detail odetail in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(sSchedule_ID))
                                {
                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(odetail.ChequeRegister_ID);
                                    if (oCheque != null)
                                    {
                                        if (oCheque.IsDeleted)
                                        {
                                            sMessege += ((sMessege.Length != 0) ? "\n\n" : "") + "Cannot factor canceled cheques        Cheque no - " + oCheque.ChequeNumber;
                                            bStatus = false;
                                        }
                                        if (oCheque.ChequeStatus_ID != "10")
                                        {
                                            sMessege += ((sMessege.Length != 0) ? "\n\n" : "") + "Please Consider the Cheque status     Cheque no - " + oCheque.ChequeNumber;
                                            bStatus = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (!bStatus)
                    SEACCMessageBox.Show("Something Went wrong...!", sMessege, MessageBoxButton.OK);
            }
            return bStatus;
        }

        private bool CheckValidity_Deposit()
        {
            bool bStatus = false;

            if (CheckValidity_SelectedCount())
            {
                bStatus = true;
                //#region Serial No Validity
                //if (!SEACC_Form.IsUpdateMode)
                //{
                //    if (btn_Deposit.bBtnStatus)
                //    {
                //        glbTransaction_ID = SEACC_FACTORING.UserControls.clsCommon.getAutoGeneratedCode(FormName.Fac_ChequeMgt_Deposit);

                //        if (glbTransaction_ID != "")
                //        {
                //            tbl_bpsFactoringSchedule detail = tbl_bpsFactoringSchedule.Select(glbTransaction_ID);
                //            if (detail != null)
                //            {
                //                bStatus = false;
                //                SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                //            }
                //        }
                //    }
                //}
                //#endregion
            }

            return bStatus;
        }

        private bool CheckValidity_Reconsilation()
        {
            bool bStatus = false;
            if (CheckValidity_SelectedCount())
            {
                if (CheckValidity_EmptiField())
                {
                    bStatus = true;
                    #region Serial No Validity
                    if (!SEACC_Form.IsUpdateMode)
                    {
                        if (btn_Reconsilation.bBtnStatus)
                        {
                            glbTransaction_ID = SEACC_FACTORING.UserControls.clsCommon.getAutoGeneratedCode(FormName.Fac_ChequeMgt_Reconcilation);

                            if (glbTransaction_ID != "")
                            {
                                tbl_bpsFactoringSchedule detail = tbl_bpsFactoringSchedule.Select(glbTransaction_ID);
                                if (detail != null)
                                {
                                    bStatus = false;
                                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptiField()
        {
            string strMessage = "";
            bool bStatus = true;

            //if (!clsValidation.Validate_EmptyTag(txtAcc_NO, ref strMessage))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyTag(lblbank, ref strMessage, "Bank"))
            //    bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage);

            return bStatus;
        }

        private bool CheckValidity_SelectedCount()
        {
            bool bStatus = false;
            try
            {
                decimal CountObject = decimal.Parse(lblSelected_Count.Text);
                if (CountObject > 0)
                    bStatus = true;
            }
            catch (Exception) { }

            if (!bStatus)
                SEACCMessageBox.Show("Please select one or more cheque/s to proceed...!", "", MessageBoxButton.OK);
            return bStatus;
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            //int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();
            object oSelectedItem = dgr_Main.grdMain.SelectedItem;

            bool bCheque = false;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Check")
                {
                    DataRowView dataRow = (DataRowView)oSelectedItem;
                    string sDataGridRowNo = dataRow["chequeNumber"].ToString();

                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        string sDataTableRowNo = row["chequeNumber"].ToString();
                        if (sDataTableRowNo == sDataGridRowNo)
                        {
                            bCheque = row["Check"].ToString() == "True" ? false : true;
                            row["Check"] = bCheque;
                        }
                    }

                    //bCheque = dgr_Main.dt.Rows[irowID]["Check"].ToString() == "True" ? false : true;
                    //dgr_Main.dt.Rows[irowID]["Check"] = bCheque;
                    decimal sumObject = 0, CountObject = 0;
                    
                    try
                    {
                        sumObject = decimal.Parse(dgr_Main.dt.Compute("Sum(chequeAmount)", "Check='True'").ToString());
                        CountObject = decimal.Parse(dgr_Main.dt.Compute("count(chequeAmount)", "Check='True'").ToString());
                    }
                    catch (Exception)
                    {
                    }

                    lblSelected_Amount.Text = cls_Formater.FormatDecimal(sumObject, 2);
                    lblSelected_Count.Text = cls_Formater.FormatDecimal(CountObject, 0);
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgr_Factoring_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Factoring.SelectedIndex;
            var vDG_Cell = dgr_Factoring.GetCurrentCell();
            object oSelectedItem = dgr_Factoring.grdMain.SelectedItem;

            bool bFactoring = true;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Approve")
                {
                    DataRowView dataRow = (DataRowView)oSelectedItem;
                    string sDataGridRowNo = dataRow["factoringSehedule_ID"].ToString();

                    foreach (DataRow row in dgr_Factoring.dt.Rows)
                    {
                        string sDataTableRowNo = row["factoringSehedule_ID"].ToString();
                        if (sDataTableRowNo == sDataGridRowNo)
                        {
                            bFactoring = row["Approve"].ToString() == "True" ? false : true;
                            row["Approve"] = bFactoring;
                        }
                    }

                    //bFactoring = dgr_Factoring.dt.Rows[irowID]["Approve"].ToString() == "True" ? false : true;
                    //dgr_Factoring.dt.Rows[irowID]["Approve"] = bFactoring;

                    decimal sumObject = 0, CountObject = 0;
                    try
                    {
                        sumObject = decimal.Parse(dgr_Factoring.dt.Compute("Sum(grossFactoringAmount_1)", "Approve='True'").ToString());
                        CountObject = decimal.Parse(dgr_Factoring.dt.Compute("count(grossFactoringAmount_1)", "Approve='True'").ToString());
                    }
                    catch (Exception)
                    {
                    }

                    lblSelected_Amount.Text = cls_Formater.FormatDecimal(sumObject, 2);
                    lblSelected_Count.Text = cls_Formater.FormatDecimal(CountObject, 0);
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgr_Reconcilation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)//
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            if (!(dep is ScrollViewer) && !(dep is Popup))
            {
                int irowID = dgr_Reconcilation.SelectedIndex;
                var vDG_Cell = dgr_Reconcilation.GetCurrentCell();
                object oSelectedItem = dgr_Reconcilation.grdMain.SelectedItem;

                try
                {
                    DataRowView dataRow = (DataRowView)oSelectedItem;
                    string sDataGridRowNo = dataRow["chequeNumber"].ToString();

                    foreach (DataRow row in dgr_Reconcilation.dt.Rows)
                    {
                        string sDataTableRowNo = row["chequeNumber"].ToString();
                        if (sDataTableRowNo == sDataGridRowNo)
                        {
                            if (vDG_Cell.Column.SortMemberPath == "statusName")
                            {
                                if (row["returned"].ToString() == "True")
                                    cm.IsOpen = true;
                            }
                            else if (vDG_Cell.Column.SortMemberPath == "realized" || vDG_Cell.Column.SortMemberPath == "returned")
                            {
                                bool isRealized = false, isReturned = false;
                                string sStatuSanme = clsAutocode.getChequeStatusName(ChequeStatus.Factoring_Deposited), sStatusID = clsAutocode.getChequeStatusID(ChequeStatus.Factoring_Deposited);

                                if (vDG_Cell.Column.SortMemberPath == "realized")
                                {
                                    isRealized = row["realized"].ToString() == "True" ? false : true;
                                    if (isRealized)
                                    {
                                        isReturned = !isRealized;
                                        sStatuSanme = clsAutocode.getChequeStatusName(ChequeStatus.Realized);
                                        sStatusID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                                    }
                                }
                                else if (vDG_Cell.Column.SortMemberPath == "returned")
                                {
                                    isReturned = row["returned"].ToString() == "True" ? false : true;
                                    if (isReturned)
                                    {
                                        isRealized = !isReturned;
                                        sStatuSanme = clsAutocode.getChequeStatusName(ChequeStatus.Returned_NR_C);
                                        sStatusID = clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C);
                                    }
                                }
                                row["realized"] = isRealized;
                                row["returned"] = isReturned;

                                row["chequeStatus_ID"] = sStatusID;
                                row["statusName"] = sStatuSanme;

                                decimal sumObject = 0, CountObject = 0;
                                try
                                {
                                    sumObject = decimal.Parse(dgr_Reconcilation.dt.Compute("Sum(chequeAmount)", "realized='True' or returned='True'").ToString());
                                    CountObject = decimal.Parse(dgr_Reconcilation.dt.Compute("count(chequeAmount)", "realized='True' or returned='True'").ToString());
                                }
                                catch (Exception) { }

                                lblSelected_Amount.Text = cls_Formater.FormatDecimal(sumObject, 2);
                                lblSelected_Count.Text = cls_Formater.FormatDecimal(CountObject, 0);

                                if (isReturned)
                                    cm.IsOpen = true;
                            }

                        }
                    }


                    #region Old Code in  Old Place
                    //if (vDG_Cell.Column.SortMemberPath == "statusName")
                    //{
                    //    if (dgr_Reconcilation.dt.Rows[irowID]["returned"].ToString() == "True")
                    //        cm.IsOpen = true;
                    //}
                    //else if (vDG_Cell.Column.SortMemberPath == "realized" || vDG_Cell.Column.SortMemberPath == "returned")
                    //{
                    //    bool isRealized = false, isReturned = false;
                    //    string sStatuSanme = clsAutocode.getChequeStatusName(ChequeStatus.Factoring_Deposited), sStatusID = clsAutocode.getChequeStatusID(ChequeStatus.Factoring_Deposited);

                    //    if (vDG_Cell.Column.SortMemberPath == "realized")
                    //    {
                    //        isRealized = dgr_Reconcilation.dt.Rows[irowID]["realized"].ToString() == "True" ? false : true;
                    //        if (isRealized)
                    //        {
                    //            isReturned = !isRealized;
                    //            sStatuSanme = clsAutocode.getChequeStatusName(ChequeStatus.Realized);
                    //            sStatusID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
                    //        }
                    //    }
                    //    else if (vDG_Cell.Column.SortMemberPath == "returned")
                    //    {
                    //        isReturned = dgr_Reconcilation.dt.Rows[irowID]["returned"].ToString() == "True" ? false : true;
                    //        if (isReturned)
                    //        {
                    //            isRealized = !isReturned;
                    //            sStatuSanme = clsAutocode.getChequeStatusName(ChequeStatus.Returned_NR_C);
                    //            sStatusID = clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C);
                    //        }
                    //    }
                    //    dgr_Reconcilation.dt.Rows[irowID]["realized"] = isRealized;
                    //    dgr_Reconcilation.dt.Rows[irowID]["returned"] = isReturned;

                    //    dgr_Reconcilation.dt.Rows[irowID]["chequeStatus_ID"] = sStatusID;
                    //    dgr_Reconcilation.dt.Rows[irowID]["statusName"] = sStatuSanme;

                    //    decimal sumObject = 0, CountObject = 0;
                    //    try
                    //    {
                    //        sumObject = decimal.Parse(dgr_Reconcilation.dt.Compute("Sum(chequeAmount)", "realized='True' or returned='True'").ToString());
                    //        CountObject = decimal.Parse(dgr_Reconcilation.dt.Compute("count(chequeAmount)", "realized='True' or returned='True'").ToString());
                    //    }
                    //    catch (Exception) { }

                    //    lblSelected_Amount.Text = cls_Formater.FormatDecimal(sumObject, 2);
                    //    lblSelected_Count.Text = cls_Formater.FormatDecimal(CountObject, 0);

                    //    if (isReturned)
                    //        cm.IsOpen = true;
                    //} 
                    #endregion
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion

        #region Search Event
        private void txtAcc_NO_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
            if (RowDataSearch.DialogResult == true)
            {
                txtAcc_NO.Text = lstResult[0];
                txtAcc_NO.Tag = lstResult[0];
                lblbank.Tag = lstResult[1];
                lblbank.Text = lstResult[2];
                lblbranch.Tag = lstResult[3];
                lblbranch.Text = lstResult[4];
            }
        } 
        #endregion

        private void Mi1_Click(object sender, RoutedEventArgs e)
        {
            MenuItem a = sender as MenuItem;
            //int irowID = dgr_Reconcilation.SelectedIndex;
            object oSelectedItem = dgr_Reconcilation.grdMain.SelectedItem;

            DataRowView dataRow = (DataRowView)oSelectedItem;
            string sDataGridRowNo = dataRow["chequeNumber"].ToString();

            foreach (DataRow row in dgr_Reconcilation.dt.Rows)
            {
                string sDataTableRowNo = row["chequeNumber"].ToString();
                if (sDataTableRowNo == sDataGridRowNo)
                {
                    row["chequeStatus_ID"] = a.Tag.ToString();
                    row["statusName"] = a.Header.ToString();
                }
            }

            //dgr_Reconcilation.dt.Rows[irowID]["chequeStatus_ID"] = a.Tag.ToString();
            //dgr_Reconcilation.dt.Rows[irowID]["statusName"] = a.Header.ToString();
        }
    }
}