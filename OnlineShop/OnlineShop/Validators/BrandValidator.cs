using FluentValidation;
using OnlineShop.Models.ScaffDir;

namespace OnlineShop.Validators;

public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {
        RuleFor(b => b.BrandName).NotEmpty().MaximumLength(50);
        RuleFor(b => b.BrandId).NotEmpty();
    }
}