using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Express.UI.Common.CustomValidators
{
    public sealed class TextValidator
    {
        public static bool IsSpecialChar(string inputValue)
        {
            bool isValid = false;
            if (Regex.IsMatch(inputValue, @"^[\sa-zA-Z0-9]*$"))
            {
                isValid = true;
            }
            else
            {
                isValid = false;                
            }
            return isValid;
        }
    }
}
