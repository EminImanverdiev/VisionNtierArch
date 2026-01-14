using Entities.DTOs.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.Products
{
    public class CreateProductDtoValidator: AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name is required.").MinimumLength(2).WithMessage("Product name must not exceed 100 characters.");
        }
    }
}
