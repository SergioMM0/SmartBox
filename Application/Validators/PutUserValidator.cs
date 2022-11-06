using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class PutUserValidator : AbstractValidator<PutUserDTO>
{
    public PutUserValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
        RuleFor(p => p.Name).NotEmpty().NotNull();
        When(u => u.Password is { Length: > 0 }, () =>
        {
            RuleFor(p => p.Password).NotNull();
        });
    }
}