namespace Digiteq
{
    partial class frm_masItemMasterFinance
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
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.chkItemCode = new System.Windows.Forms.CheckBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.chkRefNo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.chkItemName = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.chkPartNo = new System.Windows.Forms.CheckBox();
            this.chkItemSubCategory1 = new System.Windows.Forms.CheckBox();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.txtSubCategory2 = new System.Windows.Forms.TextBox();
            this.chkItemSubCategory2 = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.item_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSubCategory_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSubCategory2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSerialNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kiloPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPrice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPrice4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPrice5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholesalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategoryNameTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategoryName2Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceRs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsVATInclusive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsNBTInclusive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.xpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.xpanel1.Controls.Add(this.chkItemCode);
            this.xpanel1.Controls.Add(this.txtItemCode);
            this.xpanel1.Controls.Add(this.txtRefNo);
            this.xpanel1.Controls.Add(this.chkRefNo);
            this.xpanel1.Controls.Add(this.label2);
            this.xpanel1.Controls.Add(this.txtBranchID);
            this.xpanel1.Controls.Add(this.btnNew);
            this.xpanel1.Controls.Add(this.lblCustomerName);
            this.xpanel1.Controls.Add(this.txtCustomer);
            this.xpanel1.Controls.Add(this.txtItemName);
            this.xpanel1.Controls.Add(this.chkItemName);
            this.xpanel1.Controls.Add(this.btnCancel);
            this.xpanel1.Controls.Add(this.btnSave);
            this.xpanel1.Controls.Add(this.txtSubCategory);
            this.xpanel1.Controls.Add(this.chkPartNo);
            this.xpanel1.Controls.Add(this.chkItemSubCategory1);
            this.xpanel1.Controls.Add(this.txtPartNo);
            this.xpanel1.Controls.Add(this.txtSubCategory2);
            this.xpanel1.Controls.Add(this.chkItemSubCategory2);
            this.xpanel1.Location = new System.Drawing.Point(8, 34);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(828, 114);
            this.xpanel1.TabIndex = 0;
            this.xpanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.xpanel1_Paint);
            // 
            // chkItemCode
            // 
            this.chkItemCode.AutoSize = true;
            this.chkItemCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemCode.Location = new System.Drawing.Point(6, 12);
            this.chkItemCode.Name = "chkItemCode";
            this.chkItemCode.Size = new System.Drawing.Size(76, 18);
            this.chkItemCode.TabIndex = 593;
            this.chkItemCode.Text = "Item Code";
            this.chkItemCode.UseVisualStyleBackColor = true;
            this.chkItemCode.CheckedChanged += new System.EventHandler(this.chkItemCode_CheckedChanged);
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(115, 9);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(228, 22);
            this.txtItemCode.TabIndex = 592;
            this.txtItemCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyUp);
            // 
            // txtRefNo
            // 
            this.txtRefNo.BackColor = System.Drawing.Color.White;
            this.txtRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNo.Location = new System.Drawing.Point(115, 60);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(228, 22);
            this.txtRefNo.TabIndex = 590;
            this.txtRefNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRefNo_KeyUp);
            // 
            // chkRefNo
            // 
            this.chkRefNo.AutoSize = true;
            this.chkRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkRefNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkRefNo.Location = new System.Drawing.Point(6, 63);
            this.chkRefNo.Name = "chkRefNo";
            this.chkRefNo.Size = new System.Drawing.Size(60, 18);
            this.chkRefNo.TabIndex = 591;
            this.chkRefNo.Text = "Ref No";
            this.chkRefNo.UseVisualStyleBackColor = true;
            this.chkRefNo.CheckedChanged += new System.EventHandler(this.chkRefNo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(4, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 587;
            this.label2.Text = "Branch Name";
            // 
            // txtBranchID
            // 
            this.txtBranchID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtBranchID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(115, 86);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(228, 22);
            this.txtBranchID.TabIndex = 586;
            this.txtBranchID.DoubleClick += new System.EventHandler(this.txtBranchID_DoubleClick);
            this.txtBranchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.accept;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(563, 86);
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
            this.lblCustomerName.Location = new System.Drawing.Point(438, 64);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(87, 14);
            this.lblCustomerName.TabIndex = 584;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(563, 61);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(237, 22);
            this.txtCustomer.TabIndex = 583;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(563, 10);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(236, 22);
            this.txtItemName.TabIndex = 570;
            this.txtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyUp);
            // 
            // chkItemName
            // 
            this.chkItemName.AutoSize = true;
            this.chkItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemName.Location = new System.Drawing.Point(437, 12);
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
            this.btnCancel.Location = new System.Drawing.Point(725, 86);
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
            this.btnSave.Location = new System.Drawing.Point(649, 86);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 568;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.BackColor = System.Drawing.Color.White;
            this.txtSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory.Location = new System.Drawing.Point(563, 36);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(237, 22);
            this.txtSubCategory.TabIndex = 571;
            this.txtSubCategory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory_KeyUp);
            // 
            // chkPartNo
            // 
            this.chkPartNo.AutoSize = true;
            this.chkPartNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPartNo.Location = new System.Drawing.Point(6, 37);
            this.chkPartNo.Name = "chkPartNo";
            this.chkPartNo.Size = new System.Drawing.Size(63, 18);
            this.chkPartNo.TabIndex = 580;
            this.chkPartNo.Text = "Part No";
            this.chkPartNo.UseVisualStyleBackColor = true;
            this.chkPartNo.CheckedChanged += new System.EventHandler(this.chkPartNo_CheckedChanged);
            // 
            // chkItemSubCategory1
            // 
            this.chkItemSubCategory1.AutoSize = true;
            this.chkItemSubCategory1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkItemSubCategory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkItemSubCategory1.Location = new System.Drawing.Point(437, 40);
            this.chkItemSubCategory1.Name = "chkItemSubCategory1";
            this.chkItemSubCategory1.Size = new System.Drawing.Size(100, 18);
            this.chkItemSubCategory1.TabIndex = 578;
            this.chkItemSubCategory1.Text = "Sub Category 1";
            this.chkItemSubCategory1.UseVisualStyleBackColor = true;
            this.chkItemSubCategory1.CheckedChanged += new System.EventHandler(this.chkItemSubCategory2_CheckedChanged);
            // 
            // txtPartNo
            // 
            this.txtPartNo.BackColor = System.Drawing.Color.White;
            this.txtPartNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNo.Location = new System.Drawing.Point(115, 35);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(228, 22);
            this.txtPartNo.TabIndex = 573;
            this.txtPartNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPartNo_KeyUp);
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
            this.item_ID,
            this.ItemName,
            this.LineNo,
            this.itemSerialNo,
            this.itemSubCategory_ID,
            this.itemSubCategory2_ID,
            this.itemSerialNo2,
            this.costPriceReal,
            this.costPrice,
            this.kiloPrice,
            this.sellingPrice2,
            this.sellingPrice3,
            this.sellingPrice4,
            this.sellingPrice5,
            this.wholesalePrice,
            this.SubCategoryNameTag,
            this.SubCategoryName2Tag,
            this.sellingPrice1,
            this.sellingPriceRs,
            this.IsVATInclusive,
            this.IsNBTInclusive});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 156);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(828, 511);
            this.dgvDetail.TabIndex = 567;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // item_ID
            // 
            this.item_ID.DataPropertyName = "item_ID";
            this.item_ID.HeaderText = "Item ID";
            this.item_ID.Name = "item_ID";
            this.item_ID.ReadOnly = true;
            this.item_ID.Width = 130;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 575;
            // 
            // LineNo
            // 
            this.LineNo.DataPropertyName = "LineNo";
            this.LineNo.HeaderText = "Line #";
            this.LineNo.Name = "LineNo";
            this.LineNo.Visible = false;
            this.LineNo.Width = 50;
            // 
            // itemSerialNo
            // 
            this.itemSerialNo.DataPropertyName = "itemSerialNo";
            this.itemSerialNo.HeaderText = "Part No.";
            this.itemSerialNo.Name = "itemSerialNo";
            this.itemSerialNo.Visible = false;
            this.itemSerialNo.Width = 157;
            // 
            // itemSubCategory_ID
            // 
            this.itemSubCategory_ID.DataPropertyName = "itemSubCategory_ID";
            this.itemSubCategory_ID.HeaderText = "itemSubCategory_ID";
            this.itemSubCategory_ID.Name = "itemSubCategory_ID";
            this.itemSubCategory_ID.ReadOnly = true;
            this.itemSubCategory_ID.Visible = false;
            this.itemSubCategory_ID.Width = 270;
            // 
            // itemSubCategory2_ID
            // 
            this.itemSubCategory2_ID.DataPropertyName = "itemSubCategory2_ID";
            this.itemSubCategory2_ID.HeaderText = "itemSubCategory2_ID";
            this.itemSubCategory2_ID.Name = "itemSubCategory2_ID";
            this.itemSubCategory2_ID.ReadOnly = true;
            this.itemSubCategory2_ID.Visible = false;
            // 
            // itemSerialNo2
            // 
            this.itemSerialNo2.DataPropertyName = "itemSerialNo2";
            this.itemSerialNo2.HeaderText = "itemSerialNo2";
            this.itemSerialNo2.Name = "itemSerialNo2";
            this.itemSerialNo2.Visible = false;
            // 
            // costPriceReal
            // 
            this.costPriceReal.DataPropertyName = "costPriceReal";
            this.costPriceReal.HeaderText = "Cost Price Real";
            this.costPriceReal.Name = "costPriceReal";
            this.costPriceReal.Visible = false;
            // 
            // costPrice
            // 
            this.costPrice.DataPropertyName = "costPrice";
            this.costPrice.HeaderText = "Cost Price";
            this.costPrice.Name = "costPrice";
            this.costPrice.Visible = false;
            // 
            // kiloPrice
            // 
            this.kiloPrice.HeaderText = "Kilo Price";
            this.kiloPrice.Name = "kiloPrice";
            this.kiloPrice.Visible = false;
            // 
            // sellingPrice2
            // 
            this.sellingPrice2.HeaderText = "Selling Price 2";
            this.sellingPrice2.Name = "sellingPrice2";
            this.sellingPrice2.Visible = false;
            // 
            // sellingPrice3
            // 
            this.sellingPrice3.HeaderText = "Selling Price 3";
            this.sellingPrice3.Name = "sellingPrice3";
            this.sellingPrice3.Visible = false;
            // 
            // sellingPrice4
            // 
            this.sellingPrice4.HeaderText = "Selling Price 4";
            this.sellingPrice4.Name = "sellingPrice4";
            this.sellingPrice4.Visible = false;
            // 
            // sellingPrice5
            // 
            this.sellingPrice5.HeaderText = "Selling Price 5";
            this.sellingPrice5.Name = "sellingPrice5";
            this.sellingPrice5.Visible = false;
            // 
            // wholesalePrice
            // 
            this.wholesalePrice.HeaderText = "Wholesale Price";
            this.wholesalePrice.Name = "wholesalePrice";
            this.wholesalePrice.Visible = false;
            // 
            // SubCategoryNameTag
            // 
            this.SubCategoryNameTag.DataPropertyName = "SubCategoryNameTag";
            this.SubCategoryNameTag.HeaderText = "SubCategoryNameTag";
            this.SubCategoryNameTag.Name = "SubCategoryNameTag";
            this.SubCategoryNameTag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SubCategoryNameTag.Visible = false;
            // 
            // SubCategoryName2Tag
            // 
            this.SubCategoryName2Tag.DataPropertyName = "SubCategoryName2Tag";
            this.SubCategoryName2Tag.HeaderText = "SubCategoryName2Tag";
            this.SubCategoryName2Tag.Name = "SubCategoryName2Tag";
            this.SubCategoryName2Tag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SubCategoryName2Tag.Visible = false;
            // 
            // sellingPrice1
            // 
            this.sellingPrice1.DataPropertyName = "sellingPrice1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sellingPrice1.DefaultCellStyle = dataGridViewCellStyle1;
            this.sellingPrice1.HeaderText = "Selling Price ";
            this.sellingPrice1.Name = "sellingPrice1";
            // 
            // sellingPriceRs
            // 
            this.sellingPriceRs.DataPropertyName = "sellingPriceRs";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sellingPriceRs.DefaultCellStyle = dataGridViewCellStyle2;
            this.sellingPriceRs.HeaderText = "Selling Price Rs";
            this.sellingPriceRs.Name = "sellingPriceRs";
            this.sellingPriceRs.ReadOnly = true;
            this.sellingPriceRs.Visible = false;
            // 
            // IsVATInclusive
            // 
            this.IsVATInclusive.DataPropertyName = "IsVATInclusive";
            this.IsVATInclusive.HeaderText = "VAT Incl.";
            this.IsVATInclusive.Name = "IsVATInclusive";
            this.IsVATInclusive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsVATInclusive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsVATInclusive.Visible = false;
            this.IsVATInclusive.Width = 60;
            // 
            // IsNBTInclusive
            // 
            this.IsNBTInclusive.DataPropertyName = "IsNBTInclusive";
            this.IsNBTInclusive.HeaderText = "NBT Incl.";
            this.IsNBTInclusive.Name = "IsNBTInclusive";
            this.IsNBTInclusive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsNBTInclusive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsNBTInclusive.Visible = false;
            this.IsNBTInclusive.Width = 60;
            // 
            // frm_masItemMasterFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(844, 674);
            this.Controls.Add(this.xpanel1);
            this.Controls.Add(this.dgvDetail);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_masItemMasterFinance";
            this.Text = "Item Finance";
            this.Load += new System.EventHandler(this.frm_masItemMasterFinance_Load);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.xpanel1, 0);
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xpanel1;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSubCategory2;
        private System.Windows.Forms.CheckBox chkPartNo;
        private System.Windows.Forms.CheckBox chkItemSubCategory2;
        private System.Windows.Forms.TextBox txtPartNo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.CheckBox chkRefNo;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.CheckBox chkItemName;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.CheckBox chkItemSubCategory1;
        private System.Windows.Forms.CheckBox chkItemCode;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSubCategory_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSubCategory2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSerialNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn kiloPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPrice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPrice4;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPrice5;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholesalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCategoryNameTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCategoryName2Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceRs;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsVATInclusive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNBTInclusive;

    }
}