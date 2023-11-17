using FluentValidation;
using online_s.ScaffDir;

namespace online_s.Validators;

public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {
        RuleFor(b => b.BrandName).NotEmpty().MaximumLength(50);
        RuleFor(b => b.BrandId).NotEmpty();
    }
}