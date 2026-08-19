namespace Digiteq
{
    partial class frm_mtrCompanyStore

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIsAllowMinusStore = new System.Windows.Forms.CheckBox();
            this.chkIsShowRoom = new System.Windows.Forms.CheckBox();
            this.chkIsColdRoom = new System.Windows.Forms.CheckBox();
            this.chkIsMainStore = new System.Windows.Forms.CheckBox();
            this.chkIsTradingStore = new System.Windows.Forms.CheckBox();
            this.chkIsDamagedStore = new System.Windows.Forms.CheckBox();
            this.txtCompanyBranch = new System.Windows.Forms.TextBox();
            this.txtCompanyStoreName = new System.Windows.Forms.TextBox();
            this.txtCompanyStoreID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStoreID = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.DivisionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DivisionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsDeActive = new System.Windows.Forms.CheckBox();
            this.chkSubContractorLocation = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkSubContractorLocation);
            this.panel1.Controls.Add(this.chkIsAllowMinusStore);
            this.panel1.Controls.Add(this.chkIsShowRoom);
            this.panel1.Controls.Add(this.chkIsColdRoom);
            this.panel1.Controls.Add(this.chkIsMainStore);
            this.panel1.Controls.Add(this.chkIsTradingStore);
            this.panel1.Controls.Add(this.chkIsDamagedStore);
            this.panel1.Controls.Add(this.txtCompanyBranch);
            this.panel1.Controls.Add(this.txtCompanyStoreName);
            this.panel1.Controls.Add(this.txtCompanyStoreID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtContactPerson);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTelephone);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblStoreID);
            this.panel1.Controls.Add(this.lblBankName);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 162);
            this.panel1.TabIndex = 28;
            // 
            // chkIsAllowMinusStore
            // 
            this.chkIsAllowMinusStore.AutoSize = true;
            this.chkIsAllowMinusStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsAllowMinusStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIsAllowMinusStore.Location = new System.Drawing.Point(106, 137);
            this.chkIsAllowMinusStore.Name = "chkIsAllowMinusStore";
            this.chkIsAllowMinusStore.Size = new System.Drawing.Size(87, 18);
            this.chkIsAllowMinusStore.TabIndex = 120;
            this.chkIsAllowMinusStore.Text = "Allow Minus";
            this.chkIsAllowMinusStore.UseVisualStyleBackColor = true;
            // 
            // chkIsShowRoom
            // 
            this.chkIsShowRoom.AutoSize = true;
            this.chkIsShowRoom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsShowRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIsShowRoom.Location = new System.Drawing.Point(10, 137);
            this.chkIsShowRoom.Name = "chkIsShowRoom";
            this.chkIsShowRoom.Size = new System.Drawing.Size(82, 18);
            this.chkIsShowRoom.TabIndex = 119;
            this.chkIsShowRoom.Text = "ShowRoom";
            this.chkIsShowRoom.UseVisualStyleBackColor = true;
            // 
            // chkIsColdRoom
            // 
            this.chkIsColdRoom.AutoSize = true;
            this.chkIsColdRoom.Enabled = false;
            this.chkIsColdRoom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsColdRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIsColdRoom.Location = new System.Drawing.Point(381, 115);
            this.chkIsColdRoom.Name = "chkIsColdRoom";
            this.chkIsColdRoom.Size = new System.Drawing.Size(79, 18);
            this.chkIsColdRoom.TabIndex = 119;
            this.chkIsColdRoom.Text = "Cold Room";
            this.chkIsColdRoom.UseVisualStyleBackColor = true;
            // 
            // chkIsMainStore
            // 
            this.chkIsMainStore.AutoSize = true;
            this.chkIsMainStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsMainStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIsMainStore.Location = new System.Drawing.Point(10, 115);
            this.chkIsMainStore.Name = "chkIsMainStore";
            this.chkIsMainStore.Size = new System.Drawing.Size(80, 18);
            this.chkIsMainStore.TabIndex = 117;
            this.chkIsMainStore.Text = "Main Store";
            this.chkIsMainStore.UseVisualStyleBackColor = true;
            // 
            // chkIsTradingStore
            // 
            this.chkIsTradingStore.AutoSize = true;
            this.chkIsTradingStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsTradingStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIsTradingStore.Location = new System.Drawing.Point(106, 115);
            this.chkIsTradingStore.Name = "chkIsTradingStore";
            this.chkIsTradingStore.Size = new System.Drawing.Size(91, 18);
            this.chkIsTradingStore.TabIndex = 116;
            this.chkIsTradingStore.Text = "Trading Store";
            this.chkIsTradingStore.UseVisualStyleBackColor = true;
            // 
            // chkIsDamagedStore
            // 
            this.chkIsDamagedStore.AutoSize = true;
            this.chkIsDamagedStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsDamagedStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIsDamagedStore.Location = new System.Drawing.Point(220, 115);
            this.chkIsDamagedStore.Name = "chkIsDamagedStore";
            this.chkIsDamagedStore.Size = new System.Drawing.Size(137, 18);
            this.chkIsDamagedStore.TabIndex = 115;
            this.chkIsDamagedStore.Text = "Damaged Goods Store";
            this.chkIsDamagedStore.UseVisualStyleBackColor = true;
            // 
            // txtCompanyBranch
            // 
            this.txtCompanyBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCompanyBranch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyBranch.Location = new System.Drawing.Point(87, 33);
            this.txtCompanyBranch.Name = "txtCompanyBranch";
            this.txtCompanyBranch.ReadOnly = true;
            this.txtCompanyBranch.Size = new System.Drawing.Size(185, 22);
            this.txtCompanyBranch.TabIndex = 1;
            this.txtCompanyBranch.DoubleClick += new System.EventHandler(this.txtBranchName_DoubleClick);
            this.txtCompanyBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyBranchName_KeyDown);
            // 
            // txtCompanyStoreName
            // 
            this.txtCompanyStoreName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyStoreName.Location = new System.Drawing.Point(87, 60);
            this.txtCompanyStoreName.Name = "txtCompanyStoreName";
            this.txtCompanyStoreName.Size = new System.Drawing.Size(185, 22);
            this.txtCompanyStoreName.TabIndex = 105;
            // 
            // txtCompanyStoreID
            // 
            this.txtCompanyStoreID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCompanyStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyStoreID.Location = new System.Drawing.Point(87, 6);
            this.txtCompanyStoreID.Name = "txtCompanyStoreID";
            this.txtCompanyStoreID.Size = new System.Drawing.Size(110, 22);
            this.txtCompanyStoreID.TabIndex = 0;
            this.txtCompanyStoreID.DoubleClick += new System.EventHandler(this.txtCompanyStoreID_DoubleClick);
            this.txtCompanyStoreID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyStoreID_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(7, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 114;
            this.label5.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(87, 87);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(384, 22);
            this.txtAddress.TabIndex = 113;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(278, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 112;
            this.label4.Text = "Contact Person";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactPerson.Location = new System.Drawing.Point(361, 60);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(110, 22);
            this.txtContactPerson.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(278, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 14);
            this.label3.TabIndex = 110;
            this.label3.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(361, 33);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(110, 22);
            this.txtFax.TabIndex = 109;
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(278, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 108;
            this.label2.Text = "Telephone";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(361, 6);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(110, 22);
            this.txtTelephone.TabIndex = 107;
            this.txtTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelephone_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(7, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "Store Name";
            // 
            // lblStoreID
            // 
            this.lblStoreID.AutoSize = true;
            this.lblStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStoreID.Location = new System.Drawing.Point(7, 10);
            this.lblStoreID.Name = "lblStoreID";
            this.lblStoreID.Size = new System.Drawing.Size(60, 14);
            this.lblStoreID.TabIndex = 72;
            this.lblStoreID.Text = "Store Code";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(7, 37);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(74, 14);
            this.lblBankName.TabIndex = 104;
            this.lblBankName.Text = "Branch Name";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(337, 175);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 27;
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
            this.DivisionID,
            this.DivisionName,
            this.BranchID,
            this.ContactPerson,
            this.Telephone,
            this.Fax,
            this.Address});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 206);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(481, 245);
            this.dgvDetail.TabIndex = 26;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // DivisionID
            // 
            this.DivisionID.HeaderText = "Store ID";
            this.DivisionID.Name = "DivisionID";
            this.DivisionID.Width = 88;
            // 
            // DivisionName
            // 
            this.DivisionName.HeaderText = "Store Name";
            this.DivisionName.Name = "DivisionName";
            this.DivisionName.Width = 145;
            // 
            // BranchID
            // 
            this.BranchID.HeaderText = "Branch Name";
            this.BranchID.Name = "BranchID";
            this.BranchID.Width = 145;
            // 
            // ContactPerson
            // 
            this.ContactPerson.HeaderText = "Contact Person";
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.Visible = false;
            this.ContactPerson.Width = 145;
            // 
            // Telephone
            // 
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            // 
            // Fax
            // 
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.Visible = false;
            this.Fax.Width = 85;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = false;
            this.Address.Width = 115;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(260, 175);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 25;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(414, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsDeActive
            // 
            this.chkIsDeActive.AutoSize = true;
            this.chkIsDeActive.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsDeActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIsDeActive.Location = new System.Drawing.Point(19, 179);
            this.chkIsDeActive.Name = "chkIsDeActive";
            this.chkIsDeActive.Size = new System.Drawing.Size(71, 18);
            this.chkIsDeActive.TabIndex = 118;
            this.chkIsDeActive.Text = "DeActive";
            this.chkIsDeActive.UseVisualStyleBackColor = true;
            // 
            // chkSubContractorLocation
            // 
            this.chkSubContractorLocation.AutoSize = true;
            this.chkSubContractorLocation.Enabled = false;
            this.chkSubContractorLocation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkSubContractorLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSubContractorLocation.Location = new System.Drawing.Point(220, 137);
            this.chkSubContractorLocation.Name = "chkSubContractorLocation";
            this.chkSubContractorLocation.Size = new System.Drawing.Size(142, 18);
            this.chkSubContractorLocation.TabIndex = 121;
            this.chkSubContractorLocation.Text = "Sub Contractor Location";
            this.chkSubContractorLocation.UseVisualStyleBackColor = true;
            // 
            // frm_mtrCompanyStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(499, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkIsDeActive);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_mtrCompanyStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Store Master";
            this.Load += new System.EventHandler(this.frm_mtrBranch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrBranch_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStoreID;
        private System.Windows.Forms.TextBox txtCompanyStoreName;
        private System.Windows.Forms.TextBox txtCompanyStoreID;
        private System.Windows.Forms.TextBox txtCompanyBranch;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.CheckBox chkIsDamagedStore;
        private System.Windows.Forms.CheckBox chkIsDeActive;
        private System.Windows.Forms.CheckBox chkIsMainStore;
        private System.Windows.Forms.CheckBox chkIsTradingStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn DivisionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DivisionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.CheckBox chkIsColdRoom;
        private System.Windows.Forms.CheckBox chkIsShowRoom;
        private System.Windows.Forms.CheckBox chkIsAllowMinusStore;
        private System.Windows.Forms.CheckBox chkSubContractorLocation;
    }
}