using ClosedXML.Excel;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;

namespace SAP_DAILY_RPT
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Console.WriteLine("Running SAP Daily Report Sending for : " + DateTime.Today.ToString("yyyy-MM-dd") + " ..........................................");
				GenEmail genEmail = new GenEmail();
				using (List<ReportDocRecepDomain>.Enumerator enumerator = genEmail.getRecep().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ReportDocRecepDomain current = enumerator.Current;
						MailboxAddress from = new MailboxAddress(current.fromname, current.fromemail);

						//FOR TESTING
						//current.toemail = @"chanaka.bandara@hayleysadvantis.com";
						//current.cc = @"chanaka.bandara@hayleysadvantis.com";
						//current.bcc = @"chanaka.bandara@hayleysadvantis.com";
						//FOR TESTING

						MailboxAddress mailboxAddress = new MailboxAddress(current.toname, current.toemail);
						MailboxAddress cc = new MailboxAddress(current.cc, current.cc);
						MailboxAddress bcc = new MailboxAddress(current.bcc, current.bcc);
						string subject = current.subject;
						string smtp = current.smtp;
						int port = current.port;
						string username = current.username;
						string password = current.password;
						string header = current.header;
						bool ssl = current.ssl;
						string footer = current.footer;
						XLWorkbook xLWorkbook = genEmail.GenerateAttachment(current.DocType);
						string emailBody = genEmail.GetEmailBody(current.DocType);
						if (xLWorkbook != null)
						{
							if (genEmail.SendEmail(from, mailboxAddress, cc, bcc, subject, header + emailBody + footer, "SAP Send Summary", xLWorkbook, smtp, port, username, password, ssl))
							{
								Console.WriteLine("Email Sent to : " + mailboxAddress.Address);
								Program.AppLog("Email Sent to : " + mailboxAddress.Address);
							}
							else
							{
								Console.WriteLine("Email Sending Failed");
								Program.AppLog("Email Sending Failed");
							}
						}
						else
						{
							Console.WriteLine("Failed to Retrieve Report Data");
							Program.AppLog("Failed to Retrieve Report Data");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Exception expr_199 = ex;
				Console.WriteLine(((expr_199 != null) ? expr_199.ToString() : null) ?? "");
				string arg_1D2_0 = ex.Message;
				string arg_1D2_1 = "|";
				Exception expr_1C6 = ex.InnerException;
				Program.AppLog(arg_1D2_0 + arg_1D2_1 + ((expr_1C6 != null) ? expr_1C6.ToString() : null));
			}
		}
		public static void AppLog(string Message)
		{
			StreamWriter streamWriter;
			if (!File.Exists(Environment.CurrentDirectory + "\\logfile.txt"))
			{
				streamWriter = new StreamWriter(Environment.CurrentDirectory + "\\logfile.txt");
			}
			else
			{
				streamWriter = File.AppendText(Environment.CurrentDirectory + "\\logfile.txt");
			}
			streamWriter.WriteLine(DateTime.Now);
			streamWriter.WriteLine(Message);
			streamWriter.WriteLine();
			streamWriter.Close();
		}
	}
}
