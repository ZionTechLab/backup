using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Interfaces.Inquiry;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.Inquiry
{
    public class DutyOutstandingData : IDutyOutstanding
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
            catch (Exception ex)
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
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllRefLocations]", paraList)
                                       where Ag.GateWay == "Y"
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




        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            try
            {
                using (IExpressUnitOfWork<GatewayResults> uof = new ExpressUnitOfWork<GatewayResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@Country", CountryID) };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllRefLocations]", paraList)
                                       where Ag.Station == "Y"
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




        public IList<RefSvcRootsDomainView> GetRoutes(string CountryID)
        {
            try
            {
                using (IExpressUnitOfWork<RefSvcRootsResult> uof = new ExpressUnitOfWork<RefSvcRootsResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@Country", CountryID) };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllRoutes]", paraList)

                                       select new RefSvcRootsDomainView
                                       {
                                           CMPY = Ag.CMPY,
                                           SvcRootID = Ag.SvcRootID,
                                           SvcRootName = Ag.SvcRootName,
                                           Remarks = Ag.Remarks,
                                           Active = Ag.Active,


                                       }).ToList();

                    return GatewayList;
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


        public IList<CourrierDomainView> GetCourrier(string CountryID)
        {
            try
            {
                using (IExpressUnitOfWork<RefEmployeeResult> uof = new ExpressUnitOfWork<RefEmployeeResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@Country", CountryID) };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllCourrier]", paraList)

                                       select new CourrierDomainView
                                       {
                                           EmployeeID = Ag.EmployeeID,
                                           EmployeeName = Ag.EmployeeName,
                                           Remarks = Ag.Remarks,
                                           Active = Ag.Active,


                                       }).ToList();

                    return GatewayList;
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








        public IList<DutyOutstandingViewModel> GetOutstaindingInvoice(DateTime fromDate, DateTime todate, int CMPY, int agency, int groupID, string Gate, string Station, string Route, string Courier, string PayMode, bool DelPackg, bool OutstandingOnly, bool GateWayAll, bool StationAll, bool RouteAll, bool CourierAll, bool AgencyAll)
        {
            try
            {
                using (IExpressUnitOfWork<DutyInvOutstandingResult> uof = new ExpressUnitOfWork<DutyInvOutstandingResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@fromDate", fromDate.Year + "-" + fromDate.Month + "-" + fromDate.Day ) ,
                            new SqlParameter("@todate", todate.Year + "-" + todate.Month + "-" + todate.Day) ,
                            new SqlParameter("@cmpy", CMPY) ,
                            new SqlParameter("@agecy", AgencyAll?0: agency) ,
                            new SqlParameter("@groupID", groupID),
                            new SqlParameter("@PaymentMode", PayMode) ,
                            new SqlParameter("@DeleveredPakg", DelPackg) ,
                            new SqlParameter("@OutStandingOnly", OutstandingOnly),
                            new SqlParameter("@gateway", GateWayAll?"ALL": Gate),
                            new SqlParameter("@station", StationAll?"ALL": Station) ,
                            new SqlParameter("@Route", RouteAll?"ALL": Route) ,
                            new SqlParameter("@Courier", CourierAll?"ALL": Courier) ,





                          };



                    var GatewayList

                        = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetDutyOutstandingData]", paraList)

                           select new DutyOutstandingViewModel
                           {
                               No = Ag.No,
                               GateWayID = Ag.GateWayID,
                               StationID = Ag.StationID,
                               RouteID = Ag.RouteID,
                               Courier = Ag.Courier,
                               InvDate = Ag.InvDate,
                               InvNo = (int)Ag.InvNo,
                               AgnAwbNo = Ag.AgnAwbNo,
                               OrgCode = Ag.OrgCode,
                               OrgName = Ag.OrgName,
                               PayMode = Ag.PayMode,
                               InvAmt = (decimal)Ag.InvAmt,
                               Delivered = Ag.Delivered ? "Yes" : "No",
                               CompName = Ag.CompName



                           }).ToList();

                    return GatewayList;
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
