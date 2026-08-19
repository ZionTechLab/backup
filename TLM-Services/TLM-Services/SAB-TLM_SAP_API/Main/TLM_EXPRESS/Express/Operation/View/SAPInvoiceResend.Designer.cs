namespace Express.UI.Operation.View
{
    partial class SAPInvoiceResend
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
            this.dgvResendList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResendList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResendList
            // 
            this.dgvResendList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResendList.Location = new System.Drawing.Point(12, 12);
            this.dgvResendList.Name = "dgvResendList";
            this.dgvResendList.RowTemplate.ReadOnly = true;
            this.dgvResendList.Size = new System.Drawing.Size(791, 356);
            this.dgvResendList.TabIndex = 0;
            this.dgvResendList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResendList_CellDoubleClick);
            // 
            // SAPInvoiceResend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 380);
            this.Controls.Add(this.dgvResendList);
            this.Name = "SAPInvoiceResend";
            this.Text = "SAPInvoiceResend";
            this.Load += new System.EventHandler(this.SAPInvoiceResend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResendList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResendList;
    }
}