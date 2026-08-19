using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using DataTire;
using System.Windows.Forms.DataVisualization.Charting;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
   public class clsChart
    {     
        #region Chart Formats


        static void ChartType_ChartType(int i)
        {

        }
        //void ChartType_ChartType(int type)
        //{ }
        public static void ChartFormat_Basic(ref Digiteq.charts chtObject)
        {
            // Set Border Ski
            chtObject.BorderSkin.BackColor = Color.White;
            chtObject.BorderSkin.BorderColor = Color.Navy;
            chtObject.BorderSkin.BorderWidth = 2;
            chtObject.BorderSkin.BorderDashStyle = ChartDashStyle.Solid;
            chtObject.BorderSkin.PageColor = Color.Transparent;
            chtObject.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;


            chtObject.BorderlineColor = Color.Navy;
            chtObject.BorderlineWidth = 2;
            chtObject.BorderlineDashStyle = ChartDashStyle.Solid;

            chtObject.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            chtObject.Titles.Clear();

        }

        public static void ChartAxisFormat_Basic(ref Digiteq.charts chtObject, string sChartArea)
        {
            chtObject.ChartAreas[sChartArea].AxisY.TitleFont = new Font("Segoe WP", 6);
            chtObject.ChartAreas[sChartArea].AxisY.LabelStyle.Font = new Font("Segoe WP", 6, FontStyle.Bold);

            chtObject.ChartAreas[sChartArea].AxisX.TitleFont = new Font("Segoe WP", 6);
            chtObject.ChartAreas[sChartArea].AxisX.LabelStyle.Font = new Font("Segoe WP", 6, FontStyle.Bold);
        }

        public static void ChartLegendsFormat_Basic(ref Digiteq.charts chtObject, string sLedgendName)
        {

            chtObject.Legends[sLedgendName].BorderColor = Color.Navy;
            chtObject.Legends[sLedgendName].BorderWidth = 1;
            chtObject.Legends[sLedgendName].BorderDashStyle = ChartDashStyle.Solid;

            chtObject.Legends[sLedgendName].Docking = Docking.Bottom;
            chtObject.Legends[sLedgendName].LegendStyle = LegendStyle.Row;
            chtObject.Legends[sLedgendName].Alignment = StringAlignment.Center;

            chtObject.Legends[sLedgendName].Font = new Font("Segoe WP", 6, FontStyle.Bold);
        }

        public static void ChartTitleFormat_Basic(ref Digiteq.charts chtObject)
        {
            chtObject.Titles[0].Font = new Font("Segoe WP", 12, FontStyle.Bold);
        }
        #endregion
    }
}