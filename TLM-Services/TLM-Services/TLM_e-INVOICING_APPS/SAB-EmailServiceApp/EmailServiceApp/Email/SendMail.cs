using EmailServiceApp.Domain;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailServiceApp.Email
{
    public class SendMail
    {

        //public static readonly string SMTP_CLIENT = "smtpout.secureserver.net"; // as we are using outlook so we have provided smtp-mail.outlook.com   
        //public static readonly string EMAIL_BODY = "Reset your Password <a href='http://{0}.safetychain.com/api/Account/forgotPassword?{1}'>Here.</a>";
        public static readonly string SMTP_CLIENT = "smtp.office365.com";
        public static readonly int SMTP_PORT = 587;
        public SendMail()
        {

        }

        public void SendEmail(System.Net.Mail.MailMessage message, string senderEmail, string senderEmailPW, bool enableSsl)
        {
            var m = new MimeMessage();
            m.From.Add(new MailboxAddress(message.From.DisplayName, message.From.Address));
            m.To.Add(new MailboxAddress(message.To[0].DisplayName, message.To[0].Address));
            m.Subject = message.Subject;

            var builder = new BodyBuilder();
            TextPart txt;
            if (message.IsBodyHtml)
                txt = new TextPart("html") { Text = message.Body };
            else
                txt = new TextPart("plain") { Text = message.Body };
            builder.HtmlBody = txt.Text;
                        
            foreach(var a in message.Attachments)
            {
                builder.Attachments.Add(a.Name,a.ContentStream);
            }
            m.Body = builder.ToMessageBody();


            

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(SMTP_CLIENT, SMTP_PORT, SecureSocketOptions.StartTls);
                client.Authenticate(new NetworkCredential(senderEmail, senderEmailPW));
                client.Send(m);
                client.Disconnect(true);
            }
        }

        public ResponseMessage SendEMail(string recipient, string subject, string message, byte[] attachment, string path, string ReferenceNo, string CC, string EmailSender, string EmailSenderPassword)
        {
            string[] EmailToList = recipient.Split(';');
            string ToEmail = EmailToList[0];

            //byte[] imagedata = (byte[])attachment;
            //MemoryStream memorystream = new MemoryStream(imagedata, 0, imagedata.Length);

            ResponseMessage ResponceMsg = new ResponseMessage();
            ResponceMsg.IsSuccess = false;

            //SmtpClient client = new SmtpClient();
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SMTP_CLIENT);

            //client.Port = 587;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPassword);
            //client.EnableSsl = true;
            //client.Credentials = credentials;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //client.TargetName = "STARTTLS/smtp.office365.com";

            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(path, ct);
            attach.ContentDisposition.FileName = ReferenceNo + ".pdf";

            try
            {
                MailAddress mailFrom = new MailAddress(EmailSender.Trim(), "SAB Express LLC  - Invoices");
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
                //client.Send(mail);
                SendEmail(mail,EmailSender,EmailSenderPassword,true);
                ResponceMsg.IsSuccess = true;


            }
            catch (Exception ex)
            {
                ResponceMsg.StrMessage = "" + ex;
            }
            return ResponceMsg;
        }

        public ResponseMessage SendEMail2(string recipient, string subject, string message, byte[] attachment, string path, string ReferenceNo, string CC, string EmailSender, string EmailSenderPassword)
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
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //client.TargetName = "STARTTLS/smtp.office365.com";

            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(path, ct);
            attach.ContentDisposition.FileName = ReferenceNo + ".pdf";

            try
            {
                MailAddress mailFrom = new MailAddress(EmailSender.Trim(), "SAB Express LLC  - Invoices");
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
                //client.Send(mail);
                SendEmail(mail, EmailSender, EmailSenderPassword, true);
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
            // client.TargetName = "STARTTLS/smtp.office365.com";
            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
            //System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(memorystream, ct);
            //attach.ContentDisposition.FileName = ReferenceNo + ".pdf";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            try
            {
                MailAddress mailFrom = new MailAddress(EmailSender.Trim(), "SAB Express LLC  - Invoices");
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
                //client.Send(mail);
                SendEmail(mail, EmailSender, EmailSenderPassword, true);
                ResponceMsg.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ResponceMsg.StrMessage = "" + ex;
                Console.WriteLine(ResponceMsg.StrMessage + "Email Failed");
            }
            return ResponceMsg;
        }
        public ResponseMessage SendEMailWithError2(string recipient, string subject, string message, string ReferenceNo, string CC, string EmailSender, string EmailSenderPassword)
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
           // client.TargetName = "STARTTLS/smtp.office365.com";
            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
            //System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(memorystream, ct);
            //attach.ContentDisposition.FileName = ReferenceNo + ".pdf";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            try
            {
                MailAddress mailFrom = new MailAddress(EmailSender.Trim(), "SAB Express LLC  - Invoices");
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
                // client.Send(mail);
                SendEmail(mail, EmailSender, EmailSenderPassword, true);
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
