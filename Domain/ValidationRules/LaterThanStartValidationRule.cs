using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PS2AProject.Domain.ValidationRules
{
    public class LaterThanStartValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            DateTime endDate = (DateTime)value;

            if (DateTime.Compare(endDate.Date, StartDate.StartDate.Date) < 0)
                return new ValidationResult(false, "Data de sfârșit nu este validă!");
          
            return ValidationResult.ValidResult;
        }

        public Wrapper StartDate { get; set; }
    }

    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty StartDateProperty =
             DependencyProperty.Register("StartDate", typeof(DateTime),
             typeof(Wrapper), new FrameworkPropertyMetadata(DateTime.Now));

        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }
    }
    public class BindingProxy : System.Windows.Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));
    }
}
