using SEACC.WinFormControls.Components;

namespace SEACC.WinFormControls.Forms
{
    partial class SEACC_MessageBox
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
            this.btnLater = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterSidePanel = new System.Windows.Forms.Panel();
            this.ucTittleBar1 = new ucTittleBar();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterSidePanel.SuspendLayout();
            this.ucTittleBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLater
            // 
            this.btnLater.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLater.FlatAppearance.BorderSize = 0;
            this.btnLater.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(117)))), ((int)(((byte)(162)))));
            this.btnLater.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(117)))), ((int)(((byte)(162)))));
            this.btnLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLater.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLater.ForeColor = System.Drawing.Color.White;
            this.btnLater.Location = new System.Drawing.Point(93, 5);
            this.btnLater.Name = "btnLater";
            this.btnLater.Size = new System.Drawing.Size(75, 28);
            this.btnLater.TabIndex = 0;
            this.btnLater.Text = "Not Now";
            this.btnLater.UseVisualStyleBackColor = false;
            this.btnLater.Click += new System.EventHandler(this.btnLater_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(117)))), ((int)(((byte)(162)))));
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(117)))), ((int)(((byte)(162)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(12, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 0);
            this.panel1.TabIndex = 4;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBody.Controls.Add(this.tableLayoutPanel1);
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 35);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(477, 103);
            this.pnlBody.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 508F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescription, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 90);
            this.tableLayoutPanel1.TabIndex = 59;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(2);
            this.lblTitle.Size = new System.Drawing.Size(16, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "-";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(3, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(2);
            this.lblDescription.Size = new System.Drawing.Size(16, 19);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "-";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.pnlFooterSidePanel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 138);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(477, 37);
            this.pnlFooter.TabIndex = 5;
            // 
            // pnlFooterSidePanel
            // 
            this.pnlFooterSidePanel.Controls.Add(this.btnLater);
            this.pnlFooterSidePanel.Controls.Add(this.btnOK);
            this.pnlFooterSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterSidePanel.Location = new System.Drawing.Point(301, 0);
            this.pnlFooterSidePanel.Name = "pnlFooterSidePanel";
            this.pnlFooterSidePanel.Size = new System.Drawing.Size(176, 37);
            this.pnlFooterSidePanel.TabIndex = 2;
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.SteelBlue;
            this.ucTittleBar1.Controls.Add(this.btn_Close);
            this.ucTittleBar1.DisplayName = "SEACC Message…!";
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTittleBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(477, 35);
            this.ucTittleBar1.TabIndex = 6;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(117)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(117)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Close.Location = new System.Drawing.Point(447, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 35);
            this.btn_Close.TabIndex = 45;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // SEACC_MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(477, 175);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.ucTittleBar1);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SEACC_MessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessageBox";
            this.Load += new System.EventHandler(this.SEACC_MessageBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SEACC_MessageBox_KeyDown);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterSidePanel.ResumeLayout(false);
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLater;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterSidePanel;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Button btn_Close;
    }
}