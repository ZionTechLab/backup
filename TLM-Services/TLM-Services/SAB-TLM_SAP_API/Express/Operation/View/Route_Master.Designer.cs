namespace Express.UI.Operation.View
{
    partial class Route_Master
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.txtRouteCode = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdRouteMaster = new System.Windows.Forms.DataGridView();
            this.SvcRootID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SvcRootName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataManipulate1 = new Express.UI.Common.CustomControl.DataManipulate();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRouteMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Controls.Add(this.txtRouteName);
            this.groupBox3.Controls.Add(this.txtRouteCode);
            this.groupBox3.Controls.Add(this.chkActive);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(9, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 100);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(89, 72);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(455, 20);
            this.txtRemarks.TabIndex = 2;
            // 
            // txtRouteName
            // 
            this.txtRouteName.Location = new System.Drawing.Point(89, 46);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(455, 20);
            this.txtRouteName.TabIndex = 2;
            // 
            // txtRouteCode
            // 
            this.txtRouteCode.Location = new System.Drawing.Point(90, 20);
            this.txtRouteCode.Name = "txtRouteCode";
            this.txtRouteCode.Size = new System.Drawing.Size(100, 20);
            this.txtRouteCode.TabIndex = 2;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(554, 22);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 1;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Route Name * :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Route Code * :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Remarks :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdRouteMaster);
            this.groupBox2.Location = new System.Drawing.Point(9, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 273);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // grdRouteMaster
            // 
            this.grdRouteMaster.AllowUserToAddRows = false;
            this.grdRouteMaster.AllowUserToDeleteRows = false;
            this.grdRouteMaster.AllowUserToResizeColumns = false;
            this.grdRouteMaster.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.grdRouteMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRouteMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdRouteMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRouteMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SvcRootID,
            this.SvcRootName,
            this.Remarks,
            this.Active,
            this.ss});
            this.grdRouteMaster.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRouteMaster.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdRouteMaster.EnableHeadersVisualStyles = false;
            this.grdRouteMaster.Location = new System.Drawing.Point(6, 11);
            this.grdRouteMaster.MultiSelect = false;
            this.grdRouteMaster.Name = "grdRouteMaster";
            this.grdRouteMaster.ReadOnly = true;
            this.grdRouteMaster.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdRouteMaster.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdRouteMaster.RowTemplate.Height = 20;
            this.grdRouteMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRouteMaster.Size = new System.Drawing.Size(602, 255);
            this.grdRouteMaster.TabIndex = 5;
            this.grdRouteMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRouteMaster_CellClick);
            // 
            // SvcRootID
            // 
            this.SvcRootID.DataPropertyName = "SvcRootID";
            this.SvcRootID.HeaderText = "Route Code";
            this.SvcRootID.Name = "SvcRootID";
            this.SvcRootID.ReadOnly = true;
            // 
            // SvcRootName
            // 
            this.SvcRootName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SvcRootName.DataPropertyName = "SvcRootName";
            this.SvcRootName.HeaderText = "Route Name";
            this.SvcRootName.Name = "SvcRootName";
            this.SvcRootName.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.FillWeight = 75F;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 64;
            // 
            // ss
            // 
            this.ss.DataPropertyName = "CMPY";
            this.ss.HeaderText = "CMPY";
            this.ss.Name = "ss";
            this.ss.ReadOnly = true;
            this.ss.Visible = false;
            // 
            // dataManipulate1
            // 
            this.dataManipulate1.Location = new System.Drawing.Point(198, 387);
            this.dataManipulate1.Name = "dataManipulate1";
            this.dataManipulate1.Size = new System.Drawing.Size(623, 46);
            this.dataManipulate1.TabIndex = 11;
            // 
            // Route_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 435);
            this.Controls.Add(this.dataManipulate1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Route_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Route Master";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRouteMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdRouteMaster;
        private System.Windows.Forms.CheckBox chkActive;
        private Common.CustomControl.DataManipulate dataManipulate1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.TextBox txtRouteCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SvcRootID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SvcRootName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn ss;
    }
}