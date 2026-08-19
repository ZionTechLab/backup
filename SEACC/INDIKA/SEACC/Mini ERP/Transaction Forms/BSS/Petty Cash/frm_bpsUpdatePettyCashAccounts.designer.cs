namespace Digiteq
{
    partial class frm_bpsUpdatePettyCashAccounts
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdatePettyCash = new System.Windows.Forms.Button();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBranchD = new System.Windows.Forms.Label();
            this.txtpettyCashAccountID = new System.Windows.Forms.TextBox();
            this.dgvDetail = new SEACC_DataGrid();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowRead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowWrite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(-3, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 258);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnUpdatePettyCash);
            this.panel2.Controls.Add(this.txtAccountName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblBranchD);
            this.panel2.Controls.Add(this.txtpettyCashAccountID);
            this.panel2.Location = new System.Drawing.Point(9, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 73);
            this.panel2.TabIndex = 17;
            // 
            // btnUpdatePettyCash
            // 
            this.btnUpdatePettyCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnUpdatePettyCash.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePettyCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnUpdatePettyCash.Location = new System.Drawing.Point(349, 3);
            this.btnUpdatePettyCash.Name = "btnUpdatePettyCash";
            this.btnUpdatePettyCash.Size = new System.Drawing.Size(84, 61);
            this.btnUpdatePettyCash.TabIndex = 417;
            this.btnUpdatePettyCash.Text = "Update PettyCash Account";
            this.btnUpdatePettyCash.UseVisualStyleBackColor = false;
            this.btnUpdatePettyCash.Click += new System.EventHandler(this.btnUpdatePettyCash_Click);
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(122, 41);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(198, 23);
            this.txtAccountName.TabIndex = 414;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 415;
            this.label1.Text = "Account Name";
            // 
            // lblBranchD
            // 
            this.lblBranchD.AutoSize = true;
            this.lblBranchD.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBranchD.Location = new System.Drawing.Point(3, 16);
            this.lblBranchD.Name = "lblBranchD";
            this.lblBranchD.Size = new System.Drawing.Size(115, 14);
            this.lblBranchD.TabIndex = 72;
            this.lblBranchD.Text = "Petty Cash Account ID";
            // 
            // txtpettyCashAccountID
            // 
            this.txtpettyCashAccountID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtpettyCashAccountID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpettyCashAccountID.Location = new System.Drawing.Point(122, 13);
            this.txtpettyCashAccountID.Name = "txtpettyCashAccountID";
            this.txtpettyCashAccountID.Size = new System.Drawing.Size(144, 22);
            this.txtpettyCashAccountID.TabIndex = 0;
            this.txtpettyCashAccountID.DoubleClick += new System.EventHandler(this.txtpettyCashAccount_ID_DoubleClick);
            this.txtpettyCashAccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpettyCashAccount_ID_KeyDown);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName,
            this.AllowRead,
            this.AllowWrite,
            this.AllowDelete});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 86);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(459, 160);
            this.dgvDetail.TabIndex = 16;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "User ID";
            this.UserID.Name = "UserID";
            this.UserID.Width = 80;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.Width = 150;
            // 
            // AllowRead
            // 
            this.AllowRead.HeaderText = "Allow Read";
            this.AllowRead.Name = "AllowRead";
            this.AllowRead.Width = 70;
            // 
            // AllowWrite
            // 
            this.AllowWrite.HeaderText = "Allow Write";
            this.AllowWrite.Name = "AllowWrite";
            this.AllowWrite.Width = 75;
            // 
            // AllowDelete
            // 
            this.AllowDelete.HeaderText = "Allow Delete";
            this.AllowDelete.Name = "AllowDelete";
            this.AllowDelete.Width = 80;
            // 
            // frm_bpsUpdatePettyCashAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(472, 277);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.MaximizeBox = false;
            this.Name = "frm_bpsUpdatePettyCashAccounts";
            this.Text = "SEACC Petty Update Income And Expenditure";
            this.Load += new System.EventHandler(this.frm_bpsIOU_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBranchD;
        private System.Windows.Forms.TextBox txtpettyCashAccountID;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowRead;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowWrite;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowDelete;
        private System.Windows.Forms.Button btnUpdatePettyCash;
    }
}