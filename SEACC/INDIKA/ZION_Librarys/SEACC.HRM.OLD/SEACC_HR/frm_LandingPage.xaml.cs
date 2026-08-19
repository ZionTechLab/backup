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
using System.Reflection;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;
using System.IO;
using Digiteq.Master_Forms;
using Digiteq.User_Contrals;
using Digiteq.User_Management;
using Digiteq.Transaction_Forms.CoconutCuting;
using Digiteq.Transaction_Forms.PAY;
using Digiteq.Transaction_Forms.CC;
using Digiteq.User_Management.DTQ;
using System.Threading;

namespace Digiteq
{
    public partial class frm_LandingPage : Window
    {
        #region Class Variables
        DataTable tbl_Functions = new DataTable();
        DataTable tbl_Search = new DataTable();
        bool bIsmaximized = false;
        static BrushConverter bc = new BrushConverter();
        private System.Threading.Timer timer;
        DataTable dt = new DataTable();
        #endregion

        #region Form Control Box
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbl_securityUserMaster oUser = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
                if (oUser != null)
                {
                    oUser.IsLoged = false;
                    oUser.Update();
                }
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
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
                //this.MaxHeight = SystemParameters.WorkArea.Height;
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
            catch (Exception)
            {
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
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

        #region Responsive
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.Width < 1075)
                SetLeftPanalSize(false);
            else
                SetLeftPanalSize(true);

            btnRestore.Content = "";
        }

        private void SetLeftPanalSize(bool toBigerSize)
        {
            if (toBigerSize)
                pnlLeft.Width = 200;
            else
                pnlLeft.Width = 30;
        }

        private void btnLeftPanalSize_Click(object sender, RoutedEventArgs e)
        {
            grd_popSubMenus.Visibility = System.Windows.Visibility.Collapsed;

            if (pnlLeft.Width == 30)
                SetLeftPanalSize(true);
            else
                SetLeftPanalSize(false);
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            grd_popSubMenus.Visibility = System.Windows.Visibility.Collapsed;
        }
        #endregion

