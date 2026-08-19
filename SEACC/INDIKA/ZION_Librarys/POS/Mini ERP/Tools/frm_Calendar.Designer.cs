namespace Digiteq
{
    partial class frm_Calendar
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
            this.calDate = new System.Windows.Forms.MonthCalendar();
            this.ucTittleBar1 = new Digiteq.ucTittleBar();
            this.btn_Close = new System.Windows.Forms.Button();
            this.ucTittleBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calDate
            // 
            this.calDate.BackColor = System.Drawing.Color.White;
            this.calDate.Location = new System.Drawing.Point(1, 29);
            this.calDate.Name = "calDate";
            this.calDate.TabIndex = 0;
//            this.calDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calDate_DateChanged);
            this.calDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calDate_DateSelected);
            // 
            // ucTittleBar1
            // 
            this.ucTittleBar1.BackColor = System.Drawing.Color.SteelBlue;
            this.ucTittleBar1.Controls.Add(this.btn_Close);
            this.ucTittleBar1.DisplayName = "Calendar";
            this.ucTittleBar1.Location = new System.Drawing.Point(1, 1);
            this.ucTittleBar1.Name = "ucTittleBar1";
            this.ucTittleBar1.Size = new System.Drawing.Size(227, 27);
            this.ucTittleBar1.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Close.Location = new System.Drawing.Point(197, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 27);
            this.btn_Close.TabIndex = 45;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frm_Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(229, 192);
            this.Controls.Add(this.ucTittleBar1);
            this.Controls.Add(this.calDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Calendar";
            this.ucTittleBar1.ResumeLayout(false);
            this.ucTittleBar1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calDate;
        private ucTittleBar ucTittleBar1;
        private System.Windows.Forms.Button btn_Close;
    }
}