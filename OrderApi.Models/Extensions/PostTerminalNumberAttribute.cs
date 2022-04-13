using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models.Extensions
{
    public class PostTerminalNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;

            if (!PostTerminalNumberValidator.IsNumberValid(order.PostTerminalNumber))
            {
                return new ValidationResult($"Post terminal number={order.PostTerminalNumber} has invalid format.");
            }

            return ValidationResult.Success;
        }
    }
}
