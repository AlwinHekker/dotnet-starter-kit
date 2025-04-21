using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Products.Create.v1;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(75);

        RuleFor(p => p.Price)
            .GreaterThan(0);

        RuleFor(p => p.Description)
            .MaximumLength(1000);

        RuleFor(p => p.MetaTitle)
            .MaximumLength(150);

        RuleFor(p => p.MetaDescription)
            .MaximumLength(300);

        RuleFor(p => p.MetaKeywords)
            .MaximumLength(200);

        RuleFor(p => p.ProductFamily)
            .MaximumLength(100);

        // Optional: You may want to validate BrandId if required (e.g., not Guid.Empty)
        RuleFor(p => p.BrandId)
            .Must(id => id == null || id != Guid.Empty)
            .WithMessage("BrandId, if specified, must be a valid non-empty GUID.");

        // Optionally, add validation for date ranges
        RuleFor(p => p)
            .Must(p => !p.ValidFrom.HasValue || !p.ValidTo.HasValue || p.ValidFrom <= p.ValidTo)
            .WithMessage("ValidFrom must be earlier than or equal to ValidTo.");
    }
}
