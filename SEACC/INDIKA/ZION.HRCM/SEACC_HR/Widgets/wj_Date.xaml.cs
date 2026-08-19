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
using System.Data;
using DataTire;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for wj_Date.xaml
    /// </summary>
    public partial class wj_Date : UserControl
    {
        #region Class Variables
        static BrushConverter bc = new BrushConverter(); 
        #endregion

        public wj_Date()
        {
            InitializeComponent();
        }

        public void SetTime(DateTime date, string DayType)
        {
            txtDay.Text = date.DayOfWeek.ToString();
            txtMonth.Text = date.ToString("MMMM");
            txtDate.Text = date.ToString("dd");
            txtYear.Text = date.Year.ToString();
            txtDayType.Text = DayType;

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                Grd_Date.Background = (Brush)bc.ConvertFrom("#FFFF0000");
            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                Grd_Date.Background = (Brush)bc.ConvertFrom("#FFFF6800");
            }
            else
            {
                Grd_Date.Background = (Brush)bc.ConvertFrom("#FF007AFF");
            }
            if (DayType != "Working Day")
            {
                string script = "SELECT c.holiday_ID, c.holiday_Date, t.holydayType_Name, c.holiday_Description, c.holiday_Hours FROM  tbl_tasHolidayCalander AS c LEFT OUTER JOIN tbl_tasHolidayType AS t ON c.holydayType_ID = t.holydayType_ID WHERE (c.holiday_Date = '" + date.Date + "') AND (c.isCanceled = 0)";
                DataTable dt = DBHandling.ExecQuery(script).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtDayType.Text = dt.Rows[0]["holydayType_Name"].ToString();
                    Grd_Date.Background = (Brush)bc.ConvertFrom("#FFFF0000");
                }
            }

        
        }
    }
}
