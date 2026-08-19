using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Mail;
using SEACC_Alert_Engine;

using System.IO;
using System.Configuration;

namespace ZION.EmailService
{
    partial class SEACC : ServiceBase
    {
        private Thread _thread;
        int iloopTime = 1000 * 60 * 10;//10 minits

        public SEACC()
        {
            InitializeComponent();
        }
        public static void WriteErrorLog(string sError, int iformID, Exception ex)
        {
            try
            {
                string smsg = Environment.NewLine + DateTime.Now.ToString() + " - " + sError + " - " + iformID;

                if (ex != null)
                    smsg += Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + "-" + Environment.NewLine + Environment.NewLine;

                string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                File.AppendAllText(logFileName_Local, smsg);

                string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                File.AppendAllText(logFileName, smsg);
            }
            catch { }
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
                    _thread = new Thread(DoWork);
                    _thread.Start();

                    WriteErrorLog("Zion stock reconcilation Service Started", -1, null);

                    bisThredStartOk = true;
  
                }

                if (!bisThredStartOk)
                {
                    WriteErrorLog("Zion stock reconcilation Service Cannot be started", -1, null);
                    this.Stop();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("Service Start Faild - ", -1, ex);
                this.Stop();
            }
        }



        private void DoWork()
        {
            #region Saved Mail Send
            while (true)
            {
                try
                {
                    DBHandling.ExecQuery("EXEC SP_StoreStockReconciliation '" + DateTime.Now + "' , '" + "" + "', '" + "" + "'");
                }
                catch (Exception ex)
                {
                    WriteErrorLog("Error", -1, ex);
                }

                Thread.Sleep(iloopTime);
            }
            #endregion
        }

        protected override void OnStop()
        {
            WriteErrorLog("Service Stoped", -1, null);
        }

        #region PassDB Information
        private bool PassDBInformation()
        {
            bool bValue = false;
            try
            {
                DBHandling.DBConnection = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                WriteErrorLog("Connected to DB", -1, null);
                bValue = true;
            }
            catch (Exception ex)
            {
                bValue = false;
                WriteErrorLog("PassDBInfor-Error ", -1, ex);
            }
            return bValue;
        }
        #endregion
    }
}