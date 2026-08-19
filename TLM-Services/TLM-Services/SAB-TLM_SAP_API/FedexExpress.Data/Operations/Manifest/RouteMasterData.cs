using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Data.FedexExpressEF;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;

namespace Express.Data.Operations.Manifest
{
    public class RouteMasterData : IRouteMaster<RouteMasterView>
    {
        private string errorRaiseModule = "routeMaster";

        public ResponseMessage DeleteDetail(RouteMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(RouteMasterView typePara)
        {
            {
                ResponseMessage mMessage = new ResponseMessage();

                try
                {

                    using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                    {
                        SqlParameter[] paraList = new SqlParameter[]
                        {

                      //  new SqlParameter("@CMPY",typePara.CMPY),
                        new SqlParameter("@SvcRootID",typePara.SvcRootID),
                        new SqlParameter("@SvcRootName",typePara.SvcRootName),
                        new SqlParameter("@Remarks",typePara.Remarks),
                        new SqlParameter("@Active",typePara.Active),
                        new SqlParameter("@Status","EDIT")

                        };

                        var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_RouteMaster]", paraList)
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

        public List<RouteMasterView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<RouteMasterView> GetDetails(RouteMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public List<RouteMasterView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<RouteMasterView> GetRoutMasterGrid()
        {
            try
            {

                using (IExpressUnitOfWork<RouteMasterGridResultcs> uof = new ExpressUnitOfWork<RouteMasterGridResultcs>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        

                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_RouteMasterGrid]", paraList)
                                        select new RouteMasterView
                                        {

                                            SvcRootID = SR.SvcRootID,
                                            SvcRootName = SR.SvcRootName,
                                            Remarks = SR.Remarks,
                                            Active = SR.Active
                                            
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

        public ResponseMessage SaveDetails(RouteMasterView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                      //  new SqlParameter("@CMPY",typePara.CMPY),
                        new SqlParameter("@SvcRootID",typePara.SvcRootID),
                        new SqlParameter("@SvcRootName",typePara.SvcRootName),
                        new SqlParameter("@Remarks",typePara.Remarks),
                        new SqlParameter("@Active",typePara.Active),
                        new SqlParameter("@Status","ADD")
                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_RouteMaster]", paraList)
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
