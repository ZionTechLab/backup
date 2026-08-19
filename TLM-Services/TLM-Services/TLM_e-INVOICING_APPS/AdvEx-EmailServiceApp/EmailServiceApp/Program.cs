using EmailServiceApp.Domain;
using EmailServiceApp.Report.Invoice.ReportProxy;
using EmailServiceApp.SQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailServiceApp.Email;
using System.Text.RegularExpressions;
using FedexExpress.View.Domain.Report.Invoice;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace EmailServiceApp
{

    //changed App---> Environment.CurrentDirectory
    class Program
    {
        public static string ErrEmailPassword = "";
        public static string ErrEmail = "invoicesmhe@fedexlk.com";
        static void Main(string[] args)
        {
            try
            {
                string ErrorMassage = "";

                List<EmailListDomain> EmailItemList = new List<EmailListDomain>();
                EmailItemList = GetEmailData();
                String CustomerEmailAddress = "";
                EmailData newEmailData = new EmailData();
                InvoiceReport InvReport = new InvoiceReport();
                SendMail SendMail = new SendMail();
                string Status = "N";
                string FromEmail = "invoicesmhe@fedexlk.com";
                //string FromEmailPassword = "invoices#1234";
              //  string FromEmailPassword = "mheladmin#1234";
                string FromEmailPassword = "{";
                FromEmailPassword = FromEmailPassword + @"""";
                FromEmailPassword = FromEmailPassword+"Y2Drc#C{ySr8]&";

                ErrEmailPassword = FromEmailPassword;
                //_mail.FromEmail = "invoicesmhe@fedexlk.com";
                //_mail.FromEmailPassword = "invoices#1234";

                string USM_ID = "0";
                DateTime USM_DATE = System.DateTime.Now;
                string InvNo = "";
                // var _company = newEmailData.GetCompany(201);


                if (EmailItemList.Count > 0)
                {
                    foreach (EmailListDomain Emailitem in EmailItemList)
                    {
                        Status = "N";
                        InvNo = "" + Emailitem.InvoiceNo;
                        if (Emailitem.OrgCode != 0)
                        {
                            var _company = newEmailData.GetCompany(Emailitem.CMPY);
                            //CustomerEmailAddress = newEmailData.GetCustomerEmail(Emailitem.OrgCode.Value);
                            CustomerEmailAddress = newEmailData.GetCustomerEmail(Emailitem.OrgCode.Value);
                            //CustomerEmailAddress = "chanaka.bandara@hayleysadvantis.com";

                            if (CustomerEmailAddress == "")
                            {
                                ErrorMassage = "Customer Email Address not found";
                            }
                            else if (IsValidEmail(CustomerEmailAddress))
                            {
                                USM_ID = Emailitem.UserId.ToString();
                                string EmailSubject = null;
                                string EmailBody = null;
                               // byte[] byteArray = null;
                               // byte[] byteArray2 = null;

                                if (Emailitem.DocType.Trim() == "XDTICDC" || Emailitem.DocType.Trim() == "XDTICOA" || Emailitem.DocType.Trim() == "XHANDOB" || Emailitem.DocType.Trim() == "XDTOSTP")
                                {
                                    IList<TaxInvoiceReportDomainView> _intTaxInv = newEmailData.GetMHETaxInvoiceData(_company.First().GroupID, Emailitem.CMPY, Emailitem.AgncyCode, Convert.ToString(Emailitem.InvoiceNo));
                                    // IList<InvoiceRepAwbDetailDomainView> _invAwbInv = newEmailData.GetMHEAWBInvoiceData(_company.First().GroupID, Emailitem.CMPY, Emailitem.AgncyCode, Convert.ToString(Emailitem.InvoiceNo), Convert.ToString(Emailitem.InvoiceNo), Emailitem.DocType).ToList();

                                    if (_intTaxInv.Count() > 0)
                                    {
                                        string TxtPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"ExportItems\MHE\");
                                        if (File.Exists(TxtPath + _intTaxInv.First().InvNo + ".pdf"))
                                        {
                                            File.Create(TxtPath + _intTaxInv.First().InvNo + ".pdf").Close();
                                            WaitNSeconds(1);
                                            File.Delete(TxtPath + _intTaxInv.First().InvNo + ".pdf");
                                        }

                                        bool TaxResult = InvReport.MHEInvoiceTax(_intTaxInv, _company, _intTaxInv.First().InvNo, "MHE");

                                        string invoiceName = "Duties and Taxes";

                                        string awbs = "";
                                        foreach (var awb in _intTaxInv)
                                        {
                                            awbs = awbs + ", " + awb.DocReference;
                                        }

                                        WaitNSeconds(1);
                                        if (TaxResult == true)
                                        {
                                            string PdfPath = TxtPath + _intTaxInv.First().InvNo + ".pdf";
                                            EmailSubject = "Subject – Invoice No " + _intTaxInv.First().InvNo + " Dated " + _intTaxInv.First().DocDate.ToString("MM/dd/yyyy") + " – " + invoiceName;
                                            EmailBody = "<table><tr><td>&nbsp;</td><tr><td><p> Dear Sir / Madam,</p><p> Please find attached subject invoice for the " + invoiceName + " .</p><p> AWBs" + awbs + "</p><p> Appreciate your early settlement </p><p></p><p> Thank You </p><p> Advantis Express(Pvt) Ltd </p></td></tr><td>&nbsp;</td></tr></table> ";
                                           // byteArray = System.IO.File.ReadAllBytes(PdfPath);

                                            WaitNSeconds(1);
                                            if (!File.Exists(TxtPath + _intTaxInv.First().InvNo + ".pdf"))
                                            {
                                                ErrorMassage = "File Export Failed";
                                                Status = "N";
                                            }
                                                FileInfo xx = new FileInfo(PdfPath.ToString());
                                            if(ReadPdfFile(xx, xx.DirectoryName)){

                                                ErrorMassage = "File Export Failed";
                                                Status = "N";
                                            }
                                            else
                                            {
                                                ResponseMessage Response = SendMail.SendEMail(CustomerEmailAddress, EmailSubject, EmailBody,/* byteArray*/ null, PdfPath, _intTaxInv.First().InvNo, "", FromEmail, FromEmailPassword);
                                                WaitNSeconds(1);
                                                //ResponseMessage Response = SendMail.ret();
                                                //del up
                                               
                                                if (Response.IsSuccess == true)
                                                {
                                                    ErrorMassage = "";
                                                    Status = "Y";
                                                }
                                                else
                                                {
                                                    ErrorMassage = "" + Response.StrMessage;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ErrorMassage = " XDTICDC,XDTICOA and XHANDOB Export Fail";
                                            Status = "N";
                                            SendErorEmail("" + ErrorMassage);
                                        }
                                    }
                                }

                                if (Emailitem.DocType.Trim() == "XFRTIB" || Emailitem.DocType.Trim() == "XFRTTP")
                                {
                                    // InvoiceBulkPrintDomainView _bulkInvPrint = new InvoiceBulkPrintDomainView();

                                    //IList<FrtInvoiceReportDomainView> _invFrtInv = newEmailData.GetMHEFreightInvoiceData(_company.First().GroupID, Emailitem.CMPY, Emailitem.AgncyCode, Convert.ToString(Emailitem.InvoiceNo), Convert.ToString(Emailitem.InvoiceNo), Emailitem.DocType);
                                    IList<FrtInvoiceReportDomainView> _invFrtInv = newEmailData.GetMHEFreightInvoiceData(_company.First().GroupID, Emailitem.CMPY, Emailitem.AgncyCode, Convert.ToString(Emailitem.InvoiceNo));
                                   IList<InvoiceRepAwbDetailDomainView> _invAwbInv = newEmailData.GetMHEAWBInvoiceData(_company.First().GroupID, Emailitem.CMPY, Emailitem.AgncyCode, Convert.ToString(Emailitem.InvoiceNo), Convert.ToString(Emailitem.InvoiceNo), Emailitem.DocType);

                                    if (_invFrtInv.Count() > 0)
                                    {
                                        string FrtPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"ExportItems\MHE\");
                                        if (File.Exists(FrtPath + _invFrtInv.First().InvNo + ".pdf"))
                                        {
                                            File.Create(FrtPath + _invFrtInv.First().InvNo + ".pdf").Close();
                                            WaitNSeconds(1);
                                            File.Delete(FrtPath + _invFrtInv.First().InvNo + ".pdf");
                                        }
                                        bool Result = InvReport.MHEInvoiceFreight(_invFrtInv, _company, _invFrtInv.First().InvNo, "MHE");

                                        string invoiceName = "Inbound Freight- ";

                                        string awbs = "";
                                        foreach (var awb in _invAwbInv)
                                        {
                                            awbs = awbs + ", " + awb.AgnAWBNo;
                                        }
                                        WaitNSeconds(1);

                                        if (!File.Exists(FrtPath + _invFrtInv.First().InvNo + ".pdf"))
                                        {
                                            ErrorMassage = "File Export Failed";
                                            Status = "N";
                                        }
                                            if (Result == true)
                                        {
                                            string PdfPath = FrtPath + _invFrtInv.First().InvNo + ".pdf";
                                            EmailSubject = invoiceName + "Invoice No " + _invFrtInv.First().InvNo + " Dated " + _invFrtInv.First().InvDate.ToString("MM/dd/yyyy")  ;
                                            EmailBody = "<table><tr><td>&nbsp;</td><tr><td><p> Dear Sir / Madam,</p><p> Please find attached subject invoice for the " + invoiceName + " .</p><p> AWBs" + awbs + "</p><p> Appreciate your early settlement </p><p></p><p> Thank You </p><p> Advantis Express(Pvt) Ltd </p></td></tr><td>&nbsp;</td></tr></table> ";
                                            //byteArray = System.IO.File.ReadAllBytes(PdfPath);
                                            WaitNSeconds(1);

                                            FileInfo xx = new FileInfo(PdfPath.ToString());
                                            if (ReadPdfFile(xx, xx.DirectoryName))
                                            {

                                                ErrorMassage = "File Export Failed";
                                                Status = "N";
                                            }
                                            else
                                            {
                                                ResponseMessage Response = SendMail.SendEMail(CustomerEmailAddress, EmailSubject, EmailBody, /*byteArray*/ null, PdfPath, _invFrtInv.First().InvNo, "", FromEmail, FromEmailPassword);
                                                WaitNSeconds(1);
                                                //ResponseMessage Response = SendMail.ret();
                                                //del up
                                               
                                                if (Response.IsSuccess == true)
                                                {
                                                    ErrorMassage = "";
                                                    Status = "Y";
                                                }
                                                else
                                                {
                                                    ErrorMassage = "" + Response.StrMessage;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ErrorMassage = " XFRTIB and XFRTTP Export Fail";
                                            Status = "N";
                                            SendErorEmail("" + ErrorMassage + "|" + InvNo);
                                        }
                                    }
                                }
                                else if (Emailitem.DocType.Trim() == "XFRTOB")
                                {
                                    //InvoiceBulkPrintDomainView _bulkInvPrint = new InvoiceBulkPrintDomainView();
                                    IList<FrtInvoiceSummeryDomainView> _invFrtInv = newEmailData.GetMHEFreightSummeryInvoiceData(_company.First().GroupID, Emailitem.CMPY, Emailitem.AgncyCode, Convert.ToString(Emailitem.InvoiceNo), Convert.ToString(Emailitem.InvoiceNo), Emailitem.DocType);
                                    if (_invFrtInv.Count() > 0)
                                    {
                                        string FrtPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"ExportItems\MHE\");

                                        if (File.Exists(FrtPath + _invFrtInv.First().InvNo + ".pdf"))
                                        {
                                            File.Create(FrtPath + _invFrtInv.First().InvNo + ".pdf").Close();
                                            WaitNSeconds(1);
                                            File.Delete(FrtPath + _invFrtInv.First().InvNo + ".pdf");
                                            WaitNSeconds(1);
                                            if (File.Exists(FrtPath + _invFrtInv.First().InvNo + "_Details.pdf"))
                                            {
                                                File.Create(FrtPath + _invFrtInv.First().InvNo + "_Details.pdf").Close();
                                                WaitNSeconds(1);
                                                File.Delete(FrtPath + _invFrtInv.First().InvNo + "_Details.pdf");
                                                WaitNSeconds(1);
                                            }
                                        }
                                        bool Result = InvReport.MHEInvoiceFreightSummery(_invFrtInv, _company, _invFrtInv.First().InvNo, "MHE");

                                        WaitNSeconds(1);
                                        if (Result == true)
                                        {
                                            string PdfPath = FrtPath + _invFrtInv.First().InvNo + ".pdf";
                                            FileInfo xx1 = new FileInfo(PdfPath.ToString());
                                            if (ReadPdfFile(xx1, xx1.DirectoryName))
                                            {
                                                ErrorMassage = "File Export Failed";
                                                Status = "N";
                                            }
                                            else
                                            {
                                                IList<InvoiceRepAwbDetailDomainView> _invAwbInv = newEmailData.GetMHEAWBInvoiceData(_company.First().GroupID, Emailitem.CMPY, Emailitem.AgncyCode, Convert.ToString(Emailitem.InvoiceNo), Convert.ToString(Emailitem.InvoiceNo), Emailitem.DocType);
                                                if (_invAwbInv.Count() > 0)
                                                {
                                                    string AwbPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"ExportItems\MHE\");
                                                    bool Result2 = InvReport.MHEInvoiceAwb(_invAwbInv, _company, _invAwbInv.First().InvNo, "MHE");

                                                    if (!File.Exists(FrtPath + _invFrtInv.First().InvNo + ".pdf"))
                                                    {
                                                        ErrorMassage = "File Export Failed";
                                                        Status = "N";
                                                        if (!File.Exists(FrtPath + _invFrtInv.First().InvNo + "_Details.pdf"))
                                                        {
                                                            ErrorMassage = "File Export Failed";
                                                            Status = "N";
                                                        }
                                                    }

                                                    string invoiceName = "Outbound Freight - ";

                                                    string awbs = "";
                                                    foreach (var awb in _invAwbInv)
                                                    {
                                                        awbs = awbs + ", " + awb.AgnAWBNo;
                                                    }

                                                    if (Result2 == true)
                                                    {
                                                        string PdfPath2 = AwbPath + _invFrtInv.First().InvNo + "_Details.pdf";
                                                        EmailSubject = invoiceName+ "Invoice No " + _invFrtInv.First().InvNo + " Dated " + _invFrtInv.First().InvDate.ToString("MM/dd/yyyy")  ;
                                                        EmailBody = "<table><tr><td>&nbsp;</td><tr><td><p> Dear Sir / Madam,</p><p> Please find attached subject invoice for the " + invoiceName + " .</p><p> AWBs" + awbs + "</p><p> Appreciate your early settlement </p><p></p><p> Thank You </p><p> Advantis Express(Pvt) Ltd </p></td></tr><td>&nbsp;</td></tr></table> ";
                                                         //EmailBody = "<table><tr><td>&nbsp;</td><tr><td><p> Dear Sir / Madam,</p><p> Pls disregard the previous invoice emailed you for same invoice number and consider this invoice for the payment. ( No change to the invoice total).</p><p>Sorry for the inconvenience caused. </p><p></p><p> Any Clarification , Pls Call Laleendra Heenatigala on 077-7735570 </p><p> Mountain Hawk Express(Pvt) Ltd </p></td></tr><td>&nbsp;</td></tr></table> ";
                                                        WaitNSeconds(1);
                                                       // byteArray = System.IO.File.ReadAllBytes(PdfPath);
                                                        WaitNSeconds(2);
                                                       // byteArray2 = System.IO.File.ReadAllBytes(PdfPath2);
                                                        WaitNSeconds(1);


                                                        FileInfo xx = new FileInfo(PdfPath.ToString());
                                                        FileInfo xx2 = new FileInfo(PdfPath2.ToString());
                                                        if (ReadPdfFile(xx, xx.DirectoryName) || ReadPdfFile(xx2, xx2.DirectoryName))
                                                        {
                                                            ErrorMassage = "File Export Failed";
                                                            Status = "N";
                                                        }
                                                        else
                                                        {
                                                            ResponseMessage Response2 = SendMail.SendEMailMultiple(CustomerEmailAddress, EmailSubject, EmailBody, /*byteArray*/ null, PdfPath, /*byteArray2*/ null, PdfPath2, _invFrtInv.First().InvNo, "", FromEmail, FromEmailPassword);
                                                            WaitNSeconds(1);


                                                            if (Response2.IsSuccess == true)
                                                            {
                                                                ErrorMassage = "";
                                                                Status = "Y";
                                                            }
                                                            else
                                                            {
                                                                ErrorMassage = "" + Response2.StrMessage;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ErrorMassage = " XFRTOB AWB Export Fail";
                                                        Status = "N";
                                                        SendErorEmail("" + ErrorMassage + "|" + InvNo);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ErrorMassage = " XFRTOB AWB Export Fail";
                                            Status = "N";
                                            SendErorEmail("" + ErrorMassage + "|" + InvNo);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ErrorMassage = "Organization not found";
                            }
                            Console.WriteLine(ErrorMassage);
                            Console.WriteLine("\t" + Status == "N" ? "False" : "True" + "\t" + Emailitem.AutoID + "\t" + Emailitem.InvoiceNo + "\t" + FromEmail);
                            newEmailData.UpdateEmailLog(FromEmail, CustomerEmailAddress, ErrorMassage, Status == "N" ? "Y" : "N", Status, Emailitem.AutoID);

                            if (ErrorMassage.Trim() == "XDTICH,XDTISH,XDTISL and XDTICL Export Fail" 
                                || ErrorMassage.Trim() == "XFRTIB and XFRTOB Export Fail"
                                || ErrorMassage.Trim() == "XFRTIB and XFRTTP Export Fail"
                                || ErrorMassage.Trim() == "XFRTOB AWB Export Fail"
                                || ErrorMassage.Trim() == "XDTICDC,XDTICOA and XHANDOB Export Fail")
                            {
                               // Console.WriteLine("Exit?");
                               // Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
                    
                
            }


            catch (Exception ex)
            {
                SendErorEmail("Error" + ex);
                //Console.WriteLine("Exit?");
                //Console.ReadLine();
            }
        }

         

        private static void WaitNSeconds(int segundos)
        {
            System.Threading.Thread.Sleep(1000 * segundos);
            //if (segundos < 1) return;
            //DateTime _desired = DateTime.Now.AddSeconds(segundos);
            //while (DateTime.Now < _desired)
            //{
            //    System.Windows.Forms.Application.DoEvents();
            //}
        }

        public static bool ReadPdfFile(FileInfo f, string sourceDir)
        {
            System.Windows.Forms.Application.DoEvents();
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
        public static bool IsValidEmail(string email)
        {
            string[] EmailToList = email.Split(';');
            foreach(string x in EmailToList)
            {
                string pattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if(!regex.IsMatch(x.Trim()))
                {
                    return false;
                }
            }
            return true;
        }

        public static void SendErorEmail(string Messsage)
        {
            SendMail SendMail = new SendMail();
            //SendMail.SendEMailWithError("Leel.Gunasekara@hayleysadvantis.com;Harshana.Madusanka@hayleysadvantis.com", "Email Sending Error", Messsage, "", "", "sa.cc@sab-express.com", "SaB12345!");
            SendMail.SendEMailWithError("Chanaka.Bandara@hayleysadvantis.com;Leel.Gunasekara@hayleysadvantis.com", "Email Sending Error", "" + Messsage, "", "", ErrEmail, ErrEmailPassword);
            Console.WriteLine("" + Messsage);
        }

        public static List<EmailListDomain> GetEmailData()
        {
            EmailData newEmailData = new EmailData();
            return newEmailData.GetEmailList();
        }

    }
}
