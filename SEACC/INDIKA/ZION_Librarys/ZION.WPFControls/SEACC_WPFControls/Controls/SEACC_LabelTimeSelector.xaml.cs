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
    public partial class SEACC_LabelTimeSelector : UserControl
    {
        public event EventHandler DateTimeChanged;
        BrushConverter bc = new BrushConverter();
        int DetailBox_Width = 250;

        public SEACC_LabelTimeSelector()
        {
            ShowDate = Visibility.Collapsed;
            ShowTime = Visibility.Visible;

            InitializeComponent();
            TextBox_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");

            CaptionFontSize = 12;
            DateTimeBoxMaxWidth = 225;
            // ShowTime = true;
        }
       // public bool IsClickToExpand = false;
      

        public static DependencyProperty SEACC_DateTimeBoxMaxWidthProperty = DependencyProperty.Register("DateTimeBoxMaxWidth", typeof(int), typeof(SEACC_LabelTimeSelector));
        public int DateTimeBoxMaxWidth
        {
            get
            {
                return (int)GetValue(SEACC_DateTimeBoxMaxWidthProperty);
            }
            set
            {
                SetValue(SEACC_DateTimeBoxMaxWidthProperty, value);
            }
        }

        public static DependencyProperty SEACC_CaptionFontSizeProperty = DependencyProperty.Register("CaptionFontSize", typeof(double), typeof(SEACC_LabelTimeSelector));
        public double CaptionFontSize
        {
            get
            {
                return (double)GetValue(SEACC_CaptionFontSizeProperty);
            }
            set
            {
                SetValue(SEACC_CaptionFontSizeProperty, value);
            }
        }

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LabelTimeSelector));
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

        public static DependencyProperty TextBox_BorderBrush_Property = DependencyProperty.Register("TextBox_BorderBrush", typeof(Brush), typeof(SEACC_LabelTimeSelector));
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

        public static DependencyProperty TextBox_Background_Property = DependencyProperty.Register("TextBox_Background", typeof(Brush), typeof(SEACC_LabelTimeSelector));
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

        public DateTime GetDateTime()
        {
            return timePicker.GetDateTime();
        }

        public void SetTime(DateTime time)
        {
            timePicker.SetTime(time);
            //  TimeSelector.SetTime(time);
        }

        private void timePicker_DateTimeChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimeChanged(sender, EventArgs.Empty);
            }
            catch (Exception)
            {
            }
        }

        public static DependencyProperty SEACC_ShowDateProperty = DependencyProperty.Register("ShowDate", typeof(Visibility), typeof(SEACC_LabelTimeSelector));
        public Visibility ShowDate
        {
            get
            {
                return (Visibility)GetValue(SEACC_ShowDateProperty);
            }
            set
            {
                SetValue(SEACC_ShowDateProperty, value);
            }
        }

        public static DependencyProperty SEACC_ShowTimeProperty = DependencyProperty.Register("ShowTime", typeof(Visibility), typeof(SEACC_LabelTimeSelector));
        public Visibility ShowTime
        {
            get
            {
                return (Visibility)GetValue(SEACC_ShowTimeProperty);
            }
            set
            {
                SetValue(SEACC_ShowTimeProperty, value);
            }
        }

        private void userControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 120 + 2 * DetailBox_Width / 3)
            {
                timePicker.Margin = new Thickness(5, 27, 5, 5);
                timePicker.HorizontalAlignment = HorizontalAlignment.Center;
                timePicker.Width = ActualWidth <= 10 ? 0 : ActualWidth - 10;                
            }
            else
            {
                timePicker.Margin = new Thickness(120, 2, 0, 2);
                timePicker.HorizontalAlignment = HorizontalAlignment.Left;
                timePicker.Width = ActualWidth - 125;
            }
            timePicker.PopUpWidth = timePicker.Width-6; 
        }
    }
}
