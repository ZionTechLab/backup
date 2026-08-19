namespace Digiteq
{
    partial class frmSearchMaster_WC
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
            this.lbl_ContentSearch = new System.Windows.Forms.Label();
            this.txt_ContenttoSearch = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.cmb_SearchShowby = new System.Windows.Forms.ComboBox();
            this.cmb_Searchby = new System.Windows.Forms.ComboBox();
            this.lbl_Searchby = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Search
            // 
            this.dgv_Search.AllowUserToAddRows = false;
            this.dgv_Search.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgv_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Search.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Search.Location = new System.Drawing.Point(6, 38);
            this.dgv_Search.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgv_Search.MultiSelect = false;
            this.dgv_Search.Name = "dgv_Search";
            this.dgv_Search.RowHeadersVisible = false;
            this.dgv_Search.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Search.Size = new System.Drawing.Size(354, 335);
            this.dgv_Search.TabIndex = 39;
            this.dgv_Search.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Search_CellClick);
            this.dgv_Search.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Search_CellContentClick);
            this.dgv_Search.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Search_CellDoubleClick);
            this.dgv_Search.Click += new System.EventHandler(this.dgv_Search_Click_1);
            // 
            // lbl_ContentSearch
            // 
            this.lbl_ContentSearch.AutoSize = true;
            this.lbl_ContentSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ContentSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbl_ContentSearch.Location = new System.Drawing.Point(3, 11);
            this.lbl_ContentSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ContentSearch.Name = "lbl_ContentSearch";
            this.lbl_ContentSearch.Size = new System.Drawing.Size(43, 15);
            this.lbl_ContentSearch.TabIndex = 33;
            this.lbl_ContentSearch.Text = "Search";
            // 
            // txt_ContenttoSearch
            // 
            this.txt_ContenttoSearch.BackColor = System.Drawing.Color.White;
            this.txt_ContenttoSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ContenttoSearch.Location = new System.Drawing.Point(50, 8);
            this.txt_ContenttoSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_ContenttoSearch.Name = "txt_ContenttoSearch";
            this.txt_ContenttoSearch.Size = new System.Drawing.Size(141, 23);
            this.txt_ContenttoSearch.TabIndex = 32;
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
            this.btn_Close.Location = new System.Drawing.Point(285, 7);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 25);
            this.btn_Close.TabIndex = 38;
            this.btn_Close.Text = "     Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_Ok.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Black;
            //this.btn_Ok.Image = global::Digiteq.Properties.Resources.accept;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.Location = new System.Drawing.Point(210, 7);
            this.btn_Ok.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 25);
            this.btn_Ok.TabIndex = 37;
            this.btn_Ok.Text = "  Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // cmb_SearchShowby
            // 
            this.cmb_SearchShowby.FormattingEnabled = true;
            this.cmb_SearchShowby.Location = new System.Drawing.Point(137, 276);
            this.cmb_SearchShowby.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_SearchShowby.Name = "cmb_SearchShowby";
            this.cmb_SearchShowby.Size = new System.Drawing.Size(193, 22);
            this.cmb_SearchShowby.TabIndex = 42;
            // 
            // cmb_Searchby
            // 
            this.cmb_Searchby.FormattingEnabled = true;
            this.cmb_Searchby.Location = new System.Drawing.Point(137, 276);
            this.cmb_Searchby.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmb_Searchby.Name = "cmb_Searchby";
            this.cmb_Searchby.Size = new System.Drawing.Size(193, 22);
            this.cmb_Searchby.TabIndex = 41;
            this.cmb_Searchby.Visible = false;
            // 
            // lbl_Searchby
            // 
            this.lbl_Searchby.AutoSize = true;
            this.lbl_Searchby.ForeColor = System.Drawing.Color.Black;
            this.lbl_Searchby.Location = new System.Drawing.Point(26, 282);
            this.lbl_Searchby.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Searchby.Name = "lbl_Searchby";
            this.lbl_Searchby.Size = new System.Drawing.Size(58, 14);
            this.lbl_Searchby.TabIndex = 40;
            this.lbl_Searchby.Text = "Search by";
            // 
            // frmSearchMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(367, 380);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSearchMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Deactivate += new System.EventHandler(this.frm_HelpSearch_Deactivate);
            this.Load += new System.EventHandler(this.frm_HelpSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Search;
        private System.Windows.Forms.Label lbl_ContentSearch;
        private System.Windows.Forms.TextBox txt_ContenttoSearch;
        internal System.Windows.Forms.Button btn_Close;
        internal System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.ComboBox cmb_SearchShowby;
        private System.Windows.Forms.ComboBox cmb_Searchby;
        private System.Windows.Forms.Label lbl_Searchby;
    }
}