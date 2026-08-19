namespace Digiteq
{
    partial class frm_scsDiscardedGoodNote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.x1 = new System.Windows.Forms.Panel();
            this.txtStoreID = new System.Windows.Forms.TextBox();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.dtpDGNDate = new System.Windows.Forms.DateTimePicker();
            this.label34 = new System.Windows.Forms.Label();
            this.txtDINID = new System.Windows.Forms.TextBox();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.x2 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.xSetting = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.chkUnitPricing = new System.Windows.Forms.CheckBox();
            this.dgvDetail = new SEACC_DataGrid();
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
            this.z2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.x1.SuspendLayout();
            this.x2.SuspendLayout();
            this.xSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.z2.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.White;
            this.x1.Controls.Add(this.txtStoreID);
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.lblStore);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Controls.Add(this.dtpDGNDate);
            this.x1.Controls.Add(this.label34);
            this.x1.Controls.Add(this.txtDINID);
            this.x1.Controls.Add(this.lblInvoiceID);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(342, 90);
            this.x1.TabIndex = 449;
            // 
            // txtStoreID
            // 
            this.txtStoreID.BackColor = System.Drawing.Color.LightGray;
            this.txtStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreID.Location = new System.Drawing.Point(87, 59);
            this.txtStoreID.Name = "txtStoreID";
            this.txtStoreID.ReadOnly = true;
            this.txtStoreID.Size = new System.Drawing.Size(236, 22);
            this.txtStoreID.TabIndex = 471;
            this.txtStoreID.DoubleClick += new System.EventHandler(this.txtStoreID_DoubleClick);
            this.txtStoreID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStoreID_KeyDown);
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(228, 9);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(95, 14);
            this.lblCancelled.TabIndex = 545;
            this.lblCancelled.Text = "CANCELLED NOTE";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.ForeColor = System.Drawing.Color.Black;
            this.lblStore.Location = new System.Drawing.Point(11, 62);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(66, 14);
            this.lblStore.TabIndex = 470;
            this.lblStore.Text = "Store Name";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(231, 8);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 544;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // dtpDGNDate
            // 
            this.dtpDGNDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDGNDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDGNDate.Location = new System.Drawing.Point(88, 32);
            this.dtpDGNDate.Name = "dtpDGNDate";
            this.dtpDGNDate.Size = new System.Drawing.Size(128, 22);
            this.dtpDGNDate.TabIndex = 4;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(11, 36);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 14);
            this.label34.TabIndex = 356;
            this.label34.Text = "DIN Date";
            // 
            // txtDINID
            // 
            this.txtDINID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtDINID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDINID.Location = new System.Drawing.Point(88, 6);
            this.txtDINID.Name = "txtDINID";
            this.txtDINID.Size = new System.Drawing.Size(128, 22);
            this.txtDINID.TabIndex = 0;
            this.txtDINID.Text = "GN005";
            this.txtDINID.DoubleClick += new System.EventHandler(this.txtDINID_DoubleClick);
            this.txtDINID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDINID_KeyDown);
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceID.Location = new System.Drawing.Point(11, 10);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(53, 14);
            this.lblInvoiceID.TabIndex = 276;
            this.lblInvoiceID.Text = "DIN Code";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(85, 8);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(371, 46);
            this.txtRemark.TabIndex = 437;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 426;
            this.label7.Text = "Remarks";
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.White;
            this.x2.Controls.Add(this.txtRemark);
            this.x2.Controls.Add(this.label7);
            this.x2.Location = new System.Drawing.Point(356, 8);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(480, 90);
            this.x2.TabIndex = 472;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(761, 103);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.TabIndex = 463;
            this.btnRemove.Text = "Grid Del";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.LightGray;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.btn_Close);
            this.xSetting.Controls.Add(this.label16);
            this.xSetting.Controls.Add(this.chkUnitPricing);
            this.xSetting.Location = new System.Drawing.Point(643, 8);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(189, 76);
            this.xSetting.TabIndex = 542;
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
            this.btn_Close.Location = new System.Drawing.Point(158, 1);
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
            this.label16.Location = new System.Drawing.Point(6, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 14);
            this.label16.TabIndex = 453;
            this.label16.Text = "SPECIAL SETTINGS";
            // 
            // chkUnitPricing
            // 
            this.chkUnitPricing.AutoSize = true;
            this.chkUnitPricing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnitPricing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkUnitPricing.Location = new System.Drawing.Point(25, 23);
            this.chkUnitPricing.Name = "chkUnitPricing";
            this.chkUnitPricing.Size = new System.Drawing.Size(124, 18);
            this.chkUnitPricing.TabIndex = 464;
            this.chkUnitPricing.Text = "Weight/Qty Pricing ";
            this.chkUnitPricing.UseVisualStyleBackColor = true;
            this.chkUnitPricing.CheckedChanged += new System.EventHandler(this.chkUnitPricing_CheckedChanged);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 32;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvDetail.Location = new System.Drawing.Point(8, 133);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(828, 313);
            this.dgvDetail.TabIndex = 543;
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDetail_CellParsing);
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
            this.ItemName.Width = 280;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UOM.DefaultCellStyle = dataGridViewCellStyle8;
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            this.UOM.Width = 50;
            // 
            // Quantity
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle9;
            this.Quantity.HeaderText = "Damaged Qty";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.UnitPrice.HeaderText = "Discarding Qty";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Width = 80;
            // 
            // Weight
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle11;
            this.Weight.HeaderText = "Damaged Weight [kg]";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Visible = false;
            this.Weight.Width = 80;
            // 
            // WeightPrice
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.WeightPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.WeightPrice.HeaderText = "Discarding Weight";
            this.WeightPrice.Name = "WeightPrice";
            this.WeightPrice.Width = 80;
            // 
            // Amount
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle13;
            this.Amount.HeaderText = "Salvage Value";
            this.Amount.Name = "Amount";
            // 
            // Warranty
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Warranty.DefaultCellStyle = dataGridViewCellStyle14;
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
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.Gainsboro;
            this.z2.Controls.Add(this.label6);
            this.z2.Controls.Add(this.txtGrandTotal);
            this.z2.Location = new System.Drawing.Point(609, 452);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(227, 42);
            this.z2.TabIndex = 544;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(8, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 399;
            this.label6.Text = "Grand Total";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(82, 8);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(131, 23);
            this.txtGrandTotal.TabIndex = 5;
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkPrintOriginal
            // 
            this.chkPrintOriginal.AutoSize = true;
            this.chkPrintOriginal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPrintOriginal.Location = new System.Drawing.Point(25, 47);
            this.chkPrintOriginal.Name = "chkPrintOriginal";
            this.chkPrintOriginal.Size = new System.Drawing.Size(91, 18);
            this.chkPrintOriginal.TabIndex = 472;
            this.chkPrintOriginal.Text = "Print Original";
            this.chkPrintOriginal.UseVisualStyleBackColor = true;
            // 
            // frm_scsDiscardedGoodNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.xSetting);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.x2);
            this.Name = "frm_scsDiscardedGoodNote";
            this.Size = new System.Drawing.Size(844, 548);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsDiscardedGoodNote_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasCustomerInvoice_KeyDown);
            this.Controls.SetChildIndex(this.x2, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.z2, 0);
            this.Controls.SetChildIndex(this.xSetting, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.z2.ResumeLayout(false);
            this.z2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.DateTimePicker dtpDGNDate;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtDINID;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.TextBox txtStoreID;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkUnitPricing;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Button btn_Close;
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
        private System.Windows.Forms.CheckBox chkPrintOriginal;
    }
}