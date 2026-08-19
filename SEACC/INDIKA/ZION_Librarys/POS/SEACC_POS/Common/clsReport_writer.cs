using DataTire;
using Digiteq_Logic;
using Digiteq_Logic_POS;
using SEACC_POS.Common;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SEACC_POS
{
    public class clsReport_writer
    {
        #region Class Variables
        int iPoS_Tx_Index;
        public string sPaidAmount = clsCommon_POS.FormatToNumberWithTwoDecimalPlaces(0), sBalanceAmount = clsCommon_POS.FormatToNumberWithTwoDecimalPlaces(0);
        #endregion

        #region Constructors
        public clsReport_writer(int iPOS_TxIndex)
        {
            this.iPoS_Tx_Index = iPOS_TxIndex;
        }

        public clsReport_writer(string sPOS_TxID)
        {
            this.iPoS_Tx_Index = int.Parse(sPOS_TxID);
        } 
        #endregion

        #region Print Document Direct

        public void printDocumnet()
        {
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDoc_PrintPage);

            PrintDialog pdi = new PrintDialog();
            pdi.Document = printDoc;
            if (clsConfig_POS.bDirect_Print_R2_Pos_Invoice)
                printDoc.Print();
            else
            {
                if (pdi.ShowDialog() == DialogResult.OK)
                {
                    //PntDocTag.Print();
                    PrintPreviewDialog PrintPreviewDialog1 = new PrintPreviewDialog();
                    PrintPreviewDialog1.Document = printDoc;
                    //  PrintPreviewDialog1.Width = 200;
                    PrintPreviewDialog1.ShowDialog();
                }
            }
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int i_Xvalue = 10, i_Yvalue = 5;
            StringFormat sf = new StringFormat();
            Font Font_Title1 = new Font("Calibri", 10, FontStyle.Bold);
            Font Font_Title2 = new Font("Calibri", 10);
            Font Font_Title_Sinhala_Company = new Font("4u-Bindumathi", 13);
            Font Font_Title_Sinhala = new Font("4u-Bindumathi", 10);
            Font Font_Title_Sinhala_Big = new Font("4u-Bindumathi", 9, FontStyle.Bold);
            Font Font_Title3 = new Font("Calibri", 7);
            string sDottedLine = "--------------------------------------------------------------------";

            tbl_posTransaction oInvoice = tbl_posTransaction.Select(iPoS_Tx_Index);
            if (oInvoice != null)
            {
                e.Graphics.DrawString(clsConfig.sInvoiceTop, Font_Title_Sinhala_Company, Brushes.Black, i_Xvalue, i_Yvalue, sf);
                e.Graphics.DrawString(clsConfig.sInvoiceAddress, Font_Title_Sinhala, Brushes.Black, i_Xvalue, i_Yvalue += 19, sf);

                e.Graphics.DrawString(sDottedLine, Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue += 10);

                e.Graphics.DrawString("Invoice Number", Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue += 15); e.Graphics.DrawString(": " + iPoS_Tx_Index, Font_Title2, Brushes.Black, i_Xvalue + 105, i_Yvalue);
                e.Graphics.DrawString("Invoice Date", Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue + 20, sf); e.Graphics.DrawString(": " + clsFormatter.FormatDate_Short(oInvoice.PosTransactiondate), Font_Title2, Brushes.Black, i_Xvalue + 105, i_Yvalue + 20);
                e.Graphics.DrawString("Customer Name", Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue + 40, sf); e.Graphics.DrawString(": " + clsGenaralName.getName_Customer(oInvoice.Customer_ID), Font_Title2, Brushes.Black, i_Xvalue + 105, i_Yvalue + 40);
                e.Graphics.DrawString(sDottedLine, Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue + 50, sf);

                e.Graphics.DrawString("#", Font_Title1, Brushes.Black, i_Xvalue, i_Yvalue + 60, sf);

                //For Walimada
                e.Graphics.DrawString("Qty", Font_Title1, Brushes.Black, i_Xvalue + 30, i_Yvalue + 60, sf);
                e.Graphics.DrawString("Price", Font_Title1, Brushes.Black, i_Xvalue + 100, i_Yvalue + 60, sf);
                e.Graphics.DrawString("Amount", Font_Title1, Brushes.Black, i_Xvalue + 160, i_Yvalue + 60, sf);

                int i = 0;
                foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(iPoS_Tx_Index).OrderBy(p => p.Line_No))
                {
                    i_Yvalue += 15;
                    e.Graphics.DrawString(oDetail.Line_No.ToString(), Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue + 70, sf);
                    string sQty = "";
                    switch (clsConfig.sPOSBillDecimalPoint)
                    {
                        case "0":
                            sQty = clsFormatter.FormatDecimalPlaces_Quantity(oDetail.Qty);
                            break;
                        case "2":
                            sQty = clsCommon_POS.FormatToNumberWithTwoDecimalPlaces(oDetail.Qty);
                            break;
                        case "3":
                            sQty = clsCommon_POS.FormatToCurrecyWithThreeDecimalPlaces(oDetail.Qty);
                            break;
                        case "4":
                            sQty = clsCommon_POS.FormatToNumberWithFourDecimalPlaces(oDetail.Qty);
                            break;
                        default:
                            sQty = clsFormatter.FormatDecimalPlaces_Quantity(oDetail.Qty);
                            break;
                    }

                    //For Walimada
                    e.Graphics.DrawString(sQty, Font_Title2, Brushes.Black, i_Xvalue + 30, i_Yvalue + 83, sf);
                    e.Graphics.DrawString("x", Font_Title2, Brushes.Black, i_Xvalue + 90, i_Yvalue + 83, sf);
                    e.Graphics.DrawString(clsFormatter.FormatDecimalPlaces_Price(oDetail.UnitPrice), Font_Title2, Brushes.Black, i_Xvalue + 100, i_Yvalue + 83, sf);
                    e.Graphics.DrawString(clsFormatter.FormatDecimalPlaces_Price(oDetail.NetAmount), Font_Title2, Brushes.Black, i_Xvalue + 160, i_Yvalue + 83, sf);
                    i_Yvalue += 10;
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                    if (oItem != null)
                        e.Graphics.DrawString(oItem.Description1, Font_Title_Sinhala, Brushes.Black, i_Xvalue + 30, i_Yvalue + 63, sf);
                    i++;
                }
                //i = i;
                e.Graphics.DrawString(sDottedLine, Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue + 85, sf);

                e.Graphics.DrawString("Total    :", Font_Title2, Brushes.Black, i_Xvalue, i_Yvalue + 95, sf);
                e.Graphics.DrawString(clsFormatter.FormatDecimalPlaces_Price(oInvoice.GrandTotal), Font_Title2, Brushes.Black, i_Xvalue + 160, i_Yvalue + 95);
                //if (bFirstBillPrint)
                //{
                //    e.Graphics.DrawString("Paid", Font_Title2, System.Drawing.Brushes.Black, i_Xvalue, i_Yvalue + 110, sf); 
                //    e.Graphics.DrawString(": " + sPaidAmount, Font_Title2, System.Drawing.Brushes.Black, i_Xvalue + 85, i_Yvalue + 110);
                //    e.Graphics.DrawString("Balance", Font_Title2, System.Drawing.Brushes.Black, i_Xvalue, i_Yvalue + 130, sf); 
                //    e.Graphics.DrawString(": " + sBalanceAmount, Font_Title2, System.Drawing.Brushes.Black, i_Xvalue + 85, i_Yvalue + 130);
                //}
                //else
                //{
                //    e.Graphics.DrawString("Paid", Font_Title2, System.Drawing.Brushes.Black, i_Xvalue, i_Yvalue + 110, sf); 
                //    e.Graphics.DrawString(": " + clsFormatter.FormatDecimalPlaces_Price(oInvoice.SeattleAmount), Font_Title2, System.Drawing.Brushes.Black, i_Xvalue + 85, i_Yvalue + 110);
                //    e.Graphics.DrawString("Balance", Font_Title2, System.Drawing.Brushes.Black, i_Xvalue, i_Yvalue + 130, sf);
                //    e.Graphics.DrawString(": " + clsFormatter.FormatDecimalPlaces_Price(oInvoice.SeattleAmount - oInvoice.GrandTotal), Font_Title2, System.Drawing.Brushes.Black, i_Xvalue + 85, i_Yvalue + 130);
                //}
                e.Graphics.DrawString(clsConfig.sInvoiceBottom, Font_Title_Sinhala, Brushes.Black, i_Xvalue + 40, i_Yvalue + 120, sf);

            }
        }

        #endregion
    }
}