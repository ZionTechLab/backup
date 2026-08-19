namespace Digiteq
{
    partial class frmMultipleCheque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtExRate = new System.Windows.Forms.TextBox();
            this.txtChqregisterNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.dtpChequeDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChequeType = new System.Windows.Forms.TextBox();
            this.lblChequeType = new System.Windows.Forms.Label();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGridDelete = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvDetail);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(495, 42);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 6);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(113, 33);
            this.dgvDetail.TabIndex = 513;
            this.dgvDetail.Visible = false;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "CHEQUES";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtExRate);
            this.groupBox2.Controls.Add(this.txtChqregisterNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRemark);
            this.groupBox2.Controls.Add(this.lblRemarks);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.dtpChequeDate);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtBankName);
            this.groupBox2.Controls.Add(this.txtAccountNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtChequeType);
            this.groupBox2.Controls.Add(this.lblChequeType);
            this.groupBox2.Controls.Add(this.txtBranchName);
            this.groupBox2.Controls.Add(this.lblBranch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtChequeNo);
            this.groupBox2.Controls.Add(this.lblCategoryID);
            this.groupBox2.Controls.Add(this.lblBank);
            this.groupBox2.Location = new System.Drawing.Point(8, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 219);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtExRate
            // 
            this.txtExRate.Location = new System.Drawing.Point(149, 186);
            this.txtExRate.Name = "txtExRate";
            this.txtExRate.Size = new System.Drawing.Size(100, 20);
            this.txtExRate.TabIndex = 526;
            this.txtExRate.Visible = false;
            // 
            // txtChqregisterNo
            // 
            this.txtChqregisterNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtChqregisterNo.BackColor = System.Drawing.Color.White;
            this.txtChqregisterNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChqregisterNo.Location = new System.Drawing.Point(366, 109);
            this.txtChqregisterNo.Name = "txtChqregisterNo";
            this.txtChqregisterNo.Size = new System.Drawing.Size(115, 22);
            this.txtChqregisterNo.TabIndex = 13;
            this.txtChqregisterNo.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(288, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 14);
            this.label7.TabIndex = 525;
            this.label7.Text = "Chq. Register No.";
            this.label7.Visible = false;
            // 
            // txtRemark
            // 
            this.txtRemark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(77, 136);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(404, 44);
            this.txtRemark.TabIndex = 12;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRemarks.Location = new System.Drawing.Point(5, 139);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(51, 14);
            this.lblRemarks.TabIndex = 22;
            this.lblRemarks.Text = "Remarks";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = global::Digiteq.Properties.Resources.accept;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(398, 187);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "  OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dtpChequeDate
            // 
            this.dtpChequeDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate.Location = new System.Drawing.Point(367, 15);
            this.dtpChequeDate.Name = "dtpChequeDate";
            this.dtpChequeDate.Size = new System.Drawing.Size(115, 22);
            this.dtpChequeDate.TabIndex = 2;
            // 
            // txtAmount
            // 
            this.txtAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(367, 78);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(115, 22);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(317, 187);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 15;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "  Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(288, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Amount";
            // 
            // txtBankName
            // 
            this.txtBankName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtBankName.BackColor = System.Drawing.Color.LightGray;
            this.txtBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankName.Location = new System.Drawing.Point(77, 47);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.ReadOnly = true;
            this.txtBankName.Size = new System.Drawing.Size(184, 22);
            this.txtBankName.TabIndex = 0;
            this.txtBankName.DoubleClick += new System.EventHandler(this.txtBankName_DoubleClick);
            this.txtBankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankName_KeyDown);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtAccountNo.BackColor = System.Drawing.Color.White;
            this.txtAccountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo.Location = new System.Drawing.Point(77, 15);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(184, 22);
            this.txtAccountNo.TabIndex = 1;
            this.txtAccountNo.DoubleClick += new System.EventHandler(this.txtAccountNo_DoubleClick);
            this.txtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountNo_KeyDown);
            this.txtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(5, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Account No";
            // 
            // txtChequeType
            // 
            this.txtChequeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtChequeType.BackColor = System.Drawing.Color.LightGray;
            this.txtChequeType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeType.Location = new System.Drawing.Point(77, 108);
            this.txtChequeType.Name = "txtChequeType";
            this.txtChequeType.ReadOnly = true;
            this.txtChequeType.Size = new System.Drawing.Size(184, 22);
            this.txtChequeType.TabIndex = 11;
            this.txtChequeType.DoubleClick += new System.EventHandler(this.txtChequeType_DoubleClick);
            this.txtChequeType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeType_KeyDown);
            // 
            // lblChequeType
            // 
            this.lblChequeType.AutoSize = true;
            this.lblChequeType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblChequeType.Location = new System.Drawing.Point(5, 111);
            this.lblChequeType.Name = "lblChequeType";
            this.lblChequeType.Size = new System.Drawing.Size(70, 14);
            this.lblChequeType.TabIndex = 18;
            this.lblChequeType.Text = "Cheque Type";
            // 
            // txtBranchName
            // 
            this.txtBranchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtBranchName.BackColor = System.Drawing.Color.LightGray;
            this.txtBranchName.Enabled = false;
            this.txtBranchName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchName.Location = new System.Drawing.Point(77, 78);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.ReadOnly = true;
            this.txtBranchName.Size = new System.Drawing.Size(184, 22);
            this.txtBranchName.TabIndex = 20;
            this.txtBranchName.DoubleClick += new System.EventHandler(this.txtBranchName_DoubleClick);
            this.txtBranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchName_KeyDown);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBranch.Location = new System.Drawing.Point(5, 82);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 14);
            this.lblBranch.TabIndex = 19;
            this.lblBranch.Text = "Branch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(288, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cheque No";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtChequeNo.BackColor = System.Drawing.Color.White;
            this.txtChequeNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(367, 47);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(115, 22);
            this.txtChequeNo.TabIndex = 3;
            this.txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeNo_KeyPress);
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.AutoSize = true;
            this.lblCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCategoryID.Location = new System.Drawing.Point(288, 19);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(70, 14);
            this.lblCategoryID.TabIndex = 10;
            this.lblCategoryID.Text = "Cheque Date";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBank.Location = new System.Drawing.Point(5, 51);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(32, 14);
            this.lblBank.TabIndex = 0;
            this.lblBank.Text = "Bank";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(133, 112);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(62, 23);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.TabStop = false;
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(58, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(33, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(31, 26);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnGridDelete
            // 
            this.btnGridDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGridDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnGridDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGridDelete.Location = new System.Drawing.Point(279, 112);
            this.btnGridDelete.Name = "btnGridDelete";
            this.btnGridDelete.Size = new System.Drawing.Size(75, 25);
            this.btnGridDelete.TabIndex = 525;
            this.btnGridDelete.TabStop = false;
            this.btnGridDelete.Text = "Grid Del";
            this.btnGridDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGridDelete.UseVisualStyleBackColor = true;
            this.btnGridDelete.Click += new System.EventHandler(this.btnGridDelete_Click);
            // 
            // frmMultipleCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(511, 276);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGridDelete);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmMultipleCheque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMultipleCheque_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGridDelete;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dtpChequeDate;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChequeType;
        private System.Windows.Forms.Label lblChequeType;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtChqregisterNo;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.TextBox txtExRate;
    }
}