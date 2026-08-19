using Express.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using System.Data;
using Express.Custom.ExcepHandle.DataHadling;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Data.FedexExpressEF;
using Dapper;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Invoice;
using Express.Domain.Message;
using Express.View.Domain.Report.Invoice;
using FedexExpress.View.Domain.Pricing;
using FedexExpress.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.View.Domain.Message;

namespace Express.Data.Invoice
{
    public class InvFrtInvPorcessPrintData : IInvFrtProcessPrint
    {
        public IList<InvoiceTypeCategoryDomainView> DocumentTypes(int companyId, int agencyID)
        {
            try
            {
                ///[Express].[TLM_GetInvFrtInvoiceDetail]
                using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    string query = @"SELECT 
                                        Ltrim(rtrim(Doctype)) 'InvoiceType',
                                        Ltrim(rtrim(DoctypeN)) 'InvoiceTypeN',
                                        Ltrim(rtrim(DocCata)) 'DocCategory'
                                        FROM [Express].[CfgDoctypes] 
                                        WHERE CMPY =@companyID  AND AgncyCode = @agencyID AND Active ='Y'
                                        AND DocCata ='FRT' ";
                    return (List<InvoiceTypeCategoryDomainView>)db.Query<InvoiceTypeCategoryDomainView>(query, new
                    {
                        companyID = companyId,
                        agencyID = agencyID,
                        
                    }).ToList();

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

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@UserID", UserId);
                    para.Add("@ModuleID", ModuleId);
                    para.Add("@MenuID", MenueId);

                    return (List<AgencyDomainViewcs>)conn.Query<AgencyDomainViewcs>("[Project].[TLM_ErpGetUserAgencyList]", para, commandType: CommandType.StoredProcedure).ToList();
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

        public IList<InvFrtPrintProcessDomainView> GetFrtBillingDetail(InvFrtPrintProcessParaDomainView _para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@CompID", _para.CompanyID);
                    para.Add("@AgencyID", _para.AgencyCode);
                    para.Add("@OrgCode", _para.OrgCode);
                    para.Add("@Uptodate", _para.DteUpto);
                    para.Add("@Periodic", _para.InvModeXml);
                    para.Add("@DocTypes", _para.DocType);

                    return (List<InvFrtPrintProcessDomainView>)conn.Query<InvFrtPrintProcessDomainView>("[Express].[TLM_GetInvFrtBillingDetail]", para, commandType: CommandType.StoredProcedure).ToList();
                    
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

        public IList<InvFrtPrintProcessDomainView> GetFrtInvoiceDetail(InvFrtPrintProcessParaDomainView _para)
        {
            try
            {
                ///[Express].[TLM_GetInvFrtInvoiceDetail]
                using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    string query = @"SELECT
                                    CONVERT(varchar(10) , CONVERT(date, TRANS.[TransDate],102)) as TransDate
                                    ,TRANS.[AgnAWBNo] as AWBNumber
                                    ,TRANS.[ExpressID]
                                    ,TRANS.[ConvRate]
                                    , TRANS.ShipType as ShipType
                                    , CONVERT(Varchar(30), TRANS.BillOrgCode) as OrgCode
                                    , TRANS.BillOrgName  as OrgName
                                    , TRANS.[ORGCOUNTRY] as CountryFrom
                                    , TRANS.[DESCOUNTRY] as CountryTo
                                    , TRANS.SvcType as SrvType
                                    , TRANS.PackType as PackType
                                    ,CONVERT(varchar(30) , TRANS.InvNo)  as InvoiceNo 
                                    ,CONVERT(decimal(12,2), TRANS.[FrtSellFcTotal] +(TRANS.[SellReceptChg] +TRANS.[SellPackChg]+TRANS.[SellOtherChg])/TRANS.[ConvRate]) as FrtSellFcTotal
                                    ,(TRANS.[FrtSellLcTotal]+(TRANS.[SellReceptChg] +TRANS.[SellPackChg]+TRANS.[SellOtherChg]))as FrtSellLcTotal

                                    FROM
                                    [Express].[InvoiceTransport] TRANS
                                    INNER JOIN [FinancePR].[Debt] DEBTOR ON DEBTOR.CMPY  = TRANS.CMPY
						                AND DEBTOR.AgncyCode = TRANS.AgncyCode AND DEBTOR.InvNo =TRANS.InvNo
						
                                    WHERE                                    
                                    TRANS.CMPY =@CompID AND TRANS.AgncyCode =@AgencyID
                                    AND ((@isNumber =0 ) OR ( TRANS.InvNo BETWEEN CONVERT(INT, @InvFrom) AND CONVERT(INT, @InvTo)))
                                    AND ((@isDate =0 ) OR ( CONVERT(date, DEBTOR.[DocDate],102) BETWEEN CONVERT(date, @dtFrom,102) AND CONVERT(date, @dtTo,102)))
                                    AND ((@AllAwb =0 ) OR (TRANS.[AgnAWBNo] =@Awbnumber))
                                    AND TRANS.Deleted =0 AND DEBTOR.[Deleted]=0
                                    AND TRANS.InvNo>0
                                    AND TRANS.[DocType]=@DocTypes
                                    AND DEBTOR.DocId ='INV' 
                                    ORDER BY TRANS.TransDate , TRANS.InvNo ,TRANS.BillOrgCode  ";
                    return (List<InvFrtPrintProcessDomainView>)db.Query<InvFrtPrintProcessDomainView>(query, new
                    {
                        CompID = _para.CompanyID,
                        AgencyID = _para.AgencyCode,
                        isNumber = _para.IsInvNumberRange,
                        isDate = _para.IsInvDateRange,
                        AllAwb = _para.AllAwb,
                        InvFrom = _para.FromInvNo,
                        InvTo = _para.ToInvNo,
                        dtFrom = _para.DtFrom,
                        dtTo = _para.DtTo,
                        Awbnumber = _para.AwbNumber,
                        DocTypes =_para.DocType 
                    }).ToList();

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

        public IList<FrtInvoiceReportDomainView> GetIFrtRptInvoiceDetail(InvFrtPrintProcessParaDomainView _para)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@companyID", _para.CompanyID);
                    para.Add("@agencyCode", _para.AgencyCode);
                    para.Add("@InvNumFrom", (_para.FromInvNo == "") ? 0 : Convert.ToInt32(_para.FromInvNo));
                    para.Add("@InvNumTo", (_para.ToInvNo == "") ? 0 : Convert.ToInt32(_para.ToInvNo));
                    para.Add("@InvType", _para.DocType);
                    para.Add("@DateFrom", _para.DtFrom);
                    para.Add("@DateTo", _para.DtTo);
                    para.Add("@AgnAwbNo", _para.AwbNumber);
                    para.Add("@IsNumber", _para.IsInvNumberRange);
                    para.Add("@IsDate", _para.IsInvDateRange);
                    para.Add("@IsAllAwb", _para.AllAwb);

                    return (List<FrtInvoiceReportDomainView>)conn.Query<FrtInvoiceReportDomainView>("[Express].[TLM_RepInvoiceBulkPrintFrt]", para, commandTimeout: 1000, commandType: CommandType.StoredProcedure).ToList();

                }


                //using (IExpressUnitOfWork<FrtInvoiceReportDomainView> uof = new ExpressUnitOfWork<FrtInvoiceReportDomainView>())
                //{
                //    SqlParameter[] paraList = new SqlParameter[]
                //          {
                //                new SqlParameter("@companyID", _para.CompanyID),
                //                new SqlParameter("@agencyCode", _para.AgencyCode),
                //                new SqlParameter("@InvNumFrom", (_para.FromInvNo == "") ? 0 : Convert.ToInt32(_para.FromInvNo)),
                //                new SqlParameter("@InvNumTo", (_para.ToInvNo == "") ? 0 : Convert.ToInt32(_para.ToInvNo)),
                //                new SqlParameter("@InvType", _para.DocType),
                //                new SqlParameter("@DateFrom", _para.DtFrom),
                //                new SqlParameter("@DateTo", _para.DtTo),
                //                new SqlParameter("@AgnAwbNo", _para.AwbNumber),
                //                new SqlParameter("@IsNumber", _para.IsInvNumberRange),
                //                new SqlParameter("@IsDate", _para.IsInvDateRange),
                //                new SqlParameter("@IsAllAwb", _para.AllAwb),
                //};
                //    var invTaxReport = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_RepInvoiceBulkPrintFrt]", paraList)
                //                        select new
                //                        {
                //                            SR.CompanyID,
                //                            SR.GroupID,

                //                            SR.InvDate,
                //                            SR.TransDate,
                //                            SR.ShipDate,
                //                            SR.InvNo,
                //                            SR.OrgCode,
                //                            SR.OrgName,
                //                            SR.OrgCountry,
                //                            SR.OrgAddr1,
                //                            SR.OrgAddr2,
                //                            SR.OrgCity,
                //                            SR.ChargeCode,
                //                            SR.ChargeDesc,
                //                            SR.ConvRate,
                //                            SR.LocalCurrency,
                //                            SR.ForiengCurrency,
                //                            SR.LineLCAmount,
                //                            SR.LineFCAmount,
                //                            SR.DebtorFLCurrency,
                //                            SR.DebtorLCCurrency,
                //                            SR.DebtorFCTotAmount,
                //                            SR.DebtorLCTotAmount,
                //                            SR.Remarks,
                //                            SR.AgnAWBNo,
                //                            SR.SvcType,
                //                            SR.PackType,
                //                            SR.TotPkgs,
                //                            SR.TotWgt,
                //                            SR.WgtU,
                //                            SR.BillWgt,
                //                            SR.DimVol,
                //                            SR.RexWgt,
                //                            SR.RexVol,
                //                            SR.DocNdoc,
                //                            SR.FuelShgPer,
                //                            SR.Shipper,
                //                            SR.Consingnee,
                //                            SR.OrginCounty,
                //                            SR.DestCountry,
                //                            SR.RowID,
                //                            SR.TaxCode1Val,
                //                            SR.TaxCode2Val,
                //                            SR.LineTaxCode2Value,
                //                            SR.GoodDescription,
                //                            SR.PackName,
                //                            SR.AgncyID,
                //                            SR.DocType,
                //                            SR.PayMode,
                //                            SR.InvGroup,
                //                            SR.AccNo



                //                        }).ToList().Select(SR => new FrtInvoiceReportDomainView
                //                        {
                //                            GroupID = SR.GroupID,
                //                            CompanyID = SR.CompanyID,
                //                            InvDate = SR.InvDate,
                //                            ShipDate = SR.ShipDate,
                //                            InvNo = SR.InvNo,
                //                            OrgCode = SR.OrgCode,
                //                            OrgName = SR.OrgName,
                //                            OrgCountry = SR.OrgCountry,
                //                            OrgAddr1 = SR.OrgAddr1,
                //                            OrgAddr2 = SR.OrgAddr2,
                //                            OrgCity = SR.OrgCity,
                //                            ChargeCode = SR.ChargeCode,
                //                            ChargeDesc = SR.ChargeDesc,
                //                            ConvRate = SR.ConvRate,
                //                            LineLCAmount = SR.LineLCAmount,
                //                            LineFCAmount = SR.LineFCAmount,
                //                            LocalCurrency = SR.LocalCurrency,
                //                            ForiengCurrency = SR.ForiengCurrency,

                //                            DebtorLCTotAmount = SR.DebtorLCTotAmount,
                //                            DebtorFCTotAmount = SR.DebtorFCTotAmount,
                //                            DebtorFLCurrency = SR.DebtorFLCurrency,
                //                            DebtorLCCurrency = SR.DebtorLCCurrency,

                //                            Remarks = SR.Remarks,
                //                            AgnAWBNo = SR.AgnAWBNo,
                //                            SvcType = SR.SvcType,
                //                            PackType = SR.PackType,
                //                            TotPkgs = SR.TotPkgs,
                //                            TotWgt = SR.TotWgt,
                //                            WgtU = SR.WgtU,
                //                            BillWgt = SR.BillWgt,
                //                            DimVol = SR.DimVol,
                //                            RexWgt = SR.RexWgt,
                //                            RexVol = SR.RexVol,
                //                            DocNdoc = SR.DocNdoc,
                //                            FuelShgPer = SR.FuelShgPer,
                //                            Shipper = SR.Shipper,
                //                            Consingnee = SR.Consingnee,
                //                            OrginCounty = SR.OrginCounty,
                //                            DestCountry = SR.DestCountry,
                //                            RowID = SR.RowID,
                //                            TaxCode1Val = SR.TaxCode1Val,
                //                            TaxCode2Val = SR.TaxCode2Val,
                //                            LineTaxCode2Value = SR.LineTaxCode2Value,
                //                            GoodDescription = SR.GoodDescription,
                //                            PackName = SR.PackName,
                //                            AgncyID = SR.AgncyID,
                //                            DocType = SR.DocType,
                //                            PayMode = SR.PayMode,
                //                            InvGroup = SR.InvGroup,
                //                            AccNo = SR.AccNo
                //                        }).ToList();


                //    return invTaxReport;
                //}

            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<FrtInvoiceSummeryDomainView> GetIFrtRptInvoiceSummary(InvFrtPrintProcessParaDomainView _para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@companyID", _para.CompanyID);
                    para.Add("@agencyCode", _para.AgencyCode);
                    para.Add("@InvNumFrom", (_para.FromInvNo == "") ? 0 : Convert.ToInt32(_para.FromInvNo));
                    para.Add("@InvNumTo", (_para.ToInvNo == "") ? 0 : Convert.ToInt32(_para.ToInvNo));
                    para.Add("@InvType", _para.DocType);
                    para.Add("@DateFrom", _para.DtFrom);
                    para.Add("@DateTo", _para.DtTo);
                    para.Add("@AgnAwbNo", _para.AwbNumber);
                    para.Add("@IsNumber", _para.IsInvNumberRange);
                    para.Add("@IsDate", _para.IsInvDateRange);
                    para.Add("@IsAllAwb", _para.AllAwb);

                    return (List<FrtInvoiceSummeryDomainView>)conn.Query<FrtInvoiceSummeryDomainView>("[Express].[TLM_RepInvoiceFrtSummery]", para, commandTimeout: 1000 , commandType: CommandType.StoredProcedure).ToList();

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

        public IList<InvProcessModeDomainView> GetInvProcessMode()
        {
            try
            {
                List < InvProcessModeDomainView >  InvModeList= new List<InvProcessModeDomainView>();
                var _daily = new InvProcessModeDomainView
                {
                    InvMode ="D",
                    InvModeN = "Daily"
                };

                var _weekly = new InvProcessModeDomainView
                {
                    InvMode = "W",
                    InvModeN = "Weekly"
                };

                var _fnight = new InvProcessModeDomainView
                {
                    InvMode = "F",
                    InvModeN = "Fortnight"
                };

                var _monthly = new InvProcessModeDomainView
                {
                    InvMode = "M",
                    InvModeN = "Monthly"
                };
                InvModeList.Add(_daily);
                InvModeList.Add(_weekly);
                InvModeList.Add(_fnight);
                InvModeList.Add(_monthly);

                return InvModeList;

                //using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                //{
                //    var para = new DynamicParameters();
                //    para.Add("@UserID", UserId);
                //    para.Add("@ModuleID", ModuleId);
                //    para.Add("@MenuID", MenueId);

                //    return (List<AgencyDomainViewcs>)conn.Query<AgencyDomainViewcs>("[Project].[TLM_GetUserAgencyList]", para, commandType: CommandType.StoredProcedure).ToList();
                //}

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

        public ResponseMessage InvBulkProcess(InvFrtPrintProcessParaDomainView para)
        {
            ResponseMessage mMessage = new ResponseMessage();            
            
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var _para = new DynamicParameters();
                    _para.Add("@CMPY", para.CompanyID);
                    _para.Add("@AgncyCode", para.AgencyCode);
                    _para.Add("@CustCode", para.OrgCode);
                    _para.Add("@PeriodType", para.InvMode);
                    _para.Add("@DocType", para.DocType );
                    _para.Add("@UptoDate", para.DteUpto);
                    _para.Add("@DocDate", para.DocDate);
                    _para.Add("@UserID", para.UserID);

                    var responce = (AppResponseMessage)conn.Query<AppResponseMessage>("[FinanceGL].[USP_BulkInvoiceProccess]", _para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    if (responce.ResponseMessage == "Successfull")
                    {
                        mMessage.StrMessage = AppMessage.SaveSuccess;
                        mMessage.ReturnValue = responce.ReturnValue;
                        mMessage.ReturnValue2 = responce.ReturnValue2;
                        mMessage.IsSuccess = true;
                    }
                    else
                    {
                        mMessage.StrMessage = (responce.ResponseMessage==null || responce.ResponseMessage =="") ? "Error in process": responce.ResponseMessage;
                        mMessage.ReturnValue = responce.ReturnValue;
                        mMessage.ReturnValue2 = responce.ReturnValue2;
                        mMessage.IsSuccess = false;
                    }

                    return mMessage;
                }                
            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "", updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;
            }

           
        }
    }
}
