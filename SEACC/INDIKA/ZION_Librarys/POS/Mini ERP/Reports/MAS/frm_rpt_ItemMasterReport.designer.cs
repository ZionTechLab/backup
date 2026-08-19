namespace Digiteq
{
    partial class frm_rpt_ItemMasterReport
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
            this.rdoStore = new System.Windows.Forms.RadioButton();
            this.rdoDepartment = new System.Windows.Forms.RadioButton();
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoItemMasterReport = new System.Windows.Forms.RadioButton();
            this.rboItemMastercostDetail = new System.Windows.Forms.RadioButton();
            this.chkJobBase = new System.Windows.Forms.CheckBox();
            this.rdoSection = new System.Windows.Forms.RadioButton();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.z2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.x1.SuspendLayout();
            this.z2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoStore
            // 
            this.rdoStore.AutoSize = true;
            this.rdoStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoStore.Location = new System.Drawing.Point(12, 9);
            this.rdoStore.Name = "rdoStore";
            this.rdoStore.Size = new System.Drawing.Size(54, 18);
            this.rdoStore.TabIndex = 2;
            this.rdoStore.TabStop = true;
            this.rdoStore.Text = "Store ";
            this.rdoStore.UseVisualStyleBackColor = true;
            this.rdoStore.CheckedChanged += new System.EventHandler(this.rdoStoreStock_CheckedChanged);
            // 
            // rdoDepartment
            // 
            this.rdoDepartment.AutoSize = true;
            this.rdoDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoDepartment.Location = new System.Drawing.Point(12, 61);
            this.rdoDepartment.Name = "rdoDepartment";
            this.rdoDepartment.Size = new System.Drawing.Size(88, 18);
            this.rdoDepartment.TabIndex = 1;
            this.rdoDepartment.TabStop = true;
            this.rdoDepartment.Text = "Department ";
            this.rdoDepartment.UseVisualStyleBackColor = true;
            this.rdoDepartment.CheckedChanged += new System.EventHandler(this.rdoDepartmentStock_CheckedChanged);
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoItemMasterReport);
            this.x1.Controls.Add(this.rboItemMastercostDetail);
            this.x1.Controls.Add(this.chkJobBase);
            this.x1.Controls.Add(this.rdoSection);
            this.x1.Controls.Add(this.rdoStore);
            this.x1.Controls.Add(this.rdoDepartment);
            this.x1.Location = new System.Drawing.Point(7, 33);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(611, 118);
            this.x1.TabIndex = 5;
            this.x1.Paint += new System.Windows.Forms.PaintEventHandler(this.x1_Paint);
            // 
            // rdoItemMasterReport
            // 
            this.rdoItemMasterReport.AutoSize = true;
            this.rdoItemMasterReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoItemMasterReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoItemMasterReport.Location = new System.Drawing.Point(248, 33);
            this.rdoItemMasterReport.Name = "rdoItemMasterReport";
            this.rdoItemMasterReport.Size = new System.Drawing.Size(122, 18);
            this.rdoItemMasterReport.TabIndex = 479;
            this.rdoItemMasterReport.TabStop = true;
            this.rdoItemMasterReport.Text = "Item Master Report";
            this.rdoItemMasterReport.UseVisualStyleBackColor = true;
            this.rdoItemMasterReport.CheckedChanged += new System.EventHandler(this.rdoItemMasterReport_CheckedChanged);
            // 
            // rboItemMastercostDetail
            // 
            this.rboItemMastercostDetail.AutoSize = true;
            this.rboItemMastercostDetail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboItemMastercostDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rboItemMastercostDetail.Location = new System.Drawing.Point(248, 9);
            this.rboItemMastercostDetail.Name = "rboItemMastercostDetail";
            this.rboItemMastercostDetail.Size = new System.Drawing.Size(143, 18);
            this.rboItemMastercostDetail.TabIndex = 479;
            this.rboItemMastercostDetail.TabStop = true;
            this.rboItemMastercostDetail.Text = "Item Master Cost Detail";
            this.rboItemMastercostDetail.UseVisualStyleBackColor = true;
            this.rboItemMastercostDetail.CheckedChanged += new System.EventHandler(this.rboItemMastercostDetail_CheckedChanged);
            // 
            // chkJobBase
            // 
            this.chkJobBase.AutoSize = true;
            this.chkJobBase.Enabled = false;
            this.chkJobBase.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJobBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkJobBase.Location = new System.Drawing.Point(121, 89);
            this.chkJobBase.Name = "chkJobBase";
            this.chkJobBase.Size = new System.Drawing.Size(83, 18);
            this.chkJobBase.TabIndex = 478;
            this.chkJobBase.Text = "With Job ID";
            this.chkJobBase.UseVisualStyleBackColor = true;
            // 
            // rdoSection
            // 
            this.rdoSection.AutoSize = true;
            this.rdoSection.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSection.Location = new System.Drawing.Point(12, 35);
            this.rdoSection.Name = "rdoSection";
            this.rdoSection.Size = new System.Drawing.Size(64, 18);
            this.rdoSection.TabIndex = 5;
            this.rdoSection.TabStop = true;
            this.rdoSection.Text = "Section ";
            this.rdoSection.UseVisualStyleBackColor = true;
            this.rdoSection.CheckedChanged += new System.EventHandler(this.rdoSectionStock_CheckedChanged);
            // 
            // txtSection
            // 
            this.txtSection.BackColor = System.Drawing.Color.LightGray;
            this.txtSection.Enabled = false;
            this.txtSection.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(405, 58);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(194, 22);
            this.txtSection.TabIndex = 477;
            this.txtSection.DoubleClick += new System.EventHandler(this.txtSectionStoke_DoubleClick);
            this.txtSection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSection_KeyDown);
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.LightGray;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(405, 84);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(194, 22);
            this.txtDepartment.TabIndex = 16;
            this.txtDepartment.DoubleClick += new System.EventHandler(this.txtDepartmentStock_DoubleClick);
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartment_KeyDown);
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.LightGray;
            this.txtStore.Enabled = false;
            this.txtStore.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStore.Location = new System.Drawing.Point(405, 32);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(194, 22);
            this.txtStore.TabIndex = 15;
            this.txtStore.DoubleClick += new System.EventHandler(this.txtStoreStock_DoubleClick);
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStore_KeyDown);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(543, 282);
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
            this.btnClear.Location = new System.Drawing.Point(465, 282);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 476;
            this.btnClear.Text = "   Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.z2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.z2.Controls.Add(this.label6);
            this.z2.Controls.Add(this.label5);
            this.z2.Controls.Add(this.label4);
            this.z2.Controls.Add(this.txtJobCode);
            this.z2.Controls.Add(this.txtSection);
            this.z2.Controls.Add(this.label3);
            this.z2.Controls.Add(this.txtItemType);
            this.z2.Controls.Add(this.txtDepartment);
            this.z2.Controls.Add(this.label2);
            this.z2.Controls.Add(this.txtItemCategory);
            this.z2.Controls.Add(this.label1);
            this.z2.Controls.Add(this.txtStore);
            this.z2.Controls.Add(this.txtItemName);
            this.z2.Controls.Add(this.lblCustomer);
            this.z2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.z2.Location = new System.Drawing.Point(7, 157);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(611, 119);
            this.z2.TabIndex = 477;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(326, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 480;
            this.label6.Text = "Job Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(326, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 14);
            this.label5.TabIndex = 479;
            this.label5.Text = "Job Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(326, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 478;
            this.label4.Text = "Store Name";
            // 
            // txtJobCode
            // 
            this.txtJobCode.BackColor = System.Drawing.Color.LightGray;
            this.txtJobCode.Enabled = false;
            this.txtJobCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobCode.Location = new System.Drawing.Point(108, 89);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.ReadOnly = true;
            this.txtJobCode.Size = new System.Drawing.Size(194, 22);
            this.txtJobCode.TabIndex = 15;
            this.txtJobCode.DoubleClick += new System.EventHandler(this.txtJobCode_DoubleClick);
            this.txtJobCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Job Code";
            // 
            // txtItemType
            // 
            this.txtItemType.BackColor = System.Drawing.Color.LightGray;
            this.txtItemType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemType.Location = new System.Drawing.Point(108, 33);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.ReadOnly = true;
            this.txtItemType.Size = new System.Drawing.Size(194, 22);
            this.txtItemType.TabIndex = 15;
            this.txtItemType.DoubleClick += new System.EventHandler(this.txtItemType_DoubleClick);
            this.txtItemType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemType_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Item Type";
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.BackColor = System.Drawing.Color.LightGray;
            this.txtItemCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.Location = new System.Drawing.Point(108, 61);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.ReadOnly = true;
            this.txtItemCategory.Size = new System.Drawing.Size(194, 22);
            this.txtItemCategory.TabIndex = 13;
            this.txtItemCategory.DoubleClick += new System.EventHandler(this.txtItemCategory_DoubleClick);
            this.txtItemCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCategory_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Item Category";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.LightGray;
            this.txtItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(108, 5);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(361, 22);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.DoubleClick += new System.EventHandler(this.txtItemName_DoubleClick);
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCustomer.Location = new System.Drawing.Point(12, 8);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 14);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Item Name";
            // 
            // frm_rpt_ItemMasterReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(626, 313);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_ItemMasterReport";
            this.Text = "Item Master Report";
            this.Load += new System.EventHandler(this.frmReportChequeDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rpt_ChequeManagement_KeyDown);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.z2, 0);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.z2.ResumeLayout(false);
            this.z2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoDepartment;
        private System.Windows.Forms.RadioButton rdoStore;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdoSection;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.Panel z2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkJobBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJobCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rboItemMastercostDetail;
        private System.Windows.Forms.RadioButton rdoItemMasterReport;
    }
}