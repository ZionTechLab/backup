namespace Digiteq
{
    partial class frm_bpsAccountCashBookReceipt
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIncomeType = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddIncome = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtRegisterID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.x3 = new System.Windows.Forms.Panel();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCashInHand = new System.Windows.Forms.TextBox();
            this.txtIouTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.x2 = new System.Windows.Forms.Panel();
            this.txtTimeCheckedBy = new System.Windows.Forms.TextBox();
            this.txtTimeApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpTimeApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.dtpTimePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.txtDateCheckedBy = new System.Windows.Forms.TextBox();
            this.txtDateApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpDateApprovedBy = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDateCheckedBy = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.dtpDatePreparedBy = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPreparedBy = new System.Windows.Forms.TextBox();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.txtCheckedBy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.x3.SuspendLayout();
            this.x2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Narration,
            this.Amount,
            this.Credit});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(13, 141);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(807, 276);
            this.dgvDetail.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtInvoiceID);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtIncomeType);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnAddIncome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAccountID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtRegisterID);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 95);
            this.panel1.TabIndex = 5;
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceID.Location = new System.Drawing.Point(80, 63);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(118, 22);
            this.txtInvoiceID.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(51, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(239, 22);
            this.textBox2.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label11.Location = new System.Drawing.Point(4, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 14);
            this.label11.TabIndex = 21;
            this.label11.Text = "Payee";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label10.Location = new System.Drawing.Point(502, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "Cash Book Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(205, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Credit Account";
            // 
            // txtIncomeType
            // 
            this.txtIncomeType.BackColor = System.Drawing.Color.LightGray;
            this.txtIncomeType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncomeType.Location = new System.Drawing.Point(289, 63);
            this.txtIncomeType.Name = "txtIncomeType";
            this.txtIncomeType.ReadOnly = true;
            this.txtIncomeType.Size = new System.Drawing.Size(374, 22);
            this.txtIncomeType.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(599, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(199, 22);
            this.textBox1.TabIndex = 18;
            // 
            // btnAddIncome
            // 
            this.btnAddIncome.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIncome.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddIncome.Location = new System.Drawing.Point(773, 63);
            this.btnAddIncome.Name = "btnAddIncome";
            this.btnAddIncome.Size = new System.Drawing.Size(22, 22);
            this.btnAddIncome.TabIndex = 15;
            this.btnAddIncome.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(4, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Credit Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Narration";
            // 
            // txtAccountID
            // 
            this.txtAccountID.BackColor = System.Drawing.SystemColors.Window;
            this.txtAccountID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountID.Location = new System.Drawing.Point(415, 5);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(77, 22);
            this.txtAccountID.TabIndex = 3;
            // 
            // txtRegisterID
            // 
            this.txtRegisterID.BackColor = System.Drawing.SystemColors.Window;
            this.txtRegisterID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegisterID.Location = new System.Drawing.Point(80, 33);
            this.txtRegisterID.Name = "txtRegisterID";
            this.txtRegisterID.Size = new System.Drawing.Size(513, 22);
            this.txtRegisterID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(296, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Payment Voucher No.";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(514, 110);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 474;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Digiteq.Properties.Resources.delete;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(666, 110);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.TabIndex = 475;
            this.btnEdit.Text = "    Cancel";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(590, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 473;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Image = global::Digiteq.Properties.Resources.Printer;
            this.button21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button21.Location = new System.Drawing.Point(742, 110);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 25);
            this.button21.TabIndex = 476;
            this.button21.Text = "   Print";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // x3
            // 
            this.x3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x3.Controls.Add(this.txtBalance);
            this.x3.Controls.Add(this.label4);
            this.x3.Controls.Add(this.txtCashInHand);
            this.x3.Controls.Add(this.txtIouTotal);
            this.x3.Controls.Add(this.label6);
            this.x3.Controls.Add(this.label7);
            this.x3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x3.Location = new System.Drawing.Point(586, 424);
            this.x3.Name = "x3";
            this.x3.Size = new System.Drawing.Size(234, 97);
            this.x3.TabIndex = 478;
            // 
            // txtBalance
            // 
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(127, 8);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(97, 23);
            this.txtBalance.TabIndex = 1;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Previous Balance";
            // 
            // txtCashInHand
            // 
            this.txtCashInHand.Enabled = false;
            this.txtCashInHand.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashInHand.Location = new System.Drawing.Point(127, 63);
            this.txtCashInHand.Name = "txtCashInHand";
            this.txtCashInHand.ReadOnly = true;
            this.txtCashInHand.Size = new System.Drawing.Size(97, 23);
            this.txtCashInHand.TabIndex = 5;
            this.txtCashInHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIouTotal
            // 
            this.txtIouTotal.Enabled = false;
            this.txtIouTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIouTotal.Location = new System.Drawing.Point(127, 36);
            this.txtIouTotal.Name = "txtIouTotal";
            this.txtIouTotal.ReadOnly = true;
            this.txtIouTotal.Size = new System.Drawing.Size(97, 23);
            this.txtIouTotal.TabIndex = 3;
            this.txtIouTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(13, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "Debit Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(13, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Net Cash ";
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2.Controls.Add(this.txtTimeCheckedBy);
            this.x2.Controls.Add(this.txtTimeApprovedBy);
            this.x2.Controls.Add(this.dtpTimeApprovedBy);
            this.x2.Controls.Add(this.dtpTimeCheckedBy);
            this.x2.Controls.Add(this.dtpTimePreparedBy);
            this.x2.Controls.Add(this.txtDateCheckedBy);
            this.x2.Controls.Add(this.txtDateApprovedBy);
            this.x2.Controls.Add(this.dtpDateApprovedBy);
            this.x2.Controls.Add(this.label29);
            this.x2.Controls.Add(this.dtpDateCheckedBy);
            this.x2.Controls.Add(this.label26);
            this.x2.Controls.Add(this.dtpDatePreparedBy);
            this.x2.Controls.Add(this.label8);
            this.x2.Controls.Add(this.txtPreparedBy);
            this.x2.Controls.Add(this.txtApprovedBy);
            this.x2.Controls.Add(this.txtCheckedBy);
            this.x2.Controls.Add(this.label9);
            this.x2.Controls.Add(this.label27);
            this.x2.Controls.Add(this.label28);
            this.x2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x2.Location = new System.Drawing.Point(13, 424);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(567, 97);
            this.x2.TabIndex = 477;
            // 
            // txtTimeCheckedBy
            // 
            this.txtTimeCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeCheckedBy.Enabled = false;
            this.txtTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeCheckedBy.Location = new System.Drawing.Point(502, 37);
            this.txtTimeCheckedBy.Name = "txtTimeCheckedBy";
            this.txtTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.txtTimeCheckedBy.TabIndex = 9;
            // 
            // txtTimeApprovedBy
            // 
            this.txtTimeApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeApprovedBy.Enabled = false;
            this.txtTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeApprovedBy.Location = new System.Drawing.Point(502, 64);
            this.txtTimeApprovedBy.Name = "txtTimeApprovedBy";
            this.txtTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.txtTimeApprovedBy.TabIndex = 14;
            // 
            // dtpTimeApprovedBy
            // 
            this.dtpTimeApprovedBy.Enabled = false;
            this.dtpTimeApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeApprovedBy.Location = new System.Drawing.Point(502, 64);
            this.dtpTimeApprovedBy.Name = "dtpTimeApprovedBy";
            this.dtpTimeApprovedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeApprovedBy.TabIndex = 469;
            // 
            // dtpTimeCheckedBy
            // 
            this.dtpTimeCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpTimeCheckedBy.Enabled = false;
            this.dtpTimeCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeCheckedBy.Location = new System.Drawing.Point(502, 37);
            this.dtpTimeCheckedBy.Name = "dtpTimeCheckedBy";
            this.dtpTimeCheckedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimeCheckedBy.TabIndex = 468;
            // 
            // dtpTimePreparedBy
            // 
            this.dtpTimePreparedBy.Enabled = false;
            this.dtpTimePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimePreparedBy.Location = new System.Drawing.Point(502, 9);
            this.dtpTimePreparedBy.Name = "dtpTimePreparedBy";
            this.dtpTimePreparedBy.Size = new System.Drawing.Size(48, 22);
            this.dtpTimePreparedBy.TabIndex = 4;
            // 
            // txtDateCheckedBy
            // 
            this.txtDateCheckedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateCheckedBy.Enabled = false;
            this.txtDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCheckedBy.Location = new System.Drawing.Point(414, 37);
            this.txtDateCheckedBy.Name = "txtDateCheckedBy";
            this.txtDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.txtDateCheckedBy.TabIndex = 8;
            // 
            // txtDateApprovedBy
            // 
            this.txtDateApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApprovedBy.Enabled = false;
            this.txtDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateApprovedBy.Location = new System.Drawing.Point(414, 64);
            this.txtDateApprovedBy.Name = "txtDateApprovedBy";
            this.txtDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.txtDateApprovedBy.TabIndex = 13;
            // 
            // dtpDateApprovedBy
            // 
            this.dtpDateApprovedBy.Enabled = false;
            this.dtpDateApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateApprovedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateApprovedBy.Location = new System.Drawing.Point(414, 64);
            this.dtpDateApprovedBy.Name = "dtpDateApprovedBy";
            this.dtpDateApprovedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateApprovedBy.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Gray;
            this.label29.Location = new System.Drawing.Point(330, 68);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 14);
            this.label29.TabIndex = 12;
            this.label29.Text = "Approved Date";
            // 
            // dtpDateCheckedBy
            // 
            this.dtpDateCheckedBy.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateCheckedBy.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpDateCheckedBy.Enabled = false;
            this.dtpDateCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateCheckedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateCheckedBy.Location = new System.Drawing.Point(414, 37);
            this.dtpDateCheckedBy.Name = "dtpDateCheckedBy";
            this.dtpDateCheckedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDateCheckedBy.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Gray;
            this.label26.Location = new System.Drawing.Point(330, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 14);
            this.label26.TabIndex = 7;
            this.label26.Text = "Checked Date";
            // 
            // dtpDatePreparedBy
            // 
            this.dtpDatePreparedBy.Enabled = false;
            this.dtpDatePreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePreparedBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePreparedBy.Location = new System.Drawing.Point(414, 9);
            this.dtpDatePreparedBy.Name = "dtpDatePreparedBy";
            this.dtpDatePreparedBy.Size = new System.Drawing.Size(82, 22);
            this.dtpDatePreparedBy.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(330, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "Prepared Date";
            // 
            // txtPreparedBy
            // 
            this.txtPreparedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreparedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreparedBy.ForeColor = System.Drawing.Color.Gray;
            this.txtPreparedBy.Location = new System.Drawing.Point(107, 9);
            this.txtPreparedBy.Name = "txtPreparedBy";
            this.txtPreparedBy.ReadOnly = true;
            this.txtPreparedBy.Size = new System.Drawing.Size(200, 22);
            this.txtPreparedBy.TabIndex = 1;
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtApprovedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedBy.Location = new System.Drawing.Point(107, 64);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(200, 22);
            this.txtApprovedBy.TabIndex = 11;
            // 
            // txtCheckedBy
            // 
            this.txtCheckedBy.BackColor = System.Drawing.Color.LightGray;
            this.txtCheckedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckedBy.Location = new System.Drawing.Point(107, 37);
            this.txtCheckedBy.Name = "txtCheckedBy";
            this.txtCheckedBy.ReadOnly = true;
            this.txtCheckedBy.Size = new System.Drawing.Size(200, 22);
            this.txtCheckedBy.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label9.Location = new System.Drawing.Point(11, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 14);
            this.label9.TabIndex = 5;
            this.label9.Text = "Checked By";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Gray;
            this.label27.Location = new System.Drawing.Point(11, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 14);
            this.label27.TabIndex = 0;
            this.label27.Text = "Prepared By";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label28.Location = new System.Drawing.Point(11, 68);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 14);
            this.label28.TabIndex = 10;
            this.label28.Text = "Approved By";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label12.Location = new System.Drawing.Point(599, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 14);
            this.label12.TabIndex = 23;
            this.label12.Text = "CB Float";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LightGray;
            this.textBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(661, 33);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(136, 22);
            this.textBox3.TabIndex = 24;
            // 
            // No
            // 
            this.No.HeaderText = "#";
            this.No.Name = "No";
            this.No.Width = 40;
            // 
            // Narration
            // 
            this.Narration.HeaderText = "Narration";
            this.Narration.Name = "Narration";
            this.Narration.Width = 400;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 150;
            // 
            // Credit
            // 
            this.Credit.HeaderText = "Credit Account Head";
            this.Credit.Name = "Credit";
            this.Credit.Width = 210;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(671, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // frm_bpsAccountCashBookReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(834, 533);
            this.Controls.Add(this.x3);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetail);
            this.Name = "frm_bpsAccountCashBookReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CASH BOOK - Payment";
            this.Load += new System.EventHandler(this.frm_bpsAccountCashBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.x3.ResumeLayout(false);
            this.x3.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.TextBox txtRegisterID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddIncome;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Panel x3;
        private System.Windows.Forms.TextBox txtCashInHand;
        private System.Windows.Forms.TextBox txtIouTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.TextBox txtTimeCheckedBy;
        private System.Windows.Forms.TextBox txtTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpTimeCheckedBy;
        private System.Windows.Forms.DateTimePicker dtpTimePreparedBy;
        private System.Windows.Forms.TextBox txtDateCheckedBy;
        private System.Windows.Forms.TextBox txtDateApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpDateApprovedBy;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpDateCheckedBy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DateTimePicker dtpDatePreparedBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPreparedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.TextBox txtCheckedBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIncomeType;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
    }
}