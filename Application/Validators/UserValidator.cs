using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(p => p.id).NotEmpty().NotNull();
        RuleFor(p => p.Name).NotEmpty().NotNull();
    }
}