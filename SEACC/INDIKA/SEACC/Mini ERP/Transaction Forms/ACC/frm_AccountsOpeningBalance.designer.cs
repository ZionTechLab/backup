namespace Digiteq
{
    partial class frm_AccountsOpeningBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AccountsOpeningBalance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGLCode = new System.Windows.Forms.TextBox();
            this.txtAcctType = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFinYear = new System.Windows.Forms.TextBox();
            this.lblFinYear = new System.Windows.Forms.Label();
            this.lblGLCode = new System.Windows.Forms.Label();
            this.lblSubGL = new System.Windows.Forms.Label();
            this.txtSubGLCode = new System.Windows.Forms.TextBox();
            this.lblAccType = new System.Windows.Forms.Label();
            this.lblAccName = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.GLName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBGLName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcctTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openbalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsClosingBalDebit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsClosingBalCredit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.budget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnFilters = new System.Windows.Forms.Button();
            this.btnAutoUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.z3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txtGLCode);
            this.panel1.Controls.Add(this.txtAcctType);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.cmbMonth);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtFinYear);
            this.panel1.Controls.Add(this.lblFinYear);
            this.panel1.Controls.Add(this.lblGLCode);
            this.panel1.Controls.Add(this.lblSubGL);
            this.panel1.Controls.Add(this.txtSubGLCode);
            this.panel1.Controls.Add(this.lblAccType);
            this.panel1.Controls.Add(this.lblAccName);
            this.panel1.Controls.Add(this.txtAccountName);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 110);
            this.panel1.TabIndex = 0;
            // 
            // txtGLCode
            // 
            this.txtGLCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtGLCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGLCode.Location = new System.Drawing.Point(417, 65);
            this.txtGLCode.Name = "txtGLCode";
            this.txtGLCode.Size = new System.Drawing.Size(179, 22);
            this.txtGLCode.TabIndex = 597;
            this.txtGLCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtGLCode_KeyUp);
            // 
            // txtAcctType
            // 
            this.txtAcctType.BackColor = System.Drawing.SystemColors.Window;
            this.txtAcctType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctType.Location = new System.Drawing.Point(112, 65);
            this.txtAcctType.Name = "txtAcctType";
            this.txtAcctType.Size = new System.Drawing.Size(179, 22);
            this.txtAcctType.TabIndex = 596;
            this.txtAcctType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAcctType_KeyUp);
            // 
            // btnBack
            // 
            this.btnBack.Enabled = false;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(379, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(37, 22);
            this.btnBack.TabIndex = 595;
            this.btnBack.TabStop = false;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(561, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(37, 22);
            this.btnNext.TabIndex = 594;
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cmbMonth
            // 
            this.cmbMonth.Enabled = false;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(419, 9);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(136, 22);
            this.cmbMonth.TabIndex = 593;
            this.cmbMonth.SelectedValueChanged += new System.EventHandler(this.cmbMonth_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(306, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 592;
            this.label5.Text = "Month";
            // 
            // txtFinYear
            // 
            this.txtFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtFinYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinYear.Location = new System.Drawing.Point(112, 9);
            this.txtFinYear.Name = "txtFinYear";
            this.txtFinYear.Size = new System.Drawing.Size(179, 22);
            this.txtFinYear.TabIndex = 590;
            this.txtFinYear.DoubleClick += new System.EventHandler(this.txtFinYear_DoubleClick);
            this.txtFinYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinYear_KeyDown);
            // 
            // lblFinYear
            // 
            this.lblFinYear.AutoSize = true;
            this.lblFinYear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFinYear.Location = new System.Drawing.Point(11, 12);
            this.lblFinYear.Name = "lblFinYear";
            this.lblFinYear.Size = new System.Drawing.Size(75, 14);
            this.lblFinYear.TabIndex = 589;
            this.lblFinYear.Text = "Financial Year";
            // 
            // lblGLCode
            // 
            this.lblGLCode.AutoSize = true;
            this.lblGLCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblGLCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGLCode.Location = new System.Drawing.Point(306, 68);
            this.lblGLCode.Name = "lblGLCode";
            this.lblGLCode.Size = new System.Drawing.Size(53, 14);
            this.lblGLCode.TabIndex = 586;
            this.lblGLCode.Text = "GL Name";
            // 
            // lblSubGL
            // 
            this.lblSubGL.AutoSize = true;
            this.lblSubGL.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubGL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSubGL.Location = new System.Drawing.Point(306, 40);
            this.lblSubGL.Name = "lblSubGL";
            this.lblSubGL.Size = new System.Drawing.Size(77, 14);
            this.lblSubGL.TabIndex = 585;
            this.lblSubGL.Text = "SUB GL Name";
            // 
            // txtSubGLCode
            // 
            this.txtSubGLCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtSubGLCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubGLCode.Location = new System.Drawing.Point(417, 37);
            this.txtSubGLCode.Name = "txtSubGLCode";
            this.txtSubGLCode.Size = new System.Drawing.Size(179, 22);
            this.txtSubGLCode.TabIndex = 570;
            this.txtSubGLCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSubGLCode_KeyUp);
            // 
            // lblAccType
            // 
            this.lblAccType.AutoSize = true;
            this.lblAccType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAccType.Location = new System.Drawing.Point(11, 68);
            this.lblAccType.Name = "lblAccType";
            this.lblAccType.Size = new System.Drawing.Size(73, 14);
            this.lblAccType.TabIndex = 579;
            this.lblAccType.Text = "Account Type";
            // 
            // lblAccName
            // 
            this.lblAccName.AutoSize = true;
            this.lblAccName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAccName.Location = new System.Drawing.Point(11, 40);
            this.lblAccName.Name = "lblAccName";
            this.lblAccName.Size = new System.Drawing.Size(79, 14);
            this.lblAccName.TabIndex = 580;
            this.lblAccName.Text = "Account Name";
            // 
            // txtAccountName
            // 
            this.txtAccountName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAccountName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(112, 37);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(179, 22);
            this.txtAccountName.TabIndex = 573;
            this.txtAccountName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAccountName_KeyUp);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(468, 126);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 599;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(549, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 568;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 28;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GLName,
            this.SUBGLName,
            this.AcctTypeName,
            this.AccCode,
            this.AccName,
            this.openbalance,
            this.DebitAmount,
            this.CreditAmount,
            this.closeBalance,
            this.IsClosingBalDebit,
            this.IsClosingBalCredit,
            this.budget});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 168);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(614, 365);
            this.dgvDetail.TabIndex = 567;
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDetail_CellParsing);
            // 
            // GLName
            // 
            this.GLName.DataPropertyName = "GLName";
            this.GLName.HeaderText = "GL Name";
            this.GLName.Name = "GLName";
            this.GLName.Visible = false;
            // 
            // SUBGLName
            // 
            this.SUBGLName.DataPropertyName = "SUBGLName";
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.SUBGLName.DefaultCellStyle = dataGridViewCellStyle15;
            this.SUBGLName.HeaderText = "SUB GL Name";
            this.SUBGLName.Name = "SUBGLName";
            this.SUBGLName.Visible = false;
            // 
            // AcctTypeName
            // 
            this.AcctTypeName.DataPropertyName = "AcctTypeName";
            this.AcctTypeName.HeaderText = "Acct. Type Name";
            this.AcctTypeName.Name = "AcctTypeName";
            this.AcctTypeName.Visible = false;
            // 
            // AccCode
            // 
            this.AccCode.DataPropertyName = "AccCode";
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AccCode.DefaultCellStyle = dataGridViewCellStyle16;
            this.AccCode.HeaderText = "Account Code";
            this.AccCode.Name = "AccCode";
            this.AccCode.ReadOnly = true;
            this.AccCode.Width = 120;
            // 
            // AccName
            // 
            this.AccName.DataPropertyName = "AccName";
            this.AccName.HeaderText = "Account Name";
            this.AccName.Name = "AccName";
            this.AccName.ReadOnly = true;
            this.AccName.Width = 300;
            // 
            // openbalance
            // 
            this.openbalance.DataPropertyName = "openbalance";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.openbalance.DefaultCellStyle = dataGridViewCellStyle17;
            this.openbalance.HeaderText = "Openning Balance";
            this.openbalance.Name = "openbalance";
            this.openbalance.Visible = false;
            this.openbalance.Width = 120;
            // 
            // DebitAmount
            // 
            this.DebitAmount.DataPropertyName = "DebitAmount";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DebitAmount.DefaultCellStyle = dataGridViewCellStyle18;
            this.DebitAmount.HeaderText = "Debit Amount";
            this.DebitAmount.Name = "DebitAmount";
            this.DebitAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DebitAmount.Width = 85;
            // 
            // CreditAmount
            // 
            this.CreditAmount.DataPropertyName = "CreditAmount";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditAmount.DefaultCellStyle = dataGridViewCellStyle19;
            this.CreditAmount.HeaderText = "Credit Amount";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CreditAmount.Width = 85;
            // 
            // closeBalance
            // 
            this.closeBalance.DataPropertyName = "closeBalance";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.closeBalance.DefaultCellStyle = dataGridViewCellStyle20;
            this.closeBalance.HeaderText = "Closing Balance";
            this.closeBalance.Name = "closeBalance";
            this.closeBalance.ReadOnly = true;
            this.closeBalance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.closeBalance.Visible = false;
            this.closeBalance.Width = 80;
            // 
            // IsClosingBalDebit
            // 
            this.IsClosingBalDebit.DataPropertyName = "IsClosingBalDebit";
            this.IsClosingBalDebit.HeaderText = "Dr.";
            this.IsClosingBalDebit.Name = "IsClosingBalDebit";
            this.IsClosingBalDebit.ReadOnly = true;
            this.IsClosingBalDebit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsClosingBalDebit.Visible = false;
            this.IsClosingBalDebit.Width = 25;
            // 
            // IsClosingBalCredit
            // 
            this.IsClosingBalCredit.DataPropertyName = "IsClosingBalCredit";
            this.IsClosingBalCredit.HeaderText = "Cr.";
            this.IsClosingBalCredit.Name = "IsClosingBalCredit";
            this.IsClosingBalCredit.ReadOnly = true;
            this.IsClosingBalCredit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsClosingBalCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsClosingBalCredit.Visible = false;
            this.IsClosingBalCredit.Width = 25;
            // 
            // budget
            // 
            this.budget.DataPropertyName = "budget";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N2";
            dataGridViewCellStyle21.NullValue = null;
            this.budget.DefaultCellStyle = dataGridViewCellStyle21;
            this.budget.HeaderText = "Budget";
            this.budget.Name = "budget";
            this.budget.Visible = false;
            // 
            // z3
            // 
            this.z3.BackColor = System.Drawing.Color.DarkGray;
            this.z3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z3.Controls.Add(this.label7);
            this.z3.Controls.Add(this.txtBalance);
            this.z3.Controls.Add(this.label6);
            this.z3.Controls.Add(this.label1);
            this.z3.Controls.Add(this.txtDebit);
            this.z3.Controls.Add(this.txtCredit);
            this.z3.Location = new System.Drawing.Point(331, 537);
            this.z3.Name = "z3";
            this.z3.Size = new System.Drawing.Size(292, 90);
            this.z3.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 551;
            this.label7.Text = "Balance Amount";
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.ForeColor = System.Drawing.Color.DimGray;
            this.txtBalance.Location = new System.Drawing.Point(143, 60);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(139, 22);
            this.txtBalance.TabIndex = 550;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 15);
            this.label6.TabIndex = 549;
            this.label6.Text = "Credit Total Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 548;
            this.label1.Text = "Debit Total Amount";
            // 
            // txtDebit
            // 
            this.txtDebit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebit.ForeColor = System.Drawing.Color.DimGray;
            this.txtDebit.Location = new System.Drawing.Point(143, 6);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.ReadOnly = true;
            this.txtDebit.Size = new System.Drawing.Size(139, 22);
            this.txtDebit.TabIndex = 547;
            this.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCredit
            // 
            this.txtCredit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.ForeColor = System.Drawing.Color.DimGray;
            this.txtCredit.Location = new System.Drawing.Point(143, 34);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(139, 22);
            this.txtCredit.TabIndex = 546;
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.btnAutoUpdate);
            this.panel5.Controls.Add(this.btnFilters);
            this.panel5.Controls.Add(this.z3);
            this.panel5.Controls.Add(this.btnNew);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.dgvDetail);
            this.panel5.Location = new System.Drawing.Point(3, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(633, 638);
            this.panel5.TabIndex = 601;
            // 
            // btnFilters
            // 
            this.btnFilters.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilters.Location = new System.Drawing.Point(379, 126);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(83, 25);
            this.btnFilters.TabIndex = 616;
            this.btnFilters.Text = "Clear Filters";
            this.btnFilters.UseVisualStyleBackColor = true;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnAutoUpdate
            // 
            this.btnAutoUpdate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoUpdate.Location = new System.Drawing.Point(274, 125);
            this.btnAutoUpdate.Name = "btnAutoUpdate";
            this.btnAutoUpdate.Size = new System.Drawing.Size(99, 25);
            this.btnAutoUpdate.TabIndex = 616;
            this.btnAutoUpdate.Text = "Auto Update";
            this.btnAutoUpdate.UseVisualStyleBackColor = true;
            this.btnAutoUpdate.Click += new System.EventHandler(this.btnAutoUpdate_Click);
            // 
            // frm_AccountsOpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(639, 670);
            this.ControlBox = false;
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AccountsOpeningBalance";
            this.Text = "Accounts Opening Balance";
            this.Load += new System.EventHandler(this.frm_AccountsOpeningBalance_Load);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.z3.ResumeLayout(false);
            this.z3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAccName;
        private System.Windows.Forms.Label lblAccType;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtSubGLCode;
        private System.Windows.Forms.Label lblGLCode;
        private System.Windows.Forms.Label lblSubGL;
        private System.Windows.Forms.TextBox txtFinYear;
        private System.Windows.Forms.Label lblFinYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtAcctType;
        private System.Windows.Forms.TextBox txtGLCode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel z3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebit;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnFilters;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBGLName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcctTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccName;
        private System.Windows.Forms.DataGridViewTextBoxColumn openbalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeBalance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsClosingBalDebit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsClosingBalCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn budget;
        private System.Windows.Forms.Button btnAutoUpdate;
    }
}