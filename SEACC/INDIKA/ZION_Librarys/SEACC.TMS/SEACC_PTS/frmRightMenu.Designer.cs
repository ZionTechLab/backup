namespace SEACC_PTS
{
    partial class frmRightMenu
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
            this.lblDownLod = new System.Windows.Forms.Label();
            this.lblView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDownLod
            // 
            this.lblDownLod.AutoSize = true;
            this.lblDownLod.Location = new System.Drawing.Point(13, 13);
            this.lblDownLod.Name = "lblDownLod";
            this.lblDownLod.Size = new System.Drawing.Size(100, 13);
            this.lblDownLod.TabIndex = 0;
            this.lblDownLod.Text = "Download               ";
            this.lblDownLod.Click += new System.EventHandler(this.lblDownLod_Click);
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(14, 35);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(96, 13);
            this.lblView.TabIndex = 1;
            this.lblView.Text = "View                      ";
            this.lblView.Click += new System.EventHandler(this.lblView_Click);
            // 
            // frmRightMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 54);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.lblDownLod);
            this.Name = "frmRightMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmRightMenu";
            this.Load += new System.EventHandler(this.frmRightMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDownLod;
        private System.Windows.Forms.Label lblView;
    }
}