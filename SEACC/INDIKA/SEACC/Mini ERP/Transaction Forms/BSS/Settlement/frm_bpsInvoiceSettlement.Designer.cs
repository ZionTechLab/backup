namespace Digiteq
{
    partial class frm_bpsInvoiceSettlement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvCredits = new SEACC_DataGrid();
            this.TxnCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxnIDCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvDebits = new SEACC_DataGrid();
            this.TxnDb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxnIDDb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateDb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountDb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxActiveFilter = new System.Windows.Forms.CheckBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.zpnlSelettedInvoice = new System.Windows.Forms.FlowLayoutPanel();
            this.zpnlSettledPayment = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblPaymentAmount = new System.Windows.Forms.TextBox();
            this.lblInvoiceAmount = new System.Windows.Forms.TextBox();
            this.pgrInvoice = new System.Windows.Forms.ProgressBar();
            this.pgrPayment = new System.Windows.Forms.ProgressBar();
            this.dgvDetail = new SEACC_DataGrid();
            this.SettlemetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAllocationCode = new System.Windows.Forms.TextBox();
            this.dtpAllocationDate = new System.Windows.Forms.DateTimePicker();
            this.chkActiveAllocationDate = new System.Windows.Forms.CheckBox();
            this.chkAdvanceAllocation = new System.Windows.Forms.CheckBox();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebits)).BeginInit();
            this.z1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.dgvCredits);
            this.panel8.Controls.Add(this.label18);
            this.panel8.Controls.Add(this.chkActiveAllocationDate);
            this.panel8.Controls.Add(this.dtpAllocationDate);
            this.panel8.Controls.Add(this.txtAllocationCode);
            this.panel8.Controls.Add(this.chkAdvanceAllocation);
            this.panel8.Location = new System.Drawing.Point(338, 9);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(318, 220);
            this.panel8.TabIndex = 590;
            // 
            // dgvCredits
            // 
            this.dgvCredits.AllowUserToAddRows = false;
            this.dgvCredits.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCredits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TxnCr,
            this.TxnIDCr,
            this.DateCr,
            this.AmountCr});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCredits.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCredits.Location = new System.Drawing.Point(0, 18);
            this.dgvCredits.MultiSelect = false;
            this.dgvCredits.Name = "dgvCredits";
            this.dgvCredits.ReadOnly = true;
            this.dgvCredits.RowHeadersVisible = false;
            this.dgvCredits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCredits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCredits.Size = new System.Drawing.Size(318, 202);
            this.dgvCredits.TabIndex = 0;
            this.dgvCredits.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCredits_CellContentDoubleClick);
            this.dgvCredits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCredits_CellDoubleClick);
            this.dgvCredits.MouseLeave += new System.EventHandler(this.dgvCredits_MouseLeave);
            this.dgvCredits.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCredits_MouseUp);
            // 
            // TxnCr
            // 
            this.TxnCr.HeaderText = "Txn";
            this.TxnCr.Name = "TxnCr";
            this.TxnCr.ReadOnly = true;
            this.TxnCr.Width = 50;
            // 
            // TxnIDCr
            // 
            this.TxnIDCr.HeaderText = "Txn ID";
            this.TxnIDCr.Name = "TxnIDCr";
            this.TxnIDCr.ReadOnly = true;
            // 
            // DateCr
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.DateCr.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateCr.HeaderText = "Date";
            this.DateCr.Name = "DateCr";
            this.DateCr.ReadOnly = true;
            this.DateCr.Width = 70;
            // 
            // AmountCr
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.AmountCr.DefaultCellStyle = dataGridViewCellStyle2;
            this.AmountCr.HeaderText = "Amount";
            this.AmountCr.Name = "AmountCr";
            this.AmountCr.ReadOnly = true;
            this.AmountCr.Width = 80;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(318, 18);
            this.label18.TabIndex = 567;
            this.label18.Text = "UN-SETTLED CREDITS";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.dgvDebits);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Location = new System.Drawing.Point(8, 9);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(318, 220);
            this.panel7.TabIndex = 589;
            // 
            // dgvDebits
            // 
            this.dgvDebits.AllowUserToAddRows = false;
            this.dgvDebits.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDebits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDebits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TxnDb,
            this.TxnIDDb,
            this.DateDb,
            this.AmountDb});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDebits.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDebits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDebits.Location = new System.Drawing.Point(0, 18);
            this.dgvDebits.MultiSelect = false;
            this.dgvDebits.Name = "dgvDebits";
            this.dgvDebits.ReadOnly = true;
            this.dgvDebits.RowHeadersVisible = false;
            this.dgvDebits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDebits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDebits.Size = new System.Drawing.Size(318, 202);
            this.dgvDebits.TabIndex = 0;
            this.dgvDebits.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDebits_CellContentDoubleClick);
            this.dgvDebits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDebits_CellDoubleClick);
            this.dgvDebits.MouseLeave += new System.EventHandler(this.dgvDebits_MouseLeave);
            this.dgvDebits.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvDebits_MouseUp);
            // 
            // TxnDb
            // 
            this.TxnDb.HeaderText = "Txn";
            this.TxnDb.Name = "TxnDb";
            this.TxnDb.ReadOnly = true;
            this.TxnDb.Width = 50;
            // 
            // TxnIDDb
            // 
            this.TxnIDDb.HeaderText = "Txn ID";
            this.TxnIDDb.Name = "TxnIDDb";
            this.TxnIDDb.ReadOnly = true;
            // 
            // DateDb
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DateDb.DefaultCellStyle = dataGridViewCellStyle4;
            this.DateDb.HeaderText = "Date";
            this.DateDb.Name = "DateDb";
            this.DateDb.ReadOnly = true;
            this.DateDb.Width = 70;
            // 
            // AmountDb
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.AmountDb.DefaultCellStyle = dataGridViewCellStyle5;
            this.AmountDb.HeaderText = "Amount";
            this.AmountDb.Name = "AmountDb";
            this.AmountDb.ReadOnly = true;
            this.AmountDb.Width = 80;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(318, 18);
            this.label19.TabIndex = 567;
            this.label19.Text = "UN-SETTLED DEBITS";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(670, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 14);
            this.label13.TabIndex = 459;
            this.label13.Text = "Date To";
            // 
            // cbxActiveFilter
            // 
            this.cbxActiveFilter.AutoSize = true;
            this.cbxActiveFilter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxActiveFilter.ForeColor = System.Drawing.Color.Maroon;
            this.cbxActiveFilter.Location = new System.Drawing.Point(872, 69);
            this.cbxActiveFilter.Name = "cbxActiveFilter";
            this.cbxActiveFilter.Size = new System.Drawing.Size(86, 18);
            this.cbxActiveFilter.TabIndex = 457;
            this.cbxActiveFilter.Text = "Active Filter";
            this.cbxActiveFilter.UseVisualStyleBackColor = true;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(764, 40);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(95, 22);
            this.dtpFromDate.TabIndex = 455;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Maroon;
            this.lblFromDate.Location = new System.Drawing.Point(670, 44);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(60, 14);
            this.lblFromDate.TabIndex = 454;
            this.lblFromDate.Text = "Date From";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(764, 65);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(95, 22);
            this.dtpToDate.TabIndex = 453;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(764, 15);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(215, 22);
            this.txtCustomerID.TabIndex = 3;
            this.txtCustomerID.Text = "Asanka Jayasuriya";
            this.txtCustomerID.DoubleClick += new System.EventHandler(this.txtCustomerID_DoubleClick);
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomerID.Location = new System.Drawing.Point(670, 16);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(87, 14);
            this.lblCustomerID.TabIndex = 2;
            this.lblCustomerID.Text = "Customer Name";
            // 
            // zpnlSelettedInvoice
            // 
            this.zpnlSelettedInvoice.AutoScroll = true;
            this.zpnlSelettedInvoice.BackColor = System.Drawing.Color.White;
            this.zpnlSelettedInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpnlSelettedInvoice.Location = new System.Drawing.Point(-1, 17);
            this.zpnlSelettedInvoice.Name = "zpnlSelettedInvoice";
            this.zpnlSelettedInvoice.Size = new System.Drawing.Size(378, 74);
            this.zpnlSelettedInvoice.TabIndex = 449;
            this.zpnlSelettedInvoice.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlSelettedInvoice_DragDrop);
            this.zpnlSelettedInvoice.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlSelettedInvoice_DragEnter);
            // 
            // zpnlSettledPayment
            // 
            this.zpnlSettledPayment.AllowDrop = true;
            this.zpnlSettledPayment.AutoScroll = true;
            this.zpnlSettledPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpnlSettledPayment.Location = new System.Drawing.Point(383, 17);
            this.zpnlSettledPayment.Name = "zpnlSettledPayment";
            this.zpnlSettledPayment.Size = new System.Drawing.Size(611, 74);
            this.zpnlSettledPayment.TabIndex = 450;
            this.zpnlSettledPayment.DragDrop += new System.Windows.Forms.DragEventHandler(this.zpnlSettledPayment_DragDrop);
            this.zpnlSettledPayment.DragEnter += new System.Windows.Forms.DragEventHandler(this.zpnlSettledPayment_DragEnter);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(-1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(378, 18);
            this.label5.TabIndex = 567;
            this.label5.Text = "DEBIT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(383, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(611, 18);
            this.label6.TabIndex = 568;
            this.label6.Text = "CREDIT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(6, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 14);
            this.label7.TabIndex = 576;
            this.label7.Text = "Debit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(5, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 14);
            this.label9.TabIndex = 578;
            this.label9.Text = "Credit";
            // 
            // z1
            // 
            this.z1.AllowDrop = true;
            this.z1.BackColor = System.Drawing.Color.White;
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.label12);
            this.z1.Controls.Add(this.txtBalance);
            this.z1.Controls.Add(this.lblPaymentAmount);
            this.z1.Controls.Add(this.lblInvoiceAmount);
            this.z1.Controls.Add(this.zpnlSelettedInvoice);
            this.z1.Controls.Add(this.label5);
            this.z1.Controls.Add(this.label6);
            this.z1.Controls.Add(this.zpnlSettledPayment);
            this.z1.Controls.Add(this.pgrInvoice);
            this.z1.Controls.Add(this.label9);
            this.z1.Controls.Add(this.pgrPayment);
            this.z1.Controls.Add(this.label7);
            this.z1.Location = new System.Drawing.Point(8, 260);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(990, 145);
            this.z1.TabIndex = 451;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(901, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 14);
            this.label12.TabIndex = 588;
            this.label12.Text = "Balance Amount";
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.SystemColors.Control;
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(906, 117);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(77, 22);
            this.txtBalance.TabIndex = 587;
            this.txtBalance.Text = "GN005";
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.BackColor = System.Drawing.SystemColors.Control;
            this.lblPaymentAmount.Enabled = false;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAmount.Location = new System.Drawing.Point(87, 118);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(77, 22);
            this.lblPaymentAmount.TabIndex = 586;
            this.lblPaymentAmount.Text = "GN005";
            this.lblPaymentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.BackColor = System.Drawing.SystemColors.Control;
            this.lblInvoiceAmount.Enabled = false;
            this.lblInvoiceAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAmount.Location = new System.Drawing.Point(87, 94);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(77, 22);
            this.lblInvoiceAmount.TabIndex = 452;
            this.lblInvoiceAmount.Text = "GN005";
            this.lblInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pgrInvoice
            // 
            this.pgrInvoice.Location = new System.Drawing.Point(170, 94);
            this.pgrInvoice.Maximum = 0;
            this.pgrInvoice.Name = "pgrInvoice";
            this.pgrInvoice.Size = new System.Drawing.Size(725, 22);
            this.pgrInvoice.Step = 1;
            this.pgrInvoice.TabIndex = 4;
            // 
            // pgrPayment
            // 
            this.pgrPayment.Location = new System.Drawing.Point(170, 118);
            this.pgrPayment.Maximum = 0;
            this.pgrPayment.Name = "pgrPayment";
            this.pgrPayment.Size = new System.Drawing.Size(725, 22);
            this.pgrPayment.Step = 1;
            this.pgrPayment.TabIndex = 5;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SettlemetDate,
            this.InvoiceID,
            this.PaymentType,
            this.DocumentRefNo,
            this.DebitAmount,
            this.CreditAmount,
            this.BalanceAmount});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 427);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(990, 142);
            this.dgvDetail.TabIndex = 570;
            // 
            // SettlemetDate
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SettlemetDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.SettlemetDate.HeaderText = "Invoice Date";
            this.SettlemetDate.Name = "SettlemetDate";
            // 
            // InvoiceID
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.InvoiceID.DefaultCellStyle = dataGridViewCellStyle8;
            this.InvoiceID.HeaderText = "Invoice No";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Width = 120;
            // 
            // PaymentType
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PaymentType.DefaultCellStyle = dataGridViewCellStyle9;
            this.PaymentType.HeaderText = "Narration";
            this.PaymentType.Name = "PaymentType";
            this.PaymentType.Width = 275;
            // 
            // DocumentRefNo
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DocumentRefNo.DefaultCellStyle = dataGridViewCellStyle10;
            this.DocumentRefNo.HeaderText = "Document Amount";
            this.DocumentRefNo.Name = "DocumentRefNo";
            this.DocumentRefNo.Width = 120;
            // 
            // DebitAmount
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DebitAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.DebitAmount.HeaderText = "Debit Amount";
            this.DebitAmount.Name = "DebitAmount";
            this.DebitAmount.Width = 120;
            // 
            // CreditAmount
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.CreditAmount.HeaderText = "Credit Amount";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.Width = 120;
            // 
            // BalanceAmount
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BalanceAmount.DefaultCellStyle = dataGridViewCellStyle13;
            this.BalanceAmount.HeaderText = "Balance Amount";
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.Width = 120;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label8.Location = new System.Drawing.Point(8, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 14);
            this.label8.TabIndex = 580;
            this.label8.Text = "DRAG AND DROP HERE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label10.Location = new System.Drawing.Point(594, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 14);
            this.label10.TabIndex = 582;
            this.label10.Text = "DRAG AND DROP HERE";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Digiteq.Properties.Resources.download;
            this.pictureBox2.Location = new System.Drawing.Point(720, 237);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 18);
            this.pictureBox2.TabIndex = 583;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Digiteq.Properties.Resources.download;
            this.pictureBox1.Location = new System.Drawing.Point(134, 237);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.TabIndex = 581;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label11.Location = new System.Drawing.Point(8, 411);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(990, 18);
            this.label11.TabIndex = 587;
            this.label11.Text = "INVOICE SETTLEMENT LEDGER DETAIL - WITH PAYMENT DETAIL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAllocationCode
            // 
            this.txtAllocationCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllocationCode.Location = new System.Drawing.Point(87, 81);
            this.txtAllocationCode.Name = "txtAllocationCode";
            this.txtAllocationCode.Size = new System.Drawing.Size(120, 22);
            this.txtAllocationCode.TabIndex = 463;
            this.txtAllocationCode.Text = "Asanka Jayasuriya";
            this.txtAllocationCode.Visible = false;
            // 
            // dtpAllocationDate
            // 
            this.dtpAllocationDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtpAllocationDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAllocationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAllocationDate.Location = new System.Drawing.Point(103, 110);
            this.dtpAllocationDate.Name = "dtpAllocationDate";
            this.dtpAllocationDate.Size = new System.Drawing.Size(95, 22);
            this.dtpAllocationDate.TabIndex = 461;
            this.dtpAllocationDate.Visible = false;
            // 
            // chkActiveAllocationDate
            // 
            this.chkActiveAllocationDate.AutoSize = true;
            this.chkActiveAllocationDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkActiveAllocationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chkActiveAllocationDate.Location = new System.Drawing.Point(143, 138);
            this.chkActiveAllocationDate.Name = "chkActiveAllocationDate";
            this.chkActiveAllocationDate.Size = new System.Drawing.Size(136, 18);
            this.chkActiveAllocationDate.TabIndex = 464;
            this.chkActiveAllocationDate.Text = "Active Allocation Date";
            this.chkActiveAllocationDate.UseVisualStyleBackColor = true;
            this.chkActiveAllocationDate.Visible = false;
            // 
            // chkAdvanceAllocation
            // 
            this.chkAdvanceAllocation.AutoSize = true;
            this.chkAdvanceAllocation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkAdvanceAllocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkAdvanceAllocation.Location = new System.Drawing.Point(143, 81);
            this.chkAdvanceAllocation.Name = "chkAdvanceAllocation";
            this.chkAdvanceAllocation.Size = new System.Drawing.Size(120, 18);
            this.chkAdvanceAllocation.TabIndex = 458;
            this.chkAdvanceAllocation.Text = "Advance Allocation";
            this.chkAdvanceAllocation.UseVisualStyleBackColor = true;
            this.chkAdvanceAllocation.Visible = false;
            // 
            // frm_bpsInvoiceSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxActiveFilter);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.z1);
            this.Name = "frm_bpsInvoiceSettlement";
            this.Size = new System.Drawing.Size(1007, 633);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsInvoiceSettlement_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsInvoiceSettlement_SF_saveButton_Click);
            this.Load += new System.EventHandler(this.frm_sasInvoiceSettlement_Load);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.dtpToDate, 0);
            this.Controls.SetChildIndex(this.lblFromDate, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.dtpFromDate, 0);
            this.Controls.SetChildIndex(this.panel8, 0);
            this.Controls.SetChildIndex(this.cbxActiveFilter, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.lblCustomerID, 0);
            this.Controls.SetChildIndex(this.txtCustomerID, 0);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredits)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebits)).EndInit();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.ProgressBar pgrInvoice;
        private System.Windows.Forms.ProgressBar pgrPayment;
        private System.Windows.Forms.TextBox lblInvoiceAmount;
        private System.Windows.Forms.TextBox lblPaymentAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.CheckBox cbxActiveFilter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettlemetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceAmount;
        private System.Windows.Forms.FlowLayoutPanel zpnlSelettedInvoice;
        private System.Windows.Forms.FlowLayoutPanel zpnlSettledPayment;
        private System.Windows.Forms.Panel panel7;
        private SEACC_DataGrid dgvDebits;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel8;
        private SEACC_DataGrid dgvCredits;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxnDb;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxnIDDb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateDb;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountDb;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxnCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxnIDCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountCr;
        private System.Windows.Forms.TextBox txtAllocationCode;
        private System.Windows.Forms.DateTimePicker dtpAllocationDate;
        private System.Windows.Forms.CheckBox chkActiveAllocationDate;
        private System.Windows.Forms.CheckBox chkAdvanceAllocation;
    }
}