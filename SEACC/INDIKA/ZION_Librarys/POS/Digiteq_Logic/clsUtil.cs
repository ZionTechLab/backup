using DataTire;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using GenCode128;
using ThoughtWorks.QRCode.Codec;
//using Digiteq_Logic.DataSets;
//using Digiteq_Logic.DataSets.BSS;
//using Digiteq;

namespace Digiteq_Logic
{
    //public class rpt_CustomerOutstanding
    //{
    //    dts_bssOutstandingLedger gbl_dts_bssOutstandingLedger = new dts_bssOutstandingLedger();
    //    dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

    //    TextBox txtCustomer = new TextBox();
    //    TextBox txtSalesRep = new TextBox();
    //    RadioButton rdoLocal = new RadioButton();
    //    RadioButton rdoExport = new RadioButton();
    //    RadioButton rdopOutstandingStatement = new RadioButton();
    //    CheckBox chkUseCustomerMastorSaleRep = new CheckBox();
    //    DateTimePicker dtpFrom = new DateTimePicker();
    //    DateTimePicker dtpTo = new DateTimePicker();
    //    bool bCustomerSelected = false, bSelesRepSelected = false, isDetailReport = false;

    //    string GetReportPath(string ReportID, ref string ReportName, ref string ReportName2)
    //    {
    //        string s_Path = "";
    //        ReportName = "";
    //        ReportName2 = "";
    //        //Cursor = Cursors.WaitCursor;
    //        try
    //        {
    //            tbl_securityReportMaster detail = tbl_securityReportMaster.Select(ReportID);
    //            if (detail != null)
    //            {
    //                s_Path = detail.ReportPath.Trim();
    //                ReportName = detail.DisplayName.Trim();
    //                if (detail.DisplayName2 != null)
    //                    ReportName2 = detail.DisplayName2.Trim();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //        finally
    //        {
    //        }
    //        return s_Path;
    //    }

    //    private string GenarateReport_CustomerOutstandingBackDate(enum_ReportName enmReport, bool isRepWise)
    //    {
    //        string reportPath = "";
    //        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enmReport)))
    //        {
    //            string sRptName1 = "", sRptName2 = "";
    //            string sRptPath = GetReportPath(clsAutocode.getReportID(enmReport), ref sRptName1, ref sRptName2);

    //            if (sRptPath != null && sRptPath != "")
    //            {
    //                try
    //                {
    //                    gbl_dts_bssOutstandingLedger.Clear();
    //                    glb_dtsReportExport.Clear();

    //                    int iSalesRepShowType = 0;

    //                    #region Fill Sales rep dataset
    //                    foreach (tbl_genEmployeeMaster oSalesRep in tbl_genEmployeeMaster.SelectAll().Where(p => p.IsSelesRep))
    //                    {
    //                        gbl_dts_bssOutstandingLedger.genSalesRep.AddgenSalesRepRow(oSalesRep.Employee_ID, oSalesRep.EmployeeName);
    //                    }
    //                    #endregion

    //                    #region Fill Customer Finance dataset
    //                    if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Detail || enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Summary || enmReport == enum_ReportName.RG_OutstandingStatement || enmReport == enum_ReportName.RG_OutstandingStatement_SendEmail || enmReport == enum_ReportName.RG_Age_Analysis_Customer_wise || enmReport == enum_ReportName.RG_Age_Analysis_Salesman_wise)
    //                    {
    //                        if (bCustomerSelected)
    //                        {
    //                            tbl_genCustomerFinance oDetail = tbl_genCustomerFinance.Select(txtCustomer.Tag.ToString().Trim());
    //                            if (oDetail != null)
    //                                gbl_dts_bssOutstandingLedger.genCustomerFinance.AddgenCustomerFinanceRow(oDetail.Customer_ID, "", clsGenaralName.getName_CustomerRegisterAddress(oDetail.Customer_ID), "", 0, oDetail.CreditPeriod, oDetail.CreditLimit);
    //                        }
    //                        else
    //                        {
    //                            foreach (tbl_genCustomerFinance oDetail in tbl_genCustomerFinance.SelectAll().Where(p => p.Customer_ID != "default"))
    //                            {
    //                                gbl_dts_bssOutstandingLedger.genCustomerFinance.AddgenCustomerFinanceRow(oDetail.Customer_ID, "", clsGenaralName.getName_CustomerRegisterAddress(oDetail.Customer_ID), "", 0, oDetail.CreditPeriod, oDetail.CreditLimit);
    //                            }
    //                        }
    //                    }
    //                    #endregion

