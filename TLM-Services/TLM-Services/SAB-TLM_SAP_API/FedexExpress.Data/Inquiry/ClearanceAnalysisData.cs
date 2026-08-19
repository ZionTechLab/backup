using Express.Interfaces.Inquiry;
using Express.View.Domain.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.View.Domain.Invoice;

namespace Express.Data.Inquiry
{
    public class ClearanceAnalysisData : IClearanceAnalysis<ClearanceAnalysisDomainView>
    {
        public ResponseMessage DeleteDetail(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {
                using (IExpressUnitOfWork<UserAgencyDetailResult> uof = new ExpressUnitOfWork<UserAgencyDetailResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@UserID", UserId) ,new SqlParameter("@ModuleID", ModuleId) ,new SqlParameter("@MenuID",MenueId)};
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetUserAgencyList]", paraList)
                                           select new AgencyDomainViewcs
                                           {
                                               AgncyCode = Ag.AgncyCode,
                                               AgncyName = Ag.AgncyName,
                                               CompID = Ag.CompID,
                                               CompName = Ag.CompName,
                                               GroupID = Ag.GroupID,
                                               MenuCode = Ag.MenuCode,
                                               ModuleID = Ag.ModuleID,
                                               UsmId = Ag.UsmId,
                                               CountryCode = Ag.CountryCode,
                                               AgncyID = Ag.AgncyID,
                                               DefaultY = Ag.DefaultY,

                                           }).ToList();

                    return OrgRegistryList;
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

        public List<ClearanceAnalysisDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ClearanceAnalysisDomainView> GetDetails(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ClearanceAnalysisDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            try
            {
                using (IExpressUnitOfWork<GatewayResults> uof = new ExpressUnitOfWork<GatewayResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@Country", CountryID) };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllRefLocations]", paraList)
                                       where Ag.GateWay == "Y"
                                       select new GatewayDomainView
                                       {
                                           Active = Ag.Active,
                                           Country = Ag.Country,
                                           GateWay = Ag.GateWay,
                                           Hub = Ag.Hub,
                                           LocationID = Ag.LocationID,
                                           LocationName = Ag.LocationName,
                                           Remarks = Ag.Remarks,
                                           Station = Ag.Station,

                                       }).ToList();

                    return GatewayList;
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

        public IList<ClearanceAnalysisDomainView> GetInvoiceList(string fDate, string frominvNo, string ToInvNo, string todate, int CMPY, int agency, int groupID, string Gate, string Station, string InvoiceType, bool isInvoiceRange)
        {
            try
            {
                using (IExpressUnitOfWork<ClearanceAnalysisResult> uof = new ExpressUnitOfWork<ClearanceAnalysisResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@fromDate", fDate) 
                          ,new SqlParameter("@todate", todate) 
                          ,new SqlParameter("@cmpy",CMPY),
                          new SqlParameter("@agecy", agency) 
                          ,new SqlParameter("@groupID", groupID)
                          ,new SqlParameter("@gateway",Gate),
                          new SqlParameter("@station", Station)
                          ,new SqlParameter("@invoiceType",InvoiceType) 
                          ,new SqlParameter("@fromInvoice",frominvNo==""?"0":frominvNo),
                           new SqlParameter("@toInvoice", ToInvNo==""?"0":ToInvNo) ,
                           new SqlParameter("@isRange", isInvoiceRange==true?"Y":"N") };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetClearanceAnalysisRepData]", paraList)
                                           select new ClearanceAnalysisDomainView
                                           {
                                               TransDate = Ag.TransDate.Value,
                                               ExpressID = Ag.ExpressID,
                                               CustomVal = Ag.CustomVal.Value,
                                               PayNo = Ag.PayNo.Value,
                                               InvNo = Ag.InvNo.Value,
                                               ShipType = Ag.ShipType,
                                               TotalDutyVal = Ag.TotalDutyVal.Value,
                                               PayAmt = Ag.PayAmt.Value,
                                               InvAmt = Ag.InvAmt.Value,
                                               Duty = Ag.Duty.Value,
                                               Vat = Ag.Vat.Value,
                                               ADMIN= Ag.ADMIN.Value,
                                               CMPY=201,
                                               CompanyName="Sab",
                                               AgncyCode=201,
                                               AgncyID="agancy"


                                           }).ToList();

                    return OrgRegistryList;
                }
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

        public IList<InvoiceTypeDomainView> GetInvoiceType()
        {
            try
            {
                using (IExpressUnitOfWork<GatInvoiceTypeResult> uof = new ExpressUnitOfWork<GatInvoiceTypeResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  };
                    var InvoiceType = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GeInvoiceType]", paraList)
                                       where Ag.Active=="Y"
                                       select new InvoiceTypeDomainView
                                       {
                                           AgncyCode = Ag.AgncyCode,
                                           Active = Ag.Active,
                                           BillOrgCode = Ag.BillOrgCode,
                                           CMPY = Ag.CMPY,
                                           DocCata = Ag.DocCata,
                                           Doctype = Ag.Doctype,
                                           DoctypeN = Ag.DoctypeN,
                                           ExgRateTarif = Ag.ExgRateTarif,
                                           FuelChart = Ag.FuelChart,
                                           FuelCostChart = Ag.FuelCostChart,
                                           PaidLF = Ag.PaidLF,
                                       }).ToList();
                    return InvoiceType;
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

        public IList<GatewayDomainView> GetStations(string CountryID)
        {
            try
            {
                using (IExpressUnitOfWork<GatewayResults> uof = new ExpressUnitOfWork<GatewayResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@Country", CountryID) };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAllRefLocations]", paraList)
                                       where Ag.Station == "Y"
                                       select new GatewayDomainView
                                       {
                                           Active = Ag.Active,
                                           Country = Ag.Country,
                                           GateWay = Ag.GateWay,
                                           Hub = Ag.Hub,
                                           LocationID = Ag.LocationID,
                                           LocationName = Ag.LocationName,
                                           Remarks = Ag.Remarks,
                                           Station = Ag.Station,

                                       }).ToList();

                    return GatewayList;
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

        public ResponseMessage SaveDetails(ClearanceAnalysisDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            try
            {
                using (IExpressUnitOfWork<CfgDoctypesResult> uof = new ExpressUnitOfWork<CfgDoctypesResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                              new SqlParameter("@CMPY", CMPY),
                              new SqlParameter("@AgncyCode", AgncyCode)
                          };
                    var CfgDoctypesList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetCfgDoctypes]", paraList)
                                           select new ClrInvDocTypesDomainView
                                           {
                                               Doctype = Ag.Doctype,
                                               DoctypeN = Ag.DoctypeN,

                                           }).ToList();

                    return CfgDoctypesList;
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
    }
}
