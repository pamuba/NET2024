using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationDemo.Validators
{
    public class DateRangeValidator : ValidationAttribute
    {
        public string? OtherPropertyName { get; set; }
        public DateRangeValidator(string? otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime to_date = Convert.ToDateTime(value);
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    }
                }
                return null;
            }
            return null;
        }
    }
}
