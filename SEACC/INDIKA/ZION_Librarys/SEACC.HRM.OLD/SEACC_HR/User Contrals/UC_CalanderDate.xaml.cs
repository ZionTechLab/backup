using Digiteq_Logic;
using SEACC_WPFControls;
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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_CalanderDate.xaml
    /// </summary>
    public partial class UC_CalanderDate : UserControl
    {
        public event EventHandler Date_MouseClick;

        #region Class Variables
        BrushConverter bc = new BrushConverter();
        public DateTime Date;
        #endregion

        public UC_CalanderDate()
        {
            InitializeComponent();
        }

        public void set(DateTime dt, int month)
        {
            Date = dt;
            this.Background = (Brush)bc.ConvertFrom("transparent");
            this.Margin = new Thickness(1, 1, 1, 1);
            if (month != dt.Month)
                txt_Day.Foreground = (Brush)bc.ConvertFrom("#828282");
            else
            {
                if (Date.DayOfWeek == DayOfWeek.Sunday)
                    txt_Day.Foreground = (Brush)bc.ConvertFrom("#FFFF7D7D");
                else if (Date.DayOfWeek == DayOfWeek.Saturday)
                    txt_Day.Foreground = (Brush)bc.ConvertFrom("#FFFFB7B7");
                else
                    txt_Day.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
            }
            txt_Day.Text = dt.Day.ToString();

            holyday_poya.BorderBrush = (Brush)bc.ConvertFrom("Transparent");
            holyday_Company.Background = (Brush)bc.ConvertFrom("Transparent");
            holyday_Public.BorderBrush = (Brush)bc.ConvertFrom("Transparent");
            holyday_Bank.Background = (Brush)bc.ConvertFrom("Transparent");
        }

        public void setHolyday(string sHolidayType)
        {
            //if (sHolidayType == "HDT/001")
            //    holyday_poya.BorderBrush = (Brush)bc.ConvertFrom("Yellow");
            //else if (sHolidayType == "HDT/004")
            //    holyday_Company.Background = (Brush)bc.ConvertFrom("green");
            //else if (sHolidayType == "HDT/002" || sHolidayType == "HDT/003")
            //    holyday_Public.BorderBrush = (Brush)bc.ConvertFrom("red");
            //else if (sHolidayType == "HDT/006")
            //    holyday_Bank.Background = (Brush)bc.ConvertFrom("#7F003AFF");   

            if (sHolidayType == clsConfig.sPoyaDay)
                holyday_poya.BorderBrush = (Brush)bc.ConvertFrom("Yellow");
            else if (sHolidayType == clsConfig.sCompany)
                holyday_Company.Background = (Brush)bc.ConvertFrom("green");
            else if (sHolidayType == clsConfig.sPublic || sHolidayType == clsConfig.sMercantile)
                holyday_Public.BorderBrush = (Brush)bc.ConvertFrom("red");
            else if (sHolidayType == clsConfig.sBank)
                holyday_Bank.Background = (Brush)bc.ConvertFrom("#7F003AFF");
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Date_MouseClick(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        public void SetDayDescription(string sDescript)
        {
            if (sDescript.Length > 0)
            {
                rd_Descript.Height = new GridLength(30);
                txt_Day_Descript.Text = sDescript;
            }
        }

        public string GetDayDescription(string sDescript)
        {
            return txt_Day_Descript.Text;
        }
    }
}
