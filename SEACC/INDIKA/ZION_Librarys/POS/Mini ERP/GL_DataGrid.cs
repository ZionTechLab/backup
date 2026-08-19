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

namespace Digiteq
{
    public partial class GL_DataGrid : UserControl
    {
      public  DataTable dt_GLP;

        public GL_DataGrid()
        {
            InitializeComponent();
            dgvDetail.AutoGenerateColumns = false;


            dt_GLP = new DataTable();
            dt_GLP.Columns.Add("Line_No", typeof(int));
            dt_GLP.Columns.Add("CategoryDesc", typeof(string));
            dt_GLP.Columns.Add("GLCode", typeof(string));
            dt_GLP.Columns.Add("GLName", typeof(string));
            dt_GLP.Columns.Add("GLDebit", typeof(decimal));
            dt_GLP.Columns.Add("GLCredit", typeof(decimal));
            dt_GLP.Columns.Add("SubAcct1", typeof(string));
            dt_GLP.Columns.Add("SubAcct2", typeof(string));
            dt_GLP.Columns.Add("Employee", typeof(string));
            dt_GLP.Columns.Add("OtherCr", typeof(string));
            dt_GLP.Columns.Add("CategoryID", typeof(int));
            dt_GLP.Columns.Add("SubAcct1_ID", typeof(string));
            dt_GLP.Columns.Add("SubAcct2_ID", typeof(string));
            dt_GLP.Columns.Add("Employee_ID", typeof(string));
            dt_GLP.Columns.Add("remarks", typeof(string));
            dt_GLP.Columns.Add("APNID", typeof(string));


            dgvDetail.DataSource = dt_GLP.DefaultView;
        }
        public void Clear()
        {
            dt_GLP.Rows.Clear();
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

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "accCode" || sColName == "accName")
                {
                    string sType = clsValidate.ValidateGridValue(dgvDetail, "CategoryDesc", e.RowIndex, "");
                    if (sType == GetEnumDescription(TransactionCategory.SubTotal))
                    {
                        List<string> lstParameeters = new List<string>();
                        lstParameeters.Add("");
                        lstParameeters.Add("");

                        frmSearch RowDataSearch = new frmSearch(lstParameeters);
                        List<string> lstResult = RowDataSearch.Show(Search.AccName);
                        if (RowDataSearch.DialogResult == DialogResult.OK)
                        {
                            //   txtGLAccSubTotal.Text = lstResult[0];

                            dgvDetail["AccCode", e.RowIndex].Value = lstResult[0];
                            dgvDetail["AccName", e.RowIndex].Value = lstResult[1];
                        }
                    }
                }

                if (sColName == "SubAcct1")
                {
                    //string sType = clsValidate.ValidateGridValue(dgvDetail, "CategoryDesc", e.RowIndex, "");
                    //if (sType == GetEnumDescription(TransactionCategory.SubTotal))
                    {
                        frmSearch RowDataSearch = new frmSearch();
                        List<string> lstResult = RowDataSearch.Show(Search.CostCentre1);
                        if (RowDataSearch.DialogResult == DialogResult.OK)
                        {
                            // txtGLAccSubTotal.Text = lstResult[0];

                            dgvDetail["SubAcct1_ID", e.RowIndex].Value = lstResult[0];
                            dgvDetail["SubAcct1", e.RowIndex].Value = lstResult[1];
                        }
                    }
                }

