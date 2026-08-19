namespace SEACC_PTS
{
    partial class SeaccRichTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_BigViwer = new System.Windows.Forms.Button();
            this.btn_Bulert = new System.Windows.Forms.Button();
            this.btn_BackColor = new System.Windows.Forms.Button();
            this.btn_FColor = new System.Windows.Forms.Button();
            this.btn_Strick = new System.Windows.Forms.CheckBox();
            this.btn_addImage = new System.Windows.Forms.Button();
            this.cbxFontSize = new System.Windows.Forms.ComboBox();
            this.fontComboBox1 = new Cyotek.Windows.Forms.FontComboBox();
            this.btn_Underline = new System.Windows.Forms.CheckBox();
            this.btn_Italic = new System.Windows.Forms.CheckBox();
            this.btn_Bold = new System.Windows.Forms.CheckBox();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_BigViwer);
            this.panel1.Controls.Add(this.btn_Bulert);
            this.panel1.Controls.Add(this.btn_BackColor);
            this.panel1.Controls.Add(this.btn_FColor);
            this.panel1.Controls.Add(this.btn_Strick);
            this.panel1.Controls.Add(this.btn_addImage);
            this.panel1.Controls.Add(this.cbxFontSize);
            this.panel1.Controls.Add(this.fontComboBox1);
            this.panel1.Controls.Add(this.btn_Underline);
            this.panel1.Controls.Add(this.btn_Italic);
            this.panel1.Controls.Add(this.btn_Bold);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 25);
            this.panel1.TabIndex = 0;
            // 
            // btn_BigViwer
            // 
            this.btn_BigViwer.BackgroundImage = global::SEACC_PTS.Properties.Resources.maximize;
            this.btn_BigViwer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BigViwer.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_BigViwer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BigViwer.Location = new System.Drawing.Point(330, 2);
            this.btn_BigViwer.Name = "btn_BigViwer";
            this.btn_BigViwer.Size = new System.Drawing.Size(21, 21);
            this.btn_BigViwer.TabIndex = 15;
            this.btn_BigViwer.UseVisualStyleBackColor = true;
            this.btn_BigViwer.Click += new System.EventHandler(this.btn_BigViwer_Click);
            // 
            // btn_Bulert
            // 
            this.btn_Bulert.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Bulert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bulert.Location = new System.Drawing.Point(308, 2);
            this.btn_Bulert.Name = "btn_Bulert";
            this.btn_Bulert.Size = new System.Drawing.Size(21, 21);
            this.btn_Bulert.TabIndex = 14;
            this.btn_Bulert.Text = "button1";
            this.btn_Bulert.UseVisualStyleBackColor = true;
            this.btn_Bulert.Click += new System.EventHandler(this.btn_Bulert_Click);
            // 
            // btn_BackColor
            // 
            this.btn_BackColor.BackgroundImage = global::SEACC_PTS.Properties.Resources.Highlighter;
            this.btn_BackColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BackColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_BackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BackColor.Location = new System.Drawing.Point(242, 2);
            this.btn_BackColor.Name = "btn_BackColor";
            this.btn_BackColor.Size = new System.Drawing.Size(21, 21);
            this.btn_BackColor.TabIndex = 13;
            this.btn_BackColor.UseVisualStyleBackColor = true;
            this.btn_BackColor.Click += new System.EventHandler(this.btn_BackColor_Click);
            // 
            // btn_FColor
            // 
            this.btn_FColor.BackgroundImage = global::SEACC_PTS.Properties.Resources.TextColor;
            this.btn_FColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_FColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FColor.Location = new System.Drawing.Point(264, 2);
            this.btn_FColor.Name = "btn_FColor";
            this.btn_FColor.Size = new System.Drawing.Size(21, 21);
            this.btn_FColor.TabIndex = 12;
            this.btn_FColor.UseVisualStyleBackColor = true;
            this.btn_FColor.Click += new System.EventHandler(this.btn_FColor_Click);
            // 
            // btn_Strick
            // 
            this.btn_Strick.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_Strick.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Strick.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Strick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Strick.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Strick.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Strick.Location = new System.Drawing.Point(69, 2);
            this.btn_Strick.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Strick.Name = "btn_Strick";
            this.btn_Strick.Size = new System.Drawing.Size(21, 21);
            this.btn_Strick.TabIndex = 11;
            this.btn_Strick.Text = "S";
            this.btn_Strick.UseVisualStyleBackColor = true;
            this.btn_Strick.CheckedChanged += new System.EventHandler(this.btn_Strick_CheckedChanged);
            // 
            // btn_addImage
            // 
            this.btn_addImage.BackgroundImage = global::SEACC_PTS.Properties.Resources.image;
            this.btn_addImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addImage.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_addImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addImage.Location = new System.Drawing.Point(286, 2);
            this.btn_addImage.Name = "btn_addImage";
            this.btn_addImage.Size = new System.Drawing.Size(21, 21);
            this.btn_addImage.TabIndex = 10;
            this.btn_addImage.UseVisualStyleBackColor = true;
            this.btn_addImage.Click += new System.EventHandler(this.btn_addImage_Click);
            // 
            // cbxFontSize
            // 
            this.cbxFontSize.FormattingEnabled = true;
            this.cbxFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "26",
            "48",
            "72"});
            this.cbxFontSize.Location = new System.Drawing.Point(196, 2);
            this.cbxFontSize.Name = "cbxFontSize";
            this.cbxFontSize.Size = new System.Drawing.Size(43, 21);
            this.cbxFontSize.TabIndex = 9;
            this.cbxFontSize.SelectedIndexChanged += new System.EventHandler(this.cbxFontSize_SelectedIndexChanged);
            // 
            // fontComboBox1
            // 
            this.fontComboBox1.FormattingEnabled = true;
            this.fontComboBox1.Location = new System.Drawing.Point(91, 2);
            this.fontComboBox1.Name = "fontComboBox1";
            this.fontComboBox1.Size = new System.Drawing.Size(102, 21);
            this.fontComboBox1.TabIndex = 8;
            this.fontComboBox1.SelectedIndexChanged += new System.EventHandler(this.fontComboBox1_SelectedIndexChanged);
            // 
            // btn_Underline
            // 
            this.btn_Underline.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_Underline.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Underline.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Underline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Underline.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Underline.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Underline.Location = new System.Drawing.Point(47, 2);
            this.btn_Underline.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Underline.Name = "btn_Underline";
            this.btn_Underline.Size = new System.Drawing.Size(21, 21);
            this.btn_Underline.TabIndex = 7;
            this.btn_Underline.Text = "U";
            this.btn_Underline.UseVisualStyleBackColor = true;
            this.btn_Underline.CheckedChanged += new System.EventHandler(this.btn_Underline_CheckedChanged);
            // 
            // btn_Italic
            // 
            this.btn_Italic.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_Italic.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Italic.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Italic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Italic.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Italic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Italic.Location = new System.Drawing.Point(25, 2);
            this.btn_Italic.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Italic.Name = "btn_Italic";
            this.btn_Italic.Size = new System.Drawing.Size(21, 21);
            this.btn_Italic.TabIndex = 6;
            this.btn_Italic.Text = "I";
            this.btn_Italic.UseVisualStyleBackColor = true;
            this.btn_Italic.CheckedChanged += new System.EventHandler(this.btn_Italic_CheckedChanged);
            // 
            // btn_Bold
            // 
            this.btn_Bold.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_Bold.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Bold.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Bold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bold.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bold.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Bold.Location = new System.Drawing.Point(3, 2);
            this.btn_Bold.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Bold.Name = "btn_Bold";
            this.btn_Bold.Size = new System.Drawing.Size(21, 21);
            this.btn_Bold.TabIndex = 5;
            this.btn_Bold.Text = "B";
            this.btn_Bold.UseVisualStyleBackColor = true;
            this.btn_Bold.CheckedChanged += new System.EventHandler(this.btn_Bold_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(0, 25);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(458, 125);
            this.txtDesc.TabIndex = 15;
            this.txtDesc.Text = "";
            this.txtDesc.SelectionChanged += new System.EventHandler(this.txtDesc_SelectionChanged);
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SeaccRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.panel1);
            this.Name = "SeaccRichTextBox";
            this.Size = new System.Drawing.Size(458, 150);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxFontSize;
        private Cyotek.Windows.Forms.FontComboBox fontComboBox1;
        private System.Windows.Forms.CheckBox btn_Underline;
        private System.Windows.Forms.CheckBox btn_Italic;
        private System.Windows.Forms.CheckBox btn_Bold;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.Button btn_addImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox btn_Strick;
        private System.Windows.Forms.Button btn_FColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_BackColor;
        private System.Windows.Forms.Button btn_Bulert;
        private System.Windows.Forms.Button btn_BigViwer;

    }
}
