namespace Digiteq
{
    partial class frm_rpt_SalesRegister
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxInvType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.rdoActual = new System.Windows.Forms.RadioButton();
            this.chkUseCustomerMastorRoute = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.lblCusCategory = new System.Windows.Forms.Label();
            this.txtCusCategory = new System.Windows.Forms.TextBox();
            this.lblCusType = new System.Windows.Forms.Label();
            this.txtCusType = new System.Windows.Forms.TextBox();
            this.lblCusClass = new System.Windows.Forms.Label();
            this.txtCusClass = new System.Windows.Forms.TextBox();
            this.chkIsGroupbyProducionJob = new System.Windows.Forms.CheckBox();
            this.chkEntryError = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDOType = new System.Windows.Forms.ComboBox();
            this.chkUseCustomerMastorSaleRep = new System.Windows.Forms.CheckBox();
            this.lblJobType = new System.Windows.Forms.Label();
            this.txtJobType = new System.Windows.Forms.TextBox();
            this.lblSalesNoteType = new System.Windows.Forms.Label();
            this.txtSalesNoteType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.txtItemSerialNo = new System.Windows.Forms.TextBox();
            this.txtItemSubCategory = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
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
            this.pnlItem = new System.Windows.Forms.Panel();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.pnlCustomerClass = new System.Windows.Forms.Panel();
            this.pnlCustomerType = new System.Windows.Forms.Panel();
            this.pnlCustomerCategory = new System.Windows.Forms.Panel();
            this.pnlSalesman = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlInvoiceType = new System.Windows.Forms.Panel();
            this.pnlNoteType = new System.Windows.Forms.Panel();
            this.pnlBranch = new System.Windows.Forms.Panel();
            this.pnlRoute = new System.Windows.Forms.Panel();
            this.pnlDOType = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.pnlJobType = new System.Windows.Forms.Panel();
            this.pnlCheckBoxes = new System.Windows.Forms.Panel();
            this.pnlRadioButtons = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlItem.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlCustomerClass.SuspendLayout();
            this.pnlCustomerType.SuspendLayout();
            this.pnlCustomerCategory.SuspendLayout();
            this.pnlSalesman.SuspendLayout();
            this.pnlInvoiceType.SuspendLayout();
            this.pnlNoteType.SuspendLayout();
            this.pnlBranch.SuspendLayout();
            this.pnlRoute.SuspendLayout();
            this.pnlDOType.SuspendLayout();
            this.pnlJobType.SuspendLayout();
            this.pnlCheckBoxes.SuspendLayout();
            this.pnlRadioButtons.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.txtCustomer.Location = new System.Drawing.Point(106, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(162, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(2, 6);
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
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(106, 6);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(162, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // cbxInvType
            // 
            this.cbxInvType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxInvType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxInvType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cbxInvType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbxInvType.FormattingEnabled = true;
            this.cbxInvType.Items.AddRange(new object[] {
            "Non Tax",
            "VAT",
            "SVAT",
            "ALL"});
            this.cbxInvType.Location = new System.Drawing.Point(106, 2);
            this.cbxInvType.Name = "cbxInvType";
            this.cbxInvType.Size = new System.Drawing.Size(162, 22);
            this.cbxInvType.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 2);
            this.panel1.TabIndex = 587;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Enabled = false;
            this.rdoAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.Black;
            this.rdoAll.Location = new System.Drawing.Point(106, 7);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(80, 18);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Enabled = false;
            this.rdoDeleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeleted.ForeColor = System.Drawing.Color.Black;
            this.rdoDeleted.Location = new System.Drawing.Point(106, 43);
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
            this.rdoActual.Enabled = false;
            this.rdoActual.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActual.ForeColor = System.Drawing.Color.Black;
            this.rdoActual.Location = new System.Drawing.Point(106, 25);
            this.rdoActual.Name = "rdoActual";
            this.rdoActual.Size = new System.Drawing.Size(124, 18);
            this.rdoActual.TabIndex = 10;
            this.rdoActual.TabStop = true;
            this.rdoActual.Text = "Active Records Only";
            this.rdoActual.UseVisualStyleBackColor = true;
            // 
            // chkUseCustomerMastorRoute
            // 
            this.chkUseCustomerMastorRoute.AutoSize = true;
            this.chkUseCustomerMastorRoute.ForeColor = System.Drawing.Color.Black;
            this.chkUseCustomerMastorRoute.Location = new System.Drawing.Point(106, 9);
            this.chkUseCustomerMastorRoute.Name = "chkUseCustomerMastorRoute";
            this.chkUseCustomerMastorRoute.Size = new System.Drawing.Size(177, 18);
            this.chkUseCustomerMastorRoute.TabIndex = 583;
            this.chkUseCustomerMastorRoute.Text = "Use Customer Master Route";
            this.chkUseCustomerMastorRoute.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(2, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 14);
            this.label6.TabIndex = 582;
            this.label6.Text = "Route";
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(106, 2);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(162, 22);
            this.txtRoute.TabIndex = 581;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.Black;
            this.lblBranch.Location = new System.Drawing.Point(2, 6);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 14);
            this.lblBranch.TabIndex = 580;
            this.lblBranch.Text = "Branch";
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.LightGray;
            this.txtBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(106, 2);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(162, 22);
            this.txtBranch.TabIndex = 579;
            this.txtBranch.DoubleClick += new System.EventHandler(this.txtBranch_DoubleClick);
            // 
            // lblCusCategory
            // 
            this.lblCusCategory.AutoSize = true;
            this.lblCusCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCusCategory.Location = new System.Drawing.Point(2, 6);
            this.lblCusCategory.Name = "lblCusCategory";
            this.lblCusCategory.Size = new System.Drawing.Size(101, 14);
            this.lblCusCategory.TabIndex = 578;
            this.lblCusCategory.Text = "Customer Category";
            // 
            // txtCusCategory
            // 
            this.txtCusCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtCusCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusCategory.Location = new System.Drawing.Point(106, 2);
            this.txtCusCategory.Name = "txtCusCategory";
            this.txtCusCategory.ReadOnly = true;
            this.txtCusCategory.Size = new System.Drawing.Size(162, 22);
            this.txtCusCategory.TabIndex = 577;
            this.txtCusCategory.DoubleClick += new System.EventHandler(this.txtCusCategory_DoubleClick);
            // 
            // lblCusType
            // 
            this.lblCusType.AutoSize = true;
            this.lblCusType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusType.ForeColor = System.Drawing.Color.Black;
            this.lblCusType.Location = new System.Drawing.Point(2, 6);
            this.lblCusType.Name = "lblCusType";
            this.lblCusType.Size = new System.Drawing.Size(81, 14);
            this.lblCusType.TabIndex = 576;
            this.lblCusType.Text = "Customer Type";
            // 
            // txtCusType
            // 
            this.txtCusType.BackColor = System.Drawing.Color.LightGray;
            this.txtCusType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusType.Location = new System.Drawing.Point(106, 2);
            this.txtCusType.Name = "txtCusType";
            this.txtCusType.ReadOnly = true;
            this.txtCusType.Size = new System.Drawing.Size(162, 22);
            this.txtCusType.TabIndex = 575;
            this.txtCusType.DoubleClick += new System.EventHandler(this.txtCusType_DoubleClick);
            // 
            // lblCusClass
            // 
            this.lblCusClass.AutoSize = true;
            this.lblCusClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusClass.ForeColor = System.Drawing.Color.Black;
            this.lblCusClass.Location = new System.Drawing.Point(2, 6);
            this.lblCusClass.Name = "lblCusClass";
            this.lblCusClass.Size = new System.Drawing.Size(82, 14);
            this.lblCusClass.TabIndex = 574;
            this.lblCusClass.Text = "Customer Class";
            // 
            // txtCusClass
            // 
            this.txtCusClass.BackColor = System.Drawing.Color.LightGray;
            this.txtCusClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusClass.Location = new System.Drawing.Point(106, 2);
            this.txtCusClass.Name = "txtCusClass";
            this.txtCusClass.ReadOnly = true;
            this.txtCusClass.Size = new System.Drawing.Size(162, 22);
            this.txtCusClass.TabIndex = 573;
            this.txtCusClass.DoubleClick += new System.EventHandler(this.txtCusClass_DoubleClick);
            // 
            // chkIsGroupbyProducionJob
            // 
            this.chkIsGroupbyProducionJob.AutoSize = true;
            this.chkIsGroupbyProducionJob.ForeColor = System.Drawing.Color.Black;
            this.chkIsGroupbyProducionJob.Location = new System.Drawing.Point(106, 27);
            this.chkIsGroupbyProducionJob.Name = "chkIsGroupbyProducionJob";
            this.chkIsGroupbyProducionJob.Size = new System.Drawing.Size(182, 18);
            this.chkIsGroupbyProducionJob.TabIndex = 572;
            this.chkIsGroupbyProducionJob.Text = "Group by Production Job Type";
            this.chkIsGroupbyProducionJob.UseVisualStyleBackColor = true;
            // 
            // chkEntryError
            // 
            this.chkEntryError.AutoSize = true;
            this.chkEntryError.ForeColor = System.Drawing.Color.Black;
            this.chkEntryError.Location = new System.Drawing.Point(106, 46);
            this.chkEntryError.Name = "chkEntryError";
            this.chkEntryError.Size = new System.Drawing.Size(80, 18);
            this.chkEntryError.TabIndex = 571;
            this.chkEntryError.Text = "Entry Error";
            this.chkEntryError.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 570;
            this.label4.Text = "DO Type";
            this.label4.Visible = false;
            // 
            // cmbDOType
            // 
            this.cmbDOType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDOType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDOType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDOType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbDOType.FormattingEnabled = true;
            this.cmbDOType.Items.AddRange(new object[] {
            "<All Type>",
            "Kandana ",
            "Pettah ",
            "Chemical",
            "Direct",
            "Block "});
            this.cmbDOType.Location = new System.Drawing.Point(106, 2);
            this.cmbDOType.Name = "cmbDOType";
            this.cmbDOType.Size = new System.Drawing.Size(162, 22);
            this.cmbDOType.TabIndex = 569;
            this.cmbDOType.Visible = false;
            // 
            // chkUseCustomerMastorSaleRep
            // 
            this.chkUseCustomerMastorSaleRep.AutoSize = true;
            this.chkUseCustomerMastorSaleRep.ForeColor = System.Drawing.Color.Black;
            this.chkUseCustomerMastorSaleRep.Location = new System.Drawing.Point(106, 64);
            this.chkUseCustomerMastorSaleRep.Name = "chkUseCustomerMastorSaleRep";
            this.chkUseCustomerMastorSaleRep.Size = new System.Drawing.Size(215, 18);
            this.chkUseCustomerMastorSaleRep.TabIndex = 568;
            this.chkUseCustomerMastorSaleRep.Text = "Use Customer Master Sales Person";
            this.chkUseCustomerMastorSaleRep.UseVisualStyleBackColor = true;
            // 
            // lblJobType
            // 
            this.lblJobType.AutoSize = true;
            this.lblJobType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobType.ForeColor = System.Drawing.Color.Black;
            this.lblJobType.Location = new System.Drawing.Point(2, 6);
            this.lblJobType.Name = "lblJobType";
            this.lblJobType.Size = new System.Drawing.Size(50, 14);
            this.lblJobType.TabIndex = 567;
            this.lblJobType.Text = "Job Type";
            this.lblJobType.Visible = false;
            // 
            // txtJobType
            // 
            this.txtJobType.BackColor = System.Drawing.Color.LightGray;
            this.txtJobType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobType.Location = new System.Drawing.Point(106, 2);
            this.txtJobType.Name = "txtJobType";
            this.txtJobType.ReadOnly = true;
            this.txtJobType.Size = new System.Drawing.Size(162, 22);
            this.txtJobType.TabIndex = 566;
            this.txtJobType.Visible = false;
            this.txtJobType.DoubleClick += new System.EventHandler(this.txtJobType_DoubleClick);
            this.txtJobType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobType_KeyDown);
            // 
            // lblSalesNoteType
            // 
            this.lblSalesNoteType.AutoSize = true;
            this.lblSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblSalesNoteType.Location = new System.Drawing.Point(2, 6);
            this.lblSalesNoteType.Name = "lblSalesNoteType";
            this.lblSalesNoteType.Size = new System.Drawing.Size(58, 14);
            this.lblSalesNoteType.TabIndex = 555;
            this.lblSalesNoteType.Text = "Note Type";
            // 
            // txtSalesNoteType
            // 
            this.txtSalesNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesNoteType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesNoteType.Location = new System.Drawing.Point(106, 2);
            this.txtSalesNoteType.Name = "txtSalesNoteType";
            this.txtSalesNoteType.ReadOnly = true;
            this.txtSalesNoteType.Size = new System.Drawing.Size(162, 22);
            this.txtSalesNoteType.TabIndex = 554;
            this.txtSalesNoteType.DoubleClick += new System.EventHandler(this.txtSalesNoteType_DoubleClick);
            this.txtSalesNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNoteType_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 498;
            this.label3.Text = "Invoice Type ";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Black;
            this.lblItem.Location = new System.Drawing.Point(2, 6);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(63, 14);
            this.lblItem.TabIndex = 495;
            this.lblItem.Text = "Item Name";
            // 
            // txtItemSerialNo
            // 
            this.txtItemSerialNo.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSerialNo.ForeColor = System.Drawing.Color.Black;
            this.txtItemSerialNo.Location = new System.Drawing.Point(74, 2);
            this.txtItemSerialNo.Name = "txtItemSerialNo";
            this.txtItemSerialNo.ReadOnly = true;
            this.txtItemSerialNo.Size = new System.Drawing.Size(13, 22);
            this.txtItemSerialNo.TabIndex = 497;
            this.txtItemSerialNo.Visible = false;
            // 
            // txtItemSubCategory
            // 
            this.txtItemSubCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubCategory.ForeColor = System.Drawing.Color.Black;
            this.txtItemSubCategory.Location = new System.Drawing.Point(87, 2);
            this.txtItemSubCategory.Name = "txtItemSubCategory";
            this.txtItemSubCategory.ReadOnly = true;
            this.txtItemSubCategory.Size = new System.Drawing.Size(13, 22);
            this.txtItemSubCategory.TabIndex = 496;
            this.txtItemSubCategory.Visible = false;
            // 
            // txtItemID
            // 
            this.txtItemID.BackColor = System.Drawing.Color.LightGray;
            this.txtItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(106, 2);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(162, 22);
            this.txtItemID.TabIndex = 494;
            this.txtItemID.DoubleClick += new System.EventHandler(this.txtItemID_DoubleClick);
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyDown);
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
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            this.txtSalesRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesRep_KeyDown);
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
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDate.Controls.Add(this.dtpFrom);
            this.pnlDate.Controls.Add(this.label1);
            this.pnlDate.Controls.Add(this.dtpTo);
            this.pnlDate.Controls.Add(this.label2);
            this.pnlDate.Location = new System.Drawing.Point(0, 449);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(326, 60);
            this.pnlDate.TabIndex = 586;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(106, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(162, 22);
            this.dtpTo.TabIndex = 584;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 585;
            this.label2.Text = "Period To :";
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
            this.dgvReports.Size = new System.Drawing.Size(321, 522);
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
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(3, 29);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(331, 536);
            this.pnlGrid.TabIndex = 486;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.panel2);
            this.pnlButton.Controls.Add(this.btnClear);
            this.pnlButton.Controls.Add(this.ProgressBar);
            this.pnlButton.Controls.Add(this.btnPrint);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(3, 565);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(659, 42);
            this.pnlButton.TabIndex = 487;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 2);
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
            this.btnClear.Location = new System.Drawing.Point(495, 9);
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
            this.ProgressBar.Size = new System.Drawing.Size(484, 25);
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
            this.btnPrint.Location = new System.Drawing.Point(575, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 485;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.lblItem);
            this.pnlItem.Controls.Add(this.txtItemID);
            this.pnlItem.Controls.Add(this.txtItemSubCategory);
            this.pnlItem.Controls.Add(this.txtItemSerialNo);
            this.pnlItem.Location = new System.Drawing.Point(0, 10);
            this.pnlItem.Margin = new System.Windows.Forms.Padding(0);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(282, 27);
            this.pnlItem.TabIndex = 588;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.chkShowAll);
            this.pnlCustomer.Controls.Add(this.lblCustomer);
            this.pnlCustomer.Controls.Add(this.txtCustomer);
            this.pnlCustomer.Location = new System.Drawing.Point(0, 37);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(283, 52);
            this.pnlCustomer.TabIndex = 589;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(106, 28);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(73, 18);
            this.chkShowAll.TabIndex = 557;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            // 
            // pnlCustomerClass
            // 
            this.pnlCustomerClass.Controls.Add(this.lblCusClass);
            this.pnlCustomerClass.Controls.Add(this.txtCusClass);
            this.pnlCustomerClass.Location = new System.Drawing.Point(0, 89);
            this.pnlCustomerClass.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomerClass.Name = "pnlCustomerClass";
            this.pnlCustomerClass.Size = new System.Drawing.Size(282, 27);
            this.pnlCustomerClass.TabIndex = 589;
            // 
            // pnlCustomerType
            // 
            this.pnlCustomerType.Controls.Add(this.txtCusType);
            this.pnlCustomerType.Controls.Add(this.lblCusType);
            this.pnlCustomerType.Location = new System.Drawing.Point(0, 116);
            this.pnlCustomerType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomerType.Name = "pnlCustomerType";
            this.pnlCustomerType.Size = new System.Drawing.Size(282, 27);
            this.pnlCustomerType.TabIndex = 589;
            // 
            // pnlCustomerCategory
            // 
            this.pnlCustomerCategory.Controls.Add(this.txtCusCategory);
            this.pnlCustomerCategory.Controls.Add(this.lblCusCategory);
            this.pnlCustomerCategory.Location = new System.Drawing.Point(0, 143);
            this.pnlCustomerCategory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomerCategory.Name = "pnlCustomerCategory";
            this.pnlCustomerCategory.Size = new System.Drawing.Size(282, 27);
            this.pnlCustomerCategory.TabIndex = 589;
            // 
            // pnlSalesman
            // 
            this.pnlSalesman.Controls.Add(this.panel8);
            this.pnlSalesman.Controls.Add(this.txtSalesRep);
            this.pnlSalesman.Controls.Add(this.lblSalseRep);
            this.pnlSalesman.Location = new System.Drawing.Point(0, 170);
            this.pnlSalesman.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesman.Name = "pnlSalesman";
            this.pnlSalesman.Size = new System.Drawing.Size(282, 27);
            this.pnlSalesman.TabIndex = 589;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(0, 30);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(282, 30);
            this.panel8.TabIndex = 589;
            // 
            // pnlInvoiceType
            // 
            this.pnlInvoiceType.Controls.Add(this.cbxInvType);
            this.pnlInvoiceType.Controls.Add(this.label3);
            this.pnlInvoiceType.Location = new System.Drawing.Point(0, 197);
            this.pnlInvoiceType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlInvoiceType.Name = "pnlInvoiceType";
            this.pnlInvoiceType.Size = new System.Drawing.Size(282, 27);
            this.pnlInvoiceType.TabIndex = 590;
            // 
            // pnlNoteType
            // 
            this.pnlNoteType.Controls.Add(this.txtSalesNoteType);
            this.pnlNoteType.Controls.Add(this.lblSalesNoteType);
            this.pnlNoteType.Location = new System.Drawing.Point(0, 224);
            this.pnlNoteType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNoteType.Name = "pnlNoteType";
            this.pnlNoteType.Size = new System.Drawing.Size(282, 27);
            this.pnlNoteType.TabIndex = 589;
            // 
            // pnlBranch
            // 
            this.pnlBranch.Controls.Add(this.txtBranch);
            this.pnlBranch.Controls.Add(this.lblBranch);
            this.pnlBranch.Location = new System.Drawing.Point(0, 332);
            this.pnlBranch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBranch.Name = "pnlBranch";
            this.pnlBranch.Size = new System.Drawing.Size(282, 27);
            this.pnlBranch.TabIndex = 591;
            // 
            // pnlRoute
            // 
            this.pnlRoute.Controls.Add(this.txtRoute);
            this.pnlRoute.Controls.Add(this.label6);
            this.pnlRoute.Location = new System.Drawing.Point(0, 251);
            this.pnlRoute.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRoute.Name = "pnlRoute";
            this.pnlRoute.Size = new System.Drawing.Size(282, 27);
            this.pnlRoute.TabIndex = 589;
            // 
            // pnlDOType
            // 
            this.pnlDOType.Controls.Add(this.panel14);
            this.pnlDOType.Controls.Add(this.cmbDOType);
            this.pnlDOType.Controls.Add(this.label4);
            this.pnlDOType.Location = new System.Drawing.Point(0, 278);
            this.pnlDOType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDOType.Name = "pnlDOType";
            this.pnlDOType.Size = new System.Drawing.Size(282, 27);
            this.pnlDOType.TabIndex = 592;
            // 
            // panel14
            // 
            this.panel14.Location = new System.Drawing.Point(0, 30);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(282, 30);
            this.panel14.TabIndex = 589;
            // 
            // pnlJobType
            // 
            this.pnlJobType.Controls.Add(this.txtJobType);
            this.pnlJobType.Controls.Add(this.lblJobType);
            this.pnlJobType.Location = new System.Drawing.Point(0, 305);
            this.pnlJobType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlJobType.Name = "pnlJobType";
            this.pnlJobType.Size = new System.Drawing.Size(282, 27);
            this.pnlJobType.TabIndex = 593;
            // 
            // pnlCheckBoxes
            // 
            this.pnlCheckBoxes.AutoSize = true;
            this.pnlCheckBoxes.Controls.Add(this.panel1);
            this.pnlCheckBoxes.Controls.Add(this.chkUseCustomerMastorSaleRep);
            this.pnlCheckBoxes.Controls.Add(this.chkEntryError);
            this.pnlCheckBoxes.Controls.Add(this.chkIsGroupbyProducionJob);
            this.pnlCheckBoxes.Controls.Add(this.chkUseCustomerMastorRoute);
            this.pnlCheckBoxes.Location = new System.Drawing.Point(0, 364);
            this.pnlCheckBoxes.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlCheckBoxes.Name = "pnlCheckBoxes";
            this.pnlCheckBoxes.Size = new System.Drawing.Size(326, 85);
            this.pnlCheckBoxes.TabIndex = 594;
            // 
            // pnlRadioButtons
            // 
            this.pnlRadioButtons.Controls.Add(this.rdoAll);
            this.pnlRadioButtons.Controls.Add(this.rdoActual);
            this.pnlRadioButtons.Controls.Add(this.rdoDeleted);
            this.pnlRadioButtons.Location = new System.Drawing.Point(0, 509);
            this.pnlRadioButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRadioButtons.Name = "pnlRadioButtons";
            this.pnlRadioButtons.Size = new System.Drawing.Size(325, 64);
            this.pnlRadioButtons.TabIndex = 595;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlItem);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomer);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomerClass);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomerType);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomerCategory);
            this.flowLayoutPanel1.Controls.Add(this.pnlSalesman);
            this.flowLayoutPanel1.Controls.Add(this.pnlInvoiceType);
            this.flowLayoutPanel1.Controls.Add(this.pnlNoteType);
            this.flowLayoutPanel1.Controls.Add(this.pnlRoute);
            this.flowLayoutPanel1.Controls.Add(this.pnlDOType);
            this.flowLayoutPanel1.Controls.Add(this.pnlJobType);
            this.flowLayoutPanel1.Controls.Add(this.pnlBranch);
            this.flowLayoutPanel1.Controls.Add(this.pnlCheckBoxes);
            this.flowLayoutPanel1.Controls.Add(this.pnlDate);
            this.flowLayoutPanel1.Controls.Add(this.pnlRadioButtons);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(334, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 536);
            this.flowLayoutPanel1.TabIndex = 596;
            // 
            // frm_rpt_SalesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(665, 610);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlButton);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_SalesRegister";
            this.Text = "Sales Report Registry";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.pnlItem.ResumeLayout(false);
            this.pnlItem.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlCustomerClass.ResumeLayout(false);
            this.pnlCustomerClass.PerformLayout();
            this.pnlCustomerType.ResumeLayout(false);
            this.pnlCustomerType.PerformLayout();
            this.pnlCustomerCategory.ResumeLayout(false);
            this.pnlCustomerCategory.PerformLayout();
            this.pnlSalesman.ResumeLayout(false);
            this.pnlSalesman.PerformLayout();
            this.pnlInvoiceType.ResumeLayout(false);
            this.pnlInvoiceType.PerformLayout();
            this.pnlNoteType.ResumeLayout(false);
            this.pnlNoteType.PerformLayout();
            this.pnlBranch.ResumeLayout(false);
            this.pnlBranch.PerformLayout();
            this.pnlRoute.ResumeLayout(false);
            this.pnlRoute.PerformLayout();
            this.pnlDOType.ResumeLayout(false);
            this.pnlDOType.PerformLayout();
            this.pnlJobType.ResumeLayout(false);
            this.pnlJobType.PerformLayout();
            this.pnlCheckBoxes.ResumeLayout(false);
            this.pnlCheckBoxes.PerformLayout();
            this.pnlRadioButtons.ResumeLayout(false);
            this.pnlRadioButtons.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoActual;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox txtItemSerialNo;
        private System.Windows.Forms.TextBox txtItemSubCategory;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.ComboBox cbxInvType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSalesNoteType;
        private System.Windows.Forms.TextBox txtSalesNoteType;
        private System.Windows.Forms.Label lblJobType;
        private System.Windows.Forms.TextBox txtJobType;
        private System.Windows.Forms.CheckBox chkUseCustomerMastorSaleRep;
        private System.Windows.Forms.ComboBox cmbDOType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEntryError;
        private System.Windows.Forms.CheckBox chkIsGroupbyProducionJob;
        private System.Windows.Forms.Label lblCusCategory;
        private System.Windows.Forms.TextBox txtCusCategory;
        private System.Windows.Forms.Label lblCusType;
        private System.Windows.Forms.TextBox txtCusType;
        private System.Windows.Forms.Label lblCusClass;
        private System.Windows.Forms.TextBox txtCusClass;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.CheckBox chkUseCustomerMastorRoute;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.Panel pnlNoteType;
        private System.Windows.Forms.Panel pnlInvoiceType;
        private System.Windows.Forms.Panel pnlSalesman;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnlCustomerCategory;
        private System.Windows.Forms.Panel pnlCustomerType;
        private System.Windows.Forms.Panel pnlCustomerClass;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.Panel pnlRoute;
        private System.Windows.Forms.Panel pnlBranch;
        private System.Windows.Forms.Panel pnlJobType;
        private System.Windows.Forms.Panel pnlDOType;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel pnlRadioButtons;
        private System.Windows.Forms.Panel pnlCheckBoxes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkShowAll;
    }
}