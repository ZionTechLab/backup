namespace Digiteq
{
    partial class frm_masChequeMaster
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblChequeTypeCode = new System.Windows.Forms.Label();
            this.lblDPSize = new System.Windows.Forms.Label();
            this.txtChequeTypeName = new System.Windows.Forms.TextBox();
            this.txtChequeTypeCode = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.ChequeTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblChequeTypeCode);
            this.panel2.Controls.Add(this.lblDPSize);
            this.panel2.Controls.Add(this.txtChequeTypeName);
            this.panel2.Controls.Add(this.txtChequeTypeCode);
            this.panel2.Location = new System.Drawing.Point(8, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 61);
            this.panel2.TabIndex = 27;
            // 
            // lblChequeTypeCode
            // 
            this.lblChequeTypeCode.AutoSize = true;
            this.lblChequeTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeTypeCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblChequeTypeCode.Location = new System.Drawing.Point(7, 10);
            this.lblChequeTypeCode.Name = "lblChequeTypeCode";
            this.lblChequeTypeCode.Size = new System.Drawing.Size(97, 14);
            this.lblChequeTypeCode.TabIndex = 72;
            this.lblChequeTypeCode.Text = "Cheque Type Code";
            // 
            // lblDPSize
            // 
            this.lblDPSize.AutoSize = true;
            this.lblDPSize.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDPSize.Location = new System.Drawing.Point(7, 37);
            this.lblDPSize.Name = "lblDPSize";
            this.lblDPSize.Size = new System.Drawing.Size(103, 14);
            this.lblDPSize.TabIndex = 104;
            this.lblDPSize.Text = "Cheque Type Name";
            // 
            // txtChequeTypeName
            // 
            this.txtChequeTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeTypeName.Location = new System.Drawing.Point(110, 33);
            this.txtChequeTypeName.Name = "txtChequeTypeName";
            this.txtChequeTypeName.Size = new System.Drawing.Size(207, 22);
            this.txtChequeTypeName.TabIndex = 1;
            // 
            // txtChequeTypeCode
            // 
            this.txtChequeTypeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtChequeTypeCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeTypeCode.Location = new System.Drawing.Point(110, 5);
            this.txtChequeTypeCode.Name = "txtChequeTypeCode";
            this.txtChequeTypeCode.Size = new System.Drawing.Size(102, 22);
            this.txtChequeTypeCode.TabIndex = 0;
            this.txtChequeTypeCode.DoubleClick += new System.EventHandler(this.txtChequeTypeCode_DoubleClick);
            this.txtChequeTypeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeTypeCode_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(111, 107);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 31;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(188, 107);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(265, 107);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 30;
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
            this.ChequeTypeCode,
            this.CheckTypeName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 137);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(329, 173);
            this.dgvDetail.TabIndex = 33;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // ChequeTypeCode
            // 
            this.ChequeTypeCode.FillWeight = 200F;
            this.ChequeTypeCode.Frozen = true;
            this.ChequeTypeCode.HeaderText = "Cheque Type Code";
            this.ChequeTypeCode.Name = "ChequeTypeCode";
            this.ChequeTypeCode.Width = 120;
            // 
            // CheckTypeName
            // 
            this.CheckTypeName.FillWeight = 200F;
            this.CheckTypeName.HeaderText = "Cheque Type Name";
            this.CheckTypeName.Name = "CheckTypeName";
            this.CheckTypeName.Width = 210;
            // 
            // frm_masChequeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(348, 319);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_masChequeMaster";
            this.Text = "Cheque Type Master";
            this.Load += new System.EventHandler(this.frm_masChequeMaster_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblChequeTypeCode;
        private System.Windows.Forms.Label lblDPSize;
        private System.Windows.Forms.TextBox txtChequeTypeName;
        private System.Windows.Forms.TextBox txtChequeTypeCode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckTypeName;
    }
}