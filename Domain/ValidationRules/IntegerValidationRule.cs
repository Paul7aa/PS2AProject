using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PS2AProject.Domain.ValidationRules
{
    public class IntegerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool parseSuccessful = Int32.TryParse((string)value, out Int32 intValue);
            if (!parseSuccessful) 
                return new ValidationResult(false, "Acceptă doar valori numerice naturale!");
            if (intValue <= 0)
                return new ValidationResult(false, "Nu poate fi 0 sau mai mic!");
            if (intValue > this.MaxValue) 
                return new ValidationResult(false, "Nu poate fi mai mult de " + this.MaxValue.ToString() + " !");
            return ValidationResult.ValidResult;
        }
       
        public Int32 MaxValue { get; set; }
    }
}
