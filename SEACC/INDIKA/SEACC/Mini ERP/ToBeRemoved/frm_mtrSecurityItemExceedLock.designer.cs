namespace Digiteq
{
    partial class frm_mtrSecurityItemExceedLock
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.ValueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z1 = new System.Windows.Forms.Panel();
            this.chkConfigValue = new System.Windows.Forms.CheckBox();
            this.lblConfigValue = new System.Windows.Forms.Label();
            this.lblValueID = new System.Windows.Forms.Label();
            this.lblValueName = new System.Windows.Forms.Label();
            this.txtValueName = new System.Windows.Forms.TextBox();
            this.txtValueID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(147, 105);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "    Delete";
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
            this.ValueID,
            this.ValueName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(2, 134);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(297, 214);
            this.dgvDetail.TabIndex = 25;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // ValueID
            // 
            this.ValueID.HeaderText = "Value ID";
            this.ValueID.Name = "ValueID";
            this.ValueID.Width = 90;
            // 
            // ValueName
            // 
            this.ValueName.HeaderText = "Value Name";
            this.ValueName.Name = "ValueName";
            this.ValueName.Width = 218;
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.chkConfigValue);
            this.z1.Controls.Add(this.lblConfigValue);
            this.z1.Controls.Add(this.lblValueID);
            this.z1.Controls.Add(this.lblValueName);
            this.z1.Controls.Add(this.txtValueName);
            this.z1.Controls.Add(this.txtValueID);
            this.z1.Location = new System.Drawing.Point(6, 6);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(293, 95);
            this.z1.TabIndex = 22;
            // 
            // chkConfigValue
            // 
            this.chkConfigValue.AutoSize = true;
            this.chkConfigValue.Location = new System.Drawing.Point(116, 61);
            this.chkConfigValue.Name = "chkConfigValue";
            this.chkConfigValue.Size = new System.Drawing.Size(88, 17);
            this.chkConfigValue.TabIndex = 108;
            this.chkConfigValue.Text = "Ture or False";
            this.chkConfigValue.UseVisualStyleBackColor = true;
            // 
            // lblConfigValue
            // 
            this.lblConfigValue.AutoSize = true;
            this.lblConfigValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblConfigValue.Location = new System.Drawing.Point(7, 61);
            this.lblConfigValue.Name = "lblConfigValue";
            this.lblConfigValue.Size = new System.Drawing.Size(103, 14);
            this.lblConfigValue.TabIndex = 107;
            this.lblConfigValue.Text = "Configuration Value";
            // 
            // lblValueID
            // 
            this.lblValueID.AutoSize = true;
            this.lblValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblValueID.Location = new System.Drawing.Point(7, 10);
            this.lblValueID.Name = "lblValueID";
            this.lblValueID.Size = new System.Drawing.Size(48, 14);
            this.lblValueID.TabIndex = 72;
            this.lblValueID.Text = "Value ID";
            // 
            // lblValueName
            // 
            this.lblValueName.AutoSize = true;
            this.lblValueName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblValueName.Location = new System.Drawing.Point(7, 35);
            this.lblValueName.Name = "lblValueName";
            this.lblValueName.Size = new System.Drawing.Size(67, 14);
            this.lblValueName.TabIndex = 104;
            this.lblValueName.Text = "Value Name";
            // 
            // txtValueName
            // 
            this.txtValueName.BackColor = System.Drawing.SystemColors.Control;
            this.txtValueName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueName.Location = new System.Drawing.Point(93, 32);
            this.txtValueName.Name = "txtValueName";
            this.txtValueName.Size = new System.Drawing.Size(196, 22);
            this.txtValueName.TabIndex = 1;
            this.txtValueName.Text = "Plastic Bag";
            // 
            // txtValueID
            // 
            this.txtValueID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueID.Location = new System.Drawing.Point(93, 7);
            this.txtValueID.Name = "txtValueID";
            this.txtValueID.Size = new System.Drawing.Size(120, 22);
            this.txtValueID.TabIndex = 0;
            this.txtValueID.DoubleClick += new System.EventHandler(this.txtValueID_DoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(70, 105);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 24;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(224, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrSecurityItemExceedLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(302, 350);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_mtrSecurityItemExceedLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Item Exceed Lock";
            this.Load += new System.EventHandler(this.frm_mtrSecurityItemExceedLock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label lblConfigValue;
        private System.Windows.Forms.Label lblValueID;
        private System.Windows.Forms.Label lblValueName;
        private System.Windows.Forms.TextBox txtValueName;
        private System.Windows.Forms.TextBox txtValueID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueName;
        private System.Windows.Forms.CheckBox chkConfigValue;
    }
}