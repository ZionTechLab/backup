namespace Digiteq
{
    partial class frmSearchMaster_Multiple_ProductionJob
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
            this.dgv_Search = new System.Windows.Forms.DataGridView();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.txt_ContenttoSearch = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_ContentSearch = new System.Windows.Forms.Label();
            this.IsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CategoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Search
            // 
            this.dgv_Search.AllowUserToAddRows = false;
            this.dgv_Search.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgv_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Search.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelect,
            this.CategoryCode,
            this.CategoryName,
            this.CategoryStatus});
            this.dgv_Search.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Search.Location = new System.Drawing.Point(8, 41);
            this.dgv_Search.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgv_Search.MultiSelect = false;
            this.dgv_Search.Name = "dgv_Search";
            this.dgv_Search.RowHeadersVisible = false;
            this.dgv_Search.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Search.Size = new System.Drawing.Size(531, 412);
            this.dgv_Search.TabIndex = 52;
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_Ok.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Black;
            //this.btn_Ok.Image = global::Digiteq.Properties.Resources.accept;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.Location = new System.Drawing.Point(389, 11);
            this.btn_Ok.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 25);
            this.btn_Ok.TabIndex = 50;
            this.btn_Ok.Text = "  Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // txt_ContenttoSearch
            // 
            this.txt_ContenttoSearch.BackColor = System.Drawing.Color.White;
            this.txt_ContenttoSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ContenttoSearch.Location = new System.Drawing.Point(72, 12);
            this.txt_ContenttoSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ContenttoSearch.Name = "txt_ContenttoSearch";
            this.txt_ContenttoSearch.Size = new System.Drawing.Size(237, 23);
            this.txt_ContenttoSearch.TabIndex = 48;
            this.txt_ContenttoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ContenttoSearch_KeyDown);
            this.txt_ContenttoSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ContenttoSearch_KeyUp);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_Close.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Black;
            //this.btn_Close.Image = global::Digiteq.Properties.Resources.delete;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(464, 11);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 25);
            this.btn_Close.TabIndex = 51;
            this.btn_Close.Text = "     Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_ContentSearch
            // 
            this.lbl_ContentSearch.AutoSize = true;
            this.lbl_ContentSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ContentSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbl_ContentSearch.Location = new System.Drawing.Point(11, 15);
            this.lbl_ContentSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ContentSearch.Name = "lbl_ContentSearch";
            this.lbl_ContentSearch.Size = new System.Drawing.Size(43, 15);
            this.lbl_ContentSearch.TabIndex = 49;
            this.lbl_ContentSearch.Text = "Search";
            // 
            // IsSelect
            // 
            this.IsSelect.DataPropertyName = "IsSelect";
            this.IsSelect.HeaderText = "Select";
            this.IsSelect.Name = "IsSelect";
            this.IsSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelect.Width = 50;
            // 
            // CategoryCode
            // 
            this.CategoryCode.DataPropertyName = "CategoryCode";
            this.CategoryCode.HeaderText = "Type Code";
            this.CategoryCode.Name = "CategoryCode";
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Type Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Width = 275;
            // 
            // CategoryStatus
            // 
            this.CategoryStatus.DataPropertyName = "CategoryStatus";
            this.CategoryStatus.HeaderText = "Status";
            this.CategoryStatus.Name = "CategoryStatus";
            // 
            // frmSearchMaster_Multiple_ProductionJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(550, 465);
            this.Controls.Add(this.dgv_Search);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.txt_ContenttoSearch);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_ContentSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSearchMaster_Multiple_ProductionJob";
            this.Text = "frmSearchMaster_ItemCategory";
            this.Load += new System.EventHandler(this.frmSearchMaster_ItemCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Search;
        internal System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.TextBox txt_ContenttoSearch;
        internal System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_ContentSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryStatus;
    }
}