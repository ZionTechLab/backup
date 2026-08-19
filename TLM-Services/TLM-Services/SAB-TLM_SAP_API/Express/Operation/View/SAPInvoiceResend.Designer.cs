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
            this.btnResend = new System.Windows.Forms.Button();
            this.dgvResendList = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InvCrdNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrasDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResendList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResend
            // 
            this.btnResend.Location = new System.Drawing.Point(1029, 523);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(145, 37);
            this.btnResend.TabIndex = 1;
            this.btnResend.Text = "&Resend";
            this.btnResend.UseVisualStyleBackColor = true;
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // dgvResendList
            // 
            this.dgvResendList.AllowUserToAddRows = false;
            this.dgvResendList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResendList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.InvCrdNo,
            this.TrasDate,
            this.ErrorMessage});
            this.dgvResendList.Location = new System.Drawing.Point(15, 12);
            this.dgvResendList.Name = "dgvResendList";
            this.dgvResendList.Size = new System.Drawing.Size(1159, 505);
            this.dgvResendList.TabIndex = 2;
            // 
            // Select
            // 
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Width = 50;
            // 
            // InvCrdNo
            // 
            this.InvCrdNo.HeaderText = "Invoice No/Credit No";
            this.InvCrdNo.Name = "InvCrdNo";
            this.InvCrdNo.ReadOnly = true;
            this.InvCrdNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvCrdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvCrdNo.Width = 150;
            // 
            // TrasDate
            // 
            this.TrasDate.HeaderText = "Tras Date";
            this.TrasDate.Name = "TrasDate";
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.HeaderText = "Error Message";
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ErrorMessage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ErrorMessage.Width = 750;
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Location = new System.Drawing.Point(879, 523);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(145, 37);
            this.btnUnselectAll.TabIndex = 4;
            this.btnUnselectAll.Text = "&Unselect All";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(22, 535);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 17);
            this.lblResult.TabIndex = 5;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(729, 523);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(145, 37);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "&Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // SAPInvoiceResend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 567);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.dgvResendList);
            this.Controls.Add(this.btnResend);
            this.MaximizeBox = false;
            this.Name = "SAPInvoiceResend";
            this.Text = "SAPInvoiceResend";
            this.Load += new System.EventHandler(this.SAPInvoiceResend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResendList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnResend;
        private System.Windows.Forms.DataGridView dgvResendList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvCrdNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrasDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnSelectAll;
    }
}