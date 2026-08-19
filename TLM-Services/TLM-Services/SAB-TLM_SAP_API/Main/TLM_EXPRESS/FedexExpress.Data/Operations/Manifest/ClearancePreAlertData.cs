using Express.Interfaces.Common;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Login;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

namespace Express.Data.Operations.Manifest
{
    public class ClearancePreAlertData : IClearancePreAlert<ClearancePreAlertDomainView>
    {
        public ResponseMessage DeleteDetail(ClearancePreAlertDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                  new SqlParameter("@GroupId",typePara.GroupID),
                                  new SqlParameter("@CMPY",typePara.CMPY),
                                  new SqlParameter("@AgncyCode",typePara.AgncyCode),
                                  new SqlParameter("@ExpressCons",typePara.ExpressCons==null?"":typePara.ExpressCons),
                                };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_DeleteClearancePreAlertDataDetail]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,
                                        ReturnValue = SR.ReturnValue

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

        public ResponseMessage EditDetails(ClearancePreAlertDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                    new SqlParameter("@GroupId",typePara.GroupID),
                                  new SqlParameter("@CMPY",typePara.CMPY),
                                  new SqlParameter("@AgncyCode",typePara.AgncyCode),
                                  new SqlParameter("@AgencyId",typePara.AgncyID),
                                  new SqlParameter("@ExpressCons",typePara.ExpressCons==null?"":typePara.ExpressCons),
                                  new SqlParameter("@ConsId",typePara.ConsId==null?"":typePara.ConsId),
                                  new SqlParameter("@TransDate",typePara.TransDate),
                                  new SqlParameter("@VisaRootID",typePara.VisaRootID==null?"":typePara.VisaRootID),
                                  new SqlParameter("@FlightNo",typePara.FlightNo),
                                  new SqlParameter("@AriDate",typePara.AriDate),
                                  new SqlParameter("@DepDate",typePara.DepDate),
                                  new SqlParameter("@AriTime",typePara.AriTime),
                                  new SqlParameter("@DepTime",typePara.DepTime),
                                  new SqlParameter("@Remarks",typePara.Remarks==null?"":typePara.Remarks),
                                  new SqlParameter("@MAWBNo",typePara.MAWBNo),
                                  new SqlParameter("@OrgHubID",typePara.OrgHubID==null?"":typePara.OrgHubID),
                                  new SqlParameter("@DesHubID",typePara.DesHubID==null?"":typePara.DesHubID),
                                  new SqlParameter("@AlNumCode",typePara.AlNumCode==null?"":typePara.AlNumCode),
                                  new SqlParameter("@Currency",typePara.Currency==null?"USD":typePara.Currency),
                                  new SqlParameter("@Delete",typePara.Deleted),
                                  new SqlParameter("@HighValue",typePara.HighValueY),
                                  new SqlParameter("@TransMode",typePara.TransMode ),
                                   new SqlParameter("@ShipType",typePara.ShipType ),
                                  new SqlParameter("@Mode" ,"U")};

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditClearancePreAlertDataDetail]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,
                                        ReturnValue = SR.ReturnValue

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

        public List<ClearancePreAlertDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ClearancePreAlertDomainView> GetDetails(ClearancePreAlertDomainView typePara)
        {
            try
            {
                using (IExpressUnitOfWork<ClearancePreAlertResult> uof = new ExpressUnitOfWork<ClearancePreAlertResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@GroupId", typePara.GroupID) ,new SqlParameter("@CMPY", typePara.CMPY) ,new SqlParameter("@AgncyCode",typePara.AgncyCode)
                           ,new SqlParameter("@TransDate", typePara.TransDate),new SqlParameter("@OrgHubID", typePara.OrgHubID) };
                    var OrgRegistryList = (from OC in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClearancePreAlertDataDetail]", paraList)
                                           select new ClearancePreAlertDomainView
                                           {
                                               CMPY = OC.CMPY,
                                               GroupID = OC.GroupID,
                                               AgncyCode = OC.AgncyCode,
                                               ConsId = OC.ConsId,
                                               MAWBNo = OC.MAWBNo,
                                               TransDate = OC.TransDate.Value,
                                               VisaRootID = OC.VisaRootID,
                                               FlightNo = OC.FlightNo,
                                               AriDate = OC.AriDate.Value,
                                               AriTime = OC.AriTime.Value,
                                               ShipType = OC.ShipType,
                                               DepDate = OC.DepDate.Value,
                                               DepTime = OC.DepTime.Value,
                                               Remarks = OC.Remarks,
                                               Deleted = OC.Deleted.Value,
                                               OrgHubID = OC.OrgHubID,
                                               DesHubID = OC.DesHubID,
                                               Currency = OC.Currency,
                                               AlNumCode = OC.AlNumCode,
                                               HighValueY = OC.HighValueY == "" ? true : false,
                                               TransMode = OC.TransMode,
                                               AgncyID = OC.AgncyID,
                                               ExpressCons=OC.ExpressCons,
                                               //ALActWgt=OC.ALActWgt,
                                               //ALChgWgt=OC.ALChgWgt,
                                               //AlFreightChg=OC.AlFreightChg.Value
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

        public List<ClearancePreAlertDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            try
            {
                using (IExpressUnitOfWork<GatewayResults> uof = new ExpressUnitOfWork<GatewayResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@Country", CountryID) };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetRefLocation]", paraList)
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

        

        public ResponseMessage SaveDetails(ClearancePreAlertDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                  new SqlParameter("@GroupId",typePara.GroupID),
                                  new SqlParameter("@CMPY",typePara.CMPY),
                                  new SqlParameter("@AgncyCode",typePara.AgncyCode),
                                  new SqlParameter("@AgencyId",typePara.AgncyID),
                                  new SqlParameter("@ExpressCons",typePara.ExpressCons==null?"":typePara.ExpressCons),
                                  new SqlParameter("@ConsId",typePara.ConsId==null?"":typePara.ConsId),
                                  new SqlParameter("@TransDate",typePara.TransDate),
                                  new SqlParameter("@VisaRootID",typePara.VisaRootID==null?"":typePara.VisaRootID),
                                  new SqlParameter("@FlightNo",typePara.FlightNo),
                                  new SqlParameter("@AriDate",typePara.AriDate),
                                  new SqlParameter("@DepDate",typePara.DepDate),
                                  new SqlParameter("@AriTime",typePara.AriTime),
                                  new SqlParameter("@DepTime",typePara.DepTime),
                                  new SqlParameter("@Remarks",typePara.Remarks==null?"":typePara.Remarks),
                                  new SqlParameter("@MAWBNo",typePara.MAWBNo),
                                  new SqlParameter("@OrgHubID",typePara.OrgHubID==null?"":typePara.OrgHubID),
                                  new SqlParameter("@DesHubID",typePara.DesHubID==null?"":typePara.DesHubID),
                                  new SqlParameter("@AlNumCode",typePara.AlNumCode==null?"":typePara.AlNumCode),
                                  new SqlParameter("@Currency",typePara.Currency==null?"USD":typePara.Currency),
                                  new SqlParameter("@Delete",typePara.Deleted),
                                  new SqlParameter("@HighValue",typePara.HighValueY),
                                  new SqlParameter("@TransMode",typePara.TransMode ),
                                   new SqlParameter("@ShipType",typePara.ShipType ),
                                  new SqlParameter("@Mode" ,"I")};

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditClearancePreAlertDataDetail]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,
                                        ReturnValue= SR.ReturnValue

                                    }).FirstOrDefault();

                    if (responce.StrMessage == "Successfull")
                    {
                        mMessage.StrMessage = AppMessage.SaveSuccess;
                        mMessage.IsSuccess = true;
                        mMessage.ReturnValue = responce.ReturnValue;
                    }
                    else
                    {
                        mMessage.StrMessage = responce.StrMessage;
                        mMessage.IsSuccess = false;
                        mMessage.ReturnValue = "0";
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
