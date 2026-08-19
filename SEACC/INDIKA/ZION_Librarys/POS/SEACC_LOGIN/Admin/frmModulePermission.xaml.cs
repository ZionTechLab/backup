using DataTire;
using SEACC_LOGIN.Common;
using SEACC_LOGIN.Search;
using SEACC_WPFControls;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Digiteq_Logic;
using Digiteq;
namespace SEACC_LOGIN
{
    /// <summary>
    /// Interaction logic for frmModulePermission.xaml
    /// </summary>
    public partial class frmModulePermission : Window
    {
        #region Class Variables
        DataTable dtModule = new DataTable();
        #endregion

        #region Form Load
        public frmModulePermission()
        {
            InitializeComponent();

            #region Initialize Data Table
            dtModule.Columns.Add("LineNo");
            dtModule.Columns.Add("Module_Index");
            dtModule.Columns.Add("Module_ID");
            dtModule.Columns.Add("Module_Name");//
            dtModule.Columns.Add("IsSelected", typeof(bool));
            #endregion

            dgrModule.ItemsSource = dtModule.DefaultView;

            ClearFields();
        }
        #endregion

        #region Form Responsiveness
        private void grdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        } 
        #endregion

        #region Action Buttons
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Tag != null && txtCompanyBranch.Tag != null)
            {
                Fill_PremissionGrid(txtCompanyBranch.Tag.ToString(), txtUser.Tag.ToString());
            }
            else
            {
                if (txtCompanyBranch.Tag == null)
                    SEACCMessageBox.Show("Company Branch is Empty", "Please select a company branch...", MessageBoxButton.OK, "Red");

                if (txtUser.Tag == null)
                    SEACCMessageBox.Show("User is Empty", "Please select an user...", MessageBoxButton.OK, "Red");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUser.Tag != null && txtCompanyBranch.Tag != null)
                {
                    foreach (DataRow dr in dtModule.Rows)
                    {
                        int iModule_Index = int.Parse(dr["Module_Index"].ToString());
                        bool bIsSelected = bool.Parse(dr["IsSelected"].ToString());

                        tbl_cfgModule_Permission oOld_Permission = tbl_cfgModule_Permission.Select(
                            txtCompanyBranch.Tag.ToString(), txtUser.Tag.ToString(), iModule_Index);
                        if (oOld_Permission != null)
                            oOld_Permission.Delete();

                        tbl_cfgModule_Permission oMod_Permission = new tbl_cfgModule_Permission(
                            txtCompanyBranch.Tag.ToString(), txtUser.Tag.ToString(), iModule_Index, bIsSelected);
                        oMod_Permission.Insert();
                    }

                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                    btnLoad_Click(sender, e);


                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Clear Field
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCompanyBranch, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUser, true, false, false);

            txtCompanyBranch.Tag = clsSecurity_Login.CompanyBranchID;
            txtUser.Tag = null;

            txtCompanyBranch.Text =clsGenaralName .getName_CompanyBranchMaster(clsSecurity_Login.CompanyBranchID);
            txtUser.Text = "<Select User>";
        }
        #endregion

        #region Check Validity
        private bool CheckModulePermission(string sBranch_ID, string sUser_ID, int iModuleIndex)
        {
            bool bReturn = false;
            tbl_cfgModule_Permission oModPermission = tbl_cfgModule_Permission.Select(sBranch_ID, sUser_ID, iModuleIndex);
            if (oModPermission != null)
                bReturn = oModPermission.AllowAccess;

            return bReturn;
        } 
        #endregion

        #region Fill Grid
        private void Fill_PremissionGrid(string sBranch_ID, string sUser_ID)
        {
            try
            {
                dtModule.Clear();
                int iLine = 0;
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(p => p.IsVisible && p.IsEnable))
                {
                    dtModule.Rows.Add(++iLine, oModule.Module_Index, oModule.Module_ID, oModule.ModuleName, CheckModulePermission(sBranch_ID, sUser_ID, oModule.Module_Index));
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            System.Collections.Generic.List<string> lstResult = RowDataSearch.Show(15);
            if (RowDataSearch.DialogResult == true)
            {
                txtUser.Text = lstResult[1];
                txtUser.Tag = lstResult[0];
            }
        }
        #endregion

        #region Check Box events
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow dr in dtModule.Rows)
                dr["IsSelected"] = true;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow dr in dtModule.Rows)
                dr["IsSelected"] = false;
        } 
        #endregion
    }
}
