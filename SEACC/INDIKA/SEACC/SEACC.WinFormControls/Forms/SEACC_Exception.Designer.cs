using SEACC.WinFormControls.Components;

namespace SEACC.WinFormControls.Forms
{
    partial class SEACC_Exception
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
            this.btnMore = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblLineNo = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.ucTittleBar1 = new ucTittleBar();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_StackTrace = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ucTittleBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 48);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 15);
            this.label1.TabIndex = 53;
            this.label1.Text = "Please contact your system administrator";
            // 
            // btnMore
            // 
            this.btnMore.BackColor = System.Drawing.Color.Transparent;
            this.btnMore.FlatAppearance.BorderSize = 0;
            this.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.ForeColor = System.Drawing.Color.Red;
            this.btnMore.Location = new System.Drawing.Point(457, 12);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(69, 25);
            this.btnMore.TabIndex = 54;
            this.btnMore.Text = "More >>";
            this.btnMore.UseVisualStyleBackColor = false;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btn_StackTrace);
            this.pnlFooter.Controls.Add(this.btnOK);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 82);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(540, 38);
            this.pnlFooter.TabIndex = 55;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(457, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 25);
            this.btnOK.TabIndex = 46;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 441F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label17, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLineNo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFile, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMethod, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 82);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 87);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2);
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Line No";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 17);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(2);
            this.label11.Size = new System.Drawing.Size(47, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Method";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 34);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(2);
            this.label12.Size = new System.Drawing.Size(58, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "File Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 51);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(2);
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Message";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(68, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.label14.Size = new System.Drawing.Size(9, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(68, 17);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.label15.Size = new System.Drawing.Size(9, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = ":";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(68, 34);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.label16.Size = new System.Drawing.Size(9, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = ":";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(68, 51);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.label17.Size = new System.Drawing.Size(9, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = ":";
            // 
            // lblLineNo
            // 
            this.lblLineNo.AutoSize = true;
            this.lblLineNo.Location = new System.Drawing.Point(83, 0);
            this.lblLineNo.Name = "lblLineNo";
            this.lblLineNo.Padding = new System.Windows.Forms.Padding(2);
            this.lblLineNo.Size = new System.Drawing.Size(14, 17);
            this.lblLineNo.TabIndex = 0;
            this.lblLineNo.Text = "-";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(83, 34);
            this.lblFile.Name = "lblFile";
            this.lblFile.Padding = new System.Windows.Forms.Padding(2);
            this.lblFile.Size = new System.Drawing.Size(14, 17);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "-";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(83, 51);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(2);
            this.lblMessage.Size = new System.Drawing.Size(14, 17);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "-";
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(83, 17);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Padding = new System.Windows.Forms.Padding(2);
            this.lblMethod.Size = new System.Drawing.Size(14, 17);
            this.lblMethod.TabIndex = 1;
            this.lblMethod.Text = "-";
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucTittleBar1.Controls.Add(this.btn_Close);
            this.ucTittleBar1.DisplayName = "Something went wrong…!";
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTittleBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(540, 34);
            this.ucTittleBar1.TabIndex = 2;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Close.Location = new System.Drawing.Point(510, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 34);
            this.btn_Close.TabIndex = 45;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_StackTrace
            // 
            this.btn_StackTrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_StackTrace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StackTrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_StackTrace.Location = new System.Drawing.Point(371, 6);
            this.btn_StackTrace.Name = "btn_StackTrace";
            this.btn_StackTrace.Size = new System.Drawing.Size(80, 25);
            this.btn_StackTrace.TabIndex = 47;
            this.btn_StackTrace.Text = "Stack Trace";
            this.btn_StackTrace.UseVisualStyleBackColor = false;
            this.btn_StackTrace.Visible = false;
            this.btn_StackTrace.Click += new System.EventHandler(this.btn_StackTrace_Click);
            // 
            // SEACC_Exception
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(540, 120);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucTittleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SEACC_Exception";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEACC_Exception";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblLineNo;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Button btn_StackTrace;
    }
}