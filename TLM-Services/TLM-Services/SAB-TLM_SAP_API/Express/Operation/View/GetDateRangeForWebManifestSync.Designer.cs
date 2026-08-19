namespace Express.UI.Operation.View
{
    partial class GetDateRangeForWebManifestSync
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
            this.date_fdate = new System.Windows.Forms.DateTimePicker();
            this.lbl_FromDate = new System.Windows.Forms.Label();
            this.lbl_Todate = new System.Windows.Forms.Label();
            this.date_todate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // date_fdate
            // 
            this.date_fdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_fdate.Location = new System.Drawing.Point(199, 48);
            this.date_fdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.date_fdate.Name = "date_fdate";
            this.date_fdate.Size = new System.Drawing.Size(168, 26);
            this.date_fdate.TabIndex = 47;
            // 
            // lbl_FromDate
            // 
            this.lbl_FromDate.AutoSize = true;
            this.lbl_FromDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_FromDate.Location = new System.Drawing.Point(114, 50);
            this.lbl_FromDate.Name = "lbl_FromDate";
            this.lbl_FromDate.Size = new System.Drawing.Size(62, 23);
            this.lbl_FromDate.TabIndex = 45;
            this.lbl_FromDate.Text = "From :";
            // 
            // lbl_Todate
            // 
            this.lbl_Todate.AutoSize = true;
            this.lbl_Todate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Todate.Location = new System.Drawing.Point(136, 85);
            this.lbl_Todate.Name = "lbl_Todate";
            this.lbl_Todate.Size = new System.Drawing.Size(38, 23);
            this.lbl_Todate.TabIndex = 46;
            this.lbl_Todate.Text = "To :";
            // 
            // date_todate
            // 
            this.date_todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_todate.Location = new System.Drawing.Point(199, 82);
            this.date_todate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.date_todate.Name = "date_todate";
            this.date_todate.Size = new System.Drawing.Size(168, 26);
            this.date_todate.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 49);
            this.button1.TabIndex = 49;
            this.button1.Text = "Sync";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GetDateRangeForWebManifestSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 225);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.date_fdate);
            this.Controls.Add(this.lbl_FromDate);
            this.Controls.Add(this.lbl_Todate);
            this.Controls.Add(this.date_todate);
            this.Name = "GetDateRangeForWebManifestSync";
            this.Text = "GetDateRangeForWebManifestSync";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker date_fdate;
        private System.Windows.Forms.Label lbl_FromDate;
        private System.Windows.Forms.Label lbl_Todate;
        private System.Windows.Forms.DateTimePicker date_todate;
        private System.Windows.Forms.Button button1;
    }
}