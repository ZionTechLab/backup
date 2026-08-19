using System;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using Digiteq_Logic;
using System.Windows.Forms;
using DataTire;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace BackupService
{
    public partial class BackupService : ServiceBase
    {
        private Thread _thread;
        int iloopTime = 600000;
        DateTime dtmCurrentDate = DateTime.Now;

        public BackupService()
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
                    _thread = new Thread(DoWork);
                    _thread.Start();

                    WriteLog("SEACC Support Service Started");

                    bisThredStartOk = true;
                }

                if (!bisThredStartOk)
                {
                    WriteLog("SEACC Support Service Cannot be started");
                    this.Stop();
                }
            }
            catch (Exception ex)
            {
                WriteLog("Service Start Faild - " + ex.Message);
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
                    WriteLog("Thread Active");

                    foreach (tbl_utlBackup_Shedule oShedule in tbl_utlBackup_Shedule.SelectAll().Where(p => p.IsActive))
                    {
                        dtmCurrentDate = DateTime.Now;
                        bool value = false;

                        #region daily
                        if (oShedule.SheduleType == 1)
                        {
                            if (dtmCurrentDate.Date > oShedule.LastBackup_Time.Date && dtmCurrentDate.TimeOfDay >= oShedule.SheduledTime.TimeOfDay)   
                            {
                                value = true;
                                WriteLog("Found a Active daily Schedule - " + oShedule.Shedule_ID);
                            }
                        }
                        #endregion

                        #region monthly
                        else if (oShedule.SheduleType == 3)
                        {
                            if (oShedule.LastBackup_Time.Month != dtmCurrentDate.Month)
                            {
                                DateTime dtmSheduleTime = new DateTime(dtmCurrentDate.Year, dtmCurrentDate.Month, oShedule.SheduledTime.Day, oShedule.SheduledTime.Hour, oShedule.SheduledTime.Minute, 0);
                                if (dtmSheduleTime <= dtmCurrentDate)
                                {
                                    value = true;
                                    WriteLog("Found a Active Monthly Schedule - " + oShedule.Shedule_ID);
                                }
                            }
                        }
                        #endregion

                        if (value)
                        {
                            try
                            {
                                tbl_utlBackupSet oSet = tbl_utlBackupSet.Select(oShedule.BackUpSet_ID);
                                if (oSet != null)
                                {
                                    WriteLog("Backup validation started");
                                    bool isConfigarationOk = true;

                                    #region Check Backup Parth Validity
                                    #region target Path
                                    if (oSet.TargetPath == "")
                                    {
                                        isConfigarationOk = false;
                                        WriteLog("Backup validation error - Backup Path is null...");
                                    }
                                    else
                                    {
                                        if (!Directory.Exists(oSet.TargetPath))
                                        {
                                            isConfigarationOk = false;
                                            WriteLog("Backup validation error - " + "Invalied Backup Path...");
                                        }
                                    }
                                    #endregion

                                    #region Source File Paths
                                    if (oSet.FolderPath1 != "")
                                    {
                                        if (!Directory.Exists(oSet.FolderPath1))
                                        {
                                            isConfigarationOk = false;
                                            WriteLog("Backup validation error - " + "Invalied Source Directry Path 1...");
                                        }
                                    }

                                    if (oSet.FolderPath2 != "")
                                    {
                                        if (!Directory.Exists(oSet.FolderPath2))
                                        {
                                            isConfigarationOk = false;
                                            WriteLog("Backup validation error - " + "Invalied Source Directry Path 2...");
                                        }
                                    }

                                    if (oSet.FolderPath3 != "")
                                    {
                                        if (!Directory.Exists(oSet.FolderPath3))
                                        {
                                            isConfigarationOk = false;
                                            WriteLog("Backup validation error - " + "Invalied Source Directry Path 3...");
                                        }
                                    }
                                    #endregion
                                    #endregion

                                    if (isConfigarationOk)
                                    {
                                        WriteLog("Backup Started");

                                        DateTime dtm_BackupStartTime = DateTime.Now;

                                        string sTempDirectryPath = Application.StartupPath + "\\Temp_" + oSet.BackUpSet_Name + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm");

                                        WriteLog(sTempDirectryPath);

                                        string DatabaseBackupPath = sTempDirectryPath + "\\db_" + clsSecurity.Database + "_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SDB";
                                        string SourceFolder_1_BackupPath = sTempDirectryPath + "\\SourceFolder_1_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                                        string SourceFolder_2_BackupPath = sTempDirectryPath + "\\SourceFolder_2_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                                        string SourceFolder_3_BackupPath = sTempDirectryPath + "\\SourceFolder_3_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";

                                        string sFinalBackupFolderPath = Application.StartupPath + "\\Backups" + "\\SEACC_" + oSet.BackUpSet_Name + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";

                                        WriteLog(sFinalBackupFolderPath);


                                        if (!Directory.Exists(Application.StartupPath + "\\Backups"))
                                            Directory.CreateDirectory(Application.StartupPath + "\\Backups");

                                        Directory.CreateDirectory(sTempDirectryPath);

                                        WriteLog(clsSecurity.getServerDateTime() + " - Temporary directory created - " + sTempDirectryPath);

                                        #region Back up Database
                                        SqlConnection scon = DBHandling.GetConnection();
                                        SqlCommand command = new SqlCommand("BACKUP DATABASE " + oSet.Db + @" TO  DISK = N'" + DatabaseBackupPath + "' WITH NOFORMAT, NOINIT,  SKIP,  NOREWIND, NOUNLOAD,  STATS = 5", scon);
                                        command.CommandType = CommandType.Text;
                                        command.CommandTimeout = 8000;
                                        scon.Open();

                                        scon.InfoMessage += clsProcessMethods.scon_InfoMessage;
                                        SqlDataReader dr = command.ExecuteReader();

                                        scon.Close();
                                        WriteLog("db backed up successfully");
                                        #endregion

                                        #region Backup Folders
                                        if (oSet.FolderPath1 != "")
                                        {
                                            clsProcessMethods.ArchiveDirectory(oSet.FolderPath1, SourceFolder_1_BackupPath);
                                            WriteLog(" - Source Folder Backed up Successfully - " + oSet.FolderPath1);
                                        }

                                        if (oSet.FolderPath2 != "")
                                        {
                                            clsProcessMethods.ArchiveDirectory(oSet.FolderPath2, SourceFolder_2_BackupPath);
                                            WriteLog(" - Source Folder Backed up Successfully - " + oSet.FolderPath2);
                                        }

                                        if (oSet.FolderPath3 != "")
                                        {
                                            clsProcessMethods.ArchiveDirectory(oSet.FolderPath3, SourceFolder_3_BackupPath);
                                            WriteLog(" - Source Folder 3 Backed up Successfully - " + oSet.FolderPath3);
                                        }
                                        #endregion

                                        clsProcessMethods.ArchiveDirectory(sTempDirectryPath, sFinalBackupFolderPath);

                                        WriteLog("Folders Compressed to " + sFinalBackupFolderPath);

                                        File.Delete(DatabaseBackupPath);

                                        System.IO.DirectoryInfo di = new DirectoryInfo(sTempDirectryPath);

                                        foreach (FileInfo file in di.GetFiles())
                                        {
                                            file.Delete();
                                        }
                                        
                                        //try { File.Delete(SourceFolder_1_BackupPath); }
                                        //catch (Exception) { }
                                        //try { File.Delete(SourceFolder_2_BackupPath); }
                                        //catch (Exception) { }
                                        //try { File.Delete(SourceFolder_3_BackupPath); }
                                        //catch (Exception) { }

                                        Directory.Delete(sTempDirectryPath);
                                        File.Copy(sFinalBackupFolderPath, oSet.TargetPath + "\\" + oSet.BackUpSet_Name + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");

                                        WriteLog(clsSecurity.getServerDateTime() + " - Copy to local - " + oSet.TargetPath + "\\" + oSet.BackUpSet_Name + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");

                                        File.Delete(sFinalBackupFolderPath);

                                        oShedule.LastBackup_Time = dtm_BackupStartTime;
                                        oShedule.Update();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                WriteLog(" - Backup Program stoped - " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Alert Sending - Error " + ex.Message);
                }
                Thread.Sleep(iloopTime);
            }
            #endregion
        }

        protected override void OnStop()
        {
        }

        #region PassDB Information
        private bool PassDBInformation()
        {
            bool bValue = false;
            try
            {
                DBHandling.DBConnection = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                WriteLog("Connected to DB");
                bValue = true;
            }
            catch (Exception ex)
            {
                bValue = false;
                WriteLog("PassDBInfor-Error " + ex.Message);
            }
            return bValue;
        }
        #endregion


        #region Asign Common Values
        //private bool AsingOtherConfigValues()
        //{
        //    bool bValue = true;
        //    try
        //    {
        //        // clsBackProcess.AutoAssignConfigValue();
        //        //  clsBackProcess.AutoAssignConfigStatus();
        //        //  clsBackProcess.AutoAssignCompanyValue();

        //        WriteLog("Back process - Successful");
        //    }
        //    catch (Exception ex)
        //    {
        //        bValue = false;
        //        WriteLog("Back process-Error" + ex.Message);
        //    }
        //    return bValue;
        //}
        #endregion

        public static void WriteLog(string sError)
        {
            try
            {
                string logFileName = Path.Combine(Application.StartupPath, "Log.txt");
                File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError + Environment.NewLine + "-" + Environment.NewLine);
            }
            catch { }
        }
    }
}