namespace Digiteq
{
    partial class frm_bpsBankReconcilation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvBank = new SEACC_DataGrid();
            this.CompanyAccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReconcile = new SEACC_DataGrid();
            this.recSerial_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyAccID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatementNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateToDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpeningBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRecNew = new System.Windows.Forms.Button();
            this.btnRecCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconcile)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBank);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvReconcile);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 450);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvBank
            // 
            this.dgvBank.AllowUserToAddRows = false;
            this.dgvBank.AllowUserToDeleteRows = false;
            this.dgvBank.AllowUserToResizeColumns = false;
            this.dgvBank.AllowUserToResizeRows = false;
            this.dgvBank.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvBank.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBank.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyAccNo,
            this.BankAccNo,
            this.BankID,
            this.Bank});
            this.dgvBank.EnableHeadersVisualStyles = false;
            this.dgvBank.Location = new System.Drawing.Point(8, 9);
            this.dgvBank.MultiSelect = false;
            this.dgvBank.Name = "dgvBank";
            this.dgvBank.ReadOnly = true;
            this.dgvBank.RowHeadersVisible = false;
            this.dgvBank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBank.Size = new System.Drawing.Size(246, 432);
            this.dgvBank.TabIndex = 0;
            this.dgvBank.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBank_CellClick);
            // 
            // CompanyAccNo
            // 
            this.CompanyAccNo.DataPropertyName = "CompanyAccNo";
            this.CompanyAccNo.HeaderText = "Company Acc. No.";
            this.CompanyAccNo.Name = "CompanyAccNo";
            this.CompanyAccNo.ReadOnly = true;
            this.CompanyAccNo.Visible = false;
            // 
            // BankAccNo
            // 
            this.BankAccNo.DataPropertyName = "BankAccNo";
            this.BankAccNo.HeaderText = "Bank Acc. No";
            this.BankAccNo.Name = "BankAccNo";
            this.BankAccNo.ReadOnly = true;
            this.BankAccNo.Width = 140;
            // 
            // BankID
            // 
            this.BankID.DataPropertyName = "BankID";
            this.BankID.HeaderText = "Bank ID";
            this.BankID.Name = "BankID";
            this.BankID.ReadOnly = true;
            this.BankID.Visible = false;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Bank";
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            this.Bank.Width = 95;
            // 
            // dgvReconcile
            // 


            this.dgvReconcile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recSerial_ID,
            this.recSerialNo,
            this.companyAccID,
            this.StatementNo,
            this.dateFrom,
            this.dateTo,
            this.dateToDt,
            this.OpeningBalance,
            this.Debit,
            this.Credit,
            this.ClosingBalance,
            this.Reference});

       
            this.dgvReconcile.Location = new System.Drawing.Point(9, 9);
    
            this.dgvReconcile.Name = "dgvReconcile";
            this.dgvReconcile.ReadOnly = true;
            this.dgvReconcile.RowHeadersVisible = false;
            this.dgvReconcile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReconcile.Size = new System.Drawing.Size(876, 432);
            this.dgvReconcile.TabIndex = 1;
            this.dgvReconcile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReconcile_CellClick);
            // 
            // recSerial_ID
            // 
            this.recSerial_ID.DataPropertyName = "recSerial_ID";
            this.recSerial_ID.HeaderText = "recSerial_ID";
            this.recSerial_ID.Name = "recSerial_ID";
            this.recSerial_ID.ReadOnly = true;
            this.recSerial_ID.Visible = false;
            // 
            // recSerialNo
            // 
            this.recSerialNo.DataPropertyName = "recSerialNo";
            this.recSerialNo.HeaderText = "Rec Serial";
            this.recSerialNo.Name = "recSerialNo";
            this.recSerialNo.ReadOnly = true;
            // 
            // companyAccID
            // 
            this.companyAccID.DataPropertyName = "companyAccID";
            this.companyAccID.HeaderText = "Company AccID";
            this.companyAccID.Name = "companyAccID";
            this.companyAccID.ReadOnly = true;
            this.companyAccID.Visible = false;
            // 
            // StatementNo
            // 
            this.StatementNo.DataPropertyName = "statementNo";
            this.StatementNo.HeaderText = "Statement No";
            this.StatementNo.Name = "StatementNo";
            this.StatementNo.ReadOnly = true;
            this.StatementNo.Width = 90;
            // 
            // dateFrom
            // 
            this.dateFrom.DataPropertyName = "dateFrom";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dateFrom.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateFrom.HeaderText = "From Date";
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.ReadOnly = true;
            this.dateFrom.Width = 80;
            // 
            // dateTo
            // 
            this.dateTo.DataPropertyName = "dateTo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dateTo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dateTo.HeaderText = "To Date";
            this.dateTo.Name = "dateTo";
            this.dateTo.ReadOnly = true;
            this.dateTo.Width = 80;
            // 
            // dateToDt
            // 
            this.dateToDt.HeaderText = "dateTo";
            this.dateToDt.Name = "dateToDt";
            this.dateToDt.ReadOnly = true;
            this.dateToDt.Visible = false;
            // 
            // OpeningBalance
            // 
            this.OpeningBalance.DataPropertyName = "openingBalance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OpeningBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.OpeningBalance.HeaderText = "Opening Balance";
            this.OpeningBalance.Name = "OpeningBalance";
            this.OpeningBalance.ReadOnly = true;
            this.OpeningBalance.Width = 110;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "debit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Debit.DefaultCellStyle = dataGridViewCellStyle4;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "credit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Credit.DefaultCellStyle = dataGridViewCellStyle5;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            // 
            // ClosingBalance
            // 
            this.ClosingBalance.DataPropertyName = "closingBalance";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ClosingBalance.DefaultCellStyle = dataGridViewCellStyle6;
            this.ClosingBalance.HeaderText = "Closing Balance";
            this.ClosingBalance.Name = "ClosingBalance";
            this.ClosingBalance.ReadOnly = true;
            // 
            // Reference
            // 
            this.Reference.DataPropertyName = "Reference";
            this.Reference.HeaderText = "Reference";
            this.Reference.Name = "Reference";
            this.Reference.ReadOnly = true;
            // 
            // btnRecNew
            // 
            this.btnRecNew.BackColor = System.Drawing.Color.LightGray;
            this.btnRecNew.FlatAppearance.BorderSize = 0;
            this.btnRecNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecNew.Image = global::Digiteq.Properties.Resources.add;
            this.btnRecNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecNew.Location = new System.Drawing.Point(1014, 467);
            this.btnRecNew.Name = "btnRecNew";
            this.btnRecNew.Size = new System.Drawing.Size(137, 30);
            this.btnRecNew.TabIndex = 3;
            this.btnRecNew.Text = "  New Reconcilation";
            this.btnRecNew.UseVisualStyleBackColor = false;
            this.btnRecNew.Click += new System.EventHandler(this.btnRecNew_Click);
            // 
            // btnRecCancel
            // 
            this.btnRecCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnRecCancel.FlatAppearance.BorderSize = 0;
            this.btnRecCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRecCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecCancel.Location = new System.Drawing.Point(862, 467);
            this.btnRecCancel.Name = "btnRecCancel";
            this.btnRecCancel.Size = new System.Drawing.Size(142, 30);
            this.btnRecCancel.TabIndex = 4;
            this.btnRecCancel.Text = "    Cancel Reconcilation";
            this.btnRecCancel.UseVisualStyleBackColor = false;
            this.btnRecCancel.Click += new System.EventHandler(this.btnRecCancel_Click);
            // 
            // frm_bpsBankReconcilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRecCancel);
            this.Controls.Add(this.btnRecNew);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frm_bpsBankReconcilation";
            this.Size = new System.Drawing.Size(1162, 551);
            this.Load += new System.EventHandler(this.frm_bpsBankReconcilation_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnRecNew, 0);
            this.Controls.SetChildIndex(this.btnRecCancel, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconcile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private SEACC_DataGrid dgvBank;
        private SEACC_DataGrid dgvReconcile;
        private System.Windows.Forms.Button btnRecNew;
        private System.Windows.Forms.Button btnRecCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyAccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn recSerial_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn recSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyAccID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatementNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateToDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpeningBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosingBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
    }
}