        #region Form Load
        public frm_LandingPage()
        {
            InitializeComponent();
            //SetUpTimer(new TimeSpan(14, 30, 00));
            //SetUpTimer( clsConfig.tsAlertTime);

            //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            //dispatcherTimer.Tick += dispatcherTimer_Tick;
            //DBHandling.ExecQuery("exec sp_SyncAttendance");
            //dispatcherTimer.Interval = new TimeSpan(1,0,0);
            //dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //DBHandling.ExecQuery("exec sp_SyncAttendance");
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #region Daily Precence Alert - Tempory
        //private void SetUpTimer(TimeSpan alertTime)
        //{
        //    DateTime current = DateTime.Now;
        //    TimeSpan timeToGo = alertTime - current.TimeOfDay;
        //    if (timeToGo < TimeSpan.Zero)
        //    {
        //        return;//time already passed
        //    }
        //    this.timer = new System.Threading.Timer(x =>
        //    {
        //        this.GenerateAlert();
        //    }, null, timeToGo, Timeout.InfiniteTimeSpan);
        //}

        //private void GenerateAlert()
        //{
        //    //this runs at like 16:00:00
        //    clsAlerts_Email.CreateEmail_DailyPresentEmployees_DeptWise(DateTime.Now,  clsConfig.sAlert_Designation , clsConfig.sAlert_Email_MD);
        //}
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Maximized;
                User_Indicator.SetUser(clsSecurity.UserNameLoged, clsRef_Name.get_UserGroup_Name(clsSecurity.UserGroupIDLoged), clsSecurity.UserImageLoged, false);
                txtQuickLaunch.Focus();

                #region Menu
                #region Load modules
                foreach (tbl_securityFunctionCategory oCategory in tbl_securityFunctionCategory.SelectAll().Where(p => p.IsEnable).OrderBy(o => o.SortOrder))
                {
                    if (clsSecurity.UserIDLoged != "digiteq" && oCategory.FunctionCategory_ID == "FCAT/005")
                        continue;

                    else if (clsSecurity.UserIDLoged != "digiteq" && oCategory.FunctionCategory_ID == "FCAT/010")
                        continue;

                    SEACC_MenuButton btn_module = new SEACC_MenuButton();
                    btn_module.Height = 33;
                    btn_module.set(oCategory.DisplayName);
                    btn_module.setRightText("\uE102");
                    btn_module.Tag = oCategory.FunctionCategory_ID;
                    btn_module.MouseDown += btn_module_MouseDown;
                    grd_modules.Children.Add(btn_module);
                    // iMenuModule_Width += 33;
                }
                #endregion

                #region load Functions
                #region initialized data table
                tbl_Functions.Columns.Add("FormID", typeof(int));
                tbl_Functions.Columns.Add("FormName", typeof(string));
                tbl_Functions.Columns.Add("Image", typeof(BitmapImage));
                tbl_Functions.Columns.Add("formCategory_ID", typeof(string));
                #endregion

                foreach (tbl_securityFunctionMaster oForm in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsEnable && !p.IsReport).OrderBy(p => p.Function_Code))
                {
                    try
                    {
                        tbl_Functions.Rows.Add(oForm.Function_ID, oForm.FunctionName, (clsCommon.Convert_ByteToBitMap(oForm.Image)), oForm.FunctionCategory_ID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                #endregion

                #region initalize Search
                tbl_Search = tbl_Functions;
                dgv_Search.ItemsSource = tbl_Search.DefaultView;
                #endregion
                #endregion

                Chat.Visibility = Visibility.Hidden;
                clsCommon cs = new clsCommon();
                Chat.Refresh();
                //SetExpDate();

                if (clsConfig.SystemExpireDate.Date < DateTime.Now.Date)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Product has Expired !", "Dear Customer, \n Your Product  has Expired and Please Contact helpdesk@digiteq.biz for purchase SEACC Standard Version and Continue your amazing HR Experiance with SEACC HRCM.", MessageBoxButton.OK, "#009ACD");
                    if (bMessegeBoxResult)
                    {
                        frm_Login login = new frm_Login();
                        login.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Quick Launch
        private void btnSearch_Launch_Click(object sender, RoutedEventArgs e)
        {
            if (btnSearch_Launch.Tag.ToString() == "1")
            {
                txtQuickLaunch.Text = "";
                btnSearch_Launch.Content = "";
                btnSearch_Launch.Tag = "0";
                Grd_Search.Height = 0;
            }
        }

        private void txtQuickLaunch_KeyUp(object sender, KeyEventArgs e)
        {
            grd_popSubMenus.Visibility = System.Windows.Visibility.Collapsed;
            try
            {
                if (e.Key == Key.Escape)
                    txtQuickLaunch.Text = "";
                else if (e.Key == Key.Enter)
                    sfds_MouseLeftButtonUp(dgv_Search, null);
                else if (e.Key == Key.Up)
                    Up(true);
                else if (e.Key == Key.Down)
                    Up(false);
                else
                {
                    tbl_Search.DefaultView.RowFilter = "FormName" + " Like '%" + txtQuickLaunch.Text + "%'";
                    RefreshQuickLaunch();
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #region Quick Lunch Key Navigation

        private void Up(bool UP)
        {
            try
            {
                if (dgv_Search.SelectedIndex >= 0)
                {
                    if (UP)
                    {
                        if (dgv_Search.SelectedIndex == 0)
                            dgv_Search.SelectedIndex = dgv_Search.Items.Count - 1;
                        else
                            dgv_Search.SelectedIndex--;
                    }
                    else
                    {
                        if (dgv_Search.SelectedIndex == dgv_Search.Items.Count - 1)
                            dgv_Search.SelectedIndex = 0;
                        else
                            dgv_Search.SelectedIndex++;
                    }
                }
                else
                    dgv_Search.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Oops", ex.Message);
            }
        }
        #endregion

        private void RefreshQuickLaunch()
        {
            if (txtQuickLaunch.Text.Length != 0)
            {
                btnSearch_Launch.Content = "";
                btnSearch_Launch.Tag = "1";
                Grd_Search.Height = 150;
                dgv_Search.SelectedIndex = 0;
            }
            else
            {
                btnSearch_Launch.Content = "";
                btnSearch_Launch.Tag = "0";
                Grd_Search.Height = 0;
            }
        }
        #endregion

        #region Tab contral
        void Open_NewTabpage(UserControl uc, bool PermissionTO_Read, string FormName, string FormID)
        {

            try
            {
                if (PermissionTO_Read)
                {
                    TabItem newTab = new TabItem();
                    Style style = this.FindResource("TabItemStyle1") as Style;
                    newTab.Tag = FormID;
                    newTab.Style = style;
                    newTab.Header = FormName;

                    Grid grdMain = new Grid();
                    Grid grdTitleBar = new Grid();
                    Grid grdTopLine = new Grid();
                    Label lblTitle = new Label();
                    Label lblFormID = new Label();

                    grdTitleBar.VerticalAlignment = VerticalAlignment.Top;
                    grdTitleBar.Background = (Brush)bc.ConvertFrom("#FFFFFF");
                    grdTitleBar.Height = 50;

                    grdTopLine.Background = (Brush)bc.ConvertFrom("#FF41B1E1");
                    grdTopLine.VerticalAlignment = VerticalAlignment.Top;
                    grdTopLine.Height = 2;

                    lblTitle.FontSize = 24;
                    lblTitle.Content = "Form Name";
                    lblTitle.Foreground = (Brush)bc.ConvertFrom("#FF616161");
                    lblTitle.HorizontalAlignment = HorizontalAlignment.Left;
                    lblTitle.VerticalAlignment = VerticalAlignment.Top;
                    lblTitle.FontWeight = FontWeights.Light;
                    lblTitle.Padding = new Thickness(15, 5, 0, 0);
                    lblTitle.Content = FormName;

                    lblFormID.FontSize = 9;
                    lblFormID.Content = "Form ID";
                    lblFormID.Foreground = (Brush)bc.ConvertFrom("#FF616161");
                    lblFormID.HorizontalAlignment = HorizontalAlignment.Left;
                    lblFormID.VerticalAlignment = VerticalAlignment.Top;
                    lblFormID.Padding = new Thickness(15, 33, 0, 0);
                    lblFormID.Content = FormID;

                    grdTitleBar.Children.Add(grdTopLine);
                    grdTitleBar.Children.Add(lblTitle);
                    grdTitleBar.Children.Add(lblFormID);

                    uc.Margin = new Thickness(0, 50, 0, 0);

                    grdMain.Children.Add(grdTitleBar);
                    grdMain.Children.Add(uc);

                    newTab.Content = grdMain;

                    //Check whether the form is already exist or not
                    var matchingItem = MDI.Items.Cast<TabItem>().Where(item => item.Tag.ToString() == FormID).FirstOrDefault();
                    if (matchingItem != null)
                    {
                        if (SEACCMessageBox.Show("Do you need to open '" + FormName + "' form again?", ""))
                        {
                            MDI.Items.Add(newTab);
                            newTab.IsSelected = true;
                        }
                        else
                            MDI.SelectedItem = matchingItem;
                    }
                    else
                    {
                        MDI.Items.Add(newTab);
                        newTab.IsSelected = true;
                    }
                }
                else
                {
                    uc = null;
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                grd_popSubMenus.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnTabClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACCMessageBox.Show("Are you sure to close this tab?", ""))
                {
                    Button i = (Button)sender;
                    UIElement element = VisualTreeHelper.GetParent(i) as UIElement;
                    UIElement element2 = VisualTreeHelper.GetParent(element) as UIElement;
                    UIElement element3 = VisualTreeHelper.GetParent(element2) as UIElement;
                    UIElement element4 = VisualTreeHelper.GetParent(element3) as UIElement;
                    MDI.Items.Remove(element4);
                    element4 = null;
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACCMessageBox.Show("Are you sure to close this tab?", ""))
                {
                    UIElement dd = MDI.SelectedItem as UIElement;
                    MDI.Items.Remove(dd);
                    dd = null;
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void MenuItemCloseAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACCMessageBox.Show("Are you sure to close all tabs?", ""))
                {
                    for (int i = MDI.Items.Count - 1; i >= 0; i--)
                    {
                        MDI.Items.RemoveAt(i);
                    }
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void MenuItemCloseAllbutThis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACCMessageBox.Show("Are you sure to close all tabs?", ""))
                {
                    for (int i = MDI.Items.Count - 1; i >= 0; i--)
                    {
                        if (i != MDI.SelectedIndex)
                            MDI.Items.RemoveAt(i);
                    }
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region menu
        public void SetSubModules(string category)
        {
            stkp_submodules.Children.Clear();
            grd_popSubMenus.Visibility = System.Windows.Visibility.Visible;
            foreach (DataRow oModule in tbl_Functions.Select("formCategory_ID = '" + category + "'").CopyToDataTable().Rows) //, "FormName ASC"
            {
                SEACC_MenuButton btn_module = new SEACC_MenuButton();
                btn_module.Height = 33;
                btn_module.set(oModule["FormName"].ToString());
                btn_module.Tag = (oModule["FormID"].ToString());
                btn_module.MouseDown += sfds_MouseLeftButtonUp;
                stkp_submodules.Children.Add(btn_module);
            }
        }

        void btn_module_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SEACC_MenuButton o = sender as SEACC_MenuButton;
                foreach (SEACC_MenuButton n in grd_modules.Children)
                {
                    n.Background = (Brush)bc.ConvertFrom("Transparent");
                }
                o.Background = (Brush)bc.ConvertFrom("#FF364DAA");
                SetSubModules(o.Tag.ToString());

                //if (o.Tag.ToString() == "0")
                //{
                    //SetSubModules("DTQ");
                //}
                //if (o.Tag.ToString() == "1")
                //{
                //    SetSubModules("ADM");
                //}
                //else if (o.Tag.ToString() == "2")
                //{
                //    SetSubModules("SETT");
                //}
                //else if (o.Tag.ToString() == "3")
                //{
                //    SetSubModules("TAS");
                //}
                //else if (o.Tag.ToString() == "4")
                //{
                //    SetSubModules("PAY");
                //}
                //else if (o.Tag.ToString() == "5")
                //{
                //    SetSubModules("APP");
                //}
                //else if (o.Tag.ToString() == "6")
                //{
                //    SetSubModules("REC");
                //}
                //else if (o.Tag.ToString() == "7")
                //{
                //    SetSubModules("LOAN");
                //}
                //else if (o.Tag.ToString() == "8")
                //{
                //    SetSubModules("CAFF");
                //}
                //else if (o.Tag.ToString() == "9")
                //{
                //    SetSubModules("CCF");
                //}
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void sfds_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SEACC_MenuButton o = null;
                DataRowView row = null;
                int iFormID = 0;

                if (sender is SEACC_MenuButton)
                {
                    o = sender as SEACC_MenuButton;
                    iFormID = int.Parse(o.Tag.ToString());
                }
                else if (sender is DataGrid)
                {
                    DataGrid dgd = sender as DataGrid;
                    if (dgd.SelectedIndex >= 0)
                    {
                        row = (DataRowView)(dgd).SelectedItems[0];
                        iFormID = int.Parse(row[0].ToString());
                    }
                }

                if (o != null || row != null)
                {
                    FormName SelectedForm = (FormName)iFormID;

                    if (SelectedForm == FormName.Device_Raw_Data)
                    {
                        UC_DeviceRawData US = new UC_DeviceRawData();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Shift_Creation)
                    {
                        UC_ShiftMaster US = new UC_ShiftMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.GatePass_Official_Leave)
                    {
                        UC_GatePass US = new UC_GatePass();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Device_Creation)
                    {
                        UC_DeviceMaster US = new UC_DeviceMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll__Year)
                    {
                        UC_HRYear US = new UC_HRYear();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_Month)
                    {
                        UC_HRMonth US = new UC_HRMonth();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_Week)
                    {
                        UC_HRWeek US = new UC_HRWeek();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Department_Creation)
                    {
                        UC_DeptMaster US = new UC_DeptMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Attendance_Control_Panel)
                    {
                        UC_DailyAttendanceControlPanel US = new UC_DailyAttendanceControlPanel();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_Demography)
                    {
                        UC_EmployeeMaster US = new UC_EmployeeMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.Employee_Shift_Adjustment)
                    {
                        UC_EmpShiftAdjustment US = new UC_EmpShiftAdjustment();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Personal_Leave)
                    {
                        UC_LeaveApplication US = new UC_LeaveApplication();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if(SelectedForm == FormName.Greetings_Email_Schedular)
                    {
                        UC_GreetingsEmailScheduler US = new UC_GreetingsEmailScheduler();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.User_Creation)
                    {
                        UC_UserMaster US = new UC_UserMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Meal_Plan_Rate)
                    {
                        UC_MealPlanRates US = new UC_MealPlanRates();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Carder_Count)
                    {
                        UC_CarderRequest US = new UC_CarderRequest();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Budget_Plan)
                    {
                        UC_BudgetPlan US = new UC_BudgetPlan();
                        //Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.Payslip_Items)
                    {
                        UC_PayslipItems US = new UC_PayslipItems();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);

                    }
                    else if (SelectedForm == FormName.Payslip_Items_Class)
                    {
                        UC_PayslipItems_Class US = new UC_PayslipItems_Class();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);

                    }
                    else if (SelectedForm == FormName.Payslip_Items_Type)
                    {
                        UC_PayslipItems_Type US = new UC_PayslipItems_Type();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payslip_Items_Statutary)
                    {
                        UC_Payslip_Items_Statutary US = new UC_Payslip_Items_Statutary();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_Process_Group)
                    {
                        UC_Paymas_ProcessGroup US = new UC_Paymas_ProcessGroup();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_ProcessPeriod_Main)
                    {
                        UC_Paymass_ProcessPeriod_Main US = new UC_Paymass_ProcessPeriod_Main();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_ProcessPeriod_Sub)
                    {
                        UC_ProcessPeriod_Sub US = new UC_ProcessPeriod_Sub();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_PayslipItem_Amounts)
                    {
                        UC_Employee_PaySlipItems US = new UC_Employee_PaySlipItems();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_ControlPannel)
                    {
                        UC_PayrollControlPannel US = new UC_PayrollControlPannel();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.Payroll_User_Permissions)
                    {
                        UC_PayrollUserPermissions US = new UC_PayrollUserPermissions();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.Employee_Status_Creation)
                    {
                        UC_EmployeeStatus US = new UC_EmployeeStatus();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);

                    }
                    else if (SelectedForm == FormName.Loan_Type_Master)
                    {
                        UC_LoadTypeMaster US = new UC_LoadTypeMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);

                    }
                    

                    else if (SelectedForm == FormName.Payroll_Deduction_Creation)
                    {
                        UC_PayrollDeductionCreation US = new UC_PayrollDeductionCreation();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_Deduction_Taxes)
                    {
                        UC_PayrollDeduction_TAX US = new UC_PayrollDeduction_TAX();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Payroll_Earnings_Creation)
                    {
                        UC_PayrollEarningsMaster US = new UC_PayrollEarningsMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Lump_Sum_Earnings_Creation)
                    {
                        UC_LumpSum US = new UC_LumpSum();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Salary_Sheet_Detailed)
                    {
                        UC_SalarySheet US = new UC_SalarySheet();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Division_Creation)
                    {
                        UC_DivisionMaster US = new UC_DivisionMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Company_Calender)
                    {
                        UC_HRCalander US = new UC_HRCalander();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Approve_GatePass)
                    {
                        UC_Approve_GatePass US = new UC_Approve_GatePass();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Year_End_Process)
                    {
                        UC_YearEndProcess US = new UC_YearEndProcess();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.User_Permission)
                    {
                        UC_UserPermission US = new UC_UserPermission();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_Entitle_Leaves)
                    {
                        UC_EmployeeEntitleLeaves US = new UC_EmployeeEntitleLeaves();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Designation_Creation)
                    {
                        UC_DesignationMaster US = new UC_DesignationMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_Category_1)
                    {
                        UC_EmployeeCategory1 US = new UC_EmployeeCategory1();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_Category_2)
                    {
                        UC_EmployeeCategory2 US = new UC_EmployeeCategory2();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_Category_3)
                    {
                        UC_EmployeeCategory3 US = new UC_EmployeeCategory3();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Section_Creation)
                    {
                        UC_SectionMaster US = new UC_SectionMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Sub_Section_Creation)
                    {
                        UC_SubSectionMaster US = new UC_SubSectionMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Bank_Creation)
                    {
                        UC_Bank US = new UC_Bank();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Bank_Branch_Creation)
                    {
                        UC_BankBranch US = new UC_BankBranch();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Recruitment_Type_Creation)
                    {
                        UC_RecuirtmentType US = new UC_RecuirtmentType();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Nationality_Creation)
                    {
                        UC_NationalityMaster US = new UC_NationalityMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Religion_Creation)
                    {
                        UC_Religion US = new UC_Religion();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.City_Creation)
                    {
                        UC_CityMaster US = new UC_CityMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Country_Creation)
                    {
                        UC_CountryMaster US = new UC_CountryMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.District_Creation)
                    {
                        UC_DistrictMaster US = new UC_DistrictMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Leave_Types_Creation)
                    {
                        UC_LeaveTypesMaster US = new UC_LeaveTypesMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.Postal_Code_Creation)
                    {
                        UC_PostalCodesMaster US = new UC_PostalCodesMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }


                    else if (SelectedForm == FormName.Town_Creation)
                    {
                        UC_TownMaster US = new UC_TownMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Holiday_Type_Creation)
                    {
                        UC_HolidayTypeMaster US = new UC_HolidayTypeMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Title_Creation)
                    {
                        UC_EmployeeTitleMaster US = new UC_EmployeeTitleMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_Status_Creation)
                    {
                        UC_EmployeeStatus US = new UC_EmployeeStatus();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Grama_Niladari_Unit_Creation)
                    {
                        UC_GSDivision US = new UC_GSDivision();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Province_Creation)
                    {
                        UC_Province US = new UC_Province();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.Carder_Count)
                    {
                        UC_CarderCount US = new UC_CarderCount();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Canteen)
                    {
                        frmCanteen US = new frmCanteen();
                        US.Show();
                    }
                    else if (SelectedForm == FormName.Approvals)
                    {
                        UC_Approvals US = new UC_Approvals();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Leave_Apply)
                    {
                        UC_PayrollLevel US = new UC_PayrollLevel();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Staff_Loan)
                    {
                        UC_Staff_Loan US = new UC_Staff_Loan();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Dash_Board_Employee)
                    {
                        frm_DashBord db = new frm_DashBord(2);
                        db.ShowDialog();
                    }

                    else if (SelectedForm == FormName.Dash_Board_IT_Admin)
                    {
                        frm_DashBord db = new frm_DashBord(1);
                        db.ShowDialog();
                    }
                    else if (SelectedForm == FormName.Dash_Board_Management)
                    {
                        frm_DashBord db = new frm_DashBord(3);
                        db.ShowDialog();
                    }


                    //else if (SelectedForm == FormName.SkillCategoryMaster)
                    //{
                    //    UC_Skill_CategoryMaster US = new UC_Skill_CategoryMaster();
                    //    Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    //}
                    else if (SelectedForm == FormName.Company_Awards_And_Certification)
                    {
                        UC_CompanyAwardsAndCeritificates US = new UC_CompanyAwardsAndCeritificates();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Company_Brands)
                    {
                        UC_CompanyBrands US = new UC_CompanyBrands();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Company_Event)
                    {
                        UC_CompanyEvents US = new UC_CompanyEvents();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Vacancy)
                    {
                        UC_Vacencies US = new UC_Vacencies();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Employee_Incidental_Diary)
                    {
                        UC_EmployeeIncedentalDiary US = new UC_EmployeeIncedentalDiary();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.OT_Approval)
                    {
                        UC_OTApproval US = new UC_OTApproval();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Company_Branch_Creation)
                    {
                        UC_CompanyBranchMaster US = new UC_CompanyBranchMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Company_Creation)
                    {
                        UC_CompanyMaster US = new UC_CompanyMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Registration_Details)
                    {
                        UC_CompanyRegInfo US = new UC_CompanyRegInfo();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }


                    else if (SelectedForm == FormName.Form_Tool_Kit)
                    {
                        frm_ToolKit tool = new frm_ToolKit();
                        tool.ShowDialog();
                    }
                    else if (SelectedForm == FormName.DTQ_Test_Kit)
                    {
                        frm_DTQ_Testings tool = new frm_DTQ_Testings();
                        tool.ShowDialog();
                    }


                    else if (SelectedForm == FormName.Import_Attendance_Data)
                    {
                        System.Diagnostics.Process.Start(clsConfig.sImportAttendanceDataSW_path);
                    }
                    else if (SelectedForm == FormName.Security_Form)
                    {
                        UC_SecurityFormMaster US = new UC_SecurityFormMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Security_Report)
                    {
                        UC_SecurityReportMaster US = new UC_SecurityReportMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Documents)
                    {
                        UC_Documents US = new UC_Documents();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.System_Backup)
                    {
                        UC_SystemBackup US = new UC_SystemBackup();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.RollbackPayroll)
                    {
                        UC_RollbackPayroll US = new UC_RollbackPayroll();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.RollbackTimeAttendance)
                    {
                        UC_RollbackTimeAttendance US = new UC_RollbackTimeAttendance();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Company_Account)
                    {
                        UC_CompanyAccount US = new UC_CompanyAccount();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Paye_Tax_Table)
                    {
                        UC_PAYE_TaxTable_1 US = new UC_PAYE_TaxTable_1();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.ReportsTest)
                    {
                        UC_Report_Test US = new UC_Report_Test();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Function_Master)
                    {
                        UC_FunctionMaster_EnablePermission US = new UC_FunctionMaster_EnablePermission();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Roster_ControlPanel)
                    {
                        UC_Roster US = new UC_Roster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.AttendanceGroup1)
                    {
                        UC_AttendanceGroup1 US = new UC_AttendanceGroup1();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Weekly_AttendanceControl_Panel)
                    {
                        UC_WeeklyAttendanceControlPanel US = new UC_WeeklyAttendanceControlPanel();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Monthly_AttendanceControl_Panel)
                    {
                        UC_MonthlyAttendanceControlPanel US = new UC_MonthlyAttendanceControlPanel();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.Attendance_ProcessPeriod)
                    {
                        UC_AttendanceProcessPeriod US = new UC_AttendanceProcessPeriod();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    #region Coconut Cutting Module
                    else if (SelectedForm == FormName.CoconutCuttingDailyEntry)
                    {
                        UC_CoconutCuttingDailyEntry US = new UC_CoconutCuttingDailyEntry();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CoconutCuttingEndofWeekProcess)
                    {
                        UC_CoconutCuttingEndofWeekProcess US = new UC_CoconutCuttingEndofWeekProcess();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CoconutWashingDailyEntry)
                    {
                        UC_CoconutWashingDailyEntry US = new UC_CoconutWashingDailyEntry();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CoconutWashingEndofWeekProcess)
                    {
                        UC_CoconutWashingEndofWeekProcess US = new UC_CoconutWashingEndofWeekProcess();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CoconutLoadingTemporayWorkers)
                    {
                        UC_TemporaryWorkersDailyEntry US = new UC_TemporaryWorkersDailyEntry();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    
                    #endregion
                }

                txtQuickLaunch.Text = "";
                RefreshQuickLaunch();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            UC_Report US = new UC_Report();
            Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        }

        #endregion

        #region Chat
        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            if (Chat.Visibility == Visibility.Hidden)
                Chat.Visibility = Visibility.Visible;
            else
                Chat.Visibility = Visibility.Hidden;
        }
        #endregion

        private void dgv_Search_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            sfds_MouseLeftButtonUp(sender, e);
        }

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                txtQuickLaunch.Focus();
        }

        private void btnlogOff_Click(object sender, RoutedEventArgs e)
        {
            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.LogOut_Confirmation);
            if (bMessegeBoxResult)
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
        private void Reports2_Click(object sender, RoutedEventArgs e)
        {
            UC_Report2 US = new UC_Report2();
            Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        }
        
    }
}