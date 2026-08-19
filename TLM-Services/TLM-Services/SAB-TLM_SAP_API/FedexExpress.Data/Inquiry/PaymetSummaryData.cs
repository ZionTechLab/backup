using Express.Interfaces.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using System.Data.Entity;
using System.Data;
using Dapper;

namespace Express.Data.Inquiry
{
    public class PaymetSummaryData : IPaymnetSummary<PaymetSummaryDomainView>
    {
        public ResponseMessage DeleteDetail(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
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
                    return (List<AgencyDomainViewcs>)conn.Query<AgencyDomainViewcs>("[Project].[TLM_GetUserAgencyList]", para, commandType: CommandType.StoredProcedure).ToList();
                }
                //using (IExpressUnitOfWork<AgencyDomainViewcs> uof = new ExpressUnitOfWork<AgencyDomainViewcs>())
                //{
                //    SqlParameter[] paraList = new SqlParameter[]
                //          {  new SqlParameter("@UserID", UserId) ,new SqlParameter("@ModuleID", ModuleId) ,new SqlParameter("@MenuID",MenueId)};
                //    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetUserAgencyList]", paraList).AsNoTracking()
                //                           select new AgencyDomainViewcs
                //                           {
                //                               AgncyCode = Ag.AgncyCode,
                //                               AgncyName = Ag.AgncyName,
                //                               CompID = Ag.CompID,
                //                               CompName = Ag.CompName,
                //                               GroupID = Ag.GroupID,
                //                               MenuCode = Ag.MenuCode,
                //                               ModuleID = Ag.ModuleID,
                //                               UsmId = Ag.UsmId,
                //                               CountryCode = Ag.CountryCode,
                //                               AgncyID = Ag.AgncyID,
                //                               DefaultY = Ag.DefaultY,

                //                           }).ToList();

                //    return OrgRegistryList;
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

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@CMPY", CMPY);
                    para.Add("@AgncyCode", AgncyCode);                   
                    return (List<ClrInvDocTypesDomainView>)conn.Query<ClrInvDocTypesDomainView>("[Express].[TLM_GetCfgDoctypes]", para, commandType: CommandType.StoredProcedure).ToList();
                }
                //////using (IExpressUnitOfWork<CfgDoctypesResult> uof = new ExpressUnitOfWork<CfgDoctypesResult>())
                //////{
                //////    SqlParameter[] paraList = new SqlParameter[]
                //////          {
                //////              new SqlParameter("@CMPY", CMPY),
                //////              new SqlParameter("@AgncyCode", AgncyCode)
                //////          };
                //////    var CfgDoctypesList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetCfgDoctypes]", paraList)
                //////                           select new ClrInvDocTypesDomainView
                //////                           {
                //////                               Doctype = Ag.Doctype,
                //////                               DoctypeN = Ag.DoctypeN,

                //////                           }).ToList();

                //////    return CfgDoctypesList;
                //////}
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

        public List<PaymetSummaryDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<PaymetSummaryDomainView> GetDetails(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<PaymetSummaryDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@Country", CountryID);
                  
                    return (List<GatewayDomainView>)conn.Query<GatewayDomainView>("[Express].[TLM_GetAllRefLocations]", para, commandType: CommandType.StoredProcedure).Where(GT=>GT.GateWay=="Y").ToList();
                }
                //////using (IExpressUnitOfWork<GatewayDomainView> uof = new ExpressUnitOfWork<GatewayDomainView>())
                //////{
                //////    SqlParameter[] paraList = new SqlParameter[]
                //////          {  new SqlParameter("@Country", CountryID) };
                //////    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllRefLocations]", paraList).AsNoTracking()
                //////                       where Ag.GateWay == "Y"
                //////                       select new GatewayDomainView
                //////                       {
                //////                           Active = Ag.Active,
                //////                           Country = Ag.Country,
                //////                           GateWay = Ag.GateWay,
                //////                           Hub = Ag.Hub,
                //////                           LocationID = Ag.LocationID,
                //////                           LocationName = Ag.LocationName,
                //////                           Remarks = Ag.Remarks,
                //////                           Station = Ag.Station,

                //////                       }).ToList();

                //////    return GatewayList;
                //////}
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

