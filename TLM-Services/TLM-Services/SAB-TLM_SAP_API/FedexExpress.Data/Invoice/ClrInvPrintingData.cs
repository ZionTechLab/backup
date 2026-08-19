
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.View.Domain.Report.Invoice;
using Express.Interfaces.Invoice;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Invoice;
using System.Data.Entity;
namespace Express.Data.Invoice
{
    public class ClrInvPrintingData : IClrInvPrinting
    {
       
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {
                using (IExpressUnitOfWork<UserAgencyDetailResult> uof = new ExpressUnitOfWork<UserAgencyDetailResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@UserID", UserId) ,new SqlParameter("@ModuleID", ModuleId) ,new SqlParameter("@MenuID",MenueId)};
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetUserAgencyList]", paraList)
                                           select new AgencyDomainViewcs
                                           {
                                               AgncyCode = Ag.AgncyCode,
                                               AgncyName = Ag.AgncyName,
                                               CompID = Ag.CompID,
                                               CompName = Ag.CompName,
                                               GroupID = Ag.GroupID,
                                               MenuCode = Ag.MenuCode,
                                               ModuleID = Ag.ModuleID,
                                               UsmId = Ag.UsmId,
                                               CountryCode = Ag.CountryCode,
                                               AgncyID = Ag.AgncyID,
                                               DefaultY = Ag.DefaultY,

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

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            try
            {
                using (IExpressUnitOfWork<CfgDoctypesResult> uof = new ExpressUnitOfWork<CfgDoctypesResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                              new SqlParameter("@CMPY", CMPY),
                              new SqlParameter("@AgncyCode", AgncyCode)
                          };
                    var CfgDoctypesList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetCfgDoctypes]", paraList)
                                       select new ClrInvDocTypesDomainView
                                       {                                          
                                           Doctype = Ag.Doctype,
                                           DoctypeN = Ag.DoctypeN,                                          

                                       }).ToList();

                    return CfgDoctypesList;
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

        //public IList<CfgDtaxDocTypesDomainView> GetCfgDtaxDocTypes()
        //{
        //    try
        //    {
        //        using (IExpressUnitOfWork<CfgDtaxDocTypesResult> uof = new ExpressUnitOfWork<CfgDtaxDocTypesResult>())
        //        {
        //            SqlParameter[] paraList = new SqlParameter[]
        //                  { };
        //            var CfgDtaxDocTypesList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetCfgDtaxDocTypes]", paraList)
        //                                    select new CfgDtaxDocTypesDomainView
        //                                    {
        //                                        BillDtaxChg = Ag.BillDtaxChg,
        //                                        DocType = Ag.DocType,
        //                                        ShipType = Ag.ShipType,
        //                                        ShipValueType = Ag.ShipValueType,                                                

        //                                    }).ToList();

        //            return CfgDtaxDocTypesList;
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

        public IList<TaxInvoiceReportDomainView> GetClearenceDutyPrint(InvoiceDutyClearencePara _param)
        {
            try
            {
                using (IExpressUnitOfWork<InvoiceDutyRepResult> uof = new ExpressUnitOfWork<InvoiceDutyRepResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                               new SqlParameter("@companyID", _param.CompanyID ),
                                new SqlParameter("@agencyCode",_param.AgencyID),
                                 new SqlParameter("@invoiceNo",_param.InvoiceNo ),                                                               
                                   new SqlParameter("@userid",_param.UserID )
                          };
                    var invTaxReport = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_RepInvoiceDutyClearence]", paraList).AsNoTracking()
                                        select new
                                        {
                                            SR.CompanyID,
                                            SR.GroupID,
                                            SR.DocReference,
                                            SR.RefNo1,
                                            SR.RefNo2,
                                            SR.RefNo3,
                                            SR.DocDate,
                                            SR.InvNo,
                                            SR.JobNo,
                                            SR.OrgName,
                                            SR.OrgCountry,
                                            SR.OrgAddr1,
                                            SR.OrgAddr2,
                                            SR.OrgCity,
                                            SR.ChargeCode,
                                            SR.ChargeDesc,
                                            SR.ConvRate,
                                            SR.LC,
                                            SR.FC,
                                            SR.LineAmount,
                                            SR.LineTaxTotal,
                                            SR.LineTotalAmount,
                                            SR.DocType,
                                            SR.Remarks,
                                            SR.CustomVal,
                                            SR.TAX1,
                                            SR.TAX2,
                                            SR.TAX3,
                                            SR.SVATNO,
                                            SR.VATNO,
                                            SR.Detain,
                                            SR.GoodDescp,
                                            SR.VALFC,
                                            SR.OrgContact,
                                            SR.BillOrgCountry,
                                            SR.PayMode,
                                            SR.SenRefNotes,
                                            SR.PrintUser,
                                            SR.ManCurrency,
                                            SR.Sender,
                                            SR.Receiver,
                                            SR.ChargeArabic,
                                            SR.CusdecNo,
                                            SR.CustomsPkgVal,
                                            SR.PayRefNo,
                                            SR.TotPkgs,
                                            SR.TotWgt,
                                            SR.ShipDate,
                                            SR.Paydate,
                                            SR.OrgCode,
                                            SR.FConvRate,
                                            SR.FCAmt,
                                            SR.VALFRAmount

                                        }).ToList().Select(SR => new TaxInvoiceReportDomainView
                                        {
                                            GroupID = SR.GroupID,
                                            CompanyID = SR.CompanyID,
                                            DocReference = SR.DocReference,
                                            RefNo1 = SR.RefNo1,
                                            RefNo2 = SR.RefNo2,
                                            RefNo3 = SR.RefNo3,
                                            DocDate = SR.DocDate,
                                            InvNo = Convert.ToString(SR.InvNo),
                                            JobNo = Convert.ToDecimal(SR.JobNo),
                                            OrgName = SR.OrgName,
                                            OrgCountry = SR.OrgCountry,
                                            OrgAddr1 = SR.OrgAddr1,
                                            OrgAddr2 = SR.OrgAddr2,
                                            OrgCity = SR.OrgCity,
                                            ChargeCode = SR.ChargeCode,
                                            ChargeDesc = SR.ChargeDesc,
                                            ConvRate = SR.ConvRate,
                                            LineAmount = SR.LineAmount,
                                            LC = SR.LC,
                                            FC = SR.FC,
                                            LineTaxTotal = SR.LineTaxTotal,
                                            LineTotalAmount = SR.LineTotalAmount,
                                            DocType = SR.DocType,
                                            Remarks = SR.Remarks,
                                            CustomVal = SR.CustomVal,
                                            TAX1 = SR.TAX1,
                                            TAX2 = SR.TAX2,
                                            TAX3 = SR.TAX3,
                                            SVATNO = SR.SVATNO,
                                            VATNO = SR.VATNO,
                                            Detain = SR.Detain,
                                            GoodDescp = SR.GoodDescp,
                                            VALFC = SR.VALFC,
                                            OrgContact = SR.OrgContact,
                                            BillOrgCountry = SR.BillOrgCountry,
                                            PayMode = SR.PayMode,
                                            SenRefNotes = SR.SenRefNotes,
                                            PrintUser = SR.PrintUser,
                                            ManCurrency = SR.ManCurrency,
                                            Sender = SR.Sender,
                                            Receiver = SR.Receiver,
                                            ChargeArabic = SR.ChargeArabic,
                                            CustomsPkgVal = SR.CustomsPkgVal,
                                            TotWgt = SR.TotWgt,
                                            TotPkgs = SR.TotPkgs,
                                            CusdecNo = SR.CusdecNo,
                                            PayRefNo = SR.PayRefNo,
                                            ShipDate = SR.ShipDate,
                                            Paydate = SR.Paydate,
                                            OrgCode =SR.OrgCode,
                                            FConvRate = SR.FConvRate,
                                            FCAmt = SR.FCAmt,
                                            VALFRAmount = SR.VALFRAmount

                                        }).ToList();


                    return invTaxReport;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Clearence Report", updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            try
            {
                using (IExpressUnitOfWork<GatewayResults> uof = new ExpressUnitOfWork<GatewayResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@Country", CountryID) };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[USP_GetRefLocations]", paraList)
                                       select new GatewayDomainView
                                       {
                                           Active = Ag.Active,
                                           Country = Ag.Country,
                                           GateWay = Ag.GateWay,
                                           Hub = Ag.Hub,
                                           LocationID = Ag.LocationID,
                                           LocationName = Ag.LocationName,
                                           Remarks = Ag.Remarks,
                                           Station = Ag.Station,

                                       }).ToList();

                    return GatewayList;
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

        ////public ClrInvDetorDomainView GetInvoiceAmount(decimal DocNo)
        ////{
        ////    try
        ////    {
        ////        using (IExpressUnitOfWork<DebtResult> uof = new ExpressUnitOfWork<DebtResult>())
        ////        {
        ////            SqlParameter[] paraList = new SqlParameter[]
        ////                  {  new SqlParameter("@DocNo", DocNo) };
        ////            var Debt = (from Ag in uof.Reposotery.GetDataBySp("[FinancePR].[TLM_GetInvoiceAmount]", paraList)
        ////                               select new ClrInvDetorDomainView
        ////                               {
        ////                                   VALRS = Ag.VALRS,

        ////                               }).FirstOrDefault();

        ////            return Debt;
        ////        }
        ////    }
        ////    catch (DbUpdateException updateException)
        ////    {
        ////        var updateBaseException = updateException.GetBaseException() as SqlException;
        ////        throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
        ////    }
        ////    catch (Exception)
        ////    {
        ////        throw;
        ////    }
        ////}

        //public IList<ClrInvDomainView> GetInvoiceDTAX_InvoiceNoRange(string AgncyID, int From, int To)
        //{
        //    try
        //    {
        //        using (IExpressUnitOfWork<ClrInvPrintResult> uof = new ExpressUnitOfWork<ClrInvPrintResult>())
        //        {
        //            SqlParameter[] paraList = new SqlParameter[]
        //                  {
        //                      new SqlParameter("@AgncyID", AgncyID),
        //                      new SqlParameter("@FromInvNo", From),
        //                      new SqlParameter("@ToInvNo", To) };
        //            var InvoiceDTAXList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvoiceDTAX_InvoiceNoRange]", paraList)
        //                                   select new ClrInvDomainView
        //                                   {
        //                                       AgnAWBNo = Ag.AgnAWBNo,
        //                                       AgncyCode = Ag.AgncyCode,
        //                                       AgncyID = Ag.AgncyID,
        //                                       BillTo = Ag.BillTo,
        //                                       CMPY = Ag.CMPY,
        //                                       ConsId = Ag.ConsId,
        //                                       ConvRate = Ag.ConvRate,
        //                                       CusdecNo = Ag.CusdecNo,
        //                                       CustomVal = Ag.CustomVal,
        //                                       CustomValCur = Ag.CustomValCur,
        //                                       Descrip = Ag.Descrip,
        //                                       Detain = Ag.Detain,
        //                                       Doctype = Ag.Doctype,
        //                                       ExpressID = Ag.ExpressID,
        //                                       FlightNo = Ag.FlightNo,
        //                                       GroupID = Ag.GroupID,
        //                                       InvMode = Ag.InvMode,
        //                                       InvNo = Ag.InvNo,
        //                                       ManifestVal = Ag.ManifestVal,
        //                                       ManifestValCur = Ag.ManifestValCur,
        //                                       MAWBNo = Ag.MAWBNo,
        //                                       MissRoute = Ag.MissRoute,
        //                                       OrgAddr1 = Ag.OrgAddr1,
        //                                       OrgAddr2 = Ag.OrgAddr2,
        //                                       OrgCity = Ag.OrgCity,
        //                                       OrgCityCode = Ag.OrgCityCode,
        //                                       OrgCode = Ag.OrgCode,
        //                                       OrgCountry = Ag.OrgCountry,
        //                                       OrgName = Ag.OrgName,
        //                                       OrgPerson = Ag.OrgPerson,
        //                                       PayMode = Ag.PayMode,
        //                                       SalesCode = Ag.SalesCode,
        //                                       SenRefNotes = Ag.SenRefNotes,
        //                                       ShipType = Ag.ShipType,
        //                                       SVATRegNo = Ag.SVATRegNo,
        //                                       TransDate = Ag.TransDate,
        //                                       Remarks = Ag.Remarks,
        //                                       VATRegNo = Ag.VATRegNo,
        //                                       GateWayID = Ag.GateWayID,
        //                                       RouteID = Ag.RouteID,
        //                                       StationID = Ag.StationID,

        //                                   }).ToList();

        //            return InvoiceDTAXList;
        //        }
        //    }
        //    catch (DbUpdateException updateException)
        //    {
        //        var updateBaseException = updateException.GetBaseException() as SqlException;
        //        throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public IList<ClrInvDomainView> GetClearenceInvoices(ClrInvParamDomainView _param)
        {
            try
            {
                using (IExpressUnitOfWork<ClrInvPrintResult> uof = new ExpressUnitOfWork<ClrInvPrintResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                              new SqlParameter("@companyID", _param.CompanyID ),
                                 new SqlParameter("@agencyID", _param.AgencyCode ),
                                    new SqlParameter("@fromDate", _param.FromDate ),
                                     new SqlParameter("@toDate", _param.ToDate ) ,
                                       new SqlParameter("@fromInv", _param.FromInv  ),
                                         new SqlParameter("@toInv", _param.ToInv ) ,
                                          new SqlParameter("@invDocType", _param.InvDocTypes ) ,
                                            new SqlParameter("@invSearchType", _param.SearchType ) ,
                                             new SqlParameter("@awbnumber" , (_param.Awbnumber==null) ?"" : _param.Awbnumber ),
                                              new SqlParameter("@OutstandiY" , (_param.OutstandingY==null) ?"" : _param.OutstandingY )
                                             
                          };
                    var InvoiceDTAXList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClearencePrintInvoice]", paraList).AsNoTracking()
                                           select new ClrInvDomainView
                                       {
                                           AgnAWBNo = Ag.AgnAWBNo,                                          
                                           ConsId = Ag.ConsId,                                          
                                           CusdecNo = Ag.CusdecNo,                                                                                 
                                           Doctype = Ag.Doctype,
                                           ExpressID = Ag.ExpressID,                                          
                                           InvNo = Ag.InvNo,
                                           MAWBNo = Ag.MAWBNo,                                          
                                           OrgCode = Ag.OrgCode,                                          
                                           OrgName = Ag.OrgName,                                         
                                           PayMode = Ag.PayMode,                                          
                                           SenRefNotes = Ag.SenRefNotes,                                         
                                           GateWayID = Ag.GateWayID,
                                           RouteID = Ag.RouteID,
                                           RouteN  =Ag.RouteN ,
                                           StationID = Ag.StationID,
                                           InvAmount =Ag.InvAmount , 
                                           InvBalance =Ag.InvBalance ,
                                           IsSelect = true ,
                                           BillTo = Ag.BillTo 

                                       }).ToList();

                    return InvoiceDTAXList;
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

        public IList<OpsConsMasterDomainView> GetOpsConsMaster(string AgncyID, int CMPY)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsMasterResults> uof = new ExpressUnitOfWork<OpsConsMasterResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@AgncyID", AgncyID),new SqlParameter("@CMPY", CMPY) };
                    var OpsConsMaster = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetOpsConsMasterByAgency]", paraList)
                                         select new OpsConsMasterDomainView
                                         {
                                             AgncyCode = Ag.AgncyCode,
                                             ALActWgt = Ag.ALActWgt,
                                             ALChgWgt = Ag.ALChgWgt,
                                             AlFreightChg = Ag.AlFreightChg,
                                             AlNumCode = Ag.AlNumCode,
                                             AriDate = Ag.AriDate,
                                             AriTime = Ag.AriTime,
                                             CMPY = Ag.CMPY,
                                             ConsId = Ag.ConsId,
                                             Currency = Ag.Currency,
                                             //Deleted = Ag.Deleted,
                                             DepDate = Ag.DepDate,
                                             DepTime = Ag.DepTime,
                                             DesHubID = Ag.DesHubID,
                                             FlightNo = Ag.FlightNo,
                                             GroupID = Ag.GroupID,
                                             HighValueY = Ag.HighValueY,
                                             MAWBNo = Ag.MAWBNo,
                                             OrgHubID = Ag.OrgHubID,
                                             Remarks = Ag.Remarks,
                                             ShipType = Ag.ShipType,
                                             TransDate = Ag.TransDate,
                                             TransMode = Ag.TransMode,
                                             VisaRootID = Ag.VisaRootID,
                                             //ExprssCons
                                             //ExpressCons = Ag.ExpressCons

                                         }).ToList();

