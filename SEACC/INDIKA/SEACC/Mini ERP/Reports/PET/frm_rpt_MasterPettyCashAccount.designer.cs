namespace Digiteq
{
    partial class frm_rpt_MasterPettyCashAccount
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
            this.x1 = new System.Windows.Forms.Panel();
            this.rdoSupplier = new System.Windows.Forms.RadioButton();
            this.rdoActiviteCode = new System.Windows.Forms.RadioButton();
            this.rdoCostCenter = new System.Windows.Forms.RadioButton();
            this.rdoIncomeType = new System.Windows.Forms.RadioButton();
            this.rdoLevel3Name = new System.Windows.Forms.RadioButton();
            this.rdoLevel2Name = new System.Windows.Forms.RadioButton();
            this.rdoLevel1Name = new System.Windows.Forms.RadioButton();
            this.rdoExpenditureTypes = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.x1.SuspendLayout();
            this.SuspendLayout();
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.x1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1.Controls.Add(this.rdoSupplier);
            this.x1.Controls.Add(this.rdoActiviteCode);
            this.x1.Controls.Add(this.rdoCostCenter);
            this.x1.Controls.Add(this.rdoIncomeType);
            this.x1.Controls.Add(this.rdoLevel3Name);
            this.x1.Controls.Add(this.rdoLevel2Name);
            this.x1.Controls.Add(this.rdoLevel1Name);
            this.x1.Controls.Add(this.rdoExpenditureTypes);
            this.x1.Location = new System.Drawing.Point(11, 12);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(306, 105);
            this.x1.TabIndex = 7;
            this.x1.Paint += new System.Windows.Forms.PaintEventHandler(this.x1_Paint);
            // 
            // rdoSupplier
            // 
            this.rdoSupplier.AutoSize = true;
            this.rdoSupplier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoSupplier.Location = new System.Drawing.Point(175, 54);
            this.rdoSupplier.Name = "rdoSupplier";
            this.rdoSupplier.Size = new System.Drawing.Size(70, 18);
            this.rdoSupplier.TabIndex = 22;
            this.rdoSupplier.TabStop = true;
            this.rdoSupplier.Text = "Suppliers";
            this.rdoSupplier.UseVisualStyleBackColor = true;
            this.rdoSupplier.CheckedChanged += new System.EventHandler(this.rdoSupplier_CheckedChanged);
            // 
            // rdoActiviteCode
            // 
            this.rdoActiviteCode.AutoSize = true;
            this.rdoActiviteCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActiviteCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoActiviteCode.Location = new System.Drawing.Point(175, 30);
            this.rdoActiviteCode.Name = "rdoActiviteCode";
            this.rdoActiviteCode.Size = new System.Drawing.Size(101, 18);
            this.rdoActiviteCode.TabIndex = 21;
            this.rdoActiviteCode.TabStop = true;
            this.rdoActiviteCode.Text = "Activitys/Items";
            this.rdoActiviteCode.UseVisualStyleBackColor = true;
            // 
            // rdoCostCenter
            // 
            this.rdoCostCenter.AutoSize = true;
            this.rdoCostCenter.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCostCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoCostCenter.Location = new System.Drawing.Point(175, 6);
            this.rdoCostCenter.Name = "rdoCostCenter";
            this.rdoCostCenter.Size = new System.Drawing.Size(86, 18);
            this.rdoCostCenter.TabIndex = 20;
            this.rdoCostCenter.TabStop = true;
            this.rdoCostCenter.Text = "Cost Centers";
            this.rdoCostCenter.UseVisualStyleBackColor = true;
            // 
            // rdoIncomeType
            // 
            this.rdoIncomeType.AutoSize = true;
            this.rdoIncomeType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoIncomeType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoIncomeType.Location = new System.Drawing.Point(175, 78);
            this.rdoIncomeType.Name = "rdoIncomeType";
            this.rdoIncomeType.Size = new System.Drawing.Size(93, 18);
            this.rdoIncomeType.TabIndex = 19;
            this.rdoIncomeType.TabStop = true;
            this.rdoIncomeType.Text = "Income Types";
            this.rdoIncomeType.UseVisualStyleBackColor = true;
            // 
            // rdoLevel3Name
            // 
            this.rdoLevel3Name.AutoSize = true;
            this.rdoLevel3Name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLevel3Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoLevel3Name.Location = new System.Drawing.Point(15, 54);
            this.rdoLevel3Name.Name = "rdoLevel3Name";
            this.rdoLevel3Name.Size = new System.Drawing.Size(90, 18);
            this.rdoLevel3Name.TabIndex = 18;
            this.rdoLevel3Name.TabStop = true;
            this.rdoLevel3Name.Text = "Level 3 Titles";
            this.rdoLevel3Name.UseVisualStyleBackColor = true;
            // 
            // rdoLevel2Name
            // 
            this.rdoLevel2Name.AutoSize = true;
            this.rdoLevel2Name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLevel2Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoLevel2Name.Location = new System.Drawing.Point(15, 30);
            this.rdoLevel2Name.Name = "rdoLevel2Name";
            this.rdoLevel2Name.Size = new System.Drawing.Size(90, 18);
            this.rdoLevel2Name.TabIndex = 17;
            this.rdoLevel2Name.TabStop = true;
            this.rdoLevel2Name.Text = "Level 2 Titles";
            this.rdoLevel2Name.UseVisualStyleBackColor = true;
            // 
            // rdoLevel1Name
            // 
            this.rdoLevel1Name.AutoSize = true;
            this.rdoLevel1Name.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLevel1Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoLevel1Name.Location = new System.Drawing.Point(15, 6);
            this.rdoLevel1Name.Name = "rdoLevel1Name";
            this.rdoLevel1Name.Size = new System.Drawing.Size(90, 18);
            this.rdoLevel1Name.TabIndex = 15;
            this.rdoLevel1Name.TabStop = true;
            this.rdoLevel1Name.Text = "Level 1 Titles";
            this.rdoLevel1Name.UseVisualStyleBackColor = true;
            // 
            // rdoExpenditureTypes
            // 
            this.rdoExpenditureTypes.AutoSize = true;
            this.rdoExpenditureTypes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoExpenditureTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rdoExpenditureTypes.Location = new System.Drawing.Point(15, 78);
            this.rdoExpenditureTypes.Name = "rdoExpenditureTypes";
            this.rdoExpenditureTypes.Size = new System.Drawing.Size(116, 18);
            this.rdoExpenditureTypes.TabIndex = 10;
            this.rdoExpenditureTypes.TabStop = true;
            this.rdoExpenditureTypes.Text = "Expenditure Types";
            this.rdoExpenditureTypes.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(232, 123);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 479;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frm_rpt_MasterPettyCashAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(324, 150);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.x1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_rpt_MasterPettyCashAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Book Master Report";
            this.Load += new System.EventHandler(this.frm_rpt_MasterPettyCashAccount_Load);
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.RadioButton rdoIncomeType;
        private System.Windows.Forms.RadioButton rdoLevel3Name;
        private System.Windows.Forms.RadioButton rdoLevel2Name;
        private System.Windows.Forms.RadioButton rdoLevel1Name;
        private System.Windows.Forms.RadioButton rdoExpenditureTypes;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rdoSupplier;
        private System.Windows.Forms.RadioButton rdoActiviteCode;
        private System.Windows.Forms.RadioButton rdoCostCenter;
    }
}