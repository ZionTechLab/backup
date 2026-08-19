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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_UserPermission.xaml
    /// </summary>
    public partial class UC_UserPermission : UserControl
    {
        #region Form Load
        public UC_UserPermission()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.User_Permission;
            SEACC_Form.Initialize();

            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;

            ClearFields();

            dgr_Main.dt.Columns.Add("user_ID");
            dgr_Main.dt.Columns.Add("function_ID", typeof(int));
            dgr_Main.dt.Columns.Add("function_Code", typeof(int));
            dgr_Main.dt.Columns.Add("functionName");
            dgr_Main.dt.Columns.Add("isReport", typeof(bool)); //Need to implement
            dgr_Main.dt.Columns.Add("allowRead", typeof(bool));
            dgr_Main.dt.Columns.Add("allowWrite", typeof(bool));
            dgr_Main.dt.Columns.Add("allowDelete", typeof(bool));
            dgr_Main.dt.Columns.Add("allowApprovable", typeof(bool));
            dgr_Main.dt.Columns.Add("allowCheckable", typeof(bool));
            dgr_Main.dt.Columns.Add("allowUpdate", typeof(bool));
            dgr_Main.dt.Columns.Add("allowPrint", typeof(bool));
            dgr_Main.dt.Columns.Add("allowRePrint", typeof(bool));
            dgr_Main.dt.Columns.Add("allowExport", typeof(bool));
            dgr_Main.dt.Columns.Add("allowView", typeof(bool));

            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "#", "function_ID", 40, true, false);
            dgr_Main.Add_DatagridColoumn("Report / Form Name", "functionName", 250);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Read", "allowRead", 45, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Write", "allowWrite", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Edit", "allowUpdate", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Delete", "allowDelete", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Check", "allowCheckable", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Approve", "allowApprovable", 56, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Print", "allowPrint", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Re-print", "allowRePrint", 56, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Export", "allowExport", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "View", "allowView", 45, true, false);
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(800);
        }
        #endregion

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
                try
                {
                    this.Cursor = Cursors.Wait;
                    foreach (DataRow row in dgr_Main.dt.Rows)
                    {
                        int function_ID = int.Parse((row["function_ID"].ToString()));
                        bool isReadEnable = bool.Parse(row["allowRead"].ToString());
                        bool isWriteEnable = bool.Parse(row["allowWrite"].ToString());
                        bool isEditEnable = bool.Parse(row["allowUpdate"].ToString());
                        bool isDeleteEnable = bool.Parse(row["allowDelete"].ToString());
                        bool isCheckEnable = bool.Parse(row["allowCheckable"].ToString());
                        bool isApproveEnable = bool.Parse(row["allowApprovable"].ToString());

                        bool isPrintEnable = bool.Parse(row["allowPrint"].ToString());
                        bool isReprintEnable = bool.Parse(row["allowRePrint"].ToString());
                        bool isExportEnable = bool.Parse(row["allowExport"].ToString());
                        bool isViewEnable = bool.Parse(row["allowView"].ToString());

                        tbl_securityFunctionMaster_Permission oldRecord = tbl_securityFunctionMaster_Permission.Select(txtUserID.Tag.ToString(), function_ID);
                        if (oldRecord != null)
                        {
                            tbl_securityFunctionMaster_Permission ouserPermission = new tbl_securityFunctionMaster_Permission(txtUserID.Tag.ToString(), function_ID, isReadEnable, isWriteEnable, isDeleteEnable, isApproveEnable, isCheckEnable, isEditEnable, isPrintEnable, isReprintEnable, isExportEnable, isViewEnable);
                            ouserPermission.Update();
                        }
                        else
                        {
                            tbl_securityFunctionMaster_Permission ouserPermission = new tbl_securityFunctionMaster_Permission(txtUserID.Tag.ToString(), function_ID, isReadEnable, isWriteEnable, isDeleteEnable, isApproveEnable, isCheckEnable, isEditEnable, isPrintEnable, isReprintEnable, isExportEnable, isViewEnable);
                            ouserPermission.Insert();
                        }

                    }
                }
                catch (Exception ex)
                {

                    SEACCExeption.Show(ex);
                }
                finally
                {
                    btn_Load.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                }
        }
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            if (chkIsReport.IsChecked || chkUIs.IsChecked)
            {
                if (CheckValidity())
                {
                    if (txtCategory.Tag != null)
                        RefreshGrid(txtUserID.Tag.ToString(), txtCategory.Tag.ToString(), chkIsReport.IsChecked);
                    else
                        RefreshGrid(txtUserID.Tag.ToString(), "%", chkIsReport.IsChecked);
                }
            }
            else
            {
                dgr_Main.dt.Clear();
                dgr_Main.RefreshGrid();
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUserID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);
            txtUserID.Text = "";
            txtCategory.Text = "";

            txtUserID.Tag = null;
            txtCategory.Tag = null;

            chk_ReadAll.IsChecked = false;
            chk_WriteAll.IsChecked = false;
            chk_EditAll.IsChecked = false;
            chk_DeleteAll.IsChecked = false;
            chk_ApprovableAll.IsChecked = false;
            chk_CheckableAll.IsChecked = false;
            chk_PrintAll.IsChecked = false;
            chk_ReprintAll.IsChecked = false;
            chk_ExportAll.IsChecked = false;
            chk_ViewAll.IsChecked = false;

            chkIsReport.IsChecked = false;
            chkUIs.IsChecked = false;

            dgr_Main.dt.Clear();
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtUserID))
                bStatus = false;
            return bStatus;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string userID, string functionCategoryID, bool bIsReport)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                dgr_Main.dt.Clear();
                dgr_Main.dt = DBHandling.ExecQuery("Exec sp_securityFunction_PermissionSetup '" + userID + "','" + functionCategoryID + "','" + bIsReport + "'").Tables[0];
                if (dgr_Main.dt != null && dgr_Main.dt.Rows.Count > 0)
                {
                    dgr_Main.RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
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
                txtUserID.Text = lstResult[0];
                txtUserID.Tag = lstResult[0];

            }
        }

        private void txtCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch(true);
            List<string> lstResult = RowDataSearch.Show(Search.FunctionCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtCategory.Text = lstResult[1];
                txtCategory.Tag = lstResult[0];
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
        private void chkIsReport_checkBox_Checked(object sender, EventArgs e)
        {
            chkUIs.IsChecked = false;
        }

        private void chkUIs_checkBox_Checked(object sender, EventArgs e)
        {
            chkIsReport.IsChecked = false;
        }

        private void chk_ReadAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["allowRead"].ToString());
                if (!isReadEnable)
                {
                    row["allowRead"] = true;
                }
            }
        }

        private void chk_ReadAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
            {
                bool isReadEnable = bool.Parse(row["allowRead"].ToString());
                if (isReadEnable)
                {
                    row["allowRead"] = false;
                }
            }
        }
        private void chk_WriteAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowWrite", true);
        }

        private void chk_WriteAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowWrite", false);
        }

        private void chk_EditAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowUpdate", true);
        }

        private void chk_EditAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowUpdate", false);
        }

        private void chk_DeleteAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowDelete", true);
        }

        private void chk_DeleteAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowDelete", false);
        }

        private void chk_CheckableAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowCheckable", true);
        }

        private void chk_CheckableAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowCheckable", false);
        }

        private void chk_ApprovableAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowApprovable", true);
        }

        private void chk_ApprovableAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowApprovable", false);
        }

        private void chk_Print_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowPrint", true);
        }

        private void chk_Print_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowPrint", false);
        }

        private void chk_Reprint_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRePrint", true);
        }

        private void chk_Reprint_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRePrint", false);
        }

        private void chk_Export_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowExport", true);
        }

        private void chk_Export_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowExport", false);
        }

        private void chk_View_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowView", true);
        }

        private void chk_View_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowView", false);
        }

        public void CheckAll(string columnName, bool status)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
                row[columnName] = status;
        }

        #endregion

    }
}