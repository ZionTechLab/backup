namespace Digiteq
{
    partial class frmSearchMaster_ItemType
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
            this.IsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_SearchShowby = new System.Windows.Forms.ComboBox();
            this.cmb_Searchby = new System.Windows.Forms.ComboBox();
            this.lbl_Searchby = new System.Windows.Forms.Label();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.txt_ContenttoSearch = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_ContentSearch = new System.Windows.Forms.Label();
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
            this.TypeCode,
            this.TypeName});
            this.dgv_Search.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Search.Location = new System.Drawing.Point(8, 39);
            this.dgv_Search.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgv_Search.MultiSelect = false;
            this.dgv_Search.Name = "dgv_Search";
            this.dgv_Search.RowHeadersVisible = false;
            this.dgv_Search.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Search.Size = new System.Drawing.Size(354, 335);
            this.dgv_Search.TabIndex = 47;
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
            // TypeCode
            // 
            this.TypeCode.DataPropertyName = "TypeCode";
            this.TypeCode.HeaderText = "Type Code";
            this.TypeCode.Name = "TypeCode";
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "Type Name";
            this.TypeName.Name = "TypeName";
            this.TypeName.Width = 200;
            // 
            // cmb_SearchShowby
            // 
            this.cmb_SearchShowby.FormattingEnabled = true;
            this.cmb_SearchShowby.Location = new System.Drawing.Point(139, 277);
            this.cmb_SearchShowby.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_SearchShowby.Name = "cmb_SearchShowby";
            this.cmb_SearchShowby.Size = new System.Drawing.Size(193, 22);
            this.cmb_SearchShowby.TabIndex = 50;
            // 
            // cmb_Searchby
            // 
            this.cmb_Searchby.FormattingEnabled = true;
            this.cmb_Searchby.Location = new System.Drawing.Point(139, 277);
            this.cmb_Searchby.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_Searchby.Name = "cmb_Searchby";
            this.cmb_Searchby.Size = new System.Drawing.Size(193, 22);
            this.cmb_Searchby.TabIndex = 49;
            this.cmb_Searchby.Visible = false;
            // 
            // lbl_Searchby
            // 
            this.lbl_Searchby.AutoSize = true;
            this.lbl_Searchby.ForeColor = System.Drawing.Color.Black;
            this.lbl_Searchby.Location = new System.Drawing.Point(28, 283);
            this.lbl_Searchby.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Searchby.Name = "lbl_Searchby";
            this.lbl_Searchby.Size = new System.Drawing.Size(58, 14);
            this.lbl_Searchby.TabIndex = 48;
            this.lbl_Searchby.Text = "Search by";
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_Ok.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Black;
            //this.btn_Ok.Image = global::Digiteq.Properties.Resources.accept;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.Location = new System.Drawing.Point(212, 8);
            this.btn_Ok.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 25);
            this.btn_Ok.TabIndex = 45;
            this.btn_Ok.Text = "  Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // txt_ContenttoSearch
            // 
            this.txt_ContenttoSearch.BackColor = System.Drawing.Color.White;
            this.txt_ContenttoSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ContenttoSearch.Location = new System.Drawing.Point(52, 9);
            this.txt_ContenttoSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ContenttoSearch.Name = "txt_ContenttoSearch";
            this.txt_ContenttoSearch.Size = new System.Drawing.Size(141, 23);
            this.txt_ContenttoSearch.TabIndex = 43;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_Close.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Black;
            //this.btn_Close.Image = global::Digiteq.Properties.Resources.delete;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(287, 8);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 25);
            this.btn_Close.TabIndex = 46;
            this.btn_Close.Text = "     Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_ContentSearch
            // 
            this.lbl_ContentSearch.AutoSize = true;
            this.lbl_ContentSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ContentSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbl_ContentSearch.Location = new System.Drawing.Point(5, 12);
            this.lbl_ContentSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ContentSearch.Name = "lbl_ContentSearch";
            this.lbl_ContentSearch.Size = new System.Drawing.Size(43, 15);
            this.lbl_ContentSearch.TabIndex = 44;
            this.lbl_ContentSearch.Text = "Search";
            // 
            // frmSearchMaster_ItemCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(375, 382);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_Search);
            this.Controls.Add(this.cmb_SearchShowby);
            this.Controls.Add(this.cmb_Searchby);
            this.Controls.Add(this.lbl_Searchby);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.txt_ContenttoSearch);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_ContentSearch);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSearchMaster_ItemCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Search;
        private System.Windows.Forms.ComboBox cmb_SearchShowby;
        private System.Windows.Forms.ComboBox cmb_Searchby;
        private System.Windows.Forms.Label lbl_Searchby;
        internal System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.TextBox txt_ContenttoSearch;
        internal System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_ContentSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;

    }
}