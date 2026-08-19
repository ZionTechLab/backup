namespace Digiteq
{
    partial class UC_MtrCostCenter1
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
            this.clmCostCenterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCostCenterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCostCenterID = new System.Windows.Forms.Label();
            this.lblCostCenterName = new System.Windows.Forms.Label();
            this.txtCostCenterName = new System.Windows.Forms.TextBox();
            this.txtCostCenterID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCostCenterID,
            this.clmCostCenterName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 143);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 270);
            this.dgvDetail.TabIndex = 12;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // clmCostCenterID
            // 
            this.clmCostCenterID.HeaderText = "CostCenter ID";
            this.clmCostCenterID.Name = "clmCostCenterID";
            this.clmCostCenterID.Width = 90;
            // 
            // clmCostCenterName
            // 
            this.clmCostCenterName.HeaderText = "Cost Center Name";
            this.clmCostCenterName.Name = "clmCostCenterName";
            this.clmCostCenterName.Width = 218;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblCostCenterID);
            this.panel2.Controls.Add(this.lblCostCenterName);
            this.panel2.Controls.Add(this.txtCostCenterName);
            this.panel2.Controls.Add(this.txtCostCenterID);
            this.panel2.Location = new System.Drawing.Point(7, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 70);
            this.panel2.TabIndex = 11;
            // 
            // lblCostCenterID
            // 
            this.lblCostCenterID.AutoSize = true;
            this.lblCostCenterID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostCenterID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCostCenterID.Location = new System.Drawing.Point(5, 13);
            this.lblCostCenterID.Name = "lblCostCenterID";
            this.lblCostCenterID.Size = new System.Drawing.Size(77, 14);
            this.lblCostCenterID.TabIndex = 72;
            this.lblCostCenterID.Text = "Cost Center ID";
            // 
            // lblCostCenterName
            // 
            this.lblCostCenterName.AutoSize = true;
            this.lblCostCenterName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostCenterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCostCenterName.Location = new System.Drawing.Point(5, 39);
            this.lblCostCenterName.Name = "lblCostCenterName";
            this.lblCostCenterName.Size = new System.Drawing.Size(96, 14);
            this.lblCostCenterName.TabIndex = 104;
            this.lblCostCenterName.Text = "Cost Center Name";
            // 
            // txtCostCenterName
            // 
            this.txtCostCenterName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostCenterName.Location = new System.Drawing.Point(102, 36);
            this.txtCostCenterName.Name = "txtCostCenterName";
            this.txtCostCenterName.Size = new System.Drawing.Size(199, 22);
            this.txtCostCenterName.TabIndex = 1;
            // 
            // txtCostCenterID
            // 
            this.txtCostCenterID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCostCenterID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostCenterID.Location = new System.Drawing.Point(102, 10);
            this.txtCostCenterID.Name = "txtCostCenterID";
            this.txtCostCenterID.Size = new System.Drawing.Size(120, 22);
            this.txtCostCenterID.TabIndex = 0;
            this.txtCostCenterID.DoubleClick += new System.EventHandler(this.txtCostCenterID_DoubleClick);
            this.txtCostCenterID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostCenterID_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(165, 112);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(88, 112);
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
            this.btnSave.Location = new System.Drawing.Point(242, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UC_MtrCostCenter1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 420);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Name = "UC_MtrCostCenter1";
            this.Text = "Cost Center 1";
            this.Load += new System.EventHandler(this.frm_mtrCostCenter1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrCostCenter1_KeyDown);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCostCenterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCostCenterName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCostCenterID;
        private System.Windows.Forms.Label lblCostCenterName;
        private System.Windows.Forms.TextBox txtCostCenterName;
        private System.Windows.Forms.TextBox txtCostCenterID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
    }
}