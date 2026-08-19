namespace SEACC_PTS
{
    partial class frm_PickBox
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
            this.txtFillter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.lblHeader = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.userControl11 = new SEACC_PTS.ucTittleBar();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFillter
            // 
            this.txtFillter.BackColor = System.Drawing.Color.White;
            this.txtFillter.ForeColor = System.Drawing.Color.Black;
            this.txtFillter.Location = new System.Drawing.Point(178, 44);
            this.txtFillter.Name = "txtFillter";
            this.txtFillter.Size = new System.Drawing.Size(148, 22);
            this.txtFillter.TabIndex = 18;
            this.txtFillter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFillter_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Filter By";
            // 
            // cbxSearch
            // 
            this.cbxSearch.BackColor = System.Drawing.Color.White;
            this.cbxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearch.ForeColor = System.Drawing.Color.Black;
            this.cbxSearch.Location = new System.Drawing.Point(64, 44);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(108, 21);
            this.cbxSearch.TabIndex = 17;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.Location = new System.Drawing.Point(10, 10);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(315, 306);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            this.dgv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv1_KeyDown);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(8, 7);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(58, 20);
            this.lblHeader.TabIndex = 14;
            this.lblHeader.Text = "Header";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(335, 18);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 16);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cbxSearch);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtFillter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 73);
            this.panel2.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.userControl11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 38);
            this.panel1.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.ForeColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(8, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(315, 1);
            this.panel4.TabIndex = 15;
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(305, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 38);
            this.btn_Close.TabIndex = 21;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(0, 3);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(335, 33);
            this.userControl11.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(335, 326);
            this.panel3.TabIndex = 22;
            // 
            // frm_PickBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(335, 417);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_PickBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_PickBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.TextBox txtFillter;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cbxSearch;
        public ucTittleBar userControl11;
        public System.Windows.Forms.DataGridView dgv1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;

         public  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 ;
          public  System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 ;
          public System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3;
          public System.Windows.Forms.Panel panel4;
          public System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.Button btn_Close;
}
}