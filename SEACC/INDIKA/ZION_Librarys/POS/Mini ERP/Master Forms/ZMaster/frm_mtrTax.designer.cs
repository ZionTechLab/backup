namespace Digiteq
{
    partial class frm_mtrTax
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prifix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblReciveableGlID = new System.Windows.Forms.Label();
            this.txtRecivableGlID = new System.Windows.Forms.TextBox();
            this.lblPaybleGlID = new System.Windows.Forms.Label();
            this.txtPaybleGlID = new System.Windows.Forms.TextBox();
            this.lblPrifix = new System.Windows.Forms.Label();
            this.txtPresantage = new System.Windows.Forms.TextBox();
            this.lblClassID = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtTaxName = new System.Windows.Forms.TextBox();
            this.txtTaxID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(204, 177);
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
            this.CategoryID,
            this.Prifix,
            this.CategoryName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(5, 208);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(350, 252);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "Tax ID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Width = 95;
            // 
            // Prifix
            // 
            this.Prifix.HeaderText = "Presantage";
            this.Prifix.Name = "Prifix";
            this.Prifix.Width = 70;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Tax Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Width = 182;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblReciveableGlID);
            this.panel2.Controls.Add(this.txtRecivableGlID);
            this.panel2.Controls.Add(this.lblPaybleGlID);
            this.panel2.Controls.Add(this.txtPaybleGlID);
            this.panel2.Controls.Add(this.lblPrifix);
            this.panel2.Controls.Add(this.txtPresantage);
            this.panel2.Controls.Add(this.lblClassID);
            this.panel2.Controls.Add(this.lblClassName);
            this.panel2.Controls.Add(this.txtTaxName);
            this.panel2.Controls.Add(this.txtTaxID);
            this.panel2.Location = new System.Drawing.Point(6, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 139);
            this.panel2.TabIndex = 7;
            // 
            // lblReciveableGlID
            // 
            this.lblReciveableGlID.AutoSize = true;
            this.lblReciveableGlID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReciveableGlID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblReciveableGlID.Location = new System.Drawing.Point(4, 95);
            this.lblReciveableGlID.Name = "lblReciveableGlID";
            this.lblReciveableGlID.Size = new System.Drawing.Size(89, 14);
            this.lblReciveableGlID.TabIndex = 118;
            this.lblReciveableGlID.Text = "Reciveable Gl ID";
            // 
            // txtRecivableGlID
            // 
            this.txtRecivableGlID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecivableGlID.Location = new System.Drawing.Point(97, 92);
            this.txtRecivableGlID.Name = "txtRecivableGlID";
            this.txtRecivableGlID.ReadOnly = true;
            this.txtRecivableGlID.Size = new System.Drawing.Size(241, 22);
            this.txtRecivableGlID.TabIndex = 117;
            this.txtRecivableGlID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecivableGlID_KeyDown);
            this.txtRecivableGlID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtRecivableGlID_MouseDoubleClick);
            // 
            // lblPaybleGlID
            // 
            this.lblPaybleGlID.AutoSize = true;
            this.lblPaybleGlID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaybleGlID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPaybleGlID.Location = new System.Drawing.Point(4, 67);
            this.lblPaybleGlID.Name = "lblPaybleGlID";
            this.lblPaybleGlID.Size = new System.Drawing.Size(74, 14);
            this.lblPaybleGlID.TabIndex = 116;
            this.lblPaybleGlID.Text = "Payable Gl ID";
            // 
            // txtPaybleGlID
            // 
            this.txtPaybleGlID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaybleGlID.Location = new System.Drawing.Point(97, 64);
            this.txtPaybleGlID.Name = "txtPaybleGlID";
            this.txtPaybleGlID.ReadOnly = true;
            this.txtPaybleGlID.Size = new System.Drawing.Size(241, 22);
            this.txtPaybleGlID.TabIndex = 115;
            this.txtPaybleGlID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaybleGlID_KeyDown);
            this.txtPaybleGlID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPaybleGlID_MouseDoubleClick);
            // 
            // lblPrifix
            // 
            this.lblPrifix.AutoSize = true;
            this.lblPrifix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrifix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPrifix.Location = new System.Drawing.Point(218, 14);
            this.lblPrifix.Name = "lblPrifix";
            this.lblPrifix.Size = new System.Drawing.Size(62, 14);
            this.lblPrifix.TabIndex = 114;
            this.lblPrifix.Text = "Presantage";
            // 
            // txtPresantage
            // 
            this.txtPresantage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresantage.Location = new System.Drawing.Point(285, 10);
            this.txtPresantage.Name = "txtPresantage";
            this.txtPresantage.Size = new System.Drawing.Size(51, 22);
            this.txtPresantage.TabIndex = 113;
            this.txtPresantage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrifix_KeyPress);
            // 
            // lblClassID
            // 
            this.lblClassID.AutoSize = true;
            this.lblClassID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClassID.Location = new System.Drawing.Point(4, 14);
            this.lblClassID.Name = "lblClassID";
            this.lblClassID.Size = new System.Drawing.Size(38, 14);
            this.lblClassID.TabIndex = 72;
            this.lblClassID.Text = "Tax ID";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClassName.Location = new System.Drawing.Point(3, 39);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(57, 14);
            this.lblClassName.TabIndex = 104;
            this.lblClassName.Text = "Tax Name";
            // 
            // txtTaxName
            // 
            this.txtTaxName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxName.Location = new System.Drawing.Point(96, 36);
            this.txtTaxName.Name = "txtTaxName";
            this.txtTaxName.Size = new System.Drawing.Size(241, 22);
            this.txtTaxName.TabIndex = 1;
            this.txtTaxName.Text = "Plastic Bag";
            // 
            // txtTaxID
            // 
            this.txtTaxID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtTaxID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxID.Location = new System.Drawing.Point(96, 10);
            this.txtTaxID.Name = "txtTaxID";
            this.txtTaxID.Size = new System.Drawing.Size(114, 22);
            this.txtTaxID.TabIndex = 0;
            this.txtTaxID.DoubleClick += new System.EventHandler(this.txtClassID_DoubleClick);
            this.txtTaxID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClassID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(127, 177);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(281, 177);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(360, 468);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrTax";
            this.Text = "Tax Master";
            this.Load += new System.EventHandler(this.frm_mtrCustomerClass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrItemClass_KeyDown);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblClassID;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtTaxName;
        private System.Windows.Forms.TextBox txtTaxID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPrifix;
        private System.Windows.Forms.TextBox txtPresantage;
        private System.Windows.Forms.Label lblReciveableGlID;
        private System.Windows.Forms.TextBox txtRecivableGlID;
        private System.Windows.Forms.Label lblPaybleGlID;
        private System.Windows.Forms.TextBox txtPaybleGlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prifix;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;

    }
}