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
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using System.Globalization;
using System.Data.Entity;

namespace Express.Data.Operations.Manifest
{
    public class ManifestUploadData : IManifestUpload<ManifestUploadDomainView>
    {
        public ResponseMessage DeleteDetail(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ConsMasterDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {  new SqlParameter("@GroupId",typePara.GroupID), new SqlParameter("@CMPY",typePara.CMPY),new SqlParameter("@AgncyCode",typePara.AgncyCode),new SqlParameter("@AgencyId",typePara.AgncyID)
                              ,new SqlParameter("@ConsId",typePara.ConsId),new SqlParameter("@TransDate",typePara.TransDate),new SqlParameter("@VisaRootID",typePara.VisaRootID==null?"":typePara.VisaRootID),
                                  new SqlParameter("@FlightNo",typePara.FlightNo),new SqlParameter("@AriDate",typePara.AriDate),new SqlParameter("@DepDate",typePara.DepDate),new SqlParameter("@AriTime",typePara.AriTime),
                                  new SqlParameter("@DepTime",typePara.DepTime),  new SqlParameter("@Remarks",typePara.Remarks==null?"":typePara.Remarks), new SqlParameter("@MAWBNo",typePara.MAWBNo),
                                  new SqlParameter("@OrgHubID",typePara.OrgHubID==null?"":typePara.OrgHubID), new SqlParameter("@DesHubID",typePara.DesHubID==null?"":typePara.DesHubID),new SqlParameter("@AlNumCode",typePara.AlNumCode==null?"":typePara.AlNumCode),
                                 new SqlParameter("@Currency",typePara.Currency==null?"USD":typePara.Currency),
                                  new SqlParameter("@Delete",typePara.Deleted),new SqlParameter("@HighValue",typePara.HighValueY == true ? "Y" : ""),new SqlParameter("@TransMode",typePara.TransMode )
                                  ,new SqlParameter("@Mode" ,"U")};

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[USP_ManufestUploadEditConsMasterDetail]", paraList)
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

        public IList<ConsMasterDomainView> GetConsDetail(int CompanyId, int GroupId, int AgencyId, string TransDate, string Gate)
        {
            try
            {
                using (IExpressUnitOfWork<ConsoleMasterResult> uof = new ExpressUnitOfWork<ConsoleMasterResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@GroupId", GroupId) ,new SqlParameter("@CMPY", CompanyId) ,new SqlParameter("@AgncyCode",AgencyId)
                           ,new SqlParameter("@TransDate", TransDate),new SqlParameter("@Gate", Gate)  };
                    var OrgRegistryList = (from OC in uof.Reposotery.GetDataBySp("[Express].[TLM_GetonsDetail]", paraList)
                                           select new ConsMasterDomainView
                                           {
                                               CMPY = OC.CMPY,
                                               GroupID = OC.GroupID,
                                               AgncyCode = OC.AgncyCode,
                                               ConsId = OC.ConsId,
                                               MAWBNo = OC.MAWBNo,
                                               TransDate = OC.TransDate.Value,
                                               VisaRootID = OC.VisaRootID,
                                               FlightNo = OC.FlightNo,
                                               AriDate = OC.AriDate.Value,
                                               AriTime = OC.AriTime.Value,
                                               ShipType = OC.ShipType,
                                               DepDate = OC.DepDate.Value,
                                               DepTime = OC.DepTime.Value,
                                               Remarks = OC.Remarks,
                                               Deleted = OC.Deleted.Value,
                                               OrgHubID = OC.OrgHubID,
                                               DesHubID = OC.DesHubID,
                                               Currency = OC.Currency,
                                               AlNumCode = OC.AlNumCode,
                                               HighValueY = OC.HighValueY == "" ? true : false,
                                               TransMode = OC.TransMode,
                                               AgncyID = OC.AgncyID,
                                               ExpressCons = OC.ExpressCons,
                                               //ALActWgt=OC.ALActWgt,
                                               //ALChgWgt=OC.ALChgWgt,
                                               //AlFreightChg=OC.AlFreightChg.Value
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

        public string GetCountryCodeFromLocation(string HubId)
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadDomainView> GetDetails(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ManifestUploadDomainView> GetDetails(string code)
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
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetRefLocation]", paraList)
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
        public IList<OpsConsAWBDomainView> GetOpsConsAWBDetail3rd(int CompanyId, int GroupId, int AgencyId, string date)

        {
            try
            {
                using (IExpressUnitOfWork<AWBResult> uof = new ExpressUnitOfWork<AWBResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@GroupId", GroupId) ,new SqlParameter("@CMPY", CompanyId) ,new SqlParameter("@AgncyCode",AgencyId)
                           ,new SqlParameter("@TransDate", date) };
                    var OrgRegistryList = (from OCA in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAWBDetailbyDate]", paraList)
                                           select new OpsConsAWBDomainView
                                           {
                                               AgnAWBNo = OCA.AgnAWBNo,
                                               AgncyCode = OCA.AgncyCode.Value,
                                               AgnMpsNo = OCA.AgnMpsNo,
                                               AgnTrackNo = OCA.AgnTrackNo,
                                               AlertEmail1 = OCA.AlertEmail1,
                                               AlertEmail2 = OCA.AlertEmail2,
                                               AlertSms1 = OCA.AlertSms1,
                                               AlertSms2 = OCA.AlertSms2,
                                               BillDtaxAcNo = OCA.BillDtaxAcNo,
                                               BillDtaxChg = OCA.BillDtaxChg,
                                               BillTransAcNo = OCA.BillTransAcNo,
                                               BillTransChg = OCA.BillTransChg,
                                               BillTransChgY = OCA.BillTransChgY,
                                               BusDay14 = OCA.BusDay14.Value,
                                               CarriageVal = OCA.CarriageVal,
                                               CarriageValCur = OCA.CarriageValCur,
                                               CMPY = OCA.CMPY.Value,
                                               //ConsId = OCA.ConsId,
                                               CustomVal = OCA.CustomVal,
                                               CustomValCur = OCA.CustomValCur,
                                               Deleted = OCA.Deleted.Value,
                                               DeliverY = OCA.DeliverY,
                                               DepNotes = OCA.DepNotes,
                                               DESCOUNTRY = OCA.DESCOUNTRY,
                                               Descrip = OCA.Descrip,
                                               DESTIN = OCA.DESTIN,
                                               DimVol = OCA.DimVol,
                                               DimVolU = OCA.DimVolU,
                                               DocNdoc = OCA.DocNdoc,
                                               ExpressID = OCA.ExpressID,
                                               ExpressMpsNo = OCA.ExpressMpsNo.Value,
                                               FinComDate = OCA.FinComDate.Value,
                                               FinComTime = OCA.FinComTime.Value,
                                               GroupID = OCA.GroupID,
                                               HoldAtLoc = OCA.HoldAtLoc,
                                               IntComDate = OCA.IntComDate.Value,
                                               IntComTime = OCA.IntComTime.Value,
                                               InvNoTransChg = OCA.InvNoTransChg,
                                               LastScanDate = OCA.LastScanDate.Value,
                                               LastScanTypeS = OCA.LastScanTypeS,
                                               LatePkg = OCA.LatePkg,
                                               MisScan = OCA.MisScan,
                                               MissRoute = OCA.MissRoute,
                                               ORGCOUNTRY = OCA.ORGCOUNTRY,
                                               ORIGIN = OCA.ORIGIN,
                                               PackType = OCA.PackType,
                                               PickScanTypeS = OCA.PickScanTypeS,
                                               PickupY = OCA.PickupY,
                                               PodScanTypeS = OCA.PodScanTypeS,
                                               PodYN = OCA.PodYN,
                                               RecAccount = OCA.RecAccount,
                                               RecAddr1 = OCA.RecAddr1,
                                               RecAddr2 = OCA.RecAddr2,
                                               RecCity = OCA.RecCity.Value,
                                               RecCityN = OCA.RecCityN,
                                               RecCode = OCA.RecCode,
                                               RecCompany = OCA.RecCompany,
                                               RecCountry = OCA.RecCountry,
                                               RecName = OCA.RecName,
                                               RecPhone = OCA.RecPhone,
                                               RecState = OCA.RecState,
                                               RecZip = OCA.RecZip,
                                               Remarks = OCA.Remarks,
                                               RWDL = OCA.RWDL,
                                               ScanGap = OCA.ScanGap,
                                               ScansAll = OCA.ScansAll,
                                               SenAccount = OCA.SenAccount,
                                               SenAddr1 = OCA.SenAddr1,
                                               SenAddr2 = OCA.SenAddr2,
                                               SenCity = OCA.SenCity.Value,
                                               SenCityN = OCA.SenCityN,
                                               SenCode = OCA.SenCode,
                                               SenCompany = OCA.SenCompany,
                                               SenCountry = OCA.SenCountry,
                                               SenID = OCA.SenID,
                                               SenName = OCA.SenName,
                                               SenPhone = OCA.SenPhone,
                                               SenRefNotes = OCA.SenRefNotes,
                                               SenState = OCA.SenState,
                                               SenZip = OCA.SenZip,
                                               ShipDate = OCA.ShipDate.Value,
                                               ShipLocationType = OCA.ShipLocationType,
                                               ShipType = OCA.ShipType,
                                               slockcode = OCA.slockcode,
                                               SpCode = OCA.SpCode,
                                               SvcType = OCA.SvcType,
                                               TotPkgs = OCA.TotPkgs.Value,
                                               TotWgt = OCA.TotWgt,
                                               TrackClosedY = OCA.TrackClosedY,
                                               TransDate = OCA.TransDate.Value,
                                               USM_DATE = OCA.USM_DATE.Value,
                                               USM_LOGIN = OCA.USM_LOGIN,
                                               WgtU = OCA.WgtU,
                                               MHEPackType = OCA.MHEPackType,
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
        public IList<OpsConsAWBDomainView> GetOpsConsAWBDetail(int CompanyId, int GroupId, int AgencyId, string ConsId)
        {
            try
            {
                using (IExpressUnitOfWork<AWBResult> uof = new ExpressUnitOfWork<AWBResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@GroupId", GroupId) ,new SqlParameter("@CMPY", CompanyId) ,new SqlParameter("@AgncyCode",AgencyId)
                           ,new SqlParameter("@ExpConsNo", ConsId) };
                    var OrgRegistryList = (from OCA in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAWBDetail]", paraList)
                                           select new OpsConsAWBDomainView
                                           {
                                               AgnAWBNo = OCA.AgnAWBNo,
                                               AgncyCode = OCA.AgncyCode.Value,
                                               AgnMpsNo = OCA.AgnMpsNo,
                                               AgnTrackNo = OCA.AgnTrackNo,
                                               AlertEmail1 = OCA.AlertEmail1,
                                               AlertEmail2 = OCA.AlertEmail2,
                                               AlertSms1 = OCA.AlertSms1,
                                               AlertSms2 = OCA.AlertSms2,
                                               BillDtaxAcNo = OCA.BillDtaxAcNo,
                                               BillDtaxChg = OCA.BillDtaxChg,
                                               BillTransAcNo = OCA.BillTransAcNo,
                                               BillTransChg = OCA.BillTransChg,
                                               BillTransChgY = OCA.BillTransChgY,
                                               BusDay14 = OCA.BusDay14.Value,
                                               CarriageVal = OCA.CarriageVal,
                                               CarriageValCur = OCA.CarriageValCur,
                                               CMPY = OCA.CMPY.Value,
                                               ConsId = OCA.ConsId,
                                               CustomVal = OCA.CustomVal,
                                               CustomValCur = OCA.CustomValCur,
                                               Deleted = OCA.Deleted.Value,
                                               DeliverY = OCA.DeliverY,
                                               DepNotes = OCA.DepNotes,
                                               DESCOUNTRY = OCA.DESCOUNTRY,
                                               Descrip = OCA.Descrip,
                                               DESTIN = OCA.DESTIN,
                                               DimVol = OCA.DimVol,
                                               DimVolU = OCA.DimVolU,
                                               DocNdoc = OCA.DocNdoc,
                                               ExpressID = OCA.ExpressID,
                                               ExpressMpsNo = OCA.ExpressMpsNo.Value,
                                               FinComDate = OCA.FinComDate.Value,
                                               FinComTime = OCA.FinComTime.Value,
                                               GroupID = OCA.GroupID,
                                               HoldAtLoc = OCA.HoldAtLoc,
                                               IntComDate = OCA.IntComDate.Value,
                                               IntComTime = OCA.IntComTime.Value,
                                               InvNoTransChg = OCA.InvNoTransChg,
                                               LastScanDate = OCA.LastScanDate.Value,
                                               LastScanTypeS = OCA.LastScanTypeS,
                                               LatePkg = OCA.LatePkg,
                                               MisScan = OCA.MisScan,
                                               MissRoute = OCA.MissRoute,
                                               ORGCOUNTRY = OCA.ORGCOUNTRY,
                                               ORIGIN = OCA.ORIGIN,
                                               PackType = OCA.PackType,
                                               PickScanTypeS = OCA.PickScanTypeS,
                                               PickupY = OCA.PickupY,
                                               PodScanTypeS = OCA.PodScanTypeS,
                                               PodYN = OCA.PodYN,
                                               RecAccount = OCA.RecAccount,
                                               RecAddr1 = OCA.RecAddr1,
                                               RecAddr2 = OCA.RecAddr2,
                                               RecCity = OCA.RecCity.Value,
                                               RecCityN = OCA.RecCityN,
                                               RecCode = OCA.RecCode,
                                               RecCompany = OCA.RecCompany,
                                               RecCountry = OCA.RecCountry,
                                               RecName = OCA.RecName,
                                               RecPhone = OCA.RecPhone,
                                               RecState = OCA.RecState,
                                               RecZip = OCA.RecZip,
                                               Remarks = OCA.Remarks,
                                               RWDL = OCA.RWDL,
                                               ScanGap = OCA.ScanGap,
                                               ScansAll = OCA.ScansAll,
                                               SenAccount = OCA.SenAccount,
                                               SenAddr1 = OCA.SenAddr1,
                                               SenAddr2 = OCA.SenAddr2,
                                               SenCity = OCA.SenCity.Value,
                                               SenCityN = OCA.SenCityN,
                                               SenCode = OCA.SenCode,
                                               SenCompany = OCA.SenCompany,
                                               SenCountry = OCA.SenCountry,
                                               SenID = OCA.SenID,
                                               SenName = OCA.SenName,
                                               SenPhone = OCA.SenPhone,
                                               SenRefNotes = OCA.SenRefNotes,
                                               SenState = OCA.SenState,
                                               SenZip = OCA.SenZip,
                                               ShipDate = OCA.ShipDate.Value,
                                               ShipLocationType = OCA.ShipLocationType,
                                               ShipType = OCA.ShipType,
                                               slockcode = OCA.slockcode,
                                               SpCode = OCA.SpCode,
                                               SvcType = OCA.SvcType,
                                               TotPkgs = OCA.TotPkgs.Value,
                                               TotWgt = OCA.TotWgt,
                                               TrackClosedY = OCA.TrackClosedY,
                                               TransDate = OCA.TransDate.Value,
                                               USM_DATE = OCA.USM_DATE.Value,
                                               USM_LOGIN = OCA.USM_LOGIN,
                                               WgtU = OCA.WgtU,
                                               MHEPackType = OCA.MHEPackType,
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

        public ResponseMessage SaveFedexAwbList(ManifestUploadWrappingDomain typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {

                    string xmlString = "<ROOT>";
                    foreach (var item in typePara.AwbList)
                    {

                        xmlString = xmlString + "<ROW>"
                        + "<Deleted>" + item.Deleted + "</Deleted>"
                        + "<GroupID>" + item.GroupID + "</GroupID>"
                        + "<CMPY>" + item.CMPY + "</CMPY>"
                        + "<AgncyCode>" + item.AgncyCode + "</AgncyCode>"
                        + "<AgncyIdNo>" + item.AgncyID + "</AgncyIdNo>"
                        + "<ORIGINGate>" + item.ORIGINGate + "</ORIGINGate>"
                        + "<DESTINGate>" + item.DESTINGate + "</DESTINGate>"
                        + "<ConsId>" + item.ConsId + "</ConsId>"
                        + "<ExpressCons>" + item.ExpressCons + "</ExpressCons>"
                        + "<TransDate>"+ item.TransDate.Year + "-" + item.TransDate.Month + "-" + item.TransDate.Day + "</TransDate>"
                        + "<OriginHubId>" + item.ORIGINGate + "</OriginHubId>"
                        + "<DestinationHubId>" + item.DESTINGate + "</DestinationHubId>"
                        + "<LocalCountyCode>" + item.LocalCountyCode + "</LocalCountyCode>"
                        + "<ShipType>" + item.ShipType + "</ShipType>"
                        + "<TransMode>" + item.TransMode + "</TransMode>"
                        + "<MissRoute>" + item.MissRoute + "</MissRoute> "
                        + "<ExpressID>" + item.ExpressID + "</ExpressID>"
                        + "<ExpressMpsNo>" + item.ExpressMpsNo + "</ExpressMpsNo>"
                        + "<AgnAWBNo>" + item.AgnAWBNo + "</AgnAWBNo>"
                        + "<AgnMpsNo>" + item.AgnMpsNo + "</AgnMpsNo>"
                        + "<AgnTrackNo>" + item.AgnTrackNo + "</AgnTrackNo>"
                        + "<ORIGIN>" + item.ORIGIN + "</ORIGIN>"
                        + "<DESTIN>" + item.DESTIN + "</DESTIN>"
                        + "<ORGCOUNTRY>" + item.ORGCOUNTRY + "</ORGCOUNTRY>"
                        + "<DESCOUNTRY>" + item.DESCOUNTRY + "</DESCOUNTRY>"
                        //+ "<OrignLoc>" + item.OrignLoc + "</OrignLoc>"
                        //+ "<DestinLoc>" + item.DestinLoc + "</DestinLoc>"
                        + "<ShipDate>"+ item.ShipDate.Year + "-" + item.ShipDate.Month + "-" + item.ShipDate.Day + "</ShipDate>"
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
                        + "<RexWgt>" + item.RexWgt + "</RexWgt>"
                        + "<RexWgtU>" + item.RexWgtU + "</RexWgtU>"
                        + "<RexVol>" + item.RexVol + "</RexVol>"
                        + "<RexVolu>" + item.RexVol + "</RexVolu>"
                        + "<DimVol>" + item.DimVol + "</DimVol>"
                        + "<DimVolU>" + item.DimVolU + "</DimVolU>"
                        + "<CarriageVal>" + item.CarriageVal + "</CarriageVal>"
                        + "<CarriageValCur>" + item.CarriageValCur + "</CarriageValCur>"
                        //+ "<Rexwgt>" + item.Rexwgt + "</Rexwgt>"
                        //+ "<rexwgtu>" + item.rexwgtu + "</rexwgtu>"

                        + "<CustomVal>" + item.CustomVal + "</CustomVal>"
                        + "<CustomValCur>" + item.CustomValCur + "</CustomValCur>"
                        + "<Descrip>" + UnescapeXml(item.Descrip) + "</Descrip>"
                        + "<SenRefNotes>" + UnescapeXml(item.SenRefNotes) + "</SenRefNotes>"
                        + "<DepNotes>" + UnescapeXml(item.DepNotes) + "</DepNotes>"
                        + "<DocNdoc>" + item.DocNdoc + "</DocNdoc>"
                        + "<HoldAtLoc>" + item.HoldAtLoc + "</HoldAtLoc>"
                        + "<BillTransChg>" + item.BillTransChg + "</BillTransChg>"
                        + "<BillTransAcNo>" + item.BillTransAcNo + "</BillTransAcNo>"
                        + "<BillDtaxChg>" + item.BillDtaxChg + "</BillDtaxChg>"
                        + "<BillDtaxAcNo>" + item.BillDtaxAcNo + "</BillDtaxAcNo>"
                        //+ "<AlertEmail1>" + UnescapeXml(item.AlertEmail1) + "</AlertEmail1>"
                        //+ "<AlertEmail2>" + UnescapeXml(item.AlertEmail2) + "</AlertEmail2>"
                        //+ "<AlertSms1>" + item.AlertSms1 + "</AlertSms1>"
                        //+ "<AlertSms2>" + item.AlertSms2 + "</AlertSms2>"
                        + "<IntComDate>" + item.IntComDate.Year+ "-" + item.IntComDate.Month + "-" + item.IntComDate.Day + "</IntComDate>"
                        + "<IntComTime>" + item.IntComTime + "</IntComTime>"
                        + "<FinComDate>" + item.FinComDate.Year + "-" + item.FinComDate.Month+ "-" + item.FinComDate.Day + "</FinComDate>"
                        + "<FinComTime>" + item.FinComTime + "</FinComTime>"
                        //+ "<TrackClosedY>" + item.TrackClosedY + "</TrackClosedY>"
                        //+ "<PickupY>" + item.PickupY + "</PickupY>"
                        //+ "<DeliverY>" + item.DeliverY + "</DeliverY>"
                        //+ "<PickScanTypeS>" + item.PickScanTypeS + "</PickScanTypeS>"
                        //+ "<PodScanTypeS>" + item.PodScanTypeS + "</PodScanTypeS>"
                        //+ "<LastScanTypeS>" + item.LastScanTypeS + "</LastScanTypeS>"
                        //+ "<LastScanDate>" + item.LastScanDate + "</LastScanDate>"
                        + "<LatePkg>" + item.PickScanTypeS + "</LatePkg>"
                        + "<RWDL>" + item.RWDL + "</RWDL>"
                        + "<BusDay14>" + item.BusDay14 + "</BusDay14>"
                        //+ "<ScanGap>" + item.ScanGap + "</ScanGap>"
                        //+ "<MisScan>" + item.MisScan + "</MisScan>"
                        //+ "<PodYN>" + item.PodYN + "</PodYN>"
                        //+ "<slockcode>" + item.slockcode + "</slockcode>"
                        //+ "<SpCode>" + item.SpCode + "</SpCode>"
                        + "<Remarks>" + item.Remarks + "</Remarks>"
                        + "<USM_LOGIN>" + item.USM_LOGIN + "</USM_LOGIN>"
                        + "<USM_DATE>" + item.USM_DATE.Year + "-" + item.USM_DATE.Month + "-" + item.USM_DATE.Day + "</USM_DATE>"
                        + "<BillTransChgY>" + item.BillTransChgY + "</BillTransChgY>"
                        + "<InvNoTransChg>" + item.InvNoTransChg + "</InvNoTransChg>"
                        + "<ScansAll>" + item.ScansAll + "</ScansAll>"
                        + "<MHEPackType>" + item.MHEPackType + "</MHEPackType>"
                        + "</ROW>";
                    }
                    xmlString = xmlString + "</ROOT>";

                    SqlParameter[] paraList = new SqlParameter[]
                              {new SqlParameter("@Mode","I"),
                                  new SqlParameter("@xmlDataValue",xmlString) };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_ManifestUploadFedexAWBDetail]", paraList)
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

     
        public ResponseMessage SaveTntAwbList(ManifestUploadWrappingDomain typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {

                    string xmlString = "<ROOT>";
                    foreach (var item in typePara.AwbList)
                    {

                        xmlString = xmlString + "<ROW>"
                        + "<Deleted>" + item.Deleted + "</Deleted>"
                        + "<GroupID>" + item.GroupID + "</GroupID>"
                        + "<CMPY>" + item.CMPY + "</CMPY>"
                        + "<AgncyCode>" + item.AgncyCode + "</AgncyCode>"
                        + "<AgncyIdNo>" + item.AgncyID + "</AgncyIdNo>"
                        + "<ORIGINGate>" + item.ORIGINGate + "</ORIGINGate>"
                        + "<DESTINGate>" + item.DESTINGate + "</DESTINGate>"
                        + "<ConsId>" + item.ConsId + "</ConsId>"
                        + "<ExpressCons>" + item.ExpressCons + "</ExpressCons>"
                        + "<TransDate>" + item.TransDate.Year + "-" + item.TransDate.Month + "-" + item.TransDate.Day+ "</TransDate>"
                        + "<OriginHubId>" + item.ORIGINGate + "</OriginHubId>"
                        + "<DestinationHubId>" + item.DESTINGate + "</DestinationHubId>"
                        + "<LocalCountyCode>" + item.LocalCountyCode + "</LocalCountyCode>"
                        + "<ShipType>" + item.ShipType + "</ShipType>"
                        + "<TransMode>" + item.TransMode + "</TransMode>"
                        + "<MissRoute>" + item.MissRoute + "</MissRoute> "
                        + "<ExpressID>" + item.ExpressID + "</ExpressID>"
                        + "<ExpressMpsNo>" + item.ExpressMpsNo + "</ExpressMpsNo>"
                        + "<AgnAWBNo>" + item.AgnAWBNo + "</AgnAWBNo>"
                        + "<AgnMpsNo>" + item.AgnMpsNo + "</AgnMpsNo>"
                        + "<AgnTrackNo>" + item.AgnTrackNo + "</AgnTrackNo>"
                        + "<ORIGIN>" + item.ORIGIN + "</ORIGIN>"
                        + "<DESTIN>" + item.DESTIN + "</DESTIN>"
                        + "<ORGCOUNTRY>" + item.ORGCOUNTRY + "</ORGCOUNTRY>"
                        + "<DESCOUNTRY>" + item.DESCOUNTRY + "</DESCOUNTRY>"
                        //+ "<OrignLoc>" + item.OrignLoc + "</OrignLoc>"
                        //+ "<DestinLoc>" + item.DestinLoc + "</DestinLoc>"
                        + "<ShipDate>" + item.ShipDate.Year + "-" + item.ShipDate.Month + "-" + item.ShipDate.Day + "</ShipDate>"
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
                        + "<RexWgt>" + item.RexWgt + "</RexWgt>"
                        + "<RexWgtU>" + item.RexWgtU + "</RexWgtU>"
                        + "<RexVol>" + item.RexVol + "</RexVol>"
                        + "<RexVolu>" + item.RexVol + "</RexVolu>"
                        + "<DimVol>" + item.DimVol + "</DimVol>"
                        + "<DimVolU>" + item.DimVolU + "</DimVolU>"
                        + "<CarriageVal>" + item.CarriageVal + "</CarriageVal>"
                        + "<CarriageValCur>" + item.CarriageValCur + "</CarriageValCur>"
                        //+ "<Rexwgt>" + item.Rexwgt + "</Rexwgt>"
                        //+ "<rexwgtu>" + item.rexwgtu + "</rexwgtu>"

                        + "<CustomVal>" + item.CustomVal + "</CustomVal>"
                        + "<CustomValCur>" + item.CustomValCur + "</CustomValCur>"
                        + "<Descrip>" + UnescapeXml(item.Descrip) + "</Descrip>"
                        + "<SenRefNotes>" + UnescapeXml(item.SenRefNotes) + "</SenRefNotes>"
                        + "<DepNotes>" + UnescapeXml(item.DepNotes) + "</DepNotes>"
                        + "<DocNdoc>" + item.DocNdoc + "</DocNdoc>"
                        + "<HoldAtLoc>" + item.HoldAtLoc + "</HoldAtLoc>"
                        + "<BillTransChg>" + item.BillTransChg + "</BillTransChg>"
                        + "<BillTransAcNo>" + item.BillTransAcNo + "</BillTransAcNo>"
                        + "<BillDtaxChg>" + item.BillDtaxChg + "</BillDtaxChg>"
                        + "<BillDtaxAcNo>" + item.BillDtaxAcNo + "</BillDtaxAcNo>"
                        //+ "<AlertEmail1>" + UnescapeXml(item.AlertEmail1) + "</AlertEmail1>"
                        //+ "<AlertEmail2>" + UnescapeXml(item.AlertEmail2) + "</AlertEmail2>"
                        //+ "<AlertSms1>" + item.AlertSms1 + "</AlertSms1>"
                        //+ "<AlertSms2>" + item.AlertSms2 + "</AlertSms2>"
                        + "<IntComDate>" + item.IntComDate.Year + "-" + item.IntComDate.Month + "-" + item.IntComDate.Day + "</IntComDate>"
                        + "<IntComTime>" + item.IntComTime + "</IntComTime>"
                        + "<FinComDate>" + item.FinComDate.Year + "-" + item.FinComDate.Month + "-" + item.FinComDate.Day + "</FinComDate>"
                        + "<FinComTime>" + item.FinComTime + "</FinComTime>"
                        //+ "<TrackClosedY>" + item.TrackClosedY + "</TrackClosedY>"
                        //+ "<PickupY>" + item.PickupY + "</PickupY>"
                        //+ "<DeliverY>" + item.DeliverY + "</DeliverY>"
                        //+ "<PickScanTypeS>" + item.PickScanTypeS + "</PickScanTypeS>"
                        //+ "<PodScanTypeS>" + item.PodScanTypeS + "</PodScanTypeS>"
                        //+ "<LastScanTypeS>" + item.LastScanTypeS + "</LastScanTypeS>"
                        //+ "<LastScanDate>" + item.LastScanDate + "</LastScanDate>"
                        + "<LatePkg>" + item.PickScanTypeS + "</LatePkg>"
                        + "<RWDL>" + item.RWDL + "</RWDL>"
                        + "<BusDay14>" + item.BusDay14 + "</BusDay14>"
                        //+ "<ScanGap>" + item.ScanGap + "</ScanGap>"
                        //+ "<MisScan>" + item.MisScan + "</MisScan>"
                        //+ "<PodYN>" + item.PodYN + "</PodYN>"
                        //+ "<slockcode>" + item.slockcode + "</slockcode>"
                        //+ "<SpCode>" + item.SpCode + "</SpCode>"
                        + "<Remarks>" + item.Remarks + "</Remarks>"
                        + "<USM_LOGIN>" + item.USM_LOGIN + "</USM_LOGIN>"
                        + "<USM_DATE>" + item.USM_DATE.Year + "-" + item.USM_DATE.Month + "-" + item.USM_DATE.Day + "</USM_DATE>"
                        + "<BillTransChgY>" + item.BillTransChgY + "</BillTransChgY>"
                        + "<InvNoTransChg>" + item.InvNoTransChg + "</InvNoTransChg>"
                        + "<ScansAll>" + item.ScansAll + "</ScansAll>"
                        + "<MHEPackType>" + item.MHEPackType + "</MHEPackType>"
                        + "</ROW>";
                    }
                    xmlString = xmlString + "</ROOT>";

                    SqlParameter[] paraList = new SqlParameter[]
                              {new SqlParameter("@Mode","I"),
                                  new SqlParameter("@xmlDataValue",xmlString) };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_ManufestUploadTntAwbDetails]", paraList)
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

        public ResponseMessage SaveCons(ConsMasterDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {  new SqlParameter("@GroupId",typePara.GroupID),
                                  new SqlParameter("@CMPY",typePara.CMPY),
                                  new SqlParameter("@AgncyCode",typePara.AgncyCode),
                                  new SqlParameter("@AgencyId",typePara.AgncyID),
                                  new SqlParameter("@ConsId",typePara.ConsId),
                                  new SqlParameter("@TransDate",typePara.TransDate),
                                  new SqlParameter("@VisaRootID",typePara.VisaRootID==null?"":typePara.VisaRootID),
                                  new SqlParameter("@FlightNo",typePara.FlightNo),
                                  new SqlParameter("@AriDate",typePara.AriDate),
                                  new SqlParameter("@DepDate",typePara.DepDate),
                                  new SqlParameter("@AriTime",typePara.AriTime),
                                  new SqlParameter("@DepTime",typePara.DepTime),
                                  new SqlParameter("@Remarks",typePara.Remarks==null?"":typePara.Remarks),
                                  new SqlParameter("@MAWBNo",typePara.MAWBNo),
                                  new SqlParameter("@OrgHubID",typePara.OrgHubID==null?"":typePara.OrgHubID),
                                  new SqlParameter("@DesHubID",typePara.DesHubID==null?"":typePara.DesHubID),
                                  new SqlParameter("@AlNumCode",typePara.AlNumCode==null?"":typePara.AlNumCode),
                                  new SqlParameter("@Currency",typePara.Currency==null?"USD":typePara.Currency),
                                  new SqlParameter("@Delete",typePara.Deleted),
                                  new SqlParameter("@HighValue",typePara.HighValueY),
                                  new SqlParameter("@TransMode",typePara.TransMode ),
                                   new SqlParameter("@ShipType",typePara.ShipType ),
                                  new SqlParameter("@Mode" ,"I")};

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_ManifestConsAddEditDetail]", paraList)
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

        public ResponseMessage SaveDetails(ManifestUploadDomainView typePara)
        {
            throw new NotImplementedException();
        }

        private DateTime BuildDateTimeFromYAFormat(string dateString)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(dateString, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
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

        public IList<OpsConsAWBDomainView> GetOpsAWBDetailFromDupliacte(int CompanyId, int AgencyId, string ConsId)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<GetAWBDuplicateResult> uof = new ExpressUnitOfWork<GetAWBDuplicateResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                         {  new SqlParameter("@ConsID", ConsId) ,new SqlParameter("@CMPY", CompanyId) ,new SqlParameter("@agecnyID",AgencyId)};
                    var AwbList = (from OCA in uof.Reposotery.GetDataBySp("[Express].[Usp_GetAWBDuplicateList]", paraList)
                                   select new OpsConsAWBDomainView
                                   {
                                       AgnAWBNo = OCA.AgnAWBNo,
                                       AgncyCode = OCA.AgncyCode,
                                       AgnMpsNo = OCA.AgnMpsNo,
                                       AgnTrackNo = OCA.AgnTrackNo,
                                       AlertEmail1 = OCA.AlertEmail1,
                                       AlertEmail2 = OCA.AlertEmail2,
                                       AlertSms1 = OCA.AlertSms1,
                                       AlertSms2 = OCA.AlertSms2,
                                       BillDtaxAcNo = OCA.BillDtaxAcNo,
                                       BillDtaxChg = OCA.BillDtaxChg,
                                       BillTransAcNo = OCA.BillTransAcNo,
                                       BillTransChg = OCA.BillTransChg,
                                       BillTransChgY = OCA.BillTransChgY,
                                       BusDay14 = OCA.BusDay14,
                                       CarriageVal = OCA.CarriageVal,
                                       CarriageValCur = OCA.CarriageValCur,
                                       CMPY = OCA.CMPY,
                                       ConsId = OCA.ConsId,
                                       CustomVal = OCA.CustomVal,
                                       CustomValCur = OCA.CustomValCur,
                                       Deleted = OCA.Deleted,
                                       DeliverY = OCA.DeliverY,
                                       DepNotes = OCA.DepNotes,
                                       DESCOUNTRY = OCA.DESCOUNTRY,
                                       Descrip = OCA.Descrip,
                                       DESTIN = OCA.DESTIN,
                                       DimVol = OCA.DimVol,
                                       DimVolU = OCA.DimVolU,
                                       DocNdoc = OCA.DocNdoc,
                                       ExpressID = OCA.ExpressID,
                                       ExpressMpsNo = OCA.ExpressMpsNo,
                                       FinComDate = OCA.FinComDate,
                                       FinComTime = OCA.FinComTime,
                                       GroupID = OCA.GroupID,
                                       HoldAtLoc = OCA.HoldAtLoc,
                                       IntComDate = OCA.IntComDate,
                                       IntComTime = OCA.IntComTime,
                                       InvNoTransChg = OCA.InvNoTransChg,
                                       LastScanDate = OCA.LastScanDate,
                                       LastScanTypeS = OCA.LastScanTypeS,
                                       LatePkg = OCA.LatePkg,
                                       MisScan = OCA.MisScan,
                                       MissRoute = OCA.MissRoute,
                                       ORGCOUNTRY = OCA.ORGCOUNTRY,
                                       ORIGIN = OCA.ORIGIN,
                                       PackType = OCA.PackType,
                                       PickScanTypeS = OCA.PickScanTypeS,
                                       PickupY = OCA.PickupY,
                                       PodScanTypeS = OCA.PodScanTypeS,
                                       PodYN = OCA.PodYN,
                                       RecAccount = OCA.RecAccount,
                                       RecAddr1 = OCA.RecAddr1,
                                       RecAddr2 = OCA.RecAddr2,
                                       RecCityN = OCA.RecCityN,
                                       RecCode = OCA.RecCode,
                                       RecCompany = OCA.RecCompany,
                                       RecCountry = OCA.RecCountry,
                                       RecName = OCA.RecName,
                                       RecPhone = OCA.RecPhone,
                                       RecState = OCA.RecState,
                                       RecZip = OCA.RecZip,
                                       Remarks = OCA.Remarks,
                                       RWDL = OCA.RWDL,
                                       ScanGap = OCA.ScanGap,
                                       ScansAll = OCA.ScansAll,
                                       SenAccount = OCA.SenAccount,
                                       SenAddr1 = OCA.SenAddr1,
                                       SenAddr2 = OCA.SenAddr2,
                                       SenCityN = OCA.SenCityN,
                                       SenCode = OCA.SenCode,
                                       SenCompany = OCA.SenCompany,
                                       SenCountry = OCA.SenCountry,
                                       SenID = OCA.SenID,
                                       SenName = OCA.SenName,
                                       SenPhone = OCA.SenPhone,
                                       SenRefNotes = OCA.SenRefNotes,
                                       SenState = OCA.SenState,
                                       SenZip = OCA.SenZip,
                                       ShipDate = OCA.ShipDate,
                                       ShipLocationType = OCA.ShipLocationType,
                                       ShipType = OCA.ShipType,
                                       slockcode = OCA.slockcode,
                                       SpCode = OCA.SpCode,
                                       SvcType = OCA.SvcType,
                                       TotPkgs = OCA.TotPkgs,
                                       TotWgt = OCA.TotWgt,
                                       TrackClosedY = OCA.TrackClosedY,
                                       TransDate = OCA.TransDate,
                                       USM_DATE = OCA.USM_DATE,
                                       USM_LOGIN = OCA.USM_LOGIN,
                                       WgtU = OCA.WgtU,
                                       MHEPackType = OCA.MHEPackType,
                                   }).ToList();


                    return AwbList;
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
