namespace Digiteq
{
    partial class frmDateSettings
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
            this.label4 = new System.Windows.Forms.Label();
            this.chkActivate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxBackwardDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxForwardDays = new System.Windows.Forms.TextBox();
            this.lblProcessNoteID = new System.Windows.Forms.Label();
            this.txtProcessNoteID = new System.Windows.Forms.TextBox();
            this.dgvDetail = new SEACC_DataGrid();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ProcessNoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxFowardDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxBackwardDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zpanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // zpanel4
            // 
            this.zpanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.zpanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zpanel4.Controls.Add(this.label4);
            this.zpanel4.Controls.Add(this.chkActivate);
            this.zpanel4.Controls.Add(this.label3);
            this.zpanel4.Controls.Add(this.txtMaxBackwardDays);
            this.zpanel4.Controls.Add(this.label2);
            this.zpanel4.Controls.Add(this.txtMaxForwardDays);
            this.zpanel4.Controls.Add(this.lblProcessNoteID);
            this.zpanel4.Controls.Add(this.txtProcessNoteID);
            this.zpanel4.Location = new System.Drawing.Point(6, 6);
            this.zpanel4.Name = "zpanel4";
            this.zpanel4.Size = new System.Drawing.Size(404, 108);
            this.zpanel4.TabIndex = 465;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(246, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 468;
            this.label4.Text = "Status";
            // 
            // chkActivate
            // 
            this.chkActivate.AutoSize = true;
            this.chkActivate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.chkActivate.Location = new System.Drawing.Point(310, 45);
            this.chkActivate.Name = "chkActivate";
            this.chkActivate.Size = new System.Drawing.Size(71, 19);
            this.chkActivate.TabIndex = 467;
            this.chkActivate.Text = "Activate";
            this.chkActivate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 458;
            this.label3.Text = "Backward Days";
            // 
            // txtMaxBackwardDays
            // 
            this.txtMaxBackwardDays.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxBackwardDays.Location = new System.Drawing.Point(124, 74);
            this.txtMaxBackwardDays.Name = "txtMaxBackwardDays";
            this.txtMaxBackwardDays.Size = new System.Drawing.Size(91, 23);
            this.txtMaxBackwardDays.TabIndex = 459;
            this.txtMaxBackwardDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxBackwardDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxBackwardDays_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 456;
            this.label2.Text = "Forwad Days";
            // 
            // txtMaxForwardDays
            // 
            this.txtMaxForwardDays.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxForwardDays.Location = new System.Drawing.Point(124, 43);
            this.txtMaxForwardDays.Name = "txtMaxForwardDays";
            this.txtMaxForwardDays.Size = new System.Drawing.Size(91, 23);
            this.txtMaxForwardDays.TabIndex = 457;
            this.txtMaxForwardDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxForwardDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxForwardDays_KeyPress);
            // 
            // lblProcessNoteID
            // 
            this.lblProcessNoteID.AutoSize = true;
            this.lblProcessNoteID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessNoteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblProcessNoteID.Location = new System.Drawing.Point(10, 12);
            this.lblProcessNoteID.Name = "lblProcessNoteID";
            this.lblProcessNoteID.Size = new System.Drawing.Size(71, 15);
            this.lblProcessNoteID.TabIndex = 454;
            this.lblProcessNoteID.Text = "Note Name";
            // 
            // txtProcessNoteID
            // 
            this.txtProcessNoteID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtProcessNoteID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessNoteID.Location = new System.Drawing.Point(124, 12);
            this.txtProcessNoteID.Name = "txtProcessNoteID";
            this.txtProcessNoteID.ReadOnly = true;
            this.txtProcessNoteID.Size = new System.Drawing.Size(257, 23);
            this.txtProcessNoteID.TabIndex = 455;
            this.txtProcessNoteID.DoubleClick += new System.EventHandler(this.txtProcessNoteID_DoubleClick);
            this.txtProcessNoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcessNoteID_KeyDown);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessNoteID,
            this.MaxFowardDays,
            this.MaxBackwardDays});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(6, 154);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(404, 240);
            this.dgvDetail.TabIndex = 469;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(258, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 472;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(181, 121);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 471;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(335, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 470;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProcessNoteID
            // 
            this.ProcessNoteID.HeaderText = "Note Name";
            this.ProcessNoteID.Name = "ProcessNoteID";
            this.ProcessNoteID.Width = 200;
            // 
            // MaxFowardDays
            // 
            this.MaxFowardDays.HeaderText = "Foward Days";
            this.MaxFowardDays.Name = "MaxFowardDays";
            // 
            // MaxBackwardDays
            // 
            this.MaxBackwardDays.HeaderText = "Backward Days";
            this.MaxBackwardDays.Name = "MaxBackwardDays";
            // 
            // frmDateSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(416, 400);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.zpanel4);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmDateSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDateSettings";
            this.Load += new System.EventHandler(this.frmDateSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDateSettings_KeyDown);
            this.zpanel4.ResumeLayout(false);
            this.zpanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel zpanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkActivate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxBackwardDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxForwardDays;
        private System.Windows.Forms.Label lblProcessNoteID;
        private System.Windows.Forms.TextBox txtProcessNoteID;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessNoteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxFowardDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxBackwardDays;
    }
}