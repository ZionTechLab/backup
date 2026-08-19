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
using DataTire;
using Digiteq_Logic;
using System.Data;
using SEACC_WPFControls;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frm_DashBord.xaml
    /// </summary>
    public partial class frm_DashBord : Window
    {
        bool bIsmaximized = false;

        public frm_DashBord()
        {
            InitializeComponent();
         //   clsCommon cs = new clsCommon();
           // cs.Marquee_Display(true, this.Width);

        }

        public frm_DashBord(int i)
        {
            InitializeComponent();
            if (i == 1)
            {
                Dashboord_IT ss = new Dashboord_IT();
                body.Children.Add(ss);
            }
            if (i == 2)
            {
                dashboard_employee ss = new dashboard_employee();
                body.Children.Add(ss);
            }
            if (i == 3)
            {
                dashboard_management ss = new dashboard_management();
                body.Children.Add(ss);
            }
        }

        #region Form Control Box
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            userIndicator.SetUser(clsSecurity.UserNameLoged, "Employee", clsSecurity.UserImageLoged, false);
        }

        private void GRD_Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnRestore.Content = "";
        }
        #endregion

        #region Forms
        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            if (Chat.Visibility == Visibility.Hidden)
                Chat.Visibility = Visibility.Visible;
            else
                Chat.Visibility = Visibility.Hidden;
        }

        private void btn_WebLinks_Click(object sender, RoutedEventArgs e)
        {
            UC_WebLinks UC = new UC_WebLinks();
            if (UC.SEACC_Form.PermissionTO_Read)
            {
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
        }

        private void btn_RequestForLeter_Click(object sender, RoutedEventArgs e)
        {
            UC_RequestForLetter UC = new UC_RequestForLetter();
            if (UC.SEACC_Form.PermissionTO_Read)
            {
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
        }

        private void btn_ApplyLeave_Click(object sender, RoutedEventArgs e)
        {
            UC_LeaveApplication UC = new UC_LeaveApplication();
            if (UC.SEACC_Form.PermissionTO_Read)
            {
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
        }

        private void btn_EmpProfile_Click(object sender, RoutedEventArgs e)
        {
            //UC_EmployeeMaster UC = new UC_EmployeeMaster();
            //frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            //SW.ShowDialog();
            SEACCMessageBox.Show("Oops...", "Sorry ! '" + clsSecurity.UserNameLoged + "'  You don't have permission to view this ", MessageBoxButton.OK);
        }

        private void btn_PaySlip_Click(object sender, RoutedEventArgs e)
        {
            SEACCMessageBox.Show("Oops...", "Sorry ! '" + clsSecurity.UserNameLoged + "'  You don't have permission to view this ", MessageBoxButton.OK);
        }

        private void btn_dutiLeave_Click(object sender, RoutedEventArgs e)
        {
            UC_GatePass UC = new UC_GatePass();
            if (UC.SEACC_Form.PermissionTO_Read)
            {
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
        }

        private void btn_Approval_Click(object sender, RoutedEventArgs e)
        {
            UC_Approvals UC = new UC_Approvals();
            if (UC.SEACC_Form.PermissionTO_Read)
            {
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
        }

        private void btn_Approval_GP_Click(object sender, RoutedEventArgs e)
        {
            UC_Approve_GatePass UC = new UC_Approve_GatePass();
            if (UC.SEACC_Form.PermissionTO_Read)
            {
                frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
                SW.ShowDialog();
            }
        } 
        #endregion


    }
}