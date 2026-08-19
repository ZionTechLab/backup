using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Threading;
using SEACC_WPFControls.Logic;
using WinInterop = System.Windows.Interop;
using System.Runtime.InteropServices;

namespace SEACC_WPFControls
{
    public partial class frm_LandingPage : Window
    {
        bool bIsmaximized = false;
        static BrushConverter bc = new BrushConverter();
        public DataTable tbl_Functions = new DataTable();
        public DataTable tbl_Search = new DataTable();

        public delegate void delegate_FunctionSelected(int iFormID);
        public event delegate_FunctionSelected FunctionSelected;

        public delegate void delegate_1();
        public event delegate_1 SystemShutDown;
        //public delegate void delegate_Network(object sender, NetworkAvailabilityEventArgs e);
        //public event delegate_Network NetworkAvailabilityCheck;

        public event EventHandler BtnReportClick;
        public event EventHandler UserSettingsClick;

        public int iIdlePeriod_Seconds = 18000; //5 Hrs

        public frm_LandingPage()
        {
            LandingPageInitialize();
        }

        public frm_LandingPage(int sLogoutIdleTimeInSecs)
        {
            LandingPageInitialize();
            iIdlePeriod_Seconds = sLogoutIdleTimeInSecs;
        }

        private void LandingPageInitialize()
        {
            #region Initialize Form
            InitializeComponent();
            #endregion

            frmMain.SourceInitialized += new EventHandler(win_SourceInitialized);

            #region initialized data table
            tbl_Functions.Columns.Add("FormID", typeof(int));
            tbl_Functions.Columns.Add("FormName", typeof(string));
            tbl_Functions.Columns.Add("Image", typeof(BitmapImage));
            tbl_Functions.Columns.Add("formCategory_ID", typeof(string));
            #endregion

            #region Background Timer - In Idle Situation, Auto Log off
            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(BackgroundTimer_Tick);
            dt.Interval = new TimeSpan(0, 1, 0); // execute every Minute
            dt.Start();
            #endregion

            NetworkChange.NetworkAvailabilityChanged += NetworkAvailabilityChangeHandler;
        }

        private void BackgroundTimer_Tick(object sender, EventArgs e)
        {
            var dIdleTicks = IdleTimeFinder.GetIdleTime();
            TimeSpan tsIdle = TimeSpan.FromMilliseconds(dIdleTicks);
            double dIdleSeconds = tsIdle.TotalSeconds;
            if (dIdleSeconds > iIdlePeriod_Seconds && iIdlePeriod_Seconds > 0)
            {
                SEACC_LoggingOffBox frmLogOffBox = new SEACC_LoggingOffBox();
                if (!frmLogOffBox.ShowDialog().Value)
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    //Application.Current.Shutdown();
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }

        private void NetworkAvailabilityChangeHandler(object sender, NetworkAvailabilityEventArgs e)
        {
            if (!e.IsAvailable)
            {
                //MessageBox.Show("Please login again...", "Network Connection Loast", MessageBoxButton.OK);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    frm_WaitingMessege oMsg = new frm_WaitingMessege("Network Connection Lost!!! Application is shutting down");
                    Thread.Sleep(2000);
                    oMsg.Close();

                    var a = Application.Current.Windows.Count;
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window == Application.Current.MainWindow)
                        {
                            var windowHandle = window;
                            window.Dispatcher.Invoke(windowHandle.Close);
                        }
                    }
                });
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;

            #region initalize Search
            tbl_Search = tbl_Functions;
            // dgv_Search.ItemsSource = tbl_Search.DefaultView;
            #endregion

            grd_popSubMenus.Visibility = Visibility.Collapsed;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnRestore.Content = "";
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            bool bReturn = SEACCMessageBox.Show("System Close Confirmation", "Are you sure to close the system ? \n", MessageBoxButton.YesNo, "#FF5B6B76");

