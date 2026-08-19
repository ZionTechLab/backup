using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for SEACC_TextBox.xaml
    /// </summary>
    public partial class SEACC_TextBox : UserControl
    {
        public event EventHandler TextBox_TextChanged;
        BrushConverter bc = new BrushConverter();

        public SEACC_TextBox()
        {
            InitializeComponent();
            TextBox_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");
        }

        public void setReadOnlyStatus(bool isReadOnly)
        { 
            this.TextBox1.IsReadOnly=isReadOnly;
        }

        public static DependencyProperty SEACC_TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SEACC_TextBox));
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

        public static DependencyProperty SEACC_ErrorTextProperty = DependencyProperty.Register("ErrorText", typeof(string), typeof(SEACC_TextBox));
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

        public static DependencyProperty SEACC_ISNumaricProperty = DependencyProperty.Register("ISNumaric", typeof(bool), typeof(SEACC_TextBox));
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
                    TextBox1.HorizontalContentAlignment = HorizontalAlignment.Right;
            }
        }

        public static DependencyProperty SEACC_IsMultilineProperty = DependencyProperty.Register("IsMultiline", typeof(bool), typeof(SEACC_TextBox));
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
            }
        }

        public static DependencyProperty TextBox_BorderBrush_Property = DependencyProperty.Register("TextBox_BorderBrush", typeof(Brush), typeof(SEACC_TextBox));
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

        public static DependencyProperty TextBox_Background_Property = DependencyProperty.Register("TextBox_Background", typeof(Brush), typeof(SEACC_TextBox));
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
    }
}