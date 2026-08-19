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
using SEACC_servii.Master_Forms;
using SEACC_servii.User_Management;
using System.Windows.Shell;
namespace SEACC_servii
{
    /// <summary>
    /// Interaction logic for frm_LandingPage.xaml
    /// </summary>
    public partial class frm_LandingPage : Window
    {
        #region Class Variables
        DataTable tbl_Functions = new DataTable();
        DataTable tbl_Search = new DataTable();
        bool bIsmaximized = false;
        static BrushConverter bc = new BrushConverter();
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
                //System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);
                //bIsmaximized = false;
                //this.Height = Scr.WorkingArea.Height / 2;
                //this.Width = Scr.WorkingArea.Width / 2;
                //this.Left = Scr.Bounds.Location.X + Scr.Bounds.Width / 4;
                //this.Top = Scr.Bounds.Location.Y + Scr.WorkingArea.Height / 4;
                bIsmaximized = false;
                this.WindowState = WindowState.Normal;
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
            catch (Exception)
            {
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                //System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);

                //this.WindowState = WindowState.Normal;
                //this.Height = Scr.WorkingArea.Height;
                //this.Width = Scr.WorkingArea.Width;

                //this.Left = Scr.Bounds.Location.X;
                //this.Top = Scr.Bounds.Location.Y;
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

        public frm_LandingPage()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight-10;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Maximized;
                User_Indicator.SetUser(clsSecurity.UserNameLoged, clsRef_Name.get_UserGroup_Name(clsSecurity.UserGroupIDLoged), clsSecurity.UserImageLoged, false);
                txtQuickLaunch.Focus();

                #region Menu
                #region Load modules
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll())
                {
                    SEACC_MenuButton btn_module = new SEACC_MenuButton();
                    btn_module.Height = 33;
                    
                    btn_module.set(oModule.ModuleName);
                    btn_module.setRightText("\uE102");
                    btn_module.Tag = oModule.Module_ID;
                    btn_module.MouseDown += btn_module_MouseDown;
                    grd_modules.Children.Add(btn_module);
                    // iMenuModule_Width += 33;

                    var bc = new BrushConverter();
                    btn_module.Background = (Brush)bc.ConvertFrom("#FF5873A2");
                }
                #endregion

                #region load Functions
                #region initialized data table
                tbl_Functions.Columns.Add("FormID", typeof(int));
                tbl_Functions.Columns.Add("FormName", typeof(string));
                tbl_Functions.Columns.Add("Image", typeof(BitmapImage));
                tbl_Functions.Columns.Add("formCategory_ID", typeof(string));
                #endregion

                foreach (tbl_securityFormMaster oForm in tbl_securityFormMaster.SelectAll().Where(p => p.IsEnable == true).OrderBy(p => p.SortOrder))
                {
                    try
                    {
                        tbl_Functions.Rows.Add(oForm.Form_ID, oForm.FormName, (cls_Formater.Convert_ByteToBitMap(oForm.Image)), oForm.FormCategory_ID);
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

                //cls_Formater cs = new cls_Formater();
                SetExpDate();

                if (clsConfig.SystemExpireDate < DateTime.Now)
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


        private void dgv_Search_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            sfds_MouseLeftButtonUp(sender, e);
        }


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

                    grdTopLine.Background = (Brush)bc.ConvertFrom("#FF1919");
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

        #region menu

        public void SetSubModules(String category)
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

                if (o.Tag.ToString() == "0")
                {
                    SetSubModules("DTQ");
                }
                if (o.Tag.ToString() == "1")
                {
                    SetSubModules("ADM");
                }
                else if (o.Tag.ToString() == "2")
                {
                    SetSubModules("SETT");
                }
                else if (o.Tag.ToString() == "3")
                {
                    SetSubModules("TAS");
                }
                else if (o.Tag.ToString() == "4")
                {
                    SetSubModules("PAY");
                }
                else if (o.Tag.ToString() == "5")
                {
                    SetSubModules("APP");
                }
                else if (o.Tag.ToString() == "6")
                {
                    SetSubModules("REC");
                }
                else if (o.Tag.ToString() == "7")
                {
                    SetSubModules("LOAN");
                }
                else if (o.Tag.ToString() == "8")
                {
                    SetSubModules("CAFF");
                }
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

                    #region Master Forms
                    if (SelectedForm == FormName.CountryMaster)
                    {
                        UC_CountryMaster US = new UC_CountryMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    if (SelectedForm == FormName.ProvinceCreation)
                    {
                        UC_Province US = new UC_Province();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.DistrictMaster)
                    {
                        UC_DistrictMaster US = new UC_DistrictMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CityMaster)
                    {
                        UC_CityMaster US = new UC_CityMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.TownCreation)
                    {
                        UC_TownMaster US = new UC_TownMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }


                    else if (SelectedForm == FormName.TaxMaster)
                    {
                        UC_TaxMaster US = new UC_TaxMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CategoryOfUnitOfMeasureMaster)
                    {
                        UC_UomCategoryMaster US = new UC_UomCategoryMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.UnitOfMeasureMaster)
                    {
                        UC_UomMaster US = new UC_UomMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }


                    else if (SelectedForm == FormName.ItemClassMaster)
                    {
                        UC_ItemClassMaster US = new UC_ItemClassMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.ItemTypeMaster)
                    {
                        UC_ItemTypeMaster US = new UC_ItemTypeMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.ItemCategoryMaster)
                    {
                        UC_ItemCategoryMaster US = new UC_ItemCategoryMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.ItemBrandMaster)
                    {
                        UC_ItemBrandMaster US = new UC_ItemBrandMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.ItemCreationMaster)
                    {
                        UC_ItemMaster US = new UC_ItemMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                    else if (SelectedForm == FormName.BrokerMaster)
                    {
                        UC_BrokerMaster US = new UC_BrokerMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CustomerClassMaster)
                    {
                        UC_CustomerClassMater US = new UC_CustomerClassMater();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CustomerTypeMaster)
                    {
                        UC_CustomerTypeMaster US = new UC_CustomerTypeMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CustomerCategoryMaster)
                    {
                        UC_CustomerCategoryMaster US = new UC_CustomerCategoryMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.CustomerMaster)
                    {
                        UC_CustomerMaster US = new UC_CustomerMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.WarehouseMaster)
                    {
                        UC_WarehouseMaster US = new UC_WarehouseMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }

                   

                    #endregion

                    #region User Management
                    else if (SelectedForm == FormName.UserCreation)
                    {
                        UC_UserMaster US = new UC_UserMaster();
                        Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                    }
                    else if (SelectedForm == FormName.UserPermissionSetup)
                    {
                        UC_UserPermission US = new UC_UserPermission();
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
            //UC_Report US = new UC_Report();
            //Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        }
        #endregion

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                txtQuickLaunch.Focus();
        }

        private void SetExpDate()
        {
            tbl_securityConfigValue ExpDate = tbl_securityConfigValue.Select(1);
            clsConfig.SystemExpireDate = Convert.ToDateTime(ExpDate.ConfigValue);
        }
    }
}
