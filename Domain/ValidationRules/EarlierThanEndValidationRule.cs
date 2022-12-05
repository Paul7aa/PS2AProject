using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PS2AProject.Domain.ValidationRules
{
    public class EalierThanEndValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            DateTime startDate = (DateTime)value;

            if (DateTime.Compare(startDate.Date, EndDate.EndDate.Date) > 0)
                return new ValidationResult(false, "Data de început nu este validă!");

            return ValidationResult.ValidResult;
        }

        public Wrapper2 EndDate { get; set; }
    }

    public class Wrapper2 : DependencyObject
    {
        public static readonly DependencyProperty EndDateProperty =
             DependencyProperty.Register("EndDate", typeof(DateTime),
             typeof(Wrapper2), new FrameworkPropertyMetadata(DateTime.Now));

        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }
    }
}
