using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Digiteq
{
    
    public partial class ucChartType : UserControl
    {
        public delegate void ChartSelector( int i);
        public event ChartSelector ChartType;
       
        public ucChartType()
        {  
            InitializeComponent();
        }
        public ucChartType(Chart objChart)
        {
            InitializeComponent();
        }
        private void rdbPie_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbBar.Checked )
                {
                    ChartType(1);
                }
                else if (rdbLine.Checked)
                {
                    ChartType(2);
                }
                else if (rdbPie.Checked)
                {
                    ChartType(3);
                }
              
            }
            catch (Exception)
            {
          
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChartType(4);
        }
    }
}
