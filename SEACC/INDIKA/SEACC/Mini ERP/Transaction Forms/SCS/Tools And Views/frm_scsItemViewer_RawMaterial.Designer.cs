namespace Digiteq
{
    partial class frm_scsItemViewer_RawMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_scsItemViewer_RawMaterial));
            this.label26 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.x1 = new System.Windows.Forms.Panel();
            this.Refresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.lblMaterialID = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.x2 = new System.Windows.Forms.Panel();
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMaterialCategory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaterialType = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.lblThickness = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.lblMaterialClass = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.lblMaterialWith = new System.Windows.Forms.Label();
            this.lblMaterialUom = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDetailStore = new SEACC_DataGrid();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DamagedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WasteageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.x1.SuspendLayout();
            this.x2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailStore)).BeginInit();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(109, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(227, 19);
            this.label26.TabIndex = 274;
            this.label26.Text = "SEACC VIEWER - RAW MATERIAL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 385;
            this.pictureBox1.TabStop = false;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.Refresh);
            this.x1.Controls.Add(this.btnCancel);
            this.x1.Controls.Add(this.label72);
            this.x1.Controls.Add(this.label26);
            this.x1.Controls.Add(this.pictureBox1);
            this.x1.Controls.Add(this.lblMaterialName);
            this.x1.Controls.Add(this.lblMaterialID);
            this.x1.Controls.Add(this.label221);
            this.x1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.Location = new System.Drawing.Point(6, 6);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(630, 72);
            this.x1.TabIndex = 403;
            // 
            // Refresh
            // 
            this.Refresh.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh.Image = global::Digiteq.Properties.Resources.refresh;
            this.Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Refresh.Location = new System.Drawing.Point(490, 4);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(65, 25);
            this.Refresh.TabIndex = 396;
            this.Refresh.Text = "Refresh";
            this.Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(556, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 25);
            this.btnCancel.TabIndex = 395;
            this.btnCancel.Text = "  Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label72.Location = new System.Drawing.Point(220, 42);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(89, 15);
            this.label72.TabIndex = 390;
            this.label72.Text = "Material Name";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialName.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialName.Location = new System.Drawing.Point(315, 39);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(304, 22);
            this.lblMaterialName.TabIndex = 387;
            this.lblMaterialName.Text = "1,120,175.00";
            this.lblMaterialName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaterialID
            // 
            this.lblMaterialID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialID.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialID.Location = new System.Drawing.Point(103, 39);
            this.lblMaterialID.Name = "lblMaterialID";
            this.lblMaterialID.Size = new System.Drawing.Size(100, 22);
            this.lblMaterialID.TabIndex = 369;
            this.lblMaterialID.Text = "160,251.00";
            this.lblMaterialID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label221.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label221.Location = new System.Drawing.Point(8, 42);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(84, 15);
            this.label221.TabIndex = 357;
            this.label221.Text = "Material Code";
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.x2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2.Controls.Add(this.lblSubCategory);
            this.x2.Controls.Add(this.label4);
            this.x2.Controls.Add(this.lblMaterialCategory);
            this.x2.Controls.Add(this.label2);
            this.x2.Controls.Add(this.lblMaterialType);
            this.x2.Controls.Add(this.label78);
            this.x2.Controls.Add(this.lblThickness);
            this.x2.Controls.Add(this.label96);
            this.x2.Controls.Add(this.lblMaterialClass);
            this.x2.Controls.Add(this.label77);
            this.x2.Controls.Add(this.lblMaterialWith);
            this.x2.Controls.Add(this.lblMaterialUom);
            this.x2.Controls.Add(this.label95);
            this.x2.Controls.Add(this.label21);
            this.x2.Controls.Add(this.label22);
            this.x2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x2.Location = new System.Drawing.Point(6, 84);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(630, 141);
            this.x2.TabIndex = 404;
            // 
            // lblSubCategory
            // 
            this.lblSubCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategory.ForeColor = System.Drawing.Color.Black;
            this.lblSubCategory.Location = new System.Drawing.Point(318, 110);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(303, 22);
            this.lblSubCategory.TabIndex = 403;
            this.lblSubCategory.Text = "360,211.00";
            this.lblSubCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(213, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 402;
            this.label4.Text = "Sub Category";
            // 
            // lblMaterialCategory
            // 
            this.lblMaterialCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialCategory.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialCategory.Location = new System.Drawing.Point(317, 84);
            this.lblMaterialCategory.Name = "lblMaterialCategory";
            this.lblMaterialCategory.Size = new System.Drawing.Size(303, 22);
            this.lblMaterialCategory.TabIndex = 401;
            this.lblMaterialCategory.Text = "360,211.00";
            this.lblMaterialCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(212, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 400;
            this.label2.Text = "Material Category";
            // 
            // lblMaterialType
            // 
            this.lblMaterialType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialType.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialType.Location = new System.Drawing.Point(318, 56);
            this.lblMaterialType.Name = "lblMaterialType";
            this.lblMaterialType.Size = new System.Drawing.Size(303, 22);
            this.lblMaterialType.TabIndex = 399;
            this.lblMaterialType.Text = "360,211.00";
            this.lblMaterialType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label78.Location = new System.Drawing.Point(213, 59);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(82, 15);
            this.label78.TabIndex = 398;
            this.label78.Text = "Material Type";
            // 
            // lblThickness
            // 
            this.lblThickness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThickness.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThickness.ForeColor = System.Drawing.Color.Black;
            this.lblThickness.Location = new System.Drawing.Point(104, 84);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(100, 22);
            this.lblThickness.TabIndex = 395;
            this.lblThickness.Text = "360,211.00";
            this.lblThickness.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label96.Location = new System.Drawing.Point(7, 88);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(58, 15);
            this.label96.TabIndex = 394;
            this.label96.Text = "Thickness";
            // 
            // lblMaterialClass
            // 
            this.lblMaterialClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialClass.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialClass.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialClass.Location = new System.Drawing.Point(317, 31);
            this.lblMaterialClass.Name = "lblMaterialClass";
            this.lblMaterialClass.Size = new System.Drawing.Size(304, 22);
            this.lblMaterialClass.TabIndex = 393;
            this.lblMaterialClass.Text = "360,211.00";
            this.lblMaterialClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label77.Location = new System.Drawing.Point(213, 34);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(82, 15);
            this.label77.TabIndex = 392;
            this.label77.Text = "Material Class";
            // 
            // lblMaterialWith
            // 
            this.lblMaterialWith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialWith.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialWith.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialWith.Location = new System.Drawing.Point(104, 57);
            this.lblMaterialWith.Name = "lblMaterialWith";
            this.lblMaterialWith.Size = new System.Drawing.Size(100, 22);
            this.lblMaterialWith.TabIndex = 369;
            this.lblMaterialWith.Text = "160,251.00";
            this.lblMaterialWith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaterialUom
            // 
            this.lblMaterialUom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaterialUom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialUom.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialUom.Location = new System.Drawing.Point(104, 31);
            this.lblMaterialUom.Name = "lblMaterialUom";
            this.lblMaterialUom.Size = new System.Drawing.Size(100, 22);
            this.lblMaterialUom.TabIndex = 368;
            this.lblMaterialUom.Text = "1,120,175.00";
            this.lblMaterialUom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label95.Location = new System.Drawing.Point(7, 60);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(90, 15);
            this.label95.TabIndex = 357;
            this.label95.Text = "Material Width";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label21.Location = new System.Drawing.Point(-1, -1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(630, 25);
            this.label21.TabIndex = 356;
            this.label21.Text = "Material Detail";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label22.Location = new System.Drawing.Point(7, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 15);
            this.label22.TabIndex = 273;
            this.label22.Text = "Material UOM";
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label42.Location = new System.Drawing.Point(-1, -1);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(630, 25);
            this.label42.TabIndex = 356;
            this.label42.Text = "Material Stock Detail";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvDetailStore);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(6, 231);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(630, 283);
            this.panel3.TabIndex = 405;
            // 
            // dgvDetailStore
            // 
            this.dgvDetailStore.AllowUserToAddRows = false;
            this.dgvDetailStore.AllowUserToDeleteRows = false;
            this.dgvDetailStore.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetailStore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetailStore.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetailStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetailStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreID,
            this.StoreName,
            this.AvailableQuantity,
            this.ActualQuantity,
            this.DamagedQuantity,
            this.WasteageQuantity});
            this.dgvDetailStore.EnableHeadersVisualStyles = false;
            this.dgvDetailStore.Location = new System.Drawing.Point(-1, 23);
            this.dgvDetailStore.MultiSelect = false;
            this.dgvDetailStore.Name = "dgvDetailStore";
            this.dgvDetailStore.RowHeadersVisible = false;
            this.dgvDetailStore.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetailStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailStore.Size = new System.Drawing.Size(630, 259);
            this.dgvDetailStore.TabIndex = 505;
            // 
            // StoreID
            // 
            this.StoreID.HeaderText = "StoreID";
            this.StoreID.Name = "StoreID";
            this.StoreID.Width = 90;
            // 
            // StoreName
            // 
            this.StoreName.HeaderText = "StoreName";
            this.StoreName.Name = "StoreName";
            this.StoreName.Width = 177;
            // 
            // AvailableQuantity
            // 
            this.AvailableQuantity.HeaderText = "Available Qty";
            this.AvailableQuantity.Name = "AvailableQuantity";
            this.AvailableQuantity.Width = 90;
            // 
            // ActualQuantity
            // 
            this.ActualQuantity.HeaderText = "Actual Qty";
            this.ActualQuantity.Name = "ActualQuantity";
            this.ActualQuantity.Width = 90;
            // 
            // DamagedQuantity
            // 
            this.DamagedQuantity.HeaderText = "Damaged Qty";
            this.DamagedQuantity.Name = "DamagedQuantity";
            this.DamagedQuantity.Width = 90;
            // 
            // WasteageQuantity
            // 
            this.WasteageQuantity.HeaderText = "Wastage Qty";
            this.WasteageQuantity.Name = "WasteageQuantity";
            this.WasteageQuantity.Width = 90;
            // 
            // frm_scsItemViewer_RawMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(644, 524);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.x1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_scsItemViewer_RawMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_bpsChequeViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailStore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label lblMaterialID;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.Label lblMaterialWith;
        private System.Windows.Forms.Label lblMaterialUom;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label lblMaterialType;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label lblThickness;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label lblMaterialClass;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMaterialCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSubCategory;
        private System.Windows.Forms.Label label4;
        private SEACC_DataGrid dgvDetailStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamagedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn WasteageQuantity;
    }
}