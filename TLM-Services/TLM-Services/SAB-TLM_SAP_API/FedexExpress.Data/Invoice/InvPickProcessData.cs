using Express.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Report.Invoice;
using System.Data;
using System.Data.SqlClient;
using Express.Data.FedexExpressEF;
using Dapper;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using FedexExpress.View.Domain.Pricing;

namespace Express.Data.Invoice
{
    public class InvPickProcessData : IInvPickProcessRepo
    {
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
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

        public IList<InvDelDocTypes> GetPickDocTypes(int companyID, int agencyID, string category)
        {
            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT 
                              [Doctype]  DocType
                              ,[DoctypeN]DocTypeN
                              ,[DocCata] DocTypeCat     
                              ,[BillOrgCode] BillOrgCode
                              ,[ExgRateTarif] ExgRateTarrif     
                          FROM [Express].[CfgDoctypes]
                          WHERE CMPY =@CMPY  AND AgncyCode =@AgencyCode AND Active ='Y' AND [DocCata]='PUP' ";
                return  (List<InvDelDocTypes>)db.Query<InvDelDocTypes>(query, new
                {
                    CMPY = companyID,
                    AgencyCode = agencyID,
                    Doctype = category

                }).ToList();
            }
        }

        public InvPickProcessDomainView GetPickInvoiceDetail(InvPickProcessPramDomainView _para)
        {
            InvPickProcessDomainView _InvDet = new InvPickProcessDomainView();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
                {

                    ////string docSql = @"SELECT 
                    ////          [Doctype]  DocType
                    ////          ,[DoctypeN]DocTypeN
                    ////          ,[DocCata] DocTypeCat     
                    ////          ,[BillOrgCode] BillOrgCode
                    ////          ,[ExgRateTarif] ExgRateTarrif     
                    ////      FROM [Express].[CfgDoctypes](NOLOCK)
                    ////      WHERE CMPY =@CMPY  AND AgncyCode =@AgencyCode AND Active ='Y' AND [DocCata]='PUP' ";
                    ////var docTypesDetail = (InvDelDocTypes)db.Query<InvDelDocTypes>(docSql, new
                    ////{
                    ////    CMPY = _para.CompanyID,
                    ////    AgencyCode = _para.AgencyID,

                    ////}).FirstOrDefault();

                    ////if (docTypesDetail == null)
                    ////{
                    ////    return null;
                    ////}


                    string query = @"SELECT count(1) InvoiceAWBCount ,
                                     SUM( BillWgt) InvoiceBillWgt
                                      FROM
                                    [Express].[InvoiceTransport](NOLOCK)
                                    WHERE CMPY =@Cmpy AND AgncyCode =@AgncyCode AND InvNo = @InvNo 
                                    AND DocType =@docType ";
                    var invtrans = (InvPickProcessDomainView)db.Query<InvPickProcessDomainView>
                        (query, new
                        {
                            Cmpy = _para.CompanyID,
                            AgncyCode = _para.AgencyID,
                            InvNo = _para.InvoiceNo,
                            docType = _para.DocType.Trim(),
                        }).FirstOrDefault();

                    if (invtrans != null)
                    {
                        _InvDet.InvoiceAWBCount = invtrans.InvoiceAWBCount;
                        _InvDet.InvoiceBillWgt = invtrans.InvoiceBillWgt;
                    }
                    else
                    {
                        return null;
                    }



                    string query2 = @"SELECT 
                                        VALFC as InvoiceFCValue,
                                        VALRS as InvoiceLCValue ,
                                        ConvRate as ExtRate ,
                                        FC as SellCurrencyFC,
                                        LC  as SellCurrencyLC,
                                        OrgCode as BillOrgCode,
                                        OrgName as BillOrgName,
                                        OrgAddr1 as BillOrgAdd1,
                                        OrgAddr2 as BillOrgAdd2,
                                        OrgCity as BillOrgCity,
                                        [DocDate] as InvoiceDate,
                                        (SELECT CountryN FROM [Express].[RefCountry] WHERE Country=OrgCountry) as  BillOrgCountry 
                                        FROM
                                        [FinancePR].[Debt](NOLOCK)
                                        WHERE CMPY =@Cmpy AND AgncyCode =@AgncyCode AND InvNo = @InvNo 
                                        AND DocType =@docType ";
                    var invtdbt = (InvPickProcessDomainView)db.Query<InvPickProcessDomainView>
                        (query2, new
                        {
                            Cmpy = _para.CompanyID,
                            AgncyCode = _para.AgencyID,
                            InvNo = _para.InvoiceNo,
                            docType = _para.DocType.Trim(),
                        }).FirstOrDefault();

                    if (invtdbt != null)
                    {
                        _InvDet.InvoiceFCValue = invtdbt.InvoiceFCValue;
                        _InvDet.InvoiceLCValue = invtdbt.InvoiceLCValue;
                        _InvDet.ExtRate = invtdbt.ExtRate;
                        _InvDet.SellCurrencyFC = invtdbt.SellCurrencyFC;
                        _InvDet.SellCurrencyLC = invtdbt.SellCurrencyLC;
                        _InvDet.BillOrgCode = invtdbt.BillOrgCode;
                        _InvDet.BillOrgAdd1 = invtdbt.BillOrgAdd1;
                        _InvDet.BillOrgAdd2 = invtdbt.BillOrgAdd2;
                        _InvDet.BillOrgCity = invtdbt.BillOrgCity;
                        _InvDet.BillOrgCountry = invtdbt.BillOrgCountry;
                        _InvDet.BillOrgName = invtdbt.BillOrgName;
                        _InvDet.InvoiceDate = invtdbt.InvoiceDate;
                    }
                    else
                    {
                        return null;
                    }

                    return _InvDet;
                }
            }
            catch (DbUpdateException updateException)
            {
                return null;
                //var updateBaseException = updateException.GetBaseException() as SqlException;
                //throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public InvPickProcessDomainView GetPickSummeryDetail(InvPickProcessPramDomainView _para)
        {
           // InvDelDocTypes docTypesDetail = null;            
            InvPickProcessDomainView notBilled = null;
            InvPickProcessDomainView notInvoiced = null;
            InvPickProcessDomainView extTarrif = null;
            InvDutyExtrateDomainView exchageRate = null;
            InvPickProcessDomainView billTo = null;
            InvPickProcessDomainView returnValue = new InvPickProcessDomainView();
            ////using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            ////{
            ////    string query = @"SELECT 
            ////                  [Doctype]  DocType
            ////                  ,[DoctypeN]DocTypeN
            ////                  ,[DocCata] DocTypeCat     
            ////                  ,[BillOrgCode] BillOrgCode
            ////                  ,[ExgRateTarif] ExgRateTarrif     
            ////              FROM [Express].[CfgDoctypes]
            ////              WHERE CMPY =@CMPY  AND AgncyCode =@AgencyCode AND Active ='Y' AND [DocCata]='PUP' AND Doctype=@Doctype ";
            ////    docTypesDetail = (InvDelDocTypes)db.Query<InvDelDocTypes>(query, new
            ////    {
            ////        CMPY = _para.CompanyID,
            ////        AgencyCode = _para.AgencyID,
            ////        Doctype = _para.DocType

            ////    }).FirstOrDefault();
            ////}

            ////if (docTypesDetail == null)
            ////{
            ////    return null;
            ////}
            returnValue.DocType = _para.DocType ;
            returnValue.BillOrgCode = _para.BillOrgCode;

            //// Bill Orgnization
            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT 
                                      ([OrgName]+CHAR(13)+CHAR(10)+
                                      [OrgAddr1]+CHAR(13)+CHAR(10)+
                                      [OrgAddr2]+CHAR(13)+CHAR(10)+
                                      [OrgCity]+CHAR(13)+CHAR(10)+[OrgCountry]) BillParty,
                                      [OrgName]as BillOrgName,
                                      [OrgAddr1]as BillOrgAdd1,
                                      [OrgAddr2] as BillOrgAdd2,
                                      [OrgCity] as BillOrgCity,
                                      (SELECT CountryN FROM [Express].[RefCountry] WHERE Country=[OrgCountry]) as  BillOrgCountry
                                      FROM
                                      [SharedMain].[RefOrganization](NOLOCK)
                                      WHERE 
                                      [OrgCode]=@billOrgCode AND Deleted =0 AND OrgActive= 'Y'";
                billTo = (InvPickProcessDomainView)db.Query<InvPickProcessDomainView>(query, new
                {
                    billOrgCode = _para.BillOrgCode,

                },
                commandTimeout: 600).FirstOrDefault();
            }

            if (billTo == null)
            {
                return null;
            }
            returnValue.BillParty = billTo.BillParty;
            returnValue.BillOrgName = billTo.BillOrgName;
            returnValue.BillOrgAdd1 = billTo.BillOrgAdd1;
            returnValue.BillOrgAdd2 = billTo.BillOrgAdd2;
            returnValue.BillOrgCity = billTo.BillOrgCity;
            returnValue.BillOrgCountry = billTo.BillOrgCountry;

            

            /// not billed
            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT  count(1) CountPendingAwb ,isnull( sum( TotWgt),0) CountPendingWgt  
                                FROM [Express].[OpsConsAWB] (NOLOCK)
                                WHERE [CMPY] =@CMPY AND  [AgncyCode] =@AgncyCode  
                                AND Deleted =0 AND   [ShipType]='O' 
                                AND [BillTransChg]='C' AND [BillTransChgY]='' 
                                AND InvNoTransChg=0
                                AND CONVERT(Date ,[TransDate],102) <=CONVERT(Date ,@UptoDate,102) AND ExpressMpsNo =0";
                notBilled = (InvPickProcessDomainView)db.Query<InvPickProcessDomainView>(query, new
                {
                    CMPY = _para.CompanyID,
                    AgncyCode = _para.AgencyID,
                    UptoDate = _para.Uptodate

                }).FirstOrDefault();
            }

