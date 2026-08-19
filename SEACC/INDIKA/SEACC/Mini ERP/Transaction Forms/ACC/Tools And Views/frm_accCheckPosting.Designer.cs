namespace Digiteq.Transaction_Forms.ACC.Tools_And_Views
{
    partial class frm_accCheckPosting
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
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnCRN = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.txtDetail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Location = new System.Drawing.Point(436, 0);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(9, 35);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(85, 35);
            this.btnInvoice.TabIndex = 4;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnCRN
            // 
            this.btnCRN.Location = new System.Drawing.Point(9, 76);
            this.btnCRN.Name = "btnCRN";
            this.btnCRN.Size = new System.Drawing.Size(85, 36);
            this.btnCRN.TabIndex = 5;
            this.btnCRN.Text = "Credit Note";
            this.btnCRN.UseVisualStyleBackColor = true;
            this.btnCRN.Click += new System.EventHandler(this.btnCRN_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(9, 144);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.Size = new System.Drawing.Size(501, 150);
            this.dgvDetail.TabIndex = 56;
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(267, 37);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(243, 85);
            this.txtDetail.TabIndex = 59;
            // 
            // frm_accCheckPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 320);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnCRN);
            this.Controls.Add(this.btnInvoice);
            this.Name = "frm_accCheckPosting";
            this.Text = "frm_accCheckPosting";
            this.Controls.SetChildIndex(this.btnInvoice, 0);
            this.Controls.SetChildIndex(this.btnCRN, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.txtDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnCRN;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.TextBox txtDetail;
    }
}