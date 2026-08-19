namespace Digiteq
{
    partial class frmDatabaseBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseBackup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar_Sub = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar_Master = new System.Windows.Forms.ProgressBar();
            this.txtServerBackupPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSourceFolders1 = new System.Windows.Forms.TextBox();
            this.txtSourceFolders2 = new System.Windows.Forms.TextBox();
            this.txtSourceFolders3 = new System.Windows.Forms.TextBox();
            this.txtBackupPrefix = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSvrBackPath = new System.Windows.Forms.Button();
            this.btnFolder1 = new System.Windows.Forms.Button();
            this.btnFolder2 = new System.Windows.Forms.Button();
            this.btnFolder3 = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.dgvHistory = new SEACC_DataGrid();
            this.backupDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSettings1 = new System.Windows.Forms.Button();
            this.rdoFull = new System.Windows.Forms.RadioButton();
            this.rdoDB = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTargetPath.Location = new System.Drawing.Point(112, 36);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(351, 22);
            this.txtTargetPath.TabIndex = 446;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(19, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 445;
            this.label3.Text = "Target Location";
            // 
            // progressBar_Sub
            // 
            this.progressBar_Sub.Location = new System.Drawing.Point(22, 76);
            this.progressBar_Sub.Name = "progressBar_Sub";
            this.progressBar_Sub.Size = new System.Drawing.Size(294, 10);
            this.progressBar_Sub.TabIndex = 482;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar_Master
            // 
            this.progressBar_Master.Location = new System.Drawing.Point(22, 66);
            this.progressBar_Master.Maximum = 11;
            this.progressBar_Master.Name = "progressBar_Master";
            this.progressBar_Master.Size = new System.Drawing.Size(293, 10);
            this.progressBar_Master.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_Master.TabIndex = 482;
            // 
            // txtServerBackupPath
            // 
            this.txtServerBackupPath.AcceptsReturn = true;
            this.txtServerBackupPath.Location = new System.Drawing.Point(523, 46);
            this.txtServerBackupPath.Name = "txtServerBackupPath";
            this.txtServerBackupPath.Size = new System.Drawing.Size(250, 22);
            this.txtServerBackupPath.TabIndex = 483;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label8.Location = new System.Drawing.Point(511, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 14);
            this.label8.TabIndex = 445;
            this.label8.Text = "Server Backup Path";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(511, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 14);
            this.label9.TabIndex = 445;
            this.label9.Text = "Folders to be backup";
            // 
            // txtSourceFolders1
            // 
            this.txtSourceFolders1.Location = new System.Drawing.Point(523, 86);
            this.txtSourceFolders1.Name = "txtSourceFolders1";
            this.txtSourceFolders1.Size = new System.Drawing.Size(250, 22);
            this.txtSourceFolders1.TabIndex = 483;
            // 
            // txtSourceFolders2
            // 
            this.txtSourceFolders2.Location = new System.Drawing.Point(523, 110);
            this.txtSourceFolders2.Name = "txtSourceFolders2";
            this.txtSourceFolders2.Size = new System.Drawing.Size(250, 22);
            this.txtSourceFolders2.TabIndex = 483;
            // 
            // txtSourceFolders3
            // 
            this.txtSourceFolders3.Location = new System.Drawing.Point(523, 134);
            this.txtSourceFolders3.Name = "txtSourceFolders3";
            this.txtSourceFolders3.Size = new System.Drawing.Size(250, 22);
            this.txtSourceFolders3.TabIndex = 483;
            // 
            // txtBackupPrefix
            // 
            this.txtBackupPrefix.Location = new System.Drawing.Point(523, 174);
            this.txtBackupPrefix.Name = "txtBackupPrefix";
            this.txtBackupPrefix.Size = new System.Drawing.Size(267, 22);
            this.txtBackupPrefix.TabIndex = 483;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label10.Location = new System.Drawing.Point(511, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 14);
            this.label10.TabIndex = 484;
            this.label10.Text = "Backup Name PreFix";
            // 
            // btnSvrBackPath
            // 
            this.btnSvrBackPath.BackColor = System.Drawing.Color.White;
            this.btnSvrBackPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSvrBackPath.BackgroundImage")));
            this.btnSvrBackPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSvrBackPath.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSvrBackPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSvrBackPath.Location = new System.Drawing.Point(773, 47);
            this.btnSvrBackPath.Name = "btnSvrBackPath";
            this.btnSvrBackPath.Size = new System.Drawing.Size(20, 19);
            this.btnSvrBackPath.TabIndex = 485;
            this.btnSvrBackPath.UseVisualStyleBackColor = false;
            this.btnSvrBackPath.Click += new System.EventHandler(this.btnSvrBackPath_Click);
            // 
            // btnFolder1
            // 
            this.btnFolder1.BackColor = System.Drawing.Color.White;
            this.btnFolder1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFolder1.BackgroundImage")));
            this.btnFolder1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFolder1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnFolder1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder1.Location = new System.Drawing.Point(773, 87);
            this.btnFolder1.Name = "btnFolder1";
            this.btnFolder1.Size = new System.Drawing.Size(20, 20);
            this.btnFolder1.TabIndex = 486;
            this.btnFolder1.UseVisualStyleBackColor = false;
            this.btnFolder1.Click += new System.EventHandler(this.btnFolder1_Click);
            // 
            // btnFolder2
            // 
            this.btnFolder2.BackColor = System.Drawing.Color.White;
            this.btnFolder2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFolder2.BackgroundImage")));
            this.btnFolder2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFolder2.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnFolder2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder2.Location = new System.Drawing.Point(773, 111);
            this.btnFolder2.Name = "btnFolder2";
            this.btnFolder2.Size = new System.Drawing.Size(20, 20);
            this.btnFolder2.TabIndex = 487;
            this.btnFolder2.UseVisualStyleBackColor = false;
            this.btnFolder2.Click += new System.EventHandler(this.btnFolder2_Click);
            // 
            // btnFolder3
            // 
            this.btnFolder3.BackColor = System.Drawing.Color.White;
            this.btnFolder3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFolder3.BackgroundImage")));
            this.btnFolder3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFolder3.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnFolder3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder3.Location = new System.Drawing.Point(773, 135);
            this.btnFolder3.Name = "btnFolder3";
            this.btnFolder3.Size = new System.Drawing.Size(20, 20);
            this.btnFolder3.TabIndex = 488;
            this.btnFolder3.UseVisualStyleBackColor = false;
            this.btnFolder3.Click += new System.EventHandler(this.btnFolder3_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.LightGray;
            this.btnSaveSettings.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSaveSettings.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaveSettings.Location = new System.Drawing.Point(523, 205);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 489;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(323, 64);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 478;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.BackgroundImage = global::Digiteq.Properties.Resources.Folder;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(459, 36);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(20, 22);
            this.btnBrowse.TabIndex = 447;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnSetLocation2_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.LightGray;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Image = global::Digiteq.Properties.Resources.accept;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(404, 64);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 25);
            this.btnBackup.TabIndex = 427;
            this.btnBackup.Text = "   Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeColumns = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.ColumnHeadersVisible = false;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.backupDateTime,
            this.user_ID});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.GridColor = System.Drawing.Color.Gray;
            this.dgvHistory.Location = new System.Drawing.Point(22, 125);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(284, 123);
            this.dgvHistory.TabIndex = 490;
            // 
            // backupDateTime
            // 
            this.backupDateTime.DataPropertyName = "backupDateTime";
            this.backupDateTime.FillWeight = 105.6338F;
            this.backupDateTime.HeaderText = "backupDateTime";
            this.backupDateTime.Name = "backupDateTime";
            this.backupDateTime.ReadOnly = true;
            this.backupDateTime.Width = 150;
            // 
            // user_ID
            // 
            this.user_ID.DataPropertyName = "user_ID";
            this.user_ID.FillWeight = 94.36619F;
            this.user_ID.HeaderText = "user_ID";
            this.user_ID.Name = "user_ID";
            this.user_ID.ReadOnly = true;
            this.user_ID.Width = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 17);
            this.label1.TabIndex = 491;
            this.label1.Text = "Backup History (Top 5 Backups)";
            // 
            // btnSettings
            // 
            this.btnSettings1.BackColor = System.Drawing.Color.White;
            this.btnSettings1.BackgroundImage = global::Digiteq.Properties.Resources.Option;
            this.btnSettings1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSettings1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings1.Location = new System.Drawing.Point(459, 229);
            this.btnSettings1.Name = "btnSettings";
            this.btnSettings1.Size = new System.Drawing.Size(20, 22);
            this.btnSettings1.TabIndex = 447;
            this.btnSettings1.UseVisualStyleBackColor = false;
            this.btnSettings1.ClientSizeChanged += new System.EventHandler(this.btnSettings_ClientSizeChanged);
            this.btnSettings1.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // rdoFull
            // 
            this.rdoFull.AutoSize = true;
            this.rdoFull.Checked = true;
            this.rdoFull.Location = new System.Drawing.Point(335, 125);
            this.rdoFull.Name = "rdoFull";
            this.rdoFull.Size = new System.Drawing.Size(44, 17);
            this.rdoFull.TabIndex = 492;
            this.rdoFull.TabStop = true;
            this.rdoFull.Text = "Full";
            this.rdoFull.UseVisualStyleBackColor = true;
            // 
            // rdoDB
            // 
            this.rdoDB.AutoSize = true;
            this.rdoDB.Location = new System.Drawing.Point(335, 148);
            this.rdoDB.Name = "rdoDB";
            this.rdoDB.Size = new System.Drawing.Size(100, 17);
            this.rdoDB.TabIndex = 493;
            this.rdoDB.Text = "Database Only";
            this.rdoDB.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(320, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 445;
            this.label2.Text = "Backup Type";
            // 
            // frmDatabaseBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 262);
            this.Controls.Add(this.rdoDB);
            this.Controls.Add(this.rdoFull);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.btnFolder3);
            this.Controls.Add(this.btnFolder2);
            this.Controls.Add(this.btnFolder1);
            this.Controls.Add(this.btnSvrBackPath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBackupPrefix);
            this.Controls.Add(this.txtSourceFolders3);
            this.Controls.Add(this.txtSourceFolders2);
            this.Controls.Add(this.txtSourceFolders1);
            this.Controls.Add(this.txtServerBackupPath);
            this.Controls.Add(this.progressBar_Master);
            this.Controls.Add(this.progressBar_Sub);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSettings1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.txtTargetPath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmDatabaseBackup";
            this.Text = "System Backup";
            this.Load += new System.EventHandler(this.frmDatabaseBackup_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtTargetPath, 0);
            this.Controls.SetChildIndex(this.btnBackup, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.btnSettings1, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.progressBar_Sub, 0);
            this.Controls.SetChildIndex(this.progressBar_Master, 0);
            this.Controls.SetChildIndex(this.txtServerBackupPath, 0);
            this.Controls.SetChildIndex(this.txtSourceFolders1, 0);
            this.Controls.SetChildIndex(this.txtSourceFolders2, 0);
            this.Controls.SetChildIndex(this.txtSourceFolders3, 0);
            this.Controls.SetChildIndex(this.txtBackupPrefix, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.btnSvrBackPath, 0);
            this.Controls.SetChildIndex(this.btnFolder1, 0);
            this.Controls.SetChildIndex(this.btnFolder2, 0);
            this.Controls.SetChildIndex(this.btnFolder3, 0);
            this.Controls.SetChildIndex(this.btnSaveSettings, 0);
            this.Controls.SetChildIndex(this.dgvHistory, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rdoFull, 0);
            this.Controls.SetChildIndex(this.rdoDB, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar progressBar_Sub;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar_Master;
        private System.Windows.Forms.TextBox txtServerBackupPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSourceFolders1;
        private System.Windows.Forms.TextBox txtSourceFolders2;
        private System.Windows.Forms.TextBox txtSourceFolders3;
        private System.Windows.Forms.TextBox txtBackupPrefix;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSvrBackPath;
        private System.Windows.Forms.Button btnFolder1;
        private System.Windows.Forms.Button btnFolder2;
        private System.Windows.Forms.Button btnFolder3;
        private System.Windows.Forms.Button btnSaveSettings;
        private SEACC_DataGrid dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn backupDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettings1;
        public System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.RadioButton rdoFull;
        private System.Windows.Forms.RadioButton rdoDB;
        private System.Windows.Forms.Label label2;
    }
}