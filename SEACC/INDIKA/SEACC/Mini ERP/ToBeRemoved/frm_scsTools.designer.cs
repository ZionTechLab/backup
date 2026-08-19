namespace Digiteq
{
    partial class frm_scsTools
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
            this.btnDoManualSettle = new System.Windows.Forms.Button();
            this.btnPoEdit = new System.Windows.Forms.Button();
            this.xpanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpanel3
            // 
            this.xpanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.xpanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel3.Controls.Add(this.btnPoEdit);
            this.xpanel3.Controls.Add(this.btnDoManualSettle);
            this.xpanel3.Location = new System.Drawing.Point(8, 8);
            this.xpanel3.Name = "xpanel3";
            this.xpanel3.Size = new System.Drawing.Size(298, 158);
            this.xpanel3.TabIndex = 18;
            // 
            // btnDoManualSettle
            // 
            this.btnDoManualSettle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnDoManualSettle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDoManualSettle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoManualSettle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoManualSettle.Location = new System.Drawing.Point(8, 8);
            this.btnDoManualSettle.Name = "btnDoManualSettle";
            this.btnDoManualSettle.Size = new System.Drawing.Size(128, 67);
            this.btnDoManualSettle.TabIndex = 13;
            this.btnDoManualSettle.Text = "Stock Transfer Manual Settle";
            this.btnDoManualSettle.UseVisualStyleBackColor = false;
            this.btnDoManualSettle.Click += new System.EventHandler(this.btnDoManualSettle_Click);
            // 
            // btnPoEdit
            // 
            this.btnPoEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.btnPoEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPoEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPoEdit.Location = new System.Drawing.Point(142, 8);
            this.btnPoEdit.Name = "btnPoEdit";
            this.btnPoEdit.Size = new System.Drawing.Size(128, 67);
            this.btnPoEdit.TabIndex = 14;
            this.btnPoEdit.Text = "PO Discount Edit";
            this.btnPoEdit.UseVisualStyleBackColor = false;
            this.btnPoEdit.Click += new System.EventHandler(this.btnPoEdit_Click);
            // 
            // frm_scsTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 174);
            this.Controls.Add(this.xpanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(8, 8);
            this.Name = "frm_scsTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_sasTools";
            this.Load += new System.EventHandler(this.frm_sasTools_Load);
            this.xpanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xpanel3;
        private System.Windows.Forms.Button btnDoManualSettle;
        private System.Windows.Forms.Button btnPoEdit;

    }
}