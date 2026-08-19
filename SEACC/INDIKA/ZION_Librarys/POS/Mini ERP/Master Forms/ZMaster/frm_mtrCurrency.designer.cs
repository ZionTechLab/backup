namespace Digiteq
{
    partial class frm_mtrCurrency
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpCurrencyMasValiFrom = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBuyingRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrencyName = new System.Windows.Forms.TextBox();
            this.txtCurrencyID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrencyRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrencyCode = new System.Windows.Forms.TextBox();
            this.lblStoreID = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.currencyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.currencyMaster = new System.Windows.Forms.TabPage();
            this.CurrencyHistory = new System.Windows.Forms.TabPage();
            this.dgvDetailHistory = new System.Windows.Forms.DataGridView();
            this.ValidateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidateTill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.currencyMaster.SuspendLayout();
            this.CurrencyHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpCurrencyMasValiFrom);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtBuyingRate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCurrencyName);
            this.panel1.Controls.Add(this.txtCurrencyID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCurrencyRate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCurrencyCode);
            this.panel1.Controls.Add(this.lblStoreID);
            this.panel1.Controls.Add(this.lblBankName);
            this.panel1.Location = new System.Drawing.Point(6, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 93);
            this.panel1.TabIndex = 0;
            // 
            // dtpCurrencyMasValiFrom
            // 
            this.dtpCurrencyMasValiFrom.Enabled = false;
            this.dtpCurrencyMasValiFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCurrencyMasValiFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCurrencyMasValiFrom.Location = new System.Drawing.Point(95, 58);
            this.dtpCurrencyMasValiFrom.Name = "dtpCurrencyMasValiFrom";
            this.dtpCurrencyMasValiFrom.Size = new System.Drawing.Size(140, 22);
            this.dtpCurrencyMasValiFrom.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label19.Location = new System.Drawing.Point(6, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 14);
            this.label19.TabIndex = 11;
            this.label19.Text = "Valid From";
            // 
            // txtBuyingRate
            // 
            this.txtBuyingRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuyingRate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyingRate.Location = new System.Drawing.Point(334, 61);
            this.txtBuyingRate.Name = "txtBuyingRate";
            this.txtBuyingRate.Size = new System.Drawing.Size(127, 22);
            this.txtBuyingRate.TabIndex = 9;
            this.txtBuyingRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuyingRate_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(252, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Buying Rate";
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrencyName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyName.Location = new System.Drawing.Point(95, 32);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(140, 22);
            this.txtCurrencyName.TabIndex = 3;
            // 
            // txtCurrencyID
            // 
            this.txtCurrencyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCurrencyID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyID.Location = new System.Drawing.Point(95, 6);
            this.txtCurrencyID.Name = "txtCurrencyID";
            this.txtCurrencyID.Size = new System.Drawing.Size(140, 22);
            this.txtCurrencyID.TabIndex = 1;
            this.txtCurrencyID.DoubleClick += new System.EventHandler(this.txtCurrencyID_DoubleClick);
            this.txtCurrencyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrencyID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(249, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Currency Rate";
            // 
            // txtCurrencyRate
            // 
            this.txtCurrencyRate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyRate.Location = new System.Drawing.Point(334, 34);
            this.txtCurrencyRate.Name = "txtCurrencyRate";
            this.txtCurrencyRate.Size = new System.Drawing.Size(126, 22);
            this.txtCurrencyRate.TabIndex = 7;
            this.txtCurrencyRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrencyRate_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(249, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Currency Code";
            // 
            // txtCurrencyCode
            // 
            this.txtCurrencyCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyCode.Location = new System.Drawing.Point(334, 2);
            this.txtCurrencyCode.Name = "txtCurrencyCode";
            this.txtCurrencyCode.Size = new System.Drawing.Size(126, 22);
            this.txtCurrencyCode.TabIndex = 5;
            // 
            // lblStoreID
            // 
            this.lblStoreID.AutoSize = true;
            this.lblStoreID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStoreID.Location = new System.Drawing.Point(4, 10);
            this.lblStoreID.Name = "lblStoreID";
            this.lblStoreID.Size = new System.Drawing.Size(64, 14);
            this.lblStoreID.TabIndex = 0;
            this.lblStoreID.Text = "Currency ID";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(4, 36);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(83, 14);
            this.lblBankName.TabIndex = 2;
            this.lblBankName.Text = "Currency Name";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(323, 132);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.currencyID,
            this.currencyName,
            this.CurrencyCode,
            this.CurrencyRate});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(466, 251);
            this.dgvDetail.TabIndex = 4;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // currencyID
            // 
            this.currencyID.HeaderText = "Currency ID";
            this.currencyID.Name = "currencyID";
            this.currencyID.Width = 88;
            // 
            // currencyName
            // 
            this.currencyName.HeaderText = "Currency Name";
            this.currencyName.Name = "currencyName";
            this.currencyName.Width = 145;
            // 
            // CurrencyCode
            // 
            this.CurrencyCode.HeaderText = "Currency Code";
            this.CurrencyCode.Name = "CurrencyCode";
            this.CurrencyCode.Width = 120;
            // 
            // CurrencyRate
            // 
            this.CurrencyRate.HeaderText = "Currency Rate";
            this.CurrencyRate.Name = "CurrencyRate";
            this.CurrencyRate.Width = 120;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(246, 132);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(400, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.currencyMaster);
            this.tabControl1.Controls.Add(this.CurrencyHistory);
            this.tabControl1.Location = new System.Drawing.Point(6, 163);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(470, 277);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // currencyMaster
            // 
            this.currencyMaster.Controls.Add(this.dgvDetail);
            this.currencyMaster.Location = new System.Drawing.Point(4, 22);
            this.currencyMaster.Name = "currencyMaster";
            this.currencyMaster.Padding = new System.Windows.Forms.Padding(3);
            this.currencyMaster.Size = new System.Drawing.Size(462, 251);
            this.currencyMaster.TabIndex = 0;
            this.currencyMaster.Text = "Currency Master";
            this.currencyMaster.UseVisualStyleBackColor = true;
            // 
            // CurrencyHistory
            // 
            this.CurrencyHistory.Controls.Add(this.dgvDetailHistory);
            this.CurrencyHistory.Location = new System.Drawing.Point(4, 22);
            this.CurrencyHistory.Name = "CurrencyHistory";
            this.CurrencyHistory.Padding = new System.Windows.Forms.Padding(3);
            this.CurrencyHistory.Size = new System.Drawing.Size(462, 251);
            this.CurrencyHistory.TabIndex = 1;
            this.CurrencyHistory.Text = "Currency History";
            this.CurrencyHistory.UseVisualStyleBackColor = true;
            // 
            // dgvDetailHistory
            // 
            this.dgvDetailHistory.AllowUserToAddRows = false;
            this.dgvDetailHistory.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetailHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetailHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetailHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValidateFrom,
            this.ValidateTill,
            this.CRate,
            this.ModifiedUser});
            this.dgvDetailHistory.EnableHeadersVisualStyles = false;
            this.dgvDetailHistory.Location = new System.Drawing.Point(-4, 0);
            this.dgvDetailHistory.MultiSelect = false;
            this.dgvDetailHistory.Name = "dgvDetailHistory";
            this.dgvDetailHistory.RowHeadersVisible = false;
            this.dgvDetailHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetailHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailHistory.Size = new System.Drawing.Size(468, 251);
            this.dgvDetailHistory.TabIndex = 5;
            // 
            // ValidateFrom
            // 
            this.ValidateFrom.HeaderText = "Validate From";
            this.ValidateFrom.Name = "ValidateFrom";
            this.ValidateFrom.Width = 88;
            // 
            // ValidateTill
            // 
            this.ValidateTill.HeaderText = "Validate Till";
            this.ValidateTill.Name = "ValidateTill";
            this.ValidateTill.Width = 145;
            // 
            // CRate
            // 
            this.CRate.HeaderText = "Currency Rate";
            this.CRate.Name = "CRate";
            this.CRate.Width = 120;
            // 
            // ModifiedUser
            // 
            this.ModifiedUser.HeaderText = "Modified User";
            this.ModifiedUser.Name = "ModifiedUser";
            this.ModifiedUser.Width = 120;
            // 
            // frm_mtrCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(482, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.MinimizeBox = false;
            this.Name = "frm_mtrCurrency";
            this.Text = "Currency Master";
            this.Load += new System.EventHandler(this.frm_mtrCurrency_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrCurrency_KeyDown);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.currencyMaster.ResumeLayout(false);
            this.CurrencyHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.TextBox txtCurrencyID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrencyRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrencyCode;
        private System.Windows.Forms.Label lblStoreID;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyRate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage currencyMaster;
        private System.Windows.Forms.TabPage CurrencyHistory;
        private System.Windows.Forms.DataGridView dgvDetailHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidateTill;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedUser;
        private System.Windows.Forms.TextBox txtBuyingRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCurrencyMasValiFrom;
        private System.Windows.Forms.Label label19;
    }
}