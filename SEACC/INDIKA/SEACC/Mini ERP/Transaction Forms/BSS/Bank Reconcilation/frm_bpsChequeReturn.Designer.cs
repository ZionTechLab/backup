namespace Digiteq.Transaction_Forms.BSS.Bank_Reconcilation
{
    partial class frm_bpsChequeReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFillter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.txtDepositAccountNo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDepositBankName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDepositBranchName = new System.Windows.Forms.Label();
            this.txtDepositID = new System.Windows.Forms.TextBox();
            this.txtDepositRemark = new System.Windows.Forms.TextBox();
            this.cmbComBranch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDepositAccountHolder = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtpDepositDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridChequeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeStatus_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReconcilationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtDepositAccountNo);
            this.panel1.Controls.Add(this.txtFillter);
            this.panel1.Controls.Add(this.cmbComBranch);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 49);
            this.panel1.TabIndex = 2;
            // 
            // txtFillter
            // 
            this.txtFillter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFillter.Location = new System.Drawing.Point(688, 12);
            this.txtFillter.Name = "txtFillter";
            this.txtFillter.Size = new System.Drawing.Size(154, 22);
            this.txtFillter.TabIndex = 474;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(638, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 473;
            this.label6.Text = "Filter";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 50);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(908, 263);
            this.panel2.TabIndex = 3;
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
            this.dateCheque,
            this.RegisterCode,
            this.ChequeDate,
            this.CustomerName,
            this.ReceiptID,
            this.AccountNo,
            this.Amount,
            this.ChequeNo,
            this.IsSelected,
            this.GridChequeStatus,
            this.Sdate,
            this.chequeStatus_ID,
            this.ReconcilationDate});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 10);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(888, 243);
            this.dgvDetail.TabIndex = 472;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 313);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(908, 154);
            this.panel3.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(314, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 475;
            this.label25.Text = "Account No";
            // 
            // txtDepositAccountNo
            // 
            this.txtDepositAccountNo.BackColor = System.Drawing.Color.LightGray;
            this.txtDepositAccountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositAccountNo.Location = new System.Drawing.Point(383, 12);
            this.txtDepositAccountNo.Name = "txtDepositAccountNo";
            this.txtDepositAccountNo.ReadOnly = true;
            this.txtDepositAccountNo.Size = new System.Drawing.Size(194, 22);
            this.txtDepositAccountNo.TabIndex = 476;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.flowLayoutPanel3);
            this.panel4.Controls.Add(this.txtDepositID);
            this.panel4.Controls.Add(this.txtDepositRemark);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txtDepositAccountHolder);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.dtpDepositDate);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(10, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(823, 116);
            this.panel4.TabIndex = 488;
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
            // cmbComBranch
            // 
            this.cmbComBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComBranch.FormattingEnabled = true;
            this.cmbComBranch.Location = new System.Drawing.Point(114, 12);
            this.cmbComBranch.Name = "cmbComBranch";
            this.cmbComBranch.Size = new System.Drawing.Size(118, 22);
            this.cmbComBranch.TabIndex = 485;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 486;
            this.label1.Text = "Company Branch";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 368;
            this.label2.Text = "Account No";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(317, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(194, 22);
            this.textBox1.TabIndex = 369;
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
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 364;
            this.label4.Text = "Return Date";
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
            this.RegisterCode.DataPropertyName = "Reg. Code";
            this.RegisterCode.HeaderText = "RegisterCode";
            this.RegisterCode.Name = "RegisterCode";
            this.RegisterCode.ReadOnly = true;
            this.RegisterCode.Width = 70;
            // 
            // ChequeDate
            // 
            this.ChequeDate.DataPropertyName = "ChequeDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChequeDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ChequeDate.HeaderText = "Cheque Date";
            this.ChequeDate.Name = "ChequeDate";
            this.ChequeDate.ReadOnly = true;
            this.ChequeDate.Width = 80;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 200;
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
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 78;
            // 
            // ChequeNo
            // 
            this.ChequeNo.DataPropertyName = "ChequeNo";
            this.ChequeNo.HeaderText = "Cheque No";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.ReadOnly = true;
            this.ChequeNo.Width = 70;
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
            // ReconcilationDate
            // 
            this.ReconcilationDate.HeaderText = "Rec. Date";
            this.ReconcilationDate.Name = "ReconcilationDate";
            // 
            // frm_bpsChequeReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frm_bpsChequeReturn";
            this.Size = new System.Drawing.Size(910, 506);
            this.Load += new System.EventHandler(this.frm_bpsChequeReturn_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFillter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtDepositAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridChequeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeStatus_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReconcilationDate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDepositBankName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDepositBranchName;
        private System.Windows.Forms.TextBox txtDepositID;
        private System.Windows.Forms.TextBox txtDepositRemark;
        private System.Windows.Forms.ComboBox cmbComBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDepositAccountHolder;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpDepositDate;
        private System.Windows.Forms.Label label4;
    }
}
