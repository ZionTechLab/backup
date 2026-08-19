namespace Digiteq
{
    partial class frm_rpt_BillsRegisterReports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoSalesReceiptDetails = new System.Windows.Forms.RadioButton();
            this.rdoDebitNoteDetails = new System.Windows.Forms.RadioButton();
            this.rdoCreditNoteDetail = new System.Windows.Forms.RadioButton();
            this.rdoRecieptSummary = new System.Windows.Forms.RadioButton();
            this.rdoRecieptSummary_Account = new System.Windows.Forms.RadioButton();
            this.rdoDebitNote = new System.Windows.Forms.RadioButton();
            this.rdoCrediteNote = new System.Windows.Forms.RadioButton();
            this.rdoRecieptSummary_Sales = new System.Windows.Forms.RadioButton();
            this.cmbReceiptType = new System.Windows.Forms.ComboBox();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.chkCheckedrecOnly = new System.Windows.Forms.CheckBox();
            this.chkUseCustomerMastorSaleRep = new System.Windows.Forms.CheckBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.rdoActual = new System.Windows.Forms.RadioButton();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.txtCreditNoteType = new System.Windows.Forms.TextBox();
            this.pnlDateRange = new System.Windows.Forms.Panel();
            this.chkCheque = new System.Windows.Forms.CheckBox();
            this.lblCreditNoteType = new System.Windows.Forms.Label();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.lblReceiptType = new System.Windows.Forms.Label();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReports = new SEACC_DataGrid();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.x1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlDateRange.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(97, 10);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(172, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(5, 15);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(93, 10);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(172, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Period To :";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(93, 37);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(172, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoSalesReceiptDetails);
            this.x1.Controls.Add(this.rdoDebitNoteDetails);
            this.x1.Controls.Add(this.rdoCreditNoteDetail);
            this.x1.Controls.Add(this.rdoRecieptSummary);
            this.x1.Controls.Add(this.rdoRecieptSummary_Account);
            this.x1.Controls.Add(this.rdoDebitNote);
            this.x1.Controls.Add(this.rdoCrediteNote);
            this.x1.Controls.Add(this.rdoRecieptSummary_Sales);
            this.x1.Location = new System.Drawing.Point(266, 16);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(46, 113);
            this.x1.TabIndex = 5;
            // 
            // rdoSalesReceiptDetails
            // 
            this.rdoSalesReceiptDetails.AutoSize = true;
            this.rdoSalesReceiptDetails.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSalesReceiptDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSalesReceiptDetails.Location = new System.Drawing.Point(16, 84);
            this.rdoSalesReceiptDetails.Name = "rdoSalesReceiptDetails";
            this.rdoSalesReceiptDetails.Size = new System.Drawing.Size(129, 18);
            this.rdoSalesReceiptDetails.TabIndex = 35;
            this.rdoSalesReceiptDetails.TabStop = true;
            this.rdoSalesReceiptDetails.Text = "Sales Receipt Details";
            this.rdoSalesReceiptDetails.UseVisualStyleBackColor = true;
            // 
            // rdoDebitNoteDetails
            // 
            this.rdoDebitNoteDetails.AutoSize = true;
            this.rdoDebitNoteDetails.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDebitNoteDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDebitNoteDetails.Location = new System.Drawing.Point(16, 84);
            this.rdoDebitNoteDetails.Name = "rdoDebitNoteDetails";
            this.rdoDebitNoteDetails.Size = new System.Drawing.Size(117, 18);
            this.rdoDebitNoteDetails.TabIndex = 34;
            this.rdoDebitNoteDetails.TabStop = true;
            this.rdoDebitNoteDetails.Text = "Debit Note Details";
            this.rdoDebitNoteDetails.UseVisualStyleBackColor = true;
            // 
            // rdoCreditNoteDetail
            // 
            this.rdoCreditNoteDetail.AutoSize = true;
            this.rdoCreditNoteDetail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCreditNoteDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCreditNoteDetail.Location = new System.Drawing.Point(16, 36);
            this.rdoCreditNoteDetail.Name = "rdoCreditNoteDetail";
            this.rdoCreditNoteDetail.Size = new System.Drawing.Size(119, 18);
            this.rdoCreditNoteDetail.TabIndex = 33;
            this.rdoCreditNoteDetail.TabStop = true;
            this.rdoCreditNoteDetail.Text = "Credit Note Details";
            this.rdoCreditNoteDetail.UseVisualStyleBackColor = true;
            // 
            // rdoRecieptSummary
            // 
            this.rdoRecieptSummary.AutoSize = true;
            this.rdoRecieptSummary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRecieptSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoRecieptSummary.Location = new System.Drawing.Point(16, 12);
            this.rdoRecieptSummary.Name = "rdoRecieptSummary";
            this.rdoRecieptSummary.Size = new System.Drawing.Size(137, 18);
            this.rdoRecieptSummary.TabIndex = 32;
            this.rdoRecieptSummary.TabStop = true;
            this.rdoRecieptSummary.Text = "Receipt Summary (All)";
            this.rdoRecieptSummary.UseVisualStyleBackColor = true;
            // 
            // rdoRecieptSummary_Account
            // 
            this.rdoRecieptSummary_Account.AutoSize = true;
            this.rdoRecieptSummary_Account.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRecieptSummary_Account.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoRecieptSummary_Account.Location = new System.Drawing.Point(16, 60);
            this.rdoRecieptSummary_Account.Name = "rdoRecieptSummary_Account";
            this.rdoRecieptSummary_Account.Size = new System.Drawing.Size(160, 18);
            this.rdoRecieptSummary_Account.TabIndex = 31;
            this.rdoRecieptSummary_Account.TabStop = true;
            this.rdoRecieptSummary_Account.Text = "Reciept Summary (Interim)";
            // 
            // rdoDebitNote
            // 
            this.rdoDebitNote.AutoSize = true;
            this.rdoDebitNote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDebitNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDebitNote.Location = new System.Drawing.Point(16, 60);
            this.rdoDebitNote.Name = "rdoDebitNote";
            this.rdoDebitNote.Size = new System.Drawing.Size(130, 18);
            this.rdoDebitNote.TabIndex = 30;
            this.rdoDebitNote.TabStop = true;
            this.rdoDebitNote.Text = "Debit Note Summary";
            this.rdoDebitNote.UseVisualStyleBackColor = true;
            // 
            // rdoCrediteNote
            // 
            this.rdoCrediteNote.AutoSize = true;
            this.rdoCrediteNote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCrediteNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCrediteNote.Location = new System.Drawing.Point(16, 12);
            this.rdoCrediteNote.Name = "rdoCrediteNote";
            this.rdoCrediteNote.Size = new System.Drawing.Size(132, 18);
            this.rdoCrediteNote.TabIndex = 29;
            this.rdoCrediteNote.TabStop = true;
            this.rdoCrediteNote.Text = "Credit Note Summary";
            this.rdoCrediteNote.UseVisualStyleBackColor = true;
            // 
            // rdoRecieptSummary_Sales
            // 
            this.rdoRecieptSummary_Sales.AutoSize = true;
            this.rdoRecieptSummary_Sales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRecieptSummary_Sales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoRecieptSummary_Sales.Location = new System.Drawing.Point(16, 36);
            this.rdoRecieptSummary_Sales.Name = "rdoRecieptSummary_Sales";
            this.rdoRecieptSummary_Sales.Size = new System.Drawing.Size(150, 18);
            this.rdoRecieptSummary_Sales.TabIndex = 28;
            this.rdoRecieptSummary_Sales.TabStop = true;
            this.rdoRecieptSummary_Sales.Text = "Receipt Summary (Sales)";
            this.rdoRecieptSummary_Sales.UseVisualStyleBackColor = true;
            // 
            // cmbReceiptType
            // 
            this.cmbReceiptType.ForeColor = System.Drawing.Color.Black;
            this.cmbReceiptType.FormattingEnabled = true;
            this.cmbReceiptType.Items.AddRange(new object[] {
            "All Payment",
            "Advanced Payment",
            "Part Payments"});
            this.cmbReceiptType.Location = new System.Drawing.Point(97, 65);
            this.cmbReceiptType.Name = "cmbReceiptType";
            this.cmbReceiptType.Size = new System.Drawing.Size(172, 22);
            this.cmbReceiptType.TabIndex = 33;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.Controls.Add(this.chkShowAll);
            this.pnlFilter.Controls.Add(this.chkCheckedrecOnly);
            this.pnlFilter.Controls.Add(this.chkUseCustomerMastorSaleRep);
            this.pnlFilter.Controls.Add(this.rdoAll);
            this.pnlFilter.Controls.Add(this.lblCustomerType);
            this.pnlFilter.Controls.Add(this.rdoActual);
            this.pnlFilter.Controls.Add(this.rdoDeleted);
            this.pnlFilter.Controls.Add(this.cmbCustomerType);
            this.pnlFilter.Controls.Add(this.txtCreditNoteType);
            this.pnlFilter.Controls.Add(this.pnlDateRange);
            this.pnlFilter.Controls.Add(this.chkCheque);
            this.pnlFilter.Controls.Add(this.lblCreditNoteType);
            this.pnlFilter.Controls.Add(this.chkCash);
            this.pnlFilter.Controls.Add(this.lblReceiptType);
            this.pnlFilter.Controls.Add(this.cmbReceiptType);
            this.pnlFilter.Controls.Add(this.txtSalesRep);
            this.pnlFilter.Controls.Add(this.lblSalseRep);
            this.pnlFilter.Controls.Add(this.txtCustomer);
            this.pnlFilter.Controls.Add(this.lblCustomer);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlFilter.Location = new System.Drawing.Point(334, 29);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(346, 421);
            this.pnlFilter.TabIndex = 6;
//            this.pnlFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFilter_Paint);
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.ForeColor = System.Drawing.Color.Black;
            this.chkShowAll.Location = new System.Drawing.Point(274, 12);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(69, 18);
            this.chkShowAll.TabIndex = 558;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            // 
            // chkCheckedrecOnly
            // 
            this.chkCheckedrecOnly.AutoSize = true;
            this.chkCheckedrecOnly.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkCheckedrecOnly.ForeColor = System.Drawing.Color.Black;
            this.chkCheckedrecOnly.Location = new System.Drawing.Point(97, 269);
            this.chkCheckedrecOnly.Name = "chkCheckedrecOnly";
            this.chkCheckedrecOnly.Size = new System.Drawing.Size(135, 18);
            this.chkCheckedrecOnly.TabIndex = 548;
            this.chkCheckedrecOnly.Text = "Checked Records Only";
            this.chkCheckedrecOnly.UseVisualStyleBackColor = true;
            // 
            // chkUseCustomerMastorSaleRep
            // 
            this.chkUseCustomerMastorSaleRep.AutoSize = true;
            this.chkUseCustomerMastorSaleRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkUseCustomerMastorSaleRep.ForeColor = System.Drawing.Color.Black;
            this.chkUseCustomerMastorSaleRep.Location = new System.Drawing.Point(97, 173);
            this.chkUseCustomerMastorSaleRep.Name = "chkUseCustomerMastorSaleRep";
            this.chkUseCustomerMastorSaleRep.Size = new System.Drawing.Size(198, 18);
            this.chkUseCustomerMastorSaleRep.TabIndex = 548;
            this.chkUseCustomerMastorSaleRep.Text = "Use Customer Master Sales Person";
            this.chkUseCustomerMastorSaleRep.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.Black;
            this.rdoAll.Location = new System.Drawing.Point(97, 330);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(80, 18);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerType.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerType.Location = new System.Drawing.Point(5, 96);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(81, 14);
            this.lblCustomerType.TabIndex = 16;
            this.lblCustomerType.Text = "Customer Type";
            // 
            // rdoActual
            // 
            this.rdoActual.AutoSize = true;
            this.rdoActual.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActual.ForeColor = System.Drawing.Color.Black;
            this.rdoActual.Location = new System.Drawing.Point(97, 310);
            this.rdoActual.Name = "rdoActual";
            this.rdoActual.Size = new System.Drawing.Size(124, 18);
            this.rdoActual.TabIndex = 10;
            this.rdoActual.Text = "Active Records Only";
            this.rdoActual.UseVisualStyleBackColor = true;
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeleted.ForeColor = System.Drawing.Color.Black;
            this.rdoDeleted.Location = new System.Drawing.Point(97, 290);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(132, 18);
            this.rdoDeleted.TabIndex = 9;
            this.rdoDeleted.Text = "Deleted Records Only";
            this.rdoDeleted.UseVisualStyleBackColor = true;
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(97, 93);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(172, 22);
            this.cmbCustomerType.TabIndex = 15;
            // 
            // txtCreditNoteType
            // 
            this.txtCreditNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtCreditNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteType.Location = new System.Drawing.Point(97, 121);
            this.txtCreditNoteType.Name = "txtCreditNoteType";
            this.txtCreditNoteType.ReadOnly = true;
            this.txtCreditNoteType.Size = new System.Drawing.Size(172, 22);
            this.txtCreditNoteType.TabIndex = 547;
            this.txtCreditNoteType.DoubleClick += new System.EventHandler(this.txtCreditNoteType_DoubleClick);
            this.txtCreditNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditNoteType_KeyDown);
            // 
            // pnlDateRange
            // 
            this.pnlDateRange.BackColor = System.Drawing.Color.LightGray;
            this.pnlDateRange.Controls.Add(this.label1);
            this.pnlDateRange.Controls.Add(this.dtpFrom);
            this.pnlDateRange.Controls.Add(this.dtpTo);
            this.pnlDateRange.Controls.Add(this.label2);
            this.pnlDateRange.Location = new System.Drawing.Point(3, 192);
            this.pnlDateRange.Name = "pnlDateRange";
            this.pnlDateRange.Size = new System.Drawing.Size(326, 71);
            this.pnlDateRange.TabIndex = 38;
            // 
            // chkCheque
            // 
            this.chkCheque.AutoSize = true;
            this.chkCheque.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheque.ForeColor = System.Drawing.Color.Black;
            this.chkCheque.Location = new System.Drawing.Point(161, 151);
            this.chkCheque.Name = "chkCheque";
            this.chkCheque.Size = new System.Drawing.Size(62, 18);
            this.chkCheque.TabIndex = 14;
            this.chkCheque.Text = "Cheque";
            this.chkCheque.UseVisualStyleBackColor = true;
            // 
            // lblCreditNoteType
            // 
            this.lblCreditNoteType.AutoSize = true;
            this.lblCreditNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNoteType.Location = new System.Drawing.Point(5, 124);
            this.lblCreditNoteType.Name = "lblCreditNoteType";
            this.lblCreditNoteType.Size = new System.Drawing.Size(90, 14);
            this.lblCreditNoteType.TabIndex = 467;
            this.lblCreditNoteType.Text = "Credit Note Type";
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCash.ForeColor = System.Drawing.Color.Black;
            this.chkCash.Location = new System.Drawing.Point(97, 151);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(54, 18);
            this.chkCash.TabIndex = 13;
            this.chkCash.Text = "Other";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // lblReceiptType
            // 
            this.lblReceiptType.AutoSize = true;
            this.lblReceiptType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptType.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptType.Location = new System.Drawing.Point(5, 68);
            this.lblReceiptType.Name = "lblReceiptType";
            this.lblReceiptType.Size = new System.Drawing.Size(71, 14);
            this.lblReceiptType.TabIndex = 465;
            this.lblReceiptType.Text = "Receipt Type";
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(97, 37);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(172, 22);
            this.txtSalesRep.TabIndex = 461;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            this.txtSalesRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesRep_KeyDown);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.Black;
            this.lblSalseRep.Location = new System.Drawing.Point(5, 40);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(82, 14);
            this.lblSalseRep.TabIndex = 462;
            this.lblSalseRep.Text = "Salesman Code";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(592, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 475;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(514, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(11, 6);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(495, 25);
            this.ProgressBar.TabIndex = 486;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvReports);
            this.pnlGrid.Controls.Add(this.x1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(3, 29);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(331, 421);
            this.pnlGrid.TabIndex = 487;
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AllowUserToResizeColumns = false;
            this.dgvReports.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReports.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.ColumnHeadersVisible = false;
            this.dgvReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.report_ID,
            this.sortOrder,
            this.reportName,
            this.displayName});
            this.dgvReports.Location = new System.Drawing.Point(4, 8);
            this.dgvReports.MultiSelect = false;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvReports.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvReports.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dgvReports.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(321, 404);
            this.dgvReports.TabIndex = 485;
            this.dgvReports.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellClick);
            this.dgvReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellContentClick);
            // 
            // report_ID
            // 
            this.report_ID.DataPropertyName = "report_ID";
            this.report_ID.HeaderText = "report_ID";
            this.report_ID.Name = "report_ID";
            this.report_ID.ReadOnly = true;
            this.report_ID.Width = 60;
            // 
            // sortOrder
            // 
            this.sortOrder.DataPropertyName = "sortOrder";
            this.sortOrder.HeaderText = "sortOrder";
            this.sortOrder.Name = "sortOrder";
            this.sortOrder.ReadOnly = true;
            this.sortOrder.Visible = false;
            this.sortOrder.Width = 40;
            // 
            // reportName
            // 
            this.reportName.DataPropertyName = "reportName";
            this.reportName.HeaderText = "reportName";
            this.reportName.Name = "reportName";
            this.reportName.ReadOnly = true;
            this.reportName.Visible = false;
            this.reportName.Width = 150;
            // 
            // displayName
            // 
            this.displayName.DataPropertyName = "displayName";
            this.displayName.HeaderText = "displayName";
            this.displayName.Name = "displayName";
            this.displayName.ReadOnly = true;
            this.displayName.Width = 310;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnPrint);
            this.pnlButton.Controls.Add(this.btnClear);
            this.pnlButton.Controls.Add(this.ProgressBar);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(3, 450);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(677, 37);
            this.pnlButton.TabIndex = 488;
            // 
            // frm_rpt_BillsRegisterReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 490);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlButton);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_BillsRegisterReports";
            this.Text = "Bills Register Reports";
            this.Load += new System.EventHandler(this.frm_rpt_BankManagementReports_Load);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlDateRange.ResumeLayout(false);
            this.pnlDateRange.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlDateRange;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoActual;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.RadioButton rdoRecieptSummary;
        private System.Windows.Forms.RadioButton rdoRecieptSummary_Account;
        private System.Windows.Forms.RadioButton rdoDebitNote;
        private System.Windows.Forms.RadioButton rdoCrediteNote;
        private System.Windows.Forms.RadioButton rdoRecieptSummary_Sales;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.ComboBox cmbReceiptType;
        private System.Windows.Forms.Label lblCreditNoteType;
        private System.Windows.Forms.Label lblReceiptType;
        private System.Windows.Forms.TextBox txtCreditNoteType;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.CheckBox chkCheque;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox chkUseCustomerMastorSaleRep;
        private System.Windows.Forms.CheckBox chkCheckedrecOnly;
        private System.Windows.Forms.RadioButton rdoSalesReceiptDetails;
        private System.Windows.Forms.RadioButton rdoDebitNoteDetails;
        private System.Windows.Forms.RadioButton rdoCreditNoteDetail;
        private System.Windows.Forms.Panel pnlGrid;
        private SEACC_DataGrid dgvReports;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.CheckBox chkShowAll;
    }
}