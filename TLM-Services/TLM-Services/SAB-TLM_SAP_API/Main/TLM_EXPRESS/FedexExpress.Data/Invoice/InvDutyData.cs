using Express.Interfaces.Invoice;
using Express.View.Domain.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.Data.FedexExpressEF;
using System.Data.SqlClient;
using Express.Data.FedexExpressEF.DBDomain.ComplexTypes;
using System.Data.Entity.Infrastructure;
using Express.Custom.ExcepHandle.DataHadling;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Invoice;

namespace Express.Data.Invoice
{
    public class InvDutyData : IInvDutyProvider<InvDutyDomainView>
    {       
        private readonly string   errorModule;
        public InvDutyData(string errorModule)
        {
            this.errorModule = errorModule;
        }
        public ResponseMessage SaveDetails(InvDutyDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                      {
                        new SqlParameter("@GroupID", typePara.GroupID),
                        new SqlParameter("@CMPY", typePara.CompanyID),
                        new SqlParameter("@AgncyCode", typePara.AgncyCode),
                        //// new SqlParameter("@AgnID", typePara.AgncyRptID),
                        new SqlParameter("@AgnID", typePara.AgencyRpt),
                        new SqlParameter("@ExpressID", typePara.ExpressID.Trim()),
                        new SqlParameter("@AgnAWBNo", typePara.AirWayBill.Trim()),
                        new SqlParameter("@ConsId", (typePara.ConsID==null)?"": typePara.ConsID.Trim() ),
                        new SqlParameter("@MasterAwbNo", (typePara.MasterAwbNo==null )?"": typePara.MasterAwbNo.Trim()),
                        new SqlParameter("@TransDate", typePara.TransDate ),
                        new SqlParameter("@InvoiceDate", typePara.InvoiceDate ),
                        new SqlParameter("@ShipType", typePara.ShipType ),
                        ////new SqlParameter("@MissRoute",( typePara.IsMissRoute=="Y") ? "Y":""),
                        //// new SqlParameter("@Detain", (typePara.IsDetain=="Y")?"Y":"" ),
                        new SqlParameter("@MissRoute",""),
                        new SqlParameter("@Detain", "" ),
                        new SqlParameter("@BillTo", typePara.BillTaxChgType  ),
                        new SqlParameter("@CusdecNo", (typePara.CusdecNo==null)? "" :typePara.CusdecNo),
                        new SqlParameter("@Descrip",(typePara.GoodDescp==null)?"": typePara.GoodDescp),
                        new SqlParameter("@HSCODE",  ""),
                        new SqlParameter("@ManifestVal", typePara.ShipperValue),
                        new SqlParameter("@ManifestValCur",( typePara.ManiCurrCode==null)?"":typePara.ManiCurrCode),
                        new SqlParameter("@ManifConvRate", typePara.ManExtRate),
                        new SqlParameter("@CustomVal", typePara.ShipValueLoc),
                        new SqlParameter("@CustomValCur", ( typePara.CustomValCur==null)?"":typePara.CustomValCur),
                        new SqlParameter("@Remarks",(typePara.Remarks==null)? "": typePara.Remarks),
                        new SqlParameter("@VATRegNo", (typePara.TaxCodeOne==null || typePara.TaxCodeOne=="0")? "":typePara.TaxCodeOne),
                        new SqlParameter("@Doctype", (typePara.InvoiceType==null)? "":typePara.InvoiceType ),
                        new SqlParameter("@OrgCode",Convert.ToInt32( typePara.OrgnizCode) ),
                        new SqlParameter("@OrgName", (typePara.OrgnizName==null)?"":typePara.OrgnizName),
                        new SqlParameter("@OrgCountry", (typePara.OrgCntrCode ==null)? "":typePara.OrgCntrCode),
                        new SqlParameter("@PayMode",(typePara.PayMode==null)? "": typePara.PayMode ),
                        new SqlParameter("@InvMode", typePara.InvMode),
                        new SqlParameter("@DptCode", ""),
                        new SqlParameter("@ChargeXML", (typePara.ChargeXML==null)? "":typePara.ChargeXML),
                        new SqlParameter("@JobNum" , (typePara.JobNo==null || typePara.JobNo=="" )?"0" :typePara.JobNo ),
                        new SqlParameter("@SalesAreaID" , (typePara.SalesAreaID==null || typePara.SalesAreaID=="" )?"" :typePara.SalesAreaID ),
                        new SqlParameter("@BranchCode" , (typePara.BranchCode==null || typePara.BranchCode=="" )?"" :typePara.BranchCode ),
                        new SqlParameter("@InvoiceNumber" , (typePara.InvoiceNo ==null|| typePara.InvoiceNo=="" || typePara.InvoiceNo=="<NEW>")?"0" :typePara.InvoiceNo ),
                        new SqlParameter("@OrgPerson" , (typePara.OrgPerson ==null|| typePara.OrgPerson=="")?"" :typePara.OrgPerson ),
                        new SqlParameter("@OrgAddr1" , (typePara.OrgAddr1 ==null|| typePara.OrgAddr1=="")?"" :typePara.OrgAddr1 ),
                        new SqlParameter("@OrgAddr2" , (typePara.OrgAddr2 ==null|| typePara.OrgAddr2=="")?"" :typePara.OrgAddr2 ),
                        new SqlParameter("@OrgCityCode" , typePara.OrgCityCode ),
                        new SqlParameter("@OrgCity" , (typePara.OrgCity==null)?"": typePara.OrgCity ),
                        new SqlParameter("@FlightNo" ,(typePara.FlightNo==null)? "" :typePara.FlightNo ),
                        new SqlParameter("@SvatNo" ,""),
                        new SqlParameter("@SenRefNotes" , (typePara.SenRefNotes ==null  ) ? "" : typePara.SenRefNotes ),
                        new SqlParameter("@Paynumber" , (typePara.PayNo ==0  ) ? 0 : typePara.PayNo ),
                        new SqlParameter("@paydate" ,  typePara.PayDate ),
                        new SqlParameter("@payaccount" , (typePara.PayAccount ==0  ) ? 0 : typePara.PayAccount ),
                        new SqlParameter("@payRefnum" , (typePara.PayRefno ==null  ) ? "" : typePara.PayRefno ),
                        new SqlParameter("@gatewayid" , (typePara.GateWayID ==null  ) ? "" : typePara.GateWayID ),
                        new SqlParameter("@stationid" , (typePara.StationID ==null  ) ? "" : typePara.StationID ),
                        new SqlParameter("@routid" , (typePara.RouteID  ==null  ) ? "" : typePara.Remarks ),
                        new SqlParameter("@ShipValType" , (typePara.ShipValType  ==null  ) ? "" : typePara.ShipValType ),
                        new SqlParameter("@Status" ,"ADD"),
                        new SqlParameter("@Usm_Id" ,typePara.UserID),
                      };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditInvDutyInvoice]", paraList)
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
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;
            }

