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
using DataTire;
using SEACC_WPFControls;
using Digiteq_Logic;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_Calander.xaml
    /// </summary>
    public partial class UC_Calander : UserControl
    {
        public event EventHandler Date_MouseClick;
        public event EventHandler MonthSelected;

        #region Class Varibles
        public DateTime dtm_FirstdayOfMonth;
        public List<clsHolydays> lstHolydays = new List<clsHolydays>();
        #endregion

        #region Form Load
        public UC_Calander()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Responsiveness
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.Width <= 220)
            {
                txt_R0C1.Text = "S";
                txt_R0C2.Text = "M";
                txt_R0C3.Text = "T";
                txt_R0C4.Text = "W";
                txt_R0C5.Text = "T";
                txt_R0C6.Text = "F";
                txt_R0C7.Text = "S";
            }
            else// if (this.Width <= 220)
            {
                txt_R0C1.Text = "Sun";
                txt_R0C2.Text = "Mon";
                txt_R0C3.Text = "Tue";
                txt_R0C4.Text = "Wed";
                txt_R0C5.Text = "Thu";
                txt_R0C6.Text = "Fri";
                txt_R0C7.Text = "Sat";
            }
        }
        #endregion

        public void SetMonth(DateTime dt)
        {
            SetMonth(dt, false);
        }

        public void SetMonth(DateTime dt, bool bEmpBithdayDescripts)
        {
            dtm_FirstdayOfMonth = new DateTime(dt.Year, dt.Month, 1);
            int iFirstDayofMonth = (int)dtm_FirstdayOfMonth.DayOfWeek;
            int i = 0 - iFirstDayofMonth;
            int Month = dtm_FirstdayOfMonth.Month;

            lbl_Month.Text = dtm_FirstdayOfMonth.ToString("MMMM") + " | " + dtm_FirstdayOfMonth.Year;

            int iWeekNo = (dtm_FirstdayOfMonth.DayOfYear / 7) + 1;

            txt_WK1.Text = iWeekNo.ToString();
            txt_WK2.Text = (iWeekNo + 1).ToString();
            txt_WK3.Text = (iWeekNo + 2).ToString();
            txt_WK4.Text = (iWeekNo + 3).ToString();
            txt_WK5.Text = (iWeekNo + 4).ToString();
            txt_WK6.Text = (iWeekNo + 5).ToString();

            dt1.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt2.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt3.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt4.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt5.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt6.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt7.set(dtm_FirstdayOfMonth.AddDays(i++), Month);

            dt8.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt9.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt10.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt11.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt12.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt13.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt14.set(dtm_FirstdayOfMonth.AddDays(i++), Month);

            dt15.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt16.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt17.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt18.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt19.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt20.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt21.set(dtm_FirstdayOfMonth.AddDays(i++), Month);

            dt22.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt23.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt24.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt25.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt26.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt27.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt28.set(dtm_FirstdayOfMonth.AddDays(i++), Month);

            dt29.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt30.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt31.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt32.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt33.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt34.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt35.set(dtm_FirstdayOfMonth.AddDays(i++), Month);

            dt36.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt37.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt38.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt39.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt40.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt41.set(dtm_FirstdayOfMonth.AddDays(i++), Month);
            dt42.set(dtm_FirstdayOfMonth.AddDays(i++), Month);

            #region Set Holidays
            foreach (tbl_tasHolidayCalander day in tbl_tasHolidayCalander.SelectAll().Where(p => p.Holiday_Date.Date >= dtm_FirstdayOfMonth && p.Holiday_Date.Date <= dtm_FirstdayOfMonth.AddMonths(1).AddDays(-1) && p.Holiday_Status && p.IsCanceled == false))
            {
                int iq = iFirstDayofMonth + day.Holiday_Date.Day;
                if (iq == 1)
                    dt1.setHolyday(day.HolydayType_ID);

                if (iq == 2)
                    dt2.setHolyday(day.HolydayType_ID);

                if (iq == 3)
                    dt3.setHolyday(day.HolydayType_ID);

                if (iq == 4)
                    dt4.setHolyday(day.HolydayType_ID);

                if (iq == 5)
                    dt5.setHolyday(day.HolydayType_ID);

                if (iq == 6)
                    dt6.setHolyday(day.HolydayType_ID);

                if (iq == 7)
                    dt7.setHolyday(day.HolydayType_ID);

                if (iq == 8)
                    dt8.setHolyday(day.HolydayType_ID);

                if (iq == 9)
                    dt9.setHolyday(day.HolydayType_ID);

                if (iq == 10)
                    dt10.setHolyday(day.HolydayType_ID);

                if (iq == 11)
                    dt11.setHolyday(day.HolydayType_ID);

                if (iq == 12)
                    dt12.setHolyday(day.HolydayType_ID);

                if (iq == 13)
                    dt13.setHolyday(day.HolydayType_ID);

                if (iq == 14)
                    dt14.setHolyday(day.HolydayType_ID);

                if (iq == 15)
                    dt15.setHolyday(day.HolydayType_ID);

                if (iq == 16)
                    dt16.setHolyday(day.HolydayType_ID);

                if (iq == 17)
                    dt17.setHolyday(day.HolydayType_ID);

                if (iq == 18)
                    dt18.setHolyday(day.HolydayType_ID);

                if (iq == 19)
                    dt19.setHolyday(day.HolydayType_ID);

                if (iq == 20)
                    dt20.setHolyday(day.HolydayType_ID);

                if (iq == 21)
                    dt21.setHolyday(day.HolydayType_ID);

                if (iq == 22)
                    dt22.setHolyday(day.HolydayType_ID);

                if (iq == 23)
                    dt23.setHolyday(day.HolydayType_ID);

                if (iq == 24)
                    dt24.setHolyday(day.HolydayType_ID);

                if (iq == 25)
                    dt25.setHolyday(day.HolydayType_ID);

                if (iq == 26)
                    dt26.setHolyday(day.HolydayType_ID);

                if (iq == 27)
                    dt27.setHolyday(day.HolydayType_ID);

                if (iq == 28)
                    dt28.setHolyday(day.HolydayType_ID);

                if (iq == 29)
                    dt29.setHolyday(day.HolydayType_ID);

                if (iq == 30)
                    dt30.setHolyday(day.HolydayType_ID);

                if (iq == 31)
                    dt31.setHolyday(day.HolydayType_ID);

                if (iq == 32)
                    dt32.setHolyday(day.HolydayType_ID);

                if (iq == 33)
                    dt33.setHolyday(day.HolydayType_ID);

                if (iq == 34)
                    dt34.setHolyday(day.HolydayType_ID);

                if (iq == 35)
                    dt35.setHolyday(day.HolydayType_ID);

                if (iq == 36)
                    dt36.setHolyday(day.HolydayType_ID);

                if (iq == 37)
                    dt37.setHolyday(day.HolydayType_ID);

                if (iq == 38)
                    dt38.setHolyday(day.HolydayType_ID);

                if (iq == 39)
                    dt39.setHolyday(day.HolydayType_ID);

                if (iq == 40)
                    dt40.setHolyday(day.HolydayType_ID);

                if (iq == 41)
                    dt41.setHolyday(day.HolydayType_ID);

                if (iq == 42)
                    dt42.setHolyday(day.HolydayType_ID);
            }
            #endregion

            //#region Set Birthdays

            if (bEmpBithdayDescripts)
            {
                List<tbl_genMasEmployee> oEmployees = tbl_genMasEmployee.SelectAll().Where(r => r.DateOfBirth.Date != clsValidation.defaultDateTime.Date &&
                                                                                                r.Emp_statusID != ((int)(EmployeeStatus.Resigned)).ToString() &&
                                                                                                !r.IsCanceled).ToList();

                for (DateTime dtm = dtm_FirstdayOfMonth.Date; dtm.Date < dtm_FirstdayOfMonth.AddMonths(1).Date; dtm = dtm.AddDays(1))
                {
                    int iq = iFirstDayofMonth + dtm.Day;
                    int iBirthdayCount = oEmployees.Where(r => r.DateOfBirth.Month == dtm.Month && r.DateOfBirth.Day == dtm.Day).Count();

                    string sBithdayDescript = " ";
                    if (iBirthdayCount == 1)
                        sBithdayDescript = "1 Birthday";
                    else if (iBirthdayCount > 1)
                        sBithdayDescript = iBirthdayCount + " Birthdays";

                    if (iq == 1)
                        dt1.SetDayDescription(sBithdayDescript);

                    if (iq == 2)
                        dt2.SetDayDescription(sBithdayDescript);

                    if (iq == 3)
                        dt3.SetDayDescription(sBithdayDescript);

                    if (iq == 4)
                        dt4.SetDayDescription(sBithdayDescript);

                    if (iq == 5)
                        dt5.SetDayDescription(sBithdayDescript);

                    if (iq == 6)
                        dt6.SetDayDescription(sBithdayDescript);

                    if (iq == 7)
                        dt7.SetDayDescription(sBithdayDescript);

                    if (iq == 8)
                        dt8.SetDayDescription(sBithdayDescript);

                    if (iq == 9)
                        dt9.SetDayDescription(sBithdayDescript);

                    if (iq == 10)
                        dt10.SetDayDescription(sBithdayDescript);

                    if (iq == 11)
                        dt11.SetDayDescription(sBithdayDescript);

                    if (iq == 12)
                        dt12.SetDayDescription(sBithdayDescript);

                    if (iq == 13)
                        dt13.SetDayDescription(sBithdayDescript);

                    if (iq == 14)
                        dt14.SetDayDescription(sBithdayDescript);

                    if (iq == 15)
                        dt15.SetDayDescription(sBithdayDescript);

                    if (iq == 16)
                        dt16.SetDayDescription(sBithdayDescript);

                    if (iq == 17)
                        dt17.SetDayDescription(sBithdayDescript);

                    if (iq == 18)
                        dt18.SetDayDescription(sBithdayDescript);

                    if (iq == 19)
                        dt19.SetDayDescription(sBithdayDescript);

                    if (iq == 20)
                        dt20.SetDayDescription(sBithdayDescript);

                    if (iq == 21)
                        dt21.SetDayDescription(sBithdayDescript);

                    if (iq == 22)
                        dt22.SetDayDescription(sBithdayDescript);

                    if (iq == 23)
                        dt23.SetDayDescription(sBithdayDescript);

                    if (iq == 24)
                        dt24.SetDayDescription(sBithdayDescript);

                    if (iq == 25)
                        dt25.SetDayDescription(sBithdayDescript);

                    if (iq == 26)
                        dt26.SetDayDescription(sBithdayDescript);

                    if (iq == 27)
                        dt27.SetDayDescription(sBithdayDescript);

                    if (iq == 28)
                        dt28.SetDayDescription(sBithdayDescript);

                    if (iq == 29)
                        dt29.SetDayDescription(sBithdayDescript);

                    if (iq == 30)
                        dt30.SetDayDescription(sBithdayDescript);

                    if (iq == 31)
                        dt31.SetDayDescription(sBithdayDescript);

                    if (iq == 32)
                        dt32.SetDayDescription(sBithdayDescript);

                    if (iq == 33)
                        dt33.SetDayDescription(sBithdayDescript);

                    if (iq == 34)
                        dt34.SetDayDescription(sBithdayDescript);

                    if (iq == 35)
                        dt35.SetDayDescription(sBithdayDescript);

                    if (iq == 36)
                        dt36.SetDayDescription(sBithdayDescript);

                    if (iq == 37)
                        dt37.SetDayDescription(sBithdayDescript);

                    if (iq == 38)
                        dt38.SetDayDescription(sBithdayDescript);

                    if (iq == 39)
                        dt39.SetDayDescription(sBithdayDescript);

                    if (iq == 40)
                        dt40.SetDayDescription(sBithdayDescript);

                    if (iq == 41)
                        dt41.SetDayDescription(sBithdayDescript);

                    if (iq == 42)
                        dt42.SetDayDescription(sBithdayDescript);
                }
            }

            //#endregion
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MonthSelected(sender, EventArgs.Empty);
            }
            catch (Exception)
            {
            }
        }

        private void DateMouseClick(object sender, EventArgs e)
        {
            try
            {
                Date_MouseClick(sender, e);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

    }

    public class clsHolydays
    {
        public int iHolyDayCode;
        public DateTime dtHolydayDate;
        public clsHolydays(int HodydayCode, DateTime date)
        {
            iHolyDayCode = HodydayCode;
            dtHolydayDate = date;
        }
    }
}