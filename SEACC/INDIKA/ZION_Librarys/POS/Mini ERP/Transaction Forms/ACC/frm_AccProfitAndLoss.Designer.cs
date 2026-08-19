namespace Digiteq
{
    partial class frm_AccProfitAndLoss
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glSubCatagory_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glSubCatagoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTotal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.deleteRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_PNL = new System.Windows.Forms.TabPage();
            this.tab_BS = new System.Windows.Forms.TabPage();
            this.btnSaveBS = new System.Windows.Forms.Button();
            this.dgvBS = new System.Windows.Forms.DataGridView();
            this.TypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMainCat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsSubCat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tab_PNL.SuspendLayout();
            this.tab_BS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.glSubCatagory_ID,
            this.glSubCatagoryName,
            this.note,
            this.isTotal,
            this.deleteRow});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(6, 6);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(451, 339);
            this.dgvDetail.TabIndex = 527;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            this.dgvDetail.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvDetail_PreviewKeyDown);
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "#";
            this.LineNo.Name = "LineNo";
            this.LineNo.Width = 20;
            // 
            // glSubCatagory_ID
            // 
            this.glSubCatagory_ID.HeaderText = "Sub Catagory ID";
            this.glSubCatagory_ID.Name = "glSubCatagory_ID";
            this.glSubCatagory_ID.ReadOnly = true;
            this.glSubCatagory_ID.Width = 95;
            // 
            // glSubCatagoryName
            // 
            this.glSubCatagoryName.HeaderText = "Sub Catagory Name";
            this.glSubCatagoryName.Name = "glSubCatagoryName";
            this.glSubCatagoryName.Width = 200;
            // 
            // note
            // 
            this.note.HeaderText = "Note";
            this.note.Name = "note";
            this.note.Width = 50;
            // 
            // isTotal
            // 
            this.isTotal.HeaderText = "Total";
            this.isTotal.Name = "isTotal";
            this.isTotal.Width = 50;
            // 
            // deleteRow
            // 
            this.deleteRow.HeaderText = "";
            this.deleteRow.Name = "deleteRow";
            this.deleteRow.Width = 20;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(382, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 529;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(262, 350);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(114, 25);
            this.btnNew.TabIndex = 528;
            this.btnNew.Text = "  Add New Line";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_PNL);
            this.tabControl1.Controls.Add(this.tab_BS);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(470, 405);
            this.tabControl1.TabIndex = 530;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab_PNL
            // 
            this.tab_PNL.Controls.Add(this.dgvDetail);
            this.tab_PNL.Controls.Add(this.btnSave);
            this.tab_PNL.Controls.Add(this.btnNew);
            this.tab_PNL.Location = new System.Drawing.Point(4, 22);
            this.tab_PNL.Name = "tab_PNL";
            this.tab_PNL.Padding = new System.Windows.Forms.Padding(3);
            this.tab_PNL.Size = new System.Drawing.Size(462, 379);
            this.tab_PNL.TabIndex = 0;
            this.tab_PNL.Text = "Profit And Loss";
            this.tab_PNL.UseVisualStyleBackColor = true;
            // 
            // tab_BS
            // 
            this.tab_BS.Controls.Add(this.btnSaveBS);
            this.tab_BS.Controls.Add(this.dgvBS);
            this.tab_BS.Location = new System.Drawing.Point(4, 22);
            this.tab_BS.Name = "tab_BS";
            this.tab_BS.Padding = new System.Windows.Forms.Padding(3);
            this.tab_BS.Size = new System.Drawing.Size(462, 379);
            this.tab_BS.TabIndex = 1;
            this.tab_BS.Text = "Balance Sheet";
            this.tab_BS.UseVisualStyleBackColor = true;
            // 
            // btnSaveBS
            // 
            this.btnSaveBS.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBS.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSaveBS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBS.Location = new System.Drawing.Point(382, 348);
            this.btnSaveBS.Name = "btnSaveBS";
            this.btnSaveBS.Size = new System.Drawing.Size(75, 25);
            this.btnSaveBS.TabIndex = 530;
            this.btnSaveBS.Text = "  Save";
            this.btnSaveBS.UseVisualStyleBackColor = true;
            this.btnSaveBS.Click += new System.EventHandler(this.btnSaveBS_Click);
            // 
            // dgvBS
            // 
            this.dgvBS.AllowUserToAddRows = false;
            this.dgvBS.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvBS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeID,
            this.TypeName,
            this.Notet,
            this.IsMainCat,
            this.IsSubCat,
            this.IsType});
            this.dgvBS.EnableHeadersVisualStyles = false;
            this.dgvBS.Location = new System.Drawing.Point(6, 3);
            this.dgvBS.MultiSelect = false;
            this.dgvBS.Name = "dgvBS";
            this.dgvBS.RowHeadersVisible = false;
            this.dgvBS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBS.Size = new System.Drawing.Size(451, 339);
            this.dgvBS.TabIndex = 528;
            // 
            // TypeID
            // 
            this.TypeID.HeaderText = "Type ID";
            this.TypeID.Name = "TypeID";
            this.TypeID.ReadOnly = true;
            this.TypeID.Width = 50;
            // 
            // TypeName
            // 
            this.TypeName.HeaderText = "Type Name";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Width = 200;
            // 
            // Notet
            // 
            this.Notet.HeaderText = "Note";
            this.Notet.Name = "Notet";
            this.Notet.Width = 50;
            // 
            // IsMainCat
            // 
            this.IsMainCat.HeaderText = "IsMainCat";
            this.IsMainCat.Name = "IsMainCat";
            this.IsMainCat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsMainCat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsMainCat.Visible = false;
            // 
            // IsSubCat
            // 
            this.IsSubCat.HeaderText = "IsSubCat";
            this.IsSubCat.Name = "IsSubCat";
            this.IsSubCat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSubCat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSubCat.Visible = false;
            // 
            // IsType
            // 
            this.IsType.HeaderText = "IsType";
            this.IsType.Name = "IsType";
            this.IsType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsType.Visible = false;
            // 
            // frm_AccProfitAndLoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 437);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_AccProfitAndLoss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Builder";
            this.Load += new System.EventHandler(this.frm_AccProfitAndLoss_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tab_PNL.ResumeLayout(false);
            this.tab_BS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glSubCatagory_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn glSubCatagoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteRow;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_PNL;
        private System.Windows.Forms.TabPage tab_BS;
        private System.Windows.Forms.DataGridView dgvBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notet;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsMainCat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSubCat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsType;
        private System.Windows.Forms.Button btnSaveBS;
    }
}