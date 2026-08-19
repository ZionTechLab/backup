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

namespace SEACC_WPFControls
{
    /// <summary>
    /// Interaction logic for SEACC_LabelCheckBox.xaml
    /// </summary>
    public partial class SEACC_LabelCheckBox : UserControl
    {
        public SEACC_LabelCheckBox()
        {
            InitializeComponent();
        }

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LabelCheckBox));
        public string Caption
        {
            get
            {
                return (string)GetValue(SEACC_CaptionProperty);
            }
            set
            {
                SetValue(SEACC_CaptionProperty, value);
            }
        }

        public static DependencyProperty IsChecked_Property = DependencyProperty.Register("IsChecked", typeof(bool), typeof(SEACC_LabelCheckBox));
        public bool IsChecked
        {
            get
            {
                return (bool)GetValue(IsChecked_Property);
            }
            set
            {
                SetValue(IsChecked_Property, value);
            }
        }

        private void userControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 120 + 2 * ChkBx.ActualWidth)
                ChkBx.Margin = new Thickness(15, 27, 5, 5);
            else
                ChkBx.Margin = new Thickness(125, 2, 0, 2);
        }

        public event EventHandler checkBox_Unchecked;
        private void ChkBx_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                checkBox_Unchecked(sender, e);
            }
            catch (Exception)
            {
            }
        }

        public event EventHandler checkBox_Checked;
        private void ChkBx_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                checkBox_Checked(sender, e);
            }
            catch (Exception )
            {
            }
        }
    }
}