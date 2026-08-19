namespace Digiteq
{
    partial class frm_toolChequeToNewMode
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtRecodeID = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLogon = new System.Windows.Forms.Button();
            this.lblWip = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cheque To New Mode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(251, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(27, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRecodeID
            // 
            this.txtRecodeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRecodeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecodeID.Location = new System.Drawing.Point(114, 55);
            this.txtRecodeID.Name = "txtRecodeID";
            this.txtRecodeID.Size = new System.Drawing.Size(152, 22);
            this.txtRecodeID.TabIndex = 10;
            this.txtRecodeID.TextChanged += new System.EventHandler(this.txtRecodeID_TextChanged);
            this.txtRecodeID.DoubleClick += new System.EventHandler(this.txtRecodeID_DoubleClick);
            this.txtRecodeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecodeID_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::Digiteq.Properties.Resources.accept;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(110, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 25);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogon.Image = global::Digiteq.Properties.Resources.accept;
            this.btnLogon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogon.Location = new System.Drawing.Point(168, 99);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(98, 25);
            this.btnLogon.TabIndex = 6;
            this.btnLogon.Text = "To New Mode";
            this.btnLogon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // lblWip
            // 
            this.lblWip.AutoSize = true;
            this.lblWip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWip.Location = new System.Drawing.Point(24, 58);
            this.lblWip.Name = "lblWip";
            this.lblWip.Size = new System.Drawing.Size(47, 13);
            this.lblWip.TabIndex = 9;
            this.lblWip.Text = "Cheque";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 35);
            this.panel1.TabIndex = 5;
            // 
            // frm_toolChequeToNewMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(278, 146);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtRecodeID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_toolChequeToNewMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_toolCheckToDepositeMode1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtRecodeID;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Label lblWip;
        private System.Windows.Forms.Panel panel1;
    }
}