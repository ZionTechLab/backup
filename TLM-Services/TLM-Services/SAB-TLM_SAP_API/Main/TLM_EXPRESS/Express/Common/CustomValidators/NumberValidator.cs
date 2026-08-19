using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.CustomValidators
{
   public sealed class NumberValidator
    {
        private NumberValidator()
        {

        }
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
