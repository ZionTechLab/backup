namespace Digiteq
{
    partial class frm_TemporaryProductionJobCreation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFinishedGoodItemDescription = new System.Windows.Forms.TextBox();
            this.lblFinishedGood = new System.Windows.Forms.Label();
            this.txtFinishedGoodItem = new System.Windows.Forms.TextBox();
            this.txtTpJobNo = new System.Windows.Forms.TextBox();
            this.lbltempjobNo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtmTeporyP_JobDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.panel1.Controls.Add(this.dtmTeporyP_JobDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFinishedGoodItemDescription);
            this.panel1.Controls.Add(this.lblFinishedGood);
            this.panel1.Controls.Add(this.txtFinishedGoodItem);
            this.panel1.Controls.Add(this.txtTpJobNo);
            this.panel1.Controls.Add(this.lbltempjobNo);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 182);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(13, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Prod.Job Description\r\n";
            // 
            // txtFinishedGoodItemDescription
            // 
            this.txtFinishedGoodItemDescription.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinishedGoodItemDescription.Location = new System.Drawing.Point(126, 78);
            this.txtFinishedGoodItemDescription.Multiline = true;
            this.txtFinishedGoodItemDescription.Name = "txtFinishedGoodItemDescription";
            this.txtFinishedGoodItemDescription.ReadOnly = true;
            this.txtFinishedGoodItemDescription.Size = new System.Drawing.Size(208, 60);
            this.txtFinishedGoodItemDescription.TabIndex = 6;
            // 
            // lblFinishedGood
            // 
            this.lblFinishedGood.AutoSize = true;
            this.lblFinishedGood.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinishedGood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFinishedGood.Location = new System.Drawing.Point(13, 57);
            this.lblFinishedGood.Name = "lblFinishedGood";
            this.lblFinishedGood.Size = new System.Drawing.Size(103, 14);
            this.lblFinishedGood.TabIndex = 4;
            this.lblFinishedGood.Text = "Finished Good Item";
            // 
            // txtFinishedGoodItem
            // 
            this.txtFinishedGoodItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.txtFinishedGoodItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinishedGoodItem.Location = new System.Drawing.Point(126, 50);
            this.txtFinishedGoodItem.Name = "txtFinishedGoodItem";
            this.txtFinishedGoodItem.ReadOnly = true;
            this.txtFinishedGoodItem.Size = new System.Drawing.Size(208, 22);
            this.txtFinishedGoodItem.TabIndex = 3;
            this.txtFinishedGoodItem.Text = "GN005";
            this.txtFinishedGoodItem.DoubleClick += new System.EventHandler(this.txtFinishedGoodItem_DoubleClick);
            // 
            // txtTpJobNo
            // 
            this.txtTpJobNo.Location = new System.Drawing.Point(126, 18);
            this.txtTpJobNo.Name = "txtTpJobNo";
            this.txtTpJobNo.Size = new System.Drawing.Size(208, 20);
            this.txtTpJobNo.TabIndex = 1;
            // 
            // lbltempjobNo
            // 
            this.lbltempjobNo.AutoSize = true;
            this.lbltempjobNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lbltempjobNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbltempjobNo.Location = new System.Drawing.Point(13, 24);
            this.lbltempjobNo.Name = "lbltempjobNo";
            this.lbltempjobNo.Size = new System.Drawing.Size(110, 14);
            this.lbltempjobNo.TabIndex = 0;
            this.lbltempjobNo.Text = "Temporary Prod Job#";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Digiteq.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(220, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Digiteq.Properties.Resources.delete;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(297, 193);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Cancel";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::Digiteq.Properties.Resources.add_page;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(143, 193);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "  New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(13, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tempory Job Date";
            // 
            // dtmTeporyP_JobDate
            // 
            this.dtmTeporyP_JobDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmTeporyP_JobDate.Location = new System.Drawing.Point(126, 146);
            this.dtmTeporyP_JobDate.Name = "dtmTeporyP_JobDate";
            this.dtmTeporyP_JobDate.Size = new System.Drawing.Size(99, 20);
            this.dtmTeporyP_JobDate.TabIndex = 9;
            // 
            // frm_TemporaryProductionJobCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 221);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_TemporaryProductionJobCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_TemporaryProductionJobCreation";
            this.Load += new System.EventHandler(this.frm_TemporaryProductionJobCreation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTpJobNo;
        private System.Windows.Forms.Label lbltempjobNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtFinishedGoodItem;
        private System.Windows.Forms.Label lblFinishedGood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFinishedGoodItemDescription;
        private System.Windows.Forms.DateTimePicker dtmTeporyP_JobDate;
        private System.Windows.Forms.Label label2;
    }
}