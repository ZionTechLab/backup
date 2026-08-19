namespace Digiteq.User_Management.Tools
{
    partial class frm_bpsCashDepositCancelation_NewVersion
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
            this.btnReverce = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblWip = new System.Windows.Forms.Label();
            this.txtReciept = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReverce
            // 
            this.btnReverce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReverce.Image = global::Digiteq.Properties.Resources.accept;
            this.btnReverce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReverce.Location = new System.Drawing.Point(179, 54);
            this.btnReverce.Name = "btnReverce";
            this.btnReverce.Size = new System.Drawing.Size(98, 25);
            this.btnReverce.TabIndex = 17;
            this.btnReverce.Text = "To New Mode";
            this.btnReverce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReverce.UseVisualStyleBackColor = true;
            this.btnReverce.Click += new System.EventHandler(this.btnReverce_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::Digiteq.Properties.Resources.accept;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(121, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 25);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblWip
            // 
            this.lblWip.AutoSize = true;
            this.lblWip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWip.Location = new System.Drawing.Point(17, 19);
            this.lblWip.Name = "lblWip";
            this.lblWip.Size = new System.Drawing.Size(45, 13);
            this.lblWip.TabIndex = 16;
            this.lblWip.Text = "Receipt";
            // 
            // txtReciept
            // 
            this.txtReciept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtReciept.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReciept.Location = new System.Drawing.Point(125, 19);
            this.txtReciept.Name = "txtReciept";
            this.txtReciept.Size = new System.Drawing.Size(152, 22);
            this.txtReciept.TabIndex = 15;
            this.txtReciept.DoubleClick += new System.EventHandler(this.txtReciept_DoubleClick);
            // 
            // frm_bpsCashDepositCancelation_NewVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReverce);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblWip);
            this.Controls.Add(this.txtReciept);
            this.Name = "frm_bpsCashDepositCancelation_NewVersion";
            this.Size = new System.Drawing.Size(300, 140);
            this.Load += new System.EventHandler(this.frm_bpsCashDepositCancelation_NewVersion_Load);
            this.Controls.SetChildIndex(this.txtReciept, 0);
            this.Controls.SetChildIndex(this.lblWip, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnReverce, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReverce;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblWip;
        private System.Windows.Forms.TextBox txtReciept;
    }
}
