namespace Digiteq
{
    partial class frmManageRoute
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
            this.zpanel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblRouteID = new System.Windows.Forms.Label();
            this.lblRouteName = new System.Windows.Forms.Label();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.txtRouteID = new System.Windows.Forms.TextBox();
            this.xpanel1 = new System.Windows.Forms.Panel();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.txtRowNo1 = new System.Windows.Forms.TextBox();
            this.btnClearContact1 = new System.Windows.Forms.Button();
            this.btnRemoveContact1 = new System.Windows.Forms.Button();
            this.btnAddContact1 = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.RouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.xpanel3 = new System.Windows.Forms.Panel();
            this.txtRowNo2 = new System.Windows.Forms.TextBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lable = new System.Windows.Forms.Label();
            this.btnClearContact2 = new System.Windows.Forms.Button();
            this.btnRemoveContact2 = new System.Windows.Forms.Button();
            this.btnAddContact2 = new System.Windows.Forms.Button();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.ScheduleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScheduleName = new System.Windows.Forms.TextBox();
            this.zpanel2.SuspendLayout();
            this.xpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.xpanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // zpanel2
            // 
            this.zpanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.zpanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel2.Controls.Add(this.btnSave);
            this.zpanel2.Controls.Add(this.btnNew);
            this.zpanel2.Controls.Add(this.lblRouteID);
            this.zpanel2.Controls.Add(this.lblRouteName);
            this.zpanel2.Controls.Add(this.txtRouteName);
            this.zpanel2.Controls.Add(this.txtRouteID);
            this.zpanel2.Location = new System.Drawing.Point(8, 8);
            this.zpanel2.Name = "zpanel2";
            this.zpanel2.Size = new System.Drawing.Size(628, 45);
            this.zpanel2.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(545, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 106;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(466, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 105;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblRouteID
            // 
            this.lblRouteID.AutoSize = true;
            this.lblRouteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRouteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRouteID.Location = new System.Drawing.Point(9, 15);
            this.lblRouteID.Name = "lblRouteID";
            this.lblRouteID.Size = new System.Drawing.Size(50, 14);
            this.lblRouteID.TabIndex = 72;
            this.lblRouteID.Text = "Route ID";
            // 
            // lblRouteName
            // 
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRouteName.ForeColor = System.Drawing.Color.DimGray;
            this.lblRouteName.Location = new System.Drawing.Point(192, 15);
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Size = new System.Drawing.Size(69, 14);
            this.lblRouteName.TabIndex = 104;
            this.lblRouteName.Text = "Route Name";
            // 
            // txtRouteName
            // 
            this.txtRouteName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteName.Location = new System.Drawing.Point(262, 11);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.ReadOnly = true;
            this.txtRouteName.Size = new System.Drawing.Size(199, 22);
            this.txtRouteName.TabIndex = 1;
            // 
            // txtRouteID
            // 
            this.txtRouteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtRouteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteID.Location = new System.Drawing.Point(81, 11);
            this.txtRouteID.Name = "txtRouteID";
            this.txtRouteID.Size = new System.Drawing.Size(107, 22);
            this.txtRouteID.TabIndex = 0;
            this.txtRouteID.DoubleClick += new System.EventHandler(this.txtRouteID_DoubleClick);
            this.txtRouteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRouteID_KeyDown);
            // 
            // xpanel1
            // 
            this.xpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.xpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel1.Controls.Add(this.txtTown);
            this.xpanel1.Controls.Add(this.txtRowNo1);
            this.xpanel1.Controls.Add(this.btnClearContact1);
            this.xpanel1.Controls.Add(this.btnRemoveContact1);
            this.xpanel1.Controls.Add(this.btnAddContact1);
            this.xpanel1.Controls.Add(this.dgvDetail);
            this.xpanel1.Controls.Add(this.label1);
            this.xpanel1.Location = new System.Drawing.Point(8, 59);
            this.xpanel1.Name = "xpanel1";
            this.xpanel1.Size = new System.Drawing.Size(311, 248);
            this.xpanel1.TabIndex = 9;
            // 
            // txtTown
            // 
            this.txtTown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtTown.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.Location = new System.Drawing.Point(81, 10);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(220, 22);
            this.txtTown.TabIndex = 110;
            this.txtTown.DoubleClick += new System.EventHandler(this.txtTown_DoubleClick);
            this.txtTown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTown_KeyDown);
            // 
            // txtRowNo1
            // 
            this.txtRowNo1.Location = new System.Drawing.Point(216, 40);
            this.txtRowNo1.Name = "txtRowNo1";
            this.txtRowNo1.Size = new System.Drawing.Size(10, 20);
            this.txtRowNo1.TabIndex = 109;
            this.txtRowNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRowNo1.Visible = false;
            // 
            // btnClearContact1
            // 
            this.btnClearContact1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearContact1.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClearContact1.Location = new System.Drawing.Point(232, 39);
            this.btnClearContact1.Name = "btnClearContact1";
            this.btnClearContact1.Size = new System.Drawing.Size(22, 22);
            this.btnClearContact1.TabIndex = 108;
            this.btnClearContact1.UseVisualStyleBackColor = true;
            this.btnClearContact1.Click += new System.EventHandler(this.btnClearContact1_Click);
            // 
            // btnRemoveContact1
            // 
            this.btnRemoveContact1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveContact1.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemoveContact1.Location = new System.Drawing.Point(255, 39);
            this.btnRemoveContact1.Name = "btnRemoveContact1";
            this.btnRemoveContact1.Size = new System.Drawing.Size(22, 22);
            this.btnRemoveContact1.TabIndex = 107;
            this.btnRemoveContact1.UseVisualStyleBackColor = true;
            this.btnRemoveContact1.Click += new System.EventHandler(this.btnRemoveContact1_Click);
            // 
            // btnAddContact1
            // 
            this.btnAddContact1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContact1.Image = global::Digiteq.Properties.Resources.accept;
            this.btnAddContact1.Location = new System.Drawing.Point(279, 39);
            this.btnAddContact1.Name = "btnAddContact1";
            this.btnAddContact1.Size = new System.Drawing.Size(22, 22);
            this.btnAddContact1.TabIndex = 106;
            this.btnAddContact1.UseVisualStyleBackColor = true;
            this.btnAddContact1.Click += new System.EventHandler(this.btnAddContact1_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RouteName,
            this.TwonName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(-1, 65);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(311, 182);
            this.dgvDetail.TabIndex = 105;
            // 
            // RouteName
            // 
            this.RouteName.HeaderText = "Route Name";
            this.RouteName.Name = "RouteName";
            this.RouteName.Width = 200;
            // 
            // TwonName
            // 
            this.TwonName.HeaderText = "Twon Name";
            this.TwonName.Name = "TwonName";
            this.TwonName.Width = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 72;
            this.label1.Text = "Town Name";
            // 
            // xpanel3
            // 
            this.xpanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.xpanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel3.Controls.Add(this.txtRowNo2);
            this.xpanel3.Controls.Add(this.dtpEndDate);
            this.xpanel3.Controls.Add(this.dtpStartDate);
            this.xpanel3.Controls.Add(this.label4);
            this.xpanel3.Controls.Add(this.lable);
            this.xpanel3.Controls.Add(this.btnClearContact2);
            this.xpanel3.Controls.Add(this.btnRemoveContact2);
            this.xpanel3.Controls.Add(this.btnAddContact2);
            this.xpanel3.Controls.Add(this.dgvSchedule);
            this.xpanel3.Controls.Add(this.label2);
            this.xpanel3.Controls.Add(this.txtScheduleName);
            this.xpanel3.Location = new System.Drawing.Point(325, 59);
            this.xpanel3.Name = "xpanel3";
            this.xpanel3.Size = new System.Drawing.Size(311, 248);
            this.xpanel3.TabIndex = 109;
            // 
            // txtRowNo2
            // 
            this.txtRowNo2.Location = new System.Drawing.Point(210, 65);
            this.txtRowNo2.Name = "txtRowNo2";
            this.txtRowNo2.Size = new System.Drawing.Size(10, 20);
            this.txtRowNo2.TabIndex = 113;
            this.txtRowNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRowNo2.Visible = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(96, 63);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(105, 22);
            this.dtpEndDate.TabIndex = 112;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(96, 36);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(105, 22);
            this.dtpStartDate.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(7, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 110;
            this.label4.Text = "End Date";
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lable.Location = new System.Drawing.Point(7, 40);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(58, 14);
            this.lable.TabIndex = 109;
            this.lable.Text = "Start Date";
            // 
            // btnClearContact2
            // 
            this.btnClearContact2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearContact2.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnClearContact2.Location = new System.Drawing.Point(226, 65);
            this.btnClearContact2.Name = "btnClearContact2";
            this.btnClearContact2.Size = new System.Drawing.Size(22, 22);
            this.btnClearContact2.TabIndex = 108;
            this.btnClearContact2.UseVisualStyleBackColor = true;
            this.btnClearContact2.Click += new System.EventHandler(this.btnClearContact2_Click);
            // 
            // btnRemoveContact2
            // 
            this.btnRemoveContact2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveContact2.Image = global::Digiteq.Properties.Resources.delete;
            this.btnRemoveContact2.Location = new System.Drawing.Point(249, 65);
            this.btnRemoveContact2.Name = "btnRemoveContact2";
            this.btnRemoveContact2.Size = new System.Drawing.Size(22, 22);
            this.btnRemoveContact2.TabIndex = 107;
            this.btnRemoveContact2.UseVisualStyleBackColor = true;
            // 
            // btnAddContact2
            // 
            this.btnAddContact2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContact2.Image = global::Digiteq.Properties.Resources.accept;
            this.btnAddContact2.Location = new System.Drawing.Point(273, 65);
            this.btnAddContact2.Name = "btnAddContact2";
            this.btnAddContact2.Size = new System.Drawing.Size(22, 22);
            this.btnAddContact2.TabIndex = 106;
            this.btnAddContact2.UseVisualStyleBackColor = true;
            this.btnAddContact2.Click += new System.EventHandler(this.btnAddContact2_Click);
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScheduleName,
            this.StartTime,
            this.EndTime,
            this.sRouteName});
            this.dgvSchedule.EnableHeadersVisualStyles = false;
            this.dgvSchedule.Location = new System.Drawing.Point(-1, 92);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(311, 155);
            this.dgvSchedule.TabIndex = 105;
            // 
            // ScheduleName
            // 
            this.ScheduleName.HeaderText = "Schedule Name";
            this.ScheduleName.Name = "ScheduleName";
            this.ScheduleName.Width = 90;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.Visible = false;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            this.EndTime.Visible = false;
            // 
            // sRouteName
            // 
            this.sRouteName.HeaderText = "Route Name";
            this.sRouteName.Name = "sRouteName";
            this.sRouteName.Width = 218;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 72;
            this.label2.Text = "Schedule Name";
            // 
            // txtScheduleName
            // 
            this.txtScheduleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtScheduleName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScheduleName.Location = new System.Drawing.Point(96, 10);
            this.txtScheduleName.Name = "txtScheduleName";
            this.txtScheduleName.Size = new System.Drawing.Size(199, 22);
            this.txtScheduleName.TabIndex = 0;
            this.txtScheduleName.DoubleClick += new System.EventHandler(this.txtScheduleName_DoubleClick);
            this.txtScheduleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScheduleName_KeyDown);
            // 
            // frmManageRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 314);
            this.Controls.Add(this.xpanel3);
            this.Controls.Add(this.xpanel1);
            this.Controls.Add(this.zpanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmManageRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageRoute";
            this.Load += new System.EventHandler(this.frmManageRoute_Load);
            this.zpanel2.ResumeLayout(false);
            this.zpanel2.PerformLayout();
            this.xpanel1.ResumeLayout(false);
            this.xpanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.xpanel3.ResumeLayout(false);
            this.xpanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel zpanel2;
        private System.Windows.Forms.Label lblRouteID;
        private System.Windows.Forms.Label lblRouteName;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.TextBox txtRouteID;
        private System.Windows.Forms.Panel xpanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnClearContact1;
        private System.Windows.Forms.Button btnRemoveContact1;
        private System.Windows.Forms.Button btnAddContact1;
        private System.Windows.Forms.Panel xpanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.Button btnClearContact2;
        private System.Windows.Forms.Button btnRemoveContact2;
        private System.Windows.Forms.Button btnAddContact2;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScheduleName;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtRowNo1;
        private System.Windows.Forms.TextBox txtRowNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRouteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwonName;
        private System.Windows.Forms.TextBox txtTown;
    }
}