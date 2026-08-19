namespace Digiteq
{
    partial class frm_mtrFont
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
            this.FontType_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Font_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFontTypeName = new System.Windows.Forms.Label();
            this.txtFontTypeName = new System.Windows.Forms.TextBox();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.lblFont = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFontStyle = new System.Windows.Forms.Label();
            this.lblFontTypeID = new System.Windows.Forms.Label();
            this.txtFontTypeID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbFontName = new System.Windows.Forms.ComboBox();
            this.cmbFontStyle = new System.Windows.Forms.ComboBox();
            this.rchtFontPreview = new System.Windows.Forms.RichTextBox();
            this.lblFontPreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FontType_ID,
            this.FontType_Name,
            this.Font_Name,
            this.Size,
            this.Style});
            this.dgvDetail.Location = new System.Drawing.Point(9, 39);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(417, 283);
            this.dgvDetail.TabIndex = 4;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // FontType_ID
            // 
            this.FontType_ID.HeaderText = "#";
            this.FontType_ID.Name = "FontType_ID";
            this.FontType_ID.Width = 30;
            // 
            // FontType_Name
            // 
            this.FontType_Name.HeaderText = "Font Type Name";
            this.FontType_Name.Name = "FontType_Name";
            this.FontType_Name.Width = 115;
            // 
            // Font_Name
            // 
            this.Font_Name.HeaderText = "Font";
            this.Font_Name.Name = "Font_Name";
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // Style
            // 
            this.Style.HeaderText = "Style";
            this.Style.Name = "Style";
            // 
            // lblFontTypeName
            // 
            this.lblFontTypeName.AutoSize = true;
            this.lblFontTypeName.Location = new System.Drawing.Point(440, 86);
            this.lblFontTypeName.Name = "lblFontTypeName";
            this.lblFontTypeName.Size = new System.Drawing.Size(89, 13);
            this.lblFontTypeName.TabIndex = 5;
            this.lblFontTypeName.Text = "Font Type Name";
            // 
            // txtFontTypeName
            // 
            this.txtFontTypeName.Location = new System.Drawing.Point(536, 82);
            this.txtFontTypeName.Name = "txtFontTypeName";
            this.txtFontTypeName.Size = new System.Drawing.Size(164, 22);
            this.txtFontTypeName.TabIndex = 6;
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(536, 139);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(100, 22);
            this.txtFontSize.TabIndex = 8;
            this.txtFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFontSize_KeyPress);
            this.txtFontSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFontSize_KeyUp);
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(441, 115);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(63, 13);
            this.lblFont.TabIndex = 10;
            this.lblFont.Text = "Font Name";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(441, 146);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(54, 13);
            this.lblSize.TabIndex = 11;
            this.lblSize.Text = "Font Size";
            // 
            // lblFontStyle
            // 
            this.lblFontStyle.AutoSize = true;
            this.lblFontStyle.Location = new System.Drawing.Point(441, 175);
            this.lblFontStyle.Name = "lblFontStyle";
            this.lblFontStyle.Size = new System.Drawing.Size(58, 13);
            this.lblFontStyle.TabIndex = 12;
            this.lblFontStyle.Text = "Font Style";
            // 
            // lblFontTypeID
            // 
            this.lblFontTypeID.AutoSize = true;
            this.lblFontTypeID.Location = new System.Drawing.Point(441, 59);
            this.lblFontTypeID.Name = "lblFontTypeID";
            this.lblFontTypeID.Size = new System.Drawing.Size(71, 13);
            this.lblFontTypeID.TabIndex = 13;
            this.lblFontTypeID.Text = "Font Type ID";
            // 
            // txtFontTypeID
            // 
            this.txtFontTypeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtFontTypeID.Location = new System.Drawing.Point(536, 53);
            this.txtFontTypeID.Name = "txtFontTypeID";
            this.txtFontTypeID.Size = new System.Drawing.Size(100, 22);
            this.txtFontTypeID.TabIndex = 14;
           // this.txtFontTypeID.TextChanged += new System.EventHandler(this.txtFontTypeID_TextChanged);
            this.txtFontTypeID.DoubleClick += new System.EventHandler(this.txtFontTypeID_DoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(536, 290);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(459, 290);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(613, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(431, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 282);
            this.panel1.TabIndex = 18;
            // 
            // cmbFontName
            // 
            this.cmbFontName.FormattingEnabled = true;
            this.cmbFontName.Location = new System.Drawing.Point(536, 111);
            this.cmbFontName.Name = "cmbFontName";
            this.cmbFontName.Size = new System.Drawing.Size(100, 21);
            this.cmbFontName.TabIndex = 19;
            this.cmbFontName.SelectedIndexChanged += new System.EventHandler(this.cmbFontName_SelectedIndexChanged_1);
            // 
            // cmbFontStyle
            // 
            this.cmbFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontStyle.FormattingEnabled = true;
            this.cmbFontStyle.Location = new System.Drawing.Point(536, 168);
            this.cmbFontStyle.Name = "cmbFontStyle";
            this.cmbFontStyle.Size = new System.Drawing.Size(100, 21);
            this.cmbFontStyle.TabIndex = 20;
            this.cmbFontStyle.SelectedIndexChanged += new System.EventHandler(this.cmbFontStyle_SelectedIndexChanged);
            // 
            // rchtFontPreview
            // 
            this.rchtFontPreview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchtFontPreview.Location = new System.Drawing.Point(444, 217);
            this.rchtFontPreview.Name = "rchtFontPreview";
            this.rchtFontPreview.Size = new System.Drawing.Size(256, 67);
            this.rchtFontPreview.TabIndex = 21;
            this.rchtFontPreview.Text = "Example for font preview";
            // 
            // lblFontPreview
            // 
            this.lblFontPreview.AutoSize = true;
            this.lblFontPreview.Location = new System.Drawing.Point(628, 201);
            this.lblFontPreview.Name = "lblFontPreview";
            this.lblFontPreview.Size = new System.Drawing.Size(73, 13);
            this.lblFontPreview.TabIndex = 22;
            this.lblFontPreview.Text = "Font Preview";
            // 
            // frm_mtrFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 331);
            this.Controls.Add(this.lblFontPreview);
            this.Controls.Add(this.rchtFontPreview);
            this.Controls.Add(this.cmbFontStyle);
            this.Controls.Add(this.cmbFontName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFontTypeID);
            this.Controls.Add(this.lblFontTypeID);
            this.Controls.Add(this.lblFontStyle);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.txtFontTypeName);
            this.Controls.Add(this.lblFontTypeName);
            this.Controls.Add(this.dgvDetail);
            this.Name = "frm_mtrFont";
            this.Text = "Font Type Master";
            this.Load += new System.EventHandler(this.frm_zFont_Load);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.lblFontTypeName, 0);
            this.Controls.SetChildIndex(this.txtFontTypeName, 0);
            this.Controls.SetChildIndex(this.txtFontSize, 0);
            this.Controls.SetChildIndex(this.lblFont, 0);
            this.Controls.SetChildIndex(this.lblSize, 0);
            this.Controls.SetChildIndex(this.lblFontStyle, 0);
            this.Controls.SetChildIndex(this.lblFontTypeID, 0);
            this.Controls.SetChildIndex(this.txtFontTypeID, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.cmbFontName, 0);
            this.Controls.SetChildIndex(this.cmbFontStyle, 0);
            this.Controls.SetChildIndex(this.rchtFontPreview, 0);
            this.Controls.SetChildIndex(this.lblFontPreview, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Label lblFontTypeName;
        private System.Windows.Forms.TextBox txtFontTypeName;
        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblFontStyle;
        private System.Windows.Forms.Label lblFontTypeID;
        private System.Windows.Forms.TextBox txtFontTypeID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontType_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Font_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Style;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbFontName;
        private System.Windows.Forms.ComboBox cmbFontStyle;
        private System.Windows.Forms.RichTextBox rchtFontPreview;
        private System.Windows.Forms.Label lblFontPreview;
    }
}