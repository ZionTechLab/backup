using MHE_Api.Report.Domain;
using MHE_Api.Report.Invoice.Report.KSA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHE_Api.Report.Invoice.ReportProxy
{
    public class InvoiceReport 
    {
        // PricingReport : IInvoiceReport

        private static Dictionary<string, IInvoiceReportSelector> _strategies;
        private IInvoiceReportSelector _reportloc;
        public InvoiceReport()
        {
            if (_strategies == null)
            {
                _strategies = new Dictionary<string, IInvoiceReportSelector>();
                SetStrategies();
            }
           
        }
        #region  strategies
        public void SetStrategies()
        {
            _strategies.Add("KSA", new InvoiceKsaReport());/// Portal 
        }

        public void GeReportStrategies(string _key)
        {
            _reportloc = _strategies[_key];
        }
        #endregion

       
       
        public bool ClearenceDutyPrintExport(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string InvNo, string Path)
        {
            try
            {
                GeReportStrategies(Path);
                ////InvoiceTaxRpt invRpt = new InvoiceTaxRpt();
                var invRpt = _reportloc.InvoiceReporLocator("dutyinv");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("TaxInvoiceReportDomainView", ReportContext.ToDataTable<TaxInvoiceReportDomainView>(_rptData.ToList()));
              //  Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));

                #region QR Code Generation

                var results_S = (from Item1 in _rptData
                                 join Item2 in _company
                                 on Item1.CompanyID equals Item2.CompanyID
                                 select new { Item1.InvNo, Item1.DocDate, Item1.CmpTaxRegNo, Item1.CompanyID, Item1.TAX1, Item1.LineAmount, Item2.CompanyName, Item2.TaxRegNo })
                .GroupBy(p => new { p.InvNo, p.DocDate, p.TaxRegNo, p.CompanyID, p.CompanyName })
                .Select(p => new objTot
                {
                    InvNo = p.Key.InvNo,
                    DocDate = p.Key.DocDate,
                    TaxRegNo = p.Key.TaxRegNo,
                    CompanyID = p.Key.CompanyID,
                    CompanyName = p.Key.CompanyName,
                    TAX1 = p.Sum(u => u.TAX1),
                    LineAmount = p.Sum(u => u.LineAmount)
                }).ToList();

                var lst = new List<InvoiceQRCode>();
                var QR = new QRHelper();
                foreach (objTot Line in results_S)
                {
                    var para = new List<QRCodeDomainView>();
                    para.Add(new QRCodeDomainView { Tag = 1, Value = "SAB Express for transportation of Non-postal Parcels company" });//Line.CompanyName
                    para.Add(new QRCodeDomainView { Tag = 2, Value = Line.TaxRegNo });
                    para.Add(new QRCodeDomainView { Tag = 3, Value = Line.DocDate.ToString("yyyy-MM-ddT00:00:00Z") });
                    para.Add(new QRCodeDomainView { Tag = 4, Value = Line.LineAmount.ToString() });
                    para.Add(new QRCodeDomainView { Tag = 5, Value = Line.TAX1.ToString() });
                    var bitmap = QR.GenerateQR(para);

                    var x = new InvoiceQRCode { InvNo = Line.InvNo, QR = Cast.ImageToByteArray(bitmap) };
                    lst.Add(x);
                }

                Report_Data.Add("InvoiceQRCode", ReportContext.ToDataTable<InvoiceQRCode>(lst));
                #endregion
               
                ReportContext.ExportDutyReport("VAT INVOICE", invRpt, Report_Data, null, InvNo);
                //ReportContext.ExportDutyReportb("VAT INVOICE", invRpt, Report_Data, null, InvNo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool ClearenceFrtPrintExport(IList<FrtInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string InvNo, string Path)
        {
            try
            {
                GeReportStrategies(Path);
                var invRpt = _reportloc.InvoiceReporLocator("frtinv");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();

                #region QR Code Generation

               
                
                    var results_S = (from Item1 in _rptData
                                     join Item2 in _company
                                     on Item1.CompanyID equals Item2.CompanyID
                                     select new { Item1.InvNo, Item1.InvDate, Item1.CompanyID, Item1.LineLCAmount, Item2.CompanyName, Item2.TaxRegNo, Item1.TaxCode1Val, Item1.DocType })
                    .GroupBy(p => new { p.InvNo, p.InvDate, p.TaxRegNo, p.CompanyID, p.CompanyName, p.DocType })
                    .Select(p => new objTot
                    {
                        InvNo = p.Key.InvNo,
                        DocDate = p.Key.InvDate,
                        TaxRegNo = p.Key.TaxRegNo,
                        CompanyID = p.Key.CompanyID,
                        CompanyName = p.Key.CompanyName,
                        DocType = p.Key.DocType,
                        TAX1 = p.Sum(u => u.TaxCode1Val),
                        LineAmount = p.Sum(u => u.LineLCAmount)
                    }).ToList();

                    var lst = new List<InvoiceQRCode>();
                    var QR = new QRHelper();
                    foreach (objTot Line in results_S)
                    {
                        var para = new List<QRCodeDomainView>();
                        para.Add(new QRCodeDomainView { Tag = 1, Value = "SAB Express for transportation of Non-postal Parcels company" });//Line.CompanyName
                        para.Add(new QRCodeDomainView { Tag = 2, Value = Line.TaxRegNo });
                        para.Add(new QRCodeDomainView { Tag = 3, Value = Line.DocDate.ToString("yyyy-MM-ddT00:00:00Z") });
                        para.Add(new QRCodeDomainView { Tag = 4, Value = (Line.DocType == "XDOMTRA" ? (Line.LineAmount + Line.TAX1).ToString() : Line.LineAmount.ToString()) });
                        para.Add(new QRCodeDomainView { Tag = 5, Value = (Line.DocType == "XDOMTRA" ? Line.TAX1.ToString() : "0") });
                        var bitmap = QR.GenerateQR(para);

                        var x = new InvoiceQRCode { InvNo = Line.InvNo, QR = Cast.ImageToByteArray(bitmap) };
                        lst.Add(x);
                    }
                    Report_Data.Add("InvoiceQRCode", ReportContext.ToDataTable<InvoiceQRCode>(lst));
               
                #endregion

                Report_Data.Add("FrtInvoiceReportDomainView", ReportContext.ToDataTable<FrtInvoiceReportDomainView>(_rptData.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ExportFrtReport("Freight Bulk Invoice", invRpt, Report_Data, null, InvNo);
                //ReportContext.ExportFrtReportb("Freight Bulk Invoice", invRpt, Report_Data, null, InvNo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        private void PrintFormPdfData(string formPdfPath)
        {

        }

     

    }
}
