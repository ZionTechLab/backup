using Express.Interfaces.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Inquiry;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.AdminConfiguration;
using Express.Data.Common;
using Express.View.Domain.Login;

namespace Express.Data.Inquiry
{
    public class ShipmentHeldData : IShipmentHeld
    {
        private string errorModule = "Inquiry Shipment Held";

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

        public IList<GatewaysDomainView> GetGateways(int companyID)
        {
            return RefData.GetGateways(companyID);
        }

        public IList<InqShipmetHeldDomainView> GetShipmetHeld(InqShipmentHeldPara para)
        {
            try
            {
                using (IExpressUnitOfWork<InqShipmentHeldResult> uof = new ExpressUnitOfWork<InqShipmentHeldResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                       {
                         new SqlParameter("@companyId", para.CompanyID ),
                          new SqlParameter("@agencyId" ,para.AgencyId),
                           new SqlParameter("@uptoDate" ,para.Uptodate  ),
                           new SqlParameter ("@stationID" , para.StationID  ),
                           new SqlParameter("@gatewayId",para.GatewayID ),



                        };

                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_InqShipmentHeld]", paraList)
                                        select new InqShipmetHeldDomainView
                                        {
                                           Gateway = SR.Gateway , 
                                           Day1 = SR.Day1 ,
                                           Day2 = SR.Day2 ,
                                           Day3 = SR.Day3 , 
                                           Day4 = SR.Day4 ,
                                           Day5 = SR.Day5 ,
                                           Day6 = SR.Day6 ,
                                           Day7 = SR.Day7 ,
                                           MoreThanDay10 = SR.MoreThanDay10 ,
                                           LineTotal = SR.LineTotal 

                                        }).ToList();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<StationDomainView> GetStations(int companyID)
        {
            return RefData.GetStation(companyID);
        }
    }
}
