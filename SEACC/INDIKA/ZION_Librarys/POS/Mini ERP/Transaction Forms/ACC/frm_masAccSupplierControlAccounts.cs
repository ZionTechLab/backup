using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_masAccSupplierControlAccounts : MettroForm
    {
        #region Global Variables
        DataTable dt = new DataTable();
        private BindingSource sourceSupplierCA = new BindingSource();
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_masAccSupplierControlAccounts()
        {
            //iFormID = clsSecurity.getFormID(FormName.CompanyBankAcc);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            InitializeComponent();
        }

        private void frm_masAccSupplierControlAccounts_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            clsFormatter.setFormatForm(this, "Supplier Control Account", 1, iFormID);
            clsFormatter.ApplyGridFormat_New(dgvDetail);

            dgvDetail.DataSource = sourceSupplierCA;

            CreateDataTable();
            RefreshGrid();
        }
        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            dt.Columns.Add("SupplierClass", typeof(string));
            dt.Columns.Add("SupplierType", typeof(string));
            dt.Columns.Add("SupplierCategory", typeof(string));
            dt.Columns.Add("SupplierCode", typeof(string));
            dt.Columns.Add("SupplierName", typeof(string));
            dt.Columns.Add("GLCode", typeof(string));
            dt.Columns.Add("GLName", typeof(string));
        }
        #endregion

        #region Button New
        private void btnNew_Click(object sender, EventArgs e)
        {
            sourceSupplierCA.Filter = "";
            txtCategoryID.Clear();
            txtSupplierClassID.Clear();
            txtSupplierID.Clear();
            txtSupplierTypeID.Clear();
        }
        #endregion

        #region Save n Update Control Account
        private void SaveUpdate_ControlAccount(string sSupplierID, string sControlAcctID)
        {
            try
            {
                if (sSupplierID != null && sControlAcctID != null)
                {
                    tbl_accGLMaster_Supplier oldRecord = tbl_accGLMaster_Supplier.Select(sSupplierID);
                    if (oldRecord != null)
                    {
                        tbl_accGLMaster_Supplier.DeleteAllBySupplier_ID(sSupplierID);
                        tbl_accGLMaster_Supplier oAcc = new tbl_accGLMaster_Supplier(sControlAcctID, sSupplierID, true);
                        oAcc.Insert();

                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        tbl_accGLMaster_Supplier oSupDetails = new tbl_accGLMaster_Supplier(sControlAcctID, sSupplierID, true);
                        oSupDetails.Insert();

                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            //int iRow;
            //dt.Rows.Clear();
            //List<tbl_genSupplierMaster> details = tbl_genSupplierMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => p.Supplier_ID != "default").ToList();
            //foreach (tbl_genSupplierMaster detail in details)
            //{
            //    dt.Rows.Add(clsGenaralName.getName_SupplierClass(detail.SupplierClass_ID), clsGenaralName.getName_SupplierType(detail.SupplierType_ID),
            //        clsGenaralName.getName_SupplierCategory(detail.SupplierCategory_ID), detail.Supplier_ID, detail.SupplierName, detail.Gl_ID == "" ? "-" : detail.Gl_ID,
            //        detail.Gl_ID == "" ? "-" : clsGenaralName.getName_AccountName(detail.Gl_ID));
            //}
            //if (dt.Rows.Count > 0)
            sourceSupplierCA.DataSource = DBHandling.ExecQuery("Exec sp_SupplierWithGL_SelectAll '" + clsSecurity.CompanyID + "', '" + clsSecurity.BranchID + "'").Tables[0];
        }
        #endregion

        #region Event Datagrid
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "", sControlAcctID = "", sControlAcctName = "";
                bool bStatus = false;
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "GLCode" || sColName == "GLName")
                {
                    string sSupplierID = clsValidate.ValidateGridValue(dgvDetail, "SupplierCode", e.RowIndex, "");
                    if (sSupplierID != null)
                    {
                        SearchAccountCode(ref sControlAcctID, ref sControlAcctName);
                        if (sControlAcctID != null)
                        {
                            dgvDetail["GLName", e.RowIndex].Value = sControlAcctName;
                            dgvDetail["GLCode", e.RowIndex].Value = sControlAcctID;
                            SaveUpdate_ControlAccount(sSupplierID, sControlAcctID);
                        }
                    }
                }
            }
        }
        #endregion

        #region Event Keyup
        private void txtSupplierClassID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtSupplierClassID);
        }

        private void txtSupplierTypeID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtSupplierTypeID);
        }

        private void txtCategoryID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtCategoryID);
        }

        private void txtSupplierID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtSupplierID);
        }
        #endregion

        #region Search
        private void SearchAccountCode(ref string sID, ref string sName)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(clsAutocode.getControlAccount_Types(enum_ControlAccountType.Creditor));

                frmSearch RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.AccName_ControlTypes);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    sID = lstResult[0];
                    sName = lstResult[1];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Filter Query
        private void createFilterQuery(TextBox txtbox)
        {
            try
            {
                string sTemp = "";

                if (txtSupplierClassID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " SupplierClass like '%" + txtSupplierClassID.Text + "%'";
                    }
                }
                if (txtSupplierTypeID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " SupplierType like '%" + txtSupplierTypeID.Text + "%'";
                    }
                }
                if (txtCategoryID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " SupplierCategory like '%" + txtCategoryID.Text + "%'";
                    }
                }
                if (txtSupplierID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " SupplierName like '%" + txtSupplierID.Text + "%'";
                    }
                }

                sourceSupplierCA.Filter = "";
                sourceSupplierCA.Filter = sTemp;

                //sourceSupplierCA.DataSource = dt;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

    }
}
