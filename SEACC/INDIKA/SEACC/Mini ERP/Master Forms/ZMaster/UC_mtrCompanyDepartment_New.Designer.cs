namespace Digiteq
{
    partial class UC_mtrCompanyDepartment_New
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
            this.txtCompanyDiviton = new System.Windows.Forms.TextBox();
            this.txtCompanyDepatmentName = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtCompanyDepatmentID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBranchD = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.dgvDetail = new SEACC_DataGrid();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DivisionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompanyDiviton
            // 
            this.txtCompanyDiviton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCompanyDiviton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyDiviton.Location = new System.Drawing.Point(127, 35);
            this.txtCompanyDiviton.Name = "txtCompanyDiviton";
            this.txtCompanyDiviton.ReadOnly = true;
            this.txtCompanyDiviton.Size = new System.Drawing.Size(178, 22);
            this.txtCompanyDiviton.TabIndex = 116;
            this.txtCompanyDiviton.DoubleClick += new System.EventHandler(this.txtCompanyDiviton_DoubleClick);
            this.txtCompanyDiviton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyDiviton_KeyDown);
            // 
            // txtCompanyDepatmentName
            // 
            this.txtCompanyDepatmentName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyDepatmentName.Location = new System.Drawing.Point(127, 61);
            this.txtCompanyDepatmentName.Name = "txtCompanyDepatmentName";
            this.txtCompanyDepatmentName.Size = new System.Drawing.Size(178, 22);
            this.txtCompanyDepatmentName.TabIndex = 119;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactPerson.Location = new System.Drawing.Point(436, 61);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(178, 22);
            this.txtContactPerson.TabIndex = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(350, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 14);
            this.label3.TabIndex = 124;
            this.label3.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(436, 35);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(178, 22);
            this.txtFax.TabIndex = 123;
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(350, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 122;
            this.label2.Text = "Telephone";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(436, 9);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(178, 22);
            this.txtTelephone.TabIndex = 121;
            this.txtTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelephone_KeyPress);
            // 
            // txtCompanyDepatmentID
            // 
            this.txtCompanyDepatmentID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtCompanyDepatmentID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyDepatmentID.Location = new System.Drawing.Point(127, 9);
            this.txtCompanyDepatmentID.Name = "txtCompanyDepatmentID";
            this.txtCompanyDepatmentID.Size = new System.Drawing.Size(178, 22);
            this.txtCompanyDepatmentID.TabIndex = 115;
            this.txtCompanyDepatmentID.DoubleClick += new System.EventHandler(this.txtCompanyDepatmentID_DoubleClick);
            this.txtCompanyDepatmentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyDepatmentID_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(11, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 128;
            this.label5.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(127, 90);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(488, 22);
            this.txtAddress.TabIndex = 127;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(350, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 126;
            this.label4.Text = "Contact Person";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(11, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 120;
            this.label1.Text = "Department Name";
            // 
            // lblBranchD
            // 
            this.lblBranchD.AutoSize = true;
            this.lblBranchD.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBranchD.Location = new System.Drawing.Point(11, 13);
            this.lblBranchD.Name = "lblBranchD";
            this.lblBranchD.Size = new System.Drawing.Size(109, 14);
            this.lblBranchD.TabIndex = 117;
            this.lblBranchD.Text = "Cmp. Department ID";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBankName.Location = new System.Drawing.Point(11, 39);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(110, 14);
            this.lblBankName.TabIndex = 118;
            this.lblBankName.Text = "Company Division ID";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepartmentID,
            this.DepartmentName,
            this.ContactPerson,
            this.DivisionName,
            this.Telephone,
            this.Fax,
            this.Address});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(11, 128);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(605, 256);
            this.dgvDetail.TabIndex = 129;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // DepartmentID
            // 
            this.DepartmentID.HeaderText = "Department ID";
            this.DepartmentID.Name = "DepartmentID";
            // 
            // DepartmentName
            // 
            this.DepartmentName.HeaderText = "Department Name";
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Width = 200;
            // 
            // ContactPerson
            // 
            this.ContactPerson.HeaderText = "Contact Person";
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.Width = 185;
            // 
            // DivisionName
            // 
            this.DivisionName.HeaderText = "Division Name";
            this.DivisionName.Name = "DivisionName";
            this.DivisionName.Visible = false;
            // 
            // Telephone
            // 
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            this.Telephone.Width = 120;
            // 
            // Fax
            // 
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.Visible = false;
            this.Fax.Width = 85;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = false;
            this.Address.Width = 115;
            // 
            // UC_mtrCompanyDepartment_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtCompanyDiviton);
            this.Controls.Add(this.txtCompanyDepatmentName);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtCompanyDepatmentID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBranchD);
            this.Controls.Add(this.lblBankName);
            this.Name = "UC_mtrCompanyDepartment_New";
            this.Size = new System.Drawing.Size(627, 446);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_mtrCompanyDepartment_New_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_mtrCompanyDepartment_New_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_mtrCompanyDepartment_New_SF_cancelButton_Click);
            this.Load += new System.EventHandler(this.UC_mtrCompanyDepartment_New_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UC_mtrCompanyDepartment_New_KeyDown);
            this.Controls.SetChildIndex(this.lblBankName, 0);
            this.Controls.SetChildIndex(this.lblBranchD, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCompanyDepatmentID, 0);
            this.Controls.SetChildIndex(this.txtTelephone, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtFax, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtContactPerson, 0);
            this.Controls.SetChildIndex(this.txtCompanyDepatmentName, 0);
            this.Controls.SetChildIndex(this.txtCompanyDiviton, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCompanyDiviton;
        private System.Windows.Forms.TextBox txtCompanyDepatmentName;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtCompanyDepatmentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBranchD;
        private System.Windows.Forms.Label lblBankName;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn DivisionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}
