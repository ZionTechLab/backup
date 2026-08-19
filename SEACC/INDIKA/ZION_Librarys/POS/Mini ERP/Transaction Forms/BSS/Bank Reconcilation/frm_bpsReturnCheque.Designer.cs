namespace Digiteq
{
    partial class frm_bpsReturnCheque
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtmReturnDate = new System.Windows.Forms.DateTimePicker();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Do you want to return this cheque?";
            // 
            // dtmReturnDate
            // 
            this.dtmReturnDate.CustomFormat = "dd/MMM/yyyy";
            this.dtmReturnDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dtmReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmReturnDate.Location = new System.Drawing.Point(83, 9);
            this.dtmReturnDate.Name = "dtmReturnDate";
            this.dtmReturnDate.Size = new System.Drawing.Size(107, 22);
            this.dtmReturnDate.TabIndex = 1;
            // 
            // btnYes
            // 
            this.btnYes.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnYes.Location = new System.Drawing.Point(120, 80);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnCancle.Location = new System.Drawing.Point(35, 80);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "No";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Return Date";
            // 
            // frm_bpsReturnCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 129);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.dtmReturnDate);
            this.Controls.Add(this.label1);
            this.Name = "frm_bpsReturnCheque";
            this.Text = "Cheque Return";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_bpsReturnCheque_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtmReturnDate;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label label2;
    }
}