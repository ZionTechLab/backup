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
    public partial class UC_DoubleEntry : UserControl
    {
        public delegate void Click(TransactionCategory TxnCat);
        public event Click Clicked;

        public UC_DoubleEntry()
        {
            InitializeComponent();
            dgvDetail.AutoGenerateColumns = false;
        }

        public void ClearFields()
        {
            dgvDetail.DataSource = null;

            txtCreditAmount.Tag = null;
            txtDebitAmount.Tag = null;
            txtCreditAmount.Clear();
            txtDebitAmount.Clear();
        }

        public void Refresh(DataTable dt)
        {
            dgvDetail.DataSource = dt.DefaultView;

            decimal dDebitAmount = 0, dCreditAmount = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dDebitAmount += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, dDebitAmount);
                dCreditAmount += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, dCreditAmount);
            }

            txtCreditAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCreditAmount);
            txtDebitAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebitAmount);
        }

        public bool CheckValidity_DebitCredit()
        {
            bool bIsOk = false;

            if (decimal.Parse(txtDebitAmount.Text) == decimal.Parse(txtCreditAmount.Text))
                bIsOk = true;
            else
                MessageBox.Show("Debit / Credit Total not matching....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (bIsOk)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sAccountCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                    if (!clsMethods_GL.CheckAccountValidity(sAccountCode))
                    {
                        bIsOk = false;
                        break;
                    }
                }
            }

            return bIsOk;
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "accCode" || sColName == "accName" || sColName == "SubAcct1" || sColName == "SubAcct2")
                {
                    int sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "TxnCategory_ID", e.RowIndex, 0);
                    try
                    {
                           Clicked((TransactionCategory)(sCategoryID));
                    }
                    catch (Exception)
                    {
                    }
                } 
            }
        }
    }
}