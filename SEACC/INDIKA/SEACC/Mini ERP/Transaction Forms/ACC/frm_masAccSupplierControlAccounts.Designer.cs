namespace Digiteq
{
    partial class frm_masAccSupplierControlAccounts
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
            this.dgvDetail = new SEACC_DataGrid();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.txtSupplierClassID = new System.Windows.Forms.TextBox();
            this.txtSupplierTypeID = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SupplierClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeight = 35;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierClass,
            this.SupplierType,
            this.SupplierCategory,
            this.SupplierCode,
            this.SupplierName,
            this.GLCode,
            this.GLName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(6, 91);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(802, 397);
            this.dgvDetail.TabIndex = 369;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryID.Location = new System.Drawing.Point(425, 38);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(203, 22);
            this.txtCategoryID.TabIndex = 402;
            this.txtCategoryID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCategoryID_KeyUp);
            // 
            // txtSupplierClassID
            // 
            this.txtSupplierClassID.BackColor = System.Drawing.SystemColors.Window;
            this.txtSupplierClassID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierClassID.Location = new System.Drawing.Point(108, 38);
            this.txtSupplierClassID.Name = "txtSupplierClassID";
            this.txtSupplierClassID.Size = new System.Drawing.Size(203, 22);
            this.txtSupplierClassID.TabIndex = 401;
            this.txtSupplierClassID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSupplierClassID_KeyUp);
            // 
            // txtSupplierTypeID
            // 
            this.txtSupplierTypeID.BackColor = System.Drawing.SystemColors.Window;
            this.txtSupplierTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierTypeID.Location = new System.Drawing.Point(108, 63);
            this.txtSupplierTypeID.Name = "txtSupplierTypeID";
            this.txtSupplierTypeID.Size = new System.Drawing.Size(203, 22);
            this.txtSupplierTypeID.TabIndex = 400;
            this.txtSupplierTypeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSupplierTypeID_KeyUp);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label25.Location = new System.Drawing.Point(345, 42);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(51, 14);
            this.label25.TabIndex = 405;
            this.label25.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(12, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 403;
            this.label6.Text = "Supplier Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(12, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 404;
            this.label5.Text = "Supplier Class";
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.SystemColors.Window;
            this.txtSupplierID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierID.Location = new System.Drawing.Point(425, 64);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(203, 22);
            this.txtSupplierID.TabIndex = 406;
            this.txtSupplierID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSupplierID_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(345, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 407;
            this.label1.Text = "Supplier ";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.btnNew);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.dgvDetail);
            this.pnlBody.Controls.Add(this.txtSupplierID);
            this.pnlBody.Controls.Add(this.txtSupplierClassID);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.label5);
            this.pnlBody.Controls.Add(this.txtCategoryID);
            this.pnlBody.Controls.Add(this.label6);
            this.pnlBody.Controls.Add(this.label25);
            this.pnlBody.Controls.Add(this.txtSupplierTypeID);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(3, 29);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(814, 496);
            this.pnlBody.TabIndex = 408;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(703, 61);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 25);
            this.btnNew.TabIndex = 440;
            this.btnNew.Text = "  Clear Filter";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 438;
            this.label2.Text = "Filters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(8, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(799, 14);
            this.label3.TabIndex = 439;
            this.label3.Text = "_________________________________________________________________________________" +
    "___________________________________________________";
            // 
            // SupplierClass
            // 
            this.SupplierClass.DataPropertyName = "SupplierClass";
            this.SupplierClass.HeaderText = "Supplier Class";
            this.SupplierClass.Name = "SupplierClass";
            this.SupplierClass.ReadOnly = true;
            this.SupplierClass.Width = 90;
            // 
            // SupplierType
            // 
            this.SupplierType.DataPropertyName = "SupplierType";
            this.SupplierType.HeaderText = "Supplier Type";
            this.SupplierType.Name = "SupplierType";
            this.SupplierType.ReadOnly = true;
            this.SupplierType.Width = 90;
            // 
            // SupplierCategory
            // 
            this.SupplierCategory.DataPropertyName = "SupplierCategory";
            this.SupplierCategory.HeaderText = "Supplier Category";
            this.SupplierCategory.Name = "SupplierCategory";
            this.SupplierCategory.ReadOnly = true;
            // 
            // SupplierCode
            // 
            this.SupplierCode.DataPropertyName = "SupplierCode";
            this.SupplierCode.HeaderText = "Supplier Code";
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.ReadOnly = true;
            // 
            // SupplierName
            // 
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "Supplier Name";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            this.SupplierName.Width = 200;
            // 
            // GLCode
            // 
            this.GLCode.DataPropertyName = "GLCode";
            this.GLCode.HeaderText = "GL Code";
            this.GLCode.Name = "GLCode";
            this.GLCode.ReadOnly = true;
            this.GLCode.Visible = false;
            // 
            // GLName
            // 
            this.GLName.DataPropertyName = "GLName";
            this.GLName.HeaderText = "GL Name";
            this.GLName.Name = "GLName";
            this.GLName.ReadOnly = true;
            this.GLName.Width = 200;
            // 
            // frm_masAccSupplierControlAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 528);
            this.Controls.Add(this.pnlBody);
            this.Name = "frm_masAccSupplierControlAccounts";
            this.Text = "Supplier Control Accounts";
            this.Load += new System.EventHandler(this.frm_masAccSupplierControlAccounts_Load);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.TextBox txtSupplierClassID;
        private System.Windows.Forms.TextBox txtSupplierTypeID;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLName;

    }
}