namespace Digiteq
{
    partial class UC_Supplier
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdoSupplier = new System.Windows.Forms.RadioButton();
            this.rdoOtherCr = new System.Windows.Forms.RadioButton();
            this.btnSettlement = new System.Windows.Forms.Button();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rdoSupplier
            // 
            this.rdoSupplier.AutoSize = true;
            this.rdoSupplier.Location = new System.Drawing.Point(2, 3);
            this.rdoSupplier.Name = "rdoSupplier";
            this.rdoSupplier.Size = new System.Drawing.Size(63, 17);
            this.rdoSupplier.TabIndex = 556;
            this.rdoSupplier.TabStop = true;
            this.rdoSupplier.Text = "Supplier";
            this.rdoSupplier.UseVisualStyleBackColor = true;
            this.rdoSupplier.CheckedChanged += new System.EventHandler(this.rdoSupplier_CheckedChanged);
            // 
            // rdoOtherCr
            // 
            this.rdoOtherCr.AutoSize = true;
            this.rdoOtherCr.Location = new System.Drawing.Point(69, 3);
            this.rdoOtherCr.Name = "rdoOtherCr";
            this.rdoOtherCr.Size = new System.Drawing.Size(90, 17);
            this.rdoOtherCr.TabIndex = 555;
            this.rdoOtherCr.TabStop = true;
            this.rdoOtherCr.Text = "Other Creditor";
            this.rdoOtherCr.UseVisualStyleBackColor = true;
            // 
            // btnSettlement
            // 
            this.btnSettlement.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettlement.Image = global::Digiteq.Properties.Resources.Free;
            this.btnSettlement.Location = new System.Drawing.Point(313, 22);
            this.btnSettlement.Name = "btnSettlement";
            this.btnSettlement.Size = new System.Drawing.Size(22, 22);
            this.btnSettlement.TabIndex = 554;
            this.btnSettlement.UseVisualStyleBackColor = true;
            this.btnSettlement.Click += new System.EventHandler(this.btnSettlement_Click);
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.Color.LightGray;
            this.txtSupplierID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierID.Location = new System.Drawing.Point(64, 22);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(247, 22);
            this.txtSupplierID.TabIndex = 553;
            this.txtSupplierID.DoubleClick += new System.EventHandler(this.txtSupplierID_DoubleClick);
            this.txtSupplierID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierID_KeyDown);
            // 
            // UC_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoSupplier);
            this.Controls.Add(this.rdoOtherCr);
            this.Controls.Add(this.btnSettlement);
            this.Controls.Add(this.txtSupplierID);
            this.Name = "UC_Supplier";
            this.Size = new System.Drawing.Size(345, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoSupplier;
        private System.Windows.Forms.RadioButton rdoOtherCr;
        private System.Windows.Forms.Button btnSettlement;
        private System.Windows.Forms.TextBox txtSupplierID;
    }
}
