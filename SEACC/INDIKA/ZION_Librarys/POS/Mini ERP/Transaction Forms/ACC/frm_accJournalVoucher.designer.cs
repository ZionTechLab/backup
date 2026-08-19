namespace Digiteq
{
    partial class frm_accJournalVoucher
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
            this.x1 = new System.Windows.Forms.Panel();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.txtTxnType = new System.Windows.Forms.TextBox();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.txtRevenueCode2 = new System.Windows.Forms.TextBox();
            this.lblRevenueCode1 = new System.Windows.Forms.Label();
            this.txtRevenueCode1 = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtJournalID = new System.Windows.Forms.TextBox();
            this.lblJournalDate = new System.Windows.Forms.Label();
            this.dtpJVDate = new System.Windows.Forms.DateTimePicker();
            this.lblJournalID = new System.Windows.Forms.Label();
            this.lblRevenueCode2 = new System.Windows.Forms.Label();
            this.xpanel4 = new System.Windows.Forms.Panel();
            this.pbxCreditEntry = new System.Windows.Forms.PictureBox();
            this.pbxDebitEntry = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDebitAmount = new System.Windows.Forms.TextBox();
            this.txtCerditAmount = new System.Windows.Forms.TextBox();
            this.lblAcctCode = new System.Windows.Forms.Label();
            this.txtAcctCodeName = new System.Windows.Forms.TextBox();
            this.txtAcctCode = new System.Windows.Forms.TextBox();
            this.lblAcctCodeName = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subAcc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subAcc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zRemark = new System.Windows.Forms.Panel();
            this.lblIsCredit = new System.Windows.Forms.Label();
            this.txtDifferance = new System.Windows.Forms.TextBox();
            this.txtTotDebit = new System.Windows.Forms.TextBox();
            this.txtTotCredit = new System.Windows.Forms.TextBox();
            this.lblDifferance = new System.Windows.Forms.Label();
            this.x1.SuspendLayout();
            this.xpanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCreditEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDebitEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.zRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.lblTransactionType);
            this.x1.Controls.Add(this.txtTxnType);
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Controls.Add(this.txtRemarks);
            this.x1.Controls.Add(this.label1);
            this.x1.Controls.Add(this.txtNarration);
            this.x1.Controls.Add(this.txtRevenueCode2);
            this.x1.Controls.Add(this.lblRevenueCode1);
            this.x1.Controls.Add(this.txtRevenueCode1);
            this.x1.Controls.Add(this.lblNarration);
            this.x1.Controls.Add(this.txtJournalID);
            this.x1.Controls.Add(this.lblJournalDate);
            this.x1.Controls.Add(this.dtpJVDate);
            this.x1.Controls.Add(this.lblJournalID);
            this.x1.Controls.Add(this.lblRevenueCode2);
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(721, 112);
            this.x1.TabIndex = 511;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTransactionType.Location = new System.Drawing.Point(11, 31);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(52, 14);
            this.lblTransactionType.TabIndex = 555;
            this.lblTransactionType.Text = "Txn Type";
            // 
            // txtTxnType
            // 
            this.txtTxnType.BackColor = System.Drawing.Color.LightGray;
            this.txtTxnType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTxnType.Location = new System.Drawing.Point(79, 28);
            this.txtTxnType.Name = "txtTxnType";
            this.txtTxnType.ReadOnly = true;
            this.txtTxnType.Size = new System.Drawing.Size(110, 22);
            this.txtTxnType.TabIndex = 554;
            this.txtTxnType.TextChanged += new System.EventHandler(this.txtTxnType_TextChanged);
            this.txtTxnType.DoubleClick += new System.EventHandler(this.txtTxnType_DoubleClick);
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(192, 7);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 545;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(198, 6);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 544;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(288, 4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(76, 47);
            this.txtRemarks.TabIndex = 485;
            this.txtRemarks.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(11, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 484;
            this.label1.Text = "Remarks";
            this.label1.Visible = false;
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(79, 56);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(625, 50);
            this.txtNarration.TabIndex = 483;
            // 
            // txtRevenueCode2
            // 
            this.txtRevenueCode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRevenueCode2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevenueCode2.Location = new System.Drawing.Point(706, 43);
            this.txtRevenueCode2.Name = "txtRevenueCode2";
            this.txtRevenueCode2.Size = new System.Drawing.Size(97, 22);
            this.txtRevenueCode2.TabIndex = 0;
            this.txtRevenueCode2.Text = "default";
            this.txtRevenueCode2.Visible = false;
            // 
            // lblRevenueCode1
            // 
            this.lblRevenueCode1.AutoSize = true;
            this.lblRevenueCode1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueCode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRevenueCode1.Location = new System.Drawing.Point(618, 10);
            this.lblRevenueCode1.Name = "lblRevenueCode1";
            this.lblRevenueCode1.Size = new System.Drawing.Size(86, 14);
            this.lblRevenueCode1.TabIndex = 281;
            this.lblRevenueCode1.Text = "Revenue Code 1";
            this.lblRevenueCode1.Visible = false;
            // 
            // txtRevenueCode1
            // 
            this.txtRevenueCode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRevenueCode1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevenueCode1.Location = new System.Drawing.Point(706, 7);
            this.txtRevenueCode1.Name = "txtRevenueCode1";
            this.txtRevenueCode1.Size = new System.Drawing.Size(97, 22);
            this.txtRevenueCode1.TabIndex = 0;
            this.txtRevenueCode1.Text = "default";
            this.txtRevenueCode1.Visible = false;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNarration.Location = new System.Drawing.Point(11, 59);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(54, 14);
            this.lblNarration.TabIndex = 443;
            this.lblNarration.Text = "Narration";
            // 
            // txtJournalID
            // 
            this.txtJournalID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtJournalID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJournalID.Location = new System.Drawing.Point(79, 4);
            this.txtJournalID.Name = "txtJournalID";
            this.txtJournalID.Size = new System.Drawing.Size(110, 22);
            this.txtJournalID.TabIndex = 482;
            this.txtJournalID.DoubleClick += new System.EventHandler(this.txtJournalID_DoubleClick);
            this.txtJournalID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJournalID_KeyDown);
            // 
            // lblJournalDate
            // 
            this.lblJournalDate.AutoSize = true;
            this.lblJournalDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJournalDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblJournalDate.Location = new System.Drawing.Point(369, 7);
            this.lblJournalDate.Name = "lblJournalDate";
            this.lblJournalDate.Size = new System.Drawing.Size(31, 14);
            this.lblJournalDate.TabIndex = 479;
            this.lblJournalDate.Text = "Date";
            // 
            // dtpJVDate
            // 
            this.dtpJVDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpJVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJVDate.Location = new System.Drawing.Point(422, 4);
            this.dtpJVDate.Name = "dtpJVDate";
            this.dtpJVDate.Size = new System.Drawing.Size(98, 22);
            this.dtpJVDate.TabIndex = 6;
            // 
            // lblJournalID
            // 
            this.lblJournalID.AutoSize = true;
            this.lblJournalID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJournalID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblJournalID.Location = new System.Drawing.Point(11, 7);
            this.lblJournalID.Name = "lblJournalID";
            this.lblJournalID.Size = new System.Drawing.Size(27, 14);
            this.lblJournalID.TabIndex = 465;
            this.lblJournalID.Text = " No.";
            // 
            // lblRevenueCode2
            // 
            this.lblRevenueCode2.AutoSize = true;
            this.lblRevenueCode2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueCode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRevenueCode2.Location = new System.Drawing.Point(618, 43);
            this.lblRevenueCode2.Name = "lblRevenueCode2";
            this.lblRevenueCode2.Size = new System.Drawing.Size(86, 14);
            this.lblRevenueCode2.TabIndex = 281;
            this.lblRevenueCode2.Text = "Revenue Code 2";
            this.lblRevenueCode2.Visible = false;
            // 
            // xpanel4
            // 
            this.xpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.xpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel4.Controls.Add(this.pbxCreditEntry);
            this.xpanel4.Controls.Add(this.pbxDebitEntry);
            this.xpanel4.Controls.Add(this.label3);
            this.xpanel4.Controls.Add(this.label2);
            this.xpanel4.Controls.Add(this.txtDebitAmount);
            this.xpanel4.Controls.Add(this.txtCerditAmount);
            this.xpanel4.Location = new System.Drawing.Point(8, 125);
            this.xpanel4.Name = "xpanel4";
            this.xpanel4.Size = new System.Drawing.Size(721, 37);
            this.xpanel4.TabIndex = 525;
            // 
            // pbxCreditEntry
            // 
            this.pbxCreditEntry.Image = global::Digiteq.Properties.Resources.accept;
            this.pbxCreditEntry.Location = new System.Drawing.Point(689, 8);
            this.pbxCreditEntry.Name = "pbxCreditEntry";
            this.pbxCreditEntry.Size = new System.Drawing.Size(20, 20);
            this.pbxCreditEntry.TabIndex = 572;
            this.pbxCreditEntry.TabStop = false;
            this.pbxCreditEntry.Click += new System.EventHandler(this.pbxCreditEntry_Click);
            this.pbxCreditEntry.MouseLeave += new System.EventHandler(this.Text_MouseLeave);
            this.pbxCreditEntry.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Text_MouseMove);
            // 
            // pbxDebitEntry
            // 
            this.pbxDebitEntry.Image = global::Digiteq.Properties.Resources.accept;
            this.pbxDebitEntry.Location = new System.Drawing.Point(223, 8);
            this.pbxDebitEntry.Name = "pbxDebitEntry";
            this.pbxDebitEntry.Size = new System.Drawing.Size(20, 20);
            this.pbxDebitEntry.TabIndex = 571;
            this.pbxDebitEntry.TabStop = false;
            this.pbxDebitEntry.Click += new System.EventHandler(this.pbxDebitEntry_Click);
            this.pbxDebitEntry.MouseLeave += new System.EventHandler(this.Text_MouseLeave);
            this.pbxDebitEntry.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Text_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 495;
            this.label3.Text = "Debit Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(476, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 494;
            this.label2.Text = "Credit Amount";
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitAmount.Location = new System.Drawing.Point(114, 7);
            this.txtDebitAmount.Multiline = true;
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.Size = new System.Drawing.Size(100, 22);
            this.txtDebitAmount.TabIndex = 493;
            this.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDebitAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebitAmount_KeyPress);
            // 
            // txtCerditAmount
            // 
            this.txtCerditAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCerditAmount.Location = new System.Drawing.Point(579, 7);
            this.txtCerditAmount.Multiline = true;
            this.txtCerditAmount.Name = "txtCerditAmount";
            this.txtCerditAmount.Size = new System.Drawing.Size(100, 22);
            this.txtCerditAmount.TabIndex = 492;
            this.txtCerditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCerditAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCerditAmount_KeyPress);
            // 
            // lblAcctCode
            // 
            this.lblAcctCode.AutoSize = true;
            this.lblAcctCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblAcctCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAcctCode.Location = new System.Drawing.Point(23, 128);
            this.lblAcctCode.Name = "lblAcctCode";
            this.lblAcctCode.Size = new System.Drawing.Size(58, 14);
            this.lblAcctCode.TabIndex = 488;
            this.lblAcctCode.Text = "Acct. Code";
            // 
            // txtAcctCodeName
            // 
            this.txtAcctCodeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCodeName.Location = new System.Drawing.Point(323, 130);
            this.txtAcctCodeName.Name = "txtAcctCodeName";
            this.txtAcctCodeName.Size = new System.Drawing.Size(249, 22);
            this.txtAcctCodeName.TabIndex = 491;
            // 
            // txtAcctCode
            // 
            this.txtAcctCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAcctCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctCode.Location = new System.Drawing.Point(105, 131);
            this.txtAcctCode.Name = "txtAcctCode";
            this.txtAcctCode.Size = new System.Drawing.Size(99, 22);
            this.txtAcctCode.TabIndex = 489;
            this.txtAcctCode.DoubleClick += new System.EventHandler(this.txtAcctCode_DoubleClick);
            this.txtAcctCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcctCode_KeyDown);
            // 
            // lblAcctCodeName
            // 
            this.lblAcctCodeName.AutoSize = true;
            this.lblAcctCodeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblAcctCodeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAcctCodeName.Location = new System.Drawing.Point(224, 129);
            this.lblAcctCodeName.Name = "lblAcctCodeName";
            this.lblAcctCodeName.Size = new System.Drawing.Size(64, 14);
            this.lblAcctCodeName.TabIndex = 490;
            this.lblAcctCodeName.Text = "Acct. Name";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.IsCredit,
            this.accCode,
            this.CategoryID,
            this.accName,
            this.debitAmount,
            this.creditAmount,
            this.subAcc1,
            this.subAcc2,
            this.employee,
            this.otherCr,
            this.Remarks});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 169);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(721, 202);
            this.dgvDetail.TabIndex = 526;
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "No";
            this.LineNo.Name = "LineNo";
            this.LineNo.Width = 40;
            // 
            // IsCredit
            // 
            this.IsCredit.HeaderText = "IsCredit";
            this.IsCredit.Name = "IsCredit";
            this.IsCredit.Visible = false;
            // 
            // accCode
            // 
            this.accCode.HeaderText = "Account Code";
            this.accCode.Name = "accCode";
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "CategoryID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Visible = false;
            // 
            // accName
            // 
            this.accName.HeaderText = "Account Name";
            this.accName.Name = "accName";
            this.accName.Width = 235;
            // 
            // debitAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.debitAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.debitAmount.HeaderText = "Debit Amount";
            this.debitAmount.Name = "debitAmount";
            // 
            // creditAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.creditAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.creditAmount.HeaderText = "Credit Amount";
            this.creditAmount.Name = "creditAmount";
            // 
            // subAcc1
            // 
            this.subAcc1.HeaderText = "Sub Acct1";
            this.subAcc1.Name = "subAcc1";
            // 
            // subAcc2
            // 
            this.subAcc2.HeaderText = "Sub Acct2";
            this.subAcc2.Name = "subAcc2";
            // 
            // employee
            // 
            this.employee.HeaderText = "Employee";
            this.employee.Name = "employee";
            // 
            // otherCr
            // 
            this.otherCr.HeaderText = "OtherCr.";
            this.otherCr.Name = "otherCr";
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 300;
            // 
            // zRemark
            // 
            this.zRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.zRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zRemark.Controls.Add(this.lblIsCredit);
            this.zRemark.Controls.Add(this.txtDifferance);
            this.zRemark.Controls.Add(this.txtTotDebit);
            this.zRemark.Controls.Add(this.txtTotCredit);
            this.zRemark.Controls.Add(this.lblDifferance);
            this.zRemark.Location = new System.Drawing.Point(8, 375);
            this.zRemark.Name = "zRemark";
            this.zRemark.Size = new System.Drawing.Size(721, 31);
            this.zRemark.TabIndex = 528;
            // 
            // lblIsCredit
            // 
            this.lblIsCredit.AutoSize = true;
            this.lblIsCredit.Enabled = false;
            this.lblIsCredit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblIsCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblIsCredit.Location = new System.Drawing.Point(234, 6);
            this.lblIsCredit.Name = "lblIsCredit";
            this.lblIsCredit.Size = new System.Drawing.Size(104, 14);
            this.lblIsCredit.TabIndex = 489;
            this.lblIsCredit.Text = "Aaaaaaaaaaaaaaaa";
            this.lblIsCredit.Visible = false;
            // 
            // txtDifferance
            // 
            this.txtDifferance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDifferance.Location = new System.Drawing.Point(110, 3);
            this.txtDifferance.Multiline = true;
            this.txtDifferance.Name = "txtDifferance";
            this.txtDifferance.ReadOnly = true;
            this.txtDifferance.Size = new System.Drawing.Size(92, 22);
            this.txtDifferance.TabIndex = 11;
            // 
            // txtTotDebit
            // 
            this.txtTotDebit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotDebit.Location = new System.Drawing.Point(613, 3);
            this.txtTotDebit.Multiline = true;
            this.txtTotDebit.Name = "txtTotDebit";
            this.txtTotDebit.ReadOnly = true;
            this.txtTotDebit.Size = new System.Drawing.Size(92, 22);
            this.txtTotDebit.TabIndex = 10;
            // 
            // txtTotCredit
            // 
            this.txtTotCredit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotCredit.Location = new System.Drawing.Point(515, 3);
            this.txtTotCredit.Multiline = true;
            this.txtTotCredit.Name = "txtTotCredit";
            this.txtTotCredit.ReadOnly = true;
            this.txtTotCredit.Size = new System.Drawing.Size(92, 22);
            this.txtTotCredit.TabIndex = 9;
            // 
            // lblDifferance
            // 
            this.lblDifferance.AutoSize = true;
            this.lblDifferance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifferance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDifferance.Location = new System.Drawing.Point(7, 6);
            this.lblDifferance.Name = "lblDifferance";
            this.lblDifferance.Size = new System.Drawing.Size(100, 14);
            this.lblDifferance.TabIndex = 8;
            this.lblDifferance.Text = "Difference Amount";
            // 
            // frm_accJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.zRemark);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.xpanel4);
            this.Controls.Add(this.txtAcctCodeName);
            this.Controls.Add(this.txtAcctCode);
            this.Controls.Add(this.lblAcctCodeName);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.lblAcctCode);
            this.Name = "frm_accJournalVoucher";
            this.Size = new System.Drawing.Size(737, 459);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_accJournalVoucher_SF_History_Click);
            this.Load += new System.EventHandler(this.frm_accJournalVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_accJournalVoucher_KeyDown);
            this.Controls.SetChildIndex(this.lblAcctCode, 0);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.lblAcctCodeName, 0);
            this.Controls.SetChildIndex(this.txtAcctCode, 0);
            this.Controls.SetChildIndex(this.txtAcctCodeName, 0);
            this.Controls.SetChildIndex(this.xpanel4, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.zRemark, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.xpanel4.ResumeLayout(false);
            this.xpanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCreditEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDebitEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.zRemark.ResumeLayout(false);
            this.zRemark.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.TextBox txtRevenueCode2;
        private System.Windows.Forms.Label lblRevenueCode1;
        private System.Windows.Forms.TextBox txtRevenueCode1;
        private System.Windows.Forms.TextBox txtJournalID;
        private System.Windows.Forms.Label lblJournalDate;
        private System.Windows.Forms.DateTimePicker dtpJVDate;
        private System.Windows.Forms.Label lblJournalID;
        private System.Windows.Forms.Label lblRevenueCode2;
        private System.Windows.Forms.Panel xpanel4;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label lblAcctCode;
        private System.Windows.Forms.TextBox txtAcctCodeName;
        private System.Windows.Forms.TextBox txtAcctCode;
        private System.Windows.Forms.Label lblAcctCodeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel zRemark;
        private System.Windows.Forms.TextBox txtDifferance;
        private System.Windows.Forms.TextBox txtTotDebit;
        private System.Windows.Forms.TextBox txtTotCredit;
        private System.Windows.Forms.Label lblDifferance;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDebitAmount;
        private System.Windows.Forms.TextBox txtCerditAmount;
        private System.Windows.Forms.Label lblIsCredit;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.PictureBox pbxCreditEntry;
        private System.Windows.Forms.PictureBox pbxDebitEntry;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.TextBox txtTxnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn accCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn accName;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subAcc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn subAcc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label lblNarration;
    }
}