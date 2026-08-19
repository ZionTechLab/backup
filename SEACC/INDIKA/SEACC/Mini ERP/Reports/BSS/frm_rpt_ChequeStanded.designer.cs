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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvReports = new Digiteq.SEACC_DataGrid();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCurrency = new System.Windows.Forms.Panel();
            this.pnlCreatedUser = new System.Windows.Forms.Panel();
            this.txtCreatedUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.pnlSalesman = new System.Windows.Forms.Panel();
            this.pnlRoute = new System.Windows.Forms.Panel();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.pnlCollector = new System.Windows.Forms.Panel();
            this.pnlreturnCollection = new System.Windows.Forms.Panel();
            this.chkShowReturnCollection = new System.Windows.Forms.CheckBox();
            this.pnlUseChequeDate = new System.Windows.Forms.Panel();
            this.chkUseChequedate = new System.Windows.Forms.CheckBox();
            this.pnlShowSettledOnly = new System.Windows.Forms.Panel();
            this.chkShowSettledOnly = new System.Windows.Forms.CheckBox();
            this.pnlType = new System.Windows.Forms.Panel();
            this.pnlUseCustomerMasterSalesPerson = new System.Windows.Forms.Panel();
            this.pnlAllocationNumWise = new System.Windows.Forms.Panel();
            this.pnlAlloType = new System.Windows.Forms.Panel();
            this.pnlAllRecords = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlShowDetailReport = new System.Windows.Forms.Panel();
            this.chkShowDetailReport = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlCurrency.SuspendLayout();
            this.pnlCreatedUser.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlSalesman.SuspendLayout();
            this.pnlRoute.SuspendLayout();
            this.pnlCollector.SuspendLayout();
            this.pnlreturnCollection.SuspendLayout();
            this.pnlUseChequeDate.SuspendLayout();
            this.pnlShowSettledOnly.SuspendLayout();
            this.pnlType.SuspendLayout();
            this.pnlUseCustomerMasterSalesPerson.SuspendLayout();
            this.pnlAllocationNumWise.SuspendLayout();
            this.pnlAlloType.SuspendLayout();
            this.pnlAllRecords.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlShowDetailReport.SuspendLayout();
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
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(107, 0);
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
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(3, 4);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(56, 13);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(107, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(109, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(239, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(109, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // txtCollector
            // 
            this.txtCollector.BackColor = System.Drawing.Color.LightGray;
            this.txtCollector.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollector.Location = new System.Drawing.Point(107, 0);
            this.txtCollector.Name = "txtCollector";
            this.txtCollector.ReadOnly = true;
            this.txtCollector.Size = new System.Drawing.Size(199, 22);
            this.txtCollector.TabIndex = 479;
            this.txtCollector.DoubleClick += new System.EventHandler(this.txtCollector_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 480;
            this.label1.Text = "Collector";
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCash.ForeColor = System.Drawing.Color.Black;
            this.chkCash.Location = new System.Drawing.Point(107, 1);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(56, 17);
            this.chkCash.TabIndex = 476;
            this.chkCash.Text = "Other";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // chkCheque
            // 
            this.chkCheque.AutoSize = true;
            this.chkCheque.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheque.ForeColor = System.Drawing.Color.Black;
            this.chkCheque.Location = new System.Drawing.Point(165, 1);
            this.chkCheque.Name = "chkCheque";
            this.chkCheque.Size = new System.Drawing.Size(66, 17);
            this.chkCheque.TabIndex = 477;
            this.chkCheque.Text = "Cheque";
            this.chkCheque.UseVisualStyleBackColor = true;
            // 
            // chkAllocationNumberWise
            // 
            this.chkAllocationNumberWise.AutoSize = true;
            this.chkAllocationNumberWise.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllocationNumberWise.ForeColor = System.Drawing.Color.Black;
            this.chkAllocationNumberWise.Location = new System.Drawing.Point(107, 1);
            this.chkAllocationNumberWise.Name = "chkAllocationNumberWise";
            this.chkAllocationNumberWise.Size = new System.Drawing.Size(150, 17);
            this.chkAllocationNumberWise.TabIndex = 466;
            this.chkAllocationNumberWise.Text = "Allocation Number Wise";
            this.chkAllocationNumberWise.UseVisualStyleBackColor = true;
            // 
            // chkUseCustomerMastorSaleRep
            // 
            this.chkUseCustomerMastorSaleRep.AutoSize = true;
            this.chkUseCustomerMastorSaleRep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseCustomerMastorSaleRep.Location = new System.Drawing.Point(107, 1);
            this.chkUseCustomerMastorSaleRep.Name = "chkUseCustomerMastorSaleRep";
            this.chkUseCustomerMastorSaleRep.Size = new System.Drawing.Size(202, 17);
            this.chkUseCustomerMastorSaleRep.TabIndex = 472;
            this.chkUseCustomerMastorSaleRep.Text = "Use Customer Master Sales Person";
            this.chkUseCustomerMastorSaleRep.UseVisualStyleBackColor = true;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "<<All Currency>>",
            "Sri Lanka Rupee (LKR)",
            "American Dollar (USD)"});
            this.cmbCurrency.Location = new System.Drawing.Point(107, 0);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(133, 21);
            this.cmbCurrency.TabIndex = 464;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.ForeColor = System.Drawing.Color.Black;
            this.lblCurrency.Location = new System.Drawing.Point(3, 4);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(52, 13);
            this.lblCurrency.TabIndex = 463;
            this.lblCurrency.Text = "Currency";
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(107, 0);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(199, 22);
            this.txtSalesRep.TabIndex = 461;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.Black;
            this.lblSalseRep.Location = new System.Drawing.Point(3, 4);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(55, 13);
            this.lblSalseRep.TabIndex = 462;
            this.lblSalseRep.Text = "Salesman";
            // 
            // chkAdvance
            // 
            this.chkAdvance.AutoSize = true;
            this.chkAdvance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdvance.Location = new System.Drawing.Point(107, 2);
            this.chkAdvance.Name = "chkAdvance";
            this.chkAdvance.Size = new System.Drawing.Size(69, 17);
            this.chkAdvance.TabIndex = 465;
            this.chkAdvance.Text = "Advance";
            this.chkAdvance.UseVisualStyleBackColor = true;
            // 
            // chkPartPayment
            // 
            this.chkPartPayment.AutoSize = true;
            this.chkPartPayment.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPartPayment.Location = new System.Drawing.Point(173, 2);
            this.chkPartPayment.Name = "chkPartPayment";
            this.chkPartPayment.Size = new System.Drawing.Size(92, 17);
            this.chkPartPayment.TabIndex = 466;
            this.chkPartPayment.Text = "Part Payment";
            this.chkPartPayment.UseVisualStyleBackColor = true;
            // 
            // lblAllocationType
            // 
            this.lblAllocationType.AutoSize = true;
            this.lblAllocationType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocationType.ForeColor = System.Drawing.Color.Black;
            this.lblAllocationType.Location = new System.Drawing.Point(3, 4);
            this.lblAllocationType.Name = "lblAllocationType";
            this.lblAllocationType.Size = new System.Drawing.Size(85, 13);
            this.lblAllocationType.TabIndex = 467;
            this.lblAllocationType.Text = "Allocation Type";
            // 
            // chkOverPayment
            // 
            this.chkOverPayment.AutoSize = true;
            this.chkOverPayment.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOverPayment.Location = new System.Drawing.Point(260, 3);
            this.chkOverPayment.Name = "chkOverPayment";
            this.chkOverPayment.Size = new System.Drawing.Size(96, 17);
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
            this.rdoAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.Black;
            this.rdoAll.Location = new System.Drawing.Point(268, 3);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(82, 17);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoActual
            // 
            this.rdoActual.AutoSize = true;
            this.rdoActual.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActual.ForeColor = System.Drawing.Color.Black;
            this.rdoActual.Location = new System.Drawing.Point(138, 3);
            this.rdoActual.Name = "rdoActual";
            this.rdoActual.Size = new System.Drawing.Size(126, 17);
            this.rdoActual.TabIndex = 10;
            this.rdoActual.Text = "Active Records Only";
            this.rdoActual.UseVisualStyleBackColor = true;
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeleted.ForeColor = System.Drawing.Color.Black;
            this.rdoDeleted.Location = new System.Drawing.Point(3, 3);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(136, 17);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgvReports.Size = new System.Drawing.Size(321, 427);
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
            this.flowLayoutPanel1.Controls.Add(this.pnlCurrency);
            this.flowLayoutPanel1.Controls.Add(this.pnlCreatedUser);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomer);
            this.flowLayoutPanel1.Controls.Add(this.pnlSalesman);
            this.flowLayoutPanel1.Controls.Add(this.pnlRoute);
            this.flowLayoutPanel1.Controls.Add(this.pnlCollector);
            this.flowLayoutPanel1.Controls.Add(this.pnlreturnCollection);
            this.flowLayoutPanel1.Controls.Add(this.pnlUseChequeDate);
            this.flowLayoutPanel1.Controls.Add(this.pnlShowSettledOnly);
            this.flowLayoutPanel1.Controls.Add(this.pnlType);
            this.flowLayoutPanel1.Controls.Add(this.pnlUseCustomerMasterSalesPerson);
            this.flowLayoutPanel1.Controls.Add(this.pnlAllocationNumWise);
            this.flowLayoutPanel1.Controls.Add(this.pnlAlloType);
            this.flowLayoutPanel1.Controls.Add(this.pnlAllRecords);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.pnlShowDetailReport);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(336, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(358, 427);
            this.flowLayoutPanel1.TabIndex = 488;
            // 
            // pnlCurrency
            // 
            this.pnlCurrency.Controls.Add(this.cmbCurrency);
            this.pnlCurrency.Controls.Add(this.lblCurrency);
            this.pnlCurrency.Location = new System.Drawing.Point(0, 0);
            this.pnlCurrency.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCurrency.Name = "pnlCurrency";
            this.pnlCurrency.Size = new System.Drawing.Size(355, 27);
            this.pnlCurrency.TabIndex = 591;
            // 
            // pnlCreatedUser
            // 
            this.pnlCreatedUser.Controls.Add(this.txtCreatedUser);
            this.pnlCreatedUser.Controls.Add(this.label4);
            this.pnlCreatedUser.Location = new System.Drawing.Point(0, 27);
            this.pnlCreatedUser.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCreatedUser.Name = "pnlCreatedUser";
            this.pnlCreatedUser.Size = new System.Drawing.Size(355, 22);
            this.pnlCreatedUser.TabIndex = 592;
            // 
            // txtCreatedUser
            // 
            this.txtCreatedUser.BackColor = System.Drawing.Color.LightGray;
            this.txtCreatedUser.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreatedUser.Location = new System.Drawing.Point(107, 0);
            this.txtCreatedUser.Name = "txtCreatedUser";
            this.txtCreatedUser.ReadOnly = true;
            this.txtCreatedUser.Size = new System.Drawing.Size(199, 22);
            this.txtCreatedUser.TabIndex = 479;
            this.txtCreatedUser.DoubleClick += new System.EventHandler(this.txtCreatedUser_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 480;
            this.label4.Text = "Created User";
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.chkShowAll);
            this.pnlCustomer.Controls.Add(this.txtCustomer);
            this.pnlCustomer.Controls.Add(this.lblCustomer);
            this.pnlCustomer.Location = new System.Drawing.Point(0, 49);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(355, 41);
            this.pnlCustomer.TabIndex = 590;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAll.Location = new System.Drawing.Point(107, 22);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(71, 17);
            this.chkShowAll.TabIndex = 558;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            // 
            // pnlSalesman
            // 
            this.pnlSalesman.Controls.Add(this.txtSalesRep);
            this.pnlSalesman.Controls.Add(this.lblSalseRep);
            this.pnlSalesman.Location = new System.Drawing.Point(0, 90);
            this.pnlSalesman.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesman.Name = "pnlSalesman";
            this.pnlSalesman.Size = new System.Drawing.Size(355, 22);
            this.pnlSalesman.TabIndex = 591;
            // 
            // pnlRoute
            // 
            this.pnlRoute.Controls.Add(this.txtRoute);
            this.pnlRoute.Controls.Add(this.lblRoute);
            this.pnlRoute.Location = new System.Drawing.Point(0, 112);
            this.pnlRoute.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRoute.Name = "pnlRoute";
            this.pnlRoute.Size = new System.Drawing.Size(355, 22);
            this.pnlRoute.TabIndex = 593;
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(107, 0);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(199, 22);
            this.txtRoute.TabIndex = 461;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.Black;
            this.lblRoute.Location = new System.Drawing.Point(3, 4);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(38, 13);
            this.lblRoute.TabIndex = 462;
            this.lblRoute.Text = "Route";
            // 
            // pnlCollector
            // 
            this.pnlCollector.Controls.Add(this.txtCollector);
            this.pnlCollector.Controls.Add(this.label1);
            this.pnlCollector.Location = new System.Drawing.Point(0, 134);
            this.pnlCollector.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCollector.Name = "pnlCollector";
            this.pnlCollector.Size = new System.Drawing.Size(355, 22);
            this.pnlCollector.TabIndex = 591;
            // 
            // pnlreturnCollection
            // 
            this.pnlreturnCollection.Controls.Add(this.chkShowReturnCollection);
            this.pnlreturnCollection.Location = new System.Drawing.Point(0, 156);
            this.pnlreturnCollection.Margin = new System.Windows.Forms.Padding(0);
            this.pnlreturnCollection.Name = "pnlreturnCollection";
            this.pnlreturnCollection.Size = new System.Drawing.Size(355, 22);
            this.pnlreturnCollection.TabIndex = 596;
            // 
            // chkShowReturnCollection
            // 
            this.chkShowReturnCollection.AutoSize = true;
            this.chkShowReturnCollection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowReturnCollection.ForeColor = System.Drawing.Color.Black;
            this.chkShowReturnCollection.Location = new System.Drawing.Point(107, 1);
            this.chkShowReturnCollection.Name = "chkShowReturnCollection";
            this.chkShowReturnCollection.Size = new System.Drawing.Size(148, 17);
            this.chkShowReturnCollection.TabIndex = 466;
            this.chkShowReturnCollection.Text = "Show Return Collection";
            this.chkShowReturnCollection.UseVisualStyleBackColor = true;
            // 
            // pnlUseChequeDate
            // 
            this.pnlUseChequeDate.Controls.Add(this.chkUseChequedate);
            this.pnlUseChequeDate.Location = new System.Drawing.Point(0, 178);
            this.pnlUseChequeDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUseChequeDate.Name = "pnlUseChequeDate";
            this.pnlUseChequeDate.Size = new System.Drawing.Size(355, 22);
            this.pnlUseChequeDate.TabIndex = 595;
            // 
            // chkUseChequedate
            // 
            this.chkUseChequedate.AutoSize = true;
            this.chkUseChequedate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseChequedate.Location = new System.Drawing.Point(107, 1);
            this.chkUseChequedate.Name = "chkUseChequedate";
            this.chkUseChequedate.Size = new System.Drawing.Size(115, 17);
            this.chkUseChequedate.TabIndex = 472;
            this.chkUseChequedate.Text = "Use Cheque Date";
            this.chkUseChequedate.UseVisualStyleBackColor = true;
            // 
            // pnlShowSettledOnly
            // 
            this.pnlShowSettledOnly.Controls.Add(this.chkShowSettledOnly);
            this.pnlShowSettledOnly.Location = new System.Drawing.Point(0, 200);
            this.pnlShowSettledOnly.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShowSettledOnly.Name = "pnlShowSettledOnly";
            this.pnlShowSettledOnly.Size = new System.Drawing.Size(355, 22);
            this.pnlShowSettledOnly.TabIndex = 594;
            // 
            // chkShowSettledOnly
            // 
            this.chkShowSettledOnly.AutoSize = true;
            this.chkShowSettledOnly.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowSettledOnly.ForeColor = System.Drawing.Color.Black;
            this.chkShowSettledOnly.Location = new System.Drawing.Point(107, 1);
            this.chkShowSettledOnly.Name = "chkShowSettledOnly";
            this.chkShowSettledOnly.Size = new System.Drawing.Size(127, 17);
            this.chkShowSettledOnly.TabIndex = 466;
            this.chkShowSettledOnly.Text = "Show Setteled Only";
            this.chkShowSettledOnly.UseVisualStyleBackColor = true;
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.chkCash);
            this.pnlType.Controls.Add(this.chkCheque);
            this.pnlType.Location = new System.Drawing.Point(0, 222);
            this.pnlType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(355, 22);
            this.pnlType.TabIndex = 591;
            // 
            // pnlUseCustomerMasterSalesPerson
            // 
            this.pnlUseCustomerMasterSalesPerson.Controls.Add(this.chkUseCustomerMastorSaleRep);
            this.pnlUseCustomerMasterSalesPerson.Location = new System.Drawing.Point(0, 244);
            this.pnlUseCustomerMasterSalesPerson.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUseCustomerMasterSalesPerson.Name = "pnlUseCustomerMasterSalesPerson";
            this.pnlUseCustomerMasterSalesPerson.Size = new System.Drawing.Size(355, 22);
            this.pnlUseCustomerMasterSalesPerson.TabIndex = 591;
            // 
            // pnlAllocationNumWise
            // 
            this.pnlAllocationNumWise.Controls.Add(this.chkAllocationNumberWise);
            this.pnlAllocationNumWise.Location = new System.Drawing.Point(0, 266);
            this.pnlAllocationNumWise.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAllocationNumWise.Name = "pnlAllocationNumWise";
            this.pnlAllocationNumWise.Size = new System.Drawing.Size(355, 22);
            this.pnlAllocationNumWise.TabIndex = 591;
            // 
            // pnlAlloType
            // 
            this.pnlAlloType.Controls.Add(this.chkOverPayment);
            this.pnlAlloType.Controls.Add(this.chkPartPayment);
            this.pnlAlloType.Controls.Add(this.chkAdvance);
            this.pnlAlloType.Controls.Add(this.lblAllocationType);
            this.pnlAlloType.Location = new System.Drawing.Point(0, 288);
            this.pnlAlloType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAlloType.Name = "pnlAlloType";
            this.pnlAlloType.Size = new System.Drawing.Size(355, 22);
            this.pnlAlloType.TabIndex = 591;
            // 
            // pnlAllRecords
            // 
            this.pnlAllRecords.Controls.Add(this.rdoAll);
            this.pnlAllRecords.Controls.Add(this.rdoActual);
            this.pnlAllRecords.Controls.Add(this.rdoDeleted);
            this.pnlAllRecords.Location = new System.Drawing.Point(0, 310);
            this.pnlAllRecords.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAllRecords.Name = "pnlAllRecords";
            this.pnlAllRecords.Size = new System.Drawing.Size(355, 27);
            this.pnlAllRecords.TabIndex = 592;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pnlDate);
            this.panel8.Location = new System.Drawing.Point(0, 337);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(355, 33);
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
            this.pnlDate.Size = new System.Drawing.Size(353, 31);
            this.pnlDate.TabIndex = 587;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Period From :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(215, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 585;
            this.label3.Text = "To :";
            // 
            // pnlShowDetailReport
            // 
            this.pnlShowDetailReport.Controls.Add(this.chkShowDetailReport);
            this.pnlShowDetailReport.Location = new System.Drawing.Point(0, 370);
            this.pnlShowDetailReport.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShowDetailReport.Name = "pnlShowDetailReport";
            this.pnlShowDetailReport.Size = new System.Drawing.Size(355, 22);
            this.pnlShowDetailReport.TabIndex = 595;
            // 
            // chkShowDetailReport
            // 
            this.chkShowDetailReport.AutoSize = true;
            this.chkShowDetailReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowDetailReport.ForeColor = System.Drawing.Color.Black;
            this.chkShowDetailReport.Location = new System.Drawing.Point(107, 1);
            this.chkShowDetailReport.Name = "chkShowDetailReport";
            this.chkShowDetailReport.Size = new System.Drawing.Size(126, 17);
            this.chkShowDetailReport.TabIndex = 466;
            this.chkShowDetailReport.Text = "Show Detail Report";
            this.chkShowDetailReport.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.ProgressBar);
            this.panel1.Location = new System.Drawing.Point(9, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 37);
            this.panel1.TabIndex = 489;
            // 
            // frm_rpt_ChequeStanded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(701, 510);
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
            this.pnlCurrency.ResumeLayout(false);
            this.pnlCurrency.PerformLayout();
            this.pnlCreatedUser.ResumeLayout(false);
            this.pnlCreatedUser.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlSalesman.ResumeLayout(false);
            this.pnlSalesman.PerformLayout();
            this.pnlRoute.ResumeLayout(false);
            this.pnlRoute.PerformLayout();
            this.pnlCollector.ResumeLayout(false);
            this.pnlCollector.PerformLayout();
            this.pnlreturnCollection.ResumeLayout(false);
            this.pnlreturnCollection.PerformLayout();
            this.pnlUseChequeDate.ResumeLayout(false);
            this.pnlUseChequeDate.PerformLayout();
            this.pnlShowSettledOnly.ResumeLayout(false);
            this.pnlShowSettledOnly.PerformLayout();
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
            this.pnlShowDetailReport.ResumeLayout(false);
            this.pnlShowDetailReport.PerformLayout();
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
        private SEACC_DataGrid dgvReports;
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
        private System.Windows.Forms.Panel pnlRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Panel pnlCreatedUser;
        private System.Windows.Forms.TextBox txtCreatedUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlShowSettledOnly;
        private System.Windows.Forms.CheckBox chkShowSettledOnly;
        private System.Windows.Forms.Panel pnlUseChequeDate;
        private System.Windows.Forms.CheckBox chkUseChequedate;
        private System.Windows.Forms.Panel pnlShowDetailReport;
        private System.Windows.Forms.CheckBox chkShowDetailReport;
        private System.Windows.Forms.Panel pnlreturnCollection;
        private System.Windows.Forms.CheckBox chkShowReturnCollection;
    }
}