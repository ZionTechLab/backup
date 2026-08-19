namespace Digiteq
{
    partial class frm_bpsCreditNote2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.z1 = new System.Windows.Forms.Panel();
            this.lblSalesNoteType = new System.Windows.Forms.Label();
            this.txtSalesNoteType = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.dtpCreditNoteDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreditNoteDate = new System.Windows.Forms.Label();
            this.txtOrderRefNo = new System.Windows.Forms.TextBox();
            this.txtCreditNoteType = new System.Windows.Forms.TextBox();
            this.lblOrderRefNo = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblCreditNoteType = new System.Windows.Forms.Label();
            this.txtCreditNoteID = new System.Windows.Forms.TextBox();
            this.lblCerditNoteID = new System.Windows.Forms.Label();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.uC_ExchangeRate1 = new Digiteq.UC_ExchangeRate();
            this.uC_DoubleEntry1 = new Digiteq.UC_DoubleEntry();
            this.uC_TotalCalc1 = new Digiteq.UC_TotalCalc();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.rdoWriteOff = new System.Windows.Forms.RadioButton();
            this.rdoNormalSales = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xSetting = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAllocated = new System.Windows.Forms.TextBox();
            this.dgvInvoice = new Digiteq.SEACC_DataGrid();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocatedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.z1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.xSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.White;
            this.z1.Controls.Add(this.lblSalesNoteType);
            this.z1.Controls.Add(this.txtSalesNoteType);
            this.z1.Controls.Add(this.lblRemark);
            this.z1.Controls.Add(this.txtRemark);
            this.z1.Controls.Add(this.dtpCreditNoteDate);
            this.z1.Controls.Add(this.lblCreditNoteDate);
            this.z1.Controls.Add(this.txtOrderRefNo);
            this.z1.Controls.Add(this.txtCreditNoteType);
            this.z1.Controls.Add(this.lblOrderRefNo);
            this.z1.Controls.Add(this.txtCustomerID);
            this.z1.Controls.Add(this.lblCustomerID);
            this.z1.Controls.Add(this.lblCreditNoteType);
            this.z1.Controls.Add(this.txtCreditNoteID);
            this.z1.Controls.Add(this.lblCerditNoteID);
            this.z1.Controls.Add(this.lblCancelled);
            this.z1.Controls.Add(this.chkShowSettle);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.Location = new System.Drawing.Point(4, 4);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(410, 228);
            this.z1.TabIndex = 450;
            // 
            // lblSalesNoteType
            // 
            this.lblSalesNoteType.AutoSize = true;
            this.lblSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblSalesNoteType.Location = new System.Drawing.Point(6, 90);
            this.lblSalesNoteType.Name = "lblSalesNoteType";
            this.lblSalesNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblSalesNoteType.TabIndex = 563;
            this.lblSalesNoteType.Text = "Note Type";
            // 
            // txtSalesNoteType
            // 
            this.txtSalesNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesNoteType.Location = new System.Drawing.Point(96, 85);
            this.txtSalesNoteType.Name = "txtSalesNoteType";
            this.txtSalesNoteType.ReadOnly = true;
            this.txtSalesNoteType.Size = new System.Drawing.Size(307, 22);
            this.txtSalesNoteType.TabIndex = 562;
            this.txtSalesNoteType.DoubleClick += new System.EventHandler(this.txtSalesNoteType_DoubleClick);
            this.txtSalesNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNoteType_KeyDown);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.ForeColor = System.Drawing.Color.Black;
            this.lblRemark.Location = new System.Drawing.Point(6, 141);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(51, 14);
            this.lblRemark.TabIndex = 413;
            this.lblRemark.Text = "Remarks";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(96, 141);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(307, 78);
            this.txtRemark.TabIndex = 412;
            // 
            // dtpCreditNoteDate
            // 
            this.dtpCreditNoteDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreditNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreditNoteDate.Location = new System.Drawing.Point(96, 33);
            this.dtpCreditNoteDate.Name = "dtpCreditNoteDate";
            this.dtpCreditNoteDate.Size = new System.Drawing.Size(104, 22);
            this.dtpCreditNoteDate.TabIndex = 554;
            // 
            // lblCreditNoteDate
            // 
            this.lblCreditNoteDate.AutoSize = true;
            this.lblCreditNoteDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteDate.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNoteDate.Location = new System.Drawing.Point(6, 38);
            this.lblCreditNoteDate.Name = "lblCreditNoteDate";
            this.lblCreditNoteDate.Size = new System.Drawing.Size(55, 14);
            this.lblCreditNoteDate.TabIndex = 555;
            this.lblCreditNoteDate.Text = "CRN Date";
            // 
            // txtOrderRefNo
            // 
            this.txtOrderRefNo.BackColor = System.Drawing.Color.White;
            this.txtOrderRefNo.Enabled = false;
            this.txtOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderRefNo.Location = new System.Drawing.Point(277, 33);
            this.txtOrderRefNo.Name = "txtOrderRefNo";
            this.txtOrderRefNo.ReadOnly = true;
            this.txtOrderRefNo.Size = new System.Drawing.Size(104, 22);
            this.txtOrderRefNo.TabIndex = 547;
            // 
            // txtCreditNoteType
            // 
            this.txtCreditNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtCreditNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteType.Location = new System.Drawing.Point(96, 59);
            this.txtCreditNoteType.Name = "txtCreditNoteType";
            this.txtCreditNoteType.ReadOnly = true;
            this.txtCreditNoteType.Size = new System.Drawing.Size(307, 22);
            this.txtCreditNoteType.TabIndex = 546;
            this.txtCreditNoteType.DoubleClick += new System.EventHandler(this.txtCreditNoteType_DoubleClick);
            this.txtCreditNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditNoteType_KeyDown);
            // 
            // lblOrderRefNo
            // 
            this.lblOrderRefNo.AutoSize = true;
            this.lblOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRefNo.ForeColor = System.Drawing.Color.Gray;
            this.lblOrderRefNo.Location = new System.Drawing.Point(205, 36);
            this.lblOrderRefNo.Name = "lblOrderRefNo";
            this.lblOrderRefNo.Size = new System.Drawing.Size(68, 14);
            this.lblOrderRefNo.TabIndex = 549;
            this.lblOrderRefNo.Text = "Tracking No.";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(96, 111);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(307, 22);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.Text = "Asanka Jayasuriya";
            this.txtCustomerID.DoubleClick += new System.EventHandler(this.txtCustomerID_DoubleClick);
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerID.Location = new System.Drawing.Point(6, 115);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(87, 14);
            this.lblCustomerID.TabIndex = 273;
            this.lblCustomerID.Text = "Customer Name";
            // 
            // lblCreditNoteType
            // 
            this.lblCreditNoteType.AutoSize = true;
            this.lblCreditNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNoteType.Location = new System.Drawing.Point(6, 64);
            this.lblCreditNoteType.Name = "lblCreditNoteType";
            this.lblCreditNoteType.Size = new System.Drawing.Size(55, 14);
            this.lblCreditNoteType.TabIndex = 548;
            this.lblCreditNoteType.Text = "CRN Type";
            // 
            // txtCreditNoteID
            // 
            this.txtCreditNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCreditNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteID.Location = new System.Drawing.Point(96, 7);
            this.txtCreditNoteID.Name = "txtCreditNoteID";
            this.txtCreditNoteID.Size = new System.Drawing.Size(104, 22);
            this.txtCreditNoteID.TabIndex = 544;
            this.txtCreditNoteID.Text = "GN005";
            this.txtCreditNoteID.DoubleClick += new System.EventHandler(this.txtCreditNoteID_DoubleClick);
            this.txtCreditNoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditNoteID_KeyDown);
            // 
            // lblCerditNoteID
            // 
            this.lblCerditNoteID.AutoSize = true;
            this.lblCerditNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerditNoteID.ForeColor = System.Drawing.Color.Black;
            this.lblCerditNoteID.Location = new System.Drawing.Point(6, 11);
            this.lblCerditNoteID.Name = "lblCerditNoteID";
            this.lblCerditNoteID.Size = new System.Drawing.Size(48, 14);
            this.lblCerditNoteID.TabIndex = 545;
            this.lblCerditNoteID.Text = "CRN No.";
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(205, 11);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 543;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(213, 9);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 494;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // uC_ExchangeRate1
            // 
            this.uC_ExchangeRate1.Location = new System.Drawing.Point(-18, 238);
            this.uC_ExchangeRate1.Name = "uC_ExchangeRate1";
            this.uC_ExchangeRate1.Size = new System.Drawing.Size(308, 24);
            this.uC_ExchangeRate1.TabIndex = 451;
            this.uC_ExchangeRate1.ExRateChanged += new Digiteq.UC_ExchangeRate.valueChanged(this.uC_ExchangeRate1_ExRateChanged);
            // 
            // uC_DoubleEntry1
            // 
            this.uC_DoubleEntry1.Location = new System.Drawing.Point(4, 342);
            this.uC_DoubleEntry1.Name = "uC_DoubleEntry1";
            this.uC_DoubleEntry1.Size = new System.Drawing.Size(730, 169);
            this.uC_DoubleEntry1.TabIndex = 452;
            this.uC_DoubleEntry1.Clicked += new Digiteq.UC_DoubleEntry.Click(this.uC_DoubleEntry1_Clicked);
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
            this.uC_TotalCalc1.IsEnableAmounts = false;
            this.uC_TotalCalc1.IsNBTenable = false;
            this.uC_TotalCalc1.IsSubTotalEnable = true;
            this.uC_TotalCalc1.IsSvatEnable = false;
            this.uC_TotalCalc1.IsTaxPayable = false;
            this.uC_TotalCalc1.IsVatEnable = false;
            this.uC_TotalCalc1.Location = new System.Drawing.Point(420, 172);
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
            this.uC_TotalCalc1.Padding = new System.Windows.Forms.Padding(5);
            this.uC_TotalCalc1.Size = new System.Drawing.Size(313, 165);
            this.uC_TotalCalc1.SubTotal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.uC_TotalCalc1.TabIndex = 453;
            this.uC_TotalCalc1.VatPresentage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uC_TotalCalc1.DoubleEntryUpdataed += new Digiteq.UC_TotalCalc.valueChanged(this.uC_TotalCalc1_DoubleEntryUpdataed);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_Close);
            this.panel3.Controls.Add(this.rdoWriteOff);
            this.panel3.Controls.Add(this.rdoNormalSales);
            this.panel3.Location = new System.Drawing.Point(298, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 60);
            this.panel3.TabIndex = 593;
            this.panel3.Visible = false;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(166, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 28);
            this.btn_Close.TabIndex = 592;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            // 
            // rdoWriteOff
            // 
            this.rdoWriteOff.AutoSize = true;
            this.rdoWriteOff.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoWriteOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoWriteOff.Location = new System.Drawing.Point(8, 7);
            this.rdoWriteOff.Name = "rdoWriteOff";
            this.rdoWriteOff.Size = new System.Drawing.Size(148, 18);
            this.rdoWriteOff.TabIndex = 590;
            this.rdoWriteOff.TabStop = true;
            this.rdoWriteOff.Text = "Write-off Customer Dues";
            this.rdoWriteOff.UseVisualStyleBackColor = true;
            // 
            // rdoNormalSales
            // 
            this.rdoNormalSales.AutoSize = true;
            this.rdoNormalSales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoNormalSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoNormalSales.Location = new System.Drawing.Point(8, 31);
            this.rdoNormalSales.Name = "rdoNormalSales";
            this.rdoNormalSales.Size = new System.Drawing.Size(150, 18);
            this.rdoNormalSales.TabIndex = 591;
            this.rdoNormalSales.TabStop = true;
            this.rdoNormalSales.Text = "Normal Sales Credit Note";
            this.rdoNormalSales.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.xSetting);
            this.panel1.Controls.Add(this.txtBalanceAmount);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txtTotalAllocated);
            this.panel1.Controls.Add(this.dgvInvoice);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(420, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 163);
            this.panel1.TabIndex = 594;
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.Gainsboro;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.button1);
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.label3);
            this.xSetting.Location = new System.Drawing.Point(149, -1);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(163, 57);
            this.xSetting.TabIndex = 594;
            this.xSetting.Visible = false;
            this.xSetting.Leave += new System.EventHandler(this.xSetting_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(130, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 28);
            this.button1.TabIndex = 470;
            this.button1.Text = "";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkPrintOriginal
            // 
            this.chkPrintOriginal.AutoSize = true;
            this.chkPrintOriginal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPrintOriginal.Location = new System.Drawing.Point(29, 30);
            this.chkPrintOriginal.Name = "chkPrintOriginal";
            this.chkPrintOriginal.Size = new System.Drawing.Size(91, 18);
            this.chkPrintOriginal.TabIndex = 469;
            this.chkPrintOriginal.Text = "Print Original";
            this.chkPrintOriginal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 453;
            this.label3.Text = "Special Settings";
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtBalanceAmount.Enabled = false;
            this.txtBalanceAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceAmount.Location = new System.Drawing.Point(81, 136);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.Size = new System.Drawing.Size(100, 22);
            this.txtBalanceAmount.TabIndex = 21;
            this.txtBalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalAllocated
            // 
            this.txtTotalAllocated.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalAllocated.Enabled = false;
            this.txtTotalAllocated.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAllocated.Location = new System.Drawing.Point(185, 136);
            this.txtTotalAllocated.Name = "txtTotalAllocated";
            this.txtTotalAllocated.Size = new System.Drawing.Size(98, 22);
            this.txtTotalAllocated.TabIndex = 20;
            this.txtTotalAllocated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.OrderRefNo,
            this.InvoiceAmount,
            this.AllocatedAmount});
            this.dgvInvoice.EnableHeadersVisualStyles = false;
            this.dgvInvoice.Location = new System.Drawing.Point(8, 25);
            this.dgvInvoice.MultiSelect = false;
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(284, 107);
            this.dgvInvoice.TabIndex = 4;
            this.dgvInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellEndEdit);
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "Invoice No.";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            this.InvoiceID.Width = 80;
            // 
            // OrderRefNo
            // 
            this.OrderRefNo.HeaderText = "OrderRefNo.";
            this.OrderRefNo.Name = "OrderRefNo";
            this.OrderRefNo.Visible = false;
            // 
            // InvoiceAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InvoiceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceAmount.HeaderText = "Balance Amt";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
            // 
            // AllocatedAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AllocatedAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.AllocatedAmount.HeaderText = "Allocated Amount";
            this.AllocatedAmount.Name = "AllocatedAmount";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Digiteq.Properties.Resources.plus;
            this.btnAdd.Location = new System.Drawing.Point(237, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.Location = new System.Drawing.Point(263, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 22);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.plus;
            this.btnClear.Location = new System.Drawing.Point(237, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(22, 24);
            this.btnClear.TabIndex = 1;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 37);
            this.button2.TabIndex = 595;
            this.button2.Text = "update posting";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_bpsCreditNote2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uC_TotalCalc1);
            this.Controls.Add(this.uC_DoubleEntry1);
            this.Controls.Add(this.uC_ExchangeRate1);
            this.Controls.Add(this.z1);
            this.Name = "frm_bpsCreditNote2";
            this.Size = new System.Drawing.Size(738, 561);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCreditNote2_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.frm_bpsCreditNote2_Load);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.uC_ExchangeRate1, 0);
            this.Controls.SetChildIndex(this.uC_DoubleEntry1, 0);
            this.Controls.SetChildIndex(this.uC_TotalCalc1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label lblSalesNoteType;
        private System.Windows.Forms.TextBox txtSalesNoteType;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.DateTimePicker dtpCreditNoteDate;
        private System.Windows.Forms.Label lblCreditNoteDate;
        private System.Windows.Forms.TextBox txtOrderRefNo;
        private System.Windows.Forms.TextBox txtCreditNoteType;
        private System.Windows.Forms.Label lblOrderRefNo;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblCreditNoteType;
        private System.Windows.Forms.TextBox txtCreditNoteID;
        private System.Windows.Forms.Label lblCerditNoteID;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private UC_ExchangeRate uC_ExchangeRate1;
        private UC_DoubleEntry uC_DoubleEntry1;
        private UC_TotalCalc uC_TotalCalc1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.RadioButton rdoWriteOff;
        private System.Windows.Forms.RadioButton rdoNormalSales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.TextBox txtTotalAllocated;
        private SEACC_DataGrid dgvInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocatedAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}
