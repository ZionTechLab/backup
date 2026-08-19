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

namespace SEACC_servii.User_Controls
{
    /// <summary>
    /// Interaction logic for frm_UserMenu.xaml
    /// </summary>
    public partial class frm_UserMenu : Window
    {
        public frm_UserMenu()
        {
            InitializeComponent();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            //  this.Close();
        }

        private void Grid_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

        }

        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("lost ");
        }

        private void Window_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("Window_FocusableChanged ");
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            try
            {
                //  if (!isFirslForcuslost)
                this.Close();
                //  isFirslForcuslost = false;
            }
            catch (Exception)
            {
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //   this.Activate();
            this.Activate();
            this.Topmost = true;  // important
            // this.Topmost = false; // important
            this.Focus();
            //   this.

        }
    }
}
