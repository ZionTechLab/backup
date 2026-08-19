namespace Digiteq
{
    partial class frm_sasMultipleItemSelect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTotalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(94, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "  Save (F10)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(10, 397);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 25);
            this.btnNew.TabIndex = 1;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "  New (F9)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(502, 400);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(80, 23);
            this.txtTotalQty.TabIndex = 4;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(443, 404);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Total Qty";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.ItemName,
            this.ItemSubCategoryID1,
            this.ItemSubCategoryID2,
            this.ItemSerialNo1,
            this.ItemSerialNo2,
            this.QuantityAvailable,
            this.Weight,
            this.Quantity,
            this.UnitPrice,
            this.WeightPrice,
            this.ItemTotalValue,
            this.UOMID});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 12);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(774, 379);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetail_CurrentCellDirtyStateChanged);
            this.dgvDetail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDetail_KeyUp);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(683, 400);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(101, 23);
            this.txtTotalAmount.TabIndex = 5;
            this.txtTotalAmount.Text = "0";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(599, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total Amount";
            // 
            // ItemCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.ItemCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.Width = 95;
            // 
            // ItemName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemName.HeaderText = "Item Description";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 315;
            // 
            // ItemSubCategoryID1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemSubCategoryID1.DefaultCellStyle = dataGridViewCellStyle3;
            this.ItemSubCategoryID1.HeaderText = "ItemSubCategoryID1";
            this.ItemSubCategoryID1.Name = "ItemSubCategoryID1";
            this.ItemSubCategoryID1.ReadOnly = true;
            this.ItemSubCategoryID1.Visible = false;
            // 
            // ItemSubCategoryID2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemSubCategoryID2.DefaultCellStyle = dataGridViewCellStyle4;
            this.ItemSubCategoryID2.HeaderText = "ItemSubCategoryID2";
            this.ItemSubCategoryID2.Name = "ItemSubCategoryID2";
            this.ItemSubCategoryID2.ReadOnly = true;
            this.ItemSubCategoryID2.Visible = false;
            // 
            // ItemSerialNo1
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemSerialNo1.DefaultCellStyle = dataGridViewCellStyle5;
            this.ItemSerialNo1.HeaderText = "ItemSerialNo1";
            this.ItemSerialNo1.Name = "ItemSerialNo1";
            this.ItemSerialNo1.ReadOnly = true;
            this.ItemSerialNo1.Visible = false;
            // 
            // ItemSerialNo2
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemSerialNo2.DefaultCellStyle = dataGridViewCellStyle6;
            this.ItemSerialNo2.HeaderText = "ItemSerialNo2";
            this.ItemSerialNo2.Name = "ItemSerialNo2";
            this.ItemSerialNo2.ReadOnly = true;
            this.ItemSerialNo2.Visible = false;
            // 
            // QuantityAvailable
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QuantityAvailable.DefaultCellStyle = dataGridViewCellStyle7;
            this.QuantityAvailable.HeaderText = "Available Qty";
            this.QuantityAvailable.Name = "QuantityAvailable";
            this.QuantityAvailable.Width = 80;
            // 
            // Weight
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Weight.DefaultCellStyle = dataGridViewCellStyle8;
            this.Weight.HeaderText = "Weight [Kg]";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Visible = false;
            this.Weight.Width = 90;
            // 
            // Quantity
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle9;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 80;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // WeightPrice
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WeightPrice.DefaultCellStyle = dataGridViewCellStyle11;
            this.WeightPrice.HeaderText = "Weight Price";
            this.WeightPrice.Name = "WeightPrice";
            this.WeightPrice.ReadOnly = true;
            this.WeightPrice.Visible = false;
            // 
            // ItemTotalValue
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemTotalValue.DefaultCellStyle = dataGridViewCellStyle12;
            this.ItemTotalValue.HeaderText = "Total Amount";
            this.ItemTotalValue.Name = "ItemTotalValue";
            this.ItemTotalValue.ReadOnly = true;
            // 
            // UOMID
            // 
            this.UOMID.HeaderText = "UOM";
            this.UOMID.Name = "UOMID";
            this.UOMID.Visible = false;
            // 
            // frm_sasMultipleItemSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(794, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_sasMultipleItemSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_sasOpeningBalance";
            this.Load += new System.EventHandler(this.frm_sasOpeningBalance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sasMultipleItemSelect_SRN_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMID;
    }
}