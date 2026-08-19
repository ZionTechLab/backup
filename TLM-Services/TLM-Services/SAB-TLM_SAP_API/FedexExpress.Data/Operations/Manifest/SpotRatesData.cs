using Express.Interfaces.Pricing;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.Data.FedexExpressEF;
using System.Data.SqlClient;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

namespace Express.Data.Pricing
{
    public class SpotRatesData : ISpotRates<SpotRatesDomainView>
    {
        private string errorRaiseModule = "Spot Rate";
        public ResponseMessage DeleteDetail(SpotRatesDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                 new SqlParameter("@Deleted",1),
                                  new SqlParameter("@ExpressID",typePara.ExpressID),
                                  new SqlParameter("@AgnAWBNo",typePara.AgnAWBNo),
                                  new SqlParameter("@TransDate",typePara.TransDate),
                                  new SqlParameter("@Remarks",typePara.Remarks==null?"":typePara.Remarks),
                                  new SqlParameter("@EnterDate",typePara.EnterDate),
                                  new SqlParameter("@Rate",typePara.Rate),
                                  new SqlParameter("@USM_ID",typePara.USM_ID),
                                  new SqlParameter("@USM_DATE",typePara.USM_DATE),
                                  new SqlParameter("@AutoID",typePara.AutoID),
                                  new SqlParameter("@Mode","D")};

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditSpotRate]", paraList)
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

        public ResponseMessage EditDetails(SpotRatesDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                 new SqlParameter("@Deleted",typePara.Deleted==true?1:0),
                                  new SqlParameter("@ExpressID",typePara.ExpressID),
                                  new SqlParameter("@AgnAWBNo",typePara.AgnAWBNo),
                                  new SqlParameter("@TransDate",typePara.TransDate),
                                  new SqlParameter("@Remarks",typePara.Remarks==null?"":typePara.Remarks),
                                  new SqlParameter("@EnterDate",typePara.EnterDate),
                                  new SqlParameter("@Rate",typePara.Rate),
                                  new SqlParameter("@USM_ID",typePara.USM_ID),
                                  new SqlParameter("@USM_DATE",typePara.USM_DATE),
                                  new SqlParameter("@AutoID",typePara.AutoID),
                                  new SqlParameter("@Mode","U")};

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditSpotRate]", paraList)
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

        public IList<SpotRatesAWBDomainView> GetAwbDetails(string AWBNo)
        {
            try
            {
                using (IExpressUnitOfWork<SpotRatesAWBResult> uof = new ExpressUnitOfWork<SpotRatesAWBResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@TrackNo",AWBNo)
                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAWBResultForSpotRate]", paraList)
                                        select new SpotRatesAWBDomainView
                                        {
                                            AgencyCode = SR.AgncyCode.Value,
                                            AWBNo = SR.AgnAWBNo,
                                            CMPY = SR.CMPY.Value,
                                            ExpressID = SR.ExpressID,
                                            TrackNo = SR.AgnTrackNo,
                                            TransDate = SR.TransDate,
                                            BillTransChgY=SR.BillTransChgY,
                                            InvNoTransChg=SR.InvNoTransChg,

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

        public List<SpotRatesDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<SpotRatesDomainView> GetDetails(SpotRatesDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<SpotRatesDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<SpotRatesDomainView> GetSpotDataFromAwb(string AWBNo)
        {
            try
            {
                using (IExpressUnitOfWork<RatesSellSpotRateResult> uof = new ExpressUnitOfWork<RatesSellSpotRateResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@AwbNo",AWBNo)
                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetSpotRateFomAwb]", paraList)
                                        select new SpotRatesDomainView
                                        {
                                            AutoID=SR.AutoID,
                                            AgnAWBNo = SR.AgnAWBNo,
                                            Deleted = SR.Deleted,
                                            EnterDate = SR.EnterDate,
                                            ExpressID = SR.ExpressID,
                                            Rate = SR.Rate,
                                            TransDate = SR.TransDate,
                                            Remarks=SR.Remarks,
                                            USM_DATE=SR.USM_DATE,
                                            USM_ID=SR.USM_ID,
                                            FullName=SR.FullName,
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

        public IList<SpotRatesDomainView> GetSpotDataFromDateRange(string FDate, string ToDate)
        {
            try
            {
                using (IExpressUnitOfWork<RatesSellSpotRateResult> uof = new ExpressUnitOfWork<RatesSellSpotRateResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@FDate",FDate), new SqlParameter("@TDate",ToDate)
                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetSpotRateFomDateRange]", paraList)
                                        select new SpotRatesDomainView
                                        {
                                            AutoID = SR.AutoID,
                                            AgnAWBNo = SR.AgnAWBNo,
                                            Deleted = SR.Deleted,
                                            EnterDate = SR.EnterDate,
                                            ExpressID = SR.ExpressID,
                                            Rate = SR.Rate,
                                            TransDate = SR.TransDate,
                                            Remarks = SR.Remarks,
                                            USM_DATE = SR.USM_DATE,
                                            USM_ID = SR.USM_ID,
                                            FullName=SR.FullName,

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

        public ResponseMessage SaveDetails(SpotRatesDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                  new SqlParameter("@Deleted",typePara.Deleted==true?1:0),
                                  new SqlParameter("@ExpressID",typePara.ExpressID),
                                  new SqlParameter("@AgnAWBNo",typePara.AgnAWBNo),
                                  new SqlParameter("@TransDate",typePara.TransDate),
                                  new SqlParameter("@Remarks",typePara.Remarks==null?"":typePara.Remarks),
                                  new SqlParameter("@EnterDate",typePara.EnterDate),
                                  new SqlParameter("@Rate",typePara.Rate),
                                  new SqlParameter("@USM_ID",typePara.USM_ID),
                                  new SqlParameter("@USM_DATE",typePara.USM_DATE),
                                  new SqlParameter("@AutoID",typePara.AutoID),
                                  new SqlParameter("@Mode","I")};

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditSpotRate]", paraList)
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
    }
}
