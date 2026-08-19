using System;
using System.Collections.Generic;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Digiteq
{
    public class charts : System.Windows.Forms.DataVisualization.Charting.Chart
    {
        RadioButton rdbBar;
        RadioButton rdbLine;
        RadioButton rdbPie;
       Button button1;
        public charts()
        {
            FlowLayoutPanel flpToolBar = new FlowLayoutPanel();

            rdbBar = new RadioButton();
            rdbLine = new RadioButton();
            rdbPie = new RadioButton();
            button1 = new Button();
            this.Controls.Add(flpToolBar);
            flpToolBar.Size = new System.Drawing.Size(25, 92);
            flpToolBar.Location = new System.Drawing.Point(13, 13);
            flpToolBar.Controls.Add(rdbBar);
            flpToolBar.Controls.Add(rdbLine);
            flpToolBar.Controls.Add(rdbPie);
            flpToolBar.Controls.Add(button1);
            #region bar
            rdbBar.Appearance = System.Windows.Forms.Appearance.Button;
            rdbBar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            rdbBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            rdbBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            rdbBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //    rdbBar.FlatAppearance.BorderSize = 0;
            rdbBar.Margin = new System.Windows.Forms.Padding(0);
            rdbBar.Size = new System.Drawing.Size(20, 20);
           rdbBar.BackgroundImage = global::Digiteq.Properties.Resources.Chart_Bar_Big_icon;
            rdbBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
           rdbBar.Checked = true;
            rdbBar.CheckedChanged += new EventHandler(CheckedChanged); 
            #endregion

            #region line
            rdbLine.Appearance = System.Windows.Forms.Appearance.Button;
            rdbLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            rdbLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            rdbLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            rdbLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          //  rdbLine.FlatAppearance.BorderSize = 0;
            rdbLine.Size = new System.Drawing.Size(20, 20);
            rdbLine.CheckedChanged += new EventHandler(CheckedChanged);
            rdbLine.BackgroundImage = global::Digiteq.Properties.Resources.Line_Chart_icon;
            rdbLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            rdbLine.Margin = new System.Windows.Forms.Padding(0); 
            #endregion

            #region pie
            rdbPie.Appearance = System.Windows.Forms.Appearance.Button;
            rdbPie.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            rdbPie.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            rdbPie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            rdbPie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
       //     rdbPie.FlatAppearance.BorderSize = 0;
            rdbPie.Size = new System.Drawing.Size(20, 20);
            rdbPie.BackgroundImage = global::Digiteq.Properties.Resources.pie_chart_icon;
            rdbPie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            rdbPie.CheckedChanged += new EventHandler(CheckedChanged);
            rdbPie.Margin = new System.Windows.Forms.Padding(0); 
            #endregion

          //  button1.BackgroundImage = global::Digiteq.Properties.Resources._00450_printer;
            button1.BackgroundImage = global::Digiteq.Properties.Resources._00450_printer;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Location = new System.Drawing.Point(1, 64);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(20, 20);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(button1_Click);
            button1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0); 
        }

        void button1_Click(object sender, EventArgs e)
        {
            this.Printing.Print(true);
        }

        void CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbBar.Checked)
                {
                    for (int i = 0; i < this.Series.Count; i++)
                    {
                        this.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    }
                }
                else if (rdbLine.Checked)
                {
                    for (int i = 0; i < this.Series.Count; i++)
                    {
                        this.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    }
                }
                else if (rdbPie.Checked)
                {
                    for (int i = 0; i < this.Series.Count; i++)
                    {
                        this.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    }
                }

            }
            catch (Exception)
            {
            }
        }
    }
}

