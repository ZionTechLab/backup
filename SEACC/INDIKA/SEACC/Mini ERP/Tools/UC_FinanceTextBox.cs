using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class UC_FinanceTextBox : UserControl
    {
        public delegate void ValueChange();
        public event ValueChange TextboxValuechanged;
        public event ValueChange LedgerUpdated;

        public string AccountCode = "default";

        public DataTable glb_dt = new DataTable();
        bool bIsCredit = false;
        TransactionCategory TransactionCatagory = TransactionCategory.Other_Cr;

        #region Propertise
        public string Text
        {
            get { return txtAmount.Text; }
            set { txtAmount.Text = value; }
        }

        public decimal Amount
        {
            get { return decimal.Parse(txtAmount.Text); }

        }
        public bool ucEnabled
        {
            get { return txtAmount.Enabled; }
            set { txtAmount.Enabled = value; }
        }

        public bool IsCredit
        {
            get { return bIsCredit; }
            set { bIsCredit = value; }
        }

        public TransactionCategory TxnCat
        {
            get { return TransactionCatagory; }
            set
            {
                TransactionCatagory = value;

                if (TxnCat == TransactionCategory.SVAT)
                    pictureBox1.BackgroundImage = null;
                else
                    pictureBox1.BackgroundImage = Digiteq.Properties.Resources.info;
            }
        } 
        #endregion

        public UC_FinanceTextBox()
        {
            InitializeComponent();

            txtAmount.Text = "0.00";

            glb_dt.Columns.Add("Line_No", typeof(int));
            glb_dt.Columns.Add("TxnCategory_ID", typeof(string));
            glb_dt.Columns.Add("TxnCategory", typeof(string));
            glb_dt.Columns.Add("GLCode", typeof(string));
            glb_dt.Columns.Add("GLName", typeof(string));
            glb_dt.Columns.Add("Debit", typeof(decimal));
            glb_dt.Columns.Add("Credit", typeof(decimal));
            glb_dt.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dt.Columns.Add("SubAcct1_Name", typeof(string));
            glb_dt.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dt.Columns.Add("SubAcct2_Name", typeof(string));
            glb_dt.Columns.Add("remarks", typeof(string));
        }

        public void ClearFields()
        {
            glb_dt.Clear();
            txtAmount.Text = "0.00";
        }

        public void ClearGL()
        {
            glb_dt.Clear();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }

        public void UpdateGl()
        {
            if (TransactionCatagory == TransactionCategory.NBT || TransactionCatagory == TransactionCategory.VAT || TransactionCatagory == TransactionCategory.GrandTotal)
            {
                if (TransactionCatagory == TransactionCategory.NBT || TransactionCatagory == TransactionCategory.VAT)
                {
                    DataRow dr = glb_dt.Select().FirstOrDefault();
                    if (dr != null)
                    {
                        AccountCode = dr["GLCode"].ToString();
                    }
                }
                UpdateFixedRow();
            }
            VerifiGlGrid();
        }

        public bool VerifiGlGrid()
        {
            bool bStatus = false;

            try
            {
                if (clsCommon.isCurrency(txtAmount.Text.Trim()))
                {
                    bool isGlAccountAssigned = true;
                    decimal dTotAmount = 0;

                    foreach (DataRow row in glb_dt.Rows)
                    {
                        if (row["GLCode"].ToString() == "" || row["GLCode"].ToString() == "")
                            isGlAccountAssigned = false;

                        dTotAmount += decimal.Parse(row["Debit"].ToString());
                        dTotAmount -= decimal.Parse(row["Credit"].ToString());
                    }
                    if (IsCredit)
                        dTotAmount = -dTotAmount;

                    if (isGlAccountAssigned && decimal.Parse(txtAmount.Text.Trim()) == dTotAmount)
                    {
                        pictureBox1.BackgroundImage = Digiteq.Properties.Resources.success;
                        bStatus = true;
                    }
                    else
                        pictureBox1.BackgroundImage = Digiteq.Properties.Resources.info;
                }
                else
                {
                    pictureBox1.BackgroundImage = Digiteq.Properties.Resources.info;
                }
            }
            catch (Exception)
            {
            }
            return bStatus;
        }

        public void Open(int LineNo, int TransactionCategoryID, string AccountCode, decimal DebitAmount, decimal CreditAmount, string SubAcct1_ID, string SubAcct2_ID, string remarks)
        {
            DataRow dr;
            if (TransactionCatagory == TransactionCategory.NBT || TransactionCatagory == TransactionCategory.VAT || TransactionCatagory == TransactionCategory.GrandTotal)
            {
                if (glb_dt.Rows.Count == 0)
                {
                    dr = glb_dt.NewRow();
                    glb_dt.Rows.Add(dr);
                }
                else
                    dr = glb_dt.Select().FirstOrDefault();
            }
            else
            {
                dr = glb_dt.NewRow();
                glb_dt.Rows.Add(dr);
            }


            dr["Line_No"] = LineNo;
            dr["TxnCategory_ID"] = TransactionCategoryID;
            dr["TxnCategory"] = GetEnumDescription((TransactionCategory)TransactionCategoryID);
            dr["GLCode"] = AccountCode;
            dr["GLName"] = clsGenaralName.getName_AccountName(AccountCode);
            dr["Debit"] = DebitAmount;
            dr["Credit"] = CreditAmount;
            dr["SubAcct1_ID"] = SubAcct1_ID;
            dr["SubAcct1_Name"] = clsGenaralName.getName_AccCostCenter1(SubAcct1_ID);
            dr["SubAcct2_ID"] = SubAcct2_ID;
            dr["SubAcct2_Name"] = clsGenaralName.getName_AccCostCenter2(SubAcct2_ID); ;
            dr["remarks"] = remarks;
        }

        public string GetEnumDescription(Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();

        }

        private void UpdateFixedRow()
        {
            #region Maintain Row count
            if (glb_dt.Rows.Count == 0)
                glb_dt.Rows.Add();

            else if (glb_dt.Rows.Count > 1)
            {
                int i = 0;
                foreach (DataRow row in glb_dt.Rows)
                {
                    if (i > 1)
                        row.Delete();
                    i++;
                }
            }
            #endregion

            #region Update Row
            DataRow dr = glb_dt.Select().FirstOrDefault();
            if (dr != null)
            {
                dr["Line_No"] = 1;
                dr["TxnCategory_ID"] = clsAutocode.getTransactionCategoryID(TransactionCatagory);
                dr["TxnCategory"] = GetEnumDescription(TransactionCatagory);
                dr["GLCode"] = AccountCode;
                dr["GLName"] = clsGenaralName.getName_AccountName(AccountCode);
                dr["Debit"] = IsCredit ? 0 : decimal.Parse(txtAmount.Text);
                dr["Credit"] = IsCredit ? decimal.Parse(txtAmount.Text) : 0;
            }
            #endregion

        }

        public void initializeVariableRow()
        {
            #region Maintain Row count
            if (glb_dt.Rows.Count == 0)
                glb_dt.Rows.Add();

            else if (glb_dt.Rows.Count > 1)
            {
                int i = 0;
                foreach (DataRow row in glb_dt.Rows)
                {
                    if (i > 1)
                        row.Delete();
                    i++;
                }
            }
            #endregion

            #region Update Row
            DataRow dr = glb_dt.Select().FirstOrDefault();
            if (dr != null)
            {
                dr["Line_No"] = 1;
                dr["TxnCategory_ID"] = clsAutocode.getTransactionCategoryID(TransactionCatagory);
                dr["TxnCategory"] = GetEnumDescription(TransactionCatagory);
                dr["GLCode"] = AccountCode;
                dr["GLName"] = clsGenaralName.getName_AccountName(AccountCode);
                dr["Debit"] = IsCredit ? 0 : decimal.Parse(txtAmount.Text);
                dr["Credit"] = IsCredit ? decimal.Parse(txtAmount.Text) : 0;
            }
            #endregion

        }
        public void pictureBox1_Click(object sender, EventArgs e)
        {
            if (TxnCat != TransactionCategory.SVAT)
            {
                decimal dAmount = decimal.Parse(txtAmount.Text);
                frm_SetLedgerAccounts oLedger = new frm_SetLedgerAccounts(ref glb_dt, dAmount, TransactionCatagory, IsCredit,txtAmount.Enabled);
                LedgerUpdated();
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                TextboxValuechanged();
            }
            catch (Exception)
            {

            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TextboxValuechanged();
        }
    }
}