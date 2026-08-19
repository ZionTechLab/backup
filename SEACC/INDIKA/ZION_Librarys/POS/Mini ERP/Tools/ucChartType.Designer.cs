namespace Digiteq
{
    partial class ucChartType
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
            this.rdbBar = new System.Windows.Forms.RadioButton();
            this.rdbLine = new System.Windows.Forms.RadioButton();
            this.rdbPie = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbBar
            // 
            this.rdbBar.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbBar.BackColor = System.Drawing.Color.White;
            this.rdbBar.BackgroundImage = global::Digiteq.Properties.Resources.Chart_Bar_Big_icon;
            this.rdbBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rdbBar.Checked = true;
            this.rdbBar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.rdbBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbBar.Location = new System.Drawing.Point(1, 1);
            this.rdbBar.Margin = new System.Windows.Forms.Padding(0);
            this.rdbBar.Name = "rdbBar";
            this.rdbBar.Size = new System.Drawing.Size(20, 20);
            this.rdbBar.TabIndex = 3;
            this.rdbBar.TabStop = true;
            this.rdbBar.UseVisualStyleBackColor = false;
            this.rdbBar.CheckedChanged += new System.EventHandler(this.rdbPie_CheckedChanged);
            // 
            // rdbLine
            // 
            this.rdbLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbLine.BackColor = System.Drawing.Color.White;
            this.rdbLine.BackgroundImage = global::Digiteq.Properties.Resources.Line_Chart_icon;
            this.rdbLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rdbLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.rdbLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbLine.Location = new System.Drawing.Point(1, 21);
            this.rdbLine.Margin = new System.Windows.Forms.Padding(0);
            this.rdbLine.Name = "rdbLine";
            this.rdbLine.Size = new System.Drawing.Size(20, 20);
            this.rdbLine.TabIndex = 2;
            this.rdbLine.UseVisualStyleBackColor = false;
            this.rdbLine.CheckedChanged += new System.EventHandler(this.rdbPie_CheckedChanged);
            // 
            // rdbPie
            // 
            this.rdbPie.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbPie.BackColor = System.Drawing.Color.White;
            this.rdbPie.BackgroundImage = global::Digiteq.Properties.Resources.pie_chart_icon;
            this.rdbPie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rdbPie.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbPie.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbPie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.rdbPie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPie.Location = new System.Drawing.Point(1, 41);
            this.rdbPie.Margin = new System.Windows.Forms.Padding(0);
            this.rdbPie.Name = "rdbPie";
            this.rdbPie.Size = new System.Drawing.Size(20, 20);
            this.rdbPie.TabIndex = 1;
            this.rdbPie.UseVisualStyleBackColor = false;
            this.rdbPie.CheckedChanged += new System.EventHandler(this.rdbPie_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Digiteq.Properties.Resources._00450_printer;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucChartType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rdbBar);
            this.Controls.Add(this.rdbLine);
            this.Controls.Add(this.rdbPie);
            this.Name = "ucChartType";
            this.Size = new System.Drawing.Size(25, 92);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbBar;
        private System.Windows.Forms.RadioButton rdbLine;
        private System.Windows.Forms.RadioButton rdbPie;
        private System.Windows.Forms.Button button1;
    }
}
