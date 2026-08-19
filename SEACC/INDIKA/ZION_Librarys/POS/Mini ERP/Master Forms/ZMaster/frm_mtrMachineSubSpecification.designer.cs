namespace Digiteq
{
    partial class frm_mtrMachineSubSpecification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtSubCategoryID = new System.Windows.Forms.TextBox();
            this.lblSupplierTypeID = new System.Windows.Forms.Label();
            this.btnSpecification = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvSpecification = new System.Windows.Forms.DataGridView();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecificationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecificationValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecification)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(358, 146);
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
            this.panel2.Controls.Add(this.txtCategoryID);
            this.panel2.Controls.Add(this.lblClassName);
            this.panel2.Controls.Add(this.txtSubCategoryID);
            this.panel2.Controls.Add(this.lblSupplierTypeID);
            this.panel2.Location = new System.Drawing.Point(6, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(505, 86);
            this.panel2.TabIndex = 7;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryID.Location = new System.Drawing.Point(107, 14);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.ReadOnly = true;
            this.txtCategoryID.Size = new System.Drawing.Size(199, 22);
            this.txtCategoryID.TabIndex = 107;
            this.txtCategoryID.Text = "Plastic Bag";
            this.txtCategoryID.DoubleClick += new System.EventHandler(this.txtItemType_DoubleClick);
            this.txtCategoryID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemType_KeyDown);
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClassName.Location = new System.Drawing.Point(5, 18);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(84, 14);
            this.lblClassName.TabIndex = 106;
            this.lblClassName.Text = "Category Name";
            // 
            // txtSubCategoryID
            // 
            this.txtSubCategoryID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtSubCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategoryID.Location = new System.Drawing.Point(107, 46);
            this.txtSubCategoryID.Name = "txtSubCategoryID";
            this.txtSubCategoryID.ReadOnly = true;
            this.txtSubCategoryID.Size = new System.Drawing.Size(199, 22);
            this.txtSubCategoryID.TabIndex = 105;
            this.txtSubCategoryID.Text = "Plastic Bag";
            this.txtSubCategoryID.DoubleClick += new System.EventHandler(this.txtClassName_DoubleClick);
            this.txtSubCategoryID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClassName_KeyDown);
            // 
            // lblSupplierTypeID
            // 
            this.lblSupplierTypeID.AutoSize = true;
            this.lblSupplierTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierTypeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSupplierTypeID.Location = new System.Drawing.Point(5, 49);
            this.lblSupplierTypeID.Name = "lblSupplierTypeID";
            this.lblSupplierTypeID.Size = new System.Drawing.Size(86, 14);
            this.lblSupplierTypeID.TabIndex = 72;
            this.lblSupplierTypeID.Text = "Sub Category ID";
            // 
            // btnSpecification
            // 
            this.btnSpecification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnSpecification.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpecification.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpecification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSpecification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSpecification.Location = new System.Drawing.Point(9, 145);
            this.btnSpecification.Name = "btnSpecification";
            this.btnSpecification.Size = new System.Drawing.Size(120, 27);
            this.btnSpecification.TabIndex = 473;
            this.btnSpecification.Text = "Specification";
            this.btnSpecification.UseVisualStyleBackColor = false;
            this.btnSpecification.Click += new System.EventHandler(this.btnSpecification_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(281, 146);
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
            this.btnSave.Location = new System.Drawing.Point(435, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvSpecification
            // 
            this.dgvSpecification.AllowUserToAddRows = false;
            this.dgvSpecification.AllowUserToResizeColumns = false;
            this.dgvSpecification.AllowUserToResizeRows = false;
            this.dgvSpecification.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvSpecification.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSpecification.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSpecification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.SpecificationID,
            this.SpecificationValue});
            this.dgvSpecification.EnableHeadersVisualStyles = false;
            this.dgvSpecification.Location = new System.Drawing.Point(7, 176);
            this.dgvSpecification.MultiSelect = false;
            this.dgvSpecification.Name = "dgvSpecification";
            this.dgvSpecification.RowHeadersVisible = false;
            this.dgvSpecification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSpecification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpecification.Size = new System.Drawing.Size(505, 232);
            this.dgvSpecification.TabIndex = 12;
            this.dgvSpecification.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvSpecification.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "CategoryID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Visible = false;
            // 
            // SpecificationID
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.SpecificationID.DefaultCellStyle = dataGridViewCellStyle1;
            this.SpecificationID.HeaderText = "Specification";
            this.SpecificationID.Name = "SpecificationID";
            this.SpecificationID.ReadOnly = true;
            this.SpecificationID.Width = 251;
            // 
            // SpecificationValue
            // 
            this.SpecificationValue.HeaderText = "Specification Value";
            this.SpecificationValue.Name = "SpecificationValue";
            this.SpecificationValue.Width = 251;
            // 
            // frm_mtrMachineSubSpecification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(520, 415);
            this.Controls.Add(this.btnSpecification);
            this.Controls.Add(this.dgvSpecification);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_mtrMachineSubSpecification";
            this.Text = "Machine Specification Value Master";
            this.Load += new System.EventHandler(this.frm_mtrMachineType_Load);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.dgvSpecification, 0);
            this.Controls.SetChildIndex(this.btnSpecification, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSupplierTypeID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtSubCategoryID;
        private System.Windows.Forms.DataGridView dgvSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecificationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecificationValue;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.Button btnSpecification;

    }
}