    //                    string sSalesRep_ID = "default";

    //                    List<tbl_genCustomerMaster> ocustomers;
    //                    #region Customer
    //                    if (bCustomerSelected)
    //                        ocustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID == txtCustomer.Tag.ToString().Trim()).ToList();
    //                    else
    //                        ocustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default").ToList();
    //                    #endregion

    //                    foreach (tbl_genCustomerMaster ocustomer in ocustomers)
    //                    {
    //                        //if (!bCustomerSelected)
    //                        //    clsHelpMethods.startProgressBar(0, ocustomers.Count + 2, 1, ProgressBar);

    //                        #region Customer type filter
    //                        if (rdoLocal.Checked)
    //                        {
    //                            if (ocustomer.CustomerType_ID != "1")
    //                                continue;
    //                        }
    //                        else if (rdoExport.Checked)
    //                        {
    //                            if (ocustomer.CustomerType_ID != "2")
    //                                continue;
    //                        }
    //                        #endregion

    //                        #region Sales rep filter - customer master
    //                        if (isRepWise)
    //                        {
    //                            if (chkUseCustomerMastorSaleRep.Checked)
    //                            {
    //                                sSalesRep_ID = ocustomer.SalesRep_ID;
    //                                if (bSelesRepSelected)
    //                                    if (ocustomer.SalesRep_ID != txtSalesRep.Tag.ToString().Trim())
    //                                        continue;
    //                                iSalesRepShowType = 2;
    //                            }
    //                            else
    //                                iSalesRepShowType = 1;//filter by the SQL 
    //                        }
    //                        #endregion

    //                        var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(ocustomer.Customer_ID, Convert.ToDateTime("01/01/2001"), dtpTo.Value.Date, true);
    //                        foreach (srh_bssCustomerOutstanding oDetail in oDetails)
    //                        {
    //                            #region Sales rep filter - Others
    //                            if (iSalesRepShowType == 1)
    //                            {
    //                                if (bSelesRepSelected)
    //                                    if (oDetail.Employee_ID != txtSalesRep.Tag.ToString().Trim())
    //                                        continue;
    //                                sSalesRep_ID = oDetail.Employee_ID;
    //                            }
    //                            #endregion

    //                            if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Detail)
    //                            {
    //                                if (oDetail.IsChecueInHand)
    //                                {
    //                                    foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in srh_bssCustomerOutstanding_RecieptDetail.SelectAll(oDetail.PurchaseOrder_ID, dtpTo.Value.Date))
    //                                    {
    //                                        gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName, oDetail.TransactionType, oRecipts.Invoice_ID, oRecipts.InvoiceDate, oRecipts.GrandTotal, oRecipts.SattledAmount, "", oDetail.IsCredit, oDetail.IsChecueInHand, false, "", oRecipts.Age, oRecipts.DeliveryOrder_ID, oRecipts.PurchaseOrder_ID, oRecipts.Receipt_ID, oRecipts.CurrencyCode, oRecipts.CurrencyRate, oDetail.IsAdvance);
    //                                    }
    //                                    continue;
    //                                }
    //                                if (oDetail.TransactionType == 3)
    //                                {
    //                                    decimal dRCSettledAmount = oDetail.TransactionAmount - oDetail.Outstanding;

