using SEACC.WinFormControls.Components;

namespace Digiteq
{
    partial class UC_bpsReceiptSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_bpsReceiptSales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.xSetting = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoAdvancePayment = new System.Windows.Forms.RadioButton();
            this.rdoPartPayment = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFormBody = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.x1 = new System.Windows.Forms.Panel();
            this.txtCollector3 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtCollector2 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtCollector4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrencyCode = new System.Windows.Forms.TextBox();
            this.txtCurrencyID = new System.Windows.Forms.TextBox();
            this.txtCurrencyRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCollector1 = new System.Windows.Forms.TextBox();
            this.lblCollector = new System.Windows.Forms.Label();
            this.lblOrderRefNo = new System.Windows.Forms.Label();
            this.txtOrderRefNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSalesNoteType = new System.Windows.Forms.TextBox();
            this.lblSalesNoteType = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtSalesExecutiveID = new System.Windows.Forms.TextBox();
            this.lblSalesExecutiveID = new System.Windows.Forms.Label();
            this.txtTmpReceiptNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.btnReceiptID = new System.Windows.Forms.Button();
            this.btnCustomerViewer = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.dtpReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtReceiptID = new System.Windows.Forms.TextBox();
            this.lblReceiptID = new System.Windows.Forms.Label();
            this.x2 = new System.Windows.Forms.Panel();
            this.btnRefundableNote = new System.Windows.Forms.Button();
            this.dgvInvoice = new Digiteq.SEACC_DataGrid();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocatedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAllocated = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.pnlFormHeader = new System.Windows.Forms.Panel();
            this.ucSasProcessFlow = new Digiteq.ucSasProcessFlow();
            this.expanderCash = new SEACC.WinFormControls.Components.ucExpander2();
            this.txtCashChequeRegisterID = new System.Windows.Forms.TextBox();
            this.lblCashAmount = new System.Windows.Forms.Label();
            this.txtCashAmount = new System.Windows.Forms.TextBox();
            this.expanderCheque = new SEACC.WinFormControls.Components.ucExpander2();
            this.txtChequeRegisterID = new System.Windows.Forms.TextBox();
            this.txtChqRowNo = new System.Windows.Forms.TextBox();
            this.btnChqRemove = new System.Windows.Forms.Button();
            this.btnChqAdd = new System.Windows.Forms.Button();
            this.dgvCheq = new Digiteq.SEACC_DataGrid();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridChequeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeRegisterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtChequeTypeID = new System.Windows.Forms.TextBox();
            this.txtChequeRemarks = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBankID = new System.Windows.Forms.TextBox();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.dtpChequeDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.expanderCard = new SEACC.WinFormControls.Components.ucExpander2();
            this.txtCardChequeRegisterID = new System.Windows.Forms.TextBox();
            this.txtCrdRowNo = new System.Windows.Forms.TextBox();
            this.cmbCrdType = new System.Windows.Forms.ComboBox();
            this.btnCrdRemove = new System.Windows.Forms.Button();
            this.btnCrdAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvCard = new Digiteq.SEACC_DataGrid();
            this.crdBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdBankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdLastFourDigits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdChequeRegisterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCrdAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCrdBank = new System.Windows.Forms.TextBox();
            this.lblCrdBank = new System.Windows.Forms.Label();
            this.txtCrdLastDigits = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCrdName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.expanderBankTransfer = new SEACC.WinFormControls.Components.ucExpander2();
            this.txtBankTransferChequeRegisterID = new System.Windows.Forms.TextBox();
            this.txtBTRowNo = new System.Windows.Forms.TextBox();
            this.cmbBTType = new System.Windows.Forms.ComboBox();
            this.btnBTRemove = new System.Windows.Forms.Button();
            this.btnBTAdd = new System.Windows.Forms.Button();
            this.dtpBTDate = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.txtBTRefNo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtBTAccountNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvBankTransfer = new Digiteq.SEACC_DataGrid();
            this.BTAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTBankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTBranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTChequeRegisterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBTAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBTBranch = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBTBank = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pnlAmounts = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtAmountInWord = new System.Windows.Forms.TextBox();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            this.xSetting.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.pnlFormBody.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.x1.SuspendLayout();
            this.x2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.pnlFormHeader.SuspendLayout();
            this.expanderCash.SuspendLayout();
            this.expanderCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheq)).BeginInit();
            this.expanderCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).BeginInit();
            this.expanderBankTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankTransfer)).BeginInit();
            this.pnlAmounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.xSetting);
            this.pnlBody.Controls.Add(this.flowLayoutPanel);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(1, 1);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(874, 583);
            this.pnlBody.TabIndex = 544;
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.Gainsboro;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.btn_Close);
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.label3);
            this.xSetting.Controls.Add(this.rdoAdvancePayment);
            this.xSetting.Controls.Add(this.rdoPartPayment);
            this.xSetting.Location = new System.Drawing.Point(658, 9);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(191, 20);
            this.xSetting.TabIndex = 551;
            this.xSetting.Visible = false;
            this.xSetting.Leave += new System.EventHandler(this.xSetting_Leave);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(158, 1);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 28);
            this.btn_Close.TabIndex = 470;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // chkPrintOriginal
            // 
            this.chkPrintOriginal.AutoSize = true;
            this.chkPrintOriginal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPrintOriginal.Location = new System.Drawing.Point(27, 63);
            this.chkPrintOriginal.Name = "chkPrintOriginal";
            this.chkPrintOriginal.Size = new System.Drawing.Size(91, 18);
            this.chkPrintOriginal.TabIndex = 469;
            this.chkPrintOriginal.Text = "Print Original";
            this.chkPrintOriginal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 453;
            this.label3.Text = "Special Settings";
            // 
            // rdoAdvancePayment
            // 
            this.rdoAdvancePayment.AutoSize = true;
            this.rdoAdvancePayment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAdvancePayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoAdvancePayment.Location = new System.Drawing.Point(27, 43);
            this.rdoAdvancePayment.Name = "rdoAdvancePayment";
            this.rdoAdvancePayment.Size = new System.Drawing.Size(114, 18);
            this.rdoAdvancePayment.TabIndex = 459;
            this.rdoAdvancePayment.TabStop = true;
            this.rdoAdvancePayment.Text = "Advance Payment";
            this.rdoAdvancePayment.UseVisualStyleBackColor = true;
            // 
            // rdoPartPayment
            // 
            this.rdoPartPayment.AutoSize = true;
            this.rdoPartPayment.Checked = true;
            this.rdoPartPayment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPartPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoPartPayment.Location = new System.Drawing.Point(27, 25);
            this.rdoPartPayment.Name = "rdoPartPayment";
            this.rdoPartPayment.Size = new System.Drawing.Size(121, 18);
            this.rdoPartPayment.TabIndex = 461;
            this.rdoPartPayment.TabStop = true;
            this.rdoPartPayment.Text = "Part/Final Payment";
            this.rdoPartPayment.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.pnlFormBody);
            this.flowLayoutPanel.Controls.Add(this.expanderCash);
            this.flowLayoutPanel.Controls.Add(this.expanderCheque);
            this.flowLayoutPanel.Controls.Add(this.expanderCard);
            this.flowLayoutPanel.Controls.Add(this.expanderBankTransfer);
            this.flowLayoutPanel.Controls.Add(this.pnlAmounts);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(874, 583);
            this.flowLayoutPanel.TabIndex = 556;
            // 
            // pnlFormBody
            // 
            this.pnlFormBody.Controls.Add(this.pnlDetails);
            this.pnlFormBody.Controls.Add(this.pnlFormHeader);
            this.pnlFormBody.Location = new System.Drawing.Point(3, 3);
            this.pnlFormBody.Name = "pnlFormBody";
            this.pnlFormBody.Size = new System.Drawing.Size(850, 214);
            this.pnlFormBody.TabIndex = 559;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.x1);
            this.pnlDetails.Controls.Add(this.x2);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 18);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(850, 196);
            this.pnlDetails.TabIndex = 557;
            // 
            // x1
            // 
            this.x1.Controls.Add(this.txtCollector3);
            this.x1.Controls.Add(this.label29);
            this.x1.Controls.Add(this.txtCollector2);
            this.x1.Controls.Add(this.label28);
            this.x1.Controls.Add(this.txtCollector4);
            this.x1.Controls.Add(this.label4);
            this.x1.Controls.Add(this.txtCurrencyCode);
            this.x1.Controls.Add(this.txtCurrencyID);
            this.x1.Controls.Add(this.txtCurrencyRate);
            this.x1.Controls.Add(this.label10);
            this.x1.Controls.Add(this.txtCollector1);
            this.x1.Controls.Add(this.lblCollector);
            this.x1.Controls.Add(this.label30);
            this.x1.Controls.Add(this.lblOrderRefNo);
            this.x1.Controls.Add(this.txtPageNo);
            this.x1.Controls.Add(this.txtOrderRefNo);
            this.x1.Controls.Add(this.label20);
            this.x1.Controls.Add(this.txtSalesNoteType);
            this.x1.Controls.Add(this.lblSalesNoteType);
            this.x1.Controls.Add(this.txtRemark);
            this.x1.Controls.Add(this.txtSalesExecutiveID);
            this.x1.Controls.Add(this.lblSalesExecutiveID);
            this.x1.Controls.Add(this.txtTmpReceiptNo);
            this.x1.Controls.Add(this.label9);
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Controls.Add(this.btnReceiptID);
            this.x1.Controls.Add(this.btnCustomerViewer);
            this.x1.Controls.Add(this.txtCustomerID);
            this.x1.Controls.Add(this.dtpReceiptDate);
            this.x1.Controls.Add(this.label19);
            this.x1.Controls.Add(this.lblCustomerID);
            this.x1.Controls.Add(this.txtReceiptID);
            this.x1.Controls.Add(this.lblReceiptID);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(0, 0);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(551, 193);
            this.x1.TabIndex = 552;
            // 
            // txtCollector3
            // 
            this.txtCollector3.BackColor = System.Drawing.Color.LightGray;
            this.txtCollector3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollector3.Location = new System.Drawing.Point(433, 141);
            this.txtCollector3.Name = "txtCollector3";
            this.txtCollector3.ReadOnly = true;
            this.txtCollector3.Size = new System.Drawing.Size(115, 22);
            this.txtCollector3.TabIndex = 570;
            this.txtCollector3.DoubleClick += new System.EventHandler(this.txtCollector3_DoubleClick);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(349, 146);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(62, 13);
            this.label29.TabIndex = 571;
            this.label29.Text = "Collector 3";
            // 
            // txtCollector2
            // 
            this.txtCollector2.BackColor = System.Drawing.Color.LightGray;
            this.txtCollector2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollector2.Location = new System.Drawing.Point(433, 119);
            this.txtCollector2.Name = "txtCollector2";
            this.txtCollector2.ReadOnly = true;
            this.txtCollector2.Size = new System.Drawing.Size(115, 22);
            this.txtCollector2.TabIndex = 568;
            this.txtCollector2.DoubleClick += new System.EventHandler(this.txtCollector2_DoubleClick);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(349, 124);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 13);
            this.label28.TabIndex = 569;
            this.label28.Text = "Collector 2";
            // 
            // txtCollector4
            // 
            this.txtCollector4.BackColor = System.Drawing.Color.LightGray;
            this.txtCollector4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollector4.Location = new System.Drawing.Point(433, 163);
            this.txtCollector4.Name = "txtCollector4";
            this.txtCollector4.ReadOnly = true;
            this.txtCollector4.Size = new System.Drawing.Size(115, 22);
            this.txtCollector4.TabIndex = 566;
            this.txtCollector4.DoubleClick += new System.EventHandler(this.txtCollector4_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(349, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 567;
            this.label4.Text = "Collector 4";
            // 
            // txtCurrencyCode
            // 
            this.txtCurrencyCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtCurrencyCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyCode.Location = new System.Drawing.Point(198, 119);
            this.txtCurrencyCode.Name = "txtCurrencyCode";
            this.txtCurrencyCode.ReadOnly = true;
            this.txtCurrencyCode.Size = new System.Drawing.Size(28, 22);
            this.txtCurrencyCode.TabIndex = 565;
            this.txtCurrencyCode.Text = "Rs.";
            this.txtCurrencyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrencyID
            // 
            this.txtCurrencyID.BackColor = System.Drawing.Color.LightGray;
            this.txtCurrencyID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyID.Location = new System.Drawing.Point(99, 119);
            this.txtCurrencyID.Name = "txtCurrencyID";
            this.txtCurrencyID.Size = new System.Drawing.Size(92, 22);
            this.txtCurrencyID.TabIndex = 563;
            this.txtCurrencyID.Text = "GN005";
            this.txtCurrencyID.DoubleClick += new System.EventHandler(this.txtCurrencyID_DoubleClick);
            this.txtCurrencyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrencyID_KeyDown);
            // 
            // txtCurrencyRate
            // 
            this.txtCurrencyRate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyRate.Location = new System.Drawing.Point(232, 119);
            this.txtCurrencyRate.Name = "txtCurrencyRate";
            this.txtCurrencyRate.Size = new System.Drawing.Size(70, 22);
            this.txtCurrencyRate.TabIndex = 564;
            this.txtCurrencyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(7, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 562;
            this.label10.Text = "Exchange Rate";
            // 
            // txtCollector1
            // 
            this.txtCollector1.BackColor = System.Drawing.Color.LightGray;
            this.txtCollector1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollector1.Location = new System.Drawing.Point(99, 163);
            this.txtCollector1.Name = "txtCollector1";
            this.txtCollector1.ReadOnly = true;
            this.txtCollector1.Size = new System.Drawing.Size(203, 22);
            this.txtCollector1.TabIndex = 5;
            this.txtCollector1.DoubleClick += new System.EventHandler(this.txtCollector_DoubleClick);
            // 
            // lblCollector
            // 
            this.lblCollector.AutoSize = true;
            this.lblCollector.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollector.ForeColor = System.Drawing.Color.Black;
            this.lblCollector.Location = new System.Drawing.Point(7, 168);
            this.lblCollector.Name = "lblCollector";
            this.lblCollector.Size = new System.Drawing.Size(62, 13);
            this.lblCollector.TabIndex = 560;
            this.lblCollector.Text = "Collector 1";
            // 
            // lblOrderRefNo
            // 
            this.lblOrderRefNo.AutoSize = true;
            this.lblOrderRefNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderRefNo.ForeColor = System.Drawing.Color.Black;
            this.lblOrderRefNo.Location = new System.Drawing.Point(349, 55);
            this.lblOrderRefNo.Name = "lblOrderRefNo";
            this.lblOrderRefNo.Size = new System.Drawing.Size(75, 13);
            this.lblOrderRefNo.TabIndex = 18;
            this.lblOrderRefNo.Text = "Order Ref No";
            // 
            // txtOrderRefNo
            // 
            this.txtOrderRefNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrderRefNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderRefNo.Location = new System.Drawing.Point(431, 52);
            this.txtOrderRefNo.Name = "txtOrderRefNo";
            this.txtOrderRefNo.Size = new System.Drawing.Size(115, 22);
            this.txtOrderRefNo.TabIndex = 19;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(7, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "Receipt Remarks";
            // 
            // txtSalesNoteType
            // 
            this.txtSalesNoteType.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesNoteType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesNoteType.Location = new System.Drawing.Point(326, 124);
            this.txtSalesNoteType.Name = "txtSalesNoteType";
            this.txtSalesNoteType.ReadOnly = true;
            this.txtSalesNoteType.Size = new System.Drawing.Size(18, 22);
            this.txtSalesNoteType.TabIndex = 4;
            this.txtSalesNoteType.DoubleClick += new System.EventHandler(this.txtSalesNoteType_DoubleClick);
            this.txtSalesNoteType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesNoteType_KeyDown);
            // 
            // lblSalesNoteType
            // 
            this.lblSalesNoteType.AutoSize = true;
            this.lblSalesNoteType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesNoteType.ForeColor = System.Drawing.Color.Black;
            this.lblSalesNoteType.Location = new System.Drawing.Point(323, 155);
            this.lblSalesNoteType.Name = "lblSalesNoteType";
            this.lblSalesNoteType.Size = new System.Drawing.Size(58, 13);
            this.lblSalesNoteType.TabIndex = 559;
            this.lblSalesNoteType.Text = "Note Type";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(99, 74);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(447, 45);
            this.txtRemark.TabIndex = 9;
            // 
            // txtSalesExecutiveID
            // 
            this.txtSalesExecutiveID.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesExecutiveID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesExecutiveID.Location = new System.Drawing.Point(99, 141);
            this.txtSalesExecutiveID.Name = "txtSalesExecutiveID";
            this.txtSalesExecutiveID.ReadOnly = true;
            this.txtSalesExecutiveID.Size = new System.Drawing.Size(203, 22);
            this.txtSalesExecutiveID.TabIndex = 3;
            this.txtSalesExecutiveID.Text = "Jennifer Lopez";
            this.txtSalesExecutiveID.DoubleClick += new System.EventHandler(this.txtSalesExecutiveID_DoubleClick);
            this.txtSalesExecutiveID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesExecutiveID_KeyDown);
            // 
            // lblSalesExecutiveID
            // 
            this.lblSalesExecutiveID.AutoSize = true;
            this.lblSalesExecutiveID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesExecutiveID.ForeColor = System.Drawing.Color.Black;
            this.lblSalesExecutiveID.Location = new System.Drawing.Point(7, 146);
            this.lblSalesExecutiveID.Name = "lblSalesExecutiveID";
            this.lblSalesExecutiveID.Size = new System.Drawing.Size(56, 13);
            this.lblSalesExecutiveID.TabIndex = 6;
            this.lblSalesExecutiveID.Text = "Sales Rep";
            // 
            // txtTmpReceiptNo
            // 
            this.txtTmpReceiptNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTmpReceiptNo.Location = new System.Drawing.Point(431, 30);
            this.txtTmpReceiptNo.Name = "txtTmpReceiptNo";
            this.txtTmpReceiptNo.Size = new System.Drawing.Size(115, 22);
            this.txtTmpReceiptNo.TabIndex = 11;
            this.txtTmpReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(349, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tmp No.";
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(246, 11);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(98, 13);
            this.lblCancelled.TabIndex = 494;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowSettle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShowSettle.Location = new System.Drawing.Point(258, 10);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(71, 17);
            this.chkShowSettle.TabIndex = 496;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // btnReceiptID
            // 
            this.btnReceiptID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiptID.Image = global::Digiteq.Properties.Resources.info;
            this.btnReceiptID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiptID.Location = new System.Drawing.Point(223, 8);
            this.btnReceiptID.Name = "btnReceiptID";
            this.btnReceiptID.Size = new System.Drawing.Size(22, 22);
            this.btnReceiptID.TabIndex = 495;
            this.btnReceiptID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceiptID.UseVisualStyleBackColor = true;
            this.btnReceiptID.Click += new System.EventHandler(this.btnReceiptID_Click);
            // 
            // btnCustomerViewer
            // 
            this.btnCustomerViewer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerViewer.Image = global::Digiteq.Properties.Resources.info;
            this.btnCustomerViewer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerViewer.Location = new System.Drawing.Point(307, 30);
            this.btnCustomerViewer.Name = "btnCustomerViewer";
            this.btnCustomerViewer.Size = new System.Drawing.Size(22, 22);
            this.btnCustomerViewer.TabIndex = 489;
            this.btnCustomerViewer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomerViewer.UseVisualStyleBackColor = true;
            this.btnCustomerViewer.Click += new System.EventHandler(this.btnCustomerViewer_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(99, 30);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(203, 22);
            this.txtCustomerID.TabIndex = 2;
            this.txtCustomerID.Text = "Asanka Jayasuriya";
            this.txtCustomerID.DoubleClick += new System.EventHandler(this.txtCustomerID_DoubleClick);
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            // 
            // dtpReceiptDate
            // 
            this.dtpReceiptDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceiptDate.Location = new System.Drawing.Point(431, 7);
            this.dtpReceiptDate.Name = "dtpReceiptDate";
            this.dtpReceiptDate.Size = new System.Drawing.Size(115, 22);
            this.dtpReceiptDate.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(349, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Receipt Date";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerID.Location = new System.Drawing.Point(7, 34);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(88, 13);
            this.lblCustomerID.TabIndex = 4;
            this.lblCustomerID.Text = "Customer Name";
            // 
            // txtReceiptID
            // 
            this.txtReceiptID.BackColor = System.Drawing.Color.DarkGray;
            this.txtReceiptID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptID.Location = new System.Drawing.Point(99, 8);
            this.txtReceiptID.Name = "txtReceiptID";
            this.txtReceiptID.Size = new System.Drawing.Size(120, 22);
            this.txtReceiptID.TabIndex = 1;
            this.txtReceiptID.Text = "IN005";
            this.txtReceiptID.DoubleClick += new System.EventHandler(this.txtReceiptID_DoubleClick);
            this.txtReceiptID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptID_KeyDown);
            // 
            // lblReceiptID
            // 
            this.lblReceiptID.AutoSize = true;
            this.lblReceiptID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptID.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptID.Location = new System.Drawing.Point(7, 12);
            this.lblReceiptID.Name = "lblReceiptID";
            this.lblReceiptID.Size = new System.Drawing.Size(66, 13);
            this.lblReceiptID.TabIndex = 2;
            this.lblReceiptID.Text = "Receipt No.";
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.LightGray;
            this.x2.Controls.Add(this.btnRefundableNote);
            this.x2.Controls.Add(this.dgvInvoice);
            this.x2.Controls.Add(this.txtInvoiceID);
            this.x2.Controls.Add(this.btnAdd);
            this.x2.Controls.Add(this.txtBalanceAmount);
            this.x2.Controls.Add(this.txtTotalAllocated);
            this.x2.Controls.Add(this.btnRemove);
            this.x2.Controls.Add(this.label31);
            this.x2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x2.Location = new System.Drawing.Point(552, 2);
            this.x2.Margin = new System.Windows.Forms.Padding(5);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(295, 182);
            this.x2.TabIndex = 553;
            // 
            // btnRefundableNote
            // 
            this.btnRefundableNote.BackColor = System.Drawing.Color.LightGray;
            this.btnRefundableNote.FlatAppearance.BorderSize = 0;
            this.btnRefundableNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefundableNote.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefundableNote.Image = ((System.Drawing.Image)(resources.GetObject("btnRefundableNote.Image")));
            this.btnRefundableNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefundableNote.Location = new System.Drawing.Point(9, 155);
            this.btnRefundableNote.Name = "btnRefundableNote";
            this.btnRefundableNote.Size = new System.Drawing.Size(125, 25);
            this.btnRefundableNote.TabIndex = 588;
            this.btnRefundableNote.Text = "Refundable Note";
            this.btnRefundableNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefundableNote.UseVisualStyleBackColor = false;
            this.btnRefundableNote.Visible = false;
            this.btnRefundableNote.Click += new System.EventHandler(this.btnRefundableNote_Click);
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.OrderRefNo,
            this.InvoiceAmount,
            this.AllocatedAmount});
            this.dgvInvoice.EnableHeadersVisualStyles = false;
            this.dgvInvoice.Location = new System.Drawing.Point(6, 33);
            this.dgvInvoice.MultiSelect = false;
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(284, 117);
            this.dgvInvoice.TabIndex = 4;
            this.dgvInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellEndEdit);
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "Inv/ DBN No.";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Width = 80;
            // 
            // OrderRefNo
            // 
            this.OrderRefNo.HeaderText = "OrderRefNo.";
            this.OrderRefNo.Name = "OrderRefNo";
            this.OrderRefNo.Visible = false;
            // 
            // InvoiceAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InvoiceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceAmount.HeaderText = "Balance Amt";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
            // 
            // AllocatedAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AllocatedAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.AllocatedAmount.HeaderText = "Allocated Amount";
            this.AllocatedAmount.Name = "AllocatedAmount";
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.BackColor = System.Drawing.Color.LightGray;
            this.txtInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceID.Location = new System.Drawing.Point(80, 70);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.ReadOnly = true;
            this.txtInvoiceID.Size = new System.Drawing.Size(92, 22);
            this.txtInvoiceID.TabIndex = 16;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.Location = new System.Drawing.Point(232, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 579;
            this.btnAdd.Text = "";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtBalanceAmount.Enabled = false;
            this.txtBalanceAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceAmount.Location = new System.Drawing.Point(86, 154);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.Size = new System.Drawing.Size(100, 22);
            this.txtBalanceAmount.TabIndex = 21;
            this.txtBalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalAllocated
            // 
            this.txtTotalAllocated.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalAllocated.Enabled = false;
            this.txtTotalAllocated.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAllocated.Location = new System.Drawing.Point(190, 154);
            this.txtTotalAllocated.Name = "txtTotalAllocated";
            this.txtTotalAllocated.Size = new System.Drawing.Size(98, 22);
            this.txtTotalAllocated.TabIndex = 20;
            this.txtTotalAllocated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemove.Location = new System.Drawing.Point(261, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(25, 25);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(6, 11);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(76, 14);
            this.label31.TabIndex = 5;
            this.label31.Text = "Inv / DBN No.";
            // 
            // pnlFormHeader
            // 
            this.pnlFormHeader.Controls.Add(this.ucSasProcessFlow);
            this.pnlFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlFormHeader.Name = "pnlFormHeader";
            this.pnlFormHeader.Size = new System.Drawing.Size(850, 18);
            this.pnlFormHeader.TabIndex = 558;
            // 
            // ucSasProcessFlow
            // 
            this.ucSasProcessFlow.BackColor = System.Drawing.Color.Transparent;
            this.ucSasProcessFlow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSasProcessFlow.Location = new System.Drawing.Point(1, 1);
            this.ucSasProcessFlow.Name = "ucSasProcessFlow";
            this.ucSasProcessFlow.Size = new System.Drawing.Size(848, 15);
            this.ucSasProcessFlow.TabIndex = 561;
            // 
            // expanderCash
            // 
            this.expanderCash.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expanderCash.Controls.Add(this.txtCashChequeRegisterID);
            this.expanderCash.Controls.Add(this.lblCashAmount);
            this.expanderCash.Controls.Add(this.txtCashAmount);
            this.expanderCash.DisplayAmount = "100,000,000.00";
            this.expanderCash.DisplayName = "Cash";
            this.expanderCash.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expanderCash.FontColor = System.Drawing.Color.White;
            this.expanderCash.Location = new System.Drawing.Point(3, 223);
            this.expanderCash.Name = "expanderCash";
            this.expanderCash.Size = new System.Drawing.Size(851, 58);
            this.expanderCash.TabIndex = 555;
            this.expanderCash.ThemeColor = System.Drawing.SystemColors.ControlDarkDark;
            // 
            // txtCashChequeRegisterID
            // 
            this.txtCashChequeRegisterID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashChequeRegisterID.Location = new System.Drawing.Point(276, 31);
            this.txtCashChequeRegisterID.Name = "txtCashChequeRegisterID";
            this.txtCashChequeRegisterID.Size = new System.Drawing.Size(10, 22);
            this.txtCashChequeRegisterID.TabIndex = 16;
            this.txtCashChequeRegisterID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashChequeRegisterID.Visible = false;
            // 
            // lblCashAmount
            // 
            this.lblCashAmount.AutoSize = true;
            this.lblCashAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashAmount.ForeColor = System.Drawing.Color.Black;
            this.lblCashAmount.Location = new System.Drawing.Point(9, 34);
            this.lblCashAmount.Name = "lblCashAmount";
            this.lblCashAmount.Size = new System.Drawing.Size(81, 14);
            this.lblCashAmount.TabIndex = 14;
            this.lblCashAmount.Text = "Cash Amount : ";
            // 
            // txtCashAmount
            // 
            this.txtCashAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashAmount.Location = new System.Drawing.Point(102, 31);
            this.txtCashAmount.Name = "txtCashAmount";
            this.txtCashAmount.Size = new System.Drawing.Size(168, 22);
            this.txtCashAmount.TabIndex = 15;
            this.txtCashAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashAmount_KeyDown);
            this.txtCashAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashAmount_KeyPress);
            this.txtCashAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCashAmount_KeyUp);
            // 
            // expanderCheque
            // 
            this.expanderCheque.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expanderCheque.Controls.Add(this.txtChequeRegisterID);
            this.expanderCheque.Controls.Add(this.txtChqRowNo);
            this.expanderCheque.Controls.Add(this.btnChqRemove);
            this.expanderCheque.Controls.Add(this.btnChqAdd);
            this.expanderCheque.Controls.Add(this.dgvCheq);
            this.expanderCheque.Controls.Add(this.txtChequeTypeID);
            this.expanderCheque.Controls.Add(this.txtChequeRemarks);
            this.expanderCheque.Controls.Add(this.txtAmount);
            this.expanderCheque.Controls.Add(this.txtAccountID);
            this.expanderCheque.Controls.Add(this.label13);
            this.expanderCheque.Controls.Add(this.label18);
            this.expanderCheque.Controls.Add(this.label7);
            this.expanderCheque.Controls.Add(this.label16);
            this.expanderCheque.Controls.Add(this.label8);
            this.expanderCheque.Controls.Add(this.txtBankID);
            this.expanderCheque.Controls.Add(this.txtBranchID);
            this.expanderCheque.Controls.Add(this.dtpChequeDate);
            this.expanderCheque.Controls.Add(this.label25);
            this.expanderCheque.Controls.Add(this.txtChequeNo);
            this.expanderCheque.Controls.Add(this.label14);
            this.expanderCheque.Controls.Add(this.label15);
            this.expanderCheque.DisplayAmount = "100,000,000.00";
            this.expanderCheque.DisplayName = "Cheque";
            this.expanderCheque.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expanderCheque.FontColor = System.Drawing.Color.White;
            this.expanderCheque.Location = new System.Drawing.Point(3, 287);
            this.expanderCheque.Name = "expanderCheque";
            this.expanderCheque.Size = new System.Drawing.Size(851, 237);
            this.expanderCheque.TabIndex = 554;
            this.expanderCheque.ThemeColor = System.Drawing.SystemColors.ControlDarkDark;
            // 
            // txtChequeRegisterID
            // 
            this.txtChequeRegisterID.Location = new System.Drawing.Point(307, 56);
            this.txtChequeRegisterID.Name = "txtChequeRegisterID";
            this.txtChequeRegisterID.Size = new System.Drawing.Size(10, 22);
            this.txtChequeRegisterID.TabIndex = 580;
            this.txtChequeRegisterID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChequeRegisterID.Visible = false;
            // 
            // txtChqRowNo
            // 
            this.txtChqRowNo.Location = new System.Drawing.Point(307, 34);
            this.txtChqRowNo.Name = "txtChqRowNo";
            this.txtChqRowNo.Size = new System.Drawing.Size(10, 22);
            this.txtChqRowNo.TabIndex = 579;
            this.txtChqRowNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChqRowNo.Visible = false;
            // 
            // btnChqRemove
            // 
            this.btnChqRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnChqRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChqRemove.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChqRemove.ForeColor = System.Drawing.Color.Maroon;
            this.btnChqRemove.Location = new System.Drawing.Point(816, 75);
            this.btnChqRemove.Name = "btnChqRemove";
            this.btnChqRemove.Size = new System.Drawing.Size(25, 25);
            this.btnChqRemove.TabIndex = 577;
            this.btnChqRemove.Text = "";
            this.btnChqRemove.UseVisualStyleBackColor = true;
            this.btnChqRemove.Click += new System.EventHandler(this.btnChqRemove_Click);
            // 
            // btnChqAdd
            // 
            this.btnChqAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnChqAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChqAdd.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChqAdd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnChqAdd.Location = new System.Drawing.Point(787, 75);
            this.btnChqAdd.Name = "btnChqAdd";
            this.btnChqAdd.Size = new System.Drawing.Size(25, 25);
            this.btnChqAdd.TabIndex = 18;
            this.btnChqAdd.Text = "";
            this.btnChqAdd.UseVisualStyleBackColor = true;
            this.btnChqAdd.Click += new System.EventHandler(this.btnChqAdd_Click);
            // 
            // dgvCheq
            // 
            this.dgvCheq.AllowUserToAddRows = false;
            this.dgvCheq.AllowUserToDeleteRows = false;
            this.dgvCheq.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvCheq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCheq.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCheq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountNo,
            this.Bank,
            this.BankID,
            this.Branch,
            this.BranchID,
            this.ChequeType,
            this.ChequeTypeID,
            this.ChequeNo,
            this.ChequeDate,
            this.Amount,
            this.GridChequeStatus,
            this.Remark,
            this.ChequeRegisterCode});
            this.dgvCheq.EnableHeadersVisualStyles = false;
            this.dgvCheq.Location = new System.Drawing.Point(7, 103);
            this.dgvCheq.MultiSelect = false;
            this.dgvCheq.Name = "dgvCheq";
            this.dgvCheq.RowHeadersVisible = false;
            this.dgvCheq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCheq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheq.Size = new System.Drawing.Size(838, 125);
            this.dgvCheq.TabIndex = 19;
            this.dgvCheq.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheq_CellClick);
            this.dgvCheq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheq_CellContentClick);
            // 
            // AccountNo
            // 
            this.AccountNo.HeaderText = "Account No.";
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.ReadOnly = true;
            this.AccountNo.Width = 108;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Bank";
            this.Bank.HeaderText = "Bank Name";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            this.Bank.Width = 135;
            // 
            // BankID
            // 
            this.BankID.HeaderText = "Bank ID";
            this.BankID.Name = "BankID";
            this.BankID.ReadOnly = true;
            this.BankID.Visible = false;
            // 
            // Branch
            // 
            this.Branch.DataPropertyName = "Branch";
            this.Branch.HeaderText = "Branch Name";
            this.Branch.Name = "Branch";
            this.Branch.ReadOnly = true;
            this.Branch.Width = 130;
            // 
            // BranchID
            // 
            this.BranchID.HeaderText = "Branch ID";
            this.BranchID.Name = "BranchID";
            this.BranchID.ReadOnly = true;
            this.BranchID.Visible = false;
            // 
            // ChequeType
            // 
            this.ChequeType.DataPropertyName = "ChequeType";
            this.ChequeType.HeaderText = "Cheque Type";
            this.ChequeType.Name = "ChequeType";
            this.ChequeType.ReadOnly = true;
            this.ChequeType.Width = 105;
            // 
            // ChequeTypeID
            // 
            this.ChequeTypeID.HeaderText = "ChequeTypeID";
            this.ChequeTypeID.Name = "ChequeTypeID";
            this.ChequeTypeID.ReadOnly = true;
            this.ChequeTypeID.Visible = false;
            // 
            // ChequeNo
            // 
            this.ChequeNo.HeaderText = "Cheque No.";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.ReadOnly = true;
            this.ChequeNo.Width = 85;
            // 
            // ChequeDate
            // 
            this.ChequeDate.HeaderText = "Cheque Date";
            this.ChequeDate.Name = "ChequeDate";
            this.ChequeDate.ReadOnly = true;
            this.ChequeDate.Width = 83;
            // 
            // Amount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 80;
            // 
            // GridChequeStatus
            // 
            this.GridChequeStatus.HeaderText = "Cheque Status";
            this.GridChequeStatus.Name = "GridChequeStatus";
            this.GridChequeStatus.ReadOnly = true;
            this.GridChequeStatus.Width = 95;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Visible = false;
            // 
            // ChequeRegisterCode
            // 
            this.ChequeRegisterCode.HeaderText = "ChequeRegisterCode";
            this.ChequeRegisterCode.Name = "ChequeRegisterCode";
            this.ChequeRegisterCode.ReadOnly = true;
            this.ChequeRegisterCode.Visible = false;
            // 
            // txtChequeTypeID
            // 
            this.txtChequeTypeID.BackColor = System.Drawing.Color.LightGray;
            this.txtChequeTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeTypeID.Location = new System.Drawing.Point(427, 34);
            this.txtChequeTypeID.Name = "txtChequeTypeID";
            this.txtChequeTypeID.ReadOnly = true;
            this.txtChequeTypeID.Size = new System.Drawing.Size(128, 22);
            this.txtChequeTypeID.TabIndex = 13;
            this.txtChequeTypeID.DoubleClick += new System.EventHandler(this.txtChequeTypeID_DoubleClick);
            this.txtChequeTypeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeTypeID_KeyDown);
            // 
            // txtChequeRemarks
            // 
            this.txtChequeRemarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeRemarks.Location = new System.Drawing.Point(427, 78);
            this.txtChequeRemarks.Name = "txtChequeRemarks";
            this.txtChequeRemarks.Size = new System.Drawing.Size(343, 22);
            this.txtChequeRemarks.TabIndex = 17;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(655, 56);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(114, 22);
            this.txtAmount.TabIndex = 15;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtAccountID
            // 
            this.txtAccountID.BackColor = System.Drawing.Color.LightGray;
            this.txtAccountID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountID.Location = new System.Drawing.Point(101, 34);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(201, 22);
            this.txtAccountID.TabIndex = 10;
            this.txtAccountID.DoubleClick += new System.EventHandler(this.txtAccountID_DoubleClick);
            this.txtAccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountID_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(323, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 14);
            this.label13.TabIndex = 370;
            this.label13.Text = "Cheque Remarks";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(7, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 14);
            this.label18.TabIndex = 0;
            this.label18.Text = "Account No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(323, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cheque No.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(578, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 14);
            this.label16.TabIndex = 12;
            this.label16.Text = "Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(7, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 14);
            this.label8.TabIndex = 4;
            this.label8.Text = "Branch Name";
            // 
            // txtBankID
            // 
            this.txtBankID.BackColor = System.Drawing.Color.LightGray;
            this.txtBankID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankID.Location = new System.Drawing.Point(101, 56);
            this.txtBankID.Name = "txtBankID";
            this.txtBankID.ReadOnly = true;
            this.txtBankID.Size = new System.Drawing.Size(201, 22);
            this.txtBankID.TabIndex = 11;
            this.txtBankID.DoubleClick += new System.EventHandler(this.txtBankID_DoubleClick);
            this.txtBankID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankID_KeyDown);
            // 
            // txtBranchID
            // 
            this.txtBranchID.BackColor = System.Drawing.Color.LightGray;
            this.txtBranchID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(101, 78);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.ReadOnly = true;
            this.txtBranchID.Size = new System.Drawing.Size(201, 22);
            this.txtBranchID.TabIndex = 12;
            this.txtBranchID.DoubleClick += new System.EventHandler(this.txtBranchID_DoubleClick);
            this.txtBranchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchID_KeyDown);
            // 
            // dtpChequeDate
            // 
            this.dtpChequeDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate.Location = new System.Drawing.Point(655, 34);
            this.dtpChequeDate.Name = "dtpChequeDate";
            this.dtpChequeDate.Size = new System.Drawing.Size(114, 22);
            this.dtpChequeDate.TabIndex = 16;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(323, 38);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 14);
            this.label25.TabIndex = 6;
            this.label25.Text = "Cheque Type";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(427, 56);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(128, 22);
            this.txtChequeNo.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(578, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 10;
            this.label14.Text = "Cheque Date";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(7, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 14);
            this.label15.TabIndex = 2;
            this.label15.Text = "Bank Name";
            // 
            // expanderCard
            // 
            this.expanderCard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expanderCard.Controls.Add(this.txtCardChequeRegisterID);
            this.expanderCard.Controls.Add(this.txtCrdRowNo);
            this.expanderCard.Controls.Add(this.cmbCrdType);
            this.expanderCard.Controls.Add(this.btnCrdRemove);
            this.expanderCard.Controls.Add(this.btnCrdAdd);
            this.expanderCard.Controls.Add(this.label6);
            this.expanderCard.Controls.Add(this.dgvCard);
            this.expanderCard.Controls.Add(this.txtCrdAmount);
            this.expanderCard.Controls.Add(this.label5);
            this.expanderCard.Controls.Add(this.txtCrdBank);
            this.expanderCard.Controls.Add(this.lblCrdBank);
            this.expanderCard.Controls.Add(this.txtCrdLastDigits);
            this.expanderCard.Controls.Add(this.label2);
            this.expanderCard.Controls.Add(this.txtCrdName);
            this.expanderCard.Controls.Add(this.label1);
            this.expanderCard.DisplayAmount = "100,000,000.00";
            this.expanderCard.DisplayName = "Card";
            this.expanderCard.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expanderCard.FontColor = System.Drawing.Color.White;
            this.expanderCard.Location = new System.Drawing.Point(3, 530);
            this.expanderCard.Name = "expanderCard";
            this.expanderCard.Size = new System.Drawing.Size(851, 223);
            this.expanderCard.TabIndex = 556;
            this.expanderCard.ThemeColor = System.Drawing.SystemColors.ControlDarkDark;
            // 
            // txtCardChequeRegisterID
            // 
            this.txtCardChequeRegisterID.Location = new System.Drawing.Point(278, 54);
            this.txtCardChequeRegisterID.Name = "txtCardChequeRegisterID";
            this.txtCardChequeRegisterID.Size = new System.Drawing.Size(10, 22);
            this.txtCardChequeRegisterID.TabIndex = 581;
            this.txtCardChequeRegisterID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCardChequeRegisterID.Visible = false;
            // 
            // txtCrdRowNo
            // 
            this.txtCrdRowNo.Location = new System.Drawing.Point(278, 32);
            this.txtCrdRowNo.Name = "txtCrdRowNo";
            this.txtCrdRowNo.Size = new System.Drawing.Size(10, 22);
            this.txtCrdRowNo.TabIndex = 578;
            this.txtCrdRowNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCrdRowNo.Visible = false;
            // 
            // cmbCrdType
            // 
            this.cmbCrdType.FormattingEnabled = true;
            this.cmbCrdType.Items.AddRange(new object[] {
            "aaa"});
            this.cmbCrdType.Location = new System.Drawing.Point(98, 33);
            this.cmbCrdType.Name = "cmbCrdType";
            this.cmbCrdType.Size = new System.Drawing.Size(178, 21);
            this.cmbCrdType.TabIndex = 20;
            // 
            // btnCrdRemove
            // 
            this.btnCrdRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCrdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrdRemove.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrdRemove.ForeColor = System.Drawing.Color.Maroon;
            this.btnCrdRemove.Location = new System.Drawing.Point(817, 53);
            this.btnCrdRemove.Name = "btnCrdRemove";
            this.btnCrdRemove.Size = new System.Drawing.Size(25, 25);
            this.btnCrdRemove.TabIndex = 575;
            this.btnCrdRemove.Text = "";
            this.btnCrdRemove.UseVisualStyleBackColor = true;
            this.btnCrdRemove.Click += new System.EventHandler(this.btnCrdRemove_Click);
            // 
            // btnCrdAdd
            // 
            this.btnCrdAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCrdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrdAdd.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrdAdd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnCrdAdd.Location = new System.Drawing.Point(788, 53);
            this.btnCrdAdd.Name = "btnCrdAdd";
            this.btnCrdAdd.Size = new System.Drawing.Size(25, 25);
            this.btnCrdAdd.TabIndex = 25;
            this.btnCrdAdd.Text = "";
            this.btnCrdAdd.UseVisualStyleBackColor = true;
            this.btnCrdAdd.Click += new System.EventHandler(this.btnCrdAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 569;
            this.label6.Text = "Card Type";
            // 
            // dgvCard
            // 
            this.dgvCard.AllowUserToAddRows = false;
            this.dgvCard.AllowUserToDeleteRows = false;
            this.dgvCard.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCard.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.crdBank,
            this.crdBankID,
            this.crdType,
            this.crdTypeID,
            this.crdName,
            this.crdLastFourDigits,
            this.crdAmount,
            this.crdChequeRegisterCode});
            this.dgvCard.EnableHeadersVisualStyles = false;
            this.dgvCard.Location = new System.Drawing.Point(7, 89);
            this.dgvCard.MultiSelect = false;
            this.dgvCard.Name = "dgvCard";
            this.dgvCard.RowHeadersVisible = false;
            this.dgvCard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCard.Size = new System.Drawing.Size(838, 125);
            this.dgvCard.TabIndex = 22;
            this.dgvCard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCard_CellClick);
            this.dgvCard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCard_CellContentClick);
            // 
            // crdBank
            // 
            this.crdBank.DataPropertyName = "crdBank";
            this.crdBank.HeaderText = "Bank Name";
            this.crdBank.Name = "crdBank";
            this.crdBank.ReadOnly = true;
            this.crdBank.Width = 225;
            // 
            // crdBankID
            // 
            this.crdBankID.DataPropertyName = "crdBankID";
            this.crdBankID.HeaderText = "Bank ID";
            this.crdBankID.Name = "crdBankID";
            this.crdBankID.ReadOnly = true;
            this.crdBankID.Visible = false;
            // 
            // crdType
            // 
            this.crdType.DataPropertyName = "crdType";
            this.crdType.HeaderText = "Card Type";
            this.crdType.Name = "crdType";
            this.crdType.ReadOnly = true;
            this.crdType.Width = 150;
            // 
            // crdTypeID
            // 
            this.crdTypeID.DataPropertyName = "crdTypeID";
            this.crdTypeID.HeaderText = "Card Type ID";
            this.crdTypeID.Name = "crdTypeID";
            this.crdTypeID.ReadOnly = true;
            this.crdTypeID.Visible = false;
            // 
            // crdName
            // 
            this.crdName.DataPropertyName = "crdName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.crdName.DefaultCellStyle = dataGridViewCellStyle4;
            this.crdName.HeaderText = "Name on Card";
            this.crdName.Name = "crdName";
            this.crdName.ReadOnly = true;
            this.crdName.Width = 220;
            // 
            // crdLastFourDigits
            // 
            this.crdLastFourDigits.DataPropertyName = "crdLastFourDigits";
            this.crdLastFourDigits.HeaderText = "Last Four Digits";
            this.crdLastFourDigits.Name = "crdLastFourDigits";
            this.crdLastFourDigits.ReadOnly = true;
            this.crdLastFourDigits.Width = 120;
            // 
            // crdAmount
            // 
            this.crdAmount.DataPropertyName = "crdAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.crdAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.crdAmount.HeaderText = "Card Amount";
            this.crdAmount.Name = "crdAmount";
            this.crdAmount.ReadOnly = true;
            // 
            // crdChequeRegisterCode
            // 
            this.crdChequeRegisterCode.DataPropertyName = "crdChequeRegisterCode";
            this.crdChequeRegisterCode.HeaderText = "Cheque Register Code";
            this.crdChequeRegisterCode.Name = "crdChequeRegisterCode";
            this.crdChequeRegisterCode.ReadOnly = true;
            this.crdChequeRegisterCode.Visible = false;
            // 
            // txtCrdAmount
            // 
            this.txtCrdAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtCrdAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrdAmount.Location = new System.Drawing.Point(602, 54);
            this.txtCrdAmount.Name = "txtCrdAmount";
            this.txtCrdAmount.Size = new System.Drawing.Size(154, 22);
            this.txtCrdAmount.TabIndex = 24;
            this.txtCrdAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCrdAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrdAmount_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(550, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 567;
            this.label5.Text = "Amount";
            // 
            // txtCrdBank
            // 
            this.txtCrdBank.BackColor = System.Drawing.Color.LightGray;
            this.txtCrdBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrdBank.Location = new System.Drawing.Point(384, 32);
            this.txtCrdBank.Name = "txtCrdBank";
            this.txtCrdBank.ReadOnly = true;
            this.txtCrdBank.Size = new System.Drawing.Size(152, 22);
            this.txtCrdBank.TabIndex = 21;
            this.txtCrdBank.DoubleClick += new System.EventHandler(this.txtCrdBank_DoubleClick);
            this.txtCrdBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCrdBank_KeyDown);
            // 
            // lblCrdBank
            // 
            this.lblCrdBank.AutoSize = true;
            this.lblCrdBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrdBank.ForeColor = System.Drawing.Color.Black;
            this.lblCrdBank.Location = new System.Drawing.Point(292, 36);
            this.lblCrdBank.Name = "lblCrdBank";
            this.lblCrdBank.Size = new System.Drawing.Size(32, 14);
            this.lblCrdBank.TabIndex = 565;
            this.lblCrdBank.Text = "Bank";
            // 
            // txtCrdLastDigits
            // 
            this.txtCrdLastDigits.BackColor = System.Drawing.SystemColors.Window;
            this.txtCrdLastDigits.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrdLastDigits.Location = new System.Drawing.Point(384, 54);
            this.txtCrdLastDigits.Name = "txtCrdLastDigits";
            this.txtCrdLastDigits.Size = new System.Drawing.Size(152, 22);
            this.txtCrdLastDigits.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(292, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 563;
            this.label2.Text = "Last Four Digits";
            // 
            // txtCrdName
            // 
            this.txtCrdName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCrdName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrdName.Location = new System.Drawing.Point(98, 54);
            this.txtCrdName.Name = "txtCrdName";
            this.txtCrdName.Size = new System.Drawing.Size(178, 22);
            this.txtCrdName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 561;
            this.label1.Text = "Name on Card";
            // 
            // expanderBankTransfer
            // 
            this.expanderBankTransfer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expanderBankTransfer.Controls.Add(this.txtBankTransferChequeRegisterID);
            this.expanderBankTransfer.Controls.Add(this.txtBTRowNo);
            this.expanderBankTransfer.Controls.Add(this.cmbBTType);
            this.expanderBankTransfer.Controls.Add(this.btnBTRemove);
            this.expanderBankTransfer.Controls.Add(this.btnBTAdd);
            this.expanderBankTransfer.Controls.Add(this.dtpBTDate);
            this.expanderBankTransfer.Controls.Add(this.label24);
            this.expanderBankTransfer.Controls.Add(this.txtBTRefNo);
            this.expanderBankTransfer.Controls.Add(this.label23);
            this.expanderBankTransfer.Controls.Add(this.txtBTAccountNo);
            this.expanderBankTransfer.Controls.Add(this.label11);
            this.expanderBankTransfer.Controls.Add(this.dgvBankTransfer);
            this.expanderBankTransfer.Controls.Add(this.txtBTAmount);
            this.expanderBankTransfer.Controls.Add(this.label12);
            this.expanderBankTransfer.Controls.Add(this.txtBTBranch);
            this.expanderBankTransfer.Controls.Add(this.label17);
            this.expanderBankTransfer.Controls.Add(this.txtBTBank);
            this.expanderBankTransfer.Controls.Add(this.label21);
            this.expanderBankTransfer.Controls.Add(this.label22);
            this.expanderBankTransfer.DisplayAmount = "100,000,000.00";
            this.expanderBankTransfer.DisplayName = "Bank Transfer";
            this.expanderBankTransfer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expanderBankTransfer.FontColor = System.Drawing.Color.White;
            this.expanderBankTransfer.Location = new System.Drawing.Point(3, 759);
            this.expanderBankTransfer.Name = "expanderBankTransfer";
            this.expanderBankTransfer.Size = new System.Drawing.Size(851, 220);
            this.expanderBankTransfer.TabIndex = 570;
            this.expanderBankTransfer.ThemeColor = System.Drawing.SystemColors.ControlDarkDark;
            // 
            // txtBankTransferChequeRegisterID
            // 
            this.txtBankTransferChequeRegisterID.Location = new System.Drawing.Point(246, 54);
            this.txtBankTransferChequeRegisterID.Name = "txtBankTransferChequeRegisterID";
            this.txtBankTransferChequeRegisterID.Size = new System.Drawing.Size(10, 22);
            this.txtBankTransferChequeRegisterID.TabIndex = 580;
            this.txtBankTransferChequeRegisterID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBankTransferChequeRegisterID.Visible = false;
            // 
            // txtBTRowNo
            // 
            this.txtBTRowNo.Location = new System.Drawing.Point(246, 32);
            this.txtBTRowNo.Name = "txtBTRowNo";
            this.txtBTRowNo.Size = new System.Drawing.Size(10, 22);
            this.txtBTRowNo.TabIndex = 579;
            this.txtBTRowNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBTRowNo.Visible = false;
            // 
            // cmbBTType
            // 
            this.cmbBTType.FormattingEnabled = true;
            this.cmbBTType.Items.AddRange(new object[] {
            "aaa"});
            this.cmbBTType.Location = new System.Drawing.Point(103, 55);
            this.cmbBTType.Name = "cmbBTType";
            this.cmbBTType.Size = new System.Drawing.Size(140, 21);
            this.cmbBTType.TabIndex = 31;
            // 
            // btnBTRemove
            // 
            this.btnBTRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBTRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBTRemove.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBTRemove.ForeColor = System.Drawing.Color.Maroon;
            this.btnBTRemove.Location = new System.Drawing.Point(816, 53);
            this.btnBTRemove.Name = "btnBTRemove";
            this.btnBTRemove.Size = new System.Drawing.Size(25, 25);
            this.btnBTRemove.TabIndex = 573;
            this.btnBTRemove.Text = "";
            this.btnBTRemove.UseVisualStyleBackColor = true;
            this.btnBTRemove.Click += new System.EventHandler(this.btnBTRemove_Click);
            // 
            // btnBTAdd
            // 
            this.btnBTAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBTAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBTAdd.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBTAdd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnBTAdd.Location = new System.Drawing.Point(787, 53);
            this.btnBTAdd.Name = "btnBTAdd";
            this.btnBTAdd.Size = new System.Drawing.Size(25, 25);
            this.btnBTAdd.TabIndex = 35;
            this.btnBTAdd.Text = "";
            this.btnBTAdd.UseVisualStyleBackColor = true;
            this.btnBTAdd.Click += new System.EventHandler(this.btnBTAdd_Click);
            // 
            // dtpBTDate
            // 
            this.dtpBTDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBTDate.Location = new System.Drawing.Point(726, 32);
            this.dtpBTDate.Name = "dtpBTDate";
            this.dtpBTDate.Size = new System.Drawing.Size(113, 22);
            this.dtpBTDate.TabIndex = 34;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(689, 36);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 14);
            this.label24.TabIndex = 572;
            this.label24.Text = "Date";
            // 
            // txtBTRefNo
            // 
            this.txtBTRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTRefNo.Location = new System.Drawing.Point(356, 54);
            this.txtBTRefNo.Name = "txtBTRefNo";
            this.txtBTRefNo.Size = new System.Drawing.Size(140, 22);
            this.txtBTRefNo.TabIndex = 32;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(260, 58);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 14);
            this.label23.TabIndex = 571;
            this.label23.Text = "Transfer Ref. No.";
            // 
            // txtBTAccountNo
            // 
            this.txtBTAccountNo.BackColor = System.Drawing.Color.LightGray;
            this.txtBTAccountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTAccountNo.Location = new System.Drawing.Point(103, 32);
            this.txtBTAccountNo.Name = "txtBTAccountNo";
            this.txtBTAccountNo.ReadOnly = true;
            this.txtBTAccountNo.Size = new System.Drawing.Size(140, 22);
            this.txtBTAccountNo.TabIndex = 30;
            this.txtBTAccountNo.DoubleClick += new System.EventHandler(this.txtBTAccountNo_DoubleClick);
            this.txtBTAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBTAccountNo_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(7, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 14);
            this.label11.TabIndex = 569;
            this.label11.Text = "Deposit Acct. No.";
            // 
            // dgvBankTransfer
            // 
            this.dgvBankTransfer.AllowUserToAddRows = false;
            this.dgvBankTransfer.AllowUserToDeleteRows = false;
            this.dgvBankTransfer.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvBankTransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBankTransfer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBankTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BTAccountNo,
            this.BTBank,
            this.BTBankID,
            this.BTBranch,
            this.BTBranchID,
            this.BTRefNo,
            this.BTType,
            this.BTTypeID,
            this.BTDate,
            this.BTAmount,
            this.BTChequeRegisterCode});
            this.dgvBankTransfer.EnableHeadersVisualStyles = false;
            this.dgvBankTransfer.Location = new System.Drawing.Point(7, 81);
            this.dgvBankTransfer.MultiSelect = false;
            this.dgvBankTransfer.Name = "dgvBankTransfer";
            this.dgvBankTransfer.RowHeadersVisible = false;
            this.dgvBankTransfer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBankTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBankTransfer.Size = new System.Drawing.Size(838, 125);
            this.dgvBankTransfer.TabIndex = 22;
            this.dgvBankTransfer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBankTransfer_CellClick);
            this.dgvBankTransfer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBankTransfer_CellContentClick);
            // 
            // BTAccountNo
            // 
            this.BTAccountNo.DataPropertyName = "BTAccountNo";
            this.BTAccountNo.HeaderText = "Deposit Acct. No";
            this.BTAccountNo.Name = "BTAccountNo";
            this.BTAccountNo.ReadOnly = true;
            this.BTAccountNo.Width = 105;
            // 
            // BTBank
            // 
            this.BTBank.DataPropertyName = "BTBank";
            this.BTBank.HeaderText = "Bank Name";
            this.BTBank.Name = "BTBank";
            this.BTBank.ReadOnly = true;
            this.BTBank.Width = 150;
            // 
            // BTBankID
            // 
            this.BTBankID.DataPropertyName = "BTBankID";
            this.BTBankID.HeaderText = "Bank ID";
            this.BTBankID.Name = "BTBankID";
            this.BTBankID.ReadOnly = true;
            this.BTBankID.Visible = false;
            // 
            // BTBranch
            // 
            this.BTBranch.DataPropertyName = "BTBranch";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BTBranch.DefaultCellStyle = dataGridViewCellStyle6;
            this.BTBranch.HeaderText = "Branch";
            this.BTBranch.Name = "BTBranch";
            this.BTBranch.ReadOnly = true;
            this.BTBranch.Width = 140;
            // 
            // BTBranchID
            // 
            this.BTBranchID.DataPropertyName = "BTBranchID";
            this.BTBranchID.HeaderText = "Branch ID";
            this.BTBranchID.Name = "BTBranchID";
            this.BTBranchID.ReadOnly = true;
            this.BTBranchID.Visible = false;
            // 
            // BTRefNo
            // 
            this.BTRefNo.DataPropertyName = "BTRefNo";
            this.BTRefNo.HeaderText = "Transfer Ref. No.";
            this.BTRefNo.Name = "BTRefNo";
            this.BTRefNo.ReadOnly = true;
            // 
            // BTType
            // 
            this.BTType.DataPropertyName = "BTType";
            this.BTType.HeaderText = "Transfer Type";
            this.BTType.Name = "BTType";
            this.BTType.ReadOnly = true;
            this.BTType.Width = 120;
            // 
            // BTTypeID
            // 
            this.BTTypeID.DataPropertyName = "BTTypeID";
            this.BTTypeID.HeaderText = "TransferTypeID";
            this.BTTypeID.Name = "BTTypeID";
            this.BTTypeID.ReadOnly = true;
            this.BTTypeID.Visible = false;
            // 
            // BTDate
            // 
            this.BTDate.DataPropertyName = "BTDate";
            this.BTDate.HeaderText = "Date";
            this.BTDate.Name = "BTDate";
            this.BTDate.ReadOnly = true;
            // 
            // BTAmount
            // 
            this.BTAmount.DataPropertyName = "BTAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BTAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.BTAmount.HeaderText = "Amount";
            this.BTAmount.Name = "BTAmount";
            this.BTAmount.ReadOnly = true;
            // 
            // BTChequeRegisterCode
            // 
            this.BTChequeRegisterCode.DataPropertyName = "BTChequeRegisterCode";
            this.BTChequeRegisterCode.HeaderText = "Cheque Register Code";
            this.BTChequeRegisterCode.Name = "BTChequeRegisterCode";
            this.BTChequeRegisterCode.ReadOnly = true;
            this.BTChequeRegisterCode.Visible = false;
            // 
            // txtBTAmount
            // 
            this.txtBTAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTAmount.Location = new System.Drawing.Point(553, 54);
            this.txtBTAmount.Name = "txtBTAmount";
            this.txtBTAmount.Size = new System.Drawing.Size(129, 22);
            this.txtBTAmount.TabIndex = 33;
            this.txtBTAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBTAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBTAmount_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(503, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 14);
            this.label12.TabIndex = 567;
            this.label12.Text = "Amount";
            // 
            // txtBTBranch
            // 
            this.txtBTBranch.BackColor = System.Drawing.SystemColors.Control;
            this.txtBTBranch.Enabled = false;
            this.txtBTBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTBranch.Location = new System.Drawing.Point(553, 32);
            this.txtBTBranch.Name = "txtBTBranch";
            this.txtBTBranch.ReadOnly = true;
            this.txtBTBranch.Size = new System.Drawing.Size(129, 22);
            this.txtBTBranch.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(260, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 14);
            this.label17.TabIndex = 565;
            this.label17.Text = "Bank";
            // 
            // txtBTBank
            // 
            this.txtBTBank.BackColor = System.Drawing.SystemColors.Control;
            this.txtBTBank.Enabled = false;
            this.txtBTBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTBank.Location = new System.Drawing.Point(356, 32);
            this.txtBTBank.Name = "txtBTBank";
            this.txtBTBank.ReadOnly = true;
            this.txtBTBank.Size = new System.Drawing.Size(140, 22);
            this.txtBTBank.TabIndex = 36;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(504, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 14);
            this.label21.TabIndex = 563;
            this.label21.Text = "Branch";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(7, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 14);
            this.label22.TabIndex = 561;
            this.label22.Text = "Transfer Type";
            // 
            // pnlAmounts
            // 
            this.pnlAmounts.Controls.Add(this.panel1);
            this.pnlAmounts.Controls.Add(this.lblTotalAmount);
            this.pnlAmounts.Controls.Add(this.label27);
            this.pnlAmounts.Controls.Add(this.label26);
            this.pnlAmounts.Controls.Add(this.txtAmountInWord);
            this.pnlAmounts.Location = new System.Drawing.Point(3, 985);
            this.pnlAmounts.Name = "pnlAmounts";
            this.pnlAmounts.Size = new System.Drawing.Size(851, 52);
            this.pnlAmounts.TabIndex = 571;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(682, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 2);
            this.panel1.TabIndex = 20;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(684, 12);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAmount.Size = new System.Drawing.Size(164, 25);
            this.lblTotalAmount.TabIndex = 19;
            this.lblTotalAmount.Text = "100,000,000.00";
            this.lblTotalAmount.TextChanged += new System.EventHandler(this.lblTotalAmount_TextChanged);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Maroon;
            this.label27.Location = new System.Drawing.Point(609, 12);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(78, 25);
            this.label27.TabIndex = 18;
            this.label27.Text = "TOTAL : ";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(8, 9);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 14);
            this.label26.TabIndex = 3;
            this.label26.Text = "Amount In Word";
            // 
            // txtAmountInWord
            // 
            this.txtAmountInWord.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountInWord.Location = new System.Drawing.Point(102, 6);
            this.txtAmountInWord.Multiline = true;
            this.txtAmountInWord.Name = "txtAmountInWord";
            this.txtAmountInWord.Size = new System.Drawing.Size(477, 37);
            this.txtAmountInWord.TabIndex = 2;
            // 
            // txtPageNo
            // 
            this.txtPageNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPageNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageNo.Location = new System.Drawing.Point(99, 52);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(115, 22);
            this.txtPageNo.TabIndex = 19;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(7, 55);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 13);
            this.label30.TabIndex = 18;
            this.label30.Text = "Page No";
            // 
            // UC_bpsReceiptSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Name = "UC_bpsReceiptSales";
            this.Size = new System.Drawing.Size(876, 623);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_bpsReceiptSales_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.UC_bpsReceiptSales_Load);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            this.pnlBody.ResumeLayout(false);
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.pnlFormBody.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.pnlFormHeader.ResumeLayout(false);
            this.expanderCash.ResumeLayout(false);
            this.expanderCash.PerformLayout();
            this.expanderCheque.ResumeLayout(false);
            this.expanderCheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheq)).EndInit();
            this.expanderCard.ResumeLayout(false);
            this.expanderCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).EndInit();
            this.expanderBankTransfer.ResumeLayout(false);
            this.expanderBankTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankTransfer)).EndInit();
            this.pnlAmounts.ResumeLayout(false);
            this.pnlAmounts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.TextBox txtTotalAllocated;
        private SEACC_DataGrid dgvInvoice;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.TextBox txtCollector1;
        private System.Windows.Forms.Label lblCollector;
        private System.Windows.Forms.Label lblSalesNoteType;
        private System.Windows.Forms.TextBox txtSalesNoteType;
        private System.Windows.Forms.Label lblOrderRefNo;
        private System.Windows.Forms.TextBox txtOrderRefNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtSalesExecutiveID;
        private System.Windows.Forms.Label lblSalesExecutiveID;
        private System.Windows.Forms.TextBox txtTmpReceiptNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Button btnReceiptID;
        private System.Windows.Forms.Button btnCustomerViewer;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.DateTimePicker dtpReceiptDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtReceiptID;
        private System.Windows.Forms.Label lblReceiptID;
        private ucSasProcessFlow ucSasProcessFlow;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoAdvancePayment;
        private System.Windows.Forms.RadioButton rdoPartPayment;
        private System.Windows.Forms.TextBox txtCurrencyCode;
        private System.Windows.Forms.TextBox txtCurrencyID;
        private System.Windows.Forms.TextBox txtCurrencyRate;
        private System.Windows.Forms.Label label10;
        private ucExpander2 expanderCheque;
        private ucExpander2 expanderCash;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label lblCashAmount;
        private System.Windows.Forms.TextBox txtCashAmount;
        private SEACC_DataGrid dgvCheq;
        private System.Windows.Forms.TextBox txtChequeRemarks;
        private System.Windows.Forms.TextBox txtChequeTypeID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.DateTimePicker dtpChequeDate;
        private System.Windows.Forms.TextBox txtBankID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.TextBox txtAmount;
        private ucExpander2 expanderCard;
        private System.Windows.Forms.TextBox txtCrdAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCrdBank;
        private System.Windows.Forms.Label lblCrdBank;
        private System.Windows.Forms.TextBox txtCrdLastDigits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCrdName;
        private System.Windows.Forms.Label label1;
        private SEACC_DataGrid dgvCard;
        private System.Windows.Forms.Label label6;
        private ucExpander2 expanderBankTransfer;
        private System.Windows.Forms.TextBox txtBTAccountNo;
        private System.Windows.Forms.Label label11;
        private SEACC_DataGrid dgvBankTransfer;
        private System.Windows.Forms.TextBox txtBTAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBTBranch;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBTBank;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpBTDate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtBTRefNo;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Panel pnlFormBody;
        private System.Windows.Forms.Panel pnlAmounts;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtAmountInWord;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnBTRemove;
        private System.Windows.Forms.Button btnBTAdd;
        private System.Windows.Forms.Button btnCrdRemove;
        private System.Windows.Forms.Button btnCrdAdd;
        private System.Windows.Forms.Button btnChqRemove;
        private System.Windows.Forms.Button btnChqAdd;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCrdType;
        private System.Windows.Forms.ComboBox cmbBTType;
        private System.Windows.Forms.TextBox txtCrdRowNo;
        private System.Windows.Forms.TextBox txtBTRowNo;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtChqRowNo;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.TextBox txtChequeRegisterID;
        private System.Windows.Forms.TextBox txtCardChequeRegisterID;
        private System.Windows.Forms.TextBox txtBankTransferChequeRegisterID;
        private System.Windows.Forms.TextBox txtCashChequeRegisterID;
        private System.Windows.Forms.Button btnRefundableNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocatedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridChequeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeRegisterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdBankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdLastFourDigits;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdChequeRegisterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTBankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTBranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTChequeRegisterCode;
        private System.Windows.Forms.TextBox txtCollector3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtCollector2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtCollector4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtPageNo;
    }
}