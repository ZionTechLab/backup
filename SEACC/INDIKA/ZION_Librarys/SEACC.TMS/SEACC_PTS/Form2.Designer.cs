namespace SEACC_PTS
{
    partial class Form2
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
            this.seaccRichTextBox1 = new SEACC_PTS.SeaccRichTextBox();
            this.SuspendLayout();
            // 
            // seaccRichTextBox1
            // 
            this.seaccRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seaccRichTextBox1.FormatedText = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}" +
    "\r\n\\viewkind4\\uc1\\pard\\f0\\fs18\\par\r\n}\r\n";
            this.seaccRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.seaccRichTextBox1.Name = "seaccRichTextBox1";
            this.seaccRichTextBox1.Size = new System.Drawing.Size(688, 333);
            this.seaccRichTextBox1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 333);
            this.Controls.Add(this.seaccRichTextBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private SeaccRichTextBox seaccRichTextBox1;
    }
}