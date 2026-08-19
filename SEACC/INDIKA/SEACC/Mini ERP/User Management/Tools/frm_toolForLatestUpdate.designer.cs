namespace Digiteq
{
    partial class frm_ToolUpdateOldestInvoiceDate
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExecute2 = new System.Windows.Forms.Button();
            this.btnExecute4 = new System.Windows.Forms.Button();
            this.btnLogon = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btn_CheckDepositCorect = new System.Windows.Forms.Button();
            this.btn_CashDep_postingCorrection = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_POSTING_Rem_CUSREFUND = new System.Windows.Forms.Button();
            this.btn_GLPostingTblUpdate = new System.Windows.Forms.Button();
            this.btn_CRNPosting = new System.Windows.Forms.Button();
            this.btnSalesReceipt = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(7, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 301);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExecute2);
            this.flowLayoutPanel1.Controls.Add(this.btnExecute4);
            this.flowLayoutPanel1.Controls.Add(this.btnLogon);
            this.flowLayoutPanel1.Controls.Add(this.button10);
            this.flowLayoutPanel1.Controls.Add(this.btn_CheckDepositCorect);
            this.flowLayoutPanel1.Controls.Add(this.btn_CashDep_postingCorrection);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.btn_POSTING_Rem_CUSREFUND);
            this.flowLayoutPanel1.Controls.Add(this.btn_GLPostingTblUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btn_CRNPosting);
            this.flowLayoutPanel1.Controls.Add(this.btnSalesReceipt);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(435, 290);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btnExecute2
            // 
            this.btnExecute2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute2.Location = new System.Drawing.Point(3, 3);
            this.btnExecute2.Name = "btnExecute2";
            this.btnExecute2.Size = new System.Drawing.Size(133, 48);
            this.btnExecute2.TabIndex = 8;
            this.btnExecute2.Text = "01. Update Company Name";
            this.btnExecute2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute2.UseVisualStyleBackColor = true;
            this.btnExecute2.Click += new System.EventHandler(this.btnExecute2_Click);
            // 
            // btnExecute4
            // 
            this.btnExecute4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute4.Location = new System.Drawing.Point(142, 3);
            this.btnExecute4.Name = "btnExecute4";
            this.btnExecute4.Size = new System.Drawing.Size(133, 48);
            this.btnExecute4.TabIndex = 10;
            this.btnExecute4.Text = "04. Invoice Settled";
            this.btnExecute4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute4.UseVisualStyleBackColor = true;
            this.btnExecute4.Click += new System.EventHandler(this.btnExecute4_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogon.Location = new System.Drawing.Point(281, 3);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(133, 48);
            this.btnLogon.TabIndex = 6;
            this.btnLogon.Text = "update invoice - settled amount";
            this.btnLogon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(3, 57);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(133, 48);
            this.button10.TabIndex = 16;
            this.button10.Text = "PV posting temp recreate";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // btn_CheckDepositCorect
            // 
            this.btn_CheckDepositCorect.Location = new System.Drawing.Point(142, 57);
            this.btn_CheckDepositCorect.Name = "btn_CheckDepositCorect";
            this.btn_CheckDepositCorect.Size = new System.Drawing.Size(133, 48);
            this.btn_CheckDepositCorect.TabIndex = 17;
            this.btn_CheckDepositCorect.Text = "2017-08-03 Cheque deposit Posting Correction (ITC Only)";
            this.btn_CheckDepositCorect.UseVisualStyleBackColor = true;
            this.btn_CheckDepositCorect.Click += new System.EventHandler(this.btn_CheckDepositCorect_Click);
            // 
            // btn_CashDep_postingCorrection
            // 
            this.btn_CashDep_postingCorrection.Location = new System.Drawing.Point(281, 57);
            this.btn_CashDep_postingCorrection.Name = "btn_CashDep_postingCorrection";
            this.btn_CashDep_postingCorrection.Size = new System.Drawing.Size(133, 48);
            this.btn_CashDep_postingCorrection.TabIndex = 18;
            this.btn_CashDep_postingCorrection.Text = "2017-08-08 Cash deposit Posting Correction (ITC Only)";
            this.btn_CashDep_postingCorrection.UseVisualStyleBackColor = true;
            this.btn_CashDep_postingCorrection.Click += new System.EventHandler(this.btn_CashDep_postingCorrection_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 48);
            this.button1.TabIndex = 19;
            this.button1.Text = "2017-08-10 Cheque # update for PV postings (TW Only)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_POSTING_Rem_CUSREFUND
            // 
            this.btn_POSTING_Rem_CUSREFUND.Location = new System.Drawing.Point(142, 111);
            this.btn_POSTING_Rem_CUSREFUND.Name = "btn_POSTING_Rem_CUSREFUND";
            this.btn_POSTING_Rem_CUSREFUND.Size = new System.Drawing.Size(133, 48);
            this.btn_POSTING_Rem_CUSREFUND.TabIndex = 20;
            this.btn_POSTING_Rem_CUSREFUND.Text = "2017-08-29 Posting Remove - Customer Refundable Note";
            this.btn_POSTING_Rem_CUSREFUND.UseVisualStyleBackColor = true;
            this.btn_POSTING_Rem_CUSREFUND.Click += new System.EventHandler(this.btn_POSTING_Rem_CUSREFUND_Click);
            // 
            // btn_GLPostingTblUpdate
            // 
            this.btn_GLPostingTblUpdate.Location = new System.Drawing.Point(281, 111);
            this.btn_GLPostingTblUpdate.Name = "btn_GLPostingTblUpdate";
            this.btn_GLPostingTblUpdate.Size = new System.Drawing.Size(133, 48);
            this.btn_GLPostingTblUpdate.TabIndex = 21;
            this.btn_GLPostingTblUpdate.Text = "2017-09-08 Update Table  [tbl_accGLPosting]";
            this.btn_GLPostingTblUpdate.UseVisualStyleBackColor = true;
            this.btn_GLPostingTblUpdate.Click += new System.EventHandler(this.btn_GLPostingTblUpdate_Click);
            // 
            // btn_CRNPosting
            // 
            this.btn_CRNPosting.Location = new System.Drawing.Point(3, 165);
            this.btn_CRNPosting.Name = "btn_CRNPosting";
            this.btn_CRNPosting.Size = new System.Drawing.Size(133, 48);
            this.btn_CRNPosting.TabIndex = 17;
            this.btn_CRNPosting.Text = "2017-11-02 Credit note posting recreate (TW Only)";
            this.btn_CRNPosting.UseVisualStyleBackColor = true;
            this.btn_CRNPosting.Click += new System.EventHandler(this.btn_CRNPosting_Click);
            // 
            // btnSalesReceipt
            // 
            this.btnSalesReceipt.Location = new System.Drawing.Point(142, 165);
            this.btnSalesReceipt.Name = "btnSalesReceipt";
            this.btnSalesReceipt.Size = new System.Drawing.Size(133, 48);
            this.btnSalesReceipt.TabIndex = 22;
            this.btnSalesReceipt.Text = "2018-04-02 Sales Receipt";
            this.btnSalesReceipt.UseVisualStyleBackColor = true;
            this.btnSalesReceipt.Click += new System.EventHandler(this.btnSalesReceipt_Click);
            // 
            // frm_ToolUpdateOldestInvoiceDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(197)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(470, 347);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frm_ToolUpdateOldestInvoiceDate";
            this.Text = "DON\'T EXECUTE UNLESS U ASK FROM TECHLEAD";
            this.Load += new System.EventHandler(this.frmQuickLogin_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Button btnExecute2;
        private System.Windows.Forms.Button btnExecute4;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btn_CheckDepositCorect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_CashDep_postingCorrection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_POSTING_Rem_CUSREFUND;
        private System.Windows.Forms.Button btn_GLPostingTblUpdate;
        private System.Windows.Forms.Button btn_CRNPosting;
        private System.Windows.Forms.Button btnSalesReceipt;
    }
}