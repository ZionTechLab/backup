namespace Digiteq
{
    partial class frmSecurityType_Value
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
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblConfigTypeValue = new System.Windows.Forms.Label();
            this.lblConfigTypeValue_ID = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtConfigTypeValue = new System.Windows.Forms.TextBox();
            this.txtConfigTypeValueID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.ConfigTypeValue_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigconfigTypeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.lblRemarks);
            this.z1.Controls.Add(this.lblConfigTypeValue);
            this.z1.Controls.Add(this.lblConfigTypeValue_ID);
            this.z1.Controls.Add(this.txtRemark);
            this.z1.Controls.Add(this.txtConfigTypeValue);
            this.z1.Controls.Add(this.txtConfigTypeValueID);
            this.z1.Location = new System.Drawing.Point(6, 6);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(312, 119);
            this.z1.TabIndex = 20;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRemarks.Location = new System.Drawing.Point(9, 60);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(51, 14);
            this.lblRemarks.TabIndex = 26;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblConfigTypeValue
            // 
            this.lblConfigTypeValue.AutoSize = true;
            this.lblConfigTypeValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfigTypeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblConfigTypeValue.Location = new System.Drawing.Point(9, 33);
            this.lblConfigTypeValue.Name = "lblConfigTypeValue";
            this.lblConfigTypeValue.Size = new System.Drawing.Size(61, 14);
            this.lblConfigTypeValue.TabIndex = 25;
            this.lblConfigTypeValue.Text = "Type Value";
            // 
            // lblConfigTypeValue_ID
            // 
            this.lblConfigTypeValue_ID.AutoSize = true;
            this.lblConfigTypeValue_ID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfigTypeValue_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblConfigTypeValue_ID.Location = new System.Drawing.Point(9, 8);
            this.lblConfigTypeValue_ID.Name = "lblConfigTypeValue_ID";
            this.lblConfigTypeValue_ID.Size = new System.Drawing.Size(75, 14);
            this.lblConfigTypeValue_ID.TabIndex = 24;
            this.lblConfigTypeValue_ID.Text = "Type Value ID";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(96, 57);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(210, 57);
            this.txtRemark.TabIndex = 23;
            // 
            // txtConfigTypeValue
            // 
            this.txtConfigTypeValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigTypeValue.Location = new System.Drawing.Point(96, 30);
            this.txtConfigTypeValue.Name = "txtConfigTypeValue";
            this.txtConfigTypeValue.Size = new System.Drawing.Size(210, 22);
            this.txtConfigTypeValue.TabIndex = 22;
            // 
            // txtConfigTypeValueID
            // 
            this.txtConfigTypeValueID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtConfigTypeValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigTypeValueID.Location = new System.Drawing.Point(96, 6);
            this.txtConfigTypeValueID.Name = "txtConfigTypeValueID";
            this.txtConfigTypeValueID.Size = new System.Drawing.Size(149, 22);
            this.txtConfigTypeValueID.TabIndex = 21;
            this.txtConfigTypeValueID.DoubleClick += new System.EventHandler(this.txtConfigTypeValueID_DoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(167, 130);
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
            this.btnNew.Location = new System.Drawing.Point(90, 130);
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
            this.btnSave.Location = new System.Drawing.Point(244, 130);
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
            this.ConfigTypeValue_ID,
            this.ConfigconfigTypeValue,
            this.Remark});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 161);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(316, 272);
            this.dgvDetail.TabIndex = 16;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // ConfigTypeValue_ID
            // 
            this.ConfigTypeValue_ID.HeaderText = "Type Value ID";
            this.ConfigTypeValue_ID.Name = "ConfigTypeValue_ID";
            this.ConfigTypeValue_ID.Width = 150;
            // 
            // ConfigconfigTypeValue
            // 
            this.ConfigconfigTypeValue.HeaderText = "Type Value";
            this.ConfigconfigTypeValue.Name = "ConfigconfigTypeValue";
            this.ConfigconfigTypeValue.Width = 160;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remarks";
            this.Remark.Name = "Remark";
            this.Remark.Visible = false;
            this.Remark.Width = 130;
            // 
            // frm_mtrSecurityConfigTypeValue
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
            this.Name = "frm_mtrSecurityConfigTypeValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Configaration Type Values";
            this.Load += new System.EventHandler(this.frm_mtrSecurityConfigTypeValue_Load);
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblConfigTypeValue;
        private System.Windows.Forms.Label lblConfigTypeValue_ID;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtConfigTypeValue;
        private System.Windows.Forms.TextBox txtConfigTypeValueID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigTypeValue_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigconfigTypeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}