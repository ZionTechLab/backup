namespace Digiteq
{
    partial class frm_CommissionSlabSetting

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDateRange = new System.Windows.Forms.TextBox();
            this.txtSlabName = new System.Windows.Forms.TextBox();
            this.txtSlabID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCommissionPersentage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBranchD = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.dgvDetail = new SEACC_DataGrid();
            this.SlabID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlabName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommissionPersentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCancel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(275, 159);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDateRange);
            this.panel1.Controls.Add(this.txtSlabName);
            this.panel1.Controls.Add(this.txtSlabID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCommissionPersentage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblBranchD);
            this.panel1.Controls.Add(this.lblBankName);
            this.panel1.Location = new System.Drawing.Point(10, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 118);
            this.panel1.TabIndex = 28;
            // 
            // txtDateRange
            // 
            this.txtDateRange.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateRange.Location = new System.Drawing.Point(138, 62);
            this.txtDateRange.Name = "txtDateRange";
            this.txtDateRange.Size = new System.Drawing.Size(120, 22);
            this.txtDateRange.TabIndex = 119;
            this.txtDateRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSlabName
            // 
            this.txtSlabName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlabName.Location = new System.Drawing.Point(138, 34);
            this.txtSlabName.Name = "txtSlabName";
            this.txtSlabName.Size = new System.Drawing.Size(278, 22);
            this.txtSlabName.TabIndex = 118;
            // 
            // txtSlabID
            // 
            this.txtSlabID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtSlabID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlabID.Location = new System.Drawing.Point(138, 6);
            this.txtSlabID.Name = "txtSlabID";
            this.txtSlabID.Size = new System.Drawing.Size(120, 22);
            this.txtSlabID.TabIndex = 0;
            this.txtSlabID.DoubleClick += new System.EventHandler(this.txtCompanyBranchID_DoubleClick);
            this.txtSlabID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyBranchID_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(7, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 14);
            this.label5.TabIndex = 114;
            this.label5.Text = "Commission Persentage";
            // 
            // txtCommissionPersentage
            // 
            this.txtCommissionPersentage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommissionPersentage.Location = new System.Drawing.Point(138, 89);
            this.txtCommissionPersentage.Name = "txtCommissionPersentage";
            this.txtCommissionPersentage.Size = new System.Drawing.Size(120, 22);
            this.txtCommissionPersentage.TabIndex = 113;
            this.txtCommissionPersentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "Date Range";
            // 
            // lblBranchD
            // 
            this.lblBranchD.AutoSize = true;
            this.lblBranchD.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBranchD.Location = new System.Drawing.Point(6, 10);
            this.lblBranchD.Name = "lblBranchD";
            this.lblBranchD.Size = new System.Drawing.Size(42, 14);
            this.lblBranchD.TabIndex = 72;
            this.lblBranchD.Text = "Slab ID";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(6, 38);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(37, 14);
            this.lblBankName.TabIndex = 104;
            this.lblBankName.Text = "Name";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlabID,
            this.SlabName,
            this.DateRange,
            this.CommissionPersentage,
            this.IsCancel});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 190);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(422, 274);
            this.dgvDetail.TabIndex = 26;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // SlabID
            // 
            this.SlabID.HeaderText = "Slab ID";
            this.SlabID.Name = "SlabID";
            this.SlabID.ReadOnly = true;
            this.SlabID.Width = 80;
            // 
            // SlabName
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SlabName.DefaultCellStyle = dataGridViewCellStyle1;
            this.SlabName.HeaderText = "Name";
            this.SlabName.Name = "SlabName";
            this.SlabName.ReadOnly = true;
            this.SlabName.Width = 170;
            // 
            // DateRange
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DateRange.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateRange.HeaderText = "Date Range";
            this.DateRange.Name = "DateRange";
            this.DateRange.ReadOnly = true;
            this.DateRange.Width = 90;
            // 
            // CommissionPersentage
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CommissionPersentage.DefaultCellStyle = dataGridViewCellStyle3;
            this.CommissionPersentage.HeaderText = "Persentage";
            this.CommissionPersentage.Name = "CommissionPersentage";
            this.CommissionPersentage.ReadOnly = true;
            this.CommissionPersentage.Width = 80;
            // 
            // IsCancel
            // 
            this.IsCancel.HeaderText = "IsCancel";
            this.IsCancel.Name = "IsCancel";
            this.IsCancel.ReadOnly = true;
            this.IsCancel.Visible = false;
            this.IsCancel.Width = 50;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(194, 159);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 25;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(356, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_CommissionSlabSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(441, 472);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_CommissionSlabSetting";
            this.ShowInTaskbar = false;
            this.Text = "Commision Slab Setting";
            this.Load += new System.EventHandler(this.frm_mtrBranch_Load);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBranchD;
        private System.Windows.Forms.TextBox txtSlabID;
        private System.Windows.Forms.Label lblBankName;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCommissionPersentage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDateRange;
        private System.Windows.Forms.TextBox txtSlabName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlabID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlabName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommissionPersentage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCancel;


    }
}