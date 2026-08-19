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
    /// Interaction logic for SEACC_MessegeBox.xaml
    /// </summary>
    public partial class SEACC_MessegeBox : Window
    {      
        static BrushConverter bc = new BrushConverter();

        public SEACC_MessegeBox()
        {
            InitializeComponent();
        }

        public SEACC_MessegeBox(string Caption, string Messege,MessageBoxButton btn)
        {
            InitializeComponent();
            lbl_Caption.Text = Caption;
            lblMessege.Text = Messege;

            switch (btn)
            {
                case MessageBoxButton.OK:
                    {
                        Btn_Cancel.Visibility = Visibility.Hidden;
                        Btn_Cancel.Width = 0;
                        Btn_OK.Content = "OK";
                    }
                    break;
                case MessageBoxButton.OKCancel:
                    break;
                case MessageBoxButton.YesNo:
                    break;
                case MessageBoxButton.YesNoCancel:
                    break;
                default:
                    break;
            }
        }

        public void SetMessegeboxColor(string ColorCode)
        {
            Btn_OK.Background = (Brush)bc.ConvertFrom(ColorCode);
            grdHeader.Background = (Brush)bc.ConvertFrom(ColorCode);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          //  this.WindowState = WindowState.Maximized;
           // CenterWindowOnScreen();
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Enter)
                Btn_OK_Click(null, null);

            else if (e.Key == Key.Escape)
                Btn_Cancel_Click(null, null);

          
        }
    }
}
