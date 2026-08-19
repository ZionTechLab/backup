using Express.Interfaces.Invoice;
using Express.View.Domain.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Invoice;

namespace Express.Business.Invoice
{
    public class InvDutyBusiness : IInvDutyProvider<InvDutyDomainView>
    {
        private readonly IInvDutyProvider<InvDutyDomainView> _dutyData;
        public InvDutyBusiness(IInvDutyProvider<InvDutyDomainView> _dutyData)
        {
            this._dutyData = _dutyData;
        }
        public ResponseMessage SaveDetails(InvDutyDomainView typePara)
        {
            typePara.ChargeXML = GetChargeXml(typePara);
            return _dutyData.SaveDetails(typePara);
        }
        public ResponseMessage EditDetails(InvDutyDomainView typePara)
        {
            typePara.ChargeXML = GetChargeXml(typePara);
            return _dutyData.EditDetails(typePara);
        }

        public ResponseMessage DeleteDetail(InvDutyDomainView typePara)
        {
            return _dutyData.DeleteDetail(typePara);
        }

        public List<InvDutyDomainView> GetDetails()
        {
            return _dutyData.GetDetails();
        }

        public List<InvDutyDomainView> GetDetails(InvDutyDomainView typePara)
        {
            return _dutyData.GetDetails(typePara);
        }

        public List<InvDutyDomainView> GetDetails(string code)
        {
            return _dutyData.GetDetails(code);
        }

        public InvDutyConsAwbDomainView GetAwbDetail( string airbilNo)
        {
            return _dutyData.GetAwbDetail( airbilNo);
        }

        public InvDutyJobDomainView GetJobDetail(int companyID, int agencyID, string expressID)
        {
            return _dutyData.GetJobDetail(companyID, agencyID, expressID);
        }

        public InvDutyDomainView GetInvDutyDetail(int companyID, int agencyID, string expressID)
        {
            return _dutyData.GetInvDutyDetail(companyID, agencyID, expressID);
        }

        public IList<InvDutyDoctypeDomainView> GetDutyDoctypes(int companyID, int agencyID, string shiptype, string billto, decimal shipV, string dutyEx)
        {
            return _dutyData.GetDutyDoctypes(companyID, agencyID, shiptype ,billto , shipV , dutyEx);
        }

