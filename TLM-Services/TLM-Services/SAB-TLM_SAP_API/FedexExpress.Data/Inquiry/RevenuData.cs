using Express.Interfaces.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.View.Domain.Inquiry;
using System.Data;
using Dapper;

namespace Express.Data.Inquiry
{
    public class RevenuData : IRevenuRepo
    {
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@UserID", UserId);
                    para.Add("@ModuleID", ModuleId);
                    para.Add("@MenuID", MenueId);
                    return (List<AgencyDomainViewcs>)conn.Query<AgencyDomainViewcs>("[Project].[TLM_GetUserAgencyList]", para, commandType: CommandType.StoredProcedure).ToList();
                }


                //using (IExpressUnitOfWork<AgencyDomainViewcs> uof = new ExpressUnitOfWork<AgencyDomainViewcs>())
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

        public IList<RevenuDomainView> GetRevenu( RevenuPramDomainView _para)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@CompanyID", _para.CompanyID);
                    para.Add("@AgencyID", _para.AgencyID);
                    para.Add("@TrDateFrom", _para.TrDateFrom);
                    para.Add("@TrDateTo", _para.TrDateTo);
                    para.Add("@RevImport", _para.RevImport);
                    para.Add("@RevPickUp", _para.RevPickUp);
                    para.Add("@Rev3rdParty", _para.Rev3rdParty);

                    para.Add("@RevExport", _para.RevExport);
                    para.Add("@RevDelivery", _para.RevDelivery);
                    para.Add("@InvInvoiced", _para.InvInvoiced);
                    para.Add("@InvUnbill", _para.InvUnbill);
                    para.Add("@InvUninvoiced", _para.InvUninvoiced);
                    para.Add("@CustomerCode", _para.CustomerCode);
                    para.Add("@InvDateFrom", _para.InvDateFrom);
                    para.Add("@InvDateTo", _para.InvDateTo);
                    para.Add("@PrnInvDateFrom", _para.PrnInvDateFrom);
                    para.Add("@PrnInvDateTo", _para.PrnInvDateTo);
                    para.Add("@SalesArea", _para.SalesArea);
                    para.Add("@IsAllRevType", _para.IsAllRevType);
                    para.Add("@IsAllInvType", _para.IsAllInvType);

                    para.Add("@IsAllCust", _para.IsAllCust);
                    para.Add("@IsAllInvDate", _para.IsAllInvDate);
                    para.Add("@IsAllInvPrnDate", _para.IsAllInvPrnDate);
                    para.Add("@IsAllSalesArea", _para.IsAllSalesArea);                          