        public IList<PaymetSummaryDomainView> GetInvoiceList(string fDate, string frominvNo, string ToInvNo, string todate, int CMPY, int agency, int groupID, string Gate, string Station, string InvoiceType, bool isInvoiceRange, int payAcc, int IsPayRev)
        {
            try
            {
                //NewPaymetSummaryResult
                using (IExpressUnitOfWork<NewPaymetSummaryResult> uof = new ExpressUnitOfWork<NewPaymetSummaryResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@fromDate", fDate)
                          ,new SqlParameter("@todate", todate)
                          ,new SqlParameter("@cmpy",CMPY),
                          new SqlParameter("@agecy", agency)
                          ,new SqlParameter("@groupID", groupID)
                          ,new SqlParameter("@gateway",Gate),
                          new SqlParameter("@station", Station)
                          ,new SqlParameter("@invoiceType",InvoiceType)
                          ,new SqlParameter("@fromInvoice",frominvNo==""?"0":frominvNo),
                           new SqlParameter("@toInvoice", ToInvNo==""?"0":ToInvNo) ,
                           new SqlParameter("@isRange", isInvoiceRange==true?"Y":"N") ,
                           new SqlParameter("@PayAccount", payAcc ) ,
                            new SqlParameter("@IsPayReverse" , IsPayRev )
                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetPaymetSummaryData]", paraList)
                                           select new PaymetSummaryDomainView
                                           {
                                               CMPY = Ag.CMPY.Value,
                                               AgncyCode = Ag.AgncyCode.Value,
                                               ConsId = Ag.ConsId,
                                               AdminCharges = Ag.AdminCharges.Value,
                                               GroupID = Ag.GroupID,
                                               AgnAWBNo = Ag.AgnAWBNo,
                                               BillTo = Ag.BillTo,
                                               ConvRate = Ag.ConvRate.Value,
                                               CusdecNo = Ag.CusdecNo,
                                               AgncyID = Ag.AgncyID,
                                               CustomVal = Ag.CustomVal.Value,
                                               CustomValCur = Ag.CustomValCur,
                                               Deleted = Ag.Deleted.Value,
                                               Descrip = Ag.Descrip,
                                               Detain = Ag.Detain,
                                               Doctype = Ag.Doctype,
                                               Duty = Ag.Duty.Value,
                                               ExpressID = Ag.ExpressID,
                                               FlightNo = Ag.FlightNo,
                                               GateWayID = Ag.GateWayID,
                                               HSCODE = Ag.HSCODE,
                                               InvDate = Ag.InvDate.Value,
                                               InvMode = Ag.InvMode,
                                               InvNo = Ag.InvNo.Value,
                                               JobNo = Ag.JobNo.Value,
                                               ManifestVal = Ag.ManifestVal.Value,
                                               ManifestValCur = Ag.ManifestValCur,
                                               MAWBNo = Ag.MAWBNo,
                                               MissRoute = Ag.MissRoute,
                                               OrgAddr1 = Ag.OrgAddr1,
                                               OrgAddr2 = Ag.OrgAddr2,

                                               OrgCity = Ag.OrgCity,
                                               OrgCityCode = Ag.OrgCityCode.Value,
                                               OrgCode = Ag.OrgCode.Value,
                                               OrgCountry = Ag.OrgCountry,
                                               OrgName = Ag.OrgName,
                                               OrgPerson = Ag.OrgPerson,
                                               OtherCharges = Ag.OtherCharges.Value,
                                               PayAccount = Ag.PayAccount.Value,
                                               PayDate = Ag.PayDate.Value,
                                               PayMode = Ag.PayMode,
                                               PayNo = Ag.PayNo.Value,
                                               PayRefNo = Ag.PayRefNo,
                                               Remarks = Ag.Remarks,
                                               RouteID = Ag.RouteID,

                                               SalesCode = Ag.SalesCode,
                                               SenRefNotes = Ag.SenRefNotes,
                                               ShipType = Ag.ShipType,
                                               StationID = Ag.StationID,
                                               SVATRegNo = Ag.SVATRegNo,
                                               TransDate = Ag.TransDate.Value,
                                               Vat = Ag.Vat.Value,
                                               VATRegNo = Ag.VATRegNo,
                                               RevsDocNo = Ag.RevsDocNo ,
                                               RevsDate  =Ag.RevsDate,
                                                SAPDocNo = Ag.SAPDocNo

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

        public IList<InvoiceTypeDomainView> GetInvoiceType()
        {
            try
            {
                using (IExpressUnitOfWork<GatInvoiceTypeResult> uof = new ExpressUnitOfWork<GatInvoiceTypeResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  };
                    var InvoiceType = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GeInvoiceType]", paraList)
                                       where Ag.Active == "Y"
                                       select new InvoiceTypeDomainView
                                       {
                                           AgncyCode = Ag.AgncyCode,
                                           Active = Ag.Active,
                                           BillOrgCode = Ag.BillOrgCode,
                                           CMPY = Ag.CMPY,
                                           DocCata = Ag.DocCata,
                                           Doctype = Ag.Doctype,
                                           DoctypeN = Ag.DoctypeN,
                                           ExgRateTarif = Ag.ExgRateTarif,
                                           FuelChart = Ag.FuelChart,
                                           FuelCostChart = Ag.FuelCostChart,
                                           PaidLF = Ag.PaidLF,
                                       }).ToList();
                    return InvoiceType;
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

        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@Country", CountryID);

                    return (List<GatewayDomainView>)conn.Query<GatewayDomainView>("[Express].[TLM_GetAllRefLocations]", para, commandType: CommandType.StoredProcedure).Where(st=>st.Station =="Y").ToList()                        ;
                }
                ////using (IExpressUnitOfWork<GatewayDomainView> uof = new ExpressUnitOfWork<GatewayDomainView>())
                ////{
                ////    SqlParameter[] paraList = new SqlParameter[]
                ////          {  new SqlParameter("@Country", CountryID) };
                ////    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllRefLocations]", paraList)
                ////                       where Ag.Station == "Y"
                ////                       select new GatewayDomainView
                ////                       {
                ////                           Active = Ag.Active,
                ////                           Country = Ag.Country,
                ////                           GateWay = Ag.GateWay,
                ////                           Hub = Ag.Hub,
                ////                           LocationID = Ag.LocationID,
                ////                           LocationName = Ag.LocationName,
                ////                           Remarks = Ag.Remarks,
                ////                           Station = Ag.Station,

                ////                       }).ToList();

                ////    return GatewayList;
                ////}
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

        public ResponseMessage SaveDetails(PaymetSummaryDomainView typePara)
        {
            throw new NotImplementedException();
        }


        public IList<InvDutyClrPayAccountDomainView> GetClrPayAccounts(int companyID)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyClrPayAccountResult> uof = new ExpressUnitOfWork<InvDutyClrPayAccountResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                   {
                       new SqlParameter("@companyID", companyID),

                   };
                    var payaccounts = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetDutyClrPayAccounts]", paraList)
                                       select new InvDutyClrPayAccountDomainView
                                       {
                                           AccountCode = SR.AccountCode,
                                           AccDesc = SR.AccDesc,
                                           DefV = SR.DefV

                                       }).ToList();

                    return payaccounts;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Selling Zone Rate Master", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
