using Dapper;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.Pricing
{
    public class AWBCreditNoteData : IAWBCreditNote<AWBCreditView>
    {
        private string errorRaiseModule = "AWB_Credit_Note";

        public ResponseMessage DeleteDetail(AWBCreditView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(AWBCreditView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AWBCreditView> GetAWBCredits(string model)
        {
            throw new NotImplementedException();
        }

        //grid
        public IList<AWBCreditNoteDetailDomainViewcs> GetCreditNoteData(int CMPY, int AgencyCode, long InvoiceNo, string AWBNo)
        {
            try
            {
                using (IExpressUnitOfWork<AWBCreditNoteDataResult> uof = new ExpressUnitOfWork<AWBCreditNoteDataResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@InvoiceNo", InvoiceNo),
                             new SqlParameter("@ComapnyID", CMPY),
                             new SqlParameter("@AgencyCode", AgencyCode),
                             new SqlParameter("@AgnAWBNo", AWBNo) };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[FinancePR].[USP_GetJobDetailForCreditNote]", paraList)
                                           select new AWBCreditNoteDetailDomainViewcs
                                           {
                                               AutoId = Ag.AutoId,
                                               CMPY = Ag.CMPY,
                                               ExpressID = Ag.ExpressID,
                                               AgncyCode = Ag.AgncyCode,
                                               AWBLCAmount = Ag.AWBLCAmount,
                                               AWBNo = Ag.AWBNo,
                                               CRDLCAmount = Ag.CRDLCAmount,
                                               IsCreditabil = Ag.IsCreditabil,
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

        public IList<AWBCreditNoteDetailDomainViewcs> GetCreditNoteDataFromJobTrance(int CMPY, int AgencyCode, long InvoiceNo)
        {
            try
            {
                using (IExpressUnitOfWork<AWBCreditNoteDataResult> uof = new ExpressUnitOfWork<AWBCreditNoteDataResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CreditNoteNo", InvoiceNo), new SqlParameter("@ComapnyID", CMPY), new SqlParameter("@AgencyCode", AgencyCode) };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[FinancePR].[USP_GetCreditNoteDetailFromJobTrance]", paraList)
                                           select new AWBCreditNoteDetailDomainViewcs
                                           {
                                               AutoId = Ag.AutoId,
                                               CMPY = Ag.CMPY,
                                               ExpressID = Ag.ExpressID,
                                               AgncyCode = Ag.AgncyCode,
                                               AWBLCAmount = Ag.AWBLCAmount,
                                               AWBNo = Ag.AWBNo,
                                               CRDLCAmount = Ag.CRDLCAmount,
                                               IsCreditabil = Ag.IsCreditabil,
                                           }).ToList();
                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public IList<AWBCreditView> GetCreditNoteDetailFromDebt(decimal CreditNoteNo)
        {
            try
            {
                using (IExpressUnitOfWork<AWBCreditNoteResult> uof = new ExpressUnitOfWork<AWBCreditNoteResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CreditNoteNo", CreditNoteNo) };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[FinancePR].[USP_GetCreditNoteDetail]", paraList)
                                           select new AWBCreditView
                                           {
                                               AccountCode = Ag.AccountCode,
                                               BALANCE = Ag.BALANCE,
                                               CMPY = Ag.CMPY,
                                               AgncyCode = Ag.AgncyCode,
                                               BranchCode = Ag.BranchCode,
                                               ConvRate = Ag.ConvRate,
                                               Deleted = Ag.Deleted,
                                               DeptCode = Ag.DeptCode,
                                               DocDate = Ag.DocDate,
                                               DocId = Ag.DocId,
                                               DocNo = Ag.DocNo,
                                               DocReference = Ag.DocReference,
                                               DocType = Ag.DocType,
                                               FC = Ag.FC,
                                               InvNo = Ag.InvNo,
                                               JobNo = Ag.JobNo,
                                               LC = Ag.LC,
                                               OrgAddr1 = Ag.OrgAddr1,
                                               OrgAddr2 = Ag.OrgAddr2,
                                               OrgCity = Ag.OrgCity,
                                               OrgCode = Ag.OrgCode,
                                               OrgCountry = Ag.OrgCountry,
                                               OrgName = Ag.OrgName,
                                               OrgPerson = Ag.OrgPerson,
                                               PayAcPay = Ag.PayAcPay,
                                               PayDate = Ag.PayDate,
                                               PayMode = Ag.PayMode,
                                               PayRefBank = Ag.PayRefBank,
                                               PayRefNo = Ag.PayRefNo,
                                               PayTo = Ag.PayTo,
                                               PMVALRS = Ag.PMVALRS,
                                               ReferenceID = Ag.ReferenceID,
                                               ReferenceID1 = Ag.ReferenceID1,
                                               RefNo = Ag.RefNo,
                                               RefNo1 = Ag.RefNo1,
                                               RefNo2 = Ag.RefNo2,
                                               RefNo3 = Ag.RefNo3,
                                               Remarks1 = Ag.Remarks1,
                                               Remarks2 = Ag.Remarks2,
                                               SlockCode = Ag.SlockCode,
                                               SVATNO = Ag.SVATNO,
                                               TaxCode1 = Ag.TaxCode1,
                                               TaxCode1Per = Ag.TaxCode1Per,
                                               TaxCode1Val = Ag.TaxCode1Val,
                                               TaxCode2 = Ag.TaxCode2,
                                               TaxCode2Per = Ag.TaxCode2Per,
                                               TaxCode2Val = Ag.TaxCode2Val,
                                               TaxCode3 = Ag.TaxCode3,
                                               TaxCode3Per = Ag.TaxCode3Per,
                                               TaxCode3Val = Ag.TaxCode3Val,
                                               TaxRegNo = Ag.TaxRegNo,
                                               TaxRegNo1 = Ag.TaxRegNo1,
                                               TaxRegNo2 = Ag.TaxRegNo2,
                                               TaxRegNo3 = Ag.TaxRegNo3,
                                               TaxRegNo4 = Ag.TaxRegNo4,
                                               TranDate1 = Ag.TranDate1,
                                               TranDate2 = Ag.TranDate2,
                                               VALFC = Ag.VALFC,
                                               VALRS = Ag.VALRS,
                                               VATNO = Ag.VATNO,
                                               AgncyName = Ag.AgncyName,
                                               BranchName = Ag.BranchName,
                                               CompName = Ag.CompName,
                                               SalesAreaName = Ag.SalesAreaName,
                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public List<AWBCreditView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<AWBCreditView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public List<AWBCreditView> GetDetails(AWBCreditView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AWBCreditView> GetInvoiceDetailFromDebt(decimal invoiceNo)
        {
            try
            {
                using (IExpressUnitOfWork<AWBCreditNoteResult> uof = new ExpressUnitOfWork<AWBCreditNoteResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                              new SqlParameter("@InvoiceNo", invoiceNo)};
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[FinancePR].USP_GetInvoiceDetailForCreditNote", paraList)
                                           select new AWBCreditView
                                           {
                                               AccountCode = Ag.AccountCode,
                                               BALANCE = Ag.BALANCE,
                                               CMPY = Ag.CMPY,
                                               AgncyCode = Ag.AgncyCode,
                                               BranchCode = Ag.BranchCode,
                                               ConvRate = Ag.ConvRate,
                                               Deleted = Ag.Deleted,
                                               DeptCode = Ag.DeptCode,
                                               DocDate = Ag.DocDate,
                                               DocId = Ag.DocId,
                                               DocNo = Ag.DocNo,
                                               DocReference = Ag.DocReference,
                                               DocType = Ag.DocType,
                                               FC = Ag.FC,
                                               InvNo = Ag.InvNo,
                                               JobNo = Ag.JobNo,
                                               LC = Ag.LC,
                                               OrgAddr1 = Ag.OrgAddr1,
                                               OrgAddr2 = Ag.OrgAddr2,
                                               OrgCity = Ag.OrgCity,
                                               OrgCode = Ag.OrgCode,
                                               OrgCountry = Ag.OrgCountry,
                                               OrgName = Ag.OrgName,
                                               OrgPerson = Ag.OrgPerson,
                                               PayAcPay = Ag.PayAcPay,
                                               PayDate = Ag.PayDate,
                                               PayMode = Ag.PayMode,
                                               PayRefBank = Ag.PayRefBank,
                                               PayRefNo = Ag.PayRefNo,
                                               PayTo = Ag.PayTo,
                                               PMVALRS = Ag.PMVALRS,
                                               ReferenceID = Ag.ReferenceID,
                                               ReferenceID1 = Ag.ReferenceID1,
                                               RefNo = Ag.RefNo,
                                               RefNo1 = Ag.RefNo1,
                                               RefNo2 = Ag.RefNo2,
                                               RefNo3 = Ag.RefNo3,
                                               Remarks1 = Ag.Remarks1,
                                               Remarks2 = Ag.Remarks2,
                                               SlockCode = Ag.SlockCode, // business // get jobdetails for credit note
                                               SVATNO = Ag.SVATNO,
                                               TaxCode1 = Ag.TaxCode1,
                                               TaxCode1Per = Ag.TaxCode1Per,
                                               TaxCode1Val = Ag.TaxCode1Val,
                                               TaxCode2 = Ag.TaxCode2,
                                               TaxCode2Per = Ag.TaxCode2Per,
                                               TaxCode2Val = Ag.TaxCode2Val,
                                               TaxCode3 = Ag.TaxCode3,
                                               TaxCode3Per = Ag.TaxCode3Per,
                                               TaxCode3Val = Ag.TaxCode3Val,
                                               TaxRegNo = Ag.TaxRegNo,
                                               TaxRegNo1 = Ag.TaxRegNo1,
                                               TaxRegNo2 = Ag.TaxRegNo2,
                                               TaxRegNo3 = Ag.TaxRegNo3,
                                               TaxRegNo4 = Ag.TaxRegNo4,
                                               TranDate1 = Ag.TranDate1,
                                               TranDate2 = Ag.TranDate2,
                                               VALFC = Ag.VALFC,
                                               VALRS = Ag.VALRS,
                                               VATNO = Ag.VATNO,
                                               AgncyName = Ag.AgncyName,
                                               BranchName = Ag.BranchName,
                                               CompName = Ag.CompName,
                                               SalesAreaName = Ag.SalesAreaName,
                                           }).ToList();

                    return OrgRegistryList;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public IList<AWBCreditView> PreviewData(decimal CreditNoteNo)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var output = connection.Query<AWBCreditView>(@"SELECT JobTrans.Deleted,JobTrans.DocId,JobTrans.SeqNo,JobTrans.ChargeDesc,JobTrans.FCAmt,JobTrans.ConvRate,JobTrans.LCAmt,
                  JobTrans.TaxCode1Val,Company.CompName,Company.Address1,Company.Address2,Company.Logo,Company.Telephone,Company.Email,
                  Company.Fax,Company.TaxRegNo,Debt.DocDate,Debt.DocId,Debt.DocType,Debt.InvNo,Debt.DocNo,Debt.VALFC,Debt.FC,Debt.RefNo1,
                  Debt.RefNo2,Debt.RefNo3,Debt.OrgName,Debt.OrgAddr1,Debt.OrgAddr2,Debt.OrgCity,Debt.Remarks1,JobTrans.InvReference,JobTrans.TaxCode2Val 
	  
                From FinancePR.JobTrans JobTrans INNER JOIN Project.Company Company ON JobTrans.CMPY = Company.CompID INNER JOIN 
	                 FinancePR.Debt Debt ON  JobTrans.InvNo = Debt.InvNo AND JobTrans.DocNo = Debt.DocNo

                Where Debt.DocNo = @DocNo AND  Debt.DocId = 'CRD' and debt.Doccancel<>'Y' AND  
	                   JobTrans.DocId = 'CRD' AND JobTrans.Deleted = 0  Order By JobTrans.SeqNo Asc",
                new { DocNo = CreditNoteNo}).ToList();
                return output;
            }
        }

        //public IList<AWBCreditView> GetInvoiceDetailFromDebt(decimal invoiceNo)
        //{
        //    throw new NotImplementedException();
        //}

        public ResponseMessage SaveCreditNoteDetails(AWBCreditNoteWrappingDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {

                    string xmlString = "<ROOT>";
                    foreach (var item in typePara.CreditNoteList)
                    {
                        var AWBSelected = item.IsCreditabil == true ? "Y" : "N";
                        xmlString = xmlString + "<ROW>"
                      + "<ExpressID>" + item.ExpressID.Trim() + "</ExpressID>"
                      + "<AWBNo>" + item.AWBNo.Trim() + "</AWBNo>"
                      + "<AWBSelected>" + AWBSelected + "</AWBSelected>"
                      + "</ROW>";
                    }
                    xmlString = xmlString + "</ROOT>";

                    SqlParameter[] paraList = new SqlParameter[]
                              { new SqlParameter("@xmlDataValue",xmlString), new SqlParameter("@CMPY",typePara.CMPY), new SqlParameter("@InvoiceNo",typePara.InvoiceNo), new SqlParameter("@DocDate",typePara.DocDate.Date), new SqlParameter("@Naration",typePara.Naration),new SqlParameter("@UserID",typePara.UserID)  };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[FinanceGL].[USP_AWBCreditNoteProccess]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,
                                        ReturnValue = SR.ReturnValue == null ? "0" : SR.ReturnValue

                                    }).FirstOrDefault();

                    if (responce.StrMessage == "Successfull")
                    {
                        mMessage.StrMessage = AppMessage.SaveSuccess;
                        mMessage.ReturnValue = responce.ReturnValue;
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
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Organization", sqlEx);
            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Organization", updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;

            }
            return mMessage;
        }


        public ResponseMessage SaveDetails(AWBCreditView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
