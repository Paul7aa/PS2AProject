using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS2AProject.Domain.ValidationRules
{
    public class DoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool parseSuccessful = Double.TryParse((string)value, out Double doubleValue);
            if (!parseSuccessful)
                return new ValidationResult(false, "Acceptă doar valori numerice!");
            if (doubleValue <= 0)
                return new ValidationResult(false, "Nu poate fi 0 sau mai mic!");
            if (doubleValue.ToString().Split(".").Length > 1)
                if (doubleValue.ToString().Split(".")[1].Length > 2)
                    return new ValidationResult(false, "Nu poate avea mai mult de 2 cifre după virgulă!");
            return ValidationResult.ValidResult;
        }
    }
}
