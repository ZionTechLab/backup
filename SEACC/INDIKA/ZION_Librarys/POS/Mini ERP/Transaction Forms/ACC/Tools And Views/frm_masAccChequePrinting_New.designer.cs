namespace Digiteq
{
    partial class frm_masAccChequePrinting_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_masAccChequePrinting_New));
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.PntDocCheque = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkAccPayee = new System.Windows.Forms.CheckBox();
            this.txtAmount1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtChequeNo1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblChequeDate = new System.Windows.Forms.Label();
            this.dtpChequeDate1 = new System.Windows.Forms.DateTimePicker();
            this.txtPayee1 = new System.Windows.Forms.TextBox();
            this.txtCRGID1 = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCRGID1 = new System.Windows.Forms.Label();
            this.chkCounterBookPrint = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(14, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cheque";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txtBank);
            this.panel2.Controls.Add(this.lblBank);
            this.panel2.Location = new System.Drawing.Point(11, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 34);
            this.panel2.TabIndex = 7;
            // 
            // txtBank
            // 
            this.txtBank.BackColor = System.Drawing.Color.LightGray;
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(80, 5);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(196, 22);
            this.txtBank.TabIndex = 0;
            this.txtBank.Text = "bank";
            this.txtBank.DoubleClick += new System.EventHandler(this.txtBank_DoubleClick);
            this.txtBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBank_KeyDown);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblBank.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBank.Location = new System.Drawing.Point(7, 8);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(32, 14);
            this.lblBank.TabIndex = 0;
            this.lblBank.Text = "Bank";
            // 
            // PntDocCheque
            // 
            this.PntDocCheque.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PntDocCheque_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(12, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 1);
            this.panel1.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(16, 351);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 1);
            this.panel3.TabIndex = 27;
            // 
            // chkAccPayee
            // 
            this.chkAccPayee.AutoSize = true;
            this.chkAccPayee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAccPayee.Location = new System.Drawing.Point(92, 294);
            this.chkAccPayee.Name = "chkAccPayee";
            this.chkAccPayee.Size = new System.Drawing.Size(143, 17);
            this.chkAccPayee.TabIndex = 25;
            this.chkAccPayee.Text = "Account Payee Cheque";
            this.chkAccPayee.UseVisualStyleBackColor = true;
            // 
            // txtAmount1
            // 
            this.txtAmount1.Enabled = false;
            this.txtAmount1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount1.Location = new System.Drawing.Point(92, 266);
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Size = new System.Drawing.Size(196, 22);
            this.txtAmount1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(16, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Amount";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.accept;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(213, 358);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtChequeNo1
            // 
            this.txtChequeNo1.Enabled = false;
            this.txtChequeNo1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo1.Location = new System.Drawing.Point(92, 137);
            this.txtChequeNo1.Name = "txtChequeNo1";
            this.txtChequeNo1.Size = new System.Drawing.Size(196, 22);
            this.txtChequeNo1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cheque No.";
            // 
            // lblChequeDate
            // 
            this.lblChequeDate.AutoSize = true;
            this.lblChequeDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblChequeDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChequeDate.Location = new System.Drawing.Point(16, 241);
            this.lblChequeDate.Name = "lblChequeDate";
            this.lblChequeDate.Size = new System.Drawing.Size(70, 14);
            this.lblChequeDate.TabIndex = 18;
            this.lblChequeDate.Text = "Cheque Date";
            // 
            // dtpChequeDate1
            // 
            this.dtpChequeDate1.Enabled = false;
            this.dtpChequeDate1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dtpChequeDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate1.Location = new System.Drawing.Point(92, 238);
            this.dtpChequeDate1.Name = "dtpChequeDate1";
            this.dtpChequeDate1.Size = new System.Drawing.Size(196, 22);
            this.dtpChequeDate1.TabIndex = 20;
            this.dtpChequeDate1.Value = new System.DateTime(2011, 4, 1, 10, 17, 0, 0);
            // 
            // txtPayee1
            // 
            this.txtPayee1.Enabled = false;
            this.txtPayee1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayee1.Location = new System.Drawing.Point(92, 163);
            this.txtPayee1.Multiline = true;
            this.txtPayee1.Name = "txtPayee1";
            this.txtPayee1.Size = new System.Drawing.Size(196, 71);
            this.txtPayee1.TabIndex = 19;
            // 
            // txtCRGID1
            // 
            this.txtCRGID1.BackColor = System.Drawing.Color.LightGray;
            this.txtCRGID1.Enabled = false;
            this.txtCRGID1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCRGID1.Location = new System.Drawing.Point(92, 111);
            this.txtCRGID1.Name = "txtCRGID1";
            this.txtCRGID1.Size = new System.Drawing.Size(196, 22);
            this.txtCRGID1.TabIndex = 15;
            this.txtCRGID1.DoubleClick += new System.EventHandler(this.txtCRGID1_DoubleClick);
            this.txtCRGID1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCRGID1_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(16, 166);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(37, 14);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Payee";
            // 
            // lblCRGID1
            // 
            this.lblCRGID1.AutoSize = true;
            this.lblCRGID1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblCRGID1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCRGID1.Location = new System.Drawing.Point(16, 114);
            this.lblCRGID1.Name = "lblCRGID1";
            this.lblCRGID1.Size = new System.Drawing.Size(68, 14);
            this.lblCRGID1.TabIndex = 16;
            this.lblCRGID1.Text = "Register No.";
            // 
            // chkCounterBookPrint
            // 
            this.chkCounterBookPrint.AutoSize = true;
            this.chkCounterBookPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCounterBookPrint.Location = new System.Drawing.Point(92, 317);
            this.chkCounterBookPrint.Name = "chkCounterBookPrint";
            this.chkCounterBookPrint.Size = new System.Drawing.Size(125, 17);
            this.chkCounterBookPrint.TabIndex = 28;
            this.chkCounterBookPrint.Text = "Counter Book Print";
            this.chkCounterBookPrint.UseVisualStyleBackColor = true;
            // 
            // frm_masAccChequePrinting_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 397);
            this.Controls.Add(this.chkCounterBookPrint);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.chkAccPayee);
            this.Controls.Add(this.txtAmount1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtChequeNo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblChequeDate);
            this.Controls.Add(this.dtpChequeDate1);
            this.Controls.Add(this.txtPayee1);
            this.Controls.Add(this.txtCRGID1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCRGID1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.MaximizeBox = false;
            this.Name = "frm_masAccChequePrinting_New";
            this.Text = "Cheque Details";
            this.Load += new System.EventHandler(this.frm_masFinancialMaster_Load);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblCRGID1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.txtCRGID1, 0);
            this.Controls.SetChildIndex(this.txtPayee1, 0);
            this.Controls.SetChildIndex(this.dtpChequeDate1, 0);
            this.Controls.SetChildIndex(this.lblChequeDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtChequeNo1, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtAmount1, 0);
            this.Controls.SetChildIndex(this.chkAccPayee, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.chkCounterBookPrint, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument PntDocCheque;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkAccPayee;
        private System.Windows.Forms.TextBox txtAmount1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtChequeNo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblChequeDate;
        private System.Windows.Forms.DateTimePicker dtpChequeDate1;
        private System.Windows.Forms.TextBox txtPayee1;
        private System.Windows.Forms.TextBox txtCRGID1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCRGID1;
        private System.Windows.Forms.CheckBox chkCounterBookPrint;
    }
}