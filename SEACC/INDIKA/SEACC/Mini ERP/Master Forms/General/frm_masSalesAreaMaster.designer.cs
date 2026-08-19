namespace Digiteq
{
    partial class frm_masSalesAreaMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDetail = new Digiteq.SEACC_DataGrid();
            this.RouteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkLockArrea = new System.Windows.Forms.CheckBox();
            this.lblRouteID = new System.Windows.Forms.Label();
            this.lblRouteName = new System.Windows.Forms.Label();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.txtRouteID = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvTown = new Digiteq.SEACC_DataGrid();
            this.TownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.txtSalesRepID = new System.Windows.Forms.TextBox();
            this.txtSalesManagerID = new System.Windows.Forms.TextBox();
            this.txtAreaManagerID = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTown)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Digiteq.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(471, 428);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "    Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RouteID,
            this.RouteCode,
            this.RouteName});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(9, 37);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(340, 416);
            this.dgvDetail.TabIndex = 10;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // RouteID
            // 
            this.RouteID.HeaderText = "Area ID";
            this.RouteID.Name = "RouteID";
            this.RouteID.ReadOnly = true;
            this.RouteID.Visible = false;
            // 
            // RouteCode
            // 
            this.RouteCode.HeaderText = "Area Code";
            this.RouteCode.Name = "RouteCode";
            this.RouteCode.ReadOnly = true;
            // 
            // RouteName
            // 
            this.RouteName.HeaderText = "Area Name";
            this.RouteName.Name = "RouteName";
            this.RouteName.ReadOnly = true;
            this.RouteName.Width = 220;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label57);
            this.panel2.Controls.Add(this.chkLockArrea);
            this.panel2.Controls.Add(this.txtSalesRepID);
            this.panel2.Controls.Add(this.lblRouteID);
            this.panel2.Controls.Add(this.txtSalesManagerID);
            this.panel2.Controls.Add(this.txtAreaManagerID);
            this.panel2.Controls.Add(this.lblRouteName);
            this.panel2.Controls.Add(this.label58);
            this.panel2.Controls.Add(this.txtRouteName);
            this.panel2.Controls.Add(this.label59);
            this.panel2.Controls.Add(this.txtRouteID);
            this.panel2.Location = new System.Drawing.Point(355, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 201);
            this.panel2.TabIndex = 7;
            // 
            // chkLockArrea
            // 
            this.chkLockArrea.AutoSize = true;
            this.chkLockArrea.Location = new System.Drawing.Point(85, 55);
            this.chkLockArrea.Name = "chkLockArrea";
            this.chkLockArrea.Size = new System.Drawing.Size(75, 17);
            this.chkLockArrea.TabIndex = 105;
            this.chkLockArrea.Text = "Lock Area";
            this.chkLockArrea.UseVisualStyleBackColor = true;
            // 
            // lblRouteID
            // 
            this.lblRouteID.AutoSize = true;
            this.lblRouteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRouteID.ForeColor = System.Drawing.Color.Black;
            this.lblRouteID.Location = new System.Drawing.Point(28, 7);
            this.lblRouteID.Name = "lblRouteID";
            this.lblRouteID.Size = new System.Drawing.Size(57, 14);
            this.lblRouteID.TabIndex = 72;
            this.lblRouteID.Text = "Area Code";
            // 
            // lblRouteName
            // 
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRouteName.ForeColor = System.Drawing.Color.Black;
            this.lblRouteName.Location = new System.Drawing.Point(22, 30);
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Size = new System.Drawing.Size(63, 14);
            this.lblRouteName.TabIndex = 104;
            this.lblRouteName.Text = "Area Name";
            // 
            // txtRouteName
            // 
            this.txtRouteName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteName.Location = new System.Drawing.Point(85, 27);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(196, 22);
            this.txtRouteName.TabIndex = 1;
            this.txtRouteName.Text = "Plastic Bag";
            // 
            // txtRouteID
            // 
            this.txtRouteID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRouteID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteID.Location = new System.Drawing.Point(85, 4);
            this.txtRouteID.Name = "txtRouteID";
            this.txtRouteID.Size = new System.Drawing.Size(195, 22);
            this.txtRouteID.TabIndex = 0;
            this.txtRouteID.DoubleClick += new System.EventHandler(this.txtRouteID_DoubleClick);
            this.txtRouteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRouteID_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(390, 428);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(551, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvTown
            // 
            this.dgvTown.AllowUserToAddRows = false;
            this.dgvTown.AllowUserToDeleteRows = false;
            this.dgvTown.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvTown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTown.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TownID});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTown.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTown.EnableHeadersVisualStyles = false;
            this.dgvTown.Location = new System.Drawing.Point(655, 75);
            this.dgvTown.MultiSelect = false;
            this.dgvTown.Name = "dgvTown";
            this.dgvTown.ReadOnly = true;
            this.dgvTown.RowHeadersVisible = false;
            this.dgvTown.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTown.Size = new System.Drawing.Size(271, 378);
            this.dgvTown.TabIndex = 12;
            // 
            // TownID
            // 
            this.TownID.DataPropertyName = "TownID";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TownID.DefaultCellStyle = dataGridViewCellStyle9;
            this.TownID.HeaderText = "Town";
            this.TownID.Name = "TownID";
            this.TownID.ReadOnly = true;
            this.TownID.Width = 250;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemove.Location = new System.Drawing.Point(866, 44);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(25, 25);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGray;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.Location = new System.Drawing.Point(897, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTown
            // 
            this.txtTown.Location = new System.Drawing.Point(685, 241);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(100, 22);
            this.txtTown.TabIndex = 15;
            this.txtTown.Visible = false;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.Location = new System.Drawing.Point(8, 110);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(77, 14);
            this.label57.TabIndex = 471;
            this.label57.Text = "Area Manager";
            // 
            // txtSalesRepID
            // 
            this.txtSalesRepID.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesRepID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRepID.Location = new System.Drawing.Point(85, 128);
            this.txtSalesRepID.Name = "txtSalesRepID";
            this.txtSalesRepID.ReadOnly = true;
            this.txtSalesRepID.Size = new System.Drawing.Size(196, 22);
            this.txtSalesRepID.TabIndex = 468;
            this.txtSalesRepID.DoubleClick += new System.EventHandler(this.txtSalesRepID_DoubleClick);
            // 
            // txtSalesManagerID
            // 
            this.txtSalesManagerID.BackColor = System.Drawing.Color.LightGray;
            this.txtSalesManagerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesManagerID.Location = new System.Drawing.Point(85, 78);
            this.txtSalesManagerID.Name = "txtSalesManagerID";
            this.txtSalesManagerID.ReadOnly = true;
            this.txtSalesManagerID.Size = new System.Drawing.Size(195, 22);
            this.txtSalesManagerID.TabIndex = 466;
            this.txtSalesManagerID.DoubleClick += new System.EventHandler(this.txtSalesManagerID_DoubleClick);
            // 
            // txtAreaManagerID
            // 
            this.txtAreaManagerID.BackColor = System.Drawing.Color.LightGray;
            this.txtAreaManagerID.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaManagerID.Location = new System.Drawing.Point(85, 103);
            this.txtAreaManagerID.Name = "txtAreaManagerID";
            this.txtAreaManagerID.ReadOnly = true;
            this.txtAreaManagerID.Size = new System.Drawing.Size(195, 22);
            this.txtAreaManagerID.TabIndex = 467;
            this.txtAreaManagerID.DoubleClick += new System.EventHandler(this.txtAreaManagerID_DoubleClick);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Black;
            this.label58.Location = new System.Drawing.Point(22, 86);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(63, 14);
            this.label58.TabIndex = 470;
            this.label58.Text = "S. Manager";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(28, 136);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(56, 13);
            this.label59.TabIndex = 469;
            this.label59.Text = "SalesMen";
            // 
            // frm_masSalesAreaMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 467);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dgvTown);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtTown);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_masSalesAreaMaster";
            this.Text = "Sales Area Master";
            this.Load += new System.EventHandler(this.frm_mtrRoute_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_mtrRoute_KeyDown);
            this.Controls.SetChildIndex(this.txtTown, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.dgvTown, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private SEACC_DataGrid dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRouteID;
        private System.Windows.Forms.Label lblRouteName;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.TextBox txtRouteID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private SEACC_DataGrid dgvTown;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn TownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteName;
        private System.Windows.Forms.CheckBox chkLockArrea;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtSalesRepID;
        private System.Windows.Forms.TextBox txtSalesManagerID;
        private System.Windows.Forms.TextBox txtAreaManagerID;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
    }
}