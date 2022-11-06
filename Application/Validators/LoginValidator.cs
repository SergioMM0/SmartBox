using Domain;
using FluentValidation;

namespace Application.Validators;

public class LoginValidator : AbstractValidator<User>
{
    public LoginValidator()
    {
        RuleFor(o => o.Name).NotNull();
        RuleFor(o => o.Password).NotEmpty().NotNull();
    }
}