namespace Digiteq
{
    partial class frm_SetLedgerAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new SEACC_DataGrid();
            this.Line_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct1_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct1_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAcct2_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_AddRow = new System.Windows.Forms.Button();
            this.Btn_GridDelete = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
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
            this.accCode,
            this.accName,
            this.Debit,
            this.Credit,
            this.SubAcct1_ID,
            this.SubAcct1_Name,
            this.SubAcct2_ID,
            this.SubAcct2_Name,
            this.remarks});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 58);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(769, 137);
            this.dgvDetail.TabIndex = 574;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            // 
            // Line_No
            // 
            this.Line_No.DataPropertyName = "Line_No";
            this.Line_No.HeaderText = "#";
            this.Line_No.Name = "Line_No";
            this.Line_No.ReadOnly = true;
            this.Line_No.Width = 25;
            // 
            // accCode
            // 
            this.accCode.DataPropertyName = "GLCode";
            this.accCode.HeaderText = "Acct. Code";
            this.accCode.MinimumWidth = 50;
            this.accCode.Name = "accCode";
            this.accCode.ReadOnly = true;
            this.accCode.Width = 120;
            // 
            // accName
            // 
            this.accName.DataPropertyName = "GLName";
            this.accName.HeaderText = "Acct. Name";
            this.accName.Name = "accName";
            this.accName.ReadOnly = true;
            this.accName.Width = 220;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Debit";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.Debit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.Credit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            // 
            // SubAcct1_ID
            // 
            this.SubAcct1_ID.DataPropertyName = "SubAcct1_ID";
            this.SubAcct1_ID.HeaderText = "Sub Acct1 ID";
            this.SubAcct1_ID.Name = "SubAcct1_ID";
            this.SubAcct1_ID.ReadOnly = true;
            this.SubAcct1_ID.Visible = false;
            this.SubAcct1_ID.Width = 150;
            // 
            // SubAcct1_Name
            // 
            this.SubAcct1_Name.DataPropertyName = "SubAcct1_Name";
            this.SubAcct1_Name.HeaderText = "Sub Acct1";
            this.SubAcct1_Name.Name = "SubAcct1_Name";
            this.SubAcct1_Name.ReadOnly = true;
            // 
            // SubAcct2_ID
            // 
            this.SubAcct2_ID.DataPropertyName = "SubAcct2_ID";
            this.SubAcct2_ID.HeaderText = "Sub Acct2 ID";
            this.SubAcct2_ID.Name = "SubAcct2_ID";
            this.SubAcct2_ID.ReadOnly = true;
            this.SubAcct2_ID.Visible = false;
            this.SubAcct2_ID.Width = 150;
            // 
            // SubAcct2_Name
            // 
            this.SubAcct2_Name.DataPropertyName = "SubAcct2_Name";
            this.SubAcct2_Name.HeaderText = "Sub Acct2";
            this.SubAcct2_Name.Name = "SubAcct2_Name";
            this.SubAcct2_Name.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.Width = 200;
            // 
            // Btn_AddRow
            // 
            this.Btn_AddRow.Location = new System.Drawing.Point(756, 35);
            this.Btn_AddRow.Name = "Btn_AddRow";
            this.Btn_AddRow.Size = new System.Drawing.Size(22, 23);
            this.Btn_AddRow.TabIndex = 576;
            this.Btn_AddRow.Text = "+";
            this.Btn_AddRow.UseVisualStyleBackColor = true;
            this.Btn_AddRow.Click += new System.EventHandler(this.Btn_AddRow_Click);
            // 
            // Btn_GridDelete
            // 
            this.Btn_GridDelete.Location = new System.Drawing.Point(728, 35);
            this.Btn_GridDelete.Name = "Btn_GridDelete";
            this.Btn_GridDelete.Size = new System.Drawing.Size(23, 23);
            this.Btn_GridDelete.TabIndex = 575;
            this.Btn_GridDelete.Text = "x";
            this.Btn_GridDelete.UseVisualStyleBackColor = true;
            this.Btn_GridDelete.Click += new System.EventHandler(this.Btn_GridDelete_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Ok.Location = new System.Drawing.Point(703, 201);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 577;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            // 
            // frm_SetLedgerAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Ok;
            this.ClientSize = new System.Drawing.Size(787, 235);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.Btn_AddRow);
            this.Controls.Add(this.Btn_GridDelete);
            this.Controls.Add(this.dgvDetail);
            this.Name = "frm_SetLedgerAccounts";
            this.Text = "Edit Journal ";
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.Btn_GridDelete, 0);
            this.Controls.SetChildIndex(this.Btn_AddRow, 0);
            this.Controls.SetChildIndex(this.btn_Ok, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button Btn_AddRow;
        private System.Windows.Forms.Button Btn_GridDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn accCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn accName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct1_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct1_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAcct2_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.Button btn_Ok;
    }
}