namespace Digiteq
{
    partial class frm_mtrJobPolytheneMaterialType
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
            this.polytheneMaterailType_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dencity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polytheneMaterailTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDencity = new System.Windows.Forms.Label();
            this.txtDencity = new System.Windows.Forms.TextBox();
            this.lblJobPolytheneMaterialTypeID = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtPolytheneMaterailTypeName = new System.Windows.Forms.TextBox();
            this.txtJobPolythenMaterialTypeID = new System.Windows.Forms.TextBox();
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
            this.btnDelete.Location = new System.Drawing.Point(167, 122);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 16;
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
            this.polytheneMaterailType_ID,
            this.Dencity,
            this.polytheneMaterailTypeName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(8, 153);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 252);
            this.dgvDetail.TabIndex = 15;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // polytheneMaterailType_ID
            // 
            this.polytheneMaterailType_ID.HeaderText = "Type ID";
            this.polytheneMaterailType_ID.Name = "polytheneMaterailType_ID";
            this.polytheneMaterailType_ID.Width = 90;
            // 
            // Dencity
            // 
            this.Dencity.HeaderText = "Dencity";
            this.Dencity.Name = "Dencity";
            this.Dencity.Width = 55;
            // 
            // polytheneMaterailTypeName
            // 
            this.polytheneMaterailTypeName.HeaderText = "Material Name";
            this.polytheneMaterailTypeName.Name = "polytheneMaterailTypeName";
            this.polytheneMaterailTypeName.Width = 162;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblDencity);
            this.panel2.Controls.Add(this.txtDencity);
            this.panel2.Controls.Add(this.lblJobPolytheneMaterialTypeID);
            this.panel2.Controls.Add(this.lblClassName);
            this.panel2.Controls.Add(this.txtPolytheneMaterailTypeName);
            this.panel2.Controls.Add(this.txtJobPolythenMaterialTypeID);
            this.panel2.Location = new System.Drawing.Point(7, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 70);
            this.panel2.TabIndex = 12;
            // 
            // lblDencity
            // 
            this.lblDencity.AutoSize = true;
            this.lblDencity.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDencity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDencity.Location = new System.Drawing.Point(187, 13);
            this.lblDencity.Name = "lblDencity";
            this.lblDencity.Size = new System.Drawing.Size(45, 14);
            this.lblDencity.TabIndex = 114;
            this.lblDencity.Text = "Dencity";
            // 
            // txtDencity
            // 
            this.txtDencity.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDencity.Location = new System.Drawing.Point(232, 10);
            this.txtDencity.Name = "txtDencity";
            this.txtDencity.Size = new System.Drawing.Size(65, 22);
            this.txtDencity.TabIndex = 113;
            this.txtDencity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDencity_KeyPress);
            // 
            // lblJobPolytheneMaterialTypeID
            // 
            this.lblJobPolytheneMaterialTypeID.AutoSize = true;
            this.lblJobPolytheneMaterialTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobPolytheneMaterialTypeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblJobPolytheneMaterialTypeID.Location = new System.Drawing.Point(3, 13);
            this.lblJobPolytheneMaterialTypeID.Name = "lblJobPolytheneMaterialTypeID";
            this.lblJobPolytheneMaterialTypeID.Size = new System.Drawing.Size(45, 14);
            this.lblJobPolytheneMaterialTypeID.TabIndex = 72;
            this.lblJobPolytheneMaterialTypeID.Text = "Type ID";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClassName.Location = new System.Drawing.Point(2, 39);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(82, 14);
            this.lblClassName.TabIndex = 104;
            this.lblClassName.Text = "Material Name";
            // 
            // txtPolytheneMaterailTypeName
            // 
            this.txtPolytheneMaterailTypeName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPolytheneMaterailTypeName.Location = new System.Drawing.Point(84, 36);
            this.txtPolytheneMaterailTypeName.Name = "txtPolytheneMaterailTypeName";
            this.txtPolytheneMaterailTypeName.Size = new System.Drawing.Size(213, 22);
            this.txtPolytheneMaterailTypeName.TabIndex = 1;
            this.txtPolytheneMaterailTypeName.Text = "Plastic Bag";
            // 
            // txtJobPolythenMaterialTypeID
            // 
            this.txtJobPolythenMaterialTypeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtJobPolythenMaterialTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobPolythenMaterialTypeID.Location = new System.Drawing.Point(84, 10);
            this.txtJobPolythenMaterialTypeID.Name = "txtJobPolythenMaterialTypeID";
            this.txtJobPolythenMaterialTypeID.Size = new System.Drawing.Size(102, 22);
            this.txtJobPolythenMaterialTypeID.TabIndex = 0;
            this.txtJobPolythenMaterialTypeID.DoubleClick += new System.EventHandler(this.txtJobPolythenMaterialTypeID_DoubleClick);
            this.txtJobPolythenMaterialTypeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobPolythenMaterialTypeID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(90, 122);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(244, 122);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_mtrJobPolytheneMaterialType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(326, 413);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Name = "frm_mtrJobPolytheneMaterialType";
            this.Text = "Job Polythene Material Type Master";
            this.Load += new System.EventHandler(this.frm_mtrJobPolytheneMaterialType_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrJobPolytheneMaterialType_KeyDown);
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
        private System.Windows.Forms.Label lblDencity;
        private System.Windows.Forms.TextBox txtDencity;
        private System.Windows.Forms.Label lblJobPolytheneMaterialTypeID;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtPolytheneMaterailTypeName;
        private System.Windows.Forms.TextBox txtJobPolythenMaterialTypeID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn polytheneMaterailType_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dencity;
        private System.Windows.Forms.DataGridViewTextBoxColumn polytheneMaterailTypeName;
    }
}