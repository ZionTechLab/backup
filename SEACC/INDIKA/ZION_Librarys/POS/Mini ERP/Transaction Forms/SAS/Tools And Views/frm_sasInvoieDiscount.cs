using Digiteq_Logic;
using System;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_sasInvoiceDiscount : Form
    {
        #region Global Variable
        public event EventHandler FormresultOK;

        public decimal dCurrencyRate = 1;
        public string sInvoice_ID = "";

        bool bIsLocked_DiscountPresentage1 = true, bIsLocked_DiscountPresentage2 = true, bIsLocked_DiscountPresentage3 = true;
        #endregion

        #region Form Load
        public frm_sasInvoiceDiscount()
        {
            this.InitializeComponent();
        }

        private void frm_sasInvoieDiscount_Load(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        public void FillDetails(string Invoice_ID, decimal CurrencyRate)
        {
            //ClearFields();

            sInvoice_ID = Invoice_ID;
            dCurrencyRate = CurrencyRate;

            if (Invoice_ID.Length > 0)
            {
               // tbl_sasInvoice_Discount oInvDiscount = tbl_sasInvoice_Discount.Select(Invoice_ID);
                //if (oInvDiscount != null && oInvDiscount.Invoice_ID != "default")
                //{
                //    txtSubTotal.Tag = oInvDiscount.Subtotal;
                //    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(oInvDiscount.Subtotal, dCurrencyRate));

                //    txtAccumilatedTotal.Tag = oInvDiscount.AccumelatedTotalFinal;
                //    txtAccumilatedTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(oInvDiscount.AccumelatedTotalFinal, dCurrencyRate));

                //    txtPercentageDiscount1.Tag = oInvDiscount.DiscountPresentage1;
                //    txtPercentageDiscount1.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(oInvDiscount.DiscountPresentage1);
                //    txtPercentageDiscount2.Tag = oInvDiscount.DiscountPresentage2;
                //    txtPercentageDiscount2.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(oInvDiscount.DiscountPresentage2);
                //    txtPercentageDiscount3.Tag = oInvDiscount.DiscountPresentage3;
                //    txtPercentageDiscount3.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(oInvDiscount.DiscountPresentage3);

                //    if (oInvDiscount.DiscountAmount1 > 0)
                //    {
                //        chkDiscount1.Checked = true;
                //        txtDiscountTotal_1.Tag = oInvDiscount.DiscountAmount1;
                //        txtDiscountTotal_1.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(oInvDiscount.DiscountAmount1, dCurrencyRate));
                //        txtPercentageDiscount1.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(oInvDiscount.DiscountPresentage1);

                //    }
                //    if (oInvDiscount.DiscountAmount2 > 0)
                //    {
                //        chkDiscount2.Checked = true;
                //        txtDiscountTotal_2.Tag = oInvDiscount.DiscountAmount2;
                //        txtDiscountTotal_2.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(oInvDiscount.DiscountAmount2, dCurrencyRate));
                //        txtPercentageDiscount2.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(oInvDiscount.DiscountPresentage2);
                //    }
                //    if (oInvDiscount.DiscountAmount3 > 0)
                //    {
                //        chkDiscount3.Checked = true;
                //        txtDiscountTotal_3.Tag = oInvDiscount.DiscountAmount3;
                //        txtDiscountTotal_3.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(oInvDiscount.DiscountAmount3, dCurrencyRate));
                //        txtPercentageDiscount3.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(oInvDiscount.DiscountPresentage3);
                //    }
                //}
            }
        }

        public void ShowMultipleDiscount(decimal dSubTotal)
        {
            this.Show();
            txtSubTotal.Tag = dSubTotal;
            txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dSubTotal, dCurrencyRate));
            CalculatedAccumilatedTotal();
        }

        public void SetCustomerWiceDiscount(string Customer_ID)
        {
            ClearFields();
            foreach (tbl_genCustomerDiscount oDiscount in tbl_genCustomerDiscount.SelectAllByCustomer_ID(Customer_ID))
            {
                switch (oDiscount.Discount_Id)
                {
                    case "D001":
                        bIsLocked_DiscountPresentage1 = clsConfig.bIsRateLocked_Multiple_Discount ? true : oDiscount.IsRateLocked;
                        txtPercentageDiscount1.Enabled = bIsLocked_DiscountPresentage1 ? false : true;
                        txtPercentageDiscount1.Text = oDiscount.DiscountPresentage.ToString();
                        txtPercentageDiscount1.Tag = oDiscount.DiscountPresentage;
                        chkDiscount1.Checked = oDiscount.IsActive;
                        break;
                    case "D002":
                        bIsLocked_DiscountPresentage2 = clsConfig.bIsRateLocked_Multiple_Discount ? true : oDiscount.IsRateLocked;
                        txtPercentageDiscount2.Enabled = bIsLocked_DiscountPresentage2 ? false : true;
                        txtPercentageDiscount2.Tag = oDiscount.DiscountPresentage;
                        txtPercentageDiscount2.Text = oDiscount.DiscountPresentage.ToString();
                        chkDiscount2.Checked = oDiscount.IsActive;
                        break;
                    case "D003":
                        bIsLocked_DiscountPresentage3 = clsConfig.bIsRateLocked_Multiple_Discount ? true : oDiscount.IsRateLocked;
                        txtPercentageDiscount3.Enabled = bIsLocked_DiscountPresentage3 ? false : true;
                        chkDiscount3.Checked = oDiscount.IsActive;
                        txtPercentageDiscount3.Text = oDiscount.DiscountPresentage.ToString();
                        txtPercentageDiscount3.Tag = oDiscount.DiscountPresentage;
                        break;
                    default:
                        break;
                }
            }
        }

        #region Clear Fields
        public void ClearFields()
        {
            txtSubTotal.Tag = 0;

            txtDiscountTotal_1.Tag = 0;
            txtDiscountTotal_2.Tag = 0;
            txtDiscountTotal_3.Tag = 0;

            txtPercentageDiscount1.Tag = 0;
            txtPercentageDiscount2.Tag = 0;
            txtPercentageDiscount3.Tag = 0;

            txtAccumilatedTotal.Tag = 0;

            txtSubTotal.Text = "0.00";

            txtPercentageDiscount1.Text = "0";
            txtPercentageDiscount2.Text = "0";
            txtPercentageDiscount3.Text = "0";

            txtDiscountTotal_1.Text = "0.00";
            txtDiscountTotal_2.Text = "0.00";
            txtDiscountTotal_3.Text = "0.00";

            txtAccumilatedTotal.Text = "0.00";

            txtPercentageDiscount1.Enabled = false;
            txtPercentageDiscount2.Enabled = false;
            txtPercentageDiscount3.Enabled = false;

            txtDiscountTotal_1.Enabled = false;
            txtDiscountTotal_2.Enabled = false;
            txtDiscountTotal_3.Enabled = false;

            chkDiscount1.Checked = false;
            chkDiscount2.Checked = false;
            chkDiscount3.Checked = false;

            #region Load Discount names
            foreach (tbl_zDiscount oDiscount in tbl_zDiscount.SelectAll())
            {
                switch (oDiscount.Discount_Id)
                {
                    case "D001":
                        chkDiscount1.Text = oDiscount.DiscountName;
                        break;
                    case "D002":
                        chkDiscount2.Text = oDiscount.DiscountName;
                        break;
                    case "D003":
                        chkDiscount3.Text = oDiscount.DiscountName;
                        break;
                    default:
                        break;
                }
            }
            #endregion

            sInvoice_ID = "";
        }
        #endregion

        #region Calculate Accumilated Total
        private void CalculatedAccumilatedTotal()
        {
            decimal dSubTotal = decimal.Parse(txtSubTotal.Tag.ToString());
            decimal dAccumilateTotal = dSubTotal;

            decimal dPresentage1 = decimal.Parse(txtPercentageDiscount1.Tag.ToString());
            decimal dPresentage2 = decimal.Parse(txtPercentageDiscount2.Tag.ToString());
            decimal dPresentage3 = decimal.Parse(txtPercentageDiscount3.Tag.ToString());

            if (chkDiscount1.Checked)
            {
                decimal dDiscount1 = dPresentage1 * dAccumilateTotal / 100;
                dAccumilateTotal -= dDiscount1;
                txtDiscountTotal_1.Tag = dDiscount1;
                txtDiscountTotal_1.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dDiscount1, dCurrencyRate));
            }
            if (chkDiscount2.Checked)
            {
                decimal dDiscount2 = dPresentage2 * dAccumilateTotal / 100;
                dAccumilateTotal -= dDiscount2;
                txtDiscountTotal_2.Tag = dDiscount2;
                txtDiscountTotal_2.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dDiscount2, dCurrencyRate));
            }
            if (chkDiscount3.Checked)
            {
                decimal dDiscount3 = dPresentage3 * dAccumilateTotal / 100;
                dAccumilateTotal -= dDiscount3;
                txtDiscountTotal_3.Tag = dDiscount3;
                txtDiscountTotal_3.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dDiscount3, dCurrencyRate));
            }

            txtAccumilatedTotal.Tag = dAccumilateTotal;
            txtAccumilatedTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dAccumilateTotal, dCurrencyRate));
        }
        #endregion

        #region Key Leave
        private void txtDiscountTotal_1_Leave(object sender, EventArgs e)
        {
            decimal dSubTotal = decimal.Parse(txtSubTotal.Tag.ToString());
            decimal dDisount1 = decimal.Parse(txtDiscountTotal_1.Text);
            decimal discountPresentage1 = dDisount1 * 100 / dSubTotal;

            txtPercentageDiscount1.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(discountPresentage1, dCurrencyRate));
            txtPercentageDiscount1.Tag = discountPresentage1;

            CalculatedAccumilatedTotal();
        }
        private void txtDiscountTotal_2_Leave(object sender, EventArgs e)
        {
            decimal dSubTotal = decimal.Parse(txtSubTotal.Tag.ToString());
            decimal dDisount1 = decimal.Parse(txtDiscountTotal_1.Text);
            decimal dDisount2 = decimal.Parse(txtDiscountTotal_2.Text);
            decimal discountPresentage2 = dDisount2 * 100 / (dSubTotal - dDisount1);

            txtPercentageDiscount2.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(discountPresentage2, dCurrencyRate));
            txtPercentageDiscount2.Tag = discountPresentage2;

            CalculatedAccumilatedTotal();
        }
        private void txtDiscountTotal_3_Leave(object sender, EventArgs e)
        {
            decimal dSubTotal = decimal.Parse(txtSubTotal.Tag.ToString());
            decimal dDisount1 = decimal.Parse(txtDiscountTotal_1.Text);
            decimal dDisount2 = decimal.Parse(txtDiscountTotal_2.Text);
            decimal dDisount3 = decimal.Parse(txtDiscountTotal_3.Text);
            decimal discountPresentage3 = dDisount3 * 100 / (dSubTotal - dDisount1 - dDisount2);

            txtPercentageDiscount3.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(discountPresentage3, dCurrencyRate));
            txtPercentageDiscount3.Tag = discountPresentage3;

            CalculatedAccumilatedTotal();
        }

        private void txtPercentageDiscount1_Leave(object sender, EventArgs e)
        {
            decimal dDiscountPresentage1 = decimal.Parse(txtPercentageDiscount1.Text);
            txtPercentageDiscount1.Tag = clsHelpMethods.getSavePrice(dDiscountPresentage1, dCurrencyRate);
            CalculatedAccumilatedTotal();
        }
        private void txtPercentageDiscount2_Leave(object sender, EventArgs e)
        {
            decimal dDiscountPresentage2 = decimal.Parse(txtPercentageDiscount2.Text);
            txtPercentageDiscount2.Tag = clsHelpMethods.getSavePrice(dDiscountPresentage2, dCurrencyRate);
            CalculatedAccumilatedTotal();
        }
        private void txtPercentageDiscount3_Leave(object sender, EventArgs e)
        {
            decimal dDiscountPresentage3 = decimal.Parse(txtPercentageDiscount3.Text);
            txtPercentageDiscount3.Tag = clsHelpMethods.getSavePrice(dDiscountPresentage3, dCurrencyRate);
            CalculatedAccumilatedTotal();
        }

        #endregion

        #region Key Press Event
        private void txtDiscountTotal_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleDigiteValues(e);
        }
        private void txtDiscountTotal_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleDigiteValues(e);
        }
        private void txtDiscountTotal_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleDigiteValues(e);
        }

        private void txtPercentageDiscount1_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleDigiteValues(e);
        }
        private void txtPercentageDiscount2_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleDigiteValues(e);
        }
        private void txtPercentageDiscount3_KeyPress(object sender, KeyPressEventArgs e)
        {
            handleDigiteValues(e);
        }
        #endregion

        #region Checked Changed Event
        private void chkDiscount1_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledDisableFields();
        }
        private void chkDiscount2_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledDisableFields();
        }
        private void chkDiscount3_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledDisableFields();
        }
        #endregion

        #region Set Enabled Disabled Fields
        private void SetEnabledDisableFields()
        {
            txtPercentageDiscount1.Enabled = false;
            txtPercentageDiscount2.Enabled = false;
            txtPercentageDiscount3.Enabled = false;

            txtDiscountTotal_1.Enabled = false;
            txtDiscountTotal_2.Enabled = false;
            txtDiscountTotal_3.Enabled = false;

            txtDiscountTotal_1.Text = "0.00";
            txtDiscountTotal_1.Tag = 0;
            txtDiscountTotal_2.Text = "0.00";
            txtDiscountTotal_2.Tag = 0;
            txtDiscountTotal_3.Text = "0.00";
            txtDiscountTotal_3.Tag = 0;

            if (chkDiscount1.Checked)
            {
                if (!bIsLocked_DiscountPresentage1)
                {
                    txtPercentageDiscount1.Enabled = true;
                    txtDiscountTotal_1.Enabled = true;
                }
            }
            if (chkDiscount2.Checked)
            {
                if (!bIsLocked_DiscountPresentage2)
                {
                    txtPercentageDiscount2.Enabled = true;
                    txtDiscountTotal_2.Enabled = true;
                }
            }
            if (chkDiscount3.Checked)
            {
                if (!bIsLocked_DiscountPresentage3)
                {
                    txtPercentageDiscount3.Enabled = true;
                    txtDiscountTotal_3.Enabled = true;
                }
            }

            CalculatedAccumilatedTotal();
        }
        #endregion

        public void Update()
        {
            //tbl_sasInvoice_Discount oOldrecord = tbl_sasInvoice_Discount.Select(sInvoice_ID);
            //if (oOldrecord != null)
            //    oOldrecord.Delete();

            //decimal dSubTotal = decimal.Parse(txtSubTotal.Tag.ToString());

            //decimal dDiscountPresentage1 = decimal.Parse(txtPercentageDiscount1.Tag.ToString());
            //decimal dDiscountPresentage2 = decimal.Parse(txtPercentageDiscount2.Tag.ToString());
            //decimal dDiscountPresentage3 = decimal.Parse(txtPercentageDiscount3.Tag.ToString());

            //decimal dDiscountAmount1 = decimal.Parse(txtDiscountTotal_1.Tag.ToString());
            //decimal dDiscountAmount2 = decimal.Parse(txtDiscountTotal_2.Tag.ToString());
            //decimal dDiscountAmount3 = decimal.Parse(txtDiscountTotal_3.Tag.ToString());

            //decimal dAcumilatedTotal = decimal.Parse(txtAccumilatedTotal.Tag.ToString());

            //tbl_sasInvoice_Discount oInvoiceDetail = new tbl_sasInvoice_Discount(sInvoice_ID, dSubTotal, dDiscountPresentage1, dDiscountAmount1, dDiscountPresentage2, dDiscountAmount2, dDiscountPresentage3, dDiscountAmount3, dAcumilatedTotal);
            //oInvoiceDetail.Insert();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            CalculatedAccumilatedTotal();
            this.Hide();
            FormresultOK(sender, e);
        }
        public void getTotalDiscountPresentage(ref decimal dTotalDiscount_Amount, ref decimal dTotalDiscount_Presentage)
        {
            try
            {
                decimal dSubtotal = decimal.Parse(txtSubTotal.Tag.ToString());
                dTotalDiscount_Amount = dSubtotal - decimal.Parse(txtAccumilatedTotal.Tag.ToString());
                dTotalDiscount_Presentage = (dTotalDiscount_Amount / dSubtotal) * 100;
            }
            catch (Exception)
            {
            }
        }

        private void handleDigiteValues(KeyPressEventArgs x)
        {
            if (!char.IsControl(x.KeyChar) && !char.IsDigit(x.KeyChar) && x.KeyChar != '.')
                x.Handled = true;
        }
    }
}