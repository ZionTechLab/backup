namespace Digiteq
{
    partial class frm_bpsTools
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ChequesToNew_old = new System.Windows.Forms.Button();
            this.btn_CashDepositCancelation_old = new System.Windows.Forms.Button();
            this.btnRtnChqEdit = new System.Windows.Forms.Button();
            this.xpanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(228)))), ((int)(((byte)(194)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(228)))), ((int)(((byte)(194)))));
            // 
            // xpanel3
            // 
            this.xpanel3.BackColor = System.Drawing.Color.White;
            this.xpanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel3.Controls.Add(this.flowLayoutPanel1);
            this.xpanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xpanel3.Location = new System.Drawing.Point(1, 38);
            this.xpanel3.Name = "xpanel3";
            this.xpanel3.Size = new System.Drawing.Size(336, 212);
            this.xpanel3.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btn_CashDepositCancelation_old);
            this.flowLayoutPanel1.Controls.Add(this.btnRtnChqEdit);
            this.flowLayoutPanel1.Controls.Add(this.btn_ChequesToNew_old);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(334, 210);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // btn_ChequesToNew_old
            // 
            this.btn_ChequesToNew_old.BackColor = System.Drawing.Color.Gray;
            this.btn_ChequesToNew_old.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ChequesToNew_old.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChequesToNew_old.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ChequesToNew_old.Location = new System.Drawing.Point(147, 13);
            this.btn_ChequesToNew_old.Name = "btn_ChequesToNew_old";
            this.btn_ChequesToNew_old.Size = new System.Drawing.Size(128, 67);
            this.btn_ChequesToNew_old.TabIndex = 20;
            this.btn_ChequesToNew_old.Text = "Cheque to New Mode ";
            this.btn_ChequesToNew_old.UseVisualStyleBackColor = false;
            this.btn_ChequesToNew_old.Click += new System.EventHandler(this.btn_ChequesToNew_Click);
            // 
            // btn_CashDepositCancelation_old
            // 
            this.btn_CashDepositCancelation_old.BackColor = System.Drawing.Color.Gray;
            this.btn_CashDepositCancelation_old.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CashDepositCancelation_old.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CashDepositCancelation_old.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CashDepositCancelation_old.Location = new System.Drawing.Point(13, 13);
            this.btn_CashDepositCancelation_old.Name = "btn_CashDepositCancelation_old";
            this.btn_CashDepositCancelation_old.Size = new System.Drawing.Size(128, 67);
            this.btn_CashDepositCancelation_old.TabIndex = 21;
            this.btn_CashDepositCancelation_old.Text = "Cash Deposit Cancellation ";
            this.btn_CashDepositCancelation_old.UseVisualStyleBackColor = false;
            this.btn_CashDepositCancelation_old.Click += new System.EventHandler(this.btn_CashDepositCancelation_Click);
            // 
            // btnRtnChqEdit
            // 
            this.btnRtnChqEdit.BackColor = System.Drawing.Color.Gray;
            this.btnRtnChqEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRtnChqEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRtnChqEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRtnChqEdit.Location = new System.Drawing.Point(13, 86);
            this.btnRtnChqEdit.Name = "btnRtnChqEdit";
            this.btnRtnChqEdit.Size = new System.Drawing.Size(128, 67);
            this.btnRtnChqEdit.TabIndex = 22;
            this.btnRtnChqEdit.Text = "Return Cheque Edit";
            this.btnRtnChqEdit.UseVisualStyleBackColor = false;
            this.btnRtnChqEdit.Click += new System.EventHandler(this.btnRtnChqEdit_Click);
            // 
            // frm_bpsTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(338, 251);
            this.Controls.Add(this.xpanel3);
            this.Name = "frm_bpsTools";
            this.Text = "Bills Tools";
            this.Load += new System.EventHandler(this.frm_bpsTools_Load);
            this.Controls.SetChildIndex(this.xpanel3, 0);
            this.xpanel3.ResumeLayout(false);
            this.xpanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xpanel3;
        private System.Windows.Forms.Button btn_ChequesToNew_old;
        private System.Windows.Forms.Button btn_CashDepositCancelation_old;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRtnChqEdit;
    }
}