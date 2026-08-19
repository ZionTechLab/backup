namespace Digiteq
{
    partial class frm_BookNoShowAll
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
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBookNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Page = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allocated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.Route,
            this.Book,
            this.Remarks,
            this.Page,
            this.allocated});
            this.seacC_DataGrid1.Location = new System.Drawing.Point(9, 105);
            this.seacC_DataGrid1.Name = "seacC_DataGrid1";
            this.seacC_DataGrid1.ReadOnly = true;
            this.seacC_DataGrid1.RowHeadersVisible = false;
            this.seacC_DataGrid1.Size = new System.Drawing.Size(535, 385);
            this.seacC_DataGrid1.TabIndex = 0;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(92, 69);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(0);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(255, 22);
            this.txtRemarks.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(20, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "Remarks";
            // 
            // txtBookNO
            // 
            this.txtBookNO.BackColor = System.Drawing.Color.White;
            this.txtBookNO.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookNO.Location = new System.Drawing.Point(244, 39);
            this.txtBookNO.Margin = new System.Windows.Forms.Padding(0);
            this.txtBookNO.Name = "txtBookNO";
            this.txtBookNO.Size = new System.Drawing.Size(103, 22);
            this.txtBookNO.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(183, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "Book No";
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoute.Location = new System.Drawing.Point(20, 42);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(69, 14);
            this.lblRoute.TabIndex = 18;
            this.lblRoute.Text = "Route Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 69);
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
            // Route
            // 
            this.Route.DataPropertyName = "Route";
            this.Route.HeaderText = "Route";
            this.Route.Name = "Route";
            this.Route.ReadOnly = true;
            // 
            // Book
            // 
            this.Book.DataPropertyName = "Book";
            this.Book.HeaderText = "Book";
            this.Book.Name = "Book";
            this.Book.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // Page
            // 
            this.Page.DataPropertyName = "Page";
            this.Page.HeaderText = "Page";
            this.Page.Name = "Page";
            this.Page.ReadOnly = true;
            // 
            // allocated
            // 
            this.allocated.DataPropertyName = "allocated";
            this.allocated.HeaderText = "Allocated";
            this.allocated.Name = "allocated";
            this.allocated.ReadOnly = true;
            // 
            // frm_BookNoShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 499);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.txtBookNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.seacC_DataGrid1);
            this.Name = "frm_BookNoShowAll";
            this.Text = "Book No Show All";
            this.Load += new System.EventHandler(this.frm_BookNoShowAll_Load);
            this.Controls.SetChildIndex(this.seacC_DataGrid1, 0);
            this.Controls.SetChildIndex(this.lblRoute, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBookNO, 0);
            this.Controls.SetChildIndex(this.txtRoute, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtRemarks, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.seacC_DataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid seacC_DataGrid1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBookNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Page;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allocated;
    }
}