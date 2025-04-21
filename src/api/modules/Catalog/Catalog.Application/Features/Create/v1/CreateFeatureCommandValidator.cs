using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Create.v1;
public class CreateFeatureCommandValidator : AbstractValidator<CreateFeatureCommand>
{
    public CreateFeatureCommandValidator()
    {
        RuleFor(b => b.Name)
             .NotEmpty()
             .MinimumLength(2)
             .MaximumLength(100);

        RuleFor(b => b.Description)
            .MaximumLength(1000);

        RuleFor(b => b.ProductId)
            .NotEmpty()
            .Must(id => id != Guid.Empty)
            .WithMessage("ProductId must be a valid non-empty GUID.");

        RuleFor(b => b.ParentFeatureId)
            .Must(id => id == null || id != Guid.Empty)
            .WithMessage("ParentFeatureId, if specified, must be a valid non-empty GUID.");
    }
}
