namespace Digiteq
{
    partial class frm_rpt_ChequeStanded_APL
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
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.rdoChequeToBeDeposited = new System.Windows.Forms.RadioButton();
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoChequesInHandPendingApproval = new System.Windows.Forms.RadioButton();
            this.rdoChequesInHandApprovedForDeposite = new System.Windows.Forms.RadioButton();
            this.rdoReturnedChequesInHand = new System.Windows.Forms.RadioButton();
            this.rdoReturnCheques = new System.Windows.Forms.RadioButton();
            this.rdoRealizedCheques = new System.Windows.Forms.RadioButton();
            this.rdoChequesInHandAll = new System.Windows.Forms.RadioButton();
            this.z1 = new System.Windows.Forms.Panel();
            this.txtSalesRep = new System.Windows.Forms.TextBox();
            this.lblSalseRep = new System.Windows.Forms.Label();
            this.z2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.zpanel1 = new System.Windows.Forms.Panel();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoActual = new System.Windows.Forms.RadioButton();
            this.rdoDeleted = new System.Windows.Forms.RadioButton();
            this.x1.SuspendLayout();
            this.z1.SuspendLayout();
            this.z2.SuspendLayout();
            this.zpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBank
            // 
            this.txtBank.BackColor = System.Drawing.Color.LightGray;
            this.txtBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(110, 35);
            this.txtBank.Name = "txtBank";
            this.txtBank.ReadOnly = true;
            this.txtBank.Size = new System.Drawing.Size(342, 22);
            this.txtBank.TabIndex = 1;
            this.txtBank.DoubleClick += new System.EventHandler(this.txtBank_DoubleClick);
            this.txtBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBank_KeyDown);
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.LightGray;
            this.txtCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(110, 9);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(342, 22);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClick);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBank.Location = new System.Drawing.Point(10, 38);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(65, 14);
            this.lblBank.TabIndex = 11;
            this.lblBank.Text = "Bank Name";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(10, 12);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(87, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFrom.Location = new System.Drawing.Point(10, 12);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(73, 14);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "Period From :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(110, 8);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTo.Location = new System.Drawing.Point(279, 12);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(58, 14);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "Period To :";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(357, 8);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // rdoChequeToBeDeposited
            // 
            this.rdoChequeToBeDeposited.AutoSize = true;
            this.rdoChequeToBeDeposited.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoChequeToBeDeposited.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoChequeToBeDeposited.Location = new System.Drawing.Point(13, 9);
            this.rdoChequeToBeDeposited.Name = "rdoChequeToBeDeposited";
            this.rdoChequeToBeDeposited.Size = new System.Drawing.Size(144, 18);
            this.rdoChequeToBeDeposited.TabIndex = 0;
            this.rdoChequeToBeDeposited.TabStop = true;
            this.rdoChequeToBeDeposited.Text = "Pending Cheque Deposit";
            this.rdoChequeToBeDeposited.UseVisualStyleBackColor = true;
            this.rdoChequeToBeDeposited.CheckedChanged += new System.EventHandler(this.rdoChequeToBeDeposited_CheckedChanged);
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoReturnedChequesInHand);
            this.x1.Controls.Add(this.rdoReturnCheques);
            this.x1.Controls.Add(this.rdoRealizedCheques);
            this.x1.Controls.Add(this.rdoChequeToBeDeposited);
            this.x1.Location = new System.Drawing.Point(9, 10);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(484, 68);
            this.x1.TabIndex = 5;
            // 
            // rdoChequesInHandPendingApproval
            // 
            this.rdoChequesInHandPendingApproval.AutoSize = true;
            this.rdoChequesInHandPendingApproval.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoChequesInHandPendingApproval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoChequesInHandPendingApproval.Location = new System.Drawing.Point(250, 33);
            this.rdoChequesInHandPendingApproval.Name = "rdoChequesInHandPendingApproval";
            this.rdoChequesInHandPendingApproval.Size = new System.Drawing.Size(204, 18);
            this.rdoChequesInHandPendingApproval.TabIndex = 12;
            this.rdoChequesInHandPendingApproval.TabStop = true;
            this.rdoChequesInHandPendingApproval.Text = "Cheques in Hand (Pending Approval)";
            this.rdoChequesInHandPendingApproval.UseVisualStyleBackColor = true;
            // 
            // rdoChequesInHandApprovedForDeposite
            // 
            this.rdoChequesInHandApprovedForDeposite.AutoSize = true;
            this.rdoChequesInHandApprovedForDeposite.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoChequesInHandApprovedForDeposite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoChequesInHandApprovedForDeposite.Location = new System.Drawing.Point(250, 45);
            this.rdoChequesInHandApprovedForDeposite.Name = "rdoChequesInHandApprovedForDeposite";
            this.rdoChequesInHandApprovedForDeposite.Size = new System.Drawing.Size(225, 18);
            this.rdoChequesInHandApprovedForDeposite.TabIndex = 11;
            this.rdoChequesInHandApprovedForDeposite.TabStop = true;
            this.rdoChequesInHandApprovedForDeposite.Text = "Cheques in Hand (Approved For Deposit)";
            this.rdoChequesInHandApprovedForDeposite.UseVisualStyleBackColor = true;
            // 
            // rdoReturnedChequesInHand
            // 
            this.rdoReturnedChequesInHand.AutoSize = true;
            this.rdoReturnedChequesInHand.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReturnedChequesInHand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReturnedChequesInHand.Location = new System.Drawing.Point(273, 38);
            this.rdoReturnedChequesInHand.Name = "rdoReturnedChequesInHand";
            this.rdoReturnedChequesInHand.Size = new System.Drawing.Size(155, 18);
            this.rdoReturnedChequesInHand.TabIndex = 10;
            this.rdoReturnedChequesInHand.TabStop = true;
            this.rdoReturnedChequesInHand.Text = "Returned Cheques in Hand";
            this.rdoReturnedChequesInHand.UseVisualStyleBackColor = true;
            this.rdoReturnedChequesInHand.CheckedChanged += new System.EventHandler(this.rdoReturnCheques_CheckedChanged);
            // 
            // rdoReturnCheques
            // 
            this.rdoReturnCheques.AutoSize = true;
            this.rdoReturnCheques.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReturnCheques.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoReturnCheques.Location = new System.Drawing.Point(273, 9);
            this.rdoReturnCheques.Name = "rdoReturnCheques";
            this.rdoReturnCheques.Size = new System.Drawing.Size(179, 18);
            this.rdoReturnCheques.TabIndex = 10;
            this.rdoReturnCheques.TabStop = true;
            this.rdoReturnCheques.Text = "Returned Cheques (Bank-Wise)";
            this.rdoReturnCheques.UseVisualStyleBackColor = true;
            this.rdoReturnCheques.CheckedChanged += new System.EventHandler(this.rdoReturnCheques_CheckedChanged);
            // 
            // rdoRealizedCheques
            // 
            this.rdoRealizedCheques.AutoSize = true;
            this.rdoRealizedCheques.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRealizedCheques.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoRealizedCheques.Location = new System.Drawing.Point(13, 38);
            this.rdoRealizedCheques.Name = "rdoRealizedCheques";
            this.rdoRealizedCheques.Size = new System.Drawing.Size(111, 18);
            this.rdoRealizedCheques.TabIndex = 9;
            this.rdoRealizedCheques.TabStop = true;
            this.rdoRealizedCheques.Text = "Realized Cheques";
            this.rdoRealizedCheques.UseVisualStyleBackColor = true;
            this.rdoRealizedCheques.CheckedChanged += new System.EventHandler(this.rdoRealizedCheques_CheckedChanged);
            // 
            // rdoChequesInHandAll
            // 
            this.rdoChequesInHandAll.AutoSize = true;
            this.rdoChequesInHandAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoChequesInHandAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoChequesInHandAll.Location = new System.Drawing.Point(250, 16);
            this.rdoChequesInHandAll.Name = "rdoChequesInHandAll";
            this.rdoChequesInHandAll.Size = new System.Drawing.Size(131, 18);
            this.rdoChequesInHandAll.TabIndex = 8;
            this.rdoChequesInHandAll.TabStop = true;
            this.rdoChequesInHandAll.Text = "Cheques in Hand (All)";
            this.rdoChequesInHandAll.UseVisualStyleBackColor = true;
            this.rdoChequesInHandAll.CheckedChanged += new System.EventHandler(this.rdoChequeInHand_CheckedChanged);
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.txtSalesRep);
            this.z1.Controls.Add(this.lblSalseRep);
            this.z1.Controls.Add(this.txtCustomer);
            this.z1.Controls.Add(this.lblCustomer);
            this.z1.Controls.Add(this.txtBank);
            this.z1.Controls.Add(this.lblBank);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z1.Location = new System.Drawing.Point(9, 85);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(484, 92);
            this.z1.TabIndex = 6;
            // 
            // txtSalesRep
            // 
            this.txtSalesRep.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRep.Location = new System.Drawing.Point(110, 60);
            this.txtSalesRep.Name = "txtSalesRep";
            this.txtSalesRep.ReadOnly = true;
            this.txtSalesRep.Size = new System.Drawing.Size(342, 22);
            this.txtSalesRep.TabIndex = 461;
            this.txtSalesRep.DoubleClick += new System.EventHandler(this.txtSalesRep_DoubleClick);
            // 
            // lblSalseRep
            // 
            this.lblSalseRep.AutoSize = true;
            this.lblSalseRep.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalseRep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSalseRep.Location = new System.Drawing.Point(10, 63);
            this.lblSalseRep.Name = "lblSalseRep";
            this.lblSalseRep.Size = new System.Drawing.Size(88, 14);
            this.lblSalseRep.TabIndex = 462;
            this.lblSalseRep.Text = "Salesman Name";
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z2.Controls.Add(this.lblFrom);
            this.z2.Controls.Add(this.dtpFrom);
            this.z2.Controls.Add(this.dtpTo);
            this.z2.Controls.Add(this.lblTo);
            this.z2.Location = new System.Drawing.Point(9, 184);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(484, 39);
            this.z2.TabIndex = 38;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(418, 273);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 475;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(340, 274);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // zpanel1
            // 
            this.zpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.zpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel1.Controls.Add(this.rdoAll);
            this.zpanel1.Controls.Add(this.rdoActual);
            this.zpanel1.Controls.Add(this.rdoDeleted);
            this.zpanel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zpanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.zpanel1.Location = new System.Drawing.Point(9, 229);
            this.zpanel1.Name = "zpanel1";
            this.zpanel1.Size = new System.Drawing.Size(484, 38);
            this.zpanel1.TabIndex = 477;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoAll.Location = new System.Drawing.Point(372, 8);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(80, 18);
            this.rdoAll.TabIndex = 11;
            this.rdoAll.Text = "All Records";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoActual
            // 
            this.rdoActual.AutoSize = true;
            this.rdoActual.Checked = true;
            this.rdoActual.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoActual.Location = new System.Drawing.Point(196, 8);
            this.rdoActual.Name = "rdoActual";
            this.rdoActual.Size = new System.Drawing.Size(124, 18);
            this.rdoActual.TabIndex = 10;
            this.rdoActual.TabStop = true;
            this.rdoActual.Text = "Active Records Only";
            this.rdoActual.UseVisualStyleBackColor = true;
            // 
            // rdoDeleted
            // 
            this.rdoDeleted.AutoSize = true;
            this.rdoDeleted.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDeleted.Location = new System.Drawing.Point(13, 8);
            this.rdoDeleted.Name = "rdoDeleted";
            this.rdoDeleted.Size = new System.Drawing.Size(132, 18);
            this.rdoDeleted.TabIndex = 9;
            this.rdoDeleted.Text = "Deleted Records Only";
            this.rdoDeleted.UseVisualStyleBackColor = true;
            // 
            // frm_rpt_ChequeStanded_APL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(502, 304);
            this.Controls.Add(this.zpanel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.rdoChequesInHandPendingApproval);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rdoChequesInHandApprovedForDeposite);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.rdoChequesInHandAll);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_ChequeStanded_APL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Standed Reports";
            this.Load += new System.EventHandler(this.frm_rpt_ChequeStanded_APL_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.z2.ResumeLayout(false);
            this.z2.PerformLayout();
            this.zpanel1.ResumeLayout(false);
            this.zpanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.RadioButton rdoChequeToBeDeposited;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoChequesInHandAll;
        private System.Windows.Forms.Panel zpanel1;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoActual;
        private System.Windows.Forms.RadioButton rdoDeleted;
        private System.Windows.Forms.RadioButton rdoReturnCheques;
        private System.Windows.Forms.RadioButton rdoRealizedCheques;
        private System.Windows.Forms.RadioButton rdoChequesInHandApprovedForDeposite;
        private System.Windows.Forms.RadioButton rdoChequesInHandPendingApproval;
        private System.Windows.Forms.RadioButton rdoReturnedChequesInHand;
        private System.Windows.Forms.TextBox txtSalesRep;
        private System.Windows.Forms.Label lblSalseRep;
    }
}