namespace Digiteq
{
    partial class mtrJobMarkupPrecentage
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMarckUp = new System.Windows.Forms.TextBox();
            this.txtJobGenaralOverhead = new System.Windows.Forms.TextBox();
            this.lblBankID = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.x2 = new System.Windows.Forms.Panel();
            this.x2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(231, 72);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMarckUp
            // 
            this.txtMarckUp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txtMarckUp.Location = new System.Drawing.Point(142, 13);
            this.txtMarckUp.Name = "txtMarckUp";
            this.txtMarckUp.Size = new System.Drawing.Size(164, 22);
            this.txtMarckUp.TabIndex = 10;
            this.txtMarckUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarckUp_KeyPress);
            // 
            // txtJobGenaralOverhead
            // 
            this.txtJobGenaralOverhead.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.txtJobGenaralOverhead.Location = new System.Drawing.Point(142, 43);
            this.txtJobGenaralOverhead.Name = "txtJobGenaralOverhead";
            this.txtJobGenaralOverhead.Size = new System.Drawing.Size(164, 22);
            this.txtJobGenaralOverhead.TabIndex = 11;
            this.txtJobGenaralOverhead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobGenaralOverhead_KeyPress);
            // 
            // lblBankID
            // 
            this.lblBankID.AutoSize = true;
            this.lblBankID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankID.Location = new System.Drawing.Point(13, 13);
            this.lblBankID.Name = "lblBankID";
            this.lblBankID.Size = new System.Drawing.Size(69, 14);
            this.lblBankID.TabIndex = 105;
            this.lblBankID.Text = "Job Marckup";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(13, 43);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(116, 14);
            this.lblBankName.TabIndex = 106;
            this.lblBankName.Text = "Job Genaral Overhead";
            // 
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.x2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2.Controls.Add(this.lblBankID);
            this.x2.Controls.Add(this.btnSave);
            this.x2.Controls.Add(this.lblBankName);
            this.x2.Controls.Add(this.txtMarckUp);
            this.x2.Controls.Add(this.txtJobGenaralOverhead);
            this.x2.Location = new System.Drawing.Point(12, 12);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(317, 106);
            this.x2.TabIndex = 107;
            // 
            // mtrJobMarkupPrecentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 126);
            this.Controls.Add(this.x2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "mtrJobMarkupPrecentage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Markup Precentage";
            this.Load += new System.EventHandler(this.mtrJobMarkupPrecentage_Load);
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMarckUp;
        private System.Windows.Forms.TextBox txtJobGenaralOverhead;
        private System.Windows.Forms.Label lblBankID;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Panel x2;
    }
}