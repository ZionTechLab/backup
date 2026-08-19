namespace Digiteq
{
    partial class frm_rpt_BankManagementReports
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
            this.lblBank = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbReceiptType = new System.Windows.Forms.ComboBox();
            this.chkUseCustomerMastorSaleRep = new System.Windows.Forms.CheckBox();
            this.lblChequeNo = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.chkAllBranches = new System.Windows.Forms.CheckBox();
            this.txtCreditNoteType = new System.Windows.Forms.TextBox();
            this.chkCheque = new System.Windows.Forms.CheckBox();
            this.lblCreditNoteType = new System.Windows.Forms.Label();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.lblReceiptType = new System.Windows.Forms.Label();
            this.lblDepositAccountNo = new System.Windows.Forms.Label();
            this.txtDepositAccountNo = new System.Windows.Forms.TextBox();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.txtBankAccNo = new System.Windows.Forms.TextBox();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkShowDetail = new System.Windows.Forms.CheckBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvReports = new Digiteq.SEACC_DataGrid();
            this.report_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.pnlSalesman = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlAccountNo = new System.Windows.Forms.Panel();
            this.pnlBankAccount = new System.Windows.Forms.Panel();
            this.pnlReceiptType = new System.Windows.Forms.Panel();
            this.pnlCRNType = new System.Windows.Forms.Panel();
            this.pnlChequeNo = new System.Windows.Forms.Panel();
            this.pnlShowAllBranches = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pnlCashCheque = new System.Windows.Forms.Panel();
            this.pnlUseCustomerMasterSalesPerson = new System.Windows.Forms.Panel();
            this.pnlRepresentable = new System.Windows.Forms.Panel();
            this.chkNonRepresentable = new System.Windows.Forms.CheckBox();
            this.chkRepresentable = new System.Windows.Forms.CheckBox();
            this.pnlOutstandingOnly = new System.Windows.Forms.Panel();
            this.chkOutstandingOnly = new System.Windows.Forms.CheckBox();
            this.pnlShowDetailedReport = new System.Windows.Forms.Panel();
            this.pnlRoute = new System.Windows.Forms.Panel();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.pnlDeletedRecords = new System.Windows.Forms.Panel();
            this.pnlCustomerType = new System.Windows.Forms.Panel();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.chkDateRange = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlSalesman.SuspendLayout();
            this.pnlAccountNo.SuspendLayout();
            this.pnlBankAccount.SuspendLayout();
            this.pnlReceiptType.SuspendLayout();
            this.pnlCRNType.SuspendLayout();
            this.pnlChequeNo.SuspendLayout();
            this.pnlShowAllBranches.SuspendLayout();
            this.pnlCashCheque.SuspendLayout();
            this.pnlUseCustomerMasterSalesPerson.SuspendLayout();
            this.pnlRepresentable.SuspendLayout();
            this.pnlOutstandingOnly.SuspendLayout();
            this.pnlShowDetailedReport.SuspendLayout();
            this.pnlRoute.SuspendLayout();
            this.pnlDeletedRecords.SuspendLayout();
            this.pnlCustomerType.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.txtCustomer.Location = new System.Drawing.Point(100, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(215, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.ForeColor = System.Drawing.Color.Black;
            this.lblBank.Location = new System.Drawing.Point(3, 4);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(77, 13);
            this.lblBank.TabIndex = 11;
            this.lblBank.Text = "Bank Account";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(3, 6);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(88, 13);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name";
            // 
            // cmbReceiptType
            // 
            this.cmbReceiptType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReceiptType.ForeColor = System.Drawing.Color.Black;
            this.cmbReceiptType.FormattingEnabled = true;
            this.cmbReceiptType.Items.AddRange(new object[] {
            "All Payment",
            "Advanced Payment",
            "Part Payments"});
            this.cmbReceiptType.Location = new System.Drawing.Point(100, 0);
            this.cmbReceiptType.Name = "cmbReceiptType";
            this.cmbReceiptType.Size = new System.Drawing.Size(215, 21);
            this.cmbReceiptType.TabIndex = 33;
            // 
            // chkUseCustomerMastorSaleRep
            // 
            this.chkUseCustomerMastorSaleRep.AutoSize = true;
            this.chkUseCustomerMastorSaleRep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseCustomerMastorSaleRep.ForeColor = System.Drawing.Color.Black;
            this.chkUseCustomerMastorSaleRep.Location = new System.Drawing.Point(100, 4);
            this.chkUseCustomerMastorSaleRep.Name = "chkUseCustomerMastorSaleRep";
            this.chkUseCustomerMastorSaleRep.Size = new System.Drawing.Size(202, 17);
            this.chkUseCustomerMastorSaleRep.TabIndex = 549;
            this.chkUseCustomerMastorSaleRep.Text = "Use Customer Master Sales Person";
            this.chkUseCustomerMastorSaleRep.UseVisualStyleBackColor = true;
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeNo.ForeColor = System.Drawing.Color.Black;
            this.lblChequeNo.Location = new System.Drawing.Point(3, 4);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(65, 13);
            this.lblChequeNo.TabIndex = 548;
            this.lblChequeNo.Text = "Cheque No";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BackColor = System.Drawing.Color.LightGray;
            this.txtChequeNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(100, 0);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(215, 22);
            this.txtChequeNo.TabIndex = 549;
            this.txtChequeNo.DoubleClick += new System.EventHandler(this.txtChequeNo_DoubleClick);
            // 
            // chkAllBranches
            // 
            this.chkAllBranches.AutoSize = true;
            this.chkAllBranches.Location = new System.Drawing.Point(100, 1);
            this.chkAllBranches.Name = "chkAllBranches";
            this.chkAllBranches.Size = new System.Drawing.Size(120, 17);
            this.chkAllBranches.TabIndex = 12;
            this.chkAllBranches.Text = "Show All Branches";
            this.chkAllBranches.UseVisualStyleBackColor = true;
            this.chkAllBranches.Visible = false;
            // 
            // txtCreditNoteType
            // 
            this.txtCreditNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtCreditNoteType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditNoteType.Location = new System.Drawing.Point(100, 0);
            this.txtCreditNoteType.Name = "txtCreditNoteType";
            this.txtCreditNoteType.ReadOnly = true;
            this.txtCreditNoteType.Size = new System.Drawing.Size(215, 22);
            this.txtCreditNoteType.TabIndex = 547;
            this.txtCreditNoteType.DoubleClick += new System.EventHandler(this.txtCreditNoteType_DoubleClick);
            this.txtCreditNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditNoteType_KeyDown);
            // 
            // chkCheque
            // 
            this.chkCheque.AutoSize = true;
            this.chkCheque.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheque.ForeColor = System.Drawing.Color.Black;
            this.chkCheque.Location = new System.Drawing.Point(155, 4);
            this.chkCheque.Name = "chkCheque";
            this.chkCheque.Size = new System.Drawing.Size(66, 17);
            this.chkCheque.TabIndex = 14;
            this.chkCheque.Text = "Cheque";
            this.chkCheque.UseVisualStyleBackColor = true;
            // 
            // lblCreditNoteType
            // 
            this.lblCreditNoteType.AutoSize = true;
            this.lblCreditNoteType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNoteType.Location = new System.Drawing.Point(3, 4);
            this.lblCreditNoteType.Name = "lblCreditNoteType";
            this.lblCreditNoteType.Size = new System.Drawing.Size(92, 13);
            this.lblCreditNoteType.TabIndex = 467;
            this.lblCreditNoteType.Text = "Credit Note Type";
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCash.ForeColor = System.Drawing.Color.Black;
            this.chkCash.Location = new System.Drawing.Point(100, 4);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(51, 17);
            this.chkCash.TabIndex = 13;
            this.chkCash.Text = "Cash";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // lblReceiptType
            // 
            this.lblReceiptType.AutoSize = true;
            this.lblReceiptType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptType.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptType.Location = new System.Drawing.Point(3, 4);
            this.lblReceiptType.Name = "lblReceiptType";
            this.lblReceiptType.Size = new System.Drawing.Size(71, 13);
            this.lblReceiptType.TabIndex = 465;
            this.lblReceiptType.Text = "Receipt Type";
            // 
            // lblDepositAccountNo
            // 
            this.lblDepositAccountNo.AutoSize = true;
            this.lblDepositAccountNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositAccountNo.ForeColor = System.Drawing.Color.Black;
            this.lblDepositAccountNo.Location = new System.Drawing.Point(3, 4);
            this.lblDepositAccountNo.Name = "lblDepositAccountNo";
            this.lblDepositAccountNo.Size = new System.Drawing.Size(67, 13);
            this.lblDepositAccountNo.TabIndex = 463;
            this.lblDepositAccountNo.Text = "Account No";
            // 
            // txtDepositAccountNo
            // 
            this.txtDepositAccountNo.BackColor = System.Drawing.Color.LightGray;
            this.txtDepositAccountNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositAccountNo.Location = new System.Drawing.Point(100, 0);
            this.txtDepositAccountNo.Name = "txtDepositAccountNo";
            this.txtDepositAccountNo.Size = new System.Drawing.Size(215, 22);
            this.txtDepositAccountNo.TabIndex = 464;
            this.txtDepositAccountNo.DoubleClick += new System.EventHandler(this.txtDepositAccountName_DoubleClick);
            this.txtDepositAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepositAccountName_KeyDown);
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(100, 0);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(215, 22);
            this.txtSalesRep.TabIndex = 461;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            this.txtSalesRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesRep_KeyDown);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.Black;
            this.lblSalseRep.Location = new System.Drawing.Point(3, 4);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(85, 13);
            this.lblSalseRep.TabIndex = 462;
            this.lblSalseRep.Text = "Salesman Code";
            // 
            // txtBankAccNo
            // 
            this.txtBankAccNo.BackColor = System.Drawing.Color.LightGray;
            this.txtBankAccNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankAccNo.Location = new System.Drawing.Point(100, 0);
            this.txtBankAccNo.Name = "txtBankAccNo";
            this.txtBankAccNo.ReadOnly = true;
            this.txtBankAccNo.Size = new System.Drawing.Size(215, 22);
            this.txtBankAccNo.TabIndex = 1;
            this.txtBankAccNo.DoubleClick += new System.EventHandler(this.txtBank_DoubleClick);
            this.txtBankAccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBank_KeyDown);
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(100, 0);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(215, 21);
            this.cmbCustomerType.TabIndex = 15;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(602, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 475;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkShowDetail
            // 
            this.chkShowDetail.AutoSize = true;
            this.chkShowDetail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowDetail.Location = new System.Drawing.Point(100, 4);
            this.chkShowDetail.Name = "chkShowDetail";
            this.chkShowDetail.Size = new System.Drawing.Size(139, 17);
            this.chkShowDetail.TabIndex = 12;
            this.chkShowDetail.Text = "Show Detailed Report";
            this.chkShowDetail.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.Black;
            this.rdoAll.Location = new System.Drawing.Point(251, 3);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(82, 17);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActive.ForeColor = System.Drawing.Color.Black;
            this.rdoActive.Location = new System.Drawing.Point(144, 3);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(82, 17);
            this.rdoActive.TabIndex = 10;
            this.rdoActive.Text = "Active Only";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeleted.ForeColor = System.Drawing.Color.Black;
            this.rdoDeleted.Location = new System.Drawing.Point(28, 3);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(92, 17);
            this.rdoDeleted.TabIndex = 9;
            this.rdoDeleted.Text = "Deleted Only";
            this.rdoDeleted.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(524, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(3, 8);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(515, 19);
            this.ProgressBar.TabIndex = 486;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvReports);
            this.panel1.Location = new System.Drawing.Point(8, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 413);
            this.panel1.TabIndex = 487;
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
            this.dgvReports.Location = new System.Drawing.Point(3, 5);
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
            this.dgvReports.Size = new System.Drawing.Size(321, 404);
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
            this.report_ID.Width = 60;
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
            this.displayName.Width = 310;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomer);
            this.flowLayoutPanel1.Controls.Add(this.pnlSalesman);
            this.flowLayoutPanel1.Controls.Add(this.pnlAccountNo);
            this.flowLayoutPanel1.Controls.Add(this.pnlBankAccount);
            this.flowLayoutPanel1.Controls.Add(this.pnlReceiptType);
            this.flowLayoutPanel1.Controls.Add(this.pnlCRNType);
            this.flowLayoutPanel1.Controls.Add(this.pnlChequeNo);
            this.flowLayoutPanel1.Controls.Add(this.pnlShowAllBranches);
            this.flowLayoutPanel1.Controls.Add(this.pnlCashCheque);
            this.flowLayoutPanel1.Controls.Add(this.pnlUseCustomerMasterSalesPerson);
            this.flowLayoutPanel1.Controls.Add(this.pnlRepresentable);
            this.flowLayoutPanel1.Controls.Add(this.pnlOutstandingOnly);
            this.flowLayoutPanel1.Controls.Add(this.pnlShowDetailedReport);
            this.flowLayoutPanel1.Controls.Add(this.pnlRoute);
            this.flowLayoutPanel1.Controls.Add(this.pnlDeletedRecords);
            this.flowLayoutPanel1.Controls.Add(this.pnlCustomerType);
            this.flowLayoutPanel1.Controls.Add(this.pnlDate);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(339, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(351, 413);
            this.flowLayoutPanel1.TabIndex = 488;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.chkShowAll);
            this.pnlCustomer.Controls.Add(this.lblCustomer);
            this.pnlCustomer.Controls.Add(this.txtCustomer);
            this.pnlCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCustomer.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(349, 50);
            this.pnlCustomer.TabIndex = 591;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAll.Location = new System.Drawing.Point(100, 25);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(71, 17);
            this.chkShowAll.TabIndex = 558;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            // 
            // pnlSalesman
            // 
            this.pnlSalesman.Controls.Add(this.panel3);
            this.pnlSalesman.Controls.Add(this.txtSalesRep);
            this.pnlSalesman.Controls.Add(this.lblSalseRep);
            this.pnlSalesman.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSalesman.Location = new System.Drawing.Point(0, 50);
            this.pnlSalesman.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSalesman.Name = "pnlSalesman";
            this.pnlSalesman.Size = new System.Drawing.Size(349, 22);
            this.pnlSalesman.TabIndex = 592;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(318, 27);
            this.panel3.TabIndex = 592;
            // 
            // pnlAccountNo
            // 
            this.pnlAccountNo.Controls.Add(this.txtDepositAccountNo);
            this.pnlAccountNo.Controls.Add(this.lblDepositAccountNo);
            this.pnlAccountNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAccountNo.Location = new System.Drawing.Point(0, 72);
            this.pnlAccountNo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAccountNo.Name = "pnlAccountNo";
            this.pnlAccountNo.Size = new System.Drawing.Size(349, 22);
            this.pnlAccountNo.TabIndex = 592;
            // 
            // pnlBankAccount
            // 
            this.pnlBankAccount.Controls.Add(this.txtBankAccNo);
            this.pnlBankAccount.Controls.Add(this.lblBank);
            this.pnlBankAccount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBankAccount.Location = new System.Drawing.Point(0, 94);
            this.pnlBankAccount.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBankAccount.Name = "pnlBankAccount";
            this.pnlBankAccount.Size = new System.Drawing.Size(349, 22);
            this.pnlBankAccount.TabIndex = 592;
            // 
            // pnlReceiptType
            // 
            this.pnlReceiptType.Controls.Add(this.cmbReceiptType);
            this.pnlReceiptType.Controls.Add(this.lblReceiptType);
            this.pnlReceiptType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlReceiptType.Location = new System.Drawing.Point(0, 116);
            this.pnlReceiptType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReceiptType.Name = "pnlReceiptType";
            this.pnlReceiptType.Size = new System.Drawing.Size(349, 22);
            this.pnlReceiptType.TabIndex = 592;
            // 
            // pnlCRNType
            // 
            this.pnlCRNType.Controls.Add(this.txtCreditNoteType);
            this.pnlCRNType.Controls.Add(this.lblCreditNoteType);
            this.pnlCRNType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCRNType.Location = new System.Drawing.Point(0, 138);
            this.pnlCRNType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCRNType.Name = "pnlCRNType";
            this.pnlCRNType.Size = new System.Drawing.Size(349, 22);
            this.pnlCRNType.TabIndex = 593;
            // 
            // pnlChequeNo
            // 
            this.pnlChequeNo.Controls.Add(this.txtChequeNo);
            this.pnlChequeNo.Controls.Add(this.lblChequeNo);
            this.pnlChequeNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChequeNo.Location = new System.Drawing.Point(0, 160);
            this.pnlChequeNo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChequeNo.Name = "pnlChequeNo";
            this.pnlChequeNo.Size = new System.Drawing.Size(349, 22);
            this.pnlChequeNo.TabIndex = 592;
            // 
            // pnlShowAllBranches
            // 
            this.pnlShowAllBranches.Controls.Add(this.panel10);
            this.pnlShowAllBranches.Controls.Add(this.chkAllBranches);
            this.pnlShowAllBranches.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlShowAllBranches.Location = new System.Drawing.Point(0, 182);
            this.pnlShowAllBranches.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShowAllBranches.Name = "pnlShowAllBranches";
            this.pnlShowAllBranches.Size = new System.Drawing.Size(349, 22);
            this.pnlShowAllBranches.TabIndex = 592;
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(6, 27);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(318, 27);
            this.panel10.TabIndex = 592;
            // 
            // pnlCashCheque
            // 
            this.pnlCashCheque.Controls.Add(this.chkCheque);
            this.pnlCashCheque.Controls.Add(this.chkCash);
            this.pnlCashCheque.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCashCheque.Location = new System.Drawing.Point(0, 204);
            this.pnlCashCheque.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCashCheque.Name = "pnlCashCheque";
            this.pnlCashCheque.Size = new System.Drawing.Size(349, 22);
            this.pnlCashCheque.TabIndex = 592;
            // 
            // pnlUseCustomerMasterSalesPerson
            // 
            this.pnlUseCustomerMasterSalesPerson.Controls.Add(this.chkUseCustomerMastorSaleRep);
            this.pnlUseCustomerMasterSalesPerson.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlUseCustomerMasterSalesPerson.Location = new System.Drawing.Point(0, 226);
            this.pnlUseCustomerMasterSalesPerson.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUseCustomerMasterSalesPerson.Name = "pnlUseCustomerMasterSalesPerson";
            this.pnlUseCustomerMasterSalesPerson.Size = new System.Drawing.Size(349, 22);
            this.pnlUseCustomerMasterSalesPerson.TabIndex = 593;
            // 
            // pnlRepresentable
            // 
            this.pnlRepresentable.Controls.Add(this.chkNonRepresentable);
            this.pnlRepresentable.Controls.Add(this.chkRepresentable);
            this.pnlRepresentable.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRepresentable.Location = new System.Drawing.Point(0, 248);
            this.pnlRepresentable.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRepresentable.Name = "pnlRepresentable";
            this.pnlRepresentable.Size = new System.Drawing.Size(349, 22);
            this.pnlRepresentable.TabIndex = 598;
            // 
            // chkNonRepresentable
            // 
            this.chkNonRepresentable.AutoSize = true;
            this.chkNonRepresentable.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNonRepresentable.ForeColor = System.Drawing.Color.Black;
            this.chkNonRepresentable.Location = new System.Drawing.Point(197, 4);
            this.chkNonRepresentable.Name = "chkNonRepresentable";
            this.chkNonRepresentable.Size = new System.Drawing.Size(125, 17);
            this.chkNonRepresentable.TabIndex = 14;
            this.chkNonRepresentable.Text = "Non Representable";
            this.chkNonRepresentable.UseVisualStyleBackColor = true;
            // 
            // chkRepresentable
            // 
            this.chkRepresentable.AutoSize = true;
            this.chkRepresentable.Checked = true;
            this.chkRepresentable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRepresentable.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRepresentable.ForeColor = System.Drawing.Color.Black;
            this.chkRepresentable.Location = new System.Drawing.Point(100, 4);
            this.chkRepresentable.Name = "chkRepresentable";
            this.chkRepresentable.Size = new System.Drawing.Size(100, 17);
            this.chkRepresentable.TabIndex = 13;
            this.chkRepresentable.Text = "Representable";
            this.chkRepresentable.UseVisualStyleBackColor = true;
            // 
            // pnlOutstandingOnly
            // 
            this.pnlOutstandingOnly.Controls.Add(this.chkOutstandingOnly);
            this.pnlOutstandingOnly.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlOutstandingOnly.Location = new System.Drawing.Point(0, 270);
            this.pnlOutstandingOnly.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOutstandingOnly.Name = "pnlOutstandingOnly";
            this.pnlOutstandingOnly.Size = new System.Drawing.Size(349, 22);
            this.pnlOutstandingOnly.TabIndex = 599;
            // 
            // chkOutstandingOnly
            // 
            this.chkOutstandingOnly.AutoSize = true;
            this.chkOutstandingOnly.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOutstandingOnly.ForeColor = System.Drawing.Color.Black;
            this.chkOutstandingOnly.Location = new System.Drawing.Point(100, 4);
            this.chkOutstandingOnly.Name = "chkOutstandingOnly";
            this.chkOutstandingOnly.Size = new System.Drawing.Size(119, 17);
            this.chkOutstandingOnly.TabIndex = 549;
            this.chkOutstandingOnly.Text = "Outstanding Only";
            this.chkOutstandingOnly.UseVisualStyleBackColor = true;
            // 
            // pnlShowDetailedReport
            // 
            this.pnlShowDetailedReport.Controls.Add(this.chkShowDetail);
            this.pnlShowDetailedReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlShowDetailedReport.Location = new System.Drawing.Point(0, 292);
            this.pnlShowDetailedReport.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShowDetailedReport.Name = "pnlShowDetailedReport";
            this.pnlShowDetailedReport.Size = new System.Drawing.Size(349, 22);
            this.pnlShowDetailedReport.TabIndex = 595;
            // 
            // pnlRoute
            // 
            this.pnlRoute.BackColor = System.Drawing.Color.White;
            this.pnlRoute.Controls.Add(this.txtRoute);
            this.pnlRoute.Controls.Add(this.lblRoute);
            this.pnlRoute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlRoute.Location = new System.Drawing.Point(0, 314);
            this.pnlRoute.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRoute.Name = "pnlRoute";
            this.pnlRoute.Size = new System.Drawing.Size(341, 22);
            this.pnlRoute.TabIndex = 597;
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(100, 0);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(215, 22);
            this.txtRoute.TabIndex = 481;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.Black;
            this.lblRoute.Location = new System.Drawing.Point(3, 3);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(38, 13);
            this.lblRoute.TabIndex = 482;
            this.lblRoute.Text = "Route";
            // 
            // pnlDeletedRecords
            // 
            this.pnlDeletedRecords.Controls.Add(this.rdoAll);
            this.pnlDeletedRecords.Controls.Add(this.rdoDeleted);
            this.pnlDeletedRecords.Controls.Add(this.rdoActive);
            this.pnlDeletedRecords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDeletedRecords.Location = new System.Drawing.Point(0, 336);
            this.pnlDeletedRecords.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDeletedRecords.Name = "pnlDeletedRecords";
            this.pnlDeletedRecords.Size = new System.Drawing.Size(349, 22);
            this.pnlDeletedRecords.TabIndex = 595;
            // 
            // pnlCustomerType
            // 
            this.pnlCustomerType.Controls.Add(this.lblCustomerType);
            this.pnlCustomerType.Controls.Add(this.cmbCustomerType);
            this.pnlCustomerType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCustomerType.Location = new System.Drawing.Point(0, 358);
            this.pnlCustomerType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCustomerType.Name = "pnlCustomerType";
            this.pnlCustomerType.Size = new System.Drawing.Size(349, 22);
            this.pnlCustomerType.TabIndex = 594;
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerType.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerType.Location = new System.Drawing.Point(3, 4);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(88, 13);
            this.lblCustomerType.TabIndex = 16;
            this.lblCustomerType.Text = "Customer Type :";
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDate.Controls.Add(this.chkDateRange);
            this.pnlDate.Controls.Add(this.label3);
            this.pnlDate.Controls.Add(this.dtpTo);
            this.pnlDate.Controls.Add(this.dtpFrom);
            this.pnlDate.Controls.Add(this.label4);
            this.pnlDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDate.Location = new System.Drawing.Point(0, 380);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(349, 28);
            this.pnlDate.TabIndex = 596;
            // 
            // chkDateRange
            // 
            this.chkDateRange.AutoSize = true;
            this.chkDateRange.Location = new System.Drawing.Point(251, 4);
            this.chkDateRange.Name = "chkDateRange";
            this.chkDateRange.Size = new System.Drawing.Size(86, 17);
            this.chkDateRange.TabIndex = 12;
            this.chkDateRange.Text = "Date Range";
            this.chkDateRange.UseVisualStyleBackColor = true;
            this.chkDateRange.Visible = false;
            this.chkDateRange.CheckedChanged += new System.EventHandler(this.chkDateRange_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "From :";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(158, 2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(87, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(48, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(87, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(141, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 14);
            this.label4.TabIndex = 585;
            this.label4.Text = "To :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.ProgressBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 35);
            this.panel2.TabIndex = 489;
            // 
            // frm_rpt_BankManagementReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 489);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_BankManagementReports";
            this.Text = "Bank Management Reports";
            this.Load += new System.EventHandler(this.frm_rpt_BankManagementReports_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlSalesman.ResumeLayout(false);
            this.pnlSalesman.PerformLayout();
            this.pnlAccountNo.ResumeLayout(false);
            this.pnlAccountNo.PerformLayout();
            this.pnlBankAccount.ResumeLayout(false);
            this.pnlBankAccount.PerformLayout();
            this.pnlReceiptType.ResumeLayout(false);
            this.pnlReceiptType.PerformLayout();
            this.pnlCRNType.ResumeLayout(false);
            this.pnlCRNType.PerformLayout();
            this.pnlChequeNo.ResumeLayout(false);
            this.pnlChequeNo.PerformLayout();
            this.pnlShowAllBranches.ResumeLayout(false);
            this.pnlShowAllBranches.PerformLayout();
            this.pnlCashCheque.ResumeLayout(false);
            this.pnlCashCheque.PerformLayout();
            this.pnlUseCustomerMasterSalesPerson.ResumeLayout(false);
            this.pnlUseCustomerMasterSalesPerson.PerformLayout();
            this.pnlRepresentable.ResumeLayout(false);
            this.pnlRepresentable.PerformLayout();
            this.pnlOutstandingOnly.ResumeLayout(false);
            this.pnlOutstandingOnly.PerformLayout();
            this.pnlShowDetailedReport.ResumeLayout(false);
            this.pnlShowDetailedReport.PerformLayout();
            this.pnlRoute.ResumeLayout(false);
            this.pnlRoute.PerformLayout();
            this.pnlDeletedRecords.ResumeLayout(false);
            this.pnlDeletedRecords.PerformLayout();
            this.pnlCustomerType.ResumeLayout(false);
            this.pnlCustomerType.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
        private System.Windows.Forms.Label lblDepositAccountNo;
        private System.Windows.Forms.TextBox txtDepositAccountNo;
        private System.Windows.Forms.ComboBox cmbReceiptType;
        private System.Windows.Forms.Label lblCreditNoteType;
        private System.Windows.Forms.Label lblReceiptType;
        private System.Windows.Forms.TextBox txtCreditNoteType;
        private System.Windows.Forms.CheckBox chkShowDetail;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.CheckBox chkCheque;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.TextBox txtBankAccNo;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox chkAllBranches;
        private System.Windows.Forms.Label lblChequeNo;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.CheckBox chkUseCustomerMastorSaleRep;
        private System.Windows.Forms.Panel panel1;
        private SEACC_DataGrid dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Panel pnlSalesman;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlAccountNo;
        private System.Windows.Forms.Panel pnlBankAccount;
        private System.Windows.Forms.Panel pnlReceiptType;
        private System.Windows.Forms.Panel pnlCRNType;
        private System.Windows.Forms.Panel pnlChequeNo;
        private System.Windows.Forms.Panel pnlShowAllBranches;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel pnlCashCheque;
        private System.Windows.Forms.Panel pnlUseCustomerMasterSalesPerson;
        private System.Windows.Forms.Panel pnlCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.Panel pnlDeletedRecords;
        private System.Windows.Forms.Panel pnlShowDetailedReport;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.Panel pnlRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.CheckBox chkDateRange;
        private System.Windows.Forms.Panel pnlRepresentable;
        private System.Windows.Forms.CheckBox chkNonRepresentable;
        private System.Windows.Forms.CheckBox chkRepresentable;
        private System.Windows.Forms.Panel pnlOutstandingOnly;
        private System.Windows.Forms.CheckBox chkOutstandingOnly;
    }
}