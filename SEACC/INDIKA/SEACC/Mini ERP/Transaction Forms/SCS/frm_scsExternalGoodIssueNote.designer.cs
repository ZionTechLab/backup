namespace Digiteq
{
    partial class frm_scsExternalGoodIssueNote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new SEACC_DataGrid();
            this.RowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRNID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsTiep = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z1 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.x1 = new System.Windows.Forms.Panel();
            this.lblIssuedRefNo = new System.Windows.Forms.Label();
            this.txtSupplierRefNo = new System.Windows.Forms.TextBox();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.txtStoreID = new System.Windows.Forms.TextBox();
            this.lblStoreID = new System.Windows.Forms.Label();
            this.dtpGINDate = new System.Windows.Forms.DateTimePicker();
            this.label34 = new System.Windows.Forms.Label();
            this.txtGINID = new System.Windows.Forms.TextBox();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemSerialNo = new System.Windows.Forms.TextBox();
            this.txtItemSubCategory = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.x2 = new System.Windows.Forms.Panel();
            this.chkFreeIssue = new System.Windows.Forms.CheckBox();
            this.rdoSampleIssued = new System.Windows.Forms.RadioButton();
            this.rdoGeneralIssued = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.xSetting = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.chkReverseCalculation = new System.Windows.Forms.CheckBox();
            this.chkUnitPricing = new System.Windows.Forms.CheckBox();
            this.zpnlSetting1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.rdoSupplier = new System.Windows.Forms.RadioButton();
            this.rdoCustomer = new System.Windows.Forms.RadioButton();
            this.rdoDepartment = new System.Windows.Forms.RadioButton();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.x1.SuspendLayout();
            this.x2.SuspendLayout();
            this.xSetting.SuspendLayout();
            this.zpnlSetting1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.RowCount,
            this.LineNo,
            this.ItemCode,
            this.ItemName,
            this.ItemSubCategoryID1,
            this.ItemSubCategoryID2,
            this.ItemSerialNo1,
            this.ItemSerialNo2,
            this.POID,
            this.PRNID,
            this.Batch,
            this.IsTiep,
            this.UOM,
            this.Quantity,
            this.UnitPrice,
            this.Weight,
            this.WeightPrice,
            this.Amount,
            this.Warranty,
            this.ItemStatus,
            this.Remarks});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 172);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(828, 283);
            this.dgvDetail.TabIndex = 471;
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDetail_CellParsing);
            // 
            // RowCount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RowCount.DefaultCellStyle = dataGridViewCellStyle9;
            this.RowCount.HeaderText = "#";
            this.RowCount.Name = "RowCount";
            this.RowCount.ReadOnly = true;
            this.RowCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowCount.Width = 20;
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "LN";
            this.LineNo.Name = "LineNo";
            this.LineNo.ReadOnly = true;
            this.LineNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LineNo.Visible = false;
            this.LineNo.Width = 20;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 90;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 330;
            // 
            // ItemSubCategoryID1
            // 
            this.ItemSubCategoryID1.HeaderText = "ItemSubCategoryID1";
            this.ItemSubCategoryID1.Name = "ItemSubCategoryID1";
            this.ItemSubCategoryID1.ReadOnly = true;
            this.ItemSubCategoryID1.Visible = false;
            // 
            // ItemSubCategoryID2
            // 
            this.ItemSubCategoryID2.HeaderText = "ItemSubCategoryID2";
            this.ItemSubCategoryID2.Name = "ItemSubCategoryID2";
            this.ItemSubCategoryID2.Visible = false;
            // 
            // ItemSerialNo1
            // 
            this.ItemSerialNo1.HeaderText = "ItemSerialNo1";
            this.ItemSerialNo1.Name = "ItemSerialNo1";
            this.ItemSerialNo1.Visible = false;
            // 
            // ItemSerialNo2
            // 
            this.ItemSerialNo2.HeaderText = "ItemSerialNo2";
            this.ItemSerialNo2.Name = "ItemSerialNo2";
            this.ItemSerialNo2.Visible = false;
            // 
            // POID
            // 
            this.POID.HeaderText = "PurchaseOrderID";
            this.POID.Name = "POID";
            this.POID.ReadOnly = true;
            this.POID.Visible = false;
            // 
            // PRNID
            // 
            this.PRNID.HeaderText = "PRN";
            this.PRNID.Name = "PRNID";
            this.PRNID.Visible = false;
            // 
            // Batch
            // 
            this.Batch.HeaderText = "Batch #";
            this.Batch.Name = "Batch";
            this.Batch.Visible = false;
            this.Batch.Width = 50;
            // 
            // IsTiep
            // 
            this.IsTiep.HeaderText = "TIEP";
            this.IsTiep.Name = "IsTiep";
            this.IsTiep.ReadOnly = true;
            this.IsTiep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsTiep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsTiep.Visible = false;
            this.IsTiep.Width = 35;
            // 
            // UOM
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UOM.DefaultCellStyle = dataGridViewCellStyle10;
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            this.UOM.Width = 50;
            // 
            // Quantity
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle11;
            this.Quantity.HeaderText = "Quantity ";
            this.Quantity.Name = "Quantity";
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Width = 80;
            // 
            // Weight
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle13;
            this.Weight.HeaderText = "Weight [kg]";
            this.Weight.Name = "Weight";
            this.Weight.Visible = false;
            // 
            // WeightPrice
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.WeightPrice.DefaultCellStyle = dataGridViewCellStyle14;
            this.WeightPrice.HeaderText = "WeightPrice";
            this.WeightPrice.Name = "WeightPrice";
            this.WeightPrice.Width = 80;
            // 
            // Amount
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle15;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Visible = false;
            // 
            // Warranty
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Warranty.DefaultCellStyle = dataGridViewCellStyle16;
            this.Warranty.HeaderText = "Warranty [Month]";
            this.Warranty.Name = "Warranty";
            this.Warranty.Visible = false;
            this.Warranty.Width = 105;
            // 
            // ItemStatus
            // 
            this.ItemStatus.HeaderText = "ItemStatus";
            this.ItemStatus.Name = "ItemStatus";
            this.ItemStatus.Visible = false;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 105;
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Location = new System.Drawing.Point(79, 288);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(571, 67);
            this.z1.TabIndex = 464;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(63, 5);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(330, 61);
            this.txtRemark.TabIndex = 437;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 426;
            this.label7.Text = "Remarks";
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.White;
            this.x1.Controls.Add(this.lblIssuedRefNo);
            this.x1.Controls.Add(this.txtSupplierRefNo);
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Controls.Add(this.txtStoreID);
            this.x1.Controls.Add(this.lblStoreID);
            this.x1.Controls.Add(this.dtpGINDate);
            this.x1.Controls.Add(this.label34);
            this.x1.Controls.Add(this.txtGINID);
            this.x1.Controls.Add(this.lblInvoiceID);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(8, 7);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(283, 126);
            this.x1.TabIndex = 449;
            // 
            // lblIssuedRefNo
            // 
            this.lblIssuedRefNo.AutoSize = true;
            this.lblIssuedRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuedRefNo.ForeColor = System.Drawing.Color.Black;
            this.lblIssuedRefNo.Location = new System.Drawing.Point(8, 98);
            this.lblIssuedRefNo.Name = "lblIssuedRefNo";
            this.lblIssuedRefNo.Size = new System.Drawing.Size(46, 14);
            this.lblIssuedRefNo.TabIndex = 544;
            this.lblIssuedRefNo.Text = "Ref. No.";
            // 
            // txtSupplierRefNo
            // 
            this.txtSupplierRefNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierRefNo.Location = new System.Drawing.Point(76, 94);
            this.txtSupplierRefNo.Name = "txtSupplierRefNo";
            this.txtSupplierRefNo.Size = new System.Drawing.Size(197, 22);
            this.txtSupplierRefNo.TabIndex = 545;
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(184, 13);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 543;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(187, 12);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 495;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // txtStoreID
            // 
            this.txtStoreID.BackColor = System.Drawing.Color.LightGray;
            this.txtStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreID.Location = new System.Drawing.Point(76, 66);
            this.txtStoreID.Name = "txtStoreID";
            this.txtStoreID.ReadOnly = true;
            this.txtStoreID.Size = new System.Drawing.Size(197, 22);
            this.txtStoreID.TabIndex = 274;
            this.txtStoreID.Text = "Trading Stock";
            this.txtStoreID.DoubleClick += new System.EventHandler(this.txtStoreID_DoubleClick);
            this.txtStoreID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStoreID_KeyDown);
            // 
            // lblStoreID
            // 
            this.lblStoreID.AutoSize = true;
            this.lblStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreID.ForeColor = System.Drawing.Color.Black;
            this.lblStoreID.Location = new System.Drawing.Point(7, 69);
            this.lblStoreID.Name = "lblStoreID";
            this.lblStoreID.Size = new System.Drawing.Size(66, 14);
            this.lblStoreID.TabIndex = 275;
            this.lblStoreID.Text = "Store Name";
            // 
            // dtpGINDate
            // 
            this.dtpGINDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpGINDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGINDate.Location = new System.Drawing.Point(76, 38);
            this.dtpGINDate.Name = "dtpGINDate";
            this.dtpGINDate.Size = new System.Drawing.Size(102, 22);
            this.dtpGINDate.TabIndex = 4;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(8, 40);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(31, 14);
            this.label34.TabIndex = 356;
            this.label34.Text = "Date";
            // 
            // txtGINID
            // 
            this.txtGINID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtGINID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGINID.Location = new System.Drawing.Point(76, 10);
            this.txtGINID.Name = "txtGINID";
            this.txtGINID.Size = new System.Drawing.Size(102, 22);
            this.txtGINID.TabIndex = 0;
            this.txtGINID.Text = "GN005";
            this.txtGINID.DoubleClick += new System.EventHandler(this.txtInvoiceID_DoubleClick);
            this.txtGINID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceID_KeyDown);
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceID.Location = new System.Drawing.Point(8, 13);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(46, 14);
            this.lblInvoiceID.TabIndex = 276;
            this.lblInvoiceID.Text = "GIN No.";
            // 
            // txtOther
            // 
            this.txtOther.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOther.Location = new System.Drawing.Point(94, 90);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(145, 22);
            this.txtOther.TabIndex = 470;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 459;
            this.label2.Text = "Item Name";
            // 
            // txtItemSerialNo
            // 
            this.txtItemSerialNo.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSerialNo.Location = new System.Drawing.Point(27, 10);
            this.txtItemSerialNo.Name = "txtItemSerialNo";
            this.txtItemSerialNo.ReadOnly = true;
            this.txtItemSerialNo.Size = new System.Drawing.Size(13, 22);
            this.txtItemSerialNo.TabIndex = 499;
            this.txtItemSerialNo.Visible = false;
            // 
            // txtItemSubCategory
            // 
            this.txtItemSubCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubCategory.Location = new System.Drawing.Point(40, 9);
            this.txtItemSubCategory.Name = "txtItemSubCategory";
            this.txtItemSubCategory.ReadOnly = true;
            this.txtItemSubCategory.Size = new System.Drawing.Size(13, 22);
            this.txtItemSubCategory.TabIndex = 498;
            this.txtItemSubCategory.Visible = false;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddItem.Location = new System.Drawing.Point(252, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(22, 22);
            this.btnAddItem.TabIndex = 461;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.BackColor = System.Drawing.Color.LightGray;
            this.txtItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(80, 10);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(170, 22);
            this.txtItemID.TabIndex = 460;
            this.txtItemID.DoubleClick += new System.EventHandler(this.txtItemID_DoubleClick);
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyDown);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(761, 141);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.TabIndex = 463;
            this.btnRemove.Text = "Grid Del";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.x2.Controls.Add(this.chkFreeIssue);
            this.x2.Controls.Add(this.rdoSampleIssued);
            this.x2.Controls.Add(this.rdoGeneralIssued);
            this.x2.Controls.Add(this.label3);
            this.x2.Controls.Add(this.label2);
            this.x2.Controls.Add(this.txtItemSerialNo);
            this.x2.Controls.Add(this.txtItemSubCategory);
            this.x2.Controls.Add(this.txtItemID);
            this.x2.Controls.Add(this.btnAddItem);
            this.x2.Location = new System.Drawing.Point(549, 7);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(287, 126);
            this.x2.TabIndex = 448;
            // 
            // chkFreeIssue
            // 
            this.chkFreeIssue.AutoSize = true;
            this.chkFreeIssue.Enabled = false;
            this.chkFreeIssue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFreeIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkFreeIssue.Location = new System.Drawing.Point(80, 91);
            this.chkFreeIssue.Name = "chkFreeIssue";
            this.chkFreeIssue.Size = new System.Drawing.Size(76, 18);
            this.chkFreeIssue.TabIndex = 503;
            this.chkFreeIssue.Text = "Free Issue";
            this.chkFreeIssue.UseVisualStyleBackColor = true;
            this.chkFreeIssue.Visible = false;
            // 
            // rdoSampleIssued
            // 
            this.rdoSampleIssued.AutoSize = true;
            this.rdoSampleIssued.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSampleIssued.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSampleIssued.Location = new System.Drawing.Point(80, 70);
            this.rdoSampleIssued.Name = "rdoSampleIssued";
            this.rdoSampleIssued.Size = new System.Drawing.Size(96, 18);
            this.rdoSampleIssued.TabIndex = 502;
            this.rdoSampleIssued.Text = "Sample Issued";
            this.rdoSampleIssued.UseVisualStyleBackColor = true;
            // 
            // rdoGeneralIssued
            // 
            this.rdoGeneralIssued.AutoSize = true;
            this.rdoGeneralIssued.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGeneralIssued.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoGeneralIssued.Location = new System.Drawing.Point(80, 44);
            this.rdoGeneralIssued.Name = "rdoGeneralIssued";
            this.rdoGeneralIssued.Size = new System.Drawing.Size(98, 18);
            this.rdoGeneralIssued.TabIndex = 501;
            this.rdoGeneralIssued.Text = "General Issued";
            this.rdoGeneralIssued.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 500;
            this.label3.Text = "Issued Type";
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.LightGray;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.btn_Close);
            this.xSetting.Controls.Add(this.label16);
            this.xSetting.Controls.Add(this.chkReverseCalculation);
            this.xSetting.Controls.Add(this.chkUnitPricing);
            this.xSetting.Location = new System.Drawing.Point(631, 7);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(204, 88);
            this.xSetting.TabIndex = 541;
            this.xSetting.Visible = false;
            this.xSetting.Leave += new System.EventHandler(this.xSetting_Leave);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(171, 1);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 28);
            this.btn_Close.TabIndex = 471;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label16.Location = new System.Drawing.Point(6, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 14);
            this.label16.TabIndex = 453;
            this.label16.Text = "SPECIAL SETTINGS";
            // 
            // chkReverseCalculation
            // 
            this.chkReverseCalculation.AutoSize = true;
            this.chkReverseCalculation.Enabled = false;
            this.chkReverseCalculation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReverseCalculation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkReverseCalculation.Location = new System.Drawing.Point(27, 22);
            this.chkReverseCalculation.Name = "chkReverseCalculation";
            this.chkReverseCalculation.Size = new System.Drawing.Size(116, 18);
            this.chkReverseCalculation.TabIndex = 452;
            this.chkReverseCalculation.Text = "VAT/NBT Excluded";
            this.chkReverseCalculation.UseVisualStyleBackColor = true;
            this.chkReverseCalculation.Visible = false;
            // 
            // chkUnitPricing
            // 
            this.chkUnitPricing.AutoSize = true;
            this.chkUnitPricing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnitPricing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkUnitPricing.Location = new System.Drawing.Point(27, 44);
            this.chkUnitPricing.Name = "chkUnitPricing";
            this.chkUnitPricing.Size = new System.Drawing.Size(134, 18);
            this.chkUnitPricing.TabIndex = 464;
            this.chkUnitPricing.Text = "Issued by Weight/Qty";
            this.chkUnitPricing.UseVisualStyleBackColor = true;
            this.chkUnitPricing.CheckedChanged += new System.EventHandler(this.chkUnitPricing_CheckedChanged);
            // 
            // zpnlSetting1
            // 
            this.zpnlSetting1.BackColor = System.Drawing.Color.White;
            this.zpnlSetting1.Controls.Add(this.label7);
            this.zpnlSetting1.Controls.Add(this.txtRemark);
            this.zpnlSetting1.Location = new System.Drawing.Point(431, 461);
            this.zpnlSetting1.Name = "zpnlSetting1";
            this.zpnlSetting1.Size = new System.Drawing.Size(405, 72);
            this.zpnlSetting1.TabIndex = 548;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.rdoOther);
            this.panel1.Controls.Add(this.rdoSupplier);
            this.panel1.Controls.Add(this.rdoCustomer);
            this.panel1.Controls.Add(this.rdoDepartment);
            this.panel1.Controls.Add(this.txtSupplierID);
            this.panel1.Controls.Add(this.txtCustomerID);
            this.panel1.Controls.Add(this.txtDepartmentID);
            this.panel1.Controls.Add(this.txtOther);
            this.panel1.Location = new System.Drawing.Point(297, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 126);
            this.panel1.TabIndex = 549;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOther.ForeColor = System.Drawing.Color.Black;
            this.rdoOther.Location = new System.Drawing.Point(6, 91);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(53, 18);
            this.rdoOther.TabIndex = 472;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            this.rdoOther.CheckedChanged += new System.EventHandler(this.rdoOther_CheckedChanged);
            // 
            // rdoSupplier
            // 
            this.rdoSupplier.AutoSize = true;
            this.rdoSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSupplier.ForeColor = System.Drawing.Color.Black;
            this.rdoSupplier.Location = new System.Drawing.Point(6, 64);
            this.rdoSupplier.Name = "rdoSupplier";
            this.rdoSupplier.Size = new System.Drawing.Size(65, 18);
            this.rdoSupplier.TabIndex = 472;
            this.rdoSupplier.Text = "Supplier";
            this.rdoSupplier.UseVisualStyleBackColor = true;
            this.rdoSupplier.CheckedChanged += new System.EventHandler(this.rdoSupplier_CheckedChanged);
            // 
            // rdoCustomer
            // 
            this.rdoCustomer.AutoSize = true;
            this.rdoCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustomer.ForeColor = System.Drawing.Color.Black;
            this.rdoCustomer.Location = new System.Drawing.Point(6, 37);
            this.rdoCustomer.Name = "rdoCustomer";
            this.rdoCustomer.Size = new System.Drawing.Size(72, 18);
            this.rdoCustomer.TabIndex = 472;
            this.rdoCustomer.Text = "Customer";
            this.rdoCustomer.UseVisualStyleBackColor = true;
            this.rdoCustomer.CheckedChanged += new System.EventHandler(this.rdoCustomer_CheckedChanged);
            // 
            // rdoDepartment
            // 
            this.rdoDepartment.AutoSize = true;
            this.rdoDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDepartment.ForeColor = System.Drawing.Color.Black;
            this.rdoDepartment.Location = new System.Drawing.Point(6, 10);
            this.rdoDepartment.Name = "rdoDepartment";
            this.rdoDepartment.Size = new System.Drawing.Size(85, 18);
            this.rdoDepartment.TabIndex = 472;
            this.rdoDepartment.Text = "Department";
            this.rdoDepartment.UseVisualStyleBackColor = true;
            this.rdoDepartment.CheckedChanged += new System.EventHandler(this.rdoDepartment_CheckedChanged);
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.Color.LightGray;
            this.txtSupplierID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierID.Location = new System.Drawing.Point(94, 63);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(145, 22);
            this.txtSupplierID.TabIndex = 471;
            this.txtSupplierID.DoubleClick += new System.EventHandler(this.txtSupplierID_DoubleClick);
            this.txtSupplierID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierID_KeyDown);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(94, 36);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(145, 22);
            this.txtCustomerID.TabIndex = 469;
            this.txtCustomerID.DoubleClick += new System.EventHandler(this.txtCustomerID_DoubleClick);
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.BackColor = System.Drawing.Color.LightGray;
            this.txtDepartmentID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentID.Location = new System.Drawing.Point(94, 9);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.ReadOnly = true;
            this.txtDepartmentID.Size = new System.Drawing.Size(145, 22);
            this.txtDepartmentID.TabIndex = 467;
            this.txtDepartmentID.DoubleClick += new System.EventHandler(this.txtDepartmentID_DoubleClick);
            this.txtDepartmentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartmentID_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(300, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 402;
            this.label1.Text = "Invoice Number";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(390, 236);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(177, 22);
            this.txtInvoiceNo.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(293, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 114);
            this.panel2.TabIndex = 558;
            // 
            // chkPrintOriginal
            // 
            this.chkPrintOriginal.AutoSize = true;
            this.chkPrintOriginal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPrintOriginal.Location = new System.Drawing.Point(27, 66);
            this.chkPrintOriginal.Name = "chkPrintOriginal";
            this.chkPrintOriginal.Size = new System.Drawing.Size(91, 18);
            this.chkPrintOriginal.TabIndex = 472;
            this.chkPrintOriginal.Text = "Print Original";
            this.chkPrintOriginal.UseVisualStyleBackColor = true;
            // 
            // frm_scsExternalGoodIssueNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.xSetting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.zpnlSetting1);
            this.Controls.Add(this.x2);
            this.Name = "frm_scsExternalGoodIssueNote";
            this.Size = new System.Drawing.Size(844, 590);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsExternalGoodIssueNote_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasCustomerInvoice_KeyDown);
            this.Controls.SetChildIndex(this.x2, 0);
            this.Controls.SetChildIndex(this.zpnlSetting1, 0);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtInvoiceNo, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.xSetting, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.zpnlSetting1.ResumeLayout(false);
            this.zpnlSetting1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.DateTimePicker dtpGINDate;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtGINID;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemove;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.Label lblStoreID;
        private System.Windows.Forms.TextBox txtStoreID;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemSerialNo;
        private System.Windows.Forms.TextBox txtItemSubCategory;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkReverseCalculation;
        private System.Windows.Forms.CheckBox chkUnitPricing;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.Panel zpnlSetting1;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label lblIssuedRefNo;
        private System.Windows.Forms.TextBox txtSupplierRefNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.RadioButton rdoSupplier;
        private System.Windows.Forms.RadioButton rdoCustomer;
        private System.Windows.Forms.RadioButton rdoDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.RadioButton rdoSampleIssued;
        private System.Windows.Forms.RadioButton rdoGeneralIssued;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFreeIssue;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn POID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRNID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsTiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
    }
}