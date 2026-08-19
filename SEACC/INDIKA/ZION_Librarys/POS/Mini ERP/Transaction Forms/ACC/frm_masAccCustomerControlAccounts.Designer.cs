namespace Digiteq
{
    partial class frm_masAccCustomerControlAccounts
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.txtCustomerClassID = new System.Windows.Forms.TextBox();
            this.txtCustomerTypeID = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CustomerClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.CustomerClass,
            this.CustomerType,
            this.CustomerCategory,
            this.CustomerCode,
            this.CustomerName,
            this.GLCode,
            this.GLName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(6, 95);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(802, 397);
            this.dgvDetail.TabIndex = 368;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(438, 63);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(194, 22);
            this.txtCustomerID.TabIndex = 370;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(353, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 369;
            this.label2.Text = "Customer ";
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryID.Location = new System.Drawing.Point(438, 37);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(194, 22);
            this.txtCategoryID.TabIndex = 402;
            this.txtCategoryID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCategoryID_KeyUp);
            // 
            // txtCustomerClassID
            // 
            this.txtCustomerClassID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerClassID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerClassID.Location = new System.Drawing.Point(117, 37);
            this.txtCustomerClassID.Name = "txtCustomerClassID";
            this.txtCustomerClassID.Size = new System.Drawing.Size(207, 22);
            this.txtCustomerClassID.TabIndex = 401;
            this.txtCustomerClassID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerClassID_KeyUp);
            // 
            // txtCustomerTypeID
            // 
            this.txtCustomerTypeID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerTypeID.Location = new System.Drawing.Point(117, 63);
            this.txtCustomerTypeID.Name = "txtCustomerTypeID";
            this.txtCustomerTypeID.Size = new System.Drawing.Size(207, 22);
            this.txtCustomerTypeID.TabIndex = 400;
            this.txtCustomerTypeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerTypeID_KeyUp);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label25.Location = new System.Drawing.Point(353, 40);
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
            this.label6.Location = new System.Drawing.Point(10, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 14);
            this.label6.TabIndex = 403;
            this.label6.Text = "Customer Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(10, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 404;
            this.label5.Text = "Customer Class";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.btnNew);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.txtCustomerClassID);
            this.pnlBody.Controls.Add(this.dgvDetail);
            this.pnlBody.Controls.Add(this.txtCategoryID);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.txtCustomerID);
            this.pnlBody.Controls.Add(this.txtCustomerTypeID);
            this.pnlBody.Controls.Add(this.label5);
            this.pnlBody.Controls.Add(this.label25);
            this.pnlBody.Controls.Add(this.label6);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(3, 29);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(814, 500);
            this.pnlBody.TabIndex = 406;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(703, 60);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 25);
            this.btnNew.TabIndex = 441;
            this.btnNew.Text = "  Clear Filter";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 438;
            this.label1.Text = "Filters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(799, 14);
            this.label3.TabIndex = 439;
            this.label3.Text = "_________________________________________________________________________________" +
    "___________________________________________________";
            // 
            // CustomerClass
            // 
            this.CustomerClass.DataPropertyName = "CustomerClass";
            this.CustomerClass.HeaderText = "Customer Class";
            this.CustomerClass.Name = "CustomerClass";
            this.CustomerClass.ReadOnly = true;
            this.CustomerClass.Width = 90;
            // 
            // CustomerType
            // 
            this.CustomerType.DataPropertyName = "CustomerType";
            this.CustomerType.HeaderText = "Customer Type";
            this.CustomerType.Name = "CustomerType";
            this.CustomerType.ReadOnly = true;
            this.CustomerType.Width = 90;
            // 
            // CustomerCategory
            // 
            this.CustomerCategory.DataPropertyName = "CustomerCategory";
            this.CustomerCategory.HeaderText = "Customer Category";
            this.CustomerCategory.Name = "CustomerCategory";
            this.CustomerCategory.ReadOnly = true;
            // 
            // CustomerCode
            // 
            this.CustomerCode.DataPropertyName = "CustomerCode";
            this.CustomerCode.HeaderText = "Customer Code";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 200;
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
            // frm_masAccCustomerControlAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 532);
            this.Controls.Add(this.pnlBody);
            this.Name = "frm_masAccCustomerControlAccounts";
            this.Text = "Customer Control Accounts";
            this.Load += new System.EventHandler(this.frm_masAccCustomerControlAccounts_Load);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.TextBox txtCustomerClassID;
        private System.Windows.Forms.TextBox txtCustomerTypeID;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLName;
    }
}