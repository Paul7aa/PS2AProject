using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS2AProject.Domain.ValidationRules
{
    public class OnlyNumbersValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = value as string;
            if (!stringValue.All(x => char.IsDigit(x)))
                return new ValidationResult(false, "Poate conține doar cifre!");

            return ValidationResult.ValidResult;
        }
    }
}
