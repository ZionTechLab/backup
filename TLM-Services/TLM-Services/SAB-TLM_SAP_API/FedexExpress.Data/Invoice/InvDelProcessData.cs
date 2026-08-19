using Express.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using System.Data;
using System.Data.SqlClient;
using Express.Data.FedexExpressEF;
using FedexExpress.View.Domain.Pricing;
using Dapper;
using Express.View.Domain.Invoice;
using Express.Domain.Message;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.View.Domain.Report.Invoice;

namespace Express.Data.Invoice
{
    public class InvDelProcessData : IInvDelInvoiceProcess
    {
        public ResponseMessage DelBillingProcess(InvDelProcessPramDomainView _para)
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


                    var responce= (ResponseMessage)conn.Query<ResponseMessage>("[FinanceGL].[TLM_BillingProccess_POD]", para, commandTimeout: 1000, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    if( responce.StrMessage == "Successfull")
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

        public ResponseMessage DelInvoiceProcess(InvDelProcessPramDomainView _para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@CMPY", _para.CompanyID);
                    para.Add("@AgncyCode", _para.AgencyID);
                    para.Add("@CustCode", _para.BillOrgCode);
                    para.Add("@UptoDate", _para.Uptodate );
                    para.Add("@DocDate", _para.DocDate);
                    para.Add("@UserID", _para.UserID );


                    var responce = (ResponseMessage)conn.Query<ResponseMessage>("[FinanceGL].[TLM_InvoiceProccess_POD]", para, commandTimeout: 1000, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
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
        }

        public InvDelProcessDomainView GetPodInvoiceDetail(InvDelProcessPramDomainView _para)
        {
            InvDelProcessDomainView _InvDet = new InvDelProcessDomainView();
            try
            {
                using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
                {

                    string docSql = @"SELECT 
                              [Doctype]  DocType
                              ,[DoctypeN]DocTypeN
                              ,[DocCata] DocTypeCat     
                              ,[BillOrgCode] BillOrgCode
                              ,[ExgRateTarif] ExgRateTarrif     
                          FROM [Express].[CfgDoctypes](NOLOCK)
                          WHERE CMPY =@CMPY  AND AgncyCode =@AgencyCode AND Active ='Y' AND [DocCata]='DEL' ";
                   var docTypesDetail = (InvDelDocTypes)db.Query<InvDelDocTypes>(docSql, new
                    {
                        CMPY = _para.CompanyID,
                        AgencyCode = _para.AgencyID,

                    }).FirstOrDefault();

                    if(docTypesDetail==null)
                    {
                        return null;
                    }
                

                    string query = @"SELECT count(1) InvoiceAWBCount ,
                                     SUM( BillWgt) InvoiceBillWgt
                                      FROM
                                    [Express].[InvoiceTransport](NOLOCK)
                                    WHERE CMPY =@Cmpy AND AgncyCode =@AgncyCode AND InvNo = @InvNo 
                                    AND DocType =@docType ";
                    var invtrans = (InvDelProcessDomainView)db.Query<InvDelProcessDomainView>
                        (query, new
                        {
                            Cmpy = _para.CompanyID ,
                            AgncyCode = _para.AgencyID,
                            InvNo = _para.InvoiceNo ,
                            docType=docTypesDetail.DocType.Trim(),
                }).FirstOrDefault();

                    if(invtrans!=null )
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
                    var invtdbt = (InvDelProcessDomainView)db.Query<InvDelProcessDomainView>
                        (query2, new
                        {
                            Cmpy = _para.CompanyID,
                            AgncyCode = _para.AgencyID,
                            InvNo = _para.InvoiceNo,
                              docType = docTypesDetail.DocType.Trim(),
                        }).FirstOrDefault();

                     if(invtdbt !=null)
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

        public InvDelProcessDomainView GetPodSummeryDetail(InvDelProcessPramDomainView _para)
        {
            InvDelDocTypes docTypesDetail = null;
            InvDelProcessDomainView notDilivered = null;
            InvDelProcessDomainView notBilled = null;
            InvDelProcessDomainView notInvoiced = null;
            InvDelProcessDomainView extTarrif = null;
            InvDutyExtrateDomainView exchageRate = null;
            InvDelProcessDomainView billTo = null;
            InvDelProcessDomainView returnValue = new InvDelProcessDomainView();
            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT 
                              [Doctype]  DocType
                              ,[DoctypeN]DocTypeN
                              ,[DocCata] DocTypeCat     
                              ,[BillOrgCode] BillOrgCode
                              ,[ExgRateTarif] ExgRateTarrif     
                          FROM [Express].[CfgDoctypes]
                          WHERE CMPY =@CMPY  AND AgncyCode =@AgencyCode AND Active ='Y' AND [DocCata]='DEL' ";
             docTypesDetail =   (InvDelDocTypes)db.Query<InvDelDocTypes>(query, new
                {
                    CMPY = _para.CompanyID ,
                    AgencyCode = _para.AgencyID ,

                } ).FirstOrDefault();
            }

            if(docTypesDetail ==null)
            {
                return null;
            }
            returnValue.DocType = docTypesDetail.DocType.Trim();
            returnValue.BillOrgCode = docTypesDetail.BillOrgCode;

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
                billTo = (InvDelProcessDomainView)db.Query<InvDelProcessDomainView>(query, new
                {
                    billOrgCode = docTypesDetail.BillOrgCode,

                },
                commandTimeout: 600).FirstOrDefault();
            }

            if(billTo==null)
            {
                return null;
            }           
            returnValue.BillParty = billTo.BillParty;
            returnValue.BillOrgName = billTo.BillOrgName;
            returnValue.BillOrgAdd1 = billTo.BillOrgAdd1;
            returnValue.BillOrgAdd2 = billTo.BillOrgAdd2;
            returnValue.BillOrgCity = billTo.BillOrgCity;
            returnValue.BillOrgCountry = billTo.BillOrgCountry;

            //// not delivered invoice

            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT  count(1) CountNonDelAwb ,isnull( sum( TotWgt),0) CountNonDelWgt  
                              FROM [Express].[OpsConsAWB] (NOLOCK)
                              WHERE [CMPY] =@CMPY AND  [AgncyCode] =@AgncyCode  
                              AND Deleted =0 AND   [ShipType]='I' 
                              AND [BillTransChg]='S' AND [BillTransChgY]='' AND PodYN = '' AND DeliverY=''
                              AND CONVERT(Date ,TransDate,102) <=CONVERT(Date , @UptoDate,102) AND ExpressMpsNo =0";
                notDilivered = (InvDelProcessDomainView)db.Query<InvDelProcessDomainView>(query, new
                {
                    CMPY = _para.CompanyID,
                    AgncyCode = _para.AgencyID,
                    UptoDate = _para.Uptodate 

                }).FirstOrDefault();
            }

            if(notDilivered !=null)
            {
                returnValue.CountNonDelAwb = notDilivered.CountNonDelAwb;
                returnValue.CountNonDelWgt = notDilivered.CountNonDelWgt;
            }

            /// not billed
            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT  count(1) CountPendingAwb ,isnull( sum( TotWgt),0) CountPendingWgt  
                                FROM [Express].[OpsConsAWB] (NOLOCK)
                                WHERE [CMPY] =@CMPY AND  [AgncyCode] =@AgncyCode  
                                AND Deleted =0 AND   [ShipType]='I' 
                                AND [BillTransChg]='S' AND [BillTransChgY]='' AND PodYN = 'Y' AND DeliverY ='Y'
                                AND InvNoTransChg=0
                                AND CONVERT(Date ,LastScanDate,102) <=CONVERT(Date ,@UptoDate,102) AND ExpressMpsNo =0";
                notBilled  = (InvDelProcessDomainView)db.Query<InvDelProcessDomainView>(query, new
                {
                    CMPY = _para.CompanyID,
                    AgncyCode = _para.AgencyID,
                    UptoDate = _para.Uptodate

                }).FirstOrDefault();
            }

            if (notBilled != null)
            {
                returnValue.CountPendingAwb = notBilled.CountPendingAwb;
                returnValue.CountPendingWgt = notBilled.CountPendingWgt ;
            }

            /// not invoiced
            /// 


            using (IDbConnection db = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                string query = @"SELECT count(1) CountBillAwb , ISNULL( SUM( BillWgt),0)CountBillWgt 
                            ,ISNULL( SUM( [DeliveryChg] ),0) CountBillAmt
                            FROM [Express].[InvoiceTransport](NOLOCK)
                            WHERE CMPY =@CMPY and AgncyCode =@AgncyCode
                            AND Deleted =0 AND ShipType ='I' 
                            AND BillTo ='S' AND DocType = @DocType 
                            AND InvNo =0 
                            AND ExpressID in ( SELECT  ExpressID   
                                    FROM [Express].[OpsConsAWB] (NOLOCK)
                                    WHERE [CMPY] =@CMPY AND  [AgncyCode] =@AgncyCode  
                                    AND Deleted =0 AND   [ShipType]='I' 
                                    AND [BillTransChg]='S' AND [BillTransChgY]='Y' AND PodYN = 'Y' AND DeliverY ='Y' AND InvNoTransChg =0
                                    AND CONVERT(Date , LastScanDate ,102) <=CONVERT(Date, @UptoDate ,102)  AND ExpressMpsNo =0)";
                notInvoiced = (InvDelProcessDomainView)db.Query<InvDelProcessDomainView>(query, new
                {
                    CMPY = _para.CompanyID,
                    AgncyCode = _para.AgencyID,
                    DocType= docTypesDetail.DocType,
                    UptoDate = _para.Uptodate

                }).FirstOrDefault();
            }

            if (notInvoiced != null)
            {
                returnValue.CountBillAwb = notInvoiced.CountBillAwb ;
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
                                WHERE CMPY =@CMPY AND  Active ='Y' AND DocType=@DocType" ;
                extTarrif = (InvDelProcessDomainView)db.Query<InvDelProcessDomainView>(query, new
                {
                    CMPY = _para.CompanyID,                    
                    DocType = docTypesDetail.DocType,
                  

                }).FirstOrDefault();
            }

            if (extTarrif ==null )
            {
                return null;
            }
            returnValue.SellCurrencyFC = extTarrif.SellCurrencyFC;
            returnValue.SellExgRateTarif = extTarrif.SellExgRateTarif;


            using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var para = new DynamicParameters();
                para.Add("@dateTo", _para.Uptodate );
                para.Add("@companyID", _para.CompanyID );
                para.Add("@currency", extTarrif.SellCurrencyFC);
                para.Add("@TarrifNo", extTarrif.SellExgRateTarif);

                exchageRate =(InvDutyExtrateDomainView)conn.Query<InvDutyExtrateDomainView>("[Util].[Finance_GetFrtExchangeRate]", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            if(exchageRate ==null)
            {
                return null;
            }

            returnValue.ExtRate = exchageRate.ExgRate;
            returnValue.SellCurrencyLC = exchageRate.BaseCurrency;


          

            return returnValue;
        }

        public IList<InvDellInvoiceReportDomainView> PreviewData(DateTime TransDate, int AgencyCode)
        {
            using (IDbConnection connection = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var output = connection.Query<InvDellInvoiceReportDomainView>(@"SELECT AgnAWBNo,TransDate,ORGCOUNTRY,DESCOUNTRY,TotWgt FROM Express.OpsConsAWB
               WHERE Deleted=0  and  ShipType='I'  and DeliverY='' and  BillTransChg='S' and  BillTransChgY=''
               and ExpressMpsNo = 0 and TransDate <= @TransDate and AgncyCode = @AgncyCode",
                new { TransDate = TransDate, AgncyCode = AgencyCode }).ToList();
                return output;
            }
        }

        public IList<InvoiceDeliveryDetailDomainView> PreviewData_InvoiceDeliveryDetail(int InvoiceNo, int CMPY, int AgencyCode)
        {
            using (IDbConnection connection = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var output = connection.Query<InvoiceDeliveryDetailDomainView>(@"DECLARE @CompanyName varchar(150)
                SELECT @CompanyName=CompName FROM [Project].[Company] WHERE CompID =@CMPY
                SELECT ops.LastScanDate  'PODDate',ops.AgnAWBNo 'AWBNO' ,@CompanyName 'CompanyName',ops.TotWgt,Convert(varchar(30), @InvNoTransChg) 'InvoiceNo',
				ops.BillTransAcNo 'SenderACNo',(CASE WHEN ops.SenCompany=''  THEN ops.SenName ELSE ops.SenCompany END) AS 'SenderCompany',inv.DeliveryChg 'AmountFC'
                FROM Express.OpsConsAWB AS ops INNER JOIN Express.InvoiceTransport AS inv ON ops.AgnAWBNo = inv.AgnAWBNo
				WHERE ops.CMPY =@CMPY AND ops.AgncyCode =@AgncyCode AND ops.ShipType = 'I'AND ops.PodYN ='Y' AND ops.ExpressMpsNo=0
                AND ops.InvNoTransChg  =CONVERT(numeric(18,0) ,@InvNoTransChg)",
               new { CMPY = CMPY, AgncyCode = AgencyCode, InvNoTransChg = InvoiceNo }).ToList();
                return output;
            }
        }

        public IList<InvoiceDeliverySummaryDomainView> PreviewData_InvoiceSummery(int InvoiceNo, int CMPY, int AgencyCode)
        {
            using (IDbConnection connection = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var output = connection.Query<InvoiceDeliverySummaryDomainView>(@"SELECT 
                    CONVERT(DATE , DETOR.DocDate ,102) 'DOCDATE',DETOR.VALFC,DETOR.ConvRate,CONVERT(varchar(50), DETOR.OrgCode)'OrgCode',DETOR.OrgName+CHAR(13)+CHAR(10)+CASE WHEN  DETOR.OrgAddr1 IS NULL OR DETOR.OrgAddr1='' THEN '' ELSE DETOR.OrgAddr1+CHAR(13)+CHAR(10) END
	                +CASE WHEN  DETOR.OrgAddr2 IS NULL OR DETOR.OrgAddr2 ='' THEN '' ELSE DETOR.OrgAddr2 +CHAR(13)+CHAR(10) END	+CASE WHEN  DETOR.OrgCity IS NULL OR DETOR.OrgCity ='' THEN '' ELSE DETOR.OrgCity +CHAR(13)+CHAR(10) END 'BillOrg',
	                T.TransDate,T.DeliveryChg'DeliveryChg',T.TotPkgs 'TotPkgs',T.BillWgt 'BillWgt',CONVERT(decimal(18,2), T.DeliveryCost )'DeliveryCost',T.InvoiceType,CONVERT(varchar(50), T.InvoiceNo)'InvoiceNo',T.Pods,CMP.CompName
                FROM (SELECT TRANS.TransDate,SUM(TRANS.DeliveryChg )'DeliveryChg',SUM(TRANS.TotPkgs) 'TotPkgs',SUM(TRANS.BillWgt)'BillWgt','4' 'DeliveryCost','Inbound POD' 'InvoiceType',TRANS.InvNo 'InvoiceNo',COUNT (TRANS.InvNo) 'Pods',
	                TRANS.CMPY,TRANS.AgncyCode 
                FROM Express.InvoiceTransport TRANS	WHERE   TRANS.CMPY = @CMPY AND TRANS.AgncyCode = @AgncyCode	AND TRANS.InvNo = @InvNo AND TRANS.Deleted =0 GROUP BY TRANS.TransDate ,TRANS.InvNo ,TRANS.CMPY ,TRANS.AgncyCode 
	                ) AS T
	                INNER JOIN [FinancePR].[Debt] DETOR ON T.CMPY = DETOR.CMPY AND T.AgncyCode = DETOR.AgncyCode 
		                AND T.InvoiceNo = DETOR.InvNo 
		                AND DETOR.Deleted = 0 
		                AND DETOR.DocId ='INV'
	                INNER JOIN [Project].[Company] CMP ON DETOR.CMPY = CMP.CompID",
                new { CMPY = CMPY, AgncyCode = AgencyCode, InvNo = InvoiceNo }).ToList();
                return output;
                
            }
        }

        public IList<InvDellInvoiceReportDomainView> PreviewData_NotInvoiced(DateTime LastScanDate, int AgencyCode)
        {
            using (IDbConnection connection = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var output = connection.Query<InvDellInvoiceReportDomainView>(@"SELECT 
                                        ops.AgnAWBNo,
                                        ops.TransDate,
                                        ops.LastScanDate,
                                        ops.ORGCOUNTRY,
                                        ops.DESCOUNTRY,
                                        ops.TotWgt,
                                        inv.DeliveryChg ,
                                        ops.SenName,
										ops.BillTransAcNo
                                FROM Express.OpsConsAWB AS ops 
                                INNER JOIN Express.InvoiceTransport  AS inv ON ops.AgnAWBNo = inv.AgnAWBNo AND ops.AgncyCode =inv.AgncyCode
                                                AND ops.[ExpressID] = inv.[ExpressID]
                                                WHERE ops.Deleted=0  and  ops.ShipType='I' and ops.DeliverY='Y' and  ops.BillTransChg='S' and   ops.InvNoTransChg = 0
                                                and ops.ExpressMpsNo = 0 and ops.LastScanDate <= @LastScanDate and ops.AgncyCode = @AgncyCode",
                new { LastScanDate = LastScanDate, AgncyCode = AgencyCode }).ToList();
                return output;
            }
        }

        public IList<InvDellInvoiceReportDomainView> PreviewData_PendingDeliverd(DateTime LastScanDate, int AgencyCode)
        {
            using (IDbConnection connection = new SqlConnection(DapperConnetion.GetConnetion()))
            {
                var output = connection.Query<InvDellInvoiceReportDomainView>(@"SELECT AgnAWBNo,
                                                                TransDate,
                                                                LastScanDate,
                                                                ORGCOUNTRY,
                                                                DESCOUNTRY,
                                                                TotWgt 
                                                                FROM Express.OpsConsAWB
                WHERE Deleted=0  and  ShipType='I' and DeliverY='Y' and  BillTransChg='S' and  BillTransChgY=''
                and ExpressMpsNo = 0 and LastScanDate <= @LastScanDate and AgncyCode = @AgncyCode",
                new { LastScanDate = LastScanDate, AgncyCode = AgencyCode }).ToList();
                return output;
            }
        }
    }
}
