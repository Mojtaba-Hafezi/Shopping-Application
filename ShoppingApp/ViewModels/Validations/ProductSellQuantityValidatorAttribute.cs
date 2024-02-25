﻿using ShoppingApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.ViewModels.Validations
{
    public class ProductSellQuantityValidatorAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
            if(salesViewModel != null)
            {
                if(salesViewModel.QuantityToSell<=0)
                {
                    return new ValidationResult("The quantity to sell should be greater than zero");
                }
                var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                if(product != null)
                {
                    if(product.Quantity < salesViewModel.QuantityToSell)
                    {
                        return new ValidationResult($"Product {product.Name} has only {product.Quantity} left");
                    }
                }
                else
                {
                    return new ValidationResult("The selected product doesn't exist");
                }
            }
            return ValidationResult.Success;
        }
    }
}