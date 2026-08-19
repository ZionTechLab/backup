namespace Digiteq
{
    partial class frm_mtrProvince
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
            this.ProvinceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProvinceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProvinceName = new System.Windows.Forms.Label();
            this.txtProvinceName = new System.Windows.Forms.TextBox();
            this.lblProvinceID = new System.Windows.Forms.Label();
            this.lblCountryName = new System.Windows.Forms.Label();
            this.txtCountryName = new System.Windows.Forms.TextBox();
            this.txtProvinceID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(167, 132);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 11;
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
            this.ProvinceID,
            this.ProvinceName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 162);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 233);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // ProvinceID
            // 
            this.ProvinceID.HeaderText = "Province ID";
            this.ProvinceID.Name = "ProvinceID";
            this.ProvinceID.Width = 90;
            // 
            // ProvinceName
            // 
            this.ProvinceName.HeaderText = "Province Name";
            this.ProvinceName.Name = "ProvinceName";
            this.ProvinceName.Width = 218;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblProvinceName);
            this.panel2.Controls.Add(this.txtProvinceName);
            this.panel2.Controls.Add(this.lblProvinceID);
            this.panel2.Controls.Add(this.lblCountryName);
            this.panel2.Controls.Add(this.txtCountryName);
            this.panel2.Controls.Add(this.txtProvinceID);
            this.panel2.Location = new System.Drawing.Point(6, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 89);
            this.panel2.TabIndex = 7;
            // 
            // lblProvinceName
            // 
            this.lblProvinceName.AutoSize = true;
            this.lblProvinceName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvinceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblProvinceName.Location = new System.Drawing.Point(7, 62);
            this.lblProvinceName.Name = "lblProvinceName";
            this.lblProvinceName.Size = new System.Drawing.Size(82, 14);
            this.lblProvinceName.TabIndex = 106;
            this.lblProvinceName.Text = "Province Name";
            // 
            // txtProvinceName
            // 
            this.txtProvinceName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvinceName.Location = new System.Drawing.Point(97, 59);
            this.txtProvinceName.Name = "txtProvinceName";
            this.txtProvinceName.Size = new System.Drawing.Size(199, 22);
            this.txtProvinceName.TabIndex = 105;
            this.txtProvinceName.Text = "Plastic Bag";
            // 
            // lblProvinceID
            // 
            this.lblProvinceID.AutoSize = true;
            this.lblProvinceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvinceID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblProvinceID.Location = new System.Drawing.Point(7, 10);
            this.lblProvinceID.Name = "lblProvinceID";
            this.lblProvinceID.Size = new System.Drawing.Size(63, 14);
            this.lblProvinceID.TabIndex = 72;
            this.lblProvinceID.Text = "Province ID";
            // 
            // lblCountryName
            // 
            this.lblCountryName.AutoSize = true;
            this.lblCountryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCountryName.Location = new System.Drawing.Point(7, 35);
            this.lblCountryName.Name = "lblCountryName";
            this.lblCountryName.Size = new System.Drawing.Size(78, 14);
            this.lblCountryName.TabIndex = 104;
            this.lblCountryName.Text = "Country Name";
            // 
            // txtCountryName
            // 
            this.txtCountryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCountryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountryName.Location = new System.Drawing.Point(97, 32);
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.ReadOnly = true;
            this.txtCountryName.Size = new System.Drawing.Size(199, 22);
            this.txtCountryName.TabIndex = 1;
            this.txtCountryName.Text = "Plastic Bag";
            this.txtCountryName.DoubleClick += new System.EventHandler(this.txtCountryName_DoubleClick);
            this.txtCountryName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCountryName_KeyDown);
            // 
            // txtProvinceID
            // 
            this.txtProvinceID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtProvinceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvinceID.Location = new System.Drawing.Point(97, 7);
            this.txtProvinceID.Name = "txtProvinceID";
            this.txtProvinceID.Size = new System.Drawing.Size(120, 22);
            this.txtProvinceID.TabIndex = 0;
            this.txtProvinceID.DoubleClick += new System.EventHandler(this.txtProvinceID_DoubleClick);
            this.txtProvinceID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvinceID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(90, 132);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(244, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrProvince
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(327, 402);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrProvince";
            this.Text = "Province Master";
            this.Load += new System.EventHandler(this.frm_mtrProvince_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrProvince_KeyDown);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblProvinceName;
        private System.Windows.Forms.TextBox txtProvinceName;
        private System.Windows.Forms.Label lblProvinceID;
        private System.Windows.Forms.Label lblCountryName;
        private System.Windows.Forms.TextBox txtCountryName;
        private System.Windows.Forms.TextBox txtProvinceID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvinceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvinceName;

    }
}