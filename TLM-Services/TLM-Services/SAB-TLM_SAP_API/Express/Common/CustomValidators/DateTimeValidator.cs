using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.CustomValidators
{
    public sealed class DateTimeValidator
    {
        public static DateTime GetAppDateformat(DateTime _dt)
        {
            //"dd/MM/yyyy" DateTimeStyles.None
             //var a = _dt.ToString("M/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            var tempDateStr = _dt.ToString("MM/dd/yyyy" ,CultureInfo.InvariantCulture);
            return DateTime.ParseExact(tempDateStr, "MM/dd/yyyy", CultureInfo.InvariantCulture );
        }

        public static DateTime GetAppDateTimeFormat( DateTime _dt)
        {
            var tempDateStr = _dt.ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            return DateTime.ParseExact(tempDateStr, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public static DateTime GetAppDisplayFormat(DateTime _dt)
        {
            var tempDateStr = _dt.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
            return DateTime.ParseExact(tempDateStr, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
