using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;

namespace SEACC_WPFControls
{
    public class clsValidation
    {
        public static DateTime defaultDateTime = new DateTime(1800, 1, 1);
        public static string Format_Date = "yyyy/MM/dd";
        public static string Format_Time = "HH:mm";

        #region Combine Date and Time
        public static DateTime CombineDateAndTime(string sDate, string sTime)
        {
            DateTime rtnVal = defaultDateTime;
            try
            {
                rtnVal = DateTime.Parse(sDate + " " + sTime);
            }
            catch (Exception)
            {
                return rtnVal;
            }
            return rtnVal;
        }

        public static DateTime CombineDateAndTime(DateTime Date, DateTime Time)
        {
            DateTime rtnVal = defaultDateTime;
            try
            {
                rtnVal = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hour, Time.Minute, Time.Second);
            }
            catch (Exception)
            {
                return rtnVal;
            }
            return rtnVal;
        }
        #endregion

        public static string GetDisplayValue_Date(DateTime DateTime)
        {
            string result = "-";
            try
            {
                result = (DateTime == defaultDateTime) ? "-" : DateTime.ToString(Format_Date);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public static string GetDisplayValue_Time(DateTime DateTime)
        {
            string result = "-";
            try
            {
                result = (DateTime == defaultDateTime) ? "-" : DateTime.ToString(Format_Time);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public static string GetDisplayValue_Time(string dateTime)
        {
            string result = "-";
            try
            {
                DateTime dResult = (dateTime == "-") ? defaultDateTime : DateTime.Parse(dateTime);
                result = GetDisplayValue_Time(dResult);
            }
            catch (Exception) { }
            return result;
        }

        public static DateTime Validate_DateTime(string DateTimeInStr)
        {
            DateTime Value = defaultDateTime;
            try
            {
                Value = DateTime.Parse(DateTimeInStr);
            }
            catch (Exception)
            {
            }
            return Value;
        }

        public static DateTime Merge_DateAndTime(DateTime Date, DateTime Time)
        {
            DateTime Value = defaultDateTime;
            try
            {
                if (Date != defaultDateTime && Time != defaultDateTime)
                    Value = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hour, Time.Minute, Time.Second);
            }
            catch (Exception)
            {
            }
            return Value;
        }

        public static TimeSpan GetDateTimeSpan(int Minutes)
        {
            return TimeSpan.FromMinutes(Minutes);
        }

        public static String GetDisplayValue_Hours(int Minutes)
        {
            TimeSpan ts = TimeSpan.FromMinutes(Minutes);

            string value = "00:00";
            try
            {
                value = (ts.Hours < 0 || ts.Minutes < 0) ? "ERROR" : String.Format("{0:00}", ts.Hours + ts.Days * 24) + ":" + String.Format("{0:00}", ts.Minutes);
            }
            catch (Exception) { }
            return value;
        }

        public static String GetDisplayValue_Hours(TimeSpan ts)
        {
            string value = "00:00";
            try
            {
                value = (ts.Hours < 0 || ts.Minutes < 0) ? "ERROR" : String.Format("{0:00}", ts.Hours + ts.Days * 24) + ":" + String.Format("{0:00}", ts.Minutes);
            }
            catch (Exception) { }
            return value;
        }

        public static int GetMinutes(TimeSpan Tstemp2)
        {
            return Tstemp2.Minutes + Tstemp2.Hours * 60 + Tstemp2.Days * 24 * 60;
        }

        public static int GetMinutes(string sMinutes)
        {
            int ireturnvalue = 0;
            try
            {
                string[] words = sMinutes.Split(':');
                ireturnvalue = int.Parse(words[0]) * 60 + int.Parse(words[1]);
            }
            catch (Exception)
            {
            }
            return ireturnvalue;
        }

        public static TimeSpan SetTimeSpan(string sTime)
        {
            TimeSpan ts = new TimeSpan();
            try
            {
                string[] words = sTime.Split(':');
                int iMins = int.Parse(words[0]) * 60 + int.Parse(words[1]);
                ts = TimeSpan.FromMinutes(iMins);
            }
            catch (Exception)
            {
            }
            return ts;
        }

        #region Validate - numbers
        public static Decimal Validate_DecimalNumber(string decimalNumber)
        {
            decimal Value = 0;
            try
            {
                Value = decimal.Parse(decimalNumber);
            }
            catch (Exception)
            {
            }
            return Value;
        }

        public static bool isCurrency(string val)
        {
            Double result;
            return Double.TryParse(val, System.Globalization.NumberStyles.Currency,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public static bool isCurrency(SEACC_LableTextBox TextBox, ref string Messege)
        {
            bool result = isCurrency(TextBox.Text);
            if (!result)
                Messege += (Messege != "" ? "\n" : "") + TextBox.label;
            return result;
        }

        public static bool isInteger(string val)
        {
            Double result;
            return Double.TryParse(val, System.Globalization.NumberStyles.Integer,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public static bool isInteger(SEACC_LableTextBox TextBox, ref string Messege)
        {
            bool result = isInteger(TextBox.Text);
            if (!result)
                Messege += (Messege != "" ? "\n" : "") + TextBox.label;
            return result;
        }
        #endregion

        #region log
        public static void WriteErrorLog(string sError)
        {//need to verify
            string logFileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "ErrorLog.txt");
            try
            {
                File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError);
            }
            catch { }
        }
        public static void WriteErrorLog(string sError, int iformID)
        {
            string logFileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "ErrorLog.txt");
            try
            {
                File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError + " - " + iformID);
            }
            catch { }
        }
        #endregion

        #region Validate Empty Value
        public static bool Validate_SEACCTextBox_EmptyValue(SEACC_TextBox txtBox)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            txtBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("#FF41B1E1");
            txtBox.ErrorText = "";
            if (txtBox.Text == null || txtBox.Text.Trim().Length == 0)
            {
                bValue = false;
                txtBox.Focus();
                txtBox.TextBox_BorderBrush = Brushes.Red;

                txtBox.ErrorText = "";
            }

            return bValue;
        }

        public static bool Validate_SEACC_UserIndicator_Small_EmptyValue(SEACC_UserIndicator_Small UsrInd)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            UsrInd.Background = (Brush)bc.ConvertFrom("Transparent");
            UsrInd.ErrorText = "";
            if (UsrInd.User_ID == null || UsrInd.User_ID.Trim().Length == 0)
            {
                bValue = false;
                UsrInd.Focus();
                UsrInd.Background = Brushes.Red;

                UsrInd.ErrorText = "";
            }

            return bValue;
        }

        public static bool Validate_EmptyValue(SEACC_LableTextBox txtBox)
        {
            string sMessege = "";
            return Validate_EmptyValue(txtBox, ref sMessege);
        }

        public static bool Validate_EmptyValue(SEACC_LableTextBox txtBox, ref string Messege)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            txtBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("Red");
            txtBox.ErrorText = "";

            if (txtBox.Text == null || txtBox.Text.Trim().Length == 0)
            {
                bValue = false;
                txtBox.Focus();
                txtBox.BorderBrush = Brushes.Red;
                txtBox.ErrorText = "";

                Messege += (Messege != "" ? "\n" : "") + txtBox.label.Content;
            }
            return bValue;
        }

