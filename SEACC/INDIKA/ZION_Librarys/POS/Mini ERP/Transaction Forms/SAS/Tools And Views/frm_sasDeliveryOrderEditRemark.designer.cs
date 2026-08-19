namespace Digiteq
{
    partial class frm_sasDeliveryOrderEditRemark
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
            this.zpanel4 = new System.Windows.Forms.Panel();
            this.rhRemark = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoCode = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.zpanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.zpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel4.Controls.Add(this.rhRemark);
            this.zpanel4.Controls.Add(this.label1);
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.txtDoCode);
            this.zpanel4.Location = new System.Drawing.Point(6, 31);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(249, 170);
            this.zpanel4.TabIndex = 466;
            // 
            // rhRemark
            // 
            this.rhRemark.Location = new System.Drawing.Point(77, 41);
            this.rhRemark.Name = "rhRemark";
            this.rhRemark.Size = new System.Drawing.Size(158, 107);
            this.rhRemark.TabIndex = 459;
            this.rhRemark.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 458;
            this.label1.Text = "Remark";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 456;
            this.label2.Text = "D/O Code";
            // 
            // txtDoCode
            // 
            this.txtDoCode.BackColor = System.Drawing.Color.LightGray;
            this.txtDoCode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoCode.Location = new System.Drawing.Point(77, 6);
            this.txtDoCode.Name = "txtDoCode";
            this.txtDoCode.ReadOnly = true;
            this.txtDoCode.Size = new System.Drawing.Size(158, 23);
            this.txtDoCode.TabIndex = 457;
            this.txtDoCode.DoubleClick += new System.EventHandler(this.txtDoCode_DoubleClick);
            this.txtDoCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDoCode_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(104, 204);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 474;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(182, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 473;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_sasDeliveryOrderEditRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(262, 236);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.zpanel4);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_sasDeliveryOrderEditRemark";
            this.Text = "D/O Manual Settle";
            this.Load += new System.EventHandler(this.frm_sasDeliveryOrderManuslSettle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasDeliveryOrderManuslSettle_KeyDown);
            this.Controls.SetChildIndex(this.zpanel4, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDoCode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rhRemark;
        private System.Windows.Forms.Label label1;
    }
}