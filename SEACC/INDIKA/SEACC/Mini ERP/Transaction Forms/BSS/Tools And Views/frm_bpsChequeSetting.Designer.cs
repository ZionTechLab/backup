namespace Digiteq
{
    partial class frm_bpsChequeSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new SEACC_DataGrid();
            this.clmBankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnElementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnXValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnYValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFontType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIsPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnGetDefault = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.PntDocCheque = new System.Drawing.Printing.PrintDocument();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBankName);
            this.panel1.Controls.Add(this.lblBank);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 33);
            this.panel1.TabIndex = 0;
            // 
            // txtBankName
            // 
            this.txtBankName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtBankName.BackColor = System.Drawing.Color.LightGray;
            this.txtBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankName.Location = new System.Drawing.Point(43, 5);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.ReadOnly = true;
            this.txtBankName.Size = new System.Drawing.Size(184, 22);
            this.txtBankName.TabIndex = 1;
            this.txtBankName.DoubleClick += new System.EventHandler(this.txtBankName_DoubleClick);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBank.Location = new System.Drawing.Point(7, 9);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(32, 14);
            this.lblBank.TabIndex = 2;
            this.lblBank.Text = "Bank";
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.ForeColor = System.Drawing.Color.Maroon;
            this.btnCopy.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(522, 147);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 25);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Location = new System.Drawing.Point(5, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 464);
            this.panel2.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmBankID,
            this.clnElementID,
            this.clnAccountNo,
            this.clnElementName,
            this.clnXValue,
            this.clnYValue,
            this.clnFontType,
            this.clnLength,
            this.clnIsPrint,
            this.clnGetDefault});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvData.RowHeadersWidth = 10;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.Size = new System.Drawing.Size(507, 464);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // clmBankID
            // 
            this.clmBankID.DataPropertyName = "BankID";
            this.clmBankID.HeaderText = "BankID";
            this.clmBankID.Name = "clmBankID";
            this.clmBankID.ReadOnly = true;
            this.clmBankID.Visible = false;
            // 
            // clnElementID
            // 
            this.clnElementID.DataPropertyName = "ElementID";
            this.clnElementID.HeaderText = "ElementID";
            this.clnElementID.Name = "clnElementID";
            this.clnElementID.ReadOnly = true;
            this.clnElementID.Visible = false;
            // 
            // clnAccountNo
            // 
            this.clnAccountNo.DataPropertyName = "AccountNo";
            this.clnAccountNo.HeaderText = "AccountNo";
            this.clnAccountNo.Name = "clnAccountNo";
            this.clnAccountNo.ReadOnly = true;
            this.clnAccountNo.Visible = false;
            // 
            // clnElementName
            // 
            this.clnElementName.DataPropertyName = "ElementDiscription";
            this.clnElementName.HeaderText = "Element";
            this.clnElementName.Name = "clnElementName";
            this.clnElementName.ReadOnly = true;
            this.clnElementName.Width = 250;
            // 
            // clnXValue
            // 
            this.clnXValue.DataPropertyName = "XValue";
            this.clnXValue.HeaderText = "X";
            this.clnXValue.Name = "clnXValue";
            this.clnXValue.Width = 40;
            // 
            // clnYValue
            // 
            this.clnYValue.DataPropertyName = "YValue";
            this.clnYValue.HeaderText = "Y";
            this.clnYValue.Name = "clnYValue";
            this.clnYValue.Width = 40;
            // 
            // clnFontType
            // 
            this.clnFontType.DataPropertyName = "FontType";
            this.clnFontType.HeaderText = "Font";
            this.clnFontType.Name = "clnFontType";
            this.clnFontType.Width = 80;
            // 
            // clnLength
            // 
            this.clnLength.DataPropertyName = "Length";
            this.clnLength.HeaderText = "Length";
            this.clnLength.Name = "clnLength";
            this.clnLength.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnLength.Visible = false;
            this.clnLength.Width = 40;
            // 
            // clnIsPrint
            // 
            this.clnIsPrint.DataPropertyName = "IsPrint";
            this.clnIsPrint.HeaderText = "Print";
            this.clnIsPrint.Name = "clnIsPrint";
            this.clnIsPrint.Width = 40;
            // 
            // clnGetDefault
            // 
            this.clnGetDefault.HeaderText = ".";
            this.clnGetDefault.Name = "clnGetDefault";
            this.clnGetDefault.Width = 20;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(522, 116);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(522, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(522, 54);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // PntDocCheque
            // 
            this.PntDocCheque.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PntDocCheque_PrintPage);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 522);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 13;
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.ForeColor = System.Drawing.Color.Green;
            this.lblStatus2.Location = new System.Drawing.Point(255, 21);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(0, 13);
            this.lblStatus2.TabIndex = 14;
            // 
            // frm_bpsChequeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(606, 542);
            this.Controls.Add(this.lblStatus2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_bpsChequeSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cheque Setting";
            this.Load += new System.EventHandler(this.frm_bpsChequeSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private SEACC_DataGrid dgvData;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnElementID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnXValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnYValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnFontType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLength;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnIsPrint;
        private System.Windows.Forms.DataGridViewButtonColumn clnGetDefault;
        private System.Drawing.Printing.PrintDocument PntDocCheque;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatus2;
    }
}