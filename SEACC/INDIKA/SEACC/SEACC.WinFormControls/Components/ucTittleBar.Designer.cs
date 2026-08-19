namespace SEACC.WinFormControls.Components
{
    partial class ucTittleBar
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
            this.l_Header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_Header
            // 
            this.l_Header.AutoSize = true;
            this.l_Header.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.l_Header.Location = new System.Drawing.Point(3, 6);
            this.l_Header.Name = "l_Header";
            this.l_Header.Size = new System.Drawing.Size(57, 25);
            this.l_Header.TabIndex = 0;
            this.l_Header.Text = "label1";
            this.l_Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucTittleBar_MouseDown);
            // 
            // ucTittleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.l_Header);
            this.Name = "ucTittleBar";
            this.Size = new System.Drawing.Size(554, 34);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucTittleBar_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Header;
    }
}
