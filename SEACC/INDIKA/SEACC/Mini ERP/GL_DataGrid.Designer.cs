namespace Digiteq
{
    partial class GL_DataGrid
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
            this.Line_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct1_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.txtDebitAmount = new System.Windows.Forms.TextBox();
            this.txtCreditAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
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
            this.CategoryID,
            this.CategoryDesc,
            this.IsCredit,
            this.accCode,
            this.accName,
            this.SubAcct1_ID,
            this.SubAcct1,
            this.SubAcct2_ID,
            this.SubAcct2,
            this.debitAmount,
            this.creditAmount,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.Remarks});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(826, 138);
            this.dgvDetail.TabIndex = 579;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
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
            // CategoryID
            // 
            this.CategoryID.DataPropertyName = "CategoryID";
            this.CategoryID.HeaderText = "CategoryID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.ReadOnly = true;
            this.CategoryID.Visible = false;
            // 
            // CategoryDesc
            // 
            this.CategoryDesc.DataPropertyName = "CategoryDesc";
            this.CategoryDesc.HeaderText = "Type";
            this.CategoryDesc.Name = "CategoryDesc";
            this.CategoryDesc.ReadOnly = true;
            this.CategoryDesc.Width = 80;
            // 
            // IsCredit
            // 
            this.IsCredit.HeaderText = "IsCredit";
            this.IsCredit.Name = "IsCredit";
            this.IsCredit.ReadOnly = true;
            this.IsCredit.Visible = false;
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
            this.SubAcct1.DataPropertyName = "SubAcct1";
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
            this.SubAcct2.DataPropertyName = "SubAcct2";
            this.SubAcct2.HeaderText = "Sub Account 2";
            this.SubAcct2.Name = "SubAcct2";
            this.SubAcct2.ReadOnly = true;
            // 
            // debitAmount
            // 
            this.debitAmount.DataPropertyName = "GLDebit";
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
            this.creditAmount.DataPropertyName = "GLCredit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.creditAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.creditAmount.HeaderText = "Credit Amount";
            this.creditAmount.Name = "creditAmount";
            this.creditAmount.ReadOnly = true;
            this.creditAmount.Width = 105;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Employee";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "OtherCr.";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
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
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.AutoSize = true;
            this.lblBalanceAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBalanceAmount.Location = new System.Drawing.Point(349, 147);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(46, 14);
            this.lblBalanceAmount.TabIndex = 583;
            this.lblBalanceAmount.Text = "Balance";
            this.lblBalanceAmount.Visible = false;
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBalanceAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceAmount.Location = new System.Drawing.Point(399, 144);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.Size = new System.Drawing.Size(111, 22);
            this.txtBalanceAmount.TabIndex = 581;
            this.txtBalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceAmount.Visible = false;
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDebitAmount.Enabled = false;
            this.txtDebitAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitAmount.Location = new System.Drawing.Point(537, 144);
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.Size = new System.Drawing.Size(110, 22);
            this.txtDebitAmount.TabIndex = 582;
            this.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCreditAmount.Enabled = false;
            this.txtCreditAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditAmount.Location = new System.Drawing.Point(653, 144);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.Size = new System.Drawing.Size(110, 22);
            this.txtCreditAmount.TabIndex = 580;
            this.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GL_DataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBalanceAmount);
            this.Controls.Add(this.txtBalanceAmount);
            this.Controls.Add(this.txtDebitAmount);
            this.Controls.Add(this.txtCreditAmount);
            this.Controls.Add(this.dgvDetail);
            this.Name = "GL_DataGrid";
            this.Size = new System.Drawing.Size(826, 194);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Line_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn accCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn accName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct1_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct2;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Label lblBalanceAmount;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.TextBox txtDebitAmount;
        private System.Windows.Forms.TextBox txtCreditAmount;
        public System.Windows.Forms.DataGridView dgvDetail;
    }
}
