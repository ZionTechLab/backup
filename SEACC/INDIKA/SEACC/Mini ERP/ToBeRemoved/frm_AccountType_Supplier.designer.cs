namespace Digiteq
{
    partial class frm_AccountType_Supplier
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new SEACC_DataGrid();
            this.AccTypeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGlID = new System.Windows.Forms.Label();
            this.TxtGlID = new System.Windows.Forms.TextBox();
            this.lblAccountTypeID = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.txtAccTypeNo = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(248, 118);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccTypeNo,
            this.AccTypeName,
            this.glid});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(5, 149);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(393, 252);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // AccTypeNo
            // 
            this.AccTypeNo.HeaderText = "Acc Type No";
            this.AccTypeNo.Name = "AccTypeNo";
            this.AccTypeNo.Width = 95;
            // 
            // AccTypeName
            // 
            this.AccTypeName.HeaderText = "Acc Type Name";
            this.AccTypeName.Name = "AccTypeName";
            this.AccTypeName.Width = 195;
            // 
            // glid
            // 
            this.glid.HeaderText = "GL ID";
            this.glid.Name = "glid";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblGlID);
            this.panel2.Controls.Add(this.TxtGlID);
            this.panel2.Controls.Add(this.lblAccountTypeID);
            this.panel2.Controls.Add(this.lblClassName);
            this.panel2.Controls.Add(this.txtAccName);
            this.panel2.Controls.Add(this.txtAccTypeNo);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 107);
            this.panel2.TabIndex = 7;
            // 
            // lblGlID
            // 
            this.lblGlID.AutoSize = true;
            this.lblGlID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGlID.Location = new System.Drawing.Point(4, 67);
            this.lblGlID.Name = "lblGlID";
            this.lblGlID.Size = new System.Drawing.Size(32, 14);
            this.lblGlID.TabIndex = 116;
            this.lblGlID.Text = "Gl ID";
            // 
            // TxtGlID
            // 
            this.TxtGlID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGlID.Location = new System.Drawing.Point(116, 64);
            this.TxtGlID.Name = "TxtGlID";
            this.TxtGlID.ReadOnly = true;
            this.TxtGlID.Size = new System.Drawing.Size(241, 22);
            this.TxtGlID.TabIndex = 115;
            this.TxtGlID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaybleGlID_KeyDown);
            this.TxtGlID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPaybleGlID_MouseDoubleClick);
            // 
            // lblAccountTypeID
            // 
            this.lblAccountTypeID.AutoSize = true;
            this.lblAccountTypeID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountTypeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAccountTypeID.Location = new System.Drawing.Point(4, 14);
            this.lblAccountTypeID.Name = "lblAccountTypeID";
            this.lblAccountTypeID.Size = new System.Drawing.Size(90, 14);
            this.lblAccountTypeID.TabIndex = 72;
            this.lblAccountTypeID.Text = "Account Type No";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClassName.Location = new System.Drawing.Point(3, 39);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(106, 14);
            this.lblClassName.TabIndex = 104;
            this.lblClassName.Text = "Account Type Name";
            // 
            // txtAccName
            // 
            this.txtAccName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccName.Location = new System.Drawing.Point(116, 36);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.Size = new System.Drawing.Size(241, 22);
            this.txtAccName.TabIndex = 1;
            // 
            // txtAccTypeNo
            // 
            this.txtAccTypeNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtAccTypeNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccTypeNo.Location = new System.Drawing.Point(116, 10);
            this.txtAccTypeNo.Name = "txtAccTypeNo";
            this.txtAccTypeNo.Size = new System.Drawing.Size(114, 22);
            this.txtAccTypeNo.TabIndex = 0;           
            this.txtAccTypeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClassID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(171, 118);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(325, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frm_AccountType_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(404, 406);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_AccountType_Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Type - Supplier";
            this.Load += new System.EventHandler(this.frm_mtrCustomerClass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrItemClass_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAccountTypeID;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtAccName;
        private System.Windows.Forms.TextBox txtAccTypeNo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblGlID;
        private System.Windows.Forms.TextBox TxtGlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccTypeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn glid;

    }
}