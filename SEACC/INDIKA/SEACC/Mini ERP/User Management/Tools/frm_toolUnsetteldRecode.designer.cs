namespace Digiteq
{
    partial class frm_toolUnsetteldRecode
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
            this.rdoDebit = new System.Windows.Forms.RadioButton();
            this.rdoCreditNote = new System.Windows.Forms.RadioButton();
            this.rdoCheque = new System.Windows.Forms.RadioButton();
            this.rdoReceipt = new System.Windows.Forms.RadioButton();
            this.rdoInvoice = new System.Windows.Forms.RadioButton();
            this.txtRecodeID = new System.Windows.Forms.TextBox();
            this.lblWip = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rdoReceipt_All = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoReceipt_All);
            this.groupBox1.Controls.Add(this.rdoDebit);
            this.groupBox1.Controls.Add(this.rdoCreditNote);
            this.groupBox1.Controls.Add(this.rdoCheque);
            this.groupBox1.Controls.Add(this.rdoReceipt);
            this.groupBox1.Controls.Add(this.rdoInvoice);
            this.groupBox1.Location = new System.Drawing.Point(7, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdoDebit
            // 
            this.rdoDebit.AutoSize = true;
            this.rdoDebit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDebit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDebit.Location = new System.Drawing.Point(11, 67);
            this.rdoDebit.Name = "rdoDebit";
            this.rdoDebit.Size = new System.Drawing.Size(91, 18);
            this.rdoDebit.TabIndex = 8;
            this.rdoDebit.TabStop = true;
            this.rdoDebit.Text = "Debit Recode";
            this.rdoDebit.UseVisualStyleBackColor = true;
            // 
            // rdoCreditNote
            // 
            this.rdoCreditNote.AutoSize = true;
            this.rdoCreditNote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCreditNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCreditNote.Location = new System.Drawing.Point(11, 43);
            this.rdoCreditNote.Name = "rdoCreditNote";
            this.rdoCreditNote.Size = new System.Drawing.Size(120, 18);
            this.rdoCreditNote.TabIndex = 8;
            this.rdoCreditNote.TabStop = true;
            this.rdoCreditNote.Text = "Credit Note Recode";
            this.rdoCreditNote.UseVisualStyleBackColor = true;
            // 
            // rdoCheque
            // 
            this.rdoCheque.AutoSize = true;
            this.rdoCheque.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCheque.Location = new System.Drawing.Point(146, 19);
            this.rdoCheque.Name = "rdoCheque";
            this.rdoCheque.Size = new System.Drawing.Size(105, 18);
            this.rdoCheque.TabIndex = 8;
            this.rdoCheque.TabStop = true;
            this.rdoCheque.Text = "Cheques Recode";
            this.rdoCheque.UseVisualStyleBackColor = true;
            // 
            // rdoReceipt
            // 
            this.rdoReceipt.AutoSize = true;
            this.rdoReceipt.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReceipt.Location = new System.Drawing.Point(146, 43);
            this.rdoReceipt.Name = "rdoReceipt";
            this.rdoReceipt.Size = new System.Drawing.Size(119, 18);
            this.rdoReceipt.TabIndex = 8;
            this.rdoReceipt.TabStop = true;
            this.rdoReceipt.Text = "Reciepts Only Cash";
            this.rdoReceipt.UseVisualStyleBackColor = true;
            // 
            // rdoInvoice
            // 
            this.rdoInvoice.AutoSize = true;
            this.rdoInvoice.Checked = true;
            this.rdoInvoice.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoInvoice.Location = new System.Drawing.Point(11, 19);
            this.rdoInvoice.Name = "rdoInvoice";
            this.rdoInvoice.Size = new System.Drawing.Size(99, 18);
            this.rdoInvoice.TabIndex = 8;
            this.rdoInvoice.TabStop = true;
            this.rdoInvoice.Text = "Invoice Recode";
            this.rdoInvoice.UseVisualStyleBackColor = true;
            // 
            // txtRecodeID
            // 
            this.txtRecodeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRecodeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecodeID.Location = new System.Drawing.Point(109, 17);
            this.txtRecodeID.Name = "txtRecodeID";
            this.txtRecodeID.Size = new System.Drawing.Size(140, 22);
            this.txtRecodeID.TabIndex = 10;
            this.txtRecodeID.DoubleClick += new System.EventHandler(this.txtRecodeID_DoubleClick);
            this.txtRecodeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecodeID_KeyDown);
            // 
            // lblWip
            // 
            this.lblWip.AutoSize = true;
            this.lblWip.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWip.Location = new System.Drawing.Point(39, 21);
            this.lblWip.Name = "lblWip";
            this.lblWip.Size = new System.Drawing.Size(70, 14);
            this.lblWip.TabIndex = 9;
            this.lblWip.Text = "Recode Code";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(222, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "  Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLogon
            // 
            this.btnLogon.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogon.Image = global::Digiteq.Properties.Resources.accept;
            this.btnLogon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogon.Location = new System.Drawing.Point(77, 44);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(142, 25);
            this.btnLogon.TabIndex = 6;
            this.btnLogon.Text = "Remove Settlement";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recode Unsettle Form";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 47);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.txtRecodeID);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnLogon);
            this.groupBox3.Controls.Add(this.lblWip);
            this.groupBox3.Location = new System.Drawing.Point(8, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 78);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.accept;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(9, 44);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 25);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rdoReceipt_All
            // 
            this.rdoReceipt_All.AutoSize = true;
            this.rdoReceipt_All.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReceipt_All.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReceipt_All.Location = new System.Drawing.Point(146, 67);
            this.rdoReceipt_All.Name = "rdoReceipt_All";
            this.rdoReceipt_All.Size = new System.Drawing.Size(146, 18);
            this.rdoReceipt_All.TabIndex = 9;
            this.rdoReceipt_All.TabStop = true;
            this.rdoReceipt_All.Text = "Reciepts Cash + Cheques";
            this.rdoReceipt_All.UseVisualStyleBackColor = true;
            // 
            // frm_toolUnsetteldRecode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(197)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(314, 241);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frm_toolUnsetteldRecode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmQuickLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoReceipt;
        private System.Windows.Forms.RadioButton rdoInvoice;
        private System.Windows.Forms.TextBox txtRecodeID;
        private System.Windows.Forms.Label lblWip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoDebit;
        private System.Windows.Forms.RadioButton rdoCreditNote;
        private System.Windows.Forms.RadioButton rdoCheque;
        private System.Windows.Forms.RadioButton rdoReceipt_All;
    }
}