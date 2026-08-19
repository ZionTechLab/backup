

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.AdminConfiguration;
using Express.Data.Common;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Interfaces.Pricing;
using Express.View.Domain.Pricing;
using Express.View.Domain.Operations.Manifest;

namespace Express.Data.Pricing
{
    public class ExchangeRatesDate : IExchangeRatesDataProvider<ExchangeRatesView>
    {
        private string errorRaiseModule = "Exchange Rate";


        public ResponseMessage DeleteDetail(ExchangeRatesView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SaveDetails(ExchangeRatesView typePara)
        {

          
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@ExgRateTarif",typePara.ExgRateTarif),
                        new SqlParameter("@Currency",typePara.Currency),
                        new SqlParameter("@EffectDate",typePara.EffectDate),
                        new SqlParameter("@ExgRate",typePara.ExgRate),
                        new SqlParameter("@Remarks",typePara.Remarks),
                        new SqlParameter("@UserID",typePara.UserID),
                        new SqlParameter("@Status" ,"ADD")
                    };                  
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Finance].[USP_AddEditExgRates]", paraList)
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

        public ResponseMessage EditDetails(ExchangeRatesView typePara)
        {
            
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@ExgRateTarif",typePara.ExgRateTarif),
                        new SqlParameter("@Currency",typePara.Currency),
                        new SqlParameter("@EffectDate",typePara.EffectDate),
                        new SqlParameter("@ExgRate",typePara.ExgRate),
                        new SqlParameter("@Remarks",typePara.Remarks),
                        new SqlParameter("@UserID",typePara.UserID),
                        new SqlParameter("@Status" ,"EDIT")

                    };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Finance].[USP_AddEditExgRates]", paraList)
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

        public IList<CurrencyDetailDomainView> GetCurrencyDetail(string para)
        {
            return CommonCommboMaterData.GetCurrencyDetail(para);
        }

        public List<ExchangeRatesView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ExchangeRatesView> GetDetails(ExchangeRatesView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ExchangeRatesView> GetDetails(string code)
        {

            return null;
            //try
            //{
            //    int ExgRateTarifId = int.Parse(code);
            //    using (IExpressUnitOfWork<RatesExchange> uof = new ExpressUnitOfWork<RatesExchange>())
            //    {
            //        return (from RF in uof.Reposotery.GetDetails()
            //                where RF.ExgRateTarif == ExgRateTarifId
            //                select new
            //                {
            //                    RF.CMPY,
            //                    RF.ExgRateTarif,
            //                    RF.ExgRate,
            //                    RF.EffectDate,
            //                    RF.Remarks

            //                }).ToList().Select(R => new ExchangeRatesView
            //                {
            //                    //CMPY = R.CMPY,
            //                    ExgRateTarif = R.ExgRateTarif,
            //                    ExgRate = R.ExgRate,
            //                    EffectDate = R.EffectDate,
            //                    Remarks = R.Remarks

            //                }).ToList();
            //    }
            //}
            //catch (DbUpdateException updateException)
            //{
            //    var updateBaseException = updateException.GetBaseException() as SqlException;
            //    throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Rates Fuel Shg", updateException);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public IList<ExchaneRateTarifTypeView> GetExchangeRateTypes(string model)
        {
            return CommonCommboMaterData.GetExchangeRateType(model);
        }

        public IList<ExchangeRatesView> GetExchangeRate(int tarrifNo,  string cCurrency)
        {
            try
            {

                using (IExpressUnitOfWork<ExchangeRateValueResult> uof = new ExpressUnitOfWork<ExchangeRateValueResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {  new SqlParameter("@tarrifNo", tarrifNo),
                            new SqlParameter("@cvtCurr" ,cCurrency),                          

                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Finance].[USP_GetRefExgRates]", paraList)
                                        select new ExchangeRatesView
                                        {
                                           Currency = SR.Currency ,
                                           EffectDate = SR.EffectDate ,
                                           ExgRate =SR.ExgRate ,
                                           ExgRateTarif = SR.ExgRateTarif ,
                                           Remarks =SR.Remarks 

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

        public ManifestClearenceDomainView GetManifestClearenceConf(int companyID)
        {
            try
            {

                using (IExpressUnitOfWork<ManifestClearenceResult> uof = new ExpressUnitOfWork<ManifestClearenceResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {
                           new SqlParameter("@CompanyID", companyID  ),
                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClearenceConfig]", paraList)
                                        select new ManifestClearenceDomainView
                                        {
                                            ClearanceCurrency = SR.ClearanceCurrency,
                                            ClearanceExgRatTarif = SR.ClearanceExgRatTarif,
                                            ClearanceValue = SR.ClearanceValue


                                        }).FirstOrDefault();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "", updateException);
            }
            catch (Exception ex)
            {
                //throw;
                return null;
            }
        }
    }
}
