namespace Digiteq
{
    partial class frm_bpsPettyCashAccount
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.x1 = new System.Windows.Forms.Panel();
            this.dtpPettyCashExpireDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrency_ID = new System.Windows.Forms.TextBox();
            this.lblCurrencyID = new System.Windows.Forms.Label();
            this.txtAssignedUserID = new System.Windows.Forms.TextBox();
            this.lblQuotaionNo = new System.Windows.Forms.Label();
            this.txtPettyCashAccountName = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpPettyCashAccountDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPettyCashAccountID = new System.Windows.Forms.TextBox();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.txtTimeCheckedBy = new System.Windows.Forms.TextBox();
            this.txtTimeApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpTimeApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.txtDateCheckedBy = new System.Windows.Forms.TextBox();
            this.txtDateApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpDateApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDateCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.dtpDatePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPreparedBy = new System.Windows.Forms.TextBox();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.txtCheckedBy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtFloatAmount = new System.Windows.Forms.TextBox();
            this.lblFloatAmount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.x1.SuspendLayout();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPermission);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.x1);
            this.groupBox1.Controls.Add(this.z1);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnPermission
            // 
            this.btnPermission.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPermission.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermission.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPermission.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnPermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPermission.Location = new System.Drawing.Point(8, 153);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(105, 26);
            this.btnPermission.TabIndex = 478;
            this.btnPermission.Text = "  Permission";
            this.btnPermission.UseVisualStyleBackColor = true;
            this.btnPermission.Click += new System.EventHandler(this.txtPermission_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(346, 154);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 471;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Digiteq.Properties.Resources.delete;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(423, 154);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.TabIndex = 472;
            this.btnEdit.Text = "Cancel";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(500, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 470;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.txtFloatAmount);
            this.x1.Controls.Add(this.lblFloatAmount);
            this.x1.Controls.Add(this.dtpPettyCashExpireDate);
            this.x1.Controls.Add(this.txtRemark);
            this.x1.Controls.Add(this.label2);
            this.x1.Controls.Add(this.txtCurrency_ID);
            this.x1.Controls.Add(this.lblCurrencyID);
            this.x1.Controls.Add(this.txtAssignedUserID);
            this.x1.Controls.Add(this.lblQuotaionNo);
            this.x1.Controls.Add(this.txtPettyCashAccountName);
            this.x1.Controls.Add(this.lblAccountName);
            this.x1.Controls.Add(this.label10);
            this.x1.Controls.Add(this.dtpPettyCashAccountDate);
            this.x1.Controls.Add(this.label19);
            this.x1.Controls.Add(this.txtPettyCashAccountID);
            this.x1.Controls.Add(this.lblAccountID);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(8, 17);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(567, 130);
            this.x1.TabIndex = 469;
            this.x1.Paint += new System.Windows.Forms.PaintEventHandler(this.x1_Paint);
            // 
            // dtpPettyCashExpireDate
            // 
            this.dtpPettyCashExpireDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPettyCashExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPettyCashExpireDate.Location = new System.Drawing.Point(400, 38);
            this.dtpPettyCashExpireDate.Name = "dtpPettyCashExpireDate";
            this.dtpPettyCashExpireDate.Size = new System.Drawing.Size(150, 22);
            this.dtpPettyCashExpireDate.TabIndex = 476;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(107, 93);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(150, 22);
            this.txtRemark.TabIndex = 475;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(11, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 474;
            this.label2.Text = "Remarks";
            // 
            // txtCurrency_ID
            // 
            this.txtCurrency_ID.BackColor = System.Drawing.Color.LightGray;
            this.txtCurrency_ID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrency_ID.Location = new System.Drawing.Point(400, 65);
            this.txtCurrency_ID.Name = "txtCurrency_ID";
            this.txtCurrency_ID.ReadOnly = true;
            this.txtCurrency_ID.Size = new System.Drawing.Size(150, 22);
            this.txtCurrency_ID.TabIndex = 471;
            this.txtCurrency_ID.DoubleClick += new System.EventHandler(this.txtCurrency_ID_DoubleClick);
            this.txtCurrency_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrency_ID_KeyDown);
            // 
            // lblCurrencyID
            // 
            this.lblCurrencyID.AutoSize = true;
            this.lblCurrencyID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCurrencyID.Location = new System.Drawing.Point(297, 69);
            this.lblCurrencyID.Name = "lblCurrencyID";
            this.lblCurrencyID.Size = new System.Drawing.Size(50, 14);
            this.lblCurrencyID.TabIndex = 470;
            this.lblCurrencyID.Text = "Currency";
            // 
            // txtAssignedUserID
            // 
            this.txtAssignedUserID.BackColor = System.Drawing.Color.LightGray;
            this.txtAssignedUserID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignedUserID.Location = new System.Drawing.Point(107, 65);
            this.txtAssignedUserID.Name = "txtAssignedUserID";
            this.txtAssignedUserID.ReadOnly = true;
            this.txtAssignedUserID.Size = new System.Drawing.Size(150, 22);
            this.txtAssignedUserID.TabIndex = 469;
            this.txtAssignedUserID.DoubleClick += new System.EventHandler(this.txtAssignedUserID_DoubleClick);
            this.txtAssignedUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAssignedUserID_KeyDown);
            // 
            // lblQuotaionNo
            // 
            this.lblQuotaionNo.AutoSize = true;
            this.lblQuotaionNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuotaionNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblQuotaionNo.Location = new System.Drawing.Point(11, 69);
            this.lblQuotaionNo.Name = "lblQuotaionNo";
            this.lblQuotaionNo.Size = new System.Drawing.Size(61, 14);
            this.lblQuotaionNo.TabIndex = 468;
            this.lblQuotaionNo.Text = "Super User";
            // 
            // txtPettyCashAccountName
            // 
            this.txtPettyCashAccountName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPettyCashAccountName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPettyCashAccountName.Location = new System.Drawing.Point(107, 38);
            this.txtPettyCashAccountName.Name = "txtPettyCashAccountName";
            this.txtPettyCashAccountName.Size = new System.Drawing.Size(150, 22);
            this.txtPettyCashAccountName.TabIndex = 431;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAccountName.Location = new System.Drawing.Point(11, 42);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(79, 14);
            this.lblAccountName.TabIndex = 432;
            this.lblAccountName.Text = "Account Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label10.Location = new System.Drawing.Point(297, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 14);
            this.label10.TabIndex = 457;
            this.label10.Text = "Expire Date";
            // 
            // dtpPettyCashAccountDate
            // 
            this.dtpPettyCashAccountDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPettyCashAccountDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPettyCashAccountDate.Location = new System.Drawing.Point(400, 11);
            this.dtpPettyCashAccountDate.Name = "dtpPettyCashAccountDate";
            this.dtpPettyCashAccountDate.Size = new System.Drawing.Size(150, 22);
            this.dtpPettyCashAccountDate.TabIndex = 412;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label19.Location = new System.Drawing.Point(297, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 14);
            this.label19.TabIndex = 411;
            this.label19.Text = "Account Date";
            // 
            // txtPettyCashAccountID
            // 
            this.txtPettyCashAccountID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtPettyCashAccountID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPettyCashAccountID.Location = new System.Drawing.Point(107, 11);
            this.txtPettyCashAccountID.Name = "txtPettyCashAccountID";
            this.txtPettyCashAccountID.Size = new System.Drawing.Size(120, 22);
            this.txtPettyCashAccountID.TabIndex = 399;
            this.txtPettyCashAccountID.Text = "IN005";
            this.txtPettyCashAccountID.DoubleClick += new System.EventHandler(this.txtPettyCashAccount_ID_DoubleClick);
            this.txtPettyCashAccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPettyCashAccount_ID_KeyDown);
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAccountID.Location = new System.Drawing.Point(11, 15);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(73, 14);
            this.lblAccountID.TabIndex = 398;
            this.lblAccountID.Text = "Account Code";
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.txtTimeCheckedBy);
            this.z1.Controls.Add(this.txtTimeApprovedBy);
            this.z1.Controls.Add(this.dtpTimeApprovedBy);
            this.z1.Controls.Add(this.dtpTimeCheckedBy);
            this.z1.Controls.Add(this.dtpTimePreparedBy);
            this.z1.Controls.Add(this.txtDateCheckedBy);
            this.z1.Controls.Add(this.txtDateApprovedBy);
            this.z1.Controls.Add(this.dtpDateApprovedBy);
            this.z1.Controls.Add(this.label29);
            this.z1.Controls.Add(this.dtpDateCheckedBy);
            this.z1.Controls.Add(this.label26);
            this.z1.Controls.Add(this.dtpDatePreparedBy);
            this.z1.Controls.Add(this.label1);
            this.z1.Controls.Add(this.txtPreparedBy);
            this.z1.Controls.Add(this.txtApprovedBy);
            this.z1.Controls.Add(this.txtCheckedBy);
            this.z1.Controls.Add(this.label5);
            this.z1.Controls.Add(this.label27);
            this.z1.Controls.Add(this.label28);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.Location = new System.Drawing.Point(8, 185);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(567, 97);
            this.z1.TabIndex = 467;
            // 
            // txtTimeCheckedBy
            // 
            this.txtTimeCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeCheckedBy.Enabled = false;
            this.txtTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeCheckedBy.Location = new System.Drawing.Point(502, 37);
            this.txtTimeCheckedBy.Name = "txtTimeCheckedBy";
            this.txtTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.txtTimeCheckedBy.TabIndex = 471;
            // 
            // txtTimeApprovedBy
            // 
            this.txtTimeApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeApprovedBy.Enabled = false;
            this.txtTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeApprovedBy.Location = new System.Drawing.Point(502, 64);
            this.txtTimeApprovedBy.Name = "txtTimeApprovedBy";
            this.txtTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.txtTimeApprovedBy.TabIndex = 470;
            // 
            // dtpTimeApprovedBy
            // 
            this.dtpTimeApprovedBy.Enabled = false;
            this.dtpTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeApprovedBy.Location = new System.Drawing.Point(502, 64);
            this.dtpTimeApprovedBy.Name = "dtpTimeApprovedBy";
            this.dtpTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeApprovedBy.TabIndex = 469;
            // 
            // dtpTimeCheckedBy
            // 
            this.dtpTimeCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpTimeCheckedBy.Enabled = false;
            this.dtpTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeCheckedBy.Location = new System.Drawing.Point(502, 37);
            this.dtpTimeCheckedBy.Name = "dtpTimeCheckedBy";
            this.dtpTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeCheckedBy.TabIndex = 468;
            // 
            // dtpTimePreparedBy
            // 
            this.dtpTimePreparedBy.Enabled = false;
            this.dtpTimePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimePreparedBy.Location = new System.Drawing.Point(502, 9);
            this.dtpTimePreparedBy.Name = "dtpTimePreparedBy";
            this.dtpTimePreparedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimePreparedBy.TabIndex = 467;
            // 
            // txtDateCheckedBy
            // 
            this.txtDateCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateCheckedBy.Enabled = false;
            this.txtDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCheckedBy.Location = new System.Drawing.Point(414, 37);
            this.txtDateCheckedBy.Name = "txtDateCheckedBy";
            this.txtDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.txtDateCheckedBy.TabIndex = 466;
            // 
            // txtDateApprovedBy
            // 
            this.txtDateApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApprovedBy.Enabled = false;
            this.txtDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateApprovedBy.Location = new System.Drawing.Point(414, 64);
            this.txtDateApprovedBy.Name = "txtDateApprovedBy";
            this.txtDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.txtDateApprovedBy.TabIndex = 465;
            // 
            // dtpDateApprovedBy
            // 
            this.dtpDateApprovedBy.Enabled = false;
            this.dtpDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateApprovedBy.Location = new System.Drawing.Point(414, 64);
            this.dtpDateApprovedBy.Name = "dtpDateApprovedBy";
            this.dtpDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateApprovedBy.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Gray;
            this.label29.Location = new System.Drawing.Point(330, 68);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 14);
            this.label29.TabIndex = 443;
            this.label29.Text = "Approved Date";
            // 
            // dtpDateCheckedBy
            // 
            this.dtpDateCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpDateCheckedBy.Enabled = false;
            this.dtpDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateCheckedBy.Location = new System.Drawing.Point(414, 37);
            this.dtpDateCheckedBy.Name = "dtpDateCheckedBy";
            this.dtpDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateCheckedBy.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.Location = new System.Drawing.Point(330, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 14);
            this.label26.TabIndex = 441;
            this.label26.Text = "Checked Date";
            // 
            // dtpDatePreparedBy
            // 
            this.dtpDatePreparedBy.Enabled = false;
            this.dtpDatePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePreparedBy.Location = new System.Drawing.Point(414, 9);
            this.dtpDatePreparedBy.Name = "dtpDatePreparedBy";
            this.dtpDatePreparedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDatePreparedBy.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(330, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 439;
            this.label1.Text = "Prepared Date";
            // 
            // txtPreparedBy
            // 
            this.txtPreparedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreparedBy.ForeColor = System.Drawing.Color.Gray;
            this.txtPreparedBy.Location = new System.Drawing.Point(107, 9);
            this.txtPreparedBy.Name = "txtPreparedBy";
            this.txtPreparedBy.ReadOnly = true;
            this.txtPreparedBy.Size = new System.Drawing.Size(200, 22);
            this.txtPreparedBy.TabIndex = 0;
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedBy.Location = new System.Drawing.Point(107, 64);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(200, 22);
            this.txtApprovedBy.TabIndex = 2;
            this.txtApprovedBy.DoubleClick += new System.EventHandler(this.txtApprovedBy_DoubleClick);
            this.txtApprovedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApprovedBy_KeyDown);
            // 
            // txtCheckedBy
            // 
            this.txtCheckedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckedBy.Location = new System.Drawing.Point(107, 37);
            this.txtCheckedBy.Name = "txtCheckedBy";
            this.txtCheckedBy.ReadOnly = true;
            this.txtCheckedBy.Size = new System.Drawing.Size(200, 22);
            this.txtCheckedBy.TabIndex = 1;
            this.txtCheckedBy.DoubleClick += new System.EventHandler(this.txtCheckedBy_DoubleClick);
            this.txtCheckedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheckedBy_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(11, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 435;
            this.label5.Text = "Checked By";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(11, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 14);
            this.label27.TabIndex = 426;
            this.label27.Text = "Prepared By";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label28.Location = new System.Drawing.Point(11, 68);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 425;
            this.label28.Text = "Approved By";
            // 
            // txtFloatAmount
            // 
            this.txtFloatAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloatAmount.Location = new System.Drawing.Point(400, 93);
            this.txtFloatAmount.Name = "txtFloatAmount";
            this.txtFloatAmount.Size = new System.Drawing.Size(150, 22);
            this.txtFloatAmount.TabIndex = 478;
            this.txtFloatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFloatAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFloatAmount_KeyPress);
            // 
            // lblFloatAmount
            // 
            this.lblFloatAmount.AutoSize = true;
            this.lblFloatAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloatAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFloatAmount.Location = new System.Drawing.Point(297, 97);
            this.lblFloatAmount.Name = "lblFloatAmount";
            this.lblFloatAmount.Size = new System.Drawing.Size(74, 14);
            this.lblFloatAmount.TabIndex = 477;
            this.lblFloatAmount.Text = "Float Amount";
            // 
            // frm_bpsPettyCashAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(599, 306);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_bpsPettyCashAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEACC Petty Cash Account Creation";
            this.Load += new System.EventHandler(this.frm_bpsPettyCashAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.TextBox txtTimeCheckedBy;
        private System.Windows.Forms.TextBox txtTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeCheckedBy;
        private System.Windows.Forms.DateTimePicker dtpTimePreparedBy;
        private System.Windows.Forms.TextBox txtDateCheckedBy;
        private System.Windows.Forms.TextBox txtDateApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpDateApprovedBy;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpDateCheckedBy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DateTimePicker dtpDatePreparedBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPreparedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.TextBox txtCheckedBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpPettyCashAccountDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPettyCashAccountID;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.TextBox txtCurrency_ID;
        private System.Windows.Forms.Label lblCurrencyID;
        private System.Windows.Forms.TextBox txtAssignedUserID;
        private System.Windows.Forms.Label lblQuotaionNo;
        private System.Windows.Forms.DateTimePicker dtpPettyCashExpireDate;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPettyCashAccountName;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.TextBox txtFloatAmount;
        private System.Windows.Forms.Label lblFloatAmount;
    }
}