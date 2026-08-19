using Digiteq_Logic;
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
using SEACC_WPFControls;
using DataTire;
using SEACC_FACTORING.Reports;

namespace SEACC_FACTORING.Masters
{
    public partial class UC_Factoring_Agreement : UserControl
    {
        #region Form Load
        public UC_Factoring_Agreement()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_Agrement;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("Agreement_ID");
            dgr_Main.dt.Columns.Add("Agreement_Rev");
            dgr_Main.dt.Columns.Add("Agreement_Display");
            dgr_Main.dt.Columns.Add("Bank");
            dgr_Main.dt.Columns.Add("BankBranch");
            dgr_Main.dt.Columns.Add("AccNo");
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Agreement ID", "Agreement_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Agreement Revision", "Agreement_Rev", 70, false);
            dgr_Main.Add_DatagridColoumn("Agreement Code", "Agreement_Display", 100);
            dgr_Main.Add_DatagridColoumn("Bank", "Bank", 140);
            dgr_Main.Add_DatagridColoumn("Bank Branch", "BankBranch", 80);
            dgr_Main.Add_DatagridColoumn("Acc No", "AccNo", 120);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                coloumnA.Width = new GridLength(200);
            else
                coloumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtAgreement_ID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_bpsFactoringAgreement Details = tbl_bpsFactoringAgreement.Select(txtAgreement_ID.Tag.ToString(), txtAgrement_Rev.Tag.ToString());
                            if (Details != null)
                            {
                                Details.IsDeleted = true;
                                Details.DateDeleted = clsSecurity.getServerDateTime();
                                Details.DeletedUser_ID = clsSecurity.UserIDLoged;
                                Details.DeletedTerminal_ID = clsSecurity.TerminalID;
                                Details.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
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

        private void Btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAgreement_ID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermisshion_ToPrint())
                    {
                        tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.factoringAgreement);
                        if (oReports != null)
                        {
                            DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                            DataSets.dts_Factoring dts_factoring = new DataSets.dts_Factoring();
                            dts_factoring.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, "");
                            //dts_factoring.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsSecurity.CompanyName), clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, "");

                            tbl_bpsFactoringAgreement details = tbl_bpsFactoringAgreement.Select(txtAgreement_ID.Tag.ToString(), txtAgrement_Rev.Tag.ToString());
                            if (details != null)
                            {
                                //fill data table hear
                                dts_factoring.dt_FactoringAgreement.Adddt_FactoringAgreementRow(txtAgreement_ID.Tag.ToString(), txtAgreement_reference1.Text, txtAgreement_reference2.Text, 
                                    dtpValid_From.GetDateTime().Date, dtpValid_To.GetDateTime().Date, clsRef_Name.get_Bank_Name(txtBank_ID.Tag.ToString()), clsRef_Name.get_BankBranch_Name(txtBankBranch.Tag.ToString()), txtAcc_NO_Factoring.Text, txtAcc_NO_current.Text, 
                                    txtAcc_NO_clearing.Text, decimal.Parse(txtCredit_Limit.Text), int.Parse(txtCredit_Period.Text), int.Parse(txtrecurse_Period.Text), decimal.Parse(txtService_fee_pct.Text), decimal.Parse(txtFactoring_Rate.Text),
                                    decimal.Parse(txtIntCredit.Text), decimal.Parse(txtIntRecurse.Text), decimal.Parse(txtService_fee_minimum.Text), txtRemarks.Text, txtAgrement_Rev.Tag.ToString());

                                frm_ReportViwer CRViwer = new frm_ReportViwer();
                                CRViwer.Print(oReports.ReportPath, dts_factoring, glb_dts_ExportReport.dt_rptParameter);

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

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    string sAgr = "";
                    string sRv = "";
                    try
                    {
                        Cursor = Cursors.Wait;
                        sAgr = txtAgreement_ID.Tag.ToString(); ;
                        sRv = txtAgrement_Rev.Tag.ToString();

                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_bpsFactoringAgreement oldRecord = tbl_bpsFactoringAgreement.Select(txtAgreement_ID.Tag.ToString(), txtAgrement_Rev.Tag.ToString());
                            if (!oldRecord.IsActive)
                            {
                                SEACCMessageBox.Show("Inactive record","Can not update inactive records" , MessageBoxButton.OK, "");
                            }
                            else { 
                                if (oldRecord != null)
                                {
                                    string sRev = oldRecord.FactoringAgreement_Revision;
                                    decimal dInterstCreadit = decimal.Parse(txtIntCredit.Text);
                                    decimal dInterstRecource = decimal.Parse(txtIntRecurse.Text);
                                    string sInterestrate_ID = oldRecord.FactoringInterest_ID;
                                    string sRef1 = txtAgreement_reference1.Text;
                                    string sRef2 = txtAgreement_reference2.Text;
                                    string sRemarks = txtRemarks.Text;
                                    decimal dCreaditlimit = decimal.Parse(txtCredit_Limit.Text);
                                    decimal dFactoringRate = decimal.Parse(txtFactoring_Rate.Text);
                                    int iCreaditPeriod = int.Parse(txtCredit_Period.Text);
                                    int iRecourcePeriod = int.Parse(txtrecurse_Period.Text);
                                    decimal dServiceFeePrec = decimal.Parse(txtService_fee_pct.Text);
                                    decimal dServiceFeemin = decimal.Parse(txtService_fee_minimum.Text);

                                    #region Insert Interest
                                    tbl_bpsFactoringInterest oldint = tbl_bpsFactoringInterest.Select(oldRecord.FactoringInterest_ID);
                                    if (oldint != null)
                                    {
                                        if (oldint.Interest_Credit != dInterstCreadit || oldint.Interest_Recurse != dInterstRecource)
                                        {
                                            sInterestrate_ID = UserControls.clsCommon.getAutoGeneratedCode(FormName.Fac_Interest);
                                            tbl_bpsFactoringInterest oInterest = new tbl_bpsFactoringInterest(sInterestrate_ID, dInterstCreadit, dInterstRecource, txtAgreement_ID.Tag.ToString(), clsSecurity.UserIDLoged,
                                                "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                                            oInterest.Insert();
                                        }
                                    }
                                    #endregion
                                    if (sRef1 != oldRecord.Ref1 || sRef2 != oldRecord.Ref2 || dCreaditlimit != oldRecord.Credit_Limit || dFactoringRate != oldRecord.Factoring_Rate || iCreaditPeriod != oldRecord.Credit_Period || iRecourcePeriod != oldRecord.Recourse_Period || dServiceFeePrec != oldRecord.ServiceCharge_presentage || dServiceFeemin != oldRecord.ServiceCharge_min)
                                    {
                                        #region Get Rev NO
                                        char[] c = sRev.ToCharArray();
                                        char[] d = { (char)(char.ToUpper(c[0]) + 1) };
                                        sRev = new string(d);
                                        #endregion

                                        tbl_bpsFactoringAgreement detail = new tbl_bpsFactoringAgreement(oldRecord.FactoringAgreement_ID, sRev, sRef1, sRef2, sRemarks, 0, dtpValid_From.GetDateTime().Date, dtpValid_To.GetDateTime().Date, txtAcc_NO_Factoring.Text,
                                        txtAcc_NO_current.Text, txtAcc_NO_clearing.Text, txtBank_ID.Tag.ToString(), txtBankBranch.Tag.ToString(), dCreaditlimit, dFactoringRate, iCreaditPeriod, iRecourcePeriod, dServiceFeePrec, dServiceFeemin,
                                        sInterestrate_ID, true, oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID, oldRecord.DateCreate,
                                        clsSecurity.getServerDateTime(), oldRecord.DateChecked, oldRecord.DateApproved, oldRecord.DateDeleted, oldRecord.DatePrinted, oldRecord.IsDeleted);
                                        detail.Insert();

                                        oldRecord.IsActive = false;
                                        oldRecord.Update();
                                    }
                                    else
                                    {
                                        tbl_bpsFactoringAgreement detail = new tbl_bpsFactoringAgreement(oldRecord.FactoringAgreement_ID, sRev, sRef1, sRef2, sRemarks, 0, dtpValid_From.GetDateTime().Date, dtpValid_To.GetDateTime().Date, txtAcc_NO_Factoring.Text,
                                                                           txtAcc_NO_current.Text, txtAcc_NO_clearing.Text, txtBank_ID.Tag.ToString(), txtBankBranch.Tag.ToString(), dCreaditlimit, dFactoringRate, iCreaditPeriod, iRecourcePeriod, dServiceFeePrec, dServiceFeemin,
                                                                           sInterestrate_ID, true, clsSecurity.UserIDLoged, "default", "default", "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(),
                                  clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, false);
                                        detail.Update();
                                    }
                                    sRv = sRev;
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                        }
                        }
                        #endregion
                        #region Insert
                        else
                        {
                            string sInterestrate_ID = UserControls.clsCommon.getAutoGeneratedCode(FormName.Fac_Interest);
                            tbl_bpsFactoringInterest oInterest = new tbl_bpsFactoringInterest(sInterestrate_ID, decimal.Parse(txtIntCredit.Text), decimal.Parse(txtIntRecurse.Text), txtAgreement_ID.Tag.ToString(), clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                            oInterest.Insert();

                            tbl_bpsFactoringAgreement detail = new tbl_bpsFactoringAgreement(txtAgreement_ID.Tag.ToString(), txtAgrement_Rev.Tag.ToString(), txtAgreement_reference1.Text, txtAgreement_reference2.Text,
                                txtRemarks.Text,0, dtpValid_From.GetDateTime().Date, dtpValid_To.GetDateTime().Date, txtAcc_NO_Factoring.Text, txtAcc_NO_current.Text, txtAcc_NO_clearing.Text, txtBank_ID.Tag.ToString(), txtBankBranch.Tag.ToString(),
                               decimal.Parse(txtCredit_Limit.Text), decimal.Parse(txtFactoring_Rate.Text), int.Parse(txtCredit_Period.Text), int.Parse(txtrecurse_Period.Text), decimal.Parse(txtService_fee_pct.Text), decimal.Parse(txtService_fee_minimum.Text),
                              sInterestrate_ID, true, clsSecurity.UserIDLoged, "default", "default", "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(),
                              clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, false);
                            detail.Insert();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Arrow;
                        ClearFields();
                        RefreshGrid();
                        fillDetails(sAgr, sRv);
                    }
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            txtAgreement_ID.IsEnabled = true;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtAgreement_ID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAgreement_reference1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAgreement_reference2, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpValid_From, true,false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpValid_To, true,false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBank_ID, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBankBranch, false, false, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAcc_NO_Factoring, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAcc_NO_clearing, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAcc_NO_current, true, false, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtCredit_Limit, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFactoring_Rate, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCredit_Period, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtrecurse_Period, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtService_fee_pct, true, true, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtService_fee_pct, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtIntCredit, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtIntRecurse, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtService_fee_minimum, true, true, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);

            txtAgreement_ID.Tag = null;
            txtAgrement_Rev.Tag = "A";
            txtBank_ID.Tag = null;
            txtBankBranch.Tag = null;
            txtAcc_NO_Factoring.Tag = null;
            txtAcc_NO_clearing.Tag = null;
            txtAcc_NO_current.Tag = null;

            dtpValid_From.SetTime(DateTime.Now);
            dtpValid_To.SetTime(DateTime.Now);

            txtAgreement_ID.Text = "";
            txtAgrement_Rev.Text = "";
            txtAgreement_reference1.Text = "";
            txtAgreement_reference2.Text = "";
            txtBank_ID.Text = "";
            txtBankBranch.Text = "";
            txtAcc_NO_Factoring.Text = "";
            txtAcc_NO_clearing.Text = "";
            txtAcc_NO_current.Text = "";
            txtRemarks.Text = "";

            txtCredit_Limit.Text = "00.00";
            txtFactoring_Rate.Text = "00.00";
            txtCredit_Period.Text = "0";
            txtrecurse_Period.Text = "0";
            txtService_fee_pct.Text = "00.00";
            txtService_fee_minimum.Text = "00.00";
            txtIntCredit.Text = "00.00";
            txtIntRecurse.Text = "00.00";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_bpsFactoringAgreement detail in tbl_bpsFactoringAgreement.SelectAll().Where(p => !p.IsDeleted && p.IsActive))
                {
                    dgr_Main.dt.Rows.Add(detail.FactoringAgreement_ID, detail.FactoringAgreement_Revision, (detail.FactoringAgreement_ID + "/" + detail.FactoringAgreement_Revision), clsRef_Name.get_Bank_Name( detail.Bank_ID), clsRef_Name.get_BankBranch_Name( detail.Branch_ID), detail.AccountNumber_Factoring);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (CheckValidity_DuplicateKey())
                {
                    if (CheckNumberValidity())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtAcc_NO_Factoring, ref strMessage))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBank_ID, ref strMessage))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBankBranch, ref strMessage))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage);

            return bStatus;
        }

        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtAgreement_ID.Text = SEACC_Form.getAutoGeneratedCode();

                txtAgreement_ID.Tag = txtAgreement_ID.Text;

                tbl_bpsFactoringAgreement detail = tbl_bpsFactoringAgreement.Select(txtAgreement_ID.Tag.ToString(), txtAgrement_Rev.Tag.ToString());
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsValidation.isCurrency(txtCredit_Limit,ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtFactoring_Rate, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isInteger(txtCredit_Period, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isInteger(txtrecurse_Period, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtService_fee_pct, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtService_fee_minimum, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtIntCredit, ref strMessage))
                    bStatus = false;
                if (!clsValidation.isCurrency(txtIntRecurse, ref strMessage))
                    bStatus = false;

                if (bStatus == false)
                    SEACCMessageBox.Show("invalied curency value", strMessage);
            }
            catch (Exception)
            {
              //  clsValidate.WriteErrorLog(ex.Message, iFormID);
             //   MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (bStatus == false)
            {
              //  MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID, string rID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_bpsFactoringAgreement details = tbl_bpsFactoringAgreement.Select(sID, rID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtAgreement_ID.IsEnabled = false;

                        txtAgreement_ID.Text = details.FactoringAgreement_ID + "/" + details.FactoringAgreement_Revision;
                        txtAgreement_ID.Tag = details.FactoringAgreement_ID;
                        txtAgrement_Rev.Tag = details.FactoringAgreement_Revision;
                        txtBank_ID.Text = clsRef_Name.get_Bank_Code(details.Bank_ID);
                        txtBank_ID.Tag = details.Bank_ID;
                        txtBankBranch.Text = clsRef_Name.get_Branch_Code(details.Branch_ID);
                        txtBankBranch.Tag = details.Branch_ID;

                        txtAgreement_reference1.Text = details.Ref1;
                        txtAgreement_reference2.Text = details.Ref2;
                        dtpValid_From.SetTime(details.AgreementValidity_From);
                        dtpValid_To.SetTime(details.AgreementValidity_To);
                        txtAcc_NO_Factoring.Text = details.AccountNumber_Factoring;
                        txtAcc_NO_current.Text = details.AccountNumber_Current;
                        txtAcc_NO_clearing.Text = details.AccountNumber_Clearing;
                        txtCredit_Limit.Text = cls_Formater.FormatDecimal(decimal.Parse(details.Credit_Limit.ToString()),2);
                        txtCredit_Period.Text = cls_Formater.FormatDecimal(decimal.Parse(details.Credit_Period.ToString()),0);
                        txtrecurse_Period.Text = cls_Formater.FormatDecimal(decimal.Parse(details.Recourse_Period.ToString()),0);
                        txtService_fee_pct.Text = cls_Formater.FormatDecimal(decimal.Parse(details.ServiceCharge_presentage.ToString()),2);
                        txtFactoring_Rate.Text = cls_Formater.FormatDecimal(decimal.Parse(details.Factoring_Rate.ToString()),2);
                        txtService_fee_minimum.Text = cls_Formater.FormatDecimal(decimal.Parse(details.ServiceCharge_min.ToString()),2);
                        txtRemarks.Text = details.Remarks;

                        tbl_bpsFactoringInterest oInterest = tbl_bpsFactoringInterest.Select(details.FactoringInterest_ID);
                        if (oInterest != null)
                        {
                            txtIntCredit.Text = cls_Formater.FormatDecimal(oInterest.Interest_Credit,2);
                            txtIntRecurse.Text = cls_Formater.FormatDecimal(oInterest.Interest_Recurse,2);

                            txtIntCredit.Tag = oInterest.FactoringInterest_ID;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1_1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string periodID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string groupID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

                    fillDetails(periodID, groupID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            if (txtAgreement_ID.Tag != null)
            {
                frm_FactoringInterestRate frm = new frm_FactoringInterestRate(txtAgreement_ID.Tag.ToString());
            }
        }

        #region Search Event
        private void txtBank_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FactoringBanks);
            if (RowDataSearch.DialogResult == true)
            {
                txtBank_ID.Tag = lstResult[0];
                txtBank_ID.Text = lstResult[2];
            }
        }

        private void txtBankBranch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FactoringBankBranch);
            if (RowDataSearch.DialogResult == true)
            {
                txtBankBranch.Tag = lstResult[0];
                txtBankBranch.Text = lstResult[1];
            }
        }

        private void txtAcc_NO_Factoring_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
            if (RowDataSearch.DialogResult == true)
            {
                if (txtAcc_NO_current.Text == lstResult[0])
                {
                    SEACCMessageBox.Show("Sorry", "You Allready Select This Account for Current Account...!", MessageBoxButton.OK);
                    //bItemOk = false;
                }
                else if (txtAcc_NO_clearing.Text == lstResult[0])
                {
                    SEACCMessageBox.Show("Sorry", "You Allready Select This Account for Clearing Account...!", MessageBoxButton.OK);
                    //bItemOk = false;
                }
                else
                {
                    txtAcc_NO_Factoring.Text = lstResult[0];
                    txtBank_ID.Tag = lstResult[6];
                    txtBank_ID.Text = lstResult[2];
                    txtBankBranch.Tag = lstResult[5];
                    txtBankBranch.Text = lstResult[4];
                }
                
            }
        }

        private void txtAcc_NO_current_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CheckValidity_EmptyFields())
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(txtBank_ID.Tag.ToString());
                lstParameeters.Add(txtBankBranch.Tag.ToString());

                Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
                if (RowDataSearch.DialogResult == true)
                {
                    //bool bItemOk = true;
                    if (txtAcc_NO_Factoring.Text == lstResult[0])
                    {
                        SEACCMessageBox.Show("Sorry", "You Allready Select This Account for Factoring Account...!", MessageBoxButton.OK);
                        //bItemOk = false;
                    }
                    else if (txtAcc_NO_clearing.Text == lstResult[0])
                    {
                        SEACCMessageBox.Show("Sorry", "You Allready Select This Account for Clearing Account...!", MessageBoxButton.OK);
                        //bItemOk = false;
                    }
                    else
                    {
                        txtAcc_NO_current.Text = lstResult[0];
                    }
                    
                }
            }
        }

        private void txtAcc_NO_clearing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CheckValidity_EmptyFields())
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(txtBank_ID.Tag.ToString());
                lstParameeters.Add(txtBankBranch.Tag.ToString());

                Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
                if (RowDataSearch.DialogResult == true)
                {
                    //bool bItemOk = true;
                    if (txtAcc_NO_Factoring.Text == lstResult[0])
                    {
                        SEACCMessageBox.Show("Sorry", "You Allready Select This Account for Factoring Account...!", MessageBoxButton.OK);
                        //bItemOk = false;
                    }
                    else if (txtAcc_NO_current.Text == lstResult[0])
                    {
                        SEACCMessageBox.Show("Sorry", "You Allready Select This Account for Current Account...!", MessageBoxButton.OK);
                        //bItemOk = false;
                    }
                    else
                    {
                        txtAcc_NO_clearing.Text = lstResult[0];
                    }
                }
            }
        }

        private void txtAgreement_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FactoringAgreement);
            if (RowDataSearch.DialogResult == true)
            {
                txtAgreement_ID.Tag = lstResult[0];
                txtAgrement_Rev.Tag = lstResult[1];                
                fillDetails(lstResult[0], lstResult[1]);
            }
        }

        #endregion
    }
}