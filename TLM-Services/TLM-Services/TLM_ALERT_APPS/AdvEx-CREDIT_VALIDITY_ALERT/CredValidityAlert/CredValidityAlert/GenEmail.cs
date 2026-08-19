using ClosedXML.Excel;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Net.Mail;
using System.Text;
using System.Threading;

namespace CredValidityAlert
{
    public class GenEmail
    {
		private GetReportData _IgetData = new GetReportData();

		public bool SendEmail(MailboxAddress from, MailboxAddress to, MailboxAddress cc, MailboxAddress bcc, string subject, string body, string textbody, XLWorkbook attachment, string smtp, int port, string username, string password, bool? ssl)
		{
			MimeMessage mimeMessage = new MimeMessage();
			mimeMessage.From.Add(from);
			mimeMessage.To.Add(to);
			if (cc.Address != "")
			{

				mimeMessage.Cc.Add(cc);
			}
			if (bcc.Address != "")
			{
				mimeMessage.Bcc.Add(bcc);
			}
			mimeMessage.Subject = subject;
			BodyBuilder bodyBuilder = new BodyBuilder();
			bodyBuilder.HtmlBody = body;
			bodyBuilder.TextBody = textbody;
			if (attachment != null)
			{
				string text = string.Concat(new string[]
				{
					Environment.CurrentDirectory,
					"\\Exports\\",
					DateTime.Today.ToString("yyyy-MM-dd"),
					"_",
					Guid.NewGuid().ToString("N"),
					".xlsx"
				});
				attachment.SaveAs(text);
				bodyBuilder.Attachments.Add(text);
			}
			mimeMessage.Body = (bodyBuilder.ToMessageBody());
			mimeMessage.Importance = MessageImportance.High;
			//SmtpClient expr_108 = new SmtpClient();
			//expr_108.Connect(smtp, port, ssl, default(CancellationToken));
			//expr_108.Authenticate(username, password, default(CancellationToken));
			//expr_108. add_MessageSent(new EventHandler<MessageSentEventArgs>(this.OnMessageSent));
			//expr_108.Send(mimeMessage, default(CancellationToken), null);
			//expr_108.Disconnect(true, default(CancellationToken));
			//expr_108.Dispose();

			using var smtpmail = new SmtpClient();
			if (ssl == null)
			{
				smtpmail.Connect(smtp, port, MailKit.Security.SecureSocketOptions.None);
			}
			else
            {
				smtpmail.Connect(smtp, port, (bool)ssl);
				smtpmail.Authenticate(username, password);
			}			
			smtpmail.Send(mimeMessage);
			smtpmail.Disconnect(true);
			smtpmail.Dispose();
			return true;
		}

		private void OnMessageSent(object sender, MessageSentEventArgs e)
		{
			Console.WriteLine("The message was sent!");
		}

		public DataTable GenerateSheet(List<dynamic> list)
		{
			if (list == null || list.Count == 0)
			{
				return null;
			}
			return (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(list), typeof(DataTable));
		}

		public string ConvertDataTableToHTML(DataTable dt)
		{
			if (dt != null && dt.Rows.Count > 0)
			{
				string text = "<table>";
				text += "<tr>";
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					text = text + "<td>" + dt.Columns[i].ColumnName + "</td>";
				}
				text += "</tr>";
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					text += "<tr>";
					for (int k = 0; k < dt.Columns.Count; k++)
					{
						text = text + "<td>" + dt.Rows[j][k].ToString() + "</td>";
					}
					text += "</tr>";
				}
				return text + "</table>";
			}
			return "No Data";
		}

		//public XLWorkbook GenerateAttachment(string Doctypes)
		//{
		//	XLWorkbook xLWorkbook = new XLWorkbook();
		//	List<object> successList = this._IgetData.GetSuccessList(Doctypes);
		//	List<object> failedList = this._IgetData.GetFailedList(Doctypes);
		//	List<object> pendingList = this._IgetData.GetPendingList(Doctypes);
		//	List<object> asAtDateFailedList = this._IgetData.GetAsAtDateFailedList(Doctypes);
		//	if (successList != null && failedList != null && pendingList != null && asAtDateFailedList != null)
		//	{
		//		DataTable dataTable = this.GenerateSheet(successList);
		//		DataTable dataTable2 = this.GenerateSheet(failedList);
		//		DataTable dataTable3 = this.GenerateSheet(pendingList);
		//		DataTable dataTable4 = this.GenerateSheet(asAtDateFailedList);
		//		xLWorkbook.Worksheets.Add(dataTable, "SUCCESS");
		//		xLWorkbook.Worksheets.Add(dataTable2, "FAILED");
		//		xLWorkbook.Worksheets.Add(dataTable3, "PENDING");
		//		xLWorkbook.Worksheets.Add(dataTable4, "FAILED AS AT - " + DateTime.Today.ToString("yyyy-MM-dd"));
		//		return xLWorkbook;
		//	}
		//	return null;
		//}


		public XLWorkbook GenerateAttachment()
		{
			XLWorkbook xLWorkbook = new XLWorkbook();
			List<object> expiredList = this._IgetData.GetExpiredList();
			
			if (expiredList != null)
			{
				DataTable dataTable = this.GenerateSheet(expiredList);				
				xLWorkbook.Worksheets.Add(dataTable, "EXPIRED");				
				return xLWorkbook;
			}
			return null;
		}

		public string GetEmailBody()
		{
			DataTable dt = this.GenerateSheet(this._IgetData.GetSummaryBody());
			return this.ConvertDataTableToHTML(dt);
		}

		public List<ReportDocRecepDomain> getRecep()
		{
			return this._IgetData.GetReportsRecep();
		}
	}
}
