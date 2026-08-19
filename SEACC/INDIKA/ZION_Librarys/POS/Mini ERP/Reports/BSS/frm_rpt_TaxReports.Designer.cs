namespace Digiteq.Reports.BSS
{
    partial class frm_rpt_TaxReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_TaxReports));
            this.pnlReportGrid = new System.Windows.Forms.Panel();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBranch = new System.Windows.Forms.Panel();
            this.chkShowAll_Branch = new System.Windows.Forms.CheckBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.flowLayoutSupplierDetailPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSupplier = new System.Windows.Forms.Panel();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.pnlSupClass = new System.Windows.Forms.Panel();
            this.txtSupClass = new System.Windows.Forms.TextBox();
            this.lblSupClass = new System.Windows.Forms.Label();
            this.pnlSupType = new System.Windows.Forms.Panel();
            this.txtSupType = new System.Windows.Forms.TextBox();
            this.lblSupType = new System.Windows.Forms.Label();
            this.pnlSupCategory = new System.Windows.Forms.Panel();
            this.txtSupCategory = new System.Windows.Forms.TextBox();
            this.lblSupCategory = new System.Windows.Forms.Label();
            this.pnlNoteT = new System.Windows.Forms.Panel();
            this.txtNoteType = new System.Windows.Forms.TextBox();
            this.lblNoteType = new System.Windows.Forms.Label();
            this.flowLayoutCustomerDetailPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCusType = new System.Windows.Forms.Panel();
            this.lblCusCategory = new System.Windows.Forms.Label();
            this.txtCusClass = new System.Windows.Forms.TextBox();
            this.txtCusCategory = new System.Windows.Forms.TextBox();
            this.lblCusClass = new System.Windows.Forms.Label();
            this.lblCusType = new System.Windows.Forms.Label();
            this.txtCusType = new System.Windows.Forms.TextBox();
            this.pnlCusName = new System.Windows.Forms.Panel();
            this.chkShowAll_Customers = new System.Windows.Forms.CheckBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.pnlSalesman = new System.Windows.Forms.Panel();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.chkUseCustomerMastorSaleRep = new System.Windows.Forms.CheckBox();
            this.pnlRoute = new System.Windows.Forms.Panel();
            this.chkUseCustomerMasterRoute = new System.Windows.Forms.CheckBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.pnlTaxType = new System.Windows.Forms.Panel();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.lblTaxType = new System.Windows.Forms.Label();
            this.pnlNoteType = new System.Windows.Forms.Panel();
            this.txtSalesNoteType = new System.Windows.Forms.TextBox();
            this.lblSalesNoteType = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.pnlReportGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlBranch.SuspendLayout();
            this.flowLayoutSupplierDetailPanel.SuspendLayout();
            this.pnlSupplier.SuspendLayout();
            this.pnlSupClass.SuspendLayout();
            this.pnlSupType.SuspendLayout();
            this.pnlSupCategory.SuspendLayout();
            this.pnlNoteT.SuspendLayout();
            this.flowLayoutCustomerDetailPanel.SuspendLayout();
            this.pnlCusType.SuspendLayout();
            this.pnlCusName.SuspendLayout();
            this.pnlSalesman.SuspendLayout();
            this.pnlRoute.SuspendLayout();
            this.pnlTaxType.SuspendLayout();
            this.pnlNoteType.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // pnlReportGrid
            // 
            this.pnlReportGrid.Controls.Add(this.dgvReports);
            this.pnlReportGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlReportGrid.Location = new System.Drawing.Point(3, 29);
            this.pnlReportGrid.Name = "pnlReportGrid";
            this.pnlReportGrid.Padding = new System.Windows.Forms.Padding(5);
            this.pnlReportGrid.Size = new System.Drawing.Size(338, 492);
            this.pnlReportGrid.TabIndex = 4;
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
            this.dgvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReports.Location = new System.Drawing.Point(5, 5);
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
            this.dgvReports.Size = new System.Drawing.Size(328, 482);
            this.dgvReports.TabIndex = 578;
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
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.panel1);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(3, 521);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(679, 37);
            this.pnlFooter.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProgressBar);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 33);
            this.panel1.TabIndex = 580;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(0, 7);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(502, 20);
            this.ProgressBar.TabIndex = 482;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(508, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(586, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 475;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlFilters
            // 
            this.pnlFilters.AutoScroll = true;
            this.pnlFilters.Controls.Add(this.flowLayoutPanel1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilters.Location = new System.Drawing.Point(341, 29);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(341, 492);
            this.pnlFilters.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlBranch);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutSupplierDetailPanel);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutCustomerDetailPanel);
            this.flowLayoutPanel1.Controls.Add(this.pnlDate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(341, 492);
            this.flowLayoutPanel1.TabIndex = 580;
            // 
            // pnlBranch
            // 
            this.pnlBranch.Controls.Add(this.chkShowAll_Branch);
            this.pnlBranch.Controls.Add(this.txtBranch);
            this.pnlBranch.Controls.Add(this.lblBranch);
            this.pnlBranch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBranch.Location = new System.Drawing.Point(8, 8);
            this.pnlBranch.Name = "pnlBranch";
            this.pnlBranch.Size = new System.Drawing.Size(327, 54);
            this.pnlBranch.TabIndex = 592;
            // 
            // chkShowAll_Branch
            // 
            this.chkShowAll_Branch.AutoSize = true;
            this.chkShowAll_Branch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAll_Branch.ForeColor = System.Drawing.Color.Black;
            this.chkShowAll_Branch.Location = new System.Drawing.Point(115, 31);
            this.chkShowAll_Branch.Name = "chkShowAll_Branch";
            this.chkShowAll_Branch.Size = new System.Drawing.Size(126, 18);
            this.chkShowAll_Branch.TabIndex = 595;
            this.chkShowAll_Branch.Text = "Show All Branches";
            this.chkShowAll_Branch.UseVisualStyleBackColor = true;
            this.chkShowAll_Branch.CheckedChanged += new System.EventHandler(this.chkShowAll_Branch_CheckedChanged);
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.LightGray;
            this.txtBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(115, 3);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(207, 22);
            this.txtBranch.TabIndex = 579;
            this.txtBranch.DoubleClick += new System.EventHandler(this.txtBranch_DoubleClick);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBranch.Location = new System.Drawing.Point(4, 6);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 14);
            this.lblBranch.TabIndex = 580;
            this.lblBranch.Text = "Branch";
            // 
            // flowLayoutSupplierDetailPanel
            // 
            this.flowLayoutSupplierDetailPanel.AutoSize = true;
            this.flowLayoutSupplierDetailPanel.Controls.Add(this.pnlSupplier);
            this.flowLayoutSupplierDetailPanel.Controls.Add(this.pnlSupClass);
            this.flowLayoutSupplierDetailPanel.Controls.Add(this.pnlSupType);
            this.flowLayoutSupplierDetailPanel.Controls.Add(this.pnlSupCategory);
            this.flowLayoutSupplierDetailPanel.Controls.Add(this.pnlNoteT);
            this.flowLayoutSupplierDetailPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutSupplierDetailPanel.Location = new System.Drawing.Point(8, 65);
            this.flowLayoutSupplierDetailPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flowLayoutSupplierDetailPanel.Name = "flowLayoutSupplierDetailPanel";
            this.flowLayoutSupplierDetailPanel.Size = new System.Drawing.Size(327, 152);
            this.flowLayoutSupplierDetailPanel.TabIndex = 594;
            // 
            // pnlSupplier
            // 
            this.pnlSupplier.Controls.Add(this.txtSupplier);
            this.pnlSupplier.Controls.Add(this.lblSupplier);
            this.pnlSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnlSupplier.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupplier.Name = "pnlSupplier";
            this.pnlSupplier.Size = new System.Drawing.Size(327, 32);
            this.pnlSupplier.TabIndex = 0;
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.LightGray;
            this.txtSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(115, 4);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(207, 22);
            this.txtSupplier.TabIndex = 461;
            this.txtSupplier.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSupplier_MouseDoubleClick);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupplier.Location = new System.Drawing.Point(3, 8);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(80, 14);
            this.lblSupplier.TabIndex = 462;
            this.lblSupplier.Text = "Supplier Name";
            // 
            // pnlSupClass
            // 
            this.pnlSupClass.Controls.Add(this.txtSupClass);
            this.pnlSupClass.Controls.Add(this.lblSupClass);
            this.pnlSupClass.Location = new System.Drawing.Point(0, 32);
            this.pnlSupClass.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupClass.Name = "pnlSupClass";
            this.pnlSupClass.Size = new System.Drawing.Size(327, 30);
            this.pnlSupClass.TabIndex = 1;
            this.pnlSupClass.Visible = false;
            // 
            // txtSupClass
            // 
            this.txtSupClass.BackColor = System.Drawing.Color.LightGray;
            this.txtSupClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupClass.Location = new System.Drawing.Point(115, 2);
            this.txtSupClass.Name = "txtSupClass";
            this.txtSupClass.ReadOnly = true;
            this.txtSupClass.Size = new System.Drawing.Size(207, 22);
            this.txtSupClass.TabIndex = 579;
            this.txtSupClass.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSupClass_MouseDoubleClick);
            // 
            // lblSupClass
            // 
            this.lblSupClass.AutoSize = true;
            this.lblSupClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupClass.Location = new System.Drawing.Point(3, 6);
            this.lblSupClass.Name = "lblSupClass";
            this.lblSupClass.Size = new System.Drawing.Size(75, 14);
            this.lblSupClass.TabIndex = 580;
            this.lblSupClass.Text = "Supplier Class";
            // 
            // pnlSupType
            // 
            this.pnlSupType.Controls.Add(this.txtSupType);
            this.pnlSupType.Controls.Add(this.lblSupType);
            this.pnlSupType.Location = new System.Drawing.Point(0, 62);
            this.pnlSupType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupType.Name = "pnlSupType";
            this.pnlSupType.Size = new System.Drawing.Size(327, 30);
            this.pnlSupType.TabIndex = 1;
            this.pnlSupType.Visible = false;
            // 
            // txtSupType
            // 
            this.txtSupType.BackColor = System.Drawing.Color.LightGray;
            this.txtSupType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupType.Location = new System.Drawing.Point(115, 2);
            this.txtSupType.Name = "txtSupType";
            this.txtSupType.ReadOnly = true;
            this.txtSupType.Size = new System.Drawing.Size(207, 22);
            this.txtSupType.TabIndex = 581;
            this.txtSupType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSupType_MouseDoubleClick);
            // 
            // lblSupType
            // 
            this.lblSupType.AutoSize = true;
            this.lblSupType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupType.Location = new System.Drawing.Point(3, 6);
            this.lblSupType.Name = "lblSupType";
            this.lblSupType.Size = new System.Drawing.Size(74, 14);
            this.lblSupType.TabIndex = 582;
            this.lblSupType.Text = "Supplier Type";
            // 
            // pnlSupCategory
            // 
            this.pnlSupCategory.Controls.Add(this.txtSupCategory);
            this.pnlSupCategory.Controls.Add(this.lblSupCategory);
            this.pnlSupCategory.Location = new System.Drawing.Point(0, 92);
            this.pnlSupCategory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupCategory.Name = "pnlSupCategory";
            this.pnlSupCategory.Size = new System.Drawing.Size(327, 31);
            this.pnlSupCategory.TabIndex = 1;
            this.pnlSupCategory.Visible = false;
            // 
            // txtSupCategory
            // 
            this.txtSupCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtSupCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupCategory.Location = new System.Drawing.Point(115, 2);
            this.txtSupCategory.Name = "txtSupCategory";
            this.txtSupCategory.ReadOnly = true;
            this.txtSupCategory.Size = new System.Drawing.Size(207, 22);
            this.txtSupCategory.TabIndex = 583;
            this.txtSupCategory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSupCategory_MouseDoubleClick);
            // 
            // lblSupCategory
            // 
            this.lblSupCategory.AutoSize = true;
            this.lblSupCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupCategory.Location = new System.Drawing.Point(3, 6);
            this.lblSupCategory.Name = "lblSupCategory";
            this.lblSupCategory.Size = new System.Drawing.Size(94, 14);
            this.lblSupCategory.TabIndex = 584;
            this.lblSupCategory.Text = "Supplier Category";
            // 
            // pnlNoteT
            // 
            this.pnlNoteT.Controls.Add(this.txtNoteType);
            this.pnlNoteT.Controls.Add(this.lblNoteType);
            this.pnlNoteT.Location = new System.Drawing.Point(0, 123);
            this.pnlNoteT.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNoteT.Name = "pnlNoteT";
            this.pnlNoteT.Size = new System.Drawing.Size(327, 29);
            this.pnlNoteT.TabIndex = 1;
            // 
            // txtNoteType
            // 
            this.txtNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoteType.Location = new System.Drawing.Point(115, 2);
            this.txtNoteType.Name = "txtNoteType";
            this.txtNoteType.ReadOnly = true;
            this.txtNoteType.Size = new System.Drawing.Size(207, 22);
            this.txtNoteType.TabIndex = 461;
            this.txtNoteType.DoubleClick += new System.EventHandler(this.txtNoteType_DoubleClick);
            // 
            // lblNoteType
            // 
            this.lblNoteType.AutoSize = true;
            this.lblNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNoteType.Location = new System.Drawing.Point(3, 6);
            this.lblNoteType.Name = "lblNoteType";
            this.lblNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblNoteType.TabIndex = 478;
            this.lblNoteType.Text = "Note Type";
            // 
            // flowLayoutCustomerDetailPanel
            // 
            this.flowLayoutCustomerDetailPanel.AutoSize = true;
            this.flowLayoutCustomerDetailPanel.Controls.Add(this.pnlCusType);
            this.flowLayoutCustomerDetailPanel.Controls.Add(this.pnlCusName);
            this.flowLayoutCustomerDetailPanel.Controls.Add(this.pnlSalesman);
            this.flowLayoutCustomerDetailPanel.Controls.Add(this.pnlRoute);
            this.flowLayoutCustomerDetailPanel.Controls.Add(this.pnlTaxType);
            this.flowLayoutCustomerDetailPanel.Controls.Add(this.pnlNoteType);
            this.flowLayoutCustomerDetailPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutCustomerDetailPanel.Location = new System.Drawing.Point(8, 220);
            this.flowLayoutCustomerDetailPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowLayoutCustomerDetailPanel.Name = "flowLayoutCustomerDetailPanel";
            this.flowLayoutCustomerDetailPanel.Size = new System.Drawing.Size(327, 304);
            this.flowLayoutCustomerDetailPanel.TabIndex = 595;
            // 
            // pnlCusType
            // 
            this.pnlCusType.Controls.Add(this.lblCusCategory);
            this.pnlCusType.Controls.Add(this.txtCusClass);
            this.pnlCusType.Controls.Add(this.txtCusCategory);
            this.pnlCusType.Controls.Add(this.lblCusClass);
            this.pnlCusType.Controls.Add(this.lblCusType);
            this.pnlCusType.Controls.Add(this.txtCusType);
            this.pnlCusType.Location = new System.Drawing.Point(0, 0);
            this.pnlCusType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCusType.Name = "pnlCusType";
            this.pnlCusType.Size = new System.Drawing.Size(327, 86);
            this.pnlCusType.TabIndex = 578;
            // 
            // lblCusCategory
            // 
            this.lblCusCategory.AutoSize = true;
            this.lblCusCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCusCategory.Location = new System.Drawing.Point(4, 62);
            this.lblCusCategory.Name = "lblCusCategory";
            this.lblCusCategory.Size = new System.Drawing.Size(101, 14);
            this.lblCusCategory.TabIndex = 575;
            this.lblCusCategory.Text = "Customer Category";
            // 
            // txtCusClass
            // 
            this.txtCusClass.BackColor = System.Drawing.Color.LightGray;
            this.txtCusClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusClass.Location = new System.Drawing.Point(115, 1);
            this.txtCusClass.Name = "txtCusClass";
            this.txtCusClass.ReadOnly = true;
            this.txtCusClass.Size = new System.Drawing.Size(207, 22);
            this.txtCusClass.TabIndex = 576;
            this.txtCusClass.DoubleClick += new System.EventHandler(this.txtCusClass_DoubleClick);
            // 
            // txtCusCategory
            // 
            this.txtCusCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtCusCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusCategory.Location = new System.Drawing.Point(115, 59);
            this.txtCusCategory.Name = "txtCusCategory";
            this.txtCusCategory.ReadOnly = true;
            this.txtCusCategory.Size = new System.Drawing.Size(207, 22);
            this.txtCusCategory.TabIndex = 576;
            this.txtCusCategory.DoubleClick += new System.EventHandler(this.txtCusCategory_DoubleClick);
            // 
            // lblCusClass
            // 
            this.lblCusClass.AutoSize = true;
            this.lblCusClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCusClass.Location = new System.Drawing.Point(4, 4);
            this.lblCusClass.Name = "lblCusClass";
            this.lblCusClass.Size = new System.Drawing.Size(82, 14);
            this.lblCusClass.TabIndex = 575;
            this.lblCusClass.Text = "Customer Class";
            // 
            // lblCusType
            // 
            this.lblCusType.AutoSize = true;
            this.lblCusType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCusType.Location = new System.Drawing.Point(4, 33);
            this.lblCusType.Name = "lblCusType";
            this.lblCusType.Size = new System.Drawing.Size(81, 14);
            this.lblCusType.TabIndex = 573;
            this.lblCusType.Text = "Customer Type";
            // 
            // txtCusType
            // 
            this.txtCusType.BackColor = System.Drawing.Color.LightGray;
            this.txtCusType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusType.Location = new System.Drawing.Point(115, 30);
            this.txtCusType.Name = "txtCusType";
            this.txtCusType.ReadOnly = true;
            this.txtCusType.Size = new System.Drawing.Size(207, 22);
            this.txtCusType.TabIndex = 574;
            this.txtCusType.DoubleClick += new System.EventHandler(this.txtCusType_DoubleClick);
            // 
            // pnlCusName
            // 
            this.pnlCusName.Controls.Add(this.chkShowAll_Customers);
            this.pnlCusName.Controls.Add(this.lblCustomer);
            this.pnlCusName.Controls.Add(this.txtCustomer);
            this.pnlCusName.Location = new System.Drawing.Point(0, 86);
            this.pnlCusName.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCusName.Name = "pnlCusName";
            this.pnlCusName.Size = new System.Drawing.Size(327, 62);
            this.pnlCusName.TabIndex = 580;
            // 
            // chkShowAll_Customers
            // 
            this.chkShowAll_Customers.AutoSize = true;
            this.chkShowAll_Customers.Location = new System.Drawing.Point(115, 31);
            this.chkShowAll_Customers.Name = "chkShowAll_Customers";
            this.chkShowAll_Customers.Size = new System.Drawing.Size(71, 17);
            this.chkShowAll_Customers.TabIndex = 558;
            this.chkShowAll_Customers.Text = "Show All";
            this.chkShowAll_Customers.UseVisualStyleBackColor = true;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(4, 7);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 462;
            this.lblCustomer.Text = "Customer Name";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(115, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(207, 22);
            this.txtCustomer.TabIndex = 461;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // pnlSalesman
            // 
            this.pnlSalesman.Controls.Add(this.lblSalseRep);
            this.pnlSalesman.Controls.Add(this.txtSalesRep);
            this.pnlSalesman.Controls.Add(this.chkUseCustomerMastorSaleRep);
            this.pnlSalesman.Location = new System.Drawing.Point(0, 148);
            this.pnlSalesman.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesman.Name = "pnlSalesman";
            this.pnlSalesman.Size = new System.Drawing.Size(327, 51);
            this.pnlSalesman.TabIndex = 583;
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSalseRep.Location = new System.Drawing.Point(4, 5);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(82, 14);
            this.lblSalseRep.TabIndex = 460;
            this.lblSalseRep.Text = "Salesman Code";
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(115, 2);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(207, 22);
            this.txtSalesRep.TabIndex = 459;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            // 
            // chkUseCustomerMastorSaleRep
            // 
            this.chkUseCustomerMastorSaleRep.AutoSize = true;
            this.chkUseCustomerMastorSaleRep.Location = new System.Drawing.Point(115, 30);
            this.chkUseCustomerMastorSaleRep.Name = "chkUseCustomerMastorSaleRep";
            this.chkUseCustomerMastorSaleRep.Size = new System.Drawing.Size(202, 17);
            this.chkUseCustomerMastorSaleRep.TabIndex = 42;
            this.chkUseCustomerMastorSaleRep.Text = "Use Customer Master Sales Person";
            this.chkUseCustomerMastorSaleRep.UseVisualStyleBackColor = true;
            // 
            // pnlRoute
            // 
            this.pnlRoute.Controls.Add(this.chkUseCustomerMasterRoute);
            this.pnlRoute.Controls.Add(this.txtRoute);
            this.pnlRoute.Controls.Add(this.lblRoute);
            this.pnlRoute.Location = new System.Drawing.Point(0, 199);
            this.pnlRoute.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRoute.Name = "pnlRoute";
            this.pnlRoute.Size = new System.Drawing.Size(327, 51);
            this.pnlRoute.TabIndex = 584;
            // 
            // chkUseCustomerMasterRoute
            // 
            this.chkUseCustomerMasterRoute.AutoSize = true;
            this.chkUseCustomerMasterRoute.Location = new System.Drawing.Point(115, 30);
            this.chkUseCustomerMasterRoute.Name = "chkUseCustomerMasterRoute";
            this.chkUseCustomerMasterRoute.Size = new System.Drawing.Size(169, 17);
            this.chkUseCustomerMasterRoute.TabIndex = 583;
            this.chkUseCustomerMasterRoute.Text = "Use Customer Master Route";
            this.chkUseCustomerMasterRoute.UseVisualStyleBackColor = true;
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(115, 2);
            this.txtRoute.Margin = new System.Windows.Forms.Padding(0);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(207, 22);
            this.txtRoute.TabIndex = 0;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoute.Location = new System.Drawing.Point(4, 5);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(69, 14);
            this.lblRoute.TabIndex = 12;
            this.lblRoute.Text = "Route Name";
            // 
            // pnlTaxType
            // 
            this.pnlTaxType.Controls.Add(this.cmbTaxType);
            this.pnlTaxType.Controls.Add(this.lblTaxType);
            this.pnlTaxType.Location = new System.Drawing.Point(0, 250);
            this.pnlTaxType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTaxType.Name = "pnlTaxType";
            this.pnlTaxType.Size = new System.Drawing.Size(327, 27);
            this.pnlTaxType.TabIndex = 593;
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Items.AddRange(new object[] {
            "Local NBT/VAT",
            "Export VAT",
            "Export SVAT",
            "Local VAT (Excluding: NBT)",
            "DSE Zero Rated"});
            this.cmbTaxType.Location = new System.Drawing.Point(115, 1);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(207, 21);
            this.cmbTaxType.TabIndex = 501;
            // 
            // lblTaxType
            // 
            this.lblTaxType.AutoSize = true;
            this.lblTaxType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTaxType.Location = new System.Drawing.Point(4, 5);
            this.lblTaxType.Name = "lblTaxType";
            this.lblTaxType.Size = new System.Drawing.Size(51, 14);
            this.lblTaxType.TabIndex = 500;
            this.lblTaxType.Text = "Tax Type";
            // 
            // pnlNoteType
            // 
            this.pnlNoteType.Controls.Add(this.txtSalesNoteType);
            this.pnlNoteType.Controls.Add(this.lblSalesNoteType);
            this.pnlNoteType.Location = new System.Drawing.Point(0, 277);
            this.pnlNoteType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNoteType.Name = "pnlNoteType";
            this.pnlNoteType.Size = new System.Drawing.Size(327, 27);
            this.pnlNoteType.TabIndex = 580;
            // 
            // txtSalesNoteType
            // 
            this.txtSalesNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesNoteType.Location = new System.Drawing.Point(115, 2);
            this.txtSalesNoteType.Name = "txtSalesNoteType";
            this.txtSalesNoteType.ReadOnly = true;
            this.txtSalesNoteType.Size = new System.Drawing.Size(207, 22);
            this.txtSalesNoteType.TabIndex = 562;
            this.txtSalesNoteType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSalesNoteType_MouseDoubleClick);
            // 
            // lblSalesNoteType
            // 
            this.lblSalesNoteType.AutoSize = true;
            this.lblSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesNoteType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSalesNoteType.Location = new System.Drawing.Point(4, 6);
            this.lblSalesNoteType.Name = "lblSalesNoteType";
            this.lblSalesNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblSalesNoteType.TabIndex = 563;
            this.lblSalesNoteType.Text = "Note Type";
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDate.Controls.Add(this.label5);
            this.pnlDate.Controls.Add(this.label6);
            this.pnlDate.Controls.Add(this.dtpFrom);
            this.pnlDate.Controls.Add(this.dtpTo);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(8, 530);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(326, 60);
            this.pnlDate.TabIndex = 587;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Period From :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(9, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 14);
            this.label6.TabIndex = 585;
            this.label6.Text = "Period To :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(115, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(207, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(115, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(207, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // frm_rpt_TaxReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 561);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlReportGrid);
            this.Controls.Add(this.pnlFooter);
            this.Name = "frm_rpt_TaxReports";
            this.Text = "Tax Reports";
            this.Load += new System.EventHandler(this.frm_rpt_TaxReports_Load);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.Controls.SetChildIndex(this.pnlReportGrid, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.pnlReportGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlBranch.ResumeLayout(false);
            this.pnlBranch.PerformLayout();
            this.flowLayoutSupplierDetailPanel.ResumeLayout(false);
            this.pnlSupplier.ResumeLayout(false);
            this.pnlSupplier.PerformLayout();
            this.pnlSupClass.ResumeLayout(false);
            this.pnlSupClass.PerformLayout();
            this.pnlSupType.ResumeLayout(false);
            this.pnlSupType.PerformLayout();
            this.pnlSupCategory.ResumeLayout(false);
            this.pnlSupCategory.PerformLayout();
            this.pnlNoteT.ResumeLayout(false);
            this.pnlNoteT.PerformLayout();
            this.flowLayoutCustomerDetailPanel.ResumeLayout(false);
            this.pnlCusType.ResumeLayout(false);
            this.pnlCusType.PerformLayout();
            this.pnlCusName.ResumeLayout(false);
            this.pnlCusName.PerformLayout();
            this.pnlSalesman.ResumeLayout(false);
            this.pnlSalesman.PerformLayout();
            this.pnlRoute.ResumeLayout(false);
            this.pnlRoute.PerformLayout();
            this.pnlTaxType.ResumeLayout(false);
            this.pnlTaxType.PerformLayout();
            this.pnlNoteType.ResumeLayout(false);
            this.pnlNoteType.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReportGrid;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlCusType;
        private System.Windows.Forms.Label lblCusCategory;
        private System.Windows.Forms.TextBox txtCusClass;
        private System.Windows.Forms.TextBox txtCusCategory;
        private System.Windows.Forms.Label lblCusClass;
        private System.Windows.Forms.Label lblCusType;
        private System.Windows.Forms.TextBox txtCusType;
        private System.Windows.Forms.Panel pnlCusName;
        private System.Windows.Forms.CheckBox chkShowAll_Customers;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Panel pnlSalesman;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Panel pnlRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Panel pnlNoteType;
        private System.Windows.Forms.TextBox txtSalesNoteType;
        private System.Windows.Forms.Label lblSalesNoteType;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlBranch;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Panel pnlTaxType;
        private System.Windows.Forms.ComboBox cmbTaxType;
        private System.Windows.Forms.Label lblTaxType;
        private System.Windows.Forms.CheckBox chkUseCustomerMastorSaleRep;
        private System.Windows.Forms.CheckBox chkUseCustomerMasterRoute;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSupplierDetailPanel;
        private System.Windows.Forms.Panel pnlSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Panel pnlSupClass;
        private System.Windows.Forms.TextBox txtSupClass;
        private System.Windows.Forms.Label lblSupClass;
        private System.Windows.Forms.Panel pnlSupType;
        private System.Windows.Forms.TextBox txtSupType;
        private System.Windows.Forms.Label lblSupType;
        private System.Windows.Forms.Panel pnlSupCategory;
        private System.Windows.Forms.TextBox txtSupCategory;
        private System.Windows.Forms.Label lblSupCategory;
        private System.Windows.Forms.Panel pnlNoteT;
        private System.Windows.Forms.TextBox txtNoteType;
        private System.Windows.Forms.Label lblNoteType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCustomerDetailPanel;
        private System.Windows.Forms.CheckBox chkShowAll_Branch;
    }
}