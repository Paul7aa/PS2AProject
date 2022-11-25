using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS2AProject.Domain.ValidationRules
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = value as string;
            if (String.IsNullOrEmpty(stringValue))
                return new ValidationResult(false, "Nu poate fi gol!");
            return ValidationResult.ValidResult;
        }
    }
}
