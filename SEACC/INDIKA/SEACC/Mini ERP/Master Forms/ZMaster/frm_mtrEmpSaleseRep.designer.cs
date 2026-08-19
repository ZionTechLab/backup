namespace Digiteq
{
    partial class frm_mtrEmpSaleseRep
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
            this.SalesRepID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIsCollector = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblareaManager = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtAreaManagerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSalesRepID = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalesRepName = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtSalesRepID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMobil = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsSalesRep = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(164, 269);
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
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SalesRepID,
            this.SalesRepName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(322, 32);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 261);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // SalesRepID
            // 
            this.SalesRepID.HeaderText = "Sales Rep ID";
            this.SalesRepID.Name = "SalesRepID";
            this.SalesRepID.Width = 90;
            // 
            // SalesRepName
            // 
            this.SalesRepName.HeaderText = "Sales Rep Name";
            this.SalesRepName.Name = "SalesRepName";
            this.SalesRepName.Width = 218;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkIsSalesRep);
            this.panel2.Controls.Add(this.chkIsCollector);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblareaManager);
            this.panel2.Controls.Add(this.txtFax);
            this.panel2.Controls.Add(this.txtAreaManagerName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblSalesRepID);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.lblBankName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtSalesRepName);
            this.panel2.Controls.Add(this.txtTelephone);
            this.panel2.Controls.Add(this.txtSalesRepID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMobil);
            this.panel2.Location = new System.Drawing.Point(5, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 232);
            this.panel2.TabIndex = 7;
            // 
            // chkIsCollector
            // 
            this.chkIsCollector.AutoSize = true;
            this.chkIsCollector.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsCollector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIsCollector.Location = new System.Drawing.Point(223, 201);
            this.chkIsCollector.Name = "chkIsCollector";
            this.chkIsCollector.Size = new System.Drawing.Size(69, 18);
            this.chkIsCollector.TabIndex = 118;
            this.chkIsCollector.Text = "Collector";
            this.chkIsCollector.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(7, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 110;
            this.label4.Text = "Fax No.";
            // 
            // lblareaManager
            // 
            this.lblareaManager.AutoSize = true;
            this.lblareaManager.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblareaManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblareaManager.Location = new System.Drawing.Point(7, 35);
            this.lblareaManager.Name = "lblareaManager";
            this.lblareaManager.Size = new System.Drawing.Size(77, 14);
            this.lblareaManager.TabIndex = 106;
            this.lblareaManager.Text = "Area Manager";
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.SystemColors.Window;
            this.txtFax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(97, 145);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(199, 22);
            this.txtFax.TabIndex = 109;
            // 
            // txtAreaManagerName
            // 
            this.txtAreaManagerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAreaManagerName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaManagerName.Location = new System.Drawing.Point(97, 32);
            this.txtAreaManagerName.Name = "txtAreaManagerName";
            this.txtAreaManagerName.ReadOnly = true;
            this.txtAreaManagerName.Size = new System.Drawing.Size(199, 22);
            this.txtAreaManagerName.TabIndex = 105;
            this.txtAreaManagerName.Text = "Plastic Bag";
            this.txtAreaManagerName.DoubleClick += new System.EventHandler(this.txtAreaManager_DoubleClick);
            this.txtAreaManagerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAreaManagerName_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(7, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 108;
            this.label5.Text = "Email";
            // 
            // lblSalesRepID
            // 
            this.lblSalesRepID.AutoSize = true;
            this.lblSalesRepID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesRepID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSalesRepID.Location = new System.Drawing.Point(7, 9);
            this.lblSalesRepID.Name = "lblSalesRepID";
            this.lblSalesRepID.Size = new System.Drawing.Size(69, 14);
            this.lblSalesRepID.TabIndex = 72;
            this.lblSalesRepID.Text = "Sales Rep ID";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(97, 173);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(199, 22);
            this.txtEmail.TabIndex = 107;
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(7, 63);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(58, 14);
            this.lblBankName.TabIndex = 104;
            this.lblBankName.Text = "Sales Rep ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(7, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "Telephone No.";
            // 
            // txtSalesRepName
            // 
            this.txtSalesRepName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRepName.Location = new System.Drawing.Point(97, 60);
            this.txtSalesRepName.Name = "txtSalesRepName";
            this.txtSalesRepName.Size = new System.Drawing.Size(199, 22);
            this.txtSalesRepName.TabIndex = 1;
            this.txtSalesRepName.Text = "Plastic Bag";
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.SystemColors.Window;
            this.txtTelephone.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(97, 88);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(199, 22);
            this.txtTelephone.TabIndex = 105;
            // 
            // txtSalesRepID
            // 
            this.txtSalesRepID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtSalesRepID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRepID.Location = new System.Drawing.Point(97, 6);
            this.txtSalesRepID.Name = "txtSalesRepID";
            this.txtSalesRepID.Size = new System.Drawing.Size(120, 22);
            this.txtSalesRepID.TabIndex = 0;
            this.txtSalesRepID.DoubleClick += new System.EventHandler(this.txtSalseRepID_DoubleClick);
            this.txtSalesRepID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesRepID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(7, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 104;
            this.label3.Text = "Mobil No.";
            // 
            // txtMobil
            // 
            this.txtMobil.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobil.Location = new System.Drawing.Point(97, 116);
            this.txtMobil.Name = "txtMobil";
            this.txtMobil.Size = new System.Drawing.Size(199, 22);
            this.txtMobil.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(87, 269);
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
            this.btnSave.Location = new System.Drawing.Point(241, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsSalesRep
            // 
            this.chkIsSalesRep.AutoSize = true;
            this.chkIsSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.chkIsSalesRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkIsSalesRep.Location = new System.Drawing.Point(133, 201);
            this.chkIsSalesRep.Name = "chkIsSalesRep";
            this.chkIsSalesRep.Size = new System.Drawing.Size(74, 18);
            this.chkIsSalesRep.TabIndex = 119;
            this.chkIsSalesRep.Text = "Sales Rep";
            this.chkIsSalesRep.UseVisualStyleBackColor = true;
            // 
            // frm_mtrEmpSaleseRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(638, 299);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrEmpSaleseRep";
            this.Text = "Sales Rep";
            this.Load += new System.EventHandler(this.frm_mtrItemCategory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrSalesRep_KeyDown);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSalesRepID;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtSalesRepName;
        private System.Windows.Forms.TextBox txtSalesRepID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblareaManager;
        private System.Windows.Forms.TextBox txtAreaManagerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRepID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRepName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMobil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox chkIsCollector;
        private System.Windows.Forms.CheckBox chkIsSalesRep;
    }
}