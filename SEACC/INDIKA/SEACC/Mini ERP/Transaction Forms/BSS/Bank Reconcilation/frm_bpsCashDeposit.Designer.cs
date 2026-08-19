namespace Digiteq
{
    partial class frm_bpsCashDeposit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotDepAmount = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCashDepositeBankName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCashDepositeBranchName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbComBranch = new System.Windows.Forms.ComboBox();
            this.txtCashDepositeRemarks = new System.Windows.Forms.TextBox();
            this.txtTotDepAmount = new System.Windows.Forms.TextBox();
            this.txtCashDepositeID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtCashDepositeAccountNo = new System.Windows.Forms.TextBox();
            this.dtpCashDepositeDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFillter = new System.Windows.Forms.TextBox();
            this.dgvDetail = new SEACC_DataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmountChequeSelected = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmountCheques = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCountChequeSelected = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCountCheques = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chequeRegister_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepositedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTotDepAmount);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbComBranch);
            this.panel1.Controls.Add(this.txtCashDepositeRemarks);
            this.panel1.Controls.Add(this.txtTotDepAmount);
            this.panel1.Controls.Add(this.txtCashDepositeID);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtCashDepositeAccountNo);
            this.panel1.Controls.Add(this.dtpCashDepositeDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(8, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 116);
            this.panel1.TabIndex = 493;
            // 
            // lblTotDepAmount
            // 
            this.lblTotDepAmount.AutoSize = true;
            this.lblTotDepAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotDepAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotDepAmount.Location = new System.Drawing.Point(227, 37);
            this.lblTotDepAmount.Name = "lblTotDepAmount";
            this.lblTotDepAmount.Size = new System.Drawing.Size(129, 14);
            this.lblTotDepAmount.TabIndex = 377;
            this.lblTotDepAmount.Text = "Total Deposited Amount ";
            this.lblTotDepAmount.Visible = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.lblCashDepositeBankName);
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.lblCashDepositeBranchName);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(517, 9);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(289, 46);
            this.flowLayoutPanel3.TabIndex = 493;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 360;
            this.label2.Text = "Bank - ";
            // 
            // lblCashDepositeBankName
            // 
            this.lblCashDepositeBankName.AutoSize = true;
            this.lblCashDepositeBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashDepositeBankName.Location = new System.Drawing.Point(51, 0);
            this.lblCashDepositeBankName.Name = "lblCashDepositeBankName";
            this.lblCashDepositeBankName.Size = new System.Drawing.Size(34, 14);
            this.lblCashDepositeBankName.TabIndex = 375;
            this.lblCashDepositeBankName.Text = "Bank";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 475;
            this.label9.Text = "/";
            // 
            // lblCashDepositeBranchName
            // 
            this.lblCashDepositeBranchName.AutoSize = true;
            this.lblCashDepositeBranchName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashDepositeBranchName.Location = new System.Drawing.Point(108, 0);
            this.lblCashDepositeBranchName.Name = "lblCashDepositeBranchName";
            this.lblCashDepositeBranchName.Size = new System.Drawing.Size(34, 14);
            this.lblCashDepositeBranchName.TabIndex = 376;
            this.lblCashDepositeBranchName.Text = "Bank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 492;
            this.label1.Text = "Company Branch";
            // 
            // cmbComBranch
            // 
            this.cmbComBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComBranch.FormattingEnabled = true;
            this.cmbComBranch.Location = new System.Drawing.Point(98, 31);
            this.cmbComBranch.Name = "cmbComBranch";
            this.cmbComBranch.Size = new System.Drawing.Size(118, 22);
            this.cmbComBranch.TabIndex = 491;
            this.cmbComBranch.SelectedIndexChanged += new System.EventHandler(this.cmbComBranch_SelectedIndexChanged);
            // 
            // txtCashDepositeRemarks
            // 
            this.txtCashDepositeRemarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashDepositeRemarks.Location = new System.Drawing.Point(98, 59);
            this.txtCashDepositeRemarks.Multiline = true;
            this.txtCashDepositeRemarks.Name = "txtCashDepositeRemarks";
            this.txtCashDepositeRemarks.Size = new System.Drawing.Size(709, 41);
            this.txtCashDepositeRemarks.TabIndex = 373;
            // 
            // txtTotDepAmount
            // 
            this.txtTotDepAmount.BackColor = System.Drawing.Color.White;
            this.txtTotDepAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotDepAmount.Location = new System.Drawing.Point(395, 31);
            this.txtTotDepAmount.Name = "txtTotDepAmount";
            this.txtTotDepAmount.ReadOnly = true;
            this.txtTotDepAmount.Size = new System.Drawing.Size(116, 22);
            this.txtTotDepAmount.TabIndex = 378;
            this.txtTotDepAmount.Visible = false;
            // 
            // txtCashDepositeID
            // 
            this.txtCashDepositeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCashDepositeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashDepositeID.Location = new System.Drawing.Point(62, 78);
            this.txtCashDepositeID.Name = "txtCashDepositeID";
            this.txtCashDepositeID.Size = new System.Drawing.Size(27, 22);
            this.txtCashDepositeID.TabIndex = 374;
            this.txtCashDepositeID.Text = "GN005";
            this.txtCashDepositeID.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(3, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 14);
            this.label13.TabIndex = 372;
            this.label13.Text = "Remark";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(227, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 368;
            this.label25.Text = "Account No";
            // 
            // txtCashDepositeAccountNo
            // 
            this.txtCashDepositeAccountNo.BackColor = System.Drawing.Color.LightGray;
            this.txtCashDepositeAccountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashDepositeAccountNo.Location = new System.Drawing.Point(317, 3);
            this.txtCashDepositeAccountNo.Name = "txtCashDepositeAccountNo";
            this.txtCashDepositeAccountNo.ReadOnly = true;
            this.txtCashDepositeAccountNo.Size = new System.Drawing.Size(194, 22);
            this.txtCashDepositeAccountNo.TabIndex = 369;
            this.txtCashDepositeAccountNo.DoubleClick += new System.EventHandler(this.txtCashDepositeAccountNo_DoubleClick);
            // 
            // dtpCashDepositeDate
            // 
            this.dtpCashDepositeDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCashDepositeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCashDepositeDate.Location = new System.Drawing.Point(98, 3);
            this.dtpCashDepositeDate.Name = "dtpCashDepositeDate";
            this.dtpCashDepositeDate.Size = new System.Drawing.Size(118, 22);
            this.dtpCashDepositeDate.TabIndex = 365;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 364;
            this.label4.Text = "Deposit Date";
            // 
            // txtFillter
            // 
            this.txtFillter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFillter.Location = new System.Drawing.Point(677, 12);
            this.txtFillter.Name = "txtFillter";
            this.txtFillter.Size = new System.Drawing.Size(154, 22);
            this.txtFillter.TabIndex = 490;
            this.txtFillter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFillter_KeyUp);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelected,
            this.chequeRegister_ID,
            this.ReceiptDate2,
            this.ReceiptID,
            this.ReceiptDate,
            this.dataGridViewTextBoxColumn3,
            this.Amount,
            this.DepositedAmount,
            this.dataGridViewTextBoxColumn9,
            this.CSdate});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 40);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(823, 244);
            this.dgvDetail.TabIndex = 495;
            this.dgvDetail.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetail_CellMouseClick);
            this.dgvDetail.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellMouseLeave);
            this.dgvDetail.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetail_CellMouseMove);
            this.dgvDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetail_CurrentCellDirtyStateChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(10, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 34);
            this.panel2.TabIndex = 496;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.txtAmountChequeSelected);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.txtAmountCheques);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(132, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(347, 18);
            this.flowLayoutPanel2.TabIndex = 480;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 478;
            this.label3.Text = "Amount";
            // 
            // txtAmountChequeSelected
            // 
            this.txtAmountChequeSelected.AutoSize = true;
            this.txtAmountChequeSelected.Location = new System.Drawing.Point(55, 0);
            this.txtAmountChequeSelected.Name = "txtAmountChequeSelected";
            this.txtAmountChequeSelected.Size = new System.Drawing.Size(13, 13);
            this.txtAmountChequeSelected.TabIndex = 475;
            this.txtAmountChequeSelected.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 475;
            this.label7.Text = "/";
            // 
            // txtAmountCheques
            // 
            this.txtAmountCheques.AutoSize = true;
            this.txtAmountCheques.Location = new System.Drawing.Point(91, 0);
            this.txtAmountCheques.Name = "txtAmountCheques";
            this.txtAmountCheques.Size = new System.Drawing.Size(13, 13);
            this.txtAmountCheques.TabIndex = 471;
            this.txtAmountCheques.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label12);
            this.flowLayoutPanel1.Controls.Add(this.txtCountChequeSelected);
            this.flowLayoutPanel1.Controls.Add(this.label15);
            this.flowLayoutPanel1.Controls.Add(this.txtCountCheques);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(118, 18);
            this.flowLayoutPanel1.TabIndex = 480;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 479;
            this.label12.Text = "Count";
            // 
            // txtCountChequeSelected
            // 
            this.txtCountChequeSelected.AutoSize = true;
            this.txtCountChequeSelected.Location = new System.Drawing.Point(44, 0);
            this.txtCountChequeSelected.Name = "txtCountChequeSelected";
            this.txtCountChequeSelected.Size = new System.Drawing.Size(13, 13);
            this.txtCountChequeSelected.TabIndex = 477;
            this.txtCountChequeSelected.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(63, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 477;
            this.label15.Text = "/";
            // 
            // txtCountCheques
            // 
            this.txtCountCheques.AutoSize = true;
            this.txtCountCheques.Location = new System.Drawing.Point(80, 0);
            this.txtCountCheques.Name = "txtCountCheques";
            this.txtCountCheques.Size = new System.Drawing.Size(13, 13);
            this.txtCountCheques.TabIndex = 473;
            this.txtCountCheques.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(627, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 497;
            this.label6.Text = "Filter";
            // 
            // IsSelected
            // 
            this.IsSelected.DataPropertyName = "IsSelected";
            this.IsSelected.HeaderText = "";
            this.IsSelected.Name = "IsSelected";
            this.IsSelected.ReadOnly = true;
            this.IsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelected.Width = 35;
            // 
            // chequeRegister_ID
            // 
            this.chequeRegister_ID.DataPropertyName = "chequeRegister_ID";
            this.chequeRegister_ID.HeaderText = "chequeRegister_ID";
            this.chequeRegister_ID.Name = "chequeRegister_ID";
            this.chequeRegister_ID.Visible = false;
            // 
            // ReceiptDate2
            // 
            this.ReceiptDate2.DataPropertyName = "ReceiptDate2";
            this.ReceiptDate2.HeaderText = "ReceiptDate2";
            this.ReceiptDate2.Name = "ReceiptDate2";
            this.ReceiptDate2.Visible = false;
            // 
            // ReceiptID
            // 
            this.ReceiptID.DataPropertyName = "ReceiptID";
            this.ReceiptID.HeaderText = "Receipt ID";
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.ReadOnly = true;
            this.ReceiptID.Width = 120;
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.DataPropertyName = "ReceiptDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ReceiptDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ReceiptDate.HeaderText = "Receipt Date";
            this.ReceiptDate.Name = "ReceiptDate";
            this.ReceiptDate.ReadOnly = true;
            this.ReceiptDate.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CustomerName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Customer Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 270;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Balance Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // DepositedAmount
            // 
            this.DepositedAmount.DataPropertyName = "DepositedAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.DepositedAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.DepositedAmount.HeaderText = "Deposite Amount";
            this.DepositedAmount.Name = "DepositedAmount";
            this.DepositedAmount.Visible = false;
            this.DepositedAmount.Width = 105;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "InvoiceList";
            this.dataGridViewTextBoxColumn9.HeaderText = "Invoice List";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 205;
            // 
            // CSdate
            // 
            this.CSdate.DataPropertyName = "CSdate";
            this.CSdate.HeaderText = "CSdate";
            this.CSdate.Name = "CSdate";
            this.CSdate.ReadOnly = true;
            this.CSdate.Visible = false;
            this.CSdate.Width = 95;
            // 
            // frm_bpsCashDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtFillter);
            this.Name = "frm_bpsCashDeposit";
            this.Size = new System.Drawing.Size(839, 464);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCashDeposit_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsCashDeposit_SF_saveButton_Click);
            this.Load += new System.EventHandler(this.frm_bpsCashDeposit_Load);
            this.Controls.SetChildIndex(this.txtFillter, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCashDepositeID;
        private System.Windows.Forms.TextBox txtCashDepositeRemarks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtCashDepositeAccountNo;
        private System.Windows.Forms.DateTimePicker dtpCashDepositeDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFillter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbComBranch;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Label lblTotDepAmount;
        private System.Windows.Forms.TextBox txtTotDepAmount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCashDepositeBankName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCashDepositeBranchName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtAmountChequeSelected;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtAmountCheques;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label txtCountChequeSelected;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label txtCountCheques;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeRegister_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepositedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSdate;
    }
}
