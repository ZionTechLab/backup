namespace Digiteq
{
    partial class frm_mtrUom
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkVisibal = new System.Windows.Forms.CheckBox();
            this.chkPacking = new System.Windows.Forms.CheckBox();
            this.chksales = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUomCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUomName = new System.Windows.Forms.TextBox();
            this.lblUomID = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtUomID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoCalculationKilo = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoCalculationBag = new System.Windows.Forms.RadioButton();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.UomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UomCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UomCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoIsWeight = new System.Windows.Forms.RadioButton();
            this.rdoIsLength = new System.Windows.Forms.RadioButton();
            this.rdoIsQty = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(414, 168);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkVisibal);
            this.panel2.Controls.Add(this.chkPacking);
            this.panel2.Controls.Add(this.chksales);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtUomCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtUomName);
            this.panel2.Controls.Add(this.lblUomID);
            this.panel2.Controls.Add(this.lblCategoryName);
            this.panel2.Controls.Add(this.txtCategoryName);
            this.panel2.Controls.Add(this.txtUomID);
            this.panel2.Location = new System.Drawing.Point(7, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 118);
            this.panel2.TabIndex = 7;
            // 
            // chkVisibal
            // 
            this.chkVisibal.AutoSize = true;
            this.chkVisibal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVisibal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkVisibal.Location = new System.Drawing.Point(308, 34);
            this.chkVisibal.Name = "chkVisibal";
            this.chkVisibal.Size = new System.Drawing.Size(59, 18);
            this.chkVisibal.TabIndex = 432;
            this.chkVisibal.Text = "Visible";
            this.chkVisibal.UseVisualStyleBackColor = true;
            // 
            // chkPacking
            // 
            this.chkPacking.AutoSize = true;
            this.chkPacking.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPacking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkPacking.Location = new System.Drawing.Point(308, 61);
            this.chkPacking.Name = "chkPacking";
            this.chkPacking.Size = new System.Drawing.Size(64, 18);
            this.chkPacking.TabIndex = 434;
            this.chkPacking.Text = "Packing";
            this.chkPacking.UseVisualStyleBackColor = true;
            // 
            // chksales
            // 
            this.chksales.AutoSize = true;
            this.chksales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chksales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chksales.Location = new System.Drawing.Point(308, 89);
            this.chksales.Name = "chksales";
            this.chksales.Size = new System.Drawing.Size(52, 18);
            this.chksales.TabIndex = 433;
            this.chksales.Text = "Sales";
            this.chksales.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(7, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 436;
            this.label2.Text = "Uom Code";
            // 
            // txtUomCode
            // 
            this.txtUomCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUomCode.Location = new System.Drawing.Point(97, 87);
            this.txtUomCode.Name = "txtUomCode";
            this.txtUomCode.Size = new System.Drawing.Size(120, 22);
            this.txtUomCode.TabIndex = 435;
            this.txtUomCode.Text = "Plastic Bag";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 106;
            this.label1.Text = "Uom Name";
            // 
            // txtUomName
            // 
            this.txtUomName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUomName.Location = new System.Drawing.Point(97, 59);
            this.txtUomName.Name = "txtUomName";
            this.txtUomName.Size = new System.Drawing.Size(199, 22);
            this.txtUomName.TabIndex = 105;
            this.txtUomName.Text = "Plastic Bag";
            // 
            // lblUomID
            // 
            this.lblUomID.AutoSize = true;
            this.lblUomID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUomID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUomID.Location = new System.Drawing.Point(7, 10);
            this.lblUomID.Name = "lblUomID";
            this.lblUomID.Size = new System.Drawing.Size(45, 14);
            this.lblUomID.TabIndex = 72;
            this.lblUomID.Text = "Uom ID";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCategoryName.Location = new System.Drawing.Point(7, 35);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(84, 14);
            this.lblCategoryName.TabIndex = 104;
            this.lblCategoryName.Text = "Category Name";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCategoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(97, 32);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.ReadOnly = true;
            this.txtCategoryName.Size = new System.Drawing.Size(199, 22);
            this.txtCategoryName.TabIndex = 1;
            this.txtCategoryName.Text = "Plastic Bag";
            this.txtCategoryName.DoubleClick += new System.EventHandler(this.txtUomCategoryName_DoubleClick);
            this.txtCategoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUomCategoryName_KeyDown);
            // 
            // txtUomID
            // 
            this.txtUomID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtUomID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUomID.Location = new System.Drawing.Point(97, 7);
            this.txtUomID.Name = "txtUomID";
            this.txtUomID.Size = new System.Drawing.Size(120, 22);
            this.txtUomID.TabIndex = 0;
            this.txtUomID.DoubleClick += new System.EventHandler(this.txtUomID_DoubleClick);
            this.txtUomID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUomID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(337, 168);
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
            this.btnSave.Location = new System.Drawing.Point(491, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rdoCalculationKilo);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.rdoCalculationBag);
            this.panel1.Location = new System.Drawing.Point(393, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 118);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 362;
            this.label3.Text = "Calculation";
            // 
            // rdoCalculationKilo
            // 
            this.rdoCalculationKilo.AutoSize = true;
            this.rdoCalculationKilo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoCalculationKilo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCalculationKilo.Location = new System.Drawing.Point(7, 34);
            this.rdoCalculationKilo.Name = "rdoCalculationKilo";
            this.rdoCalculationKilo.Size = new System.Drawing.Size(61, 18);
            this.rdoCalculationKilo.TabIndex = 361;
            this.rdoCalculationKilo.TabStop = true;
            this.rdoCalculationKilo.Text = "Weight";
            this.rdoCalculationKilo.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.radioButton1.Location = new System.Drawing.Point(7, 89);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 18);
            this.radioButton1.TabIndex = 360;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Liquid";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoCalculationBag
            // 
            this.rdoCalculationBag.AutoSize = true;
            this.rdoCalculationBag.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoCalculationBag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCalculationBag.Location = new System.Drawing.Point(7, 61);
            this.rdoCalculationBag.Name = "rdoCalculationBag";
            this.rdoCalculationBag.Size = new System.Drawing.Size(49, 18);
            this.rdoCalculationBag.TabIndex = 359;
            this.rdoCalculationBag.TabStop = true;
            this.rdoCalculationBag.Text = "No/s";
            this.rdoCalculationBag.UseVisualStyleBackColor = true;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UomID,
            this.UomCode,
            this.UomName,
            this.UomCategoryID});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 197);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(559, 286);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // UomID
            // 
            this.UomID.HeaderText = "Uom ID";
            this.UomID.Name = "UomID";
            this.UomID.Width = 80;
            // 
            // UomCode
            // 
            this.UomCode.HeaderText = "Uom Code";
            this.UomCode.Name = "UomCode";
            // 
            // UomName
            // 
            this.UomName.HeaderText = "Uom Name";
            this.UomName.Name = "UomName";
            this.UomName.Width = 185;
            // 
            // UomCategoryID
            // 
            this.UomCategoryID.HeaderText = "Category Name";
            this.UomCategoryID.Name = "UomCategoryID";
            this.UomCategoryID.Width = 185;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.rdoIsWeight);
            this.panel3.Controls.Add(this.rdoIsLength);
            this.panel3.Controls.Add(this.rdoIsQty);
            this.panel3.Location = new System.Drawing.Point(482, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(83, 118);
            this.panel3.TabIndex = 363;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(23, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 362;
            this.label4.Text = "Type";
            // 
            // rdoIsWeight
            // 
            this.rdoIsWeight.AutoSize = true;
            this.rdoIsWeight.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoIsWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoIsWeight.Location = new System.Drawing.Point(7, 34);
            this.rdoIsWeight.Name = "rdoIsWeight";
            this.rdoIsWeight.Size = new System.Drawing.Size(61, 18);
            this.rdoIsWeight.TabIndex = 361;
            this.rdoIsWeight.TabStop = true;
            this.rdoIsWeight.Text = "Weight";
            this.rdoIsWeight.UseVisualStyleBackColor = true;
            // 
            // rdoIsLength
            // 
            this.rdoIsLength.AutoSize = true;
            this.rdoIsLength.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoIsLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoIsLength.Location = new System.Drawing.Point(7, 89);
            this.rdoIsLength.Name = "rdoIsLength";
            this.rdoIsLength.Size = new System.Drawing.Size(58, 18);
            this.rdoIsLength.TabIndex = 360;
            this.rdoIsLength.TabStop = true;
            this.rdoIsLength.Text = "Length";
            this.rdoIsLength.UseVisualStyleBackColor = true;
            // 
            // rdoIsQty
            // 
            this.rdoIsQty.AutoSize = true;
            this.rdoIsQty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoIsQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoIsQty.Location = new System.Drawing.Point(7, 61);
            this.rdoIsQty.Name = "rdoIsQty";
            this.rdoIsQty.Size = new System.Drawing.Size(68, 18);
            this.rdoIsQty.TabIndex = 359;
            this.rdoIsQty.TabStop = true;
            this.rdoIsQty.Text = "Quantity";
            this.rdoIsQty.UseVisualStyleBackColor = true;
            // 
            // frm_mtrUom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(574, 492);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrUom";
            this.Text = "Uom Master";
            this.Load += new System.EventHandler(this.frm_mtrBranch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrUom_KeyDown);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUomName;
        private System.Windows.Forms.Label lblUomID;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtUomID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkPacking;
        private System.Windows.Forms.CheckBox chksales;
        private System.Windows.Forms.CheckBox chkVisibal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUomCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoCalculationKilo;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdoCalculationBag;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoIsWeight;
        private System.Windows.Forms.RadioButton rdoIsLength;
        private System.Windows.Forms.RadioButton rdoIsQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UomCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UomCategoryID;

    }
}