            if (bReturn)
            {
                Close();
            }
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
                bIsmaximized = true;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            About_US.Show();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Help.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.LogOut_Confirmation);
            if (bMessegeBoxResult)
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }

        private void GRD_Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
                bIsmaximized = false;
                btnRestore.Content = "";
            }
            catch (Exception)
            {
            }
        }

        public void Addmenubutton(string ModuleName, string Module_ID)
        {
            SEACC_MenuButton btn_module = new SEACC_MenuButton();
            btn_module.Height = 33;
            btn_module.set(ModuleName);
            btn_module.setRightText("\uE102");
            btn_module.Tag = Module_ID;
            btn_module.MouseDown += btn_module_MouseDown;
            btn_module.MouseUp += Btn_module_MouseUp;
            grd_modules.Children.Add(btn_module);
        }

        private void Btn_module_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grd_popSubMenus.Focus();
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
                else
                {
                    SetSubModules(o.Tag.ToString());
                }

                grd_popSubMenus.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

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
                    FunctionSelected(iFormID);
                }

                grd_popSubMenus.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            BtnReportClick(sender, e);
        }

        private void Reports2_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Open_NewTabpage(UserControl uc, bool PermissionTO_Read, string FormName, string FormID)
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

                    grdTopLine.Background = (Brush)bc.ConvertFrom("#FFDB6E32");
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

        private void grd_popSubMenus_LostFocus(object sender, RoutedEventArgs e)
        {
            grd_popSubMenus.Visibility = Visibility.Collapsed;
            //  MessageBox.Show("");
        }

        private void SEACC_Button_Close_Click(object sender, RoutedEventArgs e)
        {
            grd_popSubMenus.Visibility = Visibility.Collapsed;
        }

        public void Set_CompanyImage(byte[] image)
        {
            try
            {
                img_Company.Source = cls_Formater.Convert_ByteToBitMap(image);
            }
            catch (Exception)
            {
            }
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //  grd_popSubMenus.Visibility = Visibility.Collapsed;
        }

        private void SetLeftPanalSize(bool toBigerSize)
        {
            lblMenuVisible.Visibility = Visibility.Collapsed;
            lblMenuHide.Visibility = Visibility.Collapsed;
            if (toBigerSize)
            {
                columnA.Width = new GridLength(200);
                lblMenuHide.Visibility = Visibility.Visible;
            }
            else
            {
                columnA.Width = new GridLength(30);
                lblMenuVisible.Visibility = Visibility.Visible;
            }

        }

        private void lblMenuHide_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (columnA.Width.Value == 30)
                SetLeftPanalSize(true);
            else
                SetLeftPanalSize(false);
        }

        private void rightPanal_GotFocus(object sender, RoutedEventArgs e)
        {
            grd_popSubMenus.Visibility = Visibility.Collapsed;
        }

        private void btnUserSettings_Click(object sender, RoutedEventArgs e)
        {
            UserSettingsClick(sender, e);
        }


        #region Avoid hiding task bar upon maximalisation

        private static System.IntPtr WindowProc(
              System.IntPtr hwnd,
              int msg,
              System.IntPtr wParam,
              System.IntPtr lParam,
              ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (System.IntPtr)0;
        }

        void win_SourceInitialized(object sender, EventArgs e)
        {
            System.IntPtr handle = (new WinInterop.WindowInteropHelper(this)).Handle;
            WinInterop.HwndSource.FromHwnd(handle).AddHook(new WinInterop.HwndSourceHook(WindowProc));
        }

        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {

            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// x coordinate of point.
            /// </summary>
            public int x;
            /// <summary>
            /// y coordinate of point.
            /// </summary>
            public int y;

            /// <summary>
            /// Construct a point of coordinates (x,y).
            /// </summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        void win_Loaded(object sender, RoutedEventArgs e)
        {
            frmMain.WindowState = WindowState.Maximized;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            /// <summary> Win32 </summary>
            public int left;
            /// <summary> Win32 </summary>
            public int top;
            /// <summary> Win32 </summary>
            public int right;
            /// <summary> Win32 </summary>
            public int bottom;

            /// <summary> Win32 </summary>
            public static readonly RECT Empty = new RECT();

            /// <summary> Win32 </summary>
            public int Width
            {
                get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
            }
            /// <summary> Win32 </summary>
            public int Height
            {
                get { return bottom - top; }
            }

            /// <summary> Win32 </summary>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }


            /// <summary> Win32 </summary>
            public RECT(RECT rcSrc)
            {
                this.left = rcSrc.left;
                this.top = rcSrc.top;
                this.right = rcSrc.right;
                this.bottom = rcSrc.bottom;
            }

            /// <summary> Win32 </summary>
            public bool IsEmpty
            {
                get
                {
                    // BUGBUG : On Bidi OS (hebrew arabic) left > right
                    return left >= right || top >= bottom;
                }
            }
            /// <summary> Return a user friendly representation of this struct </summary>
            public override string ToString()
            {
                if (this == RECT.Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }

            /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }

            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode()
            {
                return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            }


            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
            }

            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }


        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        #endregion
    }
}
