namespace Digiteq
{
    partial class frm_mtrEmpSalesExecutivecs
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
            this.SalesExecutiveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesExecutiveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtAreaManagerName = new System.Windows.Forms.TextBox();
            this.lblSupplierTypeID = new System.Windows.Forms.Label();
            this.lblSupplierTypeName = new System.Windows.Forms.Label();
            this.txtExecutiveName = new System.Windows.Forms.TextBox();
            this.txtExecutiveID = new System.Windows.Forms.TextBox();
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
            this.btnDelete.Location = new System.Drawing.Point(164, 124);
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
            this.SalesExecutiveID,
            this.SalesExecutiveName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(5, 153);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 240);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // SalesExecutiveID
            // 
            this.SalesExecutiveID.HeaderText = "Sales Executive ID ";
            this.SalesExecutiveID.Name = "SalesExecutiveID";
            this.SalesExecutiveID.Width = 110;
            // 
            // SalesExecutiveName
            // 
            this.SalesExecutiveName.HeaderText = "Sales Executive Name ";
            this.SalesExecutiveName.Name = "SalesExecutiveName";
            this.SalesExecutiveName.Width = 200;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblClassName);
            this.panel2.Controls.Add(this.txtAreaManagerName);
            this.panel2.Controls.Add(this.lblSupplierTypeID);
            this.panel2.Controls.Add(this.lblSupplierTypeName);
            this.panel2.Controls.Add(this.txtExecutiveName);
            this.panel2.Controls.Add(this.txtExecutiveID);
            this.panel2.Location = new System.Drawing.Point(6, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 89);
            this.panel2.TabIndex = 7;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClassName.Location = new System.Drawing.Point(4, 35);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(77, 14);
            this.lblClassName.TabIndex = 106;
            this.lblClassName.Text = "Area Manager";
            // 
            // txtAreaManagerName
            // 
            this.txtAreaManagerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaManagerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaManagerName.Location = new System.Drawing.Point(105, 32);
            this.txtAreaManagerName.Name = "txtAreaManagerName";
            this.txtAreaManagerName.ReadOnly = true;
            this.txtAreaManagerName.Size = new System.Drawing.Size(199, 22);
            this.txtAreaManagerName.TabIndex = 105;
            this.txtAreaManagerName.Text = "Plastic Bag";
            this.txtAreaManagerName.DoubleClick += new System.EventHandler(this.txtAreaManager_DoubleClick);
            this.txtAreaManagerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAreaManager_KeyDown);
            // 
            // lblSupplierTypeID
            // 
            this.lblSupplierTypeID.AutoSize = true;
            this.lblSupplierTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierTypeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupplierTypeID.Location = new System.Drawing.Point(4, 9);
            this.lblSupplierTypeID.Name = "lblSupplierTypeID";
            this.lblSupplierTypeID.Size = new System.Drawing.Size(98, 14);
            this.lblSupplierTypeID.TabIndex = 72;
            this.lblSupplierTypeID.Text = "Sales Executive ID";
            // 
            // lblSupplierTypeName
            // 
            this.lblSupplierTypeName.AutoSize = true;
            this.lblSupplierTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierTypeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupplierTypeName.Location = new System.Drawing.Point(4, 60);
            this.lblSupplierTypeName.Name = "lblSupplierTypeName";
            this.lblSupplierTypeName.Size = new System.Drawing.Size(87, 14);
            this.lblSupplierTypeName.TabIndex = 104;
            this.lblSupplierTypeName.Text = "Sales Executive ";
            // 
            // txtExecutiveName
            // 
            this.txtExecutiveName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExecutiveName.Location = new System.Drawing.Point(105, 58);
            this.txtExecutiveName.Name = "txtExecutiveName";
            this.txtExecutiveName.Size = new System.Drawing.Size(199, 22);
            this.txtExecutiveName.TabIndex = 1;
            this.txtExecutiveName.Text = "Plastic Bag";
            // 
            // txtExecutiveID
            // 
            this.txtExecutiveID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtExecutiveID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExecutiveID.Location = new System.Drawing.Point(105, 6);
            this.txtExecutiveID.Name = "txtExecutiveID";
            this.txtExecutiveID.Size = new System.Drawing.Size(120, 22);
            this.txtExecutiveID.TabIndex = 0;
            this.txtExecutiveID.DoubleClick += new System.EventHandler(this.txtSalseEexcutive_DoubleClick);
            this.txtExecutiveID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesExective_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(87, 124);
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
            this.btnSave.Location = new System.Drawing.Point(241, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrEmpSalesExecutivecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(323, 399);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrEmpSalesExecutivecs";
            this.Text = "Sales Executive";
            this.Load += new System.EventHandler(this.frm_mtrItemType_Load);
            this.DoubleClick += new System.EventHandler(this.frm_mtrItemType_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrSalesExectivee_KeyDown);
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
        private System.Windows.Forms.Label lblSupplierTypeID;
        private System.Windows.Forms.Label lblSupplierTypeName;
        private System.Windows.Forms.TextBox txtExecutiveName;
        private System.Windows.Forms.TextBox txtExecutiveID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtAreaManagerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesExecutiveID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesExecutiveName;

    }
}