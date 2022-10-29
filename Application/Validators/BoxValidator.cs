using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class BoxValidator : AbstractValidator<Box>
{
    public BoxValidator()
    {
        RuleFor(p => p.Id).NotNull();
        RuleFor(p => p.Material).NotEmpty().NotNull();
        RuleFor(p => p.Price).GreaterThan(0).NotNull().NotEmpty();
        RuleFor(p => p.Length).GreaterThan(0).NotNull().NotEmpty();
        RuleFor(p => p.Width).GreaterThan(0).NotNull().NotEmpty();
        RuleFor(p => p.Height).GreaterThan(0).NotNull().NotEmpty();
    }
}