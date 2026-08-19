namespace Digiteq.Transaction_Forms.COM
{
    partial class frm_masComPercentageDefinition_Collectors
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
            this.dgvCollectors = new SEACC_DataGrid();
            this.txtCol1 = new System.Windows.Forms.TextBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.txtPer1 = new System.Windows.Forms.TextBox();
            this.txtPer2 = new System.Windows.Forms.TextBox();
            this.txtCol2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColID_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPer_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColID_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPer_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollectors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // dgvCollectors
            // 
            this.dgvCollectors.AllowUserToAddRows = false;
            this.dgvCollectors.AllowUserToDeleteRows = false;
            this.dgvCollectors.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvCollectors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCollectors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCollectors.ColumnHeadersHeight = 27;
            this.dgvCollectors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ColID_1,
            this.Col_1,
            this.ColPer_1,
            this.ColID_2,
            this.Col_2,
            this.ColPer_2,
            this.Active});
            this.dgvCollectors.EnableHeadersVisualStyles = false;
            this.dgvCollectors.Location = new System.Drawing.Point(12, 42);
            this.dgvCollectors.MultiSelect = false;
            this.dgvCollectors.Name = "dgvCollectors";
            this.dgvCollectors.ReadOnly = true;
            this.dgvCollectors.RowHeadersVisible = false;
            this.dgvCollectors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCollectors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCollectors.Size = new System.Drawing.Size(576, 257);
            this.dgvCollectors.TabIndex = 441;
            this.dgvCollectors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCollectors_CellClick);
            this.dgvCollectors.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCollectors_CellContentClick);
            // 
            // txtCol1
            // 
            this.txtCol1.BackColor = System.Drawing.Color.LightGray;
            this.txtCol1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCol1.Location = new System.Drawing.Point(666, 48);
            this.txtCol1.Name = "txtCol1";
            this.txtCol1.ReadOnly = true;
            this.txtCol1.Size = new System.Drawing.Size(166, 22);
            this.txtCol1.TabIndex = 442;
            this.txtCol1.DoubleClick += new System.EventHandler(this.txtCol1_DoubleClick);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.Color.Black;
            this.lblPeriod.Location = new System.Drawing.Point(599, 52);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(59, 14);
            this.lblPeriod.TabIndex = 443;
            this.lblPeriod.Text = "Collector 1";
            // 
            // txtPer1
            // 
            this.txtPer1.BackColor = System.Drawing.Color.LightGray;
            this.txtPer1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPer1.Location = new System.Drawing.Point(838, 48);
            this.txtPer1.Name = "txtPer1";
            this.txtPer1.Size = new System.Drawing.Size(34, 22);
            this.txtPer1.TabIndex = 444;
            this.txtPer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPer2
            // 
            this.txtPer2.BackColor = System.Drawing.Color.LightGray;
            this.txtPer2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPer2.Location = new System.Drawing.Point(838, 89);
            this.txtPer2.Name = "txtPer2";
            this.txtPer2.Size = new System.Drawing.Size(34, 22);
            this.txtPer2.TabIndex = 447;
            this.txtPer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCol2
            // 
            this.txtCol2.BackColor = System.Drawing.Color.LightGray;
            this.txtCol2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCol2.Location = new System.Drawing.Point(666, 89);
            this.txtCol2.Name = "txtCol2";
            this.txtCol2.ReadOnly = true;
            this.txtCol2.Size = new System.Drawing.Size(166, 22);
            this.txtCol2.TabIndex = 445;
            this.txtCol2.DoubleClick += new System.EventHandler(this.txtCol2_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(599, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 446;
            this.label1.Text = "Collector 2";
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(740, 161);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(73, 25);
            this.btnNew.TabIndex = 459;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(819, 161);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 25);
            this.btnSave.TabIndex = 458;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.ForeColor = System.Drawing.Color.Black;
            this.chkActive.Location = new System.Drawing.Point(820, 126);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 460;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(878, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 14);
            this.label2.TabIndex = 461;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(878, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 14);
            this.label3.TabIndex = 462;
            this.label3.Text = "%";
            // 
            // No
            // 
            this.No.DataPropertyName = "p_ID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.No.DefaultCellStyle = dataGridViewCellStyle1;
            this.No.HeaderText = "#";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 30;
            // 
            // ColID_1
            // 
            this.ColID_1.DataPropertyName = "collector_ID1";
            this.ColID_1.HeaderText = "ID 1";
            this.ColID_1.Name = "ColID_1";
            this.ColID_1.ReadOnly = true;
            this.ColID_1.Visible = false;
            this.ColID_1.Width = 50;
            // 
            // Col_1
            // 
            this.Col_1.DataPropertyName = "collector_1";
            this.Col_1.HeaderText = "Collector 1";
            this.Col_1.Name = "Col_1";
            this.Col_1.ReadOnly = true;
            this.Col_1.Width = 200;
            // 
            // ColPer_1
            // 
            this.ColPer_1.DataPropertyName = "percentage1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColPer_1.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPer_1.HeaderText = "%";
            this.ColPer_1.Name = "ColPer_1";
            this.ColPer_1.ReadOnly = true;
            this.ColPer_1.Width = 40;
            // 
            // ColID_2
            // 
            this.ColID_2.DataPropertyName = "collector_ID2";
            this.ColID_2.HeaderText = "ID 2";
            this.ColID_2.Name = "ColID_2";
            this.ColID_2.ReadOnly = true;
            this.ColID_2.Visible = false;
            this.ColID_2.Width = 50;
            // 
            // Col_2
            // 
            this.Col_2.DataPropertyName = "collector_2";
            this.Col_2.HeaderText = "Collector 2";
            this.Col_2.Name = "Col_2";
            this.Col_2.ReadOnly = true;
            this.Col_2.Width = 200;
            // 
            // ColPer_2
            // 
            this.ColPer_2.DataPropertyName = "percentage2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColPer_2.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColPer_2.HeaderText = "%";
            this.ColPer_2.Name = "ColPer_2";
            this.ColPer_2.ReadOnly = true;
            this.ColPer_2.Width = 40;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "isActive";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 50;
            // 
            // frm_masComPercentageDefinition_Collectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 312);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPer2);
            this.Controls.Add(this.txtCol2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPer1);
            this.Controls.Add(this.txtCol1);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.dgvCollectors);
            this.Name = "frm_masComPercentageDefinition_Collectors";
            this.Text = "Collectors Commission Percentage Definition";
            this.Load += new System.EventHandler(this.frm_masComPercentageDefinition_Collectors_Load);
            this.Controls.SetChildIndex(this.dgvCollectors, 0);
            this.Controls.SetChildIndex(this.lblPeriod, 0);
            this.Controls.SetChildIndex(this.txtCol1, 0);
            this.Controls.SetChildIndex(this.txtPer1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCol2, 0);
            this.Controls.SetChildIndex(this.txtPer2, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.chkActive, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollectors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SEACC_DataGrid dgvCollectors;
        private System.Windows.Forms.TextBox txtCol1;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.TextBox txtPer1;
        private System.Windows.Forms.TextBox txtPer2;
        private System.Windows.Forms.TextBox txtCol2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPer_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPer_2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}