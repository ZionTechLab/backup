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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SEACC_WPFControls;
using DataTire;
using SEACC_Tender.UserControls;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;


namespace SEACC_Tender
{
    public partial class UC_ttsApplicationCollection : UserControl
    {
        #region Class Variables
        bool bIsItemChanged = false;
        string sTenderIDs;
        public int iFormID;
        
        #endregion

        #region Form Load
        public UC_ttsApplicationCollection()
        { 
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.DocumentList;
            iFormID = clsSecurity.getFormID(FormName.DocumentList);
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ApplicationID");
            dgr_Main.dt.Columns.Add("TenderID");
            dgr_Main.dt.Columns.Add("TenderNo");
            dgr_Main.dt.Columns.Add("NoticeDate");
            dgr_Main.dt.Columns.Add("ApplicationStatus");
            //dgr_Main.dt.Columns.Add("ReceiptNo");
            //dgr_Main.dt.Columns.Add("ReceiptAmount");
            //dgr_Main.dt.Columns.Add("PaymentMethod");
            //dgr_Main.dt.Columns.Add("ChequeNo");
            //dgr_Main.dt.Columns.Add("BankName");
            //dgr_Main.dt.Columns.Add("BranchName");
            //dgr_Main.dt.Columns.Add("AccountNo");
            //dgr_Main.dt.Columns.Add("ChequeDate");

            //dt2.Columns.Add("FileName");
            //dt2.Columns.Add("FilePath");
            //dt2.Columns.Add("isNew");
            //dt2.Columns.Add("isDeleted");
            //dt2.Columns.Add("Attachment_ID");
            //dt2.Columns.Add("icon");
            //dgr_Upload.ItemsSource = dt2.DefaultView;

            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Application ID", "ApplicationID", 70, false);
            dgr_Main.Add_DatagridColoumn("Tender ID", "TenderID", 70, false);
            dgr_Main.Add_DatagridColoumn("Tender No", "TenderNo", 90);
            dgr_Main.Add_DatagridColoumn("Notice Date", "NoticeDate", 100);
            dgr_Main.Add_DatagridColoumn("Status", "ApplicationStatus", 120,false);
            //dgr_Main.Add_DatagridColoumn("Receipt No", "ReceiptNo", 50);
            //dgr_Main.Add_DatagridColoumn("Receipt Amount", "ReceiptAmount", 100);
            //dgr_Main.Add_DatagridColoumn("Payment Method", "PaymentMethod", 100);
            //dgr_Main.Add_DatagridColoumn("Cheque No", "ChequeNo", 100);
            //dgr_Main.Add_DatagridColoumn("Bank Name", "BankName", 100);
            //dgr_Main.Add_DatagridColoumn("Branch Name", "BranchName", 100);
            //dgr_Main.Add_DatagridColoumn("Account No", "AccountNo", 100);
            //dgr_Main.Add_DatagridColoumn("Cheque Date", "ChequeDate", 100);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion
                   
            ClearFields();
            RefreshGrid();
        }
        #endregion

        public UC_ttsApplicationCollection(string sTenderID)
        {
            this.sTenderIDs = sTenderID;
        }

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                ColumnA.Width = new GridLength(220);
            else
                ColumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Button

        #region Save
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    Cursor = Cursors.Wait;
                    string sTenderID = "", sPayMethod = "", sChequeNo = "", sBank = "", sBranch = "", sAccountNo = "";
                    //string sUploadPDF = "", sUploadReceipt = "", sUploadPDFPath = "", sUploadReceiptPath = "";
                    DateTime dtChequeDate;
                    try
                    {
                        sTenderID = txtTenderID.Tag.ToString();

                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            //string sFilePath = "", sFileName = "", sFilePathReceipt = "", sFileNameReceipt = "";
                            tbl_ttsApplicationCollection oldDetail = tbl_ttsApplicationCollection.Select(txtApplicationNo.Tag.ToString());
                            if (oldDetail != null)
                            {
                                if (rdoCash.IsChecked == true)
                                {
                                    sPayMethod = PaymentMethods.Cash.ToString();
                                }
                                else if (rdoCheques.IsChecked == true)
                                {
                                    sPayMethod = PaymentMethods.Cheque.ToString();
                                }

                                tbl_ttsApplicationCollection oDetail = new tbl_ttsApplicationCollection(txtApplicationNo.Tag.ToString(), txtTenderID.Tag.ToString(), txtReceiptNo.Text, decimal.Parse(txtReceiptAmount.Text),
                                    sPayMethod, txtChequeNo.Text,txtAccNo.Text, dtpChequeDate.GetDateTime(), false);
                                oDetail.Update();

                                tbl_ttsTenderNotice oNotice = tbl_ttsTenderNotice.Select(txtTenderID.Tag.ToString());
                                if (oNotice != null)
                                {
                                    oNotice.PreBidMeetingAddress1 = txtAddress1.Text;
                                    oNotice.PreBidMeetingAddress2 = txtAddress2.Text;
                                    oNotice.PreBidMeetingCountry_ID = txtCountry.Tag.ToString();
                                    oNotice.PreBidMeetingCity_ID = txtCity.Tag.ToString();
                                    oNotice.PreBidMeetingTown_ID = txtTown.Tag.ToString();
                                    oNotice.PreBidMeetingDate = dtpPreBidMeetingDate.GetDateTime();
                                    oNotice.IsApplicationCollected = true;

                                    oNotice.Update();
                                }

                                //sUploadPDF = txtUploadPDF.Text;
                                //sUploadReceipt = txtUploadReceipt.Text;
                                //sUploadPDFPath = txtUploadPDF.Tag.ToString();
                                //sUploadReceiptPath = txtUploadReceipt.Tag.ToString();

                                //Attachments_Insert_Update(sUploadPDFPath, sUploadPDF);
                                //Attachments_Insert_Update_Receipt(sUploadReceiptPath, sUploadReceipt);
                               

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            if (rdoCash.IsChecked == true)
                            {
                                sPayMethod = PaymentMethods.Cash.ToString();
                            }
                            else if (rdoCheques.IsChecked == true)
                            {
                                sPayMethod = PaymentMethods.Cheque.ToString();
                            }

                            if (txtChequeNo.Text != null && txtBankCode.Tag != null && txtBranchCode.Tag != null && txtAccNo.Text != null)
                            {
                                sChequeNo = txtChequeNo.Text;
                                sBank = txtBankCode.Tag.ToString();
                                sBranch = txtBranchCode.Tag.ToString();
                                sAccountNo = txtAccNo.Text;
                                dtChequeDate = dtpChequeDate.GetDateTime();
                            }
                            else
                            {
                                sChequeNo = "0";
                                sBank = "default";
                                sBranch = "default";
                                sAccountNo = "0";
                                dtChequeDate = clsValidation.defaultDateTime;
                            }

                            if (SEACC_Form.isAutoGenaratedCode)
                                txtApplicationNo.Tag = SEACC_Form.getAutoGeneratedCode();

                            tbl_ttsApplicationCollection oDetail = new tbl_ttsApplicationCollection(txtApplicationNo.Tag.ToString(),txtTenderID.Tag.ToString(), txtReceiptNo.Text, decimal.Parse(txtReceiptAmount.Text),
                                    sPayMethod, txtChequeNo.Text,txtAccNo.Text, dtpChequeDate.GetDateTime(), false);
                            oDetail.Insert();

                            tbl_ttsTenderNotice oNotice = tbl_ttsTenderNotice.Select(txtTenderID.Tag.ToString());
                            if (oNotice != null)
                            {
                                oNotice.PreBidMeetingAddress1 = txtAddress1.Text;
                                oNotice.PreBidMeetingAddress2 = txtAddress2.Text;
                                oNotice.PreBidMeetingCountry_ID = txtCountry.Tag.ToString();
                                oNotice.PreBidMeetingCity_ID = txtCity.Tag.ToString();
                                oNotice.PreBidMeetingTown_ID = txtTown.Tag.ToString();
                                oNotice.PreBidMeetingDate = dtpPreBidMeetingDate.GetDateTime();
                                oNotice.IsApplicationCollected = true;

                                oNotice.Update();
                            }


                            Attachments.Insert(txtApplicationNo.Tag.ToString());
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
                        string sApplicationID = txtApplicationNo.Tag.ToString();
                        Cursor = Cursors.Arrow;
                        ClearFields();
                        RefreshGrid();
                        FillDetails(sApplicationID);
                    }
                }
            }
        }
        #endregion

        #region Cancel
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                    if (bMessegeBoxResult)
                    {
                        tbl_ttsApplicationCollection oDetail = tbl_ttsApplicationCollection.Select(txtTenderID.Tag.ToString());
                        if (oDetail != null)
                        {
                            oDetail.IsCanceled = true;
                            oDetail.Update();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                            ClearFields();
                            RefreshGrid();
                        }
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Please Select Details to Cancel", "Error", MessageBoxButton.OK);
                }

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region New
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion 

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            Attachments.Clear(SEACC_Form.Function_ID);

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtApplicationNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAccNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBankCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBranchCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtChequeNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpChequeDate, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReceiptAmount, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReceiptNo, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtUploadPDF, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtUploadReceipt, true, false, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtAddress1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress2, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTown, true, false, false);

            rdoCash.IsChecked = true;
            rdoCheques.IsChecked = false;

            stackPanel.Visibility = Visibility.Collapsed;

            //txtChequeNo.Visibility = Visibility.Collapsed;
            //txtBankCode.Visibility = Visibility.Collapsed;
            //txtBranchCode.Visibility = Visibility.Collapsed;
            //txtAccNo.Visibility = Visibility.Collapsed;
            //dtpChequeDate.Visibility = Visibility.Collapsed;

            txtApplicationNo.Text = "<Auto Generated>";
            txtAccNo.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtBankCode.Text = "";
            txtBranchCode.Text = "";
            txtChequeNo.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "Srilanka";
            txtReceiptAmount.Text = "";
            txtReceiptNo.Text = "";
            txtTenderID.Text = "";
            txtTown.Text = "";
            //txtUploadPDF.Text = "";
            //txtUploadReceipt.Text = "";

            txtApplicationNo.Tag = null;
            txtTenderID.Tag = null;
            txtBankCode.Tag = null;
            txtBranchCode.Tag = null;
            txtAccNo.Tag = null;

            txtCity.Tag = null;
            txtCountry.Tag = 94;
            txtTown.Tag = null;

            dtpChequeDate.SetTime(DateTime.Now);
            dtpPreBidMeetingDate.SetTime(DateTime.Now);

        } 
        #endregion

        #region Fill Details
        private void FillDetails(string sApplicationID)
        {
            if (sApplicationID != null)
            {
                SEACC_Form.IsUpdateMode = true;

                tbl_ttsApplicationCollection oApplication = tbl_ttsApplicationCollection.Select(sApplicationID);
                
                if (oApplication != null)
                {
                    tbl_ttsTenderNotice oNotice = tbl_ttsTenderNotice.Select(oApplication.Tender_ID);
                    if (oNotice != null)
                    {
                        dtpPreBidMeetingDate.SetTime(oNotice.PreBidMeetingDate);
                        txtAddress1.Text = oNotice.PreBidMeetingAddress1;
                        txtAddress2.Text = oNotice.PreBidMeetingAddress2;
                        txtCity.Tag = oNotice.PreBidMeetingCity_ID;
                        txtCity.Text = clsRef_Name.get_City_Name(oNotice.PreBidMeetingCity_ID);
                        txtCountry.Tag = oNotice.PreBidMeetingCountry_ID;
                        txtCountry.Text = clsRef_Name.get_Country_Name(oNotice.PreBidMeetingCountry_ID);
                        txtTown.Tag = oNotice.PreBidMeetingTown_ID;
                        txtTown.Text = clsRef_Name.get_Town_Name(oNotice.PreBidMeetingTown_ID);
                    }

                    txtApplicationNo.Tag = oApplication.Application_ID;
                    txtApplicationNo.Text = oApplication.Application_ID;

                    txtTenderID.Tag = oApplication.Tender_ID;
                    txtTenderID.Text = clsRef_Name.get_Bid_No(oApplication.Tender_ID);
                    txtReceiptNo.Text = oApplication.Receipt_No;
                    txtReceiptAmount.Text = cls_Formater.FormatDecimal(oApplication.Receipt_Amount, 2);
                    txtAccNo.Text = oApplication.AccountNumber;

                    tbl_genCompanyAccount comAcc = tbl_genCompanyAccount.Select(clsSecurity.CompanyID, oApplication.AccountNumber);
                    if (comAcc != null)
                    {
                        txtBankCode.Tag = comAcc.Bank_ID;
                        txtBankCode.Text = clsRef_Name.get_Bank_Name(comAcc.Bank_ID);
                        txtBranchCode.Tag = comAcc.Branch_ID;
                        txtBranchCode.Text = clsRef_Name.get_BankBranch_Name(comAcc.Branch_ID);
                    }
                    
                    txtChequeNo.Text = oApplication.Cheque_No;
                    dtpChequeDate.SetTime(oApplication.Cheque_Date);

                    if (oApplication.PaymentMethod == "Cash")
                    {
                        rdoCash.IsChecked = true;
                        //rdoCheques.IsChecked = false;
                        stackPanel.Visibility = Visibility.Collapsed;
                    }
                    else if (oApplication.PaymentMethod == "Cheque")
                    {
                        rdoCheques.IsChecked = true;
                        //rdoCash.IsChecked = false;
                        stackPanel.Visibility = Visibility.Visible;
                    }

                    Attachments.FillDetails(oApplication.Application_ID);
                }
            }
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_ttsApplicationCollection oDetail in tbl_ttsApplicationCollection.SelectAll().Where(p => p.IsCanceled != true).OrderBy(p => p.Application_ID))
                {
                    tbl_ttsTenderNotice oNotice = tbl_ttsTenderNotice.Select(oDetail.Tender_ID);
                    if (oNotice != null)
                    {
                        dgr_Main.dt.Rows.Add(oDetail.Application_ID, oDetail.Tender_ID, oNotice.BidReference_No1, oNotice.NoticeDate.ToString(cls_Formater.Format_Date2), oNotice.IsApplicationCollected);
                    }
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Data Grid Events
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oItem = dgr_Main.grdMain.SelectedItem;
                if (oItem != null)
                {
                    string sApplicationID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(oItem) as TextBlock).Text;
                    FillDetails(sApplicationID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Search
        private void txtTenderID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtTenderID.Text = "";
            txtTenderID.Tag = "";
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                bool bItemOk = true;
                foreach (tbl_ttsApplicationCollection detail in tbl_ttsApplicationCollection.SelectAllByTender_ID(lstResult[0]))
                {
                    if (detail != null)
                    {
                        //pop_Error.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                        //pop_Error.IsOpen = true;

                        //txtError.Text = "This Record Already Added";
                        bItemOk = false;
                        FillDetails(detail.Application_ID);
                    }
                }
                if (bItemOk)
                {
                    ClearFields();
                    txtTenderID.Tag = lstResult[0];
                    txtTenderID.Text = lstResult[1];
                }
            }
        }

        private void txtApplicationNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Ten_ApplicationCollection);
            if (RowDataSearch.DialogResult == true)
            {
                FillDetails(lstResult[0]);
            }
        }

        private void txtAccNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
            if (RowDataSearch.DialogResult == true)
            {
                txtAccNo.Tag = lstResult[0];
                txtAccNo.Text = lstResult[0];
                txtBankCode.Tag = lstResult[1];
                txtBankCode.Text = lstResult[2];
                txtBranchCode.Tag = lstResult[3];
                txtBranchCode.Text = lstResult[4];
            }
        }

        private void txtBankCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.FactoringBanks);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    txtBankCode.Tag = lstResult[0];
            //    txtBankCode.Text = lstResult[1];
            //}
        }

        private void txtBranchCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //List<string> lstParameeters = new List<string>();
            //if (txtBankCode.Tag != null && txtBankCode.Text != "")
            //{
            //    lstParameeters.Add(txtBankCode.Tag.ToString());
            //}
            //Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch(lstParameeters);
            //List<string> lstResult = RowDataSearch.Show(Search.FactoringBankBranch);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    txtBranchCode.Tag = lstResult[0];
            //    txtBranchCode.Text = lstResult[4];
            //}
        }

        private void txtCity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.City);
            if (RowDataSearch.DialogResult == true)
            {
                txtCity.Tag = lstResult[0];
                txtCity.Text = lstResult[1];
                txtCountry.Tag = lstResult[6];
                txtCountry.Text = lstResult[7];
            }
        }

        private void txtCountry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Country);
            if (RowDataSearch.DialogResult == true)
            {
                txtCountry.Tag = lstResult[0];
                txtCountry.Text = lstResult[1];

            }
        }

        private void txtTown_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtCity.Tag != null && txtCity.Text != "")
            {
                lstParameeters.Add(txtCity.Tag.ToString());
            }
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Towns);
            if (RowDataSearch.DialogResult == true)
            {
                txtTown.Tag = lstResult[0];
                txtTown.Text = lstResult[1];
                txtCity.Tag = lstResult[2];
                txtCity.Text = lstResult[3];
                txtCountry.Tag = lstResult[8];
                txtCountry.Text = lstResult[9];
            }
        }

        #endregion

        #region Radion Button Events
        private void rdoCash_Click(object sender, RoutedEventArgs e)
        {
            stackPanel.Visibility = Visibility.Collapsed;
            txtChequeNo.Text = "";
            txtBankCode.Text = "";
            txtBankCode.Tag = null;
            txtBranchCode.Text = "";
            txtBranchCode.Text = null;
            txtAccNo.Text = "";
            dtpChequeDate.SetTime(DateTime.Now);
        }

        private void rdoCheques_Click(object sender, RoutedEventArgs e)
        {
            stackPanel.Visibility = Visibility.Visible;
            txtChequeNo.Text = "";
            txtBankCode.Text = "";
            txtBankCode.Tag = null;
            txtBranchCode.Text = "";
            txtBranchCode.Text = null;
            txtAccNo.Text = "";
            dtpChequeDate.SetTime(DateTime.Now);
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
                    {
                        if (CheckAccountNumberValidity())
                        {
                            if (CheckGridvalidity())
                            {
                                bStatus = true;
                            }
                        }
                    }                 
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtTenderID, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtReceiptNo, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtReceiptAmount, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtCountry, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtCity, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtTown, ref strMessage))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Information", "Fields cannot be Empty " + strMessage, MessageBoxButton.OK);

            return bStatus;
        }
        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtApplicationNo.Text = SEACC_Form.getAutoGeneratedCode();

                txtApplicationNo.Tag = txtApplicationNo.Text;

                if (txtApplicationNo.Tag.ToString() != "")
                {
                    tbl_ttsApplicationCollection detail = tbl_ttsApplicationCollection.Select(txtApplicationNo.Tag.ToString());
                    if (detail != null)
                    {
                        bStatus = false;
                        SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    }
                }
                else
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Fields cannot be Empty", "Application No", MessageBoxButton.OK);
                }
            }
            return bStatus;
        }
        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (!clsValidation.isCurrency(txtReceiptAmount, ref strMessage))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Invalied curency value", strMessage);

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption());
            }
            return bStatus;
        }
        private bool CheckAccountNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (rdoCheques.IsChecked == true)
            {
                if (!clsValidation.Validate_EmptyValue(txtChequeNo, ref strMessage))
                    bStatus = false;
                else if (!clsValidation.Validate_EmptyValue(txtAccNo, ref strMessage))
                    bStatus = false;

                if (bStatus == false)
                    SEACCMessageBox.Show("Information", "Please fill required field " + strMessage, MessageBoxButton.OK);
            }

            return bStatus;
        }
        private bool CheckGridvalidity()
        {
            bool bStatus = true;
            if (Attachments.dt2.Rows.Count <= 0)
            {
                SEACCMessageBox.Show("Please select files..", "", MessageBoxButton.OK);
                bStatus = false;
            }
            return bStatus;
        }
        #endregion

        #region Upload Files
        private void btnUploadPDF_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog File = new Microsoft.Win32.OpenFileDialog();
            if (File.ShowDialog() == true)
            {
                //txtUploadPDF.Text = System.IO.Path.GetFileName(File.FileName);
                //txtUploadPDF.Tag = File.FileName;
            }
        }   
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //string sFilePath = txtUploadPDF.Tag.ToString();
            //string sFileName = txtUploadPDF.Text;

            //txtUploadPDF.Tag = null;
            //txtUploadPDF.Text = "";
        }
        private void btnUploadReceipt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog File = new Microsoft.Win32.OpenFileDialog();
            if (File.ShowDialog() == true)
            {
                //txtUploadReceipt.Text = System.IO.Path.GetFileName(File.FileName);
                //txtUploadReceipt.Tag = File.FileName;
            }
        }
        private void btnRemoveReceipt_Click(object sender, RoutedEventArgs e)
        {
            //string sFilePath = txtUploadReceipt.Tag.ToString();
            //string sFileName = txtUploadReceipt.Text;

            //txtUploadReceipt.Tag = null;
            //txtUploadReceipt.Text = "";
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.OpenFileDialog File = new Microsoft.Win32.OpenFileDialog();
            //if (File.ShowDialog() == true)
            //{
            //    string path1 = "";
            //    switch (System.IO.Path.GetExtension(File.FileName))
            //    {
            //        case ".pdf":
            //            path1 = new Uri("pack://application:,,,/Resources/PDF.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".docx":
            //            path1 = new Uri("pack://application:,,,/Resources/Docx.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".doc":
            //            path1 = new Uri("pack://application:,,,/Resources/Docx.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".txt":
            //            path1 = new Uri("pack://application:,,,/Resources/txt.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".xls":
            //            path1 = new Uri("pack://application:,,,/Resources/Xls.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".xlsx":
            //            path1 = new Uri("pack://application:,,,/Resources/Xls.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".png":
            //            path1 = new Uri("pack://application:,,,/Resources/png.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".jpg":
            //            path1 = new Uri("pack://application:,,,/Resources/jpg.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".jpeg":
            //            path1 = new Uri("pack://application:,,,/Resources/jpg.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".zip":
            //            path1 = new Uri("pack://application:,,,/Resources/Zip.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".ppt":
            //            path1 = new Uri("pack://application:,,,/Resources/ppt.png", UriKind.Absolute).ToString();
            //            break;
            //        case ".pptx":
            //            path1 = new Uri("pack://application:,,,/Resources/ppt.png", UriKind.Absolute).ToString();
            //            break;
            //        default:
            //            path1 = new Uri("pack://application:,,,/Resources/others.png", UriKind.Absolute).ToString();
            //            break;
            //    }
            //    dt2.Rows.Add(System.IO.Path.GetFileName(File.FileName), File.FileName, true, false, "", path1);
            //}
        }

        private void btnRemoveUpload_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Attachments_Insert_Update_Receipt(string filePath, string fileName)
        {
            //foreach (DataRow row in dt2.Rows)
            //{
            //bool isDeleted = row["isDeleted"].ToString() == "True" ? true : false;
            //bool isNew = row["isNew"].ToString() == "True" ? true : false;
            //string filePath = txtUploadReceipt.Tag.ToString(); 
            //string fileName = txtUploadReceipt.Text;

            if (fileName != "" && fileName != "")
            {
                string sAttachment_ID = SEACC_Tender.UserControls.clsCommon.getAutoGeneratedCode(FormName.Attachments);

                string newFileName = sAttachment_ID + System.IO.Path.GetExtension(filePath);
                System.IO.File.Copy(filePath, @"Attachments\" + newFileName);
                tbl_ttsAttachments oAttachments = new tbl_ttsAttachments(sAttachment_ID, txtTenderID.Tag.ToString(), iFormID, newFileName, fileName);
                oAttachments.Insert();
            }
            //if (fileName == "" && fileName == "")
            //{
            //    //string sAttachment_ID = row["Attachment_ID"].ToString();
            //    if (System.IO.File.Exists(filePath))
            //        System.IO.File.Delete(filePath);

            //    tbl_ttsTenderAttachments oAttachments = tbl_ttsTenderAttachments.Select(sAttachment_ID);
            //    if (oAttachments != null)
            //    {
            //        if (oAttachments.Attachment == fileName)
            //            oAttachments.Delete();
            //    }
            //}
            //}
        }

        public void Attachments_Insert_Update(string filePath, string fileName)
        {
            //string filePath = txtUploadPDF.Tag.ToString();
            //string fileName = txtUploadPDF.Text;

            if (fileName != "" && filePath != "")
            {
                string sAttachment_ID = SEACC_Tender.UserControls.clsCommon.getAutoGeneratedCode(FormName.Attachments);

                string newFileName = sAttachment_ID + System.IO.Path.GetExtension(filePath);
                System.IO.File.Copy(filePath, @"Attachments\" + newFileName);
                tbl_ttsAttachments oAttachments = new tbl_ttsAttachments(sAttachment_ID, txtTenderID.Tag.ToString(), iFormID, newFileName, fileName);
                oAttachments.Insert();
            }
            //if (!isNew && isDeleted)
            //{
            //    string sAttachment_ID = row["Attachment_ID"].ToString();
            //    if (System.IO.File.Exists(filePath))
            //        System.IO.File.Delete(filePath);

            //    tbl_tenderAttachments oAttachments = tbl_tenderAttachments.Select(sAttachment_ID);
            //    if (oAttachments != null)
            //    {
            //        if (oAttachments.Attachment == fileName)
            //            oAttachments.Delete();
            //    }
            //}
        }
        #endregion

        private void lblNext_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UC_ttsTxnTenderDocuments UC;
            if (txtTenderID.Tag != null)
                UC = new UC_ttsTxnTenderDocuments(txtTenderID.Tag.ToString());
            else
                UC = new UC_ttsTxnTenderDocuments();
            frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            SW.ShowDialog();
        }
    }
}