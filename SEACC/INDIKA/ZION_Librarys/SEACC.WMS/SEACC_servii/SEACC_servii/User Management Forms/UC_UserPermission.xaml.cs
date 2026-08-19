using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;
using System.IO;
using Microsoft.Win32;
using System.Data;
using SEACC_servii.Search_Forms;

namespace SEACC_servii.User_Management
{
    /// <summary>
    /// Interaction logic for UC_UserPermission.xaml
    /// </summary>
    public partial class UC_UserPermission : UserControl
    {
        //public UC_UserPermission()
        //{
        //    InitializeComponent();
        //}


        #region Form Load
        public UC_UserPermission()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.UserPermissionSetup;
            SEACC_Form.Initialize();

            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;

            ClearFields();

            dgr_Main.dt.Columns.Add("formID");
            dgr_Main.dt.Columns.Add("formName");
            dgr_Main.dt.Columns.Add("read");
            dgr_Main.dt.Columns.Add("write");
            dgr_Main.dt.Columns.Add("edit");
            dgr_Main.dt.Columns.Add("delete");
            dgr_Main.dt.Columns.Add("checkable");
            dgr_Main.dt.Columns.Add("approvable");

            dgr_Main.Add_DatagridColoumn("FormID", "formID", 100);
            dgr_Main.Add_DatagridColoumn("FormName", "formName", 200);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Read", "read", 50, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Write", "write", 50, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Edit", "edit", 50, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Delete", "delete", 50, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Check", "checkable", 50, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Approve", "approvable", 70, true, false);


        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(700);
        }
        #endregion

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    int formID = int.Parse((row["formID"].ToString()));
                    string formName = (row["formName"].ToString());
                    bool isReadEnable = bool.Parse(row["read"].ToString());
                    bool isWriteEnable = bool.Parse(row["write"].ToString());
                    bool isEditEnable = bool.Parse(row["edit"].ToString());
                    bool isDeleteEnable = bool.Parse(row["delete"].ToString());
                    bool isCheckEnable = bool.Parse(row["checkable"].ToString());
                    bool isApproveEnable = bool.Parse(row["approvable"].ToString());


                    tbl_securityUserPermission oldRecord = tbl_securityUserPermission.Select(txtUserID.Tag.ToString(), formID);
                    if (oldRecord != null)
                    {
                        tbl_securityUserPermission ouserPermission = new tbl_securityUserPermission(txtUserID.Tag.ToString(), formID, isReadEnable, isWriteEnable, isDeleteEnable, isApproveEnable, isCheckEnable, isEditEnable);
                        ouserPermission.Update();

                    }
                    else
                    {
                        tbl_securityUserPermission ouserPermission = new tbl_securityUserPermission(txtUserID.Tag.ToString(), formID, isReadEnable, isWriteEnable, isDeleteEnable, isApproveEnable, isCheckEnable, isEditEnable);
                        ouserPermission.Insert();

                    }

                }

                SEACCMessageBox.Show("Successfully Saved", "", MessageBoxButton.OK);

            }
            catch (Exception ex)
            {

                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
            finally
            {
                ClearFields();
            }
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUserID, true, false, false);
            txtUserID.Text = "";

            chk_ReadAll.IsChecked = false;
            chk_WriteAll.IsChecked = false;
            chk_EditAll.IsChecked = false;
            chk_DeleteAll.IsChecked = false;
            chk_ApprovableAll.IsChecked = false;
            chk_CheckableAll.IsChecked = false;
            dgr_Main.dt.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string UserID)
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_securityFormMaster osecuForm in tbl_securityFormMaster.SelectAll())
                {
                    tbl_securityUserPermission oUserPermission = tbl_securityUserPermission.Select(UserID, osecuForm.Form_ID);
                    if (oUserPermission != null)
                    {
                        dgr_Main.dt.Rows.Add(osecuForm.Form_ID, osecuForm.FormName, oUserPermission.AllowRead, oUserPermission.AllowWrite, oUserPermission.AllowUpdate, oUserPermission.AllowDelete, oUserPermission.AllowCheckable, oUserPermission.AllowApprovable);
                        if (oUserPermission.AllowRead)
                        {

                        }
                    }
                    else
                    {
                        dgr_Main.dt.Rows.Add(osecuForm.Form_ID, osecuForm.FormName, false, false, false, false, false, false);
                    }
                }
                dgr_Main.RefreshGrid();

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Search Events
        private void txtUserID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtUserID.Text = lstResult[0];
                txtUserID.Tag = lstResult[0];
                RefreshGrid(lstResult[0]);

            }
        }
        #endregion

        #region Checked/Unchecked All

        private void CheckCheckboxes()
        {
            int icount_Read = 0;
            int icount_Write = 0;
            int icount_Edit = 0;
            int icount_delete = 0;
            int icount_Checkable = 0;
            int icount_Approveble = 0;

            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["read"].ToString());
                if (!isReadEnable)
                {
                    icount_Read = icount_Read + 1;
                }

                bool isWriteEnable = bool.Parse(row["write"].ToString());
                if (!isWriteEnable)
                {
                    icount_Write = icount_Write + 1;
                }
                bool isEditEnable = bool.Parse(row["edit"].ToString());
                if (!isEditEnable)
                {
                    icount_Edit = icount_Edit + 1;
                }
                bool isDeleteEnable = bool.Parse(row["delete"].ToString());
                if (!isDeleteEnable)
                {
                    icount_delete = icount_delete + 1;
                }
                bool isCheckableEnable = bool.Parse(row["checkable"].ToString());
                if (!isCheckableEnable)
                {
                    icount_Checkable = icount_Checkable + 1;
                }
                bool isApproveEnable = bool.Parse(row["approvable"].ToString());
                if (!isApproveEnable)
                {
                    icount_Approveble = icount_Approveble + 1;
                }
            }

            if (icount_Read == 0)
            {
                chk_ReadAll.IsChecked = true;
            }
            if (icount_Write == 0)
            {
                chk_WriteAll.IsChecked = true;
            }
            if (icount_Edit == 0)
            {
                chk_EditAll.IsChecked = true;
            }
            if (icount_delete == 0)
            {
                chk_DeleteAll.IsChecked = true;
            }
            if (icount_Checkable == 0)
            {
                chk_CheckableAll.IsChecked = true;
            }
            if (icount_Approveble == 0)
            {
                chk_ApprovableAll.IsChecked = true;
            }
        }


        #endregion

        #region Grid Mouse Click Event
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();
            #region Checkboxs update
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "read")
                {
                    dgr_Main.dt.Rows[irowID]["read"] = dgr_Main.dt.Rows[irowID]["read"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "write")
                {
                    dgr_Main.dt.Rows[irowID]["write"] = dgr_Main.dt.Rows[irowID]["write"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "edit")
                {
                    dgr_Main.dt.Rows[irowID]["edit"] = dgr_Main.dt.Rows[irowID]["edit"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "delete")
                {
                    dgr_Main.dt.Rows[irowID]["delete"] = dgr_Main.dt.Rows[irowID]["delete"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "checkable")
                {
                    dgr_Main.dt.Rows[irowID]["checkable"] = dgr_Main.dt.Rows[irowID]["checkable"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "approvable")
                {
                    dgr_Main.dt.Rows[irowID]["approvable"] = dgr_Main.dt.Rows[irowID]["approvable"].ToString() == "True" ? false : true;
                }
            }
            #endregion
            catch (Exception) { }
        }
        #endregion

        #region Check Uncheck All
        private void chk_ReadAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["read"].ToString());
                if (!isReadEnable)
                {
                    row["read"] = true;
                }
            }
        }

        private void chk_ReadAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["read"].ToString());
                if (isReadEnable)
                {
                    row["read"] = false;
                }
            }
        }
        private void chk_WriteAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["write"].ToString());
                if (!isReadEnable)
                {
                    row["write"] = true;
                }
            }
        }

        private void chk_WriteAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["write"].ToString());
                if (isReadEnable)
                {
                    row["write"] = false;
                }
            }
        }

        private void chk_EditAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["edit"].ToString());
                if (!isReadEnable)
                {
                    row["edit"] = true;
                }
            }
        }

        private void chk_EditAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["edit"].ToString());
                if (isReadEnable)
                {
                    row["edit"] = false;
                }
            }
        }

        private void chk_DeleteAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["delete"].ToString());
                if (!isReadEnable)
                {
                    row["delete"] = true;
                }
            }
        }

        private void chk_DeleteAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["delete"].ToString());
                if (isReadEnable)
                {
                    row["delete"] = false;
                }
            }
        }

        private void chk_CheckableAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["checkable"].ToString());
                if (!isReadEnable)
                {
                    row["checkable"] = true;
                }
            }
        }

        private void chk_CheckableAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["checkable"].ToString());
                if (isReadEnable)
                {
                    row["checkable"] = false;
                }
            }
        }

        private void chk_ApprovableAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["approvable"].ToString());
                if (!isReadEnable)
                {
                    row["approvable"] = true;
                }
            }
        }

        private void chk_ApprovableAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["approvable"].ToString());
                if (isReadEnable)
                {
                    row["approvable"] = false;
                }
            }
        }
        #endregion

    }
}
