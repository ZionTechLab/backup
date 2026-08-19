namespace Digiteq
{
    partial class frm_bpsPettyCashPermission
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1 = new System.Windows.Forms.Panel();
            this.chkChekable = new System.Windows.Forms.CheckBox();
            this.chkApprovable = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkWrite = new System.Windows.Forms.CheckBox();
            this.chkRed = new System.Windows.Forms.CheckBox();
            this.lblpettyCashAccount_ID = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtpettyCashAccount_ID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.x1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.Controls.Add(this.x1);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(180, 135);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Cancel";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.BranchName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 164);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(324, 241);
            this.dgvDetail.TabIndex = 15;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // UserID
            // 
            this.UserID.HeaderText = "User ID";
            this.UserID.Name = "UserID";
            // 
            // BranchName
            // 
            this.BranchName.HeaderText = "Employee Name";
            this.BranchName.Name = "BranchName";
            this.BranchName.Width = 220;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.chkChekable);
            this.x1.Controls.Add(this.chkApprovable);
            this.x1.Controls.Add(this.chkDelete);
            this.x1.Controls.Add(this.chkWrite);
            this.x1.Controls.Add(this.chkRed);
            this.x1.Controls.Add(this.lblpettyCashAccount_ID);
            this.x1.Controls.Add(this.lblBankName);
            this.x1.Controls.Add(this.txtUserName);
            this.x1.Controls.Add(this.txtpettyCashAccount_ID);
            this.x1.Location = new System.Drawing.Point(8, 14);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(324, 115);
            this.x1.TabIndex = 12;
            // 
            // chkChekable
            // 
            this.chkChekable.AutoSize = true;
            this.chkChekable.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChekable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkChekable.Location = new System.Drawing.Point(112, 86);
            this.chkChekable.Name = "chkChekable";
            this.chkChekable.Size = new System.Drawing.Size(86, 18);
            this.chkChekable.TabIndex = 419;
            this.chkChekable.Text = "Allow Check";
            this.chkChekable.UseVisualStyleBackColor = true;
            // 
            // chkApprovable
            // 
            this.chkApprovable.AutoSize = true;
            this.chkApprovable.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApprovable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkApprovable.Location = new System.Drawing.Point(11, 86);
            this.chkApprovable.Name = "chkApprovable";
            this.chkApprovable.Size = new System.Drawing.Size(75, 18);
            this.chkApprovable.TabIndex = 418;
            this.chkApprovable.Text = "Approvals";
            this.chkApprovable.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDelete.Location = new System.Drawing.Point(214, 62);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(59, 18);
            this.chkDelete.TabIndex = 417;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkWrite
            // 
            this.chkWrite.AutoSize = true;
            this.chkWrite.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWrite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkWrite.Location = new System.Drawing.Point(112, 62);
            this.chkWrite.Name = "chkWrite";
            this.chkWrite.Size = new System.Drawing.Size(54, 18);
            this.chkWrite.TabIndex = 416;
            this.chkWrite.Text = "Write";
            this.chkWrite.UseVisualStyleBackColor = true;
            // 
            // chkRed
            // 
            this.chkRed.AutoSize = true;
            this.chkRed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkRed.Location = new System.Drawing.Point(11, 62);
            this.chkRed.Name = "chkRed";
            this.chkRed.Size = new System.Drawing.Size(51, 18);
            this.chkRed.TabIndex = 415;
            this.chkRed.Text = "Read";
            this.chkRed.UseVisualStyleBackColor = true;
            // 
            // lblBranchD
            // 
            this.lblpettyCashAccount_ID.AutoSize = true;
            this.lblpettyCashAccount_ID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpettyCashAccount_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblpettyCashAccount_ID.Location = new System.Drawing.Point(11, 10);
            this.lblpettyCashAccount_ID.Name = "lblBranchD";
            this.lblpettyCashAccount_ID.Size = new System.Drawing.Size(101, 14);
            this.lblpettyCashAccount_ID.TabIndex = 72;
            this.lblpettyCashAccount_ID.Text = "Petty Cash Account";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(11, 35);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(87, 14);
            this.lblBankName.TabIndex = 104;
            this.lblBankName.Text = "Employee name";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(112, 32);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(199, 22);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "Plastic Bag";
            this.txtUserName.DoubleClick += new System.EventHandler(this.txtBranchID_DoubleClick);
            // 
            // txtpettyCashAccount_ID
            // 
            this.txtpettyCashAccount_ID.BackColor = System.Drawing.SystemColors.Control;
            this.txtpettyCashAccount_ID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpettyCashAccount_ID.Location = new System.Drawing.Point(112, 7);
            this.txtpettyCashAccount_ID.Name = "txtpettyCashAccount_ID";
            this.txtpettyCashAccount_ID.Size = new System.Drawing.Size(144, 22);
            this.txtpettyCashAccount_ID.TabIndex = 0;
            this.txtpettyCashAccount_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpettyCashAccount_ID_KeyDown);
            this.txtpettyCashAccount_ID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtpettyCashAccount_ID_MouseDoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(103, 135);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(257, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_bpsPettyCashPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(353, 424);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_bpsPettyCashPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEACC Petty Cash Permission";
            this.Load += new System.EventHandler(this.frm_mtrBranch_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Label lblpettyCashAccount_ID;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtpettyCashAccount_ID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName;
        private System.Windows.Forms.CheckBox chkChekable;
        private System.Windows.Forms.CheckBox chkApprovable;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkWrite;
        private System.Windows.Forms.CheckBox chkRed;


    }
}