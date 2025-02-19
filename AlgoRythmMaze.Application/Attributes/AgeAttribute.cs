using System.ComponentModel.DataAnnotations;

namespace TopiTopi.Application.Attributes
{
    public class AgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public AgeAttribute(int minAge)
        {
            _minAge = minAge;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                int age = DateTime.Now.Year - dateOfBirth.Year;

                if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                if (age < _minAge)
                {
                    return new ValidationResult($"Minimum age for the caregivers is {_minAge}.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
