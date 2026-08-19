namespace Digiteq
{
    partial class UC_DoubleEntry
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.txtDebitAmount = new System.Windows.Forms.TextBox();
            this.txtCreditAmount = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Line_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxnCategory_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct1_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line_No,
            this.TxnCategory_ID,
            this.CategoryDesc,
            this.accCode,
            this.accName,
            this.SubAcct1_ID,
            this.SubAcct1,
            this.SubAcct2_ID,
            this.SubAcct2,
            this.debitAmount,
            this.creditAmount,
            this.Remarks});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(783, 138);
            this.dgvDetail.TabIndex = 588;
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDebitAmount.Enabled = false;
            this.txtDebitAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitAmount.Location = new System.Drawing.Point(3, 8);
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.Size = new System.Drawing.Size(110, 22);
            this.txtDebitAmount.TabIndex = 590;
            this.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCreditAmount.Enabled = false;
            this.txtCreditAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditAmount.Location = new System.Drawing.Point(119, 8);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.Size = new System.Drawing.Size(110, 22);
            this.txtCreditAmount.TabIndex = 589;
            this.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtDebitAmount);
            this.flowLayoutPanel1.Controls.Add(this.txtCreditAmount);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(540, 138);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 39);
            this.flowLayoutPanel1.TabIndex = 591;
            // 
            // Line_No
            // 
            this.Line_No.DataPropertyName = "Line_No";
            this.Line_No.Frozen = true;
            this.Line_No.HeaderText = "#";
            this.Line_No.Name = "Line_No";
            this.Line_No.ReadOnly = true;
            this.Line_No.Width = 25;
            // 
            // TxnCategory_ID
            // 
            this.TxnCategory_ID.DataPropertyName = "TxnCategory_ID";
            this.TxnCategory_ID.HeaderText = "CategoryID";
            this.TxnCategory_ID.Name = "TxnCategory_ID";
            this.TxnCategory_ID.ReadOnly = true;
            this.TxnCategory_ID.Visible = false;
            // 
            // CategoryDesc
            // 
            this.CategoryDesc.DataPropertyName = "CategoryDesc";
            this.CategoryDesc.HeaderText = "Type";
            this.CategoryDesc.Name = "CategoryDesc";
            this.CategoryDesc.ReadOnly = true;
            this.CategoryDesc.Visible = false;
            this.CategoryDesc.Width = 80;
            // 
            // accCode
            // 
            this.accCode.DataPropertyName = "GLCode";
            this.accCode.HeaderText = "Account Code";
            this.accCode.Name = "accCode";
            this.accCode.ReadOnly = true;
            this.accCode.Width = 120;
            // 
            // accName
            // 
            this.accName.DataPropertyName = "GLName";
            this.accName.HeaderText = "Account Name";
            this.accName.Name = "accName";
            this.accName.ReadOnly = true;
            this.accName.Width = 145;
            // 
            // SubAcct1_ID
            // 
            this.SubAcct1_ID.DataPropertyName = "SubAcct1_ID";
            this.SubAcct1_ID.HeaderText = "Sub Acc1 ID";
            this.SubAcct1_ID.Name = "SubAcct1_ID";
            this.SubAcct1_ID.ReadOnly = true;
            this.SubAcct1_ID.Visible = false;
            // 
            // SubAcct1
            // 
            this.SubAcct1.DataPropertyName = "SubAcct1_Name";
            this.SubAcct1.HeaderText = "Sub Account 1";
            this.SubAcct1.Name = "SubAcct1";
            this.SubAcct1.ReadOnly = true;
            // 
            // SubAcct2_ID
            // 
            this.SubAcct2_ID.DataPropertyName = "SubAcct2_ID";
            this.SubAcct2_ID.HeaderText = "Sub Acc 2 ID";
            this.SubAcct2_ID.Name = "SubAcct2_ID";
            this.SubAcct2_ID.ReadOnly = true;
            this.SubAcct2_ID.Visible = false;
            // 
            // SubAcct2
            // 
            this.SubAcct2.DataPropertyName = "SubAcct2_Name";
            this.SubAcct2.HeaderText = "Sub Account 2";
            this.SubAcct2.Name = "SubAcct2";
            this.SubAcct2.ReadOnly = true;
            // 
            // debitAmount
            // 
            this.debitAmount.DataPropertyName = "Debit";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.debitAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.debitAmount.HeaderText = "Debit Amount";
            this.debitAmount.Name = "debitAmount";
            this.debitAmount.ReadOnly = true;
            this.debitAmount.Width = 105;
            // 
            // creditAmount
            // 
            this.creditAmount.DataPropertyName = "Credit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.creditAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.creditAmount.HeaderText = "Credit Amount";
            this.creditAmount.Name = "creditAmount";
            this.creditAmount.ReadOnly = true;
            this.creditAmount.Width = 105;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Visible = false;
            this.Remarks.Width = 300;
            // 
            // UC_DoubleEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgvDetail);
            this.Name = "UC_DoubleEntry";
            this.Size = new System.Drawing.Size(783, 177);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDebitAmount;
        private System.Windows.Forms.TextBox txtCreditAmount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxnCategory_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn accCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn accName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct1_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct2;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}
