using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS2AProject.Domain.ValidationRules
{
    public class RomanianPhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = value as string;
            if (!stringValue.StartsWith("07"))
                return new ValidationResult(false, "Nu este număr valid");

            return ValidationResult.ValidResult;
        }
    }
}
