using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;
using DataTire;
using System.Threading;
using System.IO;
using Digiteq_Logic;
using Ionic.Zip;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Digiteq
{
    public partial class frmDatabaseBackup : MettroForm
    {
        bool bShowFileWicePresentage = false;
        StringBuilder sb = new StringBuilder();
        public bool bNoAccess;
        public int iFormID;

        #region FormLoad
        public frmDatabaseBackup()
        {
            iFormID = clsSecurity.getFormID(Digiteq_Logic.FormName.DatabaseBackup);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }

            InitializeComponent();
        }

        private void frmDatabaseBackup_Load(object sender, EventArgs e)
        {
            txtServerBackupPath.Text = clsConfig.sSeaccBackupPath_Server;
            txtBackupPrefix.Text = clsConfig.sSeaccBackupPreFix;
            txtSourceFolders1.Text = clsConfig.sSeaccBackup_SourceFolder_1;
            txtSourceFolders2.Text = clsConfig.sSeaccBackup_SourceFolder_2;
            txtSourceFolders3.Text = clsConfig.sSeaccBackup_SourceFolder_3;

            btnClear_Click(null, null);
        }
        #endregion

        #region Btn Browse
        private void btnSetLocation2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtTargetPath.Text = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
            }
        }
        #endregion

        void progressbar1Update(string messege)
        {
            progressBar_Master.Value = progressBar_Master.Value + 1;
        }

        #region Btn Backup
        private void btnBackup_Click(object sender, EventArgs e)
        {
            bool bIsBackupOk = false;
            sb.Clear();
            sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program stated");
            try
            {
                bool isConfigarationOk = true;
                bShowFileWicePresentage = false;
                string sError = "";

                #region Check Backup Path Validity
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
                //if (clsConfig.sSeaccBackupPath_Server != "")
                //{
                //    double dSize = clsCommon.GetFileSizeOnDisk(clsConfig.sSeaccBackupPath_Server);
                //    if (dSize < 2d)
                //    {
                //        isConfigarationOk = false;
                //        sError = "Backup Folder Capacity is Minimum '2GB'";
                //        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                //    }
                //}

                if (!isConfigarationOk)
                    MessageBox.Show(sError);

                #endregion

                #region Start backup Process
                if (isConfigarationOk)
                {
                    if (txtTargetPath.TextLength > 0)
                    {
                        progressBar_Master.Value = 1;
                        DateTime dtm_BackupStartTime = DateTime.Now;

                        #region Set All path to Variables
                        string sTempDirectryPath = clsConfig.sSeaccBackupPath_Server + "\\Temp_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm");
                        string DatabaseBackupPath = sTempDirectryPath + "\\db_" + clsSecurity.Database + "_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SDB";
                        string SourceFolder_1_BackupPath = sTempDirectryPath + "\\SourceFolder_1_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string SourceFolder_2_BackupPath = sTempDirectryPath + "\\SourceFolder_2_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string SourceFolder_3_BackupPath = sTempDirectryPath + "\\SourceFolder_3_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string sFinalBackupFolderPath = clsConfig.sSeaccBackupPath_Server + "\\SEACC_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        #endregion

                        Directory.CreateDirectory(sTempDirectryPath);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Temporary directory created - " + sTempDirectryPath);

                        #region Back up Database
                        SqlConnection scon = DBHandling.GetConnection();
                        SqlCommand command = new SqlCommand("BACKUP DATABASE " + clsSecurity.Database + @" TO  DISK = N'" + DatabaseBackupPath + "' WITH NOFORMAT, NOINIT,  SKIP,  NOREWIND, NOUNLOAD,  STATS = 5", scon);
                        command.CommandType = CommandType.Text;
                        command.CommandTimeout = 8000;
                        scon.Open();

                        progressBar_Master.Value = 2;

                        scon.InfoMessage += scon_InfoMessage;
                        SqlDataReader dr = command.ExecuteReader();

                        scon.Close();
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Database backed up successfully");
                        #endregion

                        progressBar_Master.Value = 3;
                        progressBar_Sub.Value = 0;

                        #region Full Backup
                        if (!rdoDB.Checked)
                        {
                            if (clsConfig.sSeaccBackup_SourceFolder_1 != "")
                            {
                                ArchiveDirectory(clsConfig.sSeaccBackup_SourceFolder_1, SourceFolder_1_BackupPath);
                                sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - " + clsConfig.sSeaccBackup_SourceFolder_1);
                            }

                            progressBar_Master.Value = 4;
                            progressBar_Sub.Value = 0;
                            if (clsConfig.sSeaccBackup_SourceFolder_2 != "")
                            {
                                ArchiveDirectory(clsConfig.sSeaccBackup_SourceFolder_2, SourceFolder_2_BackupPath);
                                sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - " + clsConfig.sSeaccBackup_SourceFolder_2);
                            }

                            progressBar_Master.Value = 5;
                            progressBar_Sub.Value = 0;
                            if (clsConfig.sSeaccBackup_SourceFolder_3 != "")
                            {
                                ArchiveDirectory(clsConfig.sSeaccBackup_SourceFolder_3, SourceFolder_3_BackupPath);
                                sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - " + clsConfig.sSeaccBackup_SourceFolder_3);
                            }

                            progressBar_Master.Value = 6;

                            bShowFileWicePresentage = true;
                            progressBar_Sub.Value = 0;
                            ArchiveDirectory(sTempDirectryPath, sFinalBackupFolderPath);
                            sb.AppendLine(clsSecurity.getServerDateTime() + " - Folders Compressed");
                        }
                        #endregion

                        progressBar_Master.Value = 7;

                        #region Delete Source Folder n Backups Folders
                        //delete db backup
                        File.Delete(DatabaseBackupPath);
                        progressBar_Master.Value = 8;

                        //delete SourceFolder_1 backup 
                        try { File.Delete(SourceFolder_1_BackupPath); }
                        catch (Exception) { }
                        try { File.Delete(SourceFolder_2_BackupPath); }
                        catch (Exception) { }
                        try { File.Delete(SourceFolder_3_BackupPath); }
                        catch (Exception) { }
                        progressBar_Master.Value = 9;

                        //delete temp folder
                        Directory.Delete(sTempDirectryPath);
                        #endregion

                        progressBar_Master.Value = 10;

                        #region Copy File to Target Folder
                        File.Copy(sFinalBackupFolderPath, txtTargetPath.Text + "\\" + clsConfig.sSeaccBackupPreFix + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");
                        progressBar_Master.Value = 11;
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Copy to local - " + txtTargetPath.Text + "\\" + clsConfig.sSeaccBackupPreFix + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");
                        #endregion

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
                #endregion
            }
            catch (Exception ex)
            {
                sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program stoped - " + ex.Message);
                SEACCException.Show(ex);
            }
            finally
            {
                tbl_audBackupLog oBackup = new tbl_audBackupLog(clsSecurity.getServerDateTime(), 1, bIsBackupOk, clsSecurity.UserIDLoged, clsSecurity.TerminalID, sb.ToString());
                oBackup.Insert();

                progressBar_Master.Value = 0;
                progressBar_Sub.Value = 0;
            }
        }
        #endregion

        


        void zip_SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                // MessageBox.Show("Begin Saving: " + e.ArchiveName);
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                if (!bShowFileWicePresentage)
                {
                    progressBar_Sub.Maximum = e.EntriesTotal;
                    progressBar_Sub.Value = e.EntriesSaved + 1;
                }
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                if (bShowFileWicePresentage)
                {
                    progressBar_Sub.Maximum = 100;
                    progressBar_Sub.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
                }
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                //    MessageBox.Show("Done: " + e.ArchiveName);
            }
        }


        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTargetPath.Clear();
            dgvHistory.DataSource = tbl_audBackupLog.SelectAll_DataTable();
        }
        #endregion

        #region BackupMethods
        void ArchiveDirectory(string DirectryPath, string ZipFileName)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "d1g1t3q@123@456";
                zip.AddDirectory(DirectryPath);
                zip.SaveProgress += zip_SaveProgress;
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                zip.Save(ZipFileName);
            }
        }

        void scon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            sb.AppendLine(clsSecurity.getServerDateTime() + " - " + e.Message);
            int iPresentage = 0;
            if (e.Message.Contains(" percent processed."))
            {
                iPresentage = int.Parse(e.Message.Replace(" percent processed.", ""));
                progressBar_Sub.Value = iPresentage;
            }
        }
        #endregion

        int iTimeCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar_Sub.Value = 100 + (iTimeCount * 2);
        }

        private void btnSvrBackPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtServerBackupPath.Text = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
            }
        }

        private void btnFolder1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSourceFolders1.Text = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
            }
        }

        private void btnFolder2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSourceFolders2.Text = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
            }
        }

        private void btnFolder3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSourceFolders3.Text = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            clsConfig.sSeaccBackupPath_Server = txtServerBackupPath.Text;
            clsConfig.sSeaccBackupPreFix = txtBackupPrefix.Text;
            clsConfig.sSeaccBackup_SourceFolder_1 = txtSourceFolders1.Text;
            clsConfig.sSeaccBackup_SourceFolder_2 = txtSourceFolders2.Text;
            clsConfig.sSeaccBackup_SourceFolder_3 = txtSourceFolders3.Text;

            foreach (tbl_securityConfigValue oConfig in tbl_securityConfigValue.SelectAllByConfigTypeValue_ID("CTV/001"))
            {
                switch (oConfig.ValueID)
                {
                    case 100:
                        oConfig.ConfigValue = clsConfig.sSeaccBackupPath_Server;
                        oConfig.Update();
                        break;
                    case 101:
                        oConfig.ConfigValue = clsConfig.sSeaccBackupPreFix;
                        oConfig.Update();
                        break;
                    case 102:
                        oConfig.ConfigValue = clsConfig.sSeaccBackup_SourceFolder_1;
                        oConfig.Update();
                        break;
                    case 103:
                        oConfig.ConfigValue = clsConfig.sSeaccBackup_SourceFolder_2;
                        oConfig.Update();
                        break;
                    case 104:
                        oConfig.ConfigValue = clsConfig.sSeaccBackup_SourceFolder_3;
                        oConfig.Update();
                        break;
                }
            }

            MessageBox.Show("Settings saved succesfully");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (clsSecurity.UserIDLoged == "digiteq")
            {
                if (this.Width == 825)
                    this.Width = 490;
                else
                    this.Width = 825;
            }
        }
    }
}