namespace Digiteq
{
    partial class frm_rpt_StockRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_StockRegister));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.rdoActual = new System.Windows.Forms.RadioButton();
            this.lblBranch = new System.Windows.Forms.Label();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.txtStockNoteType = new System.Windows.Forms.TextBox();
            this.pnlDateRange = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblNoteType = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlStore = new System.Windows.Forms.Panel();
            this.pnlSection = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDepartment = new System.Windows.Forms.Panel();
            this.pnlNoteType = new System.Windows.Forms.Panel();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.ckhShowAll = new System.Windows.Forms.CheckBox();
            this.pnlSupplier = new System.Windows.Forms.Panel();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.txtItemSerialNo = new System.Windows.Forms.TextBox();
            this.txtItemSubCategory = new System.Windows.Forms.TextBox();
            this.pnlBranch = new System.Windows.Forms.Panel();
            this.pnlRadioButtons = new System.Windows.Forms.Panel();
            this.pnlDateRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlStore.SuspendLayout();
            this.pnlSection.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlDepartment.SuspendLayout();
            this.pnlNoteType.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlSupplier.SuspendLayout();
            this.pnlItem.SuspendLayout();
            this.pnlBranch.SuspendLayout();
            this.pnlRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(517, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 478;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(598, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 477;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.Black;
            this.rdoAll.Location = new System.Drawing.Point(111, 53);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(80, 18);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.LightGray;
            this.txtBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(111, 4);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(155, 22);
            this.txtBranch.TabIndex = 506;
            this.txtBranch.DoubleClick += new System.EventHandler(this.txtBranch_DoubleClick);
            // 
            // rdoActual
            // 
            this.rdoActual.AutoSize = true;
            this.rdoActual.Checked = true;
            this.rdoActual.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActual.ForeColor = System.Drawing.Color.Black;
            this.rdoActual.Location = new System.Drawing.Point(111, 33);
            this.rdoActual.Name = "rdoActual";
            this.rdoActual.Size = new System.Drawing.Size(124, 18);
            this.rdoActual.TabIndex = 10;
            this.rdoActual.TabStop = true;
            this.rdoActual.Text = "Active Records Only";
            this.rdoActual.UseVisualStyleBackColor = true;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.Black;
            this.lblBranch.Location = new System.Drawing.Point(7, 8);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 14);
            this.lblBranch.TabIndex = 507;
            this.lblBranch.Text = "Branch";
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeleted.ForeColor = System.Drawing.Color.Black;
            this.rdoDeleted.Location = new System.Drawing.Point(111, 13);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(132, 18);
            this.rdoDeleted.TabIndex = 9;
            this.rdoDeleted.Text = "Deleted Records Only";
            this.rdoDeleted.UseVisualStyleBackColor = true;
            // 
            // txtStockNoteType
            // 
            this.txtStockNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtStockNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockNoteType.Location = new System.Drawing.Point(111, 4);
            this.txtStockNoteType.Name = "txtStockNoteType";
            this.txtStockNoteType.ReadOnly = true;
            this.txtStockNoteType.Size = new System.Drawing.Size(155, 22);
            this.txtStockNoteType.TabIndex = 504;
            this.txtStockNoteType.DoubleClick += new System.EventHandler(this.txtStockNoteType_DoubleClick);
            this.txtStockNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStockNoteType_KeyDown);
            // 
            // pnlDateRange
            // 
            this.pnlDateRange.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDateRange.Controls.Add(this.lblFrom);
            this.pnlDateRange.Controls.Add(this.dtpFrom);
            this.pnlDateRange.Controls.Add(this.dtpTo);
            this.pnlDateRange.Controls.Add(this.lblTo);
            this.pnlDateRange.Location = new System.Drawing.Point(0, 260);
            this.pnlDateRange.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlDateRange.Name = "pnlDateRange";
            this.pnlDateRange.Size = new System.Drawing.Size(330, 67);
            this.pnlDateRange.TabIndex = 480;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFrom.Location = new System.Drawing.Point(11, 12);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(73, 14);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(115, 8);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(155, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(115, 36);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(155, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTo.Location = new System.Drawing.Point(11, 40);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(58, 14);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "Period To :";
            // 
            // lblNoteType
            // 
            this.lblNoteType.AutoSize = true;
            this.lblNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblNoteType.Location = new System.Drawing.Point(7, 8);
            this.lblNoteType.Name = "lblNoteType";
            this.lblNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblNoteType.TabIndex = 505;
            this.lblNoteType.Text = "Note Type";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemID.ForeColor = System.Drawing.Color.Black;
            this.lblItemID.Location = new System.Drawing.Point(7, 8);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(63, 14);
            this.lblItemID.TabIndex = 500;
            this.lblItemID.Text = "Item Name";
            // 
            // txtItemID
            // 
            this.txtItemID.BackColor = System.Drawing.Color.LightGray;
            this.txtItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(111, 4);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(155, 22);
            this.txtItemID.TabIndex = 501;
            this.txtItemID.DoubleClick += new System.EventHandler(this.txtItem_DoubleClick);
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyDown);
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(111, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(155, 22);
            this.txtCustomer.TabIndex = 463;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick_1);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(7, 8);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 464;
            this.lblCustomer.Text = "Customer Name";
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.LightGray;
            this.txtSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(111, 4);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(155, 22);
            this.txtSupplier.TabIndex = 463;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplier_KeyDown);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.Color.Black;
            this.lblSupplier.Location = new System.Drawing.Point(7, 8);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(80, 14);
            this.lblSupplier.TabIndex = 464;
            this.lblSupplier.Text = "Supplier Name";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.LightGray;
            this.txtDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(111, 4);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(155, 22);
            this.txtDepartment.TabIndex = 0;
            this.txtDepartment.DoubleClick += new System.EventHandler(this.txtDepartment_DoubleClick);
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartment_KeyDown);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(7, 8);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(100, 14);
            this.lblDepartment.TabIndex = 12;
            this.lblDepartment.Text = "Department Name";
            // 
            // txtSection
            // 
            this.txtSection.BackColor = System.Drawing.Color.LightGray;
            this.txtSection.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(111, 3);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(155, 22);
            this.txtSection.TabIndex = 0;
            this.txtSection.DoubleClick += new System.EventHandler(this.txtSection_DoubleClick);
            this.txtSection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSection_KeyDown);
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.Black;
            this.lblSection.Location = new System.Drawing.Point(7, 6);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(76, 14);
            this.lblSection.TabIndex = 12;
            this.lblSection.Text = "Section Name";
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.LightGray;
            this.txtStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStore.Location = new System.Drawing.Point(111, 4);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(155, 22);
            this.txtStore.TabIndex = 0;
            this.txtStore.DoubleClick += new System.EventHandler(this.txtStore_DoubleClick);
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStore_KeyDown);
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.ForeColor = System.Drawing.Color.Black;
            this.lblStore.Location = new System.Drawing.Point(7, 8);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(69, 14);
            this.lblStore.TabIndex = 12;
            this.lblStore.Text = "Store Name ";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(11, 9);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(500, 25);
            this.ProgressBar.TabIndex = 484;
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
            this.dgvReports.Location = new System.Drawing.Point(9, 7);
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
            this.dgvReports.Size = new System.Drawing.Size(321, 530);
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
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrid.Controls.Add(this.dgvReports);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlGrid.Location = new System.Drawing.Point(3, 29);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(337, 543);
            this.pnlGrid.TabIndex = 482;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.ProgressBar);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel2.Location = new System.Drawing.Point(3, 572);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 42);
            this.panel2.TabIndex = 482;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 2);
            this.panel1.TabIndex = 588;
            // 
            // pnlStore
            // 
            this.pnlStore.Controls.Add(this.lblStore);
            this.pnlStore.Controls.Add(this.txtStore);
            this.pnlStore.Location = new System.Drawing.Point(0, 10);
            this.pnlStore.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStore.Name = "pnlStore";
            this.pnlStore.Size = new System.Drawing.Size(282, 30);
            this.pnlStore.TabIndex = 508;
            // 
            // pnlSection
            // 
            this.pnlSection.Controls.Add(this.txtSection);
            this.pnlSection.Controls.Add(this.lblSection);
            this.pnlSection.Location = new System.Drawing.Point(0, 40);
            this.pnlSection.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSection.Name = "pnlSection";
            this.pnlSection.Size = new System.Drawing.Size(282, 30);
            this.pnlSection.TabIndex = 509;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlStore);
            this.flowLayoutPanel1.Controls.Add(this.pnlSection);
            this.flowLayoutPanel1.Controls.Add(this.pnlDepartment);
            this.flowLayoutPanel1.Controls.Add(this.pnlNoteType);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomer);
            this.flowLayoutPanel1.Controls.Add(this.pnlSupplier);
            this.flowLayoutPanel1.Controls.Add(this.pnlItem);
            this.flowLayoutPanel1.Controls.Add(this.pnlBranch);
            this.flowLayoutPanel1.Controls.Add(this.pnlDateRange);
            this.flowLayoutPanel1.Controls.Add(this.pnlRadioButtons);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(340, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(347, 543);
            this.flowLayoutPanel1.TabIndex = 510;
            // 
            // pnlDepartment
            // 
            this.pnlDepartment.Controls.Add(this.lblDepartment);
            this.pnlDepartment.Controls.Add(this.txtDepartment);
            this.pnlDepartment.Location = new System.Drawing.Point(0, 70);
            this.pnlDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDepartment.Name = "pnlDepartment";
            this.pnlDepartment.Size = new System.Drawing.Size(282, 30);
            this.pnlDepartment.TabIndex = 510;
            // 
            // pnlNoteType
            // 
            this.pnlNoteType.Controls.Add(this.txtStockNoteType);
            this.pnlNoteType.Controls.Add(this.lblNoteType);
            this.pnlNoteType.Location = new System.Drawing.Point(0, 100);
            this.pnlNoteType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNoteType.Name = "pnlNoteType";
            this.pnlNoteType.Size = new System.Drawing.Size(282, 30);
            this.pnlNoteType.TabIndex = 511;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.ckhShowAll);
            this.pnlCustomer.Controls.Add(this.txtCustomer);
            this.pnlCustomer.Controls.Add(this.lblCustomer);
            this.pnlCustomer.Location = new System.Drawing.Point(0, 130);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(344, 30);
            this.pnlCustomer.TabIndex = 512;
            // 
            // ckhShowAll
            // 
            this.ckhShowAll.AutoSize = true;
            this.ckhShowAll.Location = new System.Drawing.Point(270, 7);
            this.ckhShowAll.Name = "ckhShowAll";
            this.ckhShowAll.Size = new System.Drawing.Size(71, 17);
            this.ckhShowAll.TabIndex = 557;
            this.ckhShowAll.Text = "Show All";
            this.ckhShowAll.UseVisualStyleBackColor = true;
            // 
            // pnlSupplier
            // 
            this.pnlSupplier.Controls.Add(this.txtSupplier);
            this.pnlSupplier.Controls.Add(this.lblSupplier);
            this.pnlSupplier.Location = new System.Drawing.Point(0, 160);
            this.pnlSupplier.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupplier.Name = "pnlSupplier";
            this.pnlSupplier.Size = new System.Drawing.Size(282, 30);
            this.pnlSupplier.TabIndex = 512;
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.txtItemSerialNo);
            this.pnlItem.Controls.Add(this.txtItemSubCategory);
            this.pnlItem.Controls.Add(this.txtItemID);
            this.pnlItem.Controls.Add(this.lblItemID);
            this.pnlItem.Location = new System.Drawing.Point(0, 190);
            this.pnlItem.Margin = new System.Windows.Forms.Padding(0);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(282, 30);
            this.pnlItem.TabIndex = 513;
            // 
            // txtItemSerialNo
            // 
            this.txtItemSerialNo.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSerialNo.Location = new System.Drawing.Point(95, 4);
            this.txtItemSerialNo.Name = "txtItemSerialNo";
            this.txtItemSerialNo.ReadOnly = true;
            this.txtItemSerialNo.Size = new System.Drawing.Size(10, 22);
            this.txtItemSerialNo.TabIndex = 503;
            this.txtItemSerialNo.Visible = false;
            // 
            // txtItemSubCategory
            // 
            this.txtItemSubCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubCategory.Location = new System.Drawing.Point(79, 4);
            this.txtItemSubCategory.Name = "txtItemSubCategory";
            this.txtItemSubCategory.ReadOnly = true;
            this.txtItemSubCategory.Size = new System.Drawing.Size(10, 22);
            this.txtItemSubCategory.TabIndex = 502;
            this.txtItemSubCategory.Visible = false;
            // 
            // pnlBranch
            // 
            this.pnlBranch.Controls.Add(this.txtBranch);
            this.pnlBranch.Controls.Add(this.lblBranch);
            this.pnlBranch.Location = new System.Drawing.Point(0, 220);
            this.pnlBranch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBranch.Name = "pnlBranch";
            this.pnlBranch.Size = new System.Drawing.Size(282, 30);
            this.pnlBranch.TabIndex = 514;
            // 
            // pnlRadioButtons
            // 
            this.pnlRadioButtons.Controls.Add(this.rdoDeleted);
            this.pnlRadioButtons.Controls.Add(this.rdoAll);
            this.pnlRadioButtons.Controls.Add(this.rdoActual);
            this.pnlRadioButtons.Location = new System.Drawing.Point(0, 327);
            this.pnlRadioButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRadioButtons.Name = "pnlRadioButtons";
            this.pnlRadioButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlRadioButtons.Size = new System.Drawing.Size(282, 76);
            this.pnlRadioButtons.TabIndex = 515;
            // 
            // frm_rpt_StockRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(690, 617);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panel2);
            this.Name = "frm_rpt_StockRegister";
            this.Text = "Stock Register";
            this.Load += new System.EventHandler(this.frm_rpt_StockRegister_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.pnlDateRange.ResumeLayout(false);
            this.pnlDateRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlStore.ResumeLayout(false);
            this.pnlStore.PerformLayout();
            this.pnlSection.ResumeLayout(false);
            this.pnlSection.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlDepartment.ResumeLayout(false);
            this.pnlDepartment.PerformLayout();
            this.pnlNoteType.ResumeLayout(false);
            this.pnlNoteType.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlSupplier.ResumeLayout(false);
            this.pnlSupplier.PerformLayout();
            this.pnlItem.ResumeLayout(false);
            this.pnlItem.PerformLayout();
            this.pnlBranch.ResumeLayout(false);
            this.pnlBranch.PerformLayout();
            this.pnlRadioButtons.ResumeLayout(false);
            this.pnlRadioButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Panel pnlDateRange;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoActual;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.TextBox txtStockNoteType;
        private System.Windows.Forms.Label lblNoteType;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.Panel pnlStore;
        private System.Windows.Forms.Panel pnlSection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlDepartment;
        private System.Windows.Forms.Panel pnlNoteType;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Panel pnlSupplier;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.Panel pnlBranch;
        private System.Windows.Forms.Panel pnlRadioButtons;
        private System.Windows.Forms.TextBox txtItemSerialNo;
        private System.Windows.Forms.TextBox txtItemSubCategory;
        private System.Windows.Forms.CheckBox ckhShowAll;
    }
}