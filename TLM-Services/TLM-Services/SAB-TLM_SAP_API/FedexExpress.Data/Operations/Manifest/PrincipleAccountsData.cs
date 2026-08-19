using Express.Interfaces.Operations;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using System.Data;
using Dapper;
using System.Configuration;

namespace Express.Data.Operations.Manifest
{
    public class PrincipleAccountsData : IPrincipleAccounts<PrincipleAccountsView>
    {
        private string errorRaiseModule = "principleAccount";

        public IList<PrincipleAccountsView> DeleteData(string AccountNo)
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = @"UPDATE FinancePR.OrgAgnAccounts 
                                SET Deleted = 1,DelUSM_Date = GETDATE(),DelUSM_ID = 1
                                WHERE AcNo = @AcNo";
                return (List<PrincipleAccountsView>)db.Query<PrincipleAccountsView>(query, new { AcNo = AccountNo });
            }
        }


        public ResponseMessage DeleteDetail(PrincipleAccountsView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(PrincipleAccountsView typePara)
        {
            {
                ResponseMessage mMessage = new ResponseMessage();

                try
                {

                    //    using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                    //    {
                    //        SqlParameter[] paraList = new SqlParameter[]
                    //        {

                    //           new SqlParameter("@AgencyCode",typePara.AgncyCode),
                    //            new SqlParameter("@OrgCode",typePara.OrgCode),
                    //            new SqlParameter("@AccountNo",typePara.AcNo),
                    //            new SqlParameter("@Active",typePara.Active),
                    //            new SqlParameter("@Remarks",typePara.Remarks),
                    //            new SqlParameter("@Status","EDIT")

                    //        };

                    //        var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditRefOrgAccounts]", paraList)
                    //                        select new ResponseMessage
                    //                        {
                    //                            StrMessage = SR.ResponseMessage,
                    //                            ReturnValue = SR.ReturnValue
                    //                        }).FirstOrDefault();
                    //        if (responce.StrMessage == "Successfull")
                    //        {
                    //            mMessage.StrMessage = AppMessage.SaveSuccess;
                    //            mMessage.ReturnValue = responce.ReturnValue;
                    //            mMessage.IsSuccess = true;
                    //        }
                    //        else
                    //        {
                    //            mMessage.StrMessage = responce.StrMessage;
                    //            mMessage.ReturnValue = responce.ReturnValue;
                    //            mMessage.IsSuccess = false;
                    //        }
                    //    }
                    //}
                    //catch (DbUpdateException updateException)
                    //{
                    //    mMessage.IsSuccess = false;
                    //    mMessage.StrMessage = AppMessage.SystemException;
                    //    var updateBaseException = updateException.GetBaseException() as SqlException;
                    //    throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Rates Fuel Shg", updateException);
                    //}
                    //catch (Exception)
                    //{
                    //    mMessage.IsSuccess = false;
                    //    mMessage.StrMessage = AppMessage.SystemException;
                    //    throw;
                    //}

                    //return mMessage;
                    //  ResponseMessage mMessage = new ResponseMessage();

                    ResponseProcessResult responce = null;
                    using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                    {
                        var para = new DynamicParameters();
                                              
                        para.Add("@UserID", typePara.USM_ID);
                        para.Add("@Data", typePara.USM_Date);
                        para.Add("@AgencyCode", typePara.AgncyCode);
                        para.Add("@OrgCode", typePara.OrgCode);
                        para.Add("@AccountNo", typePara.AcNo);
                        para.Add("@CurrentActNo", typePara.CurrentActNo.Trim());
                        para.Add("@Active", typePara.Active);
                        para.Add("@Remarks", typePara.Remarks);
                        //  para.Add("@UserID", typePara.UserID);
                        para.Add("@Status", "EDIT");

                        responce = (ResponseProcessResult)conn.Query<ResponseProcessResult>("[FinancePR].[TLM_AddEditOrgAgnAccounts]", para, 
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }

                    if (responce.ResponseMessage == "Successfull")
                    {
                        mMessage.StrMessage = AppMessage.SaveSuccess;
                        mMessage.ReturnValue = responce.ReturnValue;
                        mMessage.IsSuccess = true;
                    }
                    else
                    {
                        mMessage.StrMessage = responce.ResponseMessage;
                        mMessage.ReturnValue = responce.ReturnValue;
                        mMessage.IsSuccess = false;
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
        

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {
                //using (IExpressUnitOfWork<UserAgencyDetailResult> uof = new ExpressUnitOfWork<UserAgencyDetailResult>())
                //{
                //    SqlParameter[] paraList = new SqlParameter[]
                //          {  new SqlParameter("@UserID", UserId) ,new SqlParameter("@ModuleID", ModuleId) ,new SqlParameter("@MenuID",MenueId)};
                //    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetUserAgencyList]", paraList)
                //                           select new AgencyDomainViewcs
                //                           {
                //                               AgncyCode = Ag.AgncyCode,
                //                               AgncyName = Ag.AgncyName,
                //                               CompID = Ag.CompID,
                //                               CompName = Ag.CompName,
                //                               GroupID = Ag.GroupID,
                //                               MenuCode = Ag.MenuCode,
                //                               ModuleID = Ag.ModuleID,
                //                               UsmId = Ag.UsmId,
                //                               CountryCode = Ag.CountryCode,
                //                               AgncyID = Ag.AgncyID,
                //                               DefaultY = Ag.DefaultY,

                //                           }).ToList();

                //    return OrgRegistryList;
                //}

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    //para.Add("@tarrifNo", tarrifNo);
                    //para.Add("@cvtCurr", cCurrency);
                    para.Add("@UserID",UserId);
                    para.Add("@@ModuleID",ModuleId);
                    para.Add("@MenuID", MenueId);



                    return (List<AgencyDomainViewcs>)conn.Query<AgencyDomainViewcs>("[Project].[TLM_GetUserAgencyList]", para, 
                        commandType: CommandType.StoredProcedure).ToList();
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

        public List<PrincipleAccountsView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<PrincipleAccountsView> GetDetails(PrincipleAccountsView typePara)
        {
            throw new NotImplementedException();
        }

        public List<PrincipleAccountsView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<PrincipleAccountsView> GetPrincipleAccountGrid(int Agency, int OrgCode, string AccountNo)
        {

            try
            {

                using (IExpressUnitOfWork<PrincipleAccountsGridResult> uof = new ExpressUnitOfWork<PrincipleAccountsGridResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                    {
                         new SqlParameter("@AgencyCode",Agency),
                         new SqlParameter("@OrgCode",OrgCode),
                         new SqlParameter("@AccountNo",AccountNo)
                    };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[FinancePR].[TLM_GetOrgAgnAccountsGridFilter]", paraList)
                                        select new PrincipleAccountsView
                                        {
                                            AgncyCode = SR.AgncyCode,
                                            AgncyName = SR.AgncyName,
                                            AcNo = SR.AcNo,
                                            OrgCode = SR.OrgCode,
                                            OrgName = SR.OrgName,
                                            Active = SR.Active,
                                            Remarks = SR.Remarks,
                                            USM_Date = SR.USM_Date,
                                            USM_ID = SR.USM_ID
                                            

                                            //SalesAreaID = SR.SalesAreaID,
                                            //SalesAreaName = SR.SalesAreaName

                                        }).ToList();

                    return customerHead;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorRaiseModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public ResponseMessage SaveDetails(PrincipleAccountsView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                //    using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                //    {
                //        SqlParameter[] paraList = new SqlParameter[]
                //        {
                //          //  new SqlParameter("@CMPY",typePara.CMPY),
                //            new SqlParameter("@AgencyCode",typePara.AgncyCode),
                //            new SqlParameter("@OrgCode",typePara.OrgCode),
                //            new SqlParameter("@AccountNo",typePara.AcNo),
                //            new SqlParameter("@Active",typePara.Active),
                //            new SqlParameter("@Remarks",typePara.Remarks),
                //            new SqlParameter("@Status","ADD")
                //        };
                //        var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditRefOrgAccounts]", paraList)
                //                        select new ResponseMessage
                //                        {
                //                            StrMessage = SR.ResponseMessage,
                //                            ReturnValue = SR.ReturnValue
                //                        }).FirstOrDefault();

                //        if (responce.StrMessage == "Successfull")
                //        {
                //            mMessage.StrMessage = AppMessage.SaveSuccess;
                //            mMessage.ReturnValue = responce.ReturnValue;
                //            mMessage.IsSuccess = true;
                //        }
                //        else
                //        {

                //            mMessage.StrMessage = responce.StrMessage;
                //            mMessage.ReturnValue = responce.ReturnValue;
                //            mMessage.IsSuccess = false;
                //        }
                //    }

                //}
                //catch (DbUpdateException updateException)
                //{
                //    mMessage.IsSuccess = false;
                //    mMessage.StrMessage = AppMessage.SystemException;
                //    var updateBaseException = updateException.GetBaseException() as SqlException;
                //    throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Rates Fuel Shg", updateException);
                //}
                //catch (Exception ex)
                //{
                //    mMessage.IsSuccess = false;
                //    mMessage.StrMessage = AppMessage.SystemException;

                //}


                //return mMessage;
                ResponseProcessResult responce = null;
                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();

                    para.Add("@UserID", typePara.USM_ID);
                    //para.Add("@USM_Date", typePara.USM_Date);
                    //para.Add("@DelUSM_ID", typePara.DelUSM_ID);
                    //para.Add("@DelUSM_Date", typePara.DelUSM_Date);                   
                    para.Add("@Deleted", typePara.Deleted);

                    para.Add("@AgencyCode", typePara.AgncyCode);
                    para.Add("@OrgCode", typePara.OrgCode);
                    para.Add("@AccountNo", typePara.AcNo);
                    para.Add("@CurrentActNo", typePara.AcNo);
                    para.Add("@Active", typePara.Active);
                    para.Add("@Remarks", typePara.Remarks);

                  //  para.Add("@UserID", typePara.UserID);
                    para.Add("@Status", "ADD");

                    responce = (ResponseProcessResult)conn.Query<ResponseProcessResult>("[FinancePR].[TLM_AddEditOrgAgnAccounts]", para, 
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                if (responce.ResponseMessage == "Successfull")
                {
                    mMessage.StrMessage = AppMessage.SaveSuccess;
                    mMessage.ReturnValue = responce.ReturnValue;
                    mMessage.IsSuccess = true;
                }
                else
                {
                    mMessage.StrMessage = responce.ResponseMessage;
                    mMessage.ReturnValue = responce.ReturnValue;
                    mMessage.IsSuccess = false;
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
