using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostBoxValidator : AbstractValidator<PostBoxDTO>
{
    public PostBoxValidator()
    {
        RuleFor(p => p.Material).NotEmpty().NotNull();
        RuleFor(p => p.Price).GreaterThan(0).NotNull().NotEmpty();
        RuleFor(p => p.Length).GreaterThan(0).NotNull().NotEmpty();
        RuleFor(p => p.Width).GreaterThan(0).NotNull().NotEmpty();
        RuleFor(p => p.Height).GreaterThan(0).NotNull().NotEmpty();
    }
}