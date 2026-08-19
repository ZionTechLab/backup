using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.AdminConfiguration;
using Express.Data.Common;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

namespace Express.Data.Operations.Manifest
{
    public class WebManifestPopUpData : IWebManifestPopups
    {
        public IList<ClearenceStatusDomainView> GetClearenceStatus()
        {
            return ConfigData.GetClearenceStatus();
        }

        public IList<ClearenceTypeDomainView> GetClearenceType()
        {
            return ConfigData.GetClearenceType();
        }

        public IList<ConsoleTypeDomainView> GetConsoleTypes()
        {
            return RefData.GetConsoleType("Y");
        }

        public IList<RouteDomainView> GetRoute(int companyID)
        {
            return RefData.GetRoots(companyID);
        }

        public IList<StationDomainView> GetStations(int companyID)
        {
            return RefData.GetStation(companyID);
        }


        public IList<CurrencyDetailDomainView> GetCurrencyDetail(string para)
        {
            return CommonCommboMaterData.GetCurrencyDetail(para);
        }


        public ResponseMessage UpdateAwbs(WebManiPopParamDomainView _para)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@cmpyID",_para.CompanyID ),
                         new SqlParameter("@agencyID",_para.AgencyID),
                          new SqlParameter("@agnTrackNo",_para.AgnTrackNum),
                           new SqlParameter("@shipType",_para.ShipType ),
                             new SqlParameter("@remarks",_para.Remarks),

                               new SqlParameter("@DutythreshLC",_para.DutyTreshold ),
                                new SqlParameter("@ClearenceStatus",_para.ClearenceStatus ),
                                 new SqlParameter("@BillOrg", _para.OrgCode ),
                                  new SqlParameter("@BillOrgName",_para.OrgName),
                                   new SqlParameter("@BillOrgAdd1",(_para.OrgAdd1 ==null )?"": _para.OrgAdd1 ),
                                    new SqlParameter("@BillOrgAdd2",(_para.OrgAdd2 ==null )?"": _para.OrgAdd2 ),
                                     new SqlParameter("@BillOrgCity",(_para.OrgCity==null)?"": _para.OrgCity ),
                                      new SqlParameter("@StationID", ( _para.StationID ==null) ? "" : _para.StationID),
                                       new SqlParameter("@RoutID",(_para.RouteID ==null ) ? _para.RouteID:_para.RouteID ),
                                        new SqlParameter("@ClearType",_para.ClearenceType),
                                         new SqlParameter("@TotDutyValue",_para.DutyValue), 
                                          new SqlParameter("@IsCredit" ,_para.IsCredit),
                                            new SqlParameter("@DutyExcemptY" , _para.DustyExempt) ,
                                              new SqlParameter("@ConsolType" , _para.ConsolType )
                                           /// consol


                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_UpdatePreclearenceAwb]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,
                                        ReturnValue = SR.ReturnValue
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
                        mMessage.ReturnValue = responce.ReturnValue;
                        mMessage.IsSuccess = false;
                    }
                }

            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Rates Fuel Shg", updateException);
            }
            catch (Exception)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;
            }



            return mMessage;
        }
    }
}
