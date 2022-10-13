using FluentValidation;

namespace Application.Validators;

public class PostProductValidator : AbstractValidator<PostBoxDTO>
{
    public PostProductValidator()
    {
        RuleFor(p => p.Material).NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Length).GreaterThan(0);
        RuleFor(p => p.Width).GreaterThan(0);
    }
}