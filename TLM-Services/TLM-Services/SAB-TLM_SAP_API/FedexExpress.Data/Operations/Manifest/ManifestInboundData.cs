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
using Express.View.Domain.Report.Operation;

namespace Express.Data.Operations.Manifest
{
    public class ManifestInboundData : IManifestInbound<ManifestInboundDomainView>
    {
        public ResponseMessage DeleteDetail(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(ManifestInboundDomainView typePara)
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
                                               LocalCurrency =Ag.LocalCurrency 

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

        public IList<CfgDtaxCalDomainView> GetCfgDtaxCal()
        {
            try
            {
                using (IExpressUnitOfWork<CfgDtaxCalResult> uof = new ExpressUnitOfWork<CfgDtaxCalResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          { };
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetCfgDtaxCal]", paraList)
                                       select new CfgDtaxCalDomainView
                                       {
                                           CostValueF = Ag.CostValueF,
                                           CostValueP = Ag.CostValueP,
                                           DutyExcempt = Ag.DutyExcempt,
                                           ShipValueFrom = Ag.ShipValueFrom,
                                           ShipValueTo = Ag.ShipValueTo,
                                           ShipValueType = Ag.ShipValueType,
                                           ShipValueTypeCata = Ag.ShipValueTypeCata,                                           

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

        public List<ManifestInboundDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<ManifestInboundDomainView> GetDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<ManifestInboundDomainView> GetDetails(string code)
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
                    var GatewayList = (from Ag in uof.Reposotery.GetDataBySp("[Express].[USP_GetRefLocations]", paraList)
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

        public IList<RptManifestDomainView> GetManiferReport(RptManifestParaDomainView _para)
        {
            try
            {

                using (IExpressUnitOfWork<RptManifestResult> uof = new ExpressUnitOfWork<RptManifestResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {
                           new SqlParameter("@CompanyID", _para.CompanyID  ),
                            new SqlParameter("@AgencyID" ,_para.AgencyId ),
                             new SqlParameter("@ConsID" ,_para.ConsID  ),
                              new SqlParameter("@TrDate" ,_para.TrDate ),
                               new SqlParameter("@ShipValType" ,_para.ShipValType ), 
                                new SqlParameter("@IsNotInv" ,_para.IsNotInvoiced ),
                                 new SqlParameter("@PayMode" , _para.PayModes)
                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetManifestReport]", paraList)
                                        select new RptManifestDomainView
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
                                            MasterAwbNo = SR.MasterAwbNo,
                                            ShipValuLc = SR.ShipValuLc,
                                            ShipValType = SR.ShipValType,
                                            DutyValue = SR.DutyValue,
                                            InvoiceNo = SR.InvoiceNo,
                                            ConsolID = SR.ConsolID,
                                            TransDate = SR.TransDate,
                                            CompanyName =SR.CompanyName,
                                            AgencyName  =SR.AgencyName 


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
                                          ClearanceCurrency = SR.ClearanceCurrency ,
                                          ClearanceExgRatTarif =SR.ClearanceExgRatTarif ,
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

        public IList<OpsConsAWBDomainView> GetOpsConsAWB(ManifestProcessParamDomainView typePara)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsAWBResults> uof = new ExpressUnitOfWork<OpsConsAWBResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ConsId", typePara.ConsID ),
                                new SqlParameter("@agencyID" ,typePara.AgencyID ),
                                    new SqlParameter("@companyID" ,typePara.CompanyID )
                          };
                    var OpsConsAWB = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetOpsConsClearenceAWB]", paraList)
                                      select new OpsConsAWBDomainView
                                      {
                                          AgnAWBNo = Ag.AgnAWBNo,
                                          AgncyCode = Ag.AgncyCode,
                                          AgnMpsNo = Ag.AgnMpsNo,
                                          AgnTrackNo = Ag.AgnTrackNo.Trim(),
                                          AlertEmail1 = Ag.AlertEmail1,
                                          AlertEmail2 = Ag.AlertEmail2,
                                          AlertSms1 = Ag.AlertSms1,
                                          AlertSms2 = Ag.AlertSms2,
                                          BillDtaxAcNo = Ag.BillDtaxAcNo,
                                          BillDtaxChg = Ag.BillDtaxChg,
                                          BillTransAcNo = Ag.BillTransAcNo,
                                          BillTransChg = Ag.BillTransChg,
                                          BillTransChgY = Ag.BillTransChgY,
                                          BusDay14 = Ag.BusDay14,
                                          CarriageVal = Ag.CarriageVal,
                                          CarriageValCur = Ag.CarriageValCur,
                                          CMPY = Ag.CMPY,
                                          ConsId = Ag.ConsId,
                                          CustomVal = Ag.CustomVal,
                                          CustomValCur = Ag.CustomValCur,
                                          //Deleted = Ag.Deleted,
                                          DeliverY = Ag.DeliverY,
                                          DepNotes = Ag.DepNotes,
                                          DESCOUNTRY = Ag.DESCOUNTRY,
                                          Descrip = Ag.Descrip.Trim(),
                                          DESTIN = Ag.DESTIN.Trim(),
                                          DimVol = Ag.DimVol,
                                          DimVolU = Ag.DimVolU,
                                          DocNdoc = Ag.DocNdoc.Trim(),
                                          ExpressID = Ag.ExpressID,
                                          ExpressMpsNo = Ag.ExpressMpsNo,
                                          FinComDate = Ag.FinComDate,
                                          FinComTime = Ag.FinComTime,
                                          AgncyID = Ag.AgncyID,
                                          HoldAtLoc = Ag.HoldAtLoc,
                                          IntComDate = Ag.IntComDate,
                                          IntComTime = Ag.IntComTime,
                                          InvNoTransChg = Ag.InvNoTransChg,
                                          LastScanDate = Ag.LastScanDate,
                                          LastScanTypeS = Ag.LastScanTypeS,
                                          LatePkg = Ag.LatePkg,
                                          MHEPackType = Ag.MHEPackType,
                                          MisScan = Ag.MisScan,
                                          MissRoute = Ag.MissRoute,
                                          ORGCOUNTRY = Ag.ORGCOUNTRY.Trim(),
                                          ORIGIN = Ag.ORIGIN,
                                          PackType = Ag.PackType,
                                          PickScanTypeS = Ag.PickScanTypeS,
                                          PickupY = Ag.PickupY,
                                          PodScanTypeS = Ag.PodScanTypeS,
                                          PodYN = Ag.PodYN,
                                          RecAccount = Ag.RecAccount,
                                          RecAddr1 = Ag.RecAddr1,
                                          RecAddr2 = Ag.RecAddr2,
                                          RecCity = Ag.RecCity,
                                          RecCityN = Ag.RecCityN,
                                          RecCode = Ag.RecCode,
                                          RecCompany = Ag.RecCompany.Trim(),
                                          RecCountry = Ag.RecCountry,
                                          RecName = Ag.RecName,
                                          RecPhone = Ag.RecPhone,
                                          RecState = Ag.RecState,
                                          RecZip = Ag.RecZip,
                                          Remarks = Ag.Remarks,
                                          RWDL = Ag.RWDL,
                                          ScanGap = Ag.ScanGap,
                                          ScansAll = Ag.ScansAll,
                                          SenAccount = Ag.SenAccount,
                                          SenAddr1 = Ag.SenAddr1,
                                          SenAddr2 = Ag.SenAddr2,
                                          SenCity = Ag.SenCity,
                                          SenCityN = Ag.SenCityN,
                                          SenCode = Ag.SenCode,
                                          SenCompany = Ag.SenCompany.Trim(),
                                          SenCountry = Ag.SenCountry,
                                          SenID = Ag.SenID,
                                          SenName = Ag.SenName,
                                          SenPhone = Ag.SenPhone,
                                          SenRefNotes = Ag.SenRefNotes,
                                          SenState = Ag.SenState,
                                          SenZip = Ag.SenZip,
                                          ShipDate = Ag.ShipDate,
                                          ShipLocationType = Ag.ShipLocationType,
                                          ShipType = Ag.ShipType,
                                          slockcode = Ag.slockcode,
                                          SpCode = Ag.SpCode,
                                          SvcType = Ag.SvcType,
                                          TotPkgs = Ag.TotPkgs,
                                          TotWgt = Ag.TotWgt,
                                          TrackClosedY = Ag.TrackClosedY,
                                          TransDate = Ag.TransDate,
                                          USM_DATE = Ag.USM_DATE,
                                          USM_LOGIN = Ag.USM_LOGIN,
                                          WgtU = Ag.WgtU,
                                          AlFreightChg = Ag.AlFreightChg,
                                          BillDTaxChgY = Ag.BillDTaxChgY,
                                          ConvRate = Ag.ConvRate,
                                          CustomsCurr = Ag.CustomsCurr,
                                          CustomsPkgVal = Ag.CustomsPkgVal,
                                          Deleted = Ag.Deleted,
                                          DESTINGate = Ag.DESTINGate,
                                          DetainedY = Ag.DetainedY,
                                          DutyExcemptY = Ag.DutyExcemptY,
                                          InvNoDTaxChg = Ag.InvNoDTaxChg,
                                          ORIGINGate = Ag.ORIGINGate,
                                          RexVol = Ag.RexVol,
                                          RexVolU = Ag.RexVolU,
                                          RexWgt = Ag.RexWgt,
                                          RexWgtU = Ag.RexWgtU,
                                          ShipValueType = Ag.ShipValueType,
                                          StationID = Ag.StationID,
                                          TotalDutyVal = Ag.TotalDutyVal,
                                          TransMode = Ag.TransMode,
                                          BillDTaxCreditY = Ag.BillDTaxCreditY,
                                          BillOrgCode = Ag.BillOrgCode,
                                          RouteID = Ag.RouteID,
                                          ShoOvr = Ag.ShoOvr,
                                          BillOrgName = Ag.BillOrgName ,
                                          PayNoDTaxChg =Ag.PayNoDTaxChg ,
                                          BillOrgAddr2 = Ag.BillOrgAddr2,
                                          BillOrgAddr1 =Ag.BillOrgAddr2 ,
                                          BillOrgCity = Ag.BillOrgCity 


                                      }).ToList();

                    return OpsConsAWB;
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

        public IList<OpsConsAWBDomainView> GetOpsConsAWB(string ConsId)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsAWBResults> uof = new ExpressUnitOfWork<OpsConsAWBResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ConsId", ConsId) };
                    var OpsConsAWB = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetOpsConsAWB]", paraList)
                                         select new OpsConsAWBDomainView
                                         {
                                             AgnAWBNo = Ag.AgnAWBNo,
                                             AgncyCode = Ag.AgncyCode,
                                             AgnMpsNo = Ag.AgnMpsNo,
                                             AgnTrackNo = Ag.AgnTrackNo.Trim(),
                                             AlertEmail1 = Ag.AlertEmail1,
                                             AlertEmail2 = Ag.AlertEmail2,
                                             AlertSms1 = Ag.AlertSms1,
                                             AlertSms2 = Ag.AlertSms2,
                                             BillDtaxAcNo = Ag.BillDtaxAcNo,
                                             BillDtaxChg = Ag.BillDtaxChg,
                                             BillTransAcNo = Ag.BillTransAcNo,
                                             BillTransChg = Ag.BillTransChg,
                                             BillTransChgY = Ag.BillTransChgY,
                                             BusDay14 = Ag.BusDay14,
                                             CarriageVal = Ag.CarriageVal,
                                             CarriageValCur = Ag.CarriageValCur,
                                             CMPY = Ag.CMPY,
                                             ConsId = Ag.ConsId,
                                             CustomVal = Ag.CustomVal,
                                             CustomValCur = Ag.CustomValCur,
                                             //Deleted = Ag.Deleted,
                                             DeliverY = Ag.DeliverY,
                                             DepNotes = Ag.DepNotes,
                                             DESCOUNTRY = Ag.DESCOUNTRY,
                                             Descrip = Ag.Descrip.Trim(),
                                             DESTIN = Ag.DESTIN.Trim(),
                                             DimVol = Ag.DimVol,
                                             DimVolU = Ag.DimVolU,
                                             DocNdoc = Ag.DocNdoc.Trim(),
                                             ExpressID = Ag.ExpressID,
                                             ExpressMpsNo = Ag.ExpressMpsNo,
                                            // FinComDate = Ag.FinComDate,
                                             //FinComTime = Ag.FinComTime,
                                             AgncyID = Ag.AgncyID,
                                             HoldAtLoc = Ag.HoldAtLoc,
                                          //   IntComDate = Ag.IntComDate,
                                           //  IntComTime = Ag.IntComTime,
                                             InvNoTransChg = Ag.InvNoTransChg,
                                             LastScanDate = Ag.LastScanDate,
                                             LastScanTypeS = Ag.LastScanTypeS,
                                             LatePkg = Ag.LatePkg,
                                             MHEPackType = Ag.MHEPackType,
                                             MisScan = Ag.MisScan,
                                             MissRoute = Ag.MissRoute,
                                             ORGCOUNTRY = Ag.ORGCOUNTRY.Trim(),
                                             ORIGIN = Ag.ORIGIN,
                                             PackType = Ag.PackType,
                                             PickScanTypeS = Ag.PickScanTypeS,
                                             PickupY = Ag.PickupY,
                                             PodScanTypeS = Ag.PodScanTypeS,
                                             PodYN = Ag.PodYN,
                                             RecAccount = Ag.RecAccount,
                                             RecAddr1 = Ag.RecAddr1,
                                             RecAddr2 = Ag.RecAddr2,
                                             RecCity = Ag.RecCity,
                                             RecCityN = Ag.RecCityN,
                                             RecCode = Ag.RecCode,
                                             RecCompany = Ag.RecCompany.Trim(),
                                             RecCountry = Ag.RecCountry,
                                             RecName = Ag.RecName,
                                             RecPhone = Ag.RecPhone,
                                             RecState = Ag.RecState,
                                             RecZip = Ag.RecZip,
                                             Remarks = Ag.Remarks,
                                             RWDL = Ag.RWDL,
                                             ScanGap = Ag.ScanGap,
                                             ScansAll = Ag.ScansAll,
                                             SenAccount = Ag.SenAccount,
                                             SenAddr1 = Ag.SenAddr1,
                                             SenAddr2 = Ag.SenAddr2,
                                             SenCity = Ag.SenCity,
                                             SenCityN = Ag.SenCityN,
                                             SenCode = Ag.SenCode,
                                             SenCompany = Ag.SenCompany.Trim(),
                                             SenCountry = Ag.SenCountry,
                                             SenID = Ag.SenID,
                                             SenName = Ag.SenName,
                                             SenPhone = Ag.SenPhone,
                                             SenRefNotes = Ag.SenRefNotes,
                                             SenState = Ag.SenState,
                                             SenZip = Ag.SenZip,
                                             ShipDate = Ag.ShipDate,
                                             ShipLocationType = Ag.ShipLocationType,
                                             ShipType = Ag.ShipType,
                                             slockcode = Ag.slockcode,
                                             SpCode = Ag.SpCode,
                                             SvcType = Ag.SvcType,
                                             TotPkgs = Ag.TotPkgs,
                                             TotWgt = Ag.TotWgt,
                                             TrackClosedY = Ag.TrackClosedY,
                                             TransDate = Ag.TransDate,
                                             USM_DATE = Ag.USM_DATE,
                                             USM_LOGIN = Ag.USM_LOGIN,
                                             WgtU = Ag.WgtU,
                                             AlFreightChg = Ag.AlFreightChg,
                                             BillDTaxChgY = Ag.BillDTaxChgY,
                                             ConvRate = Ag.ConvRate,
                                             CustomsCurr = Ag.CustomsCurr,
                                             CustomsPkgVal = Ag.CustomsPkgVal,
                                             Deleted = Ag.Deleted,
                                             DESTINGate = Ag.DESTINGate,
                                             DetainedY = Ag.DetainedY,
                                             DutyExcemptY = Ag.DutyExcemptY,
                                             InvNoDTaxChg = Ag.InvNoDTaxChg,
                                             ORIGINGate = Ag.ORIGINGate,
                                             RexVol = Ag.RexVol,
                                             RexVolU = Ag.RexVolU,
                                             RexWgt = Ag.RexWgt,
                                             RexWgtU = Ag.RexWgtU,
                                             ShipValueType = Ag.ShipValueType,
                                             StationID = Ag.StationID,
                                             TotalDutyVal = Ag.TotalDutyVal,
                                             TransMode = Ag.TransMode,
                                             BillDTaxCreditY = Ag.BillDTaxCreditY,
                                             BillOrgCode = Ag.BillOrgCode,
                                             RouteID = Ag.RouteID,
                                             ShoOvr = Ag.ShoOvr,
                                             BillOrgName = Ag.BillOrgName,
                                             PayNoDTaxChg = Ag.PayNoDTaxChg ,
                                             BillOrgAddr1 = Ag.BillOrgAddr1 ,
                                             BillOrgAddr2 = Ag.BillOrgAddr2 ,
                                             BillOrgCity = Ag.BillOrgCity 

                                         }).ToList();

                    return OpsConsAWB;
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

        //New Express
        public IList<OpsConsAWBDomainView> GetOpsConsAWBEx(string ConsId, string ExpressCons)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsAWBResults> uof = new ExpressUnitOfWork<OpsConsAWBResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ConsId", ConsId),
                          new SqlParameter("@ExpressCons", ExpressCons)
                          };
                    var OpsConsAWB = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetOpsConsAWBEx]", paraList)
                                      select new OpsConsAWBDomainView
                                      {

                                          AgnAWBNo = Ag.AgnAWBNo,
                                          AgncyCode = Ag.AgncyCode,
                                          AgnMpsNo = Ag.AgnMpsNo,
                                          AgnTrackNo = Ag.AgnTrackNo.Trim(),
                                          AlertEmail1 = Ag.AlertEmail1,
                                          AlertEmail2 = Ag.AlertEmail2,
                                          AlertSms1 = Ag.AlertSms1,
                                          AlertSms2 = Ag.AlertSms2,
                                          BillDtaxAcNo = Ag.BillDtaxAcNo,
                                          BillDtaxChg = Ag.BillDtaxChg,
                                          BillTransAcNo = Ag.BillTransAcNo,
                                          BillTransChg = Ag.BillTransChg,
                                          BillTransChgY = Ag.BillTransChgY,
                                          BusDay14 = Ag.BusDay14,
                                          CarriageVal = Ag.CarriageVal,
                                          CarriageValCur = Ag.CarriageValCur,
                                          CMPY = Ag.CMPY,
                                          ConsId = Ag.ConsId,
                                          CustomVal = Ag.CustomVal,
                                          CustomValCur = Ag.CustomValCur,
                                          //Deleted = Ag.Deleted,
                                          DeliverY = Ag.DeliverY,
                                          DepNotes = Ag.DepNotes,
                                          DESCOUNTRY = Ag.DESCOUNTRY,
                                          Descrip = Ag.Descrip.Trim(),
                                          DESTIN = Ag.DESTIN.Trim(),
                                          DimVol = Ag.DimVol,
                                          DimVolU = Ag.DimVolU,
                                          DocNdoc = Ag.DocNdoc.Trim(),
                                          ExpressID = Ag.ExpressID,
                                          ExpressMpsNo = Ag.ExpressMpsNo,
                                          // FinComDate = Ag.FinComDate,
                                          //FinComTime = Ag.FinComTime,
                                          AgncyID = Ag.AgncyID,
                                          HoldAtLoc = Ag.HoldAtLoc,
                                          //   IntComDate = Ag.IntComDate,
                                          //  IntComTime = Ag.IntComTime,
                                          InvNoTransChg = Ag.InvNoTransChg,
                                          LastScanDate = Ag.LastScanDate,
                                          LastScanTypeS = Ag.LastScanTypeS,
                                          LatePkg = Ag.LatePkg,
                                          MHEPackType = Ag.MHEPackType,
                                          MisScan = Ag.MisScan,
                                          MissRoute = Ag.MissRoute,
                                          ORGCOUNTRY = Ag.ORGCOUNTRY.Trim(),
                                          ORIGIN = Ag.ORIGIN,
                                          PackType = Ag.PackType,
                                          PickScanTypeS = Ag.PickScanTypeS,
                                          PickupY = Ag.PickupY,
                                          PodScanTypeS = Ag.PodScanTypeS,
                                          PodYN = Ag.PodYN,
                                          RecAccount = Ag.RecAccount,
                                          RecAddr1 = Ag.RecAddr1,
                                          RecAddr2 = Ag.RecAddr2,
                                          RecCity = Ag.RecCity,
                                          RecCityN = Ag.RecCityN,
                                          RecCode = Ag.RecCode,
                                          RecCompany = Ag.RecCompany.Trim(),
                                          RecCountry = Ag.RecCountry,
                                          RecName = Ag.RecName,
                                          RecPhone = Ag.RecPhone,
                                          RecState = Ag.RecState,
                                          RecZip = Ag.RecZip,
                                          Remarks = Ag.Remarks,
                                          RWDL = Ag.RWDL,
                                          ScanGap = Ag.ScanGap,
                                          ScansAll = Ag.ScansAll,
                                          SenAccount = Ag.SenAccount,
                                          SenAddr1 = Ag.SenAddr1,
                                          SenAddr2 = Ag.SenAddr2,
                                          SenCity = Ag.SenCity,
                                          SenCityN = Ag.SenCityN,
                                          SenCode = Ag.SenCode,
                                          SenCompany = Ag.SenCompany.Trim(),
                                          SenCountry = Ag.SenCountry,
                                          SenID = Ag.SenID,
                                          SenName = Ag.SenName,
                                          SenPhone = Ag.SenPhone,
                                          SenRefNotes = Ag.SenRefNotes,
                                          SenState = Ag.SenState,
                                          SenZip = Ag.SenZip,
                                          ShipDate = Ag.ShipDate,
                                          ShipLocationType = Ag.ShipLocationType,
                                          ShipType = Ag.ShipType,
                                          slockcode = Ag.slockcode,
                                          SpCode = Ag.SpCode,
                                          SvcType = Ag.SvcType,
                                          TotPkgs = Ag.TotPkgs,
                                          TotWgt = Ag.TotWgt,
                                          TrackClosedY = Ag.TrackClosedY,
                                          TransDate = Ag.TransDate,
                                          USM_DATE = Ag.USM_DATE,
                                          USM_LOGIN = Ag.USM_LOGIN,
                                          WgtU = Ag.WgtU,
                                          AlFreightChg = Ag.AlFreightChg,
                                          BillDTaxChgY = Ag.BillDTaxChgY,
                                          ConvRate = Ag.ConvRate,
                                          CustomsCurr = Ag.CustomsCurr,
                                          CustomsPkgVal = Ag.CustomsPkgVal,
                                          Deleted = Ag.Deleted,
                                          DESTINGate = Ag.DESTINGate,
                                          DetainedY = Ag.DetainedY,
                                          DutyExcemptY = Ag.DutyExcemptY,
                                          InvNoDTaxChg = Ag.InvNoDTaxChg,
                                          ORIGINGate = Ag.ORIGINGate,
                                          RexVol = Ag.RexVol,
                                          RexVolU = Ag.RexVolU,
                                          RexWgt = Ag.RexWgt,
                                          RexWgtU = Ag.RexWgtU,
                                          ShipValueType = Ag.ShipValueType,
                                          StationID = Ag.StationID,
                                          TotalDutyVal = Ag.TotalDutyVal,
                                          TransMode = Ag.TransMode,
                                          BillDTaxCreditY = Ag.BillDTaxCreditY,
                                          BillOrgCode = Ag.BillOrgCode,
                                          RouteID = Ag.RouteID,
                                          ShoOvr = Ag.ShoOvr,
                                          BillOrgName = Ag.BillOrgName,
                                          PayNoDTaxChg = Ag.PayNoDTaxChg,
                                          BillOrgAddr1 = Ag.BillOrgAddr1,
                                          BillOrgAddr2 = Ag.BillOrgAddr2,
                                          BillOrgCity = Ag.BillOrgCity,
                                          ExpressCons = Ag.ExpressCons
                                      }).ToList();