        public InvDutyDoctypeDomainView GetDutyDocument(int companyID, int agencyID, decimal shipV, string billto, string dutyEx, string shipT)
        {
            return _dutyData.GetDutyDocument(companyID, agencyID, shipV, billto , dutyEx , shipT);
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _dutyData.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public List<InvDutySalesAreaDomainView> GetDutyLocations(int companyID, int agencyID, string country)
        {
            return _dutyData.GetDutyLocations(companyID, agencyID, country);
        }

        public InvDutyOrgnizDomainView GetDutyOrgnizFinance(int companyID, int orgCode)
        {
            return _dutyData.GetDutyOrgnizFinance(companyID, orgCode);
        }

        public InvDutyOrgnizDomainView GetDutyOrgnization(int companyID, int orgCode, string icpc)
        {
            return _dutyData.GetDutyOrgnization(companyID, orgCode, icpc);
        }

        public InvDutyExtrateDomainView GetDutyClearenceExtrate(InvDutyExtrateDomainView _para)
        {
            return _dutyData.GetDutyClearenceExtrate(_para);
        }

        public IList<InvDutyChargeDomainView> GetCharges(InvChargeParamDomainView _para)
        {
            return _dutyData.GetCharges(_para);

        }

        public InvDutyExtrateDomainView GetDutyExchangerate(InvDutyExtrateDomainView _para)
        {
            return _dutyData.GetDutyExchangerate(_para);
        }

        public ResponseMessage InoviceProccess(InvDutyDomainView invDuty)
        {
            return _dutyData.InoviceProccess(invDuty);
        }

        public ResponseMessage PaymentProccess(InvDutyDomainView invDuty)
        {
            return _dutyData.PaymentProccess(invDuty);
        }

        public IList<InvDutyChargeDomainView> GetJobCharges(InvChargeParamDomainView _para)
        {
            return _dutyData.GetJobCharges(_para);
        }

        public IList<InvDutyClrPayAccountDomainView> GetClrPayAccounts(int companyID)
        {
            return _dutyData.GetClrPayAccounts(companyID);
        }

        public IList<InvDutyAutoChargeDomainView> GetAutoCharges(string docid, int shV, string docT, string chgC, string dutyExcempt, decimal shipValueLc)
        {
            return _dutyData.GetAutoCharges(  docid,   shV,  docT,  chgC , dutyExcempt, shipValueLc);
        }

        public IList<TaxInvoiceReportDomainView> GetDutyPrint(InvoiceDutyClearencePara _param)
        {
            return _dutyData.GetDutyPrint(_param);
        }

        public InvDutyJobtransactDomainView GetDutyJobtrasact(int companyID, int agencyID, string expressID, string invtype, string  invno, string payno)
        {
            return _dutyData.GetDutyJobtrasact(companyID, agencyID, expressID, invtype, invno , payno);
        }

        public IList<InvDutyOrgnizChargeDomainView> GetOrnizCharges(int companyID, int OrgCode, string excempt)
        {
            return _dutyData.GetOrnizCharges(companyID, OrgCode, excempt);
        }

        public string GetChargeXml(InvDutyDomainView typePara)
        {
            string xmlString = "<ROOT>";


            foreach (InvDutyChargeDomainView item in typePara.charges)
            {
                if (item.SellLC > 0 || item.PayLC >0)
                {
                    xmlString = xmlString + "<ROW>" +
             "<Seqno>" + item.Seqno + "</Seqno>"
             + "<ChargeCode>" + item.ChargeCode.Trim() + "</ChargeCode>"
             + "<ChargeDesc>" + item.ChargeDesc + "</ChargeDesc>"
             + "<SellLC>" + item.SellLC + "</SellLC>"
             + "<PayLC>" + item.PayLC + "</PayLC>"
             + "<LCType>" + typePara.LLCurrency + "</LCType>"
             + "<SellFC>" + item.SellLC / typePara.SellCurrRate + "</SellFC>"
             + "<PayFC>" + item.PayLC / typePara.SellCurrRate + "</PayFC>"
             + "<FCTyep>" + typePara.FCCurrency + "</FCTyep>"
             + "<CurrencyRate>" + typePara.SellCurrRate + "</CurrencyRate>"
             + "<GlRevAc>" + item.GlRevAc + "</GlRevAc>"
            + "<GlCosAc>" + item.GlCosAc + "</GlCosAc>"
            + "<IsSell>" + ((item.SellLC>0)? "Y" :"N") + "</IsSell>"
            + "<IsCost>" + ((item.PayLC > 0) ? "Y" : "N") + "</IsCost>"

             + "<TaxCode1>" + item.TaxCode1 + "</TaxCode1>"
             + "<TaxCode1Rate>" + item.TaxCode1Rate + "</TaxCode1Rate>"
             + "<TaxCode1Value>" + item.TaxCode1Value + "</TaxCode1Value>"

             + "<TaxCode2>" + item.TaxCode2 + "</TaxCode2>"
             + "<TaxCode2Rate>" + item.TaxCode2Rate + "</TaxCode2Rate>"
             + "<TaxCode2Value>" + item.TaxCode2Value + "</TaxCode2Value>"

             + "<TaxCode3>" + item.TaxCode3 + "</TaxCode3>"
             + "<TaxCode3Rate>" + item.TaxCode3Rate + "</TaxCode3Rate>"
             + "<TaxCode3Value>" + item.TaxCode3Value + "</TaxCode3Value>"
             + "<SellDoctype>" + ((item.SellLC > 0) ? typePara.InvoiceType.Trim() : "" )+ "</SellDoctype>"
             + "<PayDoctype>" + ((item.PayLC > 0) ? typePara.PaymentType.Trim() :"") + "</PayDoctype>"
             + "</ROW>";
                }
            }

            xmlString = xmlString + "</ROOT>";
            return xmlString;
        }

        public string GetEmailAddress(int OrgCode, int GroupID)
        {
            return _dutyData.GetEmailAddress(OrgCode, GroupID);
        }

        public IList<InvDutyPaymentTypeDomainView> GetDutyPaymentDoctypes()
        {
            return _dutyData.GetDutyPaymentDoctypes();
        }

        public ResponseMessage PaymentReverse(InvDutyDomainView _param)
        {
            return _dutyData.PaymentReverse(_param);
        }
    }
}
