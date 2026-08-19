namespace SEACC_PTS
{
    partial class frm_PickBox_Mini
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Enabled = false;
            this.lblHeader.Location = new System.Drawing.Point(224, -1);
            this.lblHeader.Visible = false;
            // 
            // txtFillter
            // 
            this.txtFillter.Location = new System.Drawing.Point(102, 41);
            // 
            // label9
            // 
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(248, 39);
            this.label9.Visible = false;
            // 
            // cbxSearch
            // 
            this.cbxSearch.Enabled = false;
            this.cbxSearch.Location = new System.Drawing.Point(68, 11);
            this.cbxSearch.Visible = false;
            // 
            // userControl11
            // 
            this.userControl11.Enabled = false;
            this.userControl11.Location = new System.Drawing.Point(306, -1);
            this.userControl11.Size = new System.Drawing.Size(33, 37);
            this.userControl11.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Enabled = false;
            this.panel2.Size = new System.Drawing.Size(339, 73);
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtFillter);
            this.panel3.Padding = new System.Windows.Forms.Padding(0);
            this.panel3.Size = new System.Drawing.Size(339, 311);
            // 
            // panel1
            // 
            this.panel1.Enabled = false;
            this.panel1.Size = new System.Drawing.Size(339, 38);
            this.panel1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_PickBox_Mini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 402);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_PickBox_Mini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_PickBox_Mini";
            this.Load += new System.EventHandler(this.frm_PickBox_Mini_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
    }
}