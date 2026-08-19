namespace Digiteq
{
    partial class frm_AccDebitNote_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AccDebitNote_New));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.x1 = new System.Windows.Forms.Panel();
            this.uC_Supplier1 = new Digiteq.UC_Supplier();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDabitNoteDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreditNoteDate = new System.Windows.Forms.Label();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.txtDebitNoteType = new System.Windows.Forms.TextBox();
            this.lblTrackingNo = new System.Windows.Forms.Label();
            this.txtDebitNoteID = new System.Windows.Forms.TextBox();
            this.lblDebitNoteID = new System.Windows.Forms.Label();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.lblDebitNoteType = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.xSetting = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.rdoReturnGoods = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoAPNAdjustment = new System.Windows.Forms.RadioButton();
            this.chkSettings = new System.Windows.Forms.CheckBox();
            this.zpanel1 = new System.Windows.Forms.Panel();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvAPN = new SEACC_DataGrid();
            this.APNCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APNDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APNAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAPNNo = new System.Windows.Forms.Label();
            this.txtPRNNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSPRNNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnallocattion = new System.Windows.Forms.Button();
            this.uC_TotalCalc1 = new Digiteq.UC_TotalCalc();
            this.uC_DoubleEntry1 = new Digiteq.UC_DoubleEntry();
            this.uC_ExchangeRate1 = new Digiteq.UC_ExchangeRate();
            this.x1.SuspendLayout();
            this.xSetting.SuspendLayout();
            this.zpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPN)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.White;
            this.x1.Controls.Add(this.uC_Supplier1);
            this.x1.Controls.Add(this.panel4);
            this.x1.Controls.Add(this.txtNarration);
            this.x1.Controls.Add(this.label3);
            this.x1.Controls.Add(this.dtpDabitNoteDate);
            this.x1.Controls.Add(this.lblCreditNoteDate);
            this.x1.Controls.Add(this.txtTrackingNo);
            this.x1.Controls.Add(this.txtDebitNoteType);
            this.x1.Controls.Add(this.lblTrackingNo);
            this.x1.Controls.Add(this.txtDebitNoteID);
            this.x1.Controls.Add(this.lblDebitNoteID);
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.lblDebitNoteType);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(410, 264);
            this.x1.TabIndex = 450;
            // 
            // uC_Supplier1
            // 
            this.uC_Supplier1.Location = new System.Drawing.Point(33, 86);
            this.uC_Supplier1.Name = "uC_Supplier1";
            this.uC_Supplier1.Size = new System.Drawing.Size(345, 48);
            this.uC_Supplier1.TabIndex = 580;
            this.uC_Supplier1.SupplierChanged += new Digiteq.UC_Supplier.valueChanged(this.uC_Supplier1_SupplierChanged);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 263);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(419, 10);
            this.panel4.TabIndex = 579;
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(98, 137);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(306, 118);
            this.txtNarration.TabIndex = 577;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 576;
            this.label3.Text = "Narration";
            // 
            // dtpDabitNoteDate
            // 
            this.dtpDabitNoteDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDabitNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDabitNoteDate.Location = new System.Drawing.Point(98, 33);
            this.dtpDabitNoteDate.Name = "dtpDabitNoteDate";
            this.dtpDabitNoteDate.Size = new System.Drawing.Size(106, 22);
            this.dtpDabitNoteDate.TabIndex = 554;
            // 
            // lblCreditNoteDate
            // 
            this.lblCreditNoteDate.AutoSize = true;
            this.lblCreditNoteDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteDate.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNoteDate.Location = new System.Drawing.Point(7, 37);
            this.lblCreditNoteDate.Name = "lblCreditNoteDate";
            this.lblCreditNoteDate.Size = new System.Drawing.Size(88, 14);
            this.lblCreditNoteDate.TabIndex = 555;
            this.lblCreditNoteDate.Text = "Debit Note Date";
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.BackColor = System.Drawing.Color.White;
            this.txtTrackingNo.Enabled = false;
            this.txtTrackingNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrackingNo.Location = new System.Drawing.Point(297, 33);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(107, 22);
            this.txtTrackingNo.TabIndex = 547;
            // 
            // txtDebitNoteType
            // 
            this.txtDebitNoteType.Enabled = false;
            this.txtDebitNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitNoteType.Location = new System.Drawing.Point(98, 60);
            this.txtDebitNoteType.Name = "txtDebitNoteType";
            this.txtDebitNoteType.ReadOnly = true;
            this.txtDebitNoteType.Size = new System.Drawing.Size(306, 22);
            this.txtDebitNoteType.TabIndex = 546;
            // 
            // lblTrackingNo
            // 
            this.lblTrackingNo.AutoSize = true;
            this.lblTrackingNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackingNo.ForeColor = System.Drawing.Color.Gray;
            this.lblTrackingNo.Location = new System.Drawing.Point(227, 37);
            this.lblTrackingNo.Name = "lblTrackingNo";
            this.lblTrackingNo.Size = new System.Drawing.Size(68, 14);
            this.lblTrackingNo.TabIndex = 549;
            this.lblTrackingNo.Text = "Tracking No.";
            // 
            // txtDebitNoteID
            // 
            this.txtDebitNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtDebitNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitNoteID.Location = new System.Drawing.Point(98, 6);
            this.txtDebitNoteID.Name = "txtDebitNoteID";
            this.txtDebitNoteID.ReadOnly = true;
            this.txtDebitNoteID.Size = new System.Drawing.Size(107, 22);
            this.txtDebitNoteID.TabIndex = 544;
            this.txtDebitNoteID.Text = "GN005";
            this.txtDebitNoteID.DoubleClick += new System.EventHandler(this.txtDebitNoteID_DoubleClick);
            this.txtDebitNoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDebitNoteID_KeyDown);
            // 
            // lblDebitNoteID
            // 
            this.lblDebitNoteID.AutoSize = true;
            this.lblDebitNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitNoteID.ForeColor = System.Drawing.Color.Black;
            this.lblDebitNoteID.Location = new System.Drawing.Point(7, 10);
            this.lblDebitNoteID.Name = "lblDebitNoteID";
            this.lblDebitNoteID.Size = new System.Drawing.Size(81, 14);
            this.lblDebitNoteID.TabIndex = 545;
            this.lblDebitNoteID.Text = "Debit Note No.";
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(207, 10);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 543;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // lblDebitNoteType
            // 
            this.lblDebitNoteType.AutoSize = true;
            this.lblDebitNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitNoteType.ForeColor = System.Drawing.Color.Gray;
            this.lblDebitNoteType.Location = new System.Drawing.Point(7, 64);
            this.lblDebitNoteType.Name = "lblDebitNoteType";
            this.lblDebitNoteType.Size = new System.Drawing.Size(88, 14);
            this.lblDebitNoteType.TabIndex = 548;
            this.lblDebitNoteType.Text = "Debit Note Type";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(231, 8);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 494;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.LightGray;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.btn_Close);
            this.xSetting.Controls.Add(this.rdoReturnGoods);
            this.xSetting.Controls.Add(this.label4);
            this.xSetting.Controls.Add(this.rdoAPNAdjustment);
            this.xSetting.Location = new System.Drawing.Point(577, 8);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(157, 75);
            this.xSetting.TabIndex = 537;
            this.xSetting.Visible = false;
            this.xSetting.Leave += new System.EventHandler(this.xSetting_Leave);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(126, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 28);
            this.btn_Close.TabIndex = 559;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // rdoReturnGoods
            // 
            this.rdoReturnGoods.AutoSize = true;
            this.rdoReturnGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReturnGoods.Location = new System.Drawing.Point(18, 46);
            this.rdoReturnGoods.Name = "rdoReturnGoods";
            this.rdoReturnGoods.Size = new System.Drawing.Size(97, 17);
            this.rdoReturnGoods.TabIndex = 558;
            this.rdoReturnGoods.Text = "Return Goods";
            this.rdoReturnGoods.UseVisualStyleBackColor = true;
            this.rdoReturnGoods.CheckedChanged += new System.EventHandler(this.rdoAPNAdjustment_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 14);
            this.label4.TabIndex = 499;
            this.label4.Text = "Debit note Type";
            // 
            // rdoAPNAdjustment
            // 
            this.rdoAPNAdjustment.AutoSize = true;
            this.rdoAPNAdjustment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoAPNAdjustment.Location = new System.Drawing.Point(18, 28);
            this.rdoAPNAdjustment.Name = "rdoAPNAdjustment";
            this.rdoAPNAdjustment.Size = new System.Drawing.Size(108, 17);
            this.rdoAPNAdjustment.TabIndex = 557;
            this.rdoAPNAdjustment.Text = "APN Adjustment";
            this.rdoAPNAdjustment.UseVisualStyleBackColor = true;
            this.rdoAPNAdjustment.CheckedChanged += new System.EventHandler(this.rdoAPNAdjustment_CheckedChanged);
            // 
            // chkSettings
            // 
            this.chkSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSettings.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSettings.Image = ((System.Drawing.Image)(resources.GetObject("chkSettings.Image")));
            this.chkSettings.Location = new System.Drawing.Point(277, 6);
            this.chkSettings.Name = "chkSettings";
            this.chkSettings.Size = new System.Drawing.Size(22, 22);
            this.chkSettings.TabIndex = 539;
            this.chkSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSettings.UseVisualStyleBackColor = true;
            // 
            // zpanel1
            // 
            this.zpanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zpanel1.Controls.Add(this.txtTotalAmount);
            this.zpanel1.Controls.Add(this.btnRemove);
            this.zpanel1.Controls.Add(this.dgvAPN);
            this.zpanel1.Controls.Add(this.lblAPNNo);
            this.zpanel1.Controls.Add(this.txtPRNNo);
            this.zpanel1.Controls.Add(this.label5);
            this.zpanel1.Location = new System.Drawing.Point(427, 46);
            this.zpanel1.Name = "zpanel1";
            this.zpanel1.Size = new System.Drawing.Size(307, 158);
            this.zpanel1.TabIndex = 558;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(194, 129);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(98, 22);
            this.txtTotalAmount.TabIndex = 574;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.Location = new System.Drawing.Point(279, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 22);
            this.btnRemove.TabIndex = 560;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvAPN
            // 
            this.dgvAPN.AllowUserToAddRows = false;
            this.dgvAPN.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvAPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAPN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAPN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.APNCode,
            this.APNDate,
            this.APNAmount});
            this.dgvAPN.EnableHeadersVisualStyles = false;
            this.dgvAPN.Location = new System.Drawing.Point(4, 36);
            this.dgvAPN.MultiSelect = false;
            this.dgvAPN.Name = "dgvAPN";
            this.dgvAPN.RowHeadersVisible = false;
            this.dgvAPN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAPN.Size = new System.Drawing.Size(295, 89);
            this.dgvAPN.TabIndex = 573;
            this.dgvAPN.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAPN_CellEndEdit);
            // 
            // APNCode
            // 
            this.APNCode.HeaderText = "APN / PRN No.";
            this.APNCode.MaxInputLength = 20000;
            this.APNCode.MinimumWidth = 50;
            this.APNCode.Name = "APNCode";
            this.APNCode.ReadOnly = true;
            // 
            // APNDate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.APNDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.APNDate.HeaderText = "Date";
            this.APNDate.MaxInputLength = 20000;
            this.APNDate.Name = "APNDate";
            this.APNDate.ReadOnly = true;
            this.APNDate.Width = 80;
            // 
            // APNAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.APNAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.APNAmount.HeaderText = "Amount";
            this.APNAmount.Name = "APNAmount";
            this.APNAmount.Width = 110;
            // 
            // lblAPNNo
            // 
            this.lblAPNNo.AutoSize = true;
            this.lblAPNNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPNNo.ForeColor = System.Drawing.Color.Black;
            this.lblAPNNo.Location = new System.Drawing.Point(8, 14);
            this.lblAPNNo.Name = "lblAPNNo";
            this.lblAPNNo.Size = new System.Drawing.Size(48, 14);
            this.lblAPNNo.TabIndex = 0;
            this.lblAPNNo.Text = "APN No.";
            // 
            // txtPRNNo
            // 
            this.txtPRNNo.BackColor = System.Drawing.Color.LightGray;
            this.txtPRNNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRNNo.Location = new System.Drawing.Point(61, 8);
            this.txtPRNNo.Name = "txtPRNNo";
            this.txtPRNNo.ReadOnly = true;
            this.txtPRNNo.Size = new System.Drawing.Size(126, 22);
            this.txtPRNNo.TabIndex = 496;
            this.txtPRNNo.DoubleClick += new System.EventHandler(this.txtPRNNo_DoubleClick);
            this.txtPRNNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPRNNo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(19, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 545;
            this.label5.Text = "Total Amount";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.txtSPRNNo);
            this.panel3.Controls.Add(this.chkSettings);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(427, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 36);
            this.panel3.TabIndex = 560;
            // 
            // txtSPRNNo
            // 
            this.txtSPRNNo.BackColor = System.Drawing.Color.LightGray;
            this.txtSPRNNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPRNNo.Location = new System.Drawing.Point(61, 6);
            this.txtSPRNNo.Name = "txtSPRNNo";
            this.txtSPRNNo.ReadOnly = true;
            this.txtSPRNNo.Size = new System.Drawing.Size(210, 22);
            this.txtSPRNNo.TabIndex = 541;
            this.txtSPRNNo.Text = "GN005";
            this.txtSPRNNo.DoubleClick += new System.EventHandler(this.txtSRNNo_DoubleClick);
            this.txtSPRNNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSPRNNo_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 540;
            this.label7.Text = "PRN No.";
            // 
            // btnallocattion
            // 
            this.btnallocattion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnallocattion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnallocattion.Location = new System.Drawing.Point(8, 280);
            this.btnallocattion.Name = "btnallocattion";
            this.btnallocattion.Size = new System.Drawing.Size(70, 25);
            this.btnallocattion.TabIndex = 578;
            this.btnallocattion.Text = "Allocation";
            this.btnallocattion.UseVisualStyleBackColor = true;
            this.btnallocattion.Click += new System.EventHandler(this.btnallocattion_Click);
            // 
            // uC_TotalCalc1
            // 
            this.uC_TotalCalc1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.uC_TotalCalc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_TotalCalc1.DiscountPresentage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uC_TotalCalc1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_TotalCalc1.IsCredit = false;
            this.uC_TotalCalc1.IsDiscountEnable = false;
            this.uC_TotalCalc1.IsNBTenable = false;
            this.uC_TotalCalc1.IsSvatEnable = false;
            this.uC_TotalCalc1.IsVatEnable = false;
            this.uC_TotalCalc1.Location = new System.Drawing.Point(427, 208);
            this.uC_TotalCalc1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_TotalCalc1.Name = "uC_TotalCalc1";
            this.uC_TotalCalc1.NbtPresentage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uC_TotalCalc1.OtherTaxPresentage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uC_TotalCalc1.Size = new System.Drawing.Size(309, 157);
            this.uC_TotalCalc1.SubTotal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.uC_TotalCalc1.TabIndex = 581;
            this.uC_TotalCalc1.VatPresentage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uC_TotalCalc1.DoubleEntryUpdataed += new Digiteq.UC_TotalCalc.valueChanged(this.uC_TotalCalc1_DoubleEntryUpdataed);
            // 
            // uC_DoubleEntry1
            // 
            this.uC_DoubleEntry1.Location = new System.Drawing.Point(8, 372);
            this.uC_DoubleEntry1.Name = "uC_DoubleEntry1";
            this.uC_DoubleEntry1.Size = new System.Drawing.Size(728, 177);
            this.uC_DoubleEntry1.TabIndex = 582;
            // 
            // uC_ExchangeRate1
            // 
            this.uC_ExchangeRate1.Location = new System.Drawing.Point(109, 280);
            this.uC_ExchangeRate1.Name = "uC_ExchangeRate1";
            this.uC_ExchangeRate1.Size = new System.Drawing.Size(308, 24);
            this.uC_ExchangeRate1.TabIndex = 583;
            this.uC_ExchangeRate1.ExRateChanged += new Digiteq.UC_ExchangeRate.valueChanged(this.uC_ExchangeRate1_ExRateChanged);
            // 
            // frm_AccDebitNote_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uC_ExchangeRate1);
            this.Controls.Add(this.uC_DoubleEntry1);
            this.Controls.Add(this.uC_TotalCalc1);
            this.Controls.Add(this.xSetting);
            this.Controls.Add(this.btnallocattion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.zpanel1);
            this.Controls.Add(this.x1);
            this.Name = "frm_AccDebitNote_New";
            this.Size = new System.Drawing.Size(746, 629);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_AccDebitNote_SF_tempButton_Click_1);
            this.Load += new System.EventHandler(this.frm_AccDebitNote_Load);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.zpanel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.btnallocattion, 0);
            this.Controls.SetChildIndex(this.xSetting, 0);
            this.Controls.SetChildIndex(this.uC_TotalCalc1, 0);
            this.Controls.SetChildIndex(this.uC_DoubleEntry1, 0);
            this.Controls.SetChildIndex(this.uC_ExchangeRate1, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.zpanel1.ResumeLayout(false);
            this.zpanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPN)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.DateTimePicker dtpDabitNoteDate;
        private System.Windows.Forms.Label lblCreditNoteDate;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private System.Windows.Forms.TextBox txtDebitNoteType;
        private System.Windows.Forms.Label lblTrackingNo;
        private System.Windows.Forms.TextBox txtDebitNoteID;
        private System.Windows.Forms.Label lblDebitNoteID;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.Label lblDebitNoteType;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.CheckBox chkSettings;
        private System.Windows.Forms.Panel zpanel1;
        private System.Windows.Forms.TextBox txtPRNNo;
        private SEACC_DataGrid dgvAPN;
        private System.Windows.Forms.Label lblAPNNo;
        private System.Windows.Forms.RadioButton rdoAPNAdjustment;
        private System.Windows.Forms.RadioButton rdoReturnGoods;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSPRNNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnallocattion;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel4;
        private UC_Supplier uC_Supplier1;
        private UC_TotalCalc uC_TotalCalc1;
        private UC_DoubleEntry uC_DoubleEntry1;
        private UC_ExchangeRate uC_ExchangeRate1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn APNCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn APNDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn APNAmount;
    }
}