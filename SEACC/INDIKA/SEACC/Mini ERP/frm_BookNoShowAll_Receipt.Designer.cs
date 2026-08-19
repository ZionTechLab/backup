namespace Digiteq
{
    partial class frm_BookNoShowAll_Receipt
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
            this.seacC_DataGrid1 = new Digiteq.SEACC_DataGrid();
            this.lblRoute = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.selesRep_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allocated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.seacC_DataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // seacC_DataGrid1
            // 
            this.seacC_DataGrid1.AllowUserToAddRows = false;
            this.seacC_DataGrid1.AllowUserToDeleteRows = false;
            this.seacC_DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seacC_DataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selesRep_ID,
            this.selesRepName,
            this.book_No,
            this.PageNo,
            this.allocated});
            this.seacC_DataGrid1.Location = new System.Drawing.Point(9, 105);
            this.seacC_DataGrid1.Name = "seacC_DataGrid1";
            this.seacC_DataGrid1.ReadOnly = true;
            this.seacC_DataGrid1.RowHeadersVisible = false;
            this.seacC_DataGrid1.Size = new System.Drawing.Size(535, 385);
            this.seacC_DataGrid1.TabIndex = 0;
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoute.Location = new System.Drawing.Point(20, 42);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(55, 14);
            this.lblRoute.TabIndex = 18;
            this.lblRoute.Text = "Sales Rep";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(381, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Search";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.White;
            this.txtRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(92, 39);
            this.txtRoute.Margin = new System.Windows.Forms.Padding(0);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(88, 22);
            this.txtRoute.TabIndex = 22;
            // 
            // selesRep_ID
            // 
            this.selesRep_ID.DataPropertyName = "selesRep_ID";
            this.selesRep_ID.HeaderText = "Rep ID";
            this.selesRep_ID.Name = "selesRep_ID";
            this.selesRep_ID.ReadOnly = true;
            // 
            // selesRepName
            // 
            this.selesRepName.DataPropertyName = "selesRepName";
            this.selesRepName.HeaderText = "Seles Rep Name";
            this.selesRepName.Name = "selesRepName";
            this.selesRepName.ReadOnly = true;
            // 
            // book_No
            // 
            this.book_No.DataPropertyName = "book_No";
            this.book_No.HeaderText = "Book No";
            this.book_No.Name = "book_No";
            this.book_No.ReadOnly = true;
            // 
            // PageNo
            // 
            this.PageNo.DataPropertyName = "PageNo";
            this.PageNo.HeaderText = "Page";
            this.PageNo.Name = "PageNo";
            this.PageNo.ReadOnly = true;
            // 
            // allocated
            // 
            this.allocated.DataPropertyName = "Allocated";
            this.allocated.HeaderText = "Allocated";
            this.allocated.Name = "allocated";
            this.allocated.ReadOnly = true;
            this.allocated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.allocated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frm_BookNoShowAll_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 499);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.seacC_DataGrid1);
            this.Name = "frm_BookNoShowAll_Receipt";
            this.Text = "Book No Show All";
            this.Load += new System.EventHandler(this.frm_BookNoShowAll_Load);
            this.Controls.SetChildIndex(this.seacC_DataGrid1, 0);
            this.Controls.SetChildIndex(this.lblRoute, 0);
            this.Controls.SetChildIndex(this.txtRoute, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.seacC_DataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid seacC_DataGrid1;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn selesRep_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn selesRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn allocated;
    }
}