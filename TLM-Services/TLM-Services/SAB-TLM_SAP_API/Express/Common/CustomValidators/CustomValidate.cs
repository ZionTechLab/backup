using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.CustomValidators
{
   public sealed class CustomValidate
    {      
        private static volatile CustomValidate instance;
        private static object syncRoot = new Object();
        private Dictionary<string, ICollection<string>>
                   _validationErrors = new Dictionary<string, ICollection<string>>();

        /// <summary>
        /// avoid initiate via new keyword
        /// </summary>
        private CustomValidate()
        {

        }
        public static CustomValidate Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CustomValidate();
                    }
                }

                return instance;
            }
        }      


        #region numeric field validate

        /// <summary>
        /// check value is numeric or not , if value is numeric return true , other wise false
        /// </summary>
        /// <param name="val">string</param>
        /// <returns>bool</returns>
        public  bool TryPassDecimal(string val)
        {
            bool isValid = true;
            decimal number = 0;
            if (!Decimal.TryParse(val, out number))
            {
                isValid = false;
            }
            return isValid;
        }

        #endregion

        #region data model validation
        public string  ValidateModel(object cntext)
        {            
            _validationErrors.Clear();
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext validationContext = new ValidationContext(cntext, null, null);

            if (!Validator.TryValidateObject(cntext, validationContext, validationResults, true))
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    string property = validationResult.MemberNames.ElementAt(0);
                    if (_validationErrors.ContainsKey(property))
                    {
                        _validationErrors[property].Add(validationResult.ErrorMessage);
                    }
                    else
                    {
                        _validationErrors.Add(property, new List<string> { validationResult.ErrorMessage });
                    }                  

                }
            }

            return ValidationMessage();
        }

        private  string ValidationMessage()
        {
            //string strError = "";
            System.Text.StringBuilder strError = new System.Text.StringBuilder();
            foreach (var errList in _validationErrors)
            {
                //strError = strError + "\n" + errList.Value.ElementAt(0);
                strError.Append(errList.Value.ElementAt(0)).AppendLine();
            }

            // return strError;

            return strError.ToString();
        }
        #endregion
    }
}
