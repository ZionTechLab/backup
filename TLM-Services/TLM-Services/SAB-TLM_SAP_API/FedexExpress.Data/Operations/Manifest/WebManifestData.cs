using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.Data.FedexExpressEF;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using Express.View.Domain.AdminConfiguration;
using Express.Data.Common;
using Express.View.Domain.Report.Operation;

namespace Express.Data.Operations.Manifest
{
    public class WebManifestData : IWebManifest<WebManifestDomainView>
    {
        public ResponseMessage DeleteDetail(WebManifestDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(WebManifestDomainView typePara)
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

        public List<WebManifestDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<WebManifestDomainView> GetDetails(WebManifestDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<WebManifestDomainView> GetDetails(string code)
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
                                       where Ag.Station=="Y"
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

        public ResponseMessage SaveDetails(WebManifestDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<ServiceTypeDomainView> GetServiceType(int CMPY, int Agency)
        {
            try
            {
                using (IExpressUnitOfWork<CfgSvcType> uof = new ExpressUnitOfWork<CfgSvcType>())
                {
                    return (from svc in uof.Reposotery.GetDetails()
                            where svc.CMPY == CMPY && svc.AgncyCode == Agency
                            select new ServiceTypeDomainView
                            {
                                SvcTypeN = svc.SvcTypeN,
                                SvcType = svc.SvcType,
                                CMPY = svc.CMPY,
                                AgncyCode = svc.AgncyCode

                            }).ToList();
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

        public IList<CfgCountryDomainView> GetCountryList()
        {
            try
            {
                using (IExpressUnitOfWork<CfgCountry> uof = new ExpressUnitOfWork<CfgCountry>())
                {
                    return (from svc in uof.Reposotery.GetDetails()
                            where svc.Active == "Y"
                            select new CfgCountryDomainView
                            {
                                Active = svc.Active,
                                Country = svc.Country,
                                CountryN = svc.CountryN,

                            }).OrderBy(order=>order.CountryN).ToList();
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

        public ResponseMessage SaveWebAWBList(WebManufestUploadWrappingDoaminView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {

                    string xmlString = "<ROOT>";
                    foreach (var item in typePara.ManifestList)
                    {

                        xmlString = xmlString + "<ROW>"
                        + "<Deleted>" + item.Deleted + "</Deleted>"
                        + "<CMPY>" + item.CMPY + "</CMPY>"
                        + "<AgncyCode>" + item.AgncyCode + "</AgncyCode>"
                        + "<AgncyIdNo>" + item.AgncyID + "</AgncyIdNo>"
                        + "<ORIGINGate>" + item.ORIGINGate + "</ORIGINGate>"
                        + "<DESTINGate>" + item.DESTINGate + "</DESTINGate>"
                        + "<ConsId>" + item.ConsId + "</ConsId>"
                        + "<ShipType>" + item.ShipType + "</ShipType>"
                        + "<TransMode>" + item.TransMode + "</TransMode>"
                        + "<AgnAWBNo>" + item.AgnAWBNo + "</AgnAWBNo>"
                        + "<AgnMpsNo>" + item.AgnMpsNo + "</AgnMpsNo>"
                        + "<AgnTrackNo>" + item.AgnTrackNo + "</AgnTrackNo>"
                        + "<ORIGIN>" + item.ORIGIN + "</ORIGIN>"
                        + "<DESTIN>" + item.DESTIN + "</DESTIN>"
                        + "<ORGCOUNTRY>" + item.ORGCOUNTRY + "</ORGCOUNTRY>"
                        + "<DESCOUNTRY>" + item.DESCOUNTRY + "</DESCOUNTRY>"
                        + "<ShipDate> "+ item.ShipDate.Year+ "-" + item.ShipDate.Month + "-"+ item.ShipDate.Day + "</ShipDate>"
                        + "<ShipLocationType>" + item.ShipLocationType + "</ShipLocationType>"
                        + "<SenAccount>" + item.SenAccount + "</SenAccount>"
                        + "<SenPhone>" + item.SenPhone + "</SenPhone>"
                        + "<SenCountry>" + UnescapeXml(item.SenCountry) + "</SenCountry>"
                        + "<SenCode>" + item.SenCode + "</SenCode>"
                        + "<SenCompany>" + UnescapeXml(item.SenCompany) + "</SenCompany>"
                        + "<SenID>" + item.SenID + "</SenID>"
                        + "<SenName>" + UnescapeXml(item.SenName) + "</SenName>"
                        + "<SenAddr1>" + UnescapeXml(item.SenAddr1) + "</SenAddr1>"
                        + "<SenAddr2>" + UnescapeXml(item.SenAddr2) + "</SenAddr2>"
                        + "<SenCity>" + item.SenCity + "</SenCity>"
                        + "<SenCityN>" + UnescapeXml(item.SenCityN) + "</SenCityN>"
                        + "<SenState>" + item.SenState + "</SenState>"
                        + "<SenZip>" + item.SenZip + "</SenZip>"
                        + "<RecAccount>" + item.RecAccount + "</RecAccount>"
                        + "<RecPhone>" + item.RecPhone + "</RecPhone>"
                        + "<RecCountry>" + UnescapeXml(item.RecCountry) + "</RecCountry>"
                        + "<RecCode>" + item.RecCode + "</RecCode>"
                        + "<RecCompany>" + UnescapeXml(item.RecCompany) + "</RecCompany>"
                        + "<RecName>" + UnescapeXml(item.RecName) + "</RecName>"
                        + "<RecAddr1>" + UnescapeXml(item.RecAddr1) + "</RecAddr1>"
                        + "<RecAddr2>" + UnescapeXml(item.RecAddr2) + "</RecAddr2>"
                        + "<RecCity>" + item.RecCity + "</RecCity>"
                        + "<RecCityN>" + UnescapeXml(item.RecCityN) + "</RecCityN>"
                        + "<RecState>" + item.RecState + "</RecState>"
                        + "<RecZip>" + item.RecZip + "</RecZip>"
                        + "<TotPkgs>" + item.TotPkgs + "</TotPkgs>"
                        + "<SvcType>" + item.SvcType + "</SvcType>"
                        + "<PackType>" + item.PackType + "</PackType>"
                        + "<TotWgt>" + item.TotWgt + "</TotWgt>"
                        + "<WgtU>" + item.WgtU + "</WgtU>"
                        + "<DimVol>" + item.DimVol + "</DimVol>"
                        + "<DimVolU>" + item.DimVolU + "</DimVolU>"
                        + "<RexWgt>" + item.RexWgt + "</RexWgt>"
                        + "<RexWgtU>" + item.RexWgtU + "</RexWgtU>"
                        + "<RexVol>" + item.RexVol + "</RexVol>"
                        + "<RexVolu>" + item.RexVolU + "</RexVolu>"
                        + "<CarriageVal>" + item.CarriageVal + "</CarriageVal>"
                        + "<CarriageValCur>" + item.CarriageValCur + "</CarriageValCur>"
                        + "<CustomVal>" + item.CustomVal + "</CustomVal>"
                        + "<CustomValCur>" + item.CustomValCur + "</CustomValCur>"
                        + "<Descrip>" + UnescapeXml(item.Descrip) + "</Descrip>"
                        + "<SenRefNotes>" + UnescapeXml(item.SenRefNotes) + "</SenRefNotes>"
                        + "<DocNdoc>" + item.DocNdoc + "</DocNdoc>"
                        + "<HoldAtLoc>" + item.HoldAtLoc + "</HoldAtLoc>"
                        + "<BillTransChg>" + item.BillTransChg + "</BillTransChg>"
                        + "<BillTransAcNo>" + item.BillTransAcNo + "</BillTransAcNo>"
                        + "<BillDtaxChg>" + item.BillDtaxChg + "</BillDtaxChg>"
                        + "<BillDtaxAcNo>" + item.BillDtaxAcNo + "</BillDtaxAcNo>"
                        + "<IntComDate>" + item.IntComDate.Year + "-" + item.IntComDate.Month + "-" + item.IntComDate.Day + "</IntComDate>"
                        + "<IntComTime>" + item.IntComTime + "</IntComTime>"
                        + "<USM_LOGIN>" + item.USM_LOGIN + "</USM_LOGIN>"
                        + "<USM_DATE>"+ item.USM_DATE.Year + "-" + item.USM_DATE.Month + "-" + item.USM_DATE.Day + "</USM_DATE>"
                        + "<FormNo>" + item.Form + "</FormNo>"
                        + "<Base>" + item.Base + "</Base>"
                        + "</ROW>";
                    }
                    xmlString = xmlString + "</ROOT>";


                    SqlParameter[] paraList = new SqlParameter[]
                              {new SqlParameter("@Mode","I"),
                                  new SqlParameter("@xmlDataValue",xmlString) };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_WebManifestUploadAWBDetail]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,

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
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Organization", sqlEx);
            }
            catch (DbUpdateException updateException)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Organization", updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;

            }
            return mMessage;
        }

        public string UnescapeXml(string s)
        {
            string unxml = s;
            if (!string.IsNullOrEmpty(unxml))
            {
                unxml = unxml.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;"); ;
            }
            return unxml;
        }

        public IList<WebManifestDomainView> GetFilterResult(int CMPY, int Agency,string FilterStarte, string FDate, string ToDate, string OCountryCode, string DestinLoc, string ServiceType, string ManifestType, string FBill, string Dbill, string Cargodesc, string Consignee)
        {
            try
            {
                using (IExpressUnitOfWork<OpsGSPAWBResult> uof = new ExpressUnitOfWork<OpsGSPAWBResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@companyID",CMPY), new SqlParameter("@agencyID",Agency)
                          ,new SqlParameter("@fDate", FDate),new SqlParameter("@toDate", ToDate)
                            ,new SqlParameter("@OCountryCode",OCountryCode),
                                new SqlParameter("@destinLoc", DestinLoc),new SqlParameter("@serviceType", ServiceType)
                              ,new SqlParameter("@manifestType", ManifestType),new SqlParameter("@fBill", FBill),new SqlParameter("@dbill", Dbill)
                              ,new SqlParameter("@cargodesc", Cargodesc) ,new SqlParameter("@consignee", Consignee),new SqlParameter("@filterState", FilterStarte)
                          };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetWebManifestData]", paraList)
                                       select new WebManifestDomainView
                                       {
                                           Deleted = Ag.Deleted.Value,
                                           AgnAWBNo = Ag.AgnAWBNo,
                                           AgncyCode = Ag.AgncyCode.Value,
                                           AgncyID = Ag.AgncyID,
                                           AgnMpsNo = Ag.AgnMpsNo,
                                           AgnTrackNo = Ag.AgnTrackNo,
                                           BillDtaxAcNo = Ag.BillDtaxAcNo,
                                           StationID = Ag.StationID,
                                           BillDtaxChg = Ag.BillDtaxChg,
                                           BillDTaxCreditY = Ag.BillDTaxCreditY,
                                           BillOrgCode = Ag.BillOrgCode.Value,
                                           BillOrgName = Ag.BillOrgName,
                                           BillTransAcNo = Ag.BillTransAcNo,
                                           BillTransChg = Ag.BillTransChg,
                                           CarriageVal = Ag.CarriageVal.Value,
                                           CarriageValCur = Ag.CarriageValCur,
                                           CMPY = Ag.CMPY.Value,
                                           ConsId = Ag.ConsId,
                                           ConvRate = Ag.ConvRate.Value,
                                           CustomsCurr = Ag.CustomsCurr,
                                           CustomsPkgVal = Ag.CustomsPkgVal.Value,
                                           CustomVal = Ag.CustomVal.Value,
                                           CustomValCur = Ag.CustomValCur,
                                           DESCOUNTRY = Ag.DESCOUNTRY,
                                           Descrip = Ag.Descrip,
                                           DESTIN = Ag.DESTIN,
                                           DESTINGate = Ag.DESTINGate,
                                           DetainedY = Ag.DetainedY,
                                           DimVol = Ag.DimVol.Value,
                                           DimVolU = Ag.DimVolU,
                                           DocNdoc = Ag.DocNdoc,
                                           DutyExcemptY = Ag.DutyExcemptY,
                                           HoldAtLoc = Ag.HoldAtLoc,
                                           IntComDate = Ag.IntComDate.Value,
                                           IntComTime = Ag.IntComTime.Value,
                                           ORGCOUNTRY = Ag.ORGCOUNTRY,
                                           ORIGIN = Ag.ORIGIN,
                                           ORIGINGate = Ag.ORIGINGate,
                                           PackType = Ag.PackType,
                                           RecAccount = Ag.RecAccount,
                                           RecAddr1 = Ag.RecAddr1,
                                           RecAddr2 = Ag.RecAddr2,
                                           RecCity = Ag.RecCity.Value,
                                           RecCityN = Ag.RecCityN,
                                           RecCode = Ag.RecCode,
                                           RecCompany = Ag.RecCompany,
                                           RecCountry = Ag.RecCountry,
                                           RecName = Ag.RecName,
                                           RecPhone = Ag.RecPhone,
                                           RecState = Ag.RecState,
                                           RecZip = Ag.RecZip,
                                           RexVol = Ag.RexVol.Value,
                                           RexVolU = Ag.RexVolU,
                                           RexWgt = Ag.RexWgt.Value,
                                           RexWgtU = Ag.RexWgtU,
                                           RouteID = Ag.RouteID,
                                           SenAccount = Ag.SenAccount,
                                           SenAddr1 = Ag.SenAddr1,
                                           SenAddr2 = Ag.SenAddr2,
                                           SenCity = Ag.SenCity.Value,
                                           SenCityN = Ag.SenCityN,
                                           SenCode = Ag.SenCode,
                                           SenCompany = Ag.SenCompany,
                                           SenCountry = Ag.SenCountry,
                                           SenID = Ag.SenID,
                                           SenName = Ag.SenName,
                                           SenPhone = Ag.SenPhone,
                                           SenRefNotes = Ag.SenRefNotes,
                                           SenState = Ag.SenState,
                                           SenZip = Ag.SenZip,
                                           ShipDate = Ag.ShipDate.Value,
                                           ShipLocationType = Ag.ShipLocationType,
                                           ShipType = Ag.ShipType,
                                           ShipValueType = Ag.ShipValueType,
                                           ShipValueTypeCata = Ag.ShipValueTypeCata.Value,
                                           SvcType = Ag.SvcType,
                                           TotalDutyVal = Ag.TotalDutyVal.Value,
                                           TotPkgs = Ag.TotPkgs.Value,
                                           TotWgt = Ag.TotWgt.Value,
                                           USM_DATE = Ag.USM_DATE.Value,
                                           USM_LOGIN = Ag.USM_LOGIN,
                                           WgtU = Ag.WgtU,
                                           Remarks  = Ag.Remarks ,
                                           DutythreshLC = Ag.DutythreshLC ,
                                           ClearStatuesCode = Ag.ClearStatuesCode ,
                                           ClearStatusN = Ag.ClearStatusN ,
                                           ConsoleType = Ag.ConsoleType ,
                                           ConsoleTypeN = Ag.ConsoleTypeN 
                                          


                                       }).ToList();

                    return GatewayList;
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

        public IList<ClearenceStatusDomainView> GetClearenceStatus()
        {
            return ConfigData.GetClearenceStatus();
        }

        public IList<WebManiClearenceType> GetClearenceTypes()
        {
          return (  from ct in ConfigData.GetClearenceType()
                    select new WebManiClearenceType
                    {
                        ShipValType = ct.ShipValType 
                    }
                    ).ToList();
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


        public IList<RefExgRatesDomainView> GetRefExgRates(int CMPY, string Currency, DateTime EffectDate)
        {
            try
            {
                using (IExpressUnitOfWork<RefExgRatesResult> uof = new ExpressUnitOfWork<RefExgRatesResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {   new SqlParameter("@CMPY", CMPY),
                              new SqlParameter("@Currency", Currency),
                              new SqlParameter("@EffectDate", EffectDate) };
                    var RefExgRates = (from Ag in uof.Reposotery.GetDataBySp("[Finance].[TLM_GetRefExgRates]", paraList)
                                       select new RefExgRatesDomainView
                                       {
                                           CMPY = Ag.CMPY,
                                           ClearanceCurrency = Ag.ClearanceCurrency,
                                           Currency = Ag.Currency,
                                           //Deleted = Ag.Deleted,
                                           EffectDate = Ag.EffectDate,
                                           ExgRate = Ag.ExgRate,
                                           //ExgRateTarif = Ag.ExgRateTarif,
                                           Remarks = Ag.Remarks,
                                           //USM_DATE = Ag.USM_DATE,
                                           //USM_ID = Ag.USM_ID,
                                       }).ToList();

                    return RefExgRates;
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

        public ResponseMessage ProcessManifestClearence(ManifestProcessParamDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@agnTrackNo",typePara.AgnTrackNo),
                        new SqlParameter("@company",typePara.CompanyID),
                        new SqlParameter("@agency",typePara.AgencyID),
                        new SqlParameter("@ClearTarrif" ,typePara.ClearenceTarif),
                        new SqlParameter("@ClearValue" , typePara.ClearenceValue ), 
                        new SqlParameter("@ClearanceCurrency" ,typePara.ClearanceCurr )
                       

                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_PreClearenceAWBProcess]", paraList)
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

        public IList<RptPreManifestDomainView> GetPreManifestReport(RptManifestParaDomainView _para)
        {
            try
            {

                using (IExpressUnitOfWork<RptManifestResult> uof = new ExpressUnitOfWork<RptManifestResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {
                           new SqlParameter("@CompanyID", _para.CompanyID  ),
                            new SqlParameter("@AgencyID" ,_para.AgencyId ),
                             new SqlParameter("@agnTrakNos" ,_para.TrakNumbers   ),
                              new SqlParameter("@fromDate" ,_para.FromDate  ),
                               new SqlParameter("@toDate" ,_para.ToDate ) ,
                                new SqlParameter("@ShipValType", _para.ShipValType)
                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetPreClearManifestReport]", paraList)
                                        select new RptPreManifestDomainView
                                        {
                                            SerialNo = SR.SerialNo,
                                            AirwaybilNo = SR.AirwaybilNo,
                                            RecieverName = SR.RecieverName,
                                            NoOfPkgs = SR.NoOfPkgs,
                                            TotWeight = SR.TotWeight,
                                            ShipValueFc = SR.ShipValueFc,
                                            ManCurrencyFc = SR.ManCurrencyFc,
                                            StationID = SR.StationID,
                                            Terms = SR.Terms,
                                            SenderReference = SR.SenderReference,                                          
                                            ShipValuLc = SR.ShipValuLc,
                                            ShipValType = SR.ShipValType,
                                            DutyValue = SR.DutyValue, 
                                            CompanyName = SR.CompanyName,
                                            AgencyName = SR.AgencyName,
                                            ShipDate = SR.ShipDate,
                                            FromDate = SR.FromDate ,
                                            ToDate = SR.ToDate  
                                            

                                        }).ToList();

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

