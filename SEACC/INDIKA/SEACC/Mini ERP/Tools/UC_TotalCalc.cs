using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class UC_TotalCalc : UserControl
    {
        public delegate void valueChanged(DataTable dt);
        public event valueChanged DoubleEntryUpdataed;
        private decimal ExRate = 1;

        private string Supplier_ID = "default";
        private string Customer_ID = "default";
        private bool bIsCredit = false;
        private bool bIstaxPayable = false;
        private bool bisEnableAmounts = false;

        #region Propertis
        public bool IsCredit
        {
            get
            {
                return bIsCredit;
                SetDebitCredit();
            }
            set
            {
                bIsCredit = value;
                SetDebitCredit();
            }
        }

        #region Presentage
        public decimal DiscountPresentage
        {
            get { return decimal.Parse(txtDisc_Present.Text.Trim()); }
            set { txtDisc_Present.Text = value.ToString(); }
        }

        public decimal NbtPresentage
        {
            get { return decimal.Parse(txtPercentageNBT.Text.Trim()); }
            set { txtPercentageNBT.Text = value.ToString(); }
        }

        public decimal VatPresentage
        {
            get
            {
                decimal d = 0;
                return decimal.Parse(txtPercentageVat.Text.Trim());
            }
            set { txtPercentageVat.Text = value.ToString(); }
        }

        public decimal OtherTaxPresentage
        {
            get { return decimal.Parse(txtPercentageOtherTax.Text.Trim()); }
            set { txtPercentageOtherTax.Text = value.ToString(); }
        }
        #endregion

        #region Amounts
        public decimal SubTotal
        {
            get { return decimal.Parse(txtSubTotal.Text.Trim()) * ExRate; }
            set
            {
                txtSubTotal.Text = value.ToString();
                CalculateTaxesAndGrandTotal(false);
            }
        }

        public decimal DiscountAmount
        {
            get { return decimal.Parse(txtDesc.Text.Trim()) * ExRate; }
        }

        public decimal NbtAmount
        {
            get { return decimal.Parse(txtNBT.Text.Trim()) * ExRate; }
        }

        public decimal VatAmount
        {
            get { return decimal.Parse(txtVat.Text.Trim()) * ExRate; }
        }

        public decimal OtherTaxAmount
        {
            get { return decimal.Parse(txtOtherTax.Text.Trim()) * ExRate; }
        }

        public decimal GrandTotal
        {
            get { return decimal.Parse(txtGrandTotal.Text.Trim()) * ExRate; }
        } 
        #endregion

        public bool IsSubTotalEnable
        {
            get { return txtSubTotal.ucEnabled; }
            set { txtSubTotal.ucEnabled = value; }
        }

        public bool IsDiscountEnable
        {
            get { return chkDisc.Checked; }
            set { chkDisc.Checked = value; }
        }

        public bool IsNBTenable
        {
            get { return chkNBT.Checked; }
            set { chkNBT.Checked = value; }
        }

        public bool IsVatEnable
        {
            get { return chkVat.Checked; }
            set { chkVat.Checked = value; }
        }

        public bool IsSvatEnable
        {
            get { return chkOtherTax.Checked; }
            set { chkOtherTax.Checked = value; }
        }

        public bool IsTaxPayable
        {
            get { return bIstaxPayable; }
            set { bIstaxPayable = value; }
        }

        public bool IsEnableAmounts
        {
            get { return bisEnableAmounts; }
            set { bisEnableAmounts = value; }
        }
        #endregion

        public UC_TotalCalc()
        {
            InitializeComponent();
        }

        private void SetDebitCredit()
        {
            txtSubTotal.IsCredit = bIsCredit;
            txtDesc.IsCredit = !bIsCredit;
            txtNBT.IsCredit = bIsCredit;
            txtOtherTax.IsCredit = bIsCredit;
            txtVat.IsCredit = bIsCredit;
            txtGrandTotal.IsCredit = !bIsCredit;
        }

        public void ClearFields()
        {
            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageOtherTax, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageNBT, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageVat, false);

            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
            txtDisc_Present.Text = "0";

            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            chkDisc.Checked = false;

            txtSubTotal.ClearFields();
            txtDesc.ClearFields();
            txtNBT.ClearFields();
            txtOtherTax.ClearFields();
            txtVat.ClearFields();
            txtGrandTotal.ClearFields();

            txtSubTotal.AccountCode = "default";
            txtDesc.AccountCode = "default";
        //    txtNBT.AccountCode = "default";
          //  txtOtherTax.AccountCode = "default";
          //  txtVat.AccountCode = "default";
            txtGrandTotal.AccountCode = "default";

            try
            {
                if (bIstaxPayable)
                {
                    txtNBT.AccountCode = clsConfig.sNBTGLCode_Payable;
                    txtVat.AccountCode = clsConfig.sVATGLCode_Payable;
                }
                else
                {
                    txtNBT.AccountCode = clsConfig.sNBTGLCode_Receivable;
                    txtVat.AccountCode = clsConfig.sVATGLCode_Receivable;
                }
            }
            catch (Exception)
            {
            }

            ExRate = 1;
        }

        private void uC_FinanceTextBox4_TextboxValuechanged()
        {
            CalculateTaxesAndGrandTotal(false);
        }

        public void SetEnableTax(bool NBTEnable, bool VatEnable, bool SvatEnable, string _SupplierID, string _Customer_ID,string _SalesNoteType_ID, decimal _ExRate)
        {
            Supplier_ID = _SupplierID;
            Customer_ID = _Customer_ID;

            if (Supplier_ID != "default")
                txtGrandTotal.AccountCode = clsMethods_GL.getAccountCode_Supplier(Supplier_ID);
            else
            {
                txtGrandTotal.AccountCode = clsMethods_GL.GetAccountCode_Customer(Customer_ID);
                txtSubTotal.AccountCode= clsMethods_GL.GetAccountCode_Sales(Customer_ID, _SalesNoteType_ID);

                txtDesc.AccountCode = clsMethods_GL.CheckAccountValidity(clsConfig.sAccountCode_Discount, false) ? clsConfig.sAccountCode_Discount : txtSubTotal.AccountCode;
            }

            chkNBT.Checked = NBTEnable;
            chkVat.Checked = VatEnable;
            chkOtherTax.Checked = SvatEnable;

            ExRate = _ExRate;

            txtSubTotal.initializeVariableRow();
            txtDesc.initializeVariableRow();

            CalculateTaxesAndGrandTotal(false);
        }

        public void FillDetail(decimal _SubTotal, decimal _DiscountTotal, decimal _NbtTotal, decimal _VatTotal, decimal _OtherTaxTotal, decimal _GrandTotal, decimal _DiscountPrecentage, decimal _NbtPercentage, decimal _VatPercentage, decimal _OtherTaxPercentage, string _SupplierID, string _Customer_ID, decimal _ExRate)
        {
            Supplier_ID = _SupplierID;
            Customer_ID = _Customer_ID;

            if (Supplier_ID != "default")
                txtGrandTotal.AccountCode = clsMethods_GL.getAccountCode_Supplier(Supplier_ID);
            else
                txtGrandTotal.AccountCode = clsMethods_GL.GetAccountCode_Customer(Customer_ID);

            if (_DiscountTotal > 0)
            {
                txtDisc_Present.Enabled = true;
                txtDesc.ucEnabled = true;
                chkDisc.Checked = true;
            }
            else
            {
                txtDisc_Present.Enabled = false;
                txtDesc.ucEnabled = false;
                chkDisc.Checked = false;
            }


            // chkDisc.Checked = (_DiscountTotal > 0) ? true : false;
            chkNBT.Checked = (_NbtTotal > 0) ? true : false;
            chkVat.Checked = (_VatTotal > 0) ? true : false;
            chkOtherTax.Checked = (_OtherTaxTotal > 0) ? true : false;

            txtDisc_Present.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(_DiscountPrecentage);
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(_NbtPercentage);
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(_OtherTaxPercentage);
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(_VatPercentage);

            ExRate = _ExRate;
            CalculateTaxesAndGrandTotal(true);

            txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(_SubTotal, _ExRate));
            txtDesc.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(_DiscountTotal, _ExRate));
            txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(_NbtTotal, _ExRate));
            txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(_OtherTaxTotal, _ExRate));
            txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(_VatTotal, _ExRate));
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(_GrandTotal, _ExRate));
        }

        public void SetGL(int LineNo, int TransactionCategoryID, string AccountCode, decimal Amount, bool isCredit, string SubAcct1_ID, string SubAcct2_ID, string remarks)
        {
            if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.SubTotal)
            {
                txtSubTotal.Open(LineNo, TransactionCategoryID, AccountCode, (isCredit ? 0 : Amount), (isCredit ? Amount : 0), SubAcct1_ID, SubAcct2_ID, remarks);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.Discount)
            {
                txtDesc.Open(LineNo, TransactionCategoryID, AccountCode, (isCredit ? 0 : Amount), (isCredit ? Amount : 0), SubAcct1_ID, SubAcct2_ID, remarks);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.NBT)
            {
                txtNBT.Open(LineNo, TransactionCategoryID, AccountCode, (isCredit ? 0 : Amount), (isCredit ? Amount : 0), SubAcct1_ID, SubAcct2_ID, remarks);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.VAT)
            {
                txtVat.Open(LineNo, TransactionCategoryID, AccountCode, (isCredit ? 0 : Amount), (isCredit ? Amount : 0), SubAcct1_ID, SubAcct2_ID, remarks);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.GrandTotal)
            {
                txtGrandTotal.Open(LineNo, TransactionCategoryID, AccountCode, (isCredit ? 0 : Amount), (isCredit ? Amount : 0), SubAcct1_ID, SubAcct2_ID, remarks);
            }
            CalculateTaxesAndGrandTotal(true);
        }

        public void ClearGL( int TransactionCategoryID)
        {
            if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.SubTotal)
            {
                txtSubTotal.ClearGL();
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.Discount)
            {
                txtDesc.ClearGL();
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.NBT)
            {
                txtNBT.ClearGL();
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.VAT)
            {
                txtVat.ClearGL();
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.GrandTotal)
            {
                txtGrandTotal.ClearGL();
            }
            CalculateTaxesAndGrandTotal(false);
        }

        private void CalculateTaxesAndGrandTotal(bool bisInit)
        {
            try
            {
                decimal dSubTotal = 0, dGrandTotal = 0, dDicountRate = 0, dNbtRate = 0, dVatRate = 0, dOtherTaxRate = 0, dDicountAmount = 0, dNbtAmount = 0, dVatAmount = 0, dOtherTaxAmount = 0;

                if (txtSubTotal.Text.Trim().Length > 0 && clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                    dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());

                if (txtDisc_Present.Text.Trim().Length > 0 && clsCommon.isCurrency(txtDisc_Present.Text.Trim()))
                    dDicountRate = decimal.Parse(txtDisc_Present.Text.Trim());

                if (txtPercentageNBT.Text.Trim().Length > 0 && clsCommon.isCurrency(txtPercentageNBT.Text.Trim()))
                    dNbtRate = decimal.Parse(txtPercentageNBT.Text.Trim());

                if (txtPercentageVat.Text.Trim().Length > 0 && clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                    dVatRate = decimal.Parse(txtPercentageVat.Text.Trim());

                if (txtPercentageOtherTax.Text.Trim().Length > 0 && clsCommon.isCurrency(txtPercentageOtherTax.Text.Trim()))
                    dOtherTaxRate = decimal.Parse(txtPercentageOtherTax.Text.Trim());

                if (bisInit)
                {
                    if (dSubTotal != 0)
                        dDicountRate = txtDesc.Amount * 100 / dSubTotal;

                    if (dSubTotal - txtDesc.Amount != 0)
                        dNbtRate = txtNBT.Amount * 100 / (dSubTotal - txtDesc.Amount);

                    if (dSubTotal - txtDesc.Amount + txtNBT.Amount != 0)
                        dVatRate = txtVat.Amount * 100 / (dSubTotal - txtDesc.Amount + txtNBT.Amount);
                }

                dGrandTotal = clsHelpMethods.CalculateGrandTotalAdvance_Round1(ref dSubTotal, ref dDicountAmount, dDicountRate, chkDisc.Checked,
                  ref dNbtAmount, dNbtRate, chkNBT.Checked, ref dVatAmount, dVatRate, chkVat.Checked, ref dOtherTaxAmount, dOtherTaxRate, chkOtherTax.Checked);

                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dSubTotal);
                txtDesc.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDicountAmount);
                txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(dNbtAmount);
                txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(dVatAmount);
                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(dOtherTaxAmount);
                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dGrandTotal);

                txtSubTotal.UpdateGl();
                txtDesc.UpdateGl();
                txtNBT.UpdateGl();
                txtVat.UpdateGl();
                txtGrandTotal.UpdateGl();

                DataTable dt = new DataTable();
                dt.Merge(txtSubTotal.glb_dt);
                if (txtDesc.Amount != 0)
                    dt.Merge(txtDesc.glb_dt);
                if (txtNBT.Amount != 0)
                    dt.Merge(txtNBT.glb_dt);
                if (txtVat.Amount != 0)
                    dt.Merge(txtVat.glb_dt);
                dt.Merge(txtGrandTotal.glb_dt);

                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    row["Line_No"] = i++;

                    row["Debit"] = decimal.Parse(row["Debit"].ToString()) * ExRate;
                    row["Credit"] = decimal.Parse(row["Credit"].ToString()) * ExRate;
                }

                DoubleEntryUpdataed(dt);
            }
            catch (Exception)
            {
            }
        }

        #region Check box status change
        private void chkDisc_CheckedChanged(object sender, EventArgs e)
        {
            txtDisc_Present.Enabled = chkDisc.Checked;
            txtDesc.ucEnabled = bisEnableAmounts ? chkDisc.Checked : !chkDisc.Checked;

            CalculateTaxesAndGrandTotal(false);
        }

        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
            {
                chkVat.Checked = true;

                if (clsConfig.bEnable_TAX_ManualMode)
                {
                    txtPercentageNBT.Enabled = true;
                    txtNBT.ucEnabled= bisEnableAmounts ? true : !false;
                }
            }
            else
            {
                txtPercentageNBT.Enabled = false;
                txtNBT.ucEnabled = false;
            }
            CalculateTaxesAndGrandTotal(false);
        }

        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                chkOtherTax.Checked = false;

                if (clsConfig.bEnable_TAX_ManualMode)
                {
                    txtPercentageVat.Enabled = true;
                    txtVat.ucEnabled= bisEnableAmounts ? true : !false;
                }
            }
            else
            {
                txtPercentageVat.Enabled = false;
                txtVat.ucEnabled = false;
            }
            CalculateTaxesAndGrandTotal(false);
        }

        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                chkVat.Checked = false;

                if (clsConfig.bEnable_TAX_ManualMode)
                {
                    txtPercentageOtherTax.Enabled = true;
                    txtOtherTax.ucEnabled= bisEnableAmounts ? true : !false;
                }
            }
            else
            {
                txtPercentageOtherTax.Enabled = false;
                txtOtherTax.ucEnabled = false;
            }
            CalculateTaxesAndGrandTotal(false);
        }
        #endregion

        public bool CheckValidity_DoubleEntry()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtSubTotal.Text.Length == 0 || !clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                {
                    strMessage += "\n" + "Sub Total ";
                    bStatus = false;
                }

                if (bStatus == false)
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!txtSubTotal.VerifiGlGrid())
                {
                    strMessage += "\n Please check GL entrys for Sub Total";
                    bStatus = false;
                }
                if (!txtNBT.VerifiGlGrid())
                {
                    strMessage += "\n Please check GL entrys for NBT";
                    bStatus = false;
                }
                if (!txtVat.VerifiGlGrid())
                {
                    strMessage += "\n Please check GL entrys for VAT";
                    bStatus = false;
                }
                if (!txtGrandTotal.VerifiGlGrid())
                {
                    strMessage += "\n Please check GL entrys for Grand Total";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        private void txtDisc_Present_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal(false);
        }

        private void txtDisc_Present_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CalculateTaxesAndGrandTotal(false);
        }

        public void UpdateAccCode(TransactionCategory TransactionCategoryID)
        {
            if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.SubTotal)
            {
                txtSubTotal.pictureBox1_Click(null, null);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.Discount)
            {
               txtDesc.pictureBox1_Click(null, null);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.NBT)
            {
                txtNBT.pictureBox1_Click(null, null);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.VAT)
            {
                txtVat.pictureBox1_Click(null, null);
            }
            else if ((TransactionCategory)(TransactionCategoryID) == TransactionCategory.GrandTotal)
            {
                txtGrandTotal.pictureBox1_Click(null, null);
            }
            CalculateTaxesAndGrandTotal(false);
        }

        private void txt_LedgerUpdated()
        {
            CalculateTaxesAndGrandTotal(false);
        }

        private void txtSubTotal_TextboxValuechanged()
        {

        }

        private void txtDesc_TextboxValuechanged()
        {
            decimal dSubTotal = 0, dDiscountPresentage = 0;
            if (txtSubTotal.Text.Trim().Length > 0 && clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());

            if (dSubTotal != 0)
                dDiscountPresentage = txtDesc.Amount * 100 / dSubTotal;
            txtDisc_Present.Text = dDiscountPresentage.ToString();

            CalculateTaxesAndGrandTotal(false);
        }

        private void txtNBT_TextboxValuechanged()
        {
            decimal dSubTotal = 0, sNbtAmount = 0;
            if (txtSubTotal.Text.Trim().Length > 0 && clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());

            if (dSubTotal - txtDesc.Amount != 0)
                sNbtAmount = txtNBT.Amount * 100 / (dSubTotal - txtDesc.Amount);
            txtPercentageNBT.Text = sNbtAmount.ToString();

            CalculateTaxesAndGrandTotal(false);
        }

        private void txtVat_TextboxValuechanged()
        {
            decimal dSubTotal = 0, sVatAmount = 0;
            if (txtSubTotal.Text.Trim().Length > 0 && clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());

            if (dSubTotal - txtDesc.Amount + txtNBT.Amount != 0)
                sVatAmount =txtVat.Amount * 100 / (dSubTotal - txtDesc.Amount + txtNBT.Amount);
            txtPercentageVat.Text = sVatAmount.ToString();

            CalculateTaxesAndGrandTotal(false);
        }

        private void txtOtherTax_TextboxValuechanged()
        {

        }

        private void txtGrandTotal_TextboxValuechanged()
        {

        }

        private void txtPercentageNBT_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal(false);
        }

        private void txtPercentageNBT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CalculateTaxesAndGrandTotal(false);
        }

        private void txtPercentageVat_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal(false);
        }

        private void txtPercentageVat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CalculateTaxesAndGrandTotal(false);
        }
    }
}