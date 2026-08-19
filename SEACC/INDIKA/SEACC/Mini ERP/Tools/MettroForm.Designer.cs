using SEACC.WinFormControls.Components;

namespace Digiteq
{
    partial class MettroForm
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
            this.LineB = new System.Windows.Forms.Panel();
            this.lineR = new System.Windows.Forms.Panel();
            this.lineL = new System.Windows.Forms.Panel();
            this.ucTittleBar1 = new SEACC.WinFormControls.Components.ucTittleBar();
            this.pnlFormHeader = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btnReSize = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lineT = new System.Windows.Forms.Panel();
            this.ucTittleBar1.SuspendLayout();
            this.pnlFormHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // LineB
            // 
            this.LineB.BackColor = System.Drawing.Color.Transparent;
            this.LineB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LineB.Location = new System.Drawing.Point(1, 260);
            this.LineB.Name = "LineB";
            this.LineB.Size = new System.Drawing.Size(692, 1);
            this.LineB.TabIndex = 48;
            // 
            // lineR
            // 
            this.lineR.BackColor = System.Drawing.Color.Transparent;
            this.lineR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineR.Dock = System.Windows.Forms.DockStyle.Right;
            this.lineR.Location = new System.Drawing.Point(693, 0);
            this.lineR.Name = "lineR";
            this.lineR.Size = new System.Drawing.Size(1, 261);
            this.lineR.TabIndex = 49;
            // 
            // lineL
            // 
            this.lineL.BackColor = System.Drawing.Color.Transparent;
            this.lineL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineL.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineL.Location = new System.Drawing.Point(0, 0);
            this.lineL.Name = "lineL";
            this.lineL.Size = new System.Drawing.Size(1, 261);
            this.lineL.TabIndex = 50;
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.Transparent;
            this.ucTittleBar1.Controls.Add(this.pnlFormHeader);
            this.ucTittleBar1.Controls.Add(this.lineT);
            this.ucTittleBar1.DisplayName = "Form Name";
            this.ucTittleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTittleBar1.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTittleBar1.Location = new System.Drawing.Point(1, 0);
            this.ucTittleBar1.Margin = new System.Windows.Forms.Padding(0);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(692, 38);
            this.ucTittleBar1.TabIndex = 0;
            // 
            // pnlFormHeader
            // 
            this.pnlFormHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormHeader.Controls.Add(this.btnSettings);
            this.pnlFormHeader.Controls.Add(this.btn_minimize);
            this.pnlFormHeader.Controls.Add(this.btnReSize);
            this.pnlFormHeader.Controls.Add(this.btn_Close);
            this.pnlFormHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFormHeader.Location = new System.Drawing.Point(564, 3);
            this.pnlFormHeader.Name = "pnlFormHeader";
            this.pnlFormHeader.Size = new System.Drawing.Size(128, 35);
            this.pnlFormHeader.TabIndex = 46;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Gray;
            this.btnSettings.Location = new System.Drawing.Point(8, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(30, 35);
            this.btnSettings.TabIndex = 47;
            this.btnSettings.Text = "";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimize.ForeColor = System.Drawing.Color.Gray;
            this.btn_minimize.Location = new System.Drawing.Point(38, 0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(30, 35);
            this.btn_minimize.TabIndex = 46;
            this.btn_minimize.Text = "";
            this.btn_minimize.UseVisualStyleBackColor = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btnReSize
            // 
            this.btnReSize.BackColor = System.Drawing.Color.Transparent;
            this.btnReSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReSize.FlatAppearance.BorderSize = 0;
            this.btnReSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReSize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReSize.ForeColor = System.Drawing.Color.Gray;
            this.btnReSize.Location = new System.Drawing.Point(68, 0);
            this.btnReSize.Name = "btnReSize";
            this.btnReSize.Size = new System.Drawing.Size(30, 35);
            this.btnReSize.TabIndex = 48;
            this.btnReSize.Text = "";
            this.btnReSize.UseVisualStyleBackColor = false;
            this.btnReSize.Visible = false;
            this.btnReSize.Click += new System.EventHandler(this.btnReSize_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Gray;
            this.btn_Close.Location = new System.Drawing.Point(98, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 35);
            this.btn_Close.TabIndex = 44;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lineT
            // 
            this.lineT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(153)))));
            this.lineT.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineT.Location = new System.Drawing.Point(0, 0);
            this.lineT.Name = "lineT";
            this.lineT.Size = new System.Drawing.Size(692, 3);
            this.lineT.TabIndex = 47;
            // 
            // MettroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(694, 261);
            this.Controls.Add(this.LineB);
            this.Controls.Add(this.ucTittleBar1);
            this.Controls.Add(this.lineR);
            this.Controls.Add(this.lineL);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MettroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.MettroForm_Enter);
            this.Leave += new System.EventHandler(this.MettroForm_Leave);
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.pnlFormHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_Close;
        protected System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReSize;
        private System.Windows.Forms.Panel lineT;
        private System.Windows.Forms.Panel LineB;
        private System.Windows.Forms.Panel lineR;
        private System.Windows.Forms.Panel lineL;
    }
}