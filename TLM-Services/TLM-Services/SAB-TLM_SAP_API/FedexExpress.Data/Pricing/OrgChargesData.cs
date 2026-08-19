using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.Pricing
{
   public class OrgChargesData : IOrgCharges<OrgChargesView>
    {
        private string errorRaiseModule = "Org Charges";

        public ResponseMessage DeleteDetail(OrgChargesView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(OrgChargesView typePara)
        {
            {
                ResponseMessage mMessage = new ResponseMessage();

                try
                {

                    using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                    {
                        SqlParameter[] paraList = new SqlParameter[]
                        {

                        new SqlParameter("@Deleted",typePara.Deleted),
                        new SqlParameter("@CMPY",typePara.CMPY),
                        new SqlParameter("@OrgCode",typePara.OrgCode),
                        new SqlParameter("@Amount",typePara.Amount),
                        new SqlParameter("@excemptY",typePara.excemptY),
                        new SqlParameter("@Status","EDIT")

                        };

                        var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TML_OrgChargeCodes]", paraList)
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

        public IList<OrgChargesView> GetAdminChargesGrid(int orgCode)
        {
            try
            {

                using (IExpressUnitOfWork<OrgChargesGetRefChargeCode> uof = new ExpressUnitOfWork<OrgChargesGetRefChargeCode>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                    {

                        new SqlParameter("@OrgCode",orgCode)                        

                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TML_ChargeCodesGrid]", paraList)
                                        select new OrgChargesView
                                        {
                                           OrgCode = SR.OrgCode,
                                           OrgName = SR.OrgName,
                                           Amount = SR.Amount,
                                           excemptY = SR.excemptY,
                                           SalesAreaID = SR.SalesAreaID,
                                           SalesAreaName = SR.SalesAreaName,
                                           ChargeCode = SR.ChargeCode,
                                           OrgAddr1 = SR.OrgAddr1,
                                           OrgAddr2 = SR.OrgAddr2,
                                           OrgCity = SR.OrgCity
                                       
                                           

                                        }).ToList();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorRaiseModule, updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<OrgChargesView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<OrgChargesView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public List<OrgChargesView> GetDetails(OrgChargesView typePara)
        {
            throw new NotImplementedException();
        }
        //***
        public IList<OrgChargesCurrencyView> GetLocalCurrency(string Currency)
        {
            try
            {

                using (IExpressUnitOfWork<OrgChargeGetCurrency> uof = new ExpressUnitOfWork<OrgChargeGetCurrency>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                    {

                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Project].[TML_LocalCurrency]", paraList)
                                        select new OrgChargesCurrencyView
                                        {
                                            Currency = SR.Currency,
                                            CompID = SR.CompID

                                        }).ToList();

                    return customerHead;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorRaiseModule, updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IList<OrgChargesView> GetOrgCharges(string model)
        {
            throw new NotImplementedException();
        }

        public IList<OrgChargeSalseAreaNameView> GetSalesAreaName(int OrgCode)
        {
            try
            {

                using (IExpressUnitOfWork<OrgChargesSalseAreaName> uof = new ExpressUnitOfWork<OrgChargesSalseAreaName>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                    {                        
                         new SqlParameter("@OrgCode",OrgCode)
                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TML_SalesAreaName]", paraList)
                                        select new OrgChargeSalseAreaNameView
                                        {
                                            SalesAreaID = SR.SalesAreaID,
                                            SalesAreaName = SR.SalesAreaName

                                        }).ToList();

                    return customerHead;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorRaiseModule, updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseMessage SaveDetails(OrgChargesView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@Deleted",typePara.Deleted),
                        new SqlParameter("@CMPY",typePara.CMPY),
                        new SqlParameter("@OrgCode",typePara.OrgCode),
                        new SqlParameter("@Amount",typePara.Amount),
                        new SqlParameter("@excemptY",typePara.excemptY),
                        new SqlParameter("@Status","ADD")
                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TML_OrgChargeCodes]", paraList)
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

            }


            return mMessage;
        }

              
    }
}