                    return OpsConsAWB;
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

        public IList<OpsConsMasterDomainView> GetOpsConsMaster(int AgncyID, int CMPY, string DesHubID, DateTime TransDate)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsMasterResults> uof = new ExpressUnitOfWork<OpsConsMasterResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@AgncyID", AgncyID),
                              new SqlParameter("@CMPY", CMPY),
                              new SqlParameter("@DesHubID", DesHubID),
                              new SqlParameter("@TransDate", TransDate)
                          };
                    var OpsConsMaster = (from Ag in uof.Reposotery.GetDataBySp("[Express].[TLM_GetOpsConsMaster]", paraList)
                                       select new OpsConsMasterDomainView
                                       {
                                           AgncyCode = Ag.AgncyCode,
                                           ALActWgt = Ag.ALActWgt,
                                           ALChgWgt = Ag.ALChgWgt,
                                           AlFreightChg = Ag.AlFreightChg,
                                           AlNumCode = Ag.AlNumCode,
                                           AriDate = Ag.AriDate,
                                           AriTime = Ag.AriTime,
                                           CMPY = Ag.CMPY,
                                           ConsId = Ag.ConsId,
                                           Currency = Ag.Currency,
                                           //Deleted = Ag.Deleted,
                                           DepDate = Ag.DepDate,
                                           DepTime = Ag.DepTime,
                                           DesHubID = Ag.DesHubID,
                                           FlightNo = Ag.FlightNo,
                                           GroupID = Ag.GroupID,
                                           HighValueY = Ag.HighValueY,
                                           MAWBNo = Ag.MAWBNo,
                                           OrgHubID = Ag.OrgHubID,
                                           Remarks = Ag.Remarks,
                                           ShipType = Ag.ShipType,
                                           TransDate = Ag.TransDate,
                                           TransMode = Ag.TransMode,
                                           VisaRootID = Ag.VisaRootID,
                                           //ExpressCons
                                           ExpressCons = Ag.ExpressCons

                                       }).ToList();

