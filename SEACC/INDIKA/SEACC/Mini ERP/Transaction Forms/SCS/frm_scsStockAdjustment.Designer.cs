namespace Digiteq
{
    partial class frm_scsStockAdjustment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnF5 = new System.Windows.Forms.Button();
            this.txtItemSerialNo = new System.Windows.Forms.TextBox();
            this.txtInputMaterialID = new System.Windows.Forms.TextBox();
            this.txtItemSubCategory = new System.Windows.Forms.TextBox();
            this.lblInputMaterialID = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRowNo = new System.Windows.Forms.TextBox();
            this.chkUnitPricing = new System.Windows.Forms.CheckBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblOutputAutoWeight = new System.Windows.Forms.Label();
            this.txtMaterialQty = new System.Windows.Forms.TextBox();
            this.lblOutputAutoUOM = new System.Windows.Forms.Label();
            this.btnInfoInputItem = new System.Windows.Forms.Button();
            this.txtSANID = new System.Windows.Forms.TextBox();
            this.lblSANCode = new System.Windows.Forms.Label();
            this.txtStoreID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpAdjustmentDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetail = new SEACC_DataGrid();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.x2 = new System.Windows.Forms.Panel();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.z1 = new System.Windows.Forms.Panel();
            this.xSetting = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gauge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gusset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectArea_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WACurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAEstimated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.x2.SuspendLayout();
            this.z1.SuspendLayout();
            this.xSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF5
            // 
            this.btnF5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF5.Location = new System.Drawing.Point(255, 61);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(27, 25);
            this.btnF5.TabIndex = 608;
            this.btnF5.Text = "F5";
            this.btnF5.UseVisualStyleBackColor = true;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // txtItemSerialNo
            // 
            this.txtItemSerialNo.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSerialNo.Location = new System.Drawing.Point(458, 51);
            this.txtItemSerialNo.Name = "txtItemSerialNo";
            this.txtItemSerialNo.ReadOnly = true;
            this.txtItemSerialNo.Size = new System.Drawing.Size(10, 22);
            this.txtItemSerialNo.TabIndex = 607;
            this.txtItemSerialNo.Visible = false;
            // 
            // txtInputMaterialID
            // 
            this.txtInputMaterialID.BackColor = System.Drawing.Color.LightGray;
            this.txtInputMaterialID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputMaterialID.Location = new System.Drawing.Point(84, 61);
            this.txtInputMaterialID.Name = "txtInputMaterialID";
            this.txtInputMaterialID.ReadOnly = true;
            this.txtInputMaterialID.Size = new System.Drawing.Size(164, 22);
            this.txtInputMaterialID.TabIndex = 592;
            this.txtInputMaterialID.DoubleClick += new System.EventHandler(this.txtInputMaterialID_DoubleClick);
            this.txtInputMaterialID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputMaterialID_KeyDown);
            // 
            // txtItemSubCategory
            // 
            this.txtItemSubCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubCategory.Location = new System.Drawing.Point(473, 51);
            this.txtItemSubCategory.Name = "txtItemSubCategory";
            this.txtItemSubCategory.ReadOnly = true;
            this.txtItemSubCategory.Size = new System.Drawing.Size(10, 22);
            this.txtItemSubCategory.TabIndex = 606;
            this.txtItemSubCategory.Visible = false;
            // 
            // lblInputMaterialID
            // 
            this.lblInputMaterialID.AutoSize = true;
            this.lblInputMaterialID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputMaterialID.ForeColor = System.Drawing.Color.Black;
            this.lblInputMaterialID.Location = new System.Drawing.Point(12, 65);
            this.lblInputMaterialID.Name = "lblInputMaterialID";
            this.lblInputMaterialID.Size = new System.Drawing.Size(63, 14);
            this.lblInputMaterialID.TabIndex = 593;
            this.lblInputMaterialID.Text = "Item Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Digiteq.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(284, 61);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 483;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRowNo
            // 
            this.txtRowNo.Location = new System.Drawing.Point(442, 51);
            this.txtRowNo.Name = "txtRowNo";
            this.txtRowNo.Size = new System.Drawing.Size(10, 22);
            this.txtRowNo.TabIndex = 603;
            this.txtRowNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRowNo.Visible = false;
            // 
            // chkUnitPricing
            // 
            this.chkUnitPricing.AutoSize = true;
            this.chkUnitPricing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnitPricing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkUnitPricing.Location = new System.Drawing.Point(476, 16);
            this.chkUnitPricing.Name = "chkUnitPricing";
            this.chkUnitPricing.Size = new System.Drawing.Size(124, 18);
            this.chkUnitPricing.TabIndex = 608;
            this.chkUnitPricing.Text = "Weight/Qty Pricing ";
            this.chkUnitPricing.UseVisualStyleBackColor = true;
            // 
            // txtWeight
            // 
            this.txtWeight.BackColor = System.Drawing.SystemColors.Window;
            this.txtWeight.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(209, 239);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(162, 22);
            this.txtWeight.TabIndex = 600;
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // lblOutputAutoWeight
            // 
            this.lblOutputAutoWeight.AutoSize = true;
            this.lblOutputAutoWeight.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputAutoWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOutputAutoWeight.Location = new System.Drawing.Point(125, 247);
            this.lblOutputAutoWeight.Name = "lblOutputAutoWeight";
            this.lblOutputAutoWeight.Size = new System.Drawing.Size(43, 14);
            this.lblOutputAutoWeight.TabIndex = 598;
            this.lblOutputAutoWeight.Text = "Weight";
            // 
            // txtMaterialQty
            // 
            this.txtMaterialQty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialQty.Location = new System.Drawing.Point(209, 265);
            this.txtMaterialQty.Name = "txtMaterialQty";
            this.txtMaterialQty.Size = new System.Drawing.Size(162, 22);
            this.txtMaterialQty.TabIndex = 602;
            this.txtMaterialQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaterialQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterialQty_KeyPress);
            // 
            // lblOutputAutoUOM
            // 
            this.lblOutputAutoUOM.AutoSize = true;
            this.lblOutputAutoUOM.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputAutoUOM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOutputAutoUOM.Location = new System.Drawing.Point(125, 273);
            this.lblOutputAutoUOM.Name = "lblOutputAutoUOM";
            this.lblOutputAutoUOM.Size = new System.Drawing.Size(51, 14);
            this.lblOutputAutoUOM.TabIndex = 601;
            this.lblOutputAutoUOM.Text = "Item Qty";
            // 
            // btnInfoInputItem
            // 
            this.btnInfoInputItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoInputItem.Image = global::Digiteq.Properties.Resources.info;
            this.btnInfoInputItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfoInputItem.Location = new System.Drawing.Point(456, 259);
            this.btnInfoInputItem.Name = "btnInfoInputItem";
            this.btnInfoInputItem.Size = new System.Drawing.Size(22, 22);
            this.btnInfoInputItem.TabIndex = 597;
            this.btnInfoInputItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInfoInputItem.UseVisualStyleBackColor = true;
            this.btnInfoInputItem.Click += new System.EventHandler(this.btnInfoInputItem_Click);
            // 
            // txtSANID
            // 
            this.txtSANID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtSANID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSANID.Location = new System.Drawing.Point(84, 8);
            this.txtSANID.Name = "txtSANID";
            this.txtSANID.Size = new System.Drawing.Size(139, 22);
            this.txtSANID.TabIndex = 1;
            this.txtSANID.Text = "GN005";
            this.txtSANID.DoubleClick += new System.EventHandler(this.txtSANID_DoubleClick);
            this.txtSANID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSANID_KeyDown);
            // 
            // lblSANCode
            // 
            this.lblSANCode.AutoSize = true;
            this.lblSANCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSANCode.ForeColor = System.Drawing.Color.Black;
            this.lblSANCode.Location = new System.Drawing.Point(12, 11);
            this.lblSANCode.Name = "lblSANCode";
            this.lblSANCode.Size = new System.Drawing.Size(55, 14);
            this.lblSANCode.TabIndex = 0;
            this.lblSANCode.Text = "SAN Code";
            // 
            // txtStoreID
            // 
            this.txtStoreID.BackColor = System.Drawing.Color.LightGray;
            this.txtStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreID.Location = new System.Drawing.Point(84, 89);
            this.txtStoreID.Name = "txtStoreID";
            this.txtStoreID.ReadOnly = true;
            this.txtStoreID.Size = new System.Drawing.Size(225, 22);
            this.txtStoreID.TabIndex = 591;
            this.txtStoreID.DoubleClick += new System.EventHandler(this.txtStoreID_DoubleClick);
            this.txtStoreID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStoreID_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 14);
            this.label7.TabIndex = 590;
            this.label7.Text = "Store Name";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(72, 7);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(413, 49);
            this.txtRemark.TabIndex = 412;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(7, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 413;
            this.label8.Text = "Remarks";
            // 
            // dtpAdjustmentDate
            // 
            this.dtpAdjustmentDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdjustmentDate.Location = new System.Drawing.Point(84, 34);
            this.dtpAdjustmentDate.Name = "dtpAdjustmentDate";
            this.dtpAdjustmentDate.Size = new System.Drawing.Size(139, 22);
            this.dtpAdjustmentDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.Note_ID,
            this.Amount,
            this.Width,
            this.Height,
            this.Gauge,
            this.Gusset,
            this.Remarks,
            this.WeightPrice,
            this.ItemSubCategoryID2,
            this.ItemSerialNo,
            this.ItemSerialNo2,
            this.ItemName,
            this.ItemSubCategoryID,
            this.ItemStatus,
            this.UnitPrice,
            this.Store_ID,
            this.QtyCurrent,
            this.Quantity,
            this.UOM,
            this.Weight,
            this.SelectArea_ID,
            this.Department_ID,
            this.Section_ID,
            this.WACurrent,
            this.WAEstimated});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 157);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(844, 335);
            this.dgvDetail.TabIndex = 476;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(772, 128);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.TabIndex = 480;
            this.btnRemove.Text = "Grid Del";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(566, 271);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 479;
            this.btnDelete.Text = "Cancel  ";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.White;
            this.x2.Controls.Add(this.btnF5);
            this.x2.Controls.Add(this.lblCancelled);
            this.x2.Controls.Add(this.label2);
            this.x2.Controls.Add(this.btnAdd);
            this.x2.Controls.Add(this.chkShowSettle);
            this.x2.Controls.Add(this.dtpAdjustmentDate);
            this.x2.Controls.Add(this.label7);
            this.x2.Controls.Add(this.txtSANID);
            this.x2.Controls.Add(this.txtInputMaterialID);
            this.x2.Controls.Add(this.lblSANCode);
            this.x2.Controls.Add(this.txtStoreID);
            this.x2.Controls.Add(this.lblInputMaterialID);
            this.x2.Location = new System.Drawing.Point(8, 7);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(346, 117);
            this.x2.TabIndex = 604;
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(232, 12);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 612;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(247, 10);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 611;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.White;
            this.z1.Controls.Add(this.xSetting);
            this.z1.Controls.Add(this.txtRemark);
            this.z1.Controls.Add(this.txtItemSerialNo);
            this.z1.Controls.Add(this.txtItemSubCategory);
            this.z1.Controls.Add(this.label8);
            this.z1.Controls.Add(this.txtRowNo);
            this.z1.Location = new System.Drawing.Point(360, 7);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(494, 117);
            this.z1.TabIndex = 605;
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.Gainsboro;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.button1);
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.label3);
            this.xSetting.Location = new System.Drawing.Point(331, 0);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(163, 57);
            this.xSetting.TabIndex = 608;
            this.xSetting.Visible = false;
            this.xSetting.Leave += new System.EventHandler(this.xSetting_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(130, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 28);
            this.button1.TabIndex = 470;
            this.button1.Text = "";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkPrintOriginal
            // 
            this.chkPrintOriginal.AutoSize = true;
            this.chkPrintOriginal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPrintOriginal.Location = new System.Drawing.Point(29, 30);
            this.chkPrintOriginal.Name = "chkPrintOriginal";
            this.chkPrintOriginal.Size = new System.Drawing.Size(91, 18);
            this.chkPrintOriginal.TabIndex = 469;
            this.chkPrintOriginal.Text = "Print Original";
            this.chkPrintOriginal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 453;
            this.label3.Text = "Special Settings";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(356, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 114);
            this.panel2.TabIndex = 609;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            // 
            // Note_ID
            // 
            this.Note_ID.HeaderText = "Note ID";
            this.Note_ID.Name = "Note_ID";
            this.Note_ID.Visible = false;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Visible = false;
            // 
            // Width
            // 
            this.Width.HeaderText = "Width";
            this.Width.Name = "Width";
            this.Width.Visible = false;
            // 
            // Height
            // 
            this.Height.HeaderText = "Height";
            this.Height.Name = "Height";
            this.Height.Visible = false;
            // 
            // Gauge
            // 
            this.Gauge.HeaderText = "Gauge";
            this.Gauge.Name = "Gauge";
            this.Gauge.Visible = false;
            // 
            // Gusset
            // 
            this.Gusset.HeaderText = "Gusset";
            this.Gusset.Name = "Gusset";
            this.Gusset.Visible = false;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // WeightPrice
            // 
            this.WeightPrice.HeaderText = "WeightPrice";
            this.WeightPrice.Name = "WeightPrice";
            this.WeightPrice.Visible = false;
            // 
            // ItemSubCategoryID2
            // 
            this.ItemSubCategoryID2.HeaderText = "ItemSubCategoryID2";
            this.ItemSubCategoryID2.Name = "ItemSubCategoryID2";
            this.ItemSubCategoryID2.Visible = false;
            // 
            // ItemSerialNo
            // 
            this.ItemSerialNo.HeaderText = "ItemSerialNo1";
            this.ItemSerialNo.Name = "ItemSerialNo";
            this.ItemSerialNo.Visible = false;
            // 
            // ItemSerialNo2
            // 
            this.ItemSerialNo2.HeaderText = "ItemSerialNo2";
            this.ItemSerialNo2.Name = "ItemSerialNo2";
            this.ItemSerialNo2.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Description";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // ItemSubCategoryID
            // 
            this.ItemSubCategoryID.HeaderText = "ItemSubCategoryID";
            this.ItemSubCategoryID.Name = "ItemSubCategoryID";
            this.ItemSubCategoryID.Width = 180;
            // 
            // ItemStatus
            // 
            this.ItemStatus.HeaderText = "Item Status";
            this.ItemStatus.Name = "ItemStatus";
            this.ItemStatus.Visible = false;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Store_ID
            // 
            this.Store_ID.HeaderText = "Store Name";
            this.Store_ID.Name = "Store_ID";
            this.Store_ID.Visible = false;
            this.Store_ID.Width = 150;
            // 
            // QtyCurrent
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyCurrent.DefaultCellStyle = dataGridViewCellStyle2;
            this.QtyCurrent.HeaderText = "System Qty";
            this.QtyCurrent.Name = "QtyCurrent";
            this.QtyCurrent.ReadOnly = true;
            this.QtyCurrent.Visible = false;
            // 
            // Quantity
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            this.UOM.Width = 40;
            // 
            // Weight
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle4;
            this.Weight.HeaderText = "Weight [Kg]";
            this.Weight.Name = "Weight";
            this.Weight.Visible = false;
            this.Weight.Width = 90;
            // 
            // SelectArea_ID
            // 
            this.SelectArea_ID.HeaderText = "SelectArea_ID";
            this.SelectArea_ID.Name = "SelectArea_ID";
            this.SelectArea_ID.Visible = false;
            // 
            // Department_ID
            // 
            this.Department_ID.HeaderText = "Department_ID";
            this.Department_ID.Name = "Department_ID";
            this.Department_ID.Visible = false;
            // 
            // Section_ID
            // 
            this.Section_ID.HeaderText = "Section_ID";
            this.Section_ID.Name = "Section_ID";
            this.Section_ID.Visible = false;
            // 
            // WACurrent
            // 
            this.WACurrent.HeaderText = "W/A Current";
            this.WACurrent.Name = "WACurrent";
            this.WACurrent.ReadOnly = true;
            // 
            // WAEstimated
            // 
            this.WAEstimated.HeaderText = "W/A Estimated";
            this.WAEstimated.Name = "WAEstimated";
            this.WAEstimated.ReadOnly = true;
            this.WAEstimated.Visible = false;
            // 
            // frm_scsStockAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnInfoInputItem);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblOutputAutoWeight);
            this.Controls.Add(this.txtMaterialQty);
            this.Controls.Add(this.lblOutputAutoUOM);
            this.Controls.Add(this.chkUnitPricing);
            this.Name = "frm_scsStockAdjustment";
            this.Size = new System.Drawing.Size(858, 546);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStockAdjustment_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.frm_scsStockAdjustment_Load);
            this.Controls.SetChildIndex(this.chkUnitPricing, 0);
            this.Controls.SetChildIndex(this.lblOutputAutoUOM, 0);
            this.Controls.SetChildIndex(this.txtMaterialQty, 0);
            this.Controls.SetChildIndex(this.lblOutputAutoWeight, 0);
            this.Controls.SetChildIndex(this.txtWeight, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnInfoInputItem, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.x2, 0);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAdjustmentDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSANID;
        private System.Windows.Forms.Label lblSANCode;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox txtMaterialQty;
        private System.Windows.Forms.Label lblOutputAutoUOM;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblOutputAutoWeight;
        private System.Windows.Forms.TextBox txtStoreID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtRowNo;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Button btnInfoInputItem;
        private System.Windows.Forms.TextBox txtInputMaterialID;
        private System.Windows.Forms.Label lblInputMaterialID;
        private System.Windows.Forms.TextBox txtItemSerialNo;
        private System.Windows.Forms.TextBox txtItemSubCategory;
        private System.Windows.Forms.CheckBox chkUnitPricing;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Button btnF5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gauge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gusset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectArea_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WACurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAEstimated;
    }
}