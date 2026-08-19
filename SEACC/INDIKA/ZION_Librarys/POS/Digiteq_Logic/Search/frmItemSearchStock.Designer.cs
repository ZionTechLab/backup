namespace Digiteq
{
    partial class frmItemSearchStock
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
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtSectionID = new System.Windows.Forms.TextBox();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.txtStoreID = new System.Windows.Forms.TextBox();
            this.chkItemName = new System.Windows.Forms.CheckBox();
            this.chkItemSubCategory = new System.Windows.Forms.CheckBox();
            this.chkItemCode = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.BackColor = System.Drawing.Color.White;
            this.txtSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory.Location = new System.Drawing.Point(101, 40);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(155, 22);
            this.txtSubCategory.TabIndex = 2;
            this.txtSubCategory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory_KeyUp);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(101, 10);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(270, 22);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyUp);
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(471, 10);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(155, 22);
            this.txtItemCode.TabIndex = 1;
            this.txtItemCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyUp);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnClose.Image = global::Digiteq.Properties.Resources.delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(551, 38);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         //   this.btnSelect.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(471, 39);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 25);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "  Ok";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtSectionID
            // 
            this.txtSectionID.BackColor = System.Drawing.SystemColors.Control;
            this.txtSectionID.Enabled = false;
            this.txtSectionID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSectionID.Location = new System.Drawing.Point(212, 189);
            this.txtSectionID.Name = "txtSectionID";
            this.txtSectionID.Size = new System.Drawing.Size(26, 22);
            this.txtSectionID.TabIndex = 13;
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.BackColor = System.Drawing.SystemColors.Control;
            this.txtDepartmentID.Enabled = false;
            this.txtDepartmentID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentID.Location = new System.Drawing.Point(110, 189);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(26, 22);
            this.txtDepartmentID.TabIndex = 12;
            // 
            // txtStoreID
            // 
            this.txtStoreID.BackColor = System.Drawing.SystemColors.Control;
            this.txtStoreID.Enabled = false;
            this.txtStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreID.Location = new System.Drawing.Point(75, 200);
            this.txtStoreID.Name = "txtStoreID";
            this.txtStoreID.Size = new System.Drawing.Size(26, 22);
            this.txtStoreID.TabIndex = 11;
            // 
            // chkItemName
            // 
            this.chkItemName.AutoSize = true;
            this.chkItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemName.Location = new System.Drawing.Point(10, 12);
            this.chkItemName.Name = "chkItemName";
            this.chkItemName.Size = new System.Drawing.Size(82, 18);
            this.chkItemName.TabIndex = 5;
            this.chkItemName.Text = "Item Name";
            this.chkItemName.UseVisualStyleBackColor = true;
            this.chkItemName.CheckedChanged += new System.EventHandler(this.chkItemName_CheckedChanged);
            // 
            // chkItemSubCategory
            // 
            this.chkItemSubCategory.AutoSize = true;
            this.chkItemSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemSubCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemSubCategory.Location = new System.Drawing.Point(9, 45);
            this.chkItemSubCategory.Name = "chkItemSubCategory";
            this.chkItemSubCategory.Size = new System.Drawing.Size(91, 18);
            this.chkItemSubCategory.TabIndex = 7;
            this.chkItemSubCategory.Text = "Sub Category";
            this.chkItemSubCategory.UseVisualStyleBackColor = true;
            this.chkItemSubCategory.CheckedChanged += new System.EventHandler(this.chkItemSubCategory_CheckedChanged);
            // 
            // chkItemCode
            // 
            this.chkItemCode.AutoSize = true;
            this.chkItemCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemCode.Location = new System.Drawing.Point(377, 14);
            this.chkItemCode.Name = "chkItemCode";
            this.chkItemCode.Size = new System.Drawing.Size(76, 18);
            this.chkItemCode.TabIndex = 6;
            this.chkItemCode.Text = "Item Code";
            this.chkItemCode.UseVisualStyleBackColor = true;
            this.chkItemCode.CheckedChanged += new System.EventHandler(this.chkItemCode_CheckedChanged);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.CategoryID,
            this.SubCategoryID,
            this.ItemName,
            this.CategoryName,
            this.SubCategoryName,
            this.PartNo,
            this.SerialNo,
            this.Qty,
            this.Weight});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 68);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(616, 468);
            this.dgvDetail.TabIndex = 1;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "ItemCode";
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.Width = 80;
            // 
            // CategoryID
            // 
            this.CategoryID.DataPropertyName = "CategoryID";
            this.CategoryID.HeaderText = "CategoryID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Visible = false;
            // 
            // SubCategoryID
            // 
            this.SubCategoryID.DataPropertyName = "SubCategoryID";
            this.SubCategoryID.HeaderText = "SubCategoryID";
            this.SubCategoryID.Name = "SubCategoryID";
            this.SubCategoryID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Description";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 227;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Width = 125;
            // 
            // SubCategoryName
            // 
            this.SubCategoryName.DataPropertyName = "SubCategoryName";
            this.SubCategoryName.HeaderText = "Sub Category Name";
            this.SubCategoryName.Name = "SubCategoryName";
            this.SubCategoryName.Visible = false;
            this.SubCategoryName.Width = 112;
            // 
            // PartNo
            // 
            this.PartNo.DataPropertyName = "PartNo";
            this.PartNo.HeaderText = "Part No";
            this.PartNo.Name = "PartNo";
            this.PartNo.Visible = false;
            this.PartNo.Width = 90;
            // 
            // SerialNo
            // 
            this.SerialNo.DataPropertyName = "SerialNo";
            this.SerialNo.HeaderText = "Serial No";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Visible = false;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle2;
            this.Qty.HeaderText = "Quantity";
            this.Qty.Name = "Qty";
            this.Qty.Width = 90;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle3;
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.Width = 90;
            // 
            // frmItemSearchStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(634, 544);
            this.ControlBox = false;
            this.Controls.Add(this.chkItemName);
            this.Controls.Add(this.chkItemSubCategory);
            this.Controls.Add(this.chkItemCode);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.txtSectionID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDepartmentID);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtStoreID);
            this.Controls.Add(this.txtSubCategory);
            this.Controls.Add(this.txtItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmItemSearchStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmItemSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.CheckBox chkItemName;
        private System.Windows.Forms.CheckBox chkItemSubCategory;
        private System.Windows.Forms.CheckBox chkItemCode;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox txtStoreID;
        private System.Windows.Forms.TextBox txtSectionID;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
    }
}