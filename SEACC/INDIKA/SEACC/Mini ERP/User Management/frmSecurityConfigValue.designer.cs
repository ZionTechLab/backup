namespace Digiteq
{
    partial class frmSecurityConfigValue
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
            this.z1 = new System.Windows.Forms.Panel();
            this.lblTypeValueID = new System.Windows.Forms.Label();
            this.lblConfigValue = new System.Windows.Forms.Label();
            this.txtConfigValue = new System.Windows.Forms.TextBox();
            this.txtTypeValueID = new System.Windows.Forms.TextBox();
            this.lblValueName = new System.Windows.Forms.Label();
            this.lblValueID = new System.Windows.Forms.Label();
            this.txtValueName = new System.Windows.Forms.TextBox();
            this.txtValueID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.ConfigValueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigValueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.lblTypeValueID);
            this.z1.Controls.Add(this.lblConfigValue);
            this.z1.Controls.Add(this.txtConfigValue);
            this.z1.Controls.Add(this.txtTypeValueID);
            this.z1.Controls.Add(this.lblValueName);
            this.z1.Controls.Add(this.lblValueID);
            this.z1.Controls.Add(this.txtValueName);
            this.z1.Controls.Add(this.txtValueID);
            this.z1.Location = new System.Drawing.Point(6, 6);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(305, 117);
            this.z1.TabIndex = 20;
            // 
            // lblTypeValueID
            // 
            this.lblTypeValueID.AutoSize = true;
            this.lblTypeValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblTypeValueID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTypeValueID.Location = new System.Drawing.Point(3, 37);
            this.lblTypeValueID.Name = "lblTypeValueID";
            this.lblTypeValueID.Size = new System.Drawing.Size(64, 14);
            this.lblTypeValueID.TabIndex = 29;
            this.lblTypeValueID.Text = "Value Type ";
            // 
            // lblConfigValue
            // 
            this.lblConfigValue.AutoSize = true;
            this.lblConfigValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfigValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblConfigValue.Location = new System.Drawing.Point(3, 93);
            this.lblConfigValue.Name = "lblConfigValue";
            this.lblConfigValue.Size = new System.Drawing.Size(34, 14);
            this.lblConfigValue.TabIndex = 27;
            this.lblConfigValue.Text = "Value";
            // 
            // txtConfigValue
            // 
            this.txtConfigValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigValue.Location = new System.Drawing.Point(84, 90);
            this.txtConfigValue.Name = "txtConfigValue";
            this.txtConfigValue.Size = new System.Drawing.Size(209, 22);
            this.txtConfigValue.TabIndex = 26;
            // 
            // txtTypeValueID
            // 
            this.txtTypeValueID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTypeValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeValueID.Location = new System.Drawing.Point(84, 34);
            this.txtTypeValueID.Name = "txtTypeValueID";
            this.txtTypeValueID.Size = new System.Drawing.Size(209, 22);
            this.txtTypeValueID.TabIndex = 28;
            this.txtTypeValueID.DoubleClick += new System.EventHandler(this.txtTypeValueID_DoubleClick);
            this.txtTypeValueID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTypeValueID_KeyDown);
            // 
            // lblValueName
            // 
            this.lblValueName.AutoSize = true;
            this.lblValueName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblValueName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblValueName.Location = new System.Drawing.Point(3, 65);
            this.lblValueName.Name = "lblValueName";
            this.lblValueName.Size = new System.Drawing.Size(67, 14);
            this.lblValueName.TabIndex = 25;
            this.lblValueName.Text = "Value Name";
            // 
            // lblValueID
            // 
            this.lblValueID.AutoSize = true;
            this.lblValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblValueID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblValueID.Location = new System.Drawing.Point(3, 9);
            this.lblValueID.Name = "lblValueID";
            this.lblValueID.Size = new System.Drawing.Size(48, 14);
            this.lblValueID.TabIndex = 24;
            this.lblValueID.Text = "Value ID";
            // 
            // txtValueName
            // 
            this.txtValueName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueName.Location = new System.Drawing.Point(84, 62);
            this.txtValueName.Name = "txtValueName";
            this.txtValueName.Size = new System.Drawing.Size(209, 22);
            this.txtValueName.TabIndex = 22;
            // 
            // txtValueID
            // 
            this.txtValueID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueID.Location = new System.Drawing.Point(84, 6);
            this.txtValueID.Name = "txtValueID";
            this.txtValueID.Size = new System.Drawing.Size(152, 22);
            this.txtValueID.TabIndex = 21;
            this.txtValueID.DoubleClick += new System.EventHandler(this.txtValueID_DoubleClick);
            this.txtValueID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValueID_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(157, 129);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(80, 129);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(234, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigValueID,
            this.ConfigValueName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(-2, 160);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(315, 264);
            this.dgvDetail.TabIndex = 16;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // ConfigValueID
            // 
            this.ConfigValueID.HeaderText = "Value ID";
            this.ConfigValueID.Name = "ConfigValueID";
            this.ConfigValueID.Width = 120;
            // 
            // ConfigValueName
            // 
            this.ConfigValueName.HeaderText = "Value Name";
            this.ConfigValueName.Name = "ConfigValueName";
            this.ConfigValueName.Width = 190;
            // 
            // frm_mtr_SecurityConfigValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(312, 423);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtr_SecurityConfigValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Configuration Value";
            this.Load += new System.EventHandler(this.frm_mtrSecurityConfigValue_Load);
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label lblValueName;
        private System.Windows.Forms.Label lblValueID;
        private System.Windows.Forms.TextBox txtValueName;
        private System.Windows.Forms.TextBox txtValueID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Label lblConfigValue;
        private System.Windows.Forms.TextBox txtConfigValue;
        private System.Windows.Forms.Label lblTypeValueID;
        private System.Windows.Forms.TextBox txtTypeValueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigValueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigValueName;
    }
}