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
using DataTire;
using SEACC_WPFControls;
using Digiteq_Logic;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_MealPlanRates.xaml
    /// </summary>
    public partial class UC_MealPlanRates : UserControl
    {      

        #region Form Load
        public UC_MealPlanRates()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Meal_Plan_Rate;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("PlanID");
            dgr_Main.dt.Columns.Add("Mealtype");
            dgr_Main.dt.Columns.Add("MenuType");
            dgr_Main.dt.Columns.Add("EmpCatg");
            dgr_Main.dt.Columns.Add("ComPay");
            dgr_Main.dt.Columns.Add("EmpPay");
            dgr_Main.dt.Columns.Add("Status");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Plan Code", "PlanID", 70);
            dgr_Main.Add_DatagridColoumn("Meal Type", "Mealtype", 100);
            dgr_Main.Add_DatagridColoumn("Menu Type", "MenuType", 100);
            dgr_Main.Add_DatagridColoumn("Emp. Catg.", "EmpCatg", 120);
            dgr_Main.Add_DatagridColoumn("Pay-Commpany", "ComPay", 120);
            dgr_Main.Add_DatagridColoumn("pay-Employee", "EmpPay", 120);
            dgr_Main.Add_DatagridColoumn("Status", "Status", 100); 
            #endregion

            ClearField();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 650)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(650);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearField();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtMealPlanID.Tag != null)
                    {
                        bool MessageBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (MessageBoxResult)
                        {
                            tbl_hrm_MealPlanRates oMealPlan = tbl_hrm_MealPlanRates.Select(txtMealPlanID.Text.Trim());
                            if (oMealPlan != null)
                            {
                                oMealPlan.IsCanceled = true;
                                oMealPlan.UserID_Canceled = clsSecurity.UserIDLoged;
                                oMealPlan.Date_Canceled = clsSecurity.getServerDateTime();
                                oMealPlan.TerminalID_Canceled = clsSecurity.TerminalID;
                                oMealPlan.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearField();
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Variables
                    bool bActive = false;
                    if (chkActive.IsChecked == true)
                    {
                        bActive = true;
                    }
                    #endregion

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_hrm_MealPlanRates OldRecord = tbl_hrm_MealPlanRates.Select(txtMealPlanID.Text);
                            if (OldRecord != null)
                            {
                                tbl_hrm_MealPlanRates oMealPan = new tbl_hrm_MealPlanRates(txtMealPlanID.Text, txtMealType.Tag.ToString(), txtMenuType.Tag.ToString(), txtEmpCategory.Tag.ToString(), decimal.Parse(txtCompanyPay.Text), decimal.Parse(txtEmployeePay.Text), bActive, OldRecord.IsCanceled, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Created, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
                                oMealPan.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtMealPlanID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_hrm_MealPlanRates oMealPlan = new tbl_hrm_MealPlanRates(txtMealPlanID.Text, txtMealType.Tag.ToString(), txtMenuType.Tag.ToString(), txtEmpCategory.Tag.ToString(), decimal.Parse(txtCompanyPay.Text), decimal.Parse(txtEmployeePay.Text), bActive, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oMealPlan.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                    #endregion
                } 
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearField();
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearField()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtMealPlanID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMealType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMenuType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmpCategory, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmployeePay, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCompanyPay, true, true, false);
            cls_Formater.SetEnableDisable_CheckBox(chkActive, true);

            txtMealPlanID.Text = "";
            txtMealType.Text = "";
            txtMenuType.Text = "";
            txtEmpCategory.Text = "";
            txtEmployeePay.Text = "";
            txtCompanyPay.Text = "";
            txtEmployeePay.Text = "";
            chkActive.IsChecked = false;

            #region Set Auto Generate Fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtMealPlanID.Text = "<Auto Generate>";
                txtMealPlanID.setReadOnlyStatus(true);
            }
            else
                txtMealPlanID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_hrm_MealPlanRates omealPalnRates in tbl_hrm_MealPlanRates.SelectAll().Where(p =>  p.IsCanceled == false && p.MealPlan_ID != "default"))
                {
                    if (omealPalnRates != null)
                    {
                        dgr_Main.dt.Rows.Add(omealPalnRates.MealPlan_ID, clsRef_Name.get_MealType_Name(omealPalnRates.MealType_ID), clsRef_Name.get_MenuType_Name(omealPalnRates.MenuType_ID), clsRef_Name.get_EmployeeCategory1_Name(omealPalnRates.Emp_Catagory1_ID), omealPalnRates.Amount_byCompany.ToString(), omealPalnRates.Amount_byEmployee.ToString(), (omealPalnRates.Status == true) ? "Active" : "Inactive");
                    }
                    dgr_Main.RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtMealPlanID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtMealType))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtMenuType))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCompanyPay))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtEmployeePay))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_hrm_MealPlanRates oDetail = tbl_hrm_MealPlanRates.Select(txtMealPlanID.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_hrm_MealPlanRates oMealPaln = tbl_hrm_MealPlanRates.Select(sID);
                    if (oMealPaln != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtMealPlanID.IsEnabled = false;
                        txtMealPlanID.Text = oMealPaln.MealPlan_ID;
                        txtMealPlanID.Tag = oMealPaln.MealPlan_ID;
                        txtMealType.Text = clsRef_Name.get_MealType_Name(oMealPaln.MealType_ID);
                        txtMealType.Tag = oMealPaln.MealType_ID;
                        txtMenuType.Text = clsRef_Name.get_MenuType_Name(oMealPaln.MenuType_ID);
                        txtMenuType.Tag = oMealPaln.MenuType_ID;
                        txtCompanyPay.Text = oMealPaln.Amount_byCompany.ToString();
                        txtEmployeePay.Text = oMealPaln.Amount_byEmployee.ToString();
                        txtEmpCategory.Text = clsRef_Name.get_EmployeeCategory1_Name(oMealPaln.Emp_Catagory1_ID);
                        txtEmpCategory.Tag = oMealPaln.Emp_Catagory1_ID;
                        if (oMealPaln.Status == true)
                        {
                            chkActive.IsChecked = true;
                        }
                        else
                        {
                            chkActive.IsChecked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Grid Event
        private void grd_mealPlanReats_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    ClearField();
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtMealPlanID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.MealPlan);
            if (RowDataSearch.DialogResult == true)
            {
                ClearField();
                txtMealPlanID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtMealType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.MealType);
            if (RowDataSearch.DialogResult == true)
            {
                txtMealType.Text = lstResult[1];
                txtMealType.Tag = lstResult[0];
            }
        }

        private void txtMenuType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.MealMenu);
            if (RowDataSearch.DialogResult == true)
            {
                txtMenuType.Text = lstResult[1];
                txtMenuType.Tag = lstResult[0];
            }
        }

        private void txtEmpCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtEmpCategory.Text = lstResult[1];
                txtEmpCategory.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
