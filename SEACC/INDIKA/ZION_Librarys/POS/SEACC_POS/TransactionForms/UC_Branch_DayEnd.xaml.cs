using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SEACC_WPFControls;
using DataTire;
using System.Data;
using SEACC_POS.Controls;
using SEACC_POS.DataSet;
using Digiteq_Logic;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Web;
using System.Text;

namespace SEACC_POS.TransactionForms
{
    public partial class UC_Branch_DayEnd : UserControl
    {
        #region Class Variable
        BrushConverter bc = new BrushConverter();
        dts_posStd glb_dtsPosStd = new dts_posStd();

        string sBaseURL = clsConfig.sBaseURL; //= "https://uat2-pos.imonitor.center";
        string sClient_ID = clsConfig.sClient_ID; // = "CCB1-PS-19-00000283";
        string sClient_Secret = clsConfig.sClientScreat; // "R/tnFTMi0yzMawBNjPI2TQ==";
        #endregion

        #region Form Load
        public UC_Branch_DayEnd()
        {
            #region Form Initialize
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.POS_BranchDayEnd;
            SEACC_Form.Initialize();
            #endregion

            #region Main Table
            dgr_Main.dt.Columns.Add("DayIndex");
            dgr_Main.dt.Columns.Add("TransactionDate");
            dgr_Main.dt.Columns.Add("Branch");
            dgr_Main.dt.Columns.Add("DayEndChecked_By");
            dgr_Main.dt.Columns.Add("DayEndApproved_By");
            #endregion

            #region Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, (clsSecurity.BranchID == "BRA/0007"), false, true, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btnSendSales_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_Click;
            #endregion

            #region Main Grid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "DayIndex", 25, false, true);
            dgr_Main.Add_DatagridColoumn("Date", "TransactionDate", 100, true);
            dgr_Main.Add_DatagridColoumn("Branch", "Branch", 100, true);
            dgr_Main.Add_DatagridColoumn("Checked By", "DayEndChecked_By", 100, false);
            dgr_Main.Add_DatagridColoumn("Approved By", "DayEndApproved_By", 100);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Buttons
        //New Button
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        //Upload Sales Details to One Galleface
        private void btnSendSales_Click(object sender, RoutedEventArgs e)
        {
            tbl_posDayStartAndEnd oDayEnd = tbl_posDayStartAndEnd.Select(int.Parse(dtpTxDate.Tag.ToString()));
            if (oDayEnd != null)
            {
                if (true) //(!oDayEnd.IsApproved)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Checked_Confirmation);
                    if (bMessegeBoxResult)
                    {
                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                        frmTwoStepVerify.ShowDialog();
                        if (frmTwoStepVerify.bVerified)
                        {

                            //Auth Token
                            string sToken = GetToken(sBaseURL, sClient_ID, sClient_Secret);

                            //Get Sales Data
                            int iNoOfTxInDayEnd = 0;
                            string sSalesdata = CreateSalesJsonObj(dtpTxDate.GetDateTime(), clsSecurity.BranchID, ref iNoOfTxInDayEnd);

                            if (iNoOfTxInDayEnd > 0)
                            {
                                //Upload the Data to OneGalleFace Server
                                try
                                {
                                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(sBaseURL + "/api/possale/importpossaleswithitems");
                                    httpWebRequest.Headers.Add("Authorization", sToken);
                                    httpWebRequest.ContentType = "application/json";
                                    httpWebRequest.Method = "POST";

                                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                    {
                                        streamWriter.Write(sSalesdata);
                                        streamWriter.Flush();
                                        streamWriter.Close();
                                    }

                                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                    string sResult = "";
                                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                    {
                                        sResult = streamReader.ReadToEnd();
                                    }

                                    //Response Validation
                                    DataResponse oDataResponce = new JavaScriptSerializer().Deserialize<DataResponse>(sResult);
                                    if (oDataResponce.returnStatus.Contains("SUCCESS"))
                                    {
                                        SEACCMessageBox.Show("Successfully Updated to One Galle Face Server", oDataResponce.recordsImported + " records were uploed", MessageBoxButton.OK, "Green");
                                        //DBHandling.ExecQuery("INSERT INTO [dbo].[tbl_posDayStartAndEnd_OneGalleFace] ([dayIndex] ,[jsonResult] ,[response], [isSuccess]) VALUES (" + oDayEnd.DayIndex + ", '" + sSalesdata + "' , '" + sResult + "', '1')");
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show("Something Went Wrong", "Error Details : " + oDataResponce.errorDetails, MessageBoxButton.OK, "Red");
                                        //DBHandling.ExecQuery("INSERT INTO [dbo].[tbl_posDayStartAndEnd_OneGalleFace] ([dayIndex] ,[jsonResult] ,[response], [isSuccess]) VALUES (" + oDayEnd.DayIndex + ", '" + sSalesdata + "' , '" + sResult + "', '0')");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    SEACCExeption.Show(ex);
                                }
                            }
                            else
                            {
                                SEACCMessageBox.Show("No Transaction for Uploading...", "", MessageBoxButton.OK, "Gray");
                            }
                        }
                        frmTwoStepVerify.Close();
                    }
                }
                //else
                //{
                //    SEACCMessageBox.Show("Already Approved", "Selected Day Start has already been approved", MessageBoxButton.OK, "Red");
                //}
            }
        }

        //Update Button
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int iDayStart_ID = -1;
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_posDayStartAndEnd oBranchDay = tbl_posDayStartAndEnd.Select(int.Parse(dtpTxDate.Tag.ToString()));
                            if (oBranchDay != null)
                            {
                                if (!oBranchDay.IsApproved && !oBranchDay.IsCanceled)
                                {
                                    tbl_posDayStartAndEnd oUpdateBranchDay = new tbl_posDayStartAndEnd(
                                            int.Parse(dtpTxDate.Tag.ToString()), oBranchDay.IsChecked, oBranchDay.IsApproved, oBranchDay.IsCanceled,
                                            oBranchDay.CreateUser_ID, clsSecurity.UserIDLoged, oBranchDay.CheckedUser_ID, oBranchDay.ApprovedUser_ID, oBranchDay.CanceledUser_ID, oBranchDay.DateCreated, clsSecurity.getServerDateTime(),
                                            oBranchDay.DateChecked, oBranchDay.DateApproved, oBranchDay.DateCanceled, oBranchDay.CreatedTerminal_ID, clsSecurity.TerminalID, oBranchDay.CheckedUserTerminal_ID,
                                            oBranchDay.ApprovedUserTerminal_ID, oBranchDay.CanceledUserTerminal_ID, clsSecurity.CompanyID, clsSecurity.BranchID, oBranchDay.PostingStatus_ID);
                                    oUpdateBranchDay.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oBranchDay.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Day End has been approved", MessageBoxButton.OK, "Red");
                                    else if (oBranchDay.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..",
                                            "Selected Day End has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            if (oBranchDay != null) iDayStart_ID = oBranchDay.DayIndex;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            //No Development
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
                    ClearFields();
                    RefreshGrid();
                    FillDetails(iDayStart_ID);
                }
            }
        }

        //Approve Button
        private void btn_Approved_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToApproved())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {

                            tbl_posDayStartAndEnd oDayEnd = tbl_posDayStartAndEnd.Select(int.Parse(dtpTxDate.Tag.ToString()));
                            if (oDayEnd != null)
                            {
                                if (!oDayEnd.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oDayEnd.IsApproved = true;
                                            oDayEnd.DateApproved = clsSecurity.getServerDateTime();
                                            oDayEnd.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oDayEnd.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oDayEnd.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oDayEnd.DayIndex);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Already Approved", "Selected Day Start has already been approved", MessageBoxButton.OK, "Red");
                                }
                            }
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

