namespace Digiteq
{
    partial class frm_rpt_AccountReceivableReports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.grpAgeingSlabs = new System.Windows.Forms.GroupBox();
            this.txtSlab4 = new System.Windows.Forms.TextBox();
            this.txtSlab5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSlab2 = new System.Windows.Forms.TextBox();
            this.txtSlab3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSlab1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.txtCustomerTypeID = new System.Windows.Forms.TextBox();
            this.lblCustomerCategory = new System.Windows.Forms.Label();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.chkUseCustomerMastorSaleRep = new System.Windows.Forms.CheckBox();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCusClass = new System.Windows.Forms.Panel();
            this.txtCustomerClassID = new System.Windows.Forms.TextBox();
            this.lblCustomerClass = new System.Windows.Forms.Label();
            this.pnlCusType = new System.Windows.Forms.Panel();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.pnlSalesman = new System.Windows.Forms.Panel();
            this.pnlUseCusMasterSalesRep = new System.Windows.Forms.Panel();
            this.pnlAgingSlab = new System.Windows.Forms.Panel();
            this.pnlDateFrom = new System.Windows.Forms.Panel();
            this.pnlDateAsAt = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpAgeingSlabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlCusClass.SuspendLayout();
            this.pnlCusType.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlSalesman.SuspendLayout();
            this.pnlUseCusMasterSalesRep.SuspendLayout();
            this.pnlAgingSlab.SuspendLayout();
            this.pnlDateFrom.SuspendLayout();
            this.pnlDateAsAt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFromDate.Location = new System.Drawing.Point(3, 6);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(73, 14);
            this.lblFromDate.TabIndex = 8;
            this.lblFromDate.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(107, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(109, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "As At Date :";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(107, 2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(109, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // grpAgeingSlabs
            // 
            this.grpAgeingSlabs.BackColor = System.Drawing.Color.LightGray;
            this.grpAgeingSlabs.Controls.Add(this.txtSlab4);
            this.grpAgeingSlabs.Controls.Add(this.txtSlab5);
            this.grpAgeingSlabs.Controls.Add(this.label5);
            this.grpAgeingSlabs.Controls.Add(this.label6);
            this.grpAgeingSlabs.Controls.Add(this.txtSlab2);
            this.grpAgeingSlabs.Controls.Add(this.txtSlab3);
            this.grpAgeingSlabs.Controls.Add(this.label1);
            this.grpAgeingSlabs.Controls.Add(this.label3);
            this.grpAgeingSlabs.Controls.Add(this.txtSlab1);
            this.grpAgeingSlabs.Controls.Add(this.label4);
            this.grpAgeingSlabs.Location = new System.Drawing.Point(3, 3);
            this.grpAgeingSlabs.Name = "grpAgeingSlabs";
            this.grpAgeingSlabs.Size = new System.Drawing.Size(316, 62);
            this.grpAgeingSlabs.TabIndex = 478;
            this.grpAgeingSlabs.TabStop = false;
            this.grpAgeingSlabs.Text = "Ageing Slabs";
            // 
            // txtSlab4
            // 
            this.txtSlab4.Location = new System.Drawing.Point(206, 25);
            this.txtSlab4.Name = "txtSlab4";
            this.txtSlab4.Size = new System.Drawing.Size(40, 22);
            this.txtSlab4.TabIndex = 480;
            this.txtSlab4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlab4_KeyPress);
            // 
            // txtSlab5
            // 
            this.txtSlab5.Location = new System.Drawing.Point(267, 25);
            this.txtSlab5.Name = "txtSlab5";
            this.txtSlab5.Size = new System.Drawing.Size(40, 22);
            this.txtSlab5.TabIndex = 481;
            this.txtSlab5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlab5_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(191, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 14);
            this.label5.TabIndex = 478;
            this.label5.Text = "4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(252, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 14);
            this.label6.TabIndex = 479;
            this.label6.Text = "5";
            // 
            // txtSlab2
            // 
            this.txtSlab2.Location = new System.Drawing.Point(80, 25);
            this.txtSlab2.Name = "txtSlab2";
            this.txtSlab2.Size = new System.Drawing.Size(40, 22);
            this.txtSlab2.TabIndex = 476;
            this.txtSlab2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlab2_KeyPress);
            // 
            // txtSlab3
            // 
            this.txtSlab3.Location = new System.Drawing.Point(141, 25);
            this.txtSlab3.Name = "txtSlab3";
            this.txtSlab3.Size = new System.Drawing.Size(40, 22);
            this.txtSlab3.TabIndex = 477;
            this.txtSlab3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlab3_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 14);
            this.label1.TabIndex = 470;
            this.label1.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(65, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 14);
            this.label3.TabIndex = 472;
            this.label3.Text = "2";
            // 
            // txtSlab1
            // 
            this.txtSlab1.Location = new System.Drawing.Point(19, 25);
            this.txtSlab1.Name = "txtSlab1";
            this.txtSlab1.Size = new System.Drawing.Size(40, 22);
            this.txtSlab1.TabIndex = 475;
            this.txtSlab1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlab1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(126, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 14);
            this.label4.TabIndex = 474;
            this.label4.Text = "3";
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.BackColor = System.Drawing.Color.LightGray;
            this.txtCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryID.Location = new System.Drawing.Point(107, 2);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.ReadOnly = true;
            this.txtCategoryID.Size = new System.Drawing.Size(207, 22);
            this.txtCategoryID.TabIndex = 465;
            this.txtCategoryID.DoubleClick += new System.EventHandler(this.txtCategoryID_DoubleClick);
            // 
            // txtCustomerTypeID
            // 
            this.txtCustomerTypeID.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerTypeID.Location = new System.Drawing.Point(107, 2);
            this.txtCustomerTypeID.Name = "txtCustomerTypeID";
            this.txtCustomerTypeID.ReadOnly = true;
            this.txtCustomerTypeID.Size = new System.Drawing.Size(207, 22);
            this.txtCustomerTypeID.TabIndex = 463;
            this.txtCustomerTypeID.DoubleClick += new System.EventHandler(this.txtCustomerTypeID_DoubleClick);
            // 
            // lblCustomerCategory
            // 
            this.lblCustomerCategory.AutoSize = true;
            this.lblCustomerCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerCategory.Location = new System.Drawing.Point(3, 6);
            this.lblCustomerCategory.Name = "lblCustomerCategory";
            this.lblCustomerCategory.Size = new System.Drawing.Size(51, 14);
            this.lblCustomerCategory.TabIndex = 468;
            this.lblCustomerCategory.Text = "Category";
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerType.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerType.Location = new System.Drawing.Point(3, 6);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(81, 14);
            this.lblCustomerType.TabIndex = 466;
            this.lblCustomerType.Text = "Customer Type";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(107, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(207, 22);
            this.txtCustomer.TabIndex = 461;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(3, 6);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 14);
            this.lblCustomer.TabIndex = 462;
            this.lblCustomer.Text = "Customer";
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(107, 2);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(207, 22);
            this.txtSalesRep.TabIndex = 459;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            this.txtSalesRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesRep_KeyDown);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.Black;
            this.lblSalseRep.Location = new System.Drawing.Point(3, 6);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(55, 14);
            this.lblSalseRep.TabIndex = 460;
            this.lblSalseRep.Text = "Salesman";
            // 
            // chkUseCustomerMastorSaleRep
            // 
            this.chkUseCustomerMastorSaleRep.AutoSize = true;
            this.chkUseCustomerMastorSaleRep.Location = new System.Drawing.Point(107, 2);
            this.chkUseCustomerMastorSaleRep.Name = "chkUseCustomerMastorSaleRep";
            this.chkUseCustomerMastorSaleRep.Size = new System.Drawing.Size(215, 18);
            this.chkUseCustomerMastorSaleRep.TabIndex = 15;
            this.chkUseCustomerMastorSaleRep.Text = "Use Customer Master Sales Person";
            this.chkUseCustomerMastorSaleRep.UseVisualStyleBackColor = true;
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
            this.dgvReports.Location = new System.Drawing.Point(7, 8);
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
            this.dgvReports.Size = new System.Drawing.Size(328, 345);
            this.dgvReports.TabIndex = 486;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvReports);
            this.panel1.Controls.Add(this.ProgressBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 356);
            this.panel1.TabIndex = 487;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(80, 324);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(255, 22);
            this.ProgressBar.TabIndex = 485;
            this.ProgressBar.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlCusClass);
            this.flowLayoutPanel1.Controls.Add(this.pnlCusType);
            this.flowLayoutPanel1.Controls.Add(this.pnlCategory);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomer);
            this.flowLayoutPanel1.Controls.Add(this.pnlSalesman);
            this.flowLayoutPanel1.Controls.Add(this.pnlUseCusMasterSalesRep);
            this.flowLayoutPanel1.Controls.Add(this.pnlAgingSlab);
            this.flowLayoutPanel1.Controls.Add(this.pnlDateFrom);
            this.flowLayoutPanel1.Controls.Add(this.pnlDateAsAt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(345, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(336, 356);
            this.flowLayoutPanel1.TabIndex = 488;
            // 
            // pnlCusClass
            // 
            this.pnlCusClass.Controls.Add(this.txtCustomerClassID);
            this.pnlCusClass.Controls.Add(this.lblCustomerClass);
            this.pnlCusClass.Location = new System.Drawing.Point(0, 10);
            this.pnlCusClass.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCusClass.Name = "pnlCusClass";
            this.pnlCusClass.Size = new System.Drawing.Size(322, 27);
            this.pnlCusClass.TabIndex = 589;
            // 
            // txtCustomerClassID
            // 
            this.txtCustomerClassID.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerClassID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerClassID.Location = new System.Drawing.Point(107, 2);
            this.txtCustomerClassID.Name = "txtCustomerClassID";
            this.txtCustomerClassID.ReadOnly = true;
            this.txtCustomerClassID.Size = new System.Drawing.Size(207, 22);
            this.txtCustomerClassID.TabIndex = 464;
            this.txtCustomerClassID.DoubleClick += new System.EventHandler(this.txtCustomerClassID_DoubleClick);
            // 
            // lblCustomerClass
            // 
            this.lblCustomerClass.AutoSize = true;
            this.lblCustomerClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerClass.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerClass.Location = new System.Drawing.Point(3, 6);
            this.lblCustomerClass.Name = "lblCustomerClass";
            this.lblCustomerClass.Size = new System.Drawing.Size(82, 14);
            this.lblCustomerClass.TabIndex = 467;
            this.lblCustomerClass.Text = "Customer Class";
            // 
            // pnlCusType
            // 
            this.pnlCusType.Controls.Add(this.txtCustomerTypeID);
            this.pnlCusType.Controls.Add(this.lblCustomerType);
            this.pnlCusType.Location = new System.Drawing.Point(0, 37);
            this.pnlCusType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCusType.Name = "pnlCusType";
            this.pnlCusType.Size = new System.Drawing.Size(322, 27);
            this.pnlCusType.TabIndex = 590;
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.txtCategoryID);
            this.pnlCategory.Controls.Add(this.lblCustomerCategory);
            this.pnlCategory.Location = new System.Drawing.Point(0, 64);
            this.pnlCategory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(322, 27);
            this.pnlCategory.TabIndex = 590;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.chkShowAll);
            this.pnlCustomer.Controls.Add(this.txtCustomer);
            this.pnlCustomer.Controls.Add(this.lblCustomer);
            this.pnlCustomer.Location = new System.Drawing.Point(0, 91);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(322, 53);
            this.pnlCustomer.TabIndex = 590;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(107, 30);
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
            this.pnlSalesman.Location = new System.Drawing.Point(0, 144);
            this.pnlSalesman.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesman.Name = "pnlSalesman";
            this.pnlSalesman.Size = new System.Drawing.Size(322, 27);
            this.pnlSalesman.TabIndex = 590;
            // 
            // pnlUseCusMasterSalesRep
            // 
            this.pnlUseCusMasterSalesRep.Controls.Add(this.chkUseCustomerMastorSaleRep);
            this.pnlUseCusMasterSalesRep.Location = new System.Drawing.Point(0, 171);
            this.pnlUseCusMasterSalesRep.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUseCusMasterSalesRep.Name = "pnlUseCusMasterSalesRep";
            this.pnlUseCusMasterSalesRep.Size = new System.Drawing.Size(322, 27);
            this.pnlUseCusMasterSalesRep.TabIndex = 590;
            // 
            // pnlAgingSlab
            // 
            this.pnlAgingSlab.BackColor = System.Drawing.Color.LightGray;
            this.pnlAgingSlab.Controls.Add(this.grpAgeingSlabs);
            this.pnlAgingSlab.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.pnlAgingSlab.Location = new System.Drawing.Point(0, 198);
            this.pnlAgingSlab.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAgingSlab.Name = "pnlAgingSlab";
            this.pnlAgingSlab.Size = new System.Drawing.Size(322, 64);
            this.pnlAgingSlab.TabIndex = 590;
            // 
            // pnlDateFrom
            // 
            this.pnlDateFrom.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDateFrom.Controls.Add(this.lblFromDate);
            this.pnlDateFrom.Controls.Add(this.dtpFrom);
            this.pnlDateFrom.Location = new System.Drawing.Point(0, 262);
            this.pnlDateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDateFrom.Name = "pnlDateFrom";
            this.pnlDateFrom.Size = new System.Drawing.Size(322, 27);
            this.pnlDateFrom.TabIndex = 591;
            // 
            // pnlDateAsAt
            // 
            this.pnlDateAsAt.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDateAsAt.Controls.Add(this.label2);
            this.pnlDateAsAt.Controls.Add(this.dtpTo);
            this.pnlDateAsAt.Location = new System.Drawing.Point(0, 289);
            this.pnlDateAsAt.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDateAsAt.Name = "pnlDateAsAt";
            this.pnlDateAsAt.Size = new System.Drawing.Size(322, 27);
            this.pnlDateAsAt.TabIndex = 592;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Location = new System.Drawing.Point(342, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 38);
            this.panel2.TabIndex = 593;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(244, 5);
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
            this.btnClear.Location = new System.Drawing.Point(162, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 385);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(678, 44);
            this.panel3.TabIndex = 487;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // frm_rpt_AccountReceivableReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 432);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_AccountReceivableReports";
            this.Text = "Account Receivable Reports                ";
            this.Load += new System.EventHandler(this.frm_rpt_AccountReceivableReports_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.grpAgeingSlabs.ResumeLayout(false);
            this.grpAgeingSlabs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlCusClass.ResumeLayout(false);
            this.pnlCusClass.PerformLayout();
            this.pnlCusType.ResumeLayout(false);
            this.pnlCusType.PerformLayout();
            this.pnlCategory.ResumeLayout(false);
            this.pnlCategory.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlSalesman.ResumeLayout(false);
            this.pnlSalesman.PerformLayout();
            this.pnlUseCusMasterSalesRep.ResumeLayout(false);
            this.pnlUseCusMasterSalesRep.PerformLayout();
            this.pnlAgingSlab.ResumeLayout(false);
            this.pnlDateFrom.ResumeLayout(false);
            this.pnlDateFrom.PerformLayout();
            this.pnlDateAsAt.ResumeLayout(false);
            this.pnlDateAsAt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.CheckBox chkUseCustomerMastorSaleRep;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.TextBox txtCustomerTypeID;
        private System.Windows.Forms.Label lblCustomerCategory;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSlab3;
        private System.Windows.Forms.TextBox txtSlab2;
        private System.Windows.Forms.TextBox txtSlab1;
        private System.Windows.Forms.GroupBox grpAgeingSlabs;
        private System.Windows.Forms.TextBox txtSlab4;
        private System.Windows.Forms.TextBox txtSlab5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlCusClass;
        private System.Windows.Forms.TextBox txtCustomerClassID;
        private System.Windows.Forms.Label lblCustomerClass;
        private System.Windows.Forms.Panel pnlCusType;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Panel pnlSalesman;
        private System.Windows.Forms.Panel pnlUseCusMasterSalesRep;
        private System.Windows.Forms.Panel pnlAgingSlab;
        private System.Windows.Forms.Panel pnlDateFrom;
        private System.Windows.Forms.Panel pnlDateAsAt;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}