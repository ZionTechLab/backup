namespace Digiteq
{
    partial class frm_AccountsTools
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
            this.btnChangeChqDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
           // this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // btnChangeChqDate
            // 
            this.btnChangeChqDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeChqDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeChqDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeChqDate.Location = new System.Drawing.Point(12, 41);
            this.btnChangeChqDate.Name = "btnChangeChqDate";
            this.btnChangeChqDate.Size = new System.Drawing.Size(101, 42);
            this.btnChangeChqDate.TabIndex = 58;
            this.btnChangeChqDate.Text = "Change Cheque Date";
            this.btnChangeChqDate.UseVisualStyleBackColor = true;
            this.btnChangeChqDate.Click += new System.EventHandler(this.btnChangeChqDate_Click);
            // 
            // frm_AccountsTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 155);
            this.Controls.Add(this.btnChangeChqDate);
            this.Name = "frm_AccountsTools";
            this.Text = "Accounts Tools";
            this.Controls.SetChildIndex(this.btnChangeChqDate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChangeChqDate;
    }
}