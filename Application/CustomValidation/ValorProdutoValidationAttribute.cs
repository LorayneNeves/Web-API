using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomValidation
{
    public class ValorProdutoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is decimal decimalValue && decimalValue <= 0)
            {
                return new ValidationResult("O valor do produto deve ser maior que zero.");
            }

            return ValidationResult.Success;
        }
    }
}