                return (List<RevenuDomainView>)conn.Query<RevenuDomainView>("[Express].[TLM_InqRevenuReport]", para, commandType: CommandType.StoredProcedure).ToList();
                }


                ////using (IExpressUnitOfWork<RevenuDomainView> uof = new ExpressUnitOfWork<RevenuDomainView>())
                ////{
                ////    SqlParameter[] paraList = new SqlParameter[]
                ////          {
                ////           new SqlParameter("@CompanyID", _para.CompanyID)
                ////          ,new SqlParameter("@AgencyID",_para.AgencyID)
                ////          ,new SqlParameter("@TrDateFrom", _para.TrDateFrom )
                ////          ,new SqlParameter("@TrDateTo", _para.TrDateTo )
                ////          ,new SqlParameter("@RevImport",_para.RevImport )
                ////          ,new SqlParameter("@RevPickUp", _para.RevPickUp )
                ////          ,new SqlParameter("@Rev3rdParty",_para.Rev3rdParty)

                ////          ,new SqlParameter("@RevExport",_para.RevExport)
                ////          ,new SqlParameter("@RevDelivery",_para.RevDelivery )
                ////          ,new SqlParameter("@InvInvoiced",_para.InvInvoiced )
                ////          ,new SqlParameter("@InvUnbill",_para.InvUnbill )
                ////          ,new SqlParameter("@InvUninvoiced",_para.InvUninvoiced)
                ////          ,new SqlParameter("@CustomerCode",_para.CustomerCode )
                ////          ,new SqlParameter("@InvDateFrom",_para.InvDateFrom )
                ////          ,new SqlParameter("@InvDateTo",_para.InvDateTo )
                ////          ,new SqlParameter("@PrnInvDateFrom",_para.PrnInvDateFrom )
                ////          ,new SqlParameter("@PrnInvDateTo",_para.PrnInvDateTo )
                ////          ,new SqlParameter("@SalesArea",_para.SalesArea )
                ////          ,new SqlParameter("@IsAllRevType",_para.IsAllRevType)
                ////          ,new SqlParameter("@IsAllInvType",_para.IsAllInvType )

                ////          ,new SqlParameter("@IsAllCust",_para.IsAllCust)
                ////          ,new SqlParameter("@IsAllInvDate",_para.IsAllInvDate )
                ////          ,new SqlParameter("@IsAllInvPrnDate",_para.IsAllInvPrnDate )
                ////          ,new SqlParameter("@IsAllSalesArea",_para.IsAllSalesArea )
                ////         };
                ////    var _revReport = (from RE in uof.Reposotery.GetDataBySp("[Express].[TLM_InqRevenuReport]", paraList)
                ////                           select new RevenuDomainView
                ////                           {
                ////                               TrDate = RE.TrDate ,
                ////                               AirwaybillNo = RE.AirwaybillNo ,
                ////                               Route  = RE.Route ,
                ////                               Getway  = RE.Getway ,
                ////                               Station =RE.Station ,
                ////                               OrginCntr = RE.OrginCntr ,
                ////                               DestinCntry = RE.DestinCntry ,
                ////                               Service =RE.Service ,
                ////                               Package = RE.Package ,
                ////                               Weight =RE.Weight,
                ////                               RevType =RE.RevType,
                ////                               InvStatus =RE.InvStatus,
                ////                               PrnAccNo =RE.PrnAccNo,
                ////                               CustomerCode =RE.CustomerCode,
                ////                               CustomerN =RE.CustomerN,
                ////                               InvoiceDate =RE.InvoiceDate,
                ////                               InvoiceNo =RE.InvoiceNo,
                ////                               Currency =RE.Currency,
                ////                               SalesArea =RE.SalesArea,
                ////                               InvoiceAmount =RE.InvoiceAmount,
                ////                               GdrCost =RE.GdrCost,
                ////                               FuelSurCharge =RE.FuelSurCharge,
                ////                               OtherChg =RE.OtherChg,
                ////                               GrossProfit =RE.GrossProfit,
                ////                               RecInvDate =RE.RecInvDate,
                ////                               RecInvoiceNo =RE.RecInvoiceNo,
                ////                               RecCurrency =RE.RecCurrency,
                ////                               RecFrtAmount =RE.RecFrtAmount,
                ////                               RecFuelSurCharge =RE.RecFuelSurCharge,
                ////                               RecOtherChg =RE.RecOtherChg,
                ////                               RecDecAmount =RE.RecDecAmount,
                ////                               CostDifference=RE.CostDifference

                ////                           }).ToList();

                ////    return _revReport;
                ////}
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Express", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<SalesAreaDomainView> GetSalesArea(int companyID, int agencyID)
        {
            try
            {


                using (IDbConnection conn = new SqlConnection(DapperConnetion.GetConnetion()))
                {
                    var para = new DynamicParameters();
                    para.Add("@groupID", 1);
                    para.Add("@companyID", companyID);
                    para.Add("@agencyID", agencyID);
                    return (List<SalesAreaDomainView>)conn.Query<SalesAreaDomainView>("[Express].[USP_GetSalesAreaMap]", para, commandType: CommandType.StoredProcedure).ToList();
                }

                //using (IExpressUnitOfWork<SalesAreaDomainView> uof = new ExpressUnitOfWork<SalesAreaDomainView>())
                //{

                //    SqlParameter[] paraList = new SqlParameter[]
                //      {
                //           new SqlParameter("@groupID", 1),
                //            new SqlParameter("@companyID" ,companyID),
                //                new SqlParameter("@agencyID" ,agencyID )
                //      };
                //    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[USP_GetSalesAreaMap]", paraList)
                //                        select new
                //                        {
                //                            SR.BranchCode,
                //                            SR.SalesAreaID,
                //                            SR.SalesAreaName

                //                        }).ToList().Select(SR => new SalesAreaDomainView
                //                        {
                //                            BranchCode = SR.BranchCode,
                //                            SalesAreaID = SR.SalesAreaID,
                //                            SalesAreaName = SR.SalesAreaName

                //                        }).ToList();

                //    return customerHead;

                //}



            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
