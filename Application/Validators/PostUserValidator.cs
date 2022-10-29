using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class PostUserValidator : AbstractValidator<PostUserDTO>
{
    public PostUserValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull();
        RuleFor(p => p.Password).NotEmpty().NotNull();
    }
}