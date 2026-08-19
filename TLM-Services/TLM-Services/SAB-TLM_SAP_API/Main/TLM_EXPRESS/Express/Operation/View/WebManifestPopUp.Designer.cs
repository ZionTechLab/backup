namespace Express.UI.Operation.View
{
    partial class WebManifestPopUp
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTrackNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDutyValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDutyExt = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClearenceType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDutyTreshol = new System.Windows.Forms.TextBox();
            this.chkCrdAllow = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbConsolType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbClearStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(401, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 34);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(309, 418);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 34);
            this.btnUpdate.TabIndex = 36;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbStation
            // 
            this.cmbStation.DisplayMember = "StationN";
            this.cmbStation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Location = new System.Drawing.Point(115, 45);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(167, 21);
            this.cmbStation.TabIndex = 35;
            this.cmbStation.ValueMember = "StationID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Station  :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTrackNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDutyValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkDutyExt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbClearenceType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbRoute);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbStation);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 164);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // txtTrackNo
            // 
            this.txtTrackNo.Location = new System.Drawing.Point(115, 23);
            this.txtTrackNo.Name = "txtTrackNo";
            this.txtTrackNo.ReadOnly = true;
            this.txtTrackNo.Size = new System.Drawing.Size(167, 20);
            this.txtTrackNo.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Track Number :";
            // 
            // txtDutyValue
            // 
            this.txtDutyValue.Location = new System.Drawing.Point(115, 133);
            this.txtDutyValue.Name = "txtDutyValue";
            this.txtDutyValue.Size = new System.Drawing.Size(167, 20);
            this.txtDutyValue.TabIndex = 42;
            this.txtDutyValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDutyValue_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Duty Value :";
            // 
            // chkDutyExt
            // 
            this.chkDutyExt.AutoSize = true;
            this.chkDutyExt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDutyExt.Location = new System.Drawing.Point(115, 114);
            this.chkDutyExt.Name = "chkDutyExt";
            this.chkDutyExt.Size = new System.Drawing.Size(93, 17);
            this.chkDutyExt.TabIndex = 40;
            this.chkDutyExt.Text = "Duty Exempt";
            this.chkDutyExt.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Clearance Type  :";
            // 
            // cmbClearenceType
            // 
            this.cmbClearenceType.DisplayMember = "ShipValType";
            this.cmbClearenceType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClearenceType.FormattingEnabled = true;
            this.cmbClearenceType.Location = new System.Drawing.Point(115, 91);
            this.cmbClearenceType.Name = "cmbClearenceType";
            this.cmbClearenceType.Size = new System.Drawing.Size(167, 21);
            this.cmbClearenceType.TabIndex = 39;
            this.cmbClearenceType.ValueMember = "ShipValType";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Route  :";
            // 
            // cmbRoute
            // 
            this.cmbRoute.DisplayMember = "RouteN";
            this.cmbRoute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(115, 68);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(167, 21);
            this.cmbRoute.TabIndex = 37;
            this.cmbRoute.ValueMember = "RouteID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDutyTreshol);
            this.groupBox2.Controls.Add(this.chkCrdAllow);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbConsolType);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 147);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Duty threshold  :";
            // 
            // txtDutyTreshol
            // 
            this.txtDutyTreshol.Location = new System.Drawing.Point(115, 97);
            this.txtDutyTreshol.Name = "txtDutyTreshol";
            this.txtDutyTreshol.Size = new System.Drawing.Size(167, 20);
            this.txtDutyTreshol.TabIndex = 43;
            this.txtDutyTreshol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDutyTreshol_KeyPress);
            // 
            // chkCrdAllow
            // 
            this.chkCrdAllow.AutoSize = true;
            this.chkCrdAllow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCrdAllow.Location = new System.Drawing.Point(115, 78);
            this.chkCrdAllow.Name = "chkCrdAllow";
            this.chkCrdAllow.Size = new System.Drawing.Size(90, 17);
            this.chkCrdAllow.TabIndex = 42;
            this.chkCrdAllow.Text = "Credit Allow";
            this.chkCrdAllow.UseVisualStyleBackColor = true;
            this.chkCrdAllow.CheckedChanged += new System.EventHandler(this.chkCrdAllow_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Console Type :";
            // 
            // cmbConsolType
            // 
            this.cmbConsolType.DisplayMember = "ConsoleTypeN";
            this.cmbConsolType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConsolType.FormattingEnabled = true;
            this.cmbConsolType.Location = new System.Drawing.Point(115, 55);
            this.cmbConsolType.Name = "cmbConsolType";
            this.cmbConsolType.Size = new System.Drawing.Size(167, 21);
            this.cmbConsolType.TabIndex = 41;
            this.cmbConsolType.ValueMember = "ConsoleT";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(195, 22);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(257, 31);
            this.txtName.TabIndex = 33;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(115, 22);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(77, 31);
            this.txtCode.TabIndex = 32;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(456, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 31);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "+";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Customer  :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Clearence Status  :";
            // 
            // cmbClearStatus
            // 
            this.cmbClearStatus.DisplayMember = "ClearStatusN";
            this.cmbClearStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClearStatus.FormattingEnabled = true;
            this.cmbClearStatus.Location = new System.Drawing.Point(115, 19);
            this.cmbClearStatus.Name = "cmbClearStatus";
            this.cmbClearStatus.Size = new System.Drawing.Size(166, 21);
            this.cmbClearStatus.TabIndex = 46;
            this.cmbClearStatus.ValueMember = "ClearStatusID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(49, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Remarks  :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(115, 42);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(337, 34);
            this.txtRemarks.TabIndex = 47;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Controls.Add(this.cmbClearStatus);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 91);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            this.bgWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWork_ProgressChanged);
            this.bgWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWork_RunWorkerCompleted);
            // 
            // WebManifestPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 459);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WebManifestPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Manifest Edit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDutyValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDutyExt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClearenceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbClearStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDutyTreshol;
        private System.Windows.Forms.CheckBox chkCrdAllow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbConsolType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.TextBox txtTrackNo;
        private System.Windows.Forms.Label label10;
    }
}