namespace Digiteq
{
    partial class frmDocumentApproval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.xFlow = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtTimeCheckedBy = new System.Windows.Forms.TextBox();
            this.txtTimeApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpTimeApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.txtDateCheckedBy = new System.Windows.Forms.TextBox();
            this.txtDateApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpDateApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDateCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.txtCheckedBy = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtAuditCode = new System.Windows.Forms.TextBox();
            this.txtNoteID = new System.Windows.Forms.TextBox();
            this.xPnlCategory = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.chkOnlyDeleted = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtApproveChecked = new System.Windows.Forms.TextBox();
            this.txtUnChecked = new System.Windows.Forms.TextBox();
            this.txtUnApproved = new System.Windows.Forms.TextBox();
            this.txtUnApprovedUnChecked = new System.Windows.Forms.TextBox();
            this.txtCancelled = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NoteNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoteNumber,
            this.NoteDate,
            this.CustomerID,
            this.CustomerName,
            this.Amount,
            this.Check});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 140);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(670, 426);
            this.dgvDetail.TabIndex = 12;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            this.dgvDetail.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellMouseLeave);
            this.dgvDetail.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_CellMouseMove);
            // 
            // xFlow
            // 
            this.xFlow.AutoScroll = true;
            this.xFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xFlow.Location = new System.Drawing.Point(223, 28);
            this.xFlow.Name = "xFlow";
            this.xFlow.Size = new System.Drawing.Size(455, 84);
            this.xFlow.TabIndex = 539;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(603, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 541;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(528, 114);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 540;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtTimeCheckedBy
            // 
            this.txtTimeCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeCheckedBy.Enabled = false;
            this.txtTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeCheckedBy.Location = new System.Drawing.Point(518, 338);
            this.txtTimeCheckedBy.Name = "txtTimeCheckedBy";
            this.txtTimeCheckedBy.Size = new System.Drawing.Size(48, 23);
            this.txtTimeCheckedBy.TabIndex = 11;
            // 
            // txtTimeApprovedBy
            // 
            this.txtTimeApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeApprovedBy.Enabled = false;
            this.txtTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeApprovedBy.Location = new System.Drawing.Point(518, 365);
            this.txtTimeApprovedBy.Name = "txtTimeApprovedBy";
            this.txtTimeApprovedBy.Size = new System.Drawing.Size(48, 23);
            this.txtTimeApprovedBy.TabIndex = 15;
            // 
            // dtpTimeApprovedBy
            // 
            this.dtpTimeApprovedBy.Enabled = false;
            this.dtpTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeApprovedBy.Location = new System.Drawing.Point(518, 365);
            this.dtpTimeApprovedBy.Name = "dtpTimeApprovedBy";
            this.dtpTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeApprovedBy.TabIndex = 16;
            // 
            // dtpTimeCheckedBy
            // 
            this.dtpTimeCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpTimeCheckedBy.Enabled = false;
            this.dtpTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeCheckedBy.Location = new System.Drawing.Point(518, 338);
            this.dtpTimeCheckedBy.Name = "dtpTimeCheckedBy";
            this.dtpTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeCheckedBy.TabIndex = 12;
            // 
            // txtDateCheckedBy
            // 
            this.txtDateCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateCheckedBy.Enabled = false;
            this.txtDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCheckedBy.Location = new System.Drawing.Point(430, 338);
            this.txtDateCheckedBy.Name = "txtDateCheckedBy";
            this.txtDateCheckedBy.Size = new System.Drawing.Size(82, 23);
            this.txtDateCheckedBy.TabIndex = 10;
            // 
            // txtDateApprovedBy
            // 
            this.txtDateApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApprovedBy.Enabled = false;
            this.txtDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateApprovedBy.Location = new System.Drawing.Point(430, 365);
            this.txtDateApprovedBy.Name = "txtDateApprovedBy";
            this.txtDateApprovedBy.Size = new System.Drawing.Size(82, 23);
            this.txtDateApprovedBy.TabIndex = 14;
            // 
            // dtpDateApprovedBy
            // 
            this.dtpDateApprovedBy.Enabled = false;
            this.dtpDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateApprovedBy.Location = new System.Drawing.Point(430, 365);
            this.dtpDateApprovedBy.Name = "dtpDateApprovedBy";
            this.dtpDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateApprovedBy.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Gray;
            this.label29.Location = new System.Drawing.Point(346, 369);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 14);
            this.label29.TabIndex = 13;
            this.label29.Text = "Approved Date";
            // 
            // dtpDateCheckedBy
            // 
            this.dtpDateCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpDateCheckedBy.Enabled = false;
            this.dtpDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateCheckedBy.Location = new System.Drawing.Point(430, 338);
            this.dtpDateCheckedBy.Name = "dtpDateCheckedBy";
            this.dtpDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateCheckedBy.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.Location = new System.Drawing.Point(346, 342);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 14);
            this.label26.TabIndex = 9;
            this.label26.Text = "Checked Date";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedBy.Location = new System.Drawing.Point(126, 365);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(200, 22);
            this.txtApprovedBy.TabIndex = 5;
            // 
            // txtCheckedBy
            // 
            this.txtCheckedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckedBy.Location = new System.Drawing.Point(126, 338);
            this.txtCheckedBy.Name = "txtCheckedBy";
            this.txtCheckedBy.ReadOnly = true;
            this.txtCheckedBy.Size = new System.Drawing.Size(200, 22);
            this.txtCheckedBy.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label24.Location = new System.Drawing.Point(25, 342);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 14);
            this.label24.TabIndex = 2;
            this.label24.Text = "Checked By";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label28.Location = new System.Drawing.Point(25, 369);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 4;
            this.label28.Text = "Approved By";
            // 
            // txtAuditCode
            // 
            this.txtAuditCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAuditCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditCode.Location = new System.Drawing.Point(252, 183);
            this.txtAuditCode.Name = "txtAuditCode";
            this.txtAuditCode.Size = new System.Drawing.Size(30, 22);
            this.txtAuditCode.TabIndex = 3;
            this.txtAuditCode.Visible = false;
            // 
            // txtNoteID
            // 
            this.txtNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoteID.Location = new System.Drawing.Point(288, 183);
            this.txtNoteID.Name = "txtNoteID";
            this.txtNoteID.Size = new System.Drawing.Size(30, 22);
            this.txtNoteID.TabIndex = 543;
            this.txtNoteID.Visible = false;
            // 
            // xPnlCategory
            // 
            this.xPnlCategory.AutoScroll = true;
            this.xPnlCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xPnlCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPnlCategory.Location = new System.Drawing.Point(8, 28);
            this.xPnlCategory.Name = "xPnlCategory";
            this.xPnlCategory.Size = new System.Drawing.Size(208, 84);
            this.xPnlCategory.TabIndex = 540;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUserName.Location = new System.Drawing.Point(12, 117);
            this.lblUserName.MaximumSize = new System.Drawing.Size(310, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 18);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "User Name";
            // 
            // chkOnlyDeleted
            // 
            this.chkOnlyDeleted.AutoSize = true;
            this.chkOnlyDeleted.Location = new System.Drawing.Point(206, 185);
            this.chkOnlyDeleted.Name = "chkOnlyDeleted";
            this.chkOnlyDeleted.Size = new System.Drawing.Size(40, 17);
            this.chkOnlyDeleted.TabIndex = 544;
            this.chkOnlyDeleted.Text = "del";
            this.chkOnlyDeleted.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtApproveChecked);
            this.panel4.Controls.Add(this.txtUnChecked);
            this.panel4.Controls.Add(this.txtUnApproved);
            this.panel4.Controls.Add(this.txtUnApprovedUnChecked);
            this.panel4.Controls.Add(this.txtCancelled);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(8, 572);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(676, 26);
            this.panel4.TabIndex = 545;
            // 
            // txtApproveChecked
            // 
            this.txtApproveChecked.BackColor = System.Drawing.Color.White;
            this.txtApproveChecked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApproveChecked.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApproveChecked.Location = new System.Drawing.Point(500, 3);
            this.txtApproveChecked.Multiline = true;
            this.txtApproveChecked.Name = "txtApproveChecked";
            this.txtApproveChecked.ReadOnly = true;
            this.txtApproveChecked.Size = new System.Drawing.Size(140, 18);
            this.txtApproveChecked.TabIndex = 296;
            this.txtApproveChecked.Text = "Approved & Checked Note";
            this.txtApproveChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApproveChecked.Visible = false;
            // 
            // txtUnChecked
            // 
            this.txtUnChecked.BackColor = System.Drawing.Color.White;
            this.txtUnChecked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnChecked.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnChecked.Location = new System.Drawing.Point(385, 3);
            this.txtUnChecked.Multiline = true;
            this.txtUnChecked.Name = "txtUnChecked";
            this.txtUnChecked.ReadOnly = true;
            this.txtUnChecked.Size = new System.Drawing.Size(113, 18);
            this.txtUnChecked.TabIndex = 295;
            this.txtUnChecked.Text = "UnChecked Note";
            this.txtUnChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUnChecked.Visible = false;
            // 
            // txtUnApproved
            // 
            this.txtUnApproved.BackColor = System.Drawing.Color.White;
            this.txtUnApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnApproved.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnApproved.Location = new System.Drawing.Point(268, 3);
            this.txtUnApproved.Multiline = true;
            this.txtUnApproved.Name = "txtUnApproved";
            this.txtUnApproved.ReadOnly = true;
            this.txtUnApproved.Size = new System.Drawing.Size(113, 18);
            this.txtUnApproved.TabIndex = 294;
            this.txtUnApproved.Text = "Checked Note";
            this.txtUnApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUnApprovedUnChecked
            // 
            this.txtUnApprovedUnChecked.BackColor = System.Drawing.Color.White;
            this.txtUnApprovedUnChecked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnApprovedUnChecked.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnApprovedUnChecked.Location = new System.Drawing.Point(87, 3);
            this.txtUnApprovedUnChecked.Multiline = true;
            this.txtUnApprovedUnChecked.Name = "txtUnApprovedUnChecked";
            this.txtUnApprovedUnChecked.ReadOnly = true;
            this.txtUnApprovedUnChecked.Size = new System.Drawing.Size(173, 18);
            this.txtUnApprovedUnChecked.TabIndex = 293;
            this.txtUnApprovedUnChecked.Text = "UnApproved& UnChecked Note";
            this.txtUnApprovedUnChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCancelled
            // 
            this.txtCancelled.BackColor = System.Drawing.Color.White;
            this.txtCancelled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCancelled.Location = new System.Drawing.Point(652, 3);
            this.txtCancelled.Multiline = true;
            this.txtCancelled.Name = "txtCancelled";
            this.txtCancelled.ReadOnly = true;
            this.txtCancelled.Size = new System.Drawing.Size(113, 18);
            this.txtCancelled.TabIndex = 292;
            this.txtCancelled.Text = "Cancelled Note";
            this.txtCancelled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCancelled.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 286;
            this.label1.Text = "Colour Codes";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label42.Location = new System.Drawing.Point(8, 8);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(208, 20);
            this.label42.TabIndex = 546;
            this.label42.Text = "Approval Categories";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(223, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(455, 20);
            this.label2.TabIndex = 547;
            this.label2.Text = "Approval Needed Notes [Transaction Notes]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoteNumber
            // 
            this.NoteNumber.DataPropertyName = "NoteNumber";
            this.NoteNumber.HeaderText = "Note No";
            this.NoteNumber.Name = "NoteNumber";
            this.NoteNumber.ReadOnly = true;
            // 
            // NoteDate
            // 
            this.NoteDate.DataPropertyName = "NoteDate";
            this.NoteDate.HeaderText = "Note Date";
            this.NoteDate.Name = "NoteDate";
            this.NoteDate.ReadOnly = true;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "Customer Code";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 250;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle11;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 150;
            // 
            // Check
            // 
            this.Check.HeaderText = "Approve";
            this.Check.Name = "Check";
            this.Check.Width = 70;
            // 
            // frmDocumentApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(686, 605);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.chkOnlyDeleted);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.xPnlCategory);
            this.Controls.Add(this.txtNoteID);
            this.Controls.Add(this.txtAuditCode);
            this.Controls.Add(this.txtTimeCheckedBy);
            this.Controls.Add(this.txtTimeApprovedBy);
            this.Controls.Add(this.dtpTimeApprovedBy);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpTimeCheckedBy);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtDateCheckedBy);
            this.Controls.Add(this.xFlow);
            this.Controls.Add(this.txtDateApprovedBy);
            this.Controls.Add(this.dtpDateApprovedBy);
            this.Controls.Add(this.txtCheckedBy);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dtpDateCheckedBy);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtApprovedBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmDocumentApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Audit";
            this.Load += new System.EventHandler(this.frmGroupApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel xFlow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtTimeCheckedBy;
        private System.Windows.Forms.TextBox txtTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeCheckedBy;
        private System.Windows.Forms.TextBox txtDateCheckedBy;
        private System.Windows.Forms.TextBox txtDateApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpDateApprovedBy;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpDateCheckedBy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.TextBox txtCheckedBy;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtAuditCode;
        private System.Windows.Forms.TextBox txtNoteID;
        private System.Windows.Forms.Panel xPnlCategory;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.CheckBox chkOnlyDeleted;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApproveChecked;
        private System.Windows.Forms.TextBox txtUnChecked;
        private System.Windows.Forms.TextBox txtUnApproved;
        private System.Windows.Forms.TextBox txtUnApprovedUnChecked;
        private System.Windows.Forms.TextBox txtCancelled;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
    }
}