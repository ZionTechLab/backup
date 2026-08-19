namespace SEACC_Report
{
    partial class frm_rpt_StockCustom_Reports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoSalesReturnSummary = new System.Windows.Forms.RadioButton();
            this.rdoSalesReturn = new System.Windows.Forms.RadioButton();
            this.rdbQuataionDetails = new System.Windows.Forms.RadioButton();
            this.rdbPerformanceSummery = new System.Windows.Forms.RadioButton();
            this.rdbProformDet = new System.Windows.Forms.RadioButton();
            this.rdoInvoiceDetail = new System.Windows.Forms.RadioButton();
            this.rdoInvoiceSummary = new System.Windows.Forms.RadioButton();
            this.rdbQuatationSummery = new System.Windows.Forms.RadioButton();
            this.rdoDeliveryDetail = new System.Windows.Forms.RadioButton();
            this.rdoDeliverySummary = new System.Windows.Forms.RadioButton();
            this.rdoPendingInquiryOrderDetail = new System.Windows.Forms.RadioButton();
            this.rdoCustomerOrderSummery = new System.Windows.Forms.RadioButton();
            this.rdoCustomerOrderDetail = new System.Windows.Forms.RadioButton();
            this.rdoPendingInquiryOrderSummery = new System.Windows.Forms.RadioButton();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlToDate = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFromDate = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBranch = new System.Windows.Forms.Panel();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.pnlItemName = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.pnlItemCategory = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlStore = new System.Windows.Forms.Panel();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkShowDeactivate = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkTransactionValidateEnable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.chkProduction = new System.Windows.Forms.CheckBox();
            this.chkSales = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlShowAllBranch = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.x1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlToDate.SuspendLayout();
            this.pnlFromDate.SuspendLayout();
            this.pnlBranch.SuspendLayout();
            this.pnlItemName.SuspendLayout();
            this.pnlItemCategory.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlStore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlShowAllBranch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Location = new System.Drawing.Point(234, 0);
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoSalesReturnSummary);
            this.x1.Controls.Add(this.rdoSalesReturn);
            this.x1.Controls.Add(this.rdbQuataionDetails);
            this.x1.Controls.Add(this.rdbPerformanceSummery);
            this.x1.Controls.Add(this.rdbProformDet);
            this.x1.Controls.Add(this.rdoInvoiceDetail);
            this.x1.Controls.Add(this.rdoInvoiceSummary);
            this.x1.Controls.Add(this.rdbQuatationSummery);
            this.x1.Controls.Add(this.rdoDeliveryDetail);
            this.x1.Controls.Add(this.rdoDeliverySummary);
            this.x1.Controls.Add(this.rdoPendingInquiryOrderDetail);
            this.x1.Controls.Add(this.rdoCustomerOrderSummery);
            this.x1.Controls.Add(this.rdoCustomerOrderDetail);
            this.x1.Controls.Add(this.rdoPendingInquiryOrderSummery);
            this.x1.Location = new System.Drawing.Point(298, 17);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(20, 42);
            this.x1.TabIndex = 5;
            // 
            // rdoSalesReturnSummary
            // 
            this.rdoSalesReturnSummary.AutoSize = true;
            this.rdoSalesReturnSummary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSalesReturnSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSalesReturnSummary.Location = new System.Drawing.Point(23, 172);
            this.rdoSalesReturnSummary.Name = "rdoSalesReturnSummary";
            this.rdoSalesReturnSummary.Size = new System.Drawing.Size(138, 18);
            this.rdoSalesReturnSummary.TabIndex = 29;
            this.rdoSalesReturnSummary.TabStop = true;
            this.rdoSalesReturnSummary.Text = "Sales Return Summary";
            this.rdoSalesReturnSummary.UseVisualStyleBackColor = true;
            // 
            // rdoSalesReturn
            // 
            this.rdoSalesReturn.AutoSize = true;
            this.rdoSalesReturn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSalesReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSalesReturn.Location = new System.Drawing.Point(23, 196);
            this.rdoSalesReturn.Name = "rdoSalesReturn";
            this.rdoSalesReturn.Size = new System.Drawing.Size(120, 18);
            this.rdoSalesReturn.TabIndex = 28;
            this.rdoSalesReturn.TabStop = true;
            this.rdoSalesReturn.Text = "Sales Return Detail";
            this.rdoSalesReturn.UseVisualStyleBackColor = true;
            // 
            // rdbQuataionDetails
            // 
            this.rdbQuataionDetails.AutoSize = true;
            this.rdbQuataionDetails.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbQuataionDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdbQuataionDetails.Location = new System.Drawing.Point(188, 36);
            this.rdbQuataionDetails.Name = "rdbQuataionDetails";
            this.rdbQuataionDetails.Size = new System.Drawing.Size(112, 18);
            this.rdbQuataionDetails.TabIndex = 25;
            this.rdbQuataionDetails.TabStop = true;
            this.rdbQuataionDetails.Text = "Quotation Details";
            this.rdbQuataionDetails.UseVisualStyleBackColor = true;
            // 
            // rdbPerformanceSummery
            // 
            this.rdbPerformanceSummery.AutoSize = true;
            this.rdbPerformanceSummery.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPerformanceSummery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdbPerformanceSummery.Location = new System.Drawing.Point(356, 12);
            this.rdbPerformanceSummery.Name = "rdbPerformanceSummery";
            this.rdbPerformanceSummery.Size = new System.Drawing.Size(160, 18);
            this.rdbPerformanceSummery.TabIndex = 22;
            this.rdbPerformanceSummery.TabStop = true;
            this.rdbPerformanceSummery.Text = "Proforma Invoice Summary";
            this.rdbPerformanceSummery.UseVisualStyleBackColor = true;
            // 
            // rdbProformDet
            // 
            this.rdbProformDet.AutoSize = true;
            this.rdbProformDet.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProformDet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdbProformDet.Location = new System.Drawing.Point(356, 38);
            this.rdbProformDet.Name = "rdbProformDet";
            this.rdbProformDet.Size = new System.Drawing.Size(147, 18);
            this.rdbProformDet.TabIndex = 24;
            this.rdbProformDet.TabStop = true;
            this.rdbProformDet.Text = "Proforma Invoice Details";
            this.rdbProformDet.UseVisualStyleBackColor = true;
            // 
            // rdoInvoiceDetail
            // 
            this.rdoInvoiceDetail.AutoSize = true;
            this.rdoInvoiceDetail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvoiceDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoInvoiceDetail.Location = new System.Drawing.Point(356, 120);
            this.rdoInvoiceDetail.Name = "rdoInvoiceDetail";
            this.rdoInvoiceDetail.Size = new System.Drawing.Size(93, 18);
            this.rdoInvoiceDetail.TabIndex = 17;
            this.rdoInvoiceDetail.TabStop = true;
            this.rdoInvoiceDetail.Text = "Invoice Detail";
            this.rdoInvoiceDetail.UseVisualStyleBackColor = true;
            // 
            // rdoInvoiceSummary
            // 
            this.rdoInvoiceSummary.AutoSize = true;
            this.rdoInvoiceSummary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvoiceSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoInvoiceSummary.Location = new System.Drawing.Point(356, 94);
            this.rdoInvoiceSummary.Name = "rdoInvoiceSummary";
            this.rdoInvoiceSummary.Size = new System.Drawing.Size(111, 18);
            this.rdoInvoiceSummary.TabIndex = 16;
            this.rdoInvoiceSummary.TabStop = true;
            this.rdoInvoiceSummary.Text = "Invoice Summary";
            this.rdoInvoiceSummary.UseVisualStyleBackColor = true;
            // 
            // rdbQuatationSummery
            // 
            this.rdbQuatationSummery.AutoSize = true;
            this.rdbQuatationSummery.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbQuatationSummery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdbQuatationSummery.Location = new System.Drawing.Point(188, 12);
            this.rdbQuatationSummery.Name = "rdbQuatationSummery";
            this.rdbQuatationSummery.Size = new System.Drawing.Size(125, 18);
            this.rdbQuatationSummery.TabIndex = 23;
            this.rdbQuatationSummery.TabStop = true;
            this.rdbQuatationSummery.Text = "Quotation Summary";
            this.rdbQuatationSummery.UseVisualStyleBackColor = true;
            // 
            // rdoDeliveryDetail
            // 
            this.rdoDeliveryDetail.AutoSize = true;
            this.rdoDeliveryDetail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeliveryDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDeliveryDetail.Location = new System.Drawing.Point(188, 120);
            this.rdoDeliveryDetail.Name = "rdoDeliveryDetail";
            this.rdoDeliveryDetail.Size = new System.Drawing.Size(131, 18);
            this.rdoDeliveryDetail.TabIndex = 15;
            this.rdoDeliveryDetail.TabStop = true;
            this.rdoDeliveryDetail.Text = "Delivery Order Detail";
            this.rdoDeliveryDetail.UseVisualStyleBackColor = true;
            // 
            // rdoDeliverySummary
            // 
            this.rdoDeliverySummary.AutoSize = true;
            this.rdoDeliverySummary.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeliverySummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDeliverySummary.Location = new System.Drawing.Point(188, 94);
            this.rdoDeliverySummary.Name = "rdoDeliverySummary";
            this.rdoDeliverySummary.Size = new System.Drawing.Size(152, 18);
            this.rdoDeliverySummary.TabIndex = 14;
            this.rdoDeliverySummary.TabStop = true;
            this.rdoDeliverySummary.Text = "Delivery Order  Summary";
            this.rdoDeliverySummary.UseVisualStyleBackColor = true;
            // 
            // rdoPendingInquiryOrderDetail
            // 
            this.rdoPendingInquiryOrderDetail.AutoSize = true;
            this.rdoPendingInquiryOrderDetail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingInquiryOrderDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingInquiryOrderDetail.Location = new System.Drawing.Point(23, 38);
            this.rdoPendingInquiryOrderDetail.Name = "rdoPendingInquiryOrderDetail";
            this.rdoPendingInquiryOrderDetail.Size = new System.Drawing.Size(92, 18);
            this.rdoPendingInquiryOrderDetail.TabIndex = 13;
            this.rdoPendingInquiryOrderDetail.TabStop = true;
            this.rdoPendingInquiryOrderDetail.Text = "Inquiry Detail";
            this.rdoPendingInquiryOrderDetail.UseVisualStyleBackColor = true;
            // 
            // rdoCustomerOrderSummery
            // 
            this.rdoCustomerOrderSummery.AutoSize = true;
            this.rdoCustomerOrderSummery.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomerOrderSummery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCustomerOrderSummery.Location = new System.Drawing.Point(23, 94);
            this.rdoCustomerOrderSummery.Name = "rdoCustomerOrderSummery";
            this.rdoCustomerOrderSummery.Size = new System.Drawing.Size(131, 18);
            this.rdoCustomerOrderSummery.TabIndex = 10;
            this.rdoCustomerOrderSummery.TabStop = true;
            this.rdoCustomerOrderSummery.Text = "Cust. Order Summary";
            this.rdoCustomerOrderSummery.UseVisualStyleBackColor = true;
            // 
            // rdoCustomerOrderDetail
            // 
            this.rdoCustomerOrderDetail.AutoSize = true;
            this.rdoCustomerOrderDetail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomerOrderDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCustomerOrderDetail.Location = new System.Drawing.Point(23, 120);
            this.rdoCustomerOrderDetail.Name = "rdoCustomerOrderDetail";
            this.rdoCustomerOrderDetail.Size = new System.Drawing.Size(113, 18);
            this.rdoCustomerOrderDetail.TabIndex = 12;
            this.rdoCustomerOrderDetail.TabStop = true;
            this.rdoCustomerOrderDetail.Text = "Cust. Order Detail";
            this.rdoCustomerOrderDetail.UseVisualStyleBackColor = true;
            // 
            // rdoPendingInquiryOrderSummery
            // 
            this.rdoPendingInquiryOrderSummery.AutoSize = true;
            this.rdoPendingInquiryOrderSummery.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPendingInquiryOrderSummery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPendingInquiryOrderSummery.Location = new System.Drawing.Point(23, 12);
            this.rdoPendingInquiryOrderSummery.Name = "rdoPendingInquiryOrderSummery";
            this.rdoPendingInquiryOrderSummery.Size = new System.Drawing.Size(110, 18);
            this.rdoPendingInquiryOrderSummery.TabIndex = 11;
            this.rdoPendingInquiryOrderSummery.TabStop = true;
            this.rdoPendingInquiryOrderSummery.Text = "Inquiry Summary";
            this.rdoPendingInquiryOrderSummery.UseVisualStyleBackColor = true;
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AllowUserToResizeColumns = false;
            this.dgvReports.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
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
            this.dgvReports.Location = new System.Drawing.Point(5, 6);
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
            this.dgvReports.Size = new System.Drawing.Size(314, 406);
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
            this.report_ID.Width = 50;
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
            this.displayName.Width = 280;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvReports);
            this.pnlGrid.Controls.Add(this.x1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(1, 1);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(325, 451);
            this.pnlGrid.TabIndex = 486;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.panel2);
            this.pnlButton.Controls.Add(this.btnClear);
            this.pnlButton.Controls.Add(this.ProgressBar);
            this.pnlButton.Controls.Add(this.btnPrint);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(1, 452);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(647, 42);
            this.pnlButton.TabIndex = 487;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 2);
            this.panel2.TabIndex = 588;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(484, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 486;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(5, 9);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(476, 25);
            this.ProgressBar.TabIndex = 487;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(562, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 485;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlToDate
            // 
            this.pnlToDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlToDate.Controls.Add(this.dtpTo);
            this.pnlToDate.Controls.Add(this.label2);
            this.pnlToDate.Location = new System.Drawing.Point(0, 173);
            this.pnlToDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlToDate.Name = "pnlToDate";
            this.pnlToDate.Size = new System.Drawing.Size(343, 30);
            this.pnlToDate.TabIndex = 587;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(104, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(162, 22);
            this.dtpTo.TabIndex = 584;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 585;
            this.label2.Text = "Period To :";
            // 
            // pnlFromDate
            // 
            this.pnlFromDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlFromDate.Controls.Add(this.dtpFrom);
            this.pnlFromDate.Controls.Add(this.label1);
            this.pnlFromDate.Location = new System.Drawing.Point(0, 143);
            this.pnlFromDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFromDate.Name = "pnlFromDate";
            this.pnlFromDate.Size = new System.Drawing.Size(343, 30);
            this.pnlFromDate.TabIndex = 586;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(104, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(162, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period From :";
            // 
            // pnlBranch
            // 
            this.pnlBranch.Controls.Add(this.txtBranch);
            this.pnlBranch.Controls.Add(this.lblBranch);
            this.pnlBranch.Location = new System.Drawing.Point(0, 91);
            this.pnlBranch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBranch.Name = "pnlBranch";
            this.pnlBranch.Size = new System.Drawing.Size(343, 27);
            this.pnlBranch.TabIndex = 591;
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.LightGray;
            this.txtBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(104, 2);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(196, 22);
            this.txtBranch.TabIndex = 579;
            this.txtBranch.DoubleClick += new System.EventHandler(this.txtBranch_DoubleClick);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.Black;
            this.lblBranch.Location = new System.Drawing.Point(2, 6);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(90, 14);
            this.lblBranch.TabIndex = 580;
            this.lblBranch.Text = "Company Branch";
            // 
            // pnlItemName
            // 
            this.pnlItemName.Controls.Add(this.label4);
            this.pnlItemName.Controls.Add(this.txtItemName);
            this.pnlItemName.Location = new System.Drawing.Point(0, 64);
            this.pnlItemName.Margin = new System.Windows.Forms.Padding(0);
            this.pnlItemName.Name = "pnlItemName";
            this.pnlItemName.Size = new System.Drawing.Size(343, 27);
            this.pnlItemName.TabIndex = 596;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Item Name";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.LightGray;
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(104, 2);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(196, 22);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.DoubleClick += new System.EventHandler(this.txtItemName_DoubleClick);
            // 
            // pnlItemCategory
            // 
            this.pnlItemCategory.Controls.Add(this.label3);
            this.pnlItemCategory.Controls.Add(this.txtItemCategory);
            this.pnlItemCategory.Location = new System.Drawing.Point(0, 37);
            this.pnlItemCategory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlItemCategory.Name = "pnlItemCategory";
            this.pnlItemCategory.Size = new System.Drawing.Size(343, 27);
            this.pnlItemCategory.TabIndex = 595;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Item Category";
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.Location = new System.Drawing.Point(104, 2);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.ReadOnly = true;
            this.txtItemCategory.Size = new System.Drawing.Size(196, 22);
            this.txtItemCategory.TabIndex = 0;
            this.txtItemCategory.DoubleClick += new System.EventHandler(this.txtItemCategory_DoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlStore);
            this.flowLayoutPanel1.Controls.Add(this.pnlItemCategory);
            this.flowLayoutPanel1.Controls.Add(this.pnlItemName);
            this.flowLayoutPanel1.Controls.Add(this.pnlBranch);
            this.flowLayoutPanel1.Controls.Add(this.pnlShowAllBranch);
            this.flowLayoutPanel1.Controls.Add(this.pnlFromDate);
            this.flowLayoutPanel1.Controls.Add(this.pnlToDate);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(326, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(322, 451);
            this.flowLayoutPanel1.TabIndex = 596;
            // 
            // pnlStore
            // 
            this.pnlStore.Controls.Add(this.txtStore);
            this.pnlStore.Controls.Add(this.lblStore);
            this.pnlStore.Location = new System.Drawing.Point(0, 10);
            this.pnlStore.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStore.Name = "pnlStore";
            this.pnlStore.Size = new System.Drawing.Size(343, 27);
            this.pnlStore.TabIndex = 589;
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.LightGray;
            this.txtStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStore.Location = new System.Drawing.Point(104, 2);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(196, 22);
            this.txtStore.TabIndex = 554;
            this.txtStore.DoubleClick += new System.EventHandler(this.txtStore_DoubleClick);
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNoteType_KeyDown);
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.ForeColor = System.Drawing.Color.Black;
            this.lblStore.Location = new System.Drawing.Point(2, 6);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(33, 14);
            this.lblStore.TabIndex = 555;
            this.lblStore.Text = "Store";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 203);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 25);
            this.panel1.TabIndex = 597;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(104, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(141, 18);
            this.checkBox1.TabIndex = 595;
            this.checkBox1.Text = "Show Deactivate Items";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkShowDeactivate);
            this.panel3.Controls.Add(this.checkBox2);
            this.panel3.Location = new System.Drawing.Point(5, 24);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 25);
            this.panel3.TabIndex = 594;
            // 
            // chkShowDeactivate
            // 
            this.chkShowDeactivate.AutoSize = true;
            this.chkShowDeactivate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowDeactivate.ForeColor = System.Drawing.Color.Black;
            this.chkShowDeactivate.Location = new System.Drawing.Point(101, 3);
            this.chkShowDeactivate.Name = "chkShowDeactivate";
            this.chkShowDeactivate.Size = new System.Drawing.Size(141, 18);
            this.chkShowDeactivate.TabIndex = 594;
            this.chkShowDeactivate.Text = "Show Deactivate Items";
            this.chkShowDeactivate.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(104, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(126, 18);
            this.checkBox2.TabIndex = 593;
            this.checkBox2.Text = "Show All Branches";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkTransactionValidateEnable);
            this.panel4.Location = new System.Drawing.Point(0, 228);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(343, 25);
            this.panel4.TabIndex = 594;
            // 
            // chkTransactionValidateEnable
            // 
            this.chkTransactionValidateEnable.AutoSize = true;
            this.chkTransactionValidateEnable.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkTransactionValidateEnable.ForeColor = System.Drawing.Color.Black;
            this.chkTransactionValidateEnable.Location = new System.Drawing.Point(104, 3);
            this.chkTransactionValidateEnable.Name = "chkTransactionValidateEnable";
            this.chkTransactionValidateEnable.Size = new System.Drawing.Size(150, 18);
            this.chkTransactionValidateEnable.TabIndex = 469;
            this.chkTransactionValidateEnable.Text = "Show Only Moving Items";
            this.chkTransactionValidateEnable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(2, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 475;
            this.label5.Text = "Module";
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Checked = true;
            this.chkStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkStock.ForeColor = System.Drawing.Color.Black;
            this.chkStock.Location = new System.Drawing.Point(169, 3);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(53, 18);
            this.chkStock.TabIndex = 476;
            this.chkStock.Text = "Stock";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // chkProduction
            // 
            this.chkProduction.AutoSize = true;
            this.chkProduction.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkProduction.ForeColor = System.Drawing.Color.Black;
            this.chkProduction.Location = new System.Drawing.Point(222, 3);
            this.chkProduction.Name = "chkProduction";
            this.chkProduction.Size = new System.Drawing.Size(78, 18);
            this.chkProduction.TabIndex = 477;
            this.chkProduction.Text = "Production";
            this.chkProduction.UseVisualStyleBackColor = true;
            // 
            // chkSales
            // 
            this.chkSales.AutoSize = true;
            this.chkSales.Checked = true;
            this.chkSales.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSales.ForeColor = System.Drawing.Color.Black;
            this.chkSales.Location = new System.Drawing.Point(104, 3);
            this.chkSales.Name = "chkSales";
            this.chkSales.Size = new System.Drawing.Size(52, 18);
            this.chkSales.TabIndex = 478;
            this.chkSales.Text = "Sales";
            this.chkSales.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkSales);
            this.panel5.Controls.Add(this.chkProduction);
            this.panel5.Controls.Add(this.chkStock);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(0, 253);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(343, 25);
            this.panel5.TabIndex = 598;
            // 
            // pnlShowAllBranch
            // 
            this.pnlShowAllBranch.Controls.Add(this.chkShowAll);
            this.pnlShowAllBranch.Location = new System.Drawing.Point(0, 118);
            this.pnlShowAllBranch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShowAllBranch.Name = "pnlShowAllBranch";
            this.pnlShowAllBranch.Size = new System.Drawing.Size(343, 25);
            this.pnlShowAllBranch.TabIndex = 593;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.ForeColor = System.Drawing.Color.Black;
            this.chkShowAll.Location = new System.Drawing.Point(104, 3);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(126, 18);
            this.chkShowAll.TabIndex = 593;
            this.chkShowAll.Text = "Show All Branches";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // frm_rpt_StockCustom_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(649, 495);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlButton);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_StockCustom_Reports";
            this.Text = "Stock Report Customized";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.pnlToDate.ResumeLayout(false);
            this.pnlToDate.PerformLayout();
            this.pnlFromDate.ResumeLayout(false);
            this.pnlFromDate.PerformLayout();
            this.pnlBranch.ResumeLayout(false);
            this.pnlBranch.PerformLayout();
            this.pnlItemName.ResumeLayout(false);
            this.pnlItemName.PerformLayout();
            this.pnlItemCategory.ResumeLayout(false);
            this.pnlItemCategory.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlStore.ResumeLayout(false);
            this.pnlStore.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlShowAllBranch.ResumeLayout(false);
            this.pnlShowAllBranch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.RadioButton rdoPendingInquiryOrderSummery;
        private System.Windows.Forms.RadioButton rdoCustomerOrderSummery;
        private System.Windows.Forms.RadioButton rdoPendingInquiryOrderDetail;
        private System.Windows.Forms.RadioButton rdoCustomerOrderDetail;
        private System.Windows.Forms.RadioButton rdoDeliveryDetail;
        private System.Windows.Forms.RadioButton rdoDeliverySummary;
        private System.Windows.Forms.RadioButton rdoInvoiceDetail;
        private System.Windows.Forms.RadioButton rdoInvoiceSummary;
        private System.Windows.Forms.RadioButton rdbQuataionDetails;
        private System.Windows.Forms.RadioButton rdbPerformanceSummery;
        private System.Windows.Forms.RadioButton rdbProformDet;
        private System.Windows.Forms.RadioButton rdbQuatationSummery;
        private System.Windows.Forms.RadioButton rdoSalesReturn;
        private System.Windows.Forms.RadioButton rdoSalesReturnSummary;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.Panel pnlToDate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFromDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBranch;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Panel pnlItemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Panel pnlItemCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlStore;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkShowDeactivate;
        private System.Windows.Forms.CheckBox chkTransactionValidateEnable;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkSales;
        private System.Windows.Forms.CheckBox chkProduction;
        private System.Windows.Forms.CheckBox chkStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlShowAllBranch;
        private System.Windows.Forms.CheckBox chkShowAll;
    }
}