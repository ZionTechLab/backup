namespace Digiteq
{
    partial class frm_masAccChequePrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_masAccChequePrinting));
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.chkAccPayee = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmount1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChequeNo1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblChequeDate = new System.Windows.Forms.Label();
            this.dtpChequeDate1 = new System.Windows.Forms.DateTimePicker();
            this.txtPayee1 = new System.Windows.Forms.TextBox();
            this.txtCRGID1 = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCRGID1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.x2 = new System.Windows.Forms.Panel();
            this.chkAccPayee2 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAmount2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChequeNo2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpChequeDate2 = new System.Windows.Forms.DateTimePicker();
            this.txtPayee2 = new System.Windows.Forms.TextBox();
            this.txtCRGID2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCRGID2 = new System.Windows.Forms.Label();
            this.PntDocCheque = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.x2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetails.Controls.Add(this.chkAccPayee);
            this.pnlDetails.Controls.Add(this.label7);
            this.pnlDetails.Controls.Add(this.txtAmount1);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Controls.Add(this.txtChequeNo1);
            this.pnlDetails.Controls.Add(this.label1);
            this.pnlDetails.Controls.Add(this.lblChequeDate);
            this.pnlDetails.Controls.Add(this.dtpChequeDate1);
            this.pnlDetails.Controls.Add(this.txtPayee1);
            this.pnlDetails.Controls.Add(this.txtCRGID1);
            this.pnlDetails.Controls.Add(this.lblTitle);
            this.pnlDetails.Controls.Add(this.lblCRGID1);
            this.pnlDetails.Location = new System.Drawing.Point(8, 76);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(433, 148);
            this.pnlDetails.TabIndex = 0;
            // 
            // chkAccPayee
            // 
            this.chkAccPayee.AutoSize = true;
            this.chkAccPayee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAccPayee.Location = new System.Drawing.Point(266, 113);
            this.chkAccPayee.Name = "chkAccPayee";
            this.chkAccPayee.Size = new System.Drawing.Size(143, 17);
            this.chkAccPayee.TabIndex = 11;
            this.chkAccPayee.Text = "Account Payee Cheque";
            this.chkAccPayee.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(327, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cheque";
            // 
            // txtAmount1
            // 
            this.txtAmount1.Enabled = false;
            this.txtAmount1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount1.Location = new System.Drawing.Point(80, 113);
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Size = new System.Drawing.Size(153, 22);
            this.txtAmount1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Amount";
            // 
            // txtChequeNo1
            // 
            this.txtChequeNo1.Enabled = false;
            this.txtChequeNo1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo1.Location = new System.Drawing.Point(80, 33);
            this.txtChequeNo1.Name = "txtChequeNo1";
            this.txtChequeNo1.Size = new System.Drawing.Size(153, 22);
            this.txtChequeNo1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cheque No.";
            // 
            // lblChequeDate
            // 
            this.lblChequeDate.AutoSize = true;
            this.lblChequeDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblChequeDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChequeDate.Location = new System.Drawing.Point(4, 88);
            this.lblChequeDate.Name = "lblChequeDate";
            this.lblChequeDate.Size = new System.Drawing.Size(70, 14);
            this.lblChequeDate.TabIndex = 2;
            this.lblChequeDate.Text = "Cheque Date";
            // 
            // dtpChequeDate1
            // 
            this.dtpChequeDate1.Enabled = false;
            this.dtpChequeDate1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dtpChequeDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate1.Location = new System.Drawing.Point(80, 85);
            this.dtpChequeDate1.Name = "dtpChequeDate1";
            this.dtpChequeDate1.Size = new System.Drawing.Size(153, 22);
            this.dtpChequeDate1.TabIndex = 5;
            this.dtpChequeDate1.Value = new System.DateTime(2011, 4, 1, 10, 17, 0, 0);
            // 
            // txtPayee1
            // 
            this.txtPayee1.Enabled = false;
            this.txtPayee1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayee1.Location = new System.Drawing.Point(80, 59);
            this.txtPayee1.Name = "txtPayee1";
            this.txtPayee1.Size = new System.Drawing.Size(341, 22);
            this.txtPayee1.TabIndex = 4;
            this.txtPayee1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinancialTitle_KeyDown);
            // 
            // txtCRGID1
            // 
            this.txtCRGID1.BackColor = System.Drawing.Color.LightGray;
            this.txtCRGID1.Enabled = false;
            this.txtCRGID1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCRGID1.Location = new System.Drawing.Point(80, 7);
            this.txtCRGID1.Name = "txtCRGID1";
            this.txtCRGID1.Size = new System.Drawing.Size(153, 22);
            this.txtCRGID1.TabIndex = 0;
            this.txtCRGID1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCRGID1_KeyDown);
            this.txtCRGID1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCRGID1_MouseDoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(4, 62);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(37, 14);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Payee";
            // 
            // lblCRGID1
            // 
            this.lblCRGID1.AutoSize = true;
            this.lblCRGID1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblCRGID1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCRGID1.Location = new System.Drawing.Point(4, 10);
            this.lblCRGID1.Name = "lblCRGID1";
            this.lblCRGID1.Size = new System.Drawing.Size(68, 14);
            this.lblCRGID1.TabIndex = 0;
            this.lblCRGID1.Text = "Register No.";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.accept;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(366, 230);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txtBank);
            this.panel2.Controls.Add(this.lblBank);
            this.panel2.Location = new System.Drawing.Point(8, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 34);
            this.panel2.TabIndex = 7;
            // 
            // txtBank
            // 
            this.txtBank.BackColor = System.Drawing.Color.LightGray;
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(80, 5);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(341, 22);
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
            // x2
            // 
            this.x2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(201)))), ((int)(((byte)(200)))));
            this.x2.Controls.Add(this.chkAccPayee2);
            this.x2.Controls.Add(this.label8);
            this.x2.Controls.Add(this.txtAmount2);
            this.x2.Controls.Add(this.label3);
            this.x2.Controls.Add(this.txtChequeNo2);
            this.x2.Controls.Add(this.label4);
            this.x2.Controls.Add(this.label5);
            this.x2.Controls.Add(this.dtpChequeDate2);
            this.x2.Controls.Add(this.txtPayee2);
            this.x2.Controls.Add(this.txtCRGID2);
            this.x2.Controls.Add(this.label6);
            this.x2.Controls.Add(this.lblCRGID2);
            this.x2.Location = new System.Drawing.Point(8, 266);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(433, 148);
            this.x2.TabIndex = 10;
            this.x2.Visible = false;
            // 
            // chkAccPayee2
            // 
            this.chkAccPayee2.AutoSize = true;
            this.chkAccPayee2.Location = new System.Drawing.Point(266, 118);
            this.chkAccPayee2.Name = "chkAccPayee2";
            this.chkAccPayee2.Size = new System.Drawing.Size(143, 17);
            this.chkAccPayee2.TabIndex = 12;
            this.chkAccPayee2.Text = "Account Payee Cheque";
            this.chkAccPayee2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label8.Location = new System.Drawing.Point(327, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 11;
            this.label8.Text = "Cheque 2";
            // 
            // txtAmount2
            // 
            this.txtAmount2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount2.Location = new System.Drawing.Point(80, 113);
            this.txtAmount2.Name = "txtAmount2";
            this.txtAmount2.Size = new System.Drawing.Size(153, 22);
            this.txtAmount2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(4, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount";
            // 
            // txtChequeNo2
            // 
            this.txtChequeNo2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo2.Location = new System.Drawing.Point(80, 33);
            this.txtChequeNo2.Name = "txtChequeNo2";
            this.txtChequeNo2.Size = new System.Drawing.Size(153, 22);
            this.txtChequeNo2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(4, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cheque No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(4, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cheque Date";
            // 
            // dtpChequeDate2
            // 
            this.dtpChequeDate2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.dtpChequeDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate2.Location = new System.Drawing.Point(80, 85);
            this.dtpChequeDate2.Name = "dtpChequeDate2";
            this.dtpChequeDate2.Size = new System.Drawing.Size(153, 22);
            this.dtpChequeDate2.TabIndex = 5;
            this.dtpChequeDate2.Value = new System.DateTime(2011, 4, 1, 10, 17, 0, 0);
            // 
            // txtPayee2
            // 
            this.txtPayee2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayee2.Location = new System.Drawing.Point(80, 59);
            this.txtPayee2.Name = "txtPayee2";
            this.txtPayee2.Size = new System.Drawing.Size(341, 22);
            this.txtPayee2.TabIndex = 4;
            // 
            // txtCRGID2
            // 
            this.txtCRGID2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCRGID2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCRGID2.Location = new System.Drawing.Point(80, 5);
            this.txtCRGID2.Name = "txtCRGID2";
            this.txtCRGID2.Size = new System.Drawing.Size(153, 22);
            this.txtCRGID2.TabIndex = 0;
            this.txtCRGID2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCRGID2_KeyDown);
            this.txtCRGID2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCRGID2_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(4, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "Payee";
            // 
            // lblCRGID2
            // 
            this.lblCRGID2.AutoSize = true;
            this.lblCRGID2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblCRGID2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCRGID2.Location = new System.Drawing.Point(4, 10);
            this.lblCRGID2.Name = "lblCRGID2";
            this.lblCRGID2.Size = new System.Drawing.Size(68, 14);
            this.lblCRGID2.TabIndex = 0;
            this.lblCRGID2.Text = "Register No.";
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
            // frm_masAccChequePrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 263);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlDetails);
            this.MaximizeBox = false;
            this.Name = "frm_masAccChequePrinting";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frm_masFinancialMaster_Load);
            this.Controls.SetChildIndex(this.pnlDetails, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.x2, 0);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.x2.ResumeLayout(false);
            this.x2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblChequeDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtCRGID1;
        private System.Windows.Forms.DateTimePicker dtpChequeDate1;
        private System.Windows.Forms.TextBox txtPayee1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblCRGID1;
        private System.Windows.Forms.TextBox txtAmount1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChequeNo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel x2;
        private System.Windows.Forms.TextBox txtAmount2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChequeNo2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpChequeDate2;
        private System.Windows.Forms.TextBox txtPayee2;
        private System.Windows.Forms.TextBox txtCRGID2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCRGID2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Drawing.Printing.PrintDocument PntDocCheque;
        private System.Windows.Forms.CheckBox chkAccPayee;
        private System.Windows.Forms.CheckBox chkAccPayee2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}