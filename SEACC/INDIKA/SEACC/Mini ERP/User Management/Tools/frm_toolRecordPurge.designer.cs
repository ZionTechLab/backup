namespace Digiteq
{
    partial class frm_toolRecordPurge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_toolRecordPurge));
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpPurgeDate = new System.Windows.Forms.DateTimePicker();
            this.txtPurgeID = new System.Windows.Forms.TextBox();
            this.lblAlertID = new System.Windows.Forms.Label();
            this.lblAlertName = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.x2 = new System.Windows.Forms.Panel();
            this.txtTimeApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpTimeApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.txtDateApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpDateApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDatePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPreparedBy = new System.Windows.Forms.TextBox();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnChecking = new System.Windows.Forms.Button();
            this.txtTimeCheckedBy = new System.Windows.Forms.TextBox();
            this.dtpTimeCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.txtDateCheckedBy = new System.Windows.Forms.TextBox();
            this.dtpDateCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.txtCheckedBy = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btn_PurgeApprove = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.xpanel12 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBackUp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsPurged = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.x2.SuspendLayout();
            this.xpanel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.xpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel1.Controls.Add(this.txtRemark);
            this.xpanel1.Controls.Add(this.label8);
            this.xpanel1.Controls.Add(this.dtpPurgeDate);
            this.xpanel1.Controls.Add(this.txtPurgeID);
            this.xpanel1.Controls.Add(this.lblAlertID);
            this.xpanel1.Controls.Add(this.lblAlertName);
            this.xpanel1.Location = new System.Drawing.Point(8, 8);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(534, 70);
            this.xpanel1.TabIndex = 0;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(268, 8);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(257, 49);
            this.txtRemark.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label8.Location = new System.Drawing.Point(213, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Remark";
            // 
            // dtpPurgeDate
            // 
            this.dtpPurgeDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurgeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurgeDate.Location = new System.Drawing.Point(89, 37);
            this.dtpPurgeDate.Name = "dtpPurgeDate";
            this.dtpPurgeDate.Size = new System.Drawing.Size(105, 22);
            this.dtpPurgeDate.TabIndex = 7;
            // 
            // txtPurgeID
            // 
            this.txtPurgeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtPurgeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txtPurgeID.Location = new System.Drawing.Point(89, 9);
            this.txtPurgeID.Name = "txtPurgeID";
            this.txtPurgeID.Size = new System.Drawing.Size(105, 22);
            this.txtPurgeID.TabIndex = 5;
            this.txtPurgeID.DoubleClick += new System.EventHandler(this.txtAlertID_DoubleClick);
            this.txtPurgeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAlertID_KeyDown);
            // 
            // lblAlertID
            // 
            this.lblAlertID.AutoSize = true;
            this.lblAlertID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAlertID.Location = new System.Drawing.Point(10, 12);
            this.lblAlertID.Name = "lblAlertID";
            this.lblAlertID.Size = new System.Drawing.Size(62, 14);
            this.lblAlertID.TabIndex = 3;
            this.lblAlertID.Text = "Purge Code";
            // 
            // lblAlertName
            // 
            this.lblAlertName.AutoSize = true;
            this.lblAlertName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAlertName.Location = new System.Drawing.Point(9, 43);
            this.lblAlertName.Name = "lblAlertName";
            this.lblAlertName.Size = new System.Drawing.Size(62, 14);
            this.lblAlertName.TabIndex = 4;
            this.lblAlertName.Text = "Purge Date";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(388, 83);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(87, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.TransactionID,
            this.TransactionDate,
            this.TransactionName,
            this.IsBackUp,
            this.IsPurged,
            this.CustomerID});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 115);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(534, 188);
            this.dgvDetail.TabIndex = 7;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.x2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2.Controls.Add(this.txtTimeApprovedBy);
            this.x2.Controls.Add(this.dtpTimeApprovedBy);
            this.x2.Controls.Add(this.dtpTimePreparedBy);
            this.x2.Controls.Add(this.txtDateApprovedBy);
            this.x2.Controls.Add(this.dtpDateApprovedBy);
            this.x2.Controls.Add(this.label29);
            this.x2.Controls.Add(this.dtpDatePreparedBy);
            this.x2.Controls.Add(this.label25);
            this.x2.Controls.Add(this.txtPreparedBy);
            this.x2.Controls.Add(this.txtApprovedBy);
            this.x2.Controls.Add(this.label27);
            this.x2.Controls.Add(this.label28);
            this.x2.Location = new System.Drawing.Point(8, 309);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(534, 68);
            this.x2.TabIndex = 14;
            // 
            // txtTimeApprovedBy
            // 
            this.txtTimeApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeApprovedBy.Enabled = false;
            this.txtTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeApprovedBy.Location = new System.Drawing.Point(477, 37);
            this.txtTimeApprovedBy.Name = "txtTimeApprovedBy";
            this.txtTimeApprovedBy.Size = new System.Drawing.Size(48, 23);
            this.txtTimeApprovedBy.TabIndex = 15;
            // 
            // dtpTimeApprovedBy
            // 
            this.dtpTimeApprovedBy.Enabled = false;
            this.dtpTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeApprovedBy.Location = new System.Drawing.Point(477, 37);
            this.dtpTimeApprovedBy.Name = "dtpTimeApprovedBy";
            this.dtpTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeApprovedBy.TabIndex = 16;
            // 
            // dtpTimePreparedBy
            // 
            this.dtpTimePreparedBy.Enabled = false;
            this.dtpTimePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimePreparedBy.Location = new System.Drawing.Point(476, 9);
            this.dtpTimePreparedBy.Name = "dtpTimePreparedBy";
            this.dtpTimePreparedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimePreparedBy.TabIndex = 8;
            // 
            // txtDateApprovedBy
            // 
            this.txtDateApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApprovedBy.Enabled = false;
            this.txtDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateApprovedBy.Location = new System.Drawing.Point(389, 37);
            this.txtDateApprovedBy.Name = "txtDateApprovedBy";
            this.txtDateApprovedBy.Size = new System.Drawing.Size(82, 23);
            this.txtDateApprovedBy.TabIndex = 14;
            // 
            // dtpDateApprovedBy
            // 
            this.dtpDateApprovedBy.Enabled = false;
            this.dtpDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateApprovedBy.Location = new System.Drawing.Point(389, 37);
            this.dtpDateApprovedBy.Name = "dtpDateApprovedBy";
            this.dtpDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateApprovedBy.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Gray;
            this.label29.Location = new System.Drawing.Point(305, 41);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 14);
            this.label29.TabIndex = 13;
            this.label29.Text = "Approved Date";
            // 
            // dtpDatePreparedBy
            // 
            this.dtpDatePreparedBy.Enabled = false;
            this.dtpDatePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePreparedBy.Location = new System.Drawing.Point(388, 9);
            this.dtpDatePreparedBy.Name = "dtpDatePreparedBy";
            this.dtpDatePreparedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDatePreparedBy.TabIndex = 7;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Gray;
            this.label25.Location = new System.Drawing.Point(304, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 14);
            this.label25.TabIndex = 6;
            this.label25.Text = "Prepared Date";
            // 
            // txtPreparedBy
            // 
            this.txtPreparedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreparedBy.ForeColor = System.Drawing.Color.Gray;
            this.txtPreparedBy.Location = new System.Drawing.Point(89, 9);
            this.txtPreparedBy.Name = "txtPreparedBy";
            this.txtPreparedBy.ReadOnly = true;
            this.txtPreparedBy.Size = new System.Drawing.Size(200, 22);
            this.txtPreparedBy.TabIndex = 1;
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtApprovedBy.Enabled = false;
            this.txtApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedBy.Location = new System.Drawing.Point(89, 38);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(200, 22);
            this.txtApprovedBy.TabIndex = 5;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(9, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 14);
            this.label27.TabIndex = 0;
            this.label27.Text = "Prepared By";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Enabled = false;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Gray;
            this.label28.Location = new System.Drawing.Point(10, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 4;
            this.label28.Text = "Approved By";
            // 
            // btnChecking
            // 
            this.btnChecking.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChecking.Image = global::Digiteq.Properties.Resources.security;
            this.btnChecking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChecking.Location = new System.Drawing.Point(309, 207);
            this.btnChecking.Name = "btnChecking";
            this.btnChecking.Size = new System.Drawing.Size(22, 22);
            this.btnChecking.TabIndex = 480;
            this.btnChecking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChecking.UseVisualStyleBackColor = true;
            // 
            // txtTimeCheckedBy
            // 
            this.txtTimeCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeCheckedBy.Enabled = false;
            this.txtTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeCheckedBy.Location = new System.Drawing.Point(413, 208);
            this.txtTimeCheckedBy.Name = "txtTimeCheckedBy";
            this.txtTimeCheckedBy.Size = new System.Drawing.Size(48, 23);
            this.txtTimeCheckedBy.TabIndex = 11;
            // 
            // dtpTimeCheckedBy
            // 
            this.dtpTimeCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpTimeCheckedBy.Enabled = false;
            this.dtpTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeCheckedBy.Location = new System.Drawing.Point(413, 208);
            this.dtpTimeCheckedBy.Name = "dtpTimeCheckedBy";
            this.dtpTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeCheckedBy.TabIndex = 12;
            // 
            // txtDateCheckedBy
            // 
            this.txtDateCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateCheckedBy.Enabled = false;
            this.txtDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCheckedBy.Location = new System.Drawing.Point(435, 208);
            this.txtDateCheckedBy.Name = "txtDateCheckedBy";
            this.txtDateCheckedBy.Size = new System.Drawing.Size(82, 23);
            this.txtDateCheckedBy.TabIndex = 10;
            // 
            // dtpDateCheckedBy
            // 
            this.dtpDateCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpDateCheckedBy.Enabled = false;
            this.dtpDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateCheckedBy.Location = new System.Drawing.Point(435, 208);
            this.dtpDateCheckedBy.Name = "dtpDateCheckedBy";
            this.dtpDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateCheckedBy.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.Location = new System.Drawing.Point(351, 212);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 14);
            this.label26.TabIndex = 9;
            this.label26.Text = "Checked Date";
            // 
            // txtCheckedBy
            // 
            this.txtCheckedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckedBy.Location = new System.Drawing.Point(130, 208);
            this.txtCheckedBy.Name = "txtCheckedBy";
            this.txtCheckedBy.ReadOnly = true;
            this.txtCheckedBy.Size = new System.Drawing.Size(175, 22);
            this.txtCheckedBy.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label24.Location = new System.Drawing.Point(30, 203);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 14);
            this.label24.TabIndex = 2;
            this.label24.Text = "Checked By";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(467, 83);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 481;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btn_PurgeApprove
            // 
            this.btn_PurgeApprove.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PurgeApprove.Image = global::Digiteq.Properties.Resources.accept;
            this.btn_PurgeApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PurgeApprove.Location = new System.Drawing.Point(166, 83);
            this.btn_PurgeApprove.Name = "btn_PurgeApprove";
            this.btn_PurgeApprove.Size = new System.Drawing.Size(105, 25);
            this.btn_PurgeApprove.TabIndex = 482;
            this.btn_PurgeApprove.Text = "Purge Approve";
            this.btn_PurgeApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PurgeApprove.UseVisualStyleBackColor = true;
            this.btn_PurgeApprove.Click += new System.EventHandler(this.btn_PurgeApprove_Click);
            // 
            // btnFill
            // 
            this.btnFill.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFill.Image = global::Digiteq.Properties.Resources.accept;
            this.btnFill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFill.Location = new System.Drawing.Point(8, 83);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(77, 25);
            this.btnFill.TabIndex = 483;
            this.btnFill.Text = "Fill Data";
            this.btnFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // xpanel12
            // 
            this.xpanel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.xpanel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel12.Controls.Add(this.label3);
            this.xpanel12.Location = new System.Drawing.Point(8, 383);
            this.xpanel12.Name = "xpanel12";
            this.xpanel12.Size = new System.Drawing.Size(534, 60);
            this.xpanel12.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(515, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "Line No";
            this.LineNo.Name = "LineNo";
            this.LineNo.Width = 60;
            // 
            // TransactionID
            // 
            this.TransactionID.HeaderText = "Transation Code";
            this.TransactionID.Name = "TransactionID";
            // 
            // TransactionDate
            // 
            this.TransactionDate.HeaderText = "Transaction Date";
            this.TransactionDate.Name = "TransactionDate";
            // 
            // TransactionName
            // 
            this.TransactionName.HeaderText = "Transaction";
            this.TransactionName.Name = "TransactionName";
            this.TransactionName.Width = 148;
            // 
            // IsBackUp
            // 
            this.IsBackUp.HeaderText = "Backup";
            this.IsBackUp.Name = "IsBackUp";
            this.IsBackUp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsBackUp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsBackUp.Width = 60;
            // 
            // IsPurged
            // 
            this.IsPurged.HeaderText = "Purge";
            this.IsPurged.Name = "IsPurged";
            this.IsPurged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsPurged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsPurged.Width = 60;
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Visible = false;
            // 
            // frm_toolRecordPurge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(553, 452);
            this.Controls.Add(this.xpanel12);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.btn_PurgeApprove);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.btnChecking);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtTimeCheckedBy);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.xpanel1);
            this.Controls.Add(this.dtpTimeCheckedBy);
            this.Controls.Add(this.txtCheckedBy);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtDateCheckedBy);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.dtpDateCheckedBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_toolRecordPurge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Purge Tool";
            this.Load += new System.EventHandler(this.frmItemMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrAlert_KeyDown);
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.xpanel12.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel xpanel1;
        private System.Windows.Forms.Label lblAlertID;
        private System.Windows.Forms.Label lblAlertName;
        private System.Windows.Forms.TextBox txtPurgeID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DateTimePicker dtpPurgeDate;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.TextBox txtTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimePreparedBy;
        private System.Windows.Forms.TextBox txtDateApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpDateApprovedBy;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpDatePreparedBy;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtPreparedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnChecking;
        private System.Windows.Forms.TextBox txtTimeCheckedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeCheckedBy;
        private System.Windows.Forms.TextBox txtDateCheckedBy;
        private System.Windows.Forms.DateTimePicker dtpDateCheckedBy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCheckedBy;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btn_PurgeApprove;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Panel xpanel12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsBackUp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPurged;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
    }
}