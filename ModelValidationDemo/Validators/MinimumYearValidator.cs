using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo.Validators
{
    public class MinimumYearValidator : ValidationAttribute
    {
        public static int MinimumYear { get; set; } = 2000;
        public static int MaximumYear { get; set; } = 2023;

        public string DeafultErrorMessage { get; set; } = $"Default Error Message {MinimumYear} <> {MaximumYear}";

        public MinimumYearValidator() : base()
        {
            //string errormsg = base.ErrorMessage = $"Default Error Message {MinimumYear} <> {MaximumYear}";
        }
        public MinimumYearValidator(int minimumYear, int maximumYear)
        {
                MinimumYear = minimumYear;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear && date.Year < MaximumYear)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DeafultErrorMessage, MinimumYear, MaximumYear));
                }
            }
            else
            {
                return null;
            }
        }
    }
}
