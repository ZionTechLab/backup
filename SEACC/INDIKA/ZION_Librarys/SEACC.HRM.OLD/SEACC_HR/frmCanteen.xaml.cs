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
using System.Windows.Shapes;
using SEACC_WPFControls;
using System.Windows.Threading;
using DataTire;
using Digiteq_Logic;
using System.Data;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;


namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frmCanteen.xaml
    /// </summary>
    public partial class frmCanteen : Window
    {
        #region Class Variables
        string MealType;
        string MenuType;
        bool bIsmaximized;
        #endregion

        #region Form Load  
        public frmCanteen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            clearFields();
            BackColors("#FF59854E");
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region Background color change
        private void BackColors(string colorCode)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var ColorCode = (Brush)converter.ConvertFromString(colorCode);

            this.Background = ColorCode;
            grd_Canteen.Background = ColorCode;
            grd_Canteen.RowBackground = ColorCode;
            //txtEmpNo.Background = ColorCode;
            //txtEmpNo.BorderBrush = ColorCode;
            //txtEmpNo.Foreground = ColorCode;
        }
        #endregion

        #region Breakfast Button click
        private void SEACC_Button_Click_1(object sender, RoutedEventArgs e)
        {
            BackColors("#FF59854E");
            MealType = "MEL/001";
        }
        #endregion

        #region Lunch Button Click
        private void SEACC_Button_Click_2(object sender, RoutedEventArgs e)
        {
            BackColors("#007A99");
            MealType = "MEL/002";
        }
        #endregion

        #region Dinner Button click
        private void SEACC_Button_Click_3(object sender, RoutedEventArgs e)
        {
            BackColors("#FF682C4D");
            MealType = "MEL/003";
        }
        #endregion

        #region Contral Box
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }


        private void btnRestore_Click_1(object sender, RoutedEventArgs e)
        {
            if (bIsmaximized)
            {
                System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);
                bIsmaximized = false;
                this.Height = Scr.WorkingArea.Height / 2;
                this.Width = Scr.WorkingArea.Width / 2;
                this.Left = Scr.Bounds.Location.X + Scr.Bounds.Width / 4;
                this.Top = Scr.Bounds.Location.Y + Scr.WorkingArea.Height / 4;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                bIsmaximized = true;
            }
        }


        private void GridDragable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
                bIsmaximized = false;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Window_StateChanged_1(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);

                this.WindowState = WindowState.Normal;
                this.Height = Scr.WorkingArea.Height;
                this.Width = Scr.WorkingArea.Width;

                this.Left = Scr.Bounds.Location.X;
                this.Top = Scr.Bounds.Location.Y;
                btnRestore.Content = "";
                bIsmaximized = true;
            }
        }
        #endregion

        #region Clear Fields
        private void clearFields()
        {
            // cls_Formater.SetEnableDisable_LableTextbox(txtEmployeeNo, true, false, false);
            // txtEmployeeNo.Clear();
            //   lblamount.Content = "0.00";
            // lblDept.Content = "Departemnt";
            // lblEmployeeName.Content = "Name";
            // lblDesignation.Content = "Designation";
            // txtEmpNo.Clear();

        }
        #endregion

        #region Employee Details load
        private void FindEmployeeDetails(string sEmployeeNo)
        {

            //foreach (tbl_genMasEmployee oEmpMaster in tbl_genMasEmployee.SelectAll().Where(p => p.IsCanceled == false && p.Employee_ID == sEmployeeNo))
            //{
            //    if (oEmpMaster != null)
            //    {
            //       // lblEmployeeName.Content = oEmpMaster.Initails + " " + oEmpMaster.SurName;
            //       // lblDesignation.Content = clsRef_Name.get_Designation_Name(oEmpMaster.Designation_ID);
            //       // lblDept.Content = clsRef_Name.get_Department_Name(oEmpMaster.Department_ID);
            //    }
            //}
        }
        #endregion


        #region New Button Click
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("EmpNo");
                dt.Columns.Add("EmpName");
                dt.Columns.Add("MealType");
                dt.Columns.Add("Amount");

                foreach (tbl_hrm_Canteen oCanteen in tbl_hrm_Canteen.SelectAll().Where(p => p.IsCanceled == false))
                {
                    if (CheckValidity_EmptyField())
                    {
                        dt.Rows.Add(oCanteen.Id.ToString(), "100001", clsRef_Name.get_EmployeeName("100001"), "M/001", "50.00");
                    }
                }
                grd_Canteen.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
                //SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }

        }
        #endregion

        #region Save Button

        private void btn_Tender_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckValidity_EmptyField())
                {
                    if (chek_MealTime())
                    {
                        foreach (tbl_genMasEmployee oEmpMaster in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID != "Default" && p.IsCanceled == false && p.Employee_ID == ""))
                        {
                            if (oEmpMaster != null)
                            {
                                foreach (tbl_hrm_MealPlanRates oPlanamount in tbl_hrm_MealPlanRates.SelectAll().Where(x => x.Emp_Catagory1_ID == oEmpMaster.EmpCatagory1_ID && x.MealType_ID == MealType && x.MenuType_ID == MenuType))
                                {
                                    tbl_hrm_Canteen oCanteen = new tbl_hrm_Canteen(clsSecurity.getServerDateTime(), "", MealType, oPlanamount.Amount_byCompany, oPlanamount.Amount_byEmployee, "Default", "Default", "S/001", "Dev001", false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Defalut", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                                    oCanteen.Insert();
                                    SEACCMessageBox.Show("Please Collect Bill", "", MessageBoxButton.OK);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
               // SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
            finally
            {
                clearFields();
                RefreshGrid();
            }
        }
        #endregion

        #region Cancle Button Click
        private void btn_Cancle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = grd_Canteen.SelectedItem;
                if (item != null)
                {
                    string GridID = (grd_Canteen.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    tbl_hrm_Canteen oCanteen = tbl_hrm_Canteen.Select(int.Parse(GridID));
                    if (oCanteen != null)
                    {
                        oCanteen.IsCanceled = true;
                        oCanteen.UserID_Canceled = clsSecurity.UserIDLoged;
                        oCanteen.TerminalID_Canceled = clsSecurity.TerminalID;
                        oCanteen.Date_Canceled = clsSecurity.getServerDateTime();
                        oCanteen.Update();
                    }

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                clearFields();
                RefreshGrid();
            }
        }
        #endregion


        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            // if (!clsValidation.ValidateTextBox_EmptyValueLableTextbox(txtEmployeeNo))
            //bStatus = false;

            return bStatus;
        }

        private bool chek_MealTime()
        {
            bool bStatus = true;
            // if (lblType.Content == "")
            // {
            //   bStatus = false;
            //   SEACCMessageBox.Show("Please Select BREAKFAST Or LUNCH Or DINNER", "", MessageBoxButton.OK);
            // }
            return bStatus;
        }

        private void lblEmployeeName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                clearFields();
                //lblEmployeeName.Tag = lstResult[0];
                //  lblEmployeeName.Content = lstResult[1];
                FindEmployeeDetails(lstResult[0]);
                //  txtEmpNo.Text = lstResult[0];
            }
        }

        private void btn_Vegi_Click(object sender, RoutedEventArgs e)
        {
            MenuType = "MNU/003";
        }

        private void btn_Egg_Click(object sender, RoutedEventArgs e)
        {
            MenuType = "MNU/002";
        }

        private void btn_Fish_Click(object sender, RoutedEventArgs e)
        {
            MenuType = "MNU/001";
        }

        private void btn_che_Click(object sender, RoutedEventArgs e)
        {
            MenuType = "MNU/003";
        }

        private void btn_Special_Click(object sender, RoutedEventArgs e)
        {
            MenuType = "MNU/004";
        }

        private void txtEmpNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string s=txtEmpNo.Text;
            //if (txtEmpNo.Text == "5")
            //{
            //    FindEmployeeDetails("100001");
            //}
        }

        private void txtEmpNo_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void User_Indicator_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void User_Indicator_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                clearFields();
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(lstResult[0], clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                {
                    User_Indicator.SetUser(detail.Employee_ID + "-" + detail.SurName + " " + detail.Initails, clsRef_Name.get_Designation_Name(detail.Designation_ID), clsCommon.Convert_ByteToBitMap(detail.Employee_Image),true);
                }

                FindEmployeeDetails(lstResult[0]);

            }
        }
    }
}
