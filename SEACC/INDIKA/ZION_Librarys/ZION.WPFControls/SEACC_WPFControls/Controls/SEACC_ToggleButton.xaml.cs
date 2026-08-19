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
    public partial class SEACC_ToggleButton : UserControl
    {
        public delegate void delegate_MouseClick(object sender, MouseButtonEventArgs e);
        public event delegate_MouseClick Click;

        BrushConverter bc = new BrushConverter();
        public bool bBtnStatus = true;

        public SEACC_ToggleButton()
        {
            InitializeComponent();
            BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");
        }
        public static DependencyProperty SEACC_TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SEACC_ToggleButton));

        public string Text
        {
            get
            {
                return (string)GetValue(SEACC_TextProperty);
            }
            set
            {
                SetValue(SEACC_TextProperty, value);
            }
        }

        public void SetStatus(bool status)
        {
            if (!status)
            {
                bBtnStatus = false;
                grd_Shadow.Visibility = Visibility.Hidden;
                colorLine.Visibility = Visibility.Hidden;
            }
            else
            {
                bBtnStatus = true;
                grd_Shadow.Visibility = Visibility.Visible;
                colorLine.Visibility = Visibility.Visible;
            }
        }

        private void UserControl_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //if (bBtnStatus)
            //{
            //    bBtnStatus = false;
            //    grd_Shadow.Visibility = Visibility.Hidden;
            //    colorLine.Visibility = Visibility.Hidden;
            //}
            //else
            //{
            //    bBtnStatus = true;
            //    grd_Shadow.Visibility = Visibility.Visible;
            //    colorLine.Visibility = Visibility.Visible;
            //}
            //try
            //{
                Click(sender, e);
            //}
            //catch (Exception)
            //{
            //}
        }
    }
}