                    return OpsConsMaster;
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

        public IList<RefLocationsDomainView> GetRefLocationsStations()
        {
            try
            {
                using (IExpressUnitOfWork<RefLocationsResult> uof = new ExpressUnitOfWork<RefLocationsResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          { };
                    var RefLocationsList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetRefLocationsStations]", paraList)
                                            select new RefLocationsDomainView
                                            {
                                                Active = Ag.Active,
                                                Country = Ag.Country,
                                                GateWay = Ag.GateWay,
                                                Hub = Ag.Hub,
                                                LocationID = Ag.LocationID,
                                                LocationName = Ag.LocationName,
                                                Remarks = Ag.Remarks,
                                                SalesCode = Ag.SalesCode,
                                                Station = Ag.Station,

                                            }).ToList();

                    return RefLocationsList;
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

        public IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY)
        {
            try
            {
                using (IExpressUnitOfWork<RefSvcRootsResult> uof = new ExpressUnitOfWork<RefSvcRootsResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CMPY", CMPY) };
                    var RefSvcRootsList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetRefSvcRoots]", paraList)
                                           select new RefSvcRootsDomainView
                                           {
                                               Active = Ag.Active,
                                               CMPY = Ag.CMPY,
                                               SvcRootID = Ag.SvcRootID,
                                               SvcRootName = Ag.SvcRootName,

                                           }).ToList();

                    return RefSvcRootsList;
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

        public IList<ClrInvManifestDomainView> GetManifestConsDetail(int companyID, int agencyID, string cons)
        {
            try
            {
                using (IExpressUnitOfWork<ClrInvManifestResult> uof = new ExpressUnitOfWork<ClrInvManifestResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@companyID", companyID),
                                new SqlParameter("@agencyID" , agencyID ),
                                  new SqlParameter("@consIDs" , cons )
                          };
                    var RefSvcRootsList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClrInvManifest]", paraList)
                                           select new ClrInvManifestDomainView
                                           {
                                               ConsId = Ag.ConsId,
                                               FlightNo= Ag.FlightNo,
                                               GateWayID = Ag.GateWayID,
                                              

                                           }).ToList();

                    return RefSvcRootsList;
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

        public IList<TaxInvoiceSummeryDomainView> GetClearenceSummaryDutyPrint(InvoiceDutyClearencePara _param)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyRptSummeryResult> uof = new ExpressUnitOfWork<InvDutyRptSummeryResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                               new SqlParameter("@companyID", _param.CompanyID ),
                                new SqlParameter("@agencyID",_param.AgencyID),
                                 new SqlParameter("@invoiceNo",_param.InvoiceNo ),                                   
                                   new SqlParameter("@OutstandiY",_param. OutstandiY) ,
                                  
                          };
                    var invTaxReport = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClearencePrintSummeryInvoice]", paraList).AsNoTracking()
                                        select new
                                        {
                                          SR.CompanyN
                                          ,SR.AgencyN
                                          ,SR.InvNo
                                          ,SR.InvDate                                          
                                           , SR.PayMode 
                                          ,SR.AgnAWBNo
                                          ,SR.OrgName
                                          ,SR.InvAmount
                                          ,SR.InvBalance
                                          ,SR.RouteID

                                        }).ToList().Select(SR => new TaxInvoiceSummeryDomainView
                                        {
                                           CompanyN= SR.CompanyN
                                          ,AgencyN =SR.AgencyN
                                          ,InvNo=SR.InvNo
                                          ,PayMode=SR.PayMode
                                          ,AgnAWBNo = SR.AgnAWBNo
                                          ,OrgName=SR.OrgName
                                          ,InvAmount =SR.InvAmount
                                          ,InvBalance=SR.InvBalance
                                          ,InvDate= SR.InvDate
                                          ,RouteID = SR.RouteID
                                        }).ToList();


                    return invTaxReport;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Clearence Report", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
