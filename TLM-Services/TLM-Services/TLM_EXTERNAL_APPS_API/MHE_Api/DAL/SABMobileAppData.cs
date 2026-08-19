using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHE_Api.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using MHE_Api.DAL.SQL;
using MHE_Api.Report.Invoice.ReportProxy;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using MHE_Api.Report.Domain;

namespace MHE_Api.DAL
{
    public class SABMobileAppData : ISABMobileApp
    {
        ReportData newEmailData = new ReportData();
        InvoiceReport InvReport = new InvoiceReport();          

        private static void WaitNSeconds(int segundos)
        {
            if (segundos < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(segundos);
            while (DateTime.Now < _desired)
            {
                
            }
        }
        public static bool ReadPdfFile(FileInfo f, string sourceDir)
        {
            
            try
            {
                PdfReader pdfReader = new PdfReader(f.FullName);
                string text = PdfTextExtractor.GetTextFromPage(pdfReader, 1);
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                }
                try { pdfReader.Close(); }
                catch { }

                if (text.Trim() == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception a)
            {
                return true;
            }
            return true;
        }
        public IList<InvoiceInformation> GetInvoiceInformation(InvoiceRequest request)
        {
            try
            {
               
                string USM_ID = "0";
                DateTime USM_DATE = System.DateTime.Now;
                string InvNo = "";
                List<InvoiceInformation> invs = new List<InvoiceInformation>();

                string ErrorMassage = "";
                string Status = "";

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    invs = connection.Query<InvoiceInformation>(@"[Express].[TLMV2_GetInvoiceInformationAPI]", request, commandType: CommandType.StoredProcedure, commandTimeout: 2000).ToList();
                }
                foreach (var invitem in invs)
                {
                    if (invitem.DocType.Trim() == "XFRTIB" || invitem.DocType.Trim() == "XFRTOB" || invitem.DocType.Trim() == "XFRTTP" || invitem.DocType.Trim() == "XDOMTRA" || invitem.DocType.Trim() == "XSPSIB" || invitem.DocType.Trim() == "XSPSOB")
                    {
                        var _invFrt = newEmailData.GetFrtInvoiceResulatData(int.Parse("1"), invitem.CMPY, invitem.AgncyCode, invitem.InvoiceNo.ToString(), invitem.DocType.Trim());
                        var _company = newEmailData.GetCompany(invitem.CMPY);

                        if (_invFrt.Count() > 0)
                        {
                            string DutyPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"ExportItems\Freight\");

                            if (File.Exists(DutyPath + _invFrt.First().InvNo + ".pdf"))
                            {
                                File.Create(DutyPath + _invFrt.First().InvNo + ".pdf").Close();
                                WaitNSeconds(1);
                                File.Delete(DutyPath + _invFrt.First().InvNo + ".pdf");
                            }
                            bool Result = InvReport.ClearenceFrtPrintExport(_invFrt, _company, _invFrt.First().InvNo, "KSA");
                            WaitNSeconds(1);

                            InvNo = _invFrt.First().InvNo;

                            if (!File.Exists(DutyPath + _invFrt.First().InvNo + ".pdf"))
                            {
                                ErrorMassage = "File Export Failed";
                                Status = "N";
                            }

                            if (Result == true)
                            {
                                string PdfPath = DutyPath + _invFrt.First().InvNo + ".pdf";
                                WaitNSeconds(1);
                                FileInfo xx = new FileInfo(PdfPath.ToString());
                                if (ReadPdfFile(xx, xx.DirectoryName))
                                {
                                    ErrorMassage = "File Export Failed";
                                    Status = "N";
                                }
                                Byte[] bytes = File.ReadAllBytes(PdfPath);
                                String file = Convert.ToBase64String(bytes);
                                invitem.InvoicePDF = file;
                            }
                            else
                            {
                                ErrorMassage = "Freight invoice Export Fail";
                                Status = "N";
                            }
                        }
                    }

                    if (invitem.DocType.Trim() == "XDTICH" || invitem.DocType.Trim() == "XDTICL" || invitem.DocType.Trim() == "XDTISH" || invitem.DocType.Trim() == "XDTISL")
                    {
                        IList<TaxInvoiceReportDomainView> _invDuty = newEmailData.GetTaxInvoiceResulatData(invitem.CMPY, invitem.AgncyCode, invitem.InvoiceNo.ToString(), invitem.UserId.Value);
                        var _company = newEmailData.GetCompany(invitem.CMPY);
                        if (_invDuty.Count() > 0)
                        {
                            string FrtPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"ExportItems\Duty\");
                            if (File.Exists(FrtPath + _invDuty.First().InvNo + ".pdf"))
                            {
                                File.Create(FrtPath + _invDuty.First().InvNo + ".pdf").Close();
                                WaitNSeconds(1);
                                File.Delete(FrtPath + _invDuty.First().InvNo + ".pdf");
                            }
                            bool Result = InvReport.ClearenceDutyPrintExport(_invDuty, _company, _invDuty.First().InvNo, "KSA");
                            WaitNSeconds(1);

                            InvNo = _invDuty.First().InvNo;
                            if (Result == true)
                            {
                                string PdfPath = FrtPath + _invDuty.First().InvNo + ".pdf";

                                if (!File.Exists(PdfPath))
                                {
                                    ErrorMassage = "File Export Failed";
                                    Status = "N";
                                }
                                FileInfo xx = new FileInfo(PdfPath.ToString());
                                if (ReadPdfFile(xx, xx.DirectoryName))
                                {

                                    ErrorMassage = "File Export Failed";
                                    Status = "N";
                                }

                                Byte[] bytes = File.ReadAllBytes(PdfPath);
                                String file = Convert.ToBase64String(bytes);
                                invitem.InvoicePDF = file;
                            }
                            else
                            {
                                ErrorMassage = "Duty invoice Export Fail";
                                Status = "N";
                            }
                        }
                    }
                }
                return invs;
            }
            catch (Exception Ex)
            {
                Log.LogError(Ex);
                return null;

                // throw;
            }
        }

        public PaymentStatusResponse UpdatePaymentStatus(PaymentStatusRequest request)
        {
            try
            {

                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    var ret = connection.Query<PaymentStatusResponse>(@"[Express].[TLMV2_UpdatePaymentStatusAPI]", request, commandType: CommandType.StoredProcedure, commandTimeout: 2000).FirstOrDefault();
                    return ret;
                }
            }
            catch (Exception Ex)
            {               
                Log.LogError(Ex);
                return null;
                // throw;
            }
        }

        public IList<object> GetInvoiceInformationByDate(InvoiceRequestDates request)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    var invs = connection.Query<object>(@"[Express].[TLMV2_GetInvoiceInformationAPIByDate]", request, commandType: CommandType.StoredProcedure, commandTimeout: 2000).ToList();
                    return invs;
                }
            }
            catch
            {
                throw;
            }
        }

        public IList<InvoicePDFView> GetInvoicePDF(InvoiceRequest request)
        {
            var inv = GetInvoiceInformation(request);
            IList<InvoicePDFView> invoicePDFViews = new List<InvoicePDFView>();
            foreach(var i in inv)
            {
                invoicePDFViews.Add(new InvoicePDFView
                {
                    InvoiceNo = i.InvoiceNo,
                    InvoicePDF = i.InvoicePDF
                });
            }
            return invoicePDFViews;
        }
    }
}