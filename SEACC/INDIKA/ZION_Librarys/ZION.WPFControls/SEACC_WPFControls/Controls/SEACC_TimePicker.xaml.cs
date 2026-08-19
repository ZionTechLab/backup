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
    public partial class SEACC_TimePicker : UserControl
    {
        public event EventHandler DateTimeChanged;
        DateTime DtmCurentdateTime = DateTime.Now;
        List<string> dates;
        List<string> months;
        List<string> years;
        List<string> hours;
        List<string> mins;
        BrushConverter bc = new BrushConverter();

        public SEACC_TimePicker()
        {
            InitializeComponent();
            //BackgroudColor = (Brush)bc.ConvertFrom("#FF727272");
            //FontColor = (Brush)bc.ConvertFrom("#FFFFFFFF");
            //SeperatorColor = (Brush)bc.ConvertFrom("#FF33B9EB");

            #region Dates
            dates = new List<string>();
            dates.Add("01");
            dates.Add("02");
            dates.Add("03");
            dates.Add("04");
            dates.Add("05");
            dates.Add("06");
            dates.Add("07");
            dates.Add("08");
            dates.Add("09");
            dates.Add("10");
            dates.Add("11");
            dates.Add("12");
            dates.Add("13");
            dates.Add("14");
            dates.Add("15");
            dates.Add("16");
            dates.Add("17");
            dates.Add("18");
            dates.Add("19");
            dates.Add("20");
            dates.Add("21");
            dates.Add("22");
            dates.Add("23");
            dates.Add("24");
            dates.Add("25");
            dates.Add("26");
            dates.Add("27");
            dates.Add("28");
            dates.Add("29");
            dates.Add("30");
            dates.Add("31");
            #endregion

            #region Months
            months = new List<string>();
            months.Add("01");
            months.Add("02");
            months.Add("03");
            months.Add("04");
            months.Add("05");
            months.Add("06");
            months.Add("07");
            months.Add("08");
            months.Add("09");
            months.Add("10");
            months.Add("11");
            months.Add("12");
            #endregion

            #region Years
            years = new List<string>();
            years.Add("2005");
            years.Add("2006");
            years.Add("2007");
            years.Add("2008");
            years.Add("2009");
            years.Add("2010");
            years.Add("2011");
            years.Add("2012");
            years.Add("2013");
            years.Add("2014");
            years.Add("2015");
            years.Add("2016");
            years.Add("2017");
            years.Add("2018");
            years.Add("2019");
            years.Add("2020");
            years.Add("2021");
            years.Add("2022");
            years.Add("2023");
            years.Add("2024");
            years.Add("2025");
            years.Add("2026");
            years.Add("2027");
            years.Add("2028");
            #endregion

            #region Hours
            hours = new List<string>();
            hours.Add("00");
            hours.Add("01");
            hours.Add("02");
            hours.Add("03");
            hours.Add("04");
            hours.Add("05");
            hours.Add("06");
            hours.Add("07");
            hours.Add("08");
            hours.Add("09");
            hours.Add("10");
            hours.Add("11");
            hours.Add("12");
            hours.Add("13");
            hours.Add("14");
            hours.Add("15");
            hours.Add("16");
            hours.Add("17");
            hours.Add("18");
            hours.Add("19");
            hours.Add("20");
            hours.Add("21");
            hours.Add("22");
            hours.Add("23");
            #endregion

            #region Mins
            mins = new List<string>();
            mins.Add("00");
            mins.Add("01");
            mins.Add("02");
            mins.Add("03");
            mins.Add("04");
            mins.Add("05");
            mins.Add("06");
            mins.Add("07");
            mins.Add("08");
            mins.Add("09");
            mins.Add("10");
            mins.Add("11");
            mins.Add("12");
            mins.Add("13");
            mins.Add("14");
            mins.Add("15");
            mins.Add("16");
            mins.Add("17");
            mins.Add("18");
            mins.Add("19");
            mins.Add("20");
            mins.Add("21");
            mins.Add("22");
            mins.Add("23");
            mins.Add("24");
            mins.Add("25");
            mins.Add("26");
            mins.Add("27");
            mins.Add("28");
            mins.Add("29");
            mins.Add("30");
            mins.Add("31");
            mins.Add("32");
            mins.Add("33");
            mins.Add("34");
            mins.Add("35");
            mins.Add("36");
            mins.Add("37");
            mins.Add("38");
            mins.Add("39");
            mins.Add("40");
            mins.Add("41");
            mins.Add("42");
            mins.Add("43");
            mins.Add("44");
            mins.Add("45");
            mins.Add("46");
            mins.Add("47");
            mins.Add("48");
            mins.Add("49");
            mins.Add("50");
            mins.Add("51");
            mins.Add("52");
            mins.Add("53");
            mins.Add("54");
            mins.Add("55");
            mins.Add("56");
            mins.Add("57");
            mins.Add("58");
            mins.Add("59");
            #endregion

            lb_dates.ItemsSource = dates;
            lb_months.ItemsSource = months;
            lb_years.ItemsSource = years;
            lb_hours.ItemsSource = hours;
            lb_mins.ItemsSource = mins;

            PopUpWidth = 186;

            Update();

            lb_dates.SelectedItem = tbDay.Text;
            lb_months.SelectedItem = tbMonth.Text;
            lb_years.SelectedItem = tbYear.Text;
            lb_hours.SelectedItem = tb_Hours.Text;
            lb_mins.SelectedItem = tb_Miniths.Text;
        }

        private void Update()
        {
            tbYear.Text = DtmCurentdateTime.ToString("yyyy");
            tbMonth.Text = DtmCurentdateTime.ToString("MM");
            tbDay.Text = DtmCurentdateTime.ToString("dd");
            tb_Hours.Text = DtmCurentdateTime.ToString("HH");
            tb_Miniths.Text = DtmCurentdateTime.ToString("mm");

            txtDate.Text = DtmCurentdateTime.ToString("yyyy/MM/dd");
            txt1.Text = DtmCurentdateTime.ToString("HH:mm");
        }

        public void SetTime(DateTime time)
        {
            DtmCurentdateTime = time;
            Update();
        }

        public DateTime GetDateTime()
        {
            return DtmCurentdateTime;
        }

        private void ClickDate(bool isLeftClick)
        {
            bool bStatus = isClickToExpand;

            if (!isLeftClick)
                bStatus = !isClickToExpand;

            if (!bStatus)
            {
                pop_lists.IsOpen = false;
                txtDate.Text = DtmCurentdateTime.ToString("yyyy/MM/dd");
                txtDate.Visibility = Visibility.Visible;
                txtDate.Focus();
                txtDate.SelectAll();
            }
            else
            {
                pop_lists.IsOpen = true;
                lb_years.Focusable = true;
                Keyboard.Focus(lb_years);
                lb_dates.ScrollIntoView(lb_dates.SelectedItem);
                lb_months.ScrollIntoView(lb_months.SelectedItem);
                lb_years.ScrollIntoView(lb_years.SelectedItem);
                lb_hours.ScrollIntoView(lb_hours.SelectedItem);
                lb_mins.ScrollIntoView(lb_mins.SelectedItem);
            }
        }

        private void ClickTime(bool isLeftClick)
        {
            bool bStatus = isClickToExpand;

            if (!isLeftClick)
                bStatus = !isClickToExpand;

            if (!bStatus)
            {
                txt1.Text = DtmCurentdateTime.ToString("HH:mm");
                txt1.Visibility = Visibility.Visible;
                txt1.Focus();
                txt1.SelectAll();
            }
            else
            {
                pop_lists.IsOpen = true;
                lb_hours.Focusable = true;
                Keyboard.Focus(lb_hours);
                lb_dates.ScrollIntoView(lb_dates.SelectedItem);
                lb_months.ScrollIntoView(lb_months.SelectedItem);
                lb_years.ScrollIntoView(lb_years.SelectedItem);
                lb_hours.ScrollIntoView(lb_hours.SelectedItem);
                lb_mins.ScrollIntoView(lb_mins.SelectedItem);
            }
        }

        private void grdDate_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClickDate(true);
        }

        private void grdTime_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClickTime(true);
        }

        private void grdDate_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClickDate(false);
        }

        private void grdTime_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClickTime(false);
        }

        private void txt1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txt1_LostFocus(null, null);

            else if (e.Key == Key.Escape)
            {
                txt1.Text = DtmCurentdateTime.ToString("HH:mm");
                txt1_LostFocus(null, null);
            }
        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtDate_LostFocus(null, null);

            else if (e.Key == Key.Escape)
            {
                txtDate.Text = DtmCurentdateTime.ToString("yyyy/MM/dd");
                txtDate_LostFocus(null, null);
            }
        }

        private void txt1_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDate_LostFocus(sender, e);
        }

        private void txtDate_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dtmDate = DateTime.Parse(txtDate.Text);
                DateTime dtmTime = DateTime.Parse(txt1.Text.Replace('.', ':'));
                DtmCurentdateTime = new DateTime(dtmDate.Year, dtmDate.Month, dtmDate.Day, dtmTime.Hour, dtmTime.Minute, dtmTime.Second);
                Update();
            }
            catch (Exception)
            {
                txtDate.Text = DtmCurentdateTime.ToString("yyyy/MM/dd");
                txt1.Text = DtmCurentdateTime.ToString("HH:mm");
                SEACCMessageBox.Show("Invalid Time Format..!", "", MessageBoxButton.OK);
            }
            txtDate.Visibility = Visibility.Hidden;
            txt1.Visibility = Visibility.Hidden;

            try
            {
                DateTimeChanged(sender, EventArgs.Empty);
            }
            catch (Exception)
            {
            }
        }

        #region Custom Properties
        public bool isClickToExpand = false;

        public static DependencyProperty BackgroudColor_Property = DependencyProperty.Register("BackgroudColor", typeof(Brush), typeof(SEACC_TimePicker));
        public Brush BackgroudColor
        {
            get
            {
                return (Brush)GetValue(BackgroudColor_Property);
            }
            set
            {
                SetValue(BackgroudColor_Property, value);
            }
        }

        public static DependencyProperty FontColor_Property = DependencyProperty.Register("FontColor", typeof(Brush), typeof(SEACC_TimePicker));
        public Brush FontColor
        {
            get
            {
                return (Brush)GetValue(FontColor_Property);
            }
            set
            {
                SetValue(FontColor_Property, value);
            }
        }

        public static DependencyProperty SeperatorColor_Property = DependencyProperty.Register("SeperatorColor", typeof(Brush), typeof(SEACC_TimePicker));
        public Brush SeperatorColor
        {
            get
            {
                return (Brush)GetValue(SeperatorColor_Property);
            }
            set
            {
                SetValue(SeperatorColor_Property, value);
            }
        }

        public static DependencyProperty SEACC_ShowDateProperty = DependencyProperty.Register("ShowDate", typeof(Visibility), typeof(SEACC_TimePicker));
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

        public static DependencyProperty SEACC_ShowTimeProperty = DependencyProperty.Register("ShowTime", typeof(Visibility), typeof(SEACC_TimePicker));
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

        public static DependencyProperty SEACC_PopUpWidthProperty = DependencyProperty.Register("PopUpWidth", typeof(double), typeof(SEACC_TimePicker));
        public double PopUpWidth
        {
            get
            {
                return (double)GetValue(SEACC_PopUpWidthProperty);
            }
            set
            {
                SetValue(SEACC_PopUpWidthProperty, value);
            }
        }

       

        #endregion

        #region pop list events
        private void lb_years_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbYear.Text = lb_years.SelectedItem.ToString();
            DtmCurentdateTime = new DateTime(int.Parse(tbYear.Text), int.Parse(tbMonth.Text), int.Parse(tbDay.Text), int.Parse(tb_Hours.Text), int.Parse(tb_Miniths.Text), 00);
            
        }
        private void lb_months_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tbMonth.Text = lb_months.SelectedItem.ToString();
                DtmCurentdateTime = new DateTime(int.Parse(tbYear.Text), int.Parse(tbMonth.Text), int.Parse(tbDay.Text), int.Parse(tb_Hours.Text), int.Parse(tb_Miniths.Text), 00);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        private void lb_dates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tbDay.Text = lb_dates.SelectedItem.ToString();
                DtmCurentdateTime = new DateTime(int.Parse(tbYear.Text), int.Parse(tbMonth.Text), int.Parse(tbDay.Text), int.Parse(tb_Hours.Text), int.Parse(tb_Miniths.Text), 00);
            }
            catch (Exception ex)
            {
                DtmCurentdateTime = new DateTime(int.Parse(tbYear.Text), int.Parse(tbMonth.Text), 01, int.Parse(tb_Hours.Text), int.Parse(tb_Miniths.Text), 00);
                tbDay.Text = "01";
                SEACCExeption.Show(ex);
            }
        }
        private void lb_hours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_Hours.Text = lb_hours.SelectedItem.ToString();
            DtmCurentdateTime = new DateTime(int.Parse(tbYear.Text), int.Parse(tbMonth.Text), int.Parse(tbDay.Text), int.Parse(tb_Hours.Text), int.Parse(tb_Miniths.Text), 00);
        }
        private void lb_mins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_Miniths.Text = lb_mins.SelectedItem.ToString();
            DtmCurentdateTime = new DateTime(int.Parse(tbYear.Text), int.Parse(tbMonth.Text), int.Parse(tbDay.Text), int.Parse(tb_Hours.Text), int.Parse(tb_Miniths.Text), 00);
        }
        private void pop_lists_Closed(object sender, EventArgs e)
        {
            DateTimeChanged(sender, EventArgs.Empty);
        }
        #endregion

        private void grd_List_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                pop_lists.IsOpen = false;
        }

        private void userControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //pop_lists.IsOpen = true;
            //lb_years.Focusable = true;
            //Keyboard.Focus(lb_years);
            //lb_dates.ScrollIntoView(lb_dates.SelectedItem);
            //lb_months.ScrollIntoView(lb_months.SelectedItem);
            //lb_years.ScrollIntoView(lb_years.SelectedItem);
            //lb_hours.ScrollIntoView(lb_hours.SelectedItem);
            //lb_mins.ScrollIntoView(lb_mins.SelectedItem);
        }

    }
}