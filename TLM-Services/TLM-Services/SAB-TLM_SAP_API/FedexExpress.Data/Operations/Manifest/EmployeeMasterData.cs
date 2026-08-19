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
using System.Data.Entity.Infrastructure;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;

namespace Express.Data.Operations.Manifest
{
    public class EmployeeMasterData : IEmployeeMaster<EmployeeMasterView>
    {
        private string errorRaiseModule = "employeeMaster";

        public ResponseMessage DeleteDetail(EmployeeMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(EmployeeMasterView typePara)
        {
            {
                ResponseMessage mMessage = new ResponseMessage();

                try
                {

                    using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                    {
                        SqlParameter[] paraList = new SqlParameter[]
                        {

                        new SqlParameter("@SvcRootID",typePara.EmployeeID),
                        new SqlParameter("@SvcRootName",typePara.EmployeeName),
                        new SqlParameter("@Remarks",typePara.Remarks),
                        new SqlParameter("@Active",typePara.Active),
                        new SqlParameter("@Status","EDIT")

                        };

                        var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_EmployeeMaster]", paraList)
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

        public List<EmployeeMasterView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeMasterView> GetDetails(EmployeeMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeMasterView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<EmployeeMasterView> GetEmployeeMasterGrid()
        {
            try
            {

                using (IExpressUnitOfWork<EmployeeMasterGridResult> uof = new ExpressUnitOfWork<EmployeeMasterGridResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                    {


                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_EmployeeMasterGrid]", paraList)
                                        select new EmployeeMasterView
                                        {

                                            EmployeeID = SR.EmployeeID,
                                            EmployeeName = SR.EmployeeName,
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

        public ResponseMessage SaveDetails(EmployeeMasterView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@SvcRootID",typePara.EmployeeID),
                        new SqlParameter("@SvcRootName",typePara.EmployeeName),
                        new SqlParameter("@Remarks",typePara.Remarks),
                        new SqlParameter("@Active",typePara.Active),
                        new SqlParameter("@Status","ADD")
                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_EmployeeMaster]", paraList)
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
