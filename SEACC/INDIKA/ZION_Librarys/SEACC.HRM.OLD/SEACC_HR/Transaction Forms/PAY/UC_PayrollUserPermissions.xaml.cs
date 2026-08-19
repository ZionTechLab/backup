using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Digiteq.Transaction_Forms.PAY
{
    /// <summary>
    /// Interaction logic for UC_PayrollUserPermissions.xaml
    /// </summary>
    public partial class UC_PayrollUserPermissions : UserControl
    {
        public UC_PayrollUserPermissions()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Payroll_User_Permissions;
            SEACC_Form.Initialize();

            dgr_Main.dt.Columns.Add("user_ID");
            dgr_Main.dt.Columns.Add("group_ID");
            dgr_Main.dt.Columns.Add("group_Name");
            dgr_Main.dt.Columns.Add("allowView", typeof(bool));
            dgr_Main.dt.Columns.Add("allowSave", typeof(bool));
            dgr_Main.dt.Columns.Add("allowEdit", typeof(bool));
            dgr_Main.dt.Columns.Add("allowRollback", typeof(bool));
            dgr_Main.dt.Columns.Add("allowCheckable", typeof(bool));
            dgr_Main.dt.Columns.Add("allowApprovable", typeof(bool));


            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;

            dgr_Main.Add_DatagridColoumn("Group Id", "group_ID", 70);
            dgr_Main.Add_DatagridColoumn("Group Name", "group_Name", 250);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "View", "allowView", 45, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Save", "allowSave", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Edit", "allowEdit", 45, true, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Rollback", "allowRollback", 45, false, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Check", "allowCheckable", 45, false, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.CheckBox, "Approve", "allowApprovable", 56, false, false);

            ClearFields();
        }

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged_1(object sender, SizeChangedEventArgs e)
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
            try
            {

                foreach (DataRow row in dgr_Main.dt.Rows)
                {
                    string  sGroup_ID = (row["group_ID"].ToString());
                    bool bIsViewEnable = bool.Parse(row["allowView"].ToString());
                    bool bIsSaveEnable = bool.Parse(row["allowSave"].ToString());
                    bool bIsEditEnable = bool.Parse(row["allowEdit"].ToString());
                    bool bIsRollbackEnable = bool.Parse(row["allowRollback"].ToString());
                    bool bIsCheckEnable = bool.Parse(row["allowCheckable"].ToString());
                    bool bIsApproveEnable = bool.Parse(row["allowApprovable"].ToString());


                    tbl_securityParollGroup_UserPermission oldRecord = tbl_securityParollGroup_UserPermission.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtUserID.Tag.ToString(), sGroup_ID);
                    if (oldRecord != null)
                    {
                        tbl_securityParollGroup_UserPermission ouserPermission = new tbl_securityParollGroup_UserPermission(oldRecord.Company_ID, oldRecord.CompanyBranch_ID, oldRecord.User_ID, oldRecord.ProcessGroup_ID, bIsViewEnable, bIsSaveEnable, bIsEditEnable, bIsRollbackEnable, bIsCheckEnable, bIsApproveEnable);
                        ouserPermission.Update();
                    }
                    else
                    {
                        tbl_securityParollGroup_UserPermission ouserPermission = new tbl_securityParollGroup_UserPermission(clsSecurity.CompanyID, clsSecurity.BranchID, txtUserID.Tag.ToString(), sGroup_ID, bIsViewEnable, bIsSaveEnable, bIsEditEnable, bIsRollbackEnable, bIsCheckEnable, bIsApproveEnable);
                        ouserPermission.Insert();
                    }

                }

                SEACCMessageBox.Show("Successfully Saved", "", MessageBoxButton.OK);

            }
            catch (Exception ex)
            {

                SEACCExeption.Show(ex);
            }
            finally
            {
                ClearFields();
            }
        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUserID, true, false, false);
            txtUserID.Text = "";

            chk_ViewAll.IsChecked = false;
            chk_SaveAll.IsChecked = false;
            chk_EditAll.IsChecked = false;
            chk_RollbackAll.IsChecked = false;
            chk_CheckableAll.IsChecked = false;
            chk_ApprovableAll.IsChecked = false;

            dgr_Main.dt.Clear();
        }
        #endregion

        #region Check box Events
        private void chk_ViewAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowView" , true);
        }

        private void chk_ViewAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowView", false);
        }

        private void chk_SaveAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowSave", true);
        }

        private void chk_SaveAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowSave", false);
        }

        private void chk_EditAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowEdit", true);
        }

        private void chk_EditAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowEdit", false);
        }

        private void chk_RollbackAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRollback", true);
        }

        private void chk_RollbackAll_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll("allowRollback", false);
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

        public void CheckAll(string columnName, bool status)
        {
            foreach (DataRow row in dgr_Main.dt.Rows)
                row[columnName] = status;
        }
        #endregion


        #region Refresh Grid
        private void RefreshGrid(string userID)
        {
            try
            {
                dgr_Main.dt.Clear();
                dgr_Main.dt = DBHandling.ExecQuery("Exec sp_securityPayrollGroup_UserPermissionSetup " + userID).Tables[0];
                if (dgr_Main.dt != null && dgr_Main.dt.Rows.Count > 0)
                {
                    dgr_Main.RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion


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

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
        }
    }
}