            return mMessage;
        }
        public ResponseMessage EditDetails(InvDutyDomainView typePara)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                      {
                        new SqlParameter("@GroupID", typePara.GroupID),
                        new SqlParameter("@CMPY", typePara.CompanyID),
                        new SqlParameter("@AgncyCode", typePara.AgncyCode),
                        // new SqlParameter("@AgnID", typePara.AgncyRptID),
                        new SqlParameter("@AgnID", typePara.AgencyRpt),
                        new SqlParameter("@ExpressID", typePara.ExpressID.Trim()),
                        new SqlParameter("@AgnAWBNo", typePara.AirWayBill.Trim()),
                        new SqlParameter("@ConsId", (typePara.ConsID==null)?"": typePara.ConsID.Trim() ),
                        new SqlParameter("@MasterAwbNo", (typePara.MasterAwbNo==null )?"": typePara.MasterAwbNo.Trim()),
                        new SqlParameter("@TransDate", typePara.TransDate ),
                        new SqlParameter("@InvoiceDate", typePara.InvoiceDate ),
                        new SqlParameter("@ShipType", typePara.ShipType ),
                        //new SqlParameter("@MissRoute",( typePara.IsMissRoute=="Y") ? "Y":""),
                        // new SqlParameter("@Detain", (typePara.IsDetain=="Y")?"Y":"" ),
                        new SqlParameter("@MissRoute",""),
                        new SqlParameter("@Detain", "" ),
                        new SqlParameter("@BillTo", typePara.BillTaxChgType  ),
                        new SqlParameter("@CusdecNo", (typePara.CusdecNo==null)? "" :typePara.CusdecNo),
                        new SqlParameter("@Descrip",(typePara.GoodDescp==null)?"": typePara.GoodDescp),
                        new SqlParameter("@HSCODE",  ""),
                        new SqlParameter("@ManifestVal", typePara.ShipperValue),
                        new SqlParameter("@ManifestValCur",( typePara.ManiCurrCode==null)?"":typePara.ManiCurrCode),
                        new SqlParameter("@ManifConvRate", typePara.ManExtRate),
                        new SqlParameter("@CustomVal", typePara.ShipValueLoc),
                        new SqlParameter("@CustomValCur", ( typePara.CustomValCur==null)?"":typePara.CustomValCur),
                        new SqlParameter("@Remarks",(typePara.Remarks==null)? "": typePara.Remarks),
                        new SqlParameter("@VATRegNo", (typePara.TaxCodeOne==null || typePara.TaxCodeOne=="0")? "":typePara.TaxCodeOne),
                        new SqlParameter("@Doctype", (typePara.InvoiceType==null)? "":typePara.InvoiceType ),
                        new SqlParameter("@OrgCode",Convert.ToInt32( typePara.OrgnizCode) ),
                        new SqlParameter("@OrgName", (typePara.OrgnizName==null)?"":typePara.OrgnizName),
                        new SqlParameter("@OrgCountry", (typePara.OrgCntrCode ==null)? "":typePara.OrgCntrCode),
                        new SqlParameter("@PayMode",(typePara.PayMode==null)? "": typePara.PayMode ),
                        new SqlParameter("@InvMode", typePara.InvMode),
                        new SqlParameter("@DptCode", ""),
                        new SqlParameter("@ChargeXML", (typePara.ChargeXML==null)? "":typePara.ChargeXML),
                        new SqlParameter("@JobNum" , (typePara.JobNo==null || typePara.JobNo=="" )?"0" :typePara.JobNo ),
                        new SqlParameter("@SalesAreaID" , (typePara.SalesAreaID==null || typePara.SalesAreaID=="" )?"" :typePara.SalesAreaID ),
                        new SqlParameter("@BranchCode" , (typePara.BranchCode==null || typePara.BranchCode=="" )?"" :typePara.BranchCode ),
                        new SqlParameter("@InvoiceNumber" , (typePara.InvoiceNo ==null|| typePara.InvoiceNo=="" || typePara.InvoiceNo=="<NEW>")?"0" :typePara.InvoiceNo ),
                        new SqlParameter("@OrgPerson" , (typePara.OrgPerson ==null|| typePara.OrgPerson=="")?"" :typePara.OrgPerson ),
                        new SqlParameter("@OrgAddr1" , (typePara.OrgAddr1 ==null|| typePara.OrgAddr1=="")?"" :typePara.OrgAddr1 ),
                        new SqlParameter("@OrgAddr2" , (typePara.OrgAddr2 ==null|| typePara.OrgAddr2=="")?"" :typePara.OrgAddr2 ),
                        new SqlParameter("@OrgCityCode" , typePara.OrgCityCode ),
                        new SqlParameter("@OrgCity" , (typePara.OrgCity==null)?"": typePara.OrgCity ),
                        new SqlParameter("@FlightNo" ,(typePara.FlightNo==null)? "" :typePara.FlightNo ),
                        new SqlParameter("@SvatNo" ,""),
                        new SqlParameter("@SenRefNotes" , (typePara.SenRefNotes ==null  ) ? "" : typePara.SenRefNotes ),
                        new SqlParameter("@Paynumber" , (typePara.PayNo ==0  ) ? 0 : typePara.PayNo ),
                        new SqlParameter("@paydate" ,  typePara.PayDate ),
                        new SqlParameter("@payaccount" , (typePara.PayAccount ==0  ) ? 0 : typePara.PayAccount ),
                        new SqlParameter("@payRefnum" , (typePara.PayRefno ==null  ) ? "" : typePara.PayRefno ),
                        new SqlParameter("@gatewayid" , (typePara.GateWayID ==null  ) ? "" : typePara.GateWayID ),
                        new SqlParameter("@stationid" , (typePara.StationID ==null  ) ? "" : typePara.StationID ),
                        new SqlParameter("@routid" , (typePara.RouteID  ==null  ) ? "" : typePara.Remarks ),
                        new SqlParameter("@ShipValType" , (typePara.ShipValType  ==null  ) ? "" : typePara.ShipValType ),
                        new SqlParameter("@Status" ,"EDIT"),
                        new SqlParameter("@Usm_Id" ,typePara.UserID),
                      };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_AddEditInvDutyInvoice]", paraList)
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
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;
            }

            return mMessage;
        }

        public ResponseMessage DeleteDetail(InvDutyDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<InvDutyDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<InvDutyDomainView> GetDetails(InvDutyDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<InvDutyDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public InvDutyConsAwbDomainView GetAwbDetail(string airbilNo)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyConsAwbResult> uof = new ExpressUnitOfWork<InvDutyConsAwbResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {  
                           new SqlParameter("@awbNumber" ,airbilNo)

                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyAWBDetail]", paraList)
                                        select new InvDutyConsAwbDomainView
                                        {
                                            GroupID = SR.GroupID,
                                            CompanyID = SR.CompanyID,
                                            CompanyName = SR.CompanyName,
                                            AgencyID = SR.AgencyID,
                                            AgencyName = SR.AgencyName,
                                            ConsID = SR.ConsID,
                                            TransDate = SR.TransDate,
                                            ShipType = SR.ShipType,
                                            ShipTypeN = SR.ShipTypeN,                                           
                                            ExpressID = SR.ExpressID,
                                            MasterAwbNo = SR.MasterAwbNo,
                                            AirWayBillNo = SR.AirWayBillNo,
                                            GoodDescp = SR.GoodDescp,
                                            ShipCntr = SR.ShipCntr,
                                            ShipCntrN = SR.ShipCntrN,
                                            DestiCntr = SR.DestiCntr,
                                            DestiCntrN = SR.DestiCntrN,
                                            AccountNo = SR.AccountNo,
                                            PayBy = SR.PayBy,
                                            ShipperValue = SR.ShipperValue,
                                            BillTaxChgType = SR.BillTaxChgType,
                                            OrgName = SR.OrgName,
                                            ContactPerson = SR.ContactPerson,
                                            Address1 = SR.Address1,
                                            Address2 = SR.Address2,                                           
                                            City = SR.City,
                                            ManiCurrCode = SR.ManiCurrCode,
                                            DutyExcemptY = SR.DutyExcemptY,
                                            StationID = SR.StationID,
                                            SenRefNotes = SR.SenRefNotes,
                                            DestGateWay  = SR.DestGateWay,
                                            OrginGateWay = SR.OrginGateWay ,
                                            CusdecNo = SR.CusdecNo ,
                                            ClrShipCurr = SR.ClrShipCurr ,
                                            ClrShipValue = SR.ClrShipValue ,
                                            CountryC = SR.CountryC ,
                                            CountryN = SR.CountryN ,
                                            PhoneN =SR.PhoneN,
                                            GateWayID  =SR.GateWayID ,
                                            RouteID = SR.RouteID,
                                            OrgStation = SR.OrgStation ,
                                            DesStation = SR.DesStation ,
                                            ConsoleID =SR.ConsoleID 

                                        }).FirstOrDefault();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public InvDutyJobDomainView GetJobDetail(int companyID, int agencyID, string expressID)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyJobResult> uof = new ExpressUnitOfWork<InvDutyJobResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                       {                           
                            new SqlParameter("@companyID" ,companyID),
                              new SqlParameter("@agencyCode" ,agencyID ),
                                new SqlParameter("@expressID" ,expressID)
                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvJob]", paraList)
                                        select new
                                        {
                                            SR.ExpressID,
                                            SR.JobNo,
                                            SR.RefNo1,
                                            SR.RefNo2,
                                            SR.RefNo3

                                        }).ToList().Select(SR => new InvDutyJobDomainView
                                        {
                                            ExpressID = SR.ExpressID,
                                            JobNo =  SR.JobNo,
                                            RefNo1 = SR.RefNo1 ,
                                            RefNo2 = SR.RefNo2 ,
                                            RefNo3 = SR.RefNo3 

                                        }).FirstOrDefault();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public InvDutyDomainView GetInvDutyDetail(int companyID, int agencyID, string expressID)
        {
            try
            {

                using (IExpressUnitOfWork<InvDutyResult> uof = new ExpressUnitOfWork<InvDutyResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {                           
                            new SqlParameter("@companyID" ,companyID),
                                new SqlParameter("@agencyCode" ,agencyID ),
                                    new SqlParameter("@expressID" ,expressID ),

                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyTAX]", paraList)
                                        select new
                                        {
                                            SR.CMPY,
                                            SR.CompanyN,
                                            SR.AgncyCode,
                                            SR.AgencyN,
                                            SR.ExpressID,
                                            SR.ConsId,
                                            SR.MasterAwbNo,
                                            SR.CusdecNo,
                                            SR.GoodDescp,
                                            SR.Remarks,
                                            SR.TaxCodeOne,
                                            SR.Doctype,
                                            SR.JobNo,
                                            SR.InvNo,
                                            SR.OrgCode,
                                            SR.OrgName,
                                            SR.OrgCntrCode,
                                            SR.OrgCntrN,
                                            SR.PayMode,
                                            SR.InvMode,
                                            SR.OrgPerson,
                                            SR.OrgAddr1,
                                            SR.OrgAddr2,
                                            SR.OrgCity,
                                            SR.OrgCityCode,
                                            SR.SalesArea,
                                            SR.TransDate,

                                            SR.AgnAWBNo,
                                            SR.ShipType,
                                            SR.ShipTypeN,
                                            SR.MissRoute,
                                            SR.BillTo,
                                            SR.PayBy,
                                            SR.CustomValCur,
                                            SR.CustomVal,
                                            SR.ShipperValue,
                                            SR.ManiCurrCode,
                                            SR.ManiConvRate,
                                            SR.SenRefNotes,
                                            SR.RouteID,
                                            SR.StationID,
                                            SR.GateWayID,
                                            SR.PayAccount ,
                                            SR.PayRefNo ,
                                            SR.PayDate ,
                                            SR.PayNo 
                                            


                                        }).ToList().Select(SR => new InvDutyDomainView
                                        {

                                            CompanyID = SR.CMPY,
                                            CompanyN = SR.CompanyN,
                                            AgncyCode = SR.AgncyCode,
                                            AgencyN = SR.AgencyN,                                           
                                            ExpressID = SR.ExpressID,
                                            AirWayBill = SR.AgnAWBNo,
                                            ShipType = SR.ShipType,
                                            ShipCntr = SR.ShipTypeN,
                                            BillTaxChgType = SR.BillTo,
                                            PaidBy = SR.PayBy,
                                            ConsID = SR.ConsId,
                                            MasterAwbNo = SR.MasterAwbNo,
                                            CusdecNo = SR.CusdecNo,
                                            GoodDescp = SR.GoodDescp,
                                            Remarks = SR.Remarks,
                                            TaxCodeOne = SR.TaxCodeOne,
                                            InvoiceType = SR.Doctype,
                                            JobNo = SR.JobNo.ToString(),
                                            InvoiceNo = SR.InvNo.ToString(),
                                            OrgnizCode = SR.OrgCode.ToString(),
                                            OrgnizName = SR.OrgName,
                                            OrgPerson = SR.OrgPerson,
                                            OrgAddr1 = SR.OrgAddr1,
                                            OrgAddr2 = SR.OrgAddr2,
                                            OrgCity = SR.OrgCity,
                                            OrgCityCode = SR.OrgCityCode,
                                            OrgCntrCode = SR.OrgCntrCode,
                                            OrgCntrN = SR.OrgCntrN,
                                            InvMode = SR.InvMode,
                                            SalesAreaID = SR.SalesArea,
                                            TransDate = SR.TransDate,

                                            ManiCurrCode = SR.ManiCurrCode,
                                            ShipperValue = SR.ShipperValue,
                                            ManExtRate = SR.ManiConvRate,
                                            ShipValueLoc = SR.CustomVal,
                                            CustomValCur = SR.CustomValCur,
                                            PayMode = SR.PayMode,
                                            RouteID = SR.RouteID ,
                                            GateWayID =SR.GateWayID ,
                                            StationID = SR.StationID ,
                                            PayAccount=  SR.PayAccount,
                                            PayRefno = SR.PayRefNo,
                                            PayDate=SR.PayDate,
                                            PayNo=SR.PayNo


                                        }).FirstOrDefault();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<InvDutyDoctypeDomainView> GetDutyDoctypes(int companyID, int agencyID, string  shiptype, string billto)
        {
            try
            {

                using (IExpressUnitOfWork<InvDutyDoctypeResult> uof = new ExpressUnitOfWork<InvDutyDoctypeResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {  new SqlParameter("@companyID", companyID),
                           new SqlParameter("@agencyID" ,agencyID),                           
                            new SqlParameter("@ShipType" , (shiptype==null) ?"":shiptype ),
                             new SqlParameter("@BillDtaxChg" ,  ( billto ==null )?"":  billto)
                       };

                   
                    var dutDoctypes = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyDocTypes]", paraList)
                                        select new InvDutyDoctypeDomainView
                                        {                                           
                                            DocType = SR.DocType.Trim(),
                                            DoctypeN = SR.DoctypeN,
                                            DocCata = SR.DocCata,
                                            BillOrgCode = SR.BillOrgCode,
                                            PaidLF = SR.PaidLF,                                           
                                            ExgRateTarif = SR.ExgRateTarif,                                           
                                            ShipValuType = SR.ShipValuType

                                        }).ToList();

                    return dutDoctypes;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public InvDutyDoctypeDomainView GetDutyDocument(int companyID, int agencyID, decimal shipV, string billto, string dutyEx, string shipT)
        {
            try
            {

                using (IExpressUnitOfWork<InvDutyDoctypeResult> uof = new ExpressUnitOfWork<InvDutyDoctypeResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {  new SqlParameter("@companyID", companyID),
                          new SqlParameter("@agencyID" ,agencyID),
                           new SqlParameter("@shipValue" ,shipV ),
                             new SqlParameter("@billTaxType" , (billto ==null) ?"" :billto),
                              new SqlParameter("@dutyExtemp" ,  (dutyEx==null || dutyEx =="N") ?"": dutyEx),
                               new SqlParameter("@ShipType" , (shipT==null) ?"":shipT )

                       };
                   
                    var dutyDocuments = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetDutyInvDocumet]", paraList)
                                        select new InvDutyDoctypeDomainView
                                        {                                            
                                            DocType = SR.DocType.Trim(),
                                            DoctypeN = SR.DoctypeN,
                                            DocCata = SR.DocCata,
                                            BillOrgCode = SR.BillOrgCode,
                                            PaidLF = SR.PaidLF,                                           
                                            ExgRateTarif = SR.ExgRateTarif,
                                            IsHighValue = SR.IsHighValue,
                                            ShipValueTypeCata = SR.ShipValueTypeCata,
                                            ShipValuType = SR.ShipValuType

                                        }).FirstOrDefault();

                    return dutyDocuments;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            try
            {
                using (IExpressUnitOfWork<UserAgencyDetailResult> uof = new ExpressUnitOfWork<UserAgencyDetailResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                              new SqlParameter("@UserID", UserId) ,
                               new SqlParameter("@ModuleID", ModuleId) ,
                                new SqlParameter("@MenuID",MenueId)
                          };
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
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<InvDutySalesAreaDomainView> GetDutyLocations(int companyID, int agencyID, string country)
        {
            try
            {

                using (IExpressUnitOfWork<InvDutyLocationResult> uof = new ExpressUnitOfWork<InvDutyLocationResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {  new SqlParameter("@country",country ),
                            new SqlParameter("@cmpy",companyID ),
                               new SqlParameter("@agnecy", agencyID )

                       };
                    var dutyLocation = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyLocation]", paraList)
                                        select new InvDutySalesAreaDomainView
                                        {
                                            SalesAreaID = SR.LocationID.Trim(),
                                            SalesAreaName = SR.LocationName,
                                            BranchCode = SR.BranchCode

                                        }).ToList();
                    return dutyLocation;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public InvDutyOrgnizDomainView GetDutyOrgnizFinance(int companyID, int orgCode)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyOrgnizResult> uof = new ExpressUnitOfWork<InvDutyOrgnizResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                      {  new SqlParameter("@companyID", companyID),
                          new SqlParameter("@orgCode" ,orgCode)

                      };
                    var orgFinance = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyOrgzFinace]", paraList)
                                        select new InvDutyOrgnizDomainView
                                        { 
                                            SalesAreaID = SR.SalesAreaID,   
                                            IsCredit = SR.IsCredit,
                                            InvMode = SR.InvDutax,
                                            TaxCodeOne = SR.TaxCodeOne 

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

        public InvDutyOrgnizDomainView GetDutyOrgnization(int companyID, int orgCode, string icpc)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyOrgnizResult> uof = new ExpressUnitOfWork<InvDutyOrgnizResult>())
                {
                    
                       SqlParameter[] paraList = new SqlParameter[]
                      {  new SqlParameter("@companyID", companyID),
                          new SqlParameter("@orgCode" ,orgCode),
                            new SqlParameter("@icpcNo" ,(icpc ==null)? "": icpc),

                      };
                    var orgFinance = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyOrgzation]", paraList)
                                      select new InvDutyOrgnizDomainView
                                      {
                                          CompanyCode = SR.OrgnizCode,
                                          CompanyName = SR.OrganizName,
                                          IsDeptInv = SR.IsDeptWise,
                                          Address1 = SR.Address1,
                                          Address2 = SR.Address2,
                                          CountryCode = SR.CntrCode,
                                          CountryName = SR.CntrName,
                                          SalesAreaID = SR.SalesAreaID,                                         
                                          CityCode = SR.CityID,
                                          CityName = SR.CityName,   
                                          OrgPhone = SR.OrgPhone                                       
                                        

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

        public InvDutyExtrateDomainView GetDutyClearenceExtrate(InvDutyExtrateDomainView _para)
        {
            try
            {

                using (IExpressUnitOfWork<InvDutyExtrateResult> uof = new ExpressUnitOfWork<InvDutyExtrateResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {  new SqlParameter("@dateTo", _para.EffectDate ),
                           new SqlParameter("@companyID" ,_para.companyID  ),
                            new SqlParameter("@currency" ,_para.DefCurrency )

                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Util].[Finance_GetManifExchangeRate]", paraList)
                                        select new InvDutyExtrateDomainView
                                        {
                                            ExgRatTarif = SR.ExgRatTarif,
                                            BaseCurrency = SR.BaseCurrency,
                                            Currency = SR.Currency,
                                            EffectDate = SR.EffectDate,
                                            ExgRate = SR.ExgRate,
                                            ClearCurrency = SR.ClearCurrency

                                        }).FirstOrDefault();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        


        public IList<InvDutyChargeDomainView> GetCharges(InvChargeParamDomainView _para)
        {
           /// DateTime.ParseExact((day + "/" + month + "/" + year), "dd/MM/yyyy", null)
            try
            {
                using (IExpressUnitOfWork<InvDutyChargeResult> uof = new ExpressUnitOfWork<InvDutyChargeResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                       {
                          
                            new SqlParameter("@CompanyID", _para.CompanyID ),
                             new SqlParameter("@InvDocType" ,_para.InvDocType ),
                                new SqlParameter("@payType" ,( _para.PayDocType ==null) ? "" :_para.PayDocType ),
                              new SqlParameter("@DocDate" ,_para.DocDate ),
                               new SqlParameter("@shipValue",_para.ClrShipValue),
                                new SqlParameter("@shipValCate" ,_para.ShipValCat),
                                 new SqlParameter("@orgcode" ,_para.OrgCode) ,
                                  new SqlParameter("@dutyExtemp" ,_para.IsDutyExcempt ) 
                                  
                                  
                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetDutyChargeCode]", paraList)
                                        select new
                                        {
                                            SR.ChargeCode,
                                            SR.ChargeDesc,
                                            SR.DocType,
                                            SR.GlRevAc,
                                            SR.GlCosAc,
                                            SR.Seqno,
                                            SR.TaxCode1,
                                            SR.TaxCode2,
                                            SR.TaxCode3,
                                            SR.TaxCode1Rate,
                                            SR.TaxCode2Rate,
                                            SR.TaxCode3Rate,
                                            SR.SellLC,
                                            SR.PayLC ,
                                            SR.IsSellFix ,
                                            SR.IsCostFix 
                                        }).ToList().Select(SR => new InvDutyChargeDomainView
                                        {
                                            ChargeCode = SR.ChargeCode,
                                            ChargeDesc = SR.ChargeDesc,
                                            DocType = SR.DocType,
                                            GlRevAc = SR.GlRevAc,
                                            GlCosAc = SR.GlCosAc,
                                            Seqno = SR.Seqno,
                                            TaxCode1 = SR.TaxCode1,
                                            TaxCode2 = SR.TaxCode2,
                                            TaxCode3 = SR.TaxCode3,
                                            TaxCode1Rate = Convert.ToDecimal(SR.TaxCode1Rate),
                                            TaxCode2Rate = Convert.ToDecimal(SR.TaxCode2Rate),
                                            TaxCode3Rate = Convert.ToDecimal(SR.TaxCode3Rate),
                                            SellLC = Convert.ToDecimal(SR.SellLC),
                                            PayLC = Convert.ToDecimal(SR.PayLC ),
                                            IsCostFix = SR.IsCostFix ,
                                            IsSellFix = SR.IsSellFix 

                                        }).ToList();

                    return customerHead;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public InvDutyExtrateDomainView GetDutyExchangerate(InvDutyExtrateDomainView _para)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyExtrateResult> uof = new ExpressUnitOfWork<InvDutyExtrateResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                       {
                         new SqlParameter("@dateTo", _para.EffectDate ),
                          new SqlParameter("@InvoiceType" ,_para.InvDocType ),
                           new SqlParameter("@companyID" ,_para.companyID  )
                       };
                  
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Finance].[TLM_GetDutyExchangeRate]", paraList)
                                        select new InvDutyExtrateDomainView
                                        {
                                            ExgRatTarif = SR.ExgRatTarif,
                                            DefCurrency = SR.DefCurrency,
                                            BaseCurrency = SR.BaseCurrency,
                                            EffectDate = SR.EffectDate,
                                            ExgRate = SR.ExgRate

                                        }).FirstOrDefault();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseMessage InoviceProccess(InvDutyDomainView invDuty)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                      {

                       new SqlParameter("@CMPY", invDuty.CompanyID),
                        new SqlParameter("@JobNo" , (invDuty.JobNo=="")?"0" :invDuty.JobNo ),
                         new SqlParameter("@DocID", "INV"),
                          new SqlParameter("@DocType", (invDuty.InvoiceType==null)? "":invDuty.InvoiceType ),
                           new SqlParameter("@OrgCode",Convert.ToInt32( invDuty.OrgnizCode) ),
                            new SqlParameter("@DocDate", invDuty.InvoiceDate),
                             new SqlParameter("@PayMode",(invDuty.PayMode==null)? "": invDuty.PayMode ),
                              new SqlParameter("@InvMode", invDuty.InvMode),
                               new SqlParameter("@Usm_Id" ,invDuty.UserID),
                                new SqlParameter("@InvType" ,"D"),
                        new SqlParameter("@OrgName" ,(invDuty.OrgnizName==null)? "":invDuty.OrgnizName ),
                         new SqlParameter("@OrgPerson" ,(invDuty.OrgPerson==null)? "":invDuty.OrgPerson),
                          new SqlParameter("@OrgAddr1" , (invDuty.OrgAddr1==null)?"" :invDuty.OrgAddr1 ),
                           new SqlParameter("@OrgAddr2" ,(invDuty.OrgAddr2 ==null)? "" :invDuty.OrgAddr2),
                            new SqlParameter("@OrgCityCode" , (invDuty.OrgCity ==null)?"":invDuty.OrgCity),
                             new SqlParameter("@OrgCountry" , (invDuty.OrgCntrCode==null)?"" :invDuty.OrgCntrCode ),

                      };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[FinanceGL].[USP_InvoiceProccess]", paraList)
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
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;
            }

            return mMessage;
        }

        public ResponseMessage PaymentProccess(InvDutyDomainView invDuty)
        {
            ResponseMessage mMessage = new ResponseMessage();

            try
            {
                using (IExpressUnitOfWork<ResponseProcessResult> uof = new ExpressUnitOfWork<ResponseProcessResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                      {
                        new SqlParameter("@varConsID", (invDuty.ConsID==null)? "":invDuty.ConsID +"," ),
                        new SqlParameter("@CMPY", invDuty.CompanyID),
                        new SqlParameter("@Agency" , invDuty.AgncyCode),   
                        new SqlParameter("@DocDate", invDuty.PayDate),
                        new SqlParameter("@Naration","Payment Process"),                             
                        new SqlParameter("@Usm_Id" ,invDuty.UserID),  
                        new SqlParameter("@ShipValType" , invDuty.ShipValType ),
                        new SqlParameter("@ExpressNo" , invDuty.ExpressID.Trim()),
                        new SqlParameter("@payAccId" , invDuty.PayAccount)

                      };

                    var responce = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_DutyPaymentManualProccess]", paraList)
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
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception ex)
            {
                mMessage.IsSuccess = false;
                mMessage.StrMessage = AppMessage.SystemException;
                throw;
            }

            return mMessage;
        }

        public IList<InvDutyChargeDomainView> GetJobCharges(InvChargeParamDomainView _para)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyChargeResult> uof = new ExpressUnitOfWork<InvDutyChargeResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                       {
                           new SqlParameter("@groupID", 1),
                            new SqlParameter("@companyID" ,_para.CompanyID ),
                              new SqlParameter("@agencyCode" ,_para.AgencyID  ),
                                new SqlParameter("@expressID" , (_para.ExpressID==null) ? "" :_para.ExpressID ),
                                 new SqlParameter("@invoiceNo" ,(_para.InvoiceNo==null)?"0" :_para.InvoiceNo   ),
                                  new SqlParameter("@paymentNo" ,(_para.paymentNo==null)?"0" :_para.paymentNo   ),
                                  new SqlParameter("@invType" ,  ( _para.InvDocType ==null) ? "" :_para.InvDocType ),
                                   new SqlParameter("@payType" ,( _para.PayDocType ==null) ? "" :_para.PayDocType )


                       };
                    var customerHead = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyJOB]", paraList)
                                        select new
                                        {
                                            SR.ChargeCode,
                                            SR.ChargeDesc,
                                            SR.DocType,
                                            SR.GlRevAc,
                                            SR.GlCosAc,
                                            SR.Seqno,
                                            SR.TaxCode1,
                                            SR.TaxCode2,
                                            SR.TaxCode3,
                                            SR.TaxCode1Rate,
                                            SR.TaxCode2Rate,
                                            SR.TaxCode3Rate,
                                            SR.SellLC,
                                            SR.PayLC,
                                            SR.ConvRate



                                        }).ToList().Select(SR => new InvDutyChargeDomainView
                                        {
                                            ChargeCode = SR.ChargeCode,
                                            ChargeDesc = SR.ChargeDesc,
                                            DocType = SR.DocType,
                                            GlRevAc = SR.GlRevAc,
                                            GlCosAc = SR.GlCosAc,
                                            Seqno = SR.Seqno,
                                            TaxCode1 = SR.TaxCode1,
                                            TaxCode2 = SR.TaxCode2,
                                            TaxCode3 = SR.TaxCode3,
                                            TaxCode1Rate = Convert.ToDecimal(SR.TaxCode1Rate),
                                            TaxCode2Rate = Convert.ToDecimal(SR.TaxCode2Rate),
                                            TaxCode3Rate = Convert.ToDecimal(SR.TaxCode3Rate),
                                            SellLC = Convert.ToDecimal(SR.SellLC),
                                            PayLC = Convert.ToDecimal(SR.PayLC),
                                            ConvRate = SR.ConvRate


                                        }).ToList();

                    return customerHead;

                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, errorModule, updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<InvDutyClrPayAccountDomainView> GetClrPayAccounts(int companyID)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyClrPayAccountResult> uof = new ExpressUnitOfWork<InvDutyClrPayAccountResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                   {
                       new SqlParameter("@companyID", companyID),                          

                   };
                    var payaccounts = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetDutyClrPayAccounts]", paraList)
                                      select new InvDutyClrPayAccountDomainView
                                      {
                                         AccountCode =SR.AccountCode ,
                                         AccDesc = SR.AccDesc ,
                                         DefV =SR.DefV

                                      }).ToList();

                    return payaccounts;

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

        public IList<InvDutyAutoChargeDomainView> GetAutoCharges(string docid, int shV, string docT, string chgC , string dutyExcempt, decimal shipValueLc)
        {
            try
            {
                using (IExpressUnitOfWork<InvDutyAutoChargeResult> uof = new ExpressUnitOfWork<InvDutyAutoChargeResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                   {
                       new SqlParameter("@docid", docid),
                        new SqlParameter ("@shVal" , shV ), 
                         new SqlParameter ("@docType" , docT ) ,
                          new SqlParameter ("@chgCalCode" , chgC) ,
                           new SqlParameter("@dutyExtemp",dutyExcempt ),
                            new SqlParameter("@shipValue" ,shipValueLc)

                   };
                    var orgcharges = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetAutoChargesCal]", paraList)
                                       select new InvDutyAutoChargeDomainView
                                       {
                                          ChargeCode = SR.ChargeCode ,
                                          ChargeCodeCal = SR.ChargeCodeCal ,
                                          DocType  =SR.DocType ,
                                          DocId = SR.DocId ,
                                          ShipValueTypeCata = SR.ShipValueTypeCata ,
                                          ValueP = SR.ValueP 
                                          

                                       }).ToList();

                    return orgcharges;

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

        public IList<TaxInvoiceReportDomainView> GetDutyPrint(InvoiceDutyClearencePara _param)
        {
            try
            {
                using (IExpressUnitOfWork<InvoiceDutyRepResult> uof = new ExpressUnitOfWork<InvoiceDutyRepResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                               new SqlParameter("@companyID", _param.CompanyID ),
                                new SqlParameter("@agencyCode",_param.AgencyID),
                                 new SqlParameter("@invoiceNo",_param.InvoiceNo ),
                                   new SqlParameter("@userid",_param.UserID )
                          };
                    var invTaxReport = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_RepInvoiceDutyClearence]", paraList)
                                        select new
                                        {
                                            SR.CompanyID,
                                            SR.GroupID,
                                            SR.DocReference,
                                            SR.RefNo1,
                                            SR.RefNo2,
                                            SR.RefNo3,
                                            SR.DocDate,
                                            SR.InvNo,
                                            SR.JobNo,
                                            SR.OrgName,
                                            SR.OrgCountry,
                                            SR.OrgAddr1,
                                            SR.OrgAddr2,
                                            SR.OrgCity,
                                            SR.ChargeCode,
                                            SR.ChargeDesc,
                                            SR.ConvRate,
                                            SR.LC,
                                            SR.FC,
                                            SR.LineAmount,
                                            SR.LineTaxTotal,
                                            SR.LineTotalAmount,
                                            SR.DocType,
                                            SR.Remarks,
                                            SR.CustomVal,
                                            SR.TAX1,
                                            SR.TAX2,
                                            SR.TAX3,
                                            SR.SVATNO,
                                            SR.VATNO,
                                            SR.Detain,
                                            SR.GoodDescp,
                                            SR.VALFC,
                                            SR.OrgContact,
                                            SR.BillOrgCountry,
                                            SR.PayMode,
                                            SR.SenRefNotes,
                                            SR.PrintUser,
                                            SR.ManCurrency,
                                            SR.Sender,
                                            SR.Receiver,
                                            SR.ChargeArabic,
                                            SR.CusdecNo,
                                            SR.CustomsPkgVal,
                                            SR.PayRefNo,
                                            SR.TotPkgs,
                                            SR.TotWgt,
                                            SR.ShipDate,
                                            SR.Paydate

                                        }).ToList().Select(SR => new TaxInvoiceReportDomainView
                                        {
                                            GroupID = SR.GroupID,
                                            CompanyID = SR.CompanyID,
                                            DocReference = SR.DocReference,
                                            RefNo1 = SR.RefNo1,
                                            RefNo2 = SR.RefNo2,
                                            RefNo3 = SR.RefNo3,
                                            DocDate = SR.DocDate,
                                            InvNo = Convert.ToString(SR.InvNo),
                                            JobNo = Convert.ToDecimal(SR.JobNo),
                                            OrgName = SR.OrgName,
                                            OrgCountry = SR.OrgCountry,
                                            OrgAddr1 = SR.OrgAddr1,
                                            OrgAddr2 = SR.OrgAddr2,
                                            OrgCity = SR.OrgCity,
                                            ChargeCode = SR.ChargeCode,
                                            ChargeDesc = SR.ChargeDesc,
                                            ConvRate = SR.ConvRate,
                                            LineAmount = SR.LineAmount,
                                            LC = SR.LC,
                                            FC = SR.FC,
                                            LineTaxTotal = SR.LineTaxTotal,
                                            LineTotalAmount = SR.LineTotalAmount,
                                            DocType = SR.DocType,
                                            Remarks = SR.Remarks,
                                            CustomVal = SR.CustomVal,
                                            TAX1 = SR.TAX1,
                                            TAX2 = SR.TAX2,
                                            TAX3 = SR.TAX3,
                                            SVATNO = SR.SVATNO,
                                            VATNO = SR.VATNO,
                                            Detain = SR.Detain,
                                            GoodDescp = SR.GoodDescp,
                                            VALFC = SR.VALFC,
                                            OrgContact = SR.OrgContact,
                                            BillOrgCountry = SR.BillOrgCountry,
                                            PayMode = SR.PayMode,
                                            SenRefNotes = SR.SenRefNotes,
                                            PrintUser = SR.PrintUser,
                                            ManCurrency = SR.ManCurrency,
                                            Sender = SR.Sender,
                                            Receiver = SR.Receiver,
                                            ChargeArabic = SR.ChargeArabic,
                                            CustomsPkgVal = SR.CustomsPkgVal,
                                            TotWgt = SR.TotWgt,
                                            TotPkgs = SR.TotPkgs,
                                            CusdecNo = SR.CusdecNo,
                                            PayRefNo = SR.PayRefNo,
                                            ShipDate = SR.ShipDate,
                                            Paydate = SR.Paydate

                                        }).ToList();


                    return invTaxReport;
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Clearence Report", updateException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public InvDutyJobtransactDomainView GetDutyJobtrasact(int companyID, int agencyID, string expressID, string invtype, string  invno)
        {

            try
            {
                using (IExpressUnitOfWork<InvDutyJobtransactResult> uof = new ExpressUnitOfWork<InvDutyJobtransactResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                   {
                       new SqlParameter("@companyID", companyID ),
                        new SqlParameter ("@agencyCode" , agencyID ),
                         new SqlParameter ("@expressID" ,((expressID==null )?"": expressID )) ,
                          new SqlParameter ("@invoiceNo" ,((invno ==null || invno =="")? "0" : invno)),
                           new SqlParameter("@invType"  ,((invtype==null )? "" :invtype))

                   };
                    var jobtrans = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyJobtans]", paraList)
                                    select new
                                    {

                                        SR.InvoiceDate,
                                        SR.TransDate,
                                        SR.PayDocDate ,
                                        SR.PaymentNo ,
                                        SR.InvoiceNo ,
                                        SR.SellDocType ,
                                        SR.PayDocType 
                                    }).ToList().Select(SR => new InvDutyJobtransactDomainView
                                    {
                                        InvoiceDate  =Convert.ToDateTime( SR.InvoiceDate) ,
                                        TransDate =Convert.ToDateTime( SR.TransDate ),
                                        PayDocDate = Convert.ToDateTime(SR.PayDocDate ),
                                        PaymentNo = SR.PaymentNo,
                                        SellDocType=SR.SellDocType ,
                                        PayDocType =SR.PayDocType 

                                    }).FirstOrDefault();

                    return jobtrans;

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

        public IList<InvDutyOrgnizChargeDomainView> GetOrnizCharges(int companyID, int OrgCode, string excempt)
        {

            try
            {
                using (IExpressUnitOfWork<InvDutyOrgnizChargeResult> uof = new ExpressUnitOfWork<InvDutyOrgnizChargeResult>())
                {

                    SqlParameter[] paraList = new SqlParameter[]
                   {
                       new SqlParameter("@CompanyID", companyID ),
                        new SqlParameter ("@OrgCode" , OrgCode ),
                         new SqlParameter ("@excempt" ,((excempt==null )?"": excempt )) ,
                        

                   };
                    var jobtrans = (from SR in uof.Reposotery.GetDataBySp("[Express].[TLM_GetInvDutyOrgnizCharges]", paraList)
                                    select new InvDutyOrgnizChargeDomainView
                                    {
                                        ChargeCode =SR.ChargeCode ,
                                        Amount = SR.Amount 
                                    }).ToList();

                    return jobtrans;

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

        public string GetEmailAddress(int OrgCode, int GroupID)
        {
            try
            {

                using (IExpressUnitOfWork<OrgEmaiResult> uof = new ExpressUnitOfWork<OrgEmaiResult>())
                {
                    SqlParameter[] paraList = new SqlParameter[]
                          {
                               new SqlParameter("@OrgCode",OrgCode )

                          };
                    var docTypes = (from RE in uof.Reposotery.GetDataBySp("[Express].[USP_GetOrgEmail]", paraList)
                                    select new
                                    {
                                        RE.OrgDelEmail,

                                    }).ToList().FirstOrDefault();

                    if (docTypes != null)
                    {
                        return docTypes.OrgDelEmail;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (DbUpdateException updateException)
            {
                var updateBaseException = updateException.GetBaseException() as SqlException;
                throw new DataUpdateException(updateBaseException.Number.ToString(), updateBaseException.Message, "Email", updateException);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
