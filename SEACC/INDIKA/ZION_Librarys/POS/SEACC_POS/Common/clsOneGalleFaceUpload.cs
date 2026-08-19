using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows;

namespace SEACC_POS.Common
{
    public class clsOneGalleFaceUpload
    {
        //static string sBaseURL = "https://uat2-pos.imonitor.center";
        //static string sClient_ID = "CCB1-PS-19-00000283";
        //static string sClient_Secret = "R/tnFTMi0yzMawBNjPI2TQ==";
        static string sPosMerchantURL = clsConfig.sPosMerchantURL;
        static string sBaseURL = clsConfig.sBaseURL; //= "https://uat2-pos.imonitor.center";
        static string sClient_ID = clsConfig.sClient_ID; // = "CCB1-PS-19-00000283";
        static string sClient_Secret = clsConfig.sClientScreat; // "R/tnFTMi0yzMawBNjPI2TQ==";

        //Generate Json Array
        private static string CreateSalesJsonObj(string sComBranch_ID, ref int iNoOfTx, ref DataHeader oDH_Ref)
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

                var Txs = tbl_posTransaction.SelectAllByCompanyBranch_ID(sComBranch_ID).Where(r => r.PosTransaction_ID != "default" && !r.IsHold && !r.IsIncompleted && !r.IsDeleted && !r.IsChecked);

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
                oDH_Ref = oDH;
            }
            catch (Exception ex)
            {
                clsValidation.WriteErrorLog("\nOne Galleface Joson Generate Error " + clsSecurity.getServerDateTime() + " - " + ex.Message);
            }


            return sJsonResult;
        }

        //Get Token
        private static string GetToken(string sBaseURL, string sClient_ID, string sClientSecret)
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
                clsValidation.WriteErrorLog("\n" + clsSecurity.TerminalID + " - One Galleface Token Generate Error " + clsSecurity.getServerDateTime() + " - " + ex.Message);
                //SEACCExeption.Show(ex);
            }

            return sToken;
        }

        //Upload Sales
        public static void Send_Sales()
        {
            //Auth Token
            string sToken = GetToken(sBaseURL, sClient_ID, sClient_Secret);

            //Get Sales Data
            int iNoOfTxInDayEnd = 0;
            DataHeader oData = new DataHeader();
            string sSalesdata = CreateSalesJsonObj(clsSecurity.BranchID, ref iNoOfTxInDayEnd, ref oData);

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
                        clsValidation.WriteErrorLog("\nSuccessfully Updated to One Galle Face Server ;" + oDataResponce.recordsImported + " records were uploed");
                        //DBHandling.ExecQuery("INSERT INTO [dbo].[tbl_posDayStartAndEnd_OneGalleFace] ([jsonResult] ,[response], [isSuccess], [statustime]) VALUES (" + sSalesdata + "' , '" + sResult + "', '1', '" + clsSecurity.getServerDateTime() + "')");
                        foreach (PosSale oD in oData.PosSales)
                        {
                            tbl_posTransaction oPos = tbl_posTransaction.Select(oD.ReceiptNo);
                            if (oPos != null)
                            {
                                oPos.IsChecked = true;
                                oPos.DateChecked = clsSecurity.getServerDateTime();
                                oPos.CheckedUser_ID = clsSecurity.UserIDLoged;
                                oPos.Update();
                            }
                        }
                    }
                    else
                    {
                        clsValidation.WriteErrorLog("\nSomething Went Wrong, Error Details : " + oDataResponce.errorDetails);
                        //DBHandling.ExecQuery("INSERT INTO [dbo].[tbl_posDayStartAndEnd_OneGalleFace] ([jsonResult] ,[response], [isSuccess], [statustime]) VALUES (" + sSalesdata + "' , '" + sResult + "', '0' '" + clsSecurity.getServerDateTime() + "')");
                    }
                }
                catch (Exception ex)
                {
                    clsValidation.WriteErrorLog("\nOne Galleface Sync Error " + clsSecurity.getServerDateTime() + " - " + ex.Message);
                }
            }
        }

        //Upload Data for Customer Rewards
        public static void SendTxDataforMallRewards(string sPosTx_ID, DateTime dtmPosTx, decimal dAmount)
        {
            try
            {
                RewardRequestBody oRequestBody = new RewardRequestBody();
                oRequestBody.amount = dAmount;
                oRequestBody.receiptNumber = sPosTx_ID;
                oRequestBody.receiptDateTime = dtmPosTx.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"); ;
                oRequestBody.posId = "POS-2";

                string sJsonResult = new JavaScriptSerializer().Serialize(oRequestBody);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(sPosMerchantURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(sJsonResult);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string sResult = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    sResult = streamReader.ReadToEnd();
                }
                RewardResponseBody oDataResponce = new JavaScriptSerializer().Deserialize<RewardResponseBody>(sResult);
                if (oDataResponce.status == 0)
                {
                    //Success
                    SEACCMessageBox.Show("Successfully Saved", "Earn Reward Amount Rs: " + oDataResponce.rewardConfirmation.totalReward, MessageBoxButton.OK, "Green");
                }
                else if (oDataResponce.status == 1)
                {
                    //Error
                    SEACCMessageBox.Show("Something Went Wrong", "Error Details : " + oDataResponce.error, MessageBoxButton.OK, "Red");
                }
                else if (oDataResponce.status == 2)
                {
                    //Cancel
                    SEACCMessageBox.Show("Something Went Wrong", "Error Details : " + oDataResponce.error, MessageBoxButton.OK, "Red");
                }
                else
                {
                    SEACCMessageBox.Show("Something Went Wrong", "Error Details : " + oDataResponce.error, MessageBoxButton.OK, "Red");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

    }

    #region Model Class for Json Object Creation
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

    class RewardRequestBody
    {
        public decimal amount { get; set; }
        public string receiptNumber { get; set; }
        public string receiptDateTime { get; set; }
        public string posId { get; set; }
    }

    class RewardResponseBody
    {
        public string error { get; set; }
        public int status { get; set; }
        public RewardConfirmation rewardConfirmation { get; set; }
    }

    class RewardConfirmation
    {
        public string userId { get; set; }
        public string mobileNo { get; set; }
        public string receiptNumber { get; set; }
        public string receiptDateTime { get; set; }
        public string posId { get; set; }
        public decimal totalAmount { get; set; }
        public decimal totalReward { get; set; }
        public RewardTransction rewardTransactions { get; set; }
    }

    class RewardTransction
    {
        public string serialNumber { get; set; }
        public string rewardValue { get; set; }
        public string rewardName { get; set; }
    }
    #endregion
}
