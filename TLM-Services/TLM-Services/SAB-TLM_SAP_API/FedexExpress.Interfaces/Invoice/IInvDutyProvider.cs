using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Invoice
{
   public interface IInvDutyProvider<T> : IDataAccess<T> where T : class
    {
        /// <summary>
        /// Get company and agency detail
        /// </summary>
        /// <param name="UserId">int</param>
        /// <param name="ModuleId">int</param>
        /// <param name="MenueId">int</param>
        /// <returns></returns>
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);

        /// <summary>
        /// Get airwabil detail from manifest 
        /// </summary>
        /// <param name="airbilNo">string</param>
        /// <returns>type of InvDutyConsAwbDomainView</returns>
        InvDutyConsAwbDomainView GetAwbDetail( string airbilNo );

        /// <summary>
        /// Get exist job detail for perticular airwaybill
        /// </summary>
        /// <param name="companyID">int</param>
        /// <param name="agencyID">int</param>
        /// <param name="expressID">airbil specipic id (string)</param>
        /// <returns>type of InvDutyJobDomainView</returns>
        InvDutyJobDomainView GetJobDetail(int companyID, int agencyID, string expressID);

        /// <summary>
        /// Get exist bill or invoice for perticular airwaybill
        /// </summary>
        /// <param name="companyID">int</param>
        /// <param name="agencyID">int</param>
        /// <param name="expressID">airbil specipic id (string)</param>
        /// <returns>type of InvDutyDomainView</returns>
        InvDutyDomainView GetInvDutyDetail(int companyID, int agencyID, string expressID);

        /// <summary>
        /// Get document type list
        /// </summary>
        /// <param name="companyID">int</param>
        /// <param name="agencyID">int</param>
        /// <param name="shiptype">string</param>
        /// <param name="billto">string</param>
        /// <returns>List of InvDutyDoctypeDomainView</returns>
        IList<InvDutyDoctypeDomainView> GetDutyDoctypes(int companyID, int agencyID, string shiptype , string billto , decimal shipV , string dutyEx);

        IList<InvDutyPaymentTypeDomainView> GetDutyPaymentDoctypes();

        /// <summary>
        /// Get mapped documents type for perticular airwabill
        /// </summary>
        /// <param name="companyID">int</param>
        /// <param name="agencyID">int</param>
        /// <param name="shipV">manifest shipment value (decimal)</param>
        /// <param name="billto">duty charge to  (string)</param>
        /// <param name="dutyEx">Excempt duty (string)</param>
        /// <param name="shipT">Ship Type  (string)</param>
        /// <returns></returns>
        InvDutyDoctypeDomainView GetDutyDocument(int companyID, int agencyID, decimal shipV, string billto ,string dutyEx , string shipT);

        /// <summary>
        /// Get sales locations
        /// </summary>
        /// <param name="companyID">int</param>
        /// <param name="agencyID">int</param>
        /// <param name="country">local country (string)</param>
        /// <returns>List of InvDutySalesAreaDomainView</returns>
        List<InvDutySalesAreaDomainView> GetDutyLocations(int companyID, int agencyID, string country );

        /// <summary>
        /// Get finance related data for perticular organization
        /// </summary>
        /// <param name="companyID">int</param>
        /// <param name="orgCode">organization code (int)</param>
        /// <returns></returns>
        InvDutyOrgnizDomainView GetDutyOrgnizFinance(int companyID, int orgCode);

        /// <summary>
        /// Get organization detail by icpc number , org code
        /// </summary>
        /// <param name="companyID">int</param>
        /// <param name="orgCode">int</param>
        /// <param name="icpc">string</param>
        /// <returns>type of InvDutyOrgnizDomainView</returns>
        InvDutyOrgnizDomainView GetDutyOrgnization(int companyID, int orgCode, string icpc);

        /// <summary>
        /// Get duty clearence exchage rate
        /// </summary>
        /// <param name="_para">type of InvDutyExtrateDomainView</param>
        /// <returns>type of InvDutyExtrateDomainView</returns>
        InvDutyExtrateDomainView GetDutyClearenceExtrate(InvDutyExtrateDomainView _para);

        /// <summary>
        /// Get charges detail
        /// </summary>
        /// <param name="_para">type of InvChargeParamDomainView</param>
        /// <returns>List of InvDutyChargeDomainView</returns>
        IList<InvDutyChargeDomainView> GetCharges(InvChargeParamDomainView _para);

        /// <summary>
        /// Get duty exchange rate
        /// </summary>
        /// <param name="_para">type of InvDutyExtrateDomainView</param>
        /// <returns>type of InvDutyExtrateDomainView</returns>
        InvDutyExtrateDomainView GetDutyExchangerate(InvDutyExtrateDomainView _para);

        /// <summary>
        /// proccess unprocess invoice
        /// </summary>
        /// <param name="invDuty"></param>
        /// <returns></returns>
        ResponseMessage InoviceProccess(InvDutyDomainView invDuty);

        /// <summary>
        /// process unprocess payment
        /// </summary>
        /// <param name="invDuty"></param>
        /// <returns></returns>
        ResponseMessage PaymentProccess(InvDutyDomainView invDuty);

        /// <summary>
        /// Get exists job charges
        /// </summary>
        /// <param name="_para"></param>
        /// <returns>list of InvChargeParamDomainView</returns>
        IList<InvDutyChargeDomainView> GetJobCharges(InvChargeParamDomainView _para);

        /// <summary>
        /// Get clearence pay accounts
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns>list of InvDutyClrPayAccountDomainView</returns>
        IList<InvDutyClrPayAccountDomainView> GetClrPayAccounts(int companyID);

        IList<InvDutyAutoChargeDomainView> GetAutoCharges(string  docid, int  shV ,string docT , string chgC ,string dutyExcempt , decimal shipValueLc);

        IList<TaxInvoiceReportDomainView> GetDutyPrint(InvoiceDutyClearencePara _param);

        InvDutyJobtransactDomainView GetDutyJobtrasact(int companyID, int agencyID, string expressID, string invtype, string  invno , string payno);
        IList<InvDutyOrgnizChargeDomainView> GetOrnizCharges(int companyID, int OrgCode, string excempt);

        string GetEmailAddress(int OrgCode, int GroupID);
        ResponseMessage PaymentReverse(InvDutyDomainView _param);
        

        

    }
}
