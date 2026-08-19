namespace Digiteq
{
    partial class UC_TotalCalc
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
            this.label19 = new System.Windows.Forms.Label();
            this.txtPercentageNBT = new System.Windows.Forms.TextBox();
            this.chkNBT = new System.Windows.Forms.CheckBox();
            this.chkOtherTax = new System.Windows.Forms.CheckBox();
            this.chkVat = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPercentageOtherTax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPercentageVat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSubTotal = new Digiteq.UC_FinanceTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGrandTotal = new Digiteq.UC_FinanceTextBox();
            this.txtNBT = new Digiteq.UC_FinanceTextBox();
            this.txtVat = new Digiteq.UC_FinanceTextBox();
            this.txtOtherTax = new Digiteq.UC_FinanceTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.chkDisc = new System.Windows.Forms.CheckBox();
            this.txtDisc_Present = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new Digiteq.UC_FinanceTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label19.Location = new System.Drawing.Point(138, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 13);
            this.label19.TabIndex = 571;
            this.label19.Text = "%";
            // 
            // txtPercentageNBT
            // 
            this.txtPercentageNBT.Enabled = false;
            this.txtPercentageNBT.Location = new System.Drawing.Point(85, 3);
            this.txtPercentageNBT.Name = "txtPercentageNBT";
            this.txtPercentageNBT.Size = new System.Drawing.Size(47, 22);
            this.txtPercentageNBT.TabIndex = 570;
            this.txtPercentageNBT.Text = "0";
            this.txtPercentageNBT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkNBT
            // 
            this.chkNBT.AutoSize = true;
            this.chkNBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkNBT.Location = new System.Drawing.Point(7, 6);
            this.chkNBT.Name = "chkNBT";
            this.chkNBT.Size = new System.Drawing.Size(49, 17);
            this.chkNBT.TabIndex = 569;
            this.chkNBT.Text = "NBT ";
            this.chkNBT.UseVisualStyleBackColor = true;
            this.chkNBT.CheckedChanged += new System.EventHandler(this.chkNBT_CheckedChanged);
            // 
            // chkOtherTax
            // 
            this.chkOtherTax.AutoSize = true;
            this.chkOtherTax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkOtherTax.Location = new System.Drawing.Point(7, 57);
            this.chkOtherTax.Name = "chkOtherTax";
            this.chkOtherTax.Size = new System.Drawing.Size(49, 17);
            this.chkOtherTax.TabIndex = 562;
            this.chkOtherTax.Text = "SVAT";
            this.chkOtherTax.UseVisualStyleBackColor = true;
            this.chkOtherTax.CheckedChanged += new System.EventHandler(this.chkOtherTax_CheckedChanged);
            // 
            // chkVat
            // 
            this.chkVat.AutoSize = true;
            this.chkVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkVat.Location = new System.Drawing.Point(7, 32);
            this.chkVat.Name = "chkVat";
            this.chkVat.Size = new System.Drawing.Size(43, 17);
            this.chkVat.TabIndex = 558;
            this.chkVat.Text = "VAT";
            this.chkVat.UseVisualStyleBackColor = true;
            this.chkVat.CheckedChanged += new System.EventHandler(this.chkVat_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(7, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 556;
            this.label9.Text = "Sub Total";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label14.Location = new System.Drawing.Point(139, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 564;
            this.label14.Text = "%";
            // 
            // txtPercentageOtherTax
            // 
            this.txtPercentageOtherTax.Enabled = false;
            this.txtPercentageOtherTax.Location = new System.Drawing.Point(85, 55);
            this.txtPercentageOtherTax.Name = "txtPercentageOtherTax";
            this.txtPercentageOtherTax.Size = new System.Drawing.Size(48, 22);
            this.txtPercentageOtherTax.TabIndex = 563;
            this.txtPercentageOtherTax.Text = "0";
            this.txtPercentageOtherTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label13.Location = new System.Drawing.Point(138, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 560;
            this.label13.Text = "%";
            // 
            // txtPercentageVat
            // 
            this.txtPercentageVat.Enabled = false;
            this.txtPercentageVat.Location = new System.Drawing.Point(85, 29);
            this.txtPercentageVat.Name = "txtPercentageVat";
            this.txtPercentageVat.Size = new System.Drawing.Size(47, 22);
            this.txtPercentageVat.TabIndex = 559;
            this.txtPercentageVat.Text = "0";
            this.txtPercentageVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(7, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 566;
            this.label7.Text = "Bill Amount";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtSubTotal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 28);
            this.panel1.TabIndex = 576;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.IsCredit = false;
            this.txtSubTotal.Location = new System.Drawing.Point(85, 3);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(220, 23);
            this.txtSubTotal.TabIndex = 575;
            this.txtSubTotal.TxnCat = Digiteq_Logic.TransactionCategory.SubTotal;
            this.txtSubTotal.ucEnabled = true;
            this.txtSubTotal.TextboxValuechanged += new Digiteq.UC_FinanceTextBox.ValueChange(this.uC_FinanceTextBox4_TextboxValuechanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkNBT);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtPercentageVat);
            this.panel2.Controls.Add(this.txtGrandTotal);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtNBT);
            this.panel2.Controls.Add(this.txtPercentageOtherTax);
            this.panel2.Controls.Add(this.txtVat);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtOtherTax);
            this.panel2.Controls.Add(this.chkVat);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.chkOtherTax);
            this.panel2.Controls.Add(this.txtPercentageNBT);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 108);
            this.panel2.TabIndex = 577;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.IsCredit = true;
            this.txtGrandTotal.Location = new System.Drawing.Point(85, 79);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(220, 23);
            this.txtGrandTotal.TabIndex = 575;
            this.txtGrandTotal.TxnCat = Digiteq_Logic.TransactionCategory.GrandTotal;
            this.txtGrandTotal.ucEnabled = false;
            this.txtGrandTotal.TextboxValuechanged += new Digiteq.UC_FinanceTextBox.ValueChange(this.uC_FinanceTextBox4_TextboxValuechanged);
            // 
            // txtNBT
            // 
            this.txtNBT.IsCredit = false;
            this.txtNBT.Location = new System.Drawing.Point(167, 2);
            this.txtNBT.Name = "txtNBT";
            this.txtNBT.Size = new System.Drawing.Size(138, 23);
            this.txtNBT.TabIndex = 575;
            this.txtNBT.TxnCat = Digiteq_Logic.TransactionCategory.NBT;
            this.txtNBT.ucEnabled = false;
            this.txtNBT.TextboxValuechanged += new Digiteq.UC_FinanceTextBox.ValueChange(this.uC_FinanceTextBox4_TextboxValuechanged);
            // 
            // txtVat
            // 
            this.txtVat.IsCredit = false;
            this.txtVat.Location = new System.Drawing.Point(167, 28);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(138, 23);
            this.txtVat.TabIndex = 575;
            this.txtVat.TxnCat = Digiteq_Logic.TransactionCategory.VAT;
            this.txtVat.ucEnabled = false;
            this.txtVat.TextboxValuechanged += new Digiteq.UC_FinanceTextBox.ValueChange(this.uC_FinanceTextBox4_TextboxValuechanged);
            // 
            // txtOtherTax
            // 
            this.txtOtherTax.IsCredit = false;
            this.txtOtherTax.Location = new System.Drawing.Point(167, 54);
            this.txtOtherTax.Name = "txtOtherTax";
            this.txtOtherTax.Size = new System.Drawing.Size(138, 23);
            this.txtOtherTax.TabIndex = 574;
            this.txtOtherTax.TxnCat = Digiteq_Logic.TransactionCategory.SVAT;
            this.txtOtherTax.ucEnabled = false;
            this.txtOtherTax.TextboxValuechanged += new Digiteq.UC_FinanceTextBox.ValueChange(this.uC_FinanceTextBox4_TextboxValuechanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkDisc);
            this.flowLayoutPanel1.Controls.Add(this.txtDisc_Present);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtDesc);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(326, 23);
            this.flowLayoutPanel1.TabIndex = 578;
            // 
            // chkDisc
            // 
            this.chkDisc.AutoSize = true;
            this.chkDisc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkDisc.Location = new System.Drawing.Point(7, 3);
            this.chkDisc.Name = "chkDisc";
            this.chkDisc.Size = new System.Drawing.Size(72, 17);
            this.chkDisc.TabIndex = 569;
            this.chkDisc.Text = "Discount";
            this.chkDisc.UseVisualStyleBackColor = true;
            this.chkDisc.CheckedChanged += new System.EventHandler(this.chkDisc_CheckedChanged);
            // 
            // txtDisc_Present
            // 
            this.txtDisc_Present.Enabled = false;
            this.txtDisc_Present.Location = new System.Drawing.Point(85, 1);
            this.txtDisc_Present.Name = "txtDisc_Present";
            this.txtDisc_Present.Size = new System.Drawing.Size(47, 22);
            this.txtDisc_Present.TabIndex = 570;
            this.txtDisc_Present.Text = "0";
            this.txtDisc_Present.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc_Present.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDisc_Present_KeyDown);
            this.txtDisc_Present.Leave += new System.EventHandler(this.txtDisc_Present_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(139, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 571;
            this.label1.Text = "%";
            // 
            // txtDesc
            // 
            this.txtDesc.IsCredit = true;
            this.txtDesc.Location = new System.Drawing.Point(167, 0);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(138, 23);
            this.txtDesc.TabIndex = 575;
            this.txtDesc.TxnCat = Digiteq_Logic.TransactionCategory.Discount;
            this.txtDesc.ucEnabled = false;
            this.txtDesc.TextboxValuechanged += new Digiteq.UC_FinanceTextBox.ValueChange(this.uC_FinanceTextBox4_TextboxValuechanged);
            // 
            // UC_TotalCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_TotalCalc";
            this.Size = new System.Drawing.Size(326, 157);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPercentageNBT;
        private System.Windows.Forms.CheckBox chkNBT;
        private System.Windows.Forms.CheckBox chkOtherTax;
        private System.Windows.Forms.CheckBox chkVat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPercentageOtherTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPercentageVat;
        private System.Windows.Forms.Label label7;
        private UC_FinanceTextBox txtOtherTax;
        private UC_FinanceTextBox txtVat;
        private UC_FinanceTextBox txtNBT;
        private UC_FinanceTextBox txtSubTotal;
        private UC_FinanceTextBox txtGrandTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkDisc;
        private System.Windows.Forms.TextBox txtDisc_Present;
        private System.Windows.Forms.Label label1;
        private UC_FinanceTextBox txtDesc;
    }
}
