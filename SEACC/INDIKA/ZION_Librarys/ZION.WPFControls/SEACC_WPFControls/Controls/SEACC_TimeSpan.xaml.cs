using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SEACC_TimeSpan.xaml
    /// </summary>
    public partial class SEACC_TimeSpan : UserControl
    {
        TimeSpan ts = new TimeSpan();

        public SEACC_TimeSpan()
        {
            InitializeComponent();
        }

        public TimeSpan GetDateTimeSpan()
        {
            return ts;
        }

        public void SetTimeSpan(TimeSpan timespan)
        {
            ts = timespan;
            Update_View();
        }

        public int GetMinutes()
        {
            return (ts.Days * 24 * 60 + ts.Hours * 60 + ts.Minutes);
        }

        public int[] GetTimeDuration()
        {
            int[] duration = new int[3];
            duration[0] = ts.Days;
            duration[1] = ts.Hours;
            duration[2] = ts.Minutes;
            return duration;
        }

        public void setMinutes(int Minutes)
        {
            ts = TimeSpan.FromMinutes(Minutes);
            Update_View();
        }

        private void Update_View()
        {
            tb_Days.Text = ts.Days.ToString();
            tb_Hours.Text = ts.Hours.ToString();
            tb_minutes.Text = ts.Minutes.ToString();

            txt_Days.Text = ts.Days.ToString();
            txt_Hours.Text = ts.Hours.ToString();
            txt_minutes.Text = ts.Minutes.ToString();
        }

        private void Update_TimeSpan()
        {
            ts = TimeSpan.FromMinutes(double.Parse(txt_Days.Text) * 24 * 60 + double.Parse(txt_Hours.Text) * 60 + double.Parse(txt_minutes.Text));
            Update_View();

            txt_Hours.Visibility = Visibility.Hidden;
            txt_Days.Visibility = Visibility.Hidden;
            txt_minutes.Visibility = Visibility.Hidden;
        }
 
        private void grd_Hours_MouseUp(object sender, MouseButtonEventArgs e)
        {
            txt_Hours.Text = tb_Hours.Text;
           
            txt_Hours.Visibility = Visibility.Visible;
            txt_Hours.Focus();
            txt_Hours.SelectAll();
        }

        private void grd_Days_MouseUp(object sender, MouseButtonEventArgs e)
        {
            txt_Days.Text = tb_Days.Text;
           
            txt_Days.Visibility = Visibility.Visible;
            txt_Days.Focus();
            txt_Days.SelectAll();
        }

        private void Grd_Mts_MouseUp(object sender, MouseButtonEventArgs e)
        {
            txt_minutes.Text = tb_minutes.Text;
          
            txt_minutes.Visibility = Visibility.Visible; 
            txt_minutes.Focus();
            txt_minutes.SelectAll();
        }

        private void txt_Hours_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //char NewKey = (Char)KeyInterop.VirtualKeyFromKey(CommonValidations.getNumaricKey(e.Key));

            //if (char.IsDigit(NewKey))
            //{

            //}
            //else if (e.Key == Key.Return)
            //{
            //    Update_TimeSpan();
            //}
            //else
            //    e.Handled = true;
            if (e.Key == Key.Return)
            {
                Update_TimeSpan();
            }
        }
        private void txt_Hours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Days_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //char NewKey = (Char)KeyInterop.VirtualKeyFromKey(CommonValidations.getNumaricKey(e.Key));

            //if (char.IsDigit(NewKey))
            //{

            //}
            //else if (e.Key == Key.Return)
            //{
            //    Update_TimeSpan();
            //}
            //else
            //    e.Handled = true;
            if (e.Key == Key.Return)
            {
                Update_TimeSpan();
            }
        }
        private void txt_Days_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
      
        private void txt_minutes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //char NewKey = (Char)KeyInterop.VirtualKeyFromKey(CommonValidations.getNumaricKey(e.Key));

            //if (char.IsDigit(NewKey))
            //{

            //}
            //else if (e.Key == Key.Return)
            //{
            //    Update_TimeSpan();
            //}
            //else
            //    e.Handled = true;
            if (e.Key == Key.Return)
            {
                Update_TimeSpan();
            }
        }
        private void txt_minutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_Hours_LostFocus(object sender, RoutedEventArgs e)
        {
            Update_TimeSpan();
        }

        private void txt_Days_LostFocus(object sender, RoutedEventArgs e)
        {
            Update_TimeSpan();
        }

        private void txt_minutes_LostFocus(object sender, RoutedEventArgs e)
        {
            Update_TimeSpan();
        }


       

    }
}