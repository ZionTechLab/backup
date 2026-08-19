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
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using MimeKit;
using MailKit;

namespace EmailServiceApp
{

    //changed App---> Environment.CurrentDirectory
    class Program
    {
        public static string FromEmail = "sa.cc@sab-express.com";
        //public static string FromEmailPassword = "SaBCC@54321!";
        //public static string FromEmailPassword = "Fun30216";

        //public static string FromEmailPassword = "SaBCC@54321!";

        public static string FromEmailPassword = "SaCr3d1tcntrl112023!!";

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
               

                string USM_ID = "0";
                DateTime USM_DATE = System.DateTime.Now;
                string InvNo = "";
                if (EmailItemList.Count > 0)
                {
                    foreach (EmailListDomain Emailitem in EmailItemList)
                    {
                        Status = "N";
                        if (Emailitem.OrgCode != 0)
                        {
                            //CustomerEmailAddress = newEmailData.GetCustomerEmail(Emailitem.OrgCode.Value);
                            CustomerEmailAddress = newEmailData.GetCustomerEmail(Emailitem.OrgCode.Value);
                            //CustomerEmailAddress = "Chanaka.Bandara@hayleysadvantis.com;Leel.Gunasekara@hayleysadvantis.com";

                            if (CustomerEmailAddress == "")
                            {
                                ErrorMassage = "Customer Email Address not found";
                                Status = "N";
                            }
                            else if(IsValidEmail(CustomerEmailAddress))
                            {
                                USM_ID = Emailitem.UserId.ToString();
                                string EmailSubject = null;
                                string EmailBody = null;
                                //byte[] byteArray = null;

                                if (Emailitem.DocType.Trim() == "XFRTIB" || Emailitem.DocType.Trim() == "XFRTOB" || Emailitem.DocType.Trim() == "XFRTTP"  || Emailitem.DocType.Trim() == "XDOMTRA" || Emailitem.DocType.Trim() == "XSPSIB" || Emailitem.DocType.Trim() == "XSPSOB")
                                {
                                    
                                    var _invFrt = newEmailData.GetFrtInvoiceResulatData(int.Parse("1"), Emailitem.CMPY, Emailitem.AgncyCode, Emailitem.InvoiceNo.ToString(), Emailitem.DocType.Trim());
                                    var _company = newEmailData.GetCompany(Emailitem.CMPY);
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

                                            EmailSubject = "Subject – Invoice No " + _invFrt.First().InvNo + " Dated " + _invFrt.First().InvDate.Date.ToString("MM/dd/yyyy") + " – Invoice " + _invFrt.First().DocType;
                                            EmailBody = "<table><tr><td>&nbsp;</td><tr><td><p> Dear Customer,</p><p> At Sab Express, we are constantly looking to improve the way we do business with you.</p><p> Your new invoice is now ready, please find below the attached invoice.</p><p> For any assistance required please send us the queries to email: sa.cc@sab-express.com </p><p></p><p> Thank You </p><p> SAB Express LLC .</p></td></tr><td>&nbsp;</td></tr></table> ";

                                            // byteArray = System.IO.File.ReadAllBytes(DutyPath + _invFrt.First().InvNo + ".pdf");
                                            WaitNSeconds(1);
                                            FileInfo xx = new FileInfo(PdfPath.ToString());
                                            if (ReadPdfFile(xx, xx.DirectoryName))
                                            {

                                                ErrorMassage = "File Export Failed";
                                                Status = "N";
                                            }


                                            ResponseMessage Response = SendMail.SendEMail(CustomerEmailAddress, EmailSubject, EmailBody, /*byteArray*/ null, PdfPath, _invFrt.First().InvNo, "", FromEmail, FromEmailPassword);

                                            WaitNSeconds(1);
                                            
                                            if (Response.IsSuccess == true)
                                            {
                                                Status = "Y";
                                                ErrorMassage = "";
                                            }
                                            else
                                            {
                                                ErrorMassage = "" + Response.StrMessage;
                                                Status = "N";
                                            }
                                        }
                                        else
                                        {
                                            ErrorMassage = " XFRTIB and XFRTOB Export Fail";
                                            Status = "N";
                                            SendErorEmail("" + ErrorMassage);
                                        }
                                    }
                                }
                                if (Emailitem.DocType.Trim() == "XDTICH" || Emailitem.DocType.Trim() == "XDTICL" || Emailitem.DocType.Trim() == "XDTISH" || Emailitem.DocType.Trim() == "XDTISL")
                                {
                                  
                                    IList<TaxInvoiceReportDomainView> _invDuty = newEmailData.GetTaxInvoiceResulatData(Emailitem.CMPY, Emailitem.AgncyCode, Emailitem.InvoiceNo.ToString(), Emailitem.UserId.Value);
                                    var _company = newEmailData.GetCompany(Emailitem.CMPY);
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
                                            EmailSubject = "Subject – Invoice No " + _invDuty.First().InvNo + " Dated " + _invDuty.First().DocDate.ToString("MM/dd/yyyy") + " – Invoice " + _invDuty.First().DocType;
                                            EmailBody = "<table><tr><td>&nbsp;</td><tr><td><p> Dear Customer,</p><p> At Sab Express, we are constantly looking to improve the way we do business with you.</p><p> Your new invoice is now ready, please find below the attached invoice.</p><p> For any assistance required please send us the queries to email: sa.cc@sab-express.com </p><p></p><p> Thank You </p><p> SAB Express LLC .</p></td></tr><td>&nbsp;</td></tr></table> ";
                                            //byteArray = System.IO.File.ReadAllBytes(PdfPath);

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
                                            else
                                            {
                                                ResponseMessage Response = SendMail.SendEMail(CustomerEmailAddress, EmailSubject, EmailBody, /*byteArray*/ null, PdfPath, _invDuty.First().InvNo, "", FromEmail, FromEmailPassword);

                                                WaitNSeconds(1);
                                                
                                                if (Response.IsSuccess == true)
                                                {
                                                    ErrorMassage = "";
                                                    Status = "Y";
                                                }
                                                else
                                                {
                                                    ErrorMassage = "" + Response.StrMessage;
                                                    Status = "N";
                                                  //  SendErorEmail("" + ErrorMassage);
                                                }

                                            }
                                        }
                                        else
                                        {
                                            ErrorMassage = " XDTICH,XDTISH,XDTISL and XDTICL Export Fail";
                                            Status = "N";
                                            SendErorEmail("" + ErrorMassage);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ErrorMassage = " Invalid Email Address : " + CustomerEmailAddress;
                                Status = "N";
                            }
                        }
                        else
                        {
                            ErrorMassage = "Organization not found";
                        }
                        Console.WriteLine(ErrorMassage);
                        Console.WriteLine("\t" + Status == "N" ? "False" : "True" + "\t" + Emailitem.AutoID+ "\t"+ Emailitem.InvoiceNo+ "\t"+ FromEmail );
                        if (ErrorMassage.Length > 250)
                            ErrorMassage = ErrorMassage.Substring(0, 250);
                        newEmailData.UpdateEmailLog(FromEmail, CustomerEmailAddress, ErrorMassage, Status == "N" ? "Y" : "N", Status, Emailitem.AutoID);

                        if(ErrorMassage == " XDTICH,XDTISH,XDTISL and XDTICL Export Fail" || ErrorMassage == " XFRTIB and XFRTOB Export Fail")
                        {
                            //Console.WriteLine("Exit?");
                            //Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SendErorEmail("Error"+ex);
                //Console.WriteLine("Exit?");
                //Console.ReadLine();
            }
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


        private static void WaitNSeconds(int segundos)
        {
            if (segundos < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(segundos);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        //public static bool IsValidEmail(string email)
        //{
        //    string[] EmailToList = email.Split(';');
        //    foreach(string x in EmailToList)
        //    {
        //        string pattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        //        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
        //        if(!regex.IsMatch(x.Trim()))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        public static bool IsValidEmail(string email)
        {
            string[] EmailToList = email.Split(';');
            foreach (string x in EmailToList)
            {
                string pattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (!regex.IsMatch(x.Trim()))
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
            SendMail.SendEMailWithError("Chanaka.Bandara@hayleysadvantis.com;Leel.Gunasekara@hayleysadvantis.com", "Email Sending Error", ""+Messsage, "", "", FromEmail, FromEmailPassword);
            Console.WriteLine(""+Messsage);
        }

        public static List<EmailListDomain> GetEmailData()
        {
            EmailData newEmailData = new EmailData();
            return newEmailData.GetEmailList();
        }

    }
}
