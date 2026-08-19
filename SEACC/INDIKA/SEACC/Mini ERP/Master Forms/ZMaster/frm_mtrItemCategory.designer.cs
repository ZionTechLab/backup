namespace Digiteq
{
    partial class frm_mtrItemCategory
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSerialNo = new System.Windows.Forms.CheckBox();
            this.lblPrifix = new System.Windows.Forms.Label();
            this.txtPrifix = new System.Windows.Forms.TextBox();
            this.chkItemSubCategory2Enabled = new System.Windows.Forms.CheckBox();
            this.chkSerialNo2 = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.lblBankID = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.chkItemSubCategoryEnabled = new System.Windows.Forms.CheckBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prifix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SubCategory2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SerialNo2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(444, 141);
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
            this.dgvDetail.ColumnHeadersHeight = 28;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.Prifix,
            this.CategoryName,
            this.SubCategory,
            this.SubCategory2,
            this.SerialNo,
            this.SerialNo2});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 170);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(586, 253);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkSerialNo);
            this.panel2.Controls.Add(this.lblPrifix);
            this.panel2.Controls.Add(this.txtPrifix);
            this.panel2.Controls.Add(this.chkItemSubCategory2Enabled);
            this.panel2.Controls.Add(this.chkSerialNo2);
            this.panel2.Controls.Add(this.lblType);
            this.panel2.Controls.Add(this.txtTypeName);
            this.panel2.Controls.Add(this.lblBankID);
            this.panel2.Controls.Add(this.lblBankName);
            this.panel2.Controls.Add(this.chkItemSubCategoryEnabled);
            this.panel2.Controls.Add(this.txtCategoryName);
            this.panel2.Controls.Add(this.txtCategoryID);
            this.panel2.Location = new System.Drawing.Point(9, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 98);
            this.panel2.TabIndex = 7;
            // 
            // chkSerialNo
            // 
            this.chkSerialNo.AutoSize = true;
            this.chkSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSerialNo.Location = new System.Drawing.Point(256, 65);
            this.chkSerialNo.Name = "chkSerialNo";
            this.chkSerialNo.Size = new System.Drawing.Size(74, 18);
            this.chkSerialNo.TabIndex = 119;
            this.chkSerialNo.Text = "Serial No ";
            this.chkSerialNo.UseVisualStyleBackColor = true;
            // 
            // lblPrifix
            // 
            this.lblPrifix.AutoSize = true;
            this.lblPrifix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrifix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPrifix.Location = new System.Drawing.Point(7, 38);
            this.lblPrifix.Name = "lblPrifix";
            this.lblPrifix.Size = new System.Drawing.Size(36, 14);
            this.lblPrifix.TabIndex = 114;
            this.lblPrifix.Text = "Prefix";
            // 
            // txtPrifix
            // 
            this.txtPrifix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrifix.Location = new System.Drawing.Point(95, 35);
            this.txtPrifix.Name = "txtPrifix";
            this.txtPrifix.Size = new System.Drawing.Size(145, 22);
            this.txtPrifix.TabIndex = 113;
            // 
            // chkItemSubCategory2Enabled
            // 
            this.chkItemSubCategory2Enabled.AutoSize = true;
            this.chkItemSubCategory2Enabled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemSubCategory2Enabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemSubCategory2Enabled.Location = new System.Drawing.Point(127, 66);
            this.chkItemSubCategory2Enabled.Name = "chkItemSubCategory2Enabled";
            this.chkItemSubCategory2Enabled.Size = new System.Drawing.Size(117, 18);
            this.chkItemSubCategory2Enabled.TabIndex = 118;
            this.chkItemSubCategory2Enabled.Text = "ItemSubCategory2";
            this.chkItemSubCategory2Enabled.UseVisualStyleBackColor = true;
            // 
            // chkSerialNo2
            // 
            this.chkSerialNo2.AutoSize = true;
            this.chkSerialNo2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSerialNo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkSerialNo2.Location = new System.Drawing.Point(341, 66);
            this.chkSerialNo2.Name = "chkSerialNo2";
            this.chkSerialNo2.Size = new System.Drawing.Size(77, 18);
            this.chkSerialNo2.TabIndex = 117;
            this.chkSerialNo2.Text = "Serial No2";
            this.chkSerialNo2.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblType.Location = new System.Drawing.Point(253, 12);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(64, 14);
            this.lblType.TabIndex = 106;
            this.lblType.Text = "Type Name";
            // 
            // txtTypeName
            // 
            this.txtTypeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeName.Location = new System.Drawing.Point(341, 9);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            this.txtTypeName.Size = new System.Drawing.Size(207, 22);
            this.txtTypeName.TabIndex = 105;
            this.txtTypeName.Text = "Plastic Bag";
            this.txtTypeName.DoubleClick += new System.EventHandler(this.txtTypeName_DoubleClick);
            this.txtTypeName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTypeName_KeyUp);
            // 
            // lblBankID
            // 
            this.lblBankID.AutoSize = true;
            this.lblBankID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankID.Location = new System.Drawing.Point(7, 12);
            this.lblBankID.Name = "lblBankID";
            this.lblBankID.Size = new System.Drawing.Size(65, 14);
            this.lblBankID.TabIndex = 72;
            this.lblBankID.Text = "Category ID";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(253, 40);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(84, 14);
            this.lblBankName.TabIndex = 104;
            this.lblBankName.Text = "Category Name";
            // 
            // chkItemSubCategoryEnabled
            // 
            this.chkItemSubCategoryEnabled.AutoSize = true;
            this.chkItemSubCategoryEnabled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemSubCategoryEnabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemSubCategoryEnabled.Location = new System.Drawing.Point(10, 66);
            this.chkItemSubCategoryEnabled.Name = "chkItemSubCategoryEnabled";
            this.chkItemSubCategoryEnabled.Size = new System.Drawing.Size(111, 18);
            this.chkItemSubCategoryEnabled.TabIndex = 115;
            this.chkItemSubCategoryEnabled.Text = "ItemSubCategory";
            this.chkItemSubCategoryEnabled.UseVisualStyleBackColor = true;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(341, 37);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(207, 22);
            this.txtCategoryName.TabIndex = 1;
            this.txtCategoryName.Text = "Plastic Bag";
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryID.Location = new System.Drawing.Point(95, 9);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(145, 22);
            this.txtCategoryID.TabIndex = 0;
            this.txtCategoryID.DoubleClick += new System.EventHandler(this.txtCategoryID_DoubleClick);
            this.txtCategoryID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(367, 141);
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
            this.btnSave.Location = new System.Drawing.Point(521, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "Category ID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Width = 68;
            // 
            // Prifix
            // 
            this.Prifix.HeaderText = "Prifix";
            this.Prifix.Name = "Prifix";
            this.Prifix.Width = 53;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Width = 170;
            // 
            // SubCategory
            // 
            this.SubCategory.HeaderText = "SubCategory";
            this.SubCategory.Name = "SubCategory";
            this.SubCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SubCategory.Width = 75;
            // 
            // SubCategory2
            // 
            this.SubCategory2.HeaderText = "SubCategory2";
            this.SubCategory2.Name = "SubCategory2";
            this.SubCategory2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubCategory2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SubCategory2.Width = 80;
            // 
            // SerialNo
            // 
            this.SerialNo.HeaderText = "Serial No";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SerialNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SerialNo.Width = 60;
            // 
            // SerialNo2
            // 
            this.SerialNo2.HeaderText = "Serial No2";
            this.SerialNo2.Name = "SerialNo2";
            this.SerialNo2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SerialNo2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SerialNo2.Width = 80;
            // 
            // frm_mtrItemCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(604, 432);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrItemCategory";
            this.Text = "Item Category Master";
            this.Load += new System.EventHandler(this.frm_mtrItemCategory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrItemCategory_KeyDown);
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
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label lblPrifix;
        private System.Windows.Forms.TextBox txtPrifix;
        private System.Windows.Forms.CheckBox chkSerialNo;
        private System.Windows.Forms.CheckBox chkItemSubCategory2Enabled;
        private System.Windows.Forms.CheckBox chkSerialNo2;
        private System.Windows.Forms.CheckBox chkItemSubCategoryEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prifix;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SubCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SubCategory2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SerialNo2;

    }
}