                    return OpsConsMaster;
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

        public ResponseMessage InvoiceProcess(ManifestProcessParamDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@varConsID",typePara.ConsID),
                        new SqlParameter("@company",typePara.CompanyID),
                        new SqlParameter("@agency",typePara.AgencyID),
                        new SqlParameter("@userID",typePara.UserID)
                        

                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_DutyBulkProcess]", paraList)
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

        public ResponseMessage ProcessManifestClearence(ManifestProcessParamDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@consID",typePara.ConsID),
                        new SqlParameter("@company",typePara.CompanyID),
                        new SqlParameter("@agency",typePara.AgencyID),
                        new SqlParameter("@TrDate",typePara.TransDate),
                        new SqlParameter("@ManCurrency",typePara.Currency),
                        new SqlParameter("@billto" , typePara.PayParty )
                      
                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_ProccessAWBClearence]", paraList)
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

        public ResponseMessage ProcessManifestInbound(OpsConsAWBDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                  new SqlParameter("@CMPY",typePara.CMPY),
                                  new SqlParameter("@AgncyCode",typePara.AgncyCode),
                                  new SqlParameter("@ConsId",typePara.ConsId),
                                  new SqlParameter("@ExpressID",typePara.ExpressID),
                                  new SqlParameter("@ShipValueType",typePara.ShipValueType),
                                  new SqlParameter("@CustomsPkgVal",typePara.CustomsPkgVal),
                                  new SqlParameter("@TotalDutyVal",typePara.TotalDutyVal),
                                  new SqlParameter("@InvNoDTaxChg",typePara.InvNoDTaxChg),
                                  new SqlParameter("@varOutMsg","")
                              };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_ProcessManifestInbound]", paraList)
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

        public ResponseMessage SaveDetails(ManifestInboundDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage UpdateManifestInboundDutyStatus(OpsConsAWBDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();
            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                              {
                                  new SqlParameter("@CMPY",typePara.CMPY),
                                  new SqlParameter("@AgncyCode",typePara.AgncyCode),
                                  new SqlParameter("@ConsId",typePara.ConsId),
                                  new SqlParameter("@ExpressID",typePara.ExpressID),
                                  new SqlParameter("@DutyExcemptY",typePara.DutyExcemptY),
                                  new SqlParameter("@DetainedY",typePara.DetainedY),
                                  new SqlParameter("@varOutMsg","")
                              };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_EditManifestInboundDutyStatus]", paraList)
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
    }
}
