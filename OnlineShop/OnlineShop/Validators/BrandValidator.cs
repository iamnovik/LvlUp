using FluentValidation;
using OnlineShop.Models.ScaffDir;

namespace OnlineShop.Validators;

public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {
        RuleFor(b => b.BrandName).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9_-]+$");
        RuleFor(b => b.BrandId).NotEmpty().InclusiveBetween(0,long.MaxValue);
    }
}