            if (notBilled != null)
            {
                returnValue.CountPendingAwb = notBilled.CountPendingAwb;
                returnValue.CountPendingWgt = notBilled.CountPendingWgt;
            }

            /// not invoiced
            /// 


            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT count(1) CountBillAwb , ISNULL( SUM( BillWgt),0)CountBillWgt 
                            ,ISNULL( SUM( [PickupChgTotal] ),0) CountBillAmt
                            FROM [Express].[InvoiceTransport](NOLOCK)
                            WHERE CMPY =@CMPY and AgncyCode =@AgncyCode
                            AND Deleted =0 AND ShipType ='O' 
                            AND BillTo ='C' AND DocType = @DocType 
                            AND InvNo =0 
                            AND CONVERT(Date , [TransDate] ,102) <=CONVERT(Date, @UptoDate ,102)
                            ";
                notInvoiced = (InvPickProcessDomainView)db.Query<InvPickProcessDomainView>(query, new
                {
                    CMPY = _para.CompanyID,
                    AgncyCode = _para.AgencyID,
                    DocType = _para.DocType,
                    UptoDate = _para.Uptodate

                }).FirstOrDefault();
            }

            if (notInvoiced != null)
            {
                returnValue.CountBillAwb = notInvoiced.CountBillAwb;
                returnValue.CountBillWgt = notInvoiced.CountBillWgt;
                returnValue.CountBillAmt = notInvoiced.CountBillAmt;
            }

            //// Exchange Rate//

            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT 
                                [SellCurrencyFC]
                                ,[SellExgRateTarif]      
                                FROM [FinancePR].[RefDocTypes]
                                WHERE CMPY =@CMPY AND  Active ='Y' AND DocType=@DocType";
                extTarrif = (InvPickProcessDomainView)db.Query<InvPickProcessDomainView>(query, new
                {
                    CMPY = _para.CompanyID,
                    DocType = _para.DocType,


                }).FirstOrDefault();
            }

            if (extTarrif == null)
            {
                return null;
            }
            returnValue.SellCurrencyFC = extTarrif.SellCurrencyFC;
            returnValue.SellExgRateTarif = extTarrif.SellExgRateTarif;


            using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var para = new DynamicParameters();
                para.Add("@dateTo", _para.Uptodate);
                para.Add("@companyID", _para.CompanyID);
                para.Add("@currency", extTarrif.SellCurrencyFC);
                para.Add("@TarrifNo", extTarrif.SellExgRateTarif);

                exchageRate = (InvDutyExtrateDomainView)conn.Query<InvDutyExtrateDomainView>("[Util].[Finance_GetFrtExchangeRate]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            if (exchageRate == null)
            {
                return null;
            }

            returnValue.ExtRate = exchageRate.ExgRate;
            returnValue.SellCurrencyLC = exchageRate.BaseCurrency;




            return returnValue;
        }

        public IList<InvoicePickupRptDomainView> GetRptPickupBillingPending(InvPickProcessPramDomainView _para)
        {
            using (IDbConnection connection = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var output = connection.Query<InvoicePickupRptDomainView>(@"SELECT
                AgnAWBNo,
                TransDate,                
                ORGCOUNTRY,
                DESCOUNTRY,
                TotWgt 
                FROM Express.OpsConsAWB
                WHERE ShipType ='O' AND Deleted = '0'AND BillTransChgY ='' and BillTransChg ='C' 
                AND [InvNoTransChg] =0
                and AgncyCode =@AgncyCode  and convert(date, TransDate,102) <=convert(date, @TransDate,102)
                AND ExpressMpsNo = '0'",
                new
                {
                    TransDate =_para.Uptodate  ,
                    AgncyCode = _para.AgencyID
                }).ToList();
                return output;
            }
        }

        public IList<InvoicePickupRptDomainView> GetRptPickupInvoicePending(InvPickProcessPramDomainView _para)
        {
            using (IDbConnection connection = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var output = connection.Query<InvoicePickupRptDomainView>(@"SELECT 
                    [AgnAWBNo] AgnAWBNo,
                    [TransDate] TransDate,                    
                    [ORGCOUNTRY]ORGCOUNTRY,
                    [DESCOUNTRY] DESCOUNTRY,
                    [BillWgt] TotWgt,
                    [PickupChgTotal] Pickupchg
                    FROM [Express].[InvoiceTransport]        
                    WHERE [ShipType] ='O' AND [Deleted] = '0' AND  [BillTo] ='C'  
                    and DocType =@Doctype AND InvNo =0 AND CMPY =@CMPY 
                    AND [AgncyCode] = @AgncyCode and Convert(date, [TransDate],102) <= Convert(date, @TransDate,102) ",
                new {
                    TransDate = _para.Uptodate ,
                    AgncyCode = _para.AgencyID ,
                    Doctype = _para.DocType,
                    CMPY = _para.CompanyID 
                }).ToList();
                return output;
            }
        }


        public IList<InvoicePickupRepDetailDomainView> GetRptPickupDetail(InvPickProcessPramDomainView _para)
        {
            using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                //var output = connection.Query<InvoicePickupRepDetailDomainView>(@"DECLARE @CompanyName varchar(150)
                //SELECT @CompanyName=CompName FROM [Project].[Company] WHERE CompID =@CMPY
                //SELECT LastScanDate  'PODDate',AgnAWBNo 'AWBNO' ,@CompanyName 'CompanyName',
                //'' 'Remark',Convert(varchar(30), @InvNoTransChg) 'InvoiceNo'
                //FROM [Express].[OpsConsAWB] WHERE CMPY =@CMPY AND AgncyCode =@AgncyCode AND ShipType = 'O' AND BillTransChg = 'C' AND ExpressMpsNo=0
                //AND InvNoTransChg  =CONVERT(numeric(18,0) ,@InvNoTransChg)",
                //new { CMPY = _para.CompanyID , AgncyCode = _para.AgencyID , InvNoTransChg = _para.InvoiceNo }).ToList();
                //return output;

                var para = new DynamicParameters();
                para.Add("@CompanyID", _para.CompanyID );
                para.Add("@agencyID", _para.AgencyID );
                para.Add("@invFrom", _para.InvoiceNo );
                para.Add("@invTo", _para.InvoiceNo);

                return (List<InvoicePickupRepDetailDomainView>)conn.Query<InvoicePickupRepDetailDomainView>("[Express].[TLM_RepPickupInvDetail]", para, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public IList<InvoicePickupRepSummeryDomainView> GetRptPickupSummary(InvPickProcessPramDomainView _para)
        {
            using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                //var output = connection.Query<InvoicePickupRepSummeryDomainView>(@"SELECT CONVERT(DATE , DETOR.DocDate ,102) 'DOCDATE',DETOR.VALFC,DETOR.ConvRate,CONVERT(varchar(50), DETOR.OrgCode)'OrgCode',DETOR.OrgName+CHAR(13)+CHAR(10)+CASE WHEN  DETOR.OrgAddr1 IS NULL OR DETOR.OrgAddr1='' THEN '' ELSE DETOR.OrgAddr1+CHAR(13)+CHAR(10) END
                // +CASE WHEN  DETOR.OrgAddr2 IS NULL OR DETOR.OrgAddr2 ='' THEN '' ELSE DETOR.OrgAddr2 +CHAR(13)+CHAR(10) END	+CASE WHEN  DETOR.OrgCity IS NULL OR DETOR.OrgCity ='' THEN '' ELSE DETOR.OrgCity +CHAR(13)+CHAR(10) END 'BillOrg',
                // T.TransDate,T.PickupChg'PickupChg',T.TotPkgs 'TotPkgs',T.BillWgt 'BillWgt',T.InvoiceType,CONVERT(varchar(50), T.InvoiceNo)'InvoiceNo',T.Pods,CMP.CompName
                //FROM (SELECT TRANS.TransDate,SUM(TRANS.PickupChg )'PickupChg',SUM(TRANS.TotPkgs) 'TotPkgs',SUM(TRANS.BillWgt)'BillWgt','Outbound POD' 'InvoiceType',TRANS.InvNo 'InvoiceNo',COUNT (TRANS.InvNo) 'Pods',
                // TRANS.CMPY,TRANS.AgncyCode 
                //FROM Express.InvoiceTransport TRANS	WHERE   TRANS.CMPY = @CMPY AND TRANS.AgncyCode = @AgncyCode AND TRANS.InvNo = @InvNo AND TRANS.Deleted =0 GROUP BY TRANS.TransDate ,TRANS.InvNo ,TRANS.CMPY ,TRANS.AgncyCode 
                // ) AS T
                // INNER JOIN [FinancePR].[Debt] DETOR ON T.CMPY = DETOR.CMPY AND T.AgncyCode = DETOR.AgncyCode 
                //  AND T.InvoiceNo = DETOR.InvNo 
                //  AND DETOR.Deleted = 0 
                //  AND DETOR.DocId ='INV'
                // INNER JOIN [Project].[Company] CMP ON DETOR.CMPY = CMP.CompID",
                //new { CMPY = _para.CompanyID , AgncyCode = _para.AgencyID , InvNo = _para.InvoiceNo  }).ToList();
                //return output;

                var para = new DynamicParameters();
                para.Add("@CompanyID", _para.CompanyID);
                para.Add("@agencyID", _para.AgencyID);
                para.Add("@invFrom", _para.InvoiceNo);
                para.Add("@invTo", _para.InvoiceNo);

                return (List<InvoicePickupRepSummeryDomainView>)conn.Query<InvoicePickupRepSummeryDomainView>("[Express].[TLM_RepPickupInvSummery]", para, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ResponseMessage PickBillingProcess(InvPickProcessPramDomainView _para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@CMPY", _para.CompanyID);
                    para.Add("@AgncyCode", _para.AgencyID);
                    para.Add("@CustCode", _para.BillOrgCode);
                    para.Add("@UptoDate", _para.Uptodate);
                    para.Add("@UserID", _para.UserID);


                    var responce = (ResponseMessage)conn.Query<ResponseMessage>("[FinanceGL].[TLM_BillingProccess_Pickup]", para, commandTimeout: 1000, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    if (responce.StrMessage == "Successfull")
                    {
                        responce.IsSuccess = true;
                    }
                    else
                    {
                        responce.IsSuccess = false;
                    }
                    return responce;

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

        public ResponseMessage PickInvoiceProcess(InvPickProcessPramDomainView _para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@CMPY", _para.CompanyID);
                    para.Add("@AgncyCode", _para.AgencyID);
                    para.Add("@CustCode", _para.BillOrgCode);
                    para.Add("@UptoDate", _para.Uptodate);
                    para.Add("@DocDate", _para.DocDate);
                    para.Add("@UserID", _para.UserID);


                    var responce = (ResponseMessage)conn.Query<ResponseMessage>("[FinanceGL].[TLM_InvoiceProccess_Pickup]", para, commandTimeout: 1000, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    if (responce.StrMessage == "Successfull")
                    {
                        responce.IsSuccess = true;
                    }
                    else
                    {
                        responce.IsSuccess = false;
                    }
                    return responce;
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
    }
}
