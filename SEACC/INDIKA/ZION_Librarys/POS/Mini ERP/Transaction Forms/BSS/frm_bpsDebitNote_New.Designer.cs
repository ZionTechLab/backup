namespace Digiteq
{
    partial class frm_bpsDebitNote_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_bpsDebitNote_New));
            this.x1 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.dtpDabitNoteDate = new System.Windows.Forms.DateTimePicker();
            this.lblSalesNoteType = new System.Windows.Forms.Label();
            this.lblCreditNoteDate = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtSalesNoteType = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtOrderRefNo = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.btnCustomerViewer = new System.Windows.Forms.Button();
            this.txtDebitNoteType = new System.Windows.Forms.TextBox();
            this.lblOrderRefNo = new System.Windows.Forms.Label();
            this.txtDebitNoteID = new System.Windows.Forms.TextBox();
            this.lblDebitNoteID = new System.Windows.Forms.Label();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.lblCreditNoteType = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.btnPV = new System.Windows.Forms.Button();
            this.uC_ExchangeRate1 = new Digiteq.UC_ExchangeRate();
            this.uC_TotalCalc1 = new Digiteq.UC_TotalCalc();
            this.uC_DoubleEntry1 = new Digiteq.UC_DoubleEntry();
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.btnAddSRN = new System.Windows.Forms.Button();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.lblSalesReturnNoteID = new System.Windows.Forms.Label();
            this.txtSalesReturnNoteID = new System.Windows.Forms.TextBox();
            this.txtSalesExecutiveID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.x1.SuspendLayout();
            this.xpanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.White;
            this.x1.Controls.Add(this.txtRemark);
            this.x1.Controls.Add(this.dtpDabitNoteDate);
            this.x1.Controls.Add(this.lblSalesNoteType);
            this.x1.Controls.Add(this.lblCreditNoteDate);
            this.x1.Controls.Add(this.lblRemark);
            this.x1.Controls.Add(this.txtSalesNoteType);
            this.x1.Controls.Add(this.txtCustomerID);
            this.x1.Controls.Add(this.txtOrderRefNo);
            this.x1.Controls.Add(this.lblCustomerID);
            this.x1.Controls.Add(this.btnCustomerViewer);
            this.x1.Controls.Add(this.txtDebitNoteType);
            this.x1.Controls.Add(this.lblOrderRefNo);
            this.x1.Controls.Add(this.txtDebitNoteID);
            this.x1.Controls.Add(this.lblDebitNoteID);
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.lblCreditNoteType);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(8, 4);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(413, 182);
            this.x1.TabIndex = 563;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(62, 117);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(346, 55);
            this.txtRemark.TabIndex = 412;
            // 
            // dtpDabitNoteDate
            // 
            this.dtpDabitNoteDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDabitNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDabitNoteDate.Location = new System.Drawing.Point(63, 33);
            this.dtpDabitNoteDate.Name = "dtpDabitNoteDate";
            this.dtpDabitNoteDate.Size = new System.Drawing.Size(127, 22);
            this.dtpDabitNoteDate.TabIndex = 554;
            // 
            // lblSalesNoteType
            // 
            this.lblSalesNoteType.AutoSize = true;
            this.lblSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblSalesNoteType.Location = new System.Drawing.Point(196, 64);
            this.lblSalesNoteType.Name = "lblSalesNoteType";
            this.lblSalesNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblSalesNoteType.TabIndex = 561;
            this.lblSalesNoteType.Text = "Note Type";
            // 
            // lblCreditNoteDate
            // 
            this.lblCreditNoteDate.AutoSize = true;
            this.lblCreditNoteDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteDate.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNoteDate.Location = new System.Drawing.Point(5, 37);
            this.lblCreditNoteDate.Name = "lblCreditNoteDate";
            this.lblCreditNoteDate.Size = new System.Drawing.Size(57, 14);
            this.lblCreditNoteDate.TabIndex = 555;
            this.lblCreditNoteDate.Text = "DRN Date";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.ForeColor = System.Drawing.Color.Black;
            this.lblRemark.Location = new System.Drawing.Point(5, 120);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(51, 14);
            this.lblRemark.TabIndex = 413;
            this.lblRemark.Text = "Remarks";
            // 
            // txtSalesNoteType
            // 
            this.txtSalesNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesNoteType.Location = new System.Drawing.Point(270, 61);
            this.txtSalesNoteType.Name = "txtSalesNoteType";
            this.txtSalesNoteType.ReadOnly = true;
            this.txtSalesNoteType.Size = new System.Drawing.Size(138, 22);
            this.txtSalesNoteType.TabIndex = 560;
            this.txtSalesNoteType.DoubleClick += new System.EventHandler(this.txtSalesNoteType_DoubleClick);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(63, 89);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(311, 22);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.Text = "Asanka Jayasuriya";
            this.txtCustomerID.DoubleClick += new System.EventHandler(this.txtCustomerID_DoubleClick);
            // 
            // txtOrderRefNo
            // 
            this.txtOrderRefNo.BackColor = System.Drawing.Color.White;
            this.txtOrderRefNo.Enabled = false;
            this.txtOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderRefNo.Location = new System.Drawing.Point(270, 33);
            this.txtOrderRefNo.Name = "txtOrderRefNo";
            this.txtOrderRefNo.ReadOnly = true;
            this.txtOrderRefNo.Size = new System.Drawing.Size(138, 22);
            this.txtOrderRefNo.TabIndex = 547;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerID.Location = new System.Drawing.Point(5, 91);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(54, 14);
            this.lblCustomerID.TabIndex = 273;
            this.lblCustomerID.Text = "Customer";
            // 
            // btnCustomerViewer
            // 
            this.btnCustomerViewer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerViewer.Image = global::Digiteq.Properties.Resources.info;
            this.btnCustomerViewer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerViewer.Location = new System.Drawing.Point(380, 89);
            this.btnCustomerViewer.Name = "btnCustomerViewer";
            this.btnCustomerViewer.Size = new System.Drawing.Size(22, 22);
            this.btnCustomerViewer.TabIndex = 467;
            this.btnCustomerViewer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomerViewer.UseVisualStyleBackColor = true;
            this.btnCustomerViewer.Click += new System.EventHandler(this.btnCustomerViewer_Click);
            // 
            // txtDebitNoteType
            // 
            this.txtDebitNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtDebitNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitNoteType.Location = new System.Drawing.Point(63, 61);
            this.txtDebitNoteType.Name = "txtDebitNoteType";
            this.txtDebitNoteType.ReadOnly = true;
            this.txtDebitNoteType.Size = new System.Drawing.Size(127, 22);
            this.txtDebitNoteType.TabIndex = 546;
            this.txtDebitNoteType.DoubleClick += new System.EventHandler(this.txtDebitNoteType_DoubleClick);
            // 
            // lblOrderRefNo
            // 
            this.lblOrderRefNo.AutoSize = true;
            this.lblOrderRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRefNo.ForeColor = System.Drawing.Color.Gray;
            this.lblOrderRefNo.Location = new System.Drawing.Point(196, 37);
            this.lblOrderRefNo.Name = "lblOrderRefNo";
            this.lblOrderRefNo.Size = new System.Drawing.Size(68, 14);
            this.lblOrderRefNo.TabIndex = 549;
            this.lblOrderRefNo.Text = "Tracking No.";
            // 
            // txtDebitNoteID
            // 
            this.txtDebitNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtDebitNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitNoteID.Location = new System.Drawing.Point(63, 7);
            this.txtDebitNoteID.Name = "txtDebitNoteID";
            this.txtDebitNoteID.Size = new System.Drawing.Size(126, 22);
            this.txtDebitNoteID.TabIndex = 544;
            this.txtDebitNoteID.Text = "GN005";
            this.txtDebitNoteID.DoubleClick += new System.EventHandler(this.txtDebitNoteID_DoubleClick);
            // 
            // lblDebitNoteID
            // 
            this.lblDebitNoteID.AutoSize = true;
            this.lblDebitNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitNoteID.ForeColor = System.Drawing.Color.Black;
            this.lblDebitNoteID.Location = new System.Drawing.Point(5, 10);
            this.lblDebitNoteID.Name = "lblDebitNoteID";
            this.lblDebitNoteID.Size = new System.Drawing.Size(50, 14);
            this.lblDebitNoteID.TabIndex = 545;
            this.lblDebitNoteID.Text = "DRN No.";
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(195, 12);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 543;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // lblCreditNoteType
            // 
            this.lblCreditNoteType.AutoSize = true;
            this.lblCreditNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNoteType.Location = new System.Drawing.Point(5, 64);
            this.lblCreditNoteType.Name = "lblCreditNoteType";
            this.lblCreditNoteType.Size = new System.Drawing.Size(57, 14);
            this.lblCreditNoteType.TabIndex = 548;
            this.lblCreditNoteType.Text = "DRN Type";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(195, 11);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 494;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // btnPV
            // 
            this.btnPV.BackColor = System.Drawing.Color.LightGray;
            this.btnPV.FlatAppearance.BorderSize = 0;
            this.btnPV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPV.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPV.Image = ((System.Drawing.Image)(resources.GetObject("btnPV.Image")));
            this.btnPV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPV.Location = new System.Drawing.Point(289, 196);
            this.btnPV.Name = "btnPV";
            this.btnPV.Size = new System.Drawing.Size(130, 25);
            this.btnPV.TabIndex = 592;
            this.btnPV.Text = "      Payment Voucher";
            this.btnPV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPV.UseVisualStyleBackColor = false;
            this.btnPV.Visible = false;
            this.btnPV.Click += new System.EventHandler(this.btnPV_Click);
            // 
            // uC_ExchangeRate1
            // 
            this.uC_ExchangeRate1.Location = new System.Drawing.Point(-25, 197);
            this.uC_ExchangeRate1.Name = "uC_ExchangeRate1";
            this.uC_ExchangeRate1.Size = new System.Drawing.Size(308, 24);
            this.uC_ExchangeRate1.TabIndex = 593;
            this.uC_ExchangeRate1.ExRateChanged += new Digiteq.UC_ExchangeRate.valueChanged(this.uC_ExchangeRate1_ExRateChanged);
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
            this.uC_TotalCalc1.IsCredit = true;
            this.uC_TotalCalc1.IsDiscountEnable = false;
            this.uC_TotalCalc1.IsEnableAmounts = false;
            this.uC_TotalCalc1.IsNBTenable = false;
            this.uC_TotalCalc1.IsSubTotalEnable = true;
            this.uC_TotalCalc1.IsSvatEnable = false;
            this.uC_TotalCalc1.IsTaxPayable = false;
            this.uC_TotalCalc1.IsVatEnable = false;
            this.uC_TotalCalc1.Location = new System.Drawing.Point(434, 72);
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
            this.uC_TotalCalc1.Size = new System.Drawing.Size(310, 157);
            this.uC_TotalCalc1.SubTotal = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.uC_TotalCalc1.TabIndex = 595;
            this.uC_TotalCalc1.VatPresentage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uC_TotalCalc1.DoubleEntryUpdataed += new Digiteq.UC_TotalCalc.valueChanged(this.uC_TotalCalc1_DoubleEntryUpdataed);
            // 
            // uC_DoubleEntry1
            // 
            this.uC_DoubleEntry1.Location = new System.Drawing.Point(8, 234);
            this.uC_DoubleEntry1.Name = "uC_DoubleEntry1";
            this.uC_DoubleEntry1.Size = new System.Drawing.Size(736, 177);
            this.uC_DoubleEntry1.TabIndex = 596;
            this.uC_DoubleEntry1.Clicked += new Digiteq.UC_DoubleEntry.Click(this.uC_DoubleEntry1_Clicked);
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.Transparent;
            this.xpanel1.Controls.Add(this.lblInvoiceID);
            this.xpanel1.Controls.Add(this.txtInvoiceID);
            this.xpanel1.Controls.Add(this.btnAddSRN);
            this.xpanel1.Controls.Add(this.btnAddInvoice);
            this.xpanel1.Controls.Add(this.lblSalesReturnNoteID);
            this.xpanel1.Controls.Add(this.txtSalesReturnNoteID);
            this.xpanel1.Location = new System.Drawing.Point(434, 4);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(310, 65);
            this.xpanel1.TabIndex = 597;
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceID.Location = new System.Drawing.Point(3, 10);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(62, 14);
            this.lblInvoiceID.TabIndex = 499;
            this.lblInvoiceID.Text = "Invoice No.";
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.BackColor = System.Drawing.Color.LightGray;
            this.txtInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceID.Location = new System.Drawing.Point(65, 6);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.ReadOnly = true;
            this.txtInvoiceID.Size = new System.Drawing.Size(126, 22);
            this.txtInvoiceID.TabIndex = 496;
            this.txtInvoiceID.DoubleClick += new System.EventHandler(this.txtInvoiceID_DoubleClick);
            // 
            // btnAddSRN
            // 
            this.btnAddSRN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSRN.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddSRN.Location = new System.Drawing.Point(196, 33);
            this.btnAddSRN.Name = "btnAddSRN";
            this.btnAddSRN.Size = new System.Drawing.Size(22, 22);
            this.btnAddSRN.TabIndex = 557;
            this.btnAddSRN.UseVisualStyleBackColor = true;
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInvoice.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddInvoice.Location = new System.Drawing.Point(196, 6);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(22, 22);
            this.btnAddInvoice.TabIndex = 556;
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // lblSalesReturnNoteID
            // 
            this.lblSalesReturnNoteID.AutoSize = true;
            this.lblSalesReturnNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesReturnNoteID.ForeColor = System.Drawing.Color.Black;
            this.lblSalesReturnNoteID.Location = new System.Drawing.Point(3, 37);
            this.lblSalesReturnNoteID.Name = "lblSalesReturnNoteID";
            this.lblSalesReturnNoteID.Size = new System.Drawing.Size(48, 14);
            this.lblSalesReturnNoteID.TabIndex = 500;
            this.lblSalesReturnNoteID.Text = "SRN No.";
            // 
            // txtSalesReturnNoteID
            // 
            this.txtSalesReturnNoteID.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesReturnNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesReturnNoteID.Location = new System.Drawing.Point(65, 33);
            this.txtSalesReturnNoteID.Name = "txtSalesReturnNoteID";
            this.txtSalesReturnNoteID.ReadOnly = true;
            this.txtSalesReturnNoteID.Size = new System.Drawing.Size(126, 22);
            this.txtSalesReturnNoteID.TabIndex = 497;
            this.txtSalesReturnNoteID.DoubleClick += new System.EventHandler(this.txtSalesReturnNoteID_DoubleClick);
            // 
            // txtSalesExecutiveID
            // 
            this.txtSalesExecutiveID.Enabled = false;
            this.txtSalesExecutiveID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesExecutiveID.Location = new System.Drawing.Point(481, 200);
            this.txtSalesExecutiveID.Name = "txtSalesExecutiveID";
            this.txtSalesExecutiveID.ReadOnly = true;
            this.txtSalesExecutiveID.Size = new System.Drawing.Size(203, 22);
            this.txtSalesExecutiveID.TabIndex = 598;
            this.txtSalesExecutiveID.Text = "Jennifer Lopez";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.chkPrintOriginal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(581, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 57);
            this.panel1.TabIndex = 596;
            this.panel1.Visible = false;
            this.panel1.Leave += new System.EventHandler(this.panel1_Leave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(130, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 28);
            this.button2.TabIndex = 470;
            this.button2.Text = "";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // frm_bpsDebitNote_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uC_TotalCalc1);
            this.Controls.Add(this.txtSalesExecutiveID);
            this.Controls.Add(this.xpanel1);
            this.Controls.Add(this.uC_DoubleEntry1);
            this.Controls.Add(this.uC_ExchangeRate1);
            this.Controls.Add(this.btnPV);
            this.Controls.Add(this.x1);
            this.Name = "frm_bpsDebitNote_New";
            this.Size = new System.Drawing.Size(752, 459);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsDebitNote_New_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.frm_bpsDebitNote_New_Load);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.btnPV, 0);
            this.Controls.SetChildIndex(this.uC_ExchangeRate1, 0);
            this.Controls.SetChildIndex(this.uC_DoubleEntry1, 0);
            this.Controls.SetChildIndex(this.xpanel1, 0);
            this.Controls.SetChildIndex(this.txtSalesExecutiveID, 0);
            this.Controls.SetChildIndex(this.uC_TotalCalc1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.DateTimePicker dtpDabitNoteDate;
        private System.Windows.Forms.Label lblCreditNoteDate;
        private System.Windows.Forms.TextBox txtOrderRefNo;
        private System.Windows.Forms.TextBox txtDebitNoteType;
        private System.Windows.Forms.Label lblOrderRefNo;
        private System.Windows.Forms.TextBox txtDebitNoteID;
        private System.Windows.Forms.Label lblDebitNoteID;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.Label lblCreditNoteType;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Button btnPV;
        private UC_ExchangeRate uC_ExchangeRate1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Button btnCustomerViewer;
        private UC_TotalCalc uC_TotalCalc1;
        private UC_DoubleEntry uC_DoubleEntry1;
        private System.Windows.Forms.Panel xpanel1;
        private System.Windows.Forms.Label lblSalesNoteType;
        private System.Windows.Forms.TextBox txtSalesNoteType;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.Button btnAddSRN;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Label lblSalesReturnNoteID;
        private System.Windows.Forms.TextBox txtSalesReturnNoteID;
        private System.Windows.Forms.TextBox txtSalesExecutiveID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
        private System.Windows.Forms.Label label3;
    }
}
