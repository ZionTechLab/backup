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
        private TextValidator()
        {

        }
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

        public static string RemoveSpecialCharacters(string value)
        {            // return new String(value.Except(specialCharacters.c).ToArray());
            return Regex.Replace(value, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        public static string FixSpecialCharacters(string _value)
        {
            if (!TextValidator.IsSpecialChar(_value))
            {
                return TextValidator.RemoveSpecialCharacters(_value);
            }

            return _value;
        }

        public static bool IsAlphanumeric(string _value)
        {
            return Regex.IsMatch(_value ,@"^[a-zA-Z0-9]*$");
           //if( _value.All(x=>char.IsLetterOrDigit(x)))
           // {
           //     return false;
           // }
           //else
           // {
           //     return true;
           // }
        }
    }
}
