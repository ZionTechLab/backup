using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
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
    public partial class frm_masAccCustomerControlAccounts : MettroForm
    {
        #region Global Variables
        DataTable dt = new DataTable();
        private BindingSource sourceCustomerCA = new BindingSource();
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_masAccCustomerControlAccounts()
        {
            //iFormID = clsSecurity.getFormID(FormName.CompanyBankAcc);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            InitializeComponent();
        }

        private void frm_masAccCustomerControlAccounts_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorAccounts;
            clsFormatter.setFormatForm(this, "Customer Control Account", 1, iFormID);
            clsFormatter.ApplyGridFormat_New(dgvDetail);

            dgvDetail.DataSource = sourceCustomerCA;

            CreateDataTable();
            RefreshGrid();
        }

        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            dt.Columns.Add("CustomerClass", typeof(string));
            dt.Columns.Add("CustomerType", typeof(string));
            dt.Columns.Add("CustomerCategory", typeof(string));
            dt.Columns.Add("CustomerCode", typeof(string));
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("GLCode", typeof(string));
            dt.Columns.Add("GLName", typeof(string));
        }
        #endregion

        #region Button New
        private void btnNew_Click(object sender, EventArgs e)
        {
            sourceCustomerCA.Filter = "";
            txtCategoryID.Clear();
            txtCustomerID.Clear();
            txtCustomerTypeID.Clear();
            txtCustomerClassID.Clear();
        }
        #endregion

        #region Save n Update Control Account
        private void SaveUpdate_ControlAccount(string sCustomerID, string sControlAcctID)
        {
            try
            {
                if (sCustomerID != null && sControlAcctID != null)
                {
                    tbl_accGLMaster_Customer oldRecord = tbl_accGLMaster_Customer.Select(sCustomerID);
                    if (oldRecord != null)
                    {
                        oldRecord.Gl_ID = sControlAcctID;
                        oldRecord.Update();

                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
                        //if (oCustomer != null)
                        //{
                        //    oCustomer.Gl_ID = sControlAcctID;
                        //    oCustomer.Update();

                        //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                    else
                    {
                        tbl_accGLMaster_Customer oCusDetails = new tbl_accGLMaster_Customer(sCustomerID, sControlAcctID, true);
                        oCusDetails.Insert();

                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            //int iRow;
            //dt.Rows.Clear();
            //List<tbl_genCustomerMaster> details = tbl_genCustomerMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => p.Customer_ID != "default").ToList();
            //foreach (tbl_genCustomerMaster detail in details)
            //{

            //    dt.Rows.Add(clsGenaralName.getName_CustomerClass(detail.CustomerClass_ID), clsGenaralName.getName_CustomerType(detail.CustomerType_ID),
            //        clsGenaralName.getName_CustomerCategory(detail.CustomerCategory_ID), detail.Customer_ID, detail.CustomerName, detail.Gl_ID == "" ? "-" : detail.Gl_ID,
            //        detail.Gl_ID == "" ? "-" : clsGenaralName.getName_AccountName(detail.Gl_ID));

            //}
            //if (dt.Rows.Count > 0)
            sourceCustomerCA.DataSource = DBHandling.ExecQuery("Exec sp_CustomerWithGL_SelectAll '" + clsSecurity.CompanyID + "', '" + clsSecurity.BranchID + "'").Tables[0];
        }
        #endregion

        #region Event Datagrid
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "", sControlAcctID = "", sControlAcctName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "GLCode" || sColName == "GLName")
                {
                    string sCustomerID = clsValidate.ValidateGridValue(dgvDetail, "CustomerCode", e.RowIndex, "");
                    if (sCustomerID != null)
                    {
                        SearchAccountCode(ref sControlAcctID, ref sControlAcctName);
                        if (sControlAcctID != null)
                        {
                            dgvDetail["GLCode", e.RowIndex].Value = sControlAcctID;
                            dgvDetail["GLName", e.RowIndex].Value = sControlAcctName;
                            SaveUpdate_ControlAccount(sCustomerID, sControlAcctID);
                        }
                    }
                }
            }
        }
        #endregion

        #region Event Keyup
        private void txtCustomerClassID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtCustomerClassID);
        }

        private void txtCustomerTypeID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtCustomerTypeID);
        }

        private void txtCategoryID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtCategoryID);
        }

        private void txtCustomerID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuery(txtCustomerID);
        }
        #endregion

        #region Search
        private void SearchAccountCode(ref string sID, ref string sName)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(clsAutocode.getControlAccount_Types(enum_ControlAccountType.Debtor));

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
                clsValidate.WriteErrorLog("", -1,ex);
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

                if (txtCustomerClassID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " CustomerClass like '%" + txtCustomerClassID.Text + "%'";
                    }
                }
                if (txtCustomerTypeID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " CustomerType like '%" + txtCustomerTypeID.Text + "%'";
                    }
                }
                if (txtCategoryID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " CustomerCategory like '%" + txtCategoryID.Text + "%'";
                    }
                }
                if (txtCustomerID.Name == txtbox.Name)
                {
                    if (txtbox.Text.Trim().Length > 0)
                    {
                        sTemp = " CustomerName like '%" + txtCustomerID.Text + "%'";
                    }
                }

                sourceCustomerCA.Filter = "";
                sourceCustomerCA.Filter = sTemp;

                dgvDetail.DataSource = sourceCustomerCA;
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
