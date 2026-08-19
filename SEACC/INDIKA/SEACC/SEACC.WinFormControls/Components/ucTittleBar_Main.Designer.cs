namespace SEACC.WinFormControls.Components
{
    partial class ucTittleBar_Main
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
            this.lblSeaccType = new System.Windows.Forms.Label();
            this.lblSeaccName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSeaccType
            // 
            this.lblSeaccType.AutoSize = true;
            this.lblSeaccType.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSeaccType.Location = new System.Drawing.Point(93, 14);
            this.lblSeaccType.Name = "lblSeaccType";
            this.lblSeaccType.Size = new System.Drawing.Size(38, 13);
            this.lblSeaccType.TabIndex = 50;
            this.lblSeaccType.Text = "Crystal";
            this.lblSeaccType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucTittleBar_Main_MouseDown);
            // 
            // lblSeaccName
            // 
            this.lblSeaccName.AutoSize = true;
            this.lblSeaccName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeaccName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblSeaccName.Location = new System.Drawing.Point(6, 4);
            this.lblSeaccName.Name = "lblSeaccName";
            this.lblSeaccName.Size = new System.Drawing.Size(92, 26);
            this.lblSeaccName.TabIndex = 49;
            this.lblSeaccName.Text = "SEACC";
            this.lblSeaccName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucTittleBar_Main_MouseDown);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(181, 12);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(135, 15);
            this.lblCompanyName.TabIndex = 51;
            this.lblCompanyName.Text = "Digiteq Solution Pvt LTD";
            this.lblCompanyName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucTittleBar_Main_MouseDown);
            // 
            // ucTittleBar_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblSeaccType);
            this.Controls.Add(this.lblSeaccName);
            this.Name = "ucTittleBar_Main";
            this.Size = new System.Drawing.Size(554, 34);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucTittleBar_Main_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeaccType;
        private System.Windows.Forms.Label lblSeaccName;
        private System.Windows.Forms.Label lblCompanyName;


    }
}

