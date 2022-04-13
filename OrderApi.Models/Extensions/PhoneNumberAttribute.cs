using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models.Extensions
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;

            if (!PhoneNumberValidator.IsNumberValid(order.PhoneNumber))
            {
                return new ValidationResult($"Phone number={order.PhoneNumber} has invalid format.");
            }

            return ValidationResult.Success;
        }
    }
}
