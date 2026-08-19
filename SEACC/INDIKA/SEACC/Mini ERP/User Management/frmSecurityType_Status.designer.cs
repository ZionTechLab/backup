namespace Digiteq
{
    partial class frmSecurityType_Status
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
            this.dgvDetail = new SEACC_DataGrid();
            this.ConfigStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.z1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConfigTypeStatus = new System.Windows.Forms.Label();
            this.lblConfigTypeStatusID = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtConfigTypeStatus = new System.Windows.Forms.TextBox();
            this.txtConfigTypeStatusID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigStatusID,
            this.ConfigStatus,
            this.Remark});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 160);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(315, 277);
            this.dgvDetail.TabIndex = 11;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // ConfigStatusID
            // 
            this.ConfigStatusID.HeaderText = "Status ID";
            this.ConfigStatusID.Name = "ConfigStatusID";
            this.ConfigStatusID.Width = 160;
            // 
            // ConfigStatus
            // 
            this.ConfigStatus.HeaderText = "Status";
            this.ConfigStatus.Name = "ConfigStatus";
            this.ConfigStatus.Width = 150;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = false;
            this.Remark.Width = 130;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(167, 129);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(90, 129);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(244, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.label3);
            this.z1.Controls.Add(this.lblConfigTypeStatus);
            this.z1.Controls.Add(this.lblConfigTypeStatusID);
            this.z1.Controls.Add(this.txtRemark);
            this.z1.Controls.Add(this.txtConfigTypeStatus);
            this.z1.Controls.Add(this.txtConfigTypeStatusID);
            this.z1.Location = new System.Drawing.Point(6, 6);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(312, 119);
            this.z1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(7, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Remark";
            // 
            // lblConfigTypeStatus
            // 
            this.lblConfigTypeStatus.AutoSize = true;
            this.lblConfigTypeStatus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfigTypeStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblConfigTypeStatus.Location = new System.Drawing.Point(7, 33);
            this.lblConfigTypeStatus.Name = "lblConfigTypeStatus";
            this.lblConfigTypeStatus.Size = new System.Drawing.Size(64, 14);
            this.lblConfigTypeStatus.TabIndex = 25;
            this.lblConfigTypeStatus.Text = "Type status";
            // 
            // lblConfigTypeStatusID
            // 
            this.lblConfigTypeStatusID.AutoSize = true;
            this.lblConfigTypeStatusID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfigTypeStatusID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblConfigTypeStatusID.Location = new System.Drawing.Point(7, 8);
            this.lblConfigTypeStatusID.Name = "lblConfigTypeStatusID";
            this.lblConfigTypeStatusID.Size = new System.Drawing.Size(78, 14);
            this.lblConfigTypeStatusID.TabIndex = 24;
            this.lblConfigTypeStatusID.Text = "Type status ID";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(95, 57);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(208, 58);
            this.txtRemark.TabIndex = 23;
            // 
            // txtConfigTypeStatus
            // 
            this.txtConfigTypeStatus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigTypeStatus.Location = new System.Drawing.Point(95, 30);
            this.txtConfigTypeStatus.Name = "txtConfigTypeStatus";
            this.txtConfigTypeStatus.Size = new System.Drawing.Size(208, 22);
            this.txtConfigTypeStatus.TabIndex = 22;
            // 
            // txtConfigTypeStatusID
            // 
            this.txtConfigTypeStatusID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtConfigTypeStatusID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigTypeStatusID.Location = new System.Drawing.Point(95, 6);
            this.txtConfigTypeStatusID.Name = "txtConfigTypeStatusID";
            this.txtConfigTypeStatusID.Size = new System.Drawing.Size(154, 22);
            this.txtConfigTypeStatusID.TabIndex = 21;
            this.txtConfigTypeStatusID.DoubleClick += new System.EventHandler(this.txtConfigTypeStatusID_DoubleClick);
            this.txtConfigTypeStatusID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfigTypeStatusID_KeyDown);
            // 
            // frm_mtr_SecurityConfigType_Value
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(322, 437);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtr_SecurityConfigType_Value";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Configeration Type Status";
            this.Load += new System.EventHandler(this.frm_mtrSecurityConfigType_Status_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrSecurityConfigType_Status_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConfigTypeStatus;
        private System.Windows.Forms.Label lblConfigTypeStatusID;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtConfigTypeStatus;
        private System.Windows.Forms.TextBox txtConfigTypeStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}