        public static bool Validate_EmptyValue(TextBlock textblock, ref string Messege, string FieldName)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;

            if (textblock.Text == null || textblock.Text.Trim().Length == 0)
            {
                bValue = false;
                textblock.Foreground = Brushes.Red;

                Messege += (Messege != "" ? "\n" : "") + FieldName;
            }
            return bValue;
        }

        public static bool Validate_EmptyValue(SEACC_LabelComboBox cmbBox)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            cmbBox.ComboBox_BorderBrush = (Brush)bc.ConvertFrom("#FFE3E9EF");
            cmbBox.ErrorText = "";

            if (cmbBox.GetSelectedIndex() < 0)
            {
                bValue = false;
                cmbBox.Focus();
                cmbBox.ComboBox_BorderBrush = Brushes.Red;
                cmbBox.ErrorText = "";
            }
            return bValue;
        }

        public static bool Validate_EmptyValue(PasswordBox txtBox)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            txtBox.BorderBrush = (Brush)bc.ConvertFrom("red");

            if (txtBox.Password == null || txtBox.Password.Trim().Length == 0)
            {
                bValue = false;
                txtBox.Focus();
                txtBox.BorderBrush = Brushes.Red;
            }
            return bValue;
        }

        public static bool Validate_EmptyValue(SEACC_LabelTimeSpan TimeSelector)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            TimeSelector.TextBox_BorderBrush = (Brush)bc.ConvertFrom("Red");

            if (TimeSelector.GetMinutes() == 0)
            {
                bValue = false;
                TimeSelector.Focus();
                TimeSelector.BorderBrush = Brushes.Red;
            }
            return bValue;
        }
        #endregion

        #region Validate Empty Tag
        public static bool Validate_EmptyTag(SEACC_LableTextBox txtBox)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            txtBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("Red");
            txtBox.ErrorText = "";

            if (txtBox.Tag == null)
            {
                bValue = false;
                txtBox.Focus();
                txtBox.BorderBrush = Brushes.Red;
                txtBox.ErrorText = "";
            }
            return bValue;
        }

        public static bool Validate_EmptyTag(SEACC_LableTextBox txtBox, ref string Messege)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;
            txtBox.TextBox_BorderBrush = (Brush)bc.ConvertFrom("Red");
            txtBox.ErrorText = "";

            if (txtBox.Tag == null || txtBox.Tag.ToString().Trim().Length == 0)
            {
                bValue = false;
                txtBox.Focus();
                txtBox.BorderBrush = Brushes.Red;
                txtBox.ErrorText = "";

                Messege += (Messege != "" ? "\n" : "") + txtBox.label.Content;
            }
            return bValue;
        }

        public static bool Validate_EmptyTag(TextBlock textblock, ref string Messege, string FieldName)
        {
            BrushConverter bc = new BrushConverter();
            bool bValue = true;

            if (textblock.Tag == null || textblock.Tag.ToString().Trim().Length == 0)
            {
                bValue = false;
                textblock.Foreground = Brushes.Red;

                Messege += (Messege != "" ? "\n" : "") + FieldName;
            }
            return bValue;
        }
        #endregion
    }
}