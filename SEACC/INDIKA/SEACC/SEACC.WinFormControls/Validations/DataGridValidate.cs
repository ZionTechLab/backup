using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC.WinFormControls.Validations
{
    public sealed class DataGridValidate
    {
        public static string GetStringValue(DataGridViewCell value)
        {
            try
            {
                return value.Value.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static DateTime GetDateTimeValue(DataGridViewCell value)
        {
            try
            {
                return DateTime.Parse(value.Value.ToString());
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
        public static int GetIntValue(DataGridViewCell value)
        {
            try
            {
                return int.Parse(value.Value.ToString());
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static decimal GetDecimalValue(DataGridViewCell value)
        {
            try
            {
                return decimal.Parse(value.Value.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static bool GetBoolValue(DataGridViewCell value)
        {
            try
            {
                return bool.Parse(value.Value.ToString());
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
