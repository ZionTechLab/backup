namespace Digiteq
{
    partial class frm_sasStockTransfer_ManualSettle
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
            this.zpanel4 = new System.Windows.Forms.Panel();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.txtSectionRequisitionNoteID = new System.Windows.Forms.TextBox();
            this.lblGoodreceivedNoteID = new System.Windows.Forms.Label();
            this.txtStoreRequisitionNoteID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartmentRequisitionNoteID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zpanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.zpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel4.Controls.Add(this.txtDepartmentRequisitionNoteID);
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.txtStoreRequisitionNoteID);
            this.zpanel4.Controls.Add(this.label1);
            this.zpanel4.Controls.Add(this.txtSectionRequisitionNoteID);
            this.zpanel4.Controls.Add(this.lblGoodreceivedNoteID);
            this.zpanel4.Controls.Add(this.lblJobNo);
            this.zpanel4.Controls.Add(this.txtJobNo);
            this.zpanel4.Location = new System.Drawing.Point(8, 8);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(505, 64);
            this.zpanel4.TabIndex = 466;
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblJobNo.Location = new System.Drawing.Point(12, 11);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(44, 15);
            this.lblJobNo.TabIndex = 454;
            this.lblJobNo.Text = "Job No";
            // 
            // txtJobNo
            // 
            this.txtJobNo.BackColor = System.Drawing.Color.LightGray;
            this.txtJobNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNo.Location = new System.Drawing.Point(99, 7);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(120, 23);
            this.txtJobNo.TabIndex = 455;
            this.txtJobNo.DoubleClick += new System.EventHandler(this.txtJobNo_DoubleClick);
            this.txtJobNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNo_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(363, 78);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 474;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(438, 78);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 473;
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
            this.DODate,
            this.DOCode,
            this.IssuedBy,
            this.JobCode,
            this.Settle});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 111);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(505, 175);
            this.dgvDetail.TabIndex = 476;
            // 
            // txtSectionRequisitionNoteID
            // 
            this.txtSectionRequisitionNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtSectionRequisitionNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSectionRequisitionNoteID.Location = new System.Drawing.Point(370, 7);
            this.txtSectionRequisitionNoteID.Name = "txtSectionRequisitionNoteID";
            this.txtSectionRequisitionNoteID.Size = new System.Drawing.Size(120, 22);
            this.txtSectionRequisitionNoteID.TabIndex = 458;
            this.txtSectionRequisitionNoteID.Text = "GN005";
            this.txtSectionRequisitionNoteID.DoubleClick += new System.EventHandler(this.txtSectionRequisitionNoteID_DoubleClick);
            this.txtSectionRequisitionNoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSectionRequisitionNoteID_KeyDown);
            // 
            // lblGoodreceivedNoteID
            // 
            this.lblGoodreceivedNoteID.AutoSize = true;
            this.lblGoodreceivedNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoodreceivedNoteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGoodreceivedNoteID.Location = new System.Drawing.Point(251, 11);
            this.lblGoodreceivedNoteID.Name = "lblGoodreceivedNoteID";
            this.lblGoodreceivedNoteID.Size = new System.Drawing.Size(89, 14);
            this.lblGoodreceivedNoteID.TabIndex = 459;
            this.lblGoodreceivedNoteID.Text = "Section iSR Code";
            // 
            // txtStoreRequisitionNoteID
            // 
            this.txtStoreRequisitionNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtStoreRequisitionNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreRequisitionNoteID.Location = new System.Drawing.Point(99, 34);
            this.txtStoreRequisitionNoteID.Name = "txtStoreRequisitionNoteID";
            this.txtStoreRequisitionNoteID.Size = new System.Drawing.Size(120, 22);
            this.txtStoreRequisitionNoteID.TabIndex = 460;
            this.txtStoreRequisitionNoteID.Text = "GN005";
            this.txtStoreRequisitionNoteID.DoubleClick += new System.EventHandler(this.txtStoreRequisitionNoteID_DoubleClick);
            this.txtStoreRequisitionNoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStoreRequisitionNoteID_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 461;
            this.label1.Text = "Store iSR Code";
            // 
            // txtDepartmentRequisitionNoteID
            // 
            this.txtDepartmentRequisitionNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtDepartmentRequisitionNoteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentRequisitionNoteID.Location = new System.Drawing.Point(370, 34);
            this.txtDepartmentRequisitionNoteID.Name = "txtDepartmentRequisitionNoteID";
            this.txtDepartmentRequisitionNoteID.Size = new System.Drawing.Size(120, 22);
            this.txtDepartmentRequisitionNoteID.TabIndex = 462;
            this.txtDepartmentRequisitionNoteID.Text = "GN005";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(251, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 14);
            this.label2.TabIndex = 463;
            this.label2.Text = "Department iSR Code";
            // 
            // DODate
            // 
            this.DODate.HeaderText = "SR Date";
            this.DODate.Name = "DODate";
            this.DODate.ReadOnly = true;
            this.DODate.Width = 80;
            // 
            // DOCode
            // 
            this.DOCode.HeaderText = "SR Code";
            this.DOCode.Name = "DOCode";
            this.DOCode.ReadOnly = true;
            // 
            // IssuedBy
            // 
            this.IssuedBy.HeaderText = "Issued By";
            this.IssuedBy.Name = "IssuedBy";
            this.IssuedBy.Width = 170;
            // 
            // JobCode
            // 
            this.JobCode.HeaderText = "JobCode";
            this.JobCode.Name = "JobCode";
            // 
            // Settle
            // 
            this.Settle.HeaderText = "Settle";
            this.Settle.Name = "Settle";
            this.Settle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Settle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Settle.Width = 50;
            // 
            // frm_sasStockTransfer_ManualSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(522, 295);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.zpanel4);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_sasStockTransfer_ManualSettle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transfer Manual Settle";
            this.Load += new System.EventHandler(this.frm_sasDeliveryOrderManuslSettle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasDeliveryOrderManuslSettle_KeyDown);
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox txtSectionRequisitionNoteID;
        private System.Windows.Forms.Label lblGoodreceivedNoteID;
        private System.Windows.Forms.TextBox txtStoreRequisitionNoteID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartmentRequisitionNoteID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Settle;
    }
}