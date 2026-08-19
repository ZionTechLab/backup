using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Input;
using Ionic.Zip;
using System.IO;
using System.Data;

namespace SEACC_servii.User_Management_Forms
{
    /// <summary>
    /// Interaction logic for UC_SystemBackup.xaml
    /// </summary>
    /// 

    public partial class UC_SystemBackup : UserControl
    {
        #region Class Varibles
        bool bShowFileWicePresentage = false;
        StringBuilder sb = new StringBuilder();
        #endregion

        #region Form Load
        public UC_SystemBackup()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.SystemBackup;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("backup_Index", typeof(int));
            dgr_Main.dt.Columns.Add("backupDateTime", typeof(DateTime));
            dgr_Main.dt.Columns.Add("backupType", typeof(int));
            dgr_Main.dt.Columns.Add("isBackupSuccessfull");
            dgr_Main.dt.Columns.Add("user_ID");
            dgr_Main.dt.Columns.Add("terminal_ID");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Index", "backup_Index", 50, true, true);
            dgr_Main.Add_DatagridColoumn("Date Time", "backupDateTime", 150);
            dgr_Main.Add_DatagridColoumn("Type", "backupType", 50, false);
            dgr_Main.Add_DatagridColoumn("Status", "isBackupSuccessfull", 80);
            dgr_Main.Add_DatagridColoumn("Terminal", "terminal_ID", 150, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness

        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }

        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            clsConfig.sSERVII_BackupPath_Server = txtServerBackupPath.Text;
            clsConfig.sSERVII_Backup_SourceFolder_1 = txtFoldersTobeBackup1.Text;
            clsConfig.sSERVII_Backup_SourceFolder_2 = txtFoldersTobeBackup2.Text;
            clsConfig.sSERVII_Backup_SourceFolder_3 = txtFoldersTobeBackup3.Text;
            clsConfig.sSERVII_BackupPreFix = txtBackupNamePrefix.Text;

            foreach (tbl_securityConfigValue oConfig in tbl_securityConfigValue.SelectAllByConfigTypeValue_ID("CTV/001"))
            {
                switch (oConfig.ValueID)
                {
                    case 200:
                        oConfig.ConfigValue = clsConfig.sSERVII_BackupPath_Server;
                        oConfig.Update();
                        break;
                    case 201:
                        oConfig.ConfigValue = clsConfig.sSERVII_Backup_SourceFolder_1;
                        oConfig.Update();
                        break;
                    case 202:
                        oConfig.ConfigValue = clsConfig.sSERVII_Backup_SourceFolder_2;
                        oConfig.Update();
                        break;
                    case 203:
                        oConfig.ConfigValue = clsConfig.sSERVII_Backup_SourceFolder_3;
                        oConfig.Update();
                        break;
                    case 204:
                        oConfig.ConfigValue = clsConfig.sSERVII_BackupPreFix;
                        oConfig.Update();
                        break;
                }
            }
            SEACCMessageBox.Show("Settings saved succesfully", "");
        }

