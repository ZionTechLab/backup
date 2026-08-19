using Express.Custom.ExcepHandle.DataHadling;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using Express.Interfaces.Invoice;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;

namespace Express.Data.Invoice
{
    public class ClrInvOpsInvoiceChgData : IClrInvOpsInvoiceChg
    {
        public IList<OpsConsAWBDomainView> GetOpsConsAWB(int invoiceno, int AgencyID, int CompanyID)
        {
            try
            {
                using (IExpressUnitOfWork<OpsConsAWBResults> uof = new ExpressUnitOfWork<OpsConsAWBResults>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {  new SqlParameter("@ConsId", "" ),
                                new SqlParameter("@agencyID" , AgencyID ),
                                    new SqlParameter("@companyID" , CompanyID )
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
                                          BillOrgName = Ag.BillOrgName


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

        public InvOrgnzCreditDomainView GetOrgnizCreditDetail(int companyID, string orgCode)
        {
            try
            {
                using (IExpressUnitOfWork<InvOrgnzCreditResult> uof = new ExpressUnitOfWork<InvOrgnzCreditResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                      {  new SqlParameter("@companyID", companyID),
                          new SqlParameter("@orgCode" , (orgCode ==null || orgCode =="") ?0 : Convert.ToInt32( orgCode))

                      };
                    var orgFinance = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetOrgnizCreditDetail]", paraList)
                                      select new InvOrgnzCreditDomainView
                                      {
                                         IsDutyCredit = SR.IsDutyCredit 

                                      }).FirstOrDefault();

                    return orgFinance;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Selling Zone Rate Master", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseMessage UpdateDutyInvoiceOrginization(ClrInvOrgnPopParam _param)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {

                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                    {
                        new SqlParameter("@companyID",_param.CompanyID ),
                        new SqlParameter("@agencyID",_param.AgencyCode),
                        new SqlParameter("@orgCode",_param.OrgCode),
                        new SqlParameter("@orgName",_param.OrgName),
                        new SqlParameter("@IscrdAllow",_param.IscrdAllow),
                        new SqlParameter("@TaxRegNo",_param.TaxRegNo),
                        new SqlParameter("@invNumber",_param.InvoiceNo ),                       
                        new SqlParameter("@expressID",_param.ExpressID),
                        new SqlParameter("@userID", _param.UserID )

                    };
                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_UpdateInvOrganization]", paraList)
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
}
