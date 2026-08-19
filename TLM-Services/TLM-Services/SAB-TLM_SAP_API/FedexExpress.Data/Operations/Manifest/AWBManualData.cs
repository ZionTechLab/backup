using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.Operations.Manifest
{
    public class AWBManualData: IAWBManual
    {
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







        public IList<CountryDomainView> GetCountryList(string CountryCode)
        {
            try
            {
                using (IExpressUnitOfWork<CountryResult> uof = new ExpressUnitOfWork<CountryResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CountryCode", CountryCode) };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetCountryList]", paraList)
                                           select new CountryDomainView
                                           {
                                               CountryCode = Ag.Country,
                                               CountryName = Ag.CountryN,
                                             

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





        public IList<CityDomainView> GetCityList(string CountryCode,string CityCode)
        {
            try
            {
                using (IExpressUnitOfWork<CityResult> uof = new ExpressUnitOfWork<CityResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@CountryCode", CountryCode)
                            ,new SqlParameter("@CityCode",CityCode)};

                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetCityList]", paraList)
                                           select new CityDomainView
                                           {
                                               CityID = Ag.CityID,
                                               CityCode = Ag.CityCode,
                                               CityName = Ag.CityN,
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





        public IList<ServiceDominView> GetServiceList(string AgencyCode,string ServiceCode)
        {
            try
            {
                using (IExpressUnitOfWork<ServiceResult> uof = new ExpressUnitOfWork<ServiceResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@AgencyCode", AgencyCode),
                           new SqlParameter("@ServiceCode", ServiceCode),
                          };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetServiceList]", paraList)
                                           select new ServiceDominView
                                           {

                                               ServiceCode = Ag.SvcType,
                                               ServiceName = Ag.SvcTypeN,
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






        public IList<PackageDomainView> GetPackageList(string AgencyCode,string PackageCode)
        {
            try
            {
                using (IExpressUnitOfWork<PackageResult> uof = new ExpressUnitOfWork<PackageResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@AgencyCode", AgencyCode),
                           new SqlParameter("@PackageCode", PackageCode) };
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetPackagesList]", paraList)
                                           select new PackageDomainView
                                           {
                                               PackageCode = Ag.PackType,
                                               PackageName = Ag.PackTypeN
                                           
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







        public ResponseMessage SaveAWBD(AWBDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {

                                    new SqlParameter("@Deleted",typePara.Deleted)
                                   ,new SqlParameter("@GroupID",typePara.GroupID)
                                   ,new SqlParameter("@CMPY",typePara.CMPY)
                                   ,new SqlParameter("@AgncyCode",typePara.AgncyCode)
                                   ,new SqlParameter("@AgncyID",typePara.AgncyID)
                                   ,new SqlParameter("@ORIGINGate",typePara.ORIGINGate)
                                   ,new SqlParameter("@DESTINGate",typePara.DESTINGate)
                                   //,new SqlParameter("@GateWayID",typePara.GateWayID)
                                   //,new SqlParameter("@StationID",typePara.StationID)
                                   //,new SqlParameter("@RouteID",typePara.RouteID)
                                   ,new SqlParameter("@ConsId",typePara.ConsId)
                                   ,new SqlParameter("@TransDate",typePara.TransDate)
                                   ,new SqlParameter("@ShipType",typePara.ShipType)
                                   ,new SqlParameter("@TransMode",typePara.TransMode)
                                   ,new SqlParameter("@ExpressID",typePara.ExpressID)
                                   ,new SqlParameter("@ExpressMpsNo",typePara.ExpressMpsNo)
                                   ,new SqlParameter("@AgnAWBNo",typePara.AgnAWBNo)
                                   ,new SqlParameter("@AgnMpsNo",typePara.AgnMpsNo)
                                   ,new SqlParameter("@AgnTrackNo",typePara.AgnTrackNo)
                                   ,new SqlParameter("@ORIGIN",typePara.ORIGIN)
                                   ,new SqlParameter("@DESTIN",typePara.DESTIN)
                                   ,new SqlParameter("@ORGCOUNTRY",typePara.ORGCOUNTRY)
                                   ,new SqlParameter("@DESCOUNTRY",typePara.DESCOUNTRY)
                                   ,new SqlParameter("@ShipDate",typePara.ShipDate)
                                   //,new SqlParameter("@ShipLocationType",typePara.ShipLocationType)
                                   ,new SqlParameter("@SenAccount",typePara.SenAccount)
                                   ,new SqlParameter("@SenPhone",typePara.SenPhone)
                                   ,new SqlParameter("@SenCountry",typePara.SenCountry)
                                   ,new SqlParameter("@SenCode",typePara.SenCode)
                                   ,new SqlParameter("@SenCompany",typePara.SenCompany)
                                   ,new SqlParameter("@SenID",typePara.SenID)
                                   ,new SqlParameter("@SenName",typePara.SenName)
                                   ,new SqlParameter("@SenAddr1",typePara.SenAddr1)
                                   ,new SqlParameter("@SenAddr2",typePara.SenAddr2)
                                   ,new SqlParameter("@SenCity",typePara.SenCity)
                                   ,new SqlParameter("@SenCityN",typePara.SenCityN)
                                   ,new SqlParameter("@SenState",typePara.SenState)
                                   ,new SqlParameter("@SenZip",typePara.SenZip)
                                   ,new SqlParameter("@RecAccount",typePara.RecAccount)
                                   ,new SqlParameter("@RecPhone",typePara.RecPhone)
                                   ,new SqlParameter("@RecCountry",typePara.RecCountry)
                                   ,new SqlParameter("@RecCode",typePara.RecCode)
                                   ,new SqlParameter("@RecCompany",typePara.RecCompany)
                                   ,new SqlParameter("@RecName",typePara.RecName)
                                   ,new SqlParameter("@RecAddr1",typePara.RecAddr1)
                                   ,new SqlParameter("@RecAddr2",typePara.RecAddr2)
                                   ,new SqlParameter("@RecCity",typePara.RecCity)
                                   ,new SqlParameter("@RecCityN",typePara.RecCityN)
                                   ,new SqlParameter("@RecState",typePara.RecState)
                                   ,new SqlParameter("@RecZip",typePara.RecZip)
                                   ,new SqlParameter("@TotPkgs",typePara.TotPkgs)
                                   ,new SqlParameter("@PackType",typePara.PackType)
                                   ,new SqlParameter("@TotWgt",typePara.TotWgt)
                                   ,new SqlParameter("@WgtU",typePara.WgtU)
                                   ,new SqlParameter("@DimVol",typePara.DimVol)
                                    ,new SqlParameter("@DimVolU ",typePara.DimVolU)
                                   //,new SqlParameter("@RexWgt",typePara.RexWgt)
                                   //,new SqlParameter("@RexWgtU",typePara.RexWgtU)
                                   //,new SqlParameter("@RexVol",typePara.RexVol)
                                   //,new SqlParameter("@RexVolU",typePara.RexVolU)
                                   ,new SqlParameter("@CarriageVal",typePara.CarriageVal)
                                   ,new SqlParameter("@CarriageValCur",typePara.CarriageValCur)
                                   ,new SqlParameter("@CustomVal",typePara.CustomVal)
                                   ,new SqlParameter("@CustomValCur",typePara.CustomValCur)
                                   ,new SqlParameter("@Descrip",typePara.Descrip)
                                   ,new SqlParameter("@SenRefNotes",typePara.SenRefNotes)
                                   ,new SqlParameter("@DocNdoc",typePara.DocNdoc)
                                   ,new SqlParameter("@HoldAtLoc",typePara.HoldAtLoc)
                                   ,new SqlParameter("@BillTransChg",typePara.BillTransChg)
                                   ,new SqlParameter("@BillTransAcNo",typePara.BillTransAcNo)
                                   ,new SqlParameter("@BillDtaxChg",typePara.BillDtaxChg)
                                   ,new SqlParameter("@BillDtaxAcNo",typePara.BillDtaxAcNo)
                                   ,new SqlParameter("@IntComDate",typePara.IntComDate)
                                   ,new SqlParameter("@IntComTime",typePara.IntComTime)
                                    ,new SqlParameter("@SvcType",typePara.SvcType)
                                    ,new SqlParameter("@ExpressCons",typePara.ExpressCons)
                                   //,new SqlParameter("@FinComDate",typePara.FinComDate)
                                   //,new SqlParameter("@FinComTime",typePara.FinComTime)
                                   //,new SqlParameter("@TrackClosedY",typePara.TrackClosedY)
                                   //,new SqlParameter("@DeliverY",typePara.DeliverY)
                                   //,new SqlParameter("@PodScanTypeS",typePara.PodScanTypeS)
                                   //,new SqlParameter("@LastScanTypeS",typePara.LastScanTypeS)
                                   //,new SqlParameter("@LastScanDate",typePara.LastScanDate)
                                   //,new SqlParameter("@PodYN",typePara.PodYN)
                                   //,new SqlParameter("@CustomsPkgVal",typePara.CustomsPkgVal)
                                   //,new SqlParameter("@CustomsCurr",typePara.CustomsCurr)
                                   //,new SqlParameter("@ConvRate",typePara.ConvRate)
                                   //,new SqlParameter("@TotalDutyVal",typePara.TotalDutyVal)
                                   //,new SqlParameter("@ShipValueType",typePara.ShipValueType)
                                   //,new SqlParameter("@ShipValueTypeCata",typePara.ShipValueTypeCata)
                                   //,new SqlParameter("@DutyExcemptY",typePara.DutyExcemptY)
                                   //,new SqlParameter("@DetainedY",typePara.DetainedY)
                                   //,new SqlParameter("@MissRoute",typePara.MissRoute)
                                   //,new SqlParameter("@ShoOvr",typePara.ShoOvr)
                                   //,new SqlParameter("@DutythreshLC",typePara.DutythreshLC)
                                   //,new SqlParameter("@ClearStatuesCode",typePara.ClearStatuesCode)
                                   //,new SqlParameter("@Remarks1",typePara.Remarks1)
                                   //,new SqlParameter("@BillOrgCode",typePara.BillOrgCode)
                                   //,new SqlParameter("@BillOrgName",typePara.BillOrgName)
                                   //,new SqlParameter("@BillOrgAddr1",typePara.BillOrgAddr1)
                                   //,new SqlParameter("@BillOrgAddr2",typePara.BillOrgAddr2)
                                   //,new SqlParameter("@BillOrgCity",typePara.BillOrgCity)
                                   //,new SqlParameter("@BillDTaxCreditY",typePara.BillDTaxCreditY)
                                   //,new SqlParameter("@BillDTaxChgY",typePara.BillDTaxChgY)
                                   //,new SqlParameter("@BillTransChgY",typePara.BillTransChgY)
                                   //,new SqlParameter("@InvNoDTaxChg",typePara.InvNoDTaxChg)
                                   //,new SqlParameter("@InvNoTransChg",typePara.InvNoTransChg)
                                   //,new SqlParameter("@USM_LOGIN",typePara.USM_LOGIN)
                                   //,new SqlParameter("@USM_DATE",typePara.USM_DATE)
                                   //,new SqlParameter("@AlertEmail1",typePara.AlertEmail1)
                                   //,new SqlParameter("@AlertEmail2",typePara.AlertEmail2)
                                   //,new SqlParameter("@AlertSms1",typePara.AlertSms1)
                                   //,new SqlParameter("@AlertSms2",typePara.AlertSms2)
                                   //,new SqlParameter("@PickupY",typePara.PickupY)
                                   //,new SqlParameter("@PickScanTypeS",typePara.PickScanTypeS)
                                   //,new SqlParameter("@LatePkg",typePara.LatePkg)
                                   //,new SqlParameter("@RWDL",typePara.RWDL)
                                   //,new SqlParameter("@BusDay14",typePara.BusDay14)
                                   //,new SqlParameter("@ScanGap",typePara.ScanGap)
                                   //,new SqlParameter("@MisScan",typePara.MisScan)
                                   //,new SqlParameter("@slockcode",typePara.slockcode)
                                   //,new SqlParameter("@SpCode",typePara.SpCode)
                                   //,new SqlParameter("@DepNotes",typePara.DepNotes)
                                   //,new SqlParameter("@Remarks",typePara.Remarks)
                                   //,new SqlParameter("@AlFreightChg",typePara.AlFreightChg)
                                   //,new SqlParameter("@ScansAll",typePara.ScansAll)
                                   //,new SqlParameter("@MHEPackType",typePara.MHEPackType)
                                   ,new SqlParameter("@Event",typePara.Event

                                   )


                              };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[USP_AddEditAWBEntryDetail]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,

                                    }).FirstOrDefault();

                    if (responce.StrMessage.Length >0)
                    {

                        mMessage.StrMessage = responce.StrMessage;
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




        public IList<ConsDomainView> GetConsoleList(int GroupID,int Company,int AgencyCode,string ConsoleID)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsMasterResults> uof = new ExpressUnitOfWork<OpsConsMasterResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                            { new SqlParameter("@GroupID", GroupID),
                             new SqlParameter("@CMPY", Company) ,
                             new SqlParameter("@AgncyCode", AgencyCode) ,
                             new SqlParameter("@ConsId", ConsoleID) };
              
                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetConsoleDetails]", paraList)
                                           select new ConsDomainView
                                           {
                                              GroupID  = Ag.GroupID,
                                              CMPY = Ag.CMPY,
                                              AgncyCode = Ag.AgncyCode,                                            
                                              ShipType = Ag.ShipType,
                                              TransMode = Ag.TransMode,
                                              ConsId = Ag.ConsId,
                                              TransDate = Ag.TransDate,
                                              VisaRootID = Ag.VisaRootID,
                                              OrgHubID = Ag.OrgHubID,
                                              DesHubID = Ag.DesHubID,
                                              AlNumCode = Ag.AlNumCode,
                                              FlightNo = Ag.FlightNo,
                                              AriDate = Ag.AriDate,
                                              DepDate = Ag.DepDate,                                            
                                              MAWBNo = Ag.MAWBNo,
                                              ALActWgt = Ag.ALActWgt,
                                              ALChgWgt = Ag.ALChgWgt,
                                              AlFreightChg = Ag.AlFreightChg,
                                              Currency = Ag.Currency,                                         
                                              HighValueY = Ag.HighValueY,
                                              ExpressCons = Ag.ExpressCons

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




        public IList<AWBDomainView> GetAWBList(string AWBNo)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsAWBResults> uof = new ExpressUnitOfWork<OpsConsAWBResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                            { new SqlParameter("@AgnAWBNo", AWBNo),
                            };

                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetAWNoDetails]", paraList)
                                           select new AWBDomainView
                                           {
                                               Deleted = (bool)Ag.Deleted,
                                               GroupID = Ag.GroupID,
                                               CMPY= Ag.CMPY,
                                               AgncyCode= Ag.AgncyCode,
                                               AgncyID= Ag.AgncyID,
                                               ConsId = Ag.ConsId,
                                               TransDate = Ag.TransDate,
                                               ExpressID = Ag.ExpressID,
                                               ExpressMpsNo = Ag.ExpressMpsNo,
                                               AgnAWBNo = Ag.AgnAWBNo,
                                               AgnMpsNo = Ag.AgnMpsNo,
                                               ORIGIN = Ag.ORIGIN,
                                               DESTIN = Ag.DESTIN,
                                               ORGCOUNTRY = Ag.ORGCOUNTRY,                                                 
                                               DESCOUNTRY = Ag.DESCOUNTRY,
                                               SenAccount = Ag.SenAccount,
                                               SenPhone = Ag.SenPhone,
                                               SenCountry = Ag.SenCountry,
                                               SenCode = Ag.SenCode,
                                               SenCompany = Ag.SenCompany,
                                               SenID = Ag.SenID,
                                               SenName = Ag.SenName,
                                               SenAddr1 = Ag.SenAddr1,
                                               SenAddr2 = Ag.SenAddr2,
                                               SenCity = Ag.SenCity,
                                               SenCityN = Ag.SenCityN,
                                               SenState = Ag.SenState,
                                               SenZip = Ag.SenZip,
                                               RecAccount = Ag.RecAccount,
                                               RecPhone = Ag.RecPhone,
                                               RecCountry = Ag.RecCountry,
                                               RecCode = Ag.RecCode,
                                               RecCompany = Ag.RecCompany,
                                               RecName = Ag.RecName,
                                               RecAddr1 = Ag.RecAddr1,
                                               RecAddr2 = Ag.RecAddr2,
                                               RecCity = Ag.RecCity,
                                               RecCityN = Ag.RecCityN,
                                               RecState = Ag.RecState,
                                               RecZip = Ag.RecZip,
                                               TotPkgs = Ag.TotPkgs,                                                       
                                               PackType = Ag.PackType,
                                               TotWgt = (decimal)Ag.TotWgt,
                                               WgtU = Ag.WgtU,
                                               DimVol = (decimal)Ag.DimVol,
                                               DimVolU = Ag.DimVolU,
                                               CarriageVal = (decimal)Ag.CarriageVal,
                                               CarriageValCur = Ag.CarriageValCur,
                                               CustomVal = (decimal)Ag.CustomVal,
                                               CustomValCur = Ag.CustomValCur,
                                               Descrip = Ag.Descrip,
                                               SenRefNotes = Ag.SenRefNotes,
                                               DocNdoc = Ag.DocNdoc,
                                               HoldAtLoc = Ag.HoldAtLoc,
                                               BillTransChg = Ag.BillTransChg,
                                               BillTransAcNo = Ag.BillTransAcNo,
                                               BillDtaxChg = Ag.BillDtaxChg,
                                               BillDtaxAcNo = Ag.BillDtaxAcNo,
                                               IntComDate = Ag.IntComDate,
                                               IntComTime = Ag.IntComTime,
                                               ShipDate = Ag.ShipDate == null?DateTime.Now : Ag.ShipDate,
                                               SvcType= Ag.SvcType,
                                               RexWgtU = "K",
                                               RexVolU = "K",
                                               SenCityCode = Ag.SenCityCode,
                                               RecCityCode = Ag.RecCityCode,


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




        public IList<AWBDomainView> GetAWBMPSList(string AWBNo,string ConsID,string ExpressID)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsAWBResults> uof = new ExpressUnitOfWork<OpsConsAWBResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                            {
                                new SqlParameter("@AgnAWBNo", AWBNo),
                                new SqlParameter("@ConsId", ConsID),
                                new SqlParameter("@ExpressID", ExpressID),

                            };

                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetMPSList]", paraList)
                                           select new AWBDomainView
                                           {
                                               Deleted = (bool)Ag.Deleted,
                                               GroupID = Ag.GroupID,
                                               CMPY = Ag.CMPY,
                                               AgncyCode = Ag.AgncyCode,
                                               AgncyID = Ag.AgncyID,
                                               ConsId = Ag.ConsId,
                                               TransDate = Ag.TransDate,
                                               ExpressID = Ag.ExpressID,
                                               ExpressMpsNo = Ag.ExpressMpsNo,
                                               AgnAWBNo = Ag.AgnAWBNo,
                                               AgnMpsNo = Ag.AgnMpsNo,
                                               ORIGIN = Ag.ORIGIN,
                                               DESTIN = Ag.DESTIN,
                                               ORGCOUNTRY = Ag.ORGCOUNTRY,
                                               DESCOUNTRY = Ag.DESCOUNTRY,
                                               SenAccount = Ag.SenAccount,
                                               SenPhone = Ag.SenPhone,
                                               SenCountry = Ag.SenCountry,
                                               SenCode = Ag.SenCode,
                                               SenCompany = Ag.SenCompany,
                                               SenID = Ag.SenID,
                                               SenName = Ag.SenName,
                                               SenAddr1 = Ag.SenAddr1,
                                               SenAddr2 = Ag.SenAddr2,
                                               SenCity = Ag.SenCity,
                                               SenCityN = Ag.SenCityN,
                                               SenState = Ag.SenState,
                                               SenZip = Ag.SenZip,
                                               RecAccount = Ag.RecAccount,
                                               RecPhone = Ag.RecPhone,
                                               RecCountry = Ag.RecCountry,
                                               RecCode = Ag.RecCode,
                                               RecCompany = Ag.RecCompany,
                                               RecName = Ag.RecName,
                                               RecAddr1 = Ag.RecAddr1,
                                               RecAddr2 = Ag.RecAddr2,
                                               RecCity = Ag.RecCity,
                                               RecCityN = Ag.RecCityN,
                                               RecState = Ag.RecState,
                                               RecZip = Ag.RecZip,
                                               TotPkgs = Ag.TotPkgs,
                                               PackType = Ag.PackType,
                                               TotWgt = (decimal)Ag.TotWgt,
                                               WgtU = Ag.WgtU,
                                               DimVol = (decimal)Ag.DimVol,
                                               DimVolU = Ag.DimVolU,
                                               CarriageVal = (decimal)Ag.CarriageVal,
                                               CarriageValCur = Ag.CarriageValCur,
                                               CustomVal = (decimal)Ag.CustomVal,
                                               CustomValCur = Ag.CustomValCur,
                                               Descrip = Ag.Descrip,
                                               SenRefNotes = Ag.SenRefNotes,
                                               DocNdoc = Ag.DocNdoc,
                                               HoldAtLoc = Ag.HoldAtLoc,
                                               BillTransChg = Ag.BillTransChg,
                                               BillTransAcNo = Ag.BillTransAcNo,
                                               BillDtaxChg = Ag.BillDtaxChg,
                                               BillDtaxAcNo = Ag.BillDtaxAcNo,
                                               IntComDate = Ag.IntComDate,
                                               IntComTime = Ag.IntComTime,
                                               ShipDate = Ag.ShipDate == null ? DateTime.Now : Ag.ShipDate,
                                               SvcType = Ag.SvcType,
                                               RexWgtU = "K",
                                               RexVolU = "K",
                                               SenCityCode = Ag.SenCityCode,
                                               RecCityCode = Ag.RecCityCode,


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



        public IList<CommonDomainView> GetUOMist(string UomCode)
        {
            try
            {
                using (IExpressUnitOfWork<ServiceResult> uof = new ExpressUnitOfWork<ServiceResult>())
                {
                    List<CommonDomainView> listUOM = new List<CommonDomainView>();

                    CommonDomainView u = new CommonDomainView();

                    u.Code = "K";
                    u.Name = "Kg";

                    listUOM.Add(u);

                    return listUOM;


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



        public IList<CommonDomainView> GetDimVolUOMist(string UomCode)
        {
            try
            {
                using (IExpressUnitOfWork<ServiceResult> uof = new ExpressUnitOfWork<ServiceResult>())
                {
                    List<CommonDomainView> listUOM = new List<CommonDomainView>();

                    CommonDomainView u = new CommonDomainView();

                    u.Code = "M3";
                    u.Name = "M3";

                    listUOM.Add(u);

                    return listUOM;


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




        public IList<CommonDomainView> BillChgTo(string Code)
        {
            try
            {
                using (IExpressUnitOfWork<ServiceResult> uof = new ExpressUnitOfWork<ServiceResult>())
                {
                    List<CommonDomainView> listUOM = new List<CommonDomainView>();

                    CommonDomainView u = new CommonDomainView();

                    u.Code = "C";
                    u.Name = "Consignee";

                    listUOM.Add(u);

                    CommonDomainView u1 = new CommonDomainView();

                    u1.Code = "S";
                    u1.Name = "Shipper";

                    listUOM.Add(u1);

                    CommonDomainView u2 = new CommonDomainView();

                    u2.Code = "O";
                    u2.Name = "Other";

                    listUOM.Add(u2);

                    return listUOM;


            


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




        public ResponseMessage DeleteAWBD(AWBDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {

                                
                                   new SqlParameter("@GroupID",typePara.GroupID)
                                   ,new SqlParameter("@CMPY",typePara.CMPY)
                                   ,new SqlParameter("@AgncyCode",typePara.AgncyCode)
                                   ,new SqlParameter("@AgncyID",typePara.AgncyID)
                                   //,new SqlParameter("@ORIGINGate",typePara.ORIGINGate)
                                   //,new SqlParameter("@DESTINGate",typePara.DESTINGate)
                                   //,new SqlParameter("@GateWayID",typePara.GateWayID)
                                   //,new SqlParameter("@StationID",typePara.StationID)
                                   //,new SqlParameter("@RouteID",typePara.RouteID)
                                   ,new SqlParameter("@ConsId",typePara.ConsId)                              
                                   //,new SqlParameter("@ShipType",typePara.ShipType)
                                   //,new SqlParameter("@TransMode",typePara.TransMode)
                                   ,new SqlParameter("@ExpressID",typePara.ExpressID)
                                   ,new SqlParameter("@ExpressMpsNo",typePara.ExpressMpsNo)
                                   ,new SqlParameter("@MpsNo",typePara.AgnMpsNo)
                                   ,new SqlParameter("@AgnAWBNo",typePara.AgnAWBNo)
                                   
                               

                                   


                              };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[USP_DeleteAWBEntryDetail]", paraList)
                                    select new ResponseMessage
                                    {
                                        StrMessage = SR.ResponseMessage,

                                    }).FirstOrDefault();

                    if (responce.StrMessage.Length > 0)
                    {

                        mMessage.StrMessage = responce.StrMessage;
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








        public IList<RefLocationsDomainView> GetLocationList(string Country, string AgnLocation)
        {
            try
            {
                using (IExpressUnitOfWork<RefLocationsResult> uof = new ExpressUnitOfWork<RefLocationsResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                            { new SqlParameter("@Country", Country),
                             new SqlParameter("@AgnLocation", AgnLocation)
                            };
                         

                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[USP_GetAgencyLocationExists]", paraList)
                                           select new RefLocationsDomainView
                                           {
                                               LocationID = Ag.LocationID,
                                               Country = Ag.Country,
                                              

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



        public IList<AWBDomainView> GetAWBBilledList(string AWBNo)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsAWBResults> uof = new ExpressUnitOfWork<OpsConsAWBResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                            { new SqlParameter("@AgnAWBNo", AWBNo),
                            };

                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[TLM_GetAWNoDetailsBilled]", paraList)
                                           select new AWBDomainView
                                           {
                                               Deleted = (bool)Ag.Deleted,
                                               GroupID = Ag.GroupID,
                                               CMPY = Ag.CMPY,
                                               AgncyCode = Ag.AgncyCode,
                                               AgncyID = Ag.AgncyID,
                                               ConsId = Ag.ConsId,
                                               TransDate = Ag.TransDate,
                                               ExpressID = Ag.ExpressID,
                                               ExpressMpsNo = Ag.ExpressMpsNo,
                                               AgnAWBNo = Ag.AgnAWBNo,
                                               AgnMpsNo = Ag.AgnMpsNo,
                                               ORIGIN = Ag.ORIGIN,
                                               DESTIN = Ag.DESTIN,
                                               ORGCOUNTRY = Ag.ORGCOUNTRY,
                                               DESCOUNTRY = Ag.DESCOUNTRY,
                                               SenAccount = Ag.SenAccount,
                                               SenPhone = Ag.SenPhone,
                                               SenCountry = Ag.SenCountry,
                                               SenCode = Ag.SenCode,
                                               SenCompany = Ag.SenCompany,
                                               SenID = Ag.SenID,
                                               SenName = Ag.SenName,
                                               SenAddr1 = Ag.SenAddr1,
                                               SenAddr2 = Ag.SenAddr2,
                                               SenCity = Ag.SenCity,
                                               SenCityN = Ag.SenCityN,
                                               SenState = Ag.SenState,
                                               SenZip = Ag.SenZip,
                                               RecAccount = Ag.RecAccount,
                                               RecPhone = Ag.RecPhone,
                                               RecCountry = Ag.RecCountry,
                                               RecCode = Ag.RecCode,
                                               RecCompany = Ag.RecCompany,
                                               RecName = Ag.RecName,
                                               RecAddr1 = Ag.RecAddr1,
                                               RecAddr2 = Ag.RecAddr2,
                                               RecCity = Ag.RecCity,
                                               RecCityN = Ag.RecCityN,
                                               RecState = Ag.RecState,
                                               RecZip = Ag.RecZip,
                                               TotPkgs = Ag.TotPkgs,
                                               PackType = Ag.PackType,
                                               TotWgt = (decimal)Ag.TotWgt,
                                               WgtU = Ag.WgtU,
                                               DimVol = (decimal)Ag.DimVol,
                                               DimVolU = Ag.DimVolU,
                                               CarriageVal = (decimal)Ag.CarriageVal,
                                               CarriageValCur = Ag.CarriageValCur,
                                               CustomVal = (decimal)Ag.CustomVal,
                                               CustomValCur = Ag.CustomValCur,
                                               Descrip = Ag.Descrip,
                                               SenRefNotes = Ag.SenRefNotes,
                                               DocNdoc = Ag.DocNdoc,
                                               HoldAtLoc = Ag.HoldAtLoc,
                                               BillTransChg = Ag.BillTransChg,
                                               BillTransAcNo = Ag.BillTransAcNo,
                                               BillDtaxChg = Ag.BillDtaxChg,
                                               BillDtaxAcNo = Ag.BillDtaxAcNo,
                                               IntComDate = Ag.IntComDate,
                                               IntComTime = Ag.IntComTime,
                                               ShipDate = Ag.ShipDate == null ? DateTime.Now : Ag.ShipDate,
                                               SvcType = Ag.SvcType,
                                               RexWgtU = "K",
                                               RexVolU = "K",
                                               SenCityCode = Ag.SenCityCode,
                                               RecCityCode = Ag.RecCityCode,


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


        public IList<ConsDomainView> GetShipTypeList(int cmy, int AgencyCode, string OrgCountry, string DestCountry)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsMasterResults> uof = new ExpressUnitOfWork<OpsConsMasterResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                            { new SqlParameter("@CMPY", cmy),
                             new SqlParameter("@AgncyCode", AgencyCode) ,
                             new SqlParameter("@ORGCOUNTRY", OrgCountry) ,
                             new SqlParameter("@DESCOUNTRY", DestCountry) };

                    var OrgRegistryList = (from Ag in uof.Reposotery.GetDataBySp("[Project].[USP_GetShipmentType]", paraList)
                                           select new ConsDomainView
                                           {

                                               ShipType = Ag.ShipType,


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





    }
}
