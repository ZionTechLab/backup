using EmailServiceApp.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailServiceApp.Email
{
    public class SendMail
    {

        //  public static readonly string SMTP_CLIENT = "smtpout.secureserver.net"; // as we are using outlook so we have provided smtp-mail.outlook.com   
        //public static readonly string SMTP_CLIENT = "mail.fedexlk.com"; // as we are using outlook so we have provided smtp-mail.outlook.com   
        //public static readonly string SMTP_CLIENT = "smtp.office365.com"; 
        public static readonly string SMTP_CLIENT = "192.168.100.251";


        public static readonly string EMAIL_BODY = "Reset your Password <a href='http://{0}.safetychain.com/api/Account/forgotPassword?{1}'>Here.</a>";
        public SendMail()
        {

        }
        public ResponseMessage SendEMail(string recipient, string subject, string message, byte[] attachment,string path, string ReferenceNo, string CC, string EmailSender, string EmailSenderPassword)
        {
            string[] EmailToList = recipient.Split(';');
            string ToEmail = EmailToList[0];

            //string ToEmail = "Chanaka.Bandara@hayleysadvantis.com";

          //  byte[] imagedata = (byte[])attachment;
          //  MemoryStream memorystream = new MemoryStream(imagedata, 0, imagedata.Length);

            ResponseMessage ResponceMsg = new ResponseMessage();
            ResponceMsg.IsSuccess = false;

            //0365
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTP_CLIENT);
            //client.Port = 587;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPassword);
            //client.EnableSsl = true;
            //client.Credentials = credentials;

            //SMTP nO AUTH
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTP_CLIENT);
            client.Port = 25;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPassword);
            //client.EnableSsl = true;
            //client.Credentials = credentials;


            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);

            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(path, ct);
            attach.ContentDisposition.FileName = ReferenceNo + ".pdf";

            try
            {
                MailAddress mailFrom = new MailAddress(EmailSender.Trim(), "Advantis Express - Invoices");
                MailAddress mailTo = new MailAddress(ToEmail.Trim());
                var mail = new System.Net.Mail.MailMessage(mailFrom, mailTo);

                mail.Subject = subject;
                mail.Body = message.TrimEnd('0').TrimEnd('.');
                mail.IsBodyHtml = true;
                if (CC != "" && CC != null)
                {
                    mail.CC.Add(CC);
                }
                foreach (var e_item in EmailToList.Skip(1))
                {
                    if (e_item != "")
                    {
                        mail.CC.Add(e_item);
                    }
                }
                //System.Net.Mail.Attachment attachment;  
                //attachment = new Attachment(@"C:\Users\XXX\XXX\XXX.jpg");  
                if (attach != null)
                {
                    mail.Attachments.Add(attach);
                }

                MailAddress bcc = new MailAddress("invoicesmhe@fedexlk.com");
                mail.Bcc.Add(bcc);

                client.Send(mail);
                ResponceMsg.IsSuccess = true;


            }
            catch (Exception ex)
            {
                ResponceMsg.StrMessage = "" + ex;
            }
            return ResponceMsg;
        }



        public ResponseMessage SendEMailMultiple(string recipient, string subject, string message, byte[] attachment,string path1,byte[] attachment2,string path2, string ReferenceNo, string CC, string EmailSender, string EmailSenderPassword)
        {
            string[] EmailToList = recipient.Split(';');
            string ToEmail = EmailToList[0];
            //string ToEmail = "Chanaka.Bandara@hayleysadvantis.com";

            //byte[] imagedata = (byte[])attachment;
            //MemoryStream memorystream = new MemoryStream(imagedata, 0, imagedata.Length);

            //byte[] imagedata2 = (byte[])attachment2;
            //MemoryStream memorystream2 = new MemoryStream(imagedata2, 0, imagedata2.Length);

            ResponseMessage ResponceMsg = new ResponseMessage();
            ResponceMsg.IsSuccess = false;

            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTP_CLIENT);
            //client.Port = 587;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPassword);
            //client.EnableSsl = true;
            //client.Credentials = credentials;

            //SMTP nO AUTH
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTP_CLIENT);
            client.Port = 25;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPassword);
            //client.EnableSsl = true;
            //client.Credentials = credentials;

            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(path1, ct);
            attach.ContentDisposition.FileName = ReferenceNo + ".pdf";

            System.Net.Mail.Attachment attach2 = new System.Net.Mail.Attachment(path2, ct);
            attach2.ContentDisposition.FileName = ReferenceNo + "_Details.pdf";

            try
            {
                MailAddress mailFrom = new MailAddress(EmailSender.Trim(), "Advantis Express - Invoices");
                MailAddress mailTo = new MailAddress(ToEmail.Trim());
                var mail = new System.Net.Mail.MailMessage(mailFrom, mailTo);

                mail.Subject = subject;
                mail.Body = message.TrimEnd('0').TrimEnd('.');
                mail.IsBodyHtml = true;
                if (CC != "" && CC != null)
                {
                    mail.CC.Add(CC);
                }
                foreach (var e_item in EmailToList.Skip(1))
                {
                    if (e_item != "")
                    {
                        mail.CC.Add(e_item);
                    }
                }
                //System.Net.Mail.Attachment attachment;  
                //attachment = new Attachment(@"C:\Users\XXX\XXX\XXX.jpg");  
                if (attach != null && attach2 !=null)
                {
                    mail.Attachments.Add(attach);
                    mail.Attachments.Add(attach2);
                }

                MailAddress bcc = new MailAddress("invoicesmhe@fedexlk.com");
                mail.Bcc.Add(bcc);

                client.Send(mail);
                ResponceMsg.IsSuccess = true;


            }
            catch (Exception ex)
            {
                ResponceMsg.StrMessage = "" + ex;
            }
            return ResponceMsg;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        public ResponseMessage ret()
        {
            ResponseMessage ResponceMsg = new ResponseMessage();
            ResponceMsg.IsSuccess = false;
            return ResponceMsg;
        }

        public ResponseMessage SendEMailWithError(string recipient, string subject, string message, string ReferenceNo, string CC, string EmailSender, string EmailSenderPassword)
        {
            string[] EmailToList = recipient.Split(';');
            string ToEmail = EmailToList[0];

            //byte[] imagedata = (byte[])attachment;
            //MemoryStream memorystream = new MemoryStream(imagedata, 0, imagedata.Length);

            ResponseMessage ResponceMsg = new ResponseMessage();
            ResponceMsg.IsSuccess = false;

            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTP_CLIENT);
            //client.Port = 587;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPassword);
            //client.EnableSsl = true;
            //client.Credentials = credentials;

            //SMTP nO AUTH
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTP_CLIENT);
            client.Port = 25;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPassword);
            //client.EnableSsl = true;
            //client.Credentials = credentials;

            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
            //System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(memorystream, ct);
            //attach.ContentDisposition.FileName = ReferenceNo + ".pdf";

            try
            {
                MailAddress mailFrom = new MailAddress(EmailSender.Trim(), "Advantis Express - Invoices");
                MailAddress mailTo = new MailAddress(ToEmail.Trim());
                var mail = new System.Net.Mail.MailMessage(mailFrom, mailTo);

                mail.Subject = subject;
                mail.Body = message.TrimEnd('0').TrimEnd('.');
                mail.IsBodyHtml = true;
                if (CC != "" && CC != null)
                {
                    mail.CC.Add(CC);
                }
                foreach (var e_item in EmailToList.Skip(1))
                {
                    if (e_item != "")
                    {
                        mail.CC.Add(e_item);
                    }
                }
                //System.Net.Mail.Attachment attachment;  
                //attachment = new Attachment(@"C:\Users\XXX\XXX\XXX.jpg");  
                //if (attach != null)
                //{
                //    mail.Attachments.Add(attach);
                //}
                client.Send(mail);
                ResponceMsg.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ResponceMsg.StrMessage = ""+ex;
                Console.WriteLine(ResponceMsg.StrMessage+ "Email Failed");
            }
            return ResponceMsg;
        }
    }
}