    //                                    foreach (srh_bssCustomerOutstanding_RecieptDetail oRecipts in srh_bssCustomerOutstanding_RecieptDetail.SelectAll(oDetail.PurchaseOrder_ID, dtpTo.Value.Date).OrderBy(p => p.Age))
    //                                    {
    //                                        if (dRCSettledAmount >= oRecipts.SattledAmount)
    //                                            dRCSettledAmount -= oRecipts.SattledAmount;
    //                                        else
    //                                        {
    //                                            gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName, oDetail.TransactionType, oRecipts.Invoice_ID, oRecipts.InvoiceDate, oRecipts.GrandTotal, (oRecipts.SattledAmount - dRCSettledAmount), oDetail.Remarks, oDetail.IsCredit, false, false, "", oRecipts.Age, oRecipts.DeliveryOrder_ID, oRecipts.PurchaseOrder_ID, "", oRecipts.CurrencyCode, oRecipts.CurrencyRate, oDetail.IsAdvance);
    //                                            dRCSettledAmount = 0;
    //                                        }
    //                                    }
    //                                    continue;
    //                                }
    //                            }
    //                            if (enmReport == enum_ReportName.RG_Outstanding_Invoice_wise_Summary || enmReport == enum_ReportName.RG_OutstandingStatement || enmReport == enum_ReportName.RG_OutstandingStatement_SendEmail)
    //                            {
    //                                if (oDetail.IsChecueInHand)
    //                                    continue;
    //                            }

    //                            gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName, oDetail.TransactionType, oDetail.Transaction_ID,
    //                                oDetail.TransactionDate, oDetail.TransactionAmount, oDetail.Outstanding, oDetail.Remarks, oDetail.IsCredit, oDetail.IsChecueInHand, false, sSalesRep_ID, oDetail.Age, oDetail.DeliveryOrder_ID, oDetail.PurchaseOrder_ID, "", oDetail.CurrencyCode, oDetail.CurrencyRate, oDetail.IsAdvance);

    //                            //if (bCustomerSelected)
    //                            //    clsHelpMethods.startProgressBar(0, oDetails.Count + 2, 1, ProgressBar);
    //                        }
    //                    }

    //                    string sDateRange = "From :" + dtpFrom.Value.ToString("dd MMM yyyy") + " To :" + dtpTo.Value.ToString("dd MMM yyyy");

    //                    string sReportFilter = "";
    //                    if (rdoLocal.Checked)
    //                        sReportFilter += " Customer Type : Local";
    //                    if (rdoExport.Checked)
    //                        sReportFilter += "Customer Type : Export";
    //                    if (bCustomerSelected)
    //                        sReportFilter += " Customer Name : " + txtCustomer.Text.Trim();
    //                    if (bSelesRepSelected)
    //                        sReportFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
    //                    else
    //                        sReportFilter += (sReportFilter.Length > 0) ? "" : " - ";

    //                    gbl_dts_bssOutstandingLedger.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sRptName1, sRptName2, sDateRange, clsSecurity.UserNameLoged, sReportFilter);

    //                    string sCompanyName = "", sCompanyTell = "", sCompanyAddress = "", sCompanyEmail = "";
    //                    tbl_genCompanyInfo oInfo = tbl_genCompanyInfo.Select("Company1");
    //                    if (oInfo != null && oInfo.CompanyID != "default")
    //                    {
    //                        sCompanyName = clsSecurity.decryptPassword(oInfo.CompanyName);
    //                        sCompanyTell = oInfo.Telephone1;
    //                        sCompanyTell += "," + oInfo.Telephone2 != "" ? oInfo.Telephone2 : "";
    //                        sCompanyAddress = oInfo.Address;
    //                    }

    //                    if (rdopOutstandingStatement.Checked)
    //                    {
    //                        tbl_securityCompanyValues oCompany = tbl_securityCompanyValues.Select((int)enum_CompanyValue.companyName);//7
    //                        if (oCompany != null)
    //                            sCompanyName = oCompany.CompanyValuesDetail;

    //                        oCompany = null;
    //                        oCompany = tbl_securityCompanyValues.Select((int)enum_CompanyValue.companyEmail);//6
    //                        if (oCompany != null)
    //                            sCompanyEmail = oCompany.CompanyValuesDetail;
    //                    }

    //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDetail", isDetailReport ? "1" : "0", true);
    //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", sCompanyName, true);
    //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactTel", sCompanyTell, true);
    //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Address", sCompanyAddress, true);
    //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ContactEmail", sCompanyEmail, true);

    //                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BackDate", "As At Date : " + dtpTo.Value.Date.ToString("dd/MM/yyyy"), true);

    //                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
    //                    if (enmReport == enum_ReportName.RG_OutstandingStatement_SendEmail)
    //                    {
    //                        if (gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.Rows.Count != 0)
    //                            reportPath = rpt.print(sRptPath, gbl_dts_bssOutstandingLedger, glb_dtsReportExport.dt_rptParameter, true);
    //                    }
    //                    else
    //                        rpt.print(sRptPath, gbl_dts_bssOutstandingLedger, glb_dtsReportExport.dt_rptParameter);
    //                }
    //                catch (Exception ex)
    //                {
    //                    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                }
    //                finally
    //                {
    //                    // Cursor = Cursors.Default;
    //                    gbl_dts_bssOutstandingLedger.Clear();
    //                    glb_dtsReportExport.Clear();
    //                    //  clsHelpMethods.startProgressBar(0, 0, 0, ProgressBar);
    //                }
    //            }
    //            else
    //                MessageBox.Show("Report not found");
    //        }
    //        return reportPath;
    //    }
    //}

    public class clsUtil
    {
        #region Email
        //Email Create
        //Email Settings & Others

        #region Send Mail
        public static bool SendMail(string sUserID, ArrayList sMailTo, ArrayList sFilePaths, string Subject, string Body, bool bShowMessage)
        {
            bool bSuccess = false;
            tbl_utlEmailConfig mail = tbl_utlEmailConfig.Select(sUserID);
            if (mail != null)
            {
                try
                {
                    MailAddress From = new MailAddress(mail.EmailAddress);
                    MailMessage message = new MailMessage();
                    message.From = From;

                    foreach (string ToAdd in sMailTo)
                    {
                        MailAddress to = new MailAddress(ToAdd.ToString());
                        message.To.Add(to);
                    }

                    message.Subject = Subject;
                    message.Body = Body;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = mail.SmtpClient;
                    smtp.Port = mail.SmtpPort;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(From.Address, clsSecurity.decryptPassword(mail.EmailPassword));

                    foreach (String sFilpath in sFilePaths)
                    {
                        Attachment att = new Attachment(sFilpath);
                        message.Attachments.Add(att);
                    }

                    smtp.Send(message);
                    if (bShowMessage)
                    {
                        MessageBox.Show("Email sent successfully!");

                    } bSuccess = true;
                }

                catch (Exception ex)
                {
                    bSuccess = false;
                    if (bShowMessage)
                        MessageBox.Show("Failed to send message because " + ex.Message);
                }

            }
            return bSuccess;
        }
        #endregion

        #region Send Mail HTML
        public static void SendMailHTML(string sAlertID, string sSubject, string sBodyHTML)
        {
            int Emailid = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.EmailBox)));
            tbl_utlAlertMailBox_Pending oAlerts = new tbl_utlAlertMailBox_Pending(Emailid, sAlertID, sSubject, sBodyHTML, 0);
            oAlerts.Insert();
            int i = 0;
            foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(sAlertID))
            {
                if (oAlertSetting.UserEmail1.Length > 0)
                {
                    tbl_utlAlertMailBox_Receiver oAlertRes = new tbl_utlAlertMailBox_Receiver(Emailid, i, 0, oAlertSetting.PersonName, oAlertSetting.UserEmail1);
                    oAlertRes.Insert();
                    i++;
                }
            }
        }
        public static bool SendMailHTML(string sUserID, ArrayList sMailTo, ArrayList sFilePaths, string Subject, string Body, bool bShowMessage)
        {
            bool bSuccess = false;
            tbl_utlEmailConfig mail = tbl_utlEmailConfig.Select(sUserID);
            if (mail != null)
            {
                try
                {
                    MailAddress From = new MailAddress(mail.EmailAddress);
                    MailMessage message = new MailMessage();
                    message.IsBodyHtml = true;
                    message.From = From;

                    foreach (string ToAdd in sMailTo)
                    {
                        MailAddress to = new MailAddress(ToAdd.ToString());
                        message.To.Add(to);
                    }

                    message.Subject = Subject;
                    message.Body = Body;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = mail.SmtpClient;
                    smtp.Port = mail.SmtpPort;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(From.Address, clsSecurity.decryptPassword(mail.EmailPassword));

                    foreach (String sFilpath in sFilePaths)
                    {
                        Attachment att = new Attachment(sFilpath);
                        message.Attachments.Add(att);
                    }

                    smtp.Send(message);
                    if (bShowMessage)
                    {
                        MessageBox.Show("Email sent successfully!");

                    } bSuccess = true;
                }

                catch (Exception ex)
                {
                    bSuccess = false;
                    if (bShowMessage)
                        MessageBox.Show("Failed to send message because " + ex.Message);
                }
            }
            return bSuccess;

        }
        #endregion 
        #endregion

        #region SMS
        // SMS Create

        #region SMS Alerts JIT

        #region Creating Invoice
        public static void CreateSMS_InvoiceCreate(enum_Alerts alertType, string sMobile, string sMessage)
        {
            bool SmsStatus = false;
            try
            {
                tbl_utlAlert oAlert = tbl_utlAlert.Select(clsAutocode.getAlertID(alertType));
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    //Send Direct Number if Exists
                    if (sMobile.Length > 0)
                    {
                        SmsStatus = sendMessage_UsingShareFolder(sMobile, sMessage);
                    }

                    //Send For Setting Number
                    foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    {
                        if (oAlertSetting.PhoneNo1.Length > 0)
                        {
                            SmsStatus = sendMessage_UsingShareFolder(oAlertSetting.PhoneNo1, sMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion

        //SMS Settings & Others

        #region SMS Open and Close Ports
        public static AutoResetEvent receiveNow;

        //Open Port
        public static SerialPort OpenPort(string p_strPortName, int p_uBaudRate, int p_uDataBits, int p_uReadTimeout, int p_uWriteTimeout)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();

            try
            {
                port.PortName = p_strPortName;                 //COM1
                port.BaudRate = p_uBaudRate;                   //9600
                port.DataBits = p_uDataBits;                   //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = p_uReadTimeout;             //300
                port.WriteTimeout = p_uWriteTimeout;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception)
            {
            }
            return port;
        }

        //Close Port
        public static void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Receive data from port
        //Receive data from port
        public static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception)
            {
            }
        }
        public static string ReadResponse(SerialPort port, int timeout)
        {
            string buffer = string.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string t = port.ReadExisting();
                        buffer += t;
                    }
                    else
                    {
                        if (buffer.Length > 0)
                            throw new ApplicationException("Response received is incomplete.");
                        else
                            throw new ApplicationException("No data received from phone.");
                    }
                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> ") && !buffer.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception)
            {
            }
            return buffer;
        }
        #endregion

        #region Execute AT Command
        //Execute AT Command
        public static string ExecCommand(SerialPort port, string command, int responseTimeout, string errorMessage)
        {
            try
            {

                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                string input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException("No success message was received.");
                return input;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Send SMS
        static AutoResetEvent readNow = new AutoResetEvent(false);
        public static bool sendMessage(string PhoneNo, string Message)
        {
            bool isSend = false;

            try
            {
                SerialPort port = OpenPort(clsConfig.sDonglePortNo, 9600, 8, 300, 300);

                string recievedData = ExecCommand(port, "AT", 300, "No phone connected");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
                String command = "AT+CMGS=\"" + PhoneNo + "\"";
                recievedData = ExecCommand(port, command, 300, "Failed to accept phoneNo");
                command = Message + char.ConvertFromUtf32(26) + "\r";
                recievedData = ExecCommand(port, command, 3000, "Failed to send message"); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isSend = true;
                }
                else if (recievedData.Contains("ERROR"))
                {
                    isSend = false;
                }

                ClosePort(port);
                return isSend;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool sendMessage_UsingShareFolder(string iPhoneNo, string sMessage)
        {
            bool bRaisedError = false;
            string sFileName = "";
            StreamWriter file = null;
            try
            {
                sFileName = DateTime.Now.ToString() + ".dat";
                sFileName = sFileName.Replace("/", "-");
                sFileName = sFileName.Replace(":", ".");
                using (file = new StreamWriter(clsConfig.sGbl_SMS_Shared_Folder_Parth + sFileName))
                {
                    file.Write(iPhoneNo.ToString() + ";" + sMessage);
                    clsValidate.WriteSMSLog(iPhoneNo.ToString() + ";" + sMessage+"\r\n");
                    bRaisedError = true;                    
                }
            }
            catch (DirectoryNotFoundException)
            {

               Directory.CreateDirectory(clsConfig.sGbl_SMS_Shared_Folder_Parth);
                using (file = new StreamWriter(clsConfig.sGbl_SMS_Shared_Folder_Parth + sFileName))
                {
                    file.Write(iPhoneNo.ToString() + ";" + sMessage);
                    clsValidate.WriteSMSLog(iPhoneNo.ToString() + ";" + sMessage);
                    bRaisedError = true;
                }
            }
            catch (Exception exception)
            {
                bRaisedError = false;
                MessageBox.Show("Failed to send message because " + exception.Message);
            }
            finally
            {
                file.Close();
                file.Dispose();
            }
            return bRaisedError;

        }
        static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                    readNow.Set();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Read SMS
        //public AutoResetEvent receiveNow;
        //public ShortMessageCollection ReadSMS(SerialPort port, string p_strCommand, bool bMsgType)
        //{

        //    // Set up the phone and read the messages
        //    ShortMessageCollection messages = null;
        //    try
        //    {

        //        #region Execute Command
        //        // Check connection
        //        ExecCommand(port, "AT", 300, "No phone connected");
        //        // Use message format "Text mode"
        //        ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
        //        //// Use character set "PCCP437"
        //        //ExecCommand(port,"AT+CSCS=\"PCCP437\"", 300, "Failed to set character set.");               
        //        // Select SIM storage
        //        ExecCommand(port, "AT+CPMS=\"SM\"", 300, "Failed to select message storage.");
        //        // Read the messages
        //        string input = ExecCommand(port, p_strCommand, 5000, "Failed to read the messages.");
        //        #endregion

        //        #region Parse messages
        //        messages = ParseMessages(input, bMsgType);
        //        #endregion

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    if (messages != null)
        //        return messages;
        //    else
        //        return null;

        //}
        //public ShortMessageCollection ParseMessages(string input, bool bMsgType)
        //{
        //    ShortMessageCollection messages = new ShortMessageCollection();
        //    try
        //    {
        //        Regex r;
        //        if (bMsgType)
        //            r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
        //        else
        //            r = new Regex(@"\+CMGL: (\d+),""(.+)"",(\d+),(\d+),""(.+)"",(\d+),""(.+)"",""(.+)"",(\d+)\r\n");

        //        Match m = r.Match(input);
        //        while (m.Success)
        //        {
        //            ShortMessage msg = new ShortMessage();

        //            if (bMsgType)
        //            {
        //                msg.Index = m.Groups[1].Value;
        //                msg.Status = m.Groups[2].Value;
        //                msg.Sender = m.Groups[3].Value;
        //                msg.Alphabet = m.Groups[4].Value;
        //                msg.Sent = m.Groups[5].Value;
        //                msg.Message = m.Groups[6].Value;
        //            }
        //            else
        //            {
        //                msg.Index = m.Groups[1].Value;
        //                msg.Status = m.Groups[2].Value;
        //                msg.Alphabet = m.Groups[4].Value;
        //                msg.Sent = m.Groups[8].Value;
        //                msg.Sender = m.Groups[5].Value;
        //                if (m.Groups[9].Value == "0")
        //                    msg.Message = "Delivered";
        //                else if (m.Groups[9].Value == "34")
        //                    msg.Message = "Pending";
        //            }

        //            messages.Add(msg);
        //            m = m.NextMatch();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return messages;
        //}
        #endregion 
        #endregion

        #region Backup
        public static bool isBacupActive(DateTime dtmLastBackup)
        {
            bool isOK = false;
            if (dtmLastBackup.Date < DateTime.Now.Date)
            {
                if (dtmLastBackup.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    isOK = true;
                    clsConfig.sLastBackupedDate = DateTime.Now.ToString();
                    foreach (tbl_securityConfigValue oConValue in tbl_securityConfigValue.SelectAllByConfigTypeValue_ID("CTV/001"))
                    {
                        switch (oConValue.ValueID)
                        {
                            case 47 :
                            oConValue.ConfigValue = DateTime.Now.ToString();
                            oConValue.Update();
                            break;
                        }
                    }//47
                   
                }
            }
            return isOK;
        }

        public static void startAutoBacup(string TargetPath)
        {
          //  bool bShowFileWicePresentage = false;
            StringBuilder sb = new StringBuilder();
            bool bIsBackupOk = false;

            sb.Clear();
            sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program stated");

            try
            {
                bool isConfigarationOk = true;
             //   bShowFileWicePresentage = false;
                string sError = "";

                #region Check Backup Parth Validity

                if (clsConfig.sSeaccBackupPath_Server == "")
                {
                    isConfigarationOk = false;
                    sError = "Invalied Backup Path...";
                    sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                }
                else
                {
                    if (!Directory.Exists(clsConfig.sSeaccBackupPath_Server))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Backup Path...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (clsConfig.sSeaccBackup_SourceFolder_1 != "")
                {
                    if (!Directory.Exists(clsConfig.sSeaccBackup_SourceFolder_1))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Source Directry Path 1...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (clsConfig.sSeaccBackup_SourceFolder_2 != "")
                {
                    if (!Directory.Exists(clsConfig.sSeaccBackup_SourceFolder_2))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Source Directry Path 2...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (clsConfig.sSeaccBackup_SourceFolder_3 != "")
                {
                    if (!Directory.Exists(clsConfig.sSeaccBackup_SourceFolder_3))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Source Directry Path 3...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (!isConfigarationOk)
                    MessageBox.Show(sError);

                #endregion

                if (isConfigarationOk)
                {
                    if (TargetPath != "" && TargetPath.Length > 0)
                    {

                        DateTime dtm_BackupStartTime = DateTime.Now;
                        string sTempDirectryPath = clsConfig.sSeaccBackupPath_Server + "\\Temp_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm");
                        string DatabaseBackupPath = sTempDirectryPath + "\\db_" + clsSecurity.Database + "_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SDB";
                        string SourceFolder_1_BackupPath = sTempDirectryPath + "\\SourceFolder_1_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string SourceFolder_2_BackupPath = sTempDirectryPath + "\\SourceFolder_2_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string SourceFolder_3_BackupPath = sTempDirectryPath + "\\SourceFolder_3_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string sFinalBackupFolderPath = clsConfig.sSeaccBackupPath_Server + "\\SEACC_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";

                        Directory.CreateDirectory(sTempDirectryPath);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Temporary directory created - " + sTempDirectryPath);

                        #region Back up Database
                        SqlConnection scon = DBHandling.GetConnection();
                        SqlCommand command = new SqlCommand("BACKUP DATABASE " + clsSecurity.Database + @" TO  DISK = N'" + DatabaseBackupPath + "' WITH NOFORMAT, NOINIT,  SKIP,  NOREWIND, NOUNLOAD,  STATS = 5", scon);
                        command.CommandType = CommandType.Text;
                        command.CommandTimeout = 8000;
                        scon.Open();



                        scon.InfoMessage += clsProcessMethods.scon_InfoMessage;
                        SqlDataReader dr = command.ExecuteReader();

                        scon.Close();
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Database backed up successfully");
                        #endregion


                        if (clsConfig.sSeaccBackup_SourceFolder_1 != "")
                        {
                            clsProcessMethods.ArchiveDirectory(clsConfig.sSeaccBackup_SourceFolder_1, SourceFolder_1_BackupPath);
                            sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - " + clsConfig.sSeaccBackup_SourceFolder_1);
                        }

                        if (clsConfig.sSeaccBackup_SourceFolder_2 != "")
                        {
                            clsProcessMethods.ArchiveDirectory(clsConfig.sSeaccBackup_SourceFolder_2, SourceFolder_2_BackupPath);
                            sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - " + clsConfig.sSeaccBackup_SourceFolder_2);
                        }


                        if (clsConfig.sSeaccBackup_SourceFolder_3 != "")
                        {
                            clsProcessMethods.ArchiveDirectory(clsConfig.sSeaccBackup_SourceFolder_3, SourceFolder_3_BackupPath);
                            sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - " + clsConfig.sSeaccBackup_SourceFolder_3);
                        }



                      //  bShowFileWicePresentage = true;

                        clsProcessMethods.ArchiveDirectory(sTempDirectryPath, sFinalBackupFolderPath);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Folders Compressed");



                        //delete db backup
                        File.Delete(DatabaseBackupPath);


                        //delete SourceFolder_1 backup 
                        try { File.Delete(SourceFolder_1_BackupPath); }
                        catch (Exception) { }
                        try { File.Delete(SourceFolder_2_BackupPath); }
                        catch (Exception) { }
                        try { File.Delete(SourceFolder_3_BackupPath); }
                        catch (Exception) { }

                        //delete temp folder
                        Directory.Delete(sTempDirectryPath);


                        File.Copy(sFinalBackupFolderPath, TargetPath + "\\" + clsConfig.sSeaccBackupPreFix + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");

                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Copy to local - " + TargetPath + "\\" + clsConfig.sSeaccBackupPreFix + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");
                        MessageBox.Show("Backup Successfull");
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Successfull");
                        bIsBackupOk = true;
                    }
                    else
                    {
                        MessageBox.Show("Please Select The Location for Backup File", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - Backup lockation not set");
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program stoped - " + ex.Message);
                
            }
            finally
            {
                tbl_audBackupLog oBackup = new tbl_audBackupLog(clsSecurity.getServerDateTime(), 1, bIsBackupOk, clsSecurity.UserIDLoged, clsSecurity.TerminalID, sb.ToString());
                oBackup.Insert();
            }
        }
        #endregion

        #region Barcode/QR Code
        public static byte[] GetBarcode(string sValue)
        {
            byte[] barcodeInBytes;
            Image myimg = Code128Rendering.MakeBarcodeImage(sValue, 2, true);
            ImageConverter _imageConverter = new ImageConverter();
            barcodeInBytes = (byte[])_imageConverter.ConvertTo(myimg, typeof(byte[]));            
            return barcodeInBytes;
        }
        public static byte[] GetQRcode(string sValue)
        {
            byte[] barcodeInBytes;         

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            String encoding = "Byte"; //encoding is hardcoded to alphanumeric
            if (encoding == "Byte")            
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;            
            else if (encoding == "AlphaNumeric")          
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;           
            else if (encoding == "Numeric")
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;

            try
            {
                int scale = Convert.ToInt16(4); // size is hardcoded to 4
                qrCodeEncoder.QRCodeScale = scale;
            }
            catch (Exception )
            {
                MessageBox.Show("QR Value Size is Invalid!");               
            }
            try
            {                
                int version = Convert.ToInt16(7); //version is hardcoded to 7
                qrCodeEncoder.QRCodeVersion = version;
            }
            catch (Exception )
            {
                MessageBox.Show("QR Version is Invalid!");
            }

            string errorCorrect = "M"; //correction level is hardcoded to M
            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
             Image myimg;
            try
            {
                myimg = qrCodeEncoder.Encode(sValue);
            }
            catch(Exception )
            {
                myimg = qrCodeEncoder.Encode("Error");
            }
            ImageConverter _imageConverter = new ImageConverter();
            barcodeInBytes = (byte[])_imageConverter.ConvertTo(myimg, typeof(byte[]));
            return barcodeInBytes;
        }
        #endregion
    }
}


class tmpInvoiceExceededCreditPeriod
{
   // public int LineNo;
    public string CustomerName;
    public string InvoiceNo;
    public string InvoiceDate;
    public decimal CreditPeriod;
    public decimal Days;
    public decimal Amount;
}

class tmpCustomerExceededCredit
{
    public string CustomerCode;
    public string CustomerName;
    public string Salesman;
    public decimal Creditlimit;
    public decimal OutstandingAmu;
    public decimal ChequeInHandAmu;
    public decimal ExceedeAmu;

}

class tmpTurnOverSalesRepWise
{
    public string SalesmanID;    
    public decimal AmtInvoices;
    public decimal AmtCreditNote;
    public decimal AmtCollection_Cash;
    public decimal AmtCollection_Cheque;
    public decimal AmtApprovedOrders;
    public decimal dSalesReturnValue;
}

class tmpJobOutsStanding
{

    public int count;
    public string sProductionJob_ID;
    public string sPONo;
    public string sCustomerName;
    public DateTime CustomerOrderDate;
    public int  iAgeing;
    public string sItemCode;
    public string sUom;
    public string sOrderQty;
    public string sDeliveryQty;
    public string sBalanceQty;
    public decimal dBalancePasantage;

}

class tmpSectionPlan
{
    public string sJobNo;
    public string sCustomerName;
    public string sItemName;
    public decimal dQty;
    public string sUom;
} 