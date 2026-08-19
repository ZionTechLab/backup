namespace Digiteq
{
    partial class frm_mtrItemSubCategory_New
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
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSubCategoryID = new System.Windows.Forms.Label();
            this.lblSubCategoryName = new System.Windows.Forms.Label();
            this.txtSubCategoryName = new System.Windows.Forms.TextBox();
            this.txtSubCategoryID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.SubCategoryName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(5, 83);
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
            // CategoryID
            // 
            this.CategoryID.HeaderText = "Sub Category ID";
            this.CategoryID.Name = "CategoryID";
            // 
            // SubCategoryName
            // 
            this.SubCategoryName.HeaderText = "Sub Category Name";
            this.SubCategoryName.Name = "SubCategoryName";
            this.SubCategoryName.Width = 208;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblSubCategoryID);
            this.panel2.Controls.Add(this.lblSubCategoryName);
            this.panel2.Controls.Add(this.txtSubCategoryName);
            this.panel2.Controls.Add(this.txtSubCategoryID);
            this.panel2.Location = new System.Drawing.Point(6, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 70);
            this.panel2.TabIndex = 12;
            // 
            // lblSubCategoryID
            // 
            this.lblSubCategoryID.AutoSize = true;
            this.lblSubCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoryID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSubCategoryID.Location = new System.Drawing.Point(5, 13);
            this.lblSubCategoryID.Name = "lblSubCategoryID";
            this.lblSubCategoryID.Size = new System.Drawing.Size(86, 14);
            this.lblSubCategoryID.TabIndex = 72;
            this.lblSubCategoryID.Text = "Sub Category ID";
            // 
            // lblSubCategoryName
            // 
            this.lblSubCategoryName.AutoSize = true;
            this.lblSubCategoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSubCategoryName.Location = new System.Drawing.Point(5, 39);
            this.lblSubCategoryName.Name = "lblSubCategoryName";
            this.lblSubCategoryName.Size = new System.Drawing.Size(75, 14);
            this.lblSubCategoryName.TabIndex = 104;
            this.lblSubCategoryName.Text = "Sub Category ";
            // 
            // txtSubCategoryName
            // 
            this.txtSubCategoryName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategoryName.Location = new System.Drawing.Point(99, 36);
            this.txtSubCategoryName.Name = "txtSubCategoryName";
            this.txtSubCategoryName.Size = new System.Drawing.Size(199, 22);
            this.txtSubCategoryName.TabIndex = 1;
            this.txtSubCategoryName.Text = "Plastic Bag";
            // 
            // txtSubCategoryID
            // 
            this.txtSubCategoryID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtSubCategoryID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategoryID.Location = new System.Drawing.Point(99, 10);
            this.txtSubCategoryID.Name = "txtSubCategoryID";
            this.txtSubCategoryID.Size = new System.Drawing.Size(120, 22);
            this.txtSubCategoryID.TabIndex = 0;
            this.txtSubCategoryID.DoubleClick += new System.EventHandler(this.txtSubCategoryID_DoubleClick);
            // 
            // frm_mtrItemSubCategory_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Name = "frm_mtrItemSubCategory_New";
            this.Size = new System.Drawing.Size(322, 395);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_mtrItemSubCategory_New_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_mtrItemSubCategory_New_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.frm_mtrItemSubCategory_New_SF_cancelButton_Click);
            this.Load += new System.EventHandler(this.frm_mtrItemSubCategory_New_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrItemSubCategory_New_KeyDown);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSubCategoryID;
        private System.Windows.Forms.Label lblSubCategoryName;
        private System.Windows.Forms.TextBox txtSubCategoryName;
        private System.Windows.Forms.TextBox txtSubCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCategoryName;
    }
}