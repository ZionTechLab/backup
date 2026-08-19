namespace Digiteq.Master_Forms
{
    partial class frm_securityConfigStatus
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConfigTypeStatusID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTypeStatusName = new System.Windows.Forms.TextBox();
            this.txtStatusID = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblTypeValueID = new System.Windows.Forms.Label();
            this.dgvDetail = new SEACC_DataGrid();
            this.StatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rdbTrue = new System.Windows.Forms.RadioButton();
            this.rdbFalse = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdbFalse);
            this.panel1.Controls.Add(this.rdbTrue);
            this.panel1.Controls.Add(this.txtConfigTypeStatusID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTypeStatusName);
            this.panel1.Controls.Add(this.txtStatusID);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.lblTypeValue);
            this.panel1.Controls.Add(this.lblTypeValueID);
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 118);
            this.panel1.TabIndex = 21;
            // 
            // txtConfigTypeStatusID
            // 
            this.txtConfigTypeStatusID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtConfigTypeStatusID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigTypeStatusID.Location = new System.Drawing.Point(90, 31);
            this.txtConfigTypeStatusID.Name = "txtConfigTypeStatusID";
            this.txtConfigTypeStatusID.Size = new System.Drawing.Size(120, 22);
            this.txtConfigTypeStatusID.TabIndex = 7;
            this.txtConfigTypeStatusID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfigTypeStatusID_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status Type ID";
            // 
            // txtTypeStatusName
            // 
            this.txtTypeStatusName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeStatusName.Location = new System.Drawing.Point(89, 55);
            this.txtTypeStatusName.Name = "txtTypeStatusName";
            this.txtTypeStatusName.Size = new System.Drawing.Size(199, 22);
            this.txtTypeStatusName.TabIndex = 4;
            // 
            // txtStatusID
            // 
            this.txtStatusID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtStatusID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusID.Location = new System.Drawing.Point(90, 7);
            this.txtStatusID.Name = "txtStatusID";
            this.txtStatusID.Size = new System.Drawing.Size(120, 22);
            this.txtStatusID.TabIndex = 3;
            this.txtStatusID.DoubleClick += new System.EventHandler(this.txtStatusID_DoubleClick);
            this.txtStatusID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStatusID_KeyDown);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRemark.Location = new System.Drawing.Point(4, 80);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(38, 14);
            this.lblRemark.TabIndex = 2;
            this.lblRemark.Text = "Status";
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.AutoSize = true;
            this.lblTypeValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTypeValue.Location = new System.Drawing.Point(4, 57);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(71, 14);
            this.lblTypeValue.TabIndex = 1;
            this.lblTypeValue.Text = "Status Name";
            // 
            // lblTypeValueID
            // 
            this.lblTypeValueID.AutoSize = true;
            this.lblTypeValueID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeValueID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTypeValueID.Location = new System.Drawing.Point(5, 12);
            this.lblTypeValueID.Name = "lblTypeValueID";
            this.lblTypeValueID.Size = new System.Drawing.Size(52, 14);
            this.lblTypeValueID.TabIndex = 0;
            this.lblTypeValueID.Text = "Status ID";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusID,
            this.StatusName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(6, 157);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(299, 190);
            this.dgvDetail.TabIndex = 25;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // StatusID
            // 
            this.StatusID.HeaderText = "Status ID";
            this.StatusID.Name = "StatusID";
            this.StatusID.Width = 93;
            // 
            // StatusName
            // 
            this.StatusName.HeaderText = "Status Name";
            this.StatusName.Name = "StatusName";
            this.StatusName.Width = 203;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(68, 127);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = " New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(149, 127);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = " Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(230, 127);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdbTrue
            // 
            this.rdbTrue.AccessibleName = "Status";
            this.rdbTrue.AutoSize = true;
            this.rdbTrue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdbTrue.Location = new System.Drawing.Point(87, 84);
            this.rdbTrue.Name = "rdbTrue";
            this.rdbTrue.Size = new System.Drawing.Size(46, 18);
            this.rdbTrue.TabIndex = 8;
            this.rdbTrue.TabStop = true;
            this.rdbTrue.Text = "True";
            this.rdbTrue.UseVisualStyleBackColor = true;
            // 
            // rdbFalse
            // 
            this.rdbFalse.AccessibleName = "Status";
            this.rdbFalse.AutoSize = true;
            this.rdbFalse.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.rdbFalse.Location = new System.Drawing.Point(142, 84);
            this.rdbFalse.Name = "rdbFalse";
            this.rdbFalse.Size = new System.Drawing.Size(51, 18);
            this.rdbFalse.TabIndex = 9;
            this.rdbFalse.TabStop = true;
            this.rdbFalse.Text = "False";
            this.rdbFalse.UseVisualStyleBackColor = true;
            // 
            // frm_securityConfigStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(312, 355);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_securityConfigStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Config Status";
            this.Load += new System.EventHandler(this.frm_securityConfigStatus_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_securityConfigStatus_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtConfigTypeStatusID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTypeStatusName;
        private System.Windows.Forms.TextBox txtStatusID;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblTypeValueID;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusName;
        private System.Windows.Forms.RadioButton rdbFalse;
        private System.Windows.Forms.RadioButton rdbTrue;
    }
}