using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_SetLedgerAccounts : MettroForm
    {
        DataTable dt = new DataTable();
        decimal dAmount = 0;
        bool isCredit = false, EnableEditSubTot=false;
        TransactionCategory TransactionCatagory = TransactionCategory.Other_Cr;

        public frm_SetLedgerAccounts()
        {
            InitializeComponent();
            btnSettings.Visible = false;
        }

        public frm_SetLedgerAccounts(ref DataTable _dt,decimal _dAmount,TransactionCategory _TxnCat,bool _isCredit,bool _EnableEditSubTot)
        {
            InitializeComponent();
            dt = _dt;
            dAmount = _dAmount;
            TransactionCatagory = _TxnCat;
            isCredit = _isCredit;
            EnableEditSubTot = _EnableEditSubTot;

            dgvDetail.AutoGenerateColumns = false;
            dgvDetail.DataSource = dt.DefaultView;

            if (TransactionCatagory == TransactionCategory.NBT || TransactionCatagory == TransactionCategory.VAT || TransactionCatagory == TransactionCategory.GrandTotal|| (TransactionCatagory == TransactionCategory.SubTotal && !_EnableEditSubTot))
            {
                Btn_GridDelete.Visible = false;
                Btn_AddRow.Visible = false;

                if (isCredit)
                    this.Debit.ReadOnly = true;
                else
                    this.Credit.ReadOnly = true;
            }

            ShowDialog();
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

        private void Btn_AddRow_Click(object sender, EventArgs e)
        {
            DataRow newRow = dt.NewRow();

            newRow["TxnCategory_ID"] = clsAutocode.getTransactionCategoryID(TransactionCatagory);
            newRow["TxnCategory"] = GetEnumDescription(TransactionCatagory);

            if (isCredit)
            {
                newRow["Debit"] = 0;
                newRow["Credit"] = dAmount;
            }
            else
            {
                newRow["Debit"] = dAmount;
                newRow["Credit"] = 0;
            }

            dt.Rows.Add(newRow);
          //  dgvDetail_CellClick(null, DataGridViewCellEventArgs e)

            int i = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                row.Cells["Line_No"].Value = i++;
            }
        }

        private void Btn_GridDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedCells.Count > 0)
            {
                dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                int i = 1;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    row.Cells["Line_No"].Value = i++;
                }
            }
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region GL Account
                if (sColName == "accCode" || sColName == "accName")
                {
                    if (!(TransactionCatagory == TransactionCategory.GrandTotal || (TransactionCatagory == TransactionCategory.SubTotal && !EnableEditSubTot)))
                    {//TransactionCatagory == TransactionCategory.NBT || TransactionCatagory == TransactionCategory.VAT || 
                        List<string> lstParameeters = new List<string>();
                        lstParameeters.Add("%");
                        if(TransactionCatagory == TransactionCategory.NBT || TransactionCatagory == TransactionCategory.VAT)
                            lstParameeters.Add(clsAutocode.getControlAccount_Types(enum_ControlAccountType.Tax));
                        else
                            lstParameeters.Add("");
                        lstParameeters.Add("-");

                        frmSearch RowDataSearch = new frmSearch(lstParameeters);
                        List<string> lstResult = RowDataSearch.Show(Search.AccName);
                        if (RowDataSearch.DialogResult == DialogResult.OK)
                        {
                            dgvDetail["AccCode", e.RowIndex].Value = lstResult[0];
                            dgvDetail["AccName", e.RowIndex].Value = lstResult[1];
                        }
                    }
                }
                #endregion
                else if (sColName == "SubAcct1_Name")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.CostCentre1);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        dgvDetail["SubAcct1_ID", e.RowIndex].Value = lstResult[0];
                        dgvDetail["SubAcct1_Name", e.RowIndex].Value = lstResult[1];
                    }
                }
                else if (sColName == "SubAcct2_Name")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.CostCentre2);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        dgvDetail["SubAcct2_ID", e.RowIndex].Value = lstResult[0];
                        dgvDetail["SubAcct2_Name", e.RowIndex].Value = lstResult[1];
                    }
                }
            }
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {  
                string sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                #region Add Debit Amount
                if (sColName == "Debit" || sColName == "Credit")
                {
                    decimal dDebitAmount = 0, dCreditAmount = 0;

                    dDebitAmount = clsValidate.ValidateGridValue(dgvDetail, "Debit", e.RowIndex, decimal.Parse("0.00"));
                    dgvDetail["Debit", e.RowIndex].Value = dDebitAmount;

                    dCreditAmount = clsValidate.ValidateGridValue(dgvDetail, "Credit", e.RowIndex, decimal.Parse("0.00"));
                    dgvDetail["Credit", e.RowIndex].Value = dCreditAmount;
                }
                #endregion
            }
        }
    }
}