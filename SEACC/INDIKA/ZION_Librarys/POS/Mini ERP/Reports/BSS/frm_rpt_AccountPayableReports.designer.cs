namespace Digiteq
{
    partial class frm_rpt_AccountPayableReports
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
            this.pnlReports = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.pnlCreditorType = new System.Windows.Forms.Panel();
            this.cmbCreditorType = new System.Windows.Forms.ComboBox();
            this.lblCrediter = new System.Windows.Forms.Label();
            this.pnlNoteType = new System.Windows.Forms.Panel();
            this.txtNoteType = new System.Windows.Forms.TextBox();
            this.lblNoteType = new System.Windows.Forms.Label();
            this.pnlBranch = new System.Windows.Forms.Panel();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.pnlType = new System.Windows.Forms.Panel();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoLocal = new System.Windows.Forms.RadioButton();
            this.rdoExport = new System.Windows.Forms.RadioButton();
            this.pnlDBNOutstanding = new System.Windows.Forms.Panel();
            this.chkHidedebitNote = new System.Windows.Forms.CheckBox();
            this.pnlUseBillDate = new System.Windows.Forms.Panel();
            this.chkAPNDate = new System.Windows.Forms.CheckBox();
            this.pnlFromDate = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pnlToDate = new System.Windows.Forms.Panel();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.prog_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlReports.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlSupplier.SuspendLayout();
            this.pnlSupClass.SuspendLayout();
            this.pnlSupType.SuspendLayout();
            this.pnlSupCategory.SuspendLayout();
            this.pnlCreditorType.SuspendLayout();
            this.pnlNoteType.SuspendLayout();
            this.pnlBranch.SuspendLayout();
            this.pnlType.SuspendLayout();
            this.pnlDBNOutstanding.SuspendLayout();
            this.pnlUseBillDate.SuspendLayout();
            this.pnlFromDate.SuspendLayout();
            this.pnlToDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.Color.White;
            this.pnlReports.Controls.Add(this.flowLayoutPanel1);
            this.pnlReports.Controls.Add(this.dgvReports);
            this.pnlReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReports.Location = new System.Drawing.Point(0, 0);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(564, 346);
            this.pnlReports.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlSupplier);
            this.flowLayoutPanel1.Controls.Add(this.pnlSupClass);
            this.flowLayoutPanel1.Controls.Add(this.pnlSupType);
            this.flowLayoutPanel1.Controls.Add(this.pnlSupCategory);
            this.flowLayoutPanel1.Controls.Add(this.pnlCreditorType);
            this.flowLayoutPanel1.Controls.Add(this.pnlNoteType);
            this.flowLayoutPanel1.Controls.Add(this.pnlBranch);
            this.flowLayoutPanel1.Controls.Add(this.pnlType);
            this.flowLayoutPanel1.Controls.Add(this.pnlDBNOutstanding);
            this.flowLayoutPanel1.Controls.Add(this.pnlUseBillDate);
            this.flowLayoutPanel1.Controls.Add(this.pnlFromDate);
            this.flowLayoutPanel1.Controls.Add(this.pnlToDate);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(283, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(278, 325);
            this.flowLayoutPanel1.TabIndex = 487;
            // 
            // pnlSupplier
            // 
            this.pnlSupplier.Controls.Add(this.txtSupplier);
            this.pnlSupplier.Controls.Add(this.lblSupplier);
            this.pnlSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnlSupplier.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupplier.Name = "pnlSupplier";
            this.pnlSupplier.Size = new System.Drawing.Size(273, 27);
            this.pnlSupplier.TabIndex = 0;
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.LightGray;
            this.txtSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(97, 2);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(172, 22);
            this.txtSupplier.TabIndex = 461;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.Color.Black;
            this.lblSupplier.Location = new System.Drawing.Point(3, 6);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(80, 14);
            this.lblSupplier.TabIndex = 462;
            this.lblSupplier.Text = "Supplier Name";
            // 
            // pnlSupClass
            // 
            this.pnlSupClass.Controls.Add(this.txtSupClass);
            this.pnlSupClass.Controls.Add(this.lblSupClass);
            this.pnlSupClass.Location = new System.Drawing.Point(0, 27);
            this.pnlSupClass.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupClass.Name = "pnlSupClass";
            this.pnlSupClass.Size = new System.Drawing.Size(273, 27);
            this.pnlSupClass.TabIndex = 1;
            // 
            // txtSupClass
            // 
            this.txtSupClass.BackColor = System.Drawing.Color.LightGray;
            this.txtSupClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupClass.Location = new System.Drawing.Point(97, 2);
            this.txtSupClass.Name = "txtSupClass";
            this.txtSupClass.ReadOnly = true;
            this.txtSupClass.Size = new System.Drawing.Size(172, 22);
            this.txtSupClass.TabIndex = 579;
            this.txtSupClass.DoubleClick += new System.EventHandler(this.txtSupClass_DoubleClick);
            // 
            // lblSupClass
            // 
            this.lblSupClass.AutoSize = true;
            this.lblSupClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupClass.ForeColor = System.Drawing.Color.Black;
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
            this.pnlSupType.Location = new System.Drawing.Point(0, 54);
            this.pnlSupType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupType.Name = "pnlSupType";
            this.pnlSupType.Size = new System.Drawing.Size(273, 27);
            this.pnlSupType.TabIndex = 1;
            // 
            // txtSupType
            // 
            this.txtSupType.BackColor = System.Drawing.Color.LightGray;
            this.txtSupType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupType.Location = new System.Drawing.Point(97, 2);
            this.txtSupType.Name = "txtSupType";
            this.txtSupType.ReadOnly = true;
            this.txtSupType.Size = new System.Drawing.Size(172, 22);
            this.txtSupType.TabIndex = 581;
            this.txtSupType.DoubleClick += new System.EventHandler(this.txtSupType_DoubleClick);
            // 
            // lblSupType
            // 
            this.lblSupType.AutoSize = true;
            this.lblSupType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupType.ForeColor = System.Drawing.Color.Black;
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
            this.pnlSupCategory.Location = new System.Drawing.Point(0, 81);
            this.pnlSupCategory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSupCategory.Name = "pnlSupCategory";
            this.pnlSupCategory.Size = new System.Drawing.Size(273, 27);
            this.pnlSupCategory.TabIndex = 1;
            // 
            // txtSupCategory
            // 
            this.txtSupCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtSupCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupCategory.Location = new System.Drawing.Point(97, 2);
            this.txtSupCategory.Name = "txtSupCategory";
            this.txtSupCategory.ReadOnly = true;
            this.txtSupCategory.Size = new System.Drawing.Size(172, 22);
            this.txtSupCategory.TabIndex = 583;
            this.txtSupCategory.DoubleClick += new System.EventHandler(this.txtSupCategory_DoubleClick);
            // 
            // lblSupCategory
            // 
            this.lblSupCategory.AutoSize = true;
            this.lblSupCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupCategory.ForeColor = System.Drawing.Color.Black;
            this.lblSupCategory.Location = new System.Drawing.Point(3, 6);
            this.lblSupCategory.Name = "lblSupCategory";
            this.lblSupCategory.Size = new System.Drawing.Size(94, 14);
            this.lblSupCategory.TabIndex = 584;
            this.lblSupCategory.Text = "Supplier Category";
            // 
            // pnlCreditorType
            // 
            this.pnlCreditorType.Controls.Add(this.cmbCreditorType);
            this.pnlCreditorType.Controls.Add(this.lblCrediter);
            this.pnlCreditorType.Location = new System.Drawing.Point(0, 108);
            this.pnlCreditorType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCreditorType.Name = "pnlCreditorType";
            this.pnlCreditorType.Size = new System.Drawing.Size(273, 27);
            this.pnlCreditorType.TabIndex = 1;
            // 
            // cmbCreditorType
            // 
            this.cmbCreditorType.BackColor = System.Drawing.Color.LightGray;
            this.cmbCreditorType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCreditorType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cmbCreditorType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbCreditorType.FormattingEnabled = true;
            this.cmbCreditorType.Items.AddRange(new object[] {
            "All",
            "Suppliers",
            "Non Suppliers"});
            this.cmbCreditorType.Location = new System.Drawing.Point(97, 2);
            this.cmbCreditorType.Name = "cmbCreditorType";
            this.cmbCreditorType.Size = new System.Drawing.Size(172, 22);
            this.cmbCreditorType.TabIndex = 477;
            this.cmbCreditorType.SelectedIndexChanged += new System.EventHandler(this.cmbCreditorType_SelectedIndexChanged);
            // 
            // lblCrediter
            // 
            this.lblCrediter.AutoSize = true;
            this.lblCrediter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrediter.ForeColor = System.Drawing.Color.Black;
            this.lblCrediter.Location = new System.Drawing.Point(3, 6);
            this.lblCrediter.Name = "lblCrediter";
            this.lblCrediter.Size = new System.Drawing.Size(73, 14);
            this.lblCrediter.TabIndex = 478;
            this.lblCrediter.Text = "Creditor Type";
            // 
            // pnlNoteType
            // 
            this.pnlNoteType.Controls.Add(this.txtNoteType);
            this.pnlNoteType.Controls.Add(this.lblNoteType);
            this.pnlNoteType.Location = new System.Drawing.Point(0, 135);
            this.pnlNoteType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNoteType.Name = "pnlNoteType";
            this.pnlNoteType.Size = new System.Drawing.Size(273, 27);
            this.pnlNoteType.TabIndex = 1;
            // 
            // txtNoteType
            // 
            this.txtNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoteType.Location = new System.Drawing.Point(97, 2);
            this.txtNoteType.Name = "txtNoteType";
            this.txtNoteType.ReadOnly = true;
            this.txtNoteType.Size = new System.Drawing.Size(172, 22);
            this.txtNoteType.TabIndex = 461;
            this.txtNoteType.DoubleClick += new System.EventHandler(this.txtNoteType_DoubleClick);
            // 
            // lblNoteType
            // 
            this.lblNoteType.AutoSize = true;
            this.lblNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblNoteType.Location = new System.Drawing.Point(3, 6);
            this.lblNoteType.Name = "lblNoteType";
            this.lblNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblNoteType.TabIndex = 478;
            this.lblNoteType.Text = "Note Type";
            // 
            // pnlBranch
            // 
            this.pnlBranch.Controls.Add(this.lblBranch);
            this.pnlBranch.Controls.Add(this.txtBranch);
            this.pnlBranch.Location = new System.Drawing.Point(0, 162);
            this.pnlBranch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBranch.Name = "pnlBranch";
            this.pnlBranch.Size = new System.Drawing.Size(273, 27);
            this.pnlBranch.TabIndex = 2;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.Black;
            this.lblBranch.Location = new System.Drawing.Point(3, 6);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 14);
            this.lblBranch.TabIndex = 582;
            this.lblBranch.Text = "Branch";
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.LightGray;
            this.txtBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(97, 2);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(172, 22);
            this.txtBranch.TabIndex = 581;
            this.txtBranch.DoubleClick += new System.EventHandler(this.txtBranch_DoubleClick);
            this.txtBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranch_KeyDown);
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.rdoAll);
            this.pnlType.Controls.Add(this.rdoLocal);
            this.pnlType.Controls.Add(this.rdoExport);
            this.pnlType.Location = new System.Drawing.Point(0, 189);
            this.pnlType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(273, 27);
            this.pnlType.TabIndex = 2;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(216, 2);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(40, 18);
            this.rdoAll.TabIndex = 13;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoLocal
            // 
            this.rdoLocal.AutoSize = true;
            this.rdoLocal.Location = new System.Drawing.Point(97, 2);
            this.rdoLocal.Name = "rdoLocal";
            this.rdoLocal.Size = new System.Drawing.Size(53, 18);
            this.rdoLocal.TabIndex = 13;
            this.rdoLocal.TabStop = true;
            this.rdoLocal.Text = "Local";
            this.rdoLocal.UseVisualStyleBackColor = true;
            // 
            // rdoExport
            // 
            this.rdoExport.AutoSize = true;
            this.rdoExport.Location = new System.Drawing.Point(153, 2);
            this.rdoExport.Name = "rdoExport";
            this.rdoExport.Size = new System.Drawing.Size(58, 18);
            this.rdoExport.TabIndex = 13;
            this.rdoExport.TabStop = true;
            this.rdoExport.Text = "Export";
            this.rdoExport.UseVisualStyleBackColor = true;
            // 
            // pnlDBNOutstanding
            // 
            this.pnlDBNOutstanding.Controls.Add(this.chkHidedebitNote);
            this.pnlDBNOutstanding.Location = new System.Drawing.Point(0, 216);
            this.pnlDBNOutstanding.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDBNOutstanding.Name = "pnlDBNOutstanding";
            this.pnlDBNOutstanding.Size = new System.Drawing.Size(273, 27);
            this.pnlDBNOutstanding.TabIndex = 3;
            // 
            // chkHidedebitNote
            // 
            this.chkHidedebitNote.AutoSize = true;
            this.chkHidedebitNote.Location = new System.Drawing.Point(97, 2);
            this.chkHidedebitNote.Name = "chkHidedebitNote";
            this.chkHidedebitNote.Size = new System.Drawing.Size(181, 18);
            this.chkHidedebitNote.TabIndex = 482;
            this.chkHidedebitNote.Text = "Hide debit note outstanding";
            this.chkHidedebitNote.UseVisualStyleBackColor = true;
            // 
            // pnlUseBillDate
            // 
            this.pnlUseBillDate.Controls.Add(this.chkAPNDate);
            this.pnlUseBillDate.Location = new System.Drawing.Point(0, 243);
            this.pnlUseBillDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUseBillDate.Name = "pnlUseBillDate";
            this.pnlUseBillDate.Size = new System.Drawing.Size(273, 27);
            this.pnlUseBillDate.TabIndex = 2;
            // 
            // chkAPNDate
            // 
            this.chkAPNDate.AutoSize = true;
            this.chkAPNDate.Location = new System.Drawing.Point(97, 2);
            this.chkAPNDate.Name = "chkAPNDate";
            this.chkAPNDate.Size = new System.Drawing.Size(166, 18);
            this.chkAPNDate.TabIndex = 482;
            this.chkAPNDate.Text = "Use bill date as APN Date";
            this.chkAPNDate.UseVisualStyleBackColor = true;
            // 
            // pnlFromDate
            // 
            this.pnlFromDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlFromDate.Controls.Add(this.label3);
            this.pnlFromDate.Controls.Add(this.dtpDateFrom);
            this.pnlFromDate.Location = new System.Drawing.Point(0, 270);
            this.pnlFromDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFromDate.Name = "pnlFromDate";
            this.pnlFromDate.Size = new System.Drawing.Size(273, 27);
            this.pnlFromDate.TabIndex = 587;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Period From :";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(97, 2);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(127, 22);
            this.dtpDateFrom.TabIndex = 482;
            // 
            // pnlToDate
            // 
            this.pnlToDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlToDate.Controls.Add(this.dtpDateTo);
            this.pnlToDate.Controls.Add(this.label4);
            this.pnlToDate.Location = new System.Drawing.Point(0, 297);
            this.pnlToDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlToDate.Name = "pnlToDate";
            this.pnlToDate.Size = new System.Drawing.Size(273, 27);
            this.pnlToDate.TabIndex = 588;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(97, 2);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(127, 22);
            this.dtpDateTo.TabIndex = 481;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 585;
            this.label4.Text = "Period To :";
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
            this.dgvReports.Location = new System.Drawing.Point(8, 9);
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
            this.dgvReports.Size = new System.Drawing.Size(269, 325);
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlReports);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 387);
            this.panel1.TabIndex = 479;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.prog_ProgressBar);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 34);
            this.panel2.TabIndex = 478;
            // 
            // prog_ProgressBar
            // 
            this.prog_ProgressBar.Location = new System.Drawing.Point(3, 7);
            this.prog_ProgressBar.Name = "prog_ProgressBar";
            this.prog_ProgressBar.Size = new System.Drawing.Size(390, 21);
            this.prog_ProgressBar.TabIndex = 484;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(479, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 482;
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
            this.btnClear.Location = new System.Drawing.Point(398, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 483;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm_rpt_AccountPayableReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 419);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_AccountPayableReports";
            this.Text = "Account Payable Reports";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.pnlReports.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlSupplier.ResumeLayout(false);
            this.pnlSupplier.PerformLayout();
            this.pnlSupClass.ResumeLayout(false);
            this.pnlSupClass.PerformLayout();
            this.pnlSupType.ResumeLayout(false);
            this.pnlSupType.PerformLayout();
            this.pnlSupCategory.ResumeLayout(false);
            this.pnlSupCategory.PerformLayout();
            this.pnlCreditorType.ResumeLayout(false);
            this.pnlCreditorType.PerformLayout();
            this.pnlNoteType.ResumeLayout(false);
            this.pnlNoteType.PerformLayout();
            this.pnlBranch.ResumeLayout(false);
            this.pnlBranch.PerformLayout();
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            this.pnlDBNOutstanding.ResumeLayout(false);
            this.pnlDBNOutstanding.PerformLayout();
            this.pnlUseBillDate.ResumeLayout(false);
            this.pnlUseBillDate.PerformLayout();
            this.pnlFromDate.ResumeLayout(false);
            this.pnlFromDate.PerformLayout();
            this.pnlToDate.ResumeLayout(false);
            this.pnlToDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoExport;
        private System.Windows.Forms.RadioButton rdoLocal;
        private System.Windows.Forms.ComboBox cmbCreditorType;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblCrediter;
        private System.Windows.Forms.CheckBox chkHidedebitNote;
        private System.Windows.Forms.CheckBox chkAPNDate;
        private System.Windows.Forms.Label lblNoteType;
        private System.Windows.Forms.TextBox txtNoteType;
        private System.Windows.Forms.Label lblSupCategory;
        private System.Windows.Forms.TextBox txtSupCategory;
        private System.Windows.Forms.Label lblSupType;
        private System.Windows.Forms.TextBox txtSupType;
        private System.Windows.Forms.Label lblSupClass;
        private System.Windows.Forms.TextBox txtSupClass;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar prog_ProgressBar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlSupplier;
        private System.Windows.Forms.Panel pnlSupClass;
        private System.Windows.Forms.Panel pnlSupType;
        private System.Windows.Forms.Panel pnlSupCategory;
        private System.Windows.Forms.Panel pnlCreditorType;
        private System.Windows.Forms.Panel pnlNoteType;
        private System.Windows.Forms.Panel pnlBranch;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Panel pnlDBNOutstanding;
        private System.Windows.Forms.Panel pnlUseBillDate;
        private System.Windows.Forms.Panel pnlFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlToDate;
    }
}