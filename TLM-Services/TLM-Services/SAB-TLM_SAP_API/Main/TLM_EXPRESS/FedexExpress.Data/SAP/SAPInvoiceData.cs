
using Dapper;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Domain.Message;
using Express.Interfaces.SAP;
using Express.View.Domain.SAP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.SAP
{
    public class SAPInvoiceData:ISAPInvoice
    {
        //public IList<InvoiceHeaderView> GetInvoiceHeader(string ACDocNo)
        //{
        //    try
        //    {
        //        using (IExpressUnitOfWork<InvoiceHeaderResult> uof = new ExpressUnitOfWork<InvoiceHeaderResult>())
        //        {
        //            SqlParameter[] paraList = new SqlParameter[]
        //                  {  new SqlParameter("@ACDocNo", ACDocNo),
                            
        //                  };
                   
        //            var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_GetInvoiceHeader]", paraList)
        //                                   select new InvoiceHeaderView
        //                                   {
        //                                      AcDocNo = Ag.AcDocNo,
        //                                      HeaderTxt  = Ag.HeaderTxt,
        //                                      CompCode  = Ag.CompCode,
        //                                      DocDate = Ag.DocDate,
        //                                      PstingDate  = Ag.PstingDate,
        //                                      TransDate = Ag.TransDate,
        //                                      FiscYear = Ag.FiscYear,
        //                                      FisPeriod = Ag.FisPeriod,
        //                                      DocType = Ag.DocType,
        //                                      RefDocNo = Ag.RefDocNo,
        //                                      CreatedBy = Ag.CreatedBy,
        //                                      CreatedDate = Ag.CreatedDate,
        //                                      SAPDocNo  = Ag.SAPDocNo,
        //                                      ErrorMessage = Ag.ErrorMessage,
        //                                     // SendStatus  = Ag.SendStatus,
        //                                      SuccessStatus = Ag.SuccessStatus,
        //                                      SAPSendBy = Ag.SAPSendBy,
        //                                      SAPSendDate = Ag.SAPSendDate,
        //                                      ObjKeyInv= Ag.ObjKeyInv,
        //                                      Name = Ag.Name
                                              

        //                                     }).ToList();

        //            return OrgRegistryList;
        //        }
        //    }
        //    catch (DbUpdateException updateException)
        //    {
        //        var updateBaseException = updateException.GetBaseException() as SqlException;
        //        throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


        public IList<InvoiceHeaderView> GetInvoiceHeader(string ACDocNo)
        {
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    db.Open();
                    string query = @"SELECT   AcDocNo, HeaderTxt, CompCode, DocDate, PstingDate, TransDate, FiscYear, FisPeriod, DocType, RefDocNo, CreatedBy, CreatedDate, isnull(SAPDocNo,'') as SAPDocNo, ISNULL(ErrorMessage,'') AS ErrorMessage, SuccessStatus, isnull(SAPSendBy,0) as SAPSendBy, 
                                              ISNULL(SAPSendDate,GETDATE()) AS SAPSendDate,ObjKeyInv,Name
                                    FROM       SAP.DocHeader
                                    WHERE      SuccessStatus = 0 ";
                    return (List<InvoiceHeaderView>)db.Query<InvoiceHeaderView>(query);
                }
            }

        }



        public IList<AccountGLViewModel> GetAccountGL(string ACDocNo)
        {
            try
            {
                using (IExpressUnitOfWork<AccountGLResult> uof = new ExpressUnitOfWork<AccountGLResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ACDocNo", ACDocNo),

                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_GetAccountGL]", paraList)
                                           select new AccountGLViewModel
                                           {
                                               AccType = Ag.AcctType,
                                               FisPeriod = Ag.FisPeriod,
                                               GLAccount = Ag.GLAccount,
                                               ItemNoAcc = Ag.ItemNoAcc,
                                               ItemText = Ag.ItemText,
                                               ProfitCntr = Ag.ProfitCtr,
                                               TaxCode = Ag.TaxCode,
                                               RefKey1 = Ag.RefKey1,
                                               RefKey2 = Ag.RefKey2,
                                               RefKey3 = Ag.RefKey3,
                                               AllocNum = Ag.AllocNum

                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IList<AccountReceivableViewModel> GetAccountReceivable(string ACDocNo)
        {
            try
            {
                using (IExpressUnitOfWork<AccountReceivableResult> uof = new ExpressUnitOfWork<AccountReceivableResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ACDocNo", ACDocNo),

                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_GetAccountreceivable]", paraList)
                                           select new AccountReceivableViewModel
                                           {
                                              AllocNumber = Ag.AllocNmbr,
                                              CompCode = Ag.CompCode,
                                              ItemNoAcc = Ag.ItemNoAcc,
                                              Customer = Ag.Customer,
                                              ItemText = Ag.ItemText,
                                              PaymentCurISO = Ag.PymtCurISO,
                                              ProfitCntr = Ag.ProfitCtr,
                                              RefKey1 = Ag.RefKey1,
                                              RefKey2 = Ag.RefKey2,
                                              RefKey3 = Ag.RefKey3,
                                              PmntTrms = Ag.PmntTrms,
                                              GlAccount = Ag.GlAccount,
                                              PaymtRef = Ag.PaymtRef
                                              

                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IList<AccountTaxViewModel> GetAccountTax(string ACDocNo)
        {
            try
            {
                using (IExpressUnitOfWork<AccountTaxResult> uof = new ExpressUnitOfWork<AccountTaxResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ACDocNo", ACDocNo),

                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_GetAccounttax]", paraList)
                                           select new AccountTaxViewModel
                                           {
                                             GLAccount = Ag.GLAccount,
                                             ItemNoAcc = Ag.ItemNoAcc,
                                             TaxCode = Ag.TaxCode,
                                             TaxRate = Ag.TaxRate
                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IList<CurrencyAmountViewModel> GetCurrencyAmount(string ACDocNo)
        {
            try
            {
                using (IExpressUnitOfWork<CurrencyAmountResult> uof = new ExpressUnitOfWork<CurrencyAmountResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ACDocNo", ACDocNo),

                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_GetCurrencyamount]", paraList)
                                           select new CurrencyAmountViewModel
                                           {
                                               AmtDocCur = Ag.AmtDocCur,
                                               ItemNoAcc = Ag.ItemNoAcc,
                                               BaseAmt = Ag.BaseAmt,
                                               CurrencyISO = Ag.CurrencyISO,
                                               TaxAmt = Ag.TaxAmt
                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }






        public ResponseMessage UpdateSuccess(InvoiceHeaderView InvHed)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {

                                    new SqlParameter("@ACDocNo",InvHed.AcDocNo)
                                   ,new SqlParameter("@SAPDocNo",InvHed.SAPDocNo)
                                   ,new SqlParameter("@SAPSendBy",InvHed.SAPSendBy)
                                

                                   


                              };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[SAP].[SAP_UpdateSuccess]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,

                                    }).FirstOrDefault();

                    if (responce.StrMessage.Length > 0)
                    {

                        mMessage.StrMessage = responce.StrMessage;
                        mMessage.IsSuccess = true;
                    }
                    else
                    {
                        mMessage.StrMessage = responce.StrMessage;
                        mMessage.IsSuccess = false;
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = sqlEx.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", sqlEx);
            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;

            }
            return mMessage;
        }


        public ResponseMessage UpdateError(InvoiceHeaderView InvHed)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {

                                    new SqlParameter("@ACDocNo",InvHed.AcDocNo)
                                   ,new SqlParameter("@SAPError",InvHed.ErrorMessage)
                                   ,new SqlParameter("@SAPSendBy",InvHed.SAPSendBy)
                                   ,new SqlParameter("@ErrorType",InvHed.ErrorType)



                              };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[SAP].[SAP_UpdateError]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,

                                    }).FirstOrDefault();

                    if (responce.StrMessage.Length > 0)
                    {

                        mMessage.StrMessage = responce.StrMessage;
                        mMessage.IsSuccess = true;
                    }
                    else
                    {
                        mMessage.StrMessage = responce.StrMessage;
                        mMessage.IsSuccess = false;
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = sqlEx.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", sqlEx);
            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;

            }
            return mMessage;
        }



        public IList<InvoiceResendHeader> GetInvoiceResendList(string ACDocNo)
        {
            try
            {
                using (IExpressUnitOfWork<InvoiceHeaderResult> uof = new ExpressUnitOfWork<InvoiceHeaderResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ACDocNo", ACDocNo),

                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_GetInvoiceResendList]", paraList)
                                           select new InvoiceResendHeader
                                           {
                                               AcDocNo = Ag.AcDocNo,
                                               
                                               ErrorMessage = Ag.ErrorMessage,

                                               Customer = Ag.Customer

                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IList<AccountGLView> GetInvoiceGLResendList(string ACDocNo)
        {
            try
            {
                using (IExpressUnitOfWork<InvoiceHeaderResult> uof = new ExpressUnitOfWork<InvoiceHeaderResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ACDocNo", ACDocNo),

                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_GetGLResendList]", paraList)
                                           select new AccountGLView
                                           {
                                               ItemNoAcc = Ag.ItemNoAcc,
                                               GLAccount = Ag.GLAccount,
                                               ProfitCtr = Ag.ProfitCtr

                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }





        public IList<CustomerCpdViewModel> GetCustomerCpd(string ACDocNo)
        {
            try
            {
                using (IExpressUnitOfWork<CustomerCpd> uof = new ExpressUnitOfWork<CustomerCpd>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ACDocNo", ACDocNo),

                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[SAP_CustomerCpd]", paraList)
                                           select new CustomerCpdViewModel
                                           {
                                               CustName = Ag.CustName,
                                               CustCity = Ag.CustCity,
                                               CustCountry = Ag.CustCountry,
                                           

                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }






    }
}
