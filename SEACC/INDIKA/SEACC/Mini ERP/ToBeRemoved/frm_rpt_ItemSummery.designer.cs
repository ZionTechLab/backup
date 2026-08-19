namespace Digiteq
{
    partial class frm_rpt_ItemSummery
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
            this.txtRawMaterial = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.rdoRawMaterial = new System.Windows.Forms.RadioButton();
            this.rdoCombinationMaterial = new System.Windows.Forms.RadioButton();
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoFinishedGood = new System.Windows.Forms.RadioButton();
            this.rdoSemiFinishedGood = new System.Windows.Forms.RadioButton();
            this.rdoLaminationMaterial = new System.Windows.Forms.RadioButton();
            this.z1 = new System.Windows.Forms.Panel();
            this.txtSectionStoke = new System.Windows.Forms.TextBox();
            this.txtDepartmentStock = new System.Windows.Forms.TextBox();
            this.txtStoreStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.x1.SuspendLayout();
            this.z1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRawMaterial
            // 
            this.txtRawMaterial.BackColor = System.Drawing.Color.LightGray;
            this.txtRawMaterial.Enabled = false;
            this.txtRawMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRawMaterial.Location = new System.Drawing.Point(155, 4);
            this.txtRawMaterial.Name = "txtRawMaterial";
            this.txtRawMaterial.ReadOnly = true;
            this.txtRawMaterial.Size = new System.Drawing.Size(130, 22);
            this.txtRawMaterial.TabIndex = 0;
            this.txtRawMaterial.DoubleClick += new System.EventHandler(this.txtRawMaterial_DoubleClick);
            this.txtRawMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRawMaterial_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(10, 10);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Store Stock";
            // 
            // rdoRawMaterial
            // 
            this.rdoRawMaterial.AutoSize = true;
            this.rdoRawMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoRawMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoRawMaterial.Location = new System.Drawing.Point(13, 6);
            this.rdoRawMaterial.Name = "rdoRawMaterial";
            this.rdoRawMaterial.Size = new System.Drawing.Size(92, 18);
            this.rdoRawMaterial.TabIndex = 2;
            this.rdoRawMaterial.TabStop = true;
            this.rdoRawMaterial.Text = "Raw Material";
            this.rdoRawMaterial.UseVisualStyleBackColor = true;
            this.rdoRawMaterial.CheckedChanged += new System.EventHandler(this.rdoRawMaterial_CheckedChanged);
            // 
            // rdoCombinationMaterial
            // 
            this.rdoCombinationMaterial.AutoSize = true;
            this.rdoCombinationMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCombinationMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCombinationMaterial.Location = new System.Drawing.Point(13, 31);
            this.rdoCombinationMaterial.Name = "rdoCombinationMaterial";
            this.rdoCombinationMaterial.Size = new System.Drawing.Size(132, 18);
            this.rdoCombinationMaterial.TabIndex = 1;
            this.rdoCombinationMaterial.TabStop = true;
            this.rdoCombinationMaterial.Text = "Combination Material";
            this.rdoCombinationMaterial.UseVisualStyleBackColor = true;
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.txtRawMaterial);
            this.x1.Controls.Add(this.rdoFinishedGood);
            this.x1.Controls.Add(this.rdoSemiFinishedGood);
            this.x1.Controls.Add(this.rdoLaminationMaterial);
            this.x1.Controls.Add(this.rdoRawMaterial);
            this.x1.Controls.Add(this.rdoCombinationMaterial);
            this.x1.Location = new System.Drawing.Point(8, 8);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(299, 81);
            this.x1.TabIndex = 5;
            // 
            // rdoFinishedGood
            // 
            this.rdoFinishedGood.AutoSize = true;
            this.rdoFinishedGood.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFinishedGood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoFinishedGood.Location = new System.Drawing.Point(155, 56);
            this.rdoFinishedGood.Name = "rdoFinishedGood";
            this.rdoFinishedGood.Size = new System.Drawing.Size(95, 18);
            this.rdoFinishedGood.TabIndex = 5;
            this.rdoFinishedGood.TabStop = true;
            this.rdoFinishedGood.Text = "Finished Good";
            this.rdoFinishedGood.UseVisualStyleBackColor = true;
            // 
            // rdoSemiFinishedGood
            // 
            this.rdoSemiFinishedGood.AutoSize = true;
            this.rdoSemiFinishedGood.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSemiFinishedGood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSemiFinishedGood.Location = new System.Drawing.Point(13, 56);
            this.rdoSemiFinishedGood.Name = "rdoSemiFinishedGood";
            this.rdoSemiFinishedGood.Size = new System.Drawing.Size(123, 18);
            this.rdoSemiFinishedGood.TabIndex = 5;
            this.rdoSemiFinishedGood.TabStop = true;
            this.rdoSemiFinishedGood.Text = "Semi Finished Good";
            this.rdoSemiFinishedGood.UseVisualStyleBackColor = true;
            // 
            // rdoLaminationMaterial
            // 
            this.rdoLaminationMaterial.AutoSize = true;
            this.rdoLaminationMaterial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLaminationMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoLaminationMaterial.Location = new System.Drawing.Point(155, 31);
            this.rdoLaminationMaterial.Name = "rdoLaminationMaterial";
            this.rdoLaminationMaterial.Size = new System.Drawing.Size(125, 18);
            this.rdoLaminationMaterial.TabIndex = 5;
            this.rdoLaminationMaterial.TabStop = true;
            this.rdoLaminationMaterial.Text = "Lamination Material";
            this.rdoLaminationMaterial.UseVisualStyleBackColor = true;
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z1.Controls.Add(this.txtSectionStoke);
            this.z1.Controls.Add(this.txtDepartmentStock);
            this.z1.Controls.Add(this.txtStoreStock);
            this.z1.Controls.Add(this.label2);
            this.z1.Controls.Add(this.label1);
            this.z1.Controls.Add(this.lblCustomer);
            this.z1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z1.Location = new System.Drawing.Point(8, 95);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(299, 83);
            this.z1.TabIndex = 6;
            // 
            // txtSectionStoke
            // 
            this.txtSectionStoke.BackColor = System.Drawing.Color.LightGray;
            this.txtSectionStoke.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSectionStoke.Location = new System.Drawing.Point(155, 54);
            this.txtSectionStoke.Name = "txtSectionStoke";
            this.txtSectionStoke.ReadOnly = true;
            this.txtSectionStoke.Size = new System.Drawing.Size(130, 22);
            this.txtSectionStoke.TabIndex = 477;
            this.txtSectionStoke.DoubleClick += new System.EventHandler(this.txtSectionStoke_DoubleClick);
            // 
            // txtDepartmentStock
            // 
            this.txtDepartmentStock.BackColor = System.Drawing.Color.LightGray;
            this.txtDepartmentStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentStock.Location = new System.Drawing.Point(155, 30);
            this.txtDepartmentStock.Name = "txtDepartmentStock";
            this.txtDepartmentStock.ReadOnly = true;
            this.txtDepartmentStock.Size = new System.Drawing.Size(130, 22);
            this.txtDepartmentStock.TabIndex = 16;
            this.txtDepartmentStock.DoubleClick += new System.EventHandler(this.txtDepartmentStock_DoubleClick);
            // 
            // txtStoreStock
            // 
            this.txtStoreStock.BackColor = System.Drawing.Color.LightGray;
            this.txtStoreStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreStock.Location = new System.Drawing.Point(155, 6);
            this.txtStoreStock.Name = "txtStoreStock";
            this.txtStoreStock.ReadOnly = true;
            this.txtStoreStock.Size = new System.Drawing.Size(130, 22);
            this.txtStoreStock.TabIndex = 15;
            this.txtStoreStock.DoubleClick += new System.EventHandler(this.txtStoreStock_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Section Stock";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Department Stock";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(232, 184);
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
            this.btnClear.Location = new System.Drawing.Point(154, 184);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm_rpt_ItemSummery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(314, 216);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.z1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_ItemSummery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Registry  Report";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtRawMaterial;
        private System.Windows.Forms.RadioButton rdoCombinationMaterial;
        private System.Windows.Forms.RadioButton rdoRawMaterial;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoLaminationMaterial;
        private System.Windows.Forms.RadioButton rdoFinishedGood;
        private System.Windows.Forms.RadioButton rdoSemiFinishedGood;
        private System.Windows.Forms.TextBox txtSectionStoke;
        private System.Windows.Forms.TextBox txtDepartmentStock;
        private System.Windows.Forms.TextBox txtStoreStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}