namespace Digiteq
{
    partial class frm_scsMetfor_Home
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
            this.xpanel3 = new System.Windows.Forms.Panel();
            this.btnMatfor = new System.Windows.Forms.Button();
            this.btnMatforForecast = new System.Windows.Forms.Button();
            this.btnMatforDataEntry = new System.Windows.Forms.Button();
            this.xpanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpanel3
            // 
            this.xpanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.xpanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel3.Controls.Add(this.btnMatfor);
            this.xpanel3.Controls.Add(this.btnMatforForecast);
            this.xpanel3.Controls.Add(this.btnMatforDataEntry);
            this.xpanel3.Location = new System.Drawing.Point(8, 8);
            this.xpanel3.Name = "xpanel3";
            this.xpanel3.Size = new System.Drawing.Size(416, 87);
            this.xpanel3.TabIndex = 18;
            // 
            // btnMatfor
            // 
            this.btnMatfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnMatfor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMatfor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatfor.Location = new System.Drawing.Point(276, 8);
            this.btnMatfor.Name = "btnMatfor";
            this.btnMatfor.Size = new System.Drawing.Size(128, 67);
            this.btnMatfor.TabIndex = 16;
            this.btnMatfor.Text = "MRP Finalization";
            this.btnMatfor.UseVisualStyleBackColor = false;
            this.btnMatfor.Click += new System.EventHandler(this.btnSubAgentPaymentAdvice_Click);
            // 
            // btnMatforForecast
            // 
            this.btnMatforForecast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnMatforForecast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMatforForecast.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatforForecast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatforForecast.Location = new System.Drawing.Point(142, 8);
            this.btnMatforForecast.Name = "btnMatforForecast";
            this.btnMatforForecast.Size = new System.Drawing.Size(128, 67);
            this.btnMatforForecast.TabIndex = 15;
            this.btnMatforForecast.Text = "MRP - Forecast";
            this.btnMatforForecast.UseVisualStyleBackColor = false;
            this.btnMatforForecast.Click += new System.EventHandler(this.btnCusOrderEdit_Click);
            // 
            // btnMatforDataEntry
            // 
            this.btnMatforDataEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnMatforDataEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMatforDataEntry.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatforDataEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatforDataEntry.Location = new System.Drawing.Point(8, 8);
            this.btnMatforDataEntry.Name = "btnMatforDataEntry";
            this.btnMatforDataEntry.Size = new System.Drawing.Size(128, 67);
            this.btnMatforDataEntry.TabIndex = 13;
            this.btnMatforDataEntry.Text = "MRP - DataEntry";
            this.btnMatforDataEntry.UseVisualStyleBackColor = false;
            this.btnMatforDataEntry.Click += new System.EventHandler(this.btnDoManualSettle_Click);
            // 
            // frm_scsMetfor_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 103);
            this.Controls.Add(this.xpanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(8, 8);
            this.Name = "frm_scsMetfor_Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MRP Home [Material Requirement Planning]";
            this.Load += new System.EventHandler(this.frm_sasTools_Load);
            this.xpanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xpanel3;
        private System.Windows.Forms.Button btnMatforForecast;
        private System.Windows.Forms.Button btnMatforDataEntry;
        private System.Windows.Forms.Button btnMatfor;

    }
}