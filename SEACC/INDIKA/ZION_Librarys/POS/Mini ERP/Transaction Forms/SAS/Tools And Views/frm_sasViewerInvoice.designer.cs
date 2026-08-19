namespace Digiteq
{
    partial class frm_sasViewerInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sasViewerInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label26 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.x1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSattledAmount = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.lblInvoiceAmount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.x3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvReconciliation = new System.Windows.Forms.DataGridView();
            this.ChequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.dgvSattledmentDetail = new System.Windows.Forms.DataGridView();
            this.SettlementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatleAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SattledBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeRegister_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receipt_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.x1.SuspendLayout();
            this.x3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconciliation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSattledmentDetail)).BeginInit();
            this.x5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(109, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(121, 19);
            this.label26.TabIndex = 274;
            this.label26.Text = "INVOICE VIEWER";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 385;
            this.pictureBox1.TabStop = false;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.Transparent;
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.textBox1);
            this.x1.Controls.Add(this.lblCustomerName);
            this.x1.Controls.Add(this.lblBalance);
            this.x1.Controls.Add(this.btnRefresh);
            this.x1.Controls.Add(this.label);
            this.x1.Controls.Add(this.btnCancel);
            this.x1.Controls.Add(this.lblSattledAmount);
            this.x1.Controls.Add(this.label72);
            this.x1.Controls.Add(this.lblInvoiceAmount);
            this.x1.Controls.Add(this.label14);
            this.x1.Controls.Add(this.label26);
            this.x1.Controls.Add(this.label15);
            this.x1.Controls.Add(this.pictureBox1);
            this.x1.Controls.Add(this.lblInvoiceDate);
            this.x1.Controls.Add(this.lblInvoiceID);
            this.x1.Controls.Add(this.label22);
            this.x1.Controls.Add(this.label95);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(9, 6);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(692, 97);
            this.x1.TabIndex = 403;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(413, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 22);
            this.textBox1.TabIndex = 595;
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(339, 39);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(343, 22);
            this.lblCustomerName.TabIndex = 387;
            this.lblCustomerName.Text = "1,120,175.00";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(559, 66);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(123, 22);
            this.lblBalance.TabIndex = 594;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::Digiteq.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(551, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 25);
            this.btnRefresh.TabIndex = 396;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label.Location = new System.Drawing.Point(495, 70);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 14);
            this.label.TabIndex = 593;
            this.label.Text = "Balance";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(617, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 25);
            this.btnCancel.TabIndex = 395;
            this.btnCancel.Text = "  Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSattledAmount
            // 
            this.lblSattledAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSattledAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSattledAmount.ForeColor = System.Drawing.Color.Black;
            this.lblSattledAmount.Location = new System.Drawing.Point(339, 66);
            this.lblSattledAmount.Name = "lblSattledAmount";
            this.lblSattledAmount.Size = new System.Drawing.Size(123, 22);
            this.lblSattledAmount.TabIndex = 580;
            this.lblSattledAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label72.Location = new System.Drawing.Point(237, 43);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(97, 15);
            this.label72.TabIndex = 390;
            this.label72.Text = "Customer Name";
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInvoiceAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAmount.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceAmount.Location = new System.Drawing.Point(107, 66);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(123, 22);
            this.lblInvoiceAmount.TabIndex = 579;
            this.lblInvoiceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label14.Location = new System.Drawing.Point(237, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 15);
            this.label14.TabIndex = 578;
            this.label14.Text = "Sattled Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Location = new System.Drawing.Point(3, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 15);
            this.label15.TabIndex = 577;
            this.label15.Text = "Invoice Amount";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceDate.Location = new System.Drawing.Point(107, 39);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(123, 22);
            this.lblInvoiceDate.TabIndex = 369;
            this.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceID.Location = new System.Drawing.Point(301, 5);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(168, 22);
            this.lblInvoiceID.TabIndex = 368;
            this.lblInvoiceID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label22.Location = new System.Drawing.Point(237, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 15);
            this.label22.TabIndex = 273;
            this.label22.Text = "Invoice ID";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label95.Location = new System.Drawing.Point(5, 43);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(74, 15);
            this.label95.TabIndex = 357;
            this.label95.Text = "Invoice Date";
            // 
            // x3
            // 
            this.x3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.x3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x3.Controls.Add(this.label3);
            this.x3.Controls.Add(this.dgvReconciliation);
            this.x3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x3.Location = new System.Drawing.Point(358, 109);
            this.x3.Name = "x3";
            this.x3.Size = new System.Drawing.Size(343, 171);
            this.x3.TabIndex = 405;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(-1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 25);
            this.label3.TabIndex = 478;
            this.label3.Text = "Cheque Details";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvReconciliation
            // 
            this.dgvReconciliation.AllowUserToAddRows = false;
            this.dgvReconciliation.AllowUserToDeleteRows = false;
            this.dgvReconciliation.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvReconciliation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReconciliation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvReconciliation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChequeDate,
            this.RChequeNo,
            this.RAmount});
            this.dgvReconciliation.EnableHeadersVisualStyles = false;
            this.dgvReconciliation.Location = new System.Drawing.Point(6, 30);
            this.dgvReconciliation.MultiSelect = false;
            this.dgvReconciliation.Name = "dgvReconciliation";
            this.dgvReconciliation.RowHeadersVisible = false;
            this.dgvReconciliation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvReconciliation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReconciliation.Size = new System.Drawing.Size(332, 133);
            this.dgvReconciliation.TabIndex = 477;
            // 
            // ChequeDate
            // 
            this.ChequeDate.HeaderText = "Cheque Date";
            this.ChequeDate.Name = "ChequeDate";
            this.ChequeDate.ReadOnly = true;
            this.ChequeDate.Width = 107;
            // 
            // RChequeNo
            // 
            this.RChequeNo.HeaderText = "Cheque No";
            this.RChequeNo.Name = "RChequeNo";
            this.RChequeNo.ReadOnly = true;
            // 
            // RAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.RAmount.HeaderText = "Amount";
            this.RAmount.Name = "RAmount";
            this.RAmount.ReadOnly = true;
            this.RAmount.Width = 120;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptDate,
            this.Receipt_ID,
            this.Amount});
            this.dgvAccounts.EnableHeadersVisualStyles = false;
            this.dgvAccounts.Location = new System.Drawing.Point(7, 30);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.RowHeadersVisible = false;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(328, 133);
            this.dgvAccounts.TabIndex = 407;
            // 
            // dgvSattledmentDetail
            // 
            this.dgvSattledmentDetail.AllowUserToAddRows = false;
            this.dgvSattledmentDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvSattledmentDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSattledmentDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSattledmentDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SettlementDate,
            this.InvoiceAmount,
            this.SatleAmount,
            this.SattledBy,
            this.ReceiptID,
            this.ChequeRegister_ID,
            this.Balance});
            this.dgvSattledmentDetail.EnableHeadersVisualStyles = false;
            this.dgvSattledmentDetail.Location = new System.Drawing.Point(8, 30);
            this.dgvSattledmentDetail.MultiSelect = false;
            this.dgvSattledmentDetail.Name = "dgvSattledmentDetail";
            this.dgvSattledmentDetail.RowHeadersVisible = false;
            this.dgvSattledmentDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSattledmentDetail.Size = new System.Drawing.Size(674, 218);
            this.dgvSattledmentDetail.TabIndex = 585;
            // 
            // SettlementDate
            // 
            this.SettlementDate.HeaderText = "Settlement Date";
            this.SettlementDate.Name = "SettlementDate";
            // 
            // InvoiceAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InvoiceAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.InvoiceAmount.HeaderText = "Invoice Amount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.Width = 90;
            // 
            // SatleAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SatleAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.SatleAmount.HeaderText = "Sattled Amount";
            this.SatleAmount.Name = "SatleAmount";
            // 
            // SattledBy
            // 
            this.SattledBy.HeaderText = "Sattled By";
            this.SattledBy.Name = "SattledBy";
            // 
            // ReceiptID
            // 
            this.ReceiptID.HeaderText = "Receipt ID";
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.Width = 80;
            // 
            // ChequeRegister_ID
            // 
            this.ChequeRegister_ID.HeaderText = "Cheque No";
            this.ChequeRegister_ID.Name = "ChequeRegister_ID";
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            // 
            // x5
            // 
            this.x5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.x5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x5.Controls.Add(this.dgvSattledmentDetail);
            this.x5.Controls.Add(this.label1);
            this.x5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x5.Location = new System.Drawing.Point(9, 286);
            this.x5.Name = "x5";
            this.x5.Size = new System.Drawing.Size(692, 256);
            this.x5.TabIndex = 587;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(692, 25);
            this.label1.TabIndex = 356;
            this.label1.Text = "Sattledment Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvAccounts);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 171);
            this.panel1.TabIndex = 589;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 25);
            this.label2.TabIndex = 356;
            this.label2.Text = "Receipt Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.HeaderText = "Receipt Date";
            this.ReceiptDate.Name = "ReceiptDate";
            // 
            // Receipt_ID
            // 
            this.Receipt_ID.HeaderText = "Receipt ID";
            this.Receipt_ID.Name = "Receipt_ID";
            // 
            // Amount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 123;
            // 
            // frm_sasViewerInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(708, 549);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.x5);
            this.Controls.Add(this.x3);
            this.Controls.Add(this.x1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_sasViewerInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_bpsChequeViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.x3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconciliation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSattledmentDetail)).EndInit();
            this.x5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Panel x3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSattledAmount;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvSattledmentDetail;
        private System.Windows.Forms.Panel x5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dgvReconciliation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettlementDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatleAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SattledBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeRegister_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}