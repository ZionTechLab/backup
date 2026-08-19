using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace Digiteq
{
    public partial class UC_AccCustomerOpeningBalance : SEACC_Form
    {
        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;
        bool bShowMessages = true;

        //to keep form detail       
        public int iFormID;
        public bool bNoAccess;

        BindingSource bindingSource = new BindingSource();
        DataTable dt = new DataTable();

        private string sFilteQuary = "";
        private bool bAcctCodeTypeCode;
        private bool bAcctTypeSubGlCode;
        #endregion

        #region Form Load
        public UC_AccCustomerOpeningBalance(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void UC_AccCustomerOpeningBalance_Load(object sender, EventArgs e)
        {
            ClearFields();
            CusDataGridViewFormat();
            CreateDataTable();
            dgvDetail.DataSource = bindingSource;
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            decimal dOpeningBalance = 0;
                            string sAcctCode = "", sCustomerID = "";

                            sAcctCode = clsValidate.ValidateGridValue(dgvDetail, "AccCode", row.Index, "");
                            sCustomerID = clsValidate.ValidateGridValue(dgvDetail, "CustomerID", row.Index, "");
                            dOpeningBalance = clsValidate.ValidateGridValue(dgvDetail, "OBalance", row.Index, decimal.Parse("0.00"));

                        }
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        RefreshGrid();
                    }
                }
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dt.Rows.Clear();

                foreach (tbl_accGLMaster_Customer oCustomer in tbl_accGLMaster_Customer.SelectAll().OrderBy(p => p.Customer_ID))
                {
                    dt.Rows.Add(oCustomer.Gl_ID, clsGenaralName.getName_AccountName(oCustomer.Gl_ID), oCustomer.Customer_ID, clsGenaralName.getName_Customer(oCustomer.Customer_ID), 0);
                }
                bindingSource.DataSource = dt;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtFinYear, true);

            txtFinYear.Tag = null;
            txtFinYear.Clear();
            txtFinYear_Month.Tag = null;
            txtFinYear_Month.Clear();

            bShowMessages = false;

            dt.Rows.Clear();

        }
        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            dt.Columns.Clear();
            dt.Columns.Add("AccCode", typeof(string));
            dt.Columns.Add("AccName", typeof(string));
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("OBalance", typeof(double));
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_TextBoxes())
            {
                bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidity_TextBoxes()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtFinYear.TextLength == 0)
            {
                strMessage += "\n" + "FinYear Name ";
                bStatus = false;
            }
            if (txtFinYear_Month.TextLength == 0)
            {
                strMessage += "\n" + "FinYear Month ";
                bStatus = false;
            }

            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return bStatus;
        }


        #endregion

        #region Event Double Click
        private void txtFinYear_DoubleClick(object sender, EventArgs e)
        {
            Search_FinancialID();
        }
        private void txtFinYear_Month_DoubleClick(object sender, EventArgs e)
        {
            Search_FinancialYear_Month();
        }
        #endregion

        #region  Event Key Down
        private void txtFinYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_FinancialID();
        }
        private void txtFinYear_Month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_FinancialYear_Month();
        }
        #endregion

        #region Search Methods
        private void Search_FinancialID()
        {
            try
            {
                clsSearch.Search_FinancialID(ref txtFinYear);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_FinancialYear_Month()
        {
            try
            {
                clsSearch.Search_FinancialMonth_ID(ref txtFinYear_Month, txtFinYear.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

    }
}
