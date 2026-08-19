namespace Digiteq
{
    partial class SEACC_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEACC_Form));
            this._FLP1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Attachments = new Digiteq.SEACC_Attachments();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDraft = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnChecked = new System.Windows.Forms.Button();
            this.btnUserDetails = new System.Windows.Forms.Button();
            this.btnTemp = new System.Windows.Forms.Button();
            this.pnl_footer = new System.Windows.Forms.Panel();
            this._line1 = new System.Windows.Forms.Panel();
            this._FLP1.SuspendLayout();
            this.pnl_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _FLP1
            // 
            this._FLP1.Controls.Add(this.Attachments);
            this._FLP1.Controls.Add(this.btnCancel);
            this._FLP1.Controls.Add(this.btnPrint);
            this._FLP1.Controls.Add(this.btnDraft);
            this._FLP1.Controls.Add(this.btnSave);
            this._FLP1.Controls.Add(this.btnNew);
            this._FLP1.Controls.Add(this.btnApproved);
            this._FLP1.Controls.Add(this.btnChecked);
            this._FLP1.Controls.Add(this.btnUserDetails);
            this._FLP1.Controls.Add(this.btnTemp);
            this._FLP1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._FLP1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._FLP1.Location = new System.Drawing.Point(10, 4);
            this._FLP1.Name = "_FLP1";
            this._FLP1.Size = new System.Drawing.Size(728, 34);
            this._FLP1.TabIndex = 0;
            // 
            // Attachments
            // 
            this.Attachments.BackColor = System.Drawing.SystemColors.Control;
            this.Attachments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Attachments.Location = new System.Drawing.Point(697, 2);
            this.Attachments.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.Attachments.Name = "Attachments";
            this.Attachments.Padding = new System.Windows.Forms.Padding(1);
            this.Attachments.Size = new System.Drawing.Size(30, 27);
            this.Attachments.TabIndex = 604;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Digiteq.Properties.Resources.delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(618, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 581;
            this.btnCancel.Text = "Cancel  ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(537, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 579;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrt_Click);
            // 
            // btnDraft
            // 
            this.btnDraft.BackColor = System.Drawing.Color.LightGray;
            this.btnDraft.FlatAppearance.BorderSize = 0;
            this.btnDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraft.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDraft.Image = global::Digiteq.Properties.Resources.Printer;
            this.btnDraft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDraft.Location = new System.Drawing.Point(456, 3);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(75, 25);
            this.btnDraft.TabIndex = 606;
            this.btnDraft.Text = "   Draft";
            this.btnDraft.UseVisualStyleBackColor = false;
            this.btnDraft.Click += new System.EventHandler(this.btnDraft_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(375, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 580;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(294, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 582;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.BackColor = System.Drawing.Color.LightGray;
            this.btnApproved.FlatAppearance.BorderSize = 0;
            this.btnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApproved.Location = new System.Drawing.Point(213, 3);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(75, 25);
            this.btnApproved.TabIndex = 584;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = false;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnChecked
            // 
            this.btnChecked.BackColor = System.Drawing.Color.LightGray;
            this.btnChecked.FlatAppearance.BorderSize = 0;
            this.btnChecked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChecked.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChecked.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChecked.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChecked.Location = new System.Drawing.Point(132, 3);
            this.btnChecked.Name = "btnChecked";
            this.btnChecked.Size = new System.Drawing.Size(75, 25);
            this.btnChecked.TabIndex = 583;
            this.btnChecked.Text = "Checked";
            this.btnChecked.UseVisualStyleBackColor = false;
            this.btnChecked.Click += new System.EventHandler(this.btnChecked_Click);
            // 
            // btnUserDetails
            // 
            this.btnUserDetails.BackColor = System.Drawing.Color.LightGray;
            this.btnUserDetails.FlatAppearance.BorderSize = 0;
            this.btnUserDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserDetails.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserDetails.Location = new System.Drawing.Point(98, 3);
            this.btnUserDetails.Name = "btnUserDetails";
            this.btnUserDetails.Size = new System.Drawing.Size(28, 25);
            this.btnUserDetails.TabIndex = 605;
            this.btnUserDetails.Text = "";
            this.btnUserDetails.UseVisualStyleBackColor = false;
            this.btnUserDetails.Click += new System.EventHandler(this.btnUserDetails_Click);
            // 
            // btnTemp
            // 
            this.btnTemp.BackColor = System.Drawing.Color.LightGray;
            this.btnTemp.FlatAppearance.BorderSize = 0;
            this.btnTemp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(203)))), ((int)(((byte)(72)))));
            this.btnTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemp.Image = ((System.Drawing.Image)(resources.GetObject("btnTemp.Image")));
            this.btnTemp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTemp.Location = new System.Drawing.Point(17, 3);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(75, 25);
            this.btnTemp.TabIndex = 607;
            this.btnTemp.Text = "Temp  ";
            this.btnTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTemp.UseVisualStyleBackColor = false;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // pnl_footer
            // 
            this.pnl_footer.BackColor = System.Drawing.Color.Transparent;
            this.pnl_footer.Controls.Add(this._line1);
            this.pnl_footer.Controls.Add(this._FLP1);
            this.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_footer.Location = new System.Drawing.Point(1, 245);
            this.pnl_footer.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_footer.Name = "pnl_footer";
            this.pnl_footer.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnl_footer.Size = new System.Drawing.Size(748, 38);
            this.pnl_footer.TabIndex = 1;
            // 
            // _line1
            // 
            this._line1.BackColor = System.Drawing.Color.Gray;
            this._line1.Dock = System.Windows.Forms.DockStyle.Top;
            this._line1.Location = new System.Drawing.Point(10, 0);
            this._line1.Margin = new System.Windows.Forms.Padding(0);
            this._line1.Name = "_line1";
            this._line1.Size = new System.Drawing.Size(728, 1);
            this._line1.TabIndex = 2;
            // 
            // SEACC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnl_footer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SEACC_Form";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(750, 284);
            this._FLP1.ResumeLayout(false);
            this.pnl_footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.Panel _line1;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnApproved;
        public System.Windows.Forms.Button btnChecked;
        public SEACC_Attachments Attachments;
        public System.Windows.Forms.Button btnUserDetails;
        public System.Windows.Forms.Button btnDraft;
        private System.Windows.Forms.Button btnTemp;
        public System.Windows.Forms.FlowLayoutPanel _FLP1;
    }
}
