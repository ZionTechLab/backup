using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.Windows.Forms.DataVisualization.Charting;

namespace Digiteq
{
    public partial class frm_cht_Sales: Form
    {
        
        DateTime dtNow;
        DateTime dtFirstDayOfThisMonth;
        DateTime dtFirstDayOfThisYear;


        public frm_cht_Sales()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            createSalesByCust();
            createMounthlyColectionChart();
        }

        private void createSalesByCust()
        {
            dtNow = clsSecurity.getServerDateTime();
            dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            #region Chart Formating
            clsChart.ChartFormat_Basic(ref chtSalesByCust);

            chtSalesByCust.Titles.Add("Daily Sales By Customer");
            clsChart.ChartTitleFormat_Basic(ref chtSalesByCust);

            chtSalesByCust.Legends.Clear();

            chtSalesByCust.ChartAreas.Clear();
            chtSalesByCust.ChartAreas.Add("ChartArea");
            chtSalesByCust.ChartAreas["ChartArea"].AxisX.Title = "Day";
            chtSalesByCust.ChartAreas["ChartArea"].AxisY.Title = "Amount";
            clsChart.ChartAxisFormat_Basic(ref chtSalesByCust, "ChartArea");

            chtSalesByCust.Series.Clear();
            #endregion


            var oInputItems = tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.InvoiceDate >= dtFirstDayOfThisMonth).
                GroupBy(cm => new { cm.InvoiceDate.Date, cm.Customer_ID }, (key, group) => new { ReceiptDate = key.Date, CustomerId = key.Customer_ID, CashAmount = group.Sum(p => p.GrandTotal) });
            foreach (var item in oInputItems)
            {
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(item.CustomerId);
                if (oCustomer != null && oCustomer.Customer_ID != "default")
                {
                    if (chtSalesByCust.Series.IndexOf(item.CustomerId) == -1)
                    {

                        chtSalesByCust.Series.Add(item.CustomerId);
                        chtSalesByCust.Legends.Add(oCustomer.CustomerName);

                    }
                    chtSalesByCust.Series[item.CustomerId].Points.AddXY(item.ReceiptDate.Day, item.CashAmount);
                }
                //chtSalesByCust.Series["Cheque"].Points.AddXY(item.ReceiptDate.Day, item.ChequeAmount);
            }
            //clsCommon.ChartLegendsFormat_Basic(ref chtSalesByCust, "Cash");
            //   chtDailyCollection.ChartAreas["ChartArea"].AxisY.Maximum = dMaxValue_Cash > dMaxValue_Cheque ? double.Parse(dMaxValue_Cash.ToString()) : double.Parse(dMaxValue_Cheque.ToString());
            chtSalesByCust.ChartAreas["ChartArea"].AxisX.Minimum = 0;
            chtSalesByCust.ChartAreas["ChartArea"].AxisX.Maximum = (dtNow.Day - dtFirstDayOfThisMonth.Day + 1);
            chtSalesByCust.ChartAreas["ChartArea"].AxisY.Minimum = 0;
        }

        private void createMounthlyColectionChart()
        {
            dtFirstDayOfThisYear = new DateTime(dtNow.Year, 1, 1);
            #region Chart Formating
            clsChart.ChartFormat_Basic(ref chtMounthlyCollection);

            chtMounthlyCollection.Titles.Add("Monthly Sales By Customer");
            clsChart.ChartTitleFormat_Basic(ref chtMounthlyCollection);

            chtMounthlyCollection.Legends.Clear();

            chtMounthlyCollection.ChartAreas.Clear();
            chtMounthlyCollection.ChartAreas.Add("ChartArea");
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Title = "Day";
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Title = "Amount";
            clsChart.ChartAxisFormat_Basic(ref chtMounthlyCollection, "ChartArea");

            chtMounthlyCollection.Series.Clear();
            #endregion


            var oInputItems = tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.InvoiceDate >= dtFirstDayOfThisYear).
                GroupBy(cm => new { cm.InvoiceDate.Month, cm.Customer_ID }, (key, group) => new { ReceiptDate = key.Month, CustomerId = key.Customer_ID, CashAmount = group.Sum(p => p.GrandTotal) });
            foreach (var item in oInputItems)
            {
                if (chtMounthlyCollection.Series.IndexOf(item.CustomerId) == -1)
                {
                    chtMounthlyCollection.Series.Add(item.CustomerId);
                 //   chtMounthlyCollection.Legends.Add(item.CustomerId);
                }
                chtMounthlyCollection.Series[item.CustomerId].Points.AddXY(item.ReceiptDate, item.CashAmount);
                //chtSalesByCust.Series["Cheque"].Points.AddXY(item.ReceiptDate.Day, item.ChequeAmount);
            }

       //     chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Maximum = dMaxValue_Cash > dMaxValue_Cheque ? double.Parse(dMaxValue_Cash.ToString()) : double.Parse(dMaxValue_Cheque.ToString());
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Minimum = 0;
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Maximum = (dtNow.Month);
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Minimum = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chtDailyCollection_Click(object sender, EventArgs e)
        {
            if (chtSalesByCust.Width == 300)
            {
                chtSalesByCust.Width = 835 - 14;
                chtSalesByCust.Height = 572 - 14;
            }
            else
            {
                chtSalesByCust.Width = 835 - 14;
                chtSalesByCust.Height = 572 - 14;
            }
        }

        private void chtMounthlyCollection_Click(object sender, EventArgs e)
        {

        }

        private void x1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
