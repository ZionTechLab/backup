using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using Digiteq_Logic;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Mail;
using SEACC_Alert_Engine;
using DataTire;

namespace Digiteq_Service
{
    partial class SEACC : ServiceBase
    {
        private Thread _thread;
        private Thread _thread_Hr_Clock;

        int iloopTime = 10000;
        int iMaximumEmailsPerHour = 60;
        int iEmailCount = 0;
        DateTime dtmCurrentDate = DateTime.Now.Date;

        public SEACC()
        {
            InitializeComponent();
        }

        public void Testdebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                bool bisThredStartOk = false;

                if (PassDBInformation())
                {
                    if (AsingCommonValues())
                    {
                        if (AsingOtherConfigValues())
                        {
                            _thread = new Thread(DoWork);
                            _thread.Start();

                            _thread_Hr_Clock = new Thread(HoursClock);
                            _thread_Hr_Clock.Start();

                            clsValidate.WriteErrorLog("SEACC Support Service Started", -1,null);

                            bisThredStartOk = true;
                        }
                    }
                }

                if (!bisThredStartOk)
                {
                    clsValidate.WriteErrorLog("SEACC Support Service Cannot be started", -1, null);
                    this.Stop();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Service Start Faild - " , -1,ex);
                this.Stop();
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
                    Thread.Sleep(1800000);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("Auto Alert-Error " , -1,ex);
                    this.Stop();
                }
            }
        }

        private void DoWork()
        {
            #region Saved Mail Send
            while (true)
            {
                try
                {
                    if (iEmailCount < iMaximumEmailsPerHour)
                    {
                        foreach (tbl_utlAlertMailBox_Pending oPendingMail in tbl_utlAlertMailBox_Pending.SelectAll_UnsentMails())
                        {
                            List<MaillReceptioner> oMailToList = new List<MaillReceptioner>().ToList();
                            ArrayList sFilePaths = new ArrayList();

                            foreach (tbl_utlAlertMailBox_Receiver oEmailReciver in tbl_utlAlertMailBox_Receiver.SelectAllByEMail_ID(oPendingMail.EMail_ID))
                            {
                                MaillReceptioner oMailTo = new MaillReceptioner(oEmailReciver.Name, oEmailReciver.EmailAddress, (SendMailTypes)oEmailReciver.Type);
                                oMailToList.Add(oMailTo);
                            }

                            tbl_utlAlertMailBox_Attachments oAttachments = tbl_utlAlertMailBox_Attachments.Select(oPendingMail.EMail_ID);
                            if (oAttachments != null && oAttachments.FilePath != "")
                            {
                                sFilePaths.Add(oAttachments.FilePath);
                            }

                            oPendingMail.Status = SendMailHTML("admin", oPendingMail.Alert_ID, oMailToList, sFilePaths, oPendingMail.Subject, oPendingMail.Body);
                            oPendingMail.Update();
                            iEmailCount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("Alert Sending - Error " , -1,ex);
                }
                Thread.Sleep(iloopTime);
            }
            #endregion
        }

        protected override void OnStop()
        {
            clsValidate.WriteErrorLog("Service Stoped", -1,null);
        }

        #region PassDB Information
        private bool PassDBInformation()
        {
            bool bValue = false;
            try
            {
                if (CheckValidityRegistry())
                {
                    clsSecurity.setRegistryValue();
                    DBHandling.DBConnection = "user id=" + clsSecurity.UserName + ";password=" + clsSecurity.Password + ";data source=" + clsSecurity.Server + ";persist security info=true;initial catalog=" + clsSecurity.Database;

                    clsValidate.WriteErrorLog("Connected to DB", -1,null);
                    bValue = true;
                }
            }
            catch (Exception ex)
            {
                bValue = false;
                clsValidate.WriteErrorLog("PassDBInfor-Error " , -1,ex);
            }
            return bValue;
        }
        #endregion

        #region Check Validity Registry
        private bool CheckValidityRegistry()
        {
            clsValidate.WriteErrorLog("Checking Registry ", -1,null);
            bool isRegistryOK = true;
            try
            {

                string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"\Digiteq_Service.exe", ""); ;
                string[] lines = System.IO.File.ReadAllLines(path + "/settings.ini");
                clsSecurity.SoftwareModle = lines[0];

                clsSecurity.RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";
                if (clsSecurity.SoftwareModle.ToLower() == "epack")
                {
                    clsSecurity.RegRegistryName += "1212";
                    clsFormatter.DigiteqTitle = "SEACC ePack";
                }
                else if (clsSecurity.SoftwareModle.ToLower() == "epackt")
                {
                    clsSecurity.RegRegistryName += "1212t";
                    clsFormatter.DigiteqTitle = "SEACC ePack Test";
                }
                else if (clsSecurity.SoftwareModle.ToLower() == "epackn2")
                {
                    clsSecurity.RegRegistryName += "12121";
                    clsFormatter.DigiteqTitle = "SEACC ePack N2";
                }
                else if (clsSecurity.SoftwareModle.ToLower() == "crystal")
                {
                    clsSecurity.RegRegistryName += "1213";
                    clsFormatter.DigiteqTitle = "SEACC Crystal";
                }
                else if (clsSecurity.SoftwareModle.ToLower() == "crystalt")
                {
                    clsSecurity.RegRegistryName += "1213t";
                    clsFormatter.DigiteqTitle = "SEACC Crystal Test";
                }
                else if (clsSecurity.SoftwareModle.ToLower() == "chemical")
                {
                    clsSecurity.RegRegistryName += "1215";
                    clsFormatter.DigiteqTitle = "SEACC Chemical";
                }
                else if (clsSecurity.SoftwareModle.ToLower() == "chemicalt")
                {
                    clsSecurity.RegRegistryName += "1215t";
                    clsFormatter.DigiteqTitle = "SEACC Chemical Test";
                }
                else if (clsSecurity.SoftwareModle.ToLower() == "pvc")
                {
                    clsSecurity.RegRegistryName += "1214";
                    clsFormatter.DigiteqTitle = "SEACC PVC";
                }
                clsSecurity.setRegName();
                clsValidate.WriteErrorLog("Checking Registry Completed - " + clsSecurity.RegRegistryName, -1,null);
            }
            catch (Exception ex)
            {
                isRegistryOK = false;
                clsValidate.WriteErrorLog("Registry-Error " , -1,ex);
            }
            return isRegistryOK;
        }
        #endregion

        #region Asign Common Values
        private bool AsingCommonValues()
        {
            bool bValue = true;
            try
            {
                tbl_securityUserMaster oUser = tbl_securityUserMaster.Select("admin");
                if (oUser != null)
                {
                    clsSecurity.UserIDLoged = oUser.User_ID;
                    clsSecurity.UserNameLoged = oUser.UserName;

                    tbl_securityGroup grp = tbl_securityGroup.Select(oUser.Group_ID);
                    clsSecurity.UserGroupLoged = grp.GroupName;
                    clsSecurity.UserGroupIDLoged = oUser.Group_ID;



                    clsSecurity.FinancialYearID = clsMethods_GL.getFinancialYear_ID_Current();
                    //  clsSecurity.LastFinancialYearID = clsMethods_Fin.getLastFinanceYearID();
                    clsValidate.WriteErrorLog("AsignValue-Success", -1,null);
                }
            }
            catch (Exception ex)
            {
                bValue = false;
                clsValidate.WriteErrorLog("AsignValue-Error" , -1,ex);
            }
            return bValue;
        }

        private bool AsingOtherConfigValues()
        {
            bool bValue = true;
            try
            {
                clsBackProcess.AutoAssignConfigValue();
                clsBackProcess.AutoAssignConfigStatus();
                clsBackProcess.AutoAssignCompanyValue();

                clsValidate.WriteErrorLog("Back process - Successful", -1, null);
            }
            catch (Exception ex)
            {
                bValue = false;
                clsValidate.WriteErrorLog("Back process-Error" , -1,ex);
            }
            return bValue;
        }
        #endregion

        public static int SendMailHTML(string sUserID, string sAlertID, List<MaillReceptioner> sMailTo, ArrayList sFilePaths, string Subject, string Body)
        {
            EmailStatus enmStatus = (int)EmailStatus.newMail;

            tbl_utlEmailConfig oAlertConfig = tbl_utlEmailConfig.Select("admin");
            if (oAlertConfig != null)
            {
                try
                {
                    if (sMailTo.Count > 0)
                    {
                        MailAddress From = new MailAddress(oAlertConfig.EmailAddress, "SEACC Alert System");
                        MailMessage message = new MailMessage();
                        message.From = From;
                        message.Subject = Subject;
                        message.IsBodyHtml = true;

                        #region Reciver
                        foreach (MaillReceptioner ToAdd in sMailTo)
                        {
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
                        smtp.Host = oAlertConfig.SmtpClient;
                        smtp.Port = oAlertConfig.SmtpPort;
                        smtp.EnableSsl = true;

                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(From.Address, clsSecurity.decryptPassword(oAlertConfig.EmailPassword));
                        //  smtp
                        foreach (String sFilpath in sFilePaths)
                        {
                            Attachment att = new Attachment(sFilpath);
                            message.Attachments.Add(att);
                        }

                        smtp.Send(message);
                        enmStatus = EmailStatus.sentMail;
                        clsValidate.WriteErrorLog("Mail Sent For :" + sAlertID, -1, null);
                    }
                    else
                    {
                        clsValidate.WriteErrorLog("Alert Sending - Error - recipients not found   - " + sAlertID, -1, null);
                        enmStatus = EmailStatus.Error_Reception;
                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("Alert Sending - Error " +  " - " + sAlertID, -1,ex);
                    enmStatus = EmailStatus.Error;
                }
            }
            return (int)enmStatus;
        }
    }
}