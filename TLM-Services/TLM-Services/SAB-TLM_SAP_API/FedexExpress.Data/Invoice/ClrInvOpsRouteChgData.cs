
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Operations.Manifest;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Interfaces.Invoice;
using Express.Domain.Message;
using Express.View.Domain.Invoice;

namespace Express.Data.Invoice
{
    public class ClrInvOpsRouteChgData : IClrInvOpsRouteChg
    {
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
        public ResponseMessage UpdateDutyInvoiceRoute(ClrInvRoutePopParam _param)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@companyID",_param.CompanyID ),
                        new SqlParameter("@agencyID",_param.AgencyCode),
                        new SqlParameter("@invNumber",_param.InvoiceNo ),
                        new SqlParameter("@routID",_param.RouteID ),
                        new SqlParameter("@expressID",_param.ExpressID),
                        new SqlParameter("@userID", _param.UserID )

                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_UpdateInvRoutes]", paraList)
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
