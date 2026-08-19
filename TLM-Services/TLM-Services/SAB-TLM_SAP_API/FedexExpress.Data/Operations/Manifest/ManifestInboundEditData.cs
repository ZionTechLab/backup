using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.View.Domain.AdminConfiguration;
using Express.Data.Common;

namespace Express.Data.Operations.Manifest
{
    public class ManifestInboundEditData : IManifestInboundEdit<ManifestInboundDomainView>
    {
        public ResponseMessage DeleteDetail(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<CfgDtaxCalDomainView> GetCfgDtaxCal()
        {
            try
            {
                using (IExpressUnitOfWork<CfgDtaxCalResult> uof = new ExpressUnitOfWork<CfgDtaxCalResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          { };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetCfgDtaxCal]", paraList)
                                       select new CfgDtaxCalDomainView
                                       {
                                           CostValueF = Ag.CostValueF,
                                           CostValueP = Ag.CostValueP,
                                           DutyExcempt = Ag.DutyExcempt,
                                           ShipValueFrom = Ag.ShipValueFrom,
                                           ShipValueTo = Ag.ShipValueTo,
                                           ShipValueType = Ag.ShipValueType,
                                           ShipValueTypeCata = Ag.ShipValueTypeCata,

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

        public IList<CurrencyDetailDomainView> GetCurrencyDetail(string para)
        {
            return CommonCommboMaterData.GetCurrencyDetail(para);
        }

        public List<ManifestInboundDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ManifestInboundDomainView> GetDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ManifestInboundDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
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

        public ResponseMessage SaveDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage UpdateManifestInbound(OpsConsAWBDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                  new SqlParameter("@CMPY",typePara.CMPY),
                                  new SqlParameter("@AgncyCode",typePara.AgncyCode),
                                  new SqlParameter("@ConsId",typePara.ConsId),
                                  new SqlParameter("@ExpressID",typePara.ExpressID),
                                  new SqlParameter("@DutyExcemptY",typePara.DutyExcemptY),
                                  new SqlParameter("@DetainedY",typePara.DetainedY),
                                  new SqlParameter("@BillDTaxCreditY",typePara.BillDTaxCreditY),
                                  new SqlParameter("@BillOrgCode",typePara.BillOrgCode),
                                  new SqlParameter("@RecCompany",typePara.RecCompany),
                                  new SqlParameter("@ShipValueType",typePara.ShipValueType),
                                  new SqlParameter("@StationID",typePara.StationID),
                                  new SqlParameter("@RouteID",typePara.RouteID),
                                  new SqlParameter("@ShoOvr",typePara.ShoOvr),
                                  new SqlParameter("@MissRoute",typePara.MissRoute),
                                  new SqlParameter("@CustomVal" , typePara.CustomVal ),
                                  new SqlParameter("@CustomValCur" ,typePara.CustomValCur ),
                                  new SqlParameter("@address1" , typePara.BillOrgAddr1 ),
                                  new SqlParameter("@address2" ,typePara.BillOrgAddr2 ),
                                  new SqlParameter("@city" ,typePara.BillOrgCity ),
                                  new SqlParameter("@varOutMsg","")
                              };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_EditManifestInbound]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,

                                    }).FirstOrDefault();

                    if (responce.StrMessage == "Successfull")
                    {
                        mMessage.StrMessage = AppMessage.SaveSuccess;
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
    }
}
