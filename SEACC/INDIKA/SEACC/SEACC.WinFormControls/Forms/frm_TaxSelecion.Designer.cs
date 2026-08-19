namespace SEACC.WinFormControls.Forms
{
    partial class frm_TaxSelecion
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
            this.btnDraft = new System.Windows.Forms.Button();
            this.btnPrt = new System.Windows.Forms.Button();
            this.rdo_NonTax = new System.Windows.Forms.RadioButton();
            this.rdo_Tax = new System.Windows.Forms.RadioButton();
            this.rdo_NBT = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPrePrint = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDraft
            // 
            this.btnDraft.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraft.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         //   this.btnDraft.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnDraft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDraft.Location = new System.Drawing.Point(46, 115);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(75, 25);
            this.btnDraft.TabIndex = 554;
            this.btnDraft.Text = "Draft";
            this.btnDraft.UseVisualStyleBackColor = true;
            this.btnDraft.Visible = false;
            this.btnDraft.Click += new System.EventHandler(this.btnDraft_Click);
            // 
            // btnPrt
            // 
            this.btnPrt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    this.btnPrt.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrt.Location = new System.Drawing.Point(125, 115);
            this.btnPrt.Name = "btnPrt";
            this.btnPrt.Size = new System.Drawing.Size(75, 25);
            this.btnPrt.TabIndex = 553;
            this.btnPrt.Text = "OK";
            this.btnPrt.UseVisualStyleBackColor = true;
            this.btnPrt.Click += new System.EventHandler(this.btnPrt_Click);
            // 
            // rdo_NonTax
            // 
            this.rdo_NonTax.AutoSize = true;
            this.rdo_NonTax.Location = new System.Drawing.Point(13, 12);
            this.rdo_NonTax.Name = "rdo_NonTax";
            this.rdo_NonTax.Size = new System.Drawing.Size(104, 17);
            this.rdo_NonTax.TabIndex = 555;
            this.rdo_NonTax.TabStop = true;
            this.rdo_NonTax.Text = "Non Tax Invoice";
            this.rdo_NonTax.UseVisualStyleBackColor = true;
            // 
            // rdo_Tax
            // 
            this.rdo_Tax.AutoSize = true;
            this.rdo_Tax.Location = new System.Drawing.Point(13, 35);
            this.rdo_Tax.Name = "rdo_Tax";
            this.rdo_Tax.Size = new System.Drawing.Size(81, 17);
            this.rdo_Tax.TabIndex = 556;
            this.rdo_Tax.TabStop = true;
            this.rdo_Tax.Text = "Tax Invoice";
            this.rdo_Tax.UseVisualStyleBackColor = true;
            // 
            // rdo_NBT
            // 
            this.rdo_NBT.AutoSize = true;
            this.rdo_NBT.Location = new System.Drawing.Point(13, 58);
            this.rdo_NBT.Name = "rdo_NBT";
            this.rdo_NBT.Size = new System.Drawing.Size(183, 17);
            this.rdo_NBT.TabIndex = 556;
            this.rdo_NBT.TabStop = true;
            this.rdo_NBT.Text = "Tax Invoice - Unit Price with NBT";
            this.rdo_NBT.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.rdo_NonTax);
            this.panel1.Controls.Add(this.rdo_NBT);
            this.panel1.Controls.Add(this.rdo_Tax);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 84);
            this.panel1.TabIndex = 557;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Red;
            this.btn_Close.Location = new System.Drawing.Point(175, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 28);
            this.btn_Close.TabIndex = 557;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 84);
            this.panel2.TabIndex = 558;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 40);
            this.label1.TabIndex = 558;
            this.label1.Text = "";
            this.label1.Visible = false;
            // 
            // chkPrePrint
            // 
            this.chkPrePrint.AutoSize = true;
            this.chkPrePrint.Location = new System.Drawing.Point(13, 92);
            this.chkPrePrint.Name = "chkPrePrint";
            this.chkPrePrint.Size = new System.Drawing.Size(90, 17);
            this.chkPrePrint.TabIndex = 559;
            this.chkPrePrint.Text = "Pre Print Only";
            this.chkPrePrint.UseVisualStyleBackColor = true;
            // 
            // frm_TaxSelecion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(210, 151);
            this.Controls.Add(this.chkPrePrint);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDraft);
            this.Controls.Add(this.btnPrt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_TaxSelecion";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_TaxSelecion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDraft;
        private System.Windows.Forms.Button btnPrt;
        private System.Windows.Forms.RadioButton rdo_NonTax;
        private System.Windows.Forms.RadioButton rdo_Tax;
        private System.Windows.Forms.RadioButton rdo_NBT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.CheckBox chkPrePrint;
    }
}