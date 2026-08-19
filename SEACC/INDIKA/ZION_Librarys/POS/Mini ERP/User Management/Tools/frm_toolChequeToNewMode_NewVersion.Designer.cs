namespace Digiteq.User_Management.Tools
{
    partial class frm_toolChequeToNewMode_NewVersion
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
            this.btnLogon = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtRecodeID = new System.Windows.Forms.TextBox();
            this.lblWip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogon
            // 
            this.btnLogon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogon.Image = global::Digiteq.Properties.Resources.accept;
            this.btnLogon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogon.Location = new System.Drawing.Point(179, 54);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(98, 25);
            this.btnLogon.TabIndex = 11;
            this.btnLogon.Text = "To New Mode";
            this.btnLogon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::Digiteq.Properties.Resources.accept;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(121, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 25);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtRecodeID
            // 
            this.txtRecodeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRecodeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecodeID.Location = new System.Drawing.Point(125, 19);
            this.txtRecodeID.Name = "txtRecodeID";
            this.txtRecodeID.Size = new System.Drawing.Size(152, 22);
            this.txtRecodeID.TabIndex = 14;
            this.txtRecodeID.DoubleClick += new System.EventHandler(this.txtRecodeID_DoubleClick);
            // 
            // lblWip
            // 
            this.lblWip.AutoSize = true;
            this.lblWip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWip.Location = new System.Drawing.Point(17, 19);
            this.lblWip.Name = "lblWip";
            this.lblWip.Size = new System.Drawing.Size(47, 13);
            this.lblWip.TabIndex = 13;
            this.lblWip.Text = "Cheque";
            // 
            // frm_toolChequeToNewMode_NewVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtRecodeID);
            this.Controls.Add(this.lblWip);
            this.Name = "frm_toolChequeToNewMode_NewVersion";
            this.Size = new System.Drawing.Size(300, 140);
            this.Load += new System.EventHandler(this.frm_toolChequeToNewMode_NewVersion_Load);
            this.Controls.SetChildIndex(this.lblWip, 0);
            this.Controls.SetChildIndex(this.txtRecodeID, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnLogon, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtRecodeID;
        private System.Windows.Forms.Label lblWip;
    }
}
