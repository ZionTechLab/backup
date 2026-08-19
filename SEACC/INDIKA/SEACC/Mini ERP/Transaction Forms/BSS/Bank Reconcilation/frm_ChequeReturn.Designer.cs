namespace Digiteq.Transaction_Forms.BSS.Bank_Reconcilation
{
    partial class frm_ChequeReturn
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
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.Detail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtmReturnDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Cheque";
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(74, 54);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(115, 22);
            this.txtCheque.TabIndex = 52;
            this.txtCheque.DoubleClick += new System.EventHandler(this.txtCheque_DoubleClick);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(255, 237);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(96, 29);
            this.btnReturn.TabIndex = 53;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // Detail
            // 
            this.Detail.AutoSize = true;
            this.Detail.Location = new System.Drawing.Point(21, 90);
            this.Detail.Name = "Detail";
            this.Detail.Size = new System.Drawing.Size(38, 13);
            this.Detail.TabIndex = 54;
            this.Detail.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(21, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 56;
            this.label2.Text = "Return Date";
            // 
            // dtmReturnDate
            // 
            this.dtmReturnDate.CustomFormat = "dd/MMM/yyyy";
            this.dtmReturnDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dtmReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmReturnDate.Location = new System.Drawing.Point(96, 240);
            this.dtmReturnDate.Name = "dtmReturnDate";
            this.dtmReturnDate.Size = new System.Drawing.Size(107, 22);
            this.dtmReturnDate.TabIndex = 55;
            // 
            // frm_ChequeReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtmReturnDate);
            this.Controls.Add(this.Detail);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtCheque);
            this.Controls.Add(this.label1);
            this.Name = "frm_ChequeReturn";
            this.Text = "frm_ChequeReturn";
            this.Load += new System.EventHandler(this.frm_ChequeReturn_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCheque, 0);
            this.Controls.SetChildIndex(this.btnReturn, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            this.Controls.SetChildIndex(this.dtmReturnDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label Detail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtmReturnDate;
    }
}