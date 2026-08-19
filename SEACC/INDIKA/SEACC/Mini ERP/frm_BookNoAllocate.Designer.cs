namespace Digiteq
{
    partial class frm_BookNoAllocate
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtlength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new Digiteq.SEACC_DataGrid();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Page = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.txtSeperator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(16, 273);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(66, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.LightGray;
            this.txtRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(87, 43);
            this.txtRoute.Margin = new System.Windows.Forms.Padding(0);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(193, 22);
            this.txtRoute.TabIndex = 13;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRoute.Location = new System.Drawing.Point(13, 46);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(69, 14);
            this.lblRoute.TabIndex = 14;
            this.lblRoute.Text = "Route Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(13, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Book No";
            // 
            // txtBookNO
            // 
            this.txtBookNO.BackColor = System.Drawing.Color.White;
            this.txtBookNO.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookNO.Location = new System.Drawing.Point(87, 97);
            this.txtBookNO.Margin = new System.Windows.Forms.Padding(0);
            this.txtBookNO.Name = "txtBookNO";
            this.txtBookNO.Size = new System.Drawing.Size(190, 22);
            this.txtBookNO.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(13, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Serial No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(84, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(149, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "End";
            // 
            // txtStart
            // 
            this.txtStart.BackColor = System.Drawing.Color.White;
            this.txtStart.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStart.Location = new System.Drawing.Point(87, 211);
            this.txtStart.Margin = new System.Windows.Forms.Padding(0);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(56, 22);
            this.txtStart.TabIndex = 21;
            // 
            // txtEnd
            // 
            this.txtEnd.BackColor = System.Drawing.Color.White;
            this.txtEnd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnd.Location = new System.Drawing.Point(152, 211);
            this.txtEnd.Margin = new System.Windows.Forms.Padding(0);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(54, 22);
            this.txtEnd.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(13, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(87, 69);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(0);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(193, 22);
            this.txtRemarks.TabIndex = 16;
            // 
            // txtlength
            // 
            this.txtlength.BackColor = System.Drawing.Color.White;
            this.txtlength.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlength.Location = new System.Drawing.Point(152, 172);
            this.txtlength.Margin = new System.Windows.Forms.Padding(0);
            this.txtlength.Name = "txtlength";
            this.txtlength.Size = new System.Drawing.Size(56, 22);
            this.txtlength.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Location = new System.Drawing.Point(149, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "Length";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Route,
            this.BookNo,
            this.Page});
            this.dataGridView1.Location = new System.Drawing.Point(302, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(306, 253);
            this.dataGridView1.TabIndex = 26;
            // 
            // Route
            // 
            this.Route.HeaderText = "Route";
            this.Route.Name = "Route";
            // 
            // BookNo
            // 
            this.BookNo.HeaderText = "Book No";
            this.BookNo.Name = "BookNo";
            // 
            // Page
            // 
            this.Page.HeaderText = "Page";
            this.Page.Name = "Page";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(87, 273);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(49, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "New";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(142, 273);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(195, 273);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(67, 23);
            this.btnShowAll.TabIndex = 28;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // txtSeperator
            // 
            this.txtSeperator.BackColor = System.Drawing.Color.White;
            this.txtSeperator.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeperator.Location = new System.Drawing.Point(87, 172);
            this.txtSeperator.Margin = new System.Windows.Forms.Padding(0);
            this.txtSeperator.Name = "txtSeperator";
            this.txtSeperator.Size = new System.Drawing.Size(56, 22);
            this.txtSeperator.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(84, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "Seperator";
            // 
            // frm_BookNoAllocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 305);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeperator);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtlength);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBookNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnProcess);
            this.Name = "frm_BookNoAllocate";
            this.Text = "Book No Allocate";
            this.Load += new System.EventHandler(this.frm_BookNoAllocate_Load);
            this.Controls.SetChildIndex(this.btnProcess, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.lblRoute, 0);
            this.Controls.SetChildIndex(this.txtRoute, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBookNO, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtRemarks, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtStart, 0);
            this.Controls.SetChildIndex(this.txtEnd, 0);
            this.Controls.SetChildIndex(this.txtlength, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnShowAll, 0);
            this.Controls.SetChildIndex(this.txtSeperator, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.TextBox txtBookNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtlength;
        private System.Windows.Forms.Label label7;
        private SEACC_DataGrid dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Page;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.TextBox txtSeperator;
        private System.Windows.Forms.Label label3;
    }
}