        #region Clear Field
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBranch, false, false, false);

            dtpTxDate.Tag = null;
            txtBranch.Tag = null;

            txtBranch.Text = "";
            dtpTxDate.SetTime(DateTime.Now);

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_posDayStartAndEnd oDayEnd in tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(r => !r.IsCanceled).OrderByDescending(o => o.DateCreated))
                {
                    dgr_Main.dt.Rows.Add(
                        oDayEnd.DayIndex,
                        oDayEnd.DateCreated.ToString(cls_Formater.Format_Date2),
                        clsGenaralName.getName_CompanyBranchMaster(oDayEnd.CompanyBranch_ID),
                        clsGenaralName.getName_User(oDayEnd.CheckedUser_ID),
                        clsGenaralName.getName_User(oDayEnd.ApprovedUser_ID)
                        );
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check validity

        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_ManagerSignOffsDone())
                {
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtBranch))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_ManagerSignOffsDone()
        {
            bool bStatus = true;
            string sMessage = "";

            foreach (tbl_posDayStartAndEnd_Detail oMSoff in tbl_posDayStartAndEnd_Detail.SelectAllByDayIndex(int.Parse(dtpTxDate.Tag.ToString())).Where(r => !r.IsMgtSignOffApproved))
            {
                bStatus = false;
                sMessage += "\n" + oMSoff.SignInCashier_ID + " - " + clsGenaralName.getName_User(oMSoff.SignInCashier_ID) + " in Terminal #: " + oMSoff.PosTerminal_ID;
            }

            if (!bStatus)
                SEACCMessageBox.Show("Manager Sign Off Not Completed Yet...", "Following Sessions have already not manager signed off yet.\n" + sMessage, MessageBoxButton.OK, "Red");

            return bStatus;
        }

        #endregion

        #region Fill Details
        private void FillDetails(int sID)
        {
            try
            {
                tbl_posDayStartAndEnd oBranchDay = tbl_posDayStartAndEnd.Select(sID);
                if (oBranchDay != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    dtpTxDate.Tag = oBranchDay.DayIndex;
                    txtBranch.Tag = oBranchDay.CompanyBranch_ID;

                    txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(oBranchDay.CompanyBranch_ID);

                    dtpTxDate.SetTime(oBranchDay.DateCreated);

                    if (oBranchDay.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oBranchDay.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string sID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock)?.Text;
                    ClearFields();
                    FillDetails(int.Parse(sID));
                }
            }
            catch
            { }
        }
        #endregion

        //Generate Json Array
        private string CreateSalesJsonObj(DateTime dtmPosDay, String sComBranch_ID, ref int iNoOfTx)
        {
            string sJsonResult = "";

            try
            {
                DataHeader oDH = new DataHeader();
                oDH.PosSales = new List<PosSale>();

                oDH.AppCode = "POS-02";
                oDH.PropertyCode = "CCB1";
                oDH.ClientID = sClient_ID;
                oDH.ClientSecret = sClient_Secret;
                oDH.BatchCode = DateTime.Now.ToString("ddMMyyyyHHmmss");
                oDH.POSInterfaceCode = sClient_ID;

                var Txs = tbl_posTransaction.SelectAllByCompanyBranch_ID(sComBranch_ID).Where(r => r.PosTransaction_ID != "default" && !r.IsChecked && !r.IsDeleted && !r.IsHold && !r.IsIncompleted && r.PosTransactiondate.Date == dtmPosDay.Date);

                if (Txs != null)
                    iNoOfTx = Txs.Count();

                foreach (tbl_posTransaction oTx in Txs)
                {
                    PosSale oPS = new PosSale();
                    oPS.Items = new List<Item>();

                    oPS.PropertyCode = oDH.PropertyCode;
                    oPS.POSInterfaceCode = oDH.POSInterfaceCode;
                    oPS.ReceiptDate = oTx.PosTransactiondate.Date.ToString("dd/MM/yyyy");
                    oPS.ReceiptTime = oTx.PosTransactiondate.ToString("HH:mm:ss");
                    oPS.ReceiptNo = oTx.PosTransaction_ID;
                    oPS.NoOfItems = 0; // See following regions
                    oPS.SalesCurrency = "LKR";
                    oPS.TotalSalesAmtB4Tax = Math.Abs(oTx.GrandTotal);
                    oPS.TotalSalesAmtAfterTax = Math.Abs(oTx.GrandTotal);
                    oPS.SalesTaxRate = 0m;
                    oPS.ServiceChargeAmt = 0m;
                    oPS.PaymentAmt = Math.Abs(oTx.GrandTotal);
                    oPS.PaymentCurrency = "LKR";
                    oPS.PaymentMethod = ""; // See fallowing regions
                    oPS.SalesType = "";

                    #region No of Items & Items
                    foreach (tbl_posTransaction_Detail oTx_D in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oTx.PosTransaction_Index))
                    {
                        Item oItm = new Item();
                        oItm.ItemDesc = clsGenaralName.getName_Item(oTx_D.Item_ID);
                        oItm.ItemAmt = oTx_D.GrossAmount;
                        oItm.ItemDiscoumtAmt = oTx_D.LineDiscountTotal;
                        oPS.Items.Add(oItm);

                        ++oPS.NoOfItems;
                    }
                    #endregion

                    #region Payment Method
                    foreach (tbl_bpsChequeRegister oPayMethod in tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(r => r.PosTransaction_ID.Trim() == oTx.PosTransaction_Index.ToString()))
                    {
                        if (oPayMethod.PaymentMethod_ID == (int)PaymentMethod.Cash)
                        {
                            if (oPS.PaymentMethod == "")
                            {
                                oPS.PaymentMethod = "Cash";
                            }
                            else if (!oPS.PaymentMethod.Contains("Cash"))
                            {
                                oPS.PaymentMethod += ", Cash";
                            }
                        }
                        else if (oPayMethod.PaymentMethod_ID == (int)PaymentMethod.Card)
                        {
                            if (oPS.PaymentMethod == "")
                            {
                                oPS.PaymentMethod = "Credit Card";
                            }
                            else if (!oPS.PaymentMethod.Contains("Credit Cash"))
                            {
                                oPS.PaymentMethod += ", Credit Card";
                            }
                        }
                        else if (oPayMethod.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            if (oPS.PaymentMethod == "")
                            {
                                oPS.PaymentMethod = "Cheque";
                            }
                            else if (!oPS.PaymentMethod.Contains("Cheque"))
                            {
                                oPS.PaymentMethod += ", Cheque";
                            }
                        }
                        else if (oPayMethod.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher)
                        {
                            if (oPS.PaymentMethod == "")
                            {
                                oPS.PaymentMethod = "Voucher";
                            }
                            else if (!oPS.PaymentMethod.Contains("Voucher"))
                            {
                                oPS.PaymentMethod += ", Voucher";
                            }
                        }
                        else if (oPayMethod.PaymentMethod_ID == (int)PaymentMethod.Credit_Note)
                        {
                            if (oPS.PaymentMethod == "")
                            {
                                oPS.PaymentMethod = "Returns";
                            }
                            else if (!oPS.PaymentMethod.Contains("Returns"))
                            {
                                oPS.PaymentMethod += ", Returns";
                            }
                        }
                        else
                        {
                            if (oPS.PaymentMethod == "")
                            {
                                oPS.PaymentMethod = "Cash";
                            }
                            else if (!oPS.PaymentMethod.Contains("Cash"))
                            {
                                oPS.PaymentMethod += ", Cash";
                            }
                        }
                    }

                    if (oPS.PaymentMethod == "")
                    {
                        oPS.PaymentMethod = "Cash";
                    }
                    #endregion

                    #region Sales Type
                    if (!oTx.IsReturnedPOS_Invoice)
                    {
                        oPS.SalesType = "Sales";
                    }
                    else
                    {
                        oPS.SalesType = "Return";
                        oPS.PaymentMethod = "Voucher";
                    }
                    #endregion

                    oDH.PosSales.Add(oPS);
                }

                sJsonResult = new JavaScriptSerializer().Serialize(oDH);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

            return sJsonResult;
        }

        //Generate Auth Token
        private string GetToken(string sBaseURL, string sClient_ID, string sClientSecret)
        {
            string sToken = "";
            string sResponce = "";

            try
            {
                string post_URL = sBaseURL + "/connect/token";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    byte[] response1 = client.UploadValues(post_URL, new NameValueCollection()
                    {
                        {"grant_type" , "client_credentials" },
                        {"client_id", sClient_ID },
                        {"client_secret" , sClientSecret }
                    });

                    sResponce = System.Text.Encoding.UTF8.GetString(response1);
                }
                JsonArrayValues_Token oTkn = new JavaScriptSerializer().Deserialize<JsonArrayValues_Token>(sResponce);
                sToken = oTkn.token_type + " " + oTkn.access_token;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

            return sToken;
        }
    }

    //Data Header of Transactions
    class DataHeader
    {
        public string AppCode { get; set; }
        public string PropertyCode { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string BatchCode { get; set; }
        public string POSInterfaceCode { get; set; }
        public List<PosSale> PosSales { get; set; }
    }

    //Transactionss
    class PosSale
    {
        public string PropertyCode { get; set; }
        public string POSInterfaceCode { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptTime { get; set; }
        public string ReceiptNo { get; set; }
        public int NoOfItems { get; set; }
        public string SalesCurrency { get; set; }
        public decimal TotalSalesAmtB4Tax { get; set; }
        public decimal TotalSalesAmtAfterTax { get; set; }
        public decimal SalesTaxRate { get; set; }
        public decimal ServiceChargeAmt { get; set; }
        public decimal PaymentAmt { get; set; }
        public string PaymentCurrency { get; set; }
        public string PaymentMethod { get; set; }
        public string SalesType { get; set; }
        public List<Item> Items { get; set; }
    }

    //Transaction Details
    class Item
    {
        public string ItemDesc { get; set; }
        public decimal ItemAmt { get; set; }
        public decimal ItemDiscoumtAmt { get; set; }
    }

    //Response of Uploded Transactions
    class DataResponse
    {
        public string batchCode { get; set; }
        public string returnStatus { get; set; }
        public string recordsReceived { get; set; }
        public string recordsImported { get; set; }
        public string errorDetails { get; set; }
        public string defectiveRowNos { get; set; }
    }

    //Authontication Result
    class JsonArrayValues_Token
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string expires_in { get; set; }

    }
}
