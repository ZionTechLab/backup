using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;


namespace Digiteq
{
    public partial class frm_bpsUpdatePettyCashAccounts : MettroForm
    {
      
        #region Variables
        //to manage update and insert
     //   static bool IsUpdate = false;

        //to keep form detail       
      //  string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        #endregion

        #region From Load
        public frm_bpsUpdatePettyCashAccounts()
        {
            iFormID = clsSecurity.getFormID(FormName.UpdatePettyCashAccounts);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsIOU_Load(object sender, EventArgs e)
        {
            //RefreshGrid();
            CusDataGridViewFormat();
        } 
        #endregion


        #region Btn UpdatePettyCash
        private void btnUpdatePettyCash_Click(object sender, EventArgs e)
        {
            if (txtpettyCashAccountID.Tag != null)
            {
                if (clsSecurity.PermissionToReadPettyCash(txtpettyCashAccountID.Tag.ToString(), clsSecurity.UserIDLoged))
                {
                    frm_bpsPettyCash_IncomeAndExpenditure detail = new frm_bpsPettyCash_IncomeAndExpenditure();
                    if (detail != null)
                    {
                        detail.gblPettyCashID = txtpettyCashAccountID.Tag.ToString();
                        tbl_bpsPettyCashAccount account = tbl_bpsPettyCashAccount.Select(txtpettyCashAccountID.Tag.ToString());
                        detail.gblPettyCashUserName =
                        detail.gblPettyCashName = clsGenaralName.getName_PettyCashAccount(txtpettyCashAccountID.Tag.ToString());
                        detail.MdiParent = this.MdiParent;
                        detail.Show();
                        this.Close();
                    }
                }
                else //if no permission to delete
                   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, "Petty Cash Account ID"), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_bpsPettyCashAccount_Permission> details = tbl_bpsPettyCashAccount_Permission.SelectAllByPettyCashAccount_ID(txtpettyCashAccountID.Tag.ToString());
                foreach (tbl_bpsPettyCashAccount_Permission detail in details)
                {
                    if (detail.PettyCashAccount_ID != "default")
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        dgvDetail["UserID", iRow].Value = detail.User_ID;
                        dgvDetail["UserName", iRow].Value = clsGenaralName.getName_User(detail.User_ID);


                        if (detail.AllowRead)
                            dgvDetail["AllowRead", iRow].Value = "Yes";
                        else
                            dgvDetail["AllowRead", iRow].Value = "No";

                        if(detail.AllowWrite)
                            dgvDetail["AllowWrite", iRow].Value = "Yes";
                        else
                            dgvDetail["AllowWrite", iRow].Value = "No";

                        if(detail.AllowDelete)
                            dgvDetail["AllowDelete", iRow].Value = "Yes";
                        else
                            dgvDetail["AllowDelete", iRow].Value = "No";
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Event Double Clik
        private void txtpettyCashAccount_ID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionPettyCashAccount(ref txtpettyCashAccountID);

            if (txtpettyCashAccountID.Tag != null)
            {
                txtAccountName.Text = clsGenaralName.getName_PettyCashAccount(txtpettyCashAccountID.Tag.ToString());
                RefreshGrid();
            }
        } 
        #endregion

        #region Event Key Down
        private void txtpettyCashAccount_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionPettyCashAccount(ref txtpettyCashAccountID);

                if (txtpettyCashAccountID.Tag != null)
                {
                    txtAccountName.Text = clsGenaralName.getName_PettyCashAccount(txtpettyCashAccountID.Tag.ToString());
                    RefreshGrid();
                }
            }
        } 
        #endregion

    }
}
