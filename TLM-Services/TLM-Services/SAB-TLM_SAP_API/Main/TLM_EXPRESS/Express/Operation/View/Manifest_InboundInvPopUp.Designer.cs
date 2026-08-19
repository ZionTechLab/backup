namespace Express.UI.Operation.View
{
    partial class Manifest_InboundInvPopUp
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
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustomPay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBayanNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPayrefNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dtePayment = new System.Windows.Forms.DateTimePicker();
            this.txtLocCurrency = new System.Windows.Forms.TextBox();
            this.txtPayVouNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPayAccount = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Customs Payment Amount :";
            // 
            // txtCustomPay
            // 
            this.txtCustomPay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomPay.Location = new System.Drawing.Point(157, 21);
            this.txtCustomPay.Name = "txtCustomPay";
            this.txtCustomPay.ReadOnly = true;
            this.txtCustomPay.Size = new System.Drawing.Size(150, 22);
            this.txtCustomPay.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Payment/Invoice Date :";
            // 
            // txtBayanNo
            // 
            this.txtBayanNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBayanNo.Location = new System.Drawing.Point(157, 69);
            this.txtBayanNo.MaxLength = 15;
            this.txtBayanNo.Name = "txtBayanNo";
            this.txtBayanNo.Size = new System.Drawing.Size(150, 22);
            this.txtBayanNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Bayan No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Payment Ref :";
            // 
            // txtPayrefNo
            // 
            this.txtPayrefNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayrefNo.Location = new System.Drawing.Point(157, 93);
            this.txtPayrefNo.MaxLength = 20;
            this.txtPayrefNo.Name = "txtPayrefNo";
            this.txtPayrefNo.Size = new System.Drawing.Size(150, 22);
            this.txtPayrefNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Payment Account No :";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(247, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(157, 200);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(90, 34);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dtePayment
            // 
            this.dtePayment.Enabled = false;
            this.dtePayment.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtePayment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtePayment.Location = new System.Drawing.Point(157, 45);
            this.dtePayment.Name = "dtePayment";
            this.dtePayment.Size = new System.Drawing.Size(85, 22);
            this.dtePayment.TabIndex = 1;
            // 
            // txtLocCurrency
            // 
            this.txtLocCurrency.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocCurrency.Location = new System.Drawing.Point(309, 21);
            this.txtLocCurrency.Name = "txtLocCurrency";
            this.txtLocCurrency.ReadOnly = true;
            this.txtLocCurrency.Size = new System.Drawing.Size(34, 22);
            this.txtLocCurrency.TabIndex = 41;
            // 
            // txtPayVouNum
            // 
            this.txtPayVouNum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayVouNum.Location = new System.Drawing.Point(157, 140);
            this.txtPayVouNum.Multiline = true;
            this.txtPayVouNum.Name = "txtPayVouNum";
            this.txtPayVouNum.ReadOnly = true;
            this.txtPayVouNum.Size = new System.Drawing.Size(186, 54);
            this.txtPayVouNum.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Payment Voucher No :";
            // 
            // cmbPayAccount
            // 
            this.cmbPayAccount.DisplayMember = "AccDesc";
            this.cmbPayAccount.FormattingEnabled = true;
            this.cmbPayAccount.Location = new System.Drawing.Point(157, 117);
            this.cmbPayAccount.Name = "cmbPayAccount";
            this.cmbPayAccount.Size = new System.Drawing.Size(186, 21);
            this.cmbPayAccount.TabIndex = 81;
            this.cmbPayAccount.ValueMember = "AccountCode";
            // 
            // Manifest_InboundInvPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 275);
            this.Controls.Add(this.cmbPayAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPayVouNum);
            this.Controls.Add(this.txtLocCurrency);
            this.Controls.Add(this.dtePayment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPayrefNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBayanNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCustomPay);
            this.MaximizeBox = false;
            this.Name = "Manifest_InboundInvPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manifest Inbound Invoice Process";
            this.Load += new System.EventHandler(this.Manifest_InboundInvPopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustomPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBayanNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPayrefNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DateTimePicker dtePayment;
        private System.Windows.Forms.TextBox txtLocCurrency;
        private System.Windows.Forms.TextBox txtPayVouNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPayAccount;
    }
}