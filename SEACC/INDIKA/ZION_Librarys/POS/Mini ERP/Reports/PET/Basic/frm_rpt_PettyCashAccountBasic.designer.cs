namespace Digiteq
{
    partial class frm_rpt_PettyCashAccountBasic
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.z1 = new System.Windows.Forms.Panel();
            this.rdoEnteredDate = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoBillDate = new System.Windows.Forms.RadioButton();
            this.dtpFromEnterd = new System.Windows.Forms.DateTimePicker();
            this.dtpToEnterd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.x1 = new System.Windows.Forms.Panel();
            this.txtSpentBy = new System.Windows.Forms.TextBox();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIncomeType = new System.Windows.Forms.TextBox();
            this.lblVoucherNo = new System.Windows.Forms.Label();
            this.txtExpenditureType = new System.Windows.Forms.TextBox();
            this.chkIncomeType = new System.Windows.Forms.CheckBox();
            this.chkExpenditureType = new System.Windows.Forms.CheckBox();
            this.txtPettyCashAccountID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSpentBy = new System.Windows.Forms.CheckBox();
            this.chkVoucher = new System.Windows.Forms.CheckBox();
            this.chkNarration = new System.Windows.Forms.CheckBox();
            this.chkAmount = new System.Windows.Forms.CheckBox();
            this.txtVoucherNo1 = new System.Windows.Forms.TextBox();
            this.txtSpentBy1 = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtNaration = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.z1.SuspendLayout();
            this.x1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.z1);
            this.groupBox1.Controls.Add(this.x1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(293, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 478;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(371, 259);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 477;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.rdoEnteredDate);
            this.z1.Controls.Add(this.label5);
            this.z1.Controls.Add(this.rdoBillDate);
            this.z1.Controls.Add(this.dtpFromEnterd);
            this.z1.Controls.Add(this.dtpToEnterd);
            this.z1.Controls.Add(this.label7);
            this.z1.Controls.Add(this.label3);
            this.z1.Controls.Add(this.dtpFrom);
            this.z1.Controls.Add(this.dtpTo);
            this.z1.Controls.Add(this.label2);
            this.z1.Location = new System.Drawing.Point(15, 187);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(443, 67);
            this.z1.TabIndex = 470;
            // 
            // rdoEnteredDate
            // 
            this.rdoEnteredDate.AutoSize = true;
            this.rdoEnteredDate.Checked = true;
            this.rdoEnteredDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoEnteredDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoEnteredDate.Location = new System.Drawing.Point(11, 38);
            this.rdoEnteredDate.Name = "rdoEnteredDate";
            this.rdoEnteredDate.Size = new System.Drawing.Size(93, 18);
            this.rdoEnteredDate.TabIndex = 479;
            this.rdoEnteredDate.TabStop = true;
            this.rdoEnteredDate.Text = "Entered Date ";
            this.rdoEnteredDate.UseVisualStyleBackColor = true;
            this.rdoEnteredDate.CheckedChanged += new System.EventHandler(this.rdoEnteredDate_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(111, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "From :";
            // 
            // rdoBillDate
            // 
            this.rdoBillDate.AutoSize = true;
            this.rdoBillDate.Checked = true;
            this.rdoBillDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoBillDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoBillDate.Location = new System.Drawing.Point(11, 10);
            this.rdoBillDate.Name = "rdoBillDate";
            this.rdoBillDate.Size = new System.Drawing.Size(71, 18);
            this.rdoBillDate.TabIndex = 3;
            this.rdoBillDate.TabStop = true;
            this.rdoBillDate.Text = "Bill Date ";
            this.rdoBillDate.UseVisualStyleBackColor = true;
            this.rdoBillDate.CheckedChanged += new System.EventHandler(this.rdoBillDate_CheckedChanged);
            // 
            // dtpFromEnterd
            // 
            this.dtpFromEnterd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromEnterd.Location = new System.Drawing.Point(160, 37);
            this.dtpFromEnterd.Name = "dtpFromEnterd";
            this.dtpFromEnterd.Size = new System.Drawing.Size(99, 20);
            this.dtpFromEnterd.TabIndex = 10;
            // 
            // dtpToEnterd
            // 
            this.dtpToEnterd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToEnterd.Location = new System.Drawing.Point(317, 37);
            this.dtpToEnterd.Name = "dtpToEnterd";
            this.dtpToEnterd.Size = new System.Drawing.Size(99, 20);
            this.dtpToEnterd.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(277, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "To :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(111, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(160, 9);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(99, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(317, 10);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(99, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(277, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "To :";
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.txtSpentBy);
            this.x1.Controls.Add(this.txtVoucherNo);
            this.x1.Controls.Add(this.label9);
            this.x1.Controls.Add(this.label4);
            this.x1.Controls.Add(this.txtIncomeType);
            this.x1.Controls.Add(this.lblVoucherNo);
            this.x1.Controls.Add(this.txtExpenditureType);
            this.x1.Controls.Add(this.chkIncomeType);
            this.x1.Controls.Add(this.chkExpenditureType);
            this.x1.Controls.Add(this.txtPettyCashAccountID);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(16, 17);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(443, 164);
            this.x1.TabIndex = 469;
            // 
            // txtSpentBy
            // 
            this.txtSpentBy.BackColor = System.Drawing.Color.LightGray;
            this.txtSpentBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpentBy.Location = new System.Drawing.Point(130, 70);
            this.txtSpentBy.Name = "txtSpentBy";
            this.txtSpentBy.Size = new System.Drawing.Size(300, 22);
            this.txtSpentBy.TabIndex = 490;
            this.txtSpentBy.DoubleClick += new System.EventHandler(this.txtSpentBy_DoubleClick);
            this.txtSpentBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSpentBy_KeyDown);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.LightGray;
            this.txtVoucherNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherNo.Location = new System.Drawing.Point(130, 40);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(300, 22);
            this.txtVoucherNo.TabIndex = 489;
            this.txtVoucherNo.DoubleClick += new System.EventHandler(this.txtVoucherNo_DoubleClick);
            this.txtVoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherNo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(11, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 14);
            this.label9.TabIndex = 488;
            this.label9.Text = "Spent By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(11, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 14);
            this.label4.TabIndex = 486;
            this.label4.Text = "Petty Cash Account";
            // 
            // txtIncomeType
            // 
            this.txtIncomeType.BackColor = System.Drawing.Color.LightGray;
            this.txtIncomeType.Enabled = false;
            this.txtIncomeType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncomeType.Location = new System.Drawing.Point(130, 129);
            this.txtIncomeType.Name = "txtIncomeType";
            this.txtIncomeType.Size = new System.Drawing.Size(300, 22);
            this.txtIncomeType.TabIndex = 485;
            this.txtIncomeType.DoubleClick += new System.EventHandler(this.txtIncomeType_DoubleClick);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblVoucherNo.Location = new System.Drawing.Point(11, 44);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(66, 14);
            this.lblVoucherNo.TabIndex = 487;
            this.lblVoucherNo.Text = "Voucher No.";
            // 
            // txtExpenditureType
            // 
            this.txtExpenditureType.BackColor = System.Drawing.Color.LightGray;
            this.txtExpenditureType.Enabled = false;
            this.txtExpenditureType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenditureType.Location = new System.Drawing.Point(130, 99);
            this.txtExpenditureType.Name = "txtExpenditureType";
            this.txtExpenditureType.Size = new System.Drawing.Size(300, 22);
            this.txtExpenditureType.TabIndex = 484;
            this.txtExpenditureType.DoubleClick += new System.EventHandler(this.txtExpenditureType_DoubleClick);
            // 
            // chkIncomeType
            // 
            this.chkIncomeType.AutoSize = true;
            this.chkIncomeType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIncomeType.Location = new System.Drawing.Point(11, 131);
            this.chkIncomeType.Name = "chkIncomeType";
            this.chkIncomeType.Size = new System.Drawing.Size(89, 18);
            this.chkIncomeType.TabIndex = 483;
            this.chkIncomeType.Text = "Income Type";
            this.chkIncomeType.UseVisualStyleBackColor = true;
            this.chkIncomeType.CheckedChanged += new System.EventHandler(this.chkIncomeType_CheckedChanged);
            // 
            // chkExpenditureType
            // 
            this.chkExpenditureType.AutoSize = true;
            this.chkExpenditureType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkExpenditureType.Location = new System.Drawing.Point(11, 101);
            this.chkExpenditureType.Name = "chkExpenditureType";
            this.chkExpenditureType.Size = new System.Drawing.Size(112, 18);
            this.chkExpenditureType.TabIndex = 482;
            this.chkExpenditureType.Text = "Expenditure Type";
            this.chkExpenditureType.UseVisualStyleBackColor = true;
            this.chkExpenditureType.CheckedChanged += new System.EventHandler(this.chkExpenditureType_CheckedChanged);
            // 
            // txtPettyCashAccountID
            // 
            this.txtPettyCashAccountID.BackColor = System.Drawing.Color.LightGray;
            this.txtPettyCashAccountID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPettyCashAccountID.Location = new System.Drawing.Point(130, 12);
            this.txtPettyCashAccountID.Name = "txtPettyCashAccountID";
            this.txtPettyCashAccountID.Size = new System.Drawing.Size(300, 22);
            this.txtPettyCashAccountID.TabIndex = 399;
            this.txtPettyCashAccountID.DoubleClick += new System.EventHandler(this.txtPettyCashAccount_ID_DoubleClick);
            this.txtPettyCashAccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPettyCashAccount_ID_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkSpentBy);
            this.panel1.Controls.Add(this.chkVoucher);
            this.panel1.Controls.Add(this.chkNarration);
            this.panel1.Controls.Add(this.chkAmount);
            this.panel1.Controls.Add(this.txtVoucherNo1);
            this.panel1.Controls.Add(this.txtSpentBy1);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.txtNaration);
            this.panel1.Location = new System.Drawing.Point(16, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 79);
            this.panel1.TabIndex = 479;
            // 
            // chkSpentBy
            // 
            this.chkSpentBy.AutoSize = true;
            this.chkSpentBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSpentBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSpentBy.Location = new System.Drawing.Point(213, 51);
            this.chkSpentBy.Name = "chkSpentBy";
            this.chkSpentBy.Size = new System.Drawing.Size(70, 18);
            this.chkSpentBy.TabIndex = 502;
            this.chkSpentBy.Text = "Spent By";
            this.chkSpentBy.UseVisualStyleBackColor = true;
            // 
            // chkVoucher
            // 
            this.chkVoucher.AutoSize = true;
            this.chkVoucher.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkVoucher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkVoucher.Location = new System.Drawing.Point(213, 16);
            this.chkVoucher.Name = "chkVoucher";
            this.chkVoucher.Size = new System.Drawing.Size(85, 18);
            this.chkVoucher.TabIndex = 501;
            this.chkVoucher.Text = "Voucher No.";
            this.chkVoucher.UseVisualStyleBackColor = true;
            // 
            // chkNarration
            // 
            this.chkNarration.AutoSize = true;
            this.chkNarration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkNarration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkNarration.Location = new System.Drawing.Point(4, 51);
            this.chkNarration.Name = "chkNarration";
            this.chkNarration.Size = new System.Drawing.Size(69, 18);
            this.chkNarration.TabIndex = 500;
            this.chkNarration.Text = "Naration";
            this.chkNarration.UseVisualStyleBackColor = true;
            // 
            // chkAmount
            // 
            this.chkAmount.AutoSize = true;
            this.chkAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkAmount.Location = new System.Drawing.Point(4, 16);
            this.chkAmount.Name = "chkAmount";
            this.chkAmount.Size = new System.Drawing.Size(65, 18);
            this.chkAmount.TabIndex = 499;
            this.chkAmount.Text = "Amount";
            this.chkAmount.UseVisualStyleBackColor = true;
            // 
            // txtVoucherNo1
            // 
            this.txtVoucherNo1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherNo1.Location = new System.Drawing.Point(302, 14);
            this.txtVoucherNo1.Name = "txtVoucherNo1";
            this.txtVoucherNo1.Size = new System.Drawing.Size(128, 22);
            this.txtVoucherNo1.TabIndex = 495;
            // 
            // txtSpentBy1
            // 
            this.txtSpentBy1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpentBy1.Location = new System.Drawing.Point(302, 49);
            this.txtSpentBy1.Name = "txtSpentBy1";
            this.txtSpentBy1.Size = new System.Drawing.Size(128, 22);
            this.txtSpentBy1.TabIndex = 496;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(76, 14);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(128, 22);
            this.txtAmount.TabIndex = 491;
            // 
            // txtNaration
            // 
            this.txtNaration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNaration.Location = new System.Drawing.Point(76, 49);
            this.txtNaration.Name = "txtNaration";
            this.txtNaration.Size = new System.Drawing.Size(128, 22);
            this.txtNaration.TabIndex = 492;
            // 
            // frm_rpt_PettyCashAccountBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(488, 303);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_PettyCashAccountBasic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEACC Petty Cash Account Creation";
            this.Load += new System.EventHandler(this.frm_bpsPettyCashAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.TextBox txtPettyCashAccountID;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkIncomeType;
        private System.Windows.Forms.CheckBox chkExpenditureType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIncomeType;
        private System.Windows.Forms.TextBox txtExpenditureType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFromEnterd;
        private System.Windows.Forms.DateTimePicker dtpToEnterd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblVoucherNo;
        private System.Windows.Forms.TextBox txtSpentBy;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.RadioButton rdoEnteredDate;
        private System.Windows.Forms.RadioButton rdoBillDate;
        private System.Windows.Forms.TextBox txtNaration;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVoucherNo1;
        private System.Windows.Forms.TextBox txtSpentBy1;
        private System.Windows.Forms.CheckBox chkAmount;
        private System.Windows.Forms.CheckBox chkSpentBy;
        private System.Windows.Forms.CheckBox chkVoucher;
        private System.Windows.Forms.CheckBox chkNarration;
    }
}