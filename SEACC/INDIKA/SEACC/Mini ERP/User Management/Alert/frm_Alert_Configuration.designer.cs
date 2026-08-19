namespace Digiteq
{
    partial class frm_Alert_Configuration
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
            this.dgvDetail = new SEACC_DataGrid();
            this.settingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alertName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userEmail1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userEmail2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z1 = new System.Windows.Forms.Panel();
            this.rdoPersonName = new System.Windows.Forms.RadioButton();
            this.rdoUserName = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtMobile2 = new System.Windows.Forms.TextBox();
            this.txtMobile1 = new System.Windows.Forms.TextBox();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblSettingID = new System.Windows.Forms.Label();
            this.lblAlertName = new System.Windows.Forms.Label();
            this.txtAlertName = new System.Windows.Forms.TextBox();
            this.txtSettingID = new System.Windows.Forms.TextBox();
            this.x1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.z1.SuspendLayout();
            this.x1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.settingID,
            this.alertName,
            this.userName,
            this.personName,
            this.userEmail1,
            this.userEmail2,
            this.phoneNo1,
            this.phoneNo2});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(7, 177);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(654, 301);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // settingID
            // 
            this.settingID.HeaderText = "Sett.ID";
            this.settingID.Name = "settingID";
            this.settingID.Visible = false;
            this.settingID.Width = 50;
            // 
            // alertName
            // 
            this.alertName.HeaderText = "Alert Name";
            this.alertName.Name = "alertName";
            this.alertName.Visible = false;
            this.alertName.Width = 200;
            // 
            // userName
            // 
            this.userName.HeaderText = "User Name";
            this.userName.Name = "userName";
            this.userName.Width = 130;
            // 
            // personName
            // 
            this.personName.HeaderText = "Person Name";
            this.personName.Name = "personName";
            this.personName.Width = 125;
            // 
            // userEmail1
            // 
            this.userEmail1.HeaderText = "Email1";
            this.userEmail1.Name = "userEmail1";
            this.userEmail1.Width = 120;
            // 
            // userEmail2
            // 
            this.userEmail2.HeaderText = "Email2";
            this.userEmail2.Name = "userEmail2";
            this.userEmail2.Width = 120;
            // 
            // phoneNo1
            // 
            this.phoneNo1.HeaderText = "Mobile 1";
            this.phoneNo1.Name = "phoneNo1";
            this.phoneNo1.Width = 76;
            // 
            // phoneNo2
            // 
            this.phoneNo2.HeaderText = "Mobile 2";
            this.phoneNo2.Name = "phoneNo2";
            this.phoneNo2.Width = 80;
            // 
            // z1
            // 
            this.z1.BackColor = System.Drawing.Color.Transparent;
            this.z1.Controls.Add(this.rdoPersonName);
            this.z1.Controls.Add(this.rdoUserName);
            this.z1.Controls.Add(this.btnDelete);
            this.z1.Controls.Add(this.label1);
            this.z1.Controls.Add(this.label4);
            this.z1.Controls.Add(this.txtPersonName);
            this.z1.Controls.Add(this.btnSave);
            this.z1.Controls.Add(this.btnNew);
            this.z1.Controls.Add(this.txtMobile2);
            this.z1.Controls.Add(this.txtMobile1);
            this.z1.Controls.Add(this.txtEmail2);
            this.z1.Controls.Add(this.txtEmail1);
            this.z1.Controls.Add(this.label3);
            this.z1.Controls.Add(this.label2);
            this.z1.Controls.Add(this.txtUserName);
            this.z1.Location = new System.Drawing.Point(7, 73);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(654, 98);
            this.z1.TabIndex = 12;
            // 
            // rdoPersonName
            // 
            this.rdoPersonName.AutoSize = true;
            this.rdoPersonName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoPersonName.ForeColor = System.Drawing.Color.Black;
            this.rdoPersonName.Location = new System.Drawing.Point(10, 38);
            this.rdoPersonName.Name = "rdoPersonName";
            this.rdoPersonName.Size = new System.Drawing.Size(91, 18);
            this.rdoPersonName.TabIndex = 410;
            this.rdoPersonName.Text = "Person Name";
            this.rdoPersonName.UseVisualStyleBackColor = true;
            // 
            // rdoUserName
            // 
            this.rdoUserName.AutoSize = true;
            this.rdoUserName.Checked = true;
            this.rdoUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdoUserName.ForeColor = System.Drawing.Color.Black;
            this.rdoUserName.Location = new System.Drawing.Point(10, 8);
            this.rdoUserName.Name = "rdoUserName";
            this.rdoUserName.Size = new System.Drawing.Size(81, 18);
            this.rdoUserName.TabIndex = 410;
            this.rdoUserName.TabStop = true;
            this.rdoUserName.Text = "User Name";
            this.rdoUserName.UseVisualStyleBackColor = true;
            this.rdoUserName.CheckedChanged += new System.EventHandler(this.rdoUserName_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(492, 65);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 25);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(366, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 409;
            this.label1.Text = "Email2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(366, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 409;
            this.label4.Text = "Email1";
            // 
            // txtPersonName
            // 
            this.txtPersonName.Enabled = false;
            this.txtPersonName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonName.Location = new System.Drawing.Point(101, 36);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(242, 22);
            this.txtPersonName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.add;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(566, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "  Add";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(418, 65);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 25);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtMobile2
            // 
            this.txtMobile2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile2.Location = new System.Drawing.Point(250, 64);
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Size = new System.Drawing.Size(93, 22);
            this.txtMobile2.TabIndex = 3;
            // 
            // txtMobile1
            // 
            this.txtMobile1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile1.Location = new System.Drawing.Point(101, 64);
            this.txtMobile1.Name = "txtMobile1";
            this.txtMobile1.Size = new System.Drawing.Size(93, 22);
            this.txtMobile1.TabIndex = 2;
            // 
            // txtEmail2
            // 
            this.txtEmail2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail2.Location = new System.Drawing.Point(424, 36);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(213, 22);
            this.txtEmail2.TabIndex = 5;
            // 
            // txtEmail1
            // 
            this.txtEmail1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail1.Location = new System.Drawing.Point(424, 8);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(213, 22);
            this.txtEmail1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(197, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 108;
            this.label3.Text = "Mobile 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(27, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 108;
            this.label2.Text = "Mobile 1";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(101, 8);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(242, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.DoubleClick += new System.EventHandler(this.txtUserName_DoubleClick);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupName_KeyDown);
            // 
            // lblSettingID
            // 
            this.lblSettingID.AutoSize = true;
            this.lblSettingID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSettingID.Location = new System.Drawing.Point(87, 282);
            this.lblSettingID.Name = "lblSettingID";
            this.lblSettingID.Size = new System.Drawing.Size(56, 14);
            this.lblSettingID.TabIndex = 72;
            this.lblSettingID.Text = "Setting ID";
            // 
            // lblAlertName
            // 
            this.lblAlertName.AutoSize = true;
            this.lblAlertName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertName.ForeColor = System.Drawing.Color.Black;
            this.lblAlertName.Location = new System.Drawing.Point(27, 8);
            this.lblAlertName.Name = "lblAlertName";
            this.lblAlertName.Size = new System.Drawing.Size(64, 14);
            this.lblAlertName.TabIndex = 104;
            this.lblAlertName.Text = "Alert Name";
            // 
            // txtAlertName
            // 
            this.txtAlertName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAlertName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlertName.Location = new System.Drawing.Point(101, 5);
            this.txtAlertName.Name = "txtAlertName";
            this.txtAlertName.ReadOnly = true;
            this.txtAlertName.Size = new System.Drawing.Size(242, 22);
            this.txtAlertName.TabIndex = 0;
            this.txtAlertName.DoubleClick += new System.EventHandler(this.txtAlertName_DoubleClick);
            this.txtAlertName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupName_KeyDown);
            // 
            // txtSettingID
            // 
            this.txtSettingID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtSettingID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingID.Location = new System.Drawing.Point(174, 278);
            this.txtSettingID.Name = "txtSettingID";
            this.txtSettingID.Size = new System.Drawing.Size(120, 22);
            this.txtSettingID.TabIndex = 0;
            this.txtSettingID.DoubleClick += new System.EventHandler(this.txtSettingID_DoubleClick);
            this.txtSettingID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            // 
            // x1
            // 
            this.x1.BackColor = System.Drawing.Color.Transparent;
            this.x1.Controls.Add(this.txtAlertName);
            this.x1.Controls.Add(this.lblAlertName);
            this.x1.Location = new System.Drawing.Point(7, 33);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(351, 34);
            this.x1.TabIndex = 410;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(368, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 127);
            this.panel1.TabIndex = 436;
            // 
            // frm_Alert_Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.txtSettingID);
            this.Controls.Add(this.lblSettingID);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_Alert_Configuration";
            this.Text = "Alert Configuration Master";
            this.Load += new System.EventHandler(this.frm_masAlertConfiguration_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrUser_KeyDown);
            this.Controls.SetChildIndex(this.lblSettingID, 0);
            this.Controls.SetChildIndex(this.txtSettingID, 0);
            this.Controls.SetChildIndex(this.z1, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.x1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.z1.ResumeLayout(false);
            this.z1.PerformLayout();
            this.x1.ResumeLayout(false);
            this.x1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel z1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobile1;
        private System.Windows.Forms.TextBox txtEmail1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSettingID;
        private System.Windows.Forms.TextBox txtSettingID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label lblAlertName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtAlertName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobile2;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel x1;
        private System.Windows.Forms.RadioButton rdoPersonName;
        private System.Windows.Forms.RadioButton rdoUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn settingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn alertName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn personName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userEmail1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userEmail2;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNo2;



    }
}