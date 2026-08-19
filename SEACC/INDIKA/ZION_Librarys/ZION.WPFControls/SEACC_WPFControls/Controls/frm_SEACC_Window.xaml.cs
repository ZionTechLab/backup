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

namespace SEACC_WPFControls
{
    /// <summary>
    /// Interaction logic for frm_SEACC_Window.xaml
    /// </summary>
    public partial class frm_SEACC_Window : Window
    {
        bool bIsmaximized = false;

        public frm_SEACC_Window()
        {
            InitializeComponent();
        }

        public frm_SEACC_Window(UserControl Containt, string FormName)
        {
            InitializeComponent();
            grd_containt.Children.Add(Containt);
            lbl_Title.Text = FormName;
            Form_border.Background = Containt.Background;
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
                this.Margin = new Thickness(8);
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
                this.Margin = new Thickness(0);
            }
        }

        private void GRD_Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
                bIsmaximized = false;
                this.Margin = new Thickness(8);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnRestore.Content = "";
            this.Margin = new Thickness(8);
        }
        #endregion
    }
}
