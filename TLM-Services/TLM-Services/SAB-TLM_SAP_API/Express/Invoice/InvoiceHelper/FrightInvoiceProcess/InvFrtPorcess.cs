using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.Interfaces.Invoice;
using Express.UI.Factory.Invoice;
using Express.UI.Common.Helpers;
using Express.UI.Helpers;
using Express.View.Domain.Login;
using Express.Interfaces.Report.Invoice;
using Express.UI.Factory.Report.Invoice;
using Express.UI.Common.CustomValidators;
using Express.Interfaces.Report;
using Express.UI.Factory.Report;

namespace Express.UI.Invoice.InvoiceHelper.FrightInvoiceProcess
{
    public class InvFrtPorcess : IFrtProcess
    {
        private readonly IInvFrtProcessPrint _invprovider;
        private readonly IInvoiceReportProvider _report;
        private readonly  IGeneralReport _generalRpt;
        public InvFrtPorcess()
        {
            _invprovider = InvoiceUIFactory.GetService<IInvFrtProcessPrint>();
            _report = RptInvoiceUIFactory.GetService<IInvoiceReportProvider>();
            _generalRpt = GeneralnvoiceUIFactrory.GetService<IGeneralReport>();
        }
        public ResponseMessage InvBulkProcess(InvFrtPrintProcessParaDomainView para)
        {
            try
            {
                ResponseMessage _responce = new ResponseMessage();
                _responce.IsSuccess = false;
                if (para.CompanyID == 0)
                {                    
                    _responce.StrMessage = "Please select company ";
                    return _responce;
                }
                if (para.AgencyCode == 0)
                {                    
                    _responce.StrMessage = "Please select agency ";                  
                    return _responce;
                }

                if (para.IsPeriodic == 1 && para.InvMode == "")
                {                    
                    _responce.StrMessage = "Please select periodic type ";                   
                     return _responce;
                }

                if (para.IsCutormer == 1 && para.OrgCode == 0)
                {                   
                    _responce.StrMessage = "Please select Customer ";                  
                    return _responce;
                }

                if (para.DocType == null || para.DocType.Trim() == "")
                {                  
                    _responce.StrMessage = "Please select document type ";                   
                    return _responce;
                }

                return _invprovider.InvBulkProcess(para);
            }
            catch(Exception)
            {                 
                return null;                
            }
            
        }

        public void PrintAirwabilDetail(IList<InvFrtPrintProcessDomainView> _pendingInv, InvFrtPrintProcessParaDomainView _para)
        {
            try
            {
                if (_pendingInv == null)
                {
                    MessageNotification.MessageBoxError("Please retrive data first", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if (_pendingInv.Count == 0)
                {
                    MessageNotification.MessageBoxError("There are no data to preview", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                _report.PrintAirwabilDetail(_pendingInv, _para);
            }
            catch(Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message , LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
            
        }

        public void PrintFrtInvoicePreview(InvFrtPrintProcessParaDomainView para , InvFrtInvPrintTypes _printType)
        {
            switch(_printType)
            {
                case InvFrtInvPrintTypes.INVOICE:
                    PrintFrtInvoiceDetail(para);
                    break;
                case InvFrtInvPrintTypes.INVOICE_LIST:
                    PrintFrtInvoiceSummary(para);
                    break;
                case InvFrtInvPrintTypes.AWB_DETAIL:
                    PrintFrtInvoiceAwbDetail(para);
                    break;
            }
        }

        private  void PrintFrtInvoiceAwbDetail(InvFrtPrintProcessParaDomainView para)
        {
            if(IsValidatePrint(para))
            {
                try
                {
                    IList<InvFrtPrintProcessDomainView> _pendingInv;
                    _pendingInv = _invprovider.GetFrtInvoiceDetail(para);
                    _report.PrintInvAirwabilDetail(_pendingInv, para);
                }
                catch( Exception ex)
                {
                    MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
                }
               
            }
        }
        private  void PrintFrtInvoiceDetail(InvFrtPrintProcessParaDomainView para)
        {
            if (IsValidatePrint(para))
            {
                try
                {
                    var _pendingInv = _invprovider.GetIFrtRptInvoiceDetail(para);
                    var _company = _generalRpt.GetCompany(para.CompanyID);
                    _report.PrintInvFrtDetailReport(_pendingInv, _company, para);
                }
                catch (Exception ex)
                {
                    MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
                }
              
            }
        }      

        private  void PrintFrtInvoiceSummary(InvFrtPrintProcessParaDomainView para)
        {
            if (IsValidatePrint(para))
            {
                try
                {
                    var _pendingInv = _invprovider.GetIFrtRptInvoiceSummary(para);
                    var _company = _generalRpt.GetCompany(para.CompanyID);
                    _report.PrintInvFrtSummaryReport(_pendingInv, _company, para);
                }
                catch (Exception ex)
                {
                    MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
                }
               
            }
        }

        private bool IsValidatePrint(InvFrtPrintProcessParaDomainView _para)
        {
            
            if (_para.CompanyID == 0)
            {
                MessageNotification.MessageBoxError("Please select company ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return false;
            }
            if (_para.AgencyCode == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return false ;
            }

            if (_para.DocType.Trim() == "")
            {
                MessageNotification.MessageBoxError("Please select document type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return false; 
            }

            if (_para.IsInvNumberRange == 1)
            {
                if (!NumberValidator.TryPassInteger(_para.FromInvNo))
                {
                    MessageNotification.MessageBoxError("Please enter a value to Invoice number range (From) ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return false;
                }

                if (!NumberValidator.TryPassInteger(_para.ToInvNo))
                {
                    MessageNotification.MessageBoxError("Please enter a value to Invoice number range (To) ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return false;
                }
            }

            if (_para.IsInvDateRange == 1)
            {
                if (_para.DtFrom == "")
                {
                    MessageNotification.MessageBoxError("Please select from date ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return false;
                }

                if (_para.DtTo == "")
                {
                    MessageNotification.MessageBoxError("Please select to date ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return false;
                }
            }

            return true ;

        }
    }
}
