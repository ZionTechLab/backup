namespace SEACC_LOGIN
{
    partial class frmWorkstationRegister
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
            this.btnNew = new System.Windows.Forms.Button();
            this.lblTerminal_ID = new System.Windows.Forms.Label();
            this.txtTerminal_ID = new System.Windows.Forms.TextBox();
            this.txtWorkstationID = new System.Windows.Forms.TextBox();
            this.lblCompanyBranch = new System.Windows.Forms.Label();
            this.txtCompanyBranch = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.chkIsApproved = new System.Windows.Forms.CheckBox();
            this.ucTittleBar1 = new SEACC_LOGIN.ucTittleBar();
            this.btn_Close = new System.Windows.Forms.Button();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkstationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.ucTittleBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(518, 409);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 454;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblTerminal_ID
            // 
            this.lblTerminal_ID.AutoSize = true;
            this.lblTerminal_ID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminal_ID.ForeColor = System.Drawing.Color.Black;
            this.lblTerminal_ID.Location = new System.Drawing.Point(399, 79);
            this.lblTerminal_ID.Name = "lblTerminal_ID";
            this.lblTerminal_ID.Size = new System.Drawing.Size(64, 14);
            this.lblTerminal_ID.TabIndex = 448;
            this.lblTerminal_ID.Text = "Terminal ID";
            // 
            // txtTerminal_ID
            // 
            this.txtTerminal_ID.BackColor = System.Drawing.SystemColors.Window;
            this.txtTerminal_ID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminal_ID.Location = new System.Drawing.Point(495, 75);
            this.txtTerminal_ID.Name = "txtTerminal_ID";
            this.txtTerminal_ID.ReadOnly = true;
            this.txtTerminal_ID.Size = new System.Drawing.Size(179, 22);
            this.txtTerminal_ID.TabIndex = 447;
            // 
            // txtWorkstationID
            // 
            this.txtWorkstationID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkstationID.Location = new System.Drawing.Point(210, 65);
            this.txtWorkstationID.Name = "txtWorkstationID";
            this.txtWorkstationID.Size = new System.Drawing.Size(166, 22);
            this.txtWorkstationID.TabIndex = 445;
            // 
            // lblCompanyBranch
            // 
            this.lblCompanyBranch.AutoSize = true;
            this.lblCompanyBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyBranch.ForeColor = System.Drawing.Color.Black;
            this.lblCompanyBranch.Location = new System.Drawing.Point(399, 51);
            this.lblCompanyBranch.Name = "lblCompanyBranch";
            this.lblCompanyBranch.Size = new System.Drawing.Size(90, 14);
            this.lblCompanyBranch.TabIndex = 444;
            this.lblCompanyBranch.Text = "Company Branch";
            // 
            // txtCompanyBranch
            // 
            this.txtCompanyBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyBranch.Location = new System.Drawing.Point(495, 47);
            this.txtCompanyBranch.Name = "txtCompanyBranch";
            this.txtCompanyBranch.ReadOnly = true;
            this.txtCompanyBranch.Size = new System.Drawing.Size(179, 22);
            this.txtCompanyBranch.TabIndex = 443;
            this.txtCompanyBranch.DoubleClick += new System.EventHandler(this.txtCompanyBranch_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(599, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 441;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeight = 22;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.WorkstationID,
            this.TerminalID,
            this.BranchID});
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.Location = new System.Drawing.Point(8, 42);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(381, 392);
            this.dgvMain.TabIndex = 440;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // chkIsApproved
            // 
            this.chkIsApproved.AutoSize = true;
            this.chkIsApproved.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsApproved.Location = new System.Drawing.Point(495, 106);
            this.chkIsApproved.Name = "chkIsApproved";
            this.chkIsApproved.Size = new System.Drawing.Size(77, 18);
            this.chkIsApproved.TabIndex = 457;
            this.chkIsApproved.Text = "Approved";
            this.chkIsApproved.UseVisualStyleBackColor = true;
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(84)))));
            this.ucTittleBar1.Controls.Add(this.btn_Close);
            this.ucTittleBar1.DisplayName = "Workstation Register";
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTittleBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(686, 34);
            this.ucTittleBar1.TabIndex = 455;
            this.ucTittleBar1.Paint += new System.Windows.Forms.PaintEventHandler(this.ucTittleBar1_Paint);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Close.Location = new System.Drawing.Point(656, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 34);
            this.btn_Close.TabIndex = 47;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LineNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.LineNo.HeaderText = "   #";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.Width = 30;
            // 
            // WorkstationID
            // 
            this.WorkstationID.DataPropertyName = "WorkstationID";
            this.WorkstationID.HeaderText = "Workstation ID";
            this.WorkstationID.Name = "WorkstationID";
            this.WorkstationID.ReadOnly = true;
            this.WorkstationID.Visible = false;
            this.WorkstationID.Width = 180;
            // 
            // TerminalID
            // 
            this.TerminalID.DataPropertyName = "TerminalID";
            this.TerminalID.HeaderText = "Terminal ID";
            this.TerminalID.Name = "TerminalID";
            this.TerminalID.ReadOnly = true;
            this.TerminalID.Width = 180;
            // 
            // BranchID
            // 
            this.BranchID.DataPropertyName = "BranchID";
            this.BranchID.HeaderText = "Branch";
            this.BranchID.Name = "BranchID";
            this.BranchID.ReadOnly = true;
            this.BranchID.Width = 150;
            // 
            // frmWorkstationRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(686, 442);
            this.Controls.Add(this.chkIsApproved);
            this.Controls.Add(this.ucTittleBar1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblTerminal_ID);
            this.Controls.Add(this.txtTerminal_ID);
            this.Controls.Add(this.txtWorkstationID);
            this.Controls.Add(this.lblCompanyBranch);
            this.Controls.Add(this.txtCompanyBranch);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWorkstationRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWorkstationRegister2";
            this.Load += new System.EventHandler(this.frmWorkstationRegister2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblTerminal_ID;
        private System.Windows.Forms.TextBox txtTerminal_ID;
        private System.Windows.Forms.TextBox txtWorkstationID;
        private System.Windows.Forms.Label lblCompanyBranch;
        private System.Windows.Forms.TextBox txtCompanyBranch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvMain;
        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.CheckBox chkIsApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkstationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchID;
    }
}