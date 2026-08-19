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
    public partial class frm_cht_Stock: Form
    {
        
        DateTime dtNow;
        DateTime dtFirstDayOfThisMonth;
        DateTime dtFirstDayOfThisYear;
 

        public frm_cht_Stock()
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

            chtSalesByCust.Titles.Add("Sales By Customer");
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
                if (chtSalesByCust.Series.IndexOf(item.CustomerId) == -1)
                {
                    chtSalesByCust.Series.Add(item.CustomerId);
                    chtSalesByCust.Legends.Add(item.CustomerId);
                }
                chtSalesByCust.Series[item.CustomerId].Points.AddXY(item.ReceiptDate.Day, item.CashAmount);
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

            chtMounthlyCollection.Titles.Add("Sales By Customer");
            clsChart.ChartTitleFormat_Basic(ref chtMounthlyCollection);

            chtMounthlyCollection.Legends.Clear();

            chtMounthlyCollection.ChartAreas.Clear();
            chtMounthlyCollection.ChartAreas.Add("ChartArea");
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Title = "Day";
            chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Title = "Amount";
            clsChart.ChartAxisFormat_Basic(ref chtMounthlyCollection, "ChartArea");

            chtMounthlyCollection.Series.Clear();
            #endregion


        //    var oSalesItems = tbl_sasInvoice_Detail.SelectAllByItem_ID("ITM / FG / 0544");
                //GroupBy(cm => new { cm.InvoiceDate.Month, cm.Customer_ID }, (key, group) => new { ReceiptDate = key.Month, CustomerId = key.Customer_ID, CashAmount = group.Sum(p => p.GrandTotal) });
            foreach (tbl_sasInvoice_Detail oSalesItems in tbl_sasInvoice_Detail.SelectAllByItem_ID("ITM / FG / 0544"))
            {
                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oSalesItems.Invoice_ID);
                if (oInvoice != null)
                {
                    if (chtMounthlyCollection.Series.IndexOf(oSalesItems.Item_ID) == -1)
                    {
                        chtMounthlyCollection.Series.Add(oSalesItems.Item_ID);
                        //   chtMounthlyCollection.Legends.Add(item.CustomerId);
                    }
                    chtMounthlyCollection.Series[oSalesItems.Item_ID].Points.AddXY(oInvoice.InvoiceDate, oSalesItems.Qty);
                }
                //chtSalesByCust.Series["Cheque"].Points.AddXY(item.ReceiptDate.Day, item.ChequeAmount);
            }

       //     chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Maximum = dMaxValue_Cash > dMaxValue_Cheque ? double.Parse(dMaxValue_Cash.ToString()) : double.Parse(dMaxValue_Cheque.ToString());
        //    chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Minimum = 0;
            //chtMounthlyCollection.ChartAreas["ChartArea"].AxisX.Maximum = (dtNow.Month);
            //chtMounthlyCollection.ChartAreas["ChartArea"].AxisY.Minimum = 0;
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
