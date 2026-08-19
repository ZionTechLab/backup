namespace Digiteq
{
    partial class UC_AccAssetTransferNote
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTransferCode = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.dtpTransferDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDepFrom = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDepTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.RowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAsset = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTransferCode
            // 
            this.txtTransferCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtTransferCode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferCode.Location = new System.Drawing.Point(143, 7);
            this.txtTransferCode.Name = "txtTransferCode";
            this.txtTransferCode.ReadOnly = true;
            this.txtTransferCode.Size = new System.Drawing.Size(168, 22);
            this.txtTransferCode.TabIndex = 600;
            this.txtTransferCode.Text = "GN005";
            this.txtTransferCode.DoubleClick += new System.EventHandler(this.txtTransferCode_DoubleClick);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label24.Location = new System.Drawing.Point(6, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 14);
            this.label24.TabIndex = 599;
            this.label24.Text = "Asset Transfer Code";
            // 
            // dtpTransferDate
            // 
            this.dtpTransferDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransferDate.Location = new System.Drawing.Point(143, 32);
            this.dtpTransferDate.Name = "dtpTransferDate";
            this.dtpTransferDate.Size = new System.Drawing.Size(168, 22);
            this.dtpTransferDate.TabIndex = 602;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label21.Location = new System.Drawing.Point(6, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 14);
            this.label21.TabIndex = 601;
            this.label21.Text = "Asset Transfer Date";
            // 
            // txtDepFrom
            // 
            this.txtDepFrom.BackColor = System.Drawing.Color.LightGray;
            this.txtDepFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepFrom.Location = new System.Drawing.Point(481, 7);
            this.txtDepFrom.Name = "txtDepFrom";
            this.txtDepFrom.ReadOnly = true;
            this.txtDepFrom.Size = new System.Drawing.Size(168, 22);
            this.txtDepFrom.TabIndex = 604;
            this.txtDepFrom.DoubleClick += new System.EventHandler(this.txtDepFrom_DoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Location = new System.Drawing.Point(358, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 14);
            this.label15.TabIndex = 603;
            this.label15.Text = "From Department";
            // 
            // txtDepTo
            // 
            this.txtDepTo.BackColor = System.Drawing.Color.LightGray;
            this.txtDepTo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepTo.Location = new System.Drawing.Point(481, 32);
            this.txtDepTo.Name = "txtDepTo";
            this.txtDepTo.ReadOnly = true;
            this.txtDepTo.Size = new System.Drawing.Size(168, 22);
            this.txtDepTo.TabIndex = 606;
            this.txtDepTo.DoubleClick += new System.EventHandler(this.txtDepTo_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(358, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 605;
            this.label1.Text = "To Department";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowCount,
            this.assetCode,
            this.barcode,
            this.itemID,
            this.itemName,
            this.itemDes});
            this.dgvDetail.Location = new System.Drawing.Point(7, 90);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(646, 221);
            this.dgvDetail.TabIndex = 607;
            // 
            // RowCount
            // 
            this.RowCount.HeaderText = "#";
            this.RowCount.Name = "RowCount";
            this.RowCount.ReadOnly = true;
            this.RowCount.Visible = false;
            this.RowCount.Width = 60;
            // 
            // assetCode
            // 
            this.assetCode.HeaderText = "Asset code ";
            this.assetCode.Name = "assetCode";
            this.assetCode.ReadOnly = true;
            this.assetCode.Width = 90;
            // 
            // barcode
            // 
            this.barcode.HeaderText = "Barcode";
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            // 
            // itemID
            // 
            this.itemID.HeaderText = "Item ID";
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "Item Name";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 150;
            // 
            // itemDes
            // 
            this.itemDes.HeaderText = "Item Description";
            this.itemDes.Name = "itemDes";
            this.itemDes.ReadOnly = true;
            this.itemDes.Width = 202;
            // 
            // txtAsset
            // 
            this.txtAsset.BackColor = System.Drawing.Color.LightGray;
            this.txtAsset.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsset.Location = new System.Drawing.Point(481, 57);
            this.txtAsset.Name = "txtAsset";
            this.txtAsset.ReadOnly = true;
            this.txtAsset.Size = new System.Drawing.Size(168, 22);
            this.txtAsset.TabIndex = 609;
            this.txtAsset.DoubleClick += new System.EventHandler(this.txtAsset_DoubleClick);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbl.Location = new System.Drawing.Point(358, 61);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(34, 14);
            this.lbl.TabIndex = 608;
            this.lbl.Text = "Asset";
            // 
            // UC_AccAssetTransferNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAsset);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtDepTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDepFrom);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpTransferDate);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtTransferCode);
            this.Controls.Add(this.label24);
            this.Name = "UC_AccAssetTransferNote";
            this.Size = new System.Drawing.Size(660, 364);
            this.SF_newButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccAssetTransferNote_SF_newButton_Click);
            this.SF_saveButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccAssetTransferNote_SF_saveButton_Click);
            this.SF_cancelButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccAssetTransferNote_SF_cancelButton_Click);
            this.SF_printButton_Click += new Digiteq.SEACC_Form.dBtnClick(this.UC_AccAssetTransferNote_SF_printButton_Click);
            this.Load += new System.EventHandler(this.UC_AccAssetTransferNote_Load);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.txtTransferCode, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.dtpTransferDate, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtDepFrom, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDepTo, 0);
            this.Controls.SetChildIndex(this.dgvDetail, 0);
            this.Controls.SetChildIndex(this.lbl, 0);
            this.Controls.SetChildIndex(this.txtAsset, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransferCode;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dtpTransferDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDepFrom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDepTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox txtAsset;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDes;
    }
}
