namespace Digiteq.Transaction_Forms.SCS.Tools_And_Views
{
    partial class frm_scsMultipleItemSelect_SplitNote
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.txtTotalQty_input = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalWeight_Input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalWeight_Output = new System.Windows.Forms.TextBox();
            this.txtTotalQty_Output = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSubCategoryID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsInput = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
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
            this.UOMID,
            this.AvailableQty,
            this.InputQuantity,
            this.InputWeight,
            this.OutputQuantity,
            this.OutputWeight,
            this.IsInput});
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.Location = new System.Drawing.Point(10, 10);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(774, 379);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetail_CurrentCellDirtyStateChanged);
            this.dgvDetail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDetail_KeyUp);
            // 
            // txtTotalQty_input
            // 
            this.txtTotalQty_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty_input.Enabled = false;
            this.txtTotalQty_input.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty_input.Location = new System.Drawing.Point(475, 398);
            this.txtTotalQty_input.Name = "txtTotalQty_input";
            this.txtTotalQty_input.ReadOnly = true;
            this.txtTotalQty_input.Size = new System.Drawing.Size(80, 23);
            this.txtTotalQty_input.TabIndex = 8;
            this.txtTotalQty_input.Text = "0";
            this.txtTotalQty_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(381, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Total Input Qty";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(94, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 25);
            this.btnSave.TabIndex = 6;
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
            this.btnNew.Location = new System.Drawing.Point(10, 395);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 25);
            this.btnNew.TabIndex = 5;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "  New (F9)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(590, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total Input Weight";
            // 
            // txtTotalWeight_Input
            // 
            this.txtTotalWeight_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalWeight_Input.Enabled = false;
            this.txtTotalWeight_Input.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalWeight_Input.Location = new System.Drawing.Point(701, 398);
            this.txtTotalWeight_Input.Name = "txtTotalWeight_Input";
            this.txtTotalWeight_Input.ReadOnly = true;
            this.txtTotalWeight_Input.Size = new System.Drawing.Size(81, 23);
            this.txtTotalWeight_Input.TabIndex = 9;
            this.txtTotalWeight_Input.Text = "0";
            this.txtTotalWeight_Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(580, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total Output Weight";
            // 
            // txtTotalWeight_Output
            // 
            this.txtTotalWeight_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalWeight_Output.Enabled = false;
            this.txtTotalWeight_Output.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalWeight_Output.Location = new System.Drawing.Point(701, 427);
            this.txtTotalWeight_Output.Name = "txtTotalWeight_Output";
            this.txtTotalWeight_Output.ReadOnly = true;
            this.txtTotalWeight_Output.Size = new System.Drawing.Size(81, 23);
            this.txtTotalWeight_Output.TabIndex = 13;
            this.txtTotalWeight_Output.Text = "0";
            this.txtTotalWeight_Output.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalQty_Output
            // 
            this.txtTotalQty_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty_Output.Enabled = false;
            this.txtTotalQty_Output.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty_Output.Location = new System.Drawing.Point(475, 427);
            this.txtTotalQty_Output.Name = "txtTotalQty_Output";
            this.txtTotalQty_Output.ReadOnly = true;
            this.txtTotalQty_Output.Size = new System.Drawing.Size(80, 23);
            this.txtTotalQty_Output.TabIndex = 12;
            this.txtTotalQty_Output.Text = "0";
            this.txtTotalQty_Output.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(370, 431);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total Output Qty";
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
            this.ItemName.Width = 225;
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
            // UOMID
            // 
            this.UOMID.HeaderText = "UOM";
            this.UOMID.Name = "UOMID";
            this.UOMID.ReadOnly = true;
            this.UOMID.Width = 40;
            // 
            // AvailableQty
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = null;
            this.AvailableQty.DefaultCellStyle = dataGridViewCellStyle7;
            this.AvailableQty.HeaderText = "Available Qty.";
            this.AvailableQty.Name = "AvailableQty";
            this.AvailableQty.ReadOnly = true;
            this.AvailableQty.Width = 90;
            // 
            // InputQuantity
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InputQuantity.DefaultCellStyle = dataGridViewCellStyle8;
            this.InputQuantity.HeaderText = "Input Qty.";
            this.InputQuantity.Name = "InputQuantity";
            this.InputQuantity.Width = 80;
            // 
            // InputWeight
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.InputWeight.DefaultCellStyle = dataGridViewCellStyle9;
            this.InputWeight.HeaderText = "Input [Kg]";
            this.InputWeight.Name = "InputWeight";
            this.InputWeight.Width = 80;
            // 
            // OutputQuantity
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OutputQuantity.DefaultCellStyle = dataGridViewCellStyle10;
            this.OutputQuantity.HeaderText = "Output Qty.";
            this.OutputQuantity.Name = "OutputQuantity";
            this.OutputQuantity.Width = 80;
            // 
            // OutputWeight
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OutputWeight.DefaultCellStyle = dataGridViewCellStyle11;
            this.OutputWeight.HeaderText = "Output [Kg]";
            this.OutputWeight.Name = "OutputWeight";
            this.OutputWeight.Width = 80;
            // 
            // IsInput
            // 
            this.IsInput.HeaderText = "Is Input";
            this.IsInput.Name = "IsInput";
            this.IsInput.Visible = false;
            this.IsInput.Width = 50;
            // 
            // frm_scsMultipleItemSelect_SplitNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(794, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalWeight_Output);
            this.Controls.Add(this.txtTotalQty_Output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalWeight_Input);
            this.Controls.Add(this.txtTotalQty_input);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frm_scsMultipleItemSelect_SplitNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple Item Selection [Item Split]";
            this.Load += new System.EventHandler(this.frm_scsMultipleItemSelect_SplitNote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_scsMultipleItemSelect_SplitNote_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox txtTotalQty_input;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalWeight_Input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalWeight_Output;
        private System.Windows.Forms.TextBox txtTotalQty_Output;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSubCategoryID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputWeight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsInput;
    }
}