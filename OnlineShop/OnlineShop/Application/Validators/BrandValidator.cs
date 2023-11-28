using FluentValidation;
using OnlineShop.Domain.Entity;

namespace OnlineShop.Application.Validators;

public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {
        RuleFor(b => b.BrandName).NotEmpty().MaximumLength(50).Matches("^[a-zA-Z0-9_-]+$");
        RuleFor(b => b.BrandId).NotEmpty().InclusiveBetween(0,long.MaxValue);
    }
}