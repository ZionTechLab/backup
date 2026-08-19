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
    /// Interaction logic for SEACC_LabelTimeSpan.xaml
    /// </summary>
    public partial class SEACC_LabelTimeSpan : UserControl
    {
        BrushConverter bc = new BrushConverter();

        public SEACC_LabelTimeSpan()
        {
            InitializeComponent();
            TextBox_Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");
        }

        public static DependencyProperty SEACC_CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(SEACC_LabelTimeSpan));
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

        public static DependencyProperty TextBox_BorderBrush_Property = DependencyProperty.Register("TextBox_BorderBrush", typeof(Brush), typeof(SEACC_LabelTimeSpan));
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

        public static DependencyProperty TextBox_Background_Property = DependencyProperty.Register("TextBox_Background", typeof(Brush), typeof(SEACC_LabelTimeSpan));
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

        public TimeSpan GetDateTimeSpan()
        {
            return TimeSpan.GetDateTimeSpan();
        }

        public void SetTimeSpan(TimeSpan time)
        {
            TimeSpan.SetTimeSpan(time);
        }

        public int GetMinutes()
        {
            return TimeSpan.GetMinutes();
        }

        public int[] GetDuration()
        {
            return TimeSpan.GetTimeDuration();
        }

        public void setMinutes(int Minutes)
        {
            TimeSpan.setMinutes(Minutes);
        }

        private void userControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth <= 220)
            {
                TimeSpan.Margin = new Thickness(5, 27, 5, 5);
                TimeSpan.HorizontalAlignment = HorizontalAlignment.Center;
                TimeSpan.Width = ActualWidth <= 10 ? 0 : ActualWidth - 10;
            }
            else
            {
                TimeSpan.Margin = new Thickness(120, 2, 0, 2);
                TimeSpan.HorizontalAlignment = HorizontalAlignment.Left;
                TimeSpan.Width = ActualWidth - 125;
            }
        }
    }
}
