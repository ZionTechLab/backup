using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_APPAREL.UserManagement
{
    /// <summary>
    /// Coded by Gayan
    /// 2017-04-17
    /// </summary>
    public partial class UC_UserPermission : UserControl
    {
        #region Initialize Usercontrol
        public UC_UserPermission()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.UserPermission;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("user_ID");
            dgr_Main.dt.Columns.Add("function_ID", typeof(int));
            dgr_Main.dt.Columns.Add("function_Code", typeof(int));
            dgr_Main.dt.Columns.Add("functionName");
            dgr_Main.dt.Columns.Add("isReport", typeof(bool));
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
            #endregion

            #region Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Report/UI #", "function_ID", 87, true, false);
            dgr_Main.Add_DatagridColoumn("Report/UI Name", "functionName", 200);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Read", "allowRead", 45, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Write", "allowWrite", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Edit", "allowUpdate", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Cancel", "allowDelete", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Check", "allowCheckable", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Approve", "allowApprovable", 56, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Print", "allowPrint", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Re-print", "allowRePrint", 56, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Export", "allowExport", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "View", "allowView", 45, true, false);
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Buttons

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
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

                        tbl_securityFunctionMaster_Permission oldRecord = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, txtUserID.Tag.ToString(), function_ID);
                        if (oldRecord != null)
                        {
                            tbl_securityFunctionMaster_Permission ouserPermission = new tbl_securityFunctionMaster_Permission(clsSecurity.BranchID, txtUserID.Tag.ToString(), function_ID, isReadEnable, isWriteEnable, isDeleteEnable, isApproveEnable, isCheckEnable, isEditEnable, isPrintEnable, isReprintEnable, isExportEnable, isViewEnable);
                            ouserPermission.Update();
                        }
                        else
                        {
                            tbl_securityFunctionMaster_Permission ouserPermission = new tbl_securityFunctionMaster_Permission(clsSecurity.BranchID, txtUserID.Tag.ToString(), function_ID, isReadEnable, isWriteEnable, isDeleteEnable, isApproveEnable, isCheckEnable, isEditEnable, isPrintEnable, isReprintEnable, isExportEnable, isViewEnable);
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

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            if (chkUIs.IsChecked || chkReports.IsChecked)
            {
                if (CheckValidity())
                    if (txtModule.Tag != null)
                        RefreshGrid(clsSecurity.BranchID, txtUserID.Tag.ToString(), txtModule.Tag.ToString(), chkReports.IsChecked);
                    else
                        RefreshGrid(clsSecurity.BranchID, txtUserID.Tag.ToString(), "%PROD%", chkReports.IsChecked);
            }
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUserID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtModule, true, false, false);

            txtUserID.Tag = null;
            txtModule.Tag = null;

            txtUserID.Text = "";
            txtModule.Text = "";

            chkUIs.IsChecked = false;
            chkReports.IsChecked = false;

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

            dgr_Main.dt.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sBrachID, string userID, string functionCategoryID, bool bIsReport)
        {
            try
            {
                Cursor = Cursors.Wait;
                dgr_Main.dt.Clear();
                dgr_Main.dt = DBHandling.ExecQuery("Exec sp_securityFunction_PermissionSetup '" + sBrachID + "','" + userID + "','" + functionCategoryID + "','" + bIsReport + "'").Tables[0];
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

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_Main.SelectedIndex;
            var vDG_Cell = dgr_Main.GetCurrentCell();

            #region Checkboxs update
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "allowRead")
                {
                    dgr_Main.dt.Rows[irowID]["allowRead"] = dgr_Main.dt.Rows[irowID]["allowRead"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowWrite")
                {
                    dgr_Main.dt.Rows[irowID]["allowWrite"] = dgr_Main.dt.Rows[irowID]["allowWrite"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowUpdate")
                {
                    dgr_Main.dt.Rows[irowID]["allowUpdate"] = dgr_Main.dt.Rows[irowID]["allowUpdate"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowDelete")
                {
                    dgr_Main.dt.Rows[irowID]["allowDelete"] = dgr_Main.dt.Rows[irowID]["allowDelete"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowCheckable")
                {
                    dgr_Main.dt.Rows[irowID]["allowCheckable"] = dgr_Main.dt.Rows[irowID]["allowCheckable"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowApprovable")
                {
                    dgr_Main.dt.Rows[irowID]["allowApprovable"] = dgr_Main.dt.Rows[irowID]["allowApprovable"].ToString() == "True" ? false : true;
                }

                if (vDG_Cell.Column.SortMemberPath == "allowPrint")
                {
                    dgr_Main.dt.Rows[irowID]["allowPrint"] = dgr_Main.dt.Rows[irowID]["allowPrint"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowRePrint")
                {
                    dgr_Main.dt.Rows[irowID]["allowRePrint"] = dgr_Main.dt.Rows[irowID]["allowRePrint"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowExport")
                {
                    dgr_Main.dt.Rows[irowID]["allowExport"] = dgr_Main.dt.Rows[irowID]["allowExport"].ToString() == "True" ? false : true;
                }
                if (vDG_Cell.Column.SortMemberPath == "allowView")
                {
                    dgr_Main.dt.Rows[irowID]["allowView"] = dgr_Main.dt.Rows[irowID]["allowView"].ToString() == "True" ? false : true;
                }

            }

            catch (Exception) { }
            #endregion
        }
        #endregion

        #region Search Events
        private void txtUserID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProdUsers);
            if (RowDataSearch.DialogResult == true)
            {
                txtUserID.Text = lstResult[1];
                txtUserID.Tag = lstResult[0];
            }
        }

        private void txtCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.SoftwareModules);
            if (RowDataSearch.DialogResult == true)
            {
                txtModule.Text = lstResult[1];
                txtModule.Tag = lstResult[0];
            }
        }

        #endregion

        #region Check Box Events

        private void chkUIs_checkBox_Checked(object sender, EventArgs e)
        {
            if (chkUIs != null)
                chkReports.IsChecked = false;
        }

        private void chkReports_checkBox_Checked(object sender, EventArgs e)
        {
            if (chkReports != null)
                chkUIs.IsChecked = false;
        }

        public void CheckAll(string columnName, bool status)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
                row[columnName] = status;
        }

        private void chk_ReadAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRead", true);
        }

        private void chk_ReadAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRead", false);
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

        private void chk_PrintAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowPrint", true);
        }

        private void chk_PrintAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowPrint", false);
        }

        private void chk_ReprintAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRePrint", true);
        }

        private void chk_ReprintAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRePrint", false);
        }

        private void chk_ExportAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowExport", true);
        }

        private void chk_ExportAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowExport", false);
        }

        private void chk_ViewAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowView", true);
        }

        private void chk_ViewAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowView", false);
        }
        #endregion
    }
}
