using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Express.UI.Common.CustomValidators
{
   public sealed class NumberValidator
    {
        private NumberValidator()
        {

        }

        /// <summary>
        /// check whether value can convert to decimal value
        /// int values are accepted
        /// </summary>
        /// <param name="val">string</param>
        /// <returns></returns>
        public  static bool TryPassDecimal(string val)
        {
            bool isValid = true;
            decimal number = 0;
            if (!Decimal.TryParse(val, out number))
            {
                isValid = false;
            }
            return isValid;
        }


        /// <summary>
        /// accept decimal value only
        /// not accept numbers
        /// </summary>
        /// <param name="_value">string</param>
        /// <returns></returns>
        public static bool IsOnlyDecimal(string _value)
        {
            return Regex.IsMatch(_value ,@"\d{1,12}\.\d\d");
        }


        /// <summary>
        /// check value can convert to integer
        /// </summary>
        /// <param name="val">string</param>
        /// <returns></returns>
        public  static bool TryPassInteger(string val)
        {
            bool isValid = true;
            int number = 0;
            if (!Int32.TryParse(val, out number))
            {
                isValid = false;
            }
            return isValid;
        }

        public static decimal RoundPrecision(decimal val)
        {
            return Math.Round(val, 3);
        }

    }
}
