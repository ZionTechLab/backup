namespace Digiteq.Transaction_Forms.BSS.Bank_Reconcilation
{
    partial class frm_bpsChequeReturn_New
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.txtDepositAccountNo = new System.Windows.Forms.TextBox();
            this.txtFillter = new System.Windows.Forms.TextBox();
            this.cmbComBranch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDepositRemark = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpDepositDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.oContextMenuChq = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Returned_R = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Returned_NRC = new System.Windows.Forms.ToolStripMenuItem();
            this.RegisterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridChequeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeStatus_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeDeposit_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dateReturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.oContextMenuChq.SuspendLayout();
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
            this.txtDepositAccountNo.DoubleClick += new System.EventHandler(this.txtDepositAccountNo_DoubleClick);
            // 
            // txtFillter
            // 
            this.txtFillter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFillter.Location = new System.Drawing.Point(688, 12);
            this.txtFillter.Name = "txtFillter";
            this.txtFillter.Size = new System.Drawing.Size(154, 22);
            this.txtFillter.TabIndex = 474;
            this.txtFillter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFillter_KeyUp);
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
            this.cmbComBranch.Visible = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 486;
            this.label1.Text = "Company Branch";
            this.label1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 50);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(908, 320);
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
            this.RegisterCode,
            this.ChequeDate,
            this.CustomerName,
            this.ReceiptID,
            this.AccountNo,
            this.Amount,
            this.ChequeNo,
            this.GridChequeStatus,
            this.Sdate,
            this.chequeStatus_ID,
            this.dateDeposit,
            this.chequeDeposit_ID,
            this.IsSelected,
            this.dateReturned});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 10);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(888, 300);
            this.dgvDetail.TabIndex = 472;
            this.dgvDetail.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetail_CellMouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 370);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(908, 97);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtDepositRemark);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.dtpDepositDate);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(10, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(887, 83);
            this.panel4.TabIndex = 488;
            // 
            // txtDepositRemark
            // 
            this.txtDepositRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositRemark.Location = new System.Drawing.Point(98, 31);
            this.txtDepositRemark.Multiline = true;
            this.txtDepositRemark.Name = "txtDepositRemark";
            this.txtDepositRemark.Size = new System.Drawing.Size(773, 41);
            this.txtDepositRemark.TabIndex = 373;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 372;
            this.label13.Text = "Remarks";
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
            // oContextMenuChq
            // 
            this.oContextMenuChq.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Returned_R,
            this.toolStripMenuItem_Returned_NRC});
            this.oContextMenuChq.Name = "Retur";
            this.oContextMenuChq.Size = new System.Drawing.Size(163, 48);
            // 
            // toolStripMenuItem_Returned_R
            // 
            this.toolStripMenuItem_Returned_R.Name = "toolStripMenuItem_Returned_R";
            this.toolStripMenuItem_Returned_R.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem_Returned_R.Text = "Returned [R]";
            this.toolStripMenuItem_Returned_R.Click += new System.EventHandler(this.oContextMenuChq_Click);
            // 
            // toolStripMenuItem_Returned_NRC
            // 
            this.toolStripMenuItem_Returned_NRC.Name = "toolStripMenuItem_Returned_NRC";
            this.toolStripMenuItem_Returned_NRC.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem_Returned_NRC.Text = "Returned [NR/C]";
            this.toolStripMenuItem_Returned_NRC.Click += new System.EventHandler(this.oContextMenuChq_Click);
            // 
            // RegisterCode
            // 
            this.RegisterCode.DataPropertyName = "RegisterCode";
            this.RegisterCode.HeaderText = "Reg. Code";
            this.RegisterCode.Name = "RegisterCode";
            this.RegisterCode.ReadOnly = true;
            // 
            // ChequeDate
            // 
            this.ChequeDate.DataPropertyName = "dateCheque";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ChequeDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChequeDate.HeaderText = "Cheque Date";
            this.ChequeDate.Name = "ChequeDate";
            this.ChequeDate.ReadOnly = true;
            this.ChequeDate.Width = 70;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 180;
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
            this.AccountNo.Width = 80;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 75;
            // 
            // ChequeNo
            // 
            this.ChequeNo.DataPropertyName = "ChequeNo";
            this.ChequeNo.HeaderText = "Cheque No";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.ReadOnly = true;
            this.ChequeNo.Width = 70;
            // 
            // GridChequeStatus
            // 
            this.GridChequeStatus.DataPropertyName = "GridChequeStatus";
            this.GridChequeStatus.HeaderText = "Chq Status";
            this.GridChequeStatus.Name = "GridChequeStatus";
            this.GridChequeStatus.ReadOnly = true;
            this.GridChequeStatus.Width = 110;
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
            // dateDeposit
            // 
            this.dateDeposit.DataPropertyName = "dateDeposit";
            dataGridViewCellStyle3.Format = "dd/mm/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.dateDeposit.DefaultCellStyle = dataGridViewCellStyle3;
            this.dateDeposit.HeaderText = "Deposit Date";
            this.dateDeposit.Name = "dateDeposit";
            this.dateDeposit.ReadOnly = true;
            this.dateDeposit.Width = 70;
            // 
            // chequeDeposit_ID
            // 
            this.chequeDeposit_ID.DataPropertyName = "chequeDeposit_ID";
            this.chequeDeposit_ID.HeaderText = "chequeDeposit_ID";
            this.chequeDeposit_ID.Name = "chequeDeposit_ID";
            this.chequeDeposit_ID.Visible = false;
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
            // dateReturned
            // 
            this.dateReturned.DataPropertyName = "dateReturned";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dateReturned.DefaultCellStyle = dataGridViewCellStyle4;
            this.dateReturned.HeaderText = "Returned Date";
            this.dateReturned.Name = "dateReturned";
            this.dateReturned.Visible = false;
            this.dateReturned.Width = 70;
            // 
            // frm_bpsChequeReturn_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frm_bpsChequeReturn_New";
            this.Size = new System.Drawing.Size(910, 506);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsChequeReturn_New_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_bpsChequeReturn_New_SF_saveButton_Click);
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
            this.oContextMenuChq.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtDepositRemark;
        private System.Windows.Forms.ComboBox cmbComBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpDepositDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip oContextMenuChq;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Returned_R;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Returned_NRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridChequeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeStatus_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeDeposit_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReturned;
    }
}
