namespace Digiteq
{
    partial class frm_sasOpeningBalance
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
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.x1 = new System.Windows.Forms.Panel();
            this.dgvDetail = new SEACC_DataGrid();
            this.txtTimeCheckedBy = new System.Windows.Forms.TextBox();
            this.txtTimeApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpTimeApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.txtDateCheckedBy = new System.Windows.Forms.TextBox();
            this.txtDateApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpDateApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDateCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.txtCheckedBy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnCustomerViewer = new System.Windows.Forms.Button();
            this.Z2 = new System.Windows.Forms.Panel();
            this.dtpChequeDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Panel();
            this.dtpTimePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpDatePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPreparedBy = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.Z2.SuspendLayout();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(99, 8);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(228, 22);
            this.txtCustomerID.TabIndex = 433;
            this.txtCustomerID.Text = "Asanka Jayasuriya";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomerID.Location = new System.Drawing.Point(6, 11);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(87, 14);
            this.lblCustomerID.TabIndex = 434;
            this.lblCustomerID.Text = "Customer Name";
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.dgvDetail);
            this.x1.Controls.Add(this.txtTimeCheckedBy);
            this.x1.Controls.Add(this.txtTimeApprovedBy);
            this.x1.Controls.Add(this.dtpTimeApprovedBy);
            this.x1.Controls.Add(this.dtpTimeCheckedBy);
            this.x1.Controls.Add(this.txtDateCheckedBy);
            this.x1.Controls.Add(this.txtDateApprovedBy);
            this.x1.Controls.Add(this.dtpDateApprovedBy);
            this.x1.Controls.Add(this.label29);
            this.x1.Controls.Add(this.dtpDateCheckedBy);
            this.x1.Controls.Add(this.label26);
            this.x1.Controls.Add(this.txtApprovedBy);
            this.x1.Controls.Add(this.txtCheckedBy);
            this.x1.Controls.Add(this.label5);
            this.x1.Controls.Add(this.label28);
            this.x1.Controls.Add(this.btnCustomerViewer);
            this.x1.Controls.Add(this.txtCustomerID);
            this.x1.Controls.Add(this.lblCustomerID);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(468, 168);
            this.x1.TabIndex = 435;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.InvoiceDate,
            this.InvoiceAmount,
            this.DueAmount});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(-1, 39);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(468, 127);
            this.dgvDetail.TabIndex = 452;
            // 
            // txtTimeCheckedBy
            // 
            this.txtTimeCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeCheckedBy.Enabled = false;
            this.txtTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeCheckedBy.Location = new System.Drawing.Point(382, 90);
            this.txtTimeCheckedBy.Name = "txtTimeCheckedBy";
            this.txtTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.txtTimeCheckedBy.TabIndex = 485;
            // 
            // txtTimeApprovedBy
            // 
            this.txtTimeApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeApprovedBy.Enabled = false;
            this.txtTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeApprovedBy.Location = new System.Drawing.Point(394, 118);
            this.txtTimeApprovedBy.Name = "txtTimeApprovedBy";
            this.txtTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.txtTimeApprovedBy.TabIndex = 484;
            // 
            // dtpTimeApprovedBy
            // 
            this.dtpTimeApprovedBy.Enabled = false;
            this.dtpTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeApprovedBy.Location = new System.Drawing.Point(385, 141);
            this.dtpTimeApprovedBy.Name = "dtpTimeApprovedBy";
            this.dtpTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeApprovedBy.TabIndex = 483;
            // 
            // dtpTimeCheckedBy
            // 
            this.dtpTimeCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpTimeCheckedBy.Enabled = false;
            this.dtpTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeCheckedBy.Location = new System.Drawing.Point(385, 66);
            this.dtpTimeCheckedBy.Name = "dtpTimeCheckedBy";
            this.dtpTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeCheckedBy.TabIndex = 482;
            // 
            // txtDateCheckedBy
            // 
            this.txtDateCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateCheckedBy.Enabled = false;
            this.txtDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCheckedBy.Location = new System.Drawing.Point(348, 91);
            this.txtDateCheckedBy.Name = "txtDateCheckedBy";
            this.txtDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.txtDateCheckedBy.TabIndex = 481;
            // 
            // txtDateApprovedBy
            // 
            this.txtDateApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApprovedBy.Enabled = false;
            this.txtDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateApprovedBy.Location = new System.Drawing.Point(348, 118);
            this.txtDateApprovedBy.Name = "txtDateApprovedBy";
            this.txtDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.txtDateApprovedBy.TabIndex = 480;
            // 
            // dtpDateApprovedBy
            // 
            this.dtpDateApprovedBy.Enabled = false;
            this.dtpDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateApprovedBy.Location = new System.Drawing.Point(297, 135);
            this.dtpDateApprovedBy.Name = "dtpDateApprovedBy";
            this.dtpDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateApprovedBy.TabIndex = 475;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Gray;
            this.label29.Location = new System.Drawing.Point(264, 122);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 14);
            this.label29.TabIndex = 479;
            this.label29.Text = "Approved Date";
            // 
            // dtpDateCheckedBy
            // 
            this.dtpDateCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpDateCheckedBy.Enabled = false;
            this.dtpDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateCheckedBy.Location = new System.Drawing.Point(297, 70);
            this.dtpDateCheckedBy.Name = "dtpDateCheckedBy";
            this.dtpDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateCheckedBy.TabIndex = 474;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.Location = new System.Drawing.Point(264, 95);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 14);
            this.label26.TabIndex = 478;
            this.label26.Text = "Checked Date";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedBy.Location = new System.Drawing.Point(44, 118);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(200, 22);
            this.txtApprovedBy.TabIndex = 473;
            // 
            // txtCheckedBy
            // 
            this.txtCheckedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckedBy.Location = new System.Drawing.Point(44, 91);
            this.txtCheckedBy.Name = "txtCheckedBy";
            this.txtCheckedBy.ReadOnly = true;
            this.txtCheckedBy.Size = new System.Drawing.Size(200, 22);
            this.txtCheckedBy.TabIndex = 472;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(41, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 477;
            this.label5.Text = "Checked By";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label28.Location = new System.Drawing.Point(23, 143);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 476;
            this.label28.Text = "Approved By";
            // 
            // btnCustomerViewer
            // 
            this.btnCustomerViewer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerViewer.Image = global::Digiteq.Properties.Resources.info;
            this.btnCustomerViewer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerViewer.Location = new System.Drawing.Point(330, 8);
            this.btnCustomerViewer.Name = "btnCustomerViewer";
            this.btnCustomerViewer.Size = new System.Drawing.Size(22, 22);
            this.btnCustomerViewer.TabIndex = 453;
            this.btnCustomerViewer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomerViewer.UseVisualStyleBackColor = true;
            // 
            // Z2
            // 
            this.Z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.Z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Z2.Controls.Add(this.dtpChequeDate);
            this.Z2.Controls.Add(this.button1);
            this.Z2.Controls.Add(this.btnSave);
            this.Z2.Controls.Add(this.btnNew);
            this.Z2.Controls.Add(this.btnEdit);
            this.Z2.Controls.Add(this.textBox3);
            this.Z2.Controls.Add(this.label3);
            this.Z2.Controls.Add(this.label2);
            this.Z2.Controls.Add(this.textBox1);
            this.Z2.Controls.Add(this.label1);
            this.Z2.Controls.Add(this.txtTotalAmount);
            this.Z2.Controls.Add(this.label17);
            this.Z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z2.Location = new System.Drawing.Point(8, 182);
            this.Z2.Name = "Z2";
            this.Z2.Size = new System.Drawing.Size(468, 98);
            this.Z2.TabIndex = 436;
            // 
            // dtpChequeDate
            // 
            this.dtpChequeDate.Enabled = false;
            this.dtpChequeDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate.Location = new System.Drawing.Point(99, 34);
            this.dtpChequeDate.Name = "dtpChequeDate";
            this.dtpChequeDate.Size = new System.Drawing.Size(114, 22);
            this.dtpChequeDate.TabIndex = 490;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Digiteq.Properties.Resources.Printer;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(381, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 486;
            this.button1.Text = "   Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(304, 63);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 487;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(149, 63);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 488;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Digiteq.Properties.Resources.delete;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(227, 63);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.TabIndex = 489;
            this.btnEdit.Text = "    Delete";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(343, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 23);
            this.textBox3.TabIndex = 484;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(241, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 485;
            this.label3.Text = "Paid Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 483;
            this.label2.Text = "Invoice Date";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(343, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 23);
            this.textBox1.TabIndex = 480;
            this.textBox1.Text = "55000.00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(241, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 481;
            this.label1.Text = "Due Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(99, 7);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(113, 23);
            this.txtTotalAmount.TabIndex = 478;
            this.txtTotalAmount.Text = "INV/A/001";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(7, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 15);
            this.label17.TabIndex = 479;
            this.label17.Text = "Invoice No";
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.dtpTimePreparedBy);
            this.z1.Controls.Add(this.dtpDatePreparedBy);
            this.z1.Controls.Add(this.label4);
            this.z1.Controls.Add(this.txtPreparedBy);
            this.z1.Controls.Add(this.label27);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.Location = new System.Drawing.Point(8, 286);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(468, 43);
            this.z1.TabIndex = 465;
            // 
            // dtpTimePreparedBy
            // 
            this.dtpTimePreparedBy.Enabled = false;
            this.dtpTimePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimePreparedBy.Location = new System.Drawing.Point(394, 9);
            this.dtpTimePreparedBy.Name = "dtpTimePreparedBy";
            this.dtpTimePreparedBy.Size = new System.Drawing.Size(62, 22);
            this.dtpTimePreparedBy.TabIndex = 467;
            // 
            // dtpDatePreparedBy
            // 
            this.dtpDatePreparedBy.Enabled = false;
            this.dtpDatePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePreparedBy.Location = new System.Drawing.Point(306, 9);
            this.dtpDatePreparedBy.Name = "dtpDatePreparedBy";
            this.dtpDatePreparedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDatePreparedBy.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(222, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 439;
            this.label4.Text = "Prepared Date";
            // 
            // txtPreparedBy
            // 
            this.txtPreparedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreparedBy.ForeColor = System.Drawing.Color.Gray;
            this.txtPreparedBy.Location = new System.Drawing.Point(99, 9);
            this.txtPreparedBy.Name = "txtPreparedBy";
            this.txtPreparedBy.ReadOnly = true;
            this.txtPreparedBy.Size = new System.Drawing.Size(113, 22);
            this.txtPreparedBy.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(11, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 14);
            this.label27.TabIndex = 426;
            this.label27.Text = "Prepared By";
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Width = 112;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.Width = 113;
            // 
            // InvoiceAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InvoiceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceAmount.HeaderText = "InvoiceAmount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.Width = 120;
            // 
            // DueAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DueAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.DueAmount.HeaderText = "DueAmount";
            this.DueAmount.Name = "DueAmount";
            this.DueAmount.Width = 120;
            // 
            // frm_sasOpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(484, 338);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.Z2);
            this.Controls.Add(this.x1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_sasOpeningBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_sasOpeningBalance";
            this.Load += new System.EventHandler(this.frm_sasOpeningBalance_Load);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.Z2.ResumeLayout(false);
            this.Z2.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Panel x1;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel Z2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DateTimePicker dtpChequeDate;
        private System.Windows.Forms.Button btnCustomerViewer;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.DateTimePicker dtpTimePreparedBy;
        private System.Windows.Forms.DateTimePicker dtpDatePreparedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPreparedBy;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtTimeCheckedBy;
        private System.Windows.Forms.TextBox txtTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeCheckedBy;
        private System.Windows.Forms.TextBox txtDateCheckedBy;
        private System.Windows.Forms.TextBox txtDateApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpDateApprovedBy;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpDateCheckedBy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.TextBox txtCheckedBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueAmount;
    }
}