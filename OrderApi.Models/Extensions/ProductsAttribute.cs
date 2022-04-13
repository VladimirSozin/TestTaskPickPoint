using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models.Extensions
{
    public class ProductsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;

            if (order.Products.Count > 10)
            {
                return new ValidationResult($"Products count is more than 10.");
            }

            return ValidationResult.Success;
        }
    }
}