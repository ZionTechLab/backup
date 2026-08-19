namespace Digiteq
{
    partial class frm_accSupplierAccountpayableNote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.x1 = new System.Windows.Forms.Panel();
            this.uC_Supplier = new Digiteq.UC_Supplier();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.lblApnDate = new System.Windows.Forms.Label();
            this.txtAPNType = new System.Windows.Forms.TextBox();
            this.dtpAPNDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAPNNo = new System.Windows.Forms.Label();
            this.txtAPNID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_TotalCalc1 = new Digiteq.UC_TotalCalc();
            this.uC_DoubleEntry1 = new Digiteq.UC_DoubleEntry();
            this.lblJobDate = new System.Windows.Forms.Label();
            this.uC_ExchangeRate1 = new Digiteq.UC_ExchangeRate();
            this.x2 = new System.Windows.Forms.Panel();
            this.txtTotalUnsettled = new System.Windows.Forms.TextBox();
            this.txtTotalAllocated = new System.Windows.Forms.TextBox();
            this.dgvGRN = new System.Windows.Forms.DataGridView();
            this.GRNID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnsettledAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocatedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGRN = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDeliveryOrderID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAWB = new System.Windows.Forms.TextBox();
            this.txtCreditDays = new System.Windows.Forms.TextBox();
            this.lblDONo = new System.Windows.Forms.Label();
            this.txtNoteType = new System.Windows.Forms.TextBox();
            this.lblNoteType = new System.Windows.Forms.Label();
            this.xSetting = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.x1.SuspendLayout();
            this.x2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGRN)).BeginInit();
            this.panel1.SuspendLayout();
            this.xSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.Transparent;
            this.x1.Controls.Add(this.uC_Supplier);
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Controls.Add(this.label22);
            this.x1.Controls.Add(this.txtNarration);
            this.x1.Controls.Add(this.dtpBillDate);
            this.x1.Controls.Add(this.label10);
            this.x1.Controls.Add(this.lblApnDate);
            this.x1.Controls.Add(this.txtAPNType);
            this.x1.Controls.Add(this.dtpAPNDate);
            this.x1.Controls.Add(this.label3);
            this.x1.Controls.Add(this.lblAPNNo);
            this.x1.Controls.Add(this.txtAPNID);
            this.x1.Controls.Add(this.label11);
            this.x1.Controls.Add(this.txtBillNo);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(7, 7);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(352, 193);
            this.x1.TabIndex = 533;
            // 
            // uC_Supplier
            // 
            this.uC_Supplier.Location = new System.Drawing.Point(7, 80);
            this.uC_Supplier.Name = "uC_Supplier";
            this.uC_Supplier.Size = new System.Drawing.Size(359, 50);
            this.uC_Supplier.TabIndex = 550;
            this.uC_Supplier.SupplierChanged += new Digiteq.UC_Supplier.valueChanged(this.uC_Supplier1_SupplierChanged);
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(174, 10);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 546;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(177, 9);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 547;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(186, 60);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 14);
            this.label22.TabIndex = 544;
            this.label22.Text = "Bill Date";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(71, 131);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(270, 52);
            this.txtNarration.TabIndex = 536;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBillDate.Location = new System.Drawing.Point(241, 57);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(100, 22);
            this.dtpBillDate.TabIndex = 543;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 535;
            this.label10.Text = "Narration";
            // 
            // lblApnDate
            // 
            this.lblApnDate.AutoSize = true;
            this.lblApnDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApnDate.ForeColor = System.Drawing.Color.Black;
            this.lblApnDate.Location = new System.Drawing.Point(6, 34);
            this.lblApnDate.Name = "lblApnDate";
            this.lblApnDate.Size = new System.Drawing.Size(55, 14);
            this.lblApnDate.TabIndex = 462;
            this.lblApnDate.Text = "APN Date";
            // 
            // txtAPNType
            // 
            this.txtAPNType.BackColor = System.Drawing.Color.LightGray;
            this.txtAPNType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPNType.Location = new System.Drawing.Point(71, 52);
            this.txtAPNType.Name = "txtAPNType";
            this.txtAPNType.ReadOnly = true;
            this.txtAPNType.Size = new System.Drawing.Size(100, 22);
            this.txtAPNType.TabIndex = 545;
            this.txtAPNType.DoubleClick += new System.EventHandler(this.txtAPNType_DoubleClick);
            // 
            // dtpAPNDate
            // 
            this.dtpAPNDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAPNDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAPNDate.Location = new System.Drawing.Point(71, 30);
            this.dtpAPNDate.Name = "dtpAPNDate";
            this.dtpAPNDate.Size = new System.Drawing.Size(100, 22);
            this.dtpAPNDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 462;
            this.label3.Text = "PV Type";
            // 
            // lblAPNNo
            // 
            this.lblAPNNo.AutoSize = true;
            this.lblAPNNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPNNo.ForeColor = System.Drawing.Color.Black;
            this.lblAPNNo.Location = new System.Drawing.Point(6, 9);
            this.lblAPNNo.Name = "lblAPNNo";
            this.lblAPNNo.Size = new System.Drawing.Size(48, 14);
            this.lblAPNNo.TabIndex = 458;
            this.lblAPNNo.Text = "APN No.";
            // 
            // txtAPNID
            // 
            this.txtAPNID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAPNID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPNID.Location = new System.Drawing.Point(71, 5);
            this.txtAPNID.Name = "txtAPNID";
            this.txtAPNID.Size = new System.Drawing.Size(100, 22);
            this.txtAPNID.TabIndex = 0;
            this.txtAPNID.DoubleClick += new System.EventHandler(this.txtAPNID_DoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(186, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "Bill #";
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtBillNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(241, 30);
            this.txtBillNo.Multiline = true;
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(100, 22);
            this.txtBillNo.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(365, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 215);
            this.panel2.TabIndex = 592;
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
            this.uC_TotalCalc1.IsEnableAmounts = true;
            this.uC_TotalCalc1.IsNBTenable = false;
            this.uC_TotalCalc1.IsSubTotalEnable = false;
            this.uC_TotalCalc1.IsSvatEnable = false;
            this.uC_TotalCalc1.IsTaxPayable = true;
            this.uC_TotalCalc1.IsVatEnable = false;
            this.uC_TotalCalc1.Location = new System.Drawing.Point(375, 201);
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
            this.uC_TotalCalc1.Size = new System.Drawing.Size(426, 165);
            this.uC_TotalCalc1.SubTotal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.uC_TotalCalc1.TabIndex = 593;
            this.uC_TotalCalc1.VatPresentage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uC_TotalCalc1.DoubleEntryUpdataed += new Digiteq.UC_TotalCalc.valueChanged(this.uC_TotalCalc1_DoubleEntryUpdataed);
            // 
            // uC_DoubleEntry1
            // 
            this.uC_DoubleEntry1.Location = new System.Drawing.Point(7, 374);
            this.uC_DoubleEntry1.Name = "uC_DoubleEntry1";
            this.uC_DoubleEntry1.Size = new System.Drawing.Size(793, 177);
            this.uC_DoubleEntry1.TabIndex = 594;
            this.uC_DoubleEntry1.Clicked += new Digiteq.UC_DoubleEntry.Click(this.uC_DoubleEntry1_Clicked);
            // 
            // lblJobDate
            // 
            this.lblJobDate.AutoSize = true;
            this.lblJobDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobDate.ForeColor = System.Drawing.Color.Black;
            this.lblJobDate.Location = new System.Drawing.Point(6, 34);
            this.lblJobDate.Name = "lblJobDate";
            this.lblJobDate.Size = new System.Drawing.Size(55, 14);
            this.lblJobDate.TabIndex = 462;
            this.lblJobDate.Text = "APN Date";
            // 
            // uC_ExchangeRate1
            // 
            this.uC_ExchangeRate1.Location = new System.Drawing.Point(7, 206);
            this.uC_ExchangeRate1.Name = "uC_ExchangeRate1";
            this.uC_ExchangeRate1.Size = new System.Drawing.Size(308, 24);
            this.uC_ExchangeRate1.TabIndex = 595;
            this.uC_ExchangeRate1.ExRateChanged += new Digiteq.UC_ExchangeRate.valueChanged(this.uC_ExchangeRate1_ExRateChanged);
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.x2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2.Controls.Add(this.txtTotalUnsettled);
            this.x2.Controls.Add(this.txtTotalAllocated);
            this.x2.Controls.Add(this.dgvGRN);
            this.x2.Controls.Add(this.txtGRN);
            this.x2.Controls.Add(this.btnClear);
            this.x2.Controls.Add(this.btnRemove);
            this.x2.Controls.Add(this.label31);
            this.x2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x2.Location = new System.Drawing.Point(375, 7);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(425, 187);
            this.x2.TabIndex = 596;
            // 
            // txtTotalUnsettled
            // 
            this.txtTotalUnsettled.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalUnsettled.Enabled = false;
            this.txtTotalUnsettled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalUnsettled.Location = new System.Drawing.Point(246, 5);
            this.txtTotalUnsettled.Name = "txtTotalUnsettled";
            this.txtTotalUnsettled.Size = new System.Drawing.Size(84, 22);
            this.txtTotalUnsettled.TabIndex = 21;
            this.txtTotalUnsettled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalAllocated
            // 
            this.txtTotalAllocated.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalAllocated.Enabled = false;
            this.txtTotalAllocated.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAllocated.Location = new System.Drawing.Point(333, 5);
            this.txtTotalAllocated.Name = "txtTotalAllocated";
            this.txtTotalAllocated.Size = new System.Drawing.Size(79, 22);
            this.txtTotalAllocated.TabIndex = 20;
            this.txtTotalAllocated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvGRN
            // 
            this.dgvGRN.AllowUserToAddRows = false;
            this.dgvGRN.AllowUserToDeleteRows = false;
            this.dgvGRN.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvGRN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGRN.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvGRN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GRNID,
            this.ItemCode,
            this.ItemName,
            this.UnsettledAmount,
            this.AllocatedAmount});
            this.dgvGRN.EnableHeadersVisualStyles = false;
            this.dgvGRN.Location = new System.Drawing.Point(6, 31);
            this.dgvGRN.MultiSelect = false;
            this.dgvGRN.Name = "dgvGRN";
            this.dgvGRN.RowHeadersVisible = false;
            this.dgvGRN.RowTemplate.Height = 18;
            this.dgvGRN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvGRN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGRN.Size = new System.Drawing.Size(409, 151);
            this.dgvGRN.TabIndex = 4;
            this.dgvGRN.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGRN_CellEndEdit);
            // 
            // GRNID
            // 
            this.GRNID.DataPropertyName = "GRNID";
            this.GRNID.HeaderText = "GRN No.";
            this.GRNID.Name = "GRNID";
            this.GRNID.ReadOnly = true;
            this.GRNID.Width = 70;
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "ItemCode";
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 75;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // UnsettledAmount
            // 
            this.UnsettledAmount.DataPropertyName = "UnsettledAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.UnsettledAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.UnsettledAmount.HeaderText = "Unsettled Amt";
            this.UnsettledAmount.Name = "UnsettledAmount";
            this.UnsettledAmount.ReadOnly = true;
            this.UnsettledAmount.Width = 80;
            // 
            // AllocatedAmount
            // 
            this.AllocatedAmount.DataPropertyName = "AllocatedAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.AllocatedAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.AllocatedAmount.HeaderText = "Allocated Amt.";
            this.AllocatedAmount.Name = "AllocatedAmount";
            this.AllocatedAmount.Width = 80;
            // 
            // txtGRN
            // 
            this.txtGRN.BackColor = System.Drawing.Color.LightGray;
            this.txtGRN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGRN.Location = new System.Drawing.Point(65, 5);
            this.txtGRN.Name = "txtGRN";
            this.txtGRN.ReadOnly = true;
            this.txtGRN.Size = new System.Drawing.Size(127, 22);
            this.txtGRN.TabIndex = 536;
            this.txtGRN.DoubleClick += new System.EventHandler(this.txtGRN_DoubleClick);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.Location = new System.Drawing.Point(195, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(22, 22);
            this.btnClear.TabIndex = 1;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.Location = new System.Drawing.Point(220, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 22);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label31.Location = new System.Drawing.Point(5, 9);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 14);
            this.label31.TabIndex = 5;
            this.label31.Text = "GRN No.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDeliveryOrderID);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtLCNo);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtAWB);
            this.panel1.Controls.Add(this.txtCreditDays);
            this.panel1.Controls.Add(this.lblDONo);
            this.panel1.Location = new System.Drawing.Point(7, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 62);
            this.panel1.TabIndex = 599;
            // 
            // txtDeliveryOrderID
            // 
            this.txtDeliveryOrderID.BackColor = System.Drawing.SystemColors.Window;
            this.txtDeliveryOrderID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryOrderID.Location = new System.Drawing.Point(77, 5);
            this.txtDeliveryOrderID.Name = "txtDeliveryOrderID";
            this.txtDeliveryOrderID.Size = new System.Drawing.Size(81, 22);
            this.txtDeliveryOrderID.TabIndex = 539;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Location = new System.Drawing.Point(164, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 14);
            this.label15.TabIndex = 12;
            this.label15.Text = "AWB/BL #";
            // 
            // txtLCNo
            // 
            this.txtLCNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLCNo.Location = new System.Drawing.Point(77, 32);
            this.txtLCNo.Multiline = true;
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(81, 22);
            this.txtLCNo.TabIndex = 536;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label21.Location = new System.Drawing.Point(168, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 14);
            this.label21.TabIndex = 541;
            this.label21.Text = "Credit Days";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label12.Location = new System.Drawing.Point(29, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 14);
            this.label12.TabIndex = 10;
            this.label12.Text = "L/C #";
            // 
            // txtAWB
            // 
            this.txtAWB.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAWB.Location = new System.Drawing.Point(234, 3);
            this.txtAWB.Multiline = true;
            this.txtAWB.Name = "txtAWB";
            this.txtAWB.Size = new System.Drawing.Size(104, 22);
            this.txtAWB.TabIndex = 540;
            // 
            // txtCreditDays
            // 
            this.txtCreditDays.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditDays.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCreditDays.Location = new System.Drawing.Point(234, 32);
            this.txtCreditDays.Multiline = true;
            this.txtCreditDays.Name = "txtCreditDays";
            this.txtCreditDays.Size = new System.Drawing.Size(104, 22);
            this.txtCreditDays.TabIndex = 542;
            this.txtCreditDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDONo
            // 
            this.lblDONo.AutoSize = true;
            this.lblDONo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDONo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDONo.Location = new System.Drawing.Point(29, 9);
            this.lblDONo.Name = "lblDONo";
            this.lblDONo.Size = new System.Drawing.Size(39, 15);
            this.lblDONo.TabIndex = 538;
            this.lblDONo.Text = "D/O #";
            // 
            // txtNoteType
            // 
            this.txtNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoteType.Location = new System.Drawing.Point(261, 253);
            this.txtNoteType.Name = "txtNoteType";
            this.txtNoteType.ReadOnly = true;
            this.txtNoteType.Size = new System.Drawing.Size(100, 22);
            this.txtNoteType.TabIndex = 598;
            // 
            // lblNoteType
            // 
            this.lblNoteType.AutoSize = true;
            this.lblNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblNoteType.Location = new System.Drawing.Point(200, 251);
            this.lblNoteType.Name = "lblNoteType";
            this.lblNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblNoteType.TabIndex = 597;
            this.lblNoteType.Text = "Note Type";
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.Gainsboro;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.button1);
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.label1);
            this.xSetting.Location = new System.Drawing.Point(637, 0);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(163, 57);
            this.xSetting.TabIndex = 595;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 453;
            this.label1.Text = "Special Settings";
            // 
            // frm_accSupplierAccountpayableNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xSetting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtNoteType);
            this.Controls.Add(this.lblNoteType);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.uC_ExchangeRate1);
            this.Controls.Add(this.uC_DoubleEntry1);
            this.Controls.Add(this.uC_TotalCalc1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.x1);
            this.Name = "frm_accSupplierAccountpayableNote";
            this.Size = new System.Drawing.Size(809, 608);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accAccountpayableNote_NEW_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.frm_accAccountpayableNote_NEW_Load);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.uC_TotalCalc1, 0);
            this.Controls.SetChildIndex(this.uC_DoubleEntry1, 0);
            this.Controls.SetChildIndex(this.uC_ExchangeRate1, 0);
            this.Controls.SetChildIndex(this.x2, 0);
            this.Controls.SetChildIndex(this.lblNoteType, 0);
            this.Controls.SetChildIndex(this.txtNoteType, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.xSetting, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGRN)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.TextBox txtAPNType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblApnDate;
        private System.Windows.Forms.DateTimePicker dtpAPNDate;
        private System.Windows.Forms.Label lblAPNNo;
        private System.Windows.Forms.TextBox txtAPNID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Panel panel2;
        private UC_TotalCalc uC_TotalCalc1;
        private UC_Supplier uC_Supplier;
        private UC_DoubleEntry uC_DoubleEntry1;
        private System.Windows.Forms.Label lblJobDate;
        private UC_ExchangeRate uC_ExchangeRate1;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.TextBox txtTotalUnsettled;
        private System.Windows.Forms.TextBox txtTotalAllocated;
        private System.Windows.Forms.DataGridView dgvGRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRNID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnsettledAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocatedAmount;
        private System.Windows.Forms.TextBox txtGRN;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDeliveryOrderID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAWB;
        private System.Windows.Forms.TextBox txtCreditDays;
        private System.Windows.Forms.Label lblDONo;
        private System.Windows.Forms.TextBox txtNoteType;
        private System.Windows.Forms.Label lblNoteType;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
        private System.Windows.Forms.Label label1;
    }
}
