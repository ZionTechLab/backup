namespace Digiteq.Transaction_Forms.BSS.Tools_And_Views
{
    partial class frm_RepresentableChqUpdate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblChqNo = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtmRedepositDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.gridMain = new Digiteq.SEACC_DataGrid();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeRegister_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.route_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_Representable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks_Representable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Controls.Add(this.lblChqNo);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtmRedepositDate);
            this.panel1.Controls.Add(this.txtRemarks);
            this.panel1.Controls.Add(this.gridMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 407);
            this.panel1.TabIndex = 51;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(774, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(855, 356);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(727, 104);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(107, 13);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Date To Redeposit :";
            // 
            // lblChqNo
            // 
            this.lblChqNo.AutoSize = true;
            this.lblChqNo.Location = new System.Drawing.Point(727, 81);
            this.lblChqNo.Name = "lblChqNo";
            this.lblChqNo.Size = new System.Drawing.Size(107, 13);
            this.lblChqNo.TabIndex = 6;
            this.lblChqNo.Text = "Date To Redeposit :";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(727, 26);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(107, 13);
            this.lblCustomer.TabIndex = 6;
            this.lblCustomer.Text = "Date To Redeposit :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(673, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Amount :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Customer :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cheque No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(671, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Remarks :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date To Redeposit :";
            // 
            // dtmRedepositDate
            // 
            this.dtmRedepositDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmRedepositDate.Location = new System.Drawing.Point(730, 142);
            this.dtmRedepositDate.Name = "dtmRedepositDate";
            this.dtmRedepositDate.Size = new System.Drawing.Size(204, 22);
            this.dtmRedepositDate.TabIndex = 2;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(730, 170);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(204, 126);
            this.txtRemarks.TabIndex = 1;
            // 
            // gridMain
            // 
            this.gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerName,
            this.chequeNumber,
            this.chequeRegister_ID,
            this.dateCheque,
            this.ReturnDate,
            this.ChequeAmount,
            this.Balance,
            this.route_Code,
            this.date_Representable,
            this.Remarks_Representable});
            this.gridMain.Location = new System.Drawing.Point(11, 15);
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            this.gridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMain.Size = new System.Drawing.Size(604, 381);
            this.gridMain.TabIndex = 0;
            this.gridMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMain_CellClick);
            // 
            // customerName
            // 
            this.customerName.DataPropertyName = "customerName";
            this.customerName.HeaderText = "Customer";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            this.customerName.Width = 250;
            // 
            // chequeNumber
            // 
            this.chequeNumber.DataPropertyName = "chequeNumber";
            this.chequeNumber.HeaderText = "Cheque No";
            this.chequeNumber.Name = "chequeNumber";
            this.chequeNumber.ReadOnly = true;
            this.chequeNumber.Width = 60;
            // 
            // chequeRegister_ID
            // 
            this.chequeRegister_ID.DataPropertyName = "chequeRegister_ID";
            this.chequeRegister_ID.HeaderText = "ChqbRegister ID";
            this.chequeRegister_ID.Name = "chequeRegister_ID";
            this.chequeRegister_ID.ReadOnly = true;
            this.chequeRegister_ID.Width = 60;
            // 
            // dateCheque
            // 
            this.dateCheque.DataPropertyName = "dateCheque";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dateCheque.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateCheque.HeaderText = "Cheque Date";
            this.dateCheque.Name = "dateCheque";
            this.dateCheque.ReadOnly = true;
            this.dateCheque.Width = 60;
            // 
            // ReturnDate
            // 
            this.ReturnDate.DataPropertyName = "ReturnDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ReturnDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReturnDate.HeaderText = "Return Date";
            this.ReturnDate.Name = "ReturnDate";
            this.ReturnDate.ReadOnly = true;
            this.ReturnDate.Width = 60;
            // 
            // ChequeAmount
            // 
            this.ChequeAmount.DataPropertyName = "ChequeAmount";
            this.ChequeAmount.HeaderText = "Cheque Amount";
            this.ChequeAmount.Name = "ChequeAmount";
            this.ChequeAmount.ReadOnly = true;
            this.ChequeAmount.Width = 80;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 80;
            // 
            // route_Code
            // 
            this.route_Code.DataPropertyName = "route_Code";
            this.route_Code.HeaderText = "Route";
            this.route_Code.Name = "route_Code";
            this.route_Code.ReadOnly = true;
            this.route_Code.Width = 60;
            // 
            // date_Representable
            // 
            this.date_Representable.DataPropertyName = "date_Representable";
            this.date_Representable.HeaderText = " Representable Date";
            this.date_Representable.Name = "date_Representable";
            this.date_Representable.ReadOnly = true;
            // 
            // Remarks_Representable
            // 
            this.Remarks_Representable.DataPropertyName = "Remarks_Representable";
            this.Remarks_Representable.HeaderText = "Remarks";
            this.Remarks_Representable.Name = "Remarks_Representable";
            this.Remarks_Representable.ReadOnly = true;
            // 
            // frm_RepresentableChqUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 446);
            this.Controls.Add(this.panel1);
            this.Name = "frm_RepresentableChqUpdate";
            this.Text = "Representable Cheque Update";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SEACC_DataGrid gridMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblChqNo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtmRedepositDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeRegister_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn route_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_Representable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks_Representable;
    }
}