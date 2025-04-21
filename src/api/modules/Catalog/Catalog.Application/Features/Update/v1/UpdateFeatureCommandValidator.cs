using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Update.v1;
public class UpdateFeatureCommandValidator : AbstractValidator<UpdateFeatureCommand>
{
    public UpdateFeatureCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(b => b.Description).MaximumLength(1000);
    }
}
