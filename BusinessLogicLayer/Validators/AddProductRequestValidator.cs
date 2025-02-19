using BusinessLogicLayer.DTO;
using FluentValidation;

namespace BusinessLogicLayer.Validators;
public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
{
    public AddProductRequestValidator()
    {
        RuleFor(temp => temp.ProductName)
            .NotEmpty().WithMessage("Product name is required");
        RuleFor(temp => temp.Category)
            .NotEmpty().WithMessage("Category is required");
        RuleFor(temp => temp.UnitPrice)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price value must be greather than 0");
    }
}
