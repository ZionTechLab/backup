using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.Windows.Forms.DataVisualization.Charting;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_cht_DailyCollection : Form
    {
        #region Variables
        DateTime dtNow;
        DateTime dtFirstDayOfThisMonth;
        DateTime dtFirstDayOfThisYear;
        #endregion

        public frm_cht_DailyCollection()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            createDailyColectionChart();
            createMounthlyColectionChart();          
        }

        private void createDailyColectionChart()
        {
            dtNow = clsSecurity.getServerDateTime();
            dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            #region Chart Formating
            clsChart.ChartFormat_Basic(ref chtDailyCollection);

            chtDailyCollection.Titles.Add("Daily Collection Report Cash/Cheque (Current Month)");
            clsChart.ChartTitleFormat_Basic(ref chtDailyCollection);

            chtDailyCollection.Legends.Clear();
            chtDailyCollection.Legends.Add("Cash");
            chtDailyCollection.Legends.Add("Cheque");
            clsChart.ChartLegendsFormat_Basic(ref chtDailyCollection, "Cash");

            chtDailyCollection.ChartAreas.Clear();
            chtDailyCollection.ChartAreas.Add("ChartArea");
            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Title = "Day";
            chtDailyCollection.ChartAreas["ChartArea"].AxisY.Title = "Amount";
            clsChart.ChartAxisFormat_Basic(ref chtDailyCollection, "ChartArea");

            chtDailyCollection.Series.Clear();
            chtDailyCollection.Series.Add("Cash");
            chtDailyCollection.Series.Add("Cheque");
            #endregion

            var oInputItems = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.ReceiptDate >= dtFirstDayOfThisMonth).
                GroupBy(cm => new { cm.ReceiptDate.Date }, (key, group) => new { ReceiptDate = key.Date, CashAmount = group.Sum(p => p.CashAmount), ChequeAmount = group.Sum(p => p.ChequeAmount) });
         //   decimal dMaxValue_Cheque = oInputItems.Max(p => p.ChequeAmount);
         //   decimal dMaxValue_Cash = oInputItems.Max(p => p.CashAmount);
            foreach (var item in oInputItems)
            {
                chtDailyCollection.Series["Cash"].Points.AddXY(item.ReceiptDate.Day, item.CashAmount);
                chtDailyCollection.Series["Cheque"].Points.AddXY(item.ReceiptDate.Day, item.ChequeAmount);
            }

       //     chtDailyCollection.ChartAreas["ChartArea"].AxisY.Maximum = dMaxValue_Cash > dMaxValue_Cheque ? double.Parse(dMaxValue_Cash.ToString()) : double.Parse(dMaxValue_Cheque.ToString());
            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Minimum = 0;
            chtDailyCollection.ChartAreas["ChartArea"].AxisX.Maximum = (dtNow.Day - dtFirstDayOfThisMonth.Day + 1);
            chtDailyCollection.ChartAreas["ChartArea"].AxisY.Minimum = 0;
        }

        private void createMounthlyColectionChart()
        {
            dtFirstDayOfThisYear = new DateTime(dtNow.Year, 1, 1);

            #region Chart Formating
            clsChart.ChartFormat_Basic(ref chtMounthlyCollection);

            chtMounthlyCollection.Titles.Add("Monthly Collection Report Cash/Cheque (Current Year)");
            clsChart.ChartTitleFormat_Basic(ref chtMounthlyCollection);

            chtMounthlyCollection.Legends.Clear();
            chtMounthlyCollection.Legends.Add("Cash");
            chtMounthlyCollection.Legends.Add("Cheque");
            clsChart.ChartLegendsFormat_Basic(ref chtMounthlyCollection, "Cash");

            chtMounthlyCollection.ChartAreas.Clear();
            chtMounthlyCollection.ChartAreas.Add("ChartArea");
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Title = "Month";
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Title = "Amount";
            clsChart.ChartAxisFormat_Basic(ref chtMounthlyCollection, "ChartArea");

            chtMounthlyCollection.Series.Clear();
            chtMounthlyCollection.Series.Add("Cash");
            chtMounthlyCollection.Series.Add("Cheque");
            #endregion

            var oInputItems = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.ReceiptDate >= dtFirstDayOfThisYear).
              GroupBy(cm => new { cm.ReceiptDate.Month }, (key, group) => new { ReceiptDate = key.Month, CashAmount = group.Sum(p => p.CashAmount), ChequeAmount = group.Sum(p => p.ChequeAmount) });
         //   decimal dMaxValue_Cheque = oInputItems.Max(p => p.ChequeAmount);
         //   decimal dMaxValue_Cash = oInputItems.Max(p => p.CashAmount);
            foreach (var item in oInputItems)
            {
                chtMounthlyCollection.Series["Cash"].Points.AddXY(item.ReceiptDate, item.CashAmount);
                chtMounthlyCollection.Series["Cheque"].Points.AddXY(item.ReceiptDate, item.ChequeAmount);
            }

       //     chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Maximum = dMaxValue_Cash > dMaxValue_Cheque ? double.Parse(dMaxValue_Cash.ToString()) : double.Parse(dMaxValue_Cheque.ToString());
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Minimum = 0;
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Maximum = 12;
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Minimum = 0;
        }      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chtDailyCollection_Click(object sender, EventArgs e)
        {
            if (chtDailyCollection.Width == 300)
            {
                chtDailyCollection.Width = 835 - 14;
                chtDailyCollection.Height = 572 - 14;
            }
            else
            {
                chtDailyCollection.Width = 835 - 14;
                chtDailyCollection.Height = 572 - 14;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_cht_Sales c = new frm_cht_Sales();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_cht_Stock d = new frm_cht_Stock();
            d.ShowDialog();
        }

    }
}
