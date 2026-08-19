namespace Digiteq
{
    partial class frm_masItemMasterCustomerWiseSalesCode
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
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.chkItemID = new System.Windows.Forms.CheckBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.chkItemCatagory = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.chkItemName = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.chkItemClass = new System.Windows.Forms.CheckBox();
            this.chkItemType = new System.Windows.Forms.CheckBox();
            this.txtItemClass = new System.Windows.Forms.TextBox();
            this.txtSubCategory2 = new System.Windows.Forms.TextBox();
            this.chkItemSubCategory2 = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSubCategory_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSubCategory2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pluCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.xpanel1.Controls.Add(this.chkItemID);
            this.xpanel1.Controls.Add(this.txtItemID);
            this.xpanel1.Controls.Add(this.txtItemCategory);
            this.xpanel1.Controls.Add(this.chkItemCatagory);
            this.xpanel1.Controls.Add(this.label2);
            this.xpanel1.Controls.Add(this.txtBranchID);
            this.xpanel1.Controls.Add(this.btnNew);
            this.xpanel1.Controls.Add(this.lblCustomerName);
            this.xpanel1.Controls.Add(this.txtCustomer);
            this.xpanel1.Controls.Add(this.txtItemName);
            this.xpanel1.Controls.Add(this.chkItemName);
            this.xpanel1.Controls.Add(this.btnCancel);
            this.xpanel1.Controls.Add(this.btnSave);
            this.xpanel1.Controls.Add(this.txtItemType);
            this.xpanel1.Controls.Add(this.chkItemClass);
            this.xpanel1.Controls.Add(this.chkItemType);
            this.xpanel1.Controls.Add(this.txtItemClass);
            this.xpanel1.Controls.Add(this.txtSubCategory2);
            this.xpanel1.Controls.Add(this.chkItemSubCategory2);
            this.xpanel1.Location = new System.Drawing.Point(8, 34);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(828, 147);
            this.xpanel1.TabIndex = 0;
            // 
            // chkItemID
            // 
            this.chkItemID.AutoSize = true;
            this.chkItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemID.Location = new System.Drawing.Point(14, 11);
            this.chkItemID.Name = "chkItemID";
            this.chkItemID.Size = new System.Drawing.Size(63, 18);
            this.chkItemID.TabIndex = 593;
            this.chkItemID.Text = "Item ID";
            this.chkItemID.UseVisualStyleBackColor = true;
            this.chkItemID.CheckedChanged += new System.EventHandler(this.chkItemID_CheckedChanged);
            // 
            // txtItemID
            // 
            this.txtItemID.BackColor = System.Drawing.Color.White;
            this.txtItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(116, 8);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(310, 22);
            this.txtItemID.TabIndex = 592;
            this.txtItemID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyUp);
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.BackColor = System.Drawing.Color.White;
            this.txtItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.Location = new System.Drawing.Point(116, 116);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.Size = new System.Drawing.Size(310, 22);
            this.txtItemCategory.TabIndex = 590;
            this.txtItemCategory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemCategory_KeyUp);
            // 
            // chkItemCatagory
            // 
            this.chkItemCatagory.AutoSize = true;
            this.chkItemCatagory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemCatagory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemCatagory.Location = new System.Drawing.Point(13, 118);
            this.chkItemCatagory.Name = "chkItemCatagory";
            this.chkItemCatagory.Size = new System.Drawing.Size(96, 18);
            this.chkItemCatagory.TabIndex = 591;
            this.chkItemCatagory.Text = "Item Category";
            this.chkItemCatagory.UseVisualStyleBackColor = true;
            this.chkItemCatagory.CheckedChanged += new System.EventHandler(this.chkItemCategory_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(456, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 587;
            this.label2.Text = "Branch Name";
            this.label2.Visible = false;
            // 
            // txtBranchID
            // 
            this.txtBranchID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtBranchID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(553, 62);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(259, 22);
            this.txtBranchID.TabIndex = 586;
            this.txtBranchID.Visible = false;
            this.txtBranchID.DoubleClick += new System.EventHandler(this.txtBranchID_DoubleClick);
            this.txtBranchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.accept;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(553, 93);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 23);
            this.btnNew.TabIndex = 585;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomerName.Location = new System.Drawing.Point(456, 39);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(87, 14);
            this.lblCustomerName.TabIndex = 584;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(553, 34);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(259, 22);
            this.txtCustomer.TabIndex = 583;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(116, 35);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(310, 22);
            this.txtItemName.TabIndex = 570;
            this.txtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyUp);
            // 
            // chkItemName
            // 
            this.chkItemName.AutoSize = true;
            this.chkItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemName.Location = new System.Drawing.Point(14, 39);
            this.chkItemName.Name = "chkItemName";
            this.chkItemName.Size = new System.Drawing.Size(82, 18);
            this.chkItemName.TabIndex = 579;
            this.chkItemName.Text = "Item Name";
            this.chkItemName.UseVisualStyleBackColor = true;
            this.chkItemName.CheckedChanged += new System.EventHandler(this.chkItemName_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(737, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 569;
            this.btnCancel.Text = "   Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(649, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 568;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtItemType
            // 
            this.txtItemType.BackColor = System.Drawing.Color.White;
            this.txtItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemType.Location = new System.Drawing.Point(116, 89);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.Size = new System.Drawing.Size(310, 22);
            this.txtItemType.TabIndex = 571;
            this.txtItemType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemType_KeyUp);
            // 
            // chkItemClass
            // 
            this.chkItemClass.AutoSize = true;
            this.chkItemClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemClass.Location = new System.Drawing.Point(14, 66);
            this.chkItemClass.Name = "chkItemClass";
            this.chkItemClass.Size = new System.Drawing.Size(77, 18);
            this.chkItemClass.TabIndex = 580;
            this.chkItemClass.Text = "Item Class";
            this.chkItemClass.UseVisualStyleBackColor = true;
            this.chkItemClass.CheckedChanged += new System.EventHandler(this.chkItemClass_CheckedChanged);
            // 
            // chkItemType
            // 
            this.chkItemType.AutoSize = true;
            this.chkItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemType.Location = new System.Drawing.Point(13, 91);
            this.chkItemType.Name = "chkItemType";
            this.chkItemType.Size = new System.Drawing.Size(76, 18);
            this.chkItemType.TabIndex = 578;
            this.chkItemType.Text = "Item Type";
            this.chkItemType.UseVisualStyleBackColor = true;
            this.chkItemType.CheckedChanged += new System.EventHandler(this.chkItemType_CheckedChanged);
            // 
            // txtItemClass
            // 
            this.txtItemClass.BackColor = System.Drawing.Color.White;
            this.txtItemClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemClass.Location = new System.Drawing.Point(116, 62);
            this.txtItemClass.Name = "txtItemClass";
            this.txtItemClass.Size = new System.Drawing.Size(310, 22);
            this.txtItemClass.TabIndex = 573;
            this.txtItemClass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemClass_KeyUp);
            // 
            // txtSubCategory2
            // 
            this.txtSubCategory2.BackColor = System.Drawing.Color.White;
            this.txtSubCategory2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory2.Location = new System.Drawing.Point(453, 177);
            this.txtSubCategory2.Name = "txtSubCategory2";
            this.txtSubCategory2.Size = new System.Drawing.Size(152, 22);
            this.txtSubCategory2.TabIndex = 574;
            this.txtSubCategory2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory2_KeyUp);
            // 
            // chkItemSubCategory2
            // 
            this.chkItemSubCategory2.AutoSize = true;
            this.chkItemSubCategory2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemSubCategory2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemSubCategory2.Location = new System.Drawing.Point(364, 179);
            this.chkItemSubCategory2.Name = "chkItemSubCategory2";
            this.chkItemSubCategory2.Size = new System.Drawing.Size(100, 18);
            this.chkItemSubCategory2.TabIndex = 577;
            this.chkItemSubCategory2.Text = "Sub Category 2";
            this.chkItemSubCategory2.UseVisualStyleBackColor = true;
            this.chkItemSubCategory2.CheckedChanged += new System.EventHandler(this.chkItemSubCategory_CheckedChanged);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.item_ID,
            this.ItemName,
            this.itemSubCategory_ID,
            this.itemSubCategory2_ID,
            this.serialNo1,
            this.serialNo2,
            this.itemClass,
            this.ItemType,
            this.itemCategory,
            this.pluCode});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 189);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(828, 480);
            this.dgvDetail.TabIndex = 567;
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.LineNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.LineNo.HeaderText = "Line #";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.Width = 50;
            // 
            // item_ID
            // 
            this.item_ID.DataPropertyName = "item_ID";
            this.item_ID.HeaderText = "Item ID";
            this.item_ID.Name = "item_ID";
            this.item_ID.ReadOnly = true;
            this.item_ID.Width = 80;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 250;
            // 
            // itemSubCategory_ID
            // 
            this.itemSubCategory_ID.DataPropertyName = "itemSubCategory_ID";
            this.itemSubCategory_ID.HeaderText = "Sub Category 1";
            this.itemSubCategory_ID.Name = "itemSubCategory_ID";
            this.itemSubCategory_ID.ReadOnly = true;
            this.itemSubCategory_ID.Visible = false;
            this.itemSubCategory_ID.Width = 270;
            // 
            // itemSubCategory2_ID
            // 
            this.itemSubCategory2_ID.DataPropertyName = "itemSubCategory2_ID";
            this.itemSubCategory2_ID.HeaderText = "Sub Category 2";
            this.itemSubCategory2_ID.Name = "itemSubCategory2_ID";
            this.itemSubCategory2_ID.ReadOnly = true;
            this.itemSubCategory2_ID.Visible = false;
            // 
            // serialNo1
            // 
            this.serialNo1.DataPropertyName = "serialNo1";
            this.serialNo1.HeaderText = "Serial No 1";
            this.serialNo1.Name = "serialNo1";
            this.serialNo1.ReadOnly = true;
            this.serialNo1.Visible = false;
            // 
            // serialNo2
            // 
            this.serialNo2.DataPropertyName = "serialNo2";
            this.serialNo2.HeaderText = "Searial No 2";
            this.serialNo2.Name = "serialNo2";
            this.serialNo2.ReadOnly = true;
            this.serialNo2.Visible = false;
            // 
            // itemClass
            // 
            this.itemClass.DataPropertyName = "itemClass";
            this.itemClass.HeaderText = "Item Class";
            this.itemClass.Name = "itemClass";
            this.itemClass.ReadOnly = true;
            this.itemClass.Width = 110;
            // 
            // ItemType
            // 
            this.ItemType.DataPropertyName = "ItemType";
            this.ItemType.HeaderText = "Item Type";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            this.ItemType.Width = 110;
            // 
            // itemCategory
            // 
            this.itemCategory.DataPropertyName = "itemCategory";
            this.itemCategory.HeaderText = "Item Category";
            this.itemCategory.Name = "itemCategory";
            this.itemCategory.ReadOnly = true;
            this.itemCategory.Width = 110;
            // 
            // pluCode
            // 
            this.pluCode.DataPropertyName = "pluCode";
            this.pluCode.HeaderText = "PLU Code";
            this.pluCode.Name = "pluCode";
            // 
            // frm_masItemMasterCustomerWiseSalesCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(844, 679);
            this.Controls.Add(this.xpanel1);
            this.Controls.Add(this.dgvDetail);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_masItemMasterCustomerWiseSalesCode";
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.xpanel1, 0);
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xpanel1;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSubCategory2;
        private System.Windows.Forms.CheckBox chkItemSubCategory2;
        private System.Windows.Forms.TextBox txtItemClass;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.CheckBox chkItemName;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.CheckBox chkItemType;
        private System.Windows.Forms.CheckBox chkItemID;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.CheckBox chkItemCatagory;
        private System.Windows.Forms.CheckBox chkItemClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSubCategory_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSubCategory2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn pluCode;
    }
}