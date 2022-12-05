using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PS2AProject.Domain.ValidationRules
{
    public class FixedLengthValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = value as string;
            if (stringValue.Length != FixedLength)
                return new ValidationResult(false, "Trebuie sa conțină exact " + FixedLength + " caractere!");

            return ValidationResult.ValidResult;
        }

        public Int32 FixedLength { get; set; }
    }
}
