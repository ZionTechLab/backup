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
    /// Interaction logic for SEACC_LabelPasswordBox.xaml
    /// </summary>
    public partial class SEACC_LabelPasswordBox : UserControl
    {
        public SEACC_LabelPasswordBox()
        {
            InitializeComponent();

            //TextBox_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            //TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");
            //DetailBox_Width = 250;
            //IsMultiline = true;
        }
        /*
        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LableTextBox));
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

        public static DependencyProperty SEACC_TextProperty = DependencyProperty.Register("Password", typeof(string), typeof(SEACC_LableTextBox));
        public string Password
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

        public static DependencyProperty SEACC_ErrorTextProperty = DependencyProperty.Register("ErrorText", typeof(string), typeof(SEACC_LableTextBox));
        public string ErrorText
        {
            get
            {
                return (string)GetValue(SEACC_ErrorTextProperty);
            }
            set
            {
                SetValue(SEACC_ErrorTextProperty, value);
            }
        }

        public static DependencyProperty SEACC_ISNumaricProperty = DependencyProperty.Register("ISNumaric", typeof(bool), typeof(SEACC_LableTextBox));
        public bool ISNumaric
        {
            get
            {
                return (bool)GetValue(SEACC_ISNumaricProperty);
            }
            set
            {
                SetValue(SEACC_ISNumaricProperty, value);
                if (ISNumaric)
                    TextBox1.FlowDirection = FlowDirection.RightToLeft;
            }
        }

        public static DependencyProperty TextBox_BorderBrush_Property = DependencyProperty.Register("TextBox_BorderBrush", typeof(Brush), typeof(SEACC_LableTextBox));
        public Brush TextBox_BorderBrush
        {
            get
            {
                return (Brush)GetValue(TextBox_BorderBrush_Property);
            }
            set
            {
                SetValue(TextBox_BorderBrush_Property, value);
            }
        }

        public static DependencyProperty DetailBox_Width_Property = DependencyProperty.Register("DetailBox_Width", typeof(int), typeof(SEACC_LableTextBox));
        public int DetailBox_Width
        {
            get
            {
                return (int)GetValue(DetailBox_Width_Property);
            }
            set
            {
                SetValue(DetailBox_Width_Property, value);
            }
        }

        public static DependencyProperty TextBox_Background_Property = DependencyProperty.Register("TextBox_Background", typeof(Brush), typeof(SEACC_LableTextBox));
        public Brush TextBox_Background
        {
            get
            {
                return (Brush)GetValue(TextBox_Background_Property);
            }
            set
            {
                SetValue(TextBox_Background_Property, value);
            }
        }

        private void TextBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (ISNumaric)
            {
                char NewKey = (Char)KeyInterop.VirtualKeyFromKey(CommonValidations.getNumaricKey(e.Key));
                if (!(char.IsDigit(NewKey) || e.Key == Key.Decimal || e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Right || e.Key == Key.Left))
                    e.Handled = true;
            }
        }

        private void userControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 120 + 2 * DetailBox_Width / 3)
            {
                TextBox1.Margin = new Thickness(5, 27, 5, 5);
                TextBox1.HorizontalAlignment = HorizontalAlignment.Center;
                TextBox1.Width = ActualWidth <= 10 ? 0 : ActualWidth - 10;
            }
            else
            {
                TextBox1.Margin = new Thickness(120, 2, 0, 2);
                TextBox1.HorizontalAlignment = HorizontalAlignment.Left;
                TextBox1.Width = ActualWidth - 125;
            }
        }
         */
    }
}
