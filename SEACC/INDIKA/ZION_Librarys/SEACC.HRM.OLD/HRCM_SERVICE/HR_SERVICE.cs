using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Reflection;
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;
using SEACC_Alert_Engine;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace HRCM_SERVICE
{
    public partial class SEACC_HRCMT_SERVICE : ServiceBase
    {
        #region Class Variables
        private Thread _thread;
        private Thread _thread_Hr_Clock;

        int iloopTime = 10000;
        int iMaximumEmailsPerHour = 60;
        int iEmailCount = 0;
        DateTime dtmCurrentDate = DateTime.Now.Date;
        #endregion

        #region Initialize Service
        public SEACC_HRCMT_SERVICE()
        {
            InitializeComponent();
            clsValidation.WriteErrorLog("\nSEACC Support Service Initialize");
        }
        #endregion

        #region Actions

        protected override void OnStart(string[] args)
        {
            try
            {
                bool bisThredStartOk = false;
                if (CheckValidityRegistry())
                    if (GetConnectionInformation())
                    {
                        if (clsSecurity.AutoAssignCompanyValue())
                            if (CheckValidity_Company())
                            {
                                _thread = new Thread(DoWork);
                                _thread.Start();

                                _thread_Hr_Clock = new Thread(HoursClock);
                                _thread_Hr_Clock.Start();

                                bisThredStartOk = true;
                            }
                    }

                if (!bisThredStartOk)
                {
                    clsValidation.WriteErrorLog("\nSEACC Support Service Cannot be started");
                    Stop();
                }
                else
                {
                    clsValidation.WriteErrorLog("\nSEACC Support Service Started");
                }
            }
            catch (Exception ex)
            {
                clsValidation.WriteErrorLog("\nService Start Faild - " + ex.Message);
                Stop();
            }
        }

        public void Testdebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            clsValidation.WriteErrorLog("\nService Stoped");
        }

        private void DoWork()
        {
            while (true)
            {
                try
                {
                    if (iEmailCount < iMaximumEmailsPerHour)
                    {
                        foreach (tbl_utlAlertMailBox_Pending oPendingMail in tbl_utlAlertMailBox_Pending.SelectAll().Where(r => r.Status != (int)EmailStatus.sentMail && r.Status != (int)EmailStatus.Error_Reception))
                        {
                            List<MaillReceptioner> oMailToList = new List<MaillReceptioner>().ToList();
                            ArrayList sFilePaths = new ArrayList();

                            foreach (tbl_utlAlertMailBox_Receiver oEmailReciver in tbl_utlAlertMailBox_Receiver.SelectAll().Where(p=> p.EMail_ID == oPendingMail.EMail_ID))
                            {
                                MaillReceptioner oMailTo = new MaillReceptioner(oEmailReciver.Name, oEmailReciver.EmailAddress, (SendMailTypes)oEmailReciver.Type);
                                oMailToList.Add(oMailTo);
                            }

                            #region Attachments
                            //tbl_utlAlertMailBox_Attachments oAttachments = tbl_utlAlertMailBox_Attachments.Select(oPendingMail.EMail_ID);
                            //if (oAttachments != null && oAttachments.FilePath != "")
                            //{
                            //    sFilePaths.Add(oAttachments.FilePath);
                            //}
                            #endregion

                            tbl_utlAlert oAlert = tbl_utlAlert.Select(oPendingMail.Alert_ID);

                            //oPendingMail.Status = SendMailHTML("admin", oPendingMail.Alert_ID.ToString(), oMailToList, sFilePaths, oPendingMail.Subject, oPendingMail.Body);
                            oPendingMail.Status = SendMailHTML(oAlert.AlertSender_ID, oPendingMail.Alert_ID.ToString(), oMailToList, sFilePaths, oPendingMail.Subject, oPendingMail.Body);
                            oPendingMail.Update();
                            iEmailCount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsValidation.WriteErrorLog("\nAlert Sending - Error " + ex.Message);
                }
                Thread.Sleep(iloopTime);
            }
        }

        private void HoursClock()
        {
            while (true)
            {
                try
                {
                    clsAlerts_Email.Checking_SheduledAlerts();
                    iEmailCount = 0;
                    Thread.Sleep(1800000); // Sleep 30 mins
                }
                catch (Exception ex)
                {
                    clsValidation.WriteErrorLog("\nAuto Alert-Error " + ex.Message);
                    Stop();
                }
            }
        }

        #endregion

        #region Check Validity

        #region Check Validity Registry
        private bool CheckValidityRegistry()
        {
            bool isRegistryOK = true;
            try
            {
                string ProductType = ((AssemblyProductAttribute[])Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)).Single().Product.ToLower();
                clsSecurity.RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";

                #region Select Product type
                if (ProductType == "epack")
                {
                    clsSecurity.RegRegistryName += "1212";
                }
                else if (ProductType == "epackt")
                {
                    clsSecurity.RegRegistryName += "1212t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "epackn2")
                {
                    clsSecurity.RegRegistryName += "1212n";
                }
                else if (ProductType == "crystal")
                {
                    clsSecurity.RegRegistryName += "1213";
                }
                else if (ProductType == "crystalt")
                {
                    clsSecurity.RegRegistryName += "1213t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "crystaln2")
                {
                    clsSecurity.RegRegistryName += "1213n";
                }
                else if (ProductType == "chemical")
                {
                    clsSecurity.RegRegistryName += "1215";
                }
                else if (ProductType == "chemicalt")
                {
                    clsSecurity.RegRegistryName += "1215t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "hrcm")
                {
                    clsSecurity.RegRegistryName += "1216";
                }
                else if (ProductType == "hrcmt")
                {
                    clsSecurity.RegRegistryName += "1216t";
                }
                else if (ProductType == "pvc")
                {
                    clsSecurity.RegRegistryName += "1214";
                }
                #endregion

                if (!clsSecurity.CheckRegName())
                {
                    clsValidation.WriteErrorLog("Registry Error...");
                    isRegistryOK = false;
                }
            }
            catch (Exception ex)
            {
                isRegistryOK = false;
                clsValidation.WriteErrorLog(ex.Message, 0);
            }

            return isRegistryOK;
        }
        #endregion

        #region Check Validity Company
        private bool CheckValidity_Company()
        {
            bool bValid = true;
            try
            {
                string sCom = clsSecurity.CompanyID;
                tbl_genCompanyInfo company = tbl_genCompanyInfo.Select(sCom);
                if (company != null)
                {
                    clsSecurity.CompanyID = company.CompanyID;
                    clsBackProcess.AutoAssignConfigValue();
                    clsBackProcess.AutoAssignConfigStatus();
                }
                else
                {
                    clsValidation.WriteErrorLog("\nRegistry Error....! Please contact your system administrator");
                    bValid = false;
                }
            }
            catch (Exception ex)
            {
                clsValidation.WriteErrorLog("\nRegistry Error....!" + ex.Message);
                bValid = false;
            }
            return bValid;
        }
        #endregion

        #endregion

        #region PassDB Information
        private bool GetConnectionInformation()
        {
            bool status = false;
            if (clsSecurity.setRegistryValue())
            {
                DBHandling.DBConnection = "user id=" + clsSecurity.DB_UserName + ";password=" + clsSecurity.DB_Password + ";data source=" + clsSecurity.DB_Server + ";persist security info=true;initial catalog=" + clsSecurity.DB_Database;
                status = true;
            }
            return status;
        }
        #endregion

        #region Help Methods
        public static int SendMailHTML(string sSenderID, string sAlertID, List<MaillReceptioner> sMailTo, ArrayList sFilePaths, string Subject, string Body)
        {
            EmailStatus enmStatus = (int)EmailStatus.newMail;

            //tbl_utlAlert_Sender oAlertSender = tbl_utlAlert_Sender.Select("admin");
            tbl_utlAlert_Sender oAlertSender = tbl_utlAlert_Sender.Select(sSenderID);
            if (oAlertSender != null)
            {
                try
                {
                    if (sMailTo.Count > 0)
                    {
                        MailAddress From = new MailAddress(oAlertSender.EmailAddress, "SEACC Alert System");
                        MailMessage message = new MailMessage();
                        message.From = From;
                        message.Subject = Subject;
                        message.IsBodyHtml = true;

                        #region Reciver
                        foreach (MaillReceptioner ToAdd in sMailTo)
                        {
                            if (ToAdd.sEmail != null && ToAdd.sEmail.Length > 1)
                                switch (ToAdd.iMsgType)
                                {
                                    case SendMailTypes.To:
                                        MailAddress to = new MailAddress(ToAdd.sEmail, ToAdd.sName);
                                        message.To.Add(to);
                                        break;
                                    case SendMailTypes.CC:
                                        MailAddress cc = new MailAddress(ToAdd.sEmail, ToAdd.sName);
                                        message.CC.Add(cc);
                                        break;
                                    case SendMailTypes.BCC:
                                        MailAddress bcc = new MailAddress(ToAdd.sEmail, ToAdd.sName);
                                        message.Bcc.Add(bcc);
                                        break;
                                    default:
                                        break;
                                }
                        }
                        #endregion

                        message.Subject = Subject;
                        message.Body = Body;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = oAlertSender.SmtpClient;
                        smtp.Port = oAlertSender.SmtpPort;
                        smtp.EnableSsl = true;

                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(From.Address, clsSecurity.decryptPassword(oAlertSender.EmailPassword));
                        //  smtp
                        foreach (string sFilpath in sFilePaths)
                        {
                            Attachment att = new Attachment(sFilpath);
                            message.Attachments.Add(att);
                        }

                        smtp.Send(message);
                        enmStatus = EmailStatus.sentMail;
                        clsValidation.WriteErrorLog("\nMail Sent For :" + sAlertID);
                    }
                    else
                    {
                        clsValidation.WriteErrorLog("\nAlert Sending - Error - recipients not found   - " + sAlertID);
                        enmStatus = EmailStatus.Error_Reception;
                    }
                }
                catch (Exception ex)
                {
                    clsValidation.WriteErrorLog("\nAlert Sending - Error " + ex.Message + " - " + sAlertID);
                    enmStatus = EmailStatus.Error;
                }
            }
            return (int)enmStatus;
        }
        #endregion
    }
}
