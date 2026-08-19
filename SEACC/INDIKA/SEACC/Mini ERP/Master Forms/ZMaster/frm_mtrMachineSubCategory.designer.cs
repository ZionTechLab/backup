namespace Digiteq
{
    partial class frm_mtrMachineSubCategory
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
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prifix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPrifix = new System.Windows.Forms.Label();
            this.txtPrifix = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblBankID = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtSubCategoryName = new System.Windows.Forms.TextBox();
            this.txtSubCategoryID = new System.Windows.Forms.TextBox();
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
            this.btnDelete.Location = new System.Drawing.Point(168, 131);
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
            this.CategoryID,
            this.Prifix,
            this.CategoryName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 162);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 235);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "Sub Category ID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Width = 95;
            // 
            // Prifix
            // 
            this.Prifix.HeaderText = "Prifix";
            this.Prifix.Name = "Prifix";
            this.Prifix.Width = 38;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Sub Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Width = 175;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblPrifix);
            this.panel2.Controls.Add(this.txtPrifix);
            this.panel2.Controls.Add(this.lblType);
            this.panel2.Controls.Add(this.txtCategoryName);
            this.panel2.Controls.Add(this.lblBankID);
            this.panel2.Controls.Add(this.lblBankName);
            this.panel2.Controls.Add(this.txtSubCategoryName);
            this.panel2.Controls.Add(this.txtSubCategoryID);
            this.panel2.Location = new System.Drawing.Point(7, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 89);
            this.panel2.TabIndex = 7;
            // 
            // lblPrifix
            // 
            this.lblPrifix.AutoSize = true;
            this.lblPrifix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrifix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPrifix.Location = new System.Drawing.Point(199, 9);
            this.lblPrifix.Name = "lblPrifix";
            this.lblPrifix.Size = new System.Drawing.Size(33, 14);
            this.lblPrifix.TabIndex = 112;
            this.lblPrifix.Text = "Prifix";
            // 
            // txtPrifix
            // 
            this.txtPrifix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrifix.Location = new System.Drawing.Point(239, 6);
            this.txtPrifix.Name = "txtPrifix";
            this.txtPrifix.Size = new System.Drawing.Size(65, 22);
            this.txtPrifix.TabIndex = 111;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblType.Location = new System.Drawing.Point(3, 36);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(84, 14);
            this.lblType.TabIndex = 106;
            this.lblType.Text = "Category Name";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCategoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(88, 33);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.ReadOnly = true;
            this.txtCategoryName.Size = new System.Drawing.Size(216, 22);
            this.txtCategoryName.TabIndex = 105;
            this.txtCategoryName.Text = "Plastic Bag";
            this.txtCategoryName.DoubleClick += new System.EventHandler(this.txtCategoryName_DoubleClick);
            this.txtCategoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryName_KeyUp);
            // 
            // lblBankID
            // 
            this.lblBankID.AutoSize = true;
            this.lblBankID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankID.Location = new System.Drawing.Point(3, 9);
            this.lblBankID.Name = "lblBankID";
            this.lblBankID.Size = new System.Drawing.Size(86, 14);
            this.lblBankID.TabIndex = 72;
            this.lblBankID.Text = "Sub Category ID";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(3, 64);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(80, 14);
            this.lblBankName.TabIndex = 104;
            this.lblBankName.Text = "Sub Cat. Name";
            // 
            // txtSubCategoryName
            // 
            this.txtSubCategoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategoryName.Location = new System.Drawing.Point(88, 61);
            this.txtSubCategoryName.Name = "txtSubCategoryName";
            this.txtSubCategoryName.Size = new System.Drawing.Size(216, 22);
            this.txtSubCategoryName.TabIndex = 1;
            this.txtSubCategoryName.Text = "Plastic Bag";
            // 
            // txtSubCategoryID
            // 
            this.txtSubCategoryID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtSubCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategoryID.Location = new System.Drawing.Point(88, 5);
            this.txtSubCategoryID.Name = "txtSubCategoryID";
            this.txtSubCategoryID.Size = new System.Drawing.Size(100, 22);
            this.txtSubCategoryID.TabIndex = 0;
            this.txtSubCategoryID.DoubleClick += new System.EventHandler(this.txtSubCategoryID_DoubleClick);
            this.txtSubCategoryID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategoryID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(91, 131);
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
            this.btnSave.Location = new System.Drawing.Point(245, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrMachineSubCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(328, 406);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrMachineSubCategory";
            this.Text = "Machine Sub Category Master";
            this.Load += new System.EventHandler(this.frm_mtrItemCategory_Load);
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
        private System.Windows.Forms.Label lblBankID;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtSubCategoryName;
        private System.Windows.Forms.TextBox txtSubCategoryID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblPrifix;
        private System.Windows.Forms.TextBox txtPrifix;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prifix;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;

    }
}