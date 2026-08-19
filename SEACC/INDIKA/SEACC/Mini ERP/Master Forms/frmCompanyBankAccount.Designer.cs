namespace Digiteq
{
    partial class frmCompanyBankAccount
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblChequeFormat = new System.Windows.Forms.Label();
            this.txtChequeFormat = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblControlAcc = new System.Windows.Forms.Label();
            this.txtControlAccID = new System.Windows.Forms.TextBox();
            this.lblBankBranch = new System.Windows.Forms.Label();
            this.txtBankBranchID = new System.Windows.Forms.TextBox();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtBankID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvAccounts = new SEACC_DataGrid();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Location = new System.Drawing.Point(748, 0);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lblChequeFormat);
            this.pnlBody.Controls.Add(this.txtChequeFormat);
            this.pnlBody.Controls.Add(this.btnNew);
            this.pnlBody.Controls.Add(this.label5);
            this.pnlBody.Controls.Add(this.lblPrefix);
            this.pnlBody.Controls.Add(this.txtPrefix);
            this.pnlBody.Controls.Add(this.lblControlAcc);
            this.pnlBody.Controls.Add(this.txtControlAccID);
            this.pnlBody.Controls.Add(this.lblBankBranch);
            this.pnlBody.Controls.Add(this.txtBankBranchID);
            this.pnlBody.Controls.Add(this.lblAccountNo);
            this.pnlBody.Controls.Add(this.txtAccountNo);
            this.pnlBody.Controls.Add(this.lblBankName);
            this.pnlBody.Controls.Add(this.txtBankID);
            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnSave);
            this.pnlBody.Controls.Add(this.dgvAccounts);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(3, 29);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(832, 408);
            this.pnlBody.TabIndex = 4;
          //  this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // lblChequeFormat
            // 
            this.lblChequeFormat.AutoSize = true;
            this.lblChequeFormat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblChequeFormat.Location = new System.Drawing.Point(576, 141);
            this.lblChequeFormat.Name = "lblChequeFormat";
            this.lblChequeFormat.Size = new System.Drawing.Size(82, 14);
            this.lblChequeFormat.TabIndex = 439;
            this.lblChequeFormat.Text = "Cheque Format";
            // 
            // txtChequeFormat
            // 
            this.txtChequeFormat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeFormat.Location = new System.Drawing.Point(664, 137);
            this.txtChequeFormat.Name = "txtChequeFormat";
            this.txtChequeFormat.ReadOnly = true;
            this.txtChequeFormat.Size = new System.Drawing.Size(156, 22);
            this.txtChequeFormat.TabIndex = 438;
            this.txtChequeFormat.DoubleClick += new System.EventHandler(this.txtChequeFormat_DoubleClick);
            this.txtChequeFormat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeFormat_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(588, 370);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 436;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(572, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 14);
            this.label5.TabIndex = 435;
            this.label5.Text = "Cheque Refference No";
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPrefix.Location = new System.Drawing.Point(576, 206);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(36, 14);
            this.lblPrefix.TabIndex = 434;
            this.lblPrefix.Text = "Prefix";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefix.Location = new System.Drawing.Point(664, 202);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(156, 22);
            this.txtPrefix.TabIndex = 433;
            // 
            // lblControlAcc
            // 
            this.lblControlAcc.AutoSize = true;
            this.lblControlAcc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblControlAcc.Location = new System.Drawing.Point(576, 113);
            this.lblControlAcc.Name = "lblControlAcc";
            this.lblControlAcc.Size = new System.Drawing.Size(65, 14);
            this.lblControlAcc.TabIndex = 432;
            this.lblControlAcc.Text = "Control Acc.";
            // 
            // txtControlAccID
            // 
            this.txtControlAccID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlAccID.Location = new System.Drawing.Point(664, 109);
            this.txtControlAccID.Name = "txtControlAccID";
            this.txtControlAccID.ReadOnly = true;
            this.txtControlAccID.Size = new System.Drawing.Size(156, 22);
            this.txtControlAccID.TabIndex = 431;
            this.txtControlAccID.DoubleClick += new System.EventHandler(this.txtControlAccID_DoubleClick);
            this.txtControlAccID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControlAccID_KeyDown);
            // 
            // lblBankBranch
            // 
            this.lblBankBranch.AutoSize = true;
            this.lblBankBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankBranch.Location = new System.Drawing.Point(576, 85);
            this.lblBankBranch.Name = "lblBankBranch";
            this.lblBankBranch.Size = new System.Drawing.Size(69, 14);
            this.lblBankBranch.TabIndex = 430;
            this.lblBankBranch.Text = "Bank Branch";
            // 
            // txtBankBranchID
            // 
            this.txtBankBranchID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankBranchID.Location = new System.Drawing.Point(664, 81);
            this.txtBankBranchID.Name = "txtBankBranchID";
            this.txtBankBranchID.ReadOnly = true;
            this.txtBankBranchID.Size = new System.Drawing.Size(156, 22);
            this.txtBankBranchID.TabIndex = 429;
            this.txtBankBranchID.DoubleClick += new System.EventHandler(this.txtBankBranchID_DoubleClick);
            this.txtBankBranchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankBranchID_KeyDown);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAccountNo.Location = new System.Drawing.Point(576, 29);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(63, 14);
            this.lblAccountNo.TabIndex = 428;
            this.lblAccountNo.Text = "Account No";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo.Location = new System.Drawing.Point(664, 25);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(156, 22);
            this.txtAccountNo.TabIndex = 427;
            this.txtAccountNo.DoubleClick += new System.EventHandler(this.txtAccountNo_DoubleClick);
            this.txtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountNo_KeyDown);
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(576, 57);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(65, 14);
            this.lblBankName.TabIndex = 426;
            this.lblBankName.Text = "Bank Name";
            // 
            // txtBankID
            // 
            this.txtBankID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankID.Location = new System.Drawing.Point(664, 53);
            this.txtBankID.Name = "txtBankID";
            this.txtBankID.ReadOnly = true;
            this.txtBankID.Size = new System.Drawing.Size(156, 22);
            this.txtBankID.TabIndex = 425;
            this.txtBankID.DoubleClick += new System.EventHandler(this.txtBankID_DoubleClick);
            this.txtBankID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankID_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(669, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 25);
            this.btnCancel.TabIndex = 424;
            this.btnCancel.Text = "     Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(746, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 423;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAccounts.ColumnHeadersHeight = 27;
            this.dgvAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BankName,
            this.BranchName,
            this.AccountID,
            this.AccountNo,
            this.GLCode});
            this.dgvAccounts.EnableHeadersVisualStyles = false;
            this.dgvAccounts.Location = new System.Drawing.Point(6, 8);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.RowHeadersVisible = false;
            this.dgvAccounts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(560, 392);
            this.dgvAccounts.TabIndex = 422;
            this.dgvAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellClick);
            // 
            // BankName
            // 
            this.BankName.HeaderText = "Bank Name";
            this.BankName.Name = "BankName";
            this.BankName.ReadOnly = true;
            this.BankName.Width = 140;
            // 
            // BranchName
            // 
            this.BranchName.HeaderText = "Branch Name";
            this.BranchName.Name = "BranchName";
            this.BranchName.ReadOnly = true;
            this.BranchName.Width = 130;
            // 
            // AccountID
            // 
            this.AccountID.HeaderText = "Company Acc. ID";
            this.AccountID.Name = "AccountID";
            this.AccountID.ReadOnly = true;
            this.AccountID.Visible = false;
            // 
            // AccountNo
            // 
            this.AccountNo.HeaderText = "Account No";
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.ReadOnly = true;
            this.AccountNo.Width = 120;
            // 
            // GLCode
            // 
            this.GLCode.HeaderText = "GL Code";
            this.GLCode.Name = "GLCode";
            this.GLCode.ReadOnly = true;
            this.GLCode.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(573, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 14);
            this.label1.TabIndex = 437;
            this.label1.Text = "_________________________________________";
            // 
            // frmCompanyBankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 440);
            this.Controls.Add(this.pnlBody);
            this.Name = "frmCompanyBankAccount";
            this.Text = "Company Bank Account";
            this.Load += new System.EventHandler(this.frmCompanyBankAccount_Load);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblControlAcc;
        private System.Windows.Forms.TextBox txtControlAccID;
        private System.Windows.Forms.Label lblBankBranch;
        private System.Windows.Forms.TextBox txtBankBranchID;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtBankID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvAccounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLCode;
        private System.Windows.Forms.Label lblChequeFormat;
        private System.Windows.Forms.TextBox txtChequeFormat;

    }
}