namespace Express
{
    partial class ExchangeRates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.extRateTypes = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currList = new System.Windows.Forms.ComboBox();
            this.currCode = new System.Windows.Forms.TextBox();
            this.baseCurrDesc = new System.Windows.Forms.TextBox();
            this.baseCurrCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.extRateList = new System.Windows.Forms.DataGridView();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EffectivDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExgRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.remarks = new System.Windows.Forms.TextBox();
            this.extRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.effectDate = new System.Windows.Forms.DateTimePicker();
            this.rateBackworks = new System.ComponentModel.BackgroundWorker();
            this.dataManipulate1 = new Express.UI.Common.CustomControl.DataManipulate();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extRateList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exchange Rate Types :";
            // 
            // extRateTypes
            // 
            this.extRateTypes.DisplayMember = "ExgRatTarifN";
            this.extRateTypes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extRateTypes.FormattingEnabled = true;
            this.extRateTypes.Location = new System.Drawing.Point(131, 19);
            this.extRateTypes.Name = "extRateTypes";
            this.extRateTypes.Size = new System.Drawing.Size(324, 21);
            this.extRateTypes.TabIndex = 1;
            this.extRateTypes.ValueMember = "ExgRatTarif";
            this.extRateTypes.SelectedValueChanged += new System.EventHandler(this.extRateTypes_SelectedValueChanged);
            this.extRateTypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.extRateTypes_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.currList);
            this.groupBox1.Controls.Add(this.currCode);
            this.groupBox1.Controls.Add(this.baseCurrDesc);
            this.groupBox1.Controls.Add(this.baseCurrCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.extRateTypes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 94);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exchange Rate";
            // 
            // currList
            // 
            this.currList.DisplayMember = "CurrencyN";
            this.currList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currList.FormattingEnabled = true;
            this.currList.Location = new System.Drawing.Point(180, 65);
            this.currList.Name = "currList";
            this.currList.Size = new System.Drawing.Size(275, 21);
            this.currList.TabIndex = 7;
            this.currList.ValueMember = "Currency";
            this.currList.SelectedIndexChanged += new System.EventHandler(this.currList_SelectedIndexChanged);
            this.currList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currList_KeyDown);
            // 
            // currCode
            // 
            this.currCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currCode.Location = new System.Drawing.Point(131, 64);
            this.currCode.MaxLength = 3;
            this.currCode.Name = "currCode";
            this.currCode.Size = new System.Drawing.Size(46, 22);
            this.currCode.TabIndex = 6;
            this.currCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.currCode_KeyPress);
            // 
            // baseCurrDesc
            // 
            this.baseCurrDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseCurrDesc.Location = new System.Drawing.Point(180, 41);
            this.baseCurrDesc.Name = "baseCurrDesc";
            this.baseCurrDesc.ReadOnly = true;
            this.baseCurrDesc.Size = new System.Drawing.Size(275, 22);
            this.baseCurrDesc.TabIndex = 5;
            // 
            // baseCurrCode
            // 
            this.baseCurrCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseCurrCode.Location = new System.Drawing.Point(131, 41);
            this.baseCurrCode.Name = "baseCurrCode";
            this.baseCurrCode.ReadOnly = true;
            this.baseCurrCode.Size = new System.Drawing.Size(46, 22);
            this.baseCurrCode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Currency Code :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base Currency :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.extRateList);
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 308);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // extRateList
            // 
            this.extRateList.AllowUserToAddRows = false;
            this.extRateList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.extRateList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.extRateList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.extRateList.ColumnHeadersHeight = 20;
            this.extRateList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Currency,
            this.EffectivDate,
            this.ExgRate,
            this.Remark});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.extRateList.DefaultCellStyle = dataGridViewCellStyle3;
            this.extRateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extRateList.EnableHeadersVisualStyles = false;
            this.extRateList.Location = new System.Drawing.Point(3, 16);
            this.extRateList.Name = "extRateList";
            this.extRateList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.extRateList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.extRateList.RowHeadersWidth = 25;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extRateList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.extRateList.RowTemplate.Height = 20;
            this.extRateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.extRateList.Size = new System.Drawing.Size(644, 289);
            this.extRateList.TabIndex = 0;
            this.extRateList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.extRateList_RowStateChanged);
            // 
            // Currency
            // 
            this.Currency.DataPropertyName = "Currency";
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            this.Currency.ReadOnly = true;
            // 
            // EffectivDate
            // 
            this.EffectivDate.DataPropertyName = "EffectDate";
            this.EffectivDate.HeaderText = "Effective Date";
            this.EffectivDate.Name = "EffectivDate";
            this.EffectivDate.ReadOnly = true;
            // 
            // ExgRate
            // 
            this.ExgRate.DataPropertyName = "ExgRate";
            this.ExgRate.HeaderText = "Exchange Rate";
            this.ExgRate.Name = "ExgRate";
            this.ExgRate.ReadOnly = true;
            this.ExgRate.Width = 150;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remarks";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 250;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.remarks);
            this.groupBox3.Controls.Add(this.extRate);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.effectDate);
            this.groupBox3.Location = new System.Drawing.Point(3, 410);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(650, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New/Edit Records";
            // 
            // remarks
            // 
            this.remarks.Location = new System.Drawing.Point(113, 63);
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(531, 20);
            this.remarks.TabIndex = 5;
            // 
            // extRate
            // 
            this.extRate.Location = new System.Drawing.Point(113, 41);
            this.extRate.Name = "extRate";
            this.extRate.Size = new System.Drawing.Size(200, 20);
            this.extRate.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Remarks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Exchange Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Efective Date";
            // 
            // effectDate
            // 
            this.effectDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.effectDate.Location = new System.Drawing.Point(113, 19);
            this.effectDate.Name = "effectDate";
            this.effectDate.Size = new System.Drawing.Size(100, 20);
            this.effectDate.TabIndex = 0;
            // 
            // rateBackworks
            // 
            this.rateBackworks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.rateBackworks_DoWork);
            this.rateBackworks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.rateBackworks_RunWorkerCompleted);
            // 
            // dataManipulate1
            // 
            this.dataManipulate1.Location = new System.Drawing.Point(30, 516);
            this.dataManipulate1.Name = "dataManipulate1";
            this.dataManipulate1.Size = new System.Drawing.Size(623, 46);
            this.dataManipulate1.TabIndex = 12;
            // 
            // ExchangeRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 562);
            this.Controls.Add(this.dataManipulate1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExchangeRates";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange Rate";
            this.Load += new System.EventHandler(this.ExchangeRates_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.extRateList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox extRateTypes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox currList;
        private System.Windows.Forms.TextBox currCode;
        private System.Windows.Forms.TextBox baseCurrDesc;
        private System.Windows.Forms.TextBox baseCurrCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView extRateList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox remarks;
        private System.Windows.Forms.TextBox extRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker effectDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn EffectivDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExgRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private Express.UI.Common.CustomControl.DataManipulate dataManipulate1;
        private System.ComponentModel.BackgroundWorker rateBackworks;
    }
}

