using Express.SAP.Models;
using Express.SAP.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Express.Interfaces.SAP;
using Express.UI.Factory.SAP;
using Express.View.Domain.SAP;

namespace Express.SAP.Controllers
{
    public class SAPInvoiceController : ApiController
    {

      //   SI_Yms_CreditCheck_OB.SI_Yms_CreditCheck_OBService CreditCheck;

        //Invoice.zbapi_acc_document_post InvoicePass;
        Invoice.zzbapi_acc_document_post InvoicePass;
        Reversal.zdocrevpost ReversalPass;

        private readonly ISAPInvoice _extProvider;

        private List<InvoiceHeaderView> invoiceList = null;
        private List<InvoiceHeaderView> reverseList = null;

        private InvoiceHeaderView invHed = null;
        private InvoiceHeaderView revHed = null;


        public SAPInvoiceController()
        {
            try
            {
                if (_extProvider == null)
                {
                    _extProvider = SAPFactory.GetService<ISAPInvoice>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
         

           
        }


        [HttpPost]
        [Route("INVOICE")]
        public IHttpActionResult PostClient()
        {



            CommonJsonResponce response = new CommonJsonResponce();

            SAPInvoiceHeader mSAPINV = new SAPInvoiceHeader();


            response.Message = "";
            string mReturn = "";

            invoiceList = _extProvider.GetInvoiceHeader("").ToList<InvoiceHeaderView>();
            reverseList = _extProvider.GetReversalHeader("").ToList<InvoiceHeaderView>();
            invHed = new InvoiceHeaderView();
            revHed = new InvoiceHeaderView();

            if (invoiceList.Count == 0)
            {
                if (reverseList.Count == 0)
                {
                    mReturn = mReturn + "SUCCESS|There are no pending invoices or reversals to process";
                    response.Message = mReturn;
                    return Ok(response);
                }                
            }

       
            for (int i = 0; i < invoiceList.Count; i++)
            {


                response.Message = "";              

                try
                {


                    ServicePointManager.Expect100Continue = false;
                    //InvoicePass = new Invoice.zbapi_acc_document_post
                    InvoicePass = new Invoice.zzbapi_acc_document_post
                    {
                        Credentials = new NetworkCredential(Settings.Default.SapUserName, Settings.Default.SapPassword),
                        UnsafeAuthenticatedConnectionSharing = true,
                        AllowAutoRedirect = true,
                        PreAuthenticate = true
                    };
                    
                    //Invoice.ZbapiAccDocumentPost InvoiceReq = new Invoice.ZbapiAccDocumentPost();
                    //Invoice.ZbapiAccDocumentPostResponse InvoiceResp = new Invoice.ZbapiAccDocumentPostResponse();
                    Invoice.ZzbapiAccDocumentPost InvoiceReq = new Invoice.ZzbapiAccDocumentPost();
                    Invoice.ZzbapiAccDocumentPostResponse InvoiceResp = new Invoice.ZzbapiAccDocumentPostResponse();

                    mSAPINV.CustomerCpd = _extProvider.GetCustomerCpd(invoiceList[i].AcDocNo).ToList();

                    InvoiceReq.Customercpd = new Invoice.Bapiacpa09();

                    InvoiceReq.Documentheader = new Invoice.Bapiache09();



                    InvoiceReq.Documentheader.AcDocNo = mSAPINV.ACDocNo == null ? "" : mSAPINV.ACDocNo;            
                    InvoiceReq.Documentheader.CompCode = invoiceList[i].CompCode == null ? "" : invoiceList[i].CompCode;
                    InvoiceReq.Documentheader.DocDate = invoiceList[i].DocDate;
                    InvoiceReq.Documentheader.DocType = invoiceList[i].DocType == null ? "" : invoiceList[i].DocType;
                    InvoiceReq.Documentheader.FiscYear = invoiceList[i].FiscYear.ToString();
                    InvoiceReq.Documentheader.FisPeriod = invoiceList[i].FisPeriod.ToString();
                    InvoiceReq.Documentheader.HeaderTxt = invoiceList[i].HeaderTxt == null ? "" : invoiceList[i].HeaderTxt;
                    InvoiceReq.Documentheader.PstngDate = invoiceList[i].PstingDate;
                    InvoiceReq.Documentheader.RefDocNo = invoiceList[i].RefDocNo == null ? "" : invoiceList[i].RefDocNo;
                    InvoiceReq.Documentheader.TransDate = invoiceList[i].TransDate;
                    InvoiceReq.Documentheader.ObjKeyInv = invoiceList[i].ObjKeyInv;
                    InvoiceReq.Documentheader.Username = "USERNAME";


                    if (mSAPINV.CustomerCpd.ToList().Count > 0)
                    {

                        InvoiceReq.Customercpd.Name = mSAPINV.CustomerCpd[0].CustName;
                        InvoiceReq.Customercpd.City = mSAPINV.CustomerCpd[0].CustCity;
                        InvoiceReq.Customercpd.Country = mSAPINV.CustomerCpd[0].CustCountry;

                    }

                    

                    mSAPINV.AccountGL = _extProvider.GetAccountGL(invoiceList[i].AcDocNo).ToList();

                    InvoiceReq.Accountgl = new Invoice.Bapiacgl09[mSAPINV.AccountGL.Count];
                 


                    for (int iGL = 0; iGL < mSAPINV.AccountGL.Count; iGL++)
                    {
                        //-------Account GL---------------                    
                        InvoiceReq.Accountgl[iGL] = new Invoice.Bapiacgl09();

                        InvoiceReq.Accountgl[iGL].ItemnoAcc = mSAPINV.AccountGL[iGL].ItemNoAcc.ToString() == null ? "" : mSAPINV.AccountGL[iGL].ItemNoAcc.ToString();
                        InvoiceReq.Accountgl[iGL].GlAccount = mSAPINV.AccountGL[iGL].GLAccount == null ? "" : mSAPINV.AccountGL[iGL].GLAccount;
                        InvoiceReq.Accountgl[iGL].ItemText = mSAPINV.AccountGL[iGL].ItemText == null ? "" : mSAPINV.AccountGL[iGL].ItemText;
                        InvoiceReq.Accountgl[iGL].AcctType = mSAPINV.AccountGL[iGL].AccType == null ? "" : mSAPINV.AccountGL[iGL].AccType;
                        InvoiceReq.Accountgl[iGL].FisPeriod = mSAPINV.AccountGL[iGL].FisPeriod.ToString();
                        InvoiceReq.Accountgl[iGL].TaxCode = mSAPINV.AccountGL[iGL].TaxCode == null ? "" : mSAPINV.AccountGL[iGL].TaxCode;
                        InvoiceReq.Accountgl[iGL].ProfitCtr = mSAPINV.AccountGL[iGL].ProfitCntr == null ? "" : mSAPINV.AccountGL[iGL].ProfitCntr;
                        InvoiceReq.Accountgl[iGL].RefKey1 = mSAPINV.AccountGL[iGL].RefKey1 == null ? "" : mSAPINV.AccountGL[iGL].RefKey1;
                        InvoiceReq.Accountgl[iGL].RefKey2 = mSAPINV.AccountGL[iGL].RefKey2 == null ? "" : mSAPINV.AccountGL[iGL].RefKey2;
                        InvoiceReq.Accountgl[iGL].RefKey3 = mSAPINV.AccountGL[iGL].RefKey3 == null ? "" : mSAPINV.AccountGL[iGL].RefKey3;
                        InvoiceReq.Accountgl[iGL].Costobject = mSAPINV.AccountGL[iGL].CostObject == null ? "" : mSAPINV.AccountGL[iGL].CostObject;
                        InvoiceReq.Accountgl[iGL].AllocNmbr = mSAPINV.AccountGL[iGL].AllocNum == null ? "" : mSAPINV.AccountGL[iGL].AllocNum;

                    }


                   





                    mSAPINV.AccountReceivable = _extProvider.GetAccountReceivable(invoiceList[i].AcDocNo).ToList();

                    InvoiceReq.Accountreceivable = new Invoice.Bapiacar09[mSAPINV.AccountReceivable.Count];

                    for (int iRc = 0; iRc < mSAPINV.AccountReceivable.Count; iRc++)
                    {
                        //-------Account Receivalble---------------

                        InvoiceReq.Accountreceivable[iRc] = new Invoice.Bapiacar09();


                        InvoiceReq.Accountreceivable[iRc].ItemnoAcc = mSAPINV.AccountReceivable[iRc].ItemNoAcc.ToString() == null ? "" : mSAPINV.AccountReceivable[iRc].ItemNoAcc.ToString();
                        InvoiceReq.Accountreceivable[iRc].Customer = mSAPINV.AccountReceivable[iRc].Customer == null ? "" : mSAPINV.AccountReceivable[iRc].Customer;
                        InvoiceReq.Accountreceivable[iRc].CompCode = mSAPINV.AccountReceivable[iRc].CompCode == null ? "" : mSAPINV.AccountReceivable[iRc].CompCode;
                        InvoiceReq.Accountreceivable[iRc].ProfitCtr = mSAPINV.AccountReceivable[iRc].ProfitCntr == null ? "" : mSAPINV.AccountReceivable[iRc].ProfitCntr;


                        InvoiceReq.Accountreceivable[iRc].RefKey1 = mSAPINV.AccountReceivable[iRc].RefKey1 == null ? "" : mSAPINV.AccountReceivable[iRc].RefKey1;
                        InvoiceReq.Accountreceivable[iRc].RefKey2 = mSAPINV.AccountReceivable[iRc].RefKey2 == null ? "" : mSAPINV.AccountReceivable[iRc].RefKey2;
                        InvoiceReq.Accountreceivable[iRc].RefKey3 = mSAPINV.AccountReceivable[iRc].RefKey3 == null ? "" : mSAPINV.AccountReceivable[iRc].RefKey3;
                        InvoiceReq.Accountreceivable[iRc].Pmnttrms = mSAPINV.AccountReceivable[iRc].PmntTrms == null ? "" : mSAPINV.AccountReceivable[iRc].PmntTrms;
                        InvoiceReq.Accountreceivable[iRc].GlAccount = mSAPINV.AccountReceivable[iRc].GlAccount == null ? "" : mSAPINV.AccountReceivable[iRc].GlAccount;




                    }

                 
                    mSAPINV.AccountTax = _extProvider.GetAccountTax(invoiceList[i].AcDocNo).ToList();

                    InvoiceReq.Accounttax = new Invoice.Bapiactx09[mSAPINV.AccountTax.Count];


                    for (int iAt = 0; iAt < mSAPINV.AccountTax.Count; iAt++)
                    {

                        //--------Account Tax----------------------

                        InvoiceReq.Accounttax[iAt] = new Invoice.Bapiactx09();
                        InvoiceReq.Accounttax[iAt].ItemnoAcc = mSAPINV.AccountTax[iAt].ItemNoAcc.ToString() == null ? "" : mSAPINV.AccountTax[iAt].ItemNoAcc.ToString();
                        InvoiceReq.Accounttax[iAt].GlAccount = mSAPINV.AccountTax[iAt].GLAccount == null ? "" : mSAPINV.AccountTax[iAt].GLAccount;
                        InvoiceReq.Accounttax[iAt].TaxCode = mSAPINV.AccountTax[iAt].TaxCode == null ? "" : mSAPINV.AccountTax[iAt].TaxCode;
                        InvoiceReq.Accounttax[iAt].TaxRate = mSAPINV.AccountTax[iAt].TaxRate;

                    }

                  
                       
                    mSAPINV.CurrencyAmount = _extProvider.GetCurrencyAmount(invoiceList[i].AcDocNo).ToList();

                    InvoiceReq.Currencyamount = new Invoice.Bapiaccr09[mSAPINV.CurrencyAmount.Count];

                    for (int iCa = 0; iCa < mSAPINV.CurrencyAmount.Count; iCa++)
                    {

                        //--------Currency Amount----------------------

                        InvoiceReq.Currencyamount[iCa] = new Invoice.Bapiaccr09();

                        InvoiceReq.Currencyamount[iCa].ItemnoAcc = mSAPINV.CurrencyAmount[iCa].ItemNoAcc.ToString() == null ? "" : mSAPINV.CurrencyAmount[iCa].ItemNoAcc.ToString();
                        InvoiceReq.Currencyamount[iCa].CurrencyIso = mSAPINV.CurrencyAmount[iCa].CurrencyISO == null ? "" : mSAPINV.CurrencyAmount[iCa].CurrencyISO;
                        InvoiceReq.Currencyamount[iCa].AmtDoccur = mSAPINV.CurrencyAmount[iCa].AmtDocCur;
                        InvoiceReq.Currencyamount[iCa].AmtBase = mSAPINV.CurrencyAmount[iCa].BaseAmt;

                    }

                    InvoiceReq.Return = new Invoice.Bapiret2[1];
                    InvoiceReq.Return[0] = new Invoice.Bapiret2();

                    InvoiceReq.Return[0].Field = "";
                    InvoiceReq.Return[0].LogMsgNo = "";
                    InvoiceReq.Return[0].LogNo = "";
                    InvoiceReq.Return[0].Message = "";
                    InvoiceReq.Return[0].MessageV1 = "";
                    InvoiceReq.Return[0].MessageV2 = "";
                    InvoiceReq.Return[0].MessageV3 = "";
                    InvoiceReq.Return[0].MessageV4 = "";
                    InvoiceReq.Return[0].Number = "";
                    InvoiceReq.Return[0].Parameter = "";
                    InvoiceReq.Return[0].Row = 0;
                    InvoiceReq.Return[0].System = "";
                    InvoiceReq.Return[0].Type = "";


                    InvoicePass.AllowAutoRedirect = true;
                    InvoicePass.PreAuthenticate = true;

                    string s = InvoicePass.Url.ToString();

                    InvoicePass.Proxy = System.Net.GlobalProxySelection.GetEmptyWebProxy();

                   // InvoiceResp = InvoicePass.ZbapiAccDocumentPost(InvoiceReq);
                    InvoiceResp = InvoicePass.ZzbapiAccDocumentPost(InvoiceReq);

                    string ErrMessage = "";

                    string[] result = InvoiceResp.Return[0].Message.Split(':');
                    if ((result[0].ToString() == "Document posted successfully"))
                    {

                        mReturn = mReturn + "SUCCESS|" + invoiceList[i].AcDocNo + InvoiceResp.Return[0].Message + "\n";

                        invHed.AcDocNo = invoiceList[i].AcDocNo;
                        invHed.SAPDocNo = InvoiceResp.Return[0].MessageV2;
                        invHed.SAPSendBy = invoiceList[i].SAPSendBy;

                        _extProvider.UpdateSuccess(invHed);

                    }
                    else
                    {
                        //for (int iErr = 0; iErr < InvoiceResp.Return.Count; iErr++)
                        //{
                        //  
                        //}

                        foreach (var item in InvoiceResp.Return)
                        {
                            ErrMessage = ErrMessage + item.Message + "|";
                        }


                        mReturn = mReturn + "ERROR|" + invoiceList[i].AcDocNo + ErrMessage + "\n";

                        invHed.AcDocNo = invoiceList[i].AcDocNo;
                        invHed.ErrorMessage = ErrMessage;
                        invHed.SAPSendBy = invoiceList[i].SAPSendBy;
                        invHed.ErrorType = "ERROR";


                        _extProvider.UpdateError(invHed);
                    }

                }





                catch (Exception ex)
                {
                    invHed.AcDocNo = invoiceList[i].AcDocNo;
                    invHed.ErrorMessage = ex.Message;
                    invHed.SAPSendBy = invoiceList[i].SAPSendBy;
                    invHed.ErrorType = "EXCEPTION";


                    _extProvider.UpdateError(invHed);
                    mReturn = mReturn + "EXCEPTION|" + invoiceList[i].AcDocNo + ex.Message;
                }

            }

            // --------------------------------------------------------------------------------------- REVERSALS LOOP NEW 2020/07/07


            for (int i = 0; i < reverseList.Count; i++)
            {


                response.Message = "";

                try
                {


                    ServicePointManager.Expect100Continue = false;
                    //InvoicePass = new Invoice.zbapi_acc_document_post
                    ReversalPass = new Reversal.zdocrevpost
                    {
                        Credentials = new NetworkCredential(Settings.Default.SapUserName, Settings.Default.SapPassword),
                        UnsafeAuthenticatedConnectionSharing = true,
                        AllowAutoRedirect = true,
                        PreAuthenticate = true
                    };

                    //Invoice.ZbapiAccDocumentPost InvoiceReq = new Invoice.ZbapiAccDocumentPost();
                    //Invoice.ZbapiAccDocumentPostResponse InvoiceResp = new Invoice.ZbapiAccDocumentPostResponse();
                    Reversal.ZzbapiAccDocumentRevPost ReversalReq = new Reversal.ZzbapiAccDocumentRevPost();
                    Reversal.ZzbapiAccDocumentRevPostResponse ReversalResp = new Reversal.ZzbapiAccDocumentRevPostResponse();


                    ReversalReq.CompCode = reverseList[i].CompCode == null ? "" : reverseList[i].CompCode;
                    ReversalReq.DocNo = reverseList[i].SAPDocNo; //SAPPAYDOCNO HERE
                    ReversalReq.FisPeriod = reverseList[i].FisPeriod.ToString();
                    ReversalReq.FiscalYear = reverseList[i].FiscYear.ToString();
                    ReversalReq.PstngDate = reverseList[i].PstingDate;
                    ReversalReq.RevReason = "02";

                    ReversalReq.ItReturn = new Reversal.ZfiReturn1[1];
                    ReversalReq.ItReturn[0] = new Reversal.ZfiReturn1();
                    ReversalReq.ItReturn[0].Message = "";



                    ReversalPass.AllowAutoRedirect = true;
                    ReversalPass.PreAuthenticate = true;

                    string s = ReversalPass.Url.ToString();

                    ReversalPass.Proxy = System.Net.GlobalProxySelection.GetEmptyWebProxy();

                    // InvoiceResp = InvoicePass.ZbapiAccDocumentPost(InvoiceReq);
                   // ZzbapiAccDocumentRevPostResponse ZzbapiAccDocumentRevPost
                    ReversalResp = ReversalPass.ZzbapiAccDocumentRevPost(ReversalReq);

                    string ErrMessage = "";



                    string[] result = ReversalResp.ItReturn[1].Message.Split(':');
                    if ((result[0].ToString() == "Document posted successfully"))
                    {

                        mReturn = mReturn + "SUCCESS|" + reverseList[i].AcDocNo + ReversalResp.ItReturn[1].Message + "\n";

                        revHed.AcDocNo = reverseList[i].AcDocNo;
                        revHed.SAPDocNo = ReversalResp.ObjKey;
                        revHed.SAPSendBy = reverseList[i].SAPSendBy;

                        _extProvider.UpdateSuccess(revHed);

                    }
                    else
                    {
                        //for (int iErr = 0; iErr < InvoiceResp.Return.Count; iErr++)
                        //{
                        //  
                        //}

                        foreach (var item in ReversalResp.ItReturn)
                        {
                            ErrMessage = ErrMessage + item.Message + "|";
                        }


                        mReturn = mReturn + "ERROR|" + reverseList[i].AcDocNo + ErrMessage + "\n";

                        revHed.AcDocNo = reverseList[i].AcDocNo;
                        revHed.ErrorMessage = ErrMessage;
                        revHed.SAPSendBy = reverseList[i].SAPSendBy;
                        revHed.ErrorType = "ERROR";


                        _extProvider.UpdateError(revHed);
                    }

                }





                catch (Exception ex)
                {
                    revHed.AcDocNo = reverseList[i].AcDocNo;
                    revHed.ErrorMessage = ex.Message;
                    revHed.SAPSendBy = reverseList[i].SAPSendBy;
                    revHed.ErrorType = "EXCEPTION";


                    _extProvider.UpdateError(revHed);
                    mReturn = mReturn + "EXCEPTION|" + reverseList[i].AcDocNo + ex.Message;
                }

            }


            response.Message = mReturn;
            return Ok(response);

        }

       
    }
}