        private void btnBackup_Click(object sender, RoutedEventArgs e)
        {
            bool bIsBackupOk = false;
            sb.Clear();
            frm_WaitingMessege FrmWaiting = new frm_WaitingMessege();
            Cursor = System.Windows.Input.Cursors.Wait;
            sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program stated");
            try
            {
                bool isConfigarationOk = true;
                bShowFileWicePresentage = false;
                string sError = "";

                #region Check Backup Parth Validity

                if (clsConfig.sSERVII_BackupPath_Server == "")
                {
                    isConfigarationOk = false;
                    sError = "Invalied Backup Path...";
                    sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                }
                else
                {
                    if (!Directory.Exists(clsConfig.sSERVII_BackupPath_Server))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Backup Path...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (clsConfig.sSERVII_Backup_SourceFolder_1 != "")
                {
                    if (!Directory.Exists(clsConfig.sSERVII_Backup_SourceFolder_1))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Source Directry Path 1...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (clsConfig.sSERVII_Backup_SourceFolder_2 != "")
                {
                    if (!Directory.Exists(clsConfig.sSERVII_Backup_SourceFolder_2))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Source Directry Path 2...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (clsConfig.sSERVII_Backup_SourceFolder_3 != "")
                {
                    if (!Directory.Exists(clsConfig.sSERVII_Backup_SourceFolder_3))
                    {
                        isConfigarationOk = false;
                        sError = "Invalied Source Directry Path 3...";
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - " + sError);
                    }
                }

                if (!isConfigarationOk)
                    SEACCMessageBox.Show(sError, "", MessageBoxButton.OK);

                #endregion

                if (isConfigarationOk)
                {
                    if (txtTargetLocation.Text.Length > 0)
                    {

                        //progressBar_Master.Value = 1;
                        DateTime dtm_BackupStartTime = DateTime.Now;
                        string sTempDirectryPath = clsConfig.sSERVII_BackupPath_Server + "\\Temp_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm");
                        string DatabaseBackupPath = sTempDirectryPath + "\\db_" + clsSecurity.DB_Database + "_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SDB";
                        string SourceFolder_1_BackupPath = sTempDirectryPath + "\\SourceFolder_1_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string SourceFolder_2_BackupPath = sTempDirectryPath + "\\SourceFolder_2_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string SourceFolder_3_BackupPath = sTempDirectryPath + "\\SourceFolder_3_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";
                        string sFinalBackupFolderPath = clsConfig.sSERVII_BackupPath_Server + "\\SEACC_" + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".SFB";

                        Directory.CreateDirectory(sTempDirectryPath);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Temporary directory created - " + sTempDirectryPath);

                        #region Back up Database
                        SqlConnection scon = DBHandling.GetConnection();
                        SqlCommand command = new SqlCommand("BACKUP DATABASE " + clsSecurity.DB_Database + @" TO  DISK = N'" + DatabaseBackupPath + "' WITH NOFORMAT, NOINIT,  SKIP,  NOREWIND, NOUNLOAD,  STATS = 5", scon);
                        command.CommandType = CommandType.Text;
                        command.CommandTimeout = 8000;
                        scon.Open();

                        //progressBar_Master.Value = 2;
                        scon.InfoMessage += scon_InfoMessage;
                        SqlDataReader dr = command.ExecuteReader();

                        scon.Close();
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Database backed up successfully");
                        #endregion

                        //progressBar_Master.Value = 3;
                        //progressBar_Sub.Value = 0;
                        if (clsConfig.sSERVII_Backup_SourceFolder_1 != "")
                        {
                            ArchiveDirectory(clsConfig.sSERVII_Backup_SourceFolder_1, SourceFolder_1_BackupPath);
                            sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - ");
                        }

                        //progressBar_Master.Value = 4;
                        //progressBar_Sub.Value = 0;
                        if (clsConfig.sSERVII_Backup_SourceFolder_2 != "")
                        {
                            ArchiveDirectory(clsConfig.sSERVII_Backup_SourceFolder_2, SourceFolder_2_BackupPath);
                            sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - ");
                        }

                        //progressBar_Master.Value = 5;
                        //progressBar_Sub.Value = 0;
                        if (clsConfig.sSERVII_Backup_SourceFolder_3 != "")
                        {
                            ArchiveDirectory(clsConfig.sSERVII_Backup_SourceFolder_3, SourceFolder_3_BackupPath);
                            sb.AppendLine(clsSecurity.getServerDateTime() + " - Source Folder Backed up Successfully - ");
                        }

                        //progressBar_Master.Value = 6;

                        bShowFileWicePresentage = true;
                        //progressBar_Sub.Value = 0;
                        ArchiveDirectory(sTempDirectryPath, sFinalBackupFolderPath);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Folders Compressed");

                        //progressBar_Master.Value = 7;

                        //delete db backup
                        File.Delete(DatabaseBackupPath);
                        //progressBar_Master.Value = 8;

                        //delete SourceFolder_1 backup 
                        try { File.Delete(SourceFolder_1_BackupPath); }
                        catch (Exception) { }
                        try { File.Delete(SourceFolder_2_BackupPath); }
                        catch (Exception) { }
                        try { File.Delete(SourceFolder_3_BackupPath); }
                        catch (Exception) { }
                        //progressBar_Master.Value = 9;

                        //delete temp folder
                        Directory.Delete(sTempDirectryPath);

                        //progressBar_Master.Value = 10;
                        File.Copy(sFinalBackupFolderPath, txtTargetLocation.Text + "\\" + clsConfig.sSERVII_BackupPreFix + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");
                        //progressBar_Master.Value = 11;
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Copy to local - " + txtServerBackupPath.Text + "\\" + clsConfig.sSERVII_BackupPreFix + dtm_BackupStartTime.ToString("yyyy-MM-dd-HHmm") + ".Sea");
                        SEACCMessageBox.Show("Backup Successfull", "", MessageBoxButton.OK);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Successfull");
                        bIsBackupOk = true;
                    }
                    else
                    {
                        //System.Windows.MessageBox.Show("Please Select The Location for Backup File", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program Stoped - Backup lockation not set");
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine(clsSecurity.getServerDateTime() + " - Backup Program stoped - " + ex.Message);
                SEACCExeption.Show(ex);
            }
            finally
            {
                tbl_audBackupLog oBackup = new tbl_audBackupLog(clsSecurity.getServerDateTime(), 1, bIsBackupOk, clsSecurity.UserIDLoged, clsSecurity.TerminalID, sb.ToString());
                oBackup.Insert();
                FrmWaiting.Close();
                RefreshGrid();
                Cursor = System.Windows.Input.Cursors.Arrow;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtTargetLocation, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtServerBackupPath, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFoldersTobeBackup1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFoldersTobeBackup2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFoldersTobeBackup3, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBackupNamePrefix, true, false, false);

            txtServerBackupPath.Text = clsConfig.sSERVII_BackupPath_Server;
            txtFoldersTobeBackup1.Text = clsConfig.sSERVII_Backup_SourceFolder_1;
            txtFoldersTobeBackup2.Text = clsConfig.sSERVII_Backup_SourceFolder_2;
            txtFoldersTobeBackup3.Text = clsConfig.sSERVII_Backup_SourceFolder_3;
            txtBackupNamePrefix.Text = clsConfig.sSERVII_BackupPreFix;

            txtTargetLocation.Text = "-Double Click for set folder-";

            if (clsSecurity.UserIDLoged.ToLower() != "digiteq")
            {
                this.SEACC_Form.btn_Save.Visibility = Visibility.Collapsed;
                txtServerBackupPath.IsEnabled = false;
                txtFoldersTobeBackup1.IsEnabled = false;
                txtFoldersTobeBackup2.IsEnabled = false;
                txtFoldersTobeBackup3.IsEnabled = false;
                txtBackupNamePrefix.IsEnabled = false;
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_audBackupLog detail in tbl_audBackupLog.SelectAll().OrderByDescending(r => r.Backup_Index))
                {
                    dgr_Main.dt.Rows.Add(detail.Backup_Index, detail.BackupDateTime, detail.BackupType, detail.IsBackupSuccessfull ? "Successful" : "Fail", detail.User_ID, detail.Terminal_ID);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Backup Methods
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
                    //  progressBar_Sub.Maximum = e.EntriesTotal;
                    //  progressBar_Sub.Value = e.EntriesSaved + 1;
                }
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                if (bShowFileWicePresentage)
                {
                    //  progressBar_Sub.Maximum = 100;
                    //  progressBar_Sub.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
                }
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                //    MessageBox.Show("Done: " + e.ArchiveName);
            }
        }

        void scon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            sb.AppendLine(clsSecurity.getServerDateTime() + " - " + e.Message);
            int iPresentage = 0;
            if (e.Message.Contains(" percent processed."))
            {
                iPresentage = int.Parse(e.Message.Replace(" percent processed.", ""));
                // progressBar_Sub.Value = iPresentage;
            }
        }
        #endregion

        #region Other Help Methods
        public void SelectFolderPath(SEACC_LableTextBox txtFolderPath)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new  System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtFolderPath.Text = fbd.SelectedPath;
                Environment.SpecialFolder root = fbd.RootFolder;
            }
        }
        #endregion

        #region Text Box Events
        private void txtTargetLocation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectFolderPath(txtTargetLocation);
        }

        private void txtServerBackupPath_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectFolderPath(txtServerBackupPath);
        }

        private void txtFoldersTobeBackup1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectFolderPath(txtFoldersTobeBackup1);
        }

        private void txtFoldersTobeBackup2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectFolderPath(txtFoldersTobeBackup2);
        }

        private void txtFoldersTobeBackup3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectFolderPath(txtFoldersTobeBackup3);
        } 
        #endregion
    }
}
