namespace Digiteq
{
    partial class frm_bpsReceiptAgeingViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_bpsReceiptAgeingViewer));
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
            this.label26 = new System.Windows.Forms.Label();
            this.x1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblReceiptID = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.lblReceiptDate = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.x3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInvoice = new SEACC_DataGrid();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAgeing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDueDateAgeing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDueDateAgeing = new System.Windows.Forms.Label();
            this.lblInvoiceAgeing = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.lblDepositAmount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.x4 = new System.Windows.Forms.Panel();
            this.lblTotalAllocatedAmount = new System.Windows.Forms.Label();
            this.lblTotalChequeAge = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvAllocation = new SEACC_DataGrid();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocatedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeAgeing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.x3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.x4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocation)).BeginInit();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(109, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(120, 19);
            this.label26.TabIndex = 274;
            this.label26.Text = "RECEIPT VIEWER";
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.Transparent;
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.btnPrint);
            this.x1.Controls.Add(this.lblCustomerName);
            this.x1.Controls.Add(this.btnRefresh);
            this.x1.Controls.Add(this.btnCancel);
            this.x1.Controls.Add(this.label72);
            this.x1.Controls.Add(this.label26);
            this.x1.Controls.Add(this.pictureBox1);
            this.x1.Controls.Add(this.lblReceiptID);
            this.x1.Controls.Add(this.label221);
            this.x1.Controls.Add(this.lblReceiptDate);
            this.x1.Controls.Add(this.label22);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(6, 6);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(835, 68);
            this.x1.TabIndex = 403;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(600, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 456;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(412, 38);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(415, 22);
            this.lblCustomerName.TabIndex = 387;
            this.lblCustomerName.Text = "1,120,175.00";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::Digiteq.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(676, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnRefresh.TabIndex = 396;
            this.btnRefresh.Text = "Refresh  ";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(752, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 395;
            this.btnCancel.Text = "Close    ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label72.Location = new System.Drawing.Point(307, 42);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(97, 15);
            this.label72.TabIndex = 390;
            this.label72.Text = "Customer Name";
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
            // lblReceiptID
            // 
            this.lblReceiptID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReceiptID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptID.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptID.Location = new System.Drawing.Point(412, 11);
            this.lblReceiptID.Name = "lblReceiptID";
            this.lblReceiptID.Size = new System.Drawing.Size(100, 22);
            this.lblReceiptID.TabIndex = 369;
            this.lblReceiptID.Text = "160,251.00";
            this.lblReceiptID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label221.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label221.Location = new System.Drawing.Point(307, 14);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(79, 15);
            this.label221.TabIndex = 357;
            this.label221.Text = "Receipt Code";
            // 
            // lblReceiptDate
            // 
            this.lblReceiptDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReceiptDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptDate.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptDate.Location = new System.Drawing.Point(121, 38);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(168, 22);
            this.lblReceiptDate.TabIndex = 368;
            this.lblReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label22.Location = new System.Drawing.Point(5, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 15);
            this.label22.TabIndex = 273;
            this.label22.Text = "Receipt Date";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label42.Location = new System.Drawing.Point(-1, -1);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(835, 25);
            this.label42.TabIndex = 356;
            this.label42.Text = "Receipt Comparison (Invoice Date && Invoice Due Date)";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // x3
            // 
            this.x3.BackColor = System.Drawing.Color.Transparent;
            this.x3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x3.Controls.Add(this.label2);
            this.x3.Controls.Add(this.label1);
            this.x3.Controls.Add(this.dgvInvoice);
            this.x3.Controls.Add(this.label7);
            this.x3.Controls.Add(this.lblDueDateAgeing);
            this.x3.Controls.Add(this.lblInvoiceAgeing);
            this.x3.Controls.Add(this.lblInvoiceTotal);
            this.x3.Controls.Add(this.lblDepositAmount);
            this.x3.Controls.Add(this.label15);
            this.x3.Controls.Add(this.label42);
            this.x3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x3.Location = new System.Drawing.Point(6, 81);
            this.x3.Name = "x3";
            this.x3.Size = new System.Drawing.Size(835, 185);
            this.x3.TabIndex = 405;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(638, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 592;
            this.label2.Text = "Due Date Ageing";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(371, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 591;
            this.label1.Text = "Invoice Ageing";
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.OrderRefNo,
            this.InvoiceAmount,
            this.ReceiptDate1,
            this.InvoiceDate,
            this.InvoiceAgeing,
            this.ReceiptDate2,
            this.InvoiceDueDate,
            this.InvoiceDueDateAgeing});
            this.dgvInvoice.EnableHeadersVisualStyles = false;
            this.dgvInvoice.Location = new System.Drawing.Point(-1, 23);
            this.dgvInvoice.MultiSelect = false;
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.Size = new System.Drawing.Size(835, 139);
            this.dgvInvoice.TabIndex = 585;
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "Invoice Code";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Width = 90;
            // 
            // OrderRefNo
            // 
            this.OrderRefNo.HeaderText = "Order RefNo";
            this.OrderRefNo.Name = "OrderRefNo";
            this.OrderRefNo.Width = 80;
            // 
            // InvoiceAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InvoiceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceAmount.HeaderText = "Invoice Amount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.Width = 90;
            // 
            // ReceiptDate1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ReceiptDate1.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReceiptDate1.HeaderText = "Receipt Date";
            this.ReceiptDate1.Name = "ReceiptDate1";
            // 
            // InvoiceDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.InvoiceDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            // 
            // InvoiceAgeing
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.InvoiceAgeing.DefaultCellStyle = dataGridViewCellStyle4;
            this.InvoiceAgeing.HeaderText = "Invoice Outst.";
            this.InvoiceAgeing.Name = "InvoiceAgeing";
            this.InvoiceAgeing.Width = 80;
            // 
            // ReceiptDate2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ReceiptDate2.DefaultCellStyle = dataGridViewCellStyle5;
            this.ReceiptDate2.HeaderText = "Receipt Date";
            this.ReceiptDate2.Name = "ReceiptDate2";
            // 
            // InvoiceDueDate
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.InvoiceDueDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.InvoiceDueDate.HeaderText = "Invoice Due Date";
            this.InvoiceDueDate.Name = "InvoiceDueDate";
            // 
            // InvoiceDueDateAgeing
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.InvoiceDueDateAgeing.DefaultCellStyle = dataGridViewCellStyle7;
            this.InvoiceDueDateAgeing.HeaderText = "DueDate Outst.";
            this.InvoiceDueDateAgeing.Name = "InvoiceDueDateAgeing";
            this.InvoiceDueDateAgeing.Width = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(47, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 15);
            this.label7.TabIndex = 590;
            this.label7.Text = "Invoice Total Amount";
            // 
            // lblDueDateAgeing
            // 
            this.lblDueDateAgeing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblDueDateAgeing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDueDateAgeing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDateAgeing.ForeColor = System.Drawing.Color.Green;
            this.lblDueDateAgeing.Location = new System.Drawing.Point(740, 162);
            this.lblDueDateAgeing.Name = "lblDueDateAgeing";
            this.lblDueDateAgeing.Size = new System.Drawing.Size(94, 22);
            this.lblDueDateAgeing.TabIndex = 589;
            this.lblDueDateAgeing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceAgeing
            // 
            this.lblInvoiceAgeing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblInvoiceAgeing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInvoiceAgeing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAgeing.ForeColor = System.Drawing.Color.Green;
            this.lblInvoiceAgeing.Location = new System.Drawing.Point(461, 162);
            this.lblInvoiceAgeing.Name = "lblInvoiceAgeing";
            this.lblInvoiceAgeing.Size = new System.Drawing.Size(79, 22);
            this.lblInvoiceAgeing.TabIndex = 588;
            this.lblInvoiceAgeing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.BackColor = System.Drawing.Color.White;
            this.lblInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTotal.ForeColor = System.Drawing.Color.Green;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(171, 162);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(89, 22);
            this.lblInvoiceTotal.TabIndex = 402;
            this.lblInvoiceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDepositAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDepositAmount.Location = new System.Drawing.Point(389, 76);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(123, 22);
            this.lblDepositAmount.TabIndex = 579;
            this.lblDepositAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Location = new System.Drawing.Point(282, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 15);
            this.label15.TabIndex = 577;
            this.label15.Text = "Security Deposit";
            // 
            // x4
            // 
            this.x4.BackColor = System.Drawing.Color.Transparent;
            this.x4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x4.Controls.Add(this.lblTotalAllocatedAmount);
            this.x4.Controls.Add(this.lblTotalChequeAge);
            this.x4.Controls.Add(this.label20);
            this.x4.Controls.Add(this.label9);
            this.x4.Controls.Add(this.dgvAllocation);
            this.x4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x4.Location = new System.Drawing.Point(6, 272);
            this.x4.Name = "x4";
            this.x4.Size = new System.Drawing.Size(835, 352);
            this.x4.TabIndex = 588;
            // 
            // lblTotalAllocatedAmount
            // 
            this.lblTotalAllocatedAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTotalAllocatedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAllocatedAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAllocatedAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAllocatedAmount.Location = new System.Drawing.Point(511, 328);
            this.lblTotalAllocatedAmount.Name = "lblTotalAllocatedAmount";
            this.lblTotalAllocatedAmount.Size = new System.Drawing.Size(81, 22);
            this.lblTotalAllocatedAmount.TabIndex = 597;
            this.lblTotalAllocatedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalChequeAge
            // 
            this.lblTotalChequeAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblTotalChequeAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalChequeAge.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalChequeAge.ForeColor = System.Drawing.Color.Black;
            this.lblTotalChequeAge.Location = new System.Drawing.Point(752, 328);
            this.lblTotalChequeAge.Name = "lblTotalChequeAge";
            this.lblTotalChequeAge.Size = new System.Drawing.Size(82, 22);
            this.lblTotalChequeAge.TabIndex = 596;
            this.lblTotalChequeAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label20.Location = new System.Drawing.Point(363, 331);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(135, 15);
            this.label20.TabIndex = 595;
            this.label20.Text = "Total Allocated Amount";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(-1, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(835, 25);
            this.label9.TabIndex = 356;
            this.label9.Text = "Receipt Allocation To Invoice Settlement";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAllocation
            // 
            this.dgvAllocation.AllowUserToAddRows = false;
            this.dgvAllocation.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvAllocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAllocation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAllocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BankName,
            this.ChequeNo,
            this.Remark,
            this.CInvoiceID,
            this.ChequeAmount,
            this.AllocatedAmount,
            this.ChequeDate,
            this.CInvoiceDate,
            this.ChequeAgeing});
            this.dgvAllocation.EnableHeadersVisualStyles = false;
            this.dgvAllocation.Location = new System.Drawing.Point(1, 23);
            this.dgvAllocation.MultiSelect = false;
            this.dgvAllocation.Name = "dgvAllocation";
            this.dgvAllocation.RowHeadersVisible = false;
            this.dgvAllocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAllocation.Size = new System.Drawing.Size(833, 305);
            this.dgvAllocation.TabIndex = 588;
            // 
            // BankName
            // 
            this.BankName.HeaderText = "Bank Name";
            this.BankName.Name = "BankName";
            this.BankName.Width = 155;
            // 
            // ChequeNo
            // 
            this.ChequeNo.HeaderText = "Cheque No";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.Width = 80;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Cheque Status";
            this.Remark.Name = "Remark";
            this.Remark.Width = 95;
            // 
            // CInvoiceID
            // 
            this.CInvoiceID.HeaderText = "Invoice Code";
            this.CInvoiceID.Name = "CInvoiceID";
            // 
            // ChequeAmount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ChequeAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.ChequeAmount.HeaderText = "Cheque Amt";
            this.ChequeAmount.Name = "ChequeAmount";
            this.ChequeAmount.Width = 80;
            // 
            // AllocatedAmount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.AllocatedAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.AllocatedAmount.HeaderText = "Allocate Amt";
            this.AllocatedAmount.Name = "AllocatedAmount";
            this.AllocatedAmount.Width = 80;
            // 
            // ChequeDate
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ChequeDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.ChequeDate.HeaderText = "Cheque Date";
            this.ChequeDate.Name = "ChequeDate";
            this.ChequeDate.Width = 80;
            // 
            // CInvoiceDate
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.CInvoiceDate.DefaultCellStyle = dataGridViewCellStyle11;
            this.CInvoiceDate.HeaderText = "InvoiceDate";
            this.CInvoiceDate.Name = "CInvoiceDate";
            this.CInvoiceDate.Width = 80;
            // 
            // ChequeAgeing
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ChequeAgeing.DefaultCellStyle = dataGridViewCellStyle12;
            this.ChequeAgeing.HeaderText = "Cheque Age";
            this.ChequeAgeing.Name = "ChequeAgeing";
            this.ChequeAgeing.Width = 80;
            // 
            // frm_bpsReceiptAgeingViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(848, 630);
            this.ControlBox = false;
            this.Controls.Add(this.x4);
            this.Controls.Add(this.x3);
            this.Controls.Add(this.x1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_bpsReceiptAgeingViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_bpsChequeViewer_Load);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.x3.ResumeLayout(false);
            this.x3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.x4.ResumeLayout(false);
            this.x4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblReceiptID;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.Label lblReceiptDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel x3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDepositAmount;
        private System.Windows.Forms.Label label15;
        private SEACC_DataGrid dgvInvoice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDueDateAgeing;
        private System.Windows.Forms.Label lblInvoiceAgeing;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private System.Windows.Forms.Panel x4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnPrint;
        private SEACC_DataGrid dgvAllocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAllocatedAmount;
        private System.Windows.Forms.Label lblTotalChequeAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAgeing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDueDateAgeing;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn CInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocatedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeAgeing;
    }
}