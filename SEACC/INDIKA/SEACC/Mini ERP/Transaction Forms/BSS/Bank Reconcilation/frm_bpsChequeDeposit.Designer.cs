namespace Digiteq
{
    partial class frm_bpsChequeDeposit
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
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.txtFillter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbComBranch = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDepositBankName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDepositBranchName = new System.Windows.Forms.Label();
            this.txtDepositID = new System.Windows.Forms.TextBox();
            this.txtDepositRemark = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDepositAccountHolder = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtDepositAccountNo = new System.Windows.Forms.TextBox();
            this.dtpDepositDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.z2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmountChequeSelected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmountCheques = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCountChequeSelected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCountCheques = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dateCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridChequeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeStatus_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.z2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.dateCheque,
            this.RegisterCode,
            this.ChequeDate,
            this.CustomerName,
            this.ReceiptID,
            this.AccountNo,
            this.ChequeNo,
            this.Amount,
            this.GridChequeStatus,
            this.Sdate,
            this.chequeStatus_ID});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 40);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(823, 244);
            this.dgvDetail.TabIndex = 471;
            this.dgvDetail.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetail_CellMouseClick);
            this.dgvDetail.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellMouseLeave);
            this.dgvDetail.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetail_CellMouseMove);
            // 
            // txtFillter
            // 
            this.txtFillter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFillter.Location = new System.Drawing.Point(677, 12);
            this.txtFillter.Name = "txtFillter";
            this.txtFillter.Size = new System.Drawing.Size(154, 22);
            this.txtFillter.TabIndex = 472;
            this.txtFillter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtGenChequeNo_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 486;
            this.label1.Text = "Company Branch";
            // 
            // cmbComBranch
            // 
            this.cmbComBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComBranch.FormattingEnabled = true;
            this.cmbComBranch.Location = new System.Drawing.Point(98, 34);
            this.cmbComBranch.Name = "cmbComBranch";
            this.cmbComBranch.Size = new System.Drawing.Size(118, 22);
            this.cmbComBranch.TabIndex = 485;
            this.cmbComBranch.SelectedIndexChanged += new System.EventHandler(this.cmbComBranch_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.txtDepositID);
            this.panel1.Controls.Add(this.txtDepositRemark);
            this.panel1.Controls.Add(this.cmbComBranch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtDepositAccountHolder);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtDepositAccountNo);
            this.panel1.Controls.Add(this.dtpDepositDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(8, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 116);
            this.panel1.TabIndex = 487;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label8);
            this.flowLayoutPanel3.Controls.Add(this.lblDepositBankName);
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.lblDepositBranchName);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(517, 9);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(289, 46);
            this.flowLayoutPanel3.TabIndex = 480;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 360;
            this.label8.Text = "Bank - ";
            // 
            // lblDepositBankName
            // 
            this.lblDepositBankName.AutoSize = true;
            this.lblDepositBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositBankName.Location = new System.Drawing.Point(51, 0);
            this.lblDepositBankName.Name = "lblDepositBankName";
            this.lblDepositBankName.Size = new System.Drawing.Size(34, 14);
            this.lblDepositBankName.TabIndex = 375;
            this.lblDepositBankName.Text = "Bank";
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
            // lblDepositBranchName
            // 
            this.lblDepositBranchName.AutoSize = true;
            this.lblDepositBranchName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositBranchName.Location = new System.Drawing.Point(108, 0);
            this.lblDepositBranchName.Name = "lblDepositBranchName";
            this.lblDepositBranchName.Size = new System.Drawing.Size(34, 14);
            this.lblDepositBranchName.TabIndex = 376;
            this.lblDepositBranchName.Text = "Bank";
            // 
            // txtDepositID
            // 
            this.txtDepositID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtDepositID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositID.Location = new System.Drawing.Point(569, 61);
            this.txtDepositID.Name = "txtDepositID";
            this.txtDepositID.Size = new System.Drawing.Size(27, 22);
            this.txtDepositID.TabIndex = 374;
            this.txtDepositID.Text = "GN005";
            this.txtDepositID.Visible = false;
            // 
            // txtDepositRemark
            // 
            this.txtDepositRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositRemark.Location = new System.Drawing.Point(98, 62);
            this.txtDepositRemark.Multiline = true;
            this.txtDepositRemark.Name = "txtDepositRemark";
            this.txtDepositRemark.Size = new System.Drawing.Size(708, 41);
            this.txtDepositRemark.TabIndex = 373;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 372;
            this.label13.Text = "Remarks";
            // 
            // txtDepositAccountHolder
            // 
            this.txtDepositAccountHolder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositAccountHolder.Location = new System.Drawing.Point(317, 33);
            this.txtDepositAccountHolder.Name = "txtDepositAccountHolder";
            this.txtDepositAccountHolder.Size = new System.Drawing.Size(194, 22);
            this.txtDepositAccountHolder.TabIndex = 371;
            this.txtDepositAccountHolder.Text = "Asanka Jayasuriya";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(227, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 14);
            this.label17.TabIndex = 370;
            this.label17.Text = "3rd Party Name";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(227, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 368;
            this.label25.Text = "Account No";
            // 
            // txtDepositAccountNo
            // 
            this.txtDepositAccountNo.BackColor = System.Drawing.Color.LightGray;
            this.txtDepositAccountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositAccountNo.Location = new System.Drawing.Point(317, 5);
            this.txtDepositAccountNo.Name = "txtDepositAccountNo";
            this.txtDepositAccountNo.ReadOnly = true;
            this.txtDepositAccountNo.Size = new System.Drawing.Size(194, 22);
            this.txtDepositAccountNo.TabIndex = 369;
            this.txtDepositAccountNo.DoubleClick += new System.EventHandler(this.txtDepositAccountNo_DoubleClick);
            // 
            // dtpDepositDate
            // 
            this.dtpDepositDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDepositDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepositDate.Location = new System.Drawing.Point(98, 3);
            this.dtpDepositDate.Name = "dtpDepositDate";
            this.dtpDepositDate.Size = new System.Drawing.Size(118, 22);
            this.dtpDepositDate.TabIndex = 365;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 364;
            this.label4.Text = "Deposit Date";
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.Transparent;
            this.z2.Controls.Add(this.flowLayoutPanel2);
            this.z2.Controls.Add(this.flowLayoutPanel1);
            this.z2.Location = new System.Drawing.Point(14, 425);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(536, 34);
            this.z2.TabIndex = 488;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.txtAmountChequeSelected);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.txtAmountCheques);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(132, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(329, 18);
            this.flowLayoutPanel2.TabIndex = 480;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 478;
            this.label5.Text = "Amount";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 475;
            this.label3.Text = "/";
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
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.txtCountChequeSelected);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtCountCheques);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(118, 18);
            this.flowLayoutPanel1.TabIndex = 480;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 479;
            this.label11.Text = "Count";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 477;
            this.label2.Text = "/";
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
            this.label6.TabIndex = 368;
            this.label6.Text = "Filter";
            // 
            // IsSelected
            // 
            this.IsSelected.DataPropertyName = "IsSelected";
            this.IsSelected.HeaderText = "Select";
            this.IsSelected.Name = "IsSelected";
            this.IsSelected.ReadOnly = true;
            this.IsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelected.Width = 40;
            // 
            // dateCheque
            // 
            this.dateCheque.DataPropertyName = "dateCheque";
            this.dateCheque.HeaderText = "dateCheque";
            this.dateCheque.Name = "dateCheque";
            this.dateCheque.Visible = false;
            // 
            // RegisterCode
            // 
            this.RegisterCode.DataPropertyName = "RegisterCode";
            this.RegisterCode.HeaderText = "RegisterCode";
            this.RegisterCode.Name = "RegisterCode";
            this.RegisterCode.ReadOnly = true;
            this.RegisterCode.Width = 80;
            // 
            // ChequeDate
            // 
            this.ChequeDate.DataPropertyName = "ChequeDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChequeDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChequeDate.HeaderText = "Cheque Date";
            this.ChequeDate.Name = "ChequeDate";
            this.ChequeDate.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 212;
            // 
            // ReceiptID
            // 
            this.ReceiptID.DataPropertyName = "ReceiptID";
            this.ReceiptID.HeaderText = "Receipt No";
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.ReadOnly = true;
            this.ReceiptID.Width = 80;
            // 
            // AccountNo
            // 
            this.AccountNo.DataPropertyName = "AccountNo";
            this.AccountNo.HeaderText = "Account No";
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.ReadOnly = true;
            this.AccountNo.Width = 87;
            // 
            // ChequeNo
            // 
            this.ChequeNo.DataPropertyName = "ChequeNo";
            this.ChequeNo.HeaderText = "Cheque No";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.ReadOnly = true;
            this.ChequeNo.Width = 70;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 78;
            // 
            // GridChequeStatus
            // 
            this.GridChequeStatus.DataPropertyName = "GridChequeStatus";
            this.GridChequeStatus.HeaderText = "Chq Status";
            this.GridChequeStatus.Name = "GridChequeStatus";
            this.GridChequeStatus.ReadOnly = true;
            this.GridChequeStatus.Width = 75;
            // 
            // Sdate
            // 
            this.Sdate.DataPropertyName = "Sdate";
            this.Sdate.HeaderText = "Sdate";
            this.Sdate.Name = "Sdate";
            this.Sdate.ReadOnly = true;
            this.Sdate.Visible = false;
            // 
            // chequeStatus_ID
            // 
            this.chequeStatus_ID.DataPropertyName = "chequeStatus_ID";
            this.chequeStatus_ID.HeaderText = "Chq Status ID";
            this.chequeStatus_ID.Name = "chequeStatus_ID";
            this.chequeStatus_ID.ReadOnly = true;
            this.chequeStatus_ID.Visible = false;
            // 
            // frm_bpsChequeDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.z2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtFillter);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.label6);
            this.Name = "frm_bpsChequeDeposit";
            this.Size = new System.Drawing.Size(839, 464);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsChequeDeposit_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsChequeDeposit_SF_saveButton_Click);
            this.Load += new System.EventHandler(this.frm_bpsChequeDeposit_Load);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.txtFillter, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.z2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.z2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox txtFillter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbComBranch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDepositRemark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDepositAccountHolder;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtDepositAccountNo;
        private System.Windows.Forms.DateTimePicker dtpDepositDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtAmountCheques;
        private System.Windows.Forms.Label txtCountCheques;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtCountChequeSelected;
        private System.Windows.Forms.Label txtAmountChequeSelected;
        private System.Windows.Forms.TextBox txtDepositID;
        private System.Windows.Forms.Label lblDepositBranchName;
        private System.Windows.Forms.Label lblDepositBankName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridChequeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeStatus_ID;
    }
}