                if (sColName == "SubAcct2")
                {
                    //string sType = clsValidate.ValidateGridValue(dgvDetail, "CategoryDesc", e.RowIndex, "");
                    //if (sType == GetEnumDescription(TransactionCategory.SubTotal))
                    {

                        frmSearch RowDataSearch = new frmSearch();
                        List<string> lstResult = RowDataSearch.Show(Search.CostCentre2);
                        if (RowDataSearch.DialogResult == DialogResult.OK)
                        {
                            //   txtGLAccSubTotal.Text = lstResult[0];

                            dgvDetail["SubAcct2_ID", e.RowIndex].Value = lstResult[0];
                            dgvDetail["SubAcct2", e.RowIndex].Value = lstResult[1];
                        }
                    }
                }
            }
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewRow row in dgvDetail.Rows)
            //{
            //    string sAccCode = clsValidate.ValidateDataTableValue(row, "GLAccCode", "");
            //    decimal sUnsettledAmount = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateDataTableValue(row, "AllocatedAmount", 0), dExRate);
            //    FilldataTable(iLineNo++, sAccCode, sUnsettledAmount, 0, "default", "default", "default", "default", TransactionCategory.SubTotal, txtSupplierID.Tag.ToString());
            //    dTotalCredit += sUnsettledAmount;
            //}
        }

        private void FilldataTable(TransactionCategory TransactionCategoryID, string Gl_ID, decimal Amount, bool isCredit, string CostCenter1_ID, string CostCenter2_ID, string Employee_ID, string Customer_ID, string Supplier_ID)
        {
            int Line_No = dt_GLP.Rows.Count;
            dt_GLP.Rows.Add(Line_No, GetEnumDescription(TransactionCategoryID), Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), (isCredit ? 0 : Amount), (isCredit ? Amount : 0), clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategoryID), CostCenter1_ID, CostCenter2_ID, Employee_ID);
        }

        public void Refresh_PostingEntys(string sSupplier_ID, decimal sUnsettledAmount, decimal dAmount_VAT, decimal dAmount_NBT, decimal dAmount_GrandTotal)
        {
            decimal dTotalDebit = 0, dTotalCredit = 0;
            if (sSupplier_ID != "")
            {
                dt_GLP.Clear();
                string sAccountCode_Supplier = clsMethods_GL.getAccountCode_Supplier(sSupplier_ID);

               // decimal dAmount_VAT = clsHelpMethods_Local.getSavePrice(txtVat, txtCurrencyRate);
              //  decimal dAmount_NBT = clsHelpMethods_Local.getSavePrice(txtNBT, txtCurrencyRate);
              //  decimal dAmount_GrandTotal = clsHelpMethods_Local.getSavePrice(txtGrandTotal, txtCurrencyRate);

                // int iLineNo = 0;

                if (dAmount_GrandTotal > 0 && sAccountCode_Supplier != "default")
                    FilldataTable(TransactionCategory.GrandTotal, sAccountCode_Supplier, dAmount_GrandTotal, true, "default", "default", "default", "default", sSupplier_ID);
                if (dAmount_VAT > 0)
                    FilldataTable(TransactionCategory.VAT, clsConfig.sVATGLCode_Payable, dAmount_VAT, false, "default", "default", "default", "default", "default");
                if (dAmount_NBT > 0)
                    FilldataTable(TransactionCategory.NBT, clsConfig.sNBTGLCode_Payable, dAmount_NBT, false, "default", "default", "default", "default", "default");


                dTotalCredit = dAmount_VAT + dAmount_NBT;
                dTotalDebit = dAmount_GrandTotal;
                #region Sub Total

                //if (dt_GRN.Rows.Count == 0)
                //{

                //  //  decimal sUnsettledAmount = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Text), dExRate);
                //    FilldataTable(TransactionCategory.SubTotal, "", sUnsettledAmount, false, "default", "default", "default", "default", "default");
                //    dTotalCredit += sUnsettledAmount;
                //    // }

                //}
                //else
                //{
                //    //var newDt = dt_GRN.AsEnumerable().GroupBy(r => r.Field<string>("GLAccCode"))
                //    //    .Select(g =>
                //    //    {
                //    //        var row = dt_GRN.NewRow();

                //    //        row["GLAccCode"] = g.Key;
                //    //        row["UnsettledAmount"] = g.Sum(r => r.Field<decimal>("UnsettledAmount"));
                //    //        row["AllocatedAmount"] = g.Sum(r => r.Field<decimal>("AllocatedAmount"));
                //    //        return row;
                //    //    }).CopyToDataTable();

                //    //foreach (DataRow row in newDt.Rows)
                //    //{
                //    //    string sAccCode = clsValidate.ValidateDataTableValue(row, "GLAccCode", "");
                //    //   //  sUnsettledAmount = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateDataTableValue(row, "AllocatedAmount", 0), dExRate);
                //    //  //  FilldataTable(TransactionCategory.SubTotal, sAccCode, sUnsettledAmount, false, "default", "default", "default", "default", txtSupplierID.Tag.ToString());
                //    //    dTotalCredit += sUnsettledAmount;
                //    //}
                //}
                #endregion


                txtCreditAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalCredit);
                txtDebitAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalDebit);
            }
            else
            {
                foreach (DataRow row in dt_GLP.Rows)
                {
                    string sCategoryDesc = clsValidate.ValidateDataTableValue(row, "CategoryDesc", "");
                    if (sCategoryDesc == GetEnumDescription(TransactionCategory.GrandTotal))
                    {
                        row.Delete();
                        break;
                    }

                }
            }
        }
    }
}
