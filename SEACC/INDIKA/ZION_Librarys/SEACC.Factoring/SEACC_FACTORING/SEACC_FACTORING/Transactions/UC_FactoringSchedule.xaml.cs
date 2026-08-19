using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Data;
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

namespace SEACC_FACTORING
{
    public partial class UC_FactoringSchedule : UserControl
    {
        #region Class Variables
        private DataTable dt = new DataTable();
        string glbAgrementRevishion_ID = "";
        decimal glbFactoringrate = 0, glbserviceCharge_presentage = 0, glbserviceCharge_min = 0;
        int iCreaditDays = 0;
        #endregion

        #region Form Load
        public UC_FactoringSchedule()
        {
            #region Initialize User Control
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_Schedule;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("Schedule_ID");
            dgr_Main.dt.Columns.Add("Bank_ID");
            dgr_Main.dt.Columns.Add("Bank");
            dgr_Main.dt.Columns.Add("Branch_ID");
            dgr_Main.dt.Columns.Add("Branch");
            dgr_Main.dt.Columns.Add("Account_No");

            dt.Columns.Add("LineNo");
            dt.Columns.Add("chequeRegister_ID");
            dt.Columns.Add("Bank_ID");
            dt.Columns.Add("Bank");
            dt.Columns.Add("Branch_ID");
            dt.Columns.Add("Branch");
            dt.Columns.Add("Cheque_NO");
            dt.Columns.Add("Cheque_Date");
            dt.Columns.Add("Cheque_status");
            dt.Columns.Add("ChequeAmount");
            dt.Columns.Add("Invoice_Numbers");
            dt.Columns.Add("FactoringRate");
            dt.Columns.Add("FactoringAmount");
            dt.Columns.Add("Service_Charges");
            dt.Columns.Add("No_of_Days");
            dt.Columns.Add("Estimate_Interest");
            dgr_Cheque.ItemsSource = dt.DefaultView;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Schedule ID", "Schedule_ID", 70);
            dgr_Main.Add_DatagridColoumn("Bank ID", "Bank_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Bank", "Bank", 100);
            dgr_Main.Add_DatagridColoumn("Branch ID", "Branch_ID", 70, false);
            dgr_Main.Add_DatagridColoumn("Branch", "Branch", 90);
            dgr_Main.Add_DatagridColoumn("Account No", "Account_No", 80);
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
                    if (txtSchedule_ID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_bpsFactoringSchedule Details = tbl_bpsFactoringSchedule.Select(txtSchedule_ID.Tag.ToString());
                            if (Details != null)
                            {
                                foreach (tbl_bpsFactoringSchedule_detail delDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(Details.FactoringSehedule_ID))
                                {
                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(delDetails.ChequeRegister_ID);
                                    if (oCheque != null)
                                    {
                                        oCheque.ChequeStatus_ID = "0";
                                        oCheque.Update();
                                    }
                                }

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
            Print(false);
        }
        private void btnPrintDis_Click(object sender, RoutedEventArgs e)
        {
            Print(true);
        }
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    string sSchedule_ID = "";
                    try
                    {
                        Cursor = Cursors.Wait;
                        sSchedule_ID = txtSchedule_ID.Tag.ToString();

                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_bpsFactoringSchedule OldRecord = tbl_bpsFactoringSchedule.Select(txtSchedule_ID.Text.Trim());
                            if (OldRecord != null)
                            {
                                
                                tbl_bpsFactoringSchedule odetail = new tbl_bpsFactoringSchedule(txtSchedule_ID.Text.Trim(), dtpSchedule_Date.GetDateTime().Date, 
                                    txtAgreement_Code.Tag.ToString(), glbAgrementRevishion_ID, txtRemarks.Text, decimal.Parse(txtNBTPer.Text), decimal.Parse(txtVATPer.Text),0, 
                                    decimal.Parse(txtTotFaceAmnt.Text),decimal.Parse(txtFatoringAmnt.Text), decimal.Parse(txtFactoringCharges.Text), decimal.Parse(txtNBT.Text), 
                                    decimal.Parse(txtVAT.Text), 0, decimal.Parse(txtFactoringGrossAmnt.Text),decimal.Parse(txtPendingMargin.Text),0,
                                    OldRecord.CreateUser_ID, clsSecurity.UserIDLoged, OldRecord.CheckedUser_ID, OldRecord.ApprovedUser_ID,
                               "default", "default", OldRecord.CreateTerminal_ID, clsSecurity.TerminalID, OldRecord.DeletedTerminal_ID, "default", "default", "default", OldRecord.DateCreate,
                               clsSecurity.getServerDateTime(), OldRecord.DateChecked, OldRecord.DateApproved, OldRecord.DateDeleted, OldRecord.DatePrinted, false, false,DateTime.Now, OldRecord.IsDeleted);

                                odetail.Update();

                                foreach (tbl_bpsFactoringSchedule_detail delDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(odetail.FactoringSehedule_ID))
                                {
                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(delDetails.ChequeRegister_ID);
                                    if (oCheque != null)
                                    {
                                        oCheque.ChequeStatus_ID = "0";
                                        oCheque.Update();

                                        delDetails.Delete();
                                    }
                                }
                                foreach (DataRow row in dt.Rows)
                                {
                                    string sChequeRegisterID = row["chequeRegister_ID"].ToString();
                                    decimal dAmount = decimal.Parse(row["ChequeAmount"].ToString());
                                    decimal dFacctoringRate = decimal.Parse(row["FactoringRate"].ToString());
                                    decimal dFacctoringAmount = decimal.Parse(row["FactoringAmount"].ToString());
                                    decimal dserviceChg = decimal.Parse(row["Service_Charges"].ToString());
                                    int iNofDays = int.Parse(row["No_of_Days"].ToString());
                                    decimal dInterestAmount = decimal.Parse(row["Estimate_Interest"].ToString());
                                    int iLineNo = int.Parse(row["LineNo"].ToString());
                                    string sInvNo = row["Invoice_Numbers"].ToString();

                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sChequeRegisterID);
                                    if (oCheque != null)
                                    {
                                        oCheque.ChequeStatus_ID = "10";
                                        oCheque.Update();

                                        tbl_bpsFactoringSchedule_detail details = new tbl_bpsFactoringSchedule_detail(txtSchedule_ID.Text.Trim(), sChequeRegisterID, iLineNo, sInvNo, txtRemarks.Text, dAmount, dFacctoringRate, dFacctoringAmount, dserviceChg, dInterestAmount, iNofDays, false, 0);
                                        details.Insert();
                                    }
                                }

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                        #endregion
                        #region Insert
                        else
                        {
                            tbl_bpsFactoringSchedule detail = new tbl_bpsFactoringSchedule(txtSchedule_ID.Text.Trim(), dtpSchedule_Date.GetDateTime().Date, 
                                txtAgreement_Code.Tag.ToString(), glbAgrementRevishion_ID, txtRemarks.Text, decimal.Parse(txtNBTPer.Text), decimal.Parse(txtVATPer.Text), 0,
                                decimal.Parse(txtTotFaceAmnt.Text), decimal.Parse(txtFatoringAmnt.Text), decimal.Parse(txtFactoringCharges.Text), decimal.Parse(txtNBT.Text),
                                decimal.Parse(txtVAT.Text), 0, decimal.Parse(txtFactoringGrossAmnt.Text), decimal.Parse(txtPendingMargin.Text), 0,
                                clsSecurity.UserIDLoged, "default", "default", "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default", "default", "default", clsSecurity.getServerDateTime(),
                                clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.getServerDateTime(), false, false,DateTime.Now, false);

                            detail.Insert();

                            foreach (DataRow row in dt.Rows)
                            {
                                string sChequeRegisterID = row["chequeRegister_ID"].ToString();
                                decimal dAmount = decimal.Parse(row["ChequeAmount"].ToString());
                                decimal dFacctoringRate = decimal.Parse(row["FactoringRate"].ToString());
                                decimal dFacctoringAmount = decimal.Parse(row["FactoringAmount"].ToString());
                                decimal dserviceChg = decimal.Parse(row["Service_Charges"].ToString());
                                int iNofDays = int.Parse(row["No_of_Days"].ToString());
                                decimal dInterestAmount = decimal.Parse(row["Estimate_Interest"].ToString());
                                int iLineNo = int.Parse(row["LineNo"].ToString());
                                string sInvNo = row["Invoice_Numbers"].ToString();

                                tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sChequeRegisterID);
                                if (oCheque != null)
                                {
                                    oCheque.ChequeStatus_ID = "10";
                                    oCheque.Update();

                                    tbl_bpsFactoringSchedule_detail details = new tbl_bpsFactoringSchedule_detail(txtSchedule_ID.Text.Trim(), sChequeRegisterID, iLineNo, sInvNo, txtRemarks.Text, dAmount, dFacctoringRate, dFacctoringAmount, dserviceChg, dInterestAmount, iNofDays, false, 0);
                                    details.Insert();
                                }
                            }
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
                        fillDetails(sSchedule_ID);
                    }
                }
            }
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dgr_Cheque.RowHeight = double.NaN;

            dt.Clear();
            txtSchedule_ID.IsEnabled = true;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtSchedule_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAgreement_Code, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtTotFaceAmnt, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFatoringAmnt, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFactoringCharges, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtNBT, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtVAT, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtNBTPer, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtVATPer, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFactoringGrossAmnt, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPendingMargin, false, true, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtInvoiceList, true, false, true);

            glbAgrementRevishion_ID = "";
            glbFactoringrate = 0;
            glbserviceCharge_presentage = 0;
            glbserviceCharge_min = 0;

            txtSchedule_ID.Tag = null;
            txtAgreement_Code.Tag = null;
            txtTotFaceAmnt.Tag = null;
            txtFatoringAmnt.Tag = null;
            txtFactoringCharges.Tag = null;
            txtNBT.Tag = null;
            txtVAT.Tag = null;
            txtNBTPer.Tag = null;
            txtVATPer.Tag = null;
            txtFactoringGrossAmnt.Tag = null;
            txtPendingMargin.Tag = null;

            lblbank.Tag = null;
            lblbranch.Tag = null;
            lblFactoringAccNo.Tag = null;

            txtSchedule_ID.Text = "";
            txtAgreement_Code.Text = "";
            txtRemarks.Text = "";
            txtTotFaceAmnt.Text = "0.00";
            txtFatoringAmnt.Text = "0.00";
            txtPendingMargin.Text = "0.00";
            txtFactoringCharges.Text = "0.00";
            txtNBT.Text = "0.00";
            txtVAT.Text = "0.00";
            txtFactoringGrossAmnt.Text = "0.00";
            txtNBTPer.Text = "0.00";
            txtVATPer.Text = "0.00";

            lblbank.Text = "-";
            lblbranch.Text = "-";
            lblFactoringAccNo.Text = "-";
            lblInerestRate.Text = "-";
            lblCreditLimit.Text = "-";
            lblAvailableCredit.Text = "-";

            chkNBT.IsChecked = false;
            chkVat.IsChecked = false;

            txtNBTPer.Text = clsCommon.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageNBT());
            txtVATPer.Text = clsCommon.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());

            dtpSchedule_Date.SetTime(DateTime.Now);

            #region need to update UI
            lblPrepared.Text = clsSecurity.UserNameLoged;
            lblChecked.Text = clsSecurity.UserNameLoged;
            lblApproved.Text = clsSecurity.UserNameLoged;

            lblPreparedDate.Text = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime().Date);
            lblCheckedDate.Text = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime().Date);
            lblApprovedDate.Text = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime().Date);

            lblPreparedTime.Text = clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
            lblCheckedTime.Text = clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
            lblApprovedTime.Text = clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_bpsFactoringSchedule detail in tbl_bpsFactoringSchedule.SelectAll().Where(p => p.IsDeleted == false && p.FactoringSehedule_ID != "Default"))
                {
                    tbl_bpsFactoringAgreement detailFactoring = tbl_bpsFactoringAgreement.Select(detail.FactoringAgreement_ID, detail.FactoringAgreement_Revision);
                    dgr_Main.dt.Rows.Add(detail.FactoringSehedule_ID, detailFactoring.Bank_ID, clsRef_Name.get_Bank_Name(detailFactoring.Bank_ID), detailFactoring.Branch_ID, clsRef_Name.get_BankBranch_Name(detailFactoring.Branch_ID), detailFactoring.AccountNumber_Factoring);
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
                if (CheckGridvalidity())
                    if (CheckValidity_CreditLimit())
                        if (CheckValidity_DuplicateKey())
                            if(CheckValidity_GrossAmount())
                                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_ChequeStatus()
        {
            bool bStatus = true;
            string strMessage1 = "", strMessage2="";
            if (SEACC_Form.IsUpdateMode)
            {
                foreach (tbl_bpsFactoringSchedule_detail detail in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(txtSchedule_ID.Tag.ToString()))
                {
                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(detail.ChequeRegister_ID);
                    if (oCheque != null)
                    {
                        if (oCheque.ChequeStatus_ID != "10")
                        {
                            strMessage1 += (strMessage1 != "" ? " , " : "") + oCheque.ChequeNumber;
                            bStatus = false;
                        }
                    }
                    else
                    {
                        bStatus = false;
                        strMessage2+= (strMessage2 != "" ? " , " : "") + detail.ChequeRegister_ID;
                    }
                }
            }

            if (bStatus == false)
                SEACCMessageBox.Show("Problem with Cheque Status  ", strMessage1, MessageBoxButton.OK);

            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtAgreement_Code, ref strMessage))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage, MessageBoxButton.OK);

            return bStatus;
        }

        private bool CheckGridvalidity()
        {
            bool bStatus = true;
            if (dt.Rows.Count <= 0)
            {
                SEACCMessageBox.Show("Please select Cheques..", "", MessageBoxButton.OK);
                bStatus = false;
            }
            return bStatus;
        }

        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtSchedule_ID.Text = SEACC_Form.getAutoGeneratedCode();

                txtSchedule_ID.Tag = txtSchedule_ID.Text;

                if (txtSchedule_ID.Tag.ToString() != "")
                {
                    tbl_bpsFactoringSchedule detail = tbl_bpsFactoringSchedule.Select(txtSchedule_ID.Tag.ToString());
                    if (detail != null)
                    {
                        bStatus = false;
                        SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    }
                }
                else
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Fields cannot be Empty", "Schedule ID", MessageBoxButton.OK);
                }
            }
            return bStatus;
        }

        private bool CheckValidity_GrossAmount()
        {
            string strMessage = "";
            bool bStatus = true;

            if (decimal.Parse(txtFactoringGrossAmnt.Text) <= 0)
            {
                SEACCMessageBox.Show("Gross amount should be greater than 0", strMessage, MessageBoxButton.OK);
                bStatus = false;
            }            

            return bStatus;
        }

        private bool CheckValidity_CreditLimit()
        {
            bool bStatus = true;

            //decimal dChequeAmount_dt = 0, dAllChequeAmount_dt = 0;
            decimal dChequeAmount = 0, dAllChequeAmount = 0, dFaceAmount = 0;
            tbl_bpsFactoringAgreement oFactoring = tbl_bpsFactoringAgreement.Select(txtAgreement_Code.Tag.ToString(), glbAgrementRevishion_ID);
            if (oFactoring != null)
            {
                foreach (tbl_bpsFactoringSchedule oFSche in tbl_bpsFactoringSchedule.SelectAllByFactoringAgreement_ID_FactoringAgreement_Revision(oFactoring.FactoringAgreement_ID, oFactoring.FactoringAgreement_Revision).Where(p => p.IsDeleted == false && p.FactoringSehedule_ID != "Default"))
                {
                    foreach (tbl_bpsFactoringSchedule_detail oDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(oFSche.FactoringSehedule_ID))
                    {
                        tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oDetails.ChequeRegister_ID);
                        if (oCheque != null)
                        {
                            if (oCheque.DateCheque >= dtpSchedule_Date.GetDateTime().Date)
                                dChequeAmount += oDetails.FactoringAmount;
                        }
                    }
                }

                //foreach (DataRow row in dt.Rows)
                //{
                //    dChequeAmount_dt = decimal.Parse(row["FactoringAmount"].ToString());
                //    if (dChequeAmount_dt != 0)
                //    {
                //        dAllChequeAmount_dt += dChequeAmount_dt;
                //    }
                //}

                //if (dChequeAmount != 0 && dChequeAmount_dt != 0)
                    //dAllChequeAmount = dChequeAmount + dChequeAmount_dt;

                dFaceAmount = decimal.Parse(txtFatoringAmnt.Text);
                if (dChequeAmount != 0 && dFaceAmount != 0)
                    dAllChequeAmount = dChequeAmount + dFaceAmount;

                if (dAllChequeAmount != 0)
                {
                    if (oFactoring.Credit_Limit <= dAllChequeAmount)
                    {
                        SEACCMessageBox.Show("Sorry", "Cannot Exceed the Credit Limit...!", MessageBoxButton.OK);
                        bStatus = false;
                    }
                }
            }

            //SEACCMessageBox.Show("Sorry", dChequeAmount.ToString() + "  /  " + dFaceAmount.ToString() + "  /  " +  dAllChequeAmount.ToString(), MessageBoxButton.OK);

            return bStatus;
        }

        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_bpsFactoringSchedule details = tbl_bpsFactoringSchedule.Select(sID);
                    tbl_bpsFactoringAgreement oAgree = tbl_bpsFactoringAgreement.Select(details.FactoringAgreement_ID, details.FactoringAgreement_Revision);
                    tbl_bpsFactoringInterest oInterest = tbl_bpsFactoringInterest.Select(oAgree.FactoringInterest_ID);

                    if (details != null && oAgree!=null && oInterest!=null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtSchedule_ID.IsEnabled = false;

                        #region Schedule and Agreement Fill
                        txtSchedule_ID.Text = details.FactoringSehedule_ID;
                        txtSchedule_ID.Tag = details.FactoringSehedule_ID;

                        dtpSchedule_Date.SetTime(details.FactoringSeheduleDate);

                        txtAgreement_Code.Tag = details.FactoringAgreement_ID;
                        txtAgreement_Code.Text = details.FactoringAgreement_ID + "/" + details.FactoringAgreement_Revision;
                        glbAgrementRevishion_ID = details.FactoringAgreement_Revision; 
                        #endregion

                        //edit by janith
                        if (details.VatTotal != 0)
                            chkVat.IsChecked = true;
                        else
                            chkVat.IsChecked = false;
                        if (details.NbtTotal != 0)
                            chkNBT.IsChecked = true;
                        else
                            chkNBT.IsChecked = false;
                        //

                        #region Fill Global Variables by Janith
                        glbFactoringrate = oAgree.Factoring_Rate;
                        glbserviceCharge_presentage = oAgree.ServiceCharge_presentage;
                        glbserviceCharge_min = oAgree.ServiceCharge_min;
                        iCreaditDays = oAgree.Credit_Period; 
                        #endregion

                        #region Text Boxes
                        txtRemarks.Text = details.Remark;
                        txtTotFaceAmnt.Text = clsFormatter.FormatDecimalPlaces_Price(details.FaceAmount);
                        txtFatoringAmnt.Text = clsFormatter.FormatDecimalPlaces_Price(details.FactoringAmount);
                        txtFactoringCharges.Text = clsFormatter.FormatDecimalPlaces_Price(details.ServiceCharges);
                        txtNBT.Text = clsFormatter.FormatDecimalPlaces_Price(details.NbtTotal);
                        txtVAT.Text = clsFormatter.FormatDecimalPlaces_Price(details.VatTotal);
                        txtNBTPer.Text = clsFormatter.FormatDecimalPlaces_Price(details.NbtPercentage);
                        txtVATPer.Text = clsFormatter.FormatDecimalPlaces_Price(details.VatPercentage);
                        txtFactoringGrossAmnt.Text = clsFormatter.FormatDecimalPlaces_Price(details.GrossFactoringAmount);
                        txtPendingMargin.Text = clsFormatter.FormatDecimalPlaces_Price(details.PendingAmount); 
                        #endregion

                        lblbank.Tag = oAgree.Bank_ID;
                        lblbank.Text = clsRef_Name.get_Bank_Name(oAgree.Bank_ID);
                        lblbranch.Text = clsRef_Name.get_BankBranch_Name(oAgree.Branch_ID);
                        lblFactoringAccNo.Text = oAgree.AccountNumber_Factoring;
                        lblInerestRate.Text = clsFormatter.FormatDecimalPlaces_Price(oInterest.Interest_Credit);
                        lblInerestRate.Tag = oInterest.Interest_Credit;
                        lblCreditLimit.Text = clsFormatter.FormatDecimalPlaces_Price(oAgree.Credit_Limit);

                        decimal dAvailableCreditAmount = 0, dChequeAmount = 0;
                        string sFactoringAgreement_ID = oAgree.FactoringAgreement_ID, sFactoringAgreement_Revision = oAgree.FactoringAgreement_Revision;
                        DisplayAvailableCredits(ref dChequeAmount, sFactoringAgreement_ID, sFactoringAgreement_Revision);

                        dAvailableCreditAmount = oAgree.Credit_Limit - dChequeAmount;
                        lblAvailableCredit.Text = clsFormatter.FormatDecimalPlaces_Price(dAvailableCreditAmount);

                        dt.Clear();
                        foreach (tbl_bpsFactoringSchedule_detail oDetails in tbl_bpsFactoringSchedule_detail.SelectAll().Where(r => r.FactoringSehedule_ID == details.FactoringSehedule_ID).OrderBy(p=>p.Line_No))
                        {                       
                            tbl_bpsChequeRegister detailCheque = tbl_bpsChequeRegister.Select(oDetails.ChequeRegister_ID);
                                dt.Rows.Add(oDetails.Line_No, oDetails.ChequeRegister_ID, detailCheque.Bank_ID, clsRef_Name.get_Bank_Name(detailCheque.Bank_ID), detailCheque.Branch_ID,
                                    clsRef_Name.get_BankBranch_Name(detailCheque.Branch_ID), detailCheque.ChequeNumber, clsFormatter.FormatDate_Short(detailCheque.DateCheque),
                                    detailCheque.ChequeStatus_ID, clsFormatter.FormatDecimalPlaces_Price(detailCheque.ChequeAmount), oDetails.InvoiceNos != "default" ? oDetails.InvoiceNos : "-", clsFormatter.FormatDecimalPlaces_Price(oDetails.FactoringRate),
                                    clsFormatter.FormatDecimalPlaces_Price(oDetails.FactoringAmount), clsFormatter.FormatDecimalPlaces_Price(oDetails.ServiceCharges), oDetails.NofDays, oDetails.InterestAmount);
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

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string periodID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    fillDetails(periodID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Item Grid Action Buttons
        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity_EmptyFields())
            {
                Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.ChequeRegister);
                if (RowDataSearch.DialogResult == true)
                {
                    tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(lstResult[0]);
                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);
                    if (detail != null && oReceipt != null)
                    {
                        bool bItemOk = true;
                        #region Validate Date
                        if (detail.DateCheque <= dtpSchedule_Date.GetDateTime().Date)
                        {
                            SEACCMessageBox.Show("Sorry", "This not a postdated cheque...!", MessageBoxButton.OK);
                            bItemOk = false;
                        }
                        else if (detail.DateCheque >= dtpSchedule_Date.GetDateTime().Date.AddDays(iCreaditDays))
                        {
                            SEACCMessageBox.Show("Sorry", "Cheque date cannot exceed credit period...!", MessageBoxButton.OK);
                            bItemOk = false;
                        }
                        #endregion

                        #region Validate Duplicate records
                        foreach (DataRow row in dt.Rows)
                        {
                            string sChequeRegisterID = row["chequeRegister_ID"].ToString();
                            if (sChequeRegisterID == detail.ChequeRegister_ID)
                            {
                                SEACCMessageBox.Show("Sorry", "Cheque already selected...!", MessageBoxButton.OK);
                                bItemOk = false;
                                break;
                            }
                        }
                        #endregion

                        if (bItemOk)
                        {
                            decimal dFactoringAmount = 0, dServiceCharges = 0, dInterestAmount = 0;
                            TimeSpan tspNofDays = detail.DateCheque.Date - dtpSchedule_Date.GetDateTime().Date;
                            decimal dInterestPresentage = decimal.Parse(lblInerestRate.Tag.ToString());
                            CalculateFactoringAmount(detail.ChequeAmount, glbFactoringrate, ref dFactoringAmount, ref dServiceCharges, ref dInterestAmount, tspNofDays.Days, dInterestPresentage);
                            int iRow = dt.Rows.Count + 1;

                            string sInvoice_No = "";
                            foreach (tbl_bpsReceipt_Invoice oInvoices in tbl_bpsReceipt_Invoice.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                            {
                                sInvoice_No += ((sInvoice_No != "") ? " , " : "") + oInvoices.Invoice_ID;
                            }

                            dt.Rows.Add(iRow, detail.ChequeRegister_ID, detail.Bank_ID, clsRef_Name.get_Bank_Name(detail.Bank_ID), detail.Branch_ID, clsRef_Name.get_BankBranch_Name(detail.Branch_ID), detail.ChequeNumber,
                                clsFormatter.FormatDate_Short(detail.DateCheque), detail.ChequeStatus_ID, cls_Formater.FormatDecimal(detail.ChequeAmount, 2), sInvoice_No, cls_Formater.FormatDecimal(glbFactoringrate, 2),
                                cls_Formater.FormatDecimal(dFactoringAmount, 2), cls_Formater.FormatDecimal(dServiceCharges, 2), tspNofDays.Days, cls_Formater.FormatDecimal(dInterestAmount, 2));
                            CalculateTaxesAndGrandTotal();
                        }
                    }
                }
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Cheque.SelectedItem;
            if (selectedItem != null)
            {
                ((DataRowView)(dgr_Cheque.SelectedItem)).Row.Delete();
                CalculateTaxesAndGrandTotal();
            }
        } 
        #endregion

        #region Search Event
        private void txtSchedule_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FactoringSchedule);
            if (RowDataSearch.DialogResult == true)
            {
                txtSchedule_ID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtAgreement_Code_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dt.Rows.Count <= 0)
            {
                Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.FactoringAgreement);
                if (RowDataSearch.DialogResult == true)
                {
                    tbl_bpsFactoringAgreement oAgreement = tbl_bpsFactoringAgreement.Select(lstResult[0], lstResult[1]);
                    tbl_bpsFactoringInterest oInterest = tbl_bpsFactoringInterest.Select(oAgreement.FactoringInterest_ID);
                    if (oAgreement != null && oInterest != null)
                    {
                        txtAgreement_Code.Text = oAgreement.FactoringAgreement_ID + "/" + oAgreement.FactoringAgreement_Revision;
                        txtAgreement_Code.Tag = oAgreement.FactoringAgreement_ID;
                        glbAgrementRevishion_ID = oAgreement.FactoringAgreement_Revision;

                        lblbank.Text = lstResult[3];
                        lblbranch.Text = lstResult[4];
                        lblFactoringAccNo.Text = lstResult[5];

                        lblbank.Tag = oAgreement.Bank_ID;
                        lblbranch.Tag = oAgreement.Branch_ID;
                        glbFactoringrate = oAgreement.Factoring_Rate;
                        glbserviceCharge_presentage = oAgreement.ServiceCharge_presentage;
                        glbserviceCharge_min = oAgreement.ServiceCharge_min;
                        iCreaditDays = oAgreement.Credit_Period;

                        lblInerestRate.Text = clsFormatter.FormatDecimalPlaces_Price(oInterest.Interest_Credit);
                        lblInerestRate.Tag = oInterest.Interest_Credit;

                        lblCreditLimit.Text = clsFormatter.FormatDecimalPlaces_Price(oAgreement.Credit_Limit);

                        decimal dAvailableCreditAmount = 0, dChequeAmount = 0;
                        string sFactoringAgreement_ID = oAgreement.FactoringAgreement_ID, sFactoringAgreement_Revision = oAgreement.FactoringAgreement_Revision;
                        DisplayAvailableCredits(ref dChequeAmount, sFactoringAgreement_ID, sFactoringAgreement_Revision);

                        dAvailableCreditAmount = oAgreement.Credit_Limit - dChequeAmount;
                        lblAvailableCredit.Text = clsFormatter.FormatDecimalPlaces_Price(dAvailableCreditAmount);
                    }
                }
            }
            else
                SEACCMessageBox.Show("Please remove Cheques to change the Agreement..!", "");
        }
        #endregion

        #region Popup Events
        private void dgr_Cheque_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDgv_Cell = dgr_Cheque.CurrentCell;
                //int irowID = dgr_Cheque.SelectedIndex;
                object item = dgr_Cheque.SelectedItem;

                if (vDgv_Cell.Column.Header.ToString() == "Invoice No.")
                {
                    pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                    pop_Event.IsOpen = true;
                    string GridID = (dgr_Cheque.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
                    txtInvoiceList.Text = GridID;
                }
            }
            catch (Exception )
            { }
        }

        private void btn_PoPSave_Click(object sender, RoutedEventArgs e)
        {
            //object item = dgr_Cheque.SelectedItem;
            //dgr_Cheque.SelectedCells[10].Column.SetValue(item) = txtInvoiceList.Text;
            //DataRow dr = dt.NewRow();
            //DataColumn dc = dt.Columns.;
            //dr[10] = txtInvoiceList.Text;
            //dt.Rows.Add(dr);

            int irowID = dgr_Cheque.SelectedIndex;
            dt.Rows[irowID]["Invoice_Numbers"] = txtInvoiceList.Text;

            pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event.IsOpen = false;
            
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event.IsOpen = false;
        } 
        #endregion

        #region Print method
        private void Print(bool Dis)
        {
            try
            {
                if (txtSchedule_ID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermisshion_ToPrint())
                    {
                        //tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.factoringAgreement);
                        //if (oReports != null)
                        //{
                        DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                        DataSets.dts_FactoringSchedule dts_FactoringSchedule = new DataSets.dts_FactoringSchedule();
                        dts_FactoringSchedule.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsCript.Decrypt(clsCommon.getComName()), clsCript.Decrypt(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "", "", "", clsSecurity.UserNameLoged, "");

                        tbl_bpsFactoringSchedule details = tbl_bpsFactoringSchedule.Select(txtSchedule_ID.Tag.ToString());
                        tbl_bpsFactoringAgreement oAgreement = tbl_bpsFactoringAgreement.Select(details.FactoringAgreement_ID, details.FactoringAgreement_Revision);

                        if (details != null && oAgreement!=null)
                        {
                            //fill data table here
                            dts_FactoringSchedule.dt_FactoringShedule.Adddt_FactoringSheduleRow(txtSchedule_ID.Tag.ToString(), details.FactoringSeheduleDate, details.Remark, oAgreement.Bank_ID, clsRef_Name.get_Bank_Name(oAgreement.Bank_ID), oAgreement.Branch_ID, clsRef_Name.get_OriginalBranch_Code(oAgreement.Branch_ID), oAgreement.AccountNumber_Factoring, details.FaceAmount, details.FactoringAmount, details.ServiceCharges, details.NbtPercentage, details.NbtTotal, details.VatPercentage, details.VatTotal, details.GrossFactoringAmount,0,0,0);

                            List<tbl_bpsFactoringSchedule_detail> scheduleDetails = tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(txtSchedule_ID.Tag.ToString()).ToList();
                            if (details != null)
                            {
                                foreach (tbl_bpsFactoringSchedule_detail oscheduleDet in scheduleDetails)
                                {
                                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oscheduleDet.ChequeRegister_ID);
                                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oCheque.Receipt_ID);
                                    if (oCheque != null && oReceipt != null)
                                    {
                                        //string sInvoice_No = "";
                                        //foreach (tbl_bpsReceipt_Invoice oInv in tbl_bpsReceipt_Invoice.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                                        //{
                                        //    sInvoice_No += sInvoice_No!=""?" , " :" "+ oInv.Invoice_ID;
                                        //}
                                        dts_FactoringSchedule.dt_FactoringShedule_Detail.Adddt_FactoringShedule_DetailRow(txtSchedule_ID.Tag.ToString(), oscheduleDet.ChequeRegister_ID, oCheque.Customer_ID, clsRef_Name.get_Customer_Name(oCheque.Customer_ID), oCheque.Bank_ID, clsRef_Name.get_Bank_Code(oCheque.Bank_ID), oCheque.Branch_ID, clsRef_Name.get_OriginalBranch_Code(oCheque.Branch_ID), oCheque.AccountNumber, oCheque.ChequeNumber, oCheque.DateCheque, oscheduleDet.NofDays.ToString() , oscheduleDet.InvoiceNos, oCheque.ChequeAmount, oscheduleDet.FactoringRate, details.FactoringAmount, details.ServiceCharges, 0);
                                    }
                                }
                            }

                            frm_ReportViwer CRViwer = new frm_ReportViwer();

                            if (Dis)
                            {
                                CRViwer.Print("\\Reports\\rpt_FactoringDisbursment_Commercial.rpt", dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                            }
                            else
                            {
                                if (lblbank.Tag.ToString() != "7278")
                                {
                                    CRViwer.Print("\\Reports\\rpt_FactoringShedule_Commercial.rpt", dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                                }
                                if (lblbank.Tag.ToString() == "7278")
                                {
                                    CRViwer.Print("\\Reports\\rpt_FactoringSchedule_Sampath.rpt", dts_FactoringSchedule, glb_dts_ExportReport.dt_rptParameter);
                                }
                            }                    

                        }
                        // }
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
        #endregion

        #region Calculations
        private void dgr_Cheque_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int irowID = dgr_Cheque.SelectedIndex;
                string sColoumn = e.Column.Header.ToString();
                TextBox t = e.EditingElement as TextBox;

                decimal dAmount = 0, dfactoringRate = 0, dFactoringAmount = 0, dServiceCharges = 0, dInterestAmount = 0, interestrate = 0;
                int nofdays = 0;

                dAmount = decimal.Parse(dt.Rows[irowID]["ChequeAmount"].ToString());
                dfactoringRate = decimal.Parse(dt.Rows[irowID]["FactoringRate"].ToString());

                CalculateFactoringAmount(dAmount, dfactoringRate, ref dFactoringAmount, ref dServiceCharges, ref dInterestAmount, nofdays, interestrate);

                switch (sColoumn)
                {
                    case "Factoring Rate":
                        if (t != null)
                            dfactoringRate = clsValidation.Validate_DecimalNumber(t.Text);
                        dFactoringAmount = dAmount * dfactoringRate / 100;
                        break;
                    case "Factoring Amount":
                        if (t != null)
                            dFactoringAmount = clsValidation.Validate_DecimalNumber(t.Text);
                        dfactoringRate = dFactoringAmount * 100 / dAmount;
                        break;
                    case "Service Charges":
                        if (t != null)
                            dServiceCharges = clsValidation.Validate_DecimalNumber(t.Text);
                        break;
                }
                dt.Rows[irowID]["ChequeAmount"] = cls_Formater.FormatDecimal(dAmount, 2);
                dt.Rows[irowID]["FactoringRate"] = cls_Formater.FormatDecimal(dfactoringRate, 2);
                dt.Rows[irowID]["FactoringAmount"] = cls_Formater.FormatDecimal(dFactoringAmount, 2);
                dt.Rows[irowID]["Service_Charges"] = cls_Formater.FormatDecimal(dServiceCharges, 2);

                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void chkNBT_Checked(object sender, RoutedEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void chkNBT_Unchecked(object sender, RoutedEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void chkVat_Unchecked(object sender, RoutedEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void chkVat_Checked(object sender, RoutedEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void CalculateFactoringAmount(decimal dAmount, decimal dfactoringRate, ref decimal dFactoringAmount, ref decimal dServiceCharges, ref decimal dInterestAmount, int iNofDays, decimal dInterestRate)
        {
            dFactoringAmount = dAmount * dfactoringRate / 100;
            //edit by janith
            dInterestAmount = (dFactoringAmount * dInterestRate / 100) * iNofDays / 365;
            //
            dServiceCharges = (dAmount * glbserviceCharge_presentage / 100);
            if (dServiceCharges < glbserviceCharge_min)
                dServiceCharges = glbserviceCharge_min;
        }

        private void CalculateTaxesAndGrandTotal()
        {
            decimal dAmount = 0, dfactoringAmount = 0, dService_Charges = 0, dNbtRate=0, dNbt=0, dvatRate=0, dVat=0;
            foreach (DataRow row in dt.Rows)
            {
                dAmount += decimal.Parse(row["ChequeAmount"].ToString());
                dfactoringAmount += decimal.Parse(row["FactoringAmount"].ToString());
                dService_Charges += decimal.Parse(row["Service_Charges"].ToString());
            }

            if (chkNBT.IsChecked==true)
            {
                if (txtNBTPer.Text.Length > 0 && clsCommon.isCurrency(txtNBTPer.Text.Trim()))
                    dNbtRate = decimal.Parse(txtNBTPer.Text.Trim());

                if (dNbtRate > 0)
                    dNbt = ((dService_Charges * dNbtRate) / 100);
            }
            if (chkVat.IsChecked == true)
            {
                if (txtVATPer.Text.Length > 0 && clsCommon.isCurrency(txtVATPer.Text.Trim()))
                    dvatRate = decimal.Parse(txtVATPer.Text.Trim());

                if (dvatRate > 0)
                    dVat = (((dService_Charges- dNbt) * dvatRate) / 100);
            }
            txtTotFaceAmnt.Tag = dAmount;
            txtFatoringAmnt.Tag = dfactoringAmount;
            txtFactoringCharges.Tag = dService_Charges;
            txtNBT.Tag = dNbt;
            txtVAT.Tag = dVat;
            txtFactoringGrossAmnt.Tag = dfactoringAmount- dService_Charges- dNbt- dVat;
            txtPendingMargin.Tag = dAmount * 20 / 100;

            txtTotFaceAmnt.Text= cls_Formater.FormatDecimal(dAmount, 2);
            txtFatoringAmnt.Text= cls_Formater.FormatDecimal(dfactoringAmount, 2);
            txtFactoringCharges.Text= cls_Formater.FormatDecimal(dService_Charges, 2);
            txtNBT.Text = cls_Formater.FormatDecimal(dNbt, 2);
            txtVAT.Text= cls_Formater.FormatDecimal(dVat, 2);
            txtFactoringGrossAmnt.Text = cls_Formater.FormatDecimal((dfactoringAmount - dService_Charges - dNbt - dVat), 2);
            txtPendingMargin.Text = cls_Formater.FormatDecimal(dAmount-dfactoringAmount,2 );
        }
        #endregion

        #region Display Schedule Viewer
        private void DisplayViewer()
        {
            if (txtAgreement_Code.Text.Length > 0 && txtAgreement_Code.Tag != null)
            {
                if (glbAgrementRevishion_ID != null && glbAgrementRevishion_ID != "")
                {
                    frm_ScheduleCheques_Viewer frm = new frm_ScheduleCheques_Viewer();
                    frm.glbAgreementID = txtAgreement_Code.Tag.ToString();
                    frm.glbAgreementRevesion = glbAgrementRevishion_ID;
                    frm.ShowDialog();
                }
            }
        }

        private void lblCreditLimit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DisplayViewer();
        }

        private void lblAvailableCredit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DisplayViewer();
        } 
        #endregion

        #region Display Available Credits
        private void DisplayAvailableCredits(ref decimal dChequeAmount, string sFactoringAgreement_ID, string sFactoringAgreement_Revision)
        {
            foreach (tbl_bpsFactoringSchedule oFSche in tbl_bpsFactoringSchedule.SelectAllByFactoringAgreement_ID_FactoringAgreement_Revision(sFactoringAgreement_ID, sFactoringAgreement_Revision).Where(p => p.IsDeleted == false && p.FactoringSehedule_ID != "Default"))
            {
                foreach (tbl_bpsFactoringSchedule_detail oDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(oFSche.FactoringSehedule_ID))
                {
                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oDetails.ChequeRegister_ID);
                    if (oCheque != null)
                    {
                        if (oCheque.DateCheque >= dtpSchedule_Date.GetDateTime().Date)
                            dChequeAmount += oDetails.FactoringAmount;
                    }
                }
            }
        }
        #endregion

    }
}