using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;
using Express.Data.FedexExpressEF;
using Express.Custom.ExcepHandle.DataHadling;
using System.Data.SqlClient;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.Entity.Infrastructure;
using Express.View.Domain.Invoice;

namespace Express.Data.Operations.Manifest
{
    public class ManifestInboundInvPopupData : IManifestInboundInvPopup
    {
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

        public ResponseMessage ProcessCostInvoice(ManifestInbLVProPramDomainView _para)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@varConsID",_para.ConsIds),
                         new SqlParameter("@company",_para.CompanyID),
                          new SqlParameter("@agency",_para.AgencyID),
                           new SqlParameter("@userID",_para.UserID),
                            new SqlParameter("@bayanNo",_para.BayanNo ),
                              new SqlParameter("@paymentRef",_para.PaymentRef),
                               new SqlParameter("@payAccId",_para.PaymentAcc),
                                new SqlParameter("@payDate",_para.PaymentDate) ,
                                 new SqlParameter("@billto" ,(_para.BillTo ==null)?"":_para.BillTo)
                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_DutyBulkLVProcess]", paraList)
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
