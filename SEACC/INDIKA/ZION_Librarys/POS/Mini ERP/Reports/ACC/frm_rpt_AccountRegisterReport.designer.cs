namespace Digiteq
{
    partial class frm_rpt_AccountRegisterReport
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
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblJVType = new System.Windows.Forms.Label();
            this.cmbJVTypes = new System.Windows.Forms.ComboBox();
            this.chkSupplierWiseReport = new System.Windows.Forms.CheckBox();
            this.chkUseDateAsBillDate = new System.Windows.Forms.CheckBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.rdoActual = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSupplier = new System.Windows.Forms.Panel();
            this.pnlJETypes = new System.Windows.Forms.Panel();
            this.pnlBillDate = new System.Windows.Forms.Panel();
            this.pnlSupplierWiseReport = new System.Windows.Forms.Panel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlAllRecords = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.z1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlSupplier.SuspendLayout();
            this.pnlJETypes.SuspendLayout();
            this.pnlBillDate.SuspendLayout();
            this.pnlSupplierWiseReport.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlAllRecords.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(115, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(162, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(115, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(162, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // lblJVType
            // 
            this.lblJVType.AutoSize = true;
            this.lblJVType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJVType.ForeColor = System.Drawing.Color.Black;
            this.lblJVType.Location = new System.Drawing.Point(4, 5);
            this.lblJVType.Name = "lblJVType";
            this.lblJVType.Size = new System.Drawing.Size(98, 14);
            this.lblJVType.TabIndex = 479;
            this.lblJVType.Text = "Journal Entry Type";
            // 
            // cmbJVTypes
            // 
            this.cmbJVTypes.BackColor = System.Drawing.Color.LightGray;
            this.cmbJVTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbJVTypes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cmbJVTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbJVTypes.FormattingEnabled = true;
            this.cmbJVTypes.Items.AddRange(new object[] {
            "All",
            "Stranded",
            "Bank",
            "Debtor",
            "Creditor",
            "Advance"});
            this.cmbJVTypes.Location = new System.Drawing.Point(115, 2);
            this.cmbJVTypes.Name = "cmbJVTypes";
            this.cmbJVTypes.Size = new System.Drawing.Size(167, 22);
            this.cmbJVTypes.TabIndex = 478;
            // 
            // chkSupplierWiseReport
            // 
            this.chkSupplierWiseReport.AutoSize = true;
            this.chkSupplierWiseReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSupplierWiseReport.ForeColor = System.Drawing.Color.Black;
            this.chkSupplierWiseReport.Location = new System.Drawing.Point(115, 2);
            this.chkSupplierWiseReport.Name = "chkSupplierWiseReport";
            this.chkSupplierWiseReport.Size = new System.Drawing.Size(124, 18);
            this.chkSupplierWiseReport.TabIndex = 468;
            this.chkSupplierWiseReport.Text = "SupplierWiseReport";
            this.chkSupplierWiseReport.UseVisualStyleBackColor = true;
            // 
            // chkUseDateAsBillDate
            // 
            this.chkUseDateAsBillDate.AutoSize = true;
            this.chkUseDateAsBillDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkUseDateAsBillDate.ForeColor = System.Drawing.Color.Black;
            this.chkUseDateAsBillDate.Location = new System.Drawing.Point(115, 2);
            this.chkUseDateAsBillDate.Name = "chkUseDateAsBillDate";
            this.chkUseDateAsBillDate.Size = new System.Drawing.Size(141, 18);
            this.chkUseDateAsBillDate.TabIndex = 467;
            this.chkUseDateAsBillDate.Text = "Use Date as a Bill Date";
            this.chkUseDateAsBillDate.UseVisualStyleBackColor = true;
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.LightGray;
            this.txtSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(115, 2);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(167, 22);
            this.txtSupplier.TabIndex = 465;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplier_KeyDown);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.Color.Black;
            this.lblSupplier.Location = new System.Drawing.Point(4, 5);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(80, 14);
            this.lblSupplier.TabIndex = 466;
            this.lblSupplier.Text = "Supplier Name";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(515, 5);
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
            this.btnClear.Location = new System.Drawing.Point(436, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeleted.ForeColor = System.Drawing.Color.Black;
            this.rdoDeleted.Location = new System.Drawing.Point(115, 43);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(132, 18);
            this.rdoDeleted.TabIndex = 9;
            this.rdoDeleted.Text = "Deleted Records Only";
            this.rdoDeleted.UseVisualStyleBackColor = true;
            // 
            // rdoActual
            // 
            this.rdoActual.AutoSize = true;
            this.rdoActual.Checked = true;
            this.rdoActual.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActual.ForeColor = System.Drawing.Color.Black;
            this.rdoActual.Location = new System.Drawing.Point(115, 23);
            this.rdoActual.Name = "rdoActual";
            this.rdoActual.Size = new System.Drawing.Size(124, 18);
            this.rdoActual.TabIndex = 10;
            this.rdoActual.TabStop = true;
            this.rdoActual.Text = "Active Records Only";
            this.rdoActual.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.Black;
            this.rdoAll.Location = new System.Drawing.Point(115, 3);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(80, 18);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(14, 279);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(121, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.Visible = false;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
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
            this.displayName});
            this.dgvReports.Location = new System.Drawing.Point(6, 5);
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
            this.dgvReports.Size = new System.Drawing.Size(288, 302);
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
            // displayName
            // 
            this.displayName.DataPropertyName = "displayName";
            this.displayName.HeaderText = "displayName";
            this.displayName.Name = "displayName";
            this.displayName.ReadOnly = true;
            this.displayName.Width = 280;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBank.Location = new System.Drawing.Point(10, 39);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(65, 14);
            this.lblBank.TabIndex = 11;
            this.lblBank.Text = "Bank Name";
            // 
            // txtBank
            // 
            this.txtBank.BackColor = System.Drawing.Color.LightGray;
            this.txtBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(110, 35);
            this.txtBank.Name = "txtBank";
            this.txtBank.ReadOnly = true;
            this.txtBank.Size = new System.Drawing.Size(380, 22);
            this.txtBank.TabIndex = 1;
            this.txtBank.DoubleClick += new System.EventHandler(this.txtBank_DoubleClick);
            this.txtBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBank_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(10, 13);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name";
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.lblCustomer);
            this.z1.Controls.Add(this.txtBank);
            this.z1.Controls.Add(this.lblBank);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z1.Location = new System.Drawing.Point(22, 53);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(28, 10);
            this.z1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlSupplier);
            this.flowLayoutPanel1.Controls.Add(this.pnlJETypes);
            this.flowLayoutPanel1.Controls.Add(this.pnlBillDate);
            this.flowLayoutPanel1.Controls.Add(this.pnlSupplierWiseReport);
            this.flowLayoutPanel1.Controls.Add(this.pnlDate);
            this.flowLayoutPanel1.Controls.Add(this.pnlAllRecords);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(303, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(301, 313);
            this.flowLayoutPanel1.TabIndex = 579;
            // 
            // pnlSupplier
            // 
            this.pnlSupplier.Controls.Add(this.lblSupplier);
            this.pnlSupplier.Controls.Add(this.txtSupplier);
            this.pnlSupplier.Location = new System.Drawing.Point(5, 10);
            this.pnlSupplier.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupplier.Name = "pnlSupplier";
            this.pnlSupplier.Size = new System.Drawing.Size(292, 27);
            this.pnlSupplier.TabIndex = 581;
            // 
            // pnlJETypes
            // 
            this.pnlJETypes.Controls.Add(this.cmbJVTypes);
            this.pnlJETypes.Controls.Add(this.lblJVType);
            this.pnlJETypes.Location = new System.Drawing.Point(5, 37);
            this.pnlJETypes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlJETypes.Name = "pnlJETypes";
            this.pnlJETypes.Size = new System.Drawing.Size(292, 27);
            this.pnlJETypes.TabIndex = 582;
            // 
            // pnlBillDate
            // 
            this.pnlBillDate.Controls.Add(this.chkUseDateAsBillDate);
            this.pnlBillDate.Location = new System.Drawing.Point(5, 64);
            this.pnlBillDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBillDate.Name = "pnlBillDate";
            this.pnlBillDate.Size = new System.Drawing.Size(292, 27);
            this.pnlBillDate.TabIndex = 582;
            // 
            // pnlSupplierWiseReport
            // 
            this.pnlSupplierWiseReport.Controls.Add(this.chkSupplierWiseReport);
            this.pnlSupplierWiseReport.Location = new System.Drawing.Point(5, 91);
            this.pnlSupplierWiseReport.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupplierWiseReport.Name = "pnlSupplierWiseReport";
            this.pnlSupplierWiseReport.Size = new System.Drawing.Size(292, 27);
            this.pnlSupplierWiseReport.TabIndex = 582;
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDate.Controls.Add(this.label3);
            this.pnlDate.Controls.Add(this.dtpTo);
            this.pnlDate.Controls.Add(this.dtpFrom);
            this.pnlDate.Controls.Add(this.label4);
            this.pnlDate.Location = new System.Drawing.Point(5, 118);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(292, 60);
            this.pnlDate.TabIndex = 587;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Period From :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(8, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 585;
            this.label4.Text = "Period To :";
            // 
            // pnlAllRecords
            // 
            this.pnlAllRecords.Controls.Add(this.rdoDeleted);
            this.pnlAllRecords.Controls.Add(this.rdoActual);
            this.pnlAllRecords.Controls.Add(this.rdoAll);
            this.pnlAllRecords.Location = new System.Drawing.Point(5, 178);
            this.pnlAllRecords.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAllRecords.Name = "pnlAllRecords";
            this.pnlAllRecords.Size = new System.Drawing.Size(290, 64);
            this.pnlAllRecords.TabIndex = 596;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 35);
            this.panel1.TabIndex = 580;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvReports);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 313);
            this.panel2.TabIndex = 581;
            // 
            // frm_rpt_AccountRegisterReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(607, 380);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.z1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_AccountRegisterReport";
            this.Text = "Account Register Reports";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.txtCustomer, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlSupplier.ResumeLayout(false);
            this.pnlSupplier.PerformLayout();
            this.pnlJETypes.ResumeLayout(false);
            this.pnlJETypes.PerformLayout();
            this.pnlBillDate.ResumeLayout(false);
            this.pnlBillDate.PerformLayout();
            this.pnlSupplierWiseReport.ResumeLayout(false);
            this.pnlSupplierWiseReport.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlAllRecords.ResumeLayout(false);
            this.pnlAllRecords.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.RadioButton rdoActual;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.CheckBox chkUseDateAsBillDate;
        private System.Windows.Forms.CheckBox chkSupplierWiseReport;
        private System.Windows.Forms.Label lblJVType;
        private System.Windows.Forms.ComboBox cmbJVTypes;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlSupplier;
        private System.Windows.Forms.Panel pnlJETypes;
        private System.Windows.Forms.Panel pnlBillDate;
        private System.Windows.Forms.Panel pnlSupplierWiseReport;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlAllRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}