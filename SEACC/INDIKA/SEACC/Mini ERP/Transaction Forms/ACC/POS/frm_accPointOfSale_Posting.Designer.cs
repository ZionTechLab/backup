namespace Digiteq
{
    partial class frm_accPointOfSale_Posting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPOS_LedgerPosting = new SEACC_DataGrid();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nbt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_GiftVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_AdvPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_PM_Cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_PM_Card = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_PM_Cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_PM_GiftVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_PM_AdvSettlement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_PM_CRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tx_SalesEx_CRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbComBranch = new System.Windows.Forms.ComboBox();
            this.lblComBranch = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDatePeriod = new System.Windows.Forms.Label();
            this.xPanelFilters = new System.Windows.Forms.Panel();
            this.btnLedgerPosting = new System.Windows.Forms.Button();
            this.lblStdJE = new System.Windows.Forms.LinkLabel();
            this.lblBankAjustEntry = new System.Windows.Forms.LinkLabel();
            this.lblReceipt = new System.Windows.Forms.LinkLabel();
            this.lblCashDeposit = new System.Windows.Forms.LinkLabel();
            this.lblJE_Advance = new System.Windows.Forms.LinkLabel();
            this.lblDebtoeSettlement = new System.Windows.Forms.LinkLabel();
            this.lblAccountReceipt = new System.Windows.Forms.LinkLabel();
            this.lblChequeDeposit = new System.Windows.Forms.LinkLabel();
            this.lblNetSales_Total = new System.Windows.Forms.Label();
            this.lblNbt_Total = new System.Windows.Forms.Label();
            this.lblAdv_RecivedTotal = new System.Windows.Forms.Label();
            this.lblVat_Total = new System.Windows.Forms.Label();
            this.lblSales_Total = new System.Windows.Forms.Label();
            this.lblInvSRN_Total = new System.Windows.Forms.Label();
            this.lblGV_salesTotal = new System.Windows.Forms.Label();
            this.lblCash_PM_Total = new System.Windows.Forms.Label();
            this.lblCardPM_Total = new System.Windows.Forms.Label();
            this.lblCheqePM_Total = new System.Windows.Forms.Label();
            this.lbl_GV_PM_Total = new System.Windows.Forms.Label();
            this.lblCRN_PM_Total = new System.Windows.Forms.Label();
            this.lblAdvSettlement = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS_LedgerPosting)).BeginInit();
            this.xPanelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Location = new System.Drawing.Point(1190, 0);
            // 
            // dgvPOS_LedgerPosting
            // 
            this.dgvPOS_LedgerPosting.AllowUserToAddRows = false;
            this.dgvPOS_LedgerPosting.AllowUserToDeleteRows = false;
            this.dgvPOS_LedgerPosting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPOS_LedgerPosting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPOS_LedgerPosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOS_LedgerPosting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.Tx_Date,
            this.Tx_ID,
            this.TransactionMode,
            this.Customer_Name,
            this.Company_BranchName,
            this.NetSales,
            this.Nbt,
            this.Vat,
            this.TotalSales,
            this.Tx_Total,
            this.Tx_GiftVoucher,
            this.Tx_AdvPayment,
            this.Tx_PM_Cash,
            this.Tx_PM_Card,
            this.Tx_PM_Cheque,
            this.Tx_PM_GiftVoucher,
            this.Tx_PM_AdvSettlement,
            this.Tx_PM_CRN,
            this.Tx_SalesEx_CRN});
            this.dgvPOS_LedgerPosting.Location = new System.Drawing.Point(9, 86);
            this.dgvPOS_LedgerPosting.MultiSelect = false;
            this.dgvPOS_LedgerPosting.Name = "dgvPOS_LedgerPosting";
            this.dgvPOS_LedgerPosting.ReadOnly = true;
            this.dgvPOS_LedgerPosting.RowHeadersVisible = false;
            this.dgvPOS_LedgerPosting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOS_LedgerPosting.Size = new System.Drawing.Size(1261, 367);
            this.dgvPOS_LedgerPosting.TabIndex = 0;
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.LineNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.LineNo.HeaderText = "     #";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.Width = 20;
            // 
            // Tx_Date
            // 
            this.Tx_Date.DataPropertyName = "Tx_Date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tx_Date.HeaderText = "DATE";
            this.Tx_Date.Name = "Tx_Date";
            this.Tx_Date.ReadOnly = true;
            this.Tx_Date.Width = 62;
            // 
            // Tx_ID
            // 
            this.Tx_ID.DataPropertyName = "Tx_ID";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_ID.DefaultCellStyle = dataGridViewCellStyle3;
            this.Tx_ID.HeaderText = "INVOICE / RETURN NO.";
            this.Tx_ID.Name = "Tx_ID";
            this.Tx_ID.ReadOnly = true;
            this.Tx_ID.Width = 70;
            // 
            // TransactionMode
            // 
            this.TransactionMode.DataPropertyName = "Tx_Mode";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.TransactionMode.DefaultCellStyle = dataGridViewCellStyle4;
            this.TransactionMode.HeaderText = "TX. MODE";
            this.TransactionMode.Name = "TransactionMode";
            this.TransactionMode.ReadOnly = true;
            this.TransactionMode.Width = 50;
            // 
            // Customer_Name
            // 
            this.Customer_Name.DataPropertyName = "Customer_Name";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Customer_Name.DefaultCellStyle = dataGridViewCellStyle5;
            this.Customer_Name.HeaderText = "CUSTOMER NAME & CONTACT NO.";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            this.Customer_Name.Width = 125;
            // 
            // Company_BranchName
            // 
            this.Company_BranchName.DataPropertyName = "Company_BranchName";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Company_BranchName.DefaultCellStyle = dataGridViewCellStyle6;
            this.Company_BranchName.HeaderText = "BRANCH";
            this.Company_BranchName.Name = "Company_BranchName";
            this.Company_BranchName.ReadOnly = true;
            // 
            // NetSales
            // 
            this.NetSales.DataPropertyName = "NetSales";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.NetSales.DefaultCellStyle = dataGridViewCellStyle7;
            this.NetSales.HeaderText = "NET SALES";
            this.NetSales.Name = "NetSales";
            this.NetSales.ReadOnly = true;
            this.NetSales.Width = 65;
            // 
            // Nbt
            // 
            this.Nbt.DataPropertyName = "NBT";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Nbt.DefaultCellStyle = dataGridViewCellStyle8;
            this.Nbt.HeaderText = "NBT";
            this.Nbt.Name = "Nbt";
            this.Nbt.ReadOnly = true;
            this.Nbt.Width = 45;
            // 
            // Vat
            // 
            this.Vat.DataPropertyName = "VAT";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Vat.DefaultCellStyle = dataGridViewCellStyle9;
            this.Vat.HeaderText = "VAT";
            this.Vat.Name = "Vat";
            this.Vat.ReadOnly = true;
            this.Vat.Width = 45;
            // 
            // TotalSales
            // 
            this.TotalSales.DataPropertyName = "Sales_Total";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.TotalSales.DefaultCellStyle = dataGridViewCellStyle10;
            this.TotalSales.HeaderText = "TOTAL SALES";
            this.TotalSales.Name = "TotalSales";
            this.TotalSales.ReadOnly = true;
            this.TotalSales.Width = 65;
            // 
            // Tx_Total
            // 
            this.Tx_Total.DataPropertyName = "Invoice_Return_Total";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_Total.DefaultCellStyle = dataGridViewCellStyle11;
            this.Tx_Total.HeaderText = "INVOICE / RETURN TOTAL";
            this.Tx_Total.Name = "Tx_Total";
            this.Tx_Total.ReadOnly = true;
            this.Tx_Total.Width = 65;
            // 
            // Tx_GiftVoucher
            // 
            this.Tx_GiftVoucher.DataPropertyName = "GV_sales";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_GiftVoucher.DefaultCellStyle = dataGridViewCellStyle12;
            this.Tx_GiftVoucher.HeaderText = "GIFT VOUCHER SALES";
            this.Tx_GiftVoucher.Name = "Tx_GiftVoucher";
            this.Tx_GiftVoucher.ReadOnly = true;
            this.Tx_GiftVoucher.Width = 65;
            // 
            // Tx_AdvPayment
            // 
            this.Tx_AdvPayment.DataPropertyName = "AdvancePayment";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_AdvPayment.DefaultCellStyle = dataGridViewCellStyle13;
            this.Tx_AdvPayment.HeaderText = "ADVANCE PAYMENTS";
            this.Tx_AdvPayment.Name = "Tx_AdvPayment";
            this.Tx_AdvPayment.ReadOnly = true;
            this.Tx_AdvPayment.Width = 65;
            // 
            // Tx_PM_Cash
            // 
            this.Tx_PM_Cash.DataPropertyName = "Tx_PM_Cash";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_PM_Cash.DefaultCellStyle = dataGridViewCellStyle14;
            this.Tx_PM_Cash.HeaderText = "CASH PAYMENT";
            this.Tx_PM_Cash.Name = "Tx_PM_Cash";
            this.Tx_PM_Cash.ReadOnly = true;
            this.Tx_PM_Cash.Width = 65;
            // 
            // Tx_PM_Card
            // 
            this.Tx_PM_Card.DataPropertyName = "Tx_PM_Card";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_PM_Card.DefaultCellStyle = dataGridViewCellStyle15;
            this.Tx_PM_Card.HeaderText = "CARD PAYMENT";
            this.Tx_PM_Card.Name = "Tx_PM_Card";
            this.Tx_PM_Card.ReadOnly = true;
            this.Tx_PM_Card.Width = 60;
            // 
            // Tx_PM_Cheque
            // 
            this.Tx_PM_Cheque.DataPropertyName = "Tx_PM_Cheque";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_PM_Cheque.DefaultCellStyle = dataGridViewCellStyle16;
            this.Tx_PM_Cheque.HeaderText = "CHEQUE PAYMENT";
            this.Tx_PM_Cheque.Name = "Tx_PM_Cheque";
            this.Tx_PM_Cheque.ReadOnly = true;
            this.Tx_PM_Cheque.Width = 60;
            // 
            // Tx_PM_GiftVoucher
            // 
            this.Tx_PM_GiftVoucher.DataPropertyName = "Tx_PM_GV";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_PM_GiftVoucher.DefaultCellStyle = dataGridViewCellStyle17;
            this.Tx_PM_GiftVoucher.HeaderText = "GIFT VOUCHER PAYMENT";
            this.Tx_PM_GiftVoucher.Name = "Tx_PM_GiftVoucher";
            this.Tx_PM_GiftVoucher.ReadOnly = true;
            this.Tx_PM_GiftVoucher.Width = 65;
            // 
            // Tx_PM_AdvSettlement
            // 
            this.Tx_PM_AdvSettlement.DataPropertyName = "Tx_PM_AdvSettlement";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_PM_AdvSettlement.DefaultCellStyle = dataGridViewCellStyle18;
            this.Tx_PM_AdvSettlement.HeaderText = "ADVANCE SETTLE";
            this.Tx_PM_AdvSettlement.Name = "Tx_PM_AdvSettlement";
            this.Tx_PM_AdvSettlement.ReadOnly = true;
            this.Tx_PM_AdvSettlement.Width = 65;
            // 
            // Tx_PM_CRN
            // 
            this.Tx_PM_CRN.DataPropertyName = "Tx_PM_CRN";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_PM_CRN.DefaultCellStyle = dataGridViewCellStyle19;
            this.Tx_PM_CRN.HeaderText = "CREDIT NOTES";
            this.Tx_PM_CRN.Name = "Tx_PM_CRN";
            this.Tx_PM_CRN.ReadOnly = true;
            this.Tx_PM_CRN.Width = 65;
            // 
            // Tx_SalesEx_CRN
            // 
            this.Tx_SalesEx_CRN.DataPropertyName = "Tx_SalesEx_CRN";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.Tx_SalesEx_CRN.DefaultCellStyle = dataGridViewCellStyle20;
            this.Tx_SalesEx_CRN.HeaderText = "SALES EXCHANGE CREDITE NOTES";
            this.Tx_SalesEx_CRN.Name = "Tx_SalesEx_CRN";
            this.Tx_SalesEx_CRN.ReadOnly = true;
            this.Tx_SalesEx_CRN.Visible = false;
            this.Tx_SalesEx_CRN.Width = 85;
            // 
            // cmbComBranch
            // 
            this.cmbComBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComBranch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComBranch.FormattingEnabled = true;
            this.cmbComBranch.Location = new System.Drawing.Point(147, 10);
            this.cmbComBranch.Name = "cmbComBranch";
            this.cmbComBranch.Size = new System.Drawing.Size(236, 23);
            this.cmbComBranch.TabIndex = 485;
            //this.cmbComBranch.SelectedIndexChanged += new System.EventHandler(this.cmbComBranch_SelectedIndexChanged);
            // 
            // lblComBranch
            // 
            this.lblComBranch.AutoSize = true;
            this.lblComBranch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblComBranch.Location = new System.Drawing.Point(29, 14);
            this.lblComBranch.Name = "lblComBranch";
            this.lblComBranch.Size = new System.Drawing.Size(99, 15);
            this.lblComBranch.TabIndex = 486;
            this.lblComBranch.Text = "Company Branch";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(721, 10);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(112, 23);
            this.dtpDateTo.TabIndex = 464;
            //this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpGenDepositDateTo_ValueChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(579, 10);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(112, 23);
            this.dtpDateFrom.TabIndex = 463;
            //this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpGenDepositDateFrom_ValueChanged);
            // 
            // lblDatePeriod
            // 
            this.lblDatePeriod.AutoSize = true;
            this.lblDatePeriod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatePeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDatePeriod.Location = new System.Drawing.Point(489, 14);
            this.lblDatePeriod.Name = "lblDatePeriod";
            this.lblDatePeriod.Size = new System.Drawing.Size(68, 15);
            this.lblDatePeriod.TabIndex = 466;
            this.lblDatePeriod.Text = "Date Period";
            // 
            // xPanelFilters
            // 
            this.xPanelFilters.AutoScroll = true;
            this.xPanelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xPanelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanelFilters.Controls.Add(this.btnRefresh);
            this.xPanelFilters.Controls.Add(this.lblDatePeriod);
            this.xPanelFilters.Controls.Add(this.lblComBranch);
            this.xPanelFilters.Controls.Add(this.dtpDateFrom);
            this.xPanelFilters.Controls.Add(this.cmbComBranch);
            this.xPanelFilters.Controls.Add(this.dtpDateTo);
            this.xPanelFilters.Location = new System.Drawing.Point(9, 35);
            this.xPanelFilters.Name = "xPanelFilters";
            this.xPanelFilters.Size = new System.Drawing.Size(1261, 46);
            this.xPanelFilters.TabIndex = 482;
            // 
            // btnLedgerPosting
            // 
            this.btnLedgerPosting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedgerPosting.Location = new System.Drawing.Point(9, 459);
            this.btnLedgerPosting.Name = "btnLedgerPosting";
            this.btnLedgerPosting.Size = new System.Drawing.Size(219, 31);
            this.btnLedgerPosting.TabIndex = 489;
            this.btnLedgerPosting.Text = "LEDGER POSTING";
            this.btnLedgerPosting.UseVisualStyleBackColor = true;
            this.btnLedgerPosting.Click += new System.EventHandler(this.btnLedgerPosting_Click);
            // 
            // lblStdJE
            // 
            this.lblStdJE.AutoSize = true;
            this.lblStdJE.Location = new System.Drawing.Point(11, 516);
            this.lblStdJE.Name = "lblStdJE";
            this.lblStdJE.Size = new System.Drawing.Size(148, 13);
            this.lblStdJE.TabIndex = 490;
            this.lblStdJE.TabStop = true;
            this.lblStdJE.Text = "STANDARD JOURNAL ENTRY";
            this.lblStdJE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblStdJE_LinkClicked);
            // 
            // lblBankAjustEntry
            // 
            this.lblBankAjustEntry.AutoSize = true;
            this.lblBankAjustEntry.Location = new System.Drawing.Point(191, 516);
            this.lblBankAjustEntry.Name = "lblBankAjustEntry";
            this.lblBankAjustEntry.Size = new System.Drawing.Size(139, 13);
            this.lblBankAjustEntry.TabIndex = 491;
            this.lblBankAjustEntry.TabStop = true;
            this.lblBankAjustEntry.Text = "BANK ADJUSTMENT ENTRY";
            this.lblBankAjustEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBankAjustEntry_LinkClicked);
            // 
            // lblReceipt
            // 
            this.lblReceipt.AutoSize = true;
            this.lblReceipt.Location = new System.Drawing.Point(370, 516);
            this.lblReceipt.Name = "lblReceipt";
            this.lblReceipt.Size = new System.Drawing.Size(47, 13);
            this.lblReceipt.TabIndex = 492;
            this.lblReceipt.TabStop = true;
            this.lblReceipt.Text = "RECIEPT";
            this.lblReceipt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReceipt_LinkClicked);
            // 
            // lblCashDeposit
            // 
            this.lblCashDeposit.AutoSize = true;
            this.lblCashDeposit.Location = new System.Drawing.Point(467, 516);
            this.lblCashDeposit.Name = "lblCashDeposit";
            this.lblCashDeposit.Size = new System.Drawing.Size(81, 13);
            this.lblCashDeposit.TabIndex = 493;
            this.lblCashDeposit.TabStop = true;
            this.lblCashDeposit.Text = "CASH DEPOSIT";
            this.lblCashDeposit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCashDeposit_LinkClicked);
            // 
            // lblJE_Advance
            // 
            this.lblJE_Advance.AutoSize = true;
            this.lblJE_Advance.Location = new System.Drawing.Point(600, 516);
            this.lblJE_Advance.Name = "lblJE_Advance";
            this.lblJE_Advance.Size = new System.Drawing.Size(149, 13);
            this.lblJE_Advance.TabIndex = 494;
            this.lblJE_Advance.TabStop = true;
            this.lblJE_Advance.Text = "JOURNAL ENTRY - ADVANCE";
            this.lblJE_Advance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblJE_Advance_LinkClicked);
            // 
            // lblDebtoeSettlement
            // 
            this.lblDebtoeSettlement.AutoSize = true;
            this.lblDebtoeSettlement.Location = new System.Drawing.Point(806, 516);
            this.lblDebtoeSettlement.Name = "lblDebtoeSettlement";
            this.lblDebtoeSettlement.Size = new System.Drawing.Size(114, 13);
            this.lblDebtoeSettlement.TabIndex = 495;
            this.lblDebtoeSettlement.TabStop = true;
            this.lblDebtoeSettlement.Text = "DEBTOR SETTLEMENT";
            this.lblDebtoeSettlement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDebtoeSettlement_LinkClicked);
            // 
            // lblAccountReceipt
            // 
            this.lblAccountReceipt.AutoSize = true;
            this.lblAccountReceipt.Location = new System.Drawing.Point(998, 516);
            this.lblAccountReceipt.Name = "lblAccountReceipt";
            this.lblAccountReceipt.Size = new System.Drawing.Size(101, 13);
            this.lblAccountReceipt.TabIndex = 496;
            this.lblAccountReceipt.TabStop = true;
            this.lblAccountReceipt.Text = "ACCOUNT RECIEPT";
            this.lblAccountReceipt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAccountReceipt_LinkClicked);
            // 
            // lblChequeDeposit
            // 
            this.lblChequeDeposit.AutoSize = true;
            this.lblChequeDeposit.Location = new System.Drawing.Point(1170, 516);
            this.lblChequeDeposit.Name = "lblChequeDeposit";
            this.lblChequeDeposit.Size = new System.Drawing.Size(96, 13);
            this.lblChequeDeposit.TabIndex = 497;
            this.lblChequeDeposit.TabStop = true;
            this.lblChequeDeposit.Text = "CHEQUE DEPOSIT";
            this.lblChequeDeposit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChequeDeposit_LinkClicked);
            // 
            // lblNetSales_Total
            // 
            this.lblNetSales_Total.AutoSize = true;
            this.lblNetSales_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetSales_Total.Location = new System.Drawing.Point(453, 463);
            this.lblNetSales_Total.Name = "lblNetSales_Total";
            this.lblNetSales_Total.Size = new System.Drawing.Size(49, 12);
            this.lblNetSales_Total.TabIndex = 498;
            this.lblNetSales_Total.Text = "NET SALES";
            this.lblNetSales_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNbt_Total
            // 
            this.lblNbt_Total.AutoSize = true;
            this.lblNbt_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbt_Total.Location = new System.Drawing.Point(507, 463);
            this.lblNbt_Total.Name = "lblNbt_Total";
            this.lblNbt_Total.Size = new System.Drawing.Size(41, 12);
            this.lblNbt_Total.TabIndex = 499;
            this.lblNbt_Total.Text = "NBT TOT";
            this.lblNbt_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdv_RecivedTotal
            // 
            this.lblAdv_RecivedTotal.AutoSize = true;
            this.lblAdv_RecivedTotal.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdv_RecivedTotal.Location = new System.Drawing.Point(798, 463);
            this.lblAdv_RecivedTotal.Name = "lblAdv_RecivedTotal";
            this.lblAdv_RecivedTotal.Size = new System.Drawing.Size(42, 12);
            this.lblAdv_RecivedTotal.TabIndex = 500;
            this.lblAdv_RecivedTotal.Text = "ADV TOT";
            this.lblAdv_RecivedTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVat_Total
            // 
            this.lblVat_Total.AutoSize = true;
            this.lblVat_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVat_Total.Location = new System.Drawing.Point(557, 463);
            this.lblVat_Total.Name = "lblVat_Total";
            this.lblVat_Total.Size = new System.Drawing.Size(41, 12);
            this.lblVat_Total.TabIndex = 501;
            this.lblVat_Total.Text = "VAT TOT";
            this.lblVat_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSales_Total
            // 
            this.lblSales_Total.AutoSize = true;
            this.lblSales_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSales_Total.Location = new System.Drawing.Point(612, 463);
            this.lblSales_Total.Name = "lblSales_Total";
            this.lblSales_Total.Size = new System.Drawing.Size(44, 12);
            this.lblSales_Total.TabIndex = 502;
            this.lblSales_Total.Text = "TOT SALE";
            this.lblSales_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInvSRN_Total
            // 
            this.lblInvSRN_Total.AutoSize = true;
            this.lblInvSRN_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvSRN_Total.Location = new System.Drawing.Point(668, 463);
            this.lblInvSRN_Total.Name = "lblInvSRN_Total";
            this.lblInvSRN_Total.Size = new System.Drawing.Size(58, 12);
            this.lblInvSRN_Total.TabIndex = 503;
            this.lblInvSRN_Total.Text = "INV SRN TOT";
            this.lblInvSRN_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGV_salesTotal
            // 
            this.lblGV_salesTotal.AutoSize = true;
            this.lblGV_salesTotal.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGV_salesTotal.Location = new System.Drawing.Point(740, 463);
            this.lblGV_salesTotal.Name = "lblGV_salesTotal";
            this.lblGV_salesTotal.Size = new System.Drawing.Size(39, 12);
            this.lblGV_salesTotal.TabIndex = 504;
            this.lblGV_salesTotal.Text = "GV SALE";
            this.lblGV_salesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCash_PM_Total
            // 
            this.lblCash_PM_Total.AutoSize = true;
            this.lblCash_PM_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash_PM_Total.Location = new System.Drawing.Point(862, 463);
            this.lblCash_PM_Total.Name = "lblCash_PM_Total";
            this.lblCash_PM_Total.Size = new System.Drawing.Size(41, 12);
            this.lblCash_PM_Total.TabIndex = 505;
            this.lblCash_PM_Total.Text = "CSH TOT";
            this.lblCash_PM_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardPM_Total
            // 
            this.lblCardPM_Total.AutoSize = true;
            this.lblCardPM_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardPM_Total.Location = new System.Drawing.Point(921, 463);
            this.lblCardPM_Total.Name = "lblCardPM_Total";
            this.lblCardPM_Total.Size = new System.Drawing.Size(42, 12);
            this.lblCardPM_Total.TabIndex = 506;
            this.lblCardPM_Total.Text = "CAD TOT";
            this.lblCardPM_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheqePM_Total
            // 
            this.lblCheqePM_Total.AutoSize = true;
            this.lblCheqePM_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheqePM_Total.Location = new System.Drawing.Point(985, 463);
            this.lblCheqePM_Total.Name = "lblCheqePM_Total";
            this.lblCheqePM_Total.Size = new System.Drawing.Size(43, 12);
            this.lblCheqePM_Total.TabIndex = 507;
            this.lblCheqePM_Total.Text = "CHQ TOT";
            this.lblCheqePM_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_GV_PM_Total
            // 
            this.lbl_GV_PM_Total.AutoSize = true;
            this.lbl_GV_PM_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GV_PM_Total.Location = new System.Drawing.Point(1056, 463);
            this.lbl_GV_PM_Total.Name = "lbl_GV_PM_Total";
            this.lbl_GV_PM_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_GV_PM_Total.Size = new System.Drawing.Size(36, 12);
            this.lbl_GV_PM_Total.TabIndex = 508;
            this.lbl_GV_PM_Total.Text = "GV TOT";
            this.lbl_GV_PM_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCRN_PM_Total
            // 
            this.lblCRN_PM_Total.AutoSize = true;
            this.lblCRN_PM_Total.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCRN_PM_Total.Location = new System.Drawing.Point(1185, 463);
            this.lblCRN_PM_Total.Name = "lblCRN_PM_Total";
            this.lblCRN_PM_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCRN_PM_Total.Size = new System.Drawing.Size(42, 12);
            this.lblCRN_PM_Total.TabIndex = 509;
            this.lblCRN_PM_Total.Text = "CRN TOT";
            this.lblCRN_PM_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdvSettlement
            // 
            this.lblAdvSettlement.AutoSize = true;
            this.lblAdvSettlement.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvSettlement.Location = new System.Drawing.Point(1124, 463);
            this.lblAdvSettlement.Name = "lblAdvSettlement";
            this.lblAdvSettlement.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAdvSettlement.Size = new System.Drawing.Size(42, 12);
            this.lblAdvSettlement.TabIndex = 510;
            this.lblAdvSettlement.Text = "ADV TOT";
            this.lblAdvSettlement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(901, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 29);
            this.btnRefresh.TabIndex = 490;
            this.btnRefresh.Text = "Load";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frm_accPointOfSale_Posting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 550);
            this.Controls.Add(this.lblAdvSettlement);
            this.Controls.Add(this.lblCRN_PM_Total);
            this.Controls.Add(this.lbl_GV_PM_Total);
            this.Controls.Add(this.lblCheqePM_Total);
            this.Controls.Add(this.lblCardPM_Total);
            this.Controls.Add(this.lblCash_PM_Total);
            this.Controls.Add(this.lblGV_salesTotal);
            this.Controls.Add(this.lblInvSRN_Total);
            this.Controls.Add(this.lblSales_Total);
            this.Controls.Add(this.lblVat_Total);
            this.Controls.Add(this.lblAdv_RecivedTotal);
            this.Controls.Add(this.lblNbt_Total);
            this.Controls.Add(this.lblNetSales_Total);
            this.Controls.Add(this.lblChequeDeposit);
            this.Controls.Add(this.lblAccountReceipt);
            this.Controls.Add(this.lblDebtoeSettlement);
            this.Controls.Add(this.lblJE_Advance);
            this.Controls.Add(this.lblCashDeposit);
            this.Controls.Add(this.lblReceipt);
            this.Controls.Add(this.lblBankAjustEntry);
            this.Controls.Add(this.lblStdJE);
            this.Controls.Add(this.btnLedgerPosting);
            this.Controls.Add(this.xPanelFilters);
            this.Controls.Add(this.dgvPOS_LedgerPosting);
            this.Name = "frm_accPointOfSale_Posting";
            this.Text = "POS TRANSACTION LEDGER POSTING";
            this.Controls.SetChildIndex(this.dgvPOS_LedgerPosting, 0);
            this.Controls.SetChildIndex(this.xPanelFilters, 0);
            this.Controls.SetChildIndex(this.btnLedgerPosting, 0);
            this.Controls.SetChildIndex(this.lblStdJE, 0);
            this.Controls.SetChildIndex(this.lblBankAjustEntry, 0);
            this.Controls.SetChildIndex(this.lblReceipt, 0);
            this.Controls.SetChildIndex(this.lblCashDeposit, 0);
            this.Controls.SetChildIndex(this.lblJE_Advance, 0);
            this.Controls.SetChildIndex(this.lblDebtoeSettlement, 0);
            this.Controls.SetChildIndex(this.lblAccountReceipt, 0);
            this.Controls.SetChildIndex(this.lblChequeDeposit, 0);
            this.Controls.SetChildIndex(this.lblNetSales_Total, 0);
            this.Controls.SetChildIndex(this.lblNbt_Total, 0);
            this.Controls.SetChildIndex(this.lblAdv_RecivedTotal, 0);
            this.Controls.SetChildIndex(this.lblVat_Total, 0);
            this.Controls.SetChildIndex(this.lblSales_Total, 0);
            this.Controls.SetChildIndex(this.lblInvSRN_Total, 0);
            this.Controls.SetChildIndex(this.lblGV_salesTotal, 0);
            this.Controls.SetChildIndex(this.lblCash_PM_Total, 0);
            this.Controls.SetChildIndex(this.lblCardPM_Total, 0);
            this.Controls.SetChildIndex(this.lblCheqePM_Total, 0);
            this.Controls.SetChildIndex(this.lbl_GV_PM_Total, 0);
            this.Controls.SetChildIndex(this.lblCRN_PM_Total, 0);
            this.Controls.SetChildIndex(this.lblAdvSettlement, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS_LedgerPosting)).EndInit();
            this.xPanelFilters.ResumeLayout(false);
            this.xPanelFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid dgvPOS_LedgerPosting;
        private System.Windows.Forms.ComboBox cmbComBranch;
        private System.Windows.Forms.Label lblComBranch;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDatePeriod;
        private System.Windows.Forms.Panel xPanelFilters;
        private System.Windows.Forms.Button btnLedgerPosting;
        private System.Windows.Forms.LinkLabel lblStdJE;
        private System.Windows.Forms.LinkLabel lblBankAjustEntry;
        private System.Windows.Forms.LinkLabel lblReceipt;
        private System.Windows.Forms.LinkLabel lblCashDeposit;
        private System.Windows.Forms.LinkLabel lblJE_Advance;
        private System.Windows.Forms.LinkLabel lblDebtoeSettlement;
        private System.Windows.Forms.LinkLabel lblAccountReceipt;
        private System.Windows.Forms.LinkLabel lblChequeDeposit;
        private System.Windows.Forms.Label lblNetSales_Total;
        private System.Windows.Forms.Label lblNbt_Total;
        private System.Windows.Forms.Label lblAdv_RecivedTotal;
        private System.Windows.Forms.Label lblVat_Total;
        private System.Windows.Forms.Label lblSales_Total;
        private System.Windows.Forms.Label lblInvSRN_Total;
        private System.Windows.Forms.Label lblGV_salesTotal;
        private System.Windows.Forms.Label lblCash_PM_Total;
        private System.Windows.Forms.Label lblCardPM_Total;
        private System.Windows.Forms.Label lblCheqePM_Total;
        private System.Windows.Forms.Label lbl_GV_PM_Total;
        private System.Windows.Forms.Label lblCRN_PM_Total;
        private System.Windows.Forms.Label lblAdvSettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_BranchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nbt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_GiftVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_AdvPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_PM_Cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_PM_Card;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_PM_Cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_PM_GiftVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_PM_AdvSettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_PM_CRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tx_SalesEx_CRN;
        private System.Windows.Forms.Button btnRefresh;
    }
}