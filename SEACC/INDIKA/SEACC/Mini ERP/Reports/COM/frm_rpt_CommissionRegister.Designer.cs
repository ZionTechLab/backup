namespace Digiteq.Reports.COM
{
    partial class frm_rpt_CommissionRegister
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlComPeriod = new System.Windows.Forms.Panel();
            this.lblCommissionPeriod = new System.Windows.Forms.Label();
            this.txtComPeriod = new System.Windows.Forms.TextBox();
            this.pnlSalesman = new System.Windows.Forms.Panel();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.pnlAreeaManager = new System.Windows.Forms.Panel();
            this.txtAreaManager = new System.Windows.Forms.TextBox();
            this.lblAreaManager = new System.Windows.Forms.Label();
            this.pnlSalesManager = new System.Windows.Forms.Panel();
            this.txtSalesManager = new System.Windows.Forms.TextBox();
            this.lblSalesManager = new System.Windows.Forms.Label();
            this.pnlCollector = new System.Windows.Forms.Panel();
            this.txtCollector = new System.Windows.Forms.TextBox();
            this.lblCollector = new System.Windows.Forms.Label();
            this.pnlItemType = new System.Windows.Forms.Panel();
            this.lblItemType = new System.Windows.Forms.Label();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.pnlItemCategory = new System.Windows.Forms.Panel();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.lblItemCategory = new System.Windows.Forms.Label();
            this.pnldays = new System.Windows.Forms.Panel();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReports = new Digiteq.SEACC_DataGrid();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnPrint = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlComPeriod.SuspendLayout();
            this.pnlSalesman.SuspendLayout();
            this.pnlAreeaManager.SuspendLayout();
            this.pnlSalesManager.SuspendLayout();
            this.pnlCollector.SuspendLayout();
            this.pnlItemType.SuspendLayout();
            this.pnlItemCategory.SuspendLayout();
            this.pnldays.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlComPeriod);
            this.flowLayoutPanel1.Controls.Add(this.pnlSalesman);
            this.flowLayoutPanel1.Controls.Add(this.pnlAreeaManager);
            this.flowLayoutPanel1.Controls.Add(this.pnlSalesManager);
            this.flowLayoutPanel1.Controls.Add(this.pnlCollector);
            this.flowLayoutPanel1.Controls.Add(this.pnlItemType);
            this.flowLayoutPanel1.Controls.Add(this.pnlItemCategory);
            this.flowLayoutPanel1.Controls.Add(this.pnldays);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(332, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 243);
            this.flowLayoutPanel1.TabIndex = 597;
            // 
            // pnlComPeriod
            // 
            this.pnlComPeriod.Controls.Add(this.lblCommissionPeriod);
            this.pnlComPeriod.Controls.Add(this.txtComPeriod);
            this.pnlComPeriod.Location = new System.Drawing.Point(0, 10);
            this.pnlComPeriod.Margin = new System.Windows.Forms.Padding(0);
            this.pnlComPeriod.Name = "pnlComPeriod";
            this.pnlComPeriod.Size = new System.Drawing.Size(282, 27);
            this.pnlComPeriod.TabIndex = 588;
            // 
            // lblCommissionPeriod
            // 
            this.lblCommissionPeriod.AutoSize = true;
            this.lblCommissionPeriod.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommissionPeriod.ForeColor = System.Drawing.Color.Black;
            this.lblCommissionPeriod.Location = new System.Drawing.Point(2, 6);
            this.lblCommissionPeriod.Name = "lblCommissionPeriod";
            this.lblCommissionPeriod.Size = new System.Drawing.Size(75, 14);
            this.lblCommissionPeriod.TabIndex = 495;
            this.lblCommissionPeriod.Text = "Risk A. Period";
            // 
            // txtComPeriod
            // 
            this.txtComPeriod.BackColor = System.Drawing.Color.LightGray;
            this.txtComPeriod.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComPeriod.Location = new System.Drawing.Point(106, 2);
            this.txtComPeriod.Name = "txtComPeriod";
            this.txtComPeriod.ReadOnly = true;
            this.txtComPeriod.Size = new System.Drawing.Size(162, 22);
            this.txtComPeriod.TabIndex = 494;
            this.txtComPeriod.DoubleClick += new System.EventHandler(this.txtComPeriod_DoubleClick);
            // 
            // pnlSalesman
            // 
            this.pnlSalesman.Controls.Add(this.txtSalesRep);
            this.pnlSalesman.Controls.Add(this.lblSalseRep);
            this.pnlSalesman.Location = new System.Drawing.Point(0, 37);
            this.pnlSalesman.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesman.Name = "pnlSalesman";
            this.pnlSalesman.Size = new System.Drawing.Size(282, 27);
            this.pnlSalesman.TabIndex = 589;
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(106, 2);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(162, 22);
            this.txtSalesRep.TabIndex = 459;
            this.txtSalesRep.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSalesRep_MouseDoubleClick);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.Black;
            this.lblSalseRep.Location = new System.Drawing.Point(2, 6);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(88, 14);
            this.lblSalseRep.TabIndex = 460;
            this.lblSalseRep.Text = "Salesman Name";
            // 
            // pnlAreeaManager
            // 
            this.pnlAreeaManager.Controls.Add(this.txtAreaManager);
            this.pnlAreeaManager.Controls.Add(this.lblAreaManager);
            this.pnlAreeaManager.Location = new System.Drawing.Point(0, 64);
            this.pnlAreeaManager.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAreeaManager.Name = "pnlAreeaManager";
            this.pnlAreeaManager.Size = new System.Drawing.Size(282, 27);
            this.pnlAreeaManager.TabIndex = 590;
            // 
            // txtAreaManager
            // 
            this.txtAreaManager.BackColor = System.Drawing.Color.LightGray;
            this.txtAreaManager.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaManager.Location = new System.Drawing.Point(106, 2);
            this.txtAreaManager.Name = "txtAreaManager";
            this.txtAreaManager.ReadOnly = true;
            this.txtAreaManager.Size = new System.Drawing.Size(162, 22);
            this.txtAreaManager.TabIndex = 459;
            this.txtAreaManager.DoubleClick += new System.EventHandler(this.txtAreaManager_DoubleClick);
            // 
            // lblAreaManager
            // 
            this.lblAreaManager.AutoSize = true;
            this.lblAreaManager.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaManager.ForeColor = System.Drawing.Color.Black;
            this.lblAreaManager.Location = new System.Drawing.Point(2, 6);
            this.lblAreaManager.Name = "lblAreaManager";
            this.lblAreaManager.Size = new System.Drawing.Size(77, 14);
            this.lblAreaManager.TabIndex = 460;
            this.lblAreaManager.Text = "Area Manager";
            // 
            // pnlSalesManager
            // 
            this.pnlSalesManager.Controls.Add(this.txtSalesManager);
            this.pnlSalesManager.Controls.Add(this.lblSalesManager);
            this.pnlSalesManager.Location = new System.Drawing.Point(0, 91);
            this.pnlSalesManager.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesManager.Name = "pnlSalesManager";
            this.pnlSalesManager.Size = new System.Drawing.Size(282, 27);
            this.pnlSalesManager.TabIndex = 591;
            // 
            // txtSalesManager
            // 
            this.txtSalesManager.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesManager.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesManager.Location = new System.Drawing.Point(106, 2);
            this.txtSalesManager.Name = "txtSalesManager";
            this.txtSalesManager.ReadOnly = true;
            this.txtSalesManager.Size = new System.Drawing.Size(162, 22);
            this.txtSalesManager.TabIndex = 459;
            this.txtSalesManager.DoubleClick += new System.EventHandler(this.txtSalesManager_DoubleClick);
            // 
            // lblSalesManager
            // 
            this.lblSalesManager.AutoSize = true;
            this.lblSalesManager.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesManager.ForeColor = System.Drawing.Color.Black;
            this.lblSalesManager.Location = new System.Drawing.Point(2, 6);
            this.lblSalesManager.Name = "lblSalesManager";
            this.lblSalesManager.Size = new System.Drawing.Size(80, 14);
            this.lblSalesManager.TabIndex = 460;
            this.lblSalesManager.Text = "Sales Manager";
            // 
            // pnlCollector
            // 
            this.pnlCollector.Controls.Add(this.txtCollector);
            this.pnlCollector.Controls.Add(this.lblCollector);
            this.pnlCollector.Location = new System.Drawing.Point(0, 118);
            this.pnlCollector.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCollector.Name = "pnlCollector";
            this.pnlCollector.Size = new System.Drawing.Size(282, 27);
            this.pnlCollector.TabIndex = 592;
            // 
            // txtCollector
            // 
            this.txtCollector.BackColor = System.Drawing.Color.LightGray;
            this.txtCollector.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollector.Location = new System.Drawing.Point(106, 2);
            this.txtCollector.Name = "txtCollector";
            this.txtCollector.ReadOnly = true;
            this.txtCollector.Size = new System.Drawing.Size(162, 22);
            this.txtCollector.TabIndex = 459;
            this.txtCollector.DoubleClick += new System.EventHandler(this.txtCollector_DoubleClick);
            // 
            // lblCollector
            // 
            this.lblCollector.AutoSize = true;
            this.lblCollector.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollector.ForeColor = System.Drawing.Color.Black;
            this.lblCollector.Location = new System.Drawing.Point(2, 6);
            this.lblCollector.Name = "lblCollector";
            this.lblCollector.Size = new System.Drawing.Size(50, 14);
            this.lblCollector.TabIndex = 460;
            this.lblCollector.Text = "Collector";
            // 
            // pnlItemType
            // 
            this.pnlItemType.Controls.Add(this.lblItemType);
            this.pnlItemType.Controls.Add(this.txtItemType);
            this.pnlItemType.Location = new System.Drawing.Point(0, 145);
            this.pnlItemType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlItemType.Name = "pnlItemType";
            this.pnlItemType.Size = new System.Drawing.Size(282, 27);
            this.pnlItemType.TabIndex = 589;
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemType.ForeColor = System.Drawing.Color.Black;
            this.lblItemType.Location = new System.Drawing.Point(2, 6);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(57, 14);
            this.lblItemType.TabIndex = 574;
            this.lblItemType.Text = "Item Type";
            // 
            // txtItemType
            // 
            this.txtItemType.BackColor = System.Drawing.Color.LightGray;
            this.txtItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemType.Location = new System.Drawing.Point(106, 2);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.ReadOnly = true;
            this.txtItemType.Size = new System.Drawing.Size(162, 22);
            this.txtItemType.TabIndex = 573;
            this.txtItemType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtItemType_MouseDoubleClick);
            // 
            // pnlItemCategory
            // 
            this.pnlItemCategory.Controls.Add(this.txtItemCategory);
            this.pnlItemCategory.Controls.Add(this.lblItemCategory);
            this.pnlItemCategory.Location = new System.Drawing.Point(0, 172);
            this.pnlItemCategory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlItemCategory.Name = "pnlItemCategory";
            this.pnlItemCategory.Size = new System.Drawing.Size(282, 27);
            this.pnlItemCategory.TabIndex = 589;
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.Location = new System.Drawing.Point(106, 2);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.ReadOnly = true;
            this.txtItemCategory.Size = new System.Drawing.Size(162, 22);
            this.txtItemCategory.TabIndex = 575;
            this.txtItemCategory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtItemCategory_MouseDoubleClick);
            // 
            // lblItemCategory
            // 
            this.lblItemCategory.AutoSize = true;
            this.lblItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCategory.ForeColor = System.Drawing.Color.Black;
            this.lblItemCategory.Location = new System.Drawing.Point(2, 6);
            this.lblItemCategory.Name = "lblItemCategory";
            this.lblItemCategory.Size = new System.Drawing.Size(77, 14);
            this.lblItemCategory.TabIndex = 576;
            this.lblItemCategory.Text = "Item Category";
            // 
            // pnldays
            // 
            this.pnldays.Controls.Add(this.txtDays);
            this.pnldays.Controls.Add(this.label1);
            this.pnldays.Location = new System.Drawing.Point(0, 199);
            this.pnldays.Margin = new System.Windows.Forms.Padding(0);
            this.pnldays.Name = "pnldays";
            this.pnldays.Size = new System.Drawing.Size(282, 27);
            this.pnldays.TabIndex = 593;
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.SystemColors.Control;
            this.txtDays.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.Location = new System.Drawing.Point(106, 2);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(162, 22);
            this.txtDays.TabIndex = 575;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 576;
            this.label1.Text = "Days";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvReports);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(1, 38);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(331, 243);
            this.pnlGrid.TabIndex = 598;
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
            this.dgvReports.Size = new System.Drawing.Size(321, 238);
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
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.panel2);
            this.pnlButton.Controls.Add(this.btnClear);
            this.pnlButton.Controls.Add(this.ProgressBar);
            this.pnlButton.Controls.Add(this.btnPrint);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(1, 281);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(615, 42);
            this.pnlButton.TabIndex = 599;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 2);
            this.panel2.TabIndex = 588;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(436, 9);
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
            this.ProgressBar.Size = new System.Drawing.Size(416, 25);
            this.ProgressBar.TabIndex = 487;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(523, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 485;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frm_rpt_CommissionRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 324);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlButton);
            this.Name = "frm_rpt_CommissionRegister";
            this.Text = "Risk Allowance Register";
            this.Load += new System.EventHandler(this.frm_rpt_CommissionRegister_Load);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlComPeriod.ResumeLayout(false);
            this.pnlComPeriod.PerformLayout();
            this.pnlSalesman.ResumeLayout(false);
            this.pnlSalesman.PerformLayout();
            this.pnlAreeaManager.ResumeLayout(false);
            this.pnlAreeaManager.PerformLayout();
            this.pnlSalesManager.ResumeLayout(false);
            this.pnlSalesManager.PerformLayout();
            this.pnlCollector.ResumeLayout(false);
            this.pnlCollector.PerformLayout();
            this.pnlItemType.ResumeLayout(false);
            this.pnlItemType.PerformLayout();
            this.pnlItemCategory.ResumeLayout(false);
            this.pnlItemCategory.PerformLayout();
            this.pnldays.ResumeLayout(false);
            this.pnldays.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlComPeriod;
        private System.Windows.Forms.Label lblCommissionPeriod;
        private System.Windows.Forms.TextBox txtComPeriod;
        private System.Windows.Forms.Panel pnlItemType;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.Panel pnlItemCategory;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Label lblItemCategory;
        private System.Windows.Forms.Panel pnlGrid;
        private SEACC_DataGrid dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlSalesman;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.Panel pnlAreeaManager;
        private System.Windows.Forms.TextBox txtAreaManager;
        private System.Windows.Forms.Label lblAreaManager;
        private System.Windows.Forms.Panel pnlSalesManager;
        private System.Windows.Forms.TextBox txtSalesManager;
        private System.Windows.Forms.Label lblSalesManager;
        private System.Windows.Forms.Panel pnlCollector;
        private System.Windows.Forms.TextBox txtCollector;
        private System.Windows.Forms.Label lblCollector;
        private System.Windows.Forms.Panel pnldays;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label1;
    }
}