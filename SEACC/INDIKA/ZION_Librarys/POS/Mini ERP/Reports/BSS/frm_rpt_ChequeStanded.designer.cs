namespace Digiteq
{
    partial class frm_rpt_ChequeStanded
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_ChequeStanded));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.txtCollector = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.chkCheque = new System.Windows.Forms.CheckBox();
            this.chkAllocationNumberWise = new System.Windows.Forms.CheckBox();
            this.chkUseCustomerMastorSaleRep = new System.Windows.Forms.CheckBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.chkAdvance = new System.Windows.Forms.CheckBox();
            this.chkPartPayment = new System.Windows.Forms.CheckBox();
            this.lblAllocationType = new System.Windows.Forms.Label();
            this.chkOverPayment = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoActual = new System.Windows.Forms.RadioButton();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.pnlSalesman = new System.Windows.Forms.Panel();
            this.pnlCollector = new System.Windows.Forms.Panel();
            this.pnlCurrency = new System.Windows.Forms.Panel();
            this.pnlType = new System.Windows.Forms.Panel();
            this.pnlUseCustomerMasterSalesPerson = new System.Windows.Forms.Panel();
            this.pnlAllocationNumWise = new System.Windows.Forms.Panel();
            this.pnlAlloType = new System.Windows.Forms.Panel();
            this.pnlAllRecords = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlSalesman.SuspendLayout();
            this.pnlCollector.SuspendLayout();
            this.pnlCurrency.SuspendLayout();
            this.pnlType.SuspendLayout();
            this.pnlUseCustomerMasterSalesPerson.SuspendLayout();
            this.pnlAllocationNumWise.SuspendLayout();
            this.pnlAlloType.SuspendLayout();
            this.pnlAllRecords.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.txtCustomer.Location = new System.Drawing.Point(107, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(199, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(3, 6);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(107, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(109, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(107, 30);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(109, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // txtCollector
            // 
            this.txtCollector.BackColor = System.Drawing.Color.LightGray;
            this.txtCollector.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollector.Location = new System.Drawing.Point(107, 2);
            this.txtCollector.Name = "txtCollector";
            this.txtCollector.ReadOnly = true;
            this.txtCollector.Size = new System.Drawing.Size(199, 22);
            this.txtCollector.TabIndex = 479;
            this.txtCollector.DoubleClick += new System.EventHandler(this.txtCollector_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 480;
            this.label1.Text = "Collector";
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCash.ForeColor = System.Drawing.Color.Black;
            this.chkCash.Location = new System.Drawing.Point(107, 2);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(56, 18);
            this.chkCash.TabIndex = 476;
            this.chkCash.Text = "Other";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // chkCheque
            // 
            this.chkCheque.AutoSize = true;
            this.chkCheque.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheque.ForeColor = System.Drawing.Color.Black;
            this.chkCheque.Location = new System.Drawing.Point(165, 2);
            this.chkCheque.Name = "chkCheque";
            this.chkCheque.Size = new System.Drawing.Size(67, 18);
            this.chkCheque.TabIndex = 477;
            this.chkCheque.Text = "Cheque";
            this.chkCheque.UseVisualStyleBackColor = true;
            // 
            // chkAllocationNumberWise
            // 
            this.chkAllocationNumberWise.AutoSize = true;
            this.chkAllocationNumberWise.Font = new System.Drawing.Font("Calibri", 9F);
            this.chkAllocationNumberWise.ForeColor = System.Drawing.Color.Black;
            this.chkAllocationNumberWise.Location = new System.Drawing.Point(107, 2);
            this.chkAllocationNumberWise.Name = "chkAllocationNumberWise";
            this.chkAllocationNumberWise.Size = new System.Drawing.Size(158, 18);
            this.chkAllocationNumberWise.TabIndex = 466;
            this.chkAllocationNumberWise.Text = "Allocation Number Wise";
            this.chkAllocationNumberWise.UseVisualStyleBackColor = true;
            // 
            // chkUseCustomerMastorSaleRep
            // 
            this.chkUseCustomerMastorSaleRep.AutoSize = true;
            this.chkUseCustomerMastorSaleRep.Location = new System.Drawing.Point(107, 2);
            this.chkUseCustomerMastorSaleRep.Name = "chkUseCustomerMastorSaleRep";
            this.chkUseCustomerMastorSaleRep.Size = new System.Drawing.Size(215, 18);
            this.chkUseCustomerMastorSaleRep.TabIndex = 472;
            this.chkUseCustomerMastorSaleRep.Text = "Use Customer Master Sales Person";
            this.chkUseCustomerMastorSaleRep.UseVisualStyleBackColor = true;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "<<All Currency>>",
            "Sri Lanka Rupee (LKR)",
            "American Dollar (USD)"});
            this.cmbCurrency.Location = new System.Drawing.Point(107, 2);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(133, 22);
            this.cmbCurrency.TabIndex = 464;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.ForeColor = System.Drawing.Color.Black;
            this.lblCurrency.Location = new System.Drawing.Point(3, 6);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(50, 14);
            this.lblCurrency.TabIndex = 463;
            this.lblCurrency.Text = "Currency";
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(107, 2);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(199, 22);
            this.txtSalesRep.TabIndex = 461;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.Black;
            this.lblSalseRep.Location = new System.Drawing.Point(3, 6);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(55, 14);
            this.lblSalseRep.TabIndex = 462;
            this.lblSalseRep.Text = "Salesman";
            // 
            // chkAdvance
            // 
            this.chkAdvance.AutoSize = true;
            this.chkAdvance.Location = new System.Drawing.Point(107, 2);
            this.chkAdvance.Name = "chkAdvance";
            this.chkAdvance.Size = new System.Drawing.Size(71, 18);
            this.chkAdvance.TabIndex = 465;
            this.chkAdvance.Text = "Advance";
            this.chkAdvance.UseVisualStyleBackColor = true;
            // 
            // chkPartPayment
            // 
            this.chkPartPayment.AutoSize = true;
            this.chkPartPayment.Location = new System.Drawing.Point(107, 25);
            this.chkPartPayment.Name = "chkPartPayment";
            this.chkPartPayment.Size = new System.Drawing.Size(96, 18);
            this.chkPartPayment.TabIndex = 466;
            this.chkPartPayment.Text = "Part Payment";
            this.chkPartPayment.UseVisualStyleBackColor = true;
            // 
            // lblAllocationType
            // 
            this.lblAllocationType.AutoSize = true;
            this.lblAllocationType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocationType.ForeColor = System.Drawing.Color.Black;
            this.lblAllocationType.Location = new System.Drawing.Point(3, 6);
            this.lblAllocationType.Name = "lblAllocationType";
            this.lblAllocationType.Size = new System.Drawing.Size(83, 14);
            this.lblAllocationType.TabIndex = 467;
            this.lblAllocationType.Text = "Allocation Type";
            // 
            // chkOverPayment
            // 
            this.chkOverPayment.AutoSize = true;
            this.chkOverPayment.Location = new System.Drawing.Point(107, 48);
            this.chkOverPayment.Name = "chkOverPayment";
            this.chkOverPayment.Size = new System.Drawing.Size(99, 18);
            this.chkOverPayment.TabIndex = 468;
            this.chkOverPayment.Text = "Over Payment";
            this.chkOverPayment.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(608, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 475;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(530, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(4, 7);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(523, 19);
            this.ProgressBar.TabIndex = 485;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.Black;
            this.rdoAll.Location = new System.Drawing.Point(268, 3);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(80, 18);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoActual
            // 
            this.rdoActual.AutoSize = true;
            this.rdoActual.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActual.ForeColor = System.Drawing.Color.Black;
            this.rdoActual.Location = new System.Drawing.Point(138, 3);
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
            this.rdoDeleted.Location = new System.Drawing.Point(3, 3);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(132, 18);
            this.rdoDeleted.TabIndex = 9;
            this.rdoDeleted.Text = "Deleted Records Only";
            this.rdoDeleted.UseVisualStyleBackColor = true;
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
            this.dgvReports.Location = new System.Drawing.Point(9, 35);
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
            this.dgvReports.Size = new System.Drawing.Size(321, 363);
            this.dgvReports.TabIndex = 487;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomer);
            this.flowLayoutPanel1.Controls.Add(this.pnlSalesman);
            this.flowLayoutPanel1.Controls.Add(this.pnlCollector);
            this.flowLayoutPanel1.Controls.Add(this.pnlCurrency);
            this.flowLayoutPanel1.Controls.Add(this.pnlType);
            this.flowLayoutPanel1.Controls.Add(this.pnlUseCustomerMasterSalesPerson);
            this.flowLayoutPanel1.Controls.Add(this.pnlAllocationNumWise);
            this.flowLayoutPanel1.Controls.Add(this.pnlAlloType);
            this.flowLayoutPanel1.Controls.Add(this.pnlAllRecords);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(336, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(358, 363);
            this.flowLayoutPanel1.TabIndex = 488;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.chkShowAll);
            this.pnlCustomer.Controls.Add(this.txtCustomer);
            this.pnlCustomer.Controls.Add(this.lblCustomer);
            this.pnlCustomer.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(355, 53);
            this.pnlCustomer.TabIndex = 590;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(107, 28);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(73, 18);
            this.chkShowAll.TabIndex = 558;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            // 
            // pnlSalesman
            // 
            this.pnlSalesman.Controls.Add(this.txtSalesRep);
            this.pnlSalesman.Controls.Add(this.lblSalseRep);
            this.pnlSalesman.Location = new System.Drawing.Point(0, 53);
            this.pnlSalesman.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesman.Name = "pnlSalesman";
            this.pnlSalesman.Size = new System.Drawing.Size(355, 27);
            this.pnlSalesman.TabIndex = 591;
            // 
            // pnlCollector
            // 
            this.pnlCollector.Controls.Add(this.txtCollector);
            this.pnlCollector.Controls.Add(this.label1);
            this.pnlCollector.Location = new System.Drawing.Point(0, 80);
            this.pnlCollector.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCollector.Name = "pnlCollector";
            this.pnlCollector.Size = new System.Drawing.Size(355, 27);
            this.pnlCollector.TabIndex = 591;
            // 
            // pnlCurrency
            // 
            this.pnlCurrency.Controls.Add(this.cmbCurrency);
            this.pnlCurrency.Controls.Add(this.lblCurrency);
            this.pnlCurrency.Location = new System.Drawing.Point(0, 107);
            this.pnlCurrency.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCurrency.Name = "pnlCurrency";
            this.pnlCurrency.Size = new System.Drawing.Size(355, 27);
            this.pnlCurrency.TabIndex = 591;
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.chkCash);
            this.pnlType.Controls.Add(this.chkCheque);
            this.pnlType.Location = new System.Drawing.Point(0, 134);
            this.pnlType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(355, 27);
            this.pnlType.TabIndex = 591;
            // 
            // pnlUseCustomerMasterSalesPerson
            // 
            this.pnlUseCustomerMasterSalesPerson.Controls.Add(this.chkUseCustomerMastorSaleRep);
            this.pnlUseCustomerMasterSalesPerson.Location = new System.Drawing.Point(0, 161);
            this.pnlUseCustomerMasterSalesPerson.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUseCustomerMasterSalesPerson.Name = "pnlUseCustomerMasterSalesPerson";
            this.pnlUseCustomerMasterSalesPerson.Size = new System.Drawing.Size(355, 27);
            this.pnlUseCustomerMasterSalesPerson.TabIndex = 591;
            // 
            // pnlAllocationNumWise
            // 
            this.pnlAllocationNumWise.Controls.Add(this.chkAllocationNumberWise);
            this.pnlAllocationNumWise.Location = new System.Drawing.Point(0, 188);
            this.pnlAllocationNumWise.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAllocationNumWise.Name = "pnlAllocationNumWise";
            this.pnlAllocationNumWise.Size = new System.Drawing.Size(355, 27);
            this.pnlAllocationNumWise.TabIndex = 591;
            // 
            // pnlAlloType
            // 
            this.pnlAlloType.Controls.Add(this.chkAdvance);
            this.pnlAlloType.Controls.Add(this.chkPartPayment);
            this.pnlAlloType.Controls.Add(this.chkOverPayment);
            this.pnlAlloType.Controls.Add(this.lblAllocationType);
            this.pnlAlloType.Location = new System.Drawing.Point(0, 215);
            this.pnlAlloType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAlloType.Name = "pnlAlloType";
            this.pnlAlloType.Size = new System.Drawing.Size(355, 70);
            this.pnlAlloType.TabIndex = 591;
            // 
            // pnlAllRecords
            // 
            this.pnlAllRecords.Controls.Add(this.rdoAll);
            this.pnlAllRecords.Controls.Add(this.rdoActual);
            this.pnlAllRecords.Controls.Add(this.rdoDeleted);
            this.pnlAllRecords.Location = new System.Drawing.Point(0, 285);
            this.pnlAllRecords.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAllRecords.Name = "pnlAllRecords";
            this.pnlAllRecords.Size = new System.Drawing.Size(355, 27);
            this.pnlAllRecords.TabIndex = 592;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pnlDate);
            this.panel8.Location = new System.Drawing.Point(0, 312);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(355, 64);
            this.panel8.TabIndex = 591;
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDate.Controls.Add(this.label2);
            this.pnlDate.Controls.Add(this.dtpTo);
            this.pnlDate.Controls.Add(this.dtpFrom);
            this.pnlDate.Controls.Add(this.label3);
            this.pnlDate.Location = new System.Drawing.Point(2, 1);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(353, 60);
            this.pnlDate.TabIndex = 587;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Period From :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 585;
            this.label3.Text = "Period To :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.ProgressBar);
            this.panel1.Location = new System.Drawing.Point(9, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 37);
            this.panel1.TabIndex = 489;
            // 
            // frm_rpt_ChequeStanded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgvReports);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_ChequeStanded";
            this.Text = "Bills Standard Reports";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.dgvReports, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlSalesman.ResumeLayout(false);
            this.pnlSalesman.PerformLayout();
            this.pnlCollector.ResumeLayout(false);
            this.pnlCollector.PerformLayout();
            this.pnlCurrency.ResumeLayout(false);
            this.pnlCurrency.PerformLayout();
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            this.pnlUseCustomerMasterSalesPerson.ResumeLayout(false);
            this.pnlUseCustomerMasterSalesPerson.PerformLayout();
            this.pnlAllocationNumWise.ResumeLayout(false);
            this.pnlAllocationNumWise.PerformLayout();
            this.pnlAlloType.ResumeLayout(false);
            this.pnlAlloType.PerformLayout();
            this.pnlAllRecords.ResumeLayout(false);
            this.pnlAllRecords.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox chkOverPayment;
        private System.Windows.Forms.Label lblAllocationType;
        private System.Windows.Forms.CheckBox chkPartPayment;
        private System.Windows.Forms.CheckBox chkAdvance;
        private System.Windows.Forms.CheckBox chkUseCustomerMastorSaleRep;
        private System.Windows.Forms.CheckBox chkAllocationNumberWise;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoActual;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.CheckBox chkCheque;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.TextBox txtCollector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Panel pnlSalesman;
        private System.Windows.Forms.Panel pnlCollector;
        private System.Windows.Forms.Panel pnlCurrency;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Panel pnlUseCustomerMasterSalesPerson;
        private System.Windows.Forms.Panel pnlAllocationNumWise;
        private System.Windows.Forms.Panel pnlAlloType;
        private System.Windows.Forms.Panel pnlAllRecords;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkShowAll;
    }
}