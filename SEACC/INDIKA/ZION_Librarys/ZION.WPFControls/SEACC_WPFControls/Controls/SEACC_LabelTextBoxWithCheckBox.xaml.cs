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
    /// Interaction logic for SEACC_LabelTextBoxWithCheckBox.xaml
    /// </summary>
    public partial class SEACC_LabelTextBoxWithCheckBox : UserControl
    {
        public event EventHandler TextBox_TextChanged;
        public event EventHandler TextBox_Checked;
        public event EventHandler TextBox_UnChecked;

        BrushConverter bc = new BrushConverter();

        public SEACC_LabelTextBoxWithCheckBox()
        {
            InitializeComponent();
            TextBox_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");
            BoxForeground = (Brush)bc.ConvertFrom("#000000");
            TextForeground = (Brush)bc.ConvertFrom("#000000");

            DetailBox_Width = 225;
            IsMultiline = true;
        }

        public void setReadOnlyStatus(bool isReadOnly)
        {
            TextBox1.IsReadOnly = isReadOnly;
        }

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LabelTextBoxWithCheckBox));
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

        public static DependencyProperty SEACC_TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SEACC_LabelTextBoxWithCheckBox));
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

        public static DependencyProperty SEACC_ErrorTextProperty = DependencyProperty.Register("ErrorText", typeof(string), typeof(SEACC_LabelTextBoxWithCheckBox));
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

        public static DependencyProperty SEACC_ISNumaricProperty = DependencyProperty.Register("ISNumaric", typeof(bool), typeof(SEACC_LabelTextBoxWithCheckBox));
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
                    // TextBox1.FlowDirection = FlowDirection.RightToLeft;
                    TextBox1.HorizontalContentAlignment = HorizontalAlignment.Right;
            }
        }

        public static DependencyProperty SEACC_ISCheckedroperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(SEACC_LabelTextBoxWithCheckBox));
        public bool IsChecked
        {
            get
            {
                return (bool)GetValue(SEACC_ISCheckedroperty);
            }
            set
            {
                SetValue(SEACC_ISCheckedroperty, value);
            }
        }

        public static DependencyProperty SEACC_IsMultilineProperty = DependencyProperty.Register("IsMultiline", typeof(bool), typeof(SEACC_LabelTextBoxWithCheckBox));
        public bool IsMultiline
        {
            get
            {
                return (bool)GetValue(SEACC_IsMultilineProperty);
            }
            set
            {
                SetValue(SEACC_IsMultilineProperty, value);
                if (IsMultiline)
                {
                    TextBox1.AcceptsReturn = true;
                    TextBox1.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    TextBox1.TextWrapping = TextWrapping.Wrap;
                }
                else
                {
                    TextBox1.AcceptsReturn = false;
                    // TextBox1.V  erticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    TextBox1.TextWrapping = TextWrapping.NoWrap;
                }
            }
        }

        public static DependencyProperty TextBox_BorderBrush_Property = DependencyProperty.Register("TextBox_BorderBrush", typeof(Brush), typeof(SEACC_LabelTextBoxWithCheckBox));
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

        public static DependencyProperty BoxForeground_Property = DependencyProperty.Register("BoxForeground", typeof(Brush), typeof(SEACC_LabelTextBoxWithCheckBox));
        public Brush BoxForeground
        {
            get
            {
                return (Brush)GetValue(BoxForeground_Property);
            }
            set
            {
                SetValue(BoxForeground_Property, value);
            }
        }

        public static DependencyProperty TextForeground_Property = DependencyProperty.Register("TextForeground", typeof(Brush), typeof(SEACC_LabelTextBoxWithCheckBox));
        public Brush TextForeground
        {
            get
            {
                return (Brush)GetValue(TextForeground_Property);
            }
            set
            {
                SetValue(TextForeground_Property, value);
            }
        }

        public static DependencyProperty DetailBox_Width_Property = DependencyProperty.Register("DetailBox_Width", typeof(int), typeof(SEACC_LabelTextBoxWithCheckBox));
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

        public static DependencyProperty TextBox_Background_Property = DependencyProperty.Register("TextBox_Background", typeof(Brush), typeof(SEACC_LabelTextBoxWithCheckBox));
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


        private void userControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 120 + 2 * DetailBox_Width / 3)
            {
                label.VerticalAlignment = VerticalAlignment.Top;
                TextBox1.Margin = new Thickness(2, 20, 5, 10);
                TextBox1.HorizontalAlignment = HorizontalAlignment.Center;
                TextBox1.Width = ActualWidth <= 10 ? 0 : ActualWidth - 10;
            }
            else
            {
                label.VerticalAlignment = VerticalAlignment.Center;
                TextBox1.Margin = new Thickness(117, 2, 0, 2);
                TextBox1.HorizontalAlignment = HorizontalAlignment.Left;
                TextBox1.Width = ActualWidth - 125;
            }
        }

        private void userControl_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox1.Focus();
        }

        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (ISNumaric)
            {
                bool approvedDecimalPoint = false;

                if (e.Text == ".")
                {
                    if (!((TextBox)sender).Text.Contains("."))
                        approvedDecimalPoint = true;
                }

                if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                    e.Handled = true;
            }
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox_TextChanged(sender, e);
            }
            catch { }
        }

        private void label_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox_Checked(sender, e);
            }
            catch { }
        }

        private void label_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox_UnChecked(sender, e);
            }
            catch { }
        }
    }
}
