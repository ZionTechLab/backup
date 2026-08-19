namespace Digiteq
{
    partial class frm_scsStoreProduction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.z2 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.Lineno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storeProduction_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subcategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategory2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightWestage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightRejection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gWeightPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1 = new System.Windows.Forms.Panel();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.chkShowSettle = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.dtpFGTNDate = new System.Windows.Forms.DateTimePicker();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.btnF5 = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemSerialNo = new System.Windows.Forms.TextBox();
            this.txtItemSubCategory = new System.Windows.Forms.TextBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.x2 = new System.Windows.Forms.Panel();
            this.cmbItemPrice = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtJobCode = new System.Windows.Forms.TextBox();
            this.lblJobCode = new System.Windows.Forms.Label();
            this.btnAddQuotation = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.xSetting = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chkPrintOriginal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.z2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.x1.SuspendLayout();
            this.x2.SuspendLayout();
            this.xSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.White;
            this.z2.Controls.Add(this.txtRemark);
            this.z2.Controls.Add(this.lblRemark);
            this.z2.Location = new System.Drawing.Point(8, 317);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(717, 45);
            this.z2.TabIndex = 14;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(62, 4);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(340, 38);
            this.txtRemark.TabIndex = 11;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.ForeColor = System.Drawing.Color.Black;
            this.lblRemark.Location = new System.Drawing.Point(10, 6);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(46, 14);
            this.lblRemark.TabIndex = 10;
            this.lblRemark.Text = "Remark";
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
            this.Lineno,
            this.storeProduction_ID,
            this.ItemCode,
            this.ItemName,
            this.Subcategory,
            this.ItemSubCategory2_ID,
            this.ItemSerialNo,
            this.ItemSerialNo2,
            this.UOM,
            this.QTY,
            this.Weight,
            this.WeightWestage,
            this.WeightRejection,
            this.IsLocked,
            this.Remark,
            this.gUnitPrice,
            this.gWeightPrice,
            this.gTotalAmount});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 138);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(717, 173);
            this.dgvDetail.TabIndex = 15;
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            // 
            // Lineno
            // 
            this.Lineno.HeaderText = "Line No";
            this.Lineno.Name = "Lineno";
            this.Lineno.Visible = false;
            // 
            // storeProduction_ID
            // 
            this.storeProduction_ID.HeaderText = "Store Production ID";
            this.storeProduction_ID.Name = "storeProduction_ID";
            this.storeProduction_ID.Visible = false;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 75;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 230;
            // 
            // Subcategory
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Subcategory.DefaultCellStyle = dataGridViewCellStyle15;
            this.Subcategory.HeaderText = "Sub Category";
            this.Subcategory.Name = "Subcategory";
            // 
            // ItemSubCategory2_ID
            // 
            this.ItemSubCategory2_ID.HeaderText = "Item Sub Category2 ID";
            this.ItemSubCategory2_ID.Name = "ItemSubCategory2_ID";
            this.ItemSubCategory2_ID.Visible = false;
            this.ItemSubCategory2_ID.Width = 83;
            // 
            // ItemSerialNo
            // 
            this.ItemSerialNo.HeaderText = "Item Serial No";
            this.ItemSerialNo.Name = "ItemSerialNo";
            this.ItemSerialNo.Visible = false;
            // 
            // ItemSerialNo2
            // 
            this.ItemSerialNo2.HeaderText = "Item Serial No 2";
            this.ItemSerialNo2.Name = "ItemSerialNo2";
            this.ItemSerialNo2.Visible = false;
            // 
            // UOM
            // 
            this.UOM.HeaderText = "Uom ID";
            this.UOM.Name = "UOM";
            this.UOM.Visible = false;
            // 
            // QTY
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QTY.DefaultCellStyle = dataGridViewCellStyle16;
            this.QTY.HeaderText = "QTY";
            this.QTY.Name = "QTY";
            this.QTY.Width = 75;
            // 
            // Weight
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle17;
            this.Weight.HeaderText = "Weight Kg";
            this.Weight.Name = "Weight";
            this.Weight.Width = 75;
            // 
            // WeightWestage
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.WeightWestage.DefaultCellStyle = dataGridViewCellStyle18;
            this.WeightWestage.HeaderText = "Weastage Kg";
            this.WeightWestage.Name = "WeightWestage";
            this.WeightWestage.Visible = false;
            this.WeightWestage.Width = 80;
            // 
            // WeightRejection
            // 
            this.WeightRejection.HeaderText = "Weight Rejection";
            this.WeightRejection.Name = "WeightRejection";
            this.WeightRejection.Visible = false;
            // 
            // IsLocked
            // 
            this.IsLocked.HeaderText = "Is Locked";
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.Visible = false;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = false;
            // 
            // gUnitPrice
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gUnitPrice.DefaultCellStyle = dataGridViewCellStyle19;
            this.gUnitPrice.HeaderText = "Unit Price";
            this.gUnitPrice.Name = "gUnitPrice";
            this.gUnitPrice.Visible = false;
            // 
            // gWeightPrice
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gWeightPrice.DefaultCellStyle = dataGridViewCellStyle20;
            this.gWeightPrice.HeaderText = "Weight Price";
            this.gWeightPrice.Name = "gWeightPrice";
            this.gWeightPrice.Visible = false;
            // 
            // gTotalAmount
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gTotalAmount.DefaultCellStyle = dataGridViewCellStyle21;
            this.gTotalAmount.HeaderText = "Total Amount";
            this.gTotalAmount.Name = "gTotalAmount";
            this.gTotalAmount.Visible = false;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.White;
            this.x1.Controls.Add(this.lblCancelled);
            this.x1.Controls.Add(this.chkShowSettle);
            this.x1.Controls.Add(this.label34);
            this.x1.Controls.Add(this.dtpFGTNDate);
            this.x1.Controls.Add(this.lblStoreName);
            this.x1.Controls.Add(this.txtProductID);
            this.x1.Controls.Add(this.lblProductID);
            this.x1.Controls.Add(this.txtStoreName);
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(392, 93);
            this.x1.TabIndex = 16;
            // 
            // lblCancelled
            // 
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelled.ForeColor = System.Drawing.Color.Red;
            this.lblCancelled.Location = new System.Drawing.Point(239, 11);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(64, 14);
            this.lblCancelled.TabIndex = 560;
            this.lblCancelled.Text = "CANCELLED";
            // 
            // chkShowSettle
            // 
            this.chkShowSettle.AutoSize = true;
            this.chkShowSettle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowSettle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkShowSettle.Location = new System.Drawing.Point(239, 10);
            this.chkShowSettle.Name = "chkShowSettle";
            this.chkShowSettle.Size = new System.Drawing.Size(69, 18);
            this.chkShowSettle.TabIndex = 561;
            this.chkShowSettle.Text = "Show All";
            this.chkShowSettle.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(9, 36);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(31, 14);
            this.label34.TabIndex = 561;
            this.label34.Text = "Date";
            // 
            // dtpFGTNDate
            // 
            this.dtpFGTNDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFGTNDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFGTNDate.Location = new System.Drawing.Point(87, 33);
            this.dtpFGTNDate.Name = "dtpFGTNDate";
            this.dtpFGTNDate.Size = new System.Drawing.Size(142, 22);
            this.dtpFGTNDate.TabIndex = 560;
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.ForeColor = System.Drawing.Color.Black;
            this.lblStoreName.Location = new System.Drawing.Point(9, 63);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(66, 14);
            this.lblStoreName.TabIndex = 6;
            this.lblStoreName.Text = "Store Name";
            // 
            // txtProductID
            // 
            this.txtProductID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtProductID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductID.Location = new System.Drawing.Point(87, 7);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(142, 22);
            this.txtProductID.TabIndex = 5;
            this.txtProductID.DoubleClick += new System.EventHandler(this.txtProductID_DoubleClick);
            this.txtProductID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductID_KeyDown);
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.ForeColor = System.Drawing.Color.Black;
            this.lblProductID.Location = new System.Drawing.Point(9, 11);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(73, 14);
            this.lblProductID.TabIndex = 4;
            this.lblProductID.Text = "Production ID";
            // 
            // txtStoreName
            // 
            this.txtStoreName.BackColor = System.Drawing.Color.LightGray;
            this.txtStoreName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreName.Location = new System.Drawing.Point(87, 59);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.ReadOnly = true;
            this.txtStoreName.Size = new System.Drawing.Size(291, 22);
            this.txtStoreName.TabIndex = 7;
            this.txtStoreName.DoubleClick += new System.EventHandler(this.txtStoreName_DoubleClick);
            // 
            // btnF5
            // 
            this.btnF5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF5.Location = new System.Drawing.Point(242, 61);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(27, 22);
            this.btnF5.TabIndex = 562;
            this.btnF5.Text = "F5";
            this.btnF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF5.UseVisualStyleBackColor = true;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(3, 65);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(63, 14);
            this.lblItemName.TabIndex = 507;
            this.lblItemName.Text = "Item Name";
            // 
            // txtItemSerialNo
            // 
            this.txtItemSerialNo.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSerialNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSerialNo.Location = new System.Drawing.Point(43, 63);
            this.txtItemSerialNo.Name = "txtItemSerialNo";
            this.txtItemSerialNo.ReadOnly = true;
            this.txtItemSerialNo.Size = new System.Drawing.Size(13, 22);
            this.txtItemSerialNo.TabIndex = 509;
            this.txtItemSerialNo.Visible = false;
            // 
            // txtItemSubCategory
            // 
            this.txtItemSubCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSubCategory.Location = new System.Drawing.Point(56, 61);
            this.txtItemSubCategory.Name = "txtItemSubCategory";
            this.txtItemSubCategory.ReadOnly = true;
            this.txtItemSubCategory.Size = new System.Drawing.Size(13, 22);
            this.txtItemSubCategory.TabIndex = 508;
            this.txtItemSubCategory.Visible = false;
            // 
            // txtItemID
            // 
            this.txtItemID.BackColor = System.Drawing.Color.LightGray;
            this.txtItemID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(90, 61);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(152, 22);
            this.txtItemID.TabIndex = 505;
            this.txtItemID.DoubleClick += new System.EventHandler(this.txtItemID_DoubleClick);
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyDown);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddItem.Location = new System.Drawing.Point(54, 61);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(22, 22);
            this.btnAddItem.TabIndex = 506;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Visible = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.x2.Controls.Add(this.btnF5);
            this.x2.Controls.Add(this.cmbItemPrice);
            this.x2.Controls.Add(this.label37);
            this.x2.Controls.Add(this.txtJobCode);
            this.x2.Controls.Add(this.lblItemName);
            this.x2.Controls.Add(this.lblJobCode);
            this.x2.Controls.Add(this.txtItemSerialNo);
            this.x2.Controls.Add(this.btnAddQuotation);
            this.x2.Controls.Add(this.btnAddItem);
            this.x2.Controls.Add(this.txtItemSubCategory);
            this.x2.Controls.Add(this.txtItemID);
            this.x2.Location = new System.Drawing.Point(410, 8);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(316, 93);
            this.x2.TabIndex = 17;
            // 
            // cmbItemPrice
            // 
            this.cmbItemPrice.FormattingEnabled = true;
            this.cmbItemPrice.Location = new System.Drawing.Point(90, 35);
            this.cmbItemPrice.Name = "cmbItemPrice";
            this.cmbItemPrice.Size = new System.Drawing.Size(179, 21);
            this.cmbItemPrice.TabIndex = 558;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(3, 38);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(78, 14);
            this.label37.TabIndex = 559;
            this.label37.Text = "Price Category";
            // 
            // txtJobCode
            // 
            this.txtJobCode.BackColor = System.Drawing.Color.LightGray;
            this.txtJobCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobCode.Location = new System.Drawing.Point(90, 7);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.Size = new System.Drawing.Size(179, 22);
            this.txtJobCode.TabIndex = 503;
            // 
            // lblJobCode
            // 
            this.lblJobCode.AutoSize = true;
            this.lblJobCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobCode.ForeColor = System.Drawing.Color.Black;
            this.lblJobCode.Location = new System.Drawing.Point(3, 11);
            this.lblJobCode.Name = "lblJobCode";
            this.lblJobCode.Size = new System.Drawing.Size(50, 14);
            this.lblJobCode.TabIndex = 502;
            this.lblJobCode.Text = "Job Code";
            // 
            // btnAddQuotation
            // 
            this.btnAddQuotation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuotation.Image = global::Digiteq.Properties.Resources.add;
            this.btnAddQuotation.Location = new System.Drawing.Point(59, 7);
            this.btnAddQuotation.Name = "btnAddQuotation";
            this.btnAddQuotation.Size = new System.Drawing.Size(22, 22);
            this.btnAddQuotation.TabIndex = 504;
            this.btnAddQuotation.UseVisualStyleBackColor = true;
            this.btnAddQuotation.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(651, 107);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.Text = "Grid Del";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(404, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 80);
            this.panel2.TabIndex = 559;
            // 
            // xSetting
            // 
            this.xSetting.BackColor = System.Drawing.Color.Gainsboro;
            this.xSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xSetting.Controls.Add(this.button1);
            this.xSetting.Controls.Add(this.chkPrintOriginal);
            this.xSetting.Controls.Add(this.label3);
            this.xSetting.Location = new System.Drawing.Point(574, 0);
            this.xSetting.Name = "xSetting";
            this.xSetting.Size = new System.Drawing.Size(163, 57);
            this.xSetting.TabIndex = 595;
            this.xSetting.Visible = false;
            this.xSetting.Leave += new System.EventHandler(this.xSetting_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // frm_scsStoreProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.xSetting);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.z2);
            this.Name = "frm_scsStoreProduction";
            this.Size = new System.Drawing.Size(737, 417);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_printButton_Click);
            this.SF_draftButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_draftButton_Click);
            this.SF_checkButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_checkButton_Click);
            this.SF_approveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_approveButton_Click);
            this.SF_History_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_History_Click);
            this.SF_tempButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_scsStoreProduction_SF_tempButton_Click);
            this.Load += new System.EventHandler(this.frm_scsStoreProduction_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_scsStoreProduction_KeyDown);
            this.Controls.SetChildIndex(this.z2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.x2, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.xSetting, 0);
            this.z2.ResumeLayout(false);
            this.z2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.xSetting.ResumeLayout(false);
            this.xSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemSerialNo;
        private System.Windows.Forms.TextBox txtItemSubCategory;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtJobCode;
        private System.Windows.Forms.Label lblJobCode;
        private System.Windows.Forms.Button btnAddQuotation;
        private System.Windows.Forms.ComboBox cmbItemPrice;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DateTimePicker dtpFGTNDate;
        private System.Windows.Forms.Button btnF5;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.CheckBox chkShowSettle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lineno;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeProduction_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subcategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategory2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightWestage;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightRejection;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn gUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn gWeightPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn gTotalAmount;
        private System.Windows.Forms.Panel xSetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkPrintOriginal;
        private System.Windows.Forms.Label label3;
    }
}