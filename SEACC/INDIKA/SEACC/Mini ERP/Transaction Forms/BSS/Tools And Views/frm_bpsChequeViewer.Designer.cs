namespace Digiteq
{
    partial class frm_bpsChequeViewer
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
            this.label26 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Refresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAccouNo = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.lblChequeAmount = new System.Windows.Forms.Label();
            this.lblChequeDate = new System.Windows.Forms.Label();
            this.lblChequeNo = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.lblLocationID = new System.Windows.Forms.Label();
            this.lblReceiptDate = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.lblRegisterCode = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dataGridView1 = new SEACC_DataGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(12, 9);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(180, 19);
            this.label26.TabIndex = 274;
            this.label26.Text = "SEACC VIEWER - CHEQUE ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblReceiptDate);
            this.panel1.Controls.Add(this.label97);
            this.panel1.Controls.Add(this.lblReceiptNo);
            this.panel1.Controls.Add(this.lblAccouNo);
            this.panel1.Controls.Add(this.label96);
            this.panel1.Controls.Add(this.lblCustomerName);
            this.panel1.Controls.Add(this.lblBankName);
            this.panel1.Controls.Add(this.label77);
            this.panel1.Controls.Add(this.label70);
            this.panel1.Controls.Add(this.label73);
            this.panel1.Controls.Add(this.lblChequeAmount);
            this.panel1.Controls.Add(this.lblChequeDate);
            this.panel1.Controls.Add(this.lblChequeNo);
            this.panel1.Controls.Add(this.lblRegisterCode);
            this.panel1.Controls.Add(this.label221);
            this.panel1.Controls.Add(this.label222);
            this.panel1.Controls.Add(this.lblLocationID);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 85);
            this.panel1.TabIndex = 403;
            // 
            // Refresh
            // 
            this.Refresh.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh.Image = global::Digiteq.Properties.Resources.refresh;
            this.Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Refresh.Location = new System.Drawing.Point(502, 9);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(65, 25);
            this.Refresh.TabIndex = 396;
            this.Refresh.Text = "Refresh";
            this.Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(573, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 25);
            this.btnCancel.TabIndex = 395;
            this.btnCancel.Text = "  Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAccouNo
            // 
            this.lblAccouNo.AutoSize = true;
            this.lblAccouNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccouNo.ForeColor = System.Drawing.Color.Black;
            this.lblAccouNo.Location = new System.Drawing.Point(110, 48);
            this.lblAccouNo.Name = "lblAccouNo";
            this.lblAccouNo.Size = new System.Drawing.Size(61, 13);
            this.lblAccouNo.TabIndex = 389;
            this.lblAccouNo.Text = "360,211.00";
            this.lblAccouNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.Black;
            this.lblBankName.Location = new System.Drawing.Point(110, 34);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(70, 13);
            this.lblBankName.TabIndex = 387;
            this.lblBankName.Text = "1,120,175.00";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label70.Location = new System.Drawing.Point(8, 48);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(70, 15);
            this.label70.TabIndex = 386;
            this.label70.Text = "Account No";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label73.Location = new System.Drawing.Point(8, 34);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(69, 15);
            this.label73.TabIndex = 384;
            this.label73.Text = "Bank Name";
            // 
            // lblChequeAmount
            // 
            this.lblChequeAmount.AutoSize = true;
            this.lblChequeAmount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeAmount.ForeColor = System.Drawing.Color.Black;
            this.lblChequeAmount.Location = new System.Drawing.Point(110, 61);
            this.lblChequeAmount.Name = "lblChequeAmount";
            this.lblChequeAmount.Size = new System.Drawing.Size(61, 13);
            this.lblChequeAmount.TabIndex = 370;
            this.lblChequeAmount.Text = "360,211.00";
            this.lblChequeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChequeDate
            // 
            this.lblChequeDate.AutoSize = true;
            this.lblChequeDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeDate.ForeColor = System.Drawing.Color.Black;
            this.lblChequeDate.Location = new System.Drawing.Point(110, 21);
            this.lblChequeDate.Name = "lblChequeDate";
            this.lblChequeDate.Size = new System.Drawing.Size(61, 13);
            this.lblChequeDate.TabIndex = 369;
            this.lblChequeDate.Text = "160,251.00";
            this.lblChequeDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeNo.ForeColor = System.Drawing.Color.Black;
            this.lblChequeNo.Location = new System.Drawing.Point(110, 6);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(70, 13);
            this.lblChequeNo.TabIndex = 368;
            this.lblChequeNo.Text = "1,120,175.00";
            this.lblChequeNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label221.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label221.Location = new System.Drawing.Point(8, 19);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(78, 15);
            this.label221.TabIndex = 357;
            this.label221.Text = "Cheque Date";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label222.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label222.Location = new System.Drawing.Point(8, 61);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(97, 15);
            this.label222.TabIndex = 359;
            this.label222.Text = "Cheque Amount";
            // 
            // lblLocationID
            // 
            this.lblLocationID.AutoSize = true;
            this.lblLocationID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblLocationID.Location = new System.Drawing.Point(8, 4);
            this.lblLocationID.Name = "lblLocationID";
            this.lblLocationID.Size = new System.Drawing.Size(68, 15);
            this.lblLocationID.TabIndex = 273;
            this.lblLocationID.Text = "Cheque No";
            // 
            // lblReceiptDate
            // 
            this.lblReceiptDate.AutoSize = true;
            this.lblReceiptDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptDate.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptDate.Location = new System.Drawing.Point(403, 50);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(61, 13);
            this.lblReceiptDate.TabIndex = 397;
            this.lblReceiptDate.Text = "360,211.00";
            this.lblReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label97.Location = new System.Drawing.Point(301, 48);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(77, 15);
            this.label97.TabIndex = 396;
            this.label97.Text = "Receipt Date";
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptNo.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptNo.Location = new System.Drawing.Point(403, 34);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(61, 13);
            this.lblReceiptNo.TabIndex = 395;
            this.lblReceiptNo.Text = "360,211.00";
            this.lblReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label96.Location = new System.Drawing.Point(301, 34);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(67, 15);
            this.label96.TabIndex = 394;
            this.label96.Text = "Receipt No";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(403, 6);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(61, 13);
            this.lblCustomerName.TabIndex = 393;
            this.lblCustomerName.Text = "360,211.00";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label77.Location = new System.Drawing.Point(301, 4);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(97, 15);
            this.label77.TabIndex = 392;
            this.label77.Text = "Customer Name";
            // 
            // lblRegisterCode
            // 
            this.lblRegisterCode.AutoSize = true;
            this.lblRegisterCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterCode.ForeColor = System.Drawing.Color.Black;
            this.lblRegisterCode.Location = new System.Drawing.Point(403, 21);
            this.lblRegisterCode.Name = "lblRegisterCode";
            this.lblRegisterCode.Size = new System.Drawing.Size(70, 13);
            this.lblRegisterCode.TabIndex = 368;
            this.lblRegisterCode.Text = "1,120,175.00";
            this.lblRegisterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label22.Location = new System.Drawing.Point(301, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 15);
            this.label22.TabIndex = 273;
            this.label22.Text = "Register Code";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(630, 148);
            this.dataGridView1.TabIndex = 404;
            // 
            // frm_bpsChequeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 294);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label26);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_bpsChequeViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_bpsChequeViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAccouNo;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label lblChequeAmount;
        private System.Windows.Forms.Label lblChequeDate;
        private System.Windows.Forms.Label lblChequeNo;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.Label lblLocationID;
        private System.Windows.Forms.Label lblRegisterCode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblReceiptDate;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button btnCancel;
        private SEACC_DataGrid dataGridView1;
    }
}