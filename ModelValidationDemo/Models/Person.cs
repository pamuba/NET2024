using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationDemo.Validators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo.Models
{
    public class Person :IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [StringLength(40, MinimumLength=3, ErrorMessage = "{0} shold be of length >3 and < 40")]
        [Display(Name="Person Name")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} shold alphabets, space or .")]
        public string? PersonName { get; set; }

        //[BindNever]
        [ValidateNever]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "{0} is not a proper email")]
        //[EmailAddress(ErrorMessage = "{0} is not a proper email")]
        public string? Email { get; set; }


        [Phone(ErrorMessage = "{0} is not a proper number")]
        public string? Phone { get; set; }


        [Required(ErrorMessage = "{0} can't be empty")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "{0} can't be empty")]
        [Compare("Password", ErrorMessage = "{0} and {1} should be same")]
        public string? ConfirmPassword { get; set; }


        [Range(10, 1000, ErrorMessage = "{0} should be between {1} and {2}")]
        public double? Price { get; set; }

        //[MinimumYearValidator(2000 , 2023, ErrorMessage = "Date Of Birth should not be newer than Jan 01, {0} and older than Jan 01, {1}")]
        [MinimumYearValidator]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }
        [DateRangeValidator("FromDate", ErrorMessage="'FromDate' sholud be older than or equal to 'ToDate'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"{PersonName} {Email} {Phone} {Password} {ConfirmPassword} {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of 'DateOfBirth' or 'Age' has to be specified.", new[] { nameof(Age) });
            }
        }
    }
}
