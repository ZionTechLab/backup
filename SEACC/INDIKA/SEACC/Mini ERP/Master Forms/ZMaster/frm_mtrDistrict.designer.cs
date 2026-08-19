namespace Digiteq
{
    partial class frm_mtrDistrict
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
            this.DistrictID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistrictName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDistrictName = new System.Windows.Forms.TextBox();
            this.lblDistrictID = new System.Windows.Forms.Label();
            this.lblProvinceName = new System.Windows.Forms.Label();
            this.txtProvinceName = new System.Windows.Forms.TextBox();
            this.txtDistrictID = new System.Windows.Forms.TextBox();
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
            this.btnDelete.Location = new System.Drawing.Point(168, 132);
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
            this.DistrictID,
            this.DistrictName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 161);
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
            // DistrictID
            // 
            this.DistrictID.HeaderText = "District ID";
            this.DistrictID.Name = "DistrictID";
            this.DistrictID.Width = 90;
            // 
            // DistrictName
            // 
            this.DistrictName.HeaderText = "District Name";
            this.DistrictName.Name = "DistrictName";
            this.DistrictName.Width = 218;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtDistrictName);
            this.panel2.Controls.Add(this.lblDistrictID);
            this.panel2.Controls.Add(this.lblProvinceName);
            this.panel2.Controls.Add(this.txtProvinceName);
            this.panel2.Controls.Add(this.txtDistrictID);
            this.panel2.Location = new System.Drawing.Point(8, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 89);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "District Name";
            // 
            // txtDistrictName
            // 
            this.txtDistrictName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistrictName.Location = new System.Drawing.Point(97, 59);
            this.txtDistrictName.Name = "txtDistrictName";
            this.txtDistrictName.Size = new System.Drawing.Size(199, 22);
            this.txtDistrictName.TabIndex = 105;
            this.txtDistrictName.Text = "Plastic Bag";
            this.txtDistrictName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDistrictID_KeyDown);
            // 
            // lblDistrictID
            // 
            this.lblDistrictID.AutoSize = true;
            this.lblDistrictID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrictID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDistrictID.Location = new System.Drawing.Point(7, 10);
            this.lblDistrictID.Name = "lblDistrictID";
            this.lblDistrictID.Size = new System.Drawing.Size(57, 14);
            this.lblDistrictID.TabIndex = 72;
            this.lblDistrictID.Text = "District ID";
            // 
            // lblProvinceName
            // 
            this.lblProvinceName.AutoSize = true;
            this.lblProvinceName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvinceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblProvinceName.Location = new System.Drawing.Point(7, 35);
            this.lblProvinceName.Name = "lblProvinceName";
            this.lblProvinceName.Size = new System.Drawing.Size(82, 14);
            this.lblProvinceName.TabIndex = 104;
            this.lblProvinceName.Text = "Province Name";
            // 
            // txtProvinceName
            // 
            this.txtProvinceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtProvinceName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvinceName.Location = new System.Drawing.Point(97, 32);
            this.txtProvinceName.Name = "txtProvinceName";
            this.txtProvinceName.ReadOnly = true;
            this.txtProvinceName.Size = new System.Drawing.Size(199, 22);
            this.txtProvinceName.TabIndex = 1;
            this.txtProvinceName.Text = "Plastic Bag";
            this.txtProvinceName.DoubleClick += new System.EventHandler(this.txtProvinceName_DoubleClick);
            this.txtProvinceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvinceName_KeyDown);
            // 
            // txtDistrictID
            // 
            this.txtDistrictID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtDistrictID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistrictID.Location = new System.Drawing.Point(97, 7);
            this.txtDistrictID.Name = "txtDistrictID";
            this.txtDistrictID.Size = new System.Drawing.Size(120, 22);
            this.txtDistrictID.TabIndex = 0;
            this.txtDistrictID.DoubleClick += new System.EventHandler(this.txtDistrictID_DoubleClick);
            this.txtDistrictID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDistrictID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(91, 132);
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
            this.btnSave.Location = new System.Drawing.Point(245, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(327, 403);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrDistrict";
            this.Text = "District Master";
            this.Load += new System.EventHandler(this.frm_mtrDistrict_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrDistrict_KeyDown);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDistrictName;
        private System.Windows.Forms.Label lblDistrictID;
        private System.Windows.Forms.Label lblProvinceName;
        private System.Windows.Forms.TextBox txtProvinceName;
        private System.Windows.Forms.TextBox txtDistrictID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